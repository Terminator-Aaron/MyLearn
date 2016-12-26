using System;
using System.Collections.Generic;

namespace Db.Models
{
    public partial class Experiment
    {
        public Experiment()
        {
            this.Atoms = new List<Atom>();
            this.EnergyCells = new List<EnergyCell>();
        }

        public long ExperimentID { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int StartCells { get; set; }
        public int StartHotPots { get; set; }
        public int StartAtoms { get; set; }
        public System.DateTime InitStartTime { get; set; }
        public System.DateTime InitEndTime { get; set; }
        public Nullable<System.DateTime> ExpStartTime { get; set; }
        public Nullable<System.DateTime> ExpEndTime { get; set; }
        public string ByWho { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<Atom> Atoms { get; set; }
        public virtual ICollection<EnergyCell> EnergyCells { get; set; }
    }
}
