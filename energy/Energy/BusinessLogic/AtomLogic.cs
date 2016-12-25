using Db.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AtomLogic
    {
        public List<AtomExtend> Atoms { get; private set; }

        public List<AtomExtend> CalAtoms { get; private set; }

        public Dictionary<int, List<AtomTick>> TickAtoms { get; private set; }


        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public int Length { get; private set; }

        public int MaxPositionX { get; private set; }
        public int MaxPositionY { get; private set; }

        public AtomLogic()
        {
            Atoms = new List<AtomExtend>();
            TickAtoms = new Dictionary<int, List<AtomTick>>();
            //CalAtoms = new List<AtomExtend>();
        }

        public void SetAtoms(List<AtomExtend> atomExtends)
        {
            this.Atoms = atomExtends;
        }


        public void InitAtoms(int maxX, int maxY, int length, int atomCounts)
        {
            MaxX = maxX;
            MaxY = maxY;
            Length = length;
            MaxPositionX = maxX * length;
            MaxPositionY = maxY * length;

            Random rPX = new Random();
            Random rPY = new Random();
            Random rPV = new Random();
            Random rx = new Random();
            Random ry = new Random();

            for (int i = 0; i < atomCounts; i++)
            {
                var atom = new AtomExtend()
                {
                    Order = i + 1,
                    PositionX = rPX.Next(MaxPositionX),
                    PositionY = rPX.Next(MaxPositionY),
                    Velocity = rPX.NextDouble() * 8,
                    DirectionX = (short)rPX.Next(10),
                    DirectionY = (short)rPX.Next(10),
                };
                atom = DismantleVelocity(atom);
                Atoms.Add(atom);
            }
        }

        /// <summary>
        /// 临时设置位置
        /// 要经过判断才生效
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public AtomExtend SetTempPositionAndDirection(AtomExtend atom)
        {
            atom.TempPositionX = atom.PositionX + atom.MoveDistanceX;
            atom.TempPositionY = atom.PositionY + atom.MoveDistanceY;
            atom.TempDirectionX = atom.DirectionX;
            atom.TempDirectionY = atom.DirectionY;
            return atom;
        }

        /// <summary>
        /// 分解移动速度到移动向量
        /// 速度或移动方向改变时，调用
        /// </summary>
        /// <param name="atom"></param>
        /// <param name="signX">+1 or -1</param>
        /// <param name="singY">+1 or -1</param>
        /// <returns></returns>
        public AtomExtend DismantleVelocity(AtomExtend atom)
        {
            if (atom.DirectionX == 0 && atom.DirectionY == 0)
            {
                atom.MoveDistanceX = 0;
                atom.MoveDistanceY = 0;

            }
            else
            {
                // 直角三角形，知 直角边比值，和斜边长度，求两个直角边
                // 假设 比值为  a:b = am:bm，先求m
                double m = Math.Sqrt(Math.Pow(atom.Velocity, 2) / (Math.Pow(atom.DirectionX, 2) + Math.Pow(atom.DirectionY, 2)));
                int distanceX = Math.Abs((int)(atom.DirectionX * m + 0.5)); // +0.5是为四舍五入
                int distanceY = Math.Abs((int)(atom.DirectionY * m + 0.5)); // +0.5是为四舍五入

                atom.MoveDistanceX = atom.DirectionX > 0 ? distanceX : -distanceX;
                atom.MoveDistanceY = atom.DirectionY > 0 ? distanceY : -distanceY;
            }

            return atom;
        }

        /// <summary>
        /// 超出边框时，修改位置运动方向
        /// </summary>
        /// <returns></returns>
        public AtomExtend ChangePositionAndDirection(AtomExtend atom)
        {
            if (atom.TempPositionX < 0) // 超出左边框
            {
                atom.TempPositionX = -atom.TempPositionX;
                atom.TempDirectionX = (short)-atom.TempDirectionX;
            }

            if (atom.TempPositionY < 0) // 超出上边框
            {
                atom.TempPositionY = -atom.TempPositionY;
                atom.TempDirectionY = (short)-atom.TempDirectionY;
            }

            if (atom.TempPositionX > MaxPositionX) // 超出右边框
            {
                atom.TempPositionX = 2 * MaxPositionX - atom.TempPositionX;
                atom.TempDirectionX = (short)-atom.TempDirectionX;
            }

            if (atom.TempPositionY > MaxPositionX) // 超出下边框
            {
                atom.TempPositionY = 2 * MaxPositionX - atom.TempPositionY;
                atom.TempDirectionY = (short)-atom.TempDirectionY;
            }

            return atom;
        }


        public AtomExtend TryMove(AtomExtend atom)
        {
            atom = SetTempPositionAndDirection(atom);


            // 容器之内
            // (atom.TempPositionX >= 0 && atom.TempPositionX <= MaxX) && (atom.TempPositionY >= 0 && atom.TempPositionY <= MaxY)

            bool hasChangePositionAndDirection = false;

            while (((atom.TempPositionX >= 0 && atom.TempPositionX <= MaxPositionX)
        && (atom.TempPositionY >= 0 && atom.TempPositionY <= MaxPositionY)) == false)
            {
                hasChangePositionAndDirection = true;
                // 位置超出容器范围，碰撞到容器壁反弹，需要计算新的运动方向
                atom = ChangePositionAndDirection(atom);
            }

            atom.PositionX = atom.TempPositionX;
            atom.PositionY = atom.TempPositionY;

            if (hasChangePositionAndDirection)
            {
                atom.DirectionX = atom.TempDirectionX;
                atom.DirectionY = atom.TempDirectionY;
                atom = DismantleVelocity(atom);
            }

            return atom;
        }

        public List<AtomTick> GetTickAtoms(int tick)
        {
            var tickAtoms = new List<AtomTick>();
            foreach (var atom in this.Atoms)
            {
                var tickAtom = new AtomTick()
                {
                    AtomID = atom.AtomID,
                    Tick = tick,
                    Velocity = atom.Velocity,
                    DirectionX = atom.DirectionX,
                    DirectionY = atom.DirectionY,
                    PositionX = atom.PositionX,
                    PositionY = atom.PositionY,
                };
                tickAtoms.Add(tickAtom);
            }

            this.TickAtoms.Add(tick, tickAtoms);

            return tickAtoms;
        }


        public void CalAtomStatus()
        {
            for (var i = 0; i < Atoms.Count; i++)
            {
                var atom = Atoms[i];
                atom = TryMove(atom);
            }
        }
    }
}
