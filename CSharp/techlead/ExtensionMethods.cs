using System;
using System.Linq;
using System.Collections.Generic;

namespace techlead {
    public static class RansomNote
        {
            public static bool CanSpell(this List<char> magazine, string word)
            {
                bool result = true;

                foreach(var letter in word)
                {
                    var found = magazine.IndexOf(letter);
                    if(found !=-1)
                    {
                        magazine.RemoveAt(found);
                        continue;
                    }

                    result = false;
                    break;
                }

                return result;
            }
        }
}