using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class Coordinates
    {
        public int row { get; set; }
        public int col { get; set; }

        /**
         * Coordinates default value constructor sets the value for the current Column coordinate
         * @return none
         */
        public Coordinates()
        {
            row = 0;
            col = 0;
        }

        /**
         * Coordinates explicit value constructor sets the value for the current Column coordinate
         * @param row, col column coordinate and int row coordinate
         * @return nothing
         */
        public Coordinates(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        /**
         * overridden toString function returns coordinates
         * @return Coordinate String
         */
        public override string ToString()
        {
            string coordinatesStr = " ";
            coordinatesStr += "(" + this.col + ", " + this.row + ")";
            return coordinatesStr;
        }


    }
}
