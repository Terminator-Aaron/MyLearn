using BusinessLogic;
using Db.Models;
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

        EnergyCellLogic EnergyLogic;
        AtomLogic AtomLogic;
        ExperimentLogic ExperimentLogic;

        public EnergyForm()
        {
            InitializeComponent();
            EnergyLogic = new EnergyCellLogic();
            AtomLogic = new AtomLogic();
            ExperimentLogic = new ExperimentLogic();
        }

        private void btnInitBackground_Click(object sender, EventArgs e)
        {

            //g = this.pnlContaner.CreateGraphics();
            //g.Clear(Color.White);
            MaxX = 150;
            MaxY = 150;

            Experiment experiment = new Experiment()
            {
                InitStartTime = DateTime.Now,
                MaxX = MaxX,
                MaxY = MaxY,
                ByWho = "aaron zhang",
                Remark = ""
            };


            EnergyLogic.InitEnergyCells(MaxX, MaxX, 0.0, 2);
            EnergyLogic.SetHotPot(10, 20, 10, 10, 1.0);
            EnergyLogic.SetHotPot(60, 80, 10, 10, 1.0);

            AtomLogic.InitAtoms(MaxX, MaxY, Length, 20);

            experiment.InitEndTime = DateTime.Now;
            MessageBox.Show("数据生成完成");


            //List<EnergyCellExtend> newCellExtends;
            //List<AtomExtend> newAtomExtends;

            //var result = ExperimentLogic.CreateExperiment(experiment, EnergyLogic.EnergyCells, AtomLogic.Atoms, out newCellExtends, out newAtomExtends);
            //if (result)
            //{
            //    MessageBox.Show("数据保存成功");
            //    txtExperimentID.Text = ExperimentLogic.Experiment.ExperimentID.ToString();
            //    EnergyLogic.SetEnergyCells(newCellExtends);
            //    AtomLogic.SetAtoms(newAtomExtends);
            //}


            //dgvAtom.DataSource = AtomLogic.Atoms;
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
                //if (i < 10)
                //ExperimentLogic.SaveExperimentTickData(EnergyLogic.GetTickCells(i + 1), AtomLogic.GetTickAtoms(i + 1));
                EnergyLogic.GetTickCells(i + 1);
                AtomLogic.GetTickAtoms(i + 1);

                //Thread.Sleep(300);
                filePath = string.Format(@"../../Image/cells_{0}.png", i + 1);

                Image img = new Bitmap(MaxX * Length, MaxY * Length);

                g = Graphics.FromImage(img);

                foreach (var cell in EnergyLogic.EnergyCells)
                {
                    var rgb = EnergyCellLogic.GetGRB(cell.Energy);
                    contentColor = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    contentBrush = new SolidBrush(contentColor);
                    rectContent = new Rectangle((cell.CellX - 1) * Length, (cell.CellY - 1) * Length, Length, Length);
                    g.FillRectangle(contentBrush, rectContent);
                }

                foreach (var atom in AtomLogic.Atoms)
                {
                    g.FillEllipse(atomBrush, atom.PositionX - 5, atom.PositionY - 5, 10, 10);
                    g.DrawString(atom.Order.ToString(), Font, strBrush, atom.PositionX - 5, atom.PositionY - 5);
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

            var i = 0;

            foreach (var imagefile in images)
            {
                i++;
                dgvAtom.DataSource = AtomLogic.TickAtoms[i];
                dgvCell.DataSource = EnergyLogic.TickCells[i];

                Thread.Sleep(100);
                Bitmap bitmap = new Bitmap(imagefile.FullName);
                g.DrawImage(bitmap, 0, 0);
            }

            g.Dispose();

        }
    }
}
