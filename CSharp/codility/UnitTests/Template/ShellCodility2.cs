using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;


namespace codility {

    [TestClass]
    public class ShellCodility2 {

        [TestInitialize]
        public void Setup() {

        }

        [TestCleanup]
        public void TearDown() {

        }

        [TestMethod]
        [DataRow("1,3,6,5,2", 4)]
        public void SolutionTest(string sinput, int expected) {

            Console.WriteLine("Running SolutionTest");
            var input = Array.ConvertAll(sinput.Split(','), int.Parse);
            Assert.AreEqual(expected, Codility.solution(input));
        }


        public class Codility {

            public static int solution(int[] A) {
                
                int smallest = A[0];

                var occurrences = Array.CreateInstance(typeof(bool), A.Length+1);
                
                foreach(var a in A) {

                    if(1<=a && a < A.Length) {

                        occurrences.SetValue(true, a-1);
                       
                    }

                    

                }

                
                foreach(var idx in Enumerable.Range(0, A.Length+1))
                {
                    if((bool)occurrences.GetValue(idx) ==false) {
                        return idx+1;
                    }


                }

                return -1;
            }
        }
    }
}