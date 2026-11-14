using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(17, "StringBuilder vs конкатенация (замер)",
    "Сравнить производительность конкатенации через + и StringBuilder.",
    "Собрать строку из 10 000 чисел двумя способами",
    "Замерить время каждого через Stopwatch",
    "Вывести оба времени и разницу",
    "Объяснить в комментарии, почему StringBuilder быстрее")]
public class Task17_StringBuilderVsConcat : ITask
{
    public void Run()
    {
        const int iterations = 10000;

        
        Stopwatch swConcat = Stopwatch.StartNew();
        string resultConcat = "";
        for (int i = 0; i < iterations; i++)
        {
            resultConcat += i.ToString();
        }
        swConcat.Stop();

        
        Stopwatch swBuilder = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append(i.ToString());
        }
        string resultBuilder = sb.ToString();
        swBuilder.Stop();

        
        Console.WriteLine($"Количество итераций: {iterations}");
        Console.WriteLine($"Конкатенация (+): {swConcat.ElapsedMilliseconds} мс");
        Console.WriteLine($"StringBuilder:    {swBuilder.ElapsedMilliseconds} мс");
        Console.WriteLine($"Разница:          {swConcat.ElapsedMilliseconds - swBuilder.ElapsedMilliseconds} мс");

       
        Console.WriteLine($"\nРезультаты равны по содержимому: {resultConcat == resultBuilder}");

        /*
         * ПОЧЕМУ STRINGBUILDER БЫСТРЕЕ?
         * 
         * Строки в C# (string) являются неизменяемыми (immutable). 
         * Это значит, что при каждой операции `result += i` создается НОВАЯ строка в памяти, 
         * а старая удаляется сборщиком мусора (GC). 
         * При 10 000 итерациях создается 10 000 строк, что вызывает огромную нагрузку на память и GC.
         * 
         * StringBuilder использует внутри изменяемый массив символов (буфер).
         * При вызове Append() он просто дописывает символы в конец этого массива. 
         * Если места не хватает, он увеличивает массив (обычно в 2 раза), копируя старые данные.
         * В итоге создается гораздо меньше объектов, и память расходуется эффективнее.
         */
    }
}
