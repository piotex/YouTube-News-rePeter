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
        public static int last_New              = 52; //= 58;56
        public static int last_Title            = 30; //= 30;32
        public static int last_Link             = 73; //= 75;77
        public static int last_IloscZnakow      = 77; //= 79;81
        public static int last_IloscKoment      = 80; //= 82;84
        public static int last_UntitledSzablon  = 90; //= 94;94
        public static int last_RAW              = 39; //= 41;43

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

            click_New(ref no_fo, record);

            Thread.Sleep(1000);

            //-------------Wpisy z bankiera---------------------------------------------------------//
            add_Title(ref no_fo, record);

            no_fo = driver.FindElementsByClassName("notion-focusable");

            add_Link(ref no_fo, record);
            add_CharCount(ref no_fo, record);
            add_ComentCount(ref no_fo, record);
            click_Template(ref no_fo, record);

            Thread.Sleep(2000);

            add_Text(ref no_fo, record);
        }

        public void click_New(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            for (int i = last_New; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i].Text.ToString() == "New")
                {
                    last_New = i + 4;
                    no_fo[i].Click();
                    break;
                }
            }
        }
        public void add_Title(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = last_Title; i < no_fo.Count; i++)
            {
                if (no_fo[i - 1].Text == "Untitled" && no_fo[i + 1].Text == "")
                {
                    last_Title = i + 2;
                    no_fo[i].SendKeys(record.Title);
                    no_fo[i + 1].SendKeys("Dodano do bankiera: " + record.Date);
                    break;
                }
            }
        }
        public void add_Link(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            for (int i = last_Link; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i - 1].Text == "Link")
                {
                    last_Link = i + 4;
                    no_fo[i].Click();
                    driver.FindElementsByTagName("input")[0].SendKeys(record.Link + Keys.Enter);
                    break;
                }
            }
        }
        public void add_CharCount(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            for (int i = last_IloscZnakow; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i - 1].Text == "Ilość znaków")
                {
                    last_IloscZnakow = i + 4;
                    no_fo[i].Click();
                    driver.FindElementsByTagName("input")[0].SendKeys(record.Text.Length + Keys.Enter);
                    break;
                }
            }
        }
        public void add_ComentCount(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            for (int i = last_IloscKoment; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i - 1].Text == "Ilość komentarzy")
                {
                    last_IloscKoment = i + 4;
                    no_fo[i].Click();
                    driver.FindElementsByTagName("input")[0].SendKeys(record.CommentCount + Keys.Enter);
                    break;
                }
            }
        }
        public void click_Template(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            for (int i = last_UntitledSzablon; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i - 1].Text.ToLower() == "untitled")
                {
                    last_UntitledSzablon = i + 4;
                    no_fo[i - 1].Click();
                    break;
                }
            }
        }

        public void add_Text(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            var textt = record.Text.Split('.');

            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = last_RAW; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notranslate");
                if (no_fo[i - 1].Text.ToString().Contains("R.A.W"))
                {
                    last_RAW = i + 2;
                    no_fo[i].Click();

                    Thread.Sleep(1000);

                    for (int j = textt.Length - 1; j >= 0; j--)
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