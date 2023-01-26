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
            public void TestMethod1()
            {
                var asd = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[2]"));
                Assert.AreEqual("amerika", asd.Text);
                var button = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[1]/td[7]/button"));
                button.Click();
                driver.SwitchTo().Alert().Accept();
                driver.Url = "http://localhost:5173/cart";
                var asd1 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr/td[2]"));
                Assert.AreEqual("amerika", asd1.Text);
            }
        }

        
    }
}