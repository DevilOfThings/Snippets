using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;


namespace codility {

    public class Solution {

        
        public static int solution3(int[] prices) {
            
          
           var max_profit =0;

           

            return max_profit;
        }

        public static int solution2(int[] prices) {
            
            int maxProfit =0;
            
            int index1 =-1;
            foreach(var bought in prices)
            //foreach(var (bought, index1) in prices.Select((value1, i1) => (value1, i1)))
            {
                index1++;
                var sold = prices.Skip(index1).Max();

                var profit = sold - bought;
                Console.WriteLine($"({index1}, {sold}) - ({bought}) = {profit}");
                if(profit > maxProfit)
                {
                    maxProfit = profit;
                }

            }
        
            return maxProfit;
        }
            public static int solution1(int[] A) {
            
            int maxProfit =0;
            

            int index1 = -1;
            foreach(var bought in A)
            //foreach(var (bought, index1) in A.Select((value1, i1) => (value1, i1)))
            {
                index1++;
                int index2 =-1;
                foreach(var sold in A) 
                //foreach(var (sold, index2) in A.Where(x=>x > maxProfit).Select((value2, i2) => (value2, i2))) 
                {
                    index2++;
                    if(index2>=index1)
                    {
                        var profit = sold - bought;
                        Console.WriteLine($"({index2}, {sold}) - ({index1}, {bought}) = {profit}");
                        if(profit > maxProfit)
                        {
                            maxProfit = profit;
                        }
                    }
                }
            }
        
            return maxProfit;
        }
    }
    [TestClass]
    public class MaximumSliceProblemTests {
        
        [TestInitialize]
        public void Setup() {

        }

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestMethod]
        [DataRow("23171,21011,21123,21366,21013,21367", 356)]
        public void MaxProfit(string prices, int expected)
        {
            var a = prices.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var priceList = Array.ConvertAll(a, int.Parse);

            var result = Solution.solution1(priceList);
            Assert.AreEqual(expected, result, $"expected {expected} result {result}");
            
            result = Solution.solution2(priceList);
            Assert.AreEqual(expected, result, $"expected {expected} result {result}");
        }
    }
}