using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Edge;
using NUnit;
using NUnit.Core;


using NUnit.Framework;
using System.Threading;

using OpenQA.Selenium.Support.UI;

namespace n11
{

    [TestFixture]

    public class class1
    {
        string site = "http://www.n11.com/";
        public static IWebDriver sürücü = null;

  
        [SetUp]
        public void start()
        {

            sürücü = new FirefoxDriver();
            sürücü.Navigate().GoToUrl(site);

            sürücü.FindElement(By.ClassName("btnSignIn")).Click();
        }

        [Test]
        public void login()
        {
            sürücü.FindElement(By.Id("email")).SendKeys(@"messural11@gmail.com");
           sürücü.FindElement(By.Id("password")).SendKeys("12345a");

           sürücü.FindElement(By.Id("loginButton")).Click();

         
            Thread.Sleep(4000);

           


        }

        [Test]
        public void SearchBilgisayar()
        {



            IWebElement yaz = sürücü.FindElement(By.Id("searchData"));
            yaz.SendKeys("bilgisayar");
            Thread.Sleep(4000);

            IWebElement ara = sürücü.FindElement(By.ClassName("searchBtn"));
            ara.Click();
            Thread.Sleep(4000);

           
        }

        [Test]
        public void Paging()
        {


        
            Thread.Sleep(3000);


            sürücü.FindElement(By.XPath(".//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click();
            Thread.Sleep(4000);
            
        }

        [Test]
        public void SepeteAt()
        {

            Thread.Sleep(3000);

            IWebElement sayfa= sürücü.FindElement(By.XPath(".//*[@id='view']/ul/li[3]"));
            IWebElement tıkla = sayfa.FindElement(By.ClassName("productName"));
            var sepete_atilan = tıkla.Text;
            tıkla.Click();
            Thread.Sleep(4000);
            Console.WriteLine("Ürün seçildi ve detay ekranına ulaşıldı...");

           
            IWebElement sepetat= sürücü.FindElement(By.CssSelector(".btn.btnGrey.btnAddBasket"));
            sepetat.Click();
            Thread.Sleep(3000);
            Console.WriteLine("Ürün speete atıldı...");
            IWebElement Sepet = sürücü.FindElement(By.CssSelector(".myBasket"));
            Sepet.Click();
            Thread.Sleep(8000);
            Console.WriteLine("Sepet içerisine girildi...");


            IWebElement ekle = sürücü.FindElement(By.XPath(".//*[@class='prodPrice']/div[1]/div/span[1]"));
            Thread.Sleep(4000);
            ekle.Click();

            IWebElement sil = sürücü.FindElement(By.XPath("//span[contains(@class,'removeProd svgIcon svgIcon_trash')]  [contains(text(),'Sil')]"));
            Thread.Sleep(4000);
           sil.Click();

            Console.WriteLine("Ürün silme işlemi gerçekleştirildi...");

            

        }


        [TearDown]
       public void finish()
        {
           sürücü.Close();
            sürücü.Quit();

        }

    }
}