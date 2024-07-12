namespace GEN.ControlesBase
{
    partial class frmExperienciaClienteAlertaCumple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExperienciaClienteAlertaCumple));
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.lblSegmento = new System.Windows.Forms.Label();
            this.lblFechaCumpleaños = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(275, 287);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 16;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // lblSegmento
            // 
            this.lblSegmento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegmento.Location = new System.Drawing.Point(245, 227);
            this.lblSegmento.Name = "lblSegmento";
            this.lblSegmento.Size = new System.Drawing.Size(356, 23);
            this.lblSegmento.TabIndex = 15;
            this.lblSegmento.Text = "nName";
            this.lblSegmento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaCumpleaños
            // 
            this.lblFechaCumpleaños.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCumpleaños.Location = new System.Drawing.Point(243, 188);
            this.lblFechaCumpleaños.Name = "lblFechaCumpleaños";
            this.lblFechaCumpleaños.Size = new System.Drawing.Size(358, 23);
            this.lblFechaCumpleaños.TabIndex = 14;
            this.lblFechaCumpleaños.Text = "nName";
            this.lblFechaCumpleaños.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Segmento :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fecha de Cumpleaños :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNombres
            // 
            this.lblNombres.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.Location = new System.Drawing.Point(29, 113);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(575, 23);
            this.lblNombres.TabIndex = 11;
            this.lblNombres.Text = "nName";
            this.lblNombres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "FELIZ CUMPLEAÑOS !!!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmExperienciaClienteAlertaCumple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 398);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblSegmento);
            this.Controls.Add(this.lblFechaCumpleaños);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.label1);
            this.Name = "frmExperienciaClienteAlertaCumple";
            this.Text = "Alerta Cumpleaños";
            this.Load += new System.EventHandler(this.frmExperienciaClienteAlertaCumple_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblNombres, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblFechaCumpleaños, 0);
            this.Controls.SetChildIndex(this.lblSegmento, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.BtnAceptar btnAceptar1;
        private System.Windows.Forms.Label lblSegmento;
        private System.Windows.Forms.Label lblFechaCumpleaños;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label label1;
    }
}