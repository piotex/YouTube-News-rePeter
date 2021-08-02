using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Communication.Slaves
{
    public class CommunicationNotion
    {
        protected FirefoxDriver driver;
        public CommunicationNotion()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe -private ";
            driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl(@"https://www.notion.so/You-Tube-4bfa9a98d7bf4949b5a138293ace5782");
        }
        public void LogIn()
        {
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
        }
    }
}
