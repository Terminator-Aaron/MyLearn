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
            this.SuspendLayout();
            // 
            // btnInitBackground
            // 
            this.btnInitBackground.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInitBackground.Location = new System.Drawing.Point(754, 12);
            this.btnInitBackground.Name = "btnInitBackground";
            this.btnInitBackground.Size = new System.Drawing.Size(75, 23);
            this.btnInitBackground.TabIndex = 0;
            this.btnInitBackground.Text = "加载界面";
            this.btnInitBackground.UseVisualStyleBackColor = true;
            this.btnInitBackground.Click += new System.EventHandler(this.btnInitBackground_Click);
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtStartIndex.Location = new System.Drawing.Point(729, 100);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(100, 21);
            this.txtStartIndex.TabIndex = 1;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLoadData.Location = new System.Drawing.Point(754, 139);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "加载数据";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // pnlContaner
            // 
            this.pnlContaner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContaner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContaner.Location = new System.Drawing.Point(12, 12);
            this.pnlContaner.Name = "pnlContaner";
            this.pnlContaner.Size = new System.Drawing.Size(700, 464);
            this.pnlContaner.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.Location = new System.Drawing.Point(754, 59);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始测试";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // EnergyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 488);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlContaner);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtStartIndex);
            this.Controls.Add(this.btnInitBackground);
            this.Name = "EnergyForm";
            this.Text = "能量测试界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitBackground;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Panel pnlContaner;
        private System.Windows.Forms.Button btnStart;
    }
}

