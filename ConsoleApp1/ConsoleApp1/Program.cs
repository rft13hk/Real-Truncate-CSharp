using System;
using System.Collections.Generic;
/// <summary>
/// Programa com função truncate.
/// </summary>
/// <Autor>
/// Ronaldo Francisco Tolentino
/// </Autor>
/// <e-mail>
/// rft13hk@outlook.com
/// </e-mail>
namespace ConsoleApp1
{
    //namespace MyProject.ExtensionMethods.Decimal
    //{
    public static class Decimal
    {
        public static decimal RealTrunck(this decimal value, int number)
        {
            var strZeros = new String('0', (number + 2));
            decimal MaxDecToCalc = Convert.ToDecimal(String.Concat("1", strZeros, ",", strZeros)) + value;

            if (MaxDecToCalc.ToString().IndexOf(",") == -1)
            {
                return value;
            }

            var lst = MaxDecToCalc.ToString().Split(',');

            while (lst[1].Length < number)
            {
                lst[1] += "0";
            }

            var retorno = string.Concat(Convert.ToInt32(lst[0].Substring(1)).ToString(), ",", lst[1].Substring(0, number));

            return Convert.ToDecimal(retorno);
        }

        public static string RealTrunckToString(this decimal value, int number, bool forceZeros)
        {
            return (forceZeros ? value.RealTrunck(number).ToString('.' + new String('0', number)) : value.RealTrunck(number).ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> lst = new List<decimal>
            {
                10.45678m,
                0.45678m,
                10.45m,
                10m,
                .45m,
                10.456999999m,
                1012345.456999999m
            };

            foreach (var item in lst)
            {
                //Console.WriteLine(RealDecTrunc(item, 4));
                //Console.WriteLine("Item : {0} | RealDecTrunc = {1}",item, DecimalTrunck(item, 4).ToString());

                Console.WriteLine("Item : {0} | RealDecTrunc = {1}", item, item.RealTrunck(4));
                Console.WriteLine("Item : {0} | RealDecTrunc = {1}", item, item.RealTrunckToString(4, true));
                Console.WriteLine(new string('-', 80));

            }

            Console.ReadKey();
        }

        /// <summary>
        /// Truncar um numero decimal como apresentado, sem arredondamento.
        /// </summary>
        /// <param name="value">Valor a ser truncado</param>
        /// <param name="number">quantidade de casas decimais</param>
        /// <param name="ForceZeros">se o numero tiver menos casas decimais, o mesmo ira forcar a quantidade de casas conforme casas informadas</param>
        /// <returns>Numero truncado</returns>
        static string RealDecTrunc(decimal value, int number, bool ForceZeros = true)
        {
            var strZeros = new String('0', (number + 2));
            decimal MaxDecToCalc = Convert.ToDecimal(String.Concat("1", strZeros, ".", strZeros)) + value;

            if (MaxDecToCalc.ToString().IndexOf(",") == -1)
            {
                return (ForceZeros ? value.ToString('.' + new String('0', number)) : value.ToString());
            }

            var lst = MaxDecToCalc.ToString().Split(',');

            while (lst[1].Length < number)
            {
                lst[1] += "0";
            }

            return string.Concat(Convert.ToInt32(lst[0].Substring(1)).ToString(), ".", lst[1].Substring(0, number));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static decimal DecimalTrunck(decimal value, int number)
        {
            var strZeros = new String('0', (number + 2));
            decimal MaxDecToCalc = Convert.ToDecimal(String.Concat("1", strZeros, ",", strZeros)) + value;

            if (MaxDecToCalc.ToString().IndexOf(",") == -1)
            {
                return value;
            }

            var lst = MaxDecToCalc.ToString().Split(',');

            while (lst[1].Length < number)
            {
                lst[1] += "0";
            }

            var retorno = string.Concat(Convert.ToInt32(lst[0].Substring(1)).ToString(), ",", lst[1].Substring(0, number));

            return Convert.ToDecimal(retorno);
        }

    }
}
