using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Linq;


namespace letterCombinationsOfAPhoneNumber {

    
    public static class Solution {

        public static Dictionary<int, string> digits2Letters = new Dictionary<int, string>()
        {               {2, "abc"}, {3, "def"},
           {4, "ghi"},  {5, "jkl"}, {6, "mno"},
           {7, "pqrs"}, {8, "tuv"}, {9, "wxyz"},
        };
        public static IList<string> LetterCombinations(string digits) {

            var results = new List<string>();
            
            if(string.IsNullOrEmpty(digits))
                return results;

            var stack = new Stack<char>();
            LetterCombinations(digits, results, stack, 0);

            return results;
        }

        public static void LetterCombinations(string digits, IList<string> results, Stack<char> stack, int depth) 
        {   
            if(digits.Length == depth) {
                results.Add(string.Join("", stack.Reverse()));
                return;
            }         

            var number = (int)char.GetNumericValue(digits[depth]);
            var letters = digits2Letters[number];
            foreach(var letter in letters) {
                stack.Push(letter);

                LetterCombinations(digits, results, stack, depth+1);

                stack.Pop();
            }
        }
    }

    

    [TestClass]
    public class SolutionTests {

        [TestMethod]
        [DataRow("2", "a,b,c")] // 2-9
        [DataRow("23", "ad,ae,af,bd,be,bf,cd,ce,cf")]              
        [DataRow("234", "adg,adh,adi,aeg,aeh,aei,afg,afh,afi,bdg,bdh,bdi,beg,beh,bei,bfg,bfh,bfi,cdg,cdh,cdi,ceg,ceh,cei,cfg,cfh,cfi")]
        public void LetterCombinationTests(string digits, string expected)
        {
            var expectedList = expected.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var combinations = Solution.LetterCombinations(digits);

            var difference1 =combinations.Except(expectedList);
            var difference2 =expectedList.Except(combinations);

            Assert.IsFalse(difference1.Any() && difference2.Any(), "Differences found");
        }
    }

}