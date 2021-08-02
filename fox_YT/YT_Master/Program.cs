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

namespace YT_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        static void rec_funck()
        {
            //------------------------------------------------------------WYCIAGANIE INFO Z BANKIERA--------------------------------------//
            /* 
            string url = @"https://www.bankier.pl/rynki/wiadomosci/";
            List<string> list_of_links = new List<string>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    string data = readStream.ReadToEnd();

                    int startIndex = 0;
                    for (int i = 0; i < 15; i++)
                    {
                        string dataaaaaa1 = _getParam(ref data, ref startIndex);
                        list_of_links.Add(dataaaaaa1);
                    }
                    response.Close();
                    readStream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */

            //------------------------------------------------------------LOGOWANIE SIE DO NOTION--------------------------------------//
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe -private ";
            FirefoxDriver driver = new FirefoxDriver(service);

            driver.Navigate().GoToUrl(@"https://www.notion.so/You-Tube-4bfa9a98d7bf4949b5a138293ace5782");
            //driver.FindElementsByClassName("notion-focusable")[0].Click();
            //-------------------------------------------------------------------------------------------------------------------------------//
            IWebElement passwordTextBox = driver.FindElement(By.Id("notion-email-input-1"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("pkubon2@gmail.com");
            driver.FindElementsByClassName("notion-focusable")[3].Click();
            passwordTextBox = driver.FindElement(By.Id("notion-password-input-2"));
            passwordTextBox.Clear();
            //-----------------------------------------------------------------------------------------PAMIETAJ ZEBY TO HASLO ZAREMOWAC PRZED PUSHEM !!!!!!!!!!!!!!!--------------------------------------//
            //-----------------------------------------------------------------------------------------todo - haslo w osobnym pliku ktory nie jest pushowany xD--------------------------------------//
            passwordTextBox.SendKeys("S--5");
            driver.FindElementsByClassName("notion-focusable")[3].Click();
            //-------------------------------------------------------------------------------------------------------------------------------//
            //driver.FindElementsByClassName("VfPpkd-vQzf8d")[0].Click(); 
            }
        static string _getParam(ref string body, ref int startIndex)
        {
            char critic = '"';
            string ret = "";
            string hrf = "entry-title\">\n                    <a href=\"";
            if (isNext(ref body, ref startIndex, hrf))
            {
                startIndex += hrf.Length;
                while (body[startIndex] != critic)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        static bool isNext(ref string body, ref int startIndex, string nextString)
        {
            for (int i = startIndex; i < body.Length; i++)
            {
                bool notOk = false;
                for (int j = 0; j < nextString.Length; j++)
                {
                    if (body[(i + j)] != nextString[j])
                    {
                        notOk = true;
                        break;
                    }
                }
                if (!notOk)
                {
                    startIndex = i;
                    return true;
                }
            }
            return false;
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


/*
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe -private ";
            FirefoxDriver driver = new FirefoxDriver(service);

            driver.Navigate().GoToUrl(url);
            */
//By data2 = By.ClassName("MuiButtonBase-root");
//driver.FindElement(data2).Click();
//var aaa = 
//driver.FindElementsByTagName("button")[0].Click();
//driver.FindElementById("cmp-iframe").Click();