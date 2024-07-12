namespace GRH.Presentacion
{
    partial class frmMarcadoAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcadoAsistencia));
            this.conBusPersonal = new GEN.ControlesBase.ConBusCol();
            this.btnMarcarAsistencia = new GEN.BotonesBase.btnMarcarAsistencia();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // conBusPersonal
            // 
            this.conBusPersonal.Location = new System.Drawing.Point(8, 2);
            this.conBusPersonal.Name = "conBusPersonal";
            this.conBusPersonal.Size = new System.Drawing.Size(390, 86);
            this.conBusPersonal.TabIndex = 2;
            // 
            // btnMarcarAsistencia
            // 
            this.btnMarcarAsistencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMarcarAsistencia.BackgroundImage")));
            this.btnMarcarAsistencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMarcarAsistencia.Location = new System.Drawing.Point(261, 92);
            this.btnMarcarAsistencia.Name = "btnMarcarAsistencia";
            this.btnMarcarAsistencia.Size = new System.Drawing.Size(60, 50);
            this.btnMarcarAsistencia.TabIndex = 3;
            this.btnMarcarAsistencia.Text = "Marcar";
            this.btnMarcarAsistencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMarcarAsistencia.UseVisualStyleBackColor = true;
            this.btnMarcarAsistencia.Click += new System.EventHandler(this.btnMarcarAsistencia_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(327, 92);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmMarcadoAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 168);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMarcarAsistencia);
            this.Controls.Add(this.conBusPersonal);
            this.Name = "frmMarcadoAsistencia";
            this.Text = "Marcado Asistencia";
            this.Load += new System.EventHandler(this.frmMarcadoAsistencia_Load);
            this.Controls.SetChildIndex(this.conBusPersonal, 0);
            this.Controls.SetChildIndex(this.btnMarcarAsistencia, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusPersonal;
        private GEN.BotonesBase.btnMarcarAsistencia btnMarcarAsistencia;
        private GEN.BotonesBase.btnSalir btnSalir;
    }
}

