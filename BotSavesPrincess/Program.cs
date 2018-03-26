using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotSavesPrincess
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());

            var grid = new string[m];
            for (var i = 0; i < m; i++)
            {
                grid[i] = Console.ReadLine();
            }

            DisplayPathtoPrincess(m, grid);
        }

        static void DisplayPathtoPrincess(int n, string[] grid)
        {
        }
    }
}
