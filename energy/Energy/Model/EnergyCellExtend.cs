using Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EnergyCellExtend : EnergyCell
    {
        public double Energy { get; set; }
        public bool IsHotPot { get; set; }
    }
}
