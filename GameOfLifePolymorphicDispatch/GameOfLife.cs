using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePolymorphicDispatch
{
    public class GameOfLife
    {
        List<Cell> gameBoard;

        public GameOfLife( List<Cell> gameBoard )
        {
            this.gameBoard = gameBoard;

        }

        public void Tick()
        {

        }

        public List<Cell> GetBoard()
        {

            return gameBoard;

        }

    }
}
