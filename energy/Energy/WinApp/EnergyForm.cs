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

        private Experiment _DemoExperiment;
        private ICollection<EnergyCell> _DemoEnergyCellList;
        private ICollection<Atom> _DemoAtomList;
        private Dictionary<int, List<AtomTick>> _DemoTickAtoms;
        private Dictionary<int, List<EnergyCellTick>> _DemoTickCells;

        private string _DemoTickAtomsFilePath = @"../../Data/AtomTick.tick";
        private string _DemoTickCellsFilePath = @"../../Data/EnergyCellTick.tick";


        private DirectoryDataManager<List<EnergyCellTick>> _TickCellDirectory;
        private DirectoryDataManager<List<AtomTick>> _AtomDirectory;


        #endregion


        public EnergyForm()
        {
            InitializeComponent();

            btnInitBackground.Enabled = false;
            btnStart.Enabled = false;

            btnDemoResum.Enabled = false;
            btnDemoStop.Enabled = false;
            btnDemoEnd.Enabled = false;
            //txtExperimentID.ReadOnly = true;
        }

        private void btnInitBackground_Click(object sender, EventArgs e)
        {
            MaxX = 70;
            MaxY = 70;

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


            List<EnergyCellExtend> newCellExtends;
            List<AtomExtend> newAtomExtends;

            var result = ExperimentLogic.CreateExperiment(experiment, EnergyLogic.EnergyCells, AtomLogic.Atoms, out newCellExtends, out newAtomExtends);
            if (result)
            {
                InitDirectoryDataManager(ExperimentLogic.Experiment.ExperimentID);

                MessageBox.Show("数据保存成功");
                txtExperimentID.Text = ExperimentLogic.Experiment.ExperimentID.ToString();
                EnergyLogic.SetEnergyCells(newCellExtends);
                AtomLogic.SetAtoms(newAtomExtends);
            }
        }

        /// <summary>
        /// 生成tick数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            var experimentId = Convert.ToInt64(txtExperimentID.Text);
            InitDirectoryDataManager(experimentId);

            for (int i = 0; i < 495; i++) // one second
            {
                //ExperimentLogic.SaveExperimentTickData(EnergyLogic.GetTickCells(i + 1), AtomLogic.GetTickAtoms(i + 1));

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

                var tickCells = EnergyLogic.GetTickCells(i + 1);
                _TickCellDirectory.Add(i + 1, tickCells);
                var tickAtoms = AtomLogic.GetTickAtoms(i + 1);
                _AtomDirectory.Add(i + 1, tickAtoms);


                EnergyLogic.ArgEnergyCells();
                AtomLogic.CalAtomStatus();
            }

            _TickCellDirectory.ClearCache();
            _AtomDirectory.ClearCache();

            //Tools.BinarySerialize<Dictionary<int, List<AtomTick>>>(AtomLogic.TickAtoms, _DemoTickAtomsFilePath);
            //Tools.BinarySerialize<Dictionary<int, List<EnergyCellTick>>>(EnergyLogic.TickCells, _DemoTickCellsFilePath);

            MessageBox.Show("Tick数据生成成功！");

            AtomLogic.Clear();
            EnergyLogic.Clear();
        }



        #region Deom

        private delegate void SetDataViewDelegate(int tick);

        private void SetDataView(int _Tick)
        {
            //var atoms = _DemoTickAtoms[_Tick];
            var atoms = _AtomDirectory.GetTickData(_Tick);
            var tickAtoms = (from m in atoms
                             join n in _DemoAtomList
                             on m.AtomID equals n.AtomID
                             select new { n.AtomID, n.Order, m.Tick, m.DirectionX, m.DirectionY, m.PositionX, m.PositionY, m.Velocity }).ToList();

            dgvTickAtoms.DataSource = tickAtoms;

            //var cells = _DemoTickCells[_Tick];
            var cells = _TickCellDirectory.GetTickData(_Tick);
            var tickCells = (from m in cells
                             join n in _DemoEnergyCellList
                             on m.EnergyCellID equals n.EnergyCellID
                             select new { n.EnergyCellID, n.Order, n.CellX, n.CellY, m.Tick, m.Energy, m.IsHotPot }).ToList();

            dgvTickCells.DataSource = tickCells;

            lbTick.Text = _Tick.ToString();
        }

        /// <summary>
        /// 加载1Tick数据
        /// </summary>
        private void LoadTickData()
        {
            int index = _Tick - 1;
            var imagefile = _ImageFiles[index];

            if (InvokeRequired)
            {
                this.Invoke(new SetDataViewDelegate(this.SetDataView), _Tick);
            }
            else
            {
                this.SetDataView(_Tick);
            }

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
                    this.LoadTickData();
                });
                t.Start();
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDemoStart_Click(object sender, EventArgs e)
        {
            btnDemoStart.Enabled = false;
            txtImagePath.Enabled = false;
            btnDemoStop.Enabled = true;
            btnDemoEnd.Enabled = true;

            var experimentId = Convert.ToInt32(txtExperimentID.Text);
            InitDirectoryDataManager(experimentId);

            string filePath = txtImagePath.Text;

            var imageFolder = Directory.CreateDirectory(filePath);
            _ImageFiles = imageFolder.GetFiles().OrderBy(m => m.CreationTime).ToList();
            _MaxTick = _ImageFiles.Count();

            // 加载数据
            _DemoExperiment = ExperimentLogic.LoadExperiment(experimentId);
            if (_DemoExperiment == null)
            {
                MessageBox.Show("找不到试验数据");
                return;
            }
            _DemoEnergyCellList = _DemoExperiment.EnergyCells;
            _DemoAtomList = _DemoExperiment.Atoms;

            //_DemoTickAtoms = Tools.BinaryDeSerialize<Dictionary<int, List<AtomTick>>>(_DemoTickAtomsFilePath);
            //_DemoTickCells = Tools.BinaryDeSerialize<Dictionary<int, List<EnergyCellTick>>>(_DemoTickCellsFilePath);

            MessageBox.Show("数据加载完成");

            dgvExperiment.DataSource = new List<Experiment>() { _DemoExperiment };
            dgvEnergyCells.DataSource = _DemoEnergyCellList;
            dgvAtoms.DataSource = _DemoAtomList;



            // 多线程
            StartTaskToLoadImageAndData();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDemoStop_Click(object sender, EventArgs e)
        {
            _IsStopping = true;
            btnDemoResum.Enabled = true;
            btnDemoStop.Enabled = false;
            StartTaskToLoadImageAndData();
        }

        /// <summary>
        /// 继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDemoResum_Click(object sender, EventArgs e)
        {
            _IsStopping = false;
            btnDemoResum.Enabled = false;
            btnDemoStop.Enabled = true;
            
            int jumpTick;
            if(int.TryParse(txtJumpTick.Text, out jumpTick))
            {
                _Tick = jumpTick;
            }

            StartTaskToLoadImageAndData();
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDemoEnd_Click(object sender, EventArgs e)
        {
            // 清空数据
            _IsStopping = false;
            _Tick = 1;
            _MaxTick = 0;
            //_DemoG.Dispose();
            _DemoBitmap.Dispose();
            _ImageFiles = null;
            _DemoExperiment = null;
            _DemoEnergyCellList = null;
            _DemoAtomList = null;
            _DemoTickAtoms = null;
            _DemoTickCells = null;

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

        private void btnInit_Click(object sender, EventArgs e)
        {
            btnInitBackground.Enabled = true;
            btnStart.Enabled = true;

            EnergyLogic = new EnergyCellLogic();
            AtomLogic = new AtomLogic();
            ExperimentLogic = new ExperimentLogic();
        }

        private void InitDirectoryDataManager(long experimentId)
        {
            _TickCellDirectory = new DirectoryDataManager<List<EnergyCellTick>>(10, experimentId, @"../../Data/TickCellData/", "tickCell", 10);
            _AtomDirectory = new DirectoryDataManager<List<AtomTick>>(50, experimentId, @"../../Data/AtomData/", "tickAtom", 10);
        }


    }
}
