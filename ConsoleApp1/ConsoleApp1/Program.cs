using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
        public int Distance(int x, int y)
        {
            if (x >= y)
            {
                return x - y;
            }
            else
            {
                return y - x;
            }
        }
    }
}
