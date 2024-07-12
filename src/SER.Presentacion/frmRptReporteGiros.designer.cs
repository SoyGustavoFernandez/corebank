using System.Drawing;

namespace SER.Presentacion
{
    partial class frmRptReporteGiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptReporteGiros));
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnImprimirMovGiro = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnProcesarMovGiro = new GEN.BotonesBase.btnProcesar();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboEstablecimientoGiro = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.cboAgenciasGiros = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboTipoOperacionGiro = new GEN.ControlesBase.cboTipoOperacionGiro(this.components);
            this.cboZonaGiros = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgMovimientosLista = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientosLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(489, 52);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(260, 20);
            this.dtpFecFin.TabIndex = 112;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(489, 25);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(260, 20);
            this.dtpFecIni.TabIndex = 111;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(413, 57);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 114;
            this.lblBase2.Text = "Hasta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(413, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 113;
            this.lblBase1.Text = "Desde:";
            // 
            // btnImprimirMovGiro
            // 
            this.btnImprimirMovGiro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirMovGiro.BackgroundImage")));
            this.btnImprimirMovGiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirMovGiro.Location = new System.Drawing.Point(882, 25);
            this.btnImprimirMovGiro.Name = "btnImprimirMovGiro";
            this.btnImprimirMovGiro.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirMovGiro.TabIndex = 115;
            this.btnImprimirMovGiro.Text = "&Imprimir";
            this.btnImprimirMovGiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirMovGiro.UseVisualStyleBackColor = true;
            this.btnImprimirMovGiro.Click += new System.EventHandler(this.btnImprimirMovGiro_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnProcesarMovGiro);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.cboEstablecimientoGiro);
            this.grbBase1.Controls.Add(this.cboAgenciasGiros);
            this.grbBase1.Controls.Add(this.cboTipoOperacionGiro);
            this.grbBase1.Controls.Add(this.cboZonaGiros);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.btnImprimirMovGiro);
            this.grbBase1.Location = new System.Drawing.Point(113, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(960, 116);
            this.grbBase1.TabIndex = 116;
            this.grbBase1.TabStop = false;
            // 
            // btnProcesarMovGiro
            // 
            this.btnProcesarMovGiro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesarMovGiro.BackgroundImage")));
            this.btnProcesarMovGiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesarMovGiro.Location = new System.Drawing.Point(811, 25);
            this.btnProcesarMovGiro.Name = "btnProcesarMovGiro";
            this.btnProcesarMovGiro.Size = new System.Drawing.Size(60, 50);
            this.btnProcesarMovGiro.TabIndex = 130;
            this.btnProcesarMovGiro.Text = "&Procesar";
            this.btnProcesarMovGiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesarMovGiro.UseVisualStyleBackColor = true;
            this.btnProcesarMovGiro.Click += new System.EventHandler(this.btnProcesarMovGiro_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(17, 30);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(41, 13);
            this.lblBase8.TabIndex = 129;
            this.lblBase8.Text = "Zona:";
            // 
            // lblBase7
            // 
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(0, 0);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(100, 23);
            this.lblBase7.TabIndex = 0;
            // 
            // cboEstablecimientoGiro
            // 
            this.cboEstablecimientoGiro.FormattingEnabled = true;
            this.cboEstablecimientoGiro.Location = new System.Drawing.Point(124, 78);
            this.cboEstablecimientoGiro.Name = "cboEstablecimientoGiro";
            this.cboEstablecimientoGiro.Size = new System.Drawing.Size(260, 21);
            this.cboEstablecimientoGiro.TabIndex = 127;
            // 
            // cboAgenciasGiros
            // 
            this.cboAgenciasGiros.FormattingEnabled = true;
            this.cboAgenciasGiros.Location = new System.Drawing.Point(124, 51);
            this.cboAgenciasGiros.Name = "cboAgenciasGiros";
            this.cboAgenciasGiros.Size = new System.Drawing.Size(260, 21);
            this.cboAgenciasGiros.TabIndex = 125;
            // 
            // cboTipoOperacionGiro
            // 
            this.cboTipoOperacionGiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacionGiro.FormattingEnabled = true;
            this.cboTipoOperacionGiro.Location = new System.Drawing.Point(489, 78);
            this.cboTipoOperacionGiro.Name = "cboTipoOperacionGiro";
            this.cboTipoOperacionGiro.Size = new System.Drawing.Size(260, 21);
            this.cboTipoOperacionGiro.TabIndex = 124;
            // 
            // cboZonaGiros
            // 
            this.cboZonaGiros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZonaGiros.FormattingEnabled = true;
            this.cboZonaGiros.Location = new System.Drawing.Point(124, 24);
            this.cboZonaGiros.Name = "cboZonaGiros";
            this.cboZonaGiros.Size = new System.Drawing.Size(260, 21);
            this.cboZonaGiros.TabIndex = 121;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(413, 81);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(70, 13);
            this.lblBase6.TabIndex = 120;
            this.lblBase6.Text = "Operacion:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 82);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(101, 13);
            this.lblBase5.TabIndex = 119;
            this.lblBase5.Text = "Establecimiento:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(17, 54);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 118;
            this.lblBase4.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(0, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(100, 23);
            this.lblBase3.TabIndex = 128;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgMovimientosLista);
            this.grbBase2.Location = new System.Drawing.Point(12, 135);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(1181, 263);
            this.grbBase2.TabIndex = 117;
            this.grbBase2.TabStop = false;
            // 
            // dtgMovimientosLista
            // 
            this.dtgMovimientosLista.AllowUserToAddRows = false;
            this.dtgMovimientosLista.AllowUserToDeleteRows = false;
            this.dtgMovimientosLista.AllowUserToResizeColumns = false;
            this.dtgMovimientosLista.AllowUserToResizeRows = false;
            this.dtgMovimientosLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMovimientosLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMovimientosLista.Location = new System.Drawing.Point(6, 15);
            this.dtgMovimientosLista.MultiSelect = false;
            this.dtgMovimientosLista.Name = "dtgMovimientosLista";
            this.dtgMovimientosLista.ReadOnly = true;
            this.dtgMovimientosLista.RowHeadersVisible = false;
            this.dtgMovimientosLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMovimientosLista.Size = new System.Drawing.Size(1169, 242);
            this.dtgMovimientosLista.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(1127, 428);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 118;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(101, 407);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(88, 13);
            this.lblBase9.TabIndex = 120;
            this.lblBase9.Text = "Envío de giros";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(101, 425);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(85, 13);
            this.lblBase10.TabIndex = 121;
            this.lblBase10.Text = "Pago de giros";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(101, 444);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(114, 13);
            this.lblBase11.TabIndex = 122;
            this.lblBase11.Text = "Cambio de destino";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(101, 463);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(106, 13);
            this.lblBase12.TabIndex = 123;
            this.lblBase12.Text = "Anulación de giro";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Cyan;
            this.pictureBox1.Location = new System.Drawing.Point(18, 404);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 17);
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(18, 461);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 17);
            this.pictureBox2.TabIndex = 125;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox3.Location = new System.Drawing.Point(18, 442);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(77, 17);
            this.pictureBox3.TabIndex = 126;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Blue;
            this.pictureBox4.Location = new System.Drawing.Point(18, 423);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(77, 17);
            this.pictureBox4.TabIndex = 127;
            this.pictureBox4.TabStop = false;
            // 
            // frmRptReporteGiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 511);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptReporteGiros";
            this.Text = "Reportes de Giros";
            this.Load += new System.EventHandler(this.frmReporteGiros_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimientosLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.dtpCorto dtpFecFin;
        public GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnImprimir btnImprimirMovGiro;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboTipoOperacionGiro cboTipoOperacionGiro;
        private GEN.ControlesBase.cboZona cboZonaGiros;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboAgencias cboAgenciasGiros;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoGiro;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtgBase dtgMovimientosLista;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private GEN.BotonesBase.btnProcesar btnProcesarMovGiro;
    }
}