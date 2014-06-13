using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifePolymorphicDispatch.Extensions;


namespace GameOfLifePolymorphicDispatch
{
    [Serializable]
    public class GameOfLife
    {
        List<Cell> gameBoard;
        List<Cell> newGameBoard = new List<Cell>();

        public GameOfLife( List<Cell> gameBoard )
        {
            this.gameBoard = gameBoard;

            newGameBoard = gameBoard.DeepClone();

        }

        public void Tick()
        {
             UnderPopulation underpopRule =  new UnderPopulation();

             underpopRule.ApplyRule(gameBoard, ref newGameBoard);

             gameBoard = newGameBoard.DeepClone();

        }

        public List<Cell> GetBoard()
        {
            return gameBoard;

        }

    }
}
