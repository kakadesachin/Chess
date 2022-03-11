using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEntities
{
    public record Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
