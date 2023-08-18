namespace Comedy_Of_Errors
{
    partial class ComedyOfErros_Shubhang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComedyOfErros_Shubhang));
            this.Vision = new System.Windows.Forms.PictureBox();
            this.HULK = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Vision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HULK)).BeginInit();
            this.SuspendLayout();
            // 
            // Vision
            // 
            resources.ApplyResources(this.Vision, "Vision");
            this.Vision.Name = "Vision";
            this.Vision.TabStop = false;
            this.Vision.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HULK
            // 
            resources.ApplyResources(this.HULK, "HULK");
            this.HULK.Name = "HULK";
            this.HULK.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComedyOfErros_Shubhang
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.HULK);
            this.Controls.Add(this.Vision);
            this.Name = "ComedyOfErros_Shubhang";
            ((System.ComponentModel.ISupportInitialize)(this.Vision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HULK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Vision;
        private System.Windows.Forms.PictureBox HULK;
        private System.Windows.Forms.Button button1;
    }
}

