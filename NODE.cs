using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class NODE
    {
        public int NearMine;
        public string Contents;
        public NODE()
        {
            this.Contents = "-";
            this.NearMine = 0;
        }
    }
}
