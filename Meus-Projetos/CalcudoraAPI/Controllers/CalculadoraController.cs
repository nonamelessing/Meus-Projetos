using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcudoraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalcudoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("Teste")]
        public ActionResult Teste()
        {
            return Ok();
        }

        [HttpGet("Soma/{nota1}/{nota2}")]
        public ActionResult<double> Somar(double nota1, double nota2)
        {
            CalculadoraModel calc = new CalculadoraModel(nota1, nota2);
            double soma = calc.Somar(nota1, nota2);
            return Ok(soma);
        }

        [HttpGet("Subtração/{nota1}/{nota2}")]
        public ActionResult<double> Subtrair(double nota1, double nota2)
        {
            CalculadoraModel calc = new CalculadoraModel(nota1, nota2);
            double sub = calc.Subtrair(nota1, nota2);
            return Ok(sub);
        }

        [HttpGet("Multiplicação/{nota1}/{nota2}")]
        public ActionResult<double> Multiplicacao(double nota1, double nota2)
        {
            CalculadoraModel calc = new CalculadoraModel(nota1, nota2);
            double mult = calc.Multiplicacao(nota1, nota2);
            return Ok(mult);
        }

        [HttpGet("Divisão/{nota1}/{nota2}")]
        public ActionResult<double> Divisao(double nota1, double nota2)
        {
            CalculadoraModel calc = new CalculadoraModel(nota1, nota2);
            double div = calc.Divisao(nota1, nota2);
            return Ok(div);
        }
        
        [HttpGet("Media/{nota1}/{nota2}")]
        public ActionResult<double> Media(double nota1, double nota2)
        {
            CalculadoraModel calc = new CalculadoraModel(nota1,nota2);
            double media = calc.Media(nota1,nota2);
            return Ok(media);
        }
    }
}