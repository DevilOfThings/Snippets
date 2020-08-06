using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;


namespace codility {

    public class Solution2 {

        public static int solution(int[] A) 
        {

            var occurrence = Array.CreateInstance(typeof(bool), A.Length+1);

            foreach(var item in A) {
                if(1 <= item && item <= A.Length+1) {
                    occurrence.SetValue(true, item-1);
                }
            }

            foreach(var idx in Enumerable.Range(0, A.Length+1)) {
                if((bool)occurrence.GetValue(idx) == false) {
                    return idx+1;
                }
            }

            
            return -1;
        }
    }

    [TestClass]
        
    public class SampleTests {

        [TestMethod]
        [DataRow("1,3,10,4,1,2", 5)]
        public void TestMethod1(string input, int expected) {

            var x = Array.ConvertAll(input.Split(','), int.Parse);
            Assert.AreEqual(expected, Solution2.solution(x));
        }


    }
}