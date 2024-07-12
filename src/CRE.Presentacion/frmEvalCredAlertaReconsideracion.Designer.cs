namespace CRE.Presentacion
{
    partial class frmEvalCredAlertaReconsideracion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFavorable = new System.Windows.Forms.Button();
            this.btnDesfavorable = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnDesfavorable);
            this.panel1.Controls.Add(this.btnFavorable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 184);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿ Cuál es la resolución de reconsideración ?";
            // 
            // btnFavorable
            // 
            this.btnFavorable.BackColor = System.Drawing.Color.Lime;
            this.btnFavorable.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnFavorable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFavorable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFavorable.Location = new System.Drawing.Point(42, 68);
            this.btnFavorable.Name = "btnFavorable";
            this.btnFavorable.Size = new System.Drawing.Size(119, 45);
            this.btnFavorable.TabIndex = 1;
            this.btnFavorable.Text = "Favorable";
            this.btnFavorable.UseVisualStyleBackColor = false;
            this.btnFavorable.Click += new System.EventHandler(this.btnFavorable_Click);
            // 
            // btnDesfavorable
            // 
            this.btnDesfavorable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDesfavorable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDesfavorable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesfavorable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesfavorable.ForeColor = System.Drawing.Color.Maroon;
            this.btnDesfavorable.Location = new System.Drawing.Point(234, 68);
            this.btnDesfavorable.Name = "btnDesfavorable";
            this.btnDesfavorable.Size = new System.Drawing.Size(119, 45);
            this.btnDesfavorable.TabIndex = 2;
            this.btnDesfavorable.Text = "Desfavorable";
            this.btnDesfavorable.UseVisualStyleBackColor = false;
            this.btnDesfavorable.Click += new System.EventHandler(this.btnDesfavorable_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(0, 135);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 49);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "* Si sale del formulario haciendo clic sobre el botón cerrar ( X ), por defecto s" +
    "e considerará DESFAVORABLE.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmEvalCredAlertaReconsideracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 206);
            this.Controls.Add(this.panel1);
            this.Name = "frmEvalCredAlertaReconsideracion";
            this.Text = "Resolución de Reconsideración";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDesfavorable;
        private System.Windows.Forms.Button btnFavorable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}