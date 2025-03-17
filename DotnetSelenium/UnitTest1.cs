using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace DotnetSelenium
{
    // Tutorial: https://www.youtube.com/playlist?list=PL6tu16kXT9Pr50Bu96uf9z4rNxMTVTIxm
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        Random rnd = new Random();

        [Test]
        public void Test1() // google test
        {
            // Pseudo Code for setting up Selenium
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new EdgeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com/");
            // 2a. Maximize the browser window
            driver.Manage().Window.Maximize();

            // 3. Find the element (Accept Cookies)
            IWebElement webElement = driver.FindElement(By.ClassName("sy4vM"));
            // 4. Click the element (Accept Cookies)
            webElement.Click();

            // 5. Find the element (search bar)
            webElement = driver.FindElement(By.Name("q"));
            // 6. Type the element (search for "Selenium))
            webElement.SendKeys("Selenium");
            // 7. Click on the element (enter)
            webElement.SendKeys(Keys.Enter);

            // ofc not working bc google Captcha is too strong :(
            //// 8. Find the element (Captcha)
            //webElement = driver.FindElement(By.ClassName("recaptcha-checkbox-checkmark"));
            //// 4. Click the element (Captcha)
            //webElement.Click();

            Assert.Pass();
        }


        [Test]
        public void Test2() // dino test
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("chrome://dino/");

            Actions actions = new Actions(driver);

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(200);
                actions.SendKeys(Keys.Space).Perform();
            }
        }

        [Test]
        public void Test3() // 2048 test
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://2048game.com/de/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(1000);
            IWebElement webElement = driver.FindElement(By.ClassName("css-47sehv"));
            webElement.Click();

            Actions actions = new Actions(driver);

            for (int i = 0; i < 200; i++){
                Thread.Sleep(100);

                int randomNum = rnd.Next(1,5);
                switch (randomNum)
                {
                    case 1: actions.SendKeys(Keys.ArrowUp).Perform();
                        break;
                    case 2: actions.SendKeys(Keys.ArrowLeft).Perform();
                        break;
                    case 3: actions.SendKeys(Keys.ArrowDown).Perform();
                        break;
                    case 4: actions.SendKeys(Keys.ArrowRight).Perform();
                        break;
                }
            }
        }

        [Test]
        public void Test4()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://neal.fun/stimulation-clicker/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(300);
            IWebElement cookieElement = driver.FindElement(By.ClassName("fc-primary-button"));
            cookieElement.Click();

            IWebElement webElement = driver.FindElement(By.ClassName("main-btn"));

            for (int i = 0; i < 56; i++)
            {
                webElement.Click();
            }
        }

        [Test] 
        public void Test5()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://flappybird.io/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(500);
            IWebElement webElement = driver.FindElement(By.Id("ez-accept-all"));
            webElement.Click();

            webElement = driver.FindElement(By.ClassName("container"));

            Thread.Sleep(5000);
            webElement.Click();

            for (int i = 0; i < 1000; i++)
            {
                int randomNum = rnd.Next(300, 600);
                Thread.Sleep(randomNum);
                webElement.Click();
            }
        }
    }
}