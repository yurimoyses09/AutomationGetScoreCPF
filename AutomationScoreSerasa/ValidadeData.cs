using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationScoreSerasa
{
    public class ValidadeData
    {
        public bool ValidateCPF(string CPF) 
        {
            bool controle = false;

            while (!controle)
            {
                if (String.IsNullOrEmpty(CPF) || (CPF.Length != 11))
                {
                    Console.WriteLine($"{CPF} is invalid");

                    Console.WriteLine("Enter your CPF:");
                    CPF = Console.ReadLine();

                    continue;
                }
                else
                    controle = true;
            }

            return controle;
        }
    }
}
