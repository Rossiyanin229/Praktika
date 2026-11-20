using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;
using Microsoft.Data.SqlClient;

namespace Main.Database;

[TaskInfo(28, "C# + SQL: подключение и SELECT",
    "Подключить консольное приложение к PracticeDB и выполнить запрос.",
    "NuGet-пакет Microsoft.Data.SqlClient",
    "Строка подключения — из переменной окружения PRACTICE_DB_CONNECTION",
    "Асинхронное открытие соединения (OpenAsync)",
    "Запрос SELECT EmployeeName, Salary FROM Employees",
    "Вывод через SqlDataReader",
    "Обработка SqlException")]
public class Task28_SqlSelect : ITask
{
    public void Run()
    {
        
        string connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION")
            ?? @"Server=localhost\SQLEXPRESS02;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        string query = "SELECT EmployeeName, Salary FROM Employees";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Сотрудники в базе данных:");
                    Console.WriteLine("-------------------------");
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        decimal salary = reader.GetDecimal(1);
                        Console.WriteLine($"{name,-20} | {salary,10:F2}");
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Ошибка SQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }
    }
}
