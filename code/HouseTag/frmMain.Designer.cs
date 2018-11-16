namespace HouseTag
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbxCity = new System.Windows.Forms.GroupBox();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.txtSearchProject = new System.Windows.Forms.TextBox();
            this.lblStatusTips = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxLabel = new System.Windows.Forms.GroupBox();
            this.pnlLabel = new System.Windows.Forms.Panel();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblAddess = new System.Windows.Forms.Label();
            this.gbxComment = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblDataTips = new System.Windows.Forms.Label();
            this.lstSearchResult = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.gbxInput.SuspendLayout();
            this.gbxLabel.SuspendLayout();
            this.gbxComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCity
            // 
            this.gbxCity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxCity.Location = new System.Drawing.Point(22, 17);
            this.gbxCity.Name = "gbxCity";
            this.gbxCity.Size = new System.Drawing.Size(908, 79);
            this.gbxCity.TabIndex = 0;
            this.gbxCity.TabStop = false;
            this.gbxCity.Text = "城市";
            this.gbxCity.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxCity_Paint);
            // 
            // gbxInput
            // 
            this.gbxInput.Controls.Add(this.txtSearchProject);
            this.gbxInput.Controls.Add(this.lblStatusTips);
            this.gbxInput.Controls.Add(this.btnStart);
            this.gbxInput.Controls.Add(this.label2);
            this.gbxInput.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxInput.Location = new System.Drawing.Point(22, 102);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(908, 79);
            this.gbxInput.TabIndex = 1;
            this.gbxInput.TabStop = false;
            this.gbxInput.Text = "楼盘";
            this.gbxInput.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxInput_Paint);
            // 
            // txtSearchProject
            // 
            this.txtSearchProject.Font = new System.Drawing.Font("宋体", 13F);
            this.txtSearchProject.Location = new System.Drawing.Point(131, 32);
            this.txtSearchProject.Name = "txtSearchProject";
            this.txtSearchProject.Size = new System.Drawing.Size(361, 27);
            this.txtSearchProject.TabIndex = 4;
            this.txtSearchProject.TextChanged += new System.EventHandler(this.txtSearchProject_TextChanged);
            this.txtSearchProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchProject_KeyDown);
            // 
            // lblStatusTips
            // 
            this.lblStatusTips.AutoSize = true;
            this.lblStatusTips.ForeColor = System.Drawing.Color.Red;
            this.lblStatusTips.Location = new System.Drawing.Point(704, 40);
            this.lblStatusTips.Name = "lblStatusTips";
            this.lblStatusTips.Size = new System.Drawing.Size(64, 16);
            this.lblStatusTips.TabIndex = 3;
            this.lblStatusTips.Text = "*******";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStart.Location = new System.Drawing.Point(532, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "输入楼盘名称";
            // 
            // gbxLabel
            // 
            this.gbxLabel.Controls.Add(this.pnlLabel);
            this.gbxLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxLabel.Location = new System.Drawing.Point(22, 217);
            this.gbxLabel.Name = "gbxLabel";
            this.gbxLabel.Size = new System.Drawing.Size(908, 129);
            this.gbxLabel.TabIndex = 2;
            this.gbxLabel.TabStop = false;
            this.gbxLabel.Text = "标签";
            this.gbxLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxLabel_Paint);
            // 
            // pnlLabel
            // 
            this.pnlLabel.AutoScroll = true;
            this.pnlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabel.Location = new System.Drawing.Point(3, 22);
            this.pnlLabel.Name = "pnlLabel";
            this.pnlLabel.Size = new System.Drawing.Size(902, 104);
            this.pnlLabel.TabIndex = 0;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProjectName.ForeColor = System.Drawing.Color.Blue;
            this.lblProjectName.Location = new System.Drawing.Point(102, 192);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(64, 16);
            this.lblProjectName.TabIndex = 5;
            this.lblProjectName.Text = "*******";
            // 
            // lblAddess
            // 
            this.lblAddess.AutoSize = true;
            this.lblAddess.Font = new System.Drawing.Font("宋体", 11F);
            this.lblAddess.ForeColor = System.Drawing.Color.Blue;
            this.lblAddess.Location = new System.Drawing.Point(387, 194);
            this.lblAddess.Name = "lblAddess";
            this.lblAddess.Size = new System.Drawing.Size(183, 15);
            this.lblAddess.TabIndex = 6;
            this.lblAddess.Text = "**********************";
            // 
            // gbxComment
            // 
            this.gbxComment.Controls.Add(this.lblComment);
            this.gbxComment.Controls.Add(this.txtComment);
            this.gbxComment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxComment.Location = new System.Drawing.Point(22, 359);
            this.gbxComment.Name = "gbxComment";
            this.gbxComment.Size = new System.Drawing.Size(908, 347);
            this.gbxComment.TabIndex = 7;
            this.gbxComment.TabStop = false;
            this.gbxComment.Text = "评论";
            this.gbxComment.Paint += new System.Windows.Forms.PaintEventHandler(this.gbxComment_Paint);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblComment.ForeColor = System.Drawing.Color.Red;
            this.lblComment.Location = new System.Drawing.Point(355, 22);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(48, 16);
            this.lblComment.TabIndex = 1;
            this.lblComment.Text = "*****";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(7, 47);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(890, 294);
            this.txtComment.TabIndex = 0;
            this.txtComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComment_KeyPress);
            // 
            // lblDataTips
            // 
            this.lblDataTips.AutoSize = true;
            this.lblDataTips.Location = new System.Drawing.Point(22, 711);
            this.lblDataTips.Name = "lblDataTips";
            this.lblDataTips.Size = new System.Drawing.Size(359, 12);
            this.lblDataTips.TabIndex = 8;
            this.lblDataTips.Text = "*所有数据均来自于安居客和房天下完全公开的新房楼盘及评论数据";
            // 
            // lstSearchResult
            // 
            this.lstSearchResult.Font = new System.Drawing.Font("宋体", 13F);
            this.lstSearchResult.FormattingEnabled = true;
            this.lstSearchResult.ItemHeight = 17;
            this.lstSearchResult.Location = new System.Drawing.Point(153, 161);
            this.lstSearchResult.Name = "lstSearchResult";
            this.lstSearchResult.Size = new System.Drawing.Size(361, 106);
            this.lstSearchResult.TabIndex = 6;
            this.lstSearchResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSearchResult_MouseClick);
            this.lstSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSearchResult_KeyDown);
            this.lstSearchResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSearchResult_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 711);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "*评论数据均已过滤代抢、楼盘置业顾问等(不保证100%过滤)";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("宋体", 12F);
            this.lblPrice.ForeColor = System.Drawing.Color.Blue;
            this.lblPrice.Location = new System.Drawing.Point(725, 194);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(120, 16);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "**************";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 730);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSearchResult);
            this.Controls.Add(this.lblDataTips);
            this.Controls.Add(this.gbxComment);
            this.Controls.Add(this.lblAddess);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.gbxLabel);
            this.Controls.Add(this.gbxInput);
            this.Controls.Add(this.gbxCity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "楼盘评论标签";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            this.gbxLabel.ResumeLayout(false);
            this.gbxComment.ResumeLayout(false);
            this.gbxComment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCity;
        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStatusTips;
        private System.Windows.Forms.GroupBox gbxLabel;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblAddess;
        private System.Windows.Forms.GroupBox gbxComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtSearchProject;
        private System.Windows.Forms.Panel pnlLabel;
        private System.Windows.Forms.Label lblDataTips;
        private System.Windows.Forms.ListBox lstSearchResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrice;
    }
}

