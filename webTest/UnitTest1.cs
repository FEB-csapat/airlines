using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace webTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class ChromeDriverTest
        {
            private ChromeDriver driver;
            [TestInitialize]
            public void ChromeDriverInitialize()
            {
                driver = new ChromeDriver();
                driver.Url = "http://localhost:5173";
            }
            [TestMethod]
            public void CartAddTest()
            {
                var tocity = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[3]"));
                Assert.AreEqual("London", tocity.Text);
                var fromcity = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[2]"));
                Assert.AreEqual("Budapest", fromcity.Text);
                var airline = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[1]"));
                Assert.AreEqual("WizzAir", airline.Text);
                var tocity1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[4]/td[3]"));
                Assert.AreEqual("Szarajevó", tocity1.Text);
                var fromcity1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[4]/td[2]"));
                Assert.AreEqual("Belgrád", fromcity1.Text);
                var airline1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[4]/td[1]"));
                Assert.AreEqual("Air Serbia", airline1.Text);
                var tocartbutton = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[7]/button"));
                tocartbutton.Click();
                driver.SwitchTo().Alert().Accept();
                var tocartbutton1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[4]/td[7]/button"));
                tocartbutton1.Click();
                driver.SwitchTo().Alert().Accept();
                driver.Url = "http://localhost:5173/cart";
                var cartfromcity = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr/td[2]"));
                Assert.AreEqual("Budapest", cartfromcity.Text);
                var cartfromcity1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[2]"));
                Assert.AreEqual("Belgrád", cartfromcity1.Text);
                var carttocity = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[3]"));
                Assert.AreEqual("London", carttocity.Text);
                var carttocity1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[3]"));
                Assert.AreEqual("Szarajevó", carttocity1.Text);
            }
            [TestMethod]
            public void CartDeleteTest()
            {
                var tocartbutton = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[7]/button"));
                tocartbutton.Click();
                driver.SwitchTo().Alert().Accept();
                var tocartbutton1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[4]/td[7]/button"));
                tocartbutton1.Click();
                driver.SwitchTo().Alert().Accept();
                driver.Url = "http://localhost:5173/cart";
                var deletebutton = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[5]/button"));
                deletebutton.Click();
                var cartfromcity = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr/td[2]"));
                Assert.AreEqual("Belgrád", cartfromcity.Text);
                var carttocity = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[3]"));
                Assert.AreEqual("Szarajevó", carttocity.Text);
            }
            [TestMethod]
            public void NavBarTest()
            {
                var title = driver.FindElement(By.XPath("/html/body/div/div/div/h2"));
                Assert.AreEqual("Menetrend keresõ",title.Text);
                driver.Url = "http://localhost:5173/cart";
                var carttitle = driver.FindElement(By.XPath("/html/body/div/div/div/h2"));
                Assert.AreEqual("A jegyek végösszege", carttitle.Text);
                driver.Url = "http://localhost:5173";
                title = driver.FindElement(By.XPath("/html/body/div/div/div/h2"));
                Assert.AreEqual("Menetrend keresõ", title.Text);
            }
        }

        
    }
}