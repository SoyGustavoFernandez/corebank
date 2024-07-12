namespace CRE.Presentacion
{
    partial class frmRegistroSolCapturaCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroSolCapturaCre));
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgCuentas = new GEN.ControlesBase.dtgBase(this.components);
            this.txtJustificacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblJustificacion = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbDetallesCredito = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtSaldoOtros = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtSaldoMora = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtSaldoInteres = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotalDeuda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtSaldoCapital = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtTasaInteres = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtTasaMoratoria = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDiasAtraso = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtEstadoCredito = new GEN.ControlesBase.txtBase(this.components);
            this.grbOtros = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.txtTotalSaldoCapital = new GEN.ControlesBase.txtBase(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSaldoIntComp = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentas)).BeginInit();
            this.grbDetallesCredito.SuspendLayout();
            this.grbOtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(364, 470);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(490, 470);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(427, 470);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgCuentas
            // 
            this.dtgCuentas.AllowUserToAddRows = false;
            this.dtgCuentas.AllowUserToDeleteRows = false;
            this.dtgCuentas.AllowUserToResizeColumns = false;
            this.dtgCuentas.AllowUserToResizeRows = false;
            this.dtgCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentas.Location = new System.Drawing.Point(18, 121);
            this.dtgCuentas.MultiSelect = false;
            this.dtgCuentas.Name = "dtgCuentas";
            this.dtgCuentas.ReadOnly = true;
            this.dtgCuentas.RowHeadersVisible = false;
            this.dtgCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentas.Size = new System.Drawing.Size(532, 142);
            this.dtgCuentas.TabIndex = 6;
            this.dtgCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentas_CellClick);
            this.dtgCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentas_CellContentClick);
            this.dtgCuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgCuentas_KeyDown);
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(18, 278);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(532, 49);
            this.txtJustificacion.TabIndex = 1;
            // 
            // lblJustificacion
            // 
            this.lblJustificacion.AutoSize = true;
            this.lblJustificacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblJustificacion.ForeColor = System.Drawing.Color.Navy;
            this.lblJustificacion.Location = new System.Drawing.Point(15, 264);
            this.lblJustificacion.Name = "lblJustificacion";
            this.lblJustificacion.Size = new System.Drawing.Size(80, 13);
            this.lblJustificacion.TabIndex = 8;
            this.lblJustificacion.Text = "Justificación:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 108);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(59, 13);
            this.lblBase4.TabIndex = 10;
            this.lblBase4.Text = "Cuentas:";
            // 
            // grbDetallesCredito
            // 
            this.grbDetallesCredito.Controls.Add(this.lblBase1);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoIntComp);
            this.grbDetallesCredito.Controls.Add(this.lblBase9);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoOtros);
            this.grbDetallesCredito.Controls.Add(this.lblBase8);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoMora);
            this.grbDetallesCredito.Controls.Add(this.lblBase7);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoInteres);
            this.grbDetallesCredito.Controls.Add(this.txtTotalDeuda);
            this.grbDetallesCredito.Controls.Add(this.lblBase6);
            this.grbDetallesCredito.Controls.Add(this.lblBase5);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoCapital);
            this.grbDetallesCredito.Enabled = false;
            this.grbDetallesCredito.Location = new System.Drawing.Point(18, 333);
            this.grbDetallesCredito.Name = "grbDetallesCredito";
            this.grbDetallesCredito.Size = new System.Drawing.Size(270, 147);
            this.grbDetallesCredito.TabIndex = 2;
            this.grbDetallesCredito.TabStop = false;
            this.grbDetallesCredito.Text = "Detalles de Crédito";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(7, 105);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(79, 13);
            this.lblBase9.TabIndex = 24;
            this.lblBase9.Text = "Saldo Otros:";
            // 
            // txtSaldoOtros
            // 
            this.txtSaldoOtros.Location = new System.Drawing.Point(122, 101);
            this.txtSaldoOtros.Name = "txtSaldoOtros";
            this.txtSaldoOtros.Size = new System.Drawing.Size(136, 20);
            this.txtSaldoOtros.TabIndex = 23;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(7, 85);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(76, 13);
            this.lblBase8.TabIndex = 22;
            this.lblBase8.Text = "Saldo Mora:";
            // 
            // txtSaldoMora
            // 
            this.txtSaldoMora.Location = new System.Drawing.Point(122, 81);
            this.txtSaldoMora.Name = "txtSaldoMora";
            this.txtSaldoMora.Size = new System.Drawing.Size(136, 20);
            this.txtSaldoMora.TabIndex = 21;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 45);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(89, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Saldo Interes:";
            // 
            // txtSaldoInteres
            // 
            this.txtSaldoInteres.Location = new System.Drawing.Point(122, 41);
            this.txtSaldoInteres.Name = "txtSaldoInteres";
            this.txtSaldoInteres.Size = new System.Drawing.Size(136, 20);
            this.txtSaldoInteres.TabIndex = 19;
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.Location = new System.Drawing.Point(122, 121);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.Size = new System.Drawing.Size(136, 20);
            this.txtTotalDeuda.TabIndex = 18;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(7, 125);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(80, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Total Deuda:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(7, 25);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(88, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Saldo Capital:";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.Location = new System.Drawing.Point(122, 21);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.Size = new System.Drawing.Size(136, 20);
            this.txtSaldoCapital.TabIndex = 0;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(8, 25);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(83, 13);
            this.lblBase10.TabIndex = 20;
            this.lblBase10.Text = "Tasa Interés:";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Location = new System.Drawing.Point(103, 21);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.Size = new System.Drawing.Size(129, 20);
            this.txtTasaInteres.TabIndex = 19;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(8, 45);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(96, 13);
            this.lblBase11.TabIndex = 22;
            this.lblBase11.Text = "Tasa Moratoria:";
            // 
            // txtTasaMoratoria
            // 
            this.txtTasaMoratoria.Location = new System.Drawing.Point(103, 41);
            this.txtTasaMoratoria.Name = "txtTasaMoratoria";
            this.txtTasaMoratoria.Size = new System.Drawing.Size(129, 20);
            this.txtTasaMoratoria.TabIndex = 21;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(8, 65);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(96, 13);
            this.lblBase12.TabIndex = 24;
            this.lblBase12.Text = "Días de Atraso:";
            // 
            // txtDiasAtraso
            // 
            this.txtDiasAtraso.Location = new System.Drawing.Point(103, 61);
            this.txtDiasAtraso.Name = "txtDiasAtraso";
            this.txtDiasAtraso.Size = new System.Drawing.Size(129, 20);
            this.txtDiasAtraso.TabIndex = 23;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(8, 85);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(96, 13);
            this.lblBase13.TabIndex = 26;
            this.lblBase13.Text = "Estado Crédito:";
            // 
            // txtEstadoCredito
            // 
            this.txtEstadoCredito.Location = new System.Drawing.Point(103, 81);
            this.txtEstadoCredito.Name = "txtEstadoCredito";
            this.txtEstadoCredito.Size = new System.Drawing.Size(129, 20);
            this.txtEstadoCredito.TabIndex = 25;
            // 
            // grbOtros
            // 
            this.grbOtros.Controls.Add(this.txtTasaInteres);
            this.grbOtros.Controls.Add(this.lblBase10);
            this.grbOtros.Controls.Add(this.txtEstadoCredito);
            this.grbOtros.Controls.Add(this.txtTasaMoratoria);
            this.grbOtros.Controls.Add(this.lblBase11);
            this.grbOtros.Controls.Add(this.txtDiasAtraso);
            this.grbOtros.Controls.Add(this.lblBase12);
            this.grbOtros.Controls.Add(this.lblBase13);
            this.grbOtros.Enabled = false;
            this.grbOtros.Location = new System.Drawing.Point(309, 334);
            this.grbOtros.Name = "grbOtros";
            this.grbOtros.Size = new System.Drawing.Size(241, 120);
            this.grbOtros.TabIndex = 27;
            this.grbOtros.TabStop = false;
            this.grbOtros.Text = "Otros";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(20, 503);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(119, 13);
            this.lblBase14.TabIndex = 28;
            this.lblBase14.Text = "Total Saldo Capital:";
            // 
            // txtTotalSaldoCapital
            // 
            this.txtTotalSaldoCapital.Enabled = false;
            this.txtTotalSaldoCapital.Location = new System.Drawing.Point(140, 500);
            this.txtTotalSaldoCapital.Name = "txtTotalSaldoCapital";
            this.txtTotalSaldoCapital.Size = new System.Drawing.Size(136, 20);
            this.txtTotalSaldoCapital.TabIndex = 27;
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(18, 2);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 29;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 65);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(110, 13);
            this.lblBase1.TabIndex = 26;
            this.lblBase1.Text = "Saldo Int. Comp.:";
            // 
            // txtSaldoIntComp
            // 
            this.txtSaldoIntComp.Location = new System.Drawing.Point(122, 61);
            this.txtSaldoIntComp.Name = "txtSaldoIntComp";
            this.txtSaldoIntComp.Size = new System.Drawing.Size(136, 20);
            this.txtSaldoIntComp.TabIndex = 25;
            // 
            // frmRegistroSolCapturaCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 551);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.grbOtros);
            this.Controls.Add(this.txtTotalSaldoCapital);
            this.Controls.Add(this.grbDetallesCredito);
            this.Controls.Add(this.lblJustificacion);
            this.Controls.Add(this.txtJustificacion);
            this.Controls.Add(this.dtgCuentas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase14);
            this.Controls.Add(this.lblBase4);
            this.Name = "frmRegistroSolCapturaCre";
            this.Text = "Registro Solicitud de Captura de Créditos";
            this.Load += new System.EventHandler(this.frmRegistroSolCapturaCre_Load);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase14, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.dtgCuentas, 0);
            this.Controls.SetChildIndex(this.txtJustificacion, 0);
            this.Controls.SetChildIndex(this.lblJustificacion, 0);
            this.Controls.SetChildIndex(this.grbDetallesCredito, 0);
            this.Controls.SetChildIndex(this.txtTotalSaldoCapital, 0);
            this.Controls.SetChildIndex(this.grbOtros, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentas)).EndInit();
            this.grbDetallesCredito.ResumeLayout(false);
            this.grbDetallesCredito.PerformLayout();
            this.grbOtros.ResumeLayout(false);
            this.grbOtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgCuentas;
        private GEN.ControlesBase.txtBase txtJustificacion;
        private GEN.ControlesBase.lblBase lblJustificacion;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbDetallesCredito;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtSaldoOtros;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtSaldoMora;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtSaldoInteres;
        private GEN.ControlesBase.txtBase txtTotalDeuda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtSaldoCapital;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtTasaInteres;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtTasaMoratoria;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtDiasAtraso;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtBase txtEstadoCredito;
        private GEN.ControlesBase.grbBase grbOtros;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.txtBase txtTotalSaldoCapital;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtSaldoIntComp;
    }
}