using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.ES20;

namespace ForrestAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Distance(2, 6));
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