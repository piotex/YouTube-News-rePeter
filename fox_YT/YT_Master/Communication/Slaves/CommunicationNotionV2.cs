﻿using OpenQA.Selenium;
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
        public static int last_New              = 53; 

        public static int last_Title            = 34; // 34 36 ... 132
        public static int last_Link             = 80; // 80 83 ... 230
        public static int last_IloscZnakow      = 84; // 84 87 ... 
        public static int last_IloscKoment      = 87; // 87 90 ... 236

        public static int last_UntitledSzablon  = 91; // 
        public static int last_RAW              = 41; // 

        public static int inc_last_Title            = 2; //2
        public static int inc_last_Link             = 3; //4
        public static int inc_last_IloscZnakow      = 3; //4
        public static int inc_last_IloscKoment      = 3; //4

        public static int inc_last_UntitledSzablon  = 1; //4
        public static int inc_last_RAW              = 1; //2

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
            //click_Template(ref no_fo, record);

            //Thread.Sleep(2000);

            //add_Text(ref no_fo, record);
        }

        public void click_New(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            no_fo = driver.FindElementsByClassName("notion-focusable");
            no_fo[last_New].Click();
        }
        public void add_Title(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = last_Title; i < no_fo.Count; i++)
            {
                if (no_fo[i].Text == "Untitled")
                {
                    if (i < 131)
                    {
                        last_Title = i + inc_last_Title;
                        no_fo[i - 3].SendKeys(record.Title);                            //i=131
                        no_fo[i - 2].SendKeys("Dodano do bankiera: " + record.Date);
                    }
                    else
                    {
                        last_Title = i;
                        no_fo[i - 3].SendKeys(record.Title);                            //i=131
                        no_fo[i - 2].SendKeys("Dodano do bankiera: " + record.Date);
                    }
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
                    no_fo[i].Click();
                    driver.FindElementsByTagName("input")[0].SendKeys(record.Link + Keys.Enter);
                    if (i + inc_last_Link < 228)
                    {
                        last_Link = i + inc_last_Link;
                    }
                    else
                    {
                        last_Link = i;
                    }
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
                    no_fo[i].Click();
                    driver.FindElementsByTagName("input")[0].SendKeys(record.Text.Length + Keys.Enter);
                    if (i + inc_last_IloscZnakow < 231)
                    {
                        last_IloscZnakow = i + inc_last_IloscZnakow;
                    }
                    else
                    {
                        last_IloscZnakow = i;
                    }
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
                    no_fo[i].Click();
                    driver.FindElementsByTagName("input")[0].SendKeys(record.CommentCount + Keys.Enter);
                    if (i + inc_last_IloscKoment < 234)
                    {
                        last_IloscKoment = i + inc_last_IloscKoment;
                    }
                    else
                    {
                        last_IloscKoment = i;
                    }
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
                    no_fo[i - 1].Click();
                    if (i + inc_last_UntitledSzablon < 239)
                    {
                        last_UntitledSzablon = i + inc_last_UntitledSzablon;
                    }
                    break;
                }
            }
        }

        public void add_Text(ref ReadOnlyCollection<IWebElement> no_fo, PageRecord record)
        {
            record.Text = record.Text.Replace("-"," -");
            record.Text = record.Text.Replace("\""," \"");
            var textt = record.Text.Split('.');

            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = last_RAW; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notranslate");
                if (no_fo[i - 1].Text.ToString().Contains("R.A.W"))
                {
                    last_RAW = i + inc_last_RAW;
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