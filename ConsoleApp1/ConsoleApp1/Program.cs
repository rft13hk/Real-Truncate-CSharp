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

            var valueAbs = Math.Abs(value);

            int LenSizePart1 = valueAbs.ToString().IndexOf(separator);

            if (LenSizePart1 == -1)
            {
                LenSizePart1 = valueAbs.ToString().Length;
            }
                        
            string sinal = (valueAbs < 0 ? "-1" : "1");

            var strZeros = new String('0', (LenSizePart1 + 2));
            decimal MaxDecToCalc = Convert.ToDecimal(String.Concat(sinal, strZeros, separator, strZeros)) + valueAbs;

            if (MaxDecToCalc.ToString().IndexOf(separator) == -1)
            {
                return valueAbs;
            }

            var lst = MaxDecToCalc.ToString().Split(separator);

            while (lst[1].Length < number)
            {
                lst[1] += "0";
            }

            var stringConcat = string.Concat(Convert.ToInt32(lst[0].Substring(1)).ToString(), separator, lst[1].Substring(0, number));

            int p = stringConcat.Length;

            while ((stringConcat[p - 1] == '0') && p >= 0)
            {
                p--;
            }

            stringConcat = stringConcat.Substring(0, p);

            var result = (value < 0 ? Convert.ToDecimal(stringConcat) * -1 : Convert.ToDecimal(stringConcat));
            return result;
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
            var lst = new SortedList<decimal, decimal>()
            {
                {10.456789m, 10.4567m }
                , {10.45678m, 10.4567m }
                , {0.45678m, 0.4567m }
                , {10.45m, 10.45m }
                , {10m, 10m }
                , {.45m, 0.45m }
                , {10.456999999m, 10.4569m }
                , {1012345.456999999m, 1012345.4569m }
                , {1m, 1m }
                , {0m, 0m }
                , {-1m, -1m }
            };

            foreach (var item in lst)
            {
                //Assert.AreEqual(item.Key.RealTrunck(4), item.Value);
            }

            foreach (var item in lst)
            {
                //Console.WriteLine("V: {0} |RealTrunck= {1} |RealTrunckToString= {2} |ForceZeroOn= {3} |N4= {4}", item, item.RealTrunck(4), item.RealTrunckToString(4, true), item.RealTrunckToString(4, false), item.ToString("N4"));
                Console.WriteLine("Va= {0} |RealTrunck= {1} |RealTrunckToString= {2} |ForceZeroOn= {3} |N4= {4}", item.Key , item.Key.RealTrunck(4), item.Key.RealTrunckToString(4, true), item.Key.RealTrunckToString(4, false), item.Key.ToString("N4"));
                Console.WriteLine(new string('-', 80));
            }

            Console.ReadKey();
        }
    }
}