using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class PriceCalculator
{
    private readonly IDiscountStrategy _strategy;

    
    public PriceCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal Calculate(decimal price)
    {
        return _strategy.Apply(price);
    }
}
