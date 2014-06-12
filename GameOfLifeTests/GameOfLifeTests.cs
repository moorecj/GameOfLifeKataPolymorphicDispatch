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


    }
}
