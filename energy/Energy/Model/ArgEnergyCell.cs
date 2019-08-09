using Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ArgEnergyCell
    {
        public int CellX { get; set; }
        public int CellY { get; set; }

        public List<EnergyCellExtend> RelactedCells { get; set; }
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
