using System;
using System.Globalization;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string dataaaaaaaaa = "2021-10-04 07:45           ";
            dataaaaaaaaa = dataaaaaaaaa.TrimEnd();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            var newDate = DateTime.ParseExact(dataaaaaaaaa, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            if (newDate > yesterday)
            {
                Console.WriteLine("do sth");
            }
            else
            {
                Console.WriteLine("break");
            }
            Console.ReadLine();
        }
    }
}
