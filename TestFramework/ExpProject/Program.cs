﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.AddDays(15));
            if (DateTime.Now.AddDays(15) > DateTime.Now) {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine(new DateTime(1996,09,29).ToString());
            Console.WriteLine(DateTime.Now.ToString("MMMM"));
        }
    }
}
