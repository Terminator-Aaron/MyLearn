namespace WinApp
{
    partial class EnergyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitBackground = new System.Windows.Forms.Button();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.pnlContaner = new System.Windows.Forms.Panel();
            this.dgvTickCells = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDemoStart = new System.Windows.Forms.Button();
            this.dgvTickAtoms = new System.Windows.Forms.DataGridView();
            this.txtExperimentID = new System.Windows.Forms.TextBox();
            this.btnDemoStop = new System.Windows.Forms.Button();
            this.btnDemoResum = new System.Windows.Forms.Button();
            this.lbDemo = new System.Windows.Forms.Label();
            this.btnDemoEnd = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.tabDataShow = new System.Windows.Forms.TabControl();
            this.tabPageExperiment = new System.Windows.Forms.TabPage();
            this.dgvExperiment = new System.Windows.Forms.DataGridView();
            this.tabPageEnergyCells = new System.Windows.Forms.TabPage();
            this.dgvEnergyCells = new System.Windows.Forms.DataGridView();
            this.tabPageTickCell = new System.Windows.Forms.TabPage();
            this.tabPageAtoms = new System.Windows.Forms.TabPage();
            this.dgvAtoms = new System.Windows.Forms.DataGridView();
            this.tabPageTickAtom = new System.Windows.Forms.TabPage();
            this.lbTickTip = new System.Windows.Forms.Label();
            this.lbTick = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.txtJumpTick = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickCells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickAtoms)).BeginInit();
            this.tabDataShow.SuspendLayout();
            this.tabPageExperiment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperiment)).BeginInit();
            this.tabPageEnergyCells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnergyCells)).BeginInit();
            this.tabPageTickCell.SuspendLayout();
            this.tabPageAtoms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtoms)).BeginInit();
            this.tabPageTickAtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitBackground
            // 
            this.btnInitBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInitBackground.Location = new System.Drawing.Point(1079, 3);
            this.btnInitBackground.Name = "btnInitBackground";
            this.btnInitBackground.Size = new System.Drawing.Size(89, 23);
            this.btnInitBackground.TabIndex = 0;
            this.btnInitBackground.Text = "生成试验数据";
            this.btnInitBackground.UseVisualStyleBackColor = true;
            this.btnInitBackground.Click += new System.EventHandler(this.btnInitBackground_Click);
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartIndex.Location = new System.Drawing.Point(987, 477);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(100, 21);
            this.txtStartIndex.TabIndex = 1;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Location = new System.Drawing.Point(1093, 477);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "加载数据";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // pnlContaner
            // 
            this.pnlContaner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlContaner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContaner.Location = new System.Drawing.Point(12, 12);
            this.pnlContaner.Name = "pnlContaner";
            this.pnlContaner.Size = new System.Drawing.Size(683, 488);
            this.pnlContaner.TabIndex = 3;
            // 
            // dgvTickCells
            // 
            this.dgvTickCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTickCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickCells.Location = new System.Drawing.Point(0, 0);
            this.dgvTickCells.Name = "dgvTickCells";
            this.dgvTickCells.RowTemplate.Height = 23;
            this.dgvTickCells.Size = new System.Drawing.Size(445, 367);
            this.dgvTickCells.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1079, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(89, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "生成Tick数据";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDemoStart
            // 
            this.btnDemoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemoStart.Location = new System.Drawing.Point(987, 56);
            this.btnDemoStart.Name = "btnDemoStart";
            this.btnDemoStart.Size = new System.Drawing.Size(42, 23);
            this.btnDemoStart.TabIndex = 5;
            this.btnDemoStart.Text = "开始";
            this.btnDemoStart.UseVisualStyleBackColor = true;
            this.btnDemoStart.Click += new System.EventHandler(this.btnDemoStart_Click);
            // 
            // dgvTickAtoms
            // 
            this.dgvTickAtoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTickAtoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickAtoms.Location = new System.Drawing.Point(-4, 3);
            this.dgvTickAtoms.Name = "dgvTickAtoms";
            this.dgvTickAtoms.RowTemplate.Height = 23;
            this.dgvTickAtoms.Size = new System.Drawing.Size(456, 361);
            this.dgvTickAtoms.TabIndex = 6;
            // 
            // txtExperimentID
            // 
            this.txtExperimentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExperimentID.Location = new System.Drawing.Point(973, 5);
            this.txtExperimentID.Name = "txtExperimentID";
            this.txtExperimentID.Size = new System.Drawing.Size(100, 21);
            this.txtExperimentID.TabIndex = 8;
            // 
            // btnDemoStop
            // 
            this.btnDemoStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemoStop.Location = new System.Drawing.Point(1035, 56);
            this.btnDemoStop.Name = "btnDemoStop";
            this.btnDemoStop.Size = new System.Drawing.Size(41, 23);
            this.btnDemoStop.TabIndex = 10;
            this.btnDemoStop.Text = "暂停";
            this.btnDemoStop.UseVisualStyleBackColor = true;
            this.btnDemoStop.Click += new System.EventHandler(this.btnDemoStop_Click);
            // 
            // btnDemoResum
            // 
            this.btnDemoResum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemoResum.Location = new System.Drawing.Point(1079, 56);
            this.btnDemoResum.Name = "btnDemoResum";
            this.btnDemoResum.Size = new System.Drawing.Size(49, 23);
            this.btnDemoResum.TabIndex = 11;
            this.btnDemoResum.Text = "继续";
            this.btnDemoResum.UseVisualStyleBackColor = true;
            this.btnDemoResum.Click += new System.EventHandler(this.btnDemoResum_Click);
            // 
            // lbDemo
            // 
            this.lbDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDemo.AutoSize = true;
            this.lbDemo.Location = new System.Drawing.Point(784, 61);
            this.lbDemo.Name = "lbDemo";
            this.lbDemo.Size = new System.Drawing.Size(29, 12);
            this.lbDemo.TabIndex = 12;
            this.lbDemo.Text = "演示";
            // 
            // btnDemoEnd
            // 
            this.btnDemoEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemoEnd.Location = new System.Drawing.Point(1135, 55);
            this.btnDemoEnd.Name = "btnDemoEnd";
            this.btnDemoEnd.Size = new System.Drawing.Size(42, 23);
            this.btnDemoEnd.TabIndex = 13;
            this.btnDemoEnd.Text = "结束";
            this.btnDemoEnd.UseVisualStyleBackColor = true;
            this.btnDemoEnd.Click += new System.EventHandler(this.btnDemoEnd_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagePath.Location = new System.Drawing.Point(819, 57);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(67, 21);
            this.txtImagePath.TabIndex = 14;
            this.txtImagePath.Text = "../../Image";
            // 
            // tabDataShow
            // 
            this.tabDataShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDataShow.Controls.Add(this.tabPageExperiment);
            this.tabDataShow.Controls.Add(this.tabPageEnergyCells);
            this.tabDataShow.Controls.Add(this.tabPageTickCell);
            this.tabDataShow.Controls.Add(this.tabPageAtoms);
            this.tabDataShow.Controls.Add(this.tabPageTickAtom);
            this.tabDataShow.Location = new System.Drawing.Point(701, 84);
            this.tabDataShow.Name = "tabDataShow";
            this.tabDataShow.SelectedIndex = 0;
            this.tabDataShow.Size = new System.Drawing.Size(467, 387);
            this.tabDataShow.TabIndex = 15;
            // 
            // tabPageExperiment
            // 
            this.tabPageExperiment.Controls.Add(this.dgvExperiment);
            this.tabPageExperiment.Location = new System.Drawing.Point(4, 22);
            this.tabPageExperiment.Name = "tabPageExperiment";
            this.tabPageExperiment.Size = new System.Drawing.Size(459, 361);
            this.tabPageExperiment.TabIndex = 4;
            this.tabPageExperiment.Text = "Experiment";
            this.tabPageExperiment.UseVisualStyleBackColor = true;
            // 
            // dgvExperiment
            // 
            this.dgvExperiment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExperiment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExperiment.Location = new System.Drawing.Point(3, 3);
            this.dgvExperiment.Name = "dgvExperiment";
            this.dgvExperiment.RowTemplate.Height = 23;
            this.dgvExperiment.Size = new System.Drawing.Size(453, 355);
            this.dgvExperiment.TabIndex = 0;
            // 
            // tabPageEnergyCells
            // 
            this.tabPageEnergyCells.Controls.Add(this.dgvEnergyCells);
            this.tabPageEnergyCells.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnergyCells.Name = "tabPageEnergyCells";
            this.tabPageEnergyCells.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnergyCells.Size = new System.Drawing.Size(459, 361);
            this.tabPageEnergyCells.TabIndex = 0;
            this.tabPageEnergyCells.Text = "EnergyCells";
            this.tabPageEnergyCells.UseVisualStyleBackColor = true;
            // 
            // dgvEnergyCells
            // 
            this.dgvEnergyCells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnergyCells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnergyCells.Location = new System.Drawing.Point(0, 0);
            this.dgvEnergyCells.Name = "dgvEnergyCells";
            this.dgvEnergyCells.RowTemplate.Height = 23;
            this.dgvEnergyCells.Size = new System.Drawing.Size(456, 358);
            this.dgvEnergyCells.TabIndex = 10;
            // 
            // tabPageTickCell
            // 
            this.tabPageTickCell.Controls.Add(this.dgvTickCells);
            this.tabPageTickCell.Location = new System.Drawing.Point(4, 22);
            this.tabPageTickCell.Name = "tabPageTickCell";
            this.tabPageTickCell.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTickCell.Size = new System.Drawing.Size(459, 361);
            this.tabPageTickCell.TabIndex = 1;
            this.tabPageTickCell.Text = "TickCell";
            this.tabPageTickCell.UseVisualStyleBackColor = true;
            // 
            // tabPageAtoms
            // 
            this.tabPageAtoms.Controls.Add(this.dgvAtoms);
            this.tabPageAtoms.Location = new System.Drawing.Point(4, 22);
            this.tabPageAtoms.Name = "tabPageAtoms";
            this.tabPageAtoms.Size = new System.Drawing.Size(459, 361);
            this.tabPageAtoms.TabIndex = 2;
            this.tabPageAtoms.Text = "Atoms";
            this.tabPageAtoms.UseVisualStyleBackColor = true;
            // 
            // dgvAtoms
            // 
            this.dgvAtoms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAtoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtoms.Location = new System.Drawing.Point(3, 0);
            this.dgvAtoms.Name = "dgvAtoms";
            this.dgvAtoms.RowTemplate.Height = 23;
            this.dgvAtoms.Size = new System.Drawing.Size(453, 355);
            this.dgvAtoms.TabIndex = 11;
            // 
            // tabPageTickAtom
            // 
            this.tabPageTickAtom.Controls.Add(this.dgvTickAtoms);
            this.tabPageTickAtom.Location = new System.Drawing.Point(4, 22);
            this.tabPageTickAtom.Name = "tabPageTickAtom";
            this.tabPageTickAtom.Size = new System.Drawing.Size(459, 361);
            this.tabPageTickAtom.TabIndex = 3;
            this.tabPageTickAtom.Text = "TickAtom";
            this.tabPageTickAtom.UseVisualStyleBackColor = true;
            // 
            // lbTickTip
            // 
            this.lbTickTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTickTip.AutoSize = true;
            this.lbTickTip.Location = new System.Drawing.Point(729, 60);
            this.lbTickTip.Name = "lbTickTip";
            this.lbTickTip.Size = new System.Drawing.Size(35, 12);
            this.lbTickTip.TabIndex = 16;
            this.lbTickTip.Text = "Tick:";
            // 
            // lbTick
            // 
            this.lbTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTick.AutoSize = true;
            this.lbTick.Location = new System.Drawing.Point(770, 61);
            this.lbTick.Name = "lbTick";
            this.lbTick.Size = new System.Drawing.Size(0, 12);
            this.lbTick.TabIndex = 17;
            // 
            // btnInit
            // 
            this.btnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInit.Location = new System.Drawing.Point(892, 3);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 18;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // txtJumpTick
            // 
            this.txtJumpTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJumpTick.Location = new System.Drawing.Point(901, 56);
            this.txtJumpTick.Name = "txtJumpTick";
            this.txtJumpTick.Size = new System.Drawing.Size(80, 21);
            this.txtJumpTick.TabIndex = 19;
            // 
            // EnergyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 512);
            this.Controls.Add(this.txtJumpTick);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.lbTick);
            this.Controls.Add(this.lbTickTip);
            this.Controls.Add(this.tabDataShow);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnDemoEnd);
            this.Controls.Add(this.lbDemo);
            this.Controls.Add(this.btnDemoResum);
            this.Controls.Add(this.btnDemoStop);
            this.Controls.Add(this.txtExperimentID);
            this.Controls.Add(this.btnDemoStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlContaner);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.btnInitBackground);
            this.Name = "EnergyForm";
            this.Text = "能量测试界面";
            this.Shown += new System.EventHandler(this.EnergyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickCells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickAtoms)).EndInit();
            this.tabDataShow.ResumeLayout(false);
            this.tabPageExperiment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperiment)).EndInit();
            this.tabPageEnergyCells.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnergyCells)).EndInit();
            this.tabPageTickCell.ResumeLayout(false);
            this.tabPageAtoms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtoms)).EndInit();
            this.tabPageTickAtom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitBackground;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Panel pnlContaner;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDemoStart;
        private System.Windows.Forms.DataGridView dgvTickAtoms;
        private System.Windows.Forms.TextBox txtExperimentID;
        private System.Windows.Forms.DataGridView dgvTickCells;
        private System.Windows.Forms.Button btnDemoStop;
        private System.Windows.Forms.Button btnDemoResum;
        private System.Windows.Forms.Label lbDemo;
        private System.Windows.Forms.Button btnDemoEnd;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.TabControl tabDataShow;
        private System.Windows.Forms.TabPage tabPageEnergyCells;
        private System.Windows.Forms.TabPage tabPageTickCell;
        private System.Windows.Forms.TabPage tabPageAtoms;
        private System.Windows.Forms.TabPage tabPageTickAtom;
        private System.Windows.Forms.DataGridView dgvEnergyCells;
        private System.Windows.Forms.DataGridView dgvAtoms;
        private System.Windows.Forms.TabPage tabPageExperiment;
        private System.Windows.Forms.DataGridView dgvExperiment;
        private System.Windows.Forms.Label lbTickTip;
        private System.Windows.Forms.Label lbTick;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TextBox txtJumpTick;
    }
}

