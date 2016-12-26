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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDemoStart = new System.Windows.Forms.Button();
            this.dgvAtom = new System.Windows.Forms.DataGridView();
            this.txtExperimentID = new System.Windows.Forms.TextBox();
            this.dgvCell = new System.Windows.Forms.DataGridView();
            this.btnDemoStop = new System.Windows.Forms.Button();
            this.btnDemoResum = new System.Windows.Forms.Button();
            this.lbDemo = new System.Windows.Forms.Label();
            this.btnDemoEnd = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCell)).BeginInit();
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
            this.pnlContaner.Size = new System.Drawing.Size(729, 488);
            this.pnlContaner.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1093, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始测试";
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
            // dgvAtom
            // 
            this.dgvAtom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAtom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtom.Location = new System.Drawing.Point(758, 84);
            this.dgvAtom.Name = "dgvAtom";
            this.dgvAtom.RowTemplate.Height = 23;
            this.dgvAtom.Size = new System.Drawing.Size(419, 331);
            this.dgvAtom.TabIndex = 6;
            // 
            // txtExperimentID
            // 
            this.txtExperimentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExperimentID.Location = new System.Drawing.Point(973, 5);
            this.txtExperimentID.Name = "txtExperimentID";
            this.txtExperimentID.Size = new System.Drawing.Size(100, 21);
            this.txtExperimentID.TabIndex = 8;
            // 
            // dgvCell
            // 
            this.dgvCell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCell.Location = new System.Drawing.Point(758, 233);
            this.dgvCell.Name = "dgvCell";
            this.dgvCell.RowTemplate.Height = 23;
            this.dgvCell.Size = new System.Drawing.Size(410, 238);
            this.dgvCell.TabIndex = 9;
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
            this.lbDemo.Location = new System.Drawing.Point(834, 61);
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
            this.txtImagePath.Location = new System.Drawing.Point(881, 57);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(100, 21);
            this.txtImagePath.TabIndex = 14;
            this.txtImagePath.Text = "../../Image";
            // 
            // EnergyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 512);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnDemoEnd);
            this.Controls.Add(this.lbDemo);
            this.Controls.Add(this.btnDemoResum);
            this.Controls.Add(this.btnDemoStop);
            this.Controls.Add(this.dgvCell);
            this.Controls.Add(this.txtExperimentID);
            this.Controls.Add(this.dgvAtom);
            this.Controls.Add(this.btnDemoStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlContaner);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.btnInitBackground);
            this.Name = "EnergyForm";
            this.Text = "能量测试界面";
            this.Shown += new System.EventHandler(this.EnergyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCell)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvAtom;
        private System.Windows.Forms.TextBox txtExperimentID;
        private System.Windows.Forms.DataGridView dgvCell;
        private System.Windows.Forms.Button btnDemoStop;
        private System.Windows.Forms.Button btnDemoResum;
        private System.Windows.Forms.Label lbDemo;
        private System.Windows.Forms.Button btnDemoEnd;
        private System.Windows.Forms.TextBox txtImagePath;
    }
}

