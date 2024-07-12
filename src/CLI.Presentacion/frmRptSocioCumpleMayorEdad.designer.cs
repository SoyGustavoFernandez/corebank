namespace CLI.Presentacion
{
    partial class frmRptSocioCumpleMayorEdad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSocioCumpleMayorEdad));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnImprFondo = new GEN.BotonesBase.btnImprimir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(188, 81);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(126, 18);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(168, 20);
            this.dtpFechaIni.TabIndex = 0;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 24);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Desde:";
            // 
            // btnImprFondo
            // 
            this.btnImprFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprFondo.BackgroundImage")));
            this.btnImprFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprFondo.Location = new System.Drawing.Point(122, 81);
            this.btnImprFondo.Name = "btnImprFondo";
            this.btnImprFondo.Size = new System.Drawing.Size(60, 50);
            this.btnImprFondo.TabIndex = 2;
            this.btnImprFondo.Text = "&Ver";
            this.btnImprFondo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprFondo.UseVisualStyleBackColor = true;
            this.btnImprFondo.Click += new System.EventHandler(this.btnImprFondo_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 50);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 21;
            this.lblBase1.Text = "Hasta la Fecha:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(126, 44);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(168, 20);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // frmRptSocioCumpleMayorEdad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 167);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnImprFondo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaIni);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRptSocioCumpleMayorEdad";
            this.Text = "Reporte de Socios Mayoria de Edad";
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpFechaIni, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprFondo, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnImprimir btnImprFondo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
    }
}