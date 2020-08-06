using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;


namespace codility {

    [TestClass]
    public class Template {

        [TestInitialize]
        public void Setup() {

        }

        [TestCleanup]
        public void TearDown() {

        }

        [TestMethod]
        [DataRow("3,6,5,8", 3)]
        public void SolutionTest(string sinput, int expected) {

            Console.WriteLine("Running SolutionTest");
            var input = Array.ConvertAll(sinput.Split(','), int.Parse);
            Assert.AreEqual(expected, Codility.solution(input));
        }


        public class Codility {

            public static int solution(int[] A) {
                return 3;
            }
        }
    }
}