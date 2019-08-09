using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 移动距离的向量表示，
    /// 同一段距离，根据方向的不同，可以分解为先移动x，再移动y
    /// </summary>
    public class Move
    {
        public int DistanceX { get; set; }
        public int DistanceY { get; set; }
    }
}
