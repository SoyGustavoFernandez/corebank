namespace CRE.Presentacion
{
    partial class frmRegActosProc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegActosProc));
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabActProc = new System.Windows.Forms.TabPage();
            this.cboTipoActoProcesal1 = new GEN.ControlesBase.cboTipoActoProcesal();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboEncAud = new GEN.ControlesBase.cboAbogado(this.components);
            this.btnQuitActProc = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgrActProc = new GEN.BotonesBase.btnMiniAgregar();
            this.txtEncAud = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgActProc = new GEN.ControlesBase.dtgBase(this.components);
            this.txtDetActProc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.tabDatProc = new System.Windows.Forms.TabPage();
            this.cboEstProcJud = new GEN.ControlesBase.cboEstProcJud(this.components);
            this.cboTipMedJud = new GEN.ControlesBase.cboTipMedJud(this.components);
            this.cboTipoProcJud = new GEN.ControlesBase.cboTipoProcJud(this.components);
            this.cboAbogado = new GEN.ControlesBase.cboAbogado(this.components);
            this.cboSecretario = new GEN.ControlesBase.cboSecretario(this.components);
            this.cboJuez = new GEN.ControlesBase.cboJuez(this.components);
            this.cboJuzgado = new GEN.ControlesBase.cboJuzgado(this.components);
            this.txtAbogContr = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtNroExp = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroProc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.cboTipoPersonaEjecActProc1 = new GEN.ControlesBase.cboTipoPersonaEjecActProc();
            this.tbcBase1.SuspendLayout();
            this.tabActProc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActProc)).BeginInit();
            this.tabDatProc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabActProc);
            this.tbcBase1.Controls.Add(this.tabDatProc);
            this.tbcBase1.Location = new System.Drawing.Point(12, 141);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(558, 358);
            this.tbcBase1.TabIndex = 1;
            // 
            // tabActProc
            // 
            this.tabActProc.Controls.Add(this.cboTipoPersonaEjecActProc1);
            this.tabActProc.Controls.Add(this.lblBase14);
            this.tabActProc.Controls.Add(this.cboTipoActoProcesal1);
            this.tabActProc.Controls.Add(this.lblBase13);
            this.tabActProc.Controls.Add(this.cboEncAud);
            this.tabActProc.Controls.Add(this.btnQuitActProc);
            this.tabActProc.Controls.Add(this.btnAgrActProc);
            this.tabActProc.Controls.Add(this.txtEncAud);
            this.tabActProc.Controls.Add(this.lblBase2);
            this.tabActProc.Controls.Add(this.dtgActProc);
            this.tabActProc.Controls.Add(this.txtDetActProc);
            this.tabActProc.Controls.Add(this.lblBase1);
            this.tabActProc.Location = new System.Drawing.Point(4, 22);
            this.tabActProc.Name = "tabActProc";
            this.tabActProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabActProc.Size = new System.Drawing.Size(550, 332);
            this.tabActProc.TabIndex = 0;
            this.tabActProc.Text = "Actos Procesales";
            this.tabActProc.UseVisualStyleBackColor = true;
            this.tabActProc.Click += new System.EventHandler(this.tabActProc_Click);
            // 
            // cboTipoActoProcesal1
            // 
            this.cboTipoActoProcesal1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoActoProcesal1.FormattingEnabled = true;
            this.cboTipoActoProcesal1.Location = new System.Drawing.Point(143, 270);
            this.cboTipoActoProcesal1.Name = "cboTipoActoProcesal1";
            this.cboTipoActoProcesal1.Size = new System.Drawing.Size(397, 21);
            this.cboTipoActoProcesal1.TabIndex = 12;
            this.cboTipoActoProcesal1.Leave += new System.EventHandler(this.cboTipoActoProcesal1_Leave);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(6, 273);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(135, 13);
            this.lblBase13.TabIndex = 11;
            this.lblBase13.Text = "Tipo de Acto Procesal:";
            // 
            // cboEncAud
            // 
            this.cboEncAud.FormattingEnabled = true;
            this.cboEncAud.Location = new System.Drawing.Point(143, 243);
            this.cboEncAud.Name = "cboEncAud";
            this.cboEncAud.Size = new System.Drawing.Size(291, 21);
            this.cboEncAud.TabIndex = 3;
            // 
            // btnQuitActProc
            // 
            this.btnQuitActProc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitActProc.BackgroundImage")));
            this.btnQuitActProc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitActProc.Location = new System.Drawing.Point(508, 40);
            this.btnQuitActProc.Name = "btnQuitActProc";
            this.btnQuitActProc.Size = new System.Drawing.Size(36, 28);
            this.btnQuitActProc.TabIndex = 10;
            this.btnQuitActProc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitActProc.UseVisualStyleBackColor = true;
            this.btnQuitActProc.Click += new System.EventHandler(this.btnQuitActProc_Click);
            // 
            // btnAgrActProc
            // 
            this.btnAgrActProc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgrActProc.BackgroundImage")));
            this.btnAgrActProc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgrActProc.Location = new System.Drawing.Point(508, 6);
            this.btnAgrActProc.Name = "btnAgrActProc";
            this.btnAgrActProc.Size = new System.Drawing.Size(36, 28);
            this.btnAgrActProc.TabIndex = 0;
            this.btnAgrActProc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgrActProc.UseVisualStyleBackColor = true;
            this.btnAgrActProc.Click += new System.EventHandler(this.btnAgrActProc_Click);
            // 
            // txtEncAud
            // 
            this.txtEncAud.Location = new System.Drawing.Point(440, 243);
            this.txtEncAud.Name = "txtEncAud";
            this.txtEncAud.ReadOnly = true;
            this.txtEncAud.Size = new System.Drawing.Size(100, 20);
            this.txtEncAud.TabIndex = 8;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 246);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(131, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Encargado Audiencia:";
            // 
            // dtgActProc
            // 
            this.dtgActProc.AllowUserToAddRows = false;
            this.dtgActProc.AllowUserToDeleteRows = false;
            this.dtgActProc.AllowUserToResizeColumns = false;
            this.dtgActProc.AllowUserToResizeRows = false;
            this.dtgActProc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActProc.Location = new System.Drawing.Point(6, 6);
            this.dtgActProc.MultiSelect = false;
            this.dtgActProc.Name = "dtgActProc";
            this.dtgActProc.ReadOnly = true;
            this.dtgActProc.RowHeadersVisible = false;
            this.dtgActProc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActProc.Size = new System.Drawing.Size(496, 153);
            this.dtgActProc.TabIndex = 1;
            this.dtgActProc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActProc_CellValueChanged);
            // 
            // txtDetActProc
            // 
            this.txtDetActProc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetActProc.Location = new System.Drawing.Point(6, 178);
            this.txtDetActProc.Multiline = true;
            this.txtDetActProc.Name = "txtDetActProc";
            this.txtDetActProc.Size = new System.Drawing.Size(534, 62);
            this.txtDetActProc.TabIndex = 2;
            this.txtDetActProc.Leave += new System.EventHandler(this.txtDetActProc_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 162);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Detalle:";
            // 
            // tabDatProc
            // 
            this.tabDatProc.Controls.Add(this.cboEstProcJud);
            this.tabDatProc.Controls.Add(this.cboTipMedJud);
            this.tabDatProc.Controls.Add(this.cboTipoProcJud);
            this.tabDatProc.Controls.Add(this.cboAbogado);
            this.tabDatProc.Controls.Add(this.cboSecretario);
            this.tabDatProc.Controls.Add(this.cboJuez);
            this.tabDatProc.Controls.Add(this.cboJuzgado);
            this.tabDatProc.Controls.Add(this.txtAbogContr);
            this.tabDatProc.Controls.Add(this.lblBase10);
            this.tabDatProc.Controls.Add(this.lblBase9);
            this.tabDatProc.Controls.Add(this.lblBase8);
            this.tabDatProc.Controls.Add(this.lblBase7);
            this.tabDatProc.Controls.Add(this.lblBase6);
            this.tabDatProc.Controls.Add(this.lblBase5);
            this.tabDatProc.Controls.Add(this.lblBase4);
            this.tabDatProc.Controls.Add(this.lblBase3);
            this.tabDatProc.Location = new System.Drawing.Point(4, 22);
            this.tabDatProc.Name = "tabDatProc";
            this.tabDatProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatProc.Size = new System.Drawing.Size(550, 309);
            this.tabDatProc.TabIndex = 1;
            this.tabDatProc.Text = "Datos del Proceso";
            this.tabDatProc.UseVisualStyleBackColor = true;
            // 
            // cboEstProcJud
            // 
            this.cboEstProcJud.Enabled = false;
            this.cboEstProcJud.FormattingEnabled = true;
            this.cboEstProcJud.Location = new System.Drawing.Point(180, 223);
            this.cboEstProcJud.Name = "cboEstProcJud";
            this.cboEstProcJud.Size = new System.Drawing.Size(320, 21);
            this.cboEstProcJud.TabIndex = 66;
            // 
            // cboTipMedJud
            // 
            this.cboTipMedJud.Enabled = false;
            this.cboTipMedJud.FormattingEnabled = true;
            this.cboTipMedJud.Location = new System.Drawing.Point(180, 194);
            this.cboTipMedJud.Name = "cboTipMedJud";
            this.cboTipMedJud.Size = new System.Drawing.Size(320, 21);
            this.cboTipMedJud.TabIndex = 65;
            // 
            // cboTipoProcJud
            // 
            this.cboTipoProcJud.Enabled = false;
            this.cboTipoProcJud.FormattingEnabled = true;
            this.cboTipoProcJud.Location = new System.Drawing.Point(180, 166);
            this.cboTipoProcJud.Name = "cboTipoProcJud";
            this.cboTipoProcJud.Size = new System.Drawing.Size(320, 21);
            this.cboTipoProcJud.TabIndex = 64;
            // 
            // cboAbogado
            // 
            this.cboAbogado.Enabled = false;
            this.cboAbogado.FormattingEnabled = true;
            this.cboAbogado.Location = new System.Drawing.Point(180, 103);
            this.cboAbogado.Name = "cboAbogado";
            this.cboAbogado.Size = new System.Drawing.Size(320, 21);
            this.cboAbogado.TabIndex = 63;
            // 
            // cboSecretario
            // 
            this.cboSecretario.Enabled = false;
            this.cboSecretario.FormattingEnabled = true;
            this.cboSecretario.Location = new System.Drawing.Point(180, 74);
            this.cboSecretario.Name = "cboSecretario";
            this.cboSecretario.Size = new System.Drawing.Size(320, 21);
            this.cboSecretario.TabIndex = 62;
            // 
            // cboJuez
            // 
            this.cboJuez.Enabled = false;
            this.cboJuez.FormattingEnabled = true;
            this.cboJuez.Location = new System.Drawing.Point(180, 46);
            this.cboJuez.Name = "cboJuez";
            this.cboJuez.Size = new System.Drawing.Size(320, 21);
            this.cboJuez.TabIndex = 61;
            // 
            // cboJuzgado
            // 
            this.cboJuzgado.Enabled = false;
            this.cboJuzgado.FormattingEnabled = true;
            this.cboJuzgado.Location = new System.Drawing.Point(180, 17);
            this.cboJuzgado.Name = "cboJuzgado";
            this.cboJuzgado.Size = new System.Drawing.Size(320, 21);
            this.cboJuzgado.TabIndex = 60;
            // 
            // txtAbogContr
            // 
            this.txtAbogContr.Location = new System.Drawing.Point(180, 134);
            this.txtAbogContr.Name = "txtAbogContr";
            this.txtAbogContr.ReadOnly = true;
            this.txtAbogContr.Size = new System.Drawing.Size(320, 20);
            this.txtAbogContr.TabIndex = 59;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(55, 137);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(114, 13);
            this.lblBase10.TabIndex = 58;
            this.lblBase10.Text = "Abogado Demand:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(55, 226);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(50, 13);
            this.lblBase9.TabIndex = 56;
            this.lblBase9.Text = "Estado:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(55, 197);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(80, 13);
            this.lblBase8.TabIndex = 37;
            this.lblBase8.Text = "Tipo Medida:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(55, 169);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(85, 13);
            this.lblBase7.TabIndex = 36;
            this.lblBase7.Text = "Tipo Proceso:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(55, 106);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(82, 13);
            this.lblBase6.TabIndex = 35;
            this.lblBase6.Text = "Abogado IFI:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(55, 77);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(71, 13);
            this.lblBase5.TabIndex = 34;
            this.lblBase5.Text = "Secretario:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(55, 49);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(37, 13);
            this.lblBase4.TabIndex = 33;
            this.lblBase4.Text = "Juez:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(55, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(58, 13);
            this.lblBase3.TabIndex = 32;
            this.lblBase3.Text = "Juzgado:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(510, 505);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(448, 505);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(386, 505);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 7);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 0;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(186, 120);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(103, 13);
            this.lblBase11.TabIndex = 12;
            this.lblBase11.Text = "Nro. Expediente:";
            // 
            // txtNroExp
            // 
            this.txtNroExp.Location = new System.Drawing.Point(295, 116);
            this.txtNroExp.Name = "txtNroExp";
            this.txtNroExp.ReadOnly = true;
            this.txtNroExp.Size = new System.Drawing.Size(249, 20);
            this.txtNroExp.TabIndex = 13;
            // 
            // txtNroProc
            // 
            this.txtNroProc.Location = new System.Drawing.Point(99, 116);
            this.txtNroProc.Name = "txtNroProc";
            this.txtNroProc.ReadOnly = true;
            this.txtNroProc.Size = new System.Drawing.Size(62, 20);
            this.txtNroProc.TabIndex = 15;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 120);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(85, 13);
            this.lblBase12.TabIndex = 14;
            this.lblBase12.Text = "Nro. Proceso:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(262, 505);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(324, 505);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(9, 300);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(132, 13);
            this.lblBase14.TabIndex = 13;
            this.lblBase14.Text = "Tipo Persona Ejecuta:";
            // 
            // cboTipoPersonaEjecActProc1
            // 
            this.cboTipoPersonaEjecActProc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersonaEjecActProc1.FormattingEnabled = true;
            this.cboTipoPersonaEjecActProc1.Location = new System.Drawing.Point(143, 297);
            this.cboTipoPersonaEjecActProc1.Name = "cboTipoPersonaEjecActProc1";
            this.cboTipoPersonaEjecActProc1.Size = new System.Drawing.Size(397, 21);
            this.cboTipoPersonaEjecActProc1.TabIndex = 14;
            this.cboTipoPersonaEjecActProc1.Leave += new System.EventHandler(this.cboTipoPersonaEjecActProc1_Leave);
            // 
            // frmRegActosProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 590);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtNroProc);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.txtNroExp);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tbcBase1);
            this.Name = "frmRegActosProc";
            this.Text = "Registro de Actos Procesales";
            this.Load += new System.EventHandler(this.frmRegActosProc_Load);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.txtNroExp, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.txtNroProc, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.tbcBase1.ResumeLayout(false);
            this.tabActProc.ResumeLayout(false);
            this.tabActProc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActProc)).EndInit();
            this.tabDatProc.ResumeLayout(false);
            this.tabDatProc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabActProc;
        private System.Windows.Forms.TabPage tabDatProc;
        private GEN.ControlesBase.txtBase txtEncAud;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgActProc;
        private GEN.ControlesBase.txtBase txtDetActProc;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.BotonesBase.btnMiniQuitar btnQuitActProc;
        private GEN.BotonesBase.btnMiniAgregar btnAgrActProc;
        private GEN.ControlesBase.txtBase txtAbogContr;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtNroExp;
        private GEN.ControlesBase.txtBase txtNroProc;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.cboEstProcJud cboEstProcJud;
        private GEN.ControlesBase.cboTipMedJud cboTipMedJud;
        private GEN.ControlesBase.cboTipoProcJud cboTipoProcJud;
        private GEN.ControlesBase.cboAbogado cboAbogado;
        private GEN.ControlesBase.cboSecretario cboSecretario;
        private GEN.ControlesBase.cboJuez cboJuez;
        private GEN.ControlesBase.cboJuzgado cboJuzgado;
        private GEN.ControlesBase.cboAbogado cboEncAud;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboTipoActoProcesal cboTipoActoProcesal1;
        private GEN.ControlesBase.cboTipoPersonaEjecActProc cboTipoPersonaEjecActProc1;
        private GEN.ControlesBase.lblBase lblBase14;
    }
}