namespace GRH.Presentacion
{
    partial class frmRptArchivosDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptArchivosDeposito));
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgPlanillas1 = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.cboModalidadPlanilla1 = new GEN.ControlesBase.cboModalidadPlanilla(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboPeriodoPlanilla1 = new GEN.ControlesBase.cboPeriodoPlanilla(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoPlanilla1 = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.cboRelacionLabInst1 = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboCuenta = new GEN.ControlesBase.cboBase(this.components);
            this.lblCuenta = new GEN.ControlesBase.lblBase();
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboCtaCargo = new GEN.ControlesBase.cboBase(this.components);
            this.chcValDoc = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnTeleCredito = new GEN.BotonesBase.btnTeleCredito();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas1)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 125);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(128, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Seleccionar Planillas:";
            // 
            // dtgPlanillas1
            // 
            this.dtgPlanillas1.AllowUserToAddRows = false;
            this.dtgPlanillas1.AllowUserToDeleteRows = false;
            this.dtgPlanillas1.AllowUserToResizeColumns = false;
            this.dtgPlanillas1.AllowUserToResizeRows = false;
            this.dtgPlanillas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanillas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillas1.Location = new System.Drawing.Point(10, 140);
            this.dtgPlanillas1.MultiSelect = false;
            this.dtgPlanillas1.Name = "dtgPlanillas1";
            this.dtgPlanillas1.ReadOnly = true;
            this.dtgPlanillas1.RowHeadersVisible = false;
            this.dtgPlanillas1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillas1.Size = new System.Drawing.Size(430, 90);
            this.dtgPlanillas1.TabIndex = 19;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnProcesar1);
            this.grbBase1.Controls.Add(this.cboModalidadPlanilla1);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboPeriodoPlanilla1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboTipoPlanilla1);
            this.grbBase1.Controls.Add(this.cboRelacionLabInst1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(10, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(429, 115);
            this.grbBase1.TabIndex = 18;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione los Filtros: ";
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(353, 37);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 13;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // cboModalidadPlanilla1
            // 
            this.cboModalidadPlanilla1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadPlanilla1.FormattingEnabled = true;
            this.cboModalidadPlanilla1.Location = new System.Drawing.Point(112, 88);
            this.cboModalidadPlanilla1.Name = "cboModalidadPlanilla1";
            this.cboModalidadPlanilla1.Size = new System.Drawing.Size(230, 21);
            this.cboModalidadPlanilla1.TabIndex = 6;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(10, 69);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(87, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Periodo pago:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Clasificación:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 92);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Modalidad:";
            // 
            // cboPeriodoPlanilla1
            // 
            this.cboPeriodoPlanilla1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoPlanilla1.FormattingEnabled = true;
            this.cboPeriodoPlanilla1.Location = new System.Drawing.Point(112, 65);
            this.cboPeriodoPlanilla1.Name = "cboPeriodoPlanilla1";
            this.cboPeriodoPlanilla1.Size = new System.Drawing.Size(230, 21);
            this.cboPeriodoPlanilla1.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Tipo de Planilla:";
            // 
            // cboTipoPlanilla1
            // 
            this.cboTipoPlanilla1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla1.FormattingEnabled = true;
            this.cboTipoPlanilla1.Location = new System.Drawing.Point(112, 42);
            this.cboTipoPlanilla1.Name = "cboTipoPlanilla1";
            this.cboTipoPlanilla1.Size = new System.Drawing.Size(230, 21);
            this.cboTipoPlanilla1.TabIndex = 7;
            this.cboTipoPlanilla1.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla1_SelectedIndexChanged);
            // 
            // cboRelacionLabInst1
            // 
            this.cboRelacionLabInst1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst1.FormattingEnabled = true;
            this.cboRelacionLabInst1.Location = new System.Drawing.Point(112, 19);
            this.cboRelacionLabInst1.Name = "cboRelacionLabInst1";
            this.cboRelacionLabInst1.Size = new System.Drawing.Size(230, 21);
            this.cboRelacionLabInst1.TabIndex = 8;
            this.cboRelacionLabInst1.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst1_SelectedIndexChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(380, 254);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(317, 254);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 15;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboCuenta);
            this.grbBase2.Controls.Add(this.lblCuenta);
            this.grbBase2.Controls.Add(this.cboEntidad);
            this.grbBase2.Controls.Add(this.cboCtaCargo);
            this.grbBase2.Controls.Add(this.chcValDoc);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.btnTeleCredito);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(10, 237);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(305, 109);
            this.grbBase2.TabIndex = 20;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Seleccione los Filtros: ";
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Location = new System.Drawing.Point(65, 40);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(170, 21);
            this.cboCuenta.TabIndex = 8;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblCuenta.Location = new System.Drawing.Point(5, 44);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(56, 13);
            this.lblCuenta.TabIndex = 120;
            this.lblCuenta.Text = "Nro Cta:";
            // 
            // cboEntidad
            // 
            this.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(65, 17);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(170, 21);
            this.cboEntidad.TabIndex = 7;
            this.cboEntidad.SelectedIndexChanged += new System.EventHandler(this.cboEntidad_SelectedIndexChanged);
            // 
            // cboCtaCargo
            // 
            this.cboCtaCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCtaCargo.FormattingEnabled = true;
            this.cboCtaCargo.Location = new System.Drawing.Point(110, 63);
            this.cboCtaCargo.Name = "cboCtaCargo";
            this.cboCtaCargo.Size = new System.Drawing.Size(125, 21);
            this.cboCtaCargo.TabIndex = 9;
            // 
            // chcValDoc
            // 
            this.chcValDoc.AutoSize = true;
            this.chcValDoc.Font = new System.Drawing.Font("Verdana", 8F);
            this.chcValDoc.ForeColor = System.Drawing.Color.Navy;
            this.chcValDoc.Location = new System.Drawing.Point(7, 90);
            this.chcValDoc.Name = "chcValDoc";
            this.chcValDoc.Size = new System.Drawing.Size(135, 17);
            this.chcValDoc.TabIndex = 10;
            this.chcValDoc.Text = "Validar Documento";
            this.chcValDoc.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(5, 21);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(54, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Entidad:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(5, 67);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(99, 13);
            this.lblBase7.TabIndex = 16;
            this.lblBase7.Text = "Tipo Cta Cargo:";
            // 
            // btnTeleCredito
            // 
            this.btnTeleCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTeleCredito.BackgroundImage")));
            this.btnTeleCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTeleCredito.ForeColor = System.Drawing.Color.Black;
            this.btnTeleCredito.Location = new System.Drawing.Point(239, 17);
            this.btnTeleCredito.Name = "btnTeleCredito";
            this.btnTeleCredito.Size = new System.Drawing.Size(60, 50);
            this.btnTeleCredito.TabIndex = 11;
            this.btnTeleCredito.Text = "&TeleCred";
            this.btnTeleCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTeleCredito.UseVisualStyleBackColor = true;
            this.btnTeleCredito.Click += new System.EventHandler(this.btnTeleCredito_Click);
            // 
            // frmRptArchivosDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 386);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtgPlanillas1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmRptArchivosDeposito";
            this.Text = "Reporte de Archivos de Deposito";
            this.Load += new System.EventHandler(this.frmRptArchivosDeposito_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgPlanillas1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas1)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgPlanillas1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.cboModalidadPlanilla cboModalidadPlanilla1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboPeriodoPlanilla cboPeriodoPlanilla1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla1;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboBase cboCuenta;
        private GEN.ControlesBase.lblBase lblCuenta;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.cboBase cboCtaCargo;
        private GEN.ControlesBase.chcBase chcValDoc;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnTeleCredito btnTeleCredito;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}