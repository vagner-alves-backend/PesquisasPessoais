using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrincipioDeInterface.Models.Interface;

namespace PrincipioDeInterface.Models.Services
{
    public class Division : IOperation
    {
        public double Execulte (double firstNumber, double secondNumber) => firstNumber / secondNumber;
    }
}