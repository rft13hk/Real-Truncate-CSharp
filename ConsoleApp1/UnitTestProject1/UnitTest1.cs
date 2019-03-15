using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRealTrunck()
        {
            // Massa de teste em 4 casas
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
                , {1012345.0004999999m, 1012345.0004m }
                , {1m, 1m }
                , {0m, 0m }
                , {-1m, -1m }
                , {-10.456789m, -10.4567m }
                , {-10.45678m, -10.4567m }
                , {-0.45678m, -0.4567m }
                , {-10.45m, -10.45m }
                , {-10m, -10m }
                , {-.45m, -0.45m }
                , {-10.456999999m, -10.4569m }
                , {-1012345.456999999m, -1012345.4569m }
                , {-1012345.0004999999m, -1012345.0004m }
            };

            foreach (var item in lst)
            {
                Assert.AreEqual(item.Value, item.Key.RealTrunck(4));
            }

        }

        [TestMethod]
        public void RealTrunckToString()
        {
            char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            // Massa de teste em 4 casas
            var lst = new SortedList<decimal, string>()
            {
                {10.456789m, "10.4567".Replace('.', separator) }
                , {10.45678m, "10.4567".Replace('.', separator) }
                , {0.45678m, "0.4567".Replace('.', separator) }
                , {10.45m, "10.45".Replace('.', separator) }
                , {10m, "10".Replace('.', separator) }
                , {.45m, "0.45".Replace('.', separator) }
                , {10.456999999m, "10.4569".Replace('.', separator) }
                , {1012345.456999999m, "1012345.4569".Replace('.', separator) }
            };

            foreach (var item in lst)
            {
                Assert.AreEqual(item.Value, item.Key.RealTrunckToString(4));
            }

        }
    }
}
