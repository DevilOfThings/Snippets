using System.Collections.Generic;

namespace Battleships
{
    public class Position {
        public RowCol Start;
        public RowCol End;
        public List<RowCol> Occupies;

        

        public override string ToString() {
            return $"({Start.Row} {Start.Col})({End.Row} {End.Col})";
        }


        
    }
}