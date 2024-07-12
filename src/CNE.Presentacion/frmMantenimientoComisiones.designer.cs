using System.Windows.Forms;

namespace CNE.Presentacion
{
    partial class frmMantenimientoComisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoComisiones));
            this.dtgDConfComision = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboTipoCanalServM = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNumeroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboCanalElecD = new GEN.ControlesBase.cboBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAsumeComMixto = new GEN.ControlesBase.cboBase(this.components);
            this.lblComMixto = new GEN.ControlesBase.lblBase();
            this.cboZonas = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoCanalServD = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblMin = new GEN.ControlesBase.lblBase();
            this.lblMax = new GEN.ControlesBase.lblBase();
            this.chcAplicaTodos = new GEN.ControlesBase.chcBase(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCanales = new System.Windows.Forms.TabPage();
            this.plIndicador = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCanalElectronico = new System.Windows.Forms.Label();
            this.cboCanalElecM = new GEN.ControlesBase.cboBase(this.components);
            this.btnNuevoCanal = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.gbConfCanal = new System.Windows.Forms.GroupBox();
            this.cboTipoRango = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.chcVigente = new System.Windows.Forms.CheckBox();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtpIniVigencia = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFinVigencia = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboTipoModalidadPago = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboTipoAsumeComi = new GEN.ControlesBase.cboBase(this.components);
            this.btnEditarCanal = new GEN.BotonesBase.btnMiniEditar();
            this.btnCancelCanal = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnQuitarCanal = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarCanal = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgMConfComision = new GEN.ControlesBase.dtgBase(this.components);
            this.tabComision = new System.Windows.Forms.TabPage();
            this.btnNuevoComs = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.btnEditarComs = new GEN.BotonesBase.btnMiniEditar();
            this.btnCancelComs = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnQuitarComs = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarComs = new GEN.BotonesBase.btnMiniAgregar();
            this.gbConfComision = new System.Windows.Forms.GroupBox();
            this.lblSigno = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtCosto = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblCosto = new GEN.ControlesBase.lblBase();
            this.txtMax = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtMin = new GEN.ControlesBase.txtNumerico(this.components);
            this.btnReporte = new GEN.BotonesBase.btnReporte();
            this.plBotones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDConfComision)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCanales.SuspendLayout();
            this.gbConfCanal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMConfComision)).BeginInit();
            this.tabComision.SuspendLayout();
            this.gbConfComision.SuspendLayout();
            this.plBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDConfComision
            // 
            this.dtgDConfComision.AllowUserToAddRows = false;
            this.dtgDConfComision.AllowUserToDeleteRows = false;
            this.dtgDConfComision.AllowUserToResizeColumns = false;
            this.dtgDConfComision.AllowUserToResizeRows = false;
            this.dtgDConfComision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDConfComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDConfComision.Location = new System.Drawing.Point(20, 260);
            this.dtgDConfComision.MultiSelect = false;
            this.dtgDConfComision.Name = "dtgDConfComision";
            this.dtgDConfComision.ReadOnly = true;
            this.dtgDConfComision.RowHeadersVisible = false;
            this.dtgDConfComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDConfComision.Size = new System.Drawing.Size(587, 236);
            this.dtgDConfComision.TabIndex = 2;
            this.dtgDConfComision.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDConfComision_CellDoubleClick);
            this.dtgDConfComision.SelectionChanged += new System.EventHandler(this.dtgDConfComision_SelectionChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(398, 5);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(464, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(530, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(596, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboTipoCanalServM
            // 
            this.cboTipoCanalServM.FormattingEnabled = true;
            this.cboTipoCanalServM.Location = new System.Drawing.Point(37, 46);
            this.cboTipoCanalServM.Name = "cboTipoCanalServM";
            this.cboTipoCanalServM.Size = new System.Drawing.Size(231, 21);
            this.cboTipoCanalServM.TabIndex = 7;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(35, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(113, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Canal de Servicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(333, 30);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(112, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Numero de cuenta";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(336, 47);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(205, 20);
            this.txtNumeroCuenta.TabIndex = 10;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 31);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(106, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Canal Electronico";
            // 
            // cboCanalElecD
            // 
            this.cboCanalElecD.FormattingEnabled = true;
            this.cboCanalElecD.Location = new System.Drawing.Point(129, 28);
            this.cboCanalElecD.Name = "cboCanalElecD";
            this.cboCanalElecD.Size = new System.Drawing.Size(155, 21);
            this.cboCanalElecD.TabIndex = 12;
            this.cboCanalElecD.SelectedValueChanged += new System.EventHandler(this.cboCanalElecD_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAsumeComMixto);
            this.groupBox1.Controls.Add(this.lblComMixto);
            this.groupBox1.Controls.Add(this.cboZonas);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.cboTipoCanalServD);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.cboCanalElecD);
            this.groupBox1.Location = new System.Drawing.Point(20, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 96);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // cboAsumeComMixto
            // 
            this.cboAsumeComMixto.FormattingEnabled = true;
            this.cboAsumeComMixto.Location = new System.Drawing.Point(367, 57);
            this.cboAsumeComMixto.Name = "cboAsumeComMixto";
            this.cboAsumeComMixto.Size = new System.Drawing.Size(180, 21);
            this.cboAsumeComMixto.TabIndex = 27;
            this.cboAsumeComMixto.SelectedValueChanged += new System.EventHandler(this.cboAsumeComMixto_SelectedValueChanged);
            // 
            // lblComMixto
            // 
            this.lblComMixto.AutoSize = true;
            this.lblComMixto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblComMixto.ForeColor = System.Drawing.Color.Navy;
            this.lblComMixto.Location = new System.Drawing.Point(315, 62);
            this.lblComMixto.Name = "lblComMixto";
            this.lblComMixto.Size = new System.Drawing.Size(46, 13);
            this.lblComMixto.TabIndex = 26;
            this.lblComMixto.Text = "Asume";
            // 
            // cboZonas
            // 
            this.cboZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZonas.FormattingEnabled = true;
            this.cboZonas.Location = new System.Drawing.Point(367, 29);
            this.cboZonas.Name = "cboZonas";
            this.cboZonas.Size = new System.Drawing.Size(180, 21);
            this.cboZonas.TabIndex = 19;
            this.cboZonas.SelectedValueChanged += new System.EventHandler(this.cboZonas_SelectedValueChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(16, 65);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(108, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Canal de Servicio";
            // 
            // cboTipoCanalServD
            // 
            this.cboTipoCanalServD.FormattingEnabled = true;
            this.cboTipoCanalServD.Location = new System.Drawing.Point(129, 62);
            this.cboTipoCanalServD.Name = "cboTipoCanalServD";
            this.cboTipoCanalServD.Size = new System.Drawing.Size(155, 21);
            this.cboTipoCanalServD.TabIndex = 18;
            this.cboTipoCanalServD.SelectedValueChanged += new System.EventHandler(this.cboTipoCanalServD_SelectedValueChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(325, 32);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(36, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Zona";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMin.ForeColor = System.Drawing.Color.Navy;
            this.lblMin.Location = new System.Drawing.Point(22, 35);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(92, 13);
            this.lblMin.TabIndex = 15;
            this.lblMin.Text = "Monto minimo:";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMax.ForeColor = System.Drawing.Color.Navy;
            this.lblMax.Location = new System.Drawing.Point(22, 60);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(96, 13);
            this.lblMax.TabIndex = 16;
            this.lblMax.Text = "Monto maximo:";
            // 
            // chcAplicaTodos
            // 
            this.chcAplicaTodos.AutoSize = true;
            this.chcAplicaTodos.Location = new System.Drawing.Point(21, 229);
            this.chcAplicaTodos.Name = "chcAplicaTodos";
            this.chcAplicaTodos.Size = new System.Drawing.Size(146, 17);
            this.chcAplicaTodos.TabIndex = 20;
            this.chcAplicaTodos.Text = "Aplica a Todas las Zonas";
            this.chcAplicaTodos.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCanales);
            this.tabControl.Controls.Add(this.tabComision);
            this.tabControl.Location = new System.Drawing.Point(19, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(637, 548);
            this.tabControl.TabIndex = 25;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabCanales
            // 
            this.tabCanales.Controls.Add(this.plIndicador);
            this.tabCanales.Controls.Add(this.label1);
            this.tabCanales.Controls.Add(this.lblCanalElectronico);
            this.tabCanales.Controls.Add(this.cboCanalElecM);
            this.tabCanales.Controls.Add(this.btnNuevoCanal);
            this.tabCanales.Controls.Add(this.gbConfCanal);
            this.tabCanales.Controls.Add(this.btnEditarCanal);
            this.tabCanales.Controls.Add(this.btnCancelCanal);
            this.tabCanales.Controls.Add(this.btnQuitarCanal);
            this.tabCanales.Controls.Add(this.btnAgregarCanal);
            this.tabCanales.Controls.Add(this.dtgMConfComision);
            this.tabCanales.Location = new System.Drawing.Point(4, 22);
            this.tabCanales.Name = "tabCanales";
            this.tabCanales.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanales.Size = new System.Drawing.Size(629, 522);
            this.tabCanales.TabIndex = 1;
            this.tabCanales.Text = "Mantenimiento de Canales";
            this.tabCanales.UseVisualStyleBackColor = true;
            // 
            // plIndicador
            // 
            this.plIndicador.BackColor = System.Drawing.Color.LightYellow;
            this.plIndicador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plIndicador.Location = new System.Drawing.Point(42, 299);
            this.plIndicador.Name = "plIndicador";
            this.plIndicador.Size = new System.Drawing.Size(15, 15);
            this.plIndicador.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Comisión Mixta";
            // 
            // lblCanalElectronico
            // 
            this.lblCanalElectronico.AutoSize = true;
            this.lblCanalElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanalElectronico.Location = new System.Drawing.Point(35, 21);
            this.lblCanalElectronico.Name = "lblCanalElectronico";
            this.lblCanalElectronico.Size = new System.Drawing.Size(154, 15);
            this.lblCanalElectronico.TabIndex = 34;
            this.lblCanalElectronico.Text = "CANAL ELECTRONICO:";
            // 
            // cboCanalElecM
            // 
            this.cboCanalElecM.FormattingEnabled = true;
            this.cboCanalElecM.Location = new System.Drawing.Point(195, 20);
            this.cboCanalElecM.Name = "cboCanalElecM";
            this.cboCanalElecM.Size = new System.Drawing.Size(155, 21);
            this.cboCanalElecM.TabIndex = 13;
            this.cboCanalElecM.SelectedValueChanged += new System.EventHandler(this.cboCanalElecM_SelectedValueChanged);
            // 
            // btnNuevoCanal
            // 
            this.btnNuevoCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoCanal.BackgroundImage")));
            this.btnNuevoCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoCanal.Location = new System.Drawing.Point(399, 287);
            this.btnNuevoCanal.Name = "btnNuevoCanal";
            this.btnNuevoCanal.Size = new System.Drawing.Size(36, 28);
            this.btnNuevoCanal.TabIndex = 32;
            this.btnNuevoCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoCanal.UseVisualStyleBackColor = true;
            this.btnNuevoCanal.Click += new System.EventHandler(this.btnNuevoCanal_Click);
            // 
            // gbConfCanal
            // 
            this.gbConfCanal.Controls.Add(this.cboTipoRango);
            this.gbConfCanal.Controls.Add(this.lblBase6);
            this.gbConfCanal.Controls.Add(this.chcVigente);
            this.gbConfCanal.Controls.Add(this.lblBase8);
            this.gbConfCanal.Controls.Add(this.dtpIniVigencia);
            this.gbConfCanal.Controls.Add(this.dtpFinVigencia);
            this.gbConfCanal.Controls.Add(this.lblBase9);
            this.gbConfCanal.Controls.Add(this.cboTipoCanalServM);
            this.gbConfCanal.Controls.Add(this.txtNumeroCuenta);
            this.gbConfCanal.Controls.Add(this.cboTipoModalidadPago);
            this.gbConfCanal.Controls.Add(this.lblBase2);
            this.gbConfCanal.Controls.Add(this.lblBase12);
            this.gbConfCanal.Controls.Add(this.lblBase1);
            this.gbConfCanal.Controls.Add(this.lblBase7);
            this.gbConfCanal.Controls.Add(this.cboTipoAsumeComi);
            this.gbConfCanal.Location = new System.Drawing.Point(26, 58);
            this.gbConfCanal.Name = "gbConfCanal";
            this.gbConfCanal.Size = new System.Drawing.Size(576, 221);
            this.gbConfCanal.TabIndex = 31;
            this.gbConfCanal.TabStop = false;
            this.gbConfCanal.Text = "Configuracion";
            // 
            // cboTipoRango
            // 
            this.cboTipoRango.FormattingEnabled = true;
            this.cboTipoRango.Location = new System.Drawing.Point(37, 137);
            this.cboTipoRango.Name = "cboTipoRango";
            this.cboTipoRango.Size = new System.Drawing.Size(231, 21);
            this.cboTipoRango.TabIndex = 36;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(35, 167);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(119, 13);
            this.lblBase6.TabIndex = 35;
            this.lblBase6.Text = "Modalidad de Pago:";
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(336, 183);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 34;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(333, 75);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(108, 13);
            this.lblBase8.TabIndex = 32;
            this.lblBase8.Text = "Inicio de Vigencia";
            // 
            // dtpIniVigencia
            // 
            this.dtpIniVigencia.CustomFormat = "dd/MM/yyyy";
            this.dtpIniVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIniVigencia.Location = new System.Drawing.Point(336, 91);
            this.dtpIniVigencia.Name = "dtpIniVigencia";
            this.dtpIniVigencia.Size = new System.Drawing.Size(102, 20);
            this.dtpIniVigencia.TabIndex = 30;
            // 
            // dtpFinVigencia
            // 
            this.dtpFinVigencia.CustomFormat = "dd/MM/yyyy";
            this.dtpFinVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinVigencia.Location = new System.Drawing.Point(336, 138);
            this.dtpFinVigencia.Name = "dtpFinVigencia";
            this.dtpFinVigencia.Size = new System.Drawing.Size(102, 20);
            this.dtpFinVigencia.TabIndex = 31;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(333, 121);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(93, 13);
            this.lblBase9.TabIndex = 33;
            this.lblBase9.Text = "Fin de Vigencia";
            // 
            // cboTipoModalidadPago
            // 
            this.cboTipoModalidadPago.FormattingEnabled = true;
            this.cboTipoModalidadPago.Location = new System.Drawing.Point(38, 183);
            this.cboTipoModalidadPago.Name = "cboTipoModalidadPago";
            this.cboTipoModalidadPago.Size = new System.Drawing.Size(230, 21);
            this.cboTipoModalidadPago.TabIndex = 29;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(35, 121);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(94, 13);
            this.lblBase12.TabIndex = 28;
            this.lblBase12.Text = "Tipo de Rango:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(35, 75);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(119, 13);
            this.lblBase7.TabIndex = 25;
            this.lblBase7.Text = "Asume la comision:";
            // 
            // cboTipoAsumeComi
            // 
            this.cboTipoAsumeComi.FormattingEnabled = true;
            this.cboTipoAsumeComi.Location = new System.Drawing.Point(37, 91);
            this.cboTipoAsumeComi.Name = "cboTipoAsumeComi";
            this.cboTipoAsumeComi.Size = new System.Drawing.Size(231, 21);
            this.cboTipoAsumeComi.TabIndex = 24;
            // 
            // btnEditarCanal
            // 
            this.btnEditarCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarCanal.BackgroundImage")));
            this.btnEditarCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarCanal.Location = new System.Drawing.Point(524, 285);
            this.btnEditarCanal.Name = "btnEditarCanal";
            this.btnEditarCanal.Size = new System.Drawing.Size(36, 28);
            this.btnEditarCanal.TabIndex = 23;
            this.btnEditarCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarCanal.UseVisualStyleBackColor = true;
            this.btnEditarCanal.Click += new System.EventHandler(this.btnEditarCanal_Click);
            // 
            // btnCancelCanal
            // 
            this.btnCancelCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelCanal.BackgroundImage")));
            this.btnCancelCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelCanal.Location = new System.Drawing.Point(566, 286);
            this.btnCancelCanal.Name = "btnCancelCanal";
            this.btnCancelCanal.Size = new System.Drawing.Size(36, 28);
            this.btnCancelCanal.TabIndex = 22;
            this.btnCancelCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelCanal.UseVisualStyleBackColor = true;
            this.btnCancelCanal.Click += new System.EventHandler(this.btnCancelCanal_Click);
            // 
            // btnQuitarCanal
            // 
            this.btnQuitarCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarCanal.BackgroundImage")));
            this.btnQuitarCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarCanal.Location = new System.Drawing.Point(482, 285);
            this.btnQuitarCanal.Name = "btnQuitarCanal";
            this.btnQuitarCanal.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarCanal.TabIndex = 20;
            this.btnQuitarCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarCanal.UseVisualStyleBackColor = true;
            this.btnQuitarCanal.Click += new System.EventHandler(this.btnQuitarCanal_Click);
            // 
            // btnAgregarCanal
            // 
            this.btnAgregarCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarCanal.BackgroundImage")));
            this.btnAgregarCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarCanal.Location = new System.Drawing.Point(440, 286);
            this.btnAgregarCanal.Name = "btnAgregarCanal";
            this.btnAgregarCanal.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarCanal.TabIndex = 19;
            this.btnAgregarCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarCanal.UseVisualStyleBackColor = true;
            this.btnAgregarCanal.Click += new System.EventHandler(this.btnAgregarCanal_Click);
            // 
            // dtgMConfComision
            // 
            this.dtgMConfComision.AllowUserToAddRows = false;
            this.dtgMConfComision.AllowUserToDeleteRows = false;
            this.dtgMConfComision.AllowUserToResizeColumns = false;
            this.dtgMConfComision.AllowUserToResizeRows = false;
            this.dtgMConfComision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMConfComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMConfComision.Location = new System.Drawing.Point(26, 321);
            this.dtgMConfComision.MultiSelect = false;
            this.dtgMConfComision.Name = "dtgMConfComision";
            this.dtgMConfComision.ReadOnly = true;
            this.dtgMConfComision.RowHeadersVisible = false;
            this.dtgMConfComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMConfComision.Size = new System.Drawing.Size(576, 175);
            this.dtgMConfComision.TabIndex = 18;
            this.dtgMConfComision.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMConfComision_CellDoubleClick);
            this.dtgMConfComision.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMConfComision_DataBindingComplete);
            this.dtgMConfComision.SelectionChanged += new System.EventHandler(this.dtgMConfComision_SelectionChanged);
            // 
            // tabComision
            // 
            this.tabComision.Controls.Add(this.btnNuevoComs);
            this.tabComision.Controls.Add(this.btnEditarComs);
            this.tabComision.Controls.Add(this.btnCancelComs);
            this.tabComision.Controls.Add(this.btnQuitarComs);
            this.tabComision.Controls.Add(this.btnAgregarComs);
            this.tabComision.Controls.Add(this.gbConfComision);
            this.tabComision.Controls.Add(this.dtgDConfComision);
            this.tabComision.Controls.Add(this.groupBox1);
            this.tabComision.Controls.Add(this.chcAplicaTodos);
            this.tabComision.Location = new System.Drawing.Point(4, 22);
            this.tabComision.Name = "tabComision";
            this.tabComision.Padding = new System.Windows.Forms.Padding(3);
            this.tabComision.Size = new System.Drawing.Size(629, 522);
            this.tabComision.TabIndex = 0;
            this.tabComision.Text = "Mantenimiento de Comisiones";
            this.tabComision.UseVisualStyleBackColor = true;
            // 
            // btnNuevoComs
            // 
            this.btnNuevoComs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoComs.BackgroundImage")));
            this.btnNuevoComs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoComs.Location = new System.Drawing.Point(399, 225);
            this.btnNuevoComs.Name = "btnNuevoComs";
            this.btnNuevoComs.Size = new System.Drawing.Size(36, 28);
            this.btnNuevoComs.TabIndex = 30;
            this.btnNuevoComs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoComs.UseVisualStyleBackColor = true;
            this.btnNuevoComs.Click += new System.EventHandler(this.btnNuevoComs_Click);
            // 
            // btnEditarComs
            // 
            this.btnEditarComs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarComs.BackgroundImage")));
            this.btnEditarComs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarComs.Location = new System.Drawing.Point(525, 225);
            this.btnEditarComs.Name = "btnEditarComs";
            this.btnEditarComs.Size = new System.Drawing.Size(36, 28);
            this.btnEditarComs.TabIndex = 29;
            this.btnEditarComs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarComs.UseVisualStyleBackColor = true;
            this.btnEditarComs.Click += new System.EventHandler(this.btnEditarComs_Click);
            // 
            // btnCancelComs
            // 
            this.btnCancelComs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelComs.BackgroundImage")));
            this.btnCancelComs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelComs.Location = new System.Drawing.Point(567, 226);
            this.btnCancelComs.Name = "btnCancelComs";
            this.btnCancelComs.Size = new System.Drawing.Size(36, 28);
            this.btnCancelComs.TabIndex = 28;
            this.btnCancelComs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelComs.UseVisualStyleBackColor = true;
            this.btnCancelComs.Click += new System.EventHandler(this.btnCancelComs_Click);
            // 
            // btnQuitarComs
            // 
            this.btnQuitarComs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarComs.BackgroundImage")));
            this.btnQuitarComs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarComs.Location = new System.Drawing.Point(483, 225);
            this.btnQuitarComs.Name = "btnQuitarComs";
            this.btnQuitarComs.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarComs.TabIndex = 27;
            this.btnQuitarComs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarComs.UseVisualStyleBackColor = true;
            this.btnQuitarComs.Click += new System.EventHandler(this.btnQuitarComs_Click);
            // 
            // btnAgregarComs
            // 
            this.btnAgregarComs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarComs.BackgroundImage")));
            this.btnAgregarComs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarComs.Location = new System.Drawing.Point(441, 226);
            this.btnAgregarComs.Name = "btnAgregarComs";
            this.btnAgregarComs.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarComs.TabIndex = 26;
            this.btnAgregarComs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarComs.UseVisualStyleBackColor = true;
            this.btnAgregarComs.Click += new System.EventHandler(this.btnAgregarComs_Click);
            // 
            // gbConfComision
            // 
            this.gbConfComision.Controls.Add(this.lblSigno);
            this.gbConfComision.Controls.Add(this.cboMoneda);
            this.gbConfComision.Controls.Add(this.lblMoneda);
            this.gbConfComision.Controls.Add(this.txtCosto);
            this.gbConfComision.Controls.Add(this.lblCosto);
            this.gbConfComision.Controls.Add(this.txtMax);
            this.gbConfComision.Controls.Add(this.txtMin);
            this.gbConfComision.Controls.Add(this.lblMin);
            this.gbConfComision.Controls.Add(this.lblMax);
            this.gbConfComision.Location = new System.Drawing.Point(19, 119);
            this.gbConfComision.Name = "gbConfComision";
            this.gbConfComision.Size = new System.Drawing.Size(588, 100);
            this.gbConfComision.TabIndex = 25;
            this.gbConfComision.TabStop = false;
            this.gbConfComision.Text = "Configuracion";
            // 
            // lblSigno
            // 
            this.lblSigno.AutoSize = true;
            this.lblSigno.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSigno.ForeColor = System.Drawing.Color.Navy;
            this.lblSigno.Location = new System.Drawing.Point(531, 31);
            this.lblSigno.Name = "lblSigno";
            this.lblSigno.Size = new System.Drawing.Size(24, 13);
            this.lblSigno.TabIndex = 33;
            this.lblSigno.Text = "S/.";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(413, 60);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 32;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(308, 64);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(87, 13);
            this.lblMoneda.TabIndex = 30;
            this.lblMoneda.Text = "Tipo de moneda:";
            // 
            // txtCosto
            // 
            this.txtCosto.Format = "n2";
            this.txtCosto.Location = new System.Drawing.Point(413, 28);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(116, 20);
            this.txtCosto.TabIndex = 20;
            this.txtCosto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCosto_Validating);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCosto.ForeColor = System.Drawing.Color.Navy;
            this.lblCosto.Location = new System.Drawing.Point(308, 31);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(58, 13);
            this.lblCosto.TabIndex = 19;
            this.lblCosto.Text = "Importe:";
            // 
            // txtMax
            // 
            this.txtMax.Format = "n2";
            this.txtMax.Location = new System.Drawing.Point(168, 57);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(116, 20);
            this.txtMax.TabIndex = 18;
            this.txtMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtMax_Validating);
            // 
            // txtMin
            // 
            this.txtMin.Format = "n2";
            this.txtMin.Location = new System.Drawing.Point(168, 31);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(116, 20);
            this.txtMin.TabIndex = 17;
            this.txtMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtMin_Validating);
            // 
            // btnReporte
            // 
            this.btnReporte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReporte.BackgroundImage")));
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReporte.Location = new System.Drawing.Point(19, 5);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(60, 50);
            this.btnReporte.TabIndex = 26;
            this.btnReporte.Text = "Log";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // plBotones
            // 
            this.plBotones.Controls.Add(this.btnGrabar);
            this.plBotones.Controls.Add(this.btnReporte);
            this.plBotones.Controls.Add(this.btnSalir);
            this.plBotones.Controls.Add(this.btnCancelar);
            this.plBotones.Controls.Add(this.btnEditar);
            this.plBotones.Location = new System.Drawing.Point(0, 567);
            this.plBotones.Name = "plBotones";
            this.plBotones.Size = new System.Drawing.Size(678, 62);
            this.plBotones.TabIndex = 27;
            // 
            // frmMantenimientoComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 650);
            this.Controls.Add(this.plBotones);
            this.Controls.Add(this.tabControl);
            this.Name = "frmMantenimientoComisiones";
            this.Text = "Mantenimiento de Comisiones";
            this.Load += new System.EventHandler(this.frmMantenimientoComisiones_Load);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.plBotones, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDConfComision)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabCanales.ResumeLayout(false);
            this.tabCanales.PerformLayout();
            this.gbConfCanal.ResumeLayout(false);
            this.gbConfCanal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMConfComision)).EndInit();
            this.tabComision.ResumeLayout(false);
            this.tabComision.PerformLayout();
            this.gbConfComision.ResumeLayout(false);
            this.gbConfComision.PerformLayout();
            this.plBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgDConfComision;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboBase cboTipoCanalServM;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNumeroCuenta;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboCanalElecD;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblMin;
        private GEN.ControlesBase.lblBase lblMax;
        private GEN.ControlesBase.chcBase chcAplicaTodos;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabComision;
        private System.Windows.Forms.TabPage tabCanales;
        private GEN.ControlesBase.cboBase cboTipoAsumeComi;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnMiniEditar btnEditarCanal;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelCanal;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarCanal;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarCanal;
        private System.Windows.Forms.GroupBox gbConfComision;
        private System.Windows.Forms.GroupBox gbConfCanal;
        private GEN.ControlesBase.cboBase cboTipoModalidadPago;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtNumerico txtMax;
        private GEN.ControlesBase.txtNumerico txtMin;
        private GEN.BotonesBase.btnMiniEditar btnEditarComs;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelComs;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarComs;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarComs;
        private GEN.ControlesBase.txtNumerico txtCosto;
        private GEN.ControlesBase.lblBase lblCosto;
        private GEN.ControlesBase.dtgBase dtgMConfComision;
        private System.Windows.Forms.Label lblMoneda;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblSigno;
        private GEN.BotonesBase.btnMiniNuevo btnNuevoComs;
        private GEN.BotonesBase.btnReporte btnReporte;
        private GEN.ControlesBase.cboBase cboCanalElecM;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtpCorto dtpIniVigencia;
        private GEN.ControlesBase.dtpCorto dtpFinVigencia;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.CheckBox chcVigente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboTipoCanalServD;
        private GEN.BotonesBase.btnMiniNuevo btnNuevoCanal;
        private GEN.ControlesBase.cboZona cboZonas;
        private GEN.ControlesBase.cboBase cboAsumeComMixto;
        private GEN.ControlesBase.lblBase lblComMixto;
        private Panel plBotones;
        private Label lblCanalElectronico;
        private GEN.ControlesBase.cboBase cboTipoRango;
        private GEN.ControlesBase.lblBase lblBase6;
        private Label label1;
        private Panel plIndicador;
    }
}