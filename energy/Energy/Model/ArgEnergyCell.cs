using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ArgEnergyCell:PositionBase
    {
        public List<Cell> RelactedCells { get; set; }
        public double ArgEnergy
        {
            get 
            {
                if (RelactedCells == null)
                {
                    return 0.0;
                }
                else
                {
                    return RelactedCells.Average(cell => cell.Energy);
                }
            }
        }
    }
}
