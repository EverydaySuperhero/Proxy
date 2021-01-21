using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            string result = null;
            int firstRecord = 1;
            while (true)
            {
                //создать запрос
                result+=WebConnector.GetResult("https://wss2.cex.ic.webuy.io/v3/boxes?categoryIds=[1001]&firstRecord={firstRecord}&count=50&sortBy=boxname&sortOrder=asc");
                firstRecord += 50;
                Thread.Sleep(500);
            }
        }
    }
}