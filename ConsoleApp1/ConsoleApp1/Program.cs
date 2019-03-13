using System;
using System.Collections.Generic;
using System.Threading;

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
            char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            var strZeros = new String('0', (number + 2));
            decimal MaxDecToCalc = Convert.ToDecimal(String.Concat("1", strZeros, separator, strZeros)) + value;

            if (MaxDecToCalc.ToString().IndexOf(separator) == -1)
            {
                return value;
            }

            var lst = MaxDecToCalc.ToString().Split(separator);

            while (lst[1].Length < number)
            {
                lst[1] += "0";
            }

            var stringConcat = string.Concat(Convert.ToInt32(lst[0].Substring(1)).ToString(), separator, lst[1].Substring(0, number));

            int p = stringConcat.Length;

            while ((stringConcat[p-1] == '0') && p >= 0)
            {
                p--;
            }

            stringConcat = stringConcat.Substring(0, p);

            return Convert.ToDecimal(stringConcat);
        }

        public static string RealTrunckToString(this decimal value, int number, bool forceZeros = false)
        {
            char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            var valueTrunc = value.RealTrunck(number);
            string result;

            if (forceZeros)
            {
                result = valueTrunc.ToString(string.Concat("N", number.ToString()));
            }
            else
            {
                result = valueTrunc.ToString();
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> lst = new List<decimal>
            {
                10.45678m
                ,0.45678m
                ,10.45m
                ,10m
                ,.45m
                ,10.456999999m
                ,1012345.456999999m
            };

            foreach (var item in lst)
            {
                //Console.WriteLine("V: {0} |RealTrunck= {1} |RealTrunckToString= {2} |ForceZeroOn= {3} |N4= {4}", item, item.RealTrunck(4), item.RealTrunckToString(4, true), item.RealTrunckToString(4, false), item.ToString("N4"));
                Console.WriteLine("Va= {0} |RealTrunck= {1} |RealTrunckToString= {2} |ForceZeroOn= {3} |N4= {4}", item, item.RealTrunck(4), item.RealTrunckToString(4, true), item.RealTrunckToString(4, false), item.ToString("N4"));
                Console.WriteLine(new string('-', 80));
            }

            Console.ReadKey();
        }
    }
}
