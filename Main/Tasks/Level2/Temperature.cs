using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level2;


public class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
           
            if (value < -273.15)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Температура не может быть ниже абсолютного нуля (-273.15°C)");
            }
            _celsius = value;
        }
    }


    public double Fahrenheit
    {
        get => _celsius * 9 / 5 + 32;
    }

    public Temperature(double celsius)
    {
        Celsius = celsius; 
    }
}
