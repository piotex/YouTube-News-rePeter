using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using YT_Master.Models;

namespace YT_Master.Communication.Slaves
{
    public class CommunicationNotionV2 : CommunicationNotionBasic
    {
        public static int last_New = 58;
        public static int last_Title = 30;
        public static int last_Link = 75;
        public static int last_IloscZnakow = 79;
        public static int last_IloscKoment = 82;
        public static int last_UntitledSzablon = 94;
        public static int last_RAW = 41;

        public void LogIn()
        {
            User user = new Xml.XmlReader_My().getNotionUser();
            IWebElement passwordTextBox = driver.FindElement(By.Id("notion-email-input-1"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(user.Email);
            driver.FindElementsByClassName("notion-focusable")[3].Click();
            passwordTextBox = driver.FindElement(By.Id("notion-password-input-2"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(user.Pwd);
            driver.FindElementsByClassName("notion-focusable")[3].Click();
        }
        //56
        public void AddScenario(PageRecord record)
        {
            driver.Navigate().GoToUrl(@"https://www.notion.so/YouTube-Automat-15c60d9e70384fdd9a6320ceacd5bac1");

            Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> no_fo = driver.FindElementsByClassName("notion-focusable");

            for (int i = last_New; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i].Text.ToString() == "New")
                {
                    last_New = i+4;
                    no_fo[i].Click();
                    break;
                }
            }
            Thread.Sleep(1000);


            //-------------Wpisy z bankiera---------------------------------------------------------//
            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = last_Title; i < no_fo.Count; i++)
            {
                if (no_fo[i - 1].Text == "Untitled" && no_fo[i + 1].Text == "")
                {
                    last_Title = i+2;
                    no_fo[i].SendKeys(record.Title);
                    break;
                }
            }

            try
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                for (int i = last_Link; i < no_fo.Count; i++)
                {
                    no_fo = driver.FindElementsByClassName("notion-focusable");
                    if (no_fo[i - 1].Text == "Link")
                    {
                        last_Link = i+4;
                        no_fo[i].Click();
                        driver.FindElementsByTagName("input")[0].SendKeys(record.Link + Keys.Enter);
                        break;
                    }
                }
                for (int i = last_IloscZnakow; i < no_fo.Count; i++)
                {
                    no_fo = driver.FindElementsByClassName("notion-focusable");
                    if (no_fo[i - 1].Text == "Ilość znaków")
                    {
                        last_IloscZnakow = i+4;
                        no_fo[i].Click();
                        driver.FindElementsByTagName("input")[0].SendKeys(record.Text.Length + Keys.Enter);
                        break;
                    }
                }
                for (int i = last_IloscKoment; i < no_fo.Count; i++)
                {
                    no_fo = driver.FindElementsByClassName("notion-focusable");
                    if (no_fo[i - 1].Text == "Ilość komentarzy")
                    {
                        last_IloscKoment = i+4;
                        no_fo[i].Click();
                        driver.FindElementsByTagName("input")[0].SendKeys(record.CommentCount + Keys.Enter);
                        break;
                    }
                }
                for (int i = last_UntitledSzablon; i < no_fo.Count; i++)
                {
                    no_fo = driver.FindElementsByClassName("notion-focusable");
                    if (no_fo[i - 1].Text.ToLower() == "untitled")
                    {
                        last_UntitledSzablon = i+4;
                        no_fo[i - 1].Click();
                        break;
                    }
                }
            }
            catch (Exception eeee)
            {
            }

            Thread.Sleep(2000);

            var textt = record.Text.Split('.');

            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = last_RAW; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notranslate");
                if (no_fo[i-1].Text.ToString().Contains("R.A.W"))
                {
                    last_RAW = i +2;
                    no_fo[i].Click();

                    Thread.Sleep(1000);

                    for (int j = textt.Length-1; j >= 0; j--)
                    {
                        no_fo[i].SendKeys(textt[j] + Keys.Enter);
                    }
                    break;
                }
            }

            
        }
    }
}




/*
            List<string> l_trans = new List<string>();
            no_fo = driver.FindElementsByClassName("notranslate");
            for (int j = 0; j < no_fo.Count; j++)
            {
                l_trans.Add(no_fo[j].Text.ToString());
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\rePeter---youtube-chanel-manager\fox_YT\YT_Master\Files\notranslate.txt"))
            {
                for (int i = 0; i < l_trans.Count; i++)
                {
                    writer.WriteLine(l_trans[i]);
                }
            }
            */