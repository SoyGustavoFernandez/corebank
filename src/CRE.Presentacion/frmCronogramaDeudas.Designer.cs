namespace CRE.Presentacion
{
    partial class frmCronogramaDeudas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCronogramaDeudas));
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dtgCronograma = new System.Windows.Forms.DataGridView();
            this.txtCuota = new GEN.ControlesBase.nudBase(this.components);
            this.cboTipoFrecuencia = new GEN.ControlesBase.cboBase(this.components);
            this.lblBaseCustom8 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom11 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.bindingCronograma = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.txtCuotasPend = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtSaldoActual = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMontoPrestado = new GEN.ControlesBase.txtBase(this.components);
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.cboFechaInicio = new GEN.ControlesBase.cboBase(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.label3 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCronograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCronograma)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(302, 13);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 308);
            this.panel11.TabIndex = 100;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(198, 306);
            this.panel12.TabIndex = 25;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.dtgCronograma);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 24);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(198, 282);
            this.panel13.TabIndex = 25;
            // 
            // dtgCronograma
            // 
            this.dtgCronograma.AllowUserToAddRows = false;
            this.dtgCronograma.AllowUserToDeleteRows = false;
            this.dtgCronograma.AllowUserToResizeColumns = false;
            this.dtgCronograma.AllowUserToResizeRows = false;
            this.dtgCronograma.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCronograma.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgCronograma.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgCronograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCronograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCronograma.Location = new System.Drawing.Point(0, 0);
            this.dtgCronograma.MultiSelect = false;
            this.dtgCronograma.Name = "dtgCronograma";
            this.dtgCronograma.RowHeadersVisible = false;
            this.dtgCronograma.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgCronograma.Size = new System.Drawing.Size(198, 282);
            this.dtgCronograma.TabIndex = 10;
            this.dtgCronograma.TabStop = false;
            // 
            // txtCuota
            // 
            this.txtCuota.DecimalPlaces = 2;
            this.txtCuota.Location = new System.Drawing.Point(124, 117);
            this.txtCuota.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.Size = new System.Drawing.Size(112, 20);
            this.txtCuota.TabIndex = 4;
            this.txtCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuota.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCuota_KeyUp);
            this.txtCuota.Validating += new System.ComponentModel.CancelEventHandler(this.txtCuota_Validating);
            // 
            // cboTipoFrecuencia
            // 
            this.cboTipoFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFrecuencia.FormattingEnabled = true;
            this.cboTipoFrecuencia.Location = new System.Drawing.Point(124, 94);
            this.cboTipoFrecuencia.Name = "cboTipoFrecuencia";
            this.cboTipoFrecuencia.Size = new System.Drawing.Size(148, 21);
            this.cboTipoFrecuencia.TabIndex = 2;
            // 
            // lblBaseCustom8
            // 
            this.lblBaseCustom8.AutoSize = true;
            this.lblBaseCustom8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom8.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom8.Location = new System.Drawing.Point(22, 97);
            this.lblBaseCustom8.Name = "lblBaseCustom8";
            this.lblBaseCustom8.Size = new System.Drawing.Size(100, 13);
            this.lblBaseCustom8.TabIndex = 136;
            this.lblBaseCustom8.Text = "Frecuencia Pago";
            // 
            // lblBaseCustom11
            // 
            this.lblBaseCustom11.AutoSize = true;
            this.lblBaseCustom11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom11.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom11.Location = new System.Drawing.Point(81, 119);
            this.lblBaseCustom11.Name = "lblBaseCustom11";
            this.lblBaseCustom11.Size = new System.Drawing.Size(41, 13);
            this.lblBaseCustom11.TabIndex = 135;
            this.lblBaseCustom11.Text = "Cuota";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(136, 271);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 134;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCuotasPend
            // 
            this.txtCuotasPend.Enabled = false;
            this.txtCuotasPend.Location = new System.Drawing.Point(124, 72);
            this.txtCuotasPend.Name = "txtCuotasPend";
            this.txtCuotasPend.Size = new System.Drawing.Size(51, 20);
            this.txtCuotasPend.TabIndex = 135;
            this.txtCuotasPend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 75);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(113, 13);
            this.lblBase1.TabIndex = 136;
            this.lblBase1.Text = "Cuotas Pendientes";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtSaldoActual);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtMontoPrestado);
            this.grbBase1.Controls.Add(this.btnGenerar);
            this.grbBase1.Controls.Add(this.cboFechaInicio);
            this.grbBase1.Controls.Add(this.txtCuota);
            this.grbBase1.Controls.Add(this.lblBaseCustom1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtCuotasPend);
            this.grbBase1.Controls.Add(this.lblBaseCustom11);
            this.grbBase1.Controls.Add(this.cboTipoFrecuencia);
            this.grbBase1.Controls.Add(this.lblBaseCustom8);
            this.grbBase1.Location = new System.Drawing.Point(12, 13);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(284, 225);
            this.grbBase1.TabIndex = 137;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos para Generar Cronograma";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(44, 53);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 143;
            this.lblBase3.Text = "Saldo Actual";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Enabled = false;
            this.txtSaldoActual.Location = new System.Drawing.Point(124, 50);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.Size = new System.Drawing.Size(112, 20);
            this.txtSaldoActual.TabIndex = 142;
            this.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(27, 31);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(95, 13);
            this.lblBase2.TabIndex = 141;
            this.lblBase2.Text = "Monto Prestado";
            // 
            // txtMontoPrestado
            // 
            this.txtMontoPrestado.Enabled = false;
            this.txtMontoPrestado.Location = new System.Drawing.Point(124, 28);
            this.txtMontoPrestado.Name = "txtMontoPrestado";
            this.txtMontoPrestado.Size = new System.Drawing.Size(112, 20);
            this.txtMontoPrestado.TabIndex = 140;
            this.txtMontoPrestado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(124, 166);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 139;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cboFechaInicio
            // 
            this.cboFechaInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFechaInicio.FormattingEnabled = true;
            this.cboFechaInicio.Location = new System.Drawing.Point(124, 139);
            this.cboFechaInicio.Name = "cboFechaInicio";
            this.cboFechaInicio.Size = new System.Drawing.Size(112, 21);
            this.cboFechaInicio.TabIndex = 137;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(47, 142);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(75, 13);
            this.lblBaseCustom1.TabIndex = 138;
            this.lblBaseCustom1.Text = "Fecha Inicio";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(199, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 138;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 24);
            this.label3.TabIndex = 100;
            this.label3.Text = "Cronograma Pagos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label3);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(198, 24);
            this.panel14.TabIndex = 9;
            // 
            // frmCronogramaDeudas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(511, 356);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmCronogramaDeudas";
            this.ShowInTaskbar = false;
            this.Text = "Generador de Cronograma de Pagos";
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.panel11, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCronograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCronograma)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.DataGridView dtgCronograma;
        private GEN.ControlesBase.nudBase txtCuota;
        private GEN.ControlesBase.cboBase cboTipoFrecuencia;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom8;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom11;
        private System.Windows.Forms.BindingSource bindingCronograma;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.txtBase txtCuotasPend;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboBase cboFechaInicio;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtSaldoActual;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMontoPrestado;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label3;
    }
}