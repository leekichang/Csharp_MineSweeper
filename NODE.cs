using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Node
    {
        public int NearMine;
        public string Contents;
        public Node()
        {
            this.Contents = "-";
            this.NearMine = 0;
        }
    }
}
