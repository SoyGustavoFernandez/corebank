namespace CAJ.Presentacion
{
    partial class frmRptExtractoBcos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptExtractoBcos));
            this.grbDatosCuenta = new GEN.ControlesBase.grbBase(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.btnBuscarCuenta = new GEN.BotonesBase.btnBusqueda();
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblNumeroCuenta = new GEN.ControlesBase.lblBase();
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnResumen = new GEN.BotonesBase.btnBlanco();
            this.grbDatosCuenta.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosCuenta
            // 
            this.grbDatosCuenta.Controls.Add(this.cboEntidad);
            this.grbDatosCuenta.Controls.Add(this.lblMoneda);
            this.grbDatosCuenta.Controls.Add(this.cboMoneda);
            this.grbDatosCuenta.Controls.Add(this.btnBuscarCuenta);
            this.grbDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblNumeroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblEntidad);
            this.grbDatosCuenta.Location = new System.Drawing.Point(12, 12);
            this.grbDatosCuenta.Name = "grbDatosCuenta";
            this.grbDatosCuenta.Size = new System.Drawing.Size(486, 95);
            this.grbDatosCuenta.TabIndex = 3;
            this.grbDatosCuenta.TabStop = false;
            this.grbDatosCuenta.Text = "Datos Cuenta";
            // 
            // cboEntidad
            // 
            this.cboEntidad.Enabled = false;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(112, 15);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(273, 21);
            this.cboEntidad.TabIndex = 11;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(18, 67);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 7;
            this.lblMoneda.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(112, 64);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.BackgroundImage")));
            this.btnBuscarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(411, 15);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarCuenta.TabIndex = 5;
            this.btnBuscarCuenta.Text = "&Buscar";
            this.btnBuscarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(112, 40);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(273, 20);
            this.txtNroCuenta.TabIndex = 4;
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumeroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(18, 43);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblNumeroCuenta.TabIndex = 2;
            this.lblNumeroCuenta.Text = "Nro. Cuenta:";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(18, 18);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 1;
            this.lblEntidad.Text = "Entidad:";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(371, 15);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFecFin.TabIndex = 106;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(290, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(75, 13);
            this.lblBase7.TabIndex = 107;
            this.lblBase7.Text = "Fecha Final:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(112, 15);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(100, 20);
            this.dtpFecIni.TabIndex = 104;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(18, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(83, 13);
            this.lblBase8.TabIndex = 105;
            this.lblBase8.Text = "Fecha Inicial:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Controls.Add(this.dtpFecIni);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.dtpFecFin);
            this.grbBase3.Location = new System.Drawing.Point(12, 109);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(486, 42);
            this.grbBase3.TabIndex = 108;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Rango Fechas";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(423, 150);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 110;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(287, 150);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 109;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnResumen
            // 
            this.btnResumen.BackgroundImage = global::CAJ.Presentacion.Properties.Resources.btnPrint;
            this.btnResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResumen.Location = new System.Drawing.Point(355, 150);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(60, 50);
            this.btnResumen.TabIndex = 111;
            this.btnResumen.Text = "&Resumen";
            this.btnResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // frmRptExtractoBcos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 239);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbDatosCuenta);
            this.Name = "frmRptExtractoBcos";
            this.Text = "Reporte Extracto Bancos";
            this.Load += new System.EventHandler(this.frmRptExtractoBcos_Load);
            this.Controls.SetChildIndex(this.grbDatosCuenta, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnResumen, 0);
            this.grbDatosCuenta.ResumeLayout(false);
            this.grbDatosCuenta.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosCuenta;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.BotonesBase.btnBusqueda btnBuscarCuenta;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.lblBase lblNumeroCuenta;
        private GEN.ControlesBase.lblBase lblEntidad;
        public GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase7;
        public GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnBlanco btnResumen;
    }
}