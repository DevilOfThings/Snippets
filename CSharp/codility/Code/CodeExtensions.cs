using System.Linq;
using System;

namespace CodeExtensions {

    public static class CodeExtensions {
        public static string dot_ToBinary(this int x)
        {
            char[] buff = new char[32];

            for(int i =31; i >= 0; --i)
            {
                int mask = 1 << i;
                buff[31 - i] = (x & mask) != 0 ? '1' : '0';
            }


            return new string(buff).TrimStart(new char[] { '0' });
        }

        public static int dot_findMaxBinaryGapInNumber(this int N)
        {
            int result =0;

            var binary = Convert.ToString(N, 2); // dot_ToBinary(N);
            int zeroCount =0;        
            
            foreach(var digit in binary)
            {
                if(digit == '1')
                {
                    if(zeroCount > result)
                    {
                        result = zeroCount;
                    }
                    zeroCount = 0;
                }
                else {
                    zeroCount++;
                }
            }
            return result;
        }

        public static int dot_findMaxBinaryGapInNumber2(this int N)
        {
            int result = 0;

            var binary = Convert.ToString(N, 2).ToList(); // dot_ToBinary(N).ToList();            
            int currentStart =0, idx1 =0, idx2 =0;
            
            do {
                //idx1 = binary.FindIndex(currentStart, (x) => { return x.Equals('1'); } );
                idx1 = binary.IndexOf('1', currentStart );
                if(idx1 ==-1)
                    break;
                //idx2 = binary.FindIndex(idx1+1, (x) => { return x.Equals('1'); } );
                idx2 = binary.IndexOf('1', idx1+1 );
                if(idx2 ==-1)
                    break;

                if(-1 != idx1 && -1 != idx2)
                {
                    if((idx2 - (idx1+1)) > result)
                    {
                        result = idx2 - (idx1+1);
                    }
                }
               
               currentStart = idx2+1;
            } while(idx1 != -1);

            return result;
        }
    }
}
