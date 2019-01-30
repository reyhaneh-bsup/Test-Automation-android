//package <set your test package>;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Experitest;
using Hong;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;

namespace Experitest
{
    [TestFixture]
    public class Program
    {
        private string reportDirectory = "reports";
        private string reportFormat = "xml";
        private string testName = "khar";
        protected AndroidDriver<AndroidElement> driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        public object Itouchaction { get; private set; }

        [SetUp()]
        public void SetupTest()
        {
            //dc.SetCapability("platformName", "Android");
            //dc.SetCapability("deviceName", "Samsung Galaxy S8 - 8.0 - API26 - 1440x2960");
            //dc.SetCapability("appPackage", "com.android.dialer");
            //dc.SetCapability("appActivity", "DialtactsActivity");
            //driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.01:4723/wd/hub"), dc);

            //dc.SetCapability("reportDirectory", reportDirectory);
            //dc.SetCapability("reportFormat", reportFormat);
            //dc.SetCapability("testName", testName);
            //dc.SetCapability(MobileCapabilityType.Udid, "192.168.217.103:5555");
            //dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.lalamove.techchallenge");
            //dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".app.MainActivity");
            //driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), dc);

            dc.SetCapability("reportDirectory", reportDirectory);
            dc.SetCapability("reportFormat", reportFormat);
            dc.SetCapability("testName", testName);
            dc.SetCapability(MobileCapabilityType.Udid, "192.168.217.101:5555");
            dc.SetCapability(AndroidMobileCapabilityType.AppPackage, "com.lalamove.techchallenge");
            dc.SetCapability(AndroidMobileCapabilityType.AppActivity, ".app.MainActivity");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), dc);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

        }


        [Test()]
        public void TestUntitled()
        {
            driver.Swipe(720, 2358, 189, 786, 364);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("xpath=//*[@text='TechChallenge']")));
            driver.FindElement(By.XPath("xpath=//*[@text='TechChallenge']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("xpath=(//*[@class='androidx.recyclerview.widget.RecyclerView']/*/*[@text='Deliver documents to Andrio' and (./preceding-sibling::* | ./following-sibling::*)[@text='Mong Kok']])[1]")));
            driver.FindElement(By.XPath("xpath=(//*[@class='androidx.recyclerview.widget.RecyclerView']/*/*[@text='Deliver documents to Andrio' and (./preceding-sibling::* | ./following-sibling::*)[@text='Mong Kok']])[1]")).Click();


        }

        [Test()]
        //Landing page of the app shows Delivery List with maximum 20 records when first opened.
        public void Count()
        {
            //Thread.Sleep(5000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.Id("textView_description")));
            AppiumWebElement li = driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']"));
            ReadOnlyCollection<AppiumWebElement> allTextViews = li.FindElements(By.ClassName("android.view.ViewGroup"));
            int count = allTextViews.Count;
            count--;
            Console.WriteLine(count);
            Assert.AreEqual(true, count <= 20);
            //foreach (var firibz in allTextViews)
            //{
            //    var temp = firibz;
            //}

        }

        [Test()]
        public void LongPress()
        {
            //Long press on an item, and it will be deleted.
            Thread.Sleep(7000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.Id("textView_description")));
            ITouchAction rey1;
            IWebElement element = driver.FindElementByXPath("(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[7]");
            rey1 = new TouchAction(driver).LongPress(element);
            rey1.Perform();


            IWebElement kharrrrrr = driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']"));
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']")).Displayed, "app is not active");
            Assert.IsFalse(element.Displayed, "element has not been deleted");
        }

        [Test()]
        public void ShowDetailsPage()
        {
            //Click any item from Delivery List and Delivery Details page shows.
            Thread.Sleep(7000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.Id("textView_description")));
            driver.FindElement(By.XPath("xpath=(//*[@class='androidx.recyclerview.widget.RecyclerView']/*/*[@text='Deliver documents to Andrio' and (./preceding-sibling::* | ./following-sibling::*)[@text='Kowloon Tong']])[1]")).Click();




        }

        [Test()]
        //Shows icon, description and location. Parcels are for Leviero and documents are for Andrio.
        public void Khar()
        {
            //Thread.Sleep(5000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.Id("textView_description")));

            AppiumWebElement li = driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']"));
            Thread.Sleep(5000);
            ReadOnlyCollection<AppiumWebElement> allTextViews = li.FindElements(By.ClassName("android.view.ViewGroup"));
            int count = allTextViews.Count;
            count--;
            Console.WriteLine(count);
            int repeat = 0;
            foreach (var viewGroup in allTextViews)
            {

                if (repeat < count)
                {
                    //bool a = driver.FindElement(By.Id("simpleDraweeView")).Displayed;
                    //bool b = driver.FindElement(By.Id("textView_description")).Displayed;
                    //bool c = driver.FindElement(By.Id("textView_address")).Displayed;
                    //bool d = driver.FindElement(By.Id("imageView")).Displayed;

                    Assert.IsTrue(viewGroup.FindElement(By.Id("simpleDraweeView")).Displayed);
                    Assert.IsTrue(viewGroup.FindElement(By.Id("textView_description")).Displayed);
                    Assert.IsTrue(viewGroup.FindElement(By.Id("textView_address")).Displayed);
                    Assert.IsTrue(viewGroup.FindElement(By.Id("imageView")).Displayed);

                    AppiumWebElement temp = viewGroup.FindElement(By.Id("textView_description"));
                    string title = temp.Text;
                    string order = title.Between("Deliver", "to").Trim();
                    string peyk = title.After("to").Trim();

                    if (order == "documents")
                    {
                        try
                        {
                            Assert.AreEqual("Andrio", peyk, $"{repeat + 1}`s is Deliver {order} to {peyk} ");
                        }
                        catch
                        {
                            //boro badi
                        }
                    }
                    else if (order == "parcel")
                    {
                        try
                        {
                            Assert.AreEqual("Leviero", peyk, $"{repeat + 1}`s is Deliver {order} to {peyk} ");
                        }
                        catch
                        {
                            //boro badi
                        }
                    }
                    ++repeat;
                }

            }
            int remainingSpace = 0;
            try
            {
                var remaining = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat + 1}]"));
                remainingSpace = remaining.Size.Height;
            }
            catch
            {
                remainingSpace = 0;
            }

            //----------------------

            var last = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));
            int lastX = (last.Location.X) + (last.Size.Width / 2);
            int lastY = (last.Location.Y);
            int scrollSize = last.Size.Height;
            remainingSpace += 4 + 44;
            //----------------------

            for (int i = repeat; i <= 20; ++i)
            {
                driver.Swipe(lastX, lastY, lastX, lastY - scrollSize - remainingSpace, 250);
                var current = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));

                Assert.IsTrue(current.FindElement(By.Id("simpleDraweeView")).Displayed);
                Assert.IsTrue(current.FindElement(By.Id("textView_description")).Displayed);
                Assert.IsTrue(current.FindElement(By.Id("textView_address")).Displayed);
                Assert.IsTrue(current.FindElement(By.Id("imageView")).Displayed);

                AppiumWebElement temp = current.FindElement(By.Id("textView_description"));
                string title = temp.Text;
                string order = title.Between("Deliver", "to").Trim();
                string peyk = title.After("to").Trim();

                if (order == "documents")
                {
                    try
                    {
                        Assert.AreEqual("Andrio", peyk, $"{repeat + 1}`s is Deliver {order} to {peyk} ");
                    }
                    catch
                    {
                        //boro badi
                    }
                }
                else if (order == "parcel")
                {
                    try
                    {
                        Assert.AreEqual("Leviero", peyk, $"{repeat + 1}`s is Deliver {order} to {peyk} ");
                    }
                    catch
                    {
                        //boro badi
                    }
                }

            }
        }
        [Test]
        public void information()
        {
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("(//*[@class='androidx.recyclerview.widget.RecyclerView']/*/*[@text='Deliver documents to Andrio' and (./preceding-sibling::* | ./following-sibling::*)[@text='Kowloon Tong']])[1]")).Click();
            AppiumWebElement li = driver.FindElement(By.Id("toolbar"));
            Assert.IsTrue(li.FindElement(By.XPath("//*[@text and ./parent::*[@id='toolbar']]")).Displayed);

        }

        [Test]
        //Map pin shows and centred to that pin for that delivery.
        public void MapItem()
        {
            AppiumWebElement li = driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']"));
            Thread.Sleep(5000);
            ReadOnlyCollection<AppiumWebElement> allTextViews = li.FindElements(By.ClassName("android.view.ViewGroup"));
            int count = allTextViews.Count;

            int repeat = 0;
            int remainingSpace = 0;
            AndroidElement map;
            AndroidElement frame;
            AndroidElement bottomFrame;
            double dp;
            double expectedX;
            double expectedY;
            double addX;
            double addY;

            foreach (var viewGroup in allTextViews)
            {


                if (repeat < count)
                {
                    try
                    {
                        viewGroup.FindElement(By.Id("textView_description")).Click();
                        map = driver.FindElement(By.XPath("//*[@class='android.view.View' and ./parent::*[@contentDescription='Google Map']]"));
                        frame = driver.FindElement(By.XPath("//*[@id='mapView']"));
                        bottomFrame = driver.FindElement(By.XPath("//*[@class='android.view.ViewGroup' and ./*[@id='ivDelivery']]"));
                        dp = driver.FindElement(By.XPath(" //*[@id='appBarLayout']")).Size.Height / 56;
                        expectedX = (frame.Size.Width / 2) / dp;
                        expectedY = ((frame.Size.Height - bottomFrame.Size.Height) / 2) / dp;

                        var mapLoc = map.Location;
                        addX = (map.Size.Width / 2) / dp;
                        addY = (map.Size.Height / 2) / dp;

                        try
                        {
                            Assert.AreEqual(expectedX, (mapLoc.X / dp) + addX, $"{repeat + 1}`s item az nazare width align nist.");
                            Assert.AreEqual(expectedY, ((mapLoc.Y - bottomFrame.Size.Height) / dp) + addY, $"{repeat + 1}`s item az nazare height align nist.");
                        }
                        catch
                        {
                            //boro badi
                        }
                    }
                    catch (Exception e)
                    {
                        var remaining = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat + 1}]"));
                        remainingSpace = remaining.Size.Height;
                        break;
                    }
                    driver.FindElement(By.XPath("//*[@contentDescription='Navigate up']")).Click();

                    ++repeat;
                }
            }
            //Thread.Sleep(15000);
            //driver.FindElement(By.XPath("(//*[@class='androidx.recyclerview.widget.RecyclerView']/*/*[@text='Deliver documents to Andrio' and (./preceding-sibling::* | ./following-sibling::*)[@text='Kowloon Tong']])[1]")).Click();
            //AppiumWebElement li = driver.FindElement(By.Id("toolbar"));
            //Assert.IsTrue(li.FindElement(By.XPath("//*[@text and ./parent::*[@id='toolbar']]")).Displayed);
            //Thread.Sleep(10000);

            //------------------------
            var last = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));
            int lastX = (last.Location.X) + (last.Size.Width / 2);
            int lastY = (last.Location.Y);
            int scrollSize = last.Size.Height;
            remainingSpace += 8 + 44 + 4;
            //----------------------


            int attemp = 1;

            for (int i = repeat; i <= 15; ++i)
            {
                //if (i==repeat+1)
                //{
                //    remainingSpace += 8;
                //}

                for (int j = 0; j < attemp; ++j)
                {
                    driver.Swipe(lastX, lastY, lastX, lastY - scrollSize - remainingSpace, 250);
                }
                var current = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));

                current.Click();
                map = driver.FindElement(By.XPath("//*[@class='android.view.View' and ./parent::*[@contentDescription='Google Map']]"));
                frame = driver.FindElement(By.XPath("//*[@id='mapView']"));
                bottomFrame = driver.FindElement(By.XPath("//*[@class='android.view.ViewGroup' and ./*[@id='ivDelivery']]"));
                dp = driver.FindElement(By.XPath(" //*[@id='appBarLayout']")).Size.Height / 56;
                expectedX = (frame.Size.Width / 2) / dp;
                expectedY = ((frame.Size.Height - bottomFrame.Size.Height) / 2) / dp;

                var mapLoc = map.Location;
                addX = (map.Size.Width / 2) / dp;
                addY = (map.Size.Height / 2) / dp;

                try
                {
                    Assert.AreEqual(expectedX, (mapLoc.X / dp) + addX, $"{i + 1}`s item az nazare width align nist.");
                    Assert.AreEqual(expectedY, ((mapLoc.Y - bottomFrame.Size.Height) / dp) + addY, $"{i + 1}`s item az nazare height align nist.");
                }
                catch
                {
                    //boro badi
                }

                driver.FindElement(By.XPath("//*[@contentDescription='Navigate up']")).Click();
                ++attemp;
            }



        }
        [Test]
        //Information should be shown correctly based on the item details from [Image-1A] (refer to attached mockup).
        public void DetailInformation()
        {


            AppiumWebElement li = driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']"));
            Thread.Sleep(5000);
            ReadOnlyCollection<AppiumWebElement> allTextViews = li.FindElements(By.ClassName("android.view.ViewGroup"));
            int count = allTextViews.Count;
            //count--;
            Console.WriteLine(count);
            int repeat = 0;
            int remainingSpace = 0;
            string FirstPageDes = "";
            string FirstPageAddress = "";
            string SecondPageDes = "";
            string SecondPageAddress = "";
            foreach (var viewGroup in allTextViews)
            {


                if (repeat < count)
                {
                    try
                    {
                        FirstPageDes = viewGroup.FindElement(By.Id("textView_description")).Text;
                        FirstPageAddress = viewGroup.FindElement(By.Id("textView_address")).Text;

                        viewGroup.FindElement(By.Id("textView_description")).Click();

                        SecondPageDes = driver.FindElement(By.XPath("//*[@id='tvDescription']")).Text;
                        SecondPageAddress = driver.FindElement(By.XPath("//*[@id='textView_address']")).Text;
                    }
                    catch (Exception e)
                    {
                        var remaining = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat + 1}]"));
                        remainingSpace = remaining.Size.Height;
                        break;
                    }
                    try
                    {
                        Assert.AreEqual(FirstPageDes, SecondPageDes, "no title" + repeat);
                    }
                    catch
                    {
                        //boro badi
                    }

                    try
                    {
                        Assert.AreEqual(FirstPageAddress, SecondPageAddress, "no location" + repeat);
                    }
                    catch
                    {
                        //boro badi
                    }

                    driver.FindElement(By.XPath("//*[@contentDescription='Navigate up']")).Click();

                    ++repeat;
                }
            }
            //repeat = 9;
            //driver.FindElement(By.XPath("(//*[@class='androidx.recyclerview.widget.RecyclerView']/*/*[@text='Deliver documents to Andrio' and (./preceding-sibling::* | ./following-sibling::*)[@text='Kowloon Tong']])[0]")).Click();
            //double dp = driver.FindElement(By.XPath(" //*[@id='appBarLayout']")).Size.Height / 56;
            //driver.FindElement(By.XPath("//*[@contentDescription='Navigate up']")).Click();


            //----------------------

            var last = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));
            int lastX = (last.Location.X) + (last.Size.Width / 2);
            int lastY = (last.Location.Y);
            int scrollSize = last.Size.Height;
            remainingSpace += 8 + 44 + 4;
            //----------------------


            int attemp = 1;
            for (int i = repeat; i <= 15; ++i)
            {
                //if (i==repeat+1)
                //{
                //    remainingSpace += 8;
                //}

                for (int j = 0; j < attemp; ++j)
                {
                    driver.Swipe(lastX, lastY, lastX, lastY - scrollSize - remainingSpace, 250);
                }
                var current = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));

                FirstPageDes = current.FindElement(By.Id("textView_description")).Text;
                FirstPageAddress = current.FindElement(By.Id("textView_address")).Text;

                current.Click();

                SecondPageDes = driver.FindElement(By.XPath("//*[@id='tvDescription']")).Text;
                SecondPageAddress = driver.FindElement(By.XPath("//*[@id='textView_address']")).Text;

                try
                {
                    Assert.AreEqual(FirstPageDes, SecondPageDes, "no title" + i);
                }
                catch
                {
                    //boro badi
                }

                try
                {
                    Assert.AreEqual(FirstPageAddress, SecondPageAddress, "no location" + i);
                }
                catch
                {
                    //boro badi
                }

                driver.FindElement(By.XPath("//*[@contentDescription='Navigate up']")).Click();
                ++attemp;
            }
        }

        [Test]
        //Shows when clicking the 14th record from Delivery List.
        public void thItem()
        {
            AppiumWebElement li = driver.FindElement(By.XPath("//*[@class='androidx.recyclerview.widget.RecyclerView']"));
            Thread.Sleep(5000);
            ReadOnlyCollection<AppiumWebElement> allTextViews = li.FindElements(By.ClassName("android.view.ViewGroup"));
            int count = allTextViews.Count;
            //count--;
            int repeat = 0;
            int remainingSpace = 0;
            string FirstPageDes = "";
            string FirstPageAddress = "";
            foreach (var viewGroup in allTextViews)
            {


                if (repeat < count)
                {
                    try
                    {
                        FirstPageDes = viewGroup.FindElement(By.Id("textView_description")).Text;
                        FirstPageAddress = viewGroup.FindElement(By.Id("textView_address")).Text;
                        ++repeat;
                    }
                    catch (Exception e)
                    {
                        var remaining = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat + 1}]"));
                        remainingSpace = remaining.Size.Height;
                        break;
                    }


                }
            }

            //----------------------

            var last = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));
            int lastX = (last.Location.X) + (last.Size.Width / 2);
            int lastY = (last.Location.Y);
            int scrollSize = last.Size.Height;
            remainingSpace += 8 + 44 + 4;
            //----------------------


            //if (i==repeat+1)
            //{
            //    remainingSpace += 8;
            //}

            for (int j = repeat; j < 14; ++j)
            {
                driver.Swipe(lastX, lastY, lastX, lastY - scrollSize - remainingSpace, 250);
            }
            var current = driver.FindElement(By.XPath($"(//*[@class='androidx.recyclerview.widget.RecyclerView']/*[./*[@id='simpleDraweeView']])[{repeat}]"));

            FirstPageDes = current.FindElement(By.Id("textView_description")).Text;
            FirstPageAddress = current.FindElement(By.Id("textView_address")).Text;

            current.Click();

            var SecondPageDes = driver.FindElement(By.XPath("//*[@id='tvDescription']")).Text;
            var SecondPageAddress = driver.FindElement(By.XPath("//*[@id='textView_address']")).Text;


            try
            {
                Assert.IsTrue(current.FindElement(By.XPath("//*[@class='android.widget.ImageView' and ./parent::*[@class='android.widget.LinearLayout'] and (./preceding-sibling::* | ./following-sibling::*)[@text]]")).Displayed);
                Assert.IsTrue(current.FindElement(By.Id("//*[@text and ./parent::*[@class='android.widget.LinearLayout'] and (./preceding-sibling::* | ./following-sibling::*)[@class='android.widget.ImageView']]")).Displayed);
            }
            catch
            {
                //boro badi
            }

        }


        [TearDown()]
        public void TearDown()
        {
            //driver.Quit();
        }



    }
}