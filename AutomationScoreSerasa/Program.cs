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

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            bool returnPassword = validade.ValiadePassword(password);
            bool returnCPF = validade.ValidateCPF(CPF);

            if (returnCPF && returnPassword)
            {
                try
                {
                    driver = new ChromeDriver(@"C:\Users\ADM\Downloads\chromedriver_win32");

                    driver.Manage().Window.Maximize();
                    driver.Url = "https://www.serasa.com.br/";

                    element = driver.FindElement(By.CssSelector("#__next > div > div._2gVfaGGx.heimdall--overhide > div > header > div > div.ecs_hl_fc.ecs_hl_fd.ecs_hl_fe.ecs_hl_w.ecs_hl_x.ecs_hl_y > button"));
                    element.Click();

                    driver.FindElement(By.CssSelector("#f-cpf")).SendKeys(CPF);
                    element = driver.FindElement(By.CssSelector("#__next > div > div > div > div > div > div.jsx-574449350.sign-in > div > div > form > div.jsx-1222364814.ec-form-submit.--align-center > button"));
                    element.Click();

                    Thread.Sleep(5000);
                    if (driver.FindElement(By.CssSelector("#__next > div > div > div > div > div > div > div > div > p.jsx-574449350.sign-in__title.--align-center.eu-sm-3.ea-typography.ea-typography--heading-s.et-text-dark-high")).Text == "Algo deu errado por aqui!")
                    {
                        Console.WriteLine("Falha ao logar no Serasa");
                        driver.Close();
                    }
                    else 
                    {
                        driver.FindElement(By.CssSelector("#current-password")).SendKeys(password);
                        element = driver.FindElement(By.CssSelector("#__next > div > div > div > div > div > div.jsx-574449350.sign-in > div > div > form > div.jsx-1222364814.ec-form-submit.--align-center > button"));
                        element.Click();


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
