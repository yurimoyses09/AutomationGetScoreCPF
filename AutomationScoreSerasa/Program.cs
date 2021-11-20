using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using AutomationScoreSerasa.Entities;

namespace AutomationScoreSerasa
{
    class Program
    {
        #region Classes Estaticas
        
        static IWebDriver driver;
        static IWebElement element;

        #endregion

        static void Main(string[] args)
        {
            ValidadeData validade = new ValidadeData();
            User user = new User();

            // Entrada de dados
            Console.Write("Enter your CPF: ");
            user.Cpf = Console.ReadLine();
            Console.Write("Enter your password: ");
            user.PassWord = Console.ReadLine();

            // Verificação dos dados
            bool returnPassword = validade.ValiadePassword(user.PassWord);
            bool returnCPF = validade.ValidateCPF(user.Cpf);

            if (returnCPF && returnPassword)
            {
                try
                {
                    driver = new ChromeDriver(@"C:\Users\ADM\Downloads\chromedriver_win32");

                    driver.Manage().Window.Maximize();
                    driver.Url = "https://www.serasa.com.br/";

                    element = driver.FindElement(By.CssSelector("#__next > div > div._2gVfaGGx.heimdall--overhide > div > header > div > div.ecs_hl_fc.ecs_hl_fd.ecs_hl_fe.ecs_hl_w.ecs_hl_x.ecs_hl_y > button"));
                    element.Click();

                    driver.FindElement(By.CssSelector("#f-cpf")).SendKeys(user.Cpf);
                    element = driver.FindElement(By.CssSelector("#__next > div > div > div > div > div > div.jsx-574449350.sign-in > div > div > form > div.jsx-1222364814.ec-form-submit.--align-center > button"));
                    element.Click();

                    Thread.Sleep(5000);
                    bool login = validade.ValidadeLogin(driver.Title);

                    if (login) 
                        Console.WriteLine("Falha ao logar no Serasa");
                    else
                    {
                        driver.FindElement(By.CssSelector("#current-password")).SendKeys(user.PassWord);
                        element = driver.FindElement(By.CssSelector("#__next > div > div > div > div > div > div.jsx-574449350.sign-in > div > div > form > div.jsx-1222364814.ec-form-submit.--align-center > button"));
                        element.Click();

                        if (login) 
                            Console.WriteLine("Falha ao logar no Serasa");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                {
                    driver.Close();
                    driver.Quit();
                }
            }
        }
    }
}
