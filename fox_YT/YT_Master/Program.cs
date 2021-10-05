using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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


// ToDo: api!
//https://developers.notion.com/reference/intro
//https://developers.notion.com/docs/getting-started
//https://www.notion.so/guides/connect-tools-to-notion-api



namespace YT_Master
{
    class Program
    {
        private static int pageCount = 10;
        static void Main(string[] args)
        {
            initMessage();
            try
            {
                CommunicationNotionV2 tmp = new CommunicationNotionV2();
                List<string> Links = addLinks();
                tryLogIn(ref tmp);

                for (int i = 0; i < Links.Count; i++)
                {
                    PageRecord record = new PageRecord();
                    trySetRecord(ref record, Links[i]);

                    if (!falidDate(ref record))
                    {
                        break;
                    }
                    tryAddRecordToNotionDatabase(ref tmp, ref record);

                    Console.WriteLine(DateTime.Now + "   Ilość dodanych recordow:   " + (i + 1).ToString());
                }

            }
            catch (Exception eee)
            {
                wywaliloSie(eee.Message, "BIG trY");
            }
            
            Console.WriteLine("End: " + DateTime.Now);
            Console.ReadLine();

        }

        public static void initMessage()
        {
            Console.WriteLine("\n-------Zbieranie Newsow---------\n");
            Console.WriteLine("\n--------------------------------\n");
            Console.WriteLine("Start: " + DateTime.Now);
        }
        public static bool falidDate(ref PageRecord record)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime recordDate = DateTime.ParseExact(record.Date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            return (recordDate > yesterday);
        }
        public static void tryLogIn(ref CommunicationNotionV2 tmp)
        {
            try
            {
                tmp.LogIn();
            }
            catch (Exception eee)
            {
                wywaliloSie(eee.Message, "Login");
                tmp.LogIn();
            }
        }
        public static void tryAddRecordToNotionDatabase(ref CommunicationNotionV2 tmp, ref PageRecord record)
        {
            try
            {
                tmp.AddRecordToNotionDatabase(record);
            }
            catch (Exception eee)
            {
                wywaliloSie(eee.Message);
                tmp.AddRecordToNotionDatabase(record);            //try one more time
            }
        }
        public static void trySetRecord(ref PageRecord record, string link)
        {
            try
            {
                setRecord(ref record, link);
            }
            catch (Exception eee)
            {
                wywaliloSie(eee.Message);
                setRecord(ref record, link);                  //try one more time
            }
        }
        public static int setRecord(ref PageRecord record, string link)
        {
            string body = new CommunicationBasic().GetBody(link);
            string content = new OperationGetContent().GetContent(body);

            record.Link = link;
            record.Title = new OperationGetTitle().GetTitleFromText(content);
            record.Date = new OperationGetPublicationDate().GetDate(content);
            record.Text = new OperationGetText().GetText(content);
            record.CommentCount = new OperationGetKomensCount().GetCommentsCount(content);
            
            return 0;
        }
        public static void wywaliloSie(string eee,string privMsg="")
        {
            Console.WriteLine("\n---------------------------------\n");
            Console.WriteLine("\n----------Wywalilo sie-----------\n");
            Console.WriteLine(privMsg);
            Console.WriteLine("\n---------------------------------\n");
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

