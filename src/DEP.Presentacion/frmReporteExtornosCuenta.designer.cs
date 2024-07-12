namespace DEP.Presentacion
{
    partial class frmReporteExtornosCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteExtornosCuenta));
            this.lblFechaDesde = new GEN.ControlesBase.lblBase();
            this.lblFechaHasta = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.dtFechaDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtFechaHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaDesde.Location = new System.Drawing.Point(129, 135);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(48, 13);
            this.lblFechaDesde.TabIndex = 4;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaHasta.Location = new System.Drawing.Point(284, 135);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(44, 13);
            this.lblFechaHasta.TabIndex = 5;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(513, 172);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Location = new System.Drawing.Point(12, 12);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho.TabIndex = 9;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // dtFechaDesde
            // 
            this.dtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDesde.Location = new System.Drawing.Point(183, 132);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(96, 20);
            this.dtFechaDesde.TabIndex = 10;
            // 
            // dtFechaHasta
            // 
            this.dtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaHasta.Location = new System.Drawing.Point(334, 132);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.Size = new System.Drawing.Size(96, 20);
            this.dtFechaHasta.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(447, 172);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(381, 172);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 13;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmReporteExtornosCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 253);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtFechaHasta);
            this.Controls.Add(this.dtFechaDesde);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Name = "frmReporteExtornosCuenta";
            this.Text = "Reporte de Extornos de Cta de Ahorros";
            this.Load += new System.EventHandler(this.frmReporteExtornosCuenta_Load);
            this.Controls.SetChildIndex(this.lblFechaDesde, 0);
            this.Controls.SetChildIndex(this.lblFechaHasta, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.dtFechaDesde, 0);
            this.Controls.SetChildIndex(this.dtFechaHasta, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblFechaDesde;
        private GEN.ControlesBase.lblBase lblFechaHasta;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.dtpCorto dtFechaDesde;
        private GEN.ControlesBase.dtpCorto dtFechaHasta;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
    }
}