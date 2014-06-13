using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameOfLifePolymorphicDispatch;



namespace GameOfLifeTests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void ACellShouldHaveCoordinates()
        {
            Cell cell = new Cell(0, 0);

            Assert.That(cell.GetXCoordinate(), Is.EqualTo(0));
            Assert.That(cell.GetYCoordinate(), Is.EqualTo(0));

        }

    
        [Test]
        public void ACellShouldKnowIfAnotherCellIsHisNeighbor()
        {
            Cell cell = new Cell(0, 0);

            Cell neighborCell = new Cell(0, 1);

            Assert.That(cell.IsNeighbor(neighborCell), Is.EqualTo(true));

        }

        [Test]
        public void ACellShouldNotConsiderHimselfANeighbor()
        {
            Cell cell = new Cell(0, 0);

            Assert.That(cell.IsNeighbor(cell), Is.EqualTo(false));
        }

        [Test]
        public void AGameShouldTakeListOfCells()
        {
            Cell cell1 = new Cell(0, 0);

            List<Cell> gameBoard = new List<Cell>();

            gameBoard.Add(cell1);

            GameOfLife game = new GameOfLife(gameBoard);

            Assert.That(game, Is.Not.Null);

        }

        [Test]
        public void WithASingleLiveCell_OneTickShouldResultInNoLiveCells()
        {
            Cell cell1 = new Cell(0, 0);

            List<Cell> gameBoard = new List<Cell>();

            gameBoard.Add(cell1);

            GameOfLife game = new GameOfLife(gameBoard);

            game.Tick();

            Assert.That(game.GetBoard(), Is.Empty);


        }

        [Test]
        public void AnyCellWithTwoOrThreeLiveNeighbbors_WillSurviveAfterOneTick()
        {
            Cell cell1 = new Cell(0, 0);
            Cell cell2 = new Cell(1, 0);
            Cell cell3 = new Cell(0, 1);

            List<Cell> gameBoard = new List<Cell>();

            gameBoard.Add(cell1);
            gameBoard.Add(cell2);
            gameBoard.Add(cell3);

            GameOfLife game = new GameOfLife(gameBoard);

            game.Tick();

            Assert.That(game.GetBoard()[0].GetXCoordinate(), Is.EqualTo(0));
            Assert.That(game.GetBoard()[0].GetYCoordinate(), Is.EqualTo(0));

        }





    }
}
