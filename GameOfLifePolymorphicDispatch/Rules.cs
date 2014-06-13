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
            int neighborCount = 0;

            newGameBoard = gameBoard.DeepClone();

            for( int i = 0; i < gameBoard.Count(); ++i )
            {
                
                foreach ( Cell c in gameBoard.GetRange(i, gameBoard.Count() - i) )
                {
                    if (gameBoard[i].IsNeighbor(c))
                        ++neighborCount;

                }

                if (neighborCount < 2)
                    newGameBoard.Remove(newGameBoard[i]);
            }

        }
    }




}
