using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // 格子
    public class Cell : PositionBase
    {
        /// <summary>
        /// 单元格具有的能量
        /// </summary>
        public double Energy { get; set; }

        public bool IsHotPot { get; set; }
    }
}
