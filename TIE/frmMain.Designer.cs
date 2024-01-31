namespace TIE
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lstFrom = new ListBox();
            cboFrom = new ComboBox();
            mnuMain = new MenuStrip();
            mniFile = new ToolStripMenuItem();
            mniEnv = new ToolStripMenuItem();
            mniClearCache = new ToolStripMenuItem();
            mniExit = new ToolStripMenuItem();
            mniEdit = new ToolStripMenuItem();
            mniTokenManager = new ToolStripMenuItem();
            mniHelp = new ToolStripMenuItem();
            mniAbout = new ToolStripMenuItem();
            grpTo = new GroupBox();
            lstTo = new ListBox();
            cboTo = new ComboBox();
            cmdTransfer = new Button();
            statusStrip1 = new StatusStrip();
            tslMain = new ToolStripStatusLabel();
            tspBar = new ToolStripProgressBar();
            groupBox1.SuspendLayout();
            mnuMain.SuspendLayout();
            grpTo.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstFrom);
            groupBox1.Controls.Add(cboFrom);
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(565, 333);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Destination from:";
            // 
            // lstFrom
            // 
            lstFrom.FormattingEnabled = true;
            lstFrom.ItemHeight = 25;
            lstFrom.Location = new Point(0, 69);
            lstFrom.Name = "lstFrom";
            lstFrom.Size = new Size(559, 229);
            lstFrom.TabIndex = 1;
            // 
            // cboFrom
            // 
            cboFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFrom.FormattingEnabled = true;
            cboFrom.Location = new Point(0, 30);
            cboFrom.Name = "cboFrom";
            cboFrom.Size = new Size(559, 33);
            cboFrom.TabIndex = 0;
            cboFrom.SelectedIndexChanged += cboFrom_SelectedIndexChanged;
            // 
            // mnuMain
            // 
            mnuMain.ImageScalingSize = new Size(24, 24);
            mnuMain.Items.AddRange(new ToolStripItem[] { mniFile, mniEdit, mniHelp });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new Size(1231, 33);
            mnuMain.TabIndex = 1;
            mnuMain.Text = "menuStrip1";
            // 
            // mniFile
            // 
            mniFile.DropDownItems.AddRange(new ToolStripItem[] { mniEnv, mniClearCache, mniExit });
            mniFile.Name = "mniFile";
            mniFile.Size = new Size(54, 29);
            mniFile.Text = "File";
            // 
            // mniEnv
            // 
            mniEnv.Name = "mniEnv";
            mniEnv.Size = new Size(222, 34);
            mniEnv.Text = "Environments";
            mniEnv.Click += mniEnv_Click;
            // 
            // mniClearCache
            // 
            mniClearCache.Name = "mniClearCache";
            mniClearCache.Size = new Size(222, 34);
            mniClearCache.Text = "Clear Cache";
            mniClearCache.Click += mniClearCache_Click;
            // 
            // mniExit
            // 
            mniExit.Name = "mniExit";
            mniExit.Size = new Size(222, 34);
            mniExit.Text = "Exit";
            mniExit.Click += mniExit_Click;
            // 
            // mniEdit
            // 
            mniEdit.DropDownItems.AddRange(new ToolStripItem[] { mniTokenManager });
            mniEdit.Name = "mniEdit";
            mniEdit.Size = new Size(58, 29);
            mniEdit.Text = "Edit";
            // 
            // mniTokenManager
            // 
            mniTokenManager.Name = "mniTokenManager";
            mniTokenManager.Size = new Size(235, 34);
            mniTokenManager.Text = "Token Manager";
            mniTokenManager.Click += mniTokenManager_Click;
            // 
            // mniHelp
            // 
            mniHelp.DropDownItems.AddRange(new ToolStripItem[] { mniAbout });
            mniHelp.Name = "mniHelp";
            mniHelp.Size = new Size(36, 29);
            mniHelp.Text = "?";
            // 
            // mniAbout
            // 
            mniAbout.Name = "mniAbout";
            mniAbout.Size = new Size(270, 34);
            mniAbout.Text = "About";
            mniAbout.Click += mniAbout_Click;
            // 
            // grpTo
            // 
            grpTo.Controls.Add(lstTo);
            grpTo.Controls.Add(cboTo);
            grpTo.Enabled = false;
            grpTo.Location = new Point(649, 49);
            grpTo.Name = "grpTo";
            grpTo.Size = new Size(564, 317);
            grpTo.TabIndex = 3;
            grpTo.TabStop = false;
            grpTo.Text = "Destination to:";
            // 
            // lstTo
            // 
            lstTo.FormattingEnabled = true;
            lstTo.ItemHeight = 25;
            lstTo.Location = new Point(6, 69);
            lstTo.Name = "lstTo";
            lstTo.Size = new Size(559, 229);
            lstTo.TabIndex = 2;
            // 
            // cboTo
            // 
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTo.FormattingEnabled = true;
            cboTo.Location = new Point(6, 30);
            cboTo.Name = "cboTo";
            cboTo.Size = new Size(559, 33);
            cboTo.TabIndex = 0;
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
            // 
            // cmdTransfer
            // 
            cmdTransfer.Location = new Point(583, 205);
            cmdTransfer.Name = "cmdTransfer";
            cmdTransfer.Size = new Size(60, 34);
            cmdTransfer.TabIndex = 4;
            cmdTransfer.Text = "-->";
            cmdTransfer.UseVisualStyleBackColor = true;
            cmdTransfer.Click += cmdTransfer_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslMain, tspBar });
            statusStrip1.Location = new Point(0, 369);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1231, 28);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslMain
            // 
            tslMain.Name = "tslMain";
            tslMain.Size = new Size(0, 21);
            // 
            // tspBar
            // 
            tspBar.Name = "tspBar";
            tspBar.Size = new Size(100, 20);
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 397);
            Controls.Add(statusStrip1);
            Controls.Add(cmdTransfer);
            Controls.Add(grpTo);
            Controls.Add(groupBox1);
            Controls.Add(mnuMain);
            MainMenuStrip = mnuMain;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Template Import Export";
            FormClosed += frmMain_FormClosed;
            Load += frmMain_Load;
            groupBox1.ResumeLayout(false);
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            grpTo.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private MenuStrip mnuMain;
        private ToolStripMenuItem mniFile;
        private ToolStripMenuItem mniEnv;
        private ToolStripMenuItem mniHelp;
        private ListBox lstFrom;
        private ComboBox cboFrom;
        private GroupBox grpTo;
        private ComboBox cboTo;
        private ListBox lstTo;
        private Button cmdTransfer;
        private ToolStripMenuItem mniAbout;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar tspBar;
        private ToolStripStatusLabel tslMain;
        private ToolStripMenuItem mniClearCache;
        private ToolStripMenuItem mniExit;
        private ToolStripMenuItem mniEdit;
        private ToolStripMenuItem mniTokenManager;
    }
}
