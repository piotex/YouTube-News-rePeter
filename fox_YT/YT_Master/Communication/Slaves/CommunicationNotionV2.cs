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
        public void AddScenario()
        {
            driver.Navigate().GoToUrl(@"https://www.notion.so/YouTube-Automat-15c60d9e70384fdd9a6320ceacd5bac1");

            Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> no_fo = driver.FindElementsByClassName("notion-focusable");

            for (int i = 50; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i].Text.ToString() == "New")
                {
                    no_fo[i].Click();
                    break;
                }
            }
            Thread.Sleep(1000);


            //-------------Wpisy z bankiera---------------------------------------------------------//
            for (int i = 30; i < 500; i++)
            {
                try
                {
                    if (driver.FindElementsByClassName("notranslate")[i-1].Text == "Untitled" && driver.FindElementsByClassName("notranslate")[i+1].Text == "" )
                    {
                        driver.FindElementsByClassName("notranslate")[i].SendKeys("[Title xDDD " + i + "]");
                        break;
                    }
                }
                catch (Exception eee)
                {
                    if (i > 50)
                    {
                        break;
                    }
                }
            }
            
            try
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                for (int i = 74; i < no_fo.Count; i++)//i=88
                {
                    no_fo = driver.FindElementsByClassName("notion-focusable");
                    string text = no_fo[i - 1].Text.ToLower();
                    if (text == "link")
                    {
                        no_fo[i].Click();
                        driver.FindElementsByTagName("input")[0].SendKeys("bankier.pl" + Keys.Enter);
                    }
                    if (text == "ilość znaków")
                    {
                        no_fo[i].Click();
                        driver.FindElementsByTagName("input")[0].SendKeys("99" + Keys.Enter);
                    }
                    if (text == "ilość komentarzy")
                    {
                        no_fo[i].Click();
                        driver.FindElementsByTagName("input")[0].SendKeys("1" + Keys.Enter);
                    }
                    if (text == "untitled")
                    {
                        no_fo[i - 1].Click();
                        break;
                    }
                }
            }
            catch (Exception eeee)
            {
            }

            Thread.Sleep(2000);

            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = 39; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notranslate");
                if (no_fo[i-1].Text.ToString().Contains("R.A.W"))
                {
                    no_fo[i].Click();
                    no_fo[i].SendKeys("bla bla text" + Keys.Enter);
                    no_fo[i].SendKeys("bla bla text" + Keys.Enter);
                    break;
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
        }
    }
}




