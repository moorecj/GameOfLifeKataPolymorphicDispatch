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

        List<Rules> listOfRules;
        List<Cell> gameBoard;
        List<Cell> newGameBoard = new List<Cell>();


        public GameOfLife( List<Cell> gameBoard )
        {
            this.gameBoard = gameBoard;

            newGameBoard = gameBoard.DeepClone();

            listOfRules = new List<Rules>();

            listOfRules.Add(new UnderPopulation());
            listOfRules.Add(new OverCrowding());
            listOfRules.Add(new Reproduction());


        }

        public void Tick()
        {

             newGameBoard = gameBoard.DeepClone();

             foreach( Rules r in listOfRules)
             {
                 r.ApplyRule(gameBoard, ref newGameBoard);    
             }
             
             gameBoard = newGameBoard.DeepClone();

        }

        public List<Cell> GetBoard()
        {
            return gameBoard;

        }

    }
}
