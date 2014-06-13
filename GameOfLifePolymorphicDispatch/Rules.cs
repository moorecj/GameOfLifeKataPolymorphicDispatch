using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLifePolymorphicDispatch.Extensions;

namespace GameOfLifePolymorphicDispatch
{
    public abstract class Rules
    {
        abstract public void ApplyRule(List<Cell> gameBoard, ref List<Cell> newGameBoard);

    }

    public class UnderPopulation : Rules
    {
        

        override public void ApplyRule(List<Cell> gameBoard, ref List<Cell> newGameBoard )
        {
            newGameBoard = gameBoard.DeepClone();

            for( int i = 0; i < gameBoard.Count(); ++i )
            {
                if (gameBoard[i].GetNeighborCount(gameBoard) < 2)
                    newGameBoard.Remove(newGameBoard[i]);
            }

        }

    }




}
