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

        Pen pen = new Pen(Color.Red);
        const int Length = 4;
        int MaxX; // 165
        int MaxY;

        // Dictionary<int, List<Cell>> DrawCells;

        EnergyLogic EnergyLogic;
        AtomLogic AtomLogic;

        public EnergyForm()
        {
            InitializeComponent();
            EnergyLogic = new EnergyLogic();
            AtomLogic = new AtomLogic();
        }

        private void btnInitBackground_Click(object sender, EventArgs e)
        {

            //g = this.pnlContaner.CreateGraphics();
            //g.Clear(Color.White);


            MaxX = 90;
            MaxY = 90;

            EnergyLogic.InitCells(MaxX, MaxX, 0.0, 2);
            MessageBox.Show("数据生成完成");
            EnergyLogic.SetHotPot(30, 20, 10, 10, 1.0);
            EnergyLogic.SetHotPot(60, 80, 10, 10, 1.0);

            AtomLogic.InitAtoms(MaxX, MaxY, Length);

            dgvAtom.DataSource = AtomLogic.Atoms;

            //DrawCells = new Dictionary<int, List<Cell>>();


            //for (int i = 0; i < 20; i++)
            //{
            //    var perSecondCells = EnergyLogic.InitCells(MaxX, MaxY, r);
            //    DrawCells.Add(i, perSecondCells);
            //}


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            Graphics g;

            Rectangle rectBorder;
            Rectangle rectContent;
            Color contentColor;
            Brush contentBrush;

            Brush atomBrush = new SolidBrush(Color.Red);
            Brush strBrush = new SolidBrush(Color.Blue);

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

                foreach (var atom in AtomLogic.Atoms)
                {
                    g.FillEllipse(atomBrush, atom.PositionX, atom.PositionY, 10, 10);
                    g.DrawString(i.ToString(), Font, strBrush, atom.PositionX, atom.PositionY);
                }


                img.Save(filePath, ImageFormat.Png);

                g.Dispose();
                img.Dispose();

                EnergyLogic.ArgEnergyCells();
                AtomLogic.CalAtomStatus();
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            Graphics g = this.pnlContaner.CreateGraphics();
            g.Clear(Color.White);
            string filePath = @"../../Image";

            var imageFolder = Directory.CreateDirectory(filePath);
            var images = imageFolder.GetFiles().OrderBy(m => m.CreationTime);

            foreach (var imagefile in images)
            {
                Thread.Sleep(100);
                Bitmap bitmap = new Bitmap(imagefile.FullName);
                g.DrawImage(bitmap, 0, 0);
            }

            g.Dispose();

        }
    }
}
