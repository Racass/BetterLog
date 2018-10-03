using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    static class Robo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating test");
            Controller myLog = new Controller(1);
            for (int i = 0; i < 50000; i++)
            {
                myLog.WriteLog("<" + i.ToString() + ">");
                if (i % 100 == 0)
                    Console.WriteLine("<" + i.ToString() + ">");
            }
            myLog.OpenMyForm();
            Console.ReadLine();
        }
    }
}
