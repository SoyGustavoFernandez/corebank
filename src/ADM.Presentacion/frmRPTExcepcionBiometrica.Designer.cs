namespace ADM.Presentacion
{
    partial class frmRPTExcepcionBiometrica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPTExcepcionBiometrica));
            this.cboEstablecimiento = new GEN.ControlesBase.cboEstablecimiento(this.components);
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgExcepcionBiometrica = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboEstadoSolicitud = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnDetalleExcepcion = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepcionBiometrica)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(106, 67);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(204, 21);
            this.cboEstablecimiento.TabIndex = 2;
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(106, 19);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(204, 21);
            this.cboZona.TabIndex = 4;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(41, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Zona:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 71);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(101, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Establecimiento:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(399, 19);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(175, 20);
            this.dtpDesde.TabIndex = 8;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(399, 43);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(175, 20);
            this.dtpHasta.TabIndex = 9;
            // 
            // dtgExcepcionBiometrica
            // 
            this.dtgExcepcionBiometrica.AllowUserToAddRows = false;
            this.dtgExcepcionBiometrica.AllowUserToDeleteRows = false;
            this.dtgExcepcionBiometrica.AllowUserToResizeColumns = false;
            this.dtgExcepcionBiometrica.AllowUserToResizeRows = false;
            this.dtgExcepcionBiometrica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExcepcionBiometrica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExcepcionBiometrica.Location = new System.Drawing.Point(10, 15);
            this.dtgExcepcionBiometrica.MultiSelect = false;
            this.dtgExcepcionBiometrica.Name = "dtgExcepcionBiometrica";
            this.dtgExcepcionBiometrica.ReadOnly = true;
            this.dtgExcepcionBiometrica.RowHeadersVisible = false;
            this.dtgExcepcionBiometrica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcepcionBiometrica.Size = new System.Drawing.Size(729, 271);
            this.dtgExcepcionBiometrica.TabIndex = 13;
            this.dtgExcepcionBiometrica.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExcepcionBiometrica_CellContentDoubleClick);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(346, 23);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(48, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Desde:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(346, 47);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(44, 13);
            this.lblBase5.TabIndex = 15;
            this.lblBase5.Text = "Hasta:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.cboEstadoSolicitud);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.cboZona);
            this.grbBase1.Controls.Add(this.cboEstablecimiento);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.btnImprimir);
            this.grbBase1.Controls.Add(this.dtpDesde);
            this.grbBase1.Controls.Add(this.btnConsultar);
            this.grbBase1.Controls.Add(this.dtpHasta);
            this.grbBase1.Location = new System.Drawing.Point(7, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(770, 100);
            this.grbBase1.TabIndex = 16;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Parametros";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(346, 71);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(50, 13);
            this.lblBase6.TabIndex = 18;
            this.lblBase6.Text = "Estado:";
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(399, 67);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(175, 21);
            this.cboEstadoSolicitud.TabIndex = 17;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(106, 43);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(204, 21);
            this.cboAgencia.TabIndex = 16;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(698, 19);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(632, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnDetalleExcepcion);
            this.grbBase2.Controls.Add(this.dtgExcepcionBiometrica);
            this.grbBase2.Location = new System.Drawing.Point(7, 112);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(770, 291);
            this.grbBase2.TabIndex = 17;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Solicitudes de Excepción biométrica";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(710, 409);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.LightPink;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(25, 435);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 12);
            this.pictureBox3.TabIndex = 132;
            this.pictureBox3.TabStop = false;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(46, 435);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(130, 13);
            this.lblBase8.TabIndex = 131;
            this.lblBase8.Text = "Excepción Rechazada";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(25, 421);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 12);
            this.pictureBox2.TabIndex = 130;
            this.pictureBox2.TabStop = false;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(46, 421);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(123, 13);
            this.lblBase7.TabIndex = 129;
            this.lblBase7.Text = "Excepción Aprobada";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(25, 407);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 12);
            this.pictureBox1.TabIndex = 128;
            this.pictureBox1.TabStop = false;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(46, 407);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(123, 13);
            this.lblBase9.TabIndex = 127;
            this.lblBase9.Text = "Excepción Solicitada";
            // 
            // btnDetalleExcepcion
            // 
            this.btnDetalleExcepcion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalleExcepcion.BackgroundImage")));
            this.btnDetalleExcepcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetalleExcepcion.Location = new System.Drawing.Point(742, 15);
            this.btnDetalleExcepcion.Name = "btnDetalleExcepcion";
            this.btnDetalleExcepcion.Size = new System.Drawing.Size(25, 25);
            this.btnDetalleExcepcion.TabIndex = 133;
            this.btnDetalleExcepcion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalleExcepcion.UseVisualStyleBackColor = true;
            this.btnDetalleExcepcion.Click += new System.EventHandler(this.btnDetalleExcepcion_Click);
            // 
            // frmRPTExcepcionBiometrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRPTExcepcionBiometrica";
            this.Text = "Reporte de Solicitud de Excepcion biometrica";
            this.Load += new System.EventHandler(this.frmRPTExcepcionBiometrica_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepcionBiometrica)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboEstablecimiento cboEstablecimiento;
        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpDesde;
        private GEN.ControlesBase.dtpCorto dtpHasta;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgExcepcionBiometrica;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolicitud;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnMiniBusqueda btnDetalleExcepcion;
    }
}