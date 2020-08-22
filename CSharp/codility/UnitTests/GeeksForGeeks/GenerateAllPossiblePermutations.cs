using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateAllPossiblePermutations {

    public static class Extensions {

        public static List<string> PossiblePermutations(this string S)
        {
            var result = new List<string>();

            var mtx = Array.CreateInstance(typeof(int), S.Length, S.Length);
            int idx =0;
            foreach(var s in S) 
            {
                mtx.SetValue(char.GetNumericValue(s), idx, idx);
            }

            return result;
        }

        public static void Swap<T>(this ref T x, ref T y) where T : struct
        {
            T tmp = x; x = y; y = tmp;
        }

        public static string Swap(this string s, int idx1, int idx2)
        {
            var copy =  s.ToCharArray();
            copy[idx1] = s[idx2];
            copy[idx2] = s[idx1];
            
            return string.Join("", copy);
        }

        public static List<int> Permutations(this string s, int l, int r, int N)
        {
            var result = new List<int>();

            if(l == r) {
                int j = int.Parse(s);

                if(j % N ==0)
                {
                    result.Add(j);
                    return result;
                }
            }
            
            for(int i =l; i < r; ++i)
            {
                var swapped = s.Swap(i, l);
                result.AddRange(Permutations(swapped,l+1,r,N));
            }
            
            return result;
        }

    }

    
    public class Solution {

        public static void solution(string str, int n) {

            if(string.IsNullOrWhiteSpace(str))
                return;

            var results = str.Permutations(0, str.Length, n);
        }
    }

    [TestClass]
    public class Tests {

        [TestMethod]
        [DataRow("125", 5)]
        public void TestMethod(string str, int N) {

            Solution.solution(str, N);
        }
    }
}