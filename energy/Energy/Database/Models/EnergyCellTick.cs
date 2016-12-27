using System;
using System.Collections.Generic;

namespace Db.Models
{
    [Serializable]
    public partial class EnergyCellTick
    {
        public long EnergyCellID { get; set; }
        public long Tick { get; set; }
        public double Energy { get; set; }
        public bool IsHotPot { get; set; }
        public virtual EnergyCell EnergyCell { get; set; }
    }
}
