using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePolymorphicDispatch
{
    [Serializable]
    public class Cell : IEquatable<Cell>
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

            
            foreach (Cell c in posssibleNeighbors)
            {
                if (this.IsNeighbor(c))
                    ++neighborCount;

            }


            return neighborCount;
        }


        public bool Equals (Cell other )
        {
            if (other == null)
                return false;

            if (((this.GetXCoordinate() - other.GetXCoordinate()) == 0) && ((this.GetYCoordinate() - other.GetYCoordinate()) == 0))
            {
                return true;
            }
            else
                return false;

        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Cell cellObj = obj as Cell;
            if (cellObj == null)
                return false;
            else
                return Equals(cellObj);
        }

        public static bool operator ==(Cell cell1, Cell cell2)
        {
            if ((object)cell1 == null || ((object)cell2) == null)
                return Object.Equals(cell1, cell2);

            return cell1.Equals(cell2);
        }

        public static bool operator !=(Cell cell1, Cell cell2)
        {
            if (cell1 == null || cell2 == null)
                return !Object.Equals(cell1, cell2);

            return !(cell1.Equals(cell2));
        }


 
    }
}
