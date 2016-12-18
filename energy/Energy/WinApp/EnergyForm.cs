using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class EnergyForm : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Red);
        const int Length = 4;
        int MaxX; // 165
        int MaxY;

        Dictionary<int, List<Cell>> DrawCells;

        EnergyLogic EnergyLogic;

        public EnergyForm()
        {
            InitializeComponent();
            EnergyLogic = new EnergyLogic();
        }

        private void btnInitBackground_Click(object sender, EventArgs e)
        {
            try
            {
                //g = this.pnlContaner.CreateGraphics();
                //g.Clear(Color.White);


                MaxX = 165;
                MaxY = 165;

                EnergyLogic.InitCells(MaxX, MaxX, 0.0, 2);
                MessageBox.Show("数据生成完成");
                EnergyLogic.SetHotPot(30, 20, 10, 10, 1.0);
                EnergyLogic.SetHotPot(60, 80, 10, 10, 1.0);

                //DrawCells = new Dictionary<int, List<Cell>>();


                //for (int i = 0; i < 20; i++)
                //{
                //    var perSecondCells = EnergyLogic.InitCells(MaxX, MaxY, r);
                //    DrawCells.Add(i, perSecondCells);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;


            Rectangle rectBorder;
            Rectangle rectContent;
            Color contentColor;
            Brush contentBrush;

            for (int i = 0; i < 500; i++) // one second
            {
                //Thread.Sleep(300);
                filePath = string.Format(@"../../Image/cells_{0}.png", i + 1);

                Image img = new Bitmap(MaxX * Length, MaxY * Length);

                g = Graphics.FromImage(img);

                foreach (var cell in EnergyLogic.SecondCells)
                {
                    //rectBorder = new Rectangle(cell.PositionX * Length, cell.PositionY * Length, Length, Length);
                    //g.DrawRectangle(pen, rectBorder);

                    var rgb = EnergyLogic.GetGRB(cell.Energy);
                    contentColor = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    contentBrush = new SolidBrush(contentColor);
                    rectContent = new Rectangle((cell.PositionX - 1) * Length, (cell.PositionY - 1) * Length, Length, Length);
                    g.FillRectangle(contentBrush, rectContent);
                }
                img.Save(filePath, ImageFormat.Png);

                g.Dispose();
                img.Dispose();

                EnergyLogic.ArgEnergyCells();
            }
        }
    }
}
