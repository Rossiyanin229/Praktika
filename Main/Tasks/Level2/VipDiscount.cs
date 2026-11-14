using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class VipDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price)
    {
        return price * 0.9m; 
    }
}
