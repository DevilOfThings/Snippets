using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;


namespace codility {

    [TestClass]
    public class ShellCodility1 {

        [TestInitialize]
        public void Setup() {

        }

        [TestCleanup]
        public void TearDown() {

        }

        [TestMethod]
        [DataRow("aaaabbbb", 1)]
        [DataRow("ccaaffddecee", 6)]
        public void SolutionTest(string input, int expected) {

            Console.WriteLine("Running SolutionTest");
            
            Assert.AreEqual(expected, Codility.solution(input));
        }


        public class Codility {

            public static int solution(string S) {

                var letters = Array.CreateInstance(typeof(int), 26);

                var grouped = S.GroupBy(l=>l).Select(n=> new { n.Key, Index = n.Key-97, Count = n.Count() });
                // var uniqueness = grouped.GroupBy(grouped=>grouped.Count)
                //         .Select(n=> new {n, Count = n.Count() })
                //         .OrderBy(n=>n.Count).Select(x=> new {x} );

                int remove =0;

                foreach(var l in grouped) {
                
                    letters.SetValue(l.Count,l.Index);
                }

                List<int> Counts = new List<int>();
                for(int idx =0; idx < letters.Length; ++idx) {
                    
                    while(Counts.Contains((int)letters.GetValue(idx)))
                    {
                        
                        ++remove;
                    }
                    
                }

                return remove;
            }


            public static int Sample(int[] A) {
                
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