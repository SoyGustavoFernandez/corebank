namespace GEN.ControlesBase
{
    partial class ConSolesDolar
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
            this.picDolar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDolar)).BeginInit();
            this.SuspendLayout();
            // 
            // picDolar
            // 
            this.picDolar.Image = global::GEN.ControlesBase.Properties.Resources.Signo_dolar;
            this.picDolar.Location = new System.Drawing.Point(1, 1);
            this.picDolar.Name = "picDolar";
            this.picDolar.Size = new System.Drawing.Size(52, 50);
            this.picDolar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDolar.TabIndex = 0;
            this.picDolar.TabStop = false;
            this.picDolar.Click += new System.EventHandler(this.picDolar_Click);
            // 
            // ConSolesDolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picDolar);
            this.Name = "ConSolesDolar";
            this.Size = new System.Drawing.Size(54, 52);
            this.Load += new System.EventHandler(this.ConSolesDolar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDolar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picDolar;
    }
}
