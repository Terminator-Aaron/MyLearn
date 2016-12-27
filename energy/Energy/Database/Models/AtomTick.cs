using System;
using System.Collections.Generic;

namespace Db.Models
{
    [Serializable]
    public partial class AtomTick
    {
        public long AtomID { get; set; }
        public long Tick { get; set; }
        public double Velocity { get; set; }
        public short DirectionX { get; set; }
        public short DirectionY { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public virtual Atom Atom { get; set; }
    }
}
