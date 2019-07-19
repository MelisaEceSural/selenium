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
        public static IWebDriver driver = null;

  
        [SetUp]
        public void start()
        {

            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(site);

            driver.FindElement(By.ClassName("btnSignIn")).Click();
        }

        [Test]
        public void login()
        {
            driver.FindElement(By.Id("email")).SendKeys(@"messural11@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("12345a");

            driver.FindElement(By.Id("loginButton")).Click();

         
            Thread.Sleep(4000);

           


        }

        [Test]
        public void SearchBilgisayar()
        {



            IWebElement Input_Search = driver.FindElement(By.Id("searchData"));
            Input_Search.SendKeys("bilgisayar");
            Thread.Sleep(4000);

            IWebElement Btn_Search = driver.FindElement(By.ClassName("searchBtn"));
            Btn_Search.Click();
            Thread.Sleep(4000);

           
        }

        [Test]
        public void Paging()
        {


        
            Thread.Sleep(3000);


            driver.FindElement(By.XPath(".//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click();
            Thread.Sleep(4000);
            
        }

        [Test]
        public void SepeteAt()
        {

            Thread.Sleep(3000);

            IWebElement List_3rdItem = driver.FindElement(By.XPath(".//*[@id='view']/ul/li[3]"));
            IWebElement ClickItem = List_3rdItem.FindElement(By.ClassName("productName"));
            var sepete_atilan_item = ClickItem.Text;
            ClickItem.Click();
            Thread.Sleep(4000);
            Console.WriteLine("Ürün seçildi ve detay ekranına ulaşıldı...");

           
            IWebElement Btn_Basket = driver.FindElement(By.CssSelector(".btn.btnGrey.btnAddBasket"));
            Btn_Basket.Click();
            Thread.Sleep(3000);
            Console.WriteLine("Ürün speete atıldı...");
            IWebElement Sepet = driver.FindElement(By.CssSelector(".myBasket"));
            Sepet.Click();
            Thread.Sleep(8000);
            Console.WriteLine("Sepet içerisine girildi...");


            IWebElement Btn_ekle = driver.FindElement(By.XPath(".//*[@class='prodPrice']/div[1]/div/span[1]"));
            Thread.Sleep(4000);
            Btn_ekle.Click();

            IWebElement Btn_sil = driver.FindElement(By.XPath(".//*[@class='prodDetail']/div[3]/div[2]/span[1]"));
            Thread.Sleep(4000);
            Btn_sil.Click();

            Console.WriteLine("Ürün silme işlemi gerçekleştirildi...");

            

        }


        [TearDown]
       public void finish()
        {
            driver.Close();
            driver.Quit();

        }

    }
}