using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships;
using System;
using System.Threading;

namespace Battleships
{
    [TestClass]
    public class PlayGameTests
    {
        private Game _fixture = new Game();

        [TestInitialize]
        public void Setup()
        {

        }

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestMethod]
        public void PlayGame()
        {
            
            _fixture.NewGame();
            _fixture.Player1.FleetBoard.PrintBoard();
            _fixture.Player2.FleetBoard.PrintBoard();

            int Turn =0;
            do {
                Console.WriteLine($"Turn: {++Turn}");
                var missile = _fixture.Player1.TakeTurn(_fixture.Player2.FleetBoard);
                
                if(_fixture.Player2.FleetDestroyed)
                {
                    Console.WriteLine($"Player 1 wins");
                    break;
                }

                missile = _fixture.Player2.TakeTurn(_fixture.Player1.FleetBoard);

                if(_fixture.Player1.FleetDestroyed)
                {
                    Console.WriteLine($"Player 2 wins");
                    break;
                }

                //Thread.Sleep(5000);
            } while(!_fixture.IsGameOver());

            
        }
    }
}

