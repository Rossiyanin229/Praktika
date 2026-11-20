using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;
using Microsoft.Data.SqlClient;

namespace Main.Database;

[TaskInfo(30, "C# + SQL: мини-отчёт по отделам",
    "Вывести отчёт по отделам из C#-приложения.",
    "Запрос с LEFT JOIN, COUNT, AVG и GROUP BY",
    "Выполнить через SqlCommand.ExecuteReader",
    "Вывести в консоль таблицей с выравниванием",
    "Для NULL (отдел без сотрудников) — 0 или N/A",
    "Обработать пустой результат")]
public class Task30_SqlReport : ITask
{
    private readonly string _connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION")
        ?? @"Server=localhost\SQLEXPRESS02;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public void Run()
    {
        string query = @"
            SELECT 
                d.DepartmentName, 
                COUNT(e.EmployeeId) AS EmpCount, 
                AVG(e.Salary) AS AvgSalary 
            FROM Departments d 
            LEFT JOIN Employees e ON d.DepartmentId = e.DepartmentId 
            GROUP BY d.DepartmentName
            ORDER BY d.DepartmentName";

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    Console.WriteLine($"{"Отдел",-15} | {"Сотрудников",12} | {"Средняя ЗП",12}");
                    Console.WriteLine(new string('-', 45));

                    bool hasRows = false;
                    while (reader.Read())
                    {
                        hasRows = true;
                        string deptName = reader.GetString(0);

                       
                        int empCount = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                        
                        string avgSalary = reader.IsDBNull(2)
                            ? "N/A"
                            : reader.GetDecimal(2).ToString("F2");

                        Console.WriteLine($"{deptName,-15} | {empCount,12} | {avgSalary,12}");
                    }

                    if (!hasRows)
                    {
                        Console.WriteLine("Нет данных для отображения.");
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Ошибка SQL: {ex.Message}");
        }
    }
}
