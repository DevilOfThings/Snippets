using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships;
using System;

namespace Battleships
{
    [TestClass]
    public class BattleshipBoardTests
    {
        private BattleshipBoard _fixture = new BattleshipBoard();

        [TestInitialize]
        public void Setup()
        {

        }

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestMethod]
        [DataRow(ShipType.Battleship)]
        [DataRow(ShipType.Carrier)]
        [DataRow(ShipType.Destroyer)]
        [DataRow(ShipType.Cruiser)]
        [DataRow(ShipType.Submarine)]
        public void FindSpaceOnBoard(ShipType shipType)
        {
            var ship = ShipFactory.CreateShip(shipType);
            _fixture.FindSpaceOnBoard(ship);
            Assert.IsNotNull(ship.Position.Start.Row);
            Assert.IsNotNull(ship.Position.Start.Col);
            Assert.IsNotNull(ship.Position.Occupies);
        }

        [TestMethod]
        public void FindSpaceOnBoard2()
        {
            var battleship = ShipFactory.CreateShip(ShipType.Battleship);
            var carrier =ShipFactory.CreateShip(ShipType.Carrier);
            var cruiser = ShipFactory.CreateShip(ShipType.Cruiser);
            var destroyer = ShipFactory.CreateShip(ShipType.Destroyer);
            var submarine = ShipFactory.CreateShip(ShipType.Submarine);
            _fixture.FindSpaceOnBoard(battleship);
            _fixture.FindSpaceOnBoard(carrier);
            _fixture.FindSpaceOnBoard(cruiser);
            _fixture.FindSpaceOnBoard(destroyer);
            _fixture.FindSpaceOnBoard(submarine);
            _fixture.FindSpaceOnBoard(battleship);
            _fixture.FindSpaceOnBoard(carrier);
            _fixture.FindSpaceOnBoard(cruiser);
            _fixture.FindSpaceOnBoard(destroyer);
            _fixture.FindSpaceOnBoard(submarine);
            _fixture.FindSpaceOnBoard(battleship);
            _fixture.FindSpaceOnBoard(carrier);
            _fixture.FindSpaceOnBoard(cruiser);
            _fixture.FindSpaceOnBoard(destroyer);
            _fixture.FindSpaceOnBoard(submarine);

            Console.WriteLine($"battleship:{battleship.Position}");
            Console.WriteLine($"carrier:{carrier.Position}");
            Console.WriteLine($"cruiser:{cruiser.Position}");
            Console.WriteLine($"destroyer:{destroyer.Position}");
            Console.WriteLine($"submarine:{submarine.Position}");
        }

        [TestMethod]
        public void NewBoardTests()
        {
            _fixture.NewBoard();
        }

        [TestMethod]
        [DataRow(1,6,1,9)]
        [DataRow(2,9,2,6)]
        [DataRow(3,10,3,12)]
        [DataRow(4,6,4,9)]        
        public void AllocateGridPositionsTests(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            var positions = _fixture.AllocateGridPositions(new RowCol(rowStart,colStart), new RowCol(rowEnd,colEnd));
            positions.ForEach(x=> Console.Write($"({x.Row} {x.Col})"));
        }

        [TestMethod]
        public void PrintBoardTest()
        {
            _fixture.NewBoard();
            _fixture.PrintBoard();
        }

        
    }
}
