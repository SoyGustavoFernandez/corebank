namespace CRE.Presentacion
{
    partial class frmRPTSeguimientoSeguroOncologico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPTSeguimientoSeguroOncologico));
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboPersonal = new GEN.ControlesBase.cboPersonal(this.components);
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.SuspendLayout();
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.Enabled = false;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(99, 62);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(250, 21);
            this.cboAgencia.TabIndex = 52;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged_1);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(289, 113);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 51;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(229, 113);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 50;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(202, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(44, 13);
            this.lblBase5.TabIndex = 49;
            this.lblBase5.Text = "Hasta:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(48, 13);
            this.lblBase4.TabIndex = 48;
            this.lblBase4.Text = "Desde:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 90);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 47;
            this.lblBase3.Text = "Colaborador:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 66);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 46;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 42);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(41, 13);
            this.lblBase1.TabIndex = 45;
            this.lblBase1.Text = "Zona:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(99, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(90, 20);
            this.dtpDesde.TabIndex = 44;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(259, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(90, 20);
            this.dtpHasta.TabIndex = 43;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // cboPersonal
            // 
            this.cboPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonal.Enabled = false;
            this.cboPersonal.FormattingEnabled = true;
            this.cboPersonal.Location = new System.Drawing.Point(99, 86);
            this.cboPersonal.Name = "cboPersonal";
            this.cboPersonal.Size = new System.Drawing.Size(250, 21);
            this.cboPersonal.TabIndex = 42;
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.Enabled = false;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(99, 38);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(250, 21);
            this.cboZona.TabIndex = 41;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged_1);
            // 
            // frmRPTSeguimientoSeguroOncologico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 192);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.cboPersonal);
            this.Controls.Add(this.cboZona);
            this.Name = "frmRPTSeguimientoSeguroOncologico";
            this.Text = "Reporte de Seguimiento de Seguro Oncológico";
            this.Load += new System.EventHandler(this.frmRPTSeguimientoSeguroOncologico_Load);
            this.Controls.SetChildIndex(this.cboZona, 0);
            this.Controls.SetChildIndex(this.cboPersonal, 0);
            this.Controls.SetChildIndex(this.dtpHasta, 0);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpDesde;
        private GEN.ControlesBase.dtpCorto dtpHasta;
        private GEN.ControlesBase.cboPersonal cboPersonal;
        private GEN.ControlesBase.cboZona cboZona;
    }
}