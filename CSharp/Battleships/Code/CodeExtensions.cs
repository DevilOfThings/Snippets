using System;

namespace Battleships.CodeExtensions {

    public static class CodeExtensions {

        public static int NextRow(this Random seed, int max=10)
        {
            return seed.Next(max);
        }

        public static int NextColumn(this Random seed, int max=10)
        {
            return seed.Next(max);
        }

        
    }
}