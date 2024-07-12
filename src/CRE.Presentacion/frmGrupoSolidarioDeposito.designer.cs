namespace CRE.Presentacion
{
    partial class frmGrupoSolidarioDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolidarioDeposito));
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.txtNumFirmas = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoPersona = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.conDatPerReaOperac = new GEN.ControlesBase.ConDatPerReaOperac();
            this.grbBase7 = new GEN.ControlesBase.grbBase(this.components);
            this.conCalcVuelto = new GEN.ControlesBase.conCalcVuelto();
            this.tabCliente = new System.Windows.Forms.TabPage();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.tabOperacion = new System.Windows.Forms.TabPage();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.conSolesDolar = new GEN.ControlesBase.ConSolesDolar();
            this.txtMontOpe = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnComision = new System.Windows.Forms.Button();
            this.txtRedondeo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.txtMontEnt = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtMontTotal = new GEN.ControlesBase.txtBase(this.components);
            this.txtImpuesto = new GEN.ControlesBase.txtBase(this.components);
            this.txtComision = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoPago = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase21 = new GEN.ControlesBase.lblBase();
            this.lblBase31 = new GEN.ControlesBase.lblBase();
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.tbcDeposito = new GEN.ControlesBase.tbcBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBase2.SuspendLayout();
            this.tabCliente.SuspendLayout();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.tabOperacion.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.tbcDeposito.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(75, 16);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(152, 20);
            this.txtProducto.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 19);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Producto:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(338, 18);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(120, 21);
            this.cboMoneda.TabIndex = 1;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(248, 21);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(56, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Moneda:";
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbBase2.Controls.Add(this.lblBase16);
            this.grbBase2.Controls.Add(this.txtNumFirmas);
            this.grbBase2.Controls.Add(this.cboTipoPersona);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.cboTipoCuenta);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtProducto);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Location = new System.Drawing.Point(3, 36);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(729, 72);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Cuenta:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(248, 48);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(86, 13);
            this.lblBase16.TabIndex = 49;
            this.lblBase16.Text = "Tipo Persona:";
            // 
            // txtNumFirmas
            // 
            this.txtNumFirmas.Enabled = false;
            this.txtNumFirmas.Location = new System.Drawing.Point(158, 43);
            this.txtNumFirmas.Name = "txtNumFirmas";
            this.txtNumFirmas.Size = new System.Drawing.Size(69, 20);
            this.txtNumFirmas.TabIndex = 43;
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.Enabled = false;
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(338, 44);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(120, 21);
            this.cboTipoPersona.TabIndex = 48;
            this.cboTipoPersona.SelectedIndexChanged += new System.EventHandler(this.cboTipoPersona_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(14, 46);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(142, 13);
            this.lblBase8.TabIndex = 44;
            this.lblBase8.Text = "Nro Firmas Requeridos:";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(570, 18);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(146, 21);
            this.cboTipoCuenta.TabIndex = 42;
            this.cboTipoCuenta.SelectedIndexChanged += new System.EventHandler(this.cboTipoCuenta_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(469, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 41;
            this.lblBase5.Text = "Tipo de Cuenta:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(668, 397);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(543, 397);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // conDatPerReaOperac
            // 
            this.conDatPerReaOperac.ForeColor = System.Drawing.Color.Navy;
            this.conDatPerReaOperac.Location = new System.Drawing.Point(7, 343);
            this.conDatPerReaOperac.Name = "conDatPerReaOperac";
            this.conDatPerReaOperac.Size = new System.Drawing.Size(383, 78);
            this.conDatPerReaOperac.TabIndex = 2;
            // 
            // grbBase7
            // 
            this.grbBase7.ForeColor = System.Drawing.Color.Navy;
            this.grbBase7.Location = new System.Drawing.Point(4, 330);
            this.grbBase7.Name = "grbBase7";
            this.grbBase7.Size = new System.Drawing.Size(392, 98);
            this.grbBase7.TabIndex = 46;
            this.grbBase7.TabStop = false;
            this.grbBase7.Text = "Persona que Realiza la Operación";
            // 
            // conCalcVuelto
            // 
            this.conCalcVuelto.Location = new System.Drawing.Point(536, 330);
            this.conCalcVuelto.Name = "conCalcVuelto";
            this.conCalcVuelto.Size = new System.Drawing.Size(192, 61);
            this.conCalcVuelto.TabIndex = 3;
            // 
            // tabCliente
            // 
            this.tabCliente.Controls.Add(this.grbBase4);
            this.tabCliente.Location = new System.Drawing.Point(4, 22);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabCliente.Size = new System.Drawing.Size(720, 187);
            this.tabCliente.TabIndex = 1;
            this.tabCliente.Text = "Datos del Cliente";
            this.tabCliente.UseVisualStyleBackColor = true;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.dtgIntervinientes);
            this.grbBase4.Location = new System.Drawing.Point(6, 7);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(705, 177);
            this.grbBase4.TabIndex = 87;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "INTERVINIENTES DE LA CUENTA";
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Location = new System.Drawing.Point(9, 13);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(688, 158);
            this.dtgIntervinientes.TabIndex = 4;
            // 
            // tabOperacion
            // 
            this.tabOperacion.Controls.Add(this.grbBase5);
            this.tabOperacion.Controls.Add(this.grbBase3);
            this.tabOperacion.Location = new System.Drawing.Point(4, 22);
            this.tabOperacion.Name = "tabOperacion";
            this.tabOperacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperacion.Size = new System.Drawing.Size(720, 187);
            this.tabOperacion.TabIndex = 0;
            this.tabOperacion.Text = "Datos de la Operación";
            this.tabOperacion.UseVisualStyleBackColor = true;
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.conSolesDolar);
            this.grbBase5.Controls.Add(this.txtMontOpe);
            this.grbBase5.Controls.Add(this.btnComision);
            this.grbBase5.Controls.Add(this.txtRedondeo);
            this.grbBase5.Controls.Add(this.lblBase23);
            this.grbBase5.Controls.Add(this.txtMontEnt);
            this.grbBase5.Controls.Add(this.lblBase10);
            this.grbBase5.Controls.Add(this.lblBase11);
            this.grbBase5.Controls.Add(this.txtMontTotal);
            this.grbBase5.Controls.Add(this.txtImpuesto);
            this.grbBase5.Controls.Add(this.txtComision);
            this.grbBase5.Controls.Add(this.lblBase12);
            this.grbBase5.Controls.Add(this.lblBase13);
            this.grbBase5.Controls.Add(this.lblBase14);
            this.grbBase5.Location = new System.Drawing.Point(3, 4);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(427, 177);
            this.grbBase5.TabIndex = 0;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Monto de Operacion:";
            // 
            // conSolesDolar
            // 
            this.conSolesDolar.Location = new System.Drawing.Point(15, 123);
            this.conSolesDolar.Name = "conSolesDolar";
            this.conSolesDolar.Size = new System.Drawing.Size(55, 48);
            this.conSolesDolar.TabIndex = 51;
            // 
            // txtMontOpe
            // 
            this.txtMontOpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontOpe.FormatoDecimal = false;
            this.txtMontOpe.Location = new System.Drawing.Point(106, 24);
            this.txtMontOpe.Name = "txtMontOpe";
            this.txtMontOpe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontOpe.nNumDecimales = 2;
            this.txtMontOpe.nvalor = 0D;
            this.txtMontOpe.Size = new System.Drawing.Size(96, 20);
            this.txtMontOpe.TabIndex = 0;
            this.txtMontOpe.Text = "0.00";
            this.txtMontOpe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontOpe.TextChanged += new System.EventHandler(this.txtMontOpe_TextChanged);
            this.txtMontOpe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontOpe_KeyPress);
            this.txtMontOpe.Leave += new System.EventHandler(this.txtMontOpe_Leave);
            // 
            // btnComision
            // 
            this.btnComision.Enabled = false;
            this.btnComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComision.Location = new System.Drawing.Point(163, 53);
            this.btnComision.Name = "btnComision";
            this.btnComision.Size = new System.Drawing.Size(41, 31);
            this.btnComision.TabIndex = 51;
            this.btnComision.Text = "...";
            this.btnComision.UseVisualStyleBackColor = true;
            this.btnComision.Click += new System.EventHandler(this.btnComision_Click);
            // 
            // txtRedondeo
            // 
            this.txtRedondeo.BackColor = System.Drawing.SystemColors.Control;
            this.txtRedondeo.Enabled = false;
            this.txtRedondeo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRedondeo.FormatoDecimal = true;
            this.txtRedondeo.Location = new System.Drawing.Point(308, 25);
            this.txtRedondeo.Name = "txtRedondeo";
            this.txtRedondeo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRedondeo.nNumDecimales = 2;
            this.txtRedondeo.nvalor = 0D;
            this.txtRedondeo.Size = new System.Drawing.Size(100, 22);
            this.txtRedondeo.TabIndex = 28;
            this.txtRedondeo.Text = "0.00";
            this.txtRedondeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(218, 27);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(69, 13);
            this.lblBase23.TabIndex = 27;
            this.lblBase23.Text = "Redondeo:";
            this.lblBase23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMontEnt
            // 
            this.txtMontEnt.Enabled = false;
            this.txtMontEnt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontEnt.Location = new System.Drawing.Point(308, 94);
            this.txtMontEnt.Name = "txtMontEnt";
            this.txtMontEnt.Size = new System.Drawing.Size(100, 22);
            this.txtMontEnt.TabIndex = 9;
            this.txtMontEnt.Text = "0.00";
            this.txtMontEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase10
            // 
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(223, 91);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(64, 26);
            this.lblBase10.TabIndex = 8;
            this.lblBase10.Text = "Monto a Recibir:";
            this.lblBase10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase11
            // 
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(220, 55);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(67, 29);
            this.lblBase11.TabIndex = 7;
            this.lblBase11.Text = "Monto a Depositar:";
            this.lblBase11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMontTotal
            // 
            this.txtMontTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontTotal.Enabled = false;
            this.txtMontTotal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontTotal.Location = new System.Drawing.Point(308, 59);
            this.txtMontTotal.Name = "txtMontTotal";
            this.txtMontTotal.Size = new System.Drawing.Size(100, 22);
            this.txtMontTotal.TabIndex = 6;
            this.txtMontTotal.Text = "0.00";
            this.txtMontTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.BackColor = System.Drawing.SystemColors.Control;
            this.txtImpuesto.Enabled = false;
            this.txtImpuesto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpuesto.Location = new System.Drawing.Point(104, 94);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(100, 22);
            this.txtImpuesto.TabIndex = 5;
            this.txtImpuesto.Text = "0.00";
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtComision
            // 
            this.txtComision.BackColor = System.Drawing.SystemColors.Control;
            this.txtComision.Enabled = false;
            this.txtComision.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComision.Location = new System.Drawing.Point(104, 59);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(59, 22);
            this.txtComision.TabIndex = 4;
            this.txtComision.Text = "0.00";
            this.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(53, 98);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(30, 13);
            this.lblBase12.TabIndex = 3;
            this.lblBase12.Text = "ITF:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(5, 63);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(78, 13);
            this.lblBase13.TabIndex = 2;
            this.lblBase13.Text = "Comisiones:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(37, 27);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(46, 13);
            this.lblBase14.TabIndex = 0;
            this.lblBase14.Text = "Monto:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboTipoPago);
            this.grbBase3.Controls.Add(this.lblBase21);
            this.grbBase3.Controls.Add(this.lblBase31);
            this.grbBase3.Controls.Add(this.cboMotivoOperacion);
            this.grbBase3.Location = new System.Drawing.Point(436, 3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(278, 178);
            this.grbBase3.TabIndex = 1;
            this.grbBase3.TabStop = false;
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.Enabled = false;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(12, 28);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(251, 21);
            this.cboTipoPago.TabIndex = 2;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // lblBase21
            // 
            this.lblBase21.AutoSize = true;
            this.lblBase21.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase21.ForeColor = System.Drawing.Color.Navy;
            this.lblBase21.Location = new System.Drawing.Point(66, 12);
            this.lblBase21.Name = "lblBase21";
            this.lblBase21.Size = new System.Drawing.Size(136, 13);
            this.lblBase21.TabIndex = 128;
            this.lblBase21.Text = "Modalidad de Deposito";
            // 
            // lblBase31
            // 
            this.lblBase31.AutoSize = true;
            this.lblBase31.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase31.ForeColor = System.Drawing.Color.Navy;
            this.lblBase31.Location = new System.Drawing.Point(82, 54);
            this.lblBase31.Name = "lblBase31";
            this.lblBase31.Size = new System.Drawing.Size(103, 13);
            this.lblBase31.TabIndex = 139;
            this.lblBase31.Text = "Tipo de Depósito";
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoOperacion.Enabled = false;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(12, 70);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(252, 21);
            this.cboMotivoOperacion.TabIndex = 0;
            this.cboMotivoOperacion.SelectedIndexChanged += new System.EventHandler(this.cboMotivoOperacion_SelectedIndexChanged);
            // 
            // tbcDeposito
            // 
            this.tbcDeposito.Controls.Add(this.tabOperacion);
            this.tbcDeposito.Controls.Add(this.tabCliente);
            this.tbcDeposito.Location = new System.Drawing.Point(4, 111);
            this.tbcDeposito.Name = "tbcDeposito";
            this.tbcDeposito.SelectedIndex = 0;
            this.tbcDeposito.Size = new System.Drawing.Size(728, 213);
            this.tbcDeposito.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 33);
            this.panel1.TabIndex = 47;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(75, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(170, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Nombre Completo del Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // frmGrupoSolidarioDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 475);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.conCalcVuelto);
            this.Controls.Add(this.conDatPerReaOperac);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbcDeposito);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase7);
            this.Name = "frmGrupoSolidarioDeposito";
            this.Text = "Deposito de Ahorros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDepositoAho_FormClosed);
            this.Shown += new System.EventHandler(this.frmGrupoSolidarioDeposito_Shown);
            this.Controls.SetChildIndex(this.grbBase7, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.tbcDeposito, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conDatPerReaOperac, 0);
            this.Controls.SetChildIndex(this.conCalcVuelto, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.tabCliente.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.tabOperacion.ResumeLayout(false);
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.tbcDeposito.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.ConDatPerReaOperac conDatPerReaOperac;
        private GEN.ControlesBase.grbBase grbBase7;
        private GEN.ControlesBase.txtBase txtNumFirmas;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona;
        private GEN.ControlesBase.conCalcVuelto conCalcVuelto;
        private System.Windows.Forms.TabPage tabCliente;
        private GEN.ControlesBase.grbBase grbBase4;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private System.Windows.Forms.TabPage tabOperacion;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.ConSolesDolar conSolesDolar;
        private GEN.ControlesBase.txtNumRea txtMontOpe;
        private System.Windows.Forms.Button btnComision;
        private GEN.ControlesBase.txtNumRea txtRedondeo;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.txtBase txtMontEnt;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtMontTotal;
        private GEN.ControlesBase.txtBase txtImpuesto;
        private GEN.ControlesBase.txtBase txtComision;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private GEN.ControlesBase.lblBase lblBase21;
        private GEN.ControlesBase.lblBase lblBase31;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;
        private GEN.ControlesBase.tbcBase tbcDeposito;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
    }
}