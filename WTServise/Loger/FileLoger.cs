using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTServise.Loger
{
    public class FileLoger
    {
        public void Log(string messege)
        {
            Console.WriteLine(messege);
        }

        public void Log(string messege, string code)
        {
            Console.WriteLine(messege);
            Console.WriteLine(code);
        }
    }
}