using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections;

namespace GenerateParentheses {

    public class Solution {

        public static char left = '(';
        public static char right = ')';
        public static char[] pair = {'(', ')'};
        public static IList<string> GenerateParentheses(int n) {

            var result = new List<string>();
            var sb = new StringBuilder();
            
            if(n<0)
            return result;
            

              
                
                sb.Clear();

                if(n>1) {
                    // enclosed
                    for(int i=0; i < n; ++i) {
                        sb.Append(left);
                    }

                    for(int i=0; i < n; ++i) {
                        sb.Append(right);
                    }
                    result.Add(sb.ToString());
                    sb.Clear();

                    
                }
               
                 // seperate
                for(int i=0; i < n; ++i) {    
                    sb.Append(pair);    
                }
                result.Add(sb.ToString());
                sb.Clear();

                if(n >2) {

                    // outer
                    sb.Append(left);
                    for(int i=0; i < n-1; ++i) {    
                        sb.Append(pair);    
                    }
                    sb.Append(right);
                    result.Add(sb.ToString());
                    sb.Clear();

                    var pairs = Array.CreateInstance(typeof(string), n-1);
                    for(int idx = 0; idx < n-1;  ++idx) {

                        string[] array = new string[idx+1];
                        Array.Fill<string>(array, string.Join("", pair));
                        pairs.SetValue(string.Join("", array),idx);
                    }
                    

                    //foreach(var p in pairs) {
               
                        var sb2 = new StringBuilder();    
                        
                        int r = n-2;
                        for(int i=0; i < n-1; ++i) {    
                        
                            sb2.Append(left);
                            var parentheses = pairs.GetValue(i);
                            sb2.Append(parentheses);
                            sb2.Append(right);
                            var enclosed = sb2.ToString();
                            sb.Append( enclosed + pairs.GetValue(r));
                            
                            result.Add(sb.ToString());        
                            sb.Clear();
                            sb2.Clear();

                            r--;
                        }

                        sb2.Clear(); 
                        r = n-2;
                        for(int i=0; i < n-1; ++i) {    
                        
                            sb2.Append(left);
                            var parentheses = pairs.GetValue(i);
                            sb2.Append(parentheses);
                            sb2.Append(right);
                            var enclosed = sb2.ToString();
                            sb.Append( pairs.GetValue(r) + enclosed);
                            result.Add(sb.ToString());        
                            sb.Clear();
                            sb2.Clear();

                            r--;
                        }

                   // }

                    
                    sb.Clear();



                   


                }

            
            

            

            return result;
        }


    }

    [TestClass]
    public class SolutionTests {

        [TestMethod]
        [DataRow(4)]
        public void TestSolution(int n) {

            // ["(((())))","((()()))","((())())","((()))()","(()(()))","(()()())","(()())()","(())(())","(())()()","()((()))","()(()())","()(())()","()()(())","()()()()"]
            Solution.GenerateParentheses(n);
        }

    }
}