using System;
using System.Collections.Generic;

namespace Db.Models
{
    public partial class Atom
    {
        public Atom()
        {
            this.AtomTicks = new List<AtomTick>();
        }

        public long AtomID { get; set; }
        public long ExperimentID { get; set; }
        public int Order { get; set; }
        public double VolumeRadius { get; set; }
        public double AttractionRadius { get; set; }
        public double AttractionForce { get; set; }
        public virtual Experiment Experiment { get; set; }
        public virtual ICollection<AtomTick> AtomTicks { get; set; }
    }
}
