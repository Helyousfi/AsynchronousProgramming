using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitProject_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WebClient client = new WebClient();
            string data = client.DownloadString("https://github.com/");

            Console.WriteLine(data.Length);

            Console.ReadLine();
        }
    }
}
