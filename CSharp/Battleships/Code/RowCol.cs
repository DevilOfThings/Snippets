namespace Battleships
{
    public class RowCol {

        public const int MaxCol =10;
        public const int MaxRow =10;

        public RowCol(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public int Row;
        public int Col;

        public bool IsValid() => Row >-1 && Row < MaxRow && Col > -1 && Col < MaxCol;

        public RowCol FindAdjacentEmptyCell(BattleshipBoard board)
        {
            RowCol AdjacentEmptyCell;

            bool IsAdjacentEmpty()
            {
                return AdjacentEmptyCell.IsValid() && board.findPossibleTarget(AdjacentEmptyCell);
            }

            AdjacentEmptyCell = new RowCol(Row+1, Col);
            if(IsAdjacentEmpty()) 
            {
                return AdjacentEmptyCell;
            }
            
            AdjacentEmptyCell = new RowCol(Row, Col+1);
            if(IsAdjacentEmpty()) 
            {
                return AdjacentEmptyCell;
            }

            AdjacentEmptyCell = new RowCol(Row-1, Col);
            if(IsAdjacentEmpty()) 
            {
                return AdjacentEmptyCell;
            }

            AdjacentEmptyCell = new RowCol(Row, Col-1);
            if(IsAdjacentEmpty()) 
            {
                return AdjacentEmptyCell;
            }
            
            return new RowCol(-1,-1);
        } 
    }
}