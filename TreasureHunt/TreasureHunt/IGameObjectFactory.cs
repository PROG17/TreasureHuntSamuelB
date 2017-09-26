using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    interface IGameObjectFactory
    {
        GameObject TryCreateFromChar(char ch, int x, int y);
    }
}
