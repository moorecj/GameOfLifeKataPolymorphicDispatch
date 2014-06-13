using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePolymorphicDispatch
{
    abstract class Rules
    {
        abstract public List<Cell> ApplyRule(List<Cell> gameBoard);

    }
}
