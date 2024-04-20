using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Seleniumtests_Koshkin;

public class SeleniumTestsForPractice
{
    public ChromeDriver driver;
    
    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--start-maximized", "--disable-extensions");
        
        // зайти в хром с помощью вебдрайвера
        driver = new ChromeDriver(options);
        
        // установить неявные ожидания
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
        // авторизация
        Authorization();
    }
    
    // тестирование авторизации на Стаффе
    [Test]
    public void StaffAuthorization()
    {
        // проверка, что мы находимся на главной странице Стаффа
        driver.FindElement(By.CssSelector("[data-tid='Feed']"));
        var currentUrl = driver.Url;
        currentUrl.Should().Be("https://staff-testing.testkontur.ru/news"); // библиотека FluentAssertions
    }

    // тестирование перехода на страницу сообществ 
    [Test]
    public void NavigationToCommunities()
    {
        // кликнуть на боковое меню
        var sideMenu = driver.FindElement(By.CssSelector("[data-tid='SidebarMenuButton']"));
        sideMenu.Click();
        // кликнуть на "Сообщества"
        var community = driver.FindElements(By.CssSelector("[data-tid='Community']")).First(element => element.Displayed);
        community.Click();
        // проверка, что мы перешли на страницу сообществ
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        var currentUrl = driver.Url;
        currentUrl.Should().Be("https://staff-testing.testkontur.ru/communities");
    }
    
    // тестирование навигации бокового меню
    [Test]
    public void LeftSideMenuNavigation()
    {
        // кликнуть на боковое меню
        var sideMenu = driver.FindElement(By.CssSelector("[data-tid='SidebarMenuButton']"));
        sideMenu.Click();
        
        // кликнуть на "Комментарии"
        var comments = driver.FindElements(By.CssSelector("[data-tid='Comments']")).First(element => element.Displayed);
        comments.Click();
        // проверка, что мы перешли на страницу комментариев
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.XPath("//h1[text()='Комментарии']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
        
        // кликнуть на "Диалоги"
        var messages = driver.FindElements(By.CssSelector("[data-tid='Messages']")).First(element => element.Displayed);
        messages.Click();
        // проверка, что мы перешли на страницу диалогов
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.XPath("//h1[text()='Диалоги']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
        
        // кликнуть на "Сообщества"
        var community = driver.FindElements(By.CssSelector("[data-tid='Community']")).First(element => element.Displayed);
        community.Click();
        // проверка, что мы перешли на страницу сообществ
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.XPath("//h1[text()='Сообщества']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
        
        // кликнуть на "Мероприятия"
        var events = driver.FindElements(By.CssSelector("[data-tid='Events']")).First(element => element.Displayed);
        events.Click();
        // проверка, что мы перешли на страницу мероприятий
        driver.FindElement(By.CssSelector("[data-tid='Actual']"));
        driver.FindElement(By.XPath("//title[text()='Мероприятия']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
        
        // кликнуть на "Файлы"
        var files = driver.FindElements(By.CssSelector("[data-tid='Files']")).First(element => element.Displayed);
        files.Click();
        // проверка, что мы перешли на страницу файлов
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.CssSelector("[title='Файлы']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
      
        // кликнуть на "Документы"
        var documents = driver.FindElements(By.CssSelector("[data-tid='Documents']")).First(element => element.Displayed);
        documents.Click();
        // проверка, что мы перешли на страницу документов
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.XPath("//h1[text()='Документы']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
      
        // кликнуть на "Компания"
        var structure = driver.FindElements(By.CssSelector("[data-tid='Structure']")).First(element => element.Displayed);
        structure.Click();
        // проверка, что мы перешли на страницу компании
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.XPath("//h1[text()='Тестовый холдинг']"));
        
        // кликнуть на боковое меню
        sideMenu.Click();
      
        // кликнуть на "Новости"
        var news = driver.FindElements(By.CssSelector("[data-tid='News']")).First(element => element.Displayed);
        news.Click();
        // проверка, что мы перешли на страницу новостей
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.XPath("//h1[text()='Новости']"));
        
        var currentUrl = driver.Url;
        currentUrl.Should().Be("https://staff-testing.testkontur.ru/news");
    }
    
    // тестирование появления валидации обязательных полей при создании мероприятия
    [Test]
    public void EventCreatorValidation()
    {
        // оджидание, пока загрузится главная страница
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        
        // перейти в раздел мероприятий
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru/events");
        
        // проверка, что мы перешли на страницу мероприятий
        driver.FindElement(By.CssSelector("[data-tid='Actual']"));
        driver.FindElement(By.XPath("//title[text()='Мероприятия']"));
        
        // кликнуть на "Создать"
        var createButton = driver.FindElement(By.CssSelector("[data-tid='AddButton']"));
        createButton.Click();
        
        // оджидание, пока загрузится меню создания мероприятия
        driver.FindElement(By.CssSelector("[data-tid='ModalPageHeader']"));
       
        // кликнуть на "Создать"
        var createButton1 = driver.FindElement(By.CssSelector("[data-tid='CreateButton']"));
        createButton1.Click();
        
        // проверка появления валидации
        var validation = driver.FindElement(By.CssSelector("[data-tid='validationMessage']"));
        validation.Should().NotBeNull();
    }
    
    
    // тестирование удаления папки в разделе файлы
    [Test]
    public void DeleteFolder()
    {
        // оджидание, пока загрузится главная страница
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        
        // перейти в раздел мероприятий
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru/files");
        
        // проверка, что мы перешли на страницу файлов
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        driver.FindElement(By.CssSelector("[title='Файлы']"));
        
        // кликнуть на "Добавить"
        var addButton = driver.FindElement(By.XPath("//span[text()='Добавить']"));
        addButton.Click();

        // кликнуть на "Папку"
        var CreateFolderButton = driver.FindElement(By.CssSelector("[data-tid='CreateFolder']"));
        CreateFolderButton.Click();
        
        // ввести название папки 
        var folderNameField = driver.FindElement(By.CssSelector("[data-tid='Input']"));
        var folderName = Guid.NewGuid().ToString("N");
        folderNameField.SendKeys(folderName);
        
        // кликнуть на "Сохранить"
        var saveButton = driver.FindElement(By.CssSelector("[data-tid='SaveButton']"));
        saveButton.Click();
        
        // найти созданную папку и перейти в нее
        var thisFolder = driver.FindElement(By.XPath("//div[text()='"+folderName+"']"));
        thisFolder.Click();
        
        // оджидание, пока загрузится страница
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        
        // кликнуть на настройки 
        var folderSettings = driver.FindElements(By.CssSelector("[data-tid='DropdownButton']"));
        folderSettings[1].Click();
        
        // кликнуть на "Удалить"
        var deleteButton = driver.FindElement(By.CssSelector("[data-tid='DeleteFile']"));
        deleteButton.Click();
        
        // кликнуть на "Удалить" в подтверждающем меню
        var deleteButton1 = driver.FindElement(By.CssSelector("[data-tid='DeleteButton']"));
        deleteButton1.Click();
        
        // проверка, что мы перешли на страницу файлов
        driver.FindElement(By.CssSelector("[data-tid='Title']"));
        
        // проверка удаления папки
        var findThisFolder = driver.FindElement(By.XPath("//div[text()='"+folderName+"']")).Displayed; 
        // тут у меня действительно ошибка, селениум почему то все равно видит эту папку и возвращает true
        // смотрел через девтулз - папка на стаффе отсутствует
        // (ошибка только в строке 230, до нее все отрабатывается корректно)
        findThisFolder.Should().BeFalse();
    }
    
    
    public void Authorization()
    {
        // перейти на сайт стаффа
        driver.Navigate().GoToUrl("https://staff-testing.testkontur.ru"); 

        // ввести логин 
        var login = driver.FindElement(By.Id("Username"));
        login.SendKeys("dimakoshk@hotmail.com");

        // ввести пароль
        var password = driver.FindElement(By.Name("Password"));
        password.SendKeys("Elephant27!");

        // нажать кнопку "войти"
        var enter = driver.FindElement(By.Name("button"));
        enter.Click();
        
    }
    
    [TearDown]
    public void TearDown()
    {
        // закрыть браузер и убить процесс драйвера
        driver.Close();
        driver.Quit();
    }
}



// явные оджидания - исп. DotNetSeleniumExtras
//var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3)); // в течении трех сек (каждые 100 мс) запрашивается верстка на странице // на практике берут 15 сек // может завершиться раньше 
//wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Username")));
//wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Username")));

//Assert.That(currentUrl == "https://staff-testing.testkontur.ru/news", "current url = " + currentUrl + " а должен быть https://staff-testing.testkontur.ru/news");