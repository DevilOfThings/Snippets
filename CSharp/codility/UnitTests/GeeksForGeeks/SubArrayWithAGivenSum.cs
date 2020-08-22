using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SubArrayWithAGivenSum {

    // https://practice.geeksforgeeks.org/problems/subarray-with-given-sum/0

    public static class Extensions {

        public static IEnumerable<(T ITestMethod, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item,index) =>  (item, index));
        }
    }
        
    public class Solution {

        public static (int,int) SubArrayWithGivenSum(int[] A, int S) {

            // TODO: Missing sum S check Doh!

            var B = new int[A.Length];
            Array.Copy(A, B, A.Length);
            Array.Sort(B);

            int startingIdx = -1, endingIdx = -1;
            var subArrays = new Dictionary<int, int>();
            int lastItem =0;
            foreach(var (item,index) in B.Select( (item,index) => (item,index))) {
                
                if(startingIdx==-1) {
                    startingIdx = endingIdx = index;
                    lastItem = item;
                    subArrays[startingIdx] = endingIdx;
                    continue;
                }

                if(item == lastItem+1) {
                    endingIdx = index;
                    lastItem = item;
                    subArrays[startingIdx] = endingIdx;
                    continue;
                }

                subArrays[startingIdx] = endingIdx;
                startingIdx = endingIdx = -1;
                
            }

            var query = subArrays.Aggregate(
                (l,r) => l.Value - l.Key > r.Value - r.Key ? l : r);
            
            return (query.Key+1,query.Value);
        }
    }

    [TestClass]
    public class SubArrayWithGivenSumTests {

        [TestMethod]
        [DataRow(new int[] {1,2,3,7,5}, 12, 5,4)]
        [DataRow(new int[] {1,2,3,4,5,6,7,8,9,10}, 10, 5,4)]
        public void SolutionTests(int[] A, int S, int expected1, int expected2)
        {

            var result = Solution.SubArrayWithGivenSum(A, S);
            Assert.AreEqual(result.Item1, expected1);
            Assert.AreEqual(result.Item2, expected2);
        }
    }
}
