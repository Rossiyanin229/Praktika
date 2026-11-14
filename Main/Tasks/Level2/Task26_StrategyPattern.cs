using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Common;

namespace Main.Tasks.Level2;

[TaskInfo(26, "Паттерн «Стратегия» (скидки)",
    "Реализовать калькулятор скидок через паттерн «Стратегия».",
    "Интерфейс IDiscountStrategy с методом Apply(decimal price)",
    "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%)",
    "Класс PriceCalculator, принимающий стратегию в конструкторе",
    "Продемонстрировать расчёт цены с каждой стратегией")]
public class Task26_StrategyPattern : ITask
{
    public void Run()
    {
        decimal basePrice = 1000m;

        Console.WriteLine($"Базовая цена: {basePrice} руб.\n");

        var calculator1 = new PriceCalculator(new NoDiscount());
        Console.WriteLine($"Без скидки: {calculator1.Calculate(basePrice)} руб.");

        
        var calculator2 = new PriceCalculator(new VipDiscount());
        Console.WriteLine($"VIP-скидка (10%): {calculator2.Calculate(basePrice)} руб.");

        
        var calculator3 = new PriceCalculator(new PromoDiscount());
        Console.WriteLine($"Промо-скидка (20%): {calculator3.Calculate(basePrice)} руб.");
    }
}
