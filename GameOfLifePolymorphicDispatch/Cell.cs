using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePolymorphicDispatch
{
    [Serializable]
    public class Cell
    {
        private int x;
        private int y;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        } 
        
        public Cell()
        {
            x = 0;
            y = 0;
        }


        public int GetXCoordinate( )
        {
            return (x);
        }

        public int GetYCoordinate( )
        {
            return (y);
        }

        public bool IsNeighbor( Cell cell )
        {
            bool isNeighbor = false;

            if (IsWithinOneXDimension(cell) && IsWithinOneYDimension(cell) && IsNotSameCell(cell))
                isNeighbor = true;

            return (isNeighbor);

        }

        private bool IsNotSameCell(Cell cell)
        {
            return !(x == cell.GetXCoordinate() && y == cell.GetYCoordinate());
        }

        private bool IsWithinOneXDimension(Cell cell)
        {
            return (Math.Abs(x - cell.GetXCoordinate()) <= 1);
        }

        private bool IsWithinOneYDimension(Cell cell)
        {
            return (Math.Abs(y - cell.GetYCoordinate()) <= 1);
        }

        public int GetNeighborCount(List<Cell> posssibleNeighbors)
        {
            int neighborCount = 0;

            for (int i = 0; i < posssibleNeighbors.Count(); ++i)
            {

                foreach (Cell c in posssibleNeighbors.GetRange(i, posssibleNeighbors.Count() - i))
                {
                    if (posssibleNeighbors[i].IsNeighbor(c))
                        ++neighborCount;

                }

            }

            return neighborCount;
        }
 
    }
}
