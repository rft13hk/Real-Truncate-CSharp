using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> lst = new List<decimal>();

            lst.Add(10.45678m);
            lst.Add(0.45678m);
            lst.Add(10.45m);
            lst.Add(10m);
            lst.Add(.45m);
            lst.Add(10.456999999m);
            lst.Add(1012345.456999999m);

            foreach (var item in lst)
            {
                //Console.WriteLine(RealDecTrunc(item, 4));
                //Console.WriteLine("Item : {0} | RealDecTrunc = {1}",item, DecimalTrunck(item, 4).ToString());

                Console.WriteLine("Item : {0} | RealDecTrunc = {1}", item, item.RealTrunck(4));

            }

            Console.ReadKey();
        }

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

        static decimal DecimalTrunck(decimal value, int number)
        {
            var strZeros = new String('0', (number + 2));
            decimal MaxDecToCalc = Convert.ToDecimal(String.Concat("1", strZeros, ",", strZeros)) + value;

            if (MaxDecToCalc.ToString().IndexOf(",") == -1)
            {
                return  value;
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
