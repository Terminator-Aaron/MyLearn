using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EnergyLogic
    {
        public List<Cell> SecondCells { get; private set; }

        public List<ArgEnergyCell> ArgCells { get; private set; }

        public EnergyLogic()
        {
            SecondCells = new List<Cell>();
            ArgCells = new List<ArgEnergyCell>();
        }


        public void InitCells(int maxX, int maxY, double darkEnergy, int countRange = 1)
        {
            for (var i = 1; i <= maxX; i++)
            {
                for (var j = 1; j <= maxY; j++)
                {
                    SecondCells.Add(new Cell() { PositionX = i, PositionY = j, Energy = 0.0 });
                }
            }

            foreach (var cell in SecondCells)
            {
                var argCell = new ArgEnergyCell() { RelactedCells = new List<Cell>(), PositionX = cell.PositionX, PositionY = cell.PositionY };

                // 取得能量平均单元格
                int startX = cell.PositionX - countRange;
                int startY = cell.PositionY - countRange;
                int endX = cell.PositionX + countRange;
                int endY = cell.PositionY + countRange;

                for (var i = startX; i <= endX; i++)
                {
                    for (var j = startY; j <= endY; j++)
                    {
                        var subArgCell = SecondCells.FirstOrDefault(c => c.PositionX == i && c.PositionY == j);
                        argCell.RelactedCells.Add(subArgCell ?? new Cell() { PositionX = i, PositionY = j, Energy = darkEnergy });
                    }
                }

                ArgCells.Add(argCell);
            }
        }

        public void SetHotPot(int x, int y, int width, int height, double energy)
        {
            for (var i = x; i <= x + width; i++)
            {
                for (var j = y; j <= y + height; j++)
                {
                    var cell = SecondCells.FirstOrDefault(c => c.PositionX == i && c.PositionY == j);
                    if (cell != null)
                    {
                        cell.Energy = energy;
                        cell.IsHotPot = true;
                    }
                }
            }
        }

        public void ArgEnergyCells()
        {
            for (var i = 0; i < SecondCells.Count; i++)
            {
                if (!SecondCells[i].IsHotPot)
                {
                    SecondCells[i].Energy = ArgCells[i].ArgEnergy;
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
