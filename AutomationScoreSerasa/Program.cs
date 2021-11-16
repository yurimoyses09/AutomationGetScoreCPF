using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AutomationScoreSerasa
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidadeData validade = new ValidadeData();

            IWebDriver driver;
            IWebElement element;

            Console.WriteLine("Enter your CPF:");
            string CPF = Console.ReadLine();

            bool returnCPF = validade.ValidateCPF(CPF);

            if (returnCPF)
            {
                try
                {
                    driver = new ChromeDriver(@"C:\Users\ADM\Downloads\chromedriver_win32");

                    // maximize browser window
                    driver.Manage().Window.Maximize();
                    // serasa access link
                    driver.Url = "https://www.serasa.com.br/";

                    // Search element in window - Button 'Entrar'
                    element = driver.FindElement(By.CssSelector("#__next > div > div._2gVfaGGx.heimdall--overhide > div > header > div > div.ecs_hl_fc.ecs_hl_fd.ecs_hl_fe.ecs_hl_w.ecs_hl_x.ecs_hl_y > button"));
                    Thread.Sleep(5000);
                    element.Click();

                    // Enter the CPF informad
                    driver.FindElement(By.CssSelector("#f-cpf")).SendKeys(CPF);
                    Thread.Sleep(5000);
                    // Search element in window - Button 'Continuar' the click 
                    element = driver.FindElement(By.CssSelector("#__next > div > div > div > div > div > div.jsx-574449350.sign-in > div > div > form > div.jsx-1222364814.ec-form-submit.--align-center > button"));
                    element.Click();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
