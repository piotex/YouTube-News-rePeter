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
using YT_Master.Communication.Basic;
using YT_Master.Communication.Slaves;
using YT_Master.Models;
using YT_Master.Operations.Slaves;

namespace YT_Master
{
    class Program
    {
        private static int pageCount = 10;
        static void Main(string[] args)
        {
            CommunicationNotionV2 tmp;
            CommunicationBasic bb;
            List<string> Linki;
            try
            {
                Linki = addLinks();
                bb = new CommunicationBasic();
                tmp = new CommunicationNotionV2();
            }
            catch (Exception eee)
            {
                wywaliloSie(eee.Message);

                Linki = addLinks();
                bb = new CommunicationBasic();
                tmp = new CommunicationNotionV2();
            }

            Console.WriteLine("\n---------------------------------\n");
            Console.WriteLine("Start: " + DateTime.Now);

            try
            {
                tmp.LogIn();
            }
            catch (Exception eee)
            {
                wywaliloSie(eee.Message);
                tmp.LogIn();
            }

            for (int i = 0; i < Linki.Count; i++)
            {
                PageRecord record = new PageRecord();
                
                try
                {
                    string body = bb.GetBody(Linki[i]);
                    string content = new OperationGetContent().GetContent(body);

                    record.Link = Linki[i];
                    record.Title = new OperationGetTitle().GetTitleFromText(content);
                    record.Date = new OperationGetPublicationDate().GetDate(content);
                    record.Text = new OperationGetText().GetText(content);
                    record.CommentCount = new OperationGetKomensCount().GetCommentsCount(content);
                }
                catch (Exception eee)
                {
                    wywaliloSie(eee.Message);

                    string body = bb.GetBody(Linki[i]);
                    string content = new OperationGetContent().GetContent(body);

                    record.Link = Linki[i];
                    record.Title = new OperationGetTitle().GetTitleFromText(content);
                    record.Date = new OperationGetPublicationDate().GetDate(content);
                    record.Text = new OperationGetText().GetText(content);
                    record.CommentCount = new OperationGetKomensCount().GetCommentsCount(content);
                }
                try
                {
                    tmp.AddScenario(record);
                }
                catch (Exception eee)
                {
                    wywaliloSie(eee.Message);
                    tmp.AddScenario(record);
                }

                Console.WriteLine(DateTime.Now + "   Ilość dodanych recordow:   " + (i+1).ToString() );
            }
            Console.WriteLine("End: " + DateTime.Now);

            Console.ReadLine();

        }
        public static void wywaliloSie(string eee)
        {
            Console.WriteLine("\n---------------------------------\n");
            Console.WriteLine("\n----------Wywalilo sie-----------\n");
            Console.WriteLine(eee);
            Console.WriteLine("\n---------------------------------\n");
        }

        public static List<string> addLinks()
        {
            List<string> Linki = new List<string>();

            for (int pageNumger = 1; pageNumger <= pageCount; pageNumger++)
            {
                string pageHtml = new CommunicationBankier().GetBodyBankierNews(pageNumger);
                List<string> data = new OperationGetLinks().GetLinks(pageHtml);

                for (int j = 0; j < data.Count; j++)
                {
                    Linki.Add("https://www.bankier.pl" + data[j]);
                }
            }
            return Linki;
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

