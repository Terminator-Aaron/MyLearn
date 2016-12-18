using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Atom : PositionBase
    {
        /// <summary>
        /// 体积/碰撞半径
        /// </summary>
        public double Rv { get; set; }

        /// <summary>
        /// 吸引力半径
        /// </summary>
        public double Ra { get; set; }

        /// <summary>
        /// 对周围吸引力
        /// </summary>
        public double Fa { get; set; }

        /// <summary>
        /// 受到周围影响的合力，会改变运动速度和方向
        /// </summary>
        public List<Direction> Fs { get; set; }

        /// <summary>
        /// 运动速度
        /// </summary>
        //public double v { get; set; }

        /// <summary>
        /// 运动方向速度/向量
        /// </summary>
        public Direction v { get; set; }
    }
}
