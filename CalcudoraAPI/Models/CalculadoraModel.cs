using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CalcudoraAPI.Models
{
    public class CalculadoraModel
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public double Resultado { get; set; }

        public CalculadoraModel(double a, double b)
        {
            this.Valor1 = a;
            this.Valor2 = b;
        }

        public double Somar(double a, double b)
        {
            Resultado = a + b;
            return Resultado;
        }

        public double Subtrair(double a, double b)
        {
            Resultado = a - b;
            return Resultado;
        }
        
        public double Divisao(double a, double b)
        {
            Resultado = a / b;
            return Resultado;
        }

        public double Multiplicacao(double a, double b)
        {
            Resultado = a * b;
            return Resultado;
        }

        public double Media(double a, double b)
        {
            double soma = Somar(a, b);
            double media = soma / 2;

            Resultado = media;
            return Resultado;
        }
    }
}