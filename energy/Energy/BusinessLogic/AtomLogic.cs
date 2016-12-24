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
        public List<Atom> Atoms { get; private set; }
        public List<Atom> CalAtoms { get; private set; }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public int Length { get; private set; }

        public int MaxPositionX { get; private set; }
        public int MaxPositionY { get; private set; }

        public AtomLogic()
        {
            Atoms = new List<Atom>();
            CalAtoms = new List<Atom>();
        }

        public void InitAtoms(int maxX, int maxY, int length)
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

            for (int i = 0; i < 20; i++)
            {
                var atom = new Atom()
                {
                    Iden = i,
                    PositionX = rPX.Next(MaxPositionX),
                    PositionY = rPX.Next(MaxPositionY),
                    Velocity = rPX.NextDouble() * 8,
                    Direction = new Direction() { x = rPX.Next(10), y = rPX.Next(10) }
                };
                atom = DismantleVelocity(atom);
                Atoms.Add(atom);
                CalAtoms.Add(atom);

            }
        }

        /// <summary>
        /// 临时设置位置
        /// 要经过判断才生效
        /// </summary>
        /// <param name="atom"></param>
        /// <returns></returns>
        public Atom SetTempPositionAndDirection(Atom atom)
        {
            atom.TempPositionX = atom.PositionX + atom.DismantleVelocity.DistanceX;
            atom.TempPositionY = atom.PositionY + atom.DismantleVelocity.DistanceY;
            atom.TempDirection = atom.Direction;
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
        public Atom DismantleVelocity(Atom atom)
        {
            // 直角三角形，知 直角边比值，和斜边长度，求两个直角边
            // 假设 比值为  a:b = am:bm，先求m
            double m = Math.Sqrt(Math.Pow(atom.Velocity, 2) / (Math.Pow(atom.Direction.x, 2) + Math.Pow(atom.Direction.y, 2)));
            int distanceX = Math.Abs((int)(atom.Direction.x * m + 0.5)); // +0.5是为四舍五入
            int distanceY = Math.Abs((int)(atom.Direction.y * m + 0.5)); // +0.5是为四舍五入

            atom.DismantleVelocity = new Move()
            {
                DistanceX = atom.Direction.x > 0 ? distanceX : -distanceX,
                DistanceY = atom.Direction.y > 0 ? distanceY : -distanceY
            };

            return atom;
        }

        /// <summary>
        /// 超出边框时，修改位置运动方向
        /// </summary>
        /// <returns></returns>
        public Atom ChangePositionAndDirection(Atom atom)
        {
            if (atom.TempPositionX < 0) // 超出左边框
            {
                atom.TempPositionX = -atom.TempPositionX;
                atom.TempDirection.x = -atom.Direction.x;
            }

            if (atom.TempPositionY < 0) // 超出上边框
            {
                atom.TempPositionY = -atom.TempPositionY;
                atom.TempDirection.y = -atom.Direction.y;
            }

            if (atom.TempPositionX > MaxPositionX) // 超出右边框
            {
                atom.TempPositionX = 2 * MaxPositionX - atom.TempPositionX;
                atom.TempDirection.x = -atom.Direction.x;
            }

            if (atom.TempPositionY > MaxPositionX) // 超出下边框
            {
                atom.TempPositionY = 2 * MaxPositionX - atom.TempPositionY;
                atom.TempDirection.y = -atom.Direction.y;
            }


            return atom;
        }


        public Atom TryMove(Atom atom)
        {
            atom = SetTempPositionAndDirection(atom);

            // 容器之内
            // (atom.TempPositionX >= 0 && atom.TempPositionX <= MaxX) && (atom.TempPositionY >= 0 && atom.TempPositionY <= MaxY)


            while (((atom.TempPositionX >= 0 && atom.TempPositionX <= MaxPositionX)
        && (atom.TempPositionY >= 0 && atom.TempPositionY <= MaxPositionY)) == false)
            {
                // 位置超出容器范围，碰撞到容器壁反弹，需要计算新的运动方向
                atom = ChangePositionAndDirection(atom);
                atom = DismantleVelocity(atom);
            }

            atom.PositionX = atom.TempPositionX;
            atom.PositionY = atom.TempPositionY;
            atom.Direction = atom.TempDirection;


            return atom;
        }


        public void CalAtomStatus()
        {
            for (var i = 0; i < Atoms.Count; i++)
            {
                //var calAtom = CalAtoms[i]; // 这里calAtom，atom是同一个引用
                var atom = Atoms[i];
                atom = TryMove(atom);
            }
        }
    }
}
