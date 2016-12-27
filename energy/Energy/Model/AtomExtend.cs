using Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class AtomExtend : Atom
    {
        ///// <summary>
        ///// 体积/碰撞半径
        ///// </summary>
        //public double VolumeRadius { get; set; }

        ///// <summary>
        ///// 吸引力半径，吸引力起作用范围
        ///// </summary>
        //public double AttractionRadius { get; set; }

        ///// <summary>
        ///// 对周围吸引力
        ///// </summary>
        //public double AttractionForce { get; set; }

        #region 原子Tick

        /// <summary>
        /// 运动速度
        /// </summary>
        public double Velocity { get; set; }

        /// <summary>
        /// 运动方向的X
        /// </summary>
        public short DirectionX { get; set; }

        /// <summary>
        /// 运动方向的Y
        /// </summary>
        public short DirectionY { get; set; }

        /// <summary>
        /// 当前位置X
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// 当前位置Y
        /// </summary>
        public int PositionY { get; set; }

        #endregion


        /// <summary>
        /// 运动方向/向量
        /// </summary>
        //public Direction Direction { get; set; }



        #region 中间状态

        public int TempPositionX { get; set; }
        public int TempPositionY { get; set; }

        public short TempDirectionX { get; set; }

        public short TempDirectionY { get; set; }

        //public Direction TempDirection { get; set; }

        /// <summary>
        /// 速度根据 运动方向 进行分解
        /// </summary>
        public int MoveDistanceX { get; set; }

        public int MoveDistanceY { get; set; }

        #endregion


    }
}
