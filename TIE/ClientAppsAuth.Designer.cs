namespace TIE
{
    partial class ClientAppsAuth
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblClientId = new Label();
            txtClientId = new TextBox();
            lblClientSecret = new Label();
            txtClientSecret = new TextBox();
            SuspendLayout();
            // 
            // lblClientId
            // 
            lblClientId.AutoSize = true;
            lblClientId.Location = new Point(13, 14);
            lblClientId.Name = "lblClientId";
            lblClientId.Size = new Size(83, 25);
            lblClientId.TabIndex = 0;
            lblClientId.Text = "Client ID:";
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(132, 11);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(597, 31);
            txtClientId.TabIndex = 1;
            // 
            // lblClientSecret
            // 
            lblClientSecret.AutoSize = true;
            lblClientSecret.Location = new Point(13, 50);
            lblClientSecret.Name = "lblClientSecret";
            lblClientSecret.Size = new Size(113, 25);
            lblClientSecret.TabIndex = 2;
            lblClientSecret.Text = "Client Secret:";
            // 
            // txtClientSecret
            // 
            txtClientSecret.Location = new Point(132, 50);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new Size(597, 31);
            txtClientSecret.TabIndex = 3;
            // 
            // ClientAppsAuth
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtClientSecret);
            Controls.Add(lblClientSecret);
            Controls.Add(txtClientId);
            Controls.Add(lblClientId);
            Name = "ClientAppsAuth";
            Size = new Size(765, 97);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClientId;
        private TextBox txtClientId;
        private Label lblClientSecret;
        private TextBox txtClientSecret;
    }
}
