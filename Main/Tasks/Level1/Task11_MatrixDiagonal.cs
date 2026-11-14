using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level1;

[TaskInfo(11, "Диагональ матрицы N×N",
    "Найти сумму элементов главной диагонали матрицы N×N.",
    "Размер N вводится пользователем (минимум 2)",
    "Матрица заполняется случайными числами",
    "Сумма считается без LINQ, в одном цикле for",
    "Вывести саму матрицу и сумму")]
public class Task11_MatrixDiagonal : ITask
{
    public void Run()
    {
        int n;
        Console.Write("Введите размер матрицы N (минимум 2): ");

        
        while (!int.TryParse(Console.ReadLine(), out n) || n < 2)
        {
            Console.Write("Ошибка! Введите целое число не меньше 2: ");
        }

        
        int[,] matrix = new int[n, n];
        Random rnd = new Random();

        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(1, 10);
            }
        }

        
        Console.WriteLine("\nМатрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],3}");
            }
            Console.WriteLine();
        }

        
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += matrix[i, i];
        }

        Console.WriteLine($"\nСумма элементов главной диагонали: {sum}");
    }
}
