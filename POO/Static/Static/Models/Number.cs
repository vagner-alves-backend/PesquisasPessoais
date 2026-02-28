using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Static.Models
{
    public static class Number
    {
        public static int Inteiro (this string? value)
        {
            if (!int.TryParse(value, out int number))
            {
                number = 0;
            }
            return number;
        } 
    }
}