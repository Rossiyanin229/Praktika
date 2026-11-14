using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class PromoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price)
    {
        return price * 0.8m; 
    }
}