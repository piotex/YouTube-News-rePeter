using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
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
            Thread.Sleep(5000);
            var aaa = driver.FindElementsByClassName("notion-focusable");
            List<string> bbb = new List<string>();
            aaa[52].Click();

            aaa = driver.FindElementsByClassName("notranslate");
            for (int i = 0; i < aaa.Count; i++)
            {
                //bbb.Add(aaa[i].Text);
            }
            aaa[27].Click();

            /*
            IWebElement passwordTextBox = driver.FindElement(By.Id("notion-email-input-1"));
            passwordTextBox = driver.FindElement(By.Id("notion-password-input-2"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(user.Pwd);
            driver.FindElementsByClassName("notion-focusable")[3].Click();
            */
        }
    }
}
