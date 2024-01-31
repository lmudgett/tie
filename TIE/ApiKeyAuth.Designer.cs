namespace TIE
{
    partial class ApiKeyAuth
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
            label3 = new Label();
            txtApiKey = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 9);
            label3.Name = "label3";
            label3.Size = new Size(76, 25);
            label3.TabIndex = 9;
            label3.Text = "API Key:";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(148, 3);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(597, 31);
            txtApiKey.TabIndex = 8;
            // 
            // ApiKeyAuth
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(txtApiKey);
            Name = "ApiKeyAuth";
            Size = new Size(772, 47);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox txtApiKey;
    }
}
