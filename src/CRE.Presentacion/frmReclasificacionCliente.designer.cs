namespace CRE.Presentacion
{
    partial class frmReclasificacionCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReclasificacionCliente));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboCalifIni = new GEN.ControlesBase.cboCalificacion(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.lblCalifica = new GEN.ControlesBase.lblBase();
            this.cboCalifFin = new GEN.ControlesBase.cboCalificacion(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecReclasif = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboMotReclasifCli = new GEN.ControlesBase.cboMotReclasifCli(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboCalifAlineamiento = new GEN.ControlesBase.cboCalificacion(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblCalifica2 = new GEN.ControlesBase.lblBase();
            this.btnProcesarProviciones = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCli.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 6;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(453, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(385, 382);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(513, 382);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboCalifIni
            // 
            this.cboCalifIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalifIni.Enabled = false;
            this.cboCalifIni.FormattingEnabled = true;
            this.cboCalifIni.Location = new System.Drawing.Point(22, 81);
            this.cboCalifIni.Name = "cboCalifIni";
            this.cboCalifIni.Size = new System.Drawing.Size(177, 21);
            this.cboCalifIni.TabIndex = 9;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(326, 382);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblCalifica
            // 
            this.lblCalifica.AutoSize = true;
            this.lblCalifica.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCalifica.ForeColor = System.Drawing.Color.Navy;
            this.lblCalifica.Location = new System.Drawing.Point(22, 64);
            this.lblCalifica.Name = "lblCalifica";
            this.lblCalifica.Size = new System.Drawing.Size(177, 13);
            this.lblCalifica.TabIndex = 11;
            this.lblCalifica.Text = "Calificación actual del cliente:";
            // 
            // cboCalifFin
            // 
            this.cboCalifFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalifFin.FormattingEnabled = true;
            this.cboCalifFin.Location = new System.Drawing.Point(281, 81);
            this.cboCalifFin.Name = "cboCalifFin";
            this.cboCalifFin.Size = new System.Drawing.Size(177, 21);
            this.cboCalifFin.TabIndex = 12;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(22, 156);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(62, 13);
            this.lblBase1.TabIndex = 14;
            this.lblBase1.Text = "Sustento:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Location = new System.Drawing.Point(22, 172);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(529, 71);
            this.txtObservacion.TabIndex = 15;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(22, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(107, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "F. Reclasificacion:";
            // 
            // dtpFecReclasif
            // 
            this.dtpFecReclasif.Enabled = false;
            this.dtpFecReclasif.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecReclasif.Location = new System.Drawing.Point(22, 34);
            this.dtpFecReclasif.Name = "dtpFecReclasif";
            this.dtpFecReclasif.Size = new System.Drawing.Size(116, 20);
            this.dtpFecReclasif.TabIndex = 17;
            this.dtpFecReclasif.ValueChanged += new System.EventHandler(this.dtpFecReclasif_ValueChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(22, 110);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 18;
            this.lblBase3.Text = "Motivo:";
            // 
            // cboMotReclasifCli
            // 
            this.cboMotReclasifCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotReclasifCli.FormattingEnabled = true;
            this.cboMotReclasifCli.Location = new System.Drawing.Point(22, 127);
            this.cboMotReclasifCli.Name = "cboMotReclasifCli";
            this.cboMotReclasifCli.Size = new System.Drawing.Size(177, 21);
            this.cboMotReclasifCli.TabIndex = 19;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboCalifAlineamiento);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblCalifica2);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboMotReclasifCli);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpFecReclasif);
            this.grbBase1.Controls.Add(this.cboCalifIni);
            this.grbBase1.Controls.Add(this.txtObservacion);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblCalifica);
            this.grbBase1.Controls.Add(this.cboCalifFin);
            this.grbBase1.Location = new System.Drawing.Point(12, 120);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(561, 256);
            this.grbBase1.TabIndex = 20;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos reclasificación";
            // 
            // cboCalifAlineamiento
            // 
            this.cboCalifAlineamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalifAlineamiento.Enabled = false;
            this.cboCalifAlineamiento.FormattingEnabled = true;
            this.cboCalifAlineamiento.Location = new System.Drawing.Point(281, 34);
            this.cboCalifAlineamiento.Name = "cboCalifAlineamiento";
            this.cboCalifAlineamiento.Size = new System.Drawing.Size(177, 21);
            this.cboCalifAlineamiento.TabIndex = 20;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(281, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(154, 13);
            this.lblBase4.TabIndex = 21;
            this.lblBase4.Text = "Calificación alineamiento:";
            // 
            // lblCalifica2
            // 
            this.lblCalifica2.AutoSize = true;
            this.lblCalifica2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCalifica2.ForeColor = System.Drawing.Color.Navy;
            this.lblCalifica2.Location = new System.Drawing.Point(281, 64);
            this.lblCalifica2.Name = "lblCalifica2";
            this.lblCalifica2.Size = new System.Drawing.Size(138, 13);
            this.lblCalifica2.TabIndex = 13;
            this.lblCalifica2.Text = "Cambiar calificación a:";
            // 
            // btnProcesarProviciones
            // 
            this.btnProcesarProviciones.Location = new System.Drawing.Point(34, 382);
            this.btnProcesarProviciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProcesarProviciones.Name = "btnProcesarProviciones";
            this.btnProcesarProviciones.Size = new System.Drawing.Size(74, 41);
            this.btnProcesarProviciones.TabIndex = 21;
            this.btnProcesarProviciones.Text = "Procesar Provisiones";
            this.btnProcesarProviciones.UseVisualStyleBackColor = true;
            this.btnProcesarProviciones.Click += new System.EventHandler(this.btnProcesarProviciones_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(112, 382);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(68, 41);
            this.btnExportar.TabIndex = 22;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(184, 382);
            this.btnExporExcel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 23;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // frmReclasificacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 465);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnProcesarProviciones);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReclasificacionCliente";
            this.Text = "Reclasificación Cliente";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesarProviciones, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.cboCalificacion cboCalifIni;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.lblBase lblCalifica;
        private GEN.ControlesBase.cboCalificacion cboCalifFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtObservacion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecReclasif;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboMotReclasifCli cboMotReclasifCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblCalifica2;
        private GEN.ControlesBase.cboCalificacion cboCalifAlineamiento;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.Button btnProcesarProviciones;
        private System.Windows.Forms.Button btnExportar;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
    }
}

