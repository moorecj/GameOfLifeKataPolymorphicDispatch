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

        protected void RemoveCell( ref List<Cell> gameBoard, Cell cellToRemove  )
        {
            foreach (Cell c in gameBoard)
            {
                if (c == cellToRemove)
                {
                    gameBoard.Remove(c);
                    break;
                }
            }

        }

    }

    public class UnderPopulation : Rules
    {
        override public void ApplyRule(List<Cell> gameBoard, ref List<Cell> newGameBoard )
        {
            for( int i = 0; i < gameBoard.Count(); ++i )
            {
                if( gameBoard[i].GetNeighborCount(gameBoard) < 2)
                {
                    RemoveCell(ref newGameBoard, gameBoard[i]);  
                }    
            }

        }

    }

    public class OverCrowding : Rules
    {
        public override void ApplyRule(List<Cell> gameBoard, ref List<Cell> newGameBoard)
        {
            for (int i = 0; i < gameBoard.Count(); ++i)
            {
                if (gameBoard[i].GetNeighborCount(gameBoard) > 3)
                {
                    RemoveCell(ref newGameBoard, gameBoard[i]);
                }
 
            }
            
        }
    }

    public class Reproduction : Rules
    {
        public override void ApplyRule(List<Cell> gameBoard, ref List<Cell> newGameBoard)
        {

            for (int i = 0; i < gameBoard.Count(); ++i)
            {
                for(int x = -1; x < 2; ++x )
                {
                    for(int y = -1; y < 2; ++y)
                    {
                        Cell neighbor = new Cell(gameBoard[i].GetXCoordinate() + x, gameBoard[i].GetYCoordinate() + y);

                        if (CellIsDead(neighbor, gameBoard))
                        {
                            if (CellIsDead(neighbor, newGameBoard))
                            {
                                if (neighbor.GetNeighborCount(gameBoard) == 3)
                                {
                                    newGameBoard.Add(neighbor);
                                }

                            }

                        }

                    }

                }

            }
            
        }

        private bool CellIsDead( Cell cell, List<Cell> gameBoard )
        {
            return !(gameBoard.Exists(c => c == cell));

        }
    }

    




}
