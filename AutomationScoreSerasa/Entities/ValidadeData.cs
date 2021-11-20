using AutomationScoreSerasa.Interfaces;
using System;

namespace AutomationScoreSerasa.Entities
{
    public class ValidadeData : IValidate
    {
        private readonly Control control = new Control();

        public bool ValiadePassword(string password)
        {
            control.Control_ = false;

            while (!control.Control_)
            {
                if (String.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password is null or empty");

                    Console.Write("Enter your password: ");
                    password = Console.ReadLine();

                    continue;
                }
                else control.Control_ = true;
            }

            return control.Control_;
        }

        public bool ValidateCPF(string CPF)
        {
            control.Control_ = false;

            while (!control.Control_)
            {
                if (String.IsNullOrEmpty(CPF) || (CPF.Length != 11))
                {
                    Console.WriteLine($"{CPF} is invalid");

                    Console.Write("Enter your CPF: ");
                    CPF = Console.ReadLine();

                    continue;
                }
                else control.Control_ = true;
            }

            return control.Control_;
        }

        public bool ValidadeLogin(string msg) 
        {
            control.Control_ = true;
            if (!msg.Equals("Erro - Serasa"))
                control.Control_ = false;
                
            return control.Control_;
        }
    }
}
