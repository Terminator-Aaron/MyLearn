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


        #region Demo

        private bool _IsStopping = false;
        private int _Tick = 1;
        private int _MaxTick = 0;
        //private Graphics _DemoG;
        private Bitmap _DemoBitmap;
        private IList<FileInfo> _ImageFiles;

        #endregion


        public EnergyForm()
        {
            InitializeComponent();
            EnergyLogic = new EnergyCellLogic();
            AtomLogic = new AtomLogic();
            ExperimentLogic = new ExperimentLogic();

            btnDemoResum.Enabled = false;
            btnDemoStop.Enabled = false;
            btnDemoEnd.Enabled = false;
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



        #region Deom

        private void LoadImageAndData()
        {
            int index = _Tick - 1;
            var imagefile = _ImageFiles[index];
            //dgvAtom.DataSource = AtomLogic.TickAtoms[_Tick];
            //dgvCell.DataSource = EnergyLogic.TickCells[_Tick];
            Thread.Sleep(100);
            var demoG = this.pnlContaner.CreateGraphics();
            _DemoBitmap = new Bitmap(imagefile.FullName);
            demoG.DrawImage(_DemoBitmap, 0, 0);
            demoG.Dispose();

            _Tick++;

            StartTaskToLoadImageAndData();
        }

        private void StartTaskToLoadImageAndData()
        {
            if (_MaxTick > 0 && _Tick <= _MaxTick && _IsStopping == false)
            {
                Task t = new Task(() =>
                {
                    this.LoadImageAndData();
                });
                t.Start();
            }
        }

        private void btnDemoStart_Click(object sender, EventArgs e)
        {
            btnDemoStart.Enabled = false;
            txtImagePath.Enabled = false;
            btnDemoStop.Enabled = true;
            btnDemoEnd.Enabled = true;

            //_DemoG = this.pnlContaner.CreateGraphics();
            //_DemoG.Clear(Color.White);
            string filePath = txtImagePath.Text;

            var imageFolder = Directory.CreateDirectory(filePath);
            _ImageFiles = imageFolder.GetFiles().OrderBy(m => m.CreationTime).ToList();
            _MaxTick = _ImageFiles.Count();

            // 多线程
            StartTaskToLoadImageAndData();

            //for (var i = 0; i < _ImageFiles.Count(); i++)
            //{
            //    var imagefile = _ImageFiles[i];
            //    dgvAtom.DataSource = AtomLogic.TickAtoms[i];
            //    dgvCell.DataSource = EnergyLogic.TickCells[i];

            //    Thread.Sleep(1000);
            //    Bitmap bitmap = new Bitmap(imagefile.FullName);
            //    _DemoG.DrawImage(bitmap, 0, 0);
            //}

            //var i = 0;
            //foreach (var imagefile in _ImageFiles)
            //{
            //    i++;
            //    dgvAtom.DataSource = AtomLogic.TickAtoms[i];
            //    dgvCell.DataSource = EnergyLogic.TickCells[i];

            //    Thread.Sleep(1000);
            //    Bitmap bitmap = new Bitmap(imagefile.FullName);
            //    _DemoG.DrawImage(bitmap, 0, 0);
            //}

            //_DemoG.Dispose();
        }

        private void btnDemoStop_Click(object sender, EventArgs e)
        {
            _IsStopping = true;
            btnDemoResum.Enabled = true;
            btnDemoStop.Enabled = false;
            StartTaskToLoadImageAndData();
        }

        private void btnDemoResum_Click(object sender, EventArgs e)
        {
            _IsStopping = false;
            btnDemoResum.Enabled = false;
            btnDemoStop.Enabled = true;
            StartTaskToLoadImageAndData();
        }

        private void btnDemoEnd_Click(object sender, EventArgs e)
        {
            // 清空数据
            _IsStopping = false;
            _Tick = 1;
            _MaxTick = 0;
            //_DemoG.Dispose();
            _DemoBitmap.Dispose();
            _ImageFiles = null;

            // 重置按钮
            btnDemoResum.Enabled = false;
            btnDemoStop.Enabled = false;
            btnDemoEnd.Enabled = false;
            txtImagePath.Enabled = true;
            btnDemoStart.Enabled = true;

        }

        #endregion

        private void EnergyForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }


    }
}
