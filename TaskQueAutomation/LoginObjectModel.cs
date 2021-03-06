﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskQueAutomation
{
    class LoginObjectModel
    {
        public LoginObjectModel()
        {
            PageFactory.InitElements(Browser.wdriver, this);
        }

        public static string DashBoardURL = "https://taskque.com/dashboard#/app/workspace/1122/project/2441";

        [FindsBy(How = How.Id, Using = "YumUserLogin_username")]
        public IWebElement txt_UserName { get; set; }

        [FindsBy(How = How.Id, Using = "YumUserLogin_password")]
        public IWebElement txt_Password { get; set; }

        [FindsBy(How = How.Id, Using = "YumUserLogin_rememberMe")]
        public IWebElement click_Remember { get; set; }

        [FindsBy(How = How.Name, Using = "yt0")]
        public IWebElement btn_login { get; set; }

        public void Login(string username, string password)
        {
            /* Enter Username and password */
            txt_UserName.SendKeys(username);
            txt_Password.SendKeys(password);
            btn_login.Click();

            /* Wait until page completly loads */
            WebDriverWait wait = new WebDriverWait(Browser.wdriver, TimeSpan.FromSeconds(150));
            wait.Until(ExpectedConditions.UrlToBe(DashBoardURL));
            
            /* Assert page title and page URL after login */
            Assert.AreEqual(DashBoardURL, Browser.wdriver.Url);
            Assert.AreEqual("Live Testing Project.", Browser.wdriver.Title);
            
        }
    }
}

