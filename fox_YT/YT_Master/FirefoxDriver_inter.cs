using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master
{
    public class FirefoxDriver_inter
    {
        public FirefoxDriver driver;
        public FirefoxDriver_inter()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe -private ";
            driver = new FirefoxDriver(service);
        }

        public void PlotError(string err)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(err);
            Console.WriteLine("\n----------------------");
        }
        public bool ClickButton_PlayVideo()
        {
            try
            {
                By data2 = By.ClassName("ytp-large-play-button");
                driver.FindElement(data2).Click();
            }
            catch (Exception exx) 
            {
                PlotError("Error in ClickButton_PlayVideo " + exx.Message);
            }
            return true;
        }
        public bool ClickButton_ZgadzamSie()
        {
            try
            {
                driver.FindElement(By.TagName("button")).Click();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            }
            catch (Exception exx)
            {
                PlotError("Error in ClickButton_ZgadzamSie " + exx.Message);
            }
            return true;
        }
    }
}
