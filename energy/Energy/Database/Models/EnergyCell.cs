using System;
using System.Collections.Generic;

namespace Db.Models
{
    [Serializable]
    public partial class EnergyCell
    {
        public EnergyCell()
        {
            this.EnergyCellTicks = new List<EnergyCellTick>();
        }

        public long EnergyCellID { get; set; }
        public long ExperimentID { get; set; }
        public int Order { get; set; }
        public int CellX { get; set; }
        public int CellY { get; set; }
        public virtual ICollection<EnergyCellTick> EnergyCellTicks { get; set; }
        public virtual Experiment Experiment { get; set; }
    }
}
