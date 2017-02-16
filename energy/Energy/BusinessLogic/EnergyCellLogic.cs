using Db.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EnergyCellLogic
    {
        public int EnerimentID { get; private set; }

        public List<EnergyCellExtend> EnergyCells { get; private set; }

        public Dictionary<int, List<EnergyCellTick>> TickCells { get; private set; }

        //public List<Cell> TickCells { get; private set; }

        public List<ArgEnergyCell> ArgCells { get; private set; }

        public string TickGuid { get; private set; }

        public EnergyCellLogic()
        {
            EnergyCells = new List<EnergyCellExtend>();
            TickCells = new Dictionary<int, List<EnergyCellTick>>();
            ArgCells = new List<ArgEnergyCell>();
        }

        public void Clear()
        {
            EnergyCells = null;
            TickCells = null;
            ArgCells = null;
        }

        public void SetEnergyCells(List<EnergyCellExtend> cellExtends)
        {
            this.EnergyCells = cellExtends;
        }

        /// <summary>
        /// 初始化能量格子
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        /// <param name="darkEnergy"></param>
        /// <param name="countRange"></param>
        public void InitEnergyCells(int maxX, int maxY, double darkEnergy, int countRange = 1)
        {
            int cellId = 0;
            for (var i = 1; i <= maxX; i++)
            {
                for (var j = 1; j <= maxY; j++)
                {
                    cellId++;
                    EnergyCells.Add(new EnergyCellExtend() { Order = cellId, CellX = i, CellY = j, IsHotPot = false });
                }
            }

            foreach (var cell in EnergyCells)
            {
                var argCell = new ArgEnergyCell() { RelactedCells = new List<EnergyCellExtend>(), CellX = cell.CellX, CellY = cell.CellY };

                // 取得能量平均单元格
                int startX = cell.CellX - countRange;
                int startY = cell.CellY - countRange;
                int endX = cell.CellX + countRange;
                int endY = cell.CellY + countRange;

                for (var i = startX; i <= endX; i++)
                {
                    for (var j = startY; j <= endY; j++)
                    {
                        var subArgCell = EnergyCells.FirstOrDefault(c => c.CellX == i && c.CellY == j);
                        argCell.RelactedCells.Add(subArgCell ?? new EnergyCellExtend() { CellX = i, CellY = j, Energy = darkEnergy });
                    }
                }

                ArgCells.Add(argCell);
            }
        }


        public void ArgEnergyCells()
        {
            for (var i = 0; i < EnergyCells.Count; i++)
            {
                if (!EnergyCells[i].IsHotPot)
                {
                    EnergyCells[i].Energy = ArgCells[i].ArgEnergy;
                }
            }
        }

        /// <summary>
        /// 计算当前tick的所以Cell状态
        /// </summary>
        /// <param name="tick"></param>
        public List<EnergyCellTick> GetTickCells(int tick)
        {
            var tickCells = new List<EnergyCellTick>();
            foreach (var cell in this.EnergyCells)
            {
                var tickCell = new EnergyCellTick()
                {
                    Tick = tick,
                    EnergyCellID = cell.EnergyCellID,
                    Energy = cell.Energy,
                    IsHotPot = cell.IsHotPot
                };
                tickCells.Add(tickCell);
            }

            //this.TickCells.Add(tick, tickCells);

            return tickCells;
        }


        /// <summary>
        /// 设置热源
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="energy"></param>
        public void SetHotPot(int x, int y, int width, int height, double energy)
        {
            for (var i = x; i <= x + width; i++)
            {
                for (var j = y; j <= y + height; j++)
                {
                    var cell = EnergyCells.FirstOrDefault(c => c.CellX == i && c.CellY == j);
                    if (cell != null)
                    {
                        cell.Energy = energy;
                        cell.IsHotPot = true;
                    }
                }
            }
        }



        public static RGB GetGRB(double energy)
        {
            byte degree = (byte)Math.Floor(energy * 255);

            return new RGB(degree, degree, degree);
        }
    }
}
