namespace CRE.Presentacion
{
    partial class frmConsultaPaqueteSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaPaqueteSeguro));
            this.dtpFechaDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImprimirAlta = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirBaja = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirCobro = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(179, 12);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaDesde.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(90, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Fecha desde:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(93, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(80, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha hasta:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(179, 43);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaHasta.TabIndex = 4;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(346, 78);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 17;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(78, 78);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimirAlta
            // 
            this.btnImprimirAlta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirAlta.BackgroundImage")));
            this.btnImprimirAlta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirAlta.Location = new System.Drawing.Point(145, 78);
            this.btnImprimirAlta.Name = "btnImprimirAlta";
            this.btnImprimirAlta.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirAlta.TabIndex = 19;
            this.btnImprimirAlta.Text = "Imprimir Alta";
            this.btnImprimirAlta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirAlta.UseVisualStyleBackColor = true;
            this.btnImprimirAlta.Click += new System.EventHandler(this.btnImprimirAlta_Click);
            // 
            // btnImprimirBaja
            // 
            this.btnImprimirBaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirBaja.BackgroundImage")));
            this.btnImprimirBaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirBaja.Location = new System.Drawing.Point(212, 78);
            this.btnImprimirBaja.Name = "btnImprimirBaja";
            this.btnImprimirBaja.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirBaja.TabIndex = 20;
            this.btnImprimirBaja.Text = "Imprimir Baja";
            this.btnImprimirBaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirBaja.UseVisualStyleBackColor = true;
            this.btnImprimirBaja.Click += new System.EventHandler(this.btnImprimirBaja_Click);
            // 
            // btnImprimirCobro
            // 
            this.btnImprimirCobro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirCobro.BackgroundImage")));
            this.btnImprimirCobro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirCobro.Location = new System.Drawing.Point(279, 78);
            this.btnImprimirCobro.Name = "btnImprimirCobro";
            this.btnImprimirCobro.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirCobro.TabIndex = 21;
            this.btnImprimirCobro.Text = "Imprimir Cobro";
            this.btnImprimirCobro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirCobro.UseVisualStyleBackColor = true;
            this.btnImprimirCobro.Click += new System.EventHandler(this.btnImprimirCobro_Click);
            // 
            // frmConsultaPaqueteSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 164);
            this.Controls.Add(this.btnImprimirCobro);
            this.Controls.Add(this.btnImprimirBaja);
            this.Controls.Add(this.btnImprimirAlta);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaDesde);
            this.Name = "frmConsultaPaqueteSeguro";
            this.Text = "Consulta Planes de Seguro";
            this.Load += new System.EventHandler(this.frmConsultaPaqueteSeguro_Load);
            this.Controls.SetChildIndex(this.dtpFechaDesde, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFechaHasta, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimirAlta, 0);
            this.Controls.SetChildIndex(this.btnImprimirBaja, 0);
            this.Controls.SetChildIndex(this.btnImprimirCobro, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFechaDesde;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaHasta;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImprimirAlta;
        private GEN.BotonesBase.btnImprimir btnImprimirBaja;
        private GEN.BotonesBase.btnImprimir btnImprimirCobro;
    }
}