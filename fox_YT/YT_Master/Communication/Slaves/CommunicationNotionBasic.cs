using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Communication.Slaves
{
    public class CommunicationNotionBasic
    {
        protected FirefoxDriver driver;
        public CommunicationNotionBasic()
        {
            //string path = @".";
            string path = @"C:\Users\pkubo\OneDrive\Desktop\YouTube\fox_YT\ConsoleApp1\bin\Debug\netcoreapp3.1";
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path, "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe ";// -private ";
            driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl(@"https://www.notion.so/YouTube-Automat-15c60d9e70384fdd9a6320ceacd5bac1");
        }



    }
}
