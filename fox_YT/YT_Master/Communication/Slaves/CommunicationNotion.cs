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
    public class CommunicationNotion
    {
        protected FirefoxDriver driver;
        public CommunicationNotion()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe ";// -private ";
            driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl(@"https://www.notion.so/0fc3f946a59541c790e7cda4d6b1f4be?v=83248784be54426da17208d4ad1b11f4");
        }
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
            Thread.Sleep(2000);
            driver.FindElementsByClassName("notion-focusable")[52].Click();   // klikniecie wyboru templatki

            for (int i = 25; i < driver.FindElementsByClassName("notranslate").Count; i++)
            {
                var tmp = driver.FindElementsByClassName("notranslate")[i];
                if (tmp.Text == "Basic Template")
                {
                    tmp.Click();        // klikniecie Basic Template
                    Thread.Sleep(2000);
                    driver.FindElementsByClassName("notranslate")[i+1].SendKeys("[Title]");
                    driver.FindElementsByClassName("notranslate")[i+2].SendKeys("[Komentarz]");
                    break;
                }
            }

            ReadOnlyCollection<IWebElement> no_fo = driver.FindElementsByClassName("notion-focusable");
            for (int i = 145; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notion-focusable");
                if (no_fo[i].Text.ToString() == "New")
                {
                    no_fo[i].Click();
                    break;
                }
            }
            //-------------Wpisy z bankiera---------------------------------------------------------//
            try
            {
                driver.FindElementsByClassName("notranslate")[23].SendKeys("[Title3]");
                driver.FindElementsByClassName("notranslate")[24].SendKeys("[Title4]");
                driver.FindElementsByClassName("notranslate")[25].SendKeys("[Title5]");
                driver.FindElementsByClassName("notranslate")[26].SendKeys("[Title6]");
                driver.FindElementsByClassName("notranslate")[27].SendKeys("[Title7]");
                driver.FindElementsByClassName("notranslate")[28].SendKeys("[Title8*]");
            }
            catch (Exception)
            {
            }
            /*
            List<string> ddd = new List<string>();
            no_fo = driver.FindElementsByClassName("notranslate");
            for (int i = 0; i < no_fo.Count; i++)
            {
                no_fo = driver.FindElementsByClassName("notranslate");
                ddd.Add(no_fo[i].Text);
                if (no_fo[i].Text == "Untitled")
                {
                    no_fo[i].Click();
                    //no_fo[i].SendKeys("[Title]");
                }
            }
            */
            for (int i = 100; i < no_fo.Count; i++)
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
                if (i > 120 && text == "new")
                {
                    no_fo[i - 1].Click();
                    break;
                }
            }

            driver.FindElementsByClassName("notion-page-content")[0].Click();




            var trans = driver.FindElementsByClassName("notranslate");
            List<string> l_trans = new List<string>();
            for (int i = 0; i < trans.Count; i++)
            {
                l_trans.Add(trans[i].Text.ToString());
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\rePeter---youtube-chanel-manager\fox_YT\YT_Master\Files\notranslate.txt"))
            {
                for (int i = 0; i < l_trans.Count; i++)
                {
                    writer.WriteLine(l_trans[i]);
                }
            }


            /*
            List<string> l_focus = new List<string>();
            List<string> l_trans = new List<string>();


            for (int i = 0; i < focus.Count; i++)
            {
                l_focus.Add(focus[i].Text.ToString());
            }
            for (int i = 0; i < trans.Count; i++)
            {
                l_trans.Add(trans[i].Text.ToString());
            }

            using (StreamWriter writer = new StreamWriter(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\rePeter---youtube-chanel-manager\fox_YT\YT_Master\Files\notion-focusable.txt"))
            {
                for (int i = 0; i < l_focus.Count; i++)
                {
                    writer.WriteLine(l_focus[i]);
                }
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
/*
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\rePeter---youtube-chanel-manager\fox_YT\YT_Master\notranslate.txt"))
            {
                for (int i = 0; i < aaa_trans.Count; i++)
                {
                    writer.WriteLine(bbb_trans[i]);
                }
            }
*/
/*
IWebElement passwordTextBox = driver.FindElement(By.Id("notion-email-input-1"));
passwordTextBox = driver.FindElement(By.Id("notion-password-input-2"));
passwordTextBox.Clear();
passwordTextBox.SendKeys(user.Pwd);
driver.FindElementsByClassName("notion-focusable")[3].Click();
*/

/*
var focus = driver.FindElementsByClassName("notion-focusable");
            var trans = driver.FindElementsByClassName("notranslate");
            List<string> ttt = new List<string>();
            for (int i = 0; i < focus.Count; i++)
            {
                ttt.Add(focus[i].Text.ToString());
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\rePeter---youtube-chanel-manager\fox_YT\YT_Master\Files\notion-focusable.txt"))
            {
                for (int i = 0; i < ttt.Count; i++)
                {
                    writer.WriteLine(ttt[i]);
                }
            }
*/
/*
 if (text == "status")
                {
                    no_fo[i].Click();                             
                    driver.FindElementsByTagName("input")[0].SendKeys("N"); //apisać Scenariusz
                    for (int j = i; j < no_fo.Count; j++)
                    {
                        no_fo = driver.FindElementsByClassName("notion-focusable");
                        if(no_fo[j].Text.ToString() == "Napisać Scenariusz")
                        {
                            no_fo[j].Click();
                        }
                    }
                }
 */