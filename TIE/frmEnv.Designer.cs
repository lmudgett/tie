namespace TIE
{
    partial class frmEnv
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
            grbAdd = new GroupBox();
            groupBox2 = new GroupBox();
            clientAppsAuth = new ClientAppsAuth();
            apiKeyAuth = new ApiKeyAuth();
            rdoClientApps = new RadioButton();
            rdoAuth = new RadioButton();
            cboMax = new ComboBox();
            cmdClear = new Button();
            label4 = new Label();
            cmdDelete = new Button();
            label2 = new Label();
            label1 = new Label();
            txtUrl = new TextBox();
            txtName = new TextBox();
            cmdAdd = new Button();
            groupBox1 = new GroupBox();
            lstEnvs = new ListBox();
            cmdClose = new Button();
            grbAdd.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // grbAdd
            // 
            grbAdd.Controls.Add(groupBox2);
            grbAdd.Controls.Add(cboMax);
            grbAdd.Controls.Add(cmdClear);
            grbAdd.Controls.Add(label4);
            grbAdd.Controls.Add(cmdDelete);
            grbAdd.Controls.Add(label2);
            grbAdd.Controls.Add(label1);
            grbAdd.Controls.Add(txtUrl);
            grbAdd.Controls.Add(txtName);
            grbAdd.Controls.Add(cmdAdd);
            grbAdd.Location = new Point(12, 225);
            grbAdd.Name = "grbAdd";
            grbAdd.Size = new Size(755, 377);
            grbAdd.TabIndex = 0;
            grbAdd.TabStop = false;
            grbAdd.Text = "Details";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(clientAppsAuth);
            groupBox2.Controls.Add(apiKeyAuth);
            groupBox2.Controls.Add(rdoClientApps);
            groupBox2.Controls.Add(rdoAuth);
            groupBox2.Location = new Point(8, 156);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(741, 150);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Auth Mode";
            // 
            // clientAppsAuth
            // 
            clientAppsAuth.ClientId = "";
            clientAppsAuth.ClientSecret = "";
            clientAppsAuth.Location = new Point(-6, 65);
            clientAppsAuth.Name = "clientAppsAuth";
            clientAppsAuth.Size = new Size(741, 90);
            clientAppsAuth.TabIndex = 3;
            clientAppsAuth.Visible = false;
            // 
            // apiKeyAuth
            // 
            apiKeyAuth.APIKey = "";
            apiKeyAuth.Location = new Point(6, 65);
            apiKeyAuth.Name = "apiKeyAuth";
            apiKeyAuth.Size = new Size(735, 70);
            apiKeyAuth.TabIndex = 2;
            // 
            // rdoClientApps
            // 
            rdoClientApps.AutoSize = true;
            rdoClientApps.Location = new Point(109, 30);
            rdoClientApps.Name = "rdoClientApps";
            rdoClientApps.Size = new Size(128, 29);
            rdoClientApps.TabIndex = 1;
            rdoClientApps.Text = "Client Apps";
            rdoClientApps.UseVisualStyleBackColor = true;
            rdoClientApps.CheckedChanged += rdoClientApps_CheckedChanged;
            // 
            // rdoAuth
            // 
            rdoAuth.AutoSize = true;
            rdoAuth.Checked = true;
            rdoAuth.Location = new Point(6, 30);
            rdoAuth.Name = "rdoAuth";
            rdoAuth.Size = new Size(97, 29);
            rdoAuth.TabIndex = 0;
            rdoAuth.TabStop = true;
            rdoAuth.Text = "API Key";
            rdoAuth.UseVisualStyleBackColor = true;
            rdoAuth.CheckedChanged += rdoAuth_CheckedChanged;
            // 
            // cboMax
            // 
            cboMax.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMax.FormattingEnabled = true;
            cboMax.Items.AddRange(new object[] { "10", "20", "30", "40", "50" });
            cboMax.Location = new Point(152, 117);
            cboMax.Name = "cboMax";
            cboMax.Size = new Size(99, 33);
            cboMax.TabIndex = 12;
            // 
            // cmdClear
            // 
            cmdClear.Location = new Point(270, 337);
            cmdClear.Name = "cmdClear";
            cmdClear.Size = new Size(126, 34);
            cmdClear.TabIndex = 11;
            cmdClear.Text = "Clear";
            cmdClear.UseVisualStyleBackColor = true;
            cmdClear.Click += cmdClear_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 125);
            label4.Name = "label4";
            label4.Size = new Size(49, 25);
            label4.TabIndex = 9;
            label4.Text = "Max:";
            // 
            // cmdDelete
            // 
            cmdDelete.Location = new Point(152, 337);
            cmdDelete.Name = "cmdDelete";
            cmdDelete.Size = new Size(112, 34);
            cmdDelete.TabIndex = 8;
            cmdDelete.Text = "Delete";
            cmdDelete.UseVisualStyleBackColor = true;
            cmdDelete.Click += cmdDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 83);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 6;
            label2.Text = "URL:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 5;
            label1.Text = "Name:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(152, 80);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(597, 31);
            txtUrl.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Location = new Point(152, 43);
            txtName.Name = "txtName";
            txtName.Size = new Size(597, 31);
            txtName.TabIndex = 2;
            // 
            // cmdAdd
            // 
            cmdAdd.Location = new Point(6, 337);
            cmdAdd.Name = "cmdAdd";
            cmdAdd.Size = new Size(140, 34);
            cmdAdd.TabIndex = 1;
            cmdAdd.Text = "Add / Update";
            cmdAdd.UseVisualStyleBackColor = true;
            cmdAdd.Click += cmdAdd_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstEnvs);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(755, 190);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Environments";
            // 
            // lstEnvs
            // 
            lstEnvs.FormattingEnabled = true;
            lstEnvs.ItemHeight = 25;
            lstEnvs.Location = new Point(6, 30);
            lstEnvs.Name = "lstEnvs";
            lstEnvs.Size = new Size(743, 154);
            lstEnvs.TabIndex = 0;
            lstEnvs.SelectedIndexChanged += lstEnvs_SelectedIndexChanged;
            // 
            // cmdClose
            // 
            cmdClose.CausesValidation = false;
            cmdClose.Location = new Point(655, 620);
            cmdClose.Name = "cmdClose";
            cmdClose.Size = new Size(112, 34);
            cmdClose.TabIndex = 2;
            cmdClose.Text = "Close";
            cmdClose.UseVisualStyleBackColor = true;
            cmdClose.Click += cmdClose_Click;
            // 
            // frmEnv
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 666);
            ControlBox = false;
            Controls.Add(cmdClose);
            Controls.Add(groupBox1);
            Controls.Add(grbAdd);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEnv";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Environments";
            Load += frmEnv_Load;
            grbAdd.ResumeLayout(false);
            grbAdd.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbAdd;
        private Label label1;
        private TextBox txtUrl;
        private TextBox txtName;
        private Button cmdAdd;
        private Button cmdDelete;
        private Label label2;
        private GroupBox groupBox1;
        private ListBox lstEnvs;
        private Button cmdClose;
        private Label label4;
        private Button cmdClear;
        private ComboBox cboMax;
        private GroupBox groupBox2;
        private RadioButton rdoClientApps;
        private RadioButton rdoAuth;
        private ApiKeyAuth apiKeyAuth;
        private ClientAppsAuth clientAppsAuth;
    }
}