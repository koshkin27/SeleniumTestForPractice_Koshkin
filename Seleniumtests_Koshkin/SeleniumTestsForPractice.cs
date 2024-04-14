using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Seleniumtests_Koshkin;

public class SeleniumTestsForPractice
{
    [Test]
    public void Authorization()
    {
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--start-maximized", "--disable-extensions");
        
        // зайти в хром (с помощью вебдрайвера)
        var driver = new ChromeDriver(options);
        
        // перейти по урлу
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru"); 
        Thread.Sleep(5000);
        
        // ввести логин и пароль
        var login = driver.FindElement(By.Id("Username"));
        login.SendKeys("dimakoshk@hotmail.com");

        var password = driver.FindElement(By.Name("Password"));
        password.SendKeys("Elephant27!");
        
        Thread.Sleep(3000);
        
        // нажать кнопку "войти"
        var enter = driver.FindElement(By.Name("button"));
        enter.Click();
        Thread.Sleep(3000);
        
        //проверяем, что мы находимся на нужной странице
        var currentUrl = driver.Url;
        Assert.That(currentUrl == "https://staff-testing.testkontur.ru/news");
        
        driver.Quit();
    }
}