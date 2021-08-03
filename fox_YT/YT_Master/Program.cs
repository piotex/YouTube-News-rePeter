using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YT_Master.Communication.Slaves;

namespace YT_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            CommunicationNotion tmp = new CommunicationNotion();
            tmp.LogIn();
            tmp.AddScenario();
            Console.ReadLine();
        }

        static void kill_firefox()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                    string s = process.ProcessName.ToLower();
                    if (s == "firefox")                                                //  s == "iexplore" || s == "iexplorer" || s == "chrome" ||
                        process.Kill();
                }
            }
        }
    }
}

