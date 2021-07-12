namespace LOLConfigChanger
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.icnTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAutoLoad = new System.Windows.Forms.CheckBox();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(12, 43);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(184, 30);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "현재 설정 백업";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(202, 43);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(184, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "설정 불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtClientPath
            // 
            this.txtClientPath.Location = new System.Drawing.Point(87, 12);
            this.txtClientPath.Name = "txtClientPath";
            this.txtClientPath.Size = new System.Drawing.Size(261, 25);
            this.txtClientPath.TabIndex = 2;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(344, 12);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(43, 25);
            this.btnSelectPath.TabIndex = 3;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // chkStart
            // 
            this.chkStart.Location = new System.Drawing.Point(12, 101);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(174, 24);
            this.chkStart.TabIndex = 4;
            this.chkStart.Text = "윈도우 부팅 시 실행";
            this.chkStart.UseVisualStyleBackColor = true;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(12, 11);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(69, 26);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "롤 경로:";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // icnTray
            // 
            this.icnTray.ContextMenuStrip = this.cmsTray;
            this.icnTray.Icon = ((System.Drawing.Icon) (resources.GetObject("icnTray.Icon")));
            this.icnTray.Text = "LOLConfigChanger";
            this.icnTray.Visible = true;
            this.icnTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icnTray_MouseDoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.tsmiOpen, this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(109, 52);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(108, 24);
            this.tsmiOpen.Text = "열기";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(108, 24);
            this.tsmiExit.Text = "종료";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // chkAutoLoad
            // 
            this.chkAutoLoad.Location = new System.Drawing.Point(12, 79);
            this.chkAutoLoad.Name = "chkAutoLoad";
            this.chkAutoLoad.Size = new System.Drawing.Size(280, 24);
            this.chkAutoLoad.TabIndex = 6;
            this.chkAutoLoad.Text = "롤 실행 시 자동으로 설정 불러오기";
            this.chkAutoLoad.UseVisualStyleBackColor = true;
            this.chkAutoLoad.CheckedChanged += new System.EventHandler(this.chkAutoLoad_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(400, 137);
            this.Controls.Add(this.chkAutoLoad);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.chkStart);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtClientPath);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "LOLConfigChanger";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnBackup;

        public System.Windows.Forms.CheckBox chkAutoLoad;

        private System.Windows.Forms.ContextMenuStrip cmsTray;

        public System.Windows.Forms.NotifyIcon icnTray;

        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;

        private System.Windows.Forms.ContextMenuStrip ctx;

        private System.Windows.Forms.NotifyIcon icn;

        private System.Windows.Forms.NotifyIcon icon;

        private System.Windows.Forms.Label lblPath;

        private System.Windows.Forms.CheckBox chkStart;

        public System.Windows.Forms.TextBox txtClientPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;

        #endregion
    }
}