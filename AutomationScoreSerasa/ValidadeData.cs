using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationScoreSerasa
{
    public class ValidadeData
    {
        public bool ValiadePassword(string password) 
        {
            bool control = false;

            while (!control) 
            {
                if (String.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password is null or empty");

                    Console.WriteLine("Enter your password:");
                    password = Console.ReadLine();

                    continue;
                }
                else control = true;
            }

            return control;
        }

        public bool ValidateCPF(string CPF)
        {
            bool control = false;

            while (!control)
            {
                if (String.IsNullOrEmpty(CPF) || (CPF.Length != 11))
                {
                    Console.WriteLine($"{CPF} is invalid");

                    Console.WriteLine("Enter your CPF:");
                    CPF = Console.ReadLine();

                    continue;
                }
                else control = true;
            }

            return control;
        }
    }
}
