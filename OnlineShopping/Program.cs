using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static decimal CalculatePrice(string item, int quantity)
        {
            switch (item)
            {
                case "A99":
                    return quantity * 50 - ((quantity / 3) * 20);
                case "B15":
                    return quantity * 30 - ((quantity / 2) * 15);
                case "C40":
                    return 60;
                case "T34":
                    return 99;
                default:
                    return 0;
            }
        }
    }
}
