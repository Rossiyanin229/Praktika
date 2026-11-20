using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;
using Microsoft.Data.SqlClient;

namespace Main.Database;

[TaskInfo(29, "C# + SQL: параметризованный INSERT",
    "Добавить сотрудника из C#-приложения.",
    "Метод AddEmployee(string name, decimal salary, int departmentId)",
    "Параметризованный запрос (@name, @salary, @deptId) — без конкатенации (защита от SQL-инъекций)",
    "Выполнить INSERT INTO Employees ...",
    "После вставки — SELECT для подтверждения",
    "Обработать ошибки (FK violation, дубликат)")]
public class Task29_SqlInsert : ITask
{
    private readonly string _connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION")
        ?? @"Server=localhost\SQLEXPRESS02;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public void Run()
    {
        
        AddEmployee("Тестовый Сотрудник", 50000m, 1);

       
        ShowEmployee("Тестовый Сотрудник");
    }

    private void AddEmployee(string name, decimal salary, int departmentId)
    {
        
        string query = @"INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId, ManagerId) 
                         VALUES (@name, @salary, GETDATE(), @deptId, NULL)";

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@salary", salary);
                    command.Parameters.AddWithValue("@deptId", departmentId);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Добавлено строк: {rowsAffected}");
                }
            }
        }
        catch (SqlException ex)
        {
          
            Console.WriteLine($"Ошибка SQL: {ex.Message}");
            if (ex.Number == 547) 
                Console.WriteLine("Ошибка: такого отдела не существует.");
        }
    }

    private void ShowEmployee(string name)
    {
        string query = "SELECT EmployeeId, EmployeeName, Salary, DepartmentId FROM Employees WHERE EmployeeName = @name";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32(0)}, Имя: {reader.GetString(1)}, Зарплата: {reader.GetDecimal(2)}, Отдел: {reader.GetInt32(3)}");
                    }
                }
            }
        }
    }
}
