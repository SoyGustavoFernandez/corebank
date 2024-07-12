using System.Windows.Forms;

namespace CRE.Presentacion
{
    partial class frmCastCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCastCred));
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabSalFec = new System.Windows.Forms.TabPage();
            this.grbOtros = new GEN.ControlesBase.grbBase(this.components);
            this.txtTasaInteres = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtEstadoCredito = new GEN.ControlesBase.txtBase(this.components);
            this.txtTasaMoratoria = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDiasAtraso = new GEN.ControlesBase.txtBase(this.components);
            this.grbDetallesCredito = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtSaldoIntComp = new GEN.ControlesBase.txtBase(this.components);
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
            this.tabDefCred = new System.Windows.Forms.TabPage();
            this.lblBase20 = new GEN.ControlesBase.lblBase();
            this.cboSubProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboSubTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase31 = new GEN.ControlesBase.lblBase();
            this.cboFuenteRecurso = new GEN.ControlesBase.cboFuenteRecurso(this.components);
            this.nudCuotas = new GEN.ControlesBase.nudBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase18 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgCtasCast = new GEN.ControlesBase.dtgBase(this.components);
            this.chcCastigar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonSalCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase19 = new GEN.ControlesBase.lblBase();
            this.nudAtrasoMax = new GEN.ControlesBase.nudBase(this.components);
            this.nudAtrasoIni = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.tbcBase1.SuspendLayout();
            this.tabSalFec.SuspendLayout();
            this.grbOtros.SuspendLayout();
            this.grbDetallesCredito.SuspendLayout();
            this.tabDefCred.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasCast)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtrasoMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtrasoIni)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabSalFec);
            this.tbcBase1.Controls.Add(this.tabDefCred);
            this.tbcBase1.Location = new System.Drawing.Point(12, 292);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(581, 221);
            this.tbcBase1.TabIndex = 3;
            // 
            // tabSalFec
            // 
            this.tabSalFec.Controls.Add(this.grbOtros);
            this.tabSalFec.Controls.Add(this.grbDetallesCredito);
            this.tabSalFec.Location = new System.Drawing.Point(4, 22);
            this.tabSalFec.Name = "tabSalFec";
            this.tabSalFec.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalFec.Size = new System.Drawing.Size(573, 195);
            this.tabSalFec.TabIndex = 0;
            this.tabSalFec.Text = "Saldos a la Fecha";
            this.tabSalFec.UseVisualStyleBackColor = true;
            // 
            // grbOtros
            // 
            this.grbOtros.Controls.Add(this.txtTasaInteres);
            this.grbOtros.Controls.Add(this.lblBase3);
            this.grbOtros.Controls.Add(this.lblBase10);
            this.grbOtros.Controls.Add(this.txtEstadoCredito);
            this.grbOtros.Controls.Add(this.txtTasaMoratoria);
            this.grbOtros.Controls.Add(this.lblBase4);
            this.grbOtros.Controls.Add(this.lblBase12);
            this.grbOtros.Controls.Add(this.txtDiasAtraso);
            this.grbOtros.Enabled = false;
            this.grbOtros.Location = new System.Drawing.Point(299, 7);
            this.grbOtros.Name = "grbOtros";
            this.grbOtros.Size = new System.Drawing.Size(268, 182);
            this.grbOtros.TabIndex = 30;
            this.grbOtros.TabStop = false;
            this.grbOtros.Text = "Otros";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Location = new System.Drawing.Point(102, 38);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.ReadOnly = true;
            this.txtTasaInteres.Size = new System.Drawing.Size(129, 20);
            this.txtTasaInteres.TabIndex = 19;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 127);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(91, 13);
            this.lblBase3.TabIndex = 26;
            this.lblBase3.Text = "Estado Crédito";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(9, 41);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(78, 13);
            this.lblBase10.TabIndex = 20;
            this.lblBase10.Text = "Tasa Interés";
            // 
            // txtEstadoCredito
            // 
            this.txtEstadoCredito.Location = new System.Drawing.Point(102, 124);
            this.txtEstadoCredito.Name = "txtEstadoCredito";
            this.txtEstadoCredito.ReadOnly = true;
            this.txtEstadoCredito.Size = new System.Drawing.Size(129, 20);
            this.txtEstadoCredito.TabIndex = 25;
            // 
            // txtTasaMoratoria
            // 
            this.txtTasaMoratoria.Location = new System.Drawing.Point(102, 66);
            this.txtTasaMoratoria.Name = "txtTasaMoratoria";
            this.txtTasaMoratoria.ReadOnly = true;
            this.txtTasaMoratoria.Size = new System.Drawing.Size(129, 20);
            this.txtTasaMoratoria.TabIndex = 21;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 69);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(91, 13);
            this.lblBase4.TabIndex = 22;
            this.lblBase4.Text = "Tasa Moratoria";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 98);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(91, 13);
            this.lblBase12.TabIndex = 24;
            this.lblBase12.Text = "Días de Atraso";
            // 
            // txtDiasAtraso
            // 
            this.txtDiasAtraso.Location = new System.Drawing.Point(102, 95);
            this.txtDiasAtraso.Name = "txtDiasAtraso";
            this.txtDiasAtraso.ReadOnly = true;
            this.txtDiasAtraso.Size = new System.Drawing.Size(129, 20);
            this.txtDiasAtraso.TabIndex = 23;
            // 
            // grbDetallesCredito
            // 
            this.grbDetallesCredito.Controls.Add(this.lblBase2);
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
            this.grbDetallesCredito.Location = new System.Drawing.Point(15, 6);
            this.grbDetallesCredito.Name = "grbDetallesCredito";
            this.grbDetallesCredito.Size = new System.Drawing.Size(278, 182);
            this.grbDetallesCredito.TabIndex = 29;
            this.grbDetallesCredito.TabStop = false;
            this.grbDetallesCredito.Text = "Detalles de Crédito";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 74);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 26;
            this.lblBase2.Text = "Saldo Int. Comp.";
            // 
            // txtSaldoIntComp
            // 
            this.txtSaldoIntComp.Location = new System.Drawing.Point(135, 70);
            this.txtSaldoIntComp.Name = "txtSaldoIntComp";
            this.txtSaldoIntComp.ReadOnly = true;
            this.txtSaldoIntComp.Size = new System.Drawing.Size(137, 20);
            this.txtSaldoIntComp.TabIndex = 25;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(8, 128);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(74, 13);
            this.lblBase9.TabIndex = 24;
            this.lblBase9.Text = "Saldo Otros";
            // 
            // txtSaldoOtros
            // 
            this.txtSaldoOtros.Location = new System.Drawing.Point(135, 124);
            this.txtSaldoOtros.Name = "txtSaldoOtros";
            this.txtSaldoOtros.ReadOnly = true;
            this.txtSaldoOtros.Size = new System.Drawing.Size(137, 20);
            this.txtSaldoOtros.TabIndex = 23;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(8, 101);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(71, 13);
            this.lblBase8.TabIndex = 22;
            this.lblBase8.Text = "Saldo Mora";
            // 
            // txtSaldoMora
            // 
            this.txtSaldoMora.Location = new System.Drawing.Point(135, 97);
            this.txtSaldoMora.Name = "txtSaldoMora";
            this.txtSaldoMora.ReadOnly = true;
            this.txtSaldoMora.Size = new System.Drawing.Size(137, 20);
            this.txtSaldoMora.TabIndex = 21;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(8, 47);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(84, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Saldo Interés";
            // 
            // txtSaldoInteres
            // 
            this.txtSaldoInteres.Location = new System.Drawing.Point(135, 43);
            this.txtSaldoInteres.Name = "txtSaldoInteres";
            this.txtSaldoInteres.ReadOnly = true;
            this.txtSaldoInteres.Size = new System.Drawing.Size(137, 20);
            this.txtSaldoInteres.TabIndex = 19;
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.Location = new System.Drawing.Point(135, 151);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.ReadOnly = true;
            this.txtTotalDeuda.Size = new System.Drawing.Size(137, 20);
            this.txtTotalDeuda.TabIndex = 18;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(8, 155);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(75, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Total Deuda";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(8, 20);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(83, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Saldo Capital";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.Location = new System.Drawing.Point(135, 16);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.ReadOnly = true;
            this.txtSaldoCapital.Size = new System.Drawing.Size(137, 20);
            this.txtSaldoCapital.TabIndex = 0;
            // 
            // tabDefCred
            // 
            this.tabDefCred.Controls.Add(this.lblBase20);
            this.tabDefCred.Controls.Add(this.cboSubProducto);
            this.tabDefCred.Controls.Add(this.lblBase14);
            this.tabDefCred.Controls.Add(this.cboProducto);
            this.tabDefCred.Controls.Add(this.lblBase13);
            this.tabDefCred.Controls.Add(this.cboSubTipoCredito);
            this.tabDefCred.Controls.Add(this.lblBase11);
            this.tabDefCred.Controls.Add(this.cboTipoCredito);
            this.tabDefCred.Controls.Add(this.lblBase31);
            this.tabDefCred.Controls.Add(this.cboFuenteRecurso);
            this.tabDefCred.Controls.Add(this.nudCuotas);
            this.tabDefCred.Controls.Add(this.cboMoneda);
            this.tabDefCred.Controls.Add(this.lblBase18);
            this.tabDefCred.Controls.Add(this.lblBase16);
            this.tabDefCred.Location = new System.Drawing.Point(4, 22);
            this.tabDefCred.Name = "tabDefCred";
            this.tabDefCred.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefCred.Size = new System.Drawing.Size(573, 195);
            this.tabDefCred.TabIndex = 1;
            this.tabDefCred.Text = "Definición de Crédito";
            this.tabDefCred.UseVisualStyleBackColor = true;
            // 
            // lblBase20
            // 
            this.lblBase20.AutoSize = true;
            this.lblBase20.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase20.ForeColor = System.Drawing.Color.Navy;
            this.lblBase20.Location = new System.Drawing.Point(22, 90);
            this.lblBase20.Name = "lblBase20";
            this.lblBase20.Size = new System.Drawing.Size(88, 13);
            this.lblBase20.TabIndex = 91;
            this.lblBase20.Text = "Sub Producto:";
            // 
            // cboSubProducto
            // 
            this.cboSubProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProducto.Enabled = false;
            this.cboSubProducto.FormattingEnabled = true;
            this.cboSubProducto.Location = new System.Drawing.Point(127, 87);
            this.cboSubProducto.Name = "cboSubProducto";
            this.cboSubProducto.Size = new System.Drawing.Size(353, 21);
            this.cboSubProducto.TabIndex = 87;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(22, 66);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(62, 13);
            this.lblBase14.TabIndex = 90;
            this.lblBase14.Text = "Producto:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Enabled = false;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(127, 63);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(353, 21);
            this.cboProducto.TabIndex = 86;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(22, 42);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(62, 13);
            this.lblBase13.TabIndex = 89;
            this.lblBase13.Text = "Sub Tipo:";
            // 
            // cboSubTipoCredito
            // 
            this.cboSubTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoCredito.Enabled = false;
            this.cboSubTipoCredito.FormattingEnabled = true;
            this.cboSubTipoCredito.Location = new System.Drawing.Point(127, 39);
            this.cboSubTipoCredito.Name = "cboSubTipoCredito";
            this.cboSubTipoCredito.Size = new System.Drawing.Size(353, 21);
            this.cboSubTipoCredito.TabIndex = 85;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(22, 18);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(82, 13);
            this.lblBase11.TabIndex = 88;
            this.lblBase11.Text = "Tipo Crédito:";
            // 
            // cboTipoCredito
            // 
            this.cboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCredito.Enabled = false;
            this.cboTipoCredito.FormattingEnabled = true;
            this.cboTipoCredito.Location = new System.Drawing.Point(127, 15);
            this.cboTipoCredito.Name = "cboTipoCredito";
            this.cboTipoCredito.Size = new System.Drawing.Size(353, 21);
            this.cboTipoCredito.TabIndex = 84;
            // 
            // lblBase31
            // 
            this.lblBase31.AutoSize = true;
            this.lblBase31.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase31.ForeColor = System.Drawing.Color.Navy;
            this.lblBase31.Location = new System.Drawing.Point(22, 161);
            this.lblBase31.Name = "lblBase31";
            this.lblBase31.Size = new System.Drawing.Size(100, 13);
            this.lblBase31.TabIndex = 83;
            this.lblBase31.Text = "Fuente Recurso:";
            // 
            // cboFuenteRecurso
            // 
            this.cboFuenteRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuenteRecurso.Enabled = false;
            this.cboFuenteRecurso.FormattingEnabled = true;
            this.cboFuenteRecurso.Location = new System.Drawing.Point(127, 158);
            this.cboFuenteRecurso.Name = "cboFuenteRecurso";
            this.cboFuenteRecurso.Size = new System.Drawing.Size(193, 21);
            this.cboFuenteRecurso.TabIndex = 82;
            // 
            // nudCuotas
            // 
            this.nudCuotas.Enabled = false;
            this.nudCuotas.Location = new System.Drawing.Point(127, 135);
            this.nudCuotas.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCuotas.Name = "nudCuotas";
            this.nudCuotas.ReadOnly = true;
            this.nudCuotas.Size = new System.Drawing.Size(67, 20);
            this.nudCuotas.TabIndex = 22;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(127, 111);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(193, 21);
            this.cboMoneda.TabIndex = 21;
            // 
            // lblBase18
            // 
            this.lblBase18.AutoSize = true;
            this.lblBase18.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase18.ForeColor = System.Drawing.Color.Navy;
            this.lblBase18.Location = new System.Drawing.Point(22, 137);
            this.lblBase18.Name = "lblBase18";
            this.lblBase18.Size = new System.Drawing.Size(80, 13);
            this.lblBase18.TabIndex = 24;
            this.lblBase18.Text = "Nro. Cuotas:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(22, 114);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(56, 13);
            this.lblBase16.TabIndex = 23;
            this.lblBase16.Text = "Moneda:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(527, 519);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(464, 519);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(401, 519);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgCtasCast
            // 
            this.dtgCtasCast.AllowUserToAddRows = false;
            this.dtgCtasCast.AllowUserToDeleteRows = false;
            this.dtgCtasCast.AllowUserToResizeColumns = false;
            this.dtgCtasCast.AllowUserToResizeRows = false;
            this.dtgCtasCast.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCtasCast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCtasCast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chcCastigar,
            this.idCuenta,
            this.cNombre,
            this.cNroCuenta,
            this.cNombreAge,
            this.nMonSalCapital,
            this.nAtraso,
            this.cEstado,
            this.cContable});
            this.dtgCtasCast.Location = new System.Drawing.Point(12, 77);
            this.dtgCtasCast.MultiSelect = false;
            this.dtgCtasCast.Name = "dtgCtasCast";
            this.dtgCtasCast.ReadOnly = true;
            this.dtgCtasCast.RowHeadersVisible = false;
            this.dtgCtasCast.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCtasCast.Size = new System.Drawing.Size(581, 209);
            this.dtgCtasCast.TabIndex = 0;
            this.dtgCtasCast.ReadOnly = false;
            this.dtgCtasCast.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //
            // chcCastigar
            //
            this.chcCastigar.DataPropertyName = "chcCastigar";
            this.chcCastigar.HeaderText = "Castigar?";
            this.chcCastigar.Name = "chcCastigar";
            this.chcCastigar.ReadOnly = false;
            this.chcCastigar.Width = 70;
            //
            // idCuenta
            //
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "idCuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Visible = false;
            //
            // cNombre
            //
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 150;
            //
            // cNroCuenta
            //
            this.cNroCuenta.DataPropertyName = "cNroCuenta";
            this.cNroCuenta.HeaderText = "Nro. Cuenta";
            this.cNroCuenta.Name = "cNroCuenta";
            this.cNroCuenta.ReadOnly = true;
            this.cNroCuenta.Width = 150;
            //
            // cNombreAge
            //
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.HeaderText = "Agencia";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            this.cNombreAge.Width = 130;
            //
            // nMonSalCapital
            //
            this.nMonSalCapital.DataPropertyName = "nMonSalCapital";
            this.nMonSalCapital.HeaderText = "Saldo capital";
            this.nMonSalCapital.Name = "nMonSalCapital";
            this.nMonSalCapital.ReadOnly = true;
            this.nMonSalCapital.Width = 80;
            //
            // nAtraso
            //
            this.nAtraso.DataPropertyName = "nAtraso";
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            this.nAtraso.Width = 60;
            //
            // cEstado
            //
            this.cEstado.DataPropertyName = "cEstado";
            this.cEstado.HeaderText = "Estado";
            this.cEstado.Name = "cEstado";
            this.cEstado.ReadOnly = true;
            this.cEstado.Width = 70;
            //
            // cContable
            //
            this.cContable.DataPropertyName = "cContable";
            this.cContable.HeaderText = "Cond. contable";
            this.cContable.Name = "cContable";
            this.cContable.ReadOnly = true;
            this.cContable.Width = 70;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 61);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(129, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Relación de Cuentas:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniBusq);
            this.grbBase1.Controls.Add(this.lblBase19);
            this.grbBase1.Controls.Add(this.nudAtrasoMax);
            this.grbBase1.Controls.Add(this.nudAtrasoIni);
            this.grbBase1.Controls.Add(this.lblBase17);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.lblBase15);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(581, 46);
            this.grbBase1.TabIndex = 7;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros";
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(539, 12);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 7;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // lblBase19
            // 
            this.lblBase19.AutoSize = true;
            this.lblBase19.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase19.ForeColor = System.Drawing.Color.Navy;
            this.lblBase19.Location = new System.Drawing.Point(444, 21);
            this.lblBase19.Name = "lblBase19";
            this.lblBase19.Size = new System.Drawing.Size(12, 13);
            this.lblBase19.TabIndex = 5;
            this.lblBase19.Text = "-";
            // 
            // nudAtrasoMax
            // 
            this.nudAtrasoMax.Location = new System.Drawing.Point(459, 17);
            this.nudAtrasoMax.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudAtrasoMax.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudAtrasoMax.Name = "nudAtrasoMax";
            this.nudAtrasoMax.Size = new System.Drawing.Size(67, 20);
            this.nudAtrasoMax.TabIndex = 4;
            this.nudAtrasoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAtrasoMax.ThousandsSeparator = true;
            // 
            // nudAtrasoIni
            // 
            this.nudAtrasoIni.Location = new System.Drawing.Point(374, 17);
            this.nudAtrasoIni.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudAtrasoIni.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.nudAtrasoIni.Name = "nudAtrasoIni";
            this.nudAtrasoIni.Size = new System.Drawing.Size(67, 20);
            this.nudAtrasoIni.TabIndex = 3;
            this.nudAtrasoIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAtrasoIni.ThousandsSeparator = true;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(321, 21);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(49, 13);
            this.lblBase17.TabIndex = 2;
            this.lblBase17.Text = "Atraso:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(69, 17);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(238, 21);
            this.cboAgencia.TabIndex = 1;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(6, 21);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(57, 13);
            this.lblBase15.TabIndex = 0;
            this.lblBase15.Text = "Agencia:";
            // 
            // frmCastCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 593);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.dtgCtasCast);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmCastCred";
            this.Text = "Castigo de Créditos";
            this.Load += new System.EventHandler(this.frmCastCred_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgCtasCast, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.tbcBase1.ResumeLayout(false);
            this.tabSalFec.ResumeLayout(false);
            this.grbOtros.ResumeLayout(false);
            this.grbOtros.PerformLayout();
            this.grbDetallesCredito.ResumeLayout(false);
            this.grbDetallesCredito.PerformLayout();
            this.tabDefCred.ResumeLayout(false);
            this.tabDefCred.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasCast)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtrasoMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAtrasoIni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabSalFec;
        private System.Windows.Forms.TabPage tabDefCred;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgCtasCast;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.nudBase nudCuotas;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase18;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase20;
        private GEN.ControlesBase.cboProducto cboSubProducto;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboProducto cboSubTipoCredito;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.cboProducto cboTipoCredito;
        private GEN.ControlesBase.lblBase lblBase31;
        private GEN.ControlesBase.cboFuenteRecurso cboFuenteRecurso;
        private GEN.ControlesBase.grbBase grbOtros;
        private GEN.ControlesBase.txtBase txtTasaInteres;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtEstadoCredito;
        private GEN.ControlesBase.txtBase txtTasaMoratoria;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtDiasAtraso;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn chcCastigar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonSalCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContable;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtSaldoIntComp;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.ControlesBase.lblBase lblBase19;
        private GEN.ControlesBase.nudBase nudAtrasoMax;
        private GEN.ControlesBase.nudBase nudAtrasoIni;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase15;
    }
}