namespace TIE
{
    partial class frmTokenManager
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
            cmdClose = new Button();
            groupBox1 = new GroupBox();
            cboTokenType = new ComboBox();
            groupBox2 = new GroupBox();
            lstTokens = new ListBox();
            groupBox3 = new GroupBox();
            cmdClear = new Button();
            cmdUpdate = new Button();
            txtToken = new TextBox();
            cmdDelete = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // cmdClose
            // 
            cmdClose.Location = new Point(676, 404);
            cmdClose.Name = "cmdClose";
            cmdClose.Size = new Size(112, 34);
            cmdClose.TabIndex = 0;
            cmdClose.Text = "Close";
            cmdClose.UseVisualStyleBackColor = true;
            cmdClose.Click += cmdClose_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboTokenType);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 64);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Token Type:";
            // 
            // cboTokenType
            // 
            cboTokenType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTokenType.FormattingEnabled = true;
            cboTokenType.Items.AddRange(new object[] { "Package Tokens", "Document Tokens", "Search Tokens" });
            cboTokenType.Location = new Point(6, 25);
            cboTokenType.Name = "cboTokenType";
            cboTokenType.Size = new Size(212, 33);
            cboTokenType.TabIndex = 0;
            cboTokenType.SelectedIndexChanged += cboTokenType_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstTokens);
            groupBox2.Location = new Point(12, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 212);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Token List";
            // 
            // lstTokens
            // 
            lstTokens.FormattingEnabled = true;
            lstTokens.ItemHeight = 25;
            lstTokens.Location = new Point(0, 30);
            lstTokens.Name = "lstTokens";
            lstTokens.Size = new Size(770, 154);
            lstTokens.TabIndex = 0;
            lstTokens.SelectedIndexChanged += lstTokens_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmdClear);
            groupBox3.Controls.Add(cmdUpdate);
            groupBox3.Controls.Add(txtToken);
            groupBox3.Controls.Add(cmdDelete);
            groupBox3.Location = new Point(12, 272);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(770, 126);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Token";
            // 
            // cmdClear
            // 
            cmdClear.Location = new Point(266, 86);
            cmdClear.Name = "cmdClear";
            cmdClear.Size = new Size(112, 34);
            cmdClear.TabIndex = 6;
            cmdClear.Text = "Clear";
            cmdClear.UseVisualStyleBackColor = true;
            cmdClear.Click += cmdClear_Click;
            // 
            // cmdUpdate
            // 
            cmdUpdate.Location = new Point(6, 86);
            cmdUpdate.Name = "cmdUpdate";
            cmdUpdate.Size = new Size(136, 34);
            cmdUpdate.TabIndex = 5;
            cmdUpdate.Text = "Add / Update";
            cmdUpdate.UseVisualStyleBackColor = true;
            cmdUpdate.Click += cmdUpdate_Click;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(6, 30);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(758, 31);
            txtToken.TabIndex = 4;
            // 
            // cmdDelete
            // 
            cmdDelete.Location = new Point(148, 86);
            cmdDelete.Name = "cmdDelete";
            cmdDelete.Size = new Size(112, 34);
            cmdDelete.TabIndex = 3;
            cmdDelete.Text = "Delete";
            cmdDelete.UseVisualStyleBackColor = true;
            cmdDelete.Click += cmdDelete_Click;
            // 
            // frmTokenManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(cmdClose);
            Name = "frmTokenManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Token Manager";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button cmdClose;
        private GroupBox groupBox1;
        private ComboBox cboTokenType;
        private GroupBox groupBox2;
        private ListBox lstTokens;
        private GroupBox groupBox3;
        private Button cmdUpdate;
        private TextBox txtToken;
        private Button cmdDelete;
        private Button cmdClear;
    }
}