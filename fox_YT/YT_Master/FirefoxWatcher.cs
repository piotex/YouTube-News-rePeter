using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace YT_Master
{
    public class FirefoxWatcher : FirefoxDriver_inter
    {
        private double wait_time = 5;
        public bool Watch(string url)
        {
            try
            {
                Navigate(url);
                ClickButton_ZgadzamSie();
                ClickButton_PlayVideo();
                //ClickButton_PlayVideo();
            }
            catch (Exception exx)
            {
                PlotError("Error in FirefoxWatcher:Watch " + exx.Message);
            }
            return true;
        }
        public bool Navigate(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(wait_time);
            }
            catch (Exception exx)
            {
                PlotError("Error in FirefoxWatcher:Navigate " + exx.Message);
            }
            return true;
        }
    }
}
