namespace CRE.Presentacion
{
    partial class frmCobroCreditosGrupales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobroCreditosGrupales));
            this.tbcCobranza = new GEN.ControlesBase.tbcBase(this.components);
            this.tbpPpg = new System.Windows.Forms.TabPage();
            this.dtgPpg = new GEN.ControlesBase.dtgBase(this.components);
            this.tbpKardex = new System.Windows.Forms.TabPage();
            this.dtgKardex = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.conBusGrupoSol = new GEN.ControlesBase.ConBusGrupoSol();
            this.cboGrupoSolidarioCiclo1 = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.cboTipoGrupoSolidario1 = new GEN.ControlesBase.cboTipoGrupoSolidario(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombreGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdGrupoSolidario = new GEN.ControlesBase.txtNumerico(this.components);
            this.cboGrupoSolidarioCiclo2 = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.cboTipoGrupoSolidario2 = new GEN.ControlesBase.cboTipoGrupoSolidario(this.components);
            this.txtBase4 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase5 = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumerico1 = new GEN.ControlesBase.txtNumerico(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.conSplaf1 = new GEN.ControlesBase.conSplaf();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.txtBase6 = new GEN.ControlesBase.txtBase(this.components);
            this.conCalcVuelto1 = new GEN.ControlesBase.conCalcVuelto();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtBase7 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtBase3 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase29 = new GEN.ControlesBase.lblBase();
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.lblBase25 = new GEN.ControlesBase.lblBase();
            this.cboTipoPago = new GEN.ControlesBase.cboBase(this.components);
            this.conPagoBcos = new GEN.ControlesBase.conPagoBcos();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conDatPerReaOperac = new GEN.ControlesBase.ConDatPerReaOperac();
            this.txtDocIdePerson = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccPerson = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombrePerson = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.tbcCobranza.SuspendLayout();
            this.tbpPpg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPpg)).BeginInit();
            this.tbpKardex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.conBusGrupoSol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.conPagoBcos.SuspendLayout();
            this.conDatPerReaOperac.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcCobranza
            // 
            this.tbcCobranza.Controls.Add(this.tbpPpg);
            this.tbcCobranza.Controls.Add(this.tbpKardex);
            this.tbcCobranza.Location = new System.Drawing.Point(21, 246);
            this.tbcCobranza.Name = "tbcCobranza";
            this.tbcCobranza.SelectedIndex = 0;
            this.tbcCobranza.Size = new System.Drawing.Size(604, 180);
            this.tbcCobranza.TabIndex = 2;
            // 
            // tbpPpg
            // 
            this.tbpPpg.Controls.Add(this.dtgPpg);
            this.tbpPpg.Location = new System.Drawing.Point(4, 22);
            this.tbpPpg.Name = "tbpPpg";
            this.tbpPpg.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPpg.Size = new System.Drawing.Size(596, 154);
            this.tbpPpg.TabIndex = 1;
            this.tbpPpg.Text = "Plan de Pagos";
            this.tbpPpg.UseVisualStyleBackColor = true;
            // 
            // dtgPpg
            // 
            this.dtgPpg.AllowUserToAddRows = false;
            this.dtgPpg.AllowUserToDeleteRows = false;
            this.dtgPpg.AllowUserToResizeColumns = false;
            this.dtgPpg.AllowUserToResizeRows = false;
            this.dtgPpg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgPpg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPpg.Location = new System.Drawing.Point(3, 3);
            this.dtgPpg.MultiSelect = false;
            this.dtgPpg.Name = "dtgPpg";
            this.dtgPpg.ReadOnly = true;
            this.dtgPpg.RowHeadersVisible = false;
            this.dtgPpg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPpg.Size = new System.Drawing.Size(593, 148);
            this.dtgPpg.TabIndex = 0;
            // 
            // tbpKardex
            // 
            this.tbpKardex.Controls.Add(this.dtgKardex);
            this.tbpKardex.Location = new System.Drawing.Point(4, 22);
            this.tbpKardex.Name = "tbpKardex";
            this.tbpKardex.Size = new System.Drawing.Size(596, 154);
            this.tbpKardex.TabIndex = 2;
            this.tbpKardex.Text = "Kardex de Pago";
            this.tbpKardex.UseVisualStyleBackColor = true;
            // 
            // dtgKardex
            // 
            this.dtgKardex.AllowUserToAddRows = false;
            this.dtgKardex.AllowUserToDeleteRows = false;
            this.dtgKardex.AllowUserToResizeColumns = false;
            this.dtgKardex.AllowUserToResizeRows = false;
            this.dtgKardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgKardex.Location = new System.Drawing.Point(4, 4);
            this.dtgKardex.MultiSelect = false;
            this.dtgKardex.Name = "dtgKardex";
            this.dtgKardex.ReadOnly = true;
            this.dtgKardex.RowHeadersVisible = false;
            this.dtgKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgKardex.Size = new System.Drawing.Size(589, 147);
            this.dtgKardex.TabIndex = 0;
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(21, 95);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(604, 145);
            this.dtgBase1.TabIndex = 52;
            this.dtgBase1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellContentClick);
            this.dtgBase1.SelectionChanged += new System.EventHandler(this.dtgBase1_SelectionChanged);
            // 
            // conBusGrupoSol
            // 
            this.conBusGrupoSol.Controls.Add(this.cboGrupoSolidarioCiclo1);
            this.conBusGrupoSol.Controls.Add(this.cboTipoGrupoSolidario1);
            this.conBusGrupoSol.Controls.Add(this.txtDireccion);
            this.conBusGrupoSol.Controls.Add(this.txtNombreGrupo);
            this.conBusGrupoSol.Controls.Add(this.txtIdGrupoSolidario);
            this.conBusGrupoSol.Controls.Add(this.cboGrupoSolidarioCiclo2);
            this.conBusGrupoSol.Controls.Add(this.cboTipoGrupoSolidario2);
            this.conBusGrupoSol.Controls.Add(this.txtBase4);
            this.conBusGrupoSol.Controls.Add(this.txtBase5);
            this.conBusGrupoSol.Controls.Add(this.txtNumerico1);
            this.conBusGrupoSol.Location = new System.Drawing.Point(12, 16);
            this.conBusGrupoSol.Name = "conBusGrupoSol";
            this.conBusGrupoSol.Size = new System.Drawing.Size(613, 73);
            this.conBusGrupoSol.TabIndex = 51;
            this.conBusGrupoSol.ClicBuscar += new System.EventHandler(this.conBusGrupoSol_ClicBuscar_2);
            // 
            // cboGrupoSolidarioCiclo1
            // 
            this.cboGrupoSolidarioCiclo1.DisplayMember = "cDescripcion";
            this.cboGrupoSolidarioCiclo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoSolidarioCiclo1.Enabled = false;
            this.cboGrupoSolidarioCiclo1.FormattingEnabled = true;
            this.cboGrupoSolidarioCiclo1.Location = new System.Drawing.Point(64, 49);
            this.cboGrupoSolidarioCiclo1.Name = "cboGrupoSolidarioCiclo1";
            this.cboGrupoSolidarioCiclo1.Size = new System.Drawing.Size(121, 21);
            this.cboGrupoSolidarioCiclo1.TabIndex = 19;
            this.cboGrupoSolidarioCiclo1.ValueMember = "idGrupoSolidarioCiclo";
            // 
            // cboTipoGrupoSolidario1
            // 
            this.cboTipoGrupoSolidario1.DisplayMember = "cTipoGrupoSolidario";
            this.cboTipoGrupoSolidario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGrupoSolidario1.Enabled = false;
            this.cboTipoGrupoSolidario1.FormattingEnabled = true;
            this.cboTipoGrupoSolidario1.Location = new System.Drawing.Point(273, 49);
            this.cboTipoGrupoSolidario1.Name = "cboTipoGrupoSolidario1";
            this.cboTipoGrupoSolidario1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoGrupoSolidario1.TabIndex = 17;
            this.cboTipoGrupoSolidario1.ValueMember = "idTipoGrupoSolidario";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(64, 26);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(483, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Enabled = false;
            this.txtNombreGrupo.Location = new System.Drawing.Point(133, 4);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(414, 20);
            this.txtNombreGrupo.TabIndex = 1;
            // 
            // txtIdGrupoSolidario
            // 
            this.txtIdGrupoSolidario.Enabled = false;
            this.txtIdGrupoSolidario.Format = "n2";
            this.txtIdGrupoSolidario.Location = new System.Drawing.Point(64, 4);
            this.txtIdGrupoSolidario.Name = "txtIdGrupoSolidario";
            this.txtIdGrupoSolidario.Size = new System.Drawing.Size(70, 20);
            this.txtIdGrupoSolidario.TabIndex = 0;
            this.txtIdGrupoSolidario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboGrupoSolidarioCiclo2
            // 
            this.cboGrupoSolidarioCiclo2.DisplayMember = "cDescripcion";
            this.cboGrupoSolidarioCiclo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoSolidarioCiclo2.Enabled = false;
            this.cboGrupoSolidarioCiclo2.FormattingEnabled = true;
            this.cboGrupoSolidarioCiclo2.Location = new System.Drawing.Point(64, 49);
            this.cboGrupoSolidarioCiclo2.Name = "cboGrupoSolidarioCiclo2";
            this.cboGrupoSolidarioCiclo2.Size = new System.Drawing.Size(121, 21);
            this.cboGrupoSolidarioCiclo2.TabIndex = 19;
            this.cboGrupoSolidarioCiclo2.ValueMember = "idGrupoSolidarioCiclo";
            // 
            // cboTipoGrupoSolidario2
            // 
            this.cboTipoGrupoSolidario2.DisplayMember = "cTipoGrupoSolidario";
            this.cboTipoGrupoSolidario2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGrupoSolidario2.Enabled = false;
            this.cboTipoGrupoSolidario2.FormattingEnabled = true;
            this.cboTipoGrupoSolidario2.Location = new System.Drawing.Point(273, 49);
            this.cboTipoGrupoSolidario2.Name = "cboTipoGrupoSolidario2";
            this.cboTipoGrupoSolidario2.Size = new System.Drawing.Size(121, 21);
            this.cboTipoGrupoSolidario2.TabIndex = 17;
            this.cboTipoGrupoSolidario2.ValueMember = "idTipoGrupoSolidario";
            // 
            // txtBase4
            // 
            this.txtBase4.Enabled = false;
            this.txtBase4.Location = new System.Drawing.Point(64, 26);
            this.txtBase4.Name = "txtBase4";
            this.txtBase4.Size = new System.Drawing.Size(483, 20);
            this.txtBase4.TabIndex = 2;
            // 
            // txtBase5
            // 
            this.txtBase5.Enabled = false;
            this.txtBase5.Location = new System.Drawing.Point(133, 4);
            this.txtBase5.Name = "txtBase5";
            this.txtBase5.Size = new System.Drawing.Size(414, 20);
            this.txtBase5.TabIndex = 1;
            // 
            // txtNumerico1
            // 
            this.txtNumerico1.Enabled = false;
            this.txtNumerico1.Format = "n2";
            this.txtNumerico1.Location = new System.Drawing.Point(64, 4);
            this.txtNumerico1.Name = "txtNumerico1";
            this.txtNumerico1.Size = new System.Drawing.Size(70, 20);
            this.txtNumerico1.TabIndex = 0;
            this.txtNumerico1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(483, 246);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 17);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "Pagar todos los créditos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // conSplaf1
            // 
            this.conSplaf1.AutoSize = true;
            this.conSplaf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.conSplaf1.ForeColor = System.Drawing.Color.Red;
            this.conSplaf1.Location = new System.Drawing.Point(590, 295);
            this.conSplaf1.Name = "conSplaf1";
            this.conSplaf1.Size = new System.Drawing.Size(0, 20);
            this.conSplaf1.TabIndex = 68;
            // 
            // btnSalir1
            // 
            this.btnSalir1.AutoSize = true;
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(509, 130);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 72;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.AutoSize = true;
            this.btnCancelar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(443, 130);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 71;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.AutoSize = true;
            this.btnGrabar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(377, 130);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 70;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtBase6
            // 
            this.txtBase6.Location = new System.Drawing.Point(433, 35);
            this.txtBase6.Name = "txtBase6";
            this.txtBase6.Size = new System.Drawing.Size(100, 20);
            this.txtBase6.TabIndex = 74;
            // 
            // conCalcVuelto1
            // 
            this.conCalcVuelto1.Location = new System.Drawing.Point(346, 58);
            this.conCalcVuelto1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.conCalcVuelto1.Name = "conCalcVuelto1";
            this.conCalcVuelto1.Size = new System.Drawing.Size(192, 55);
            this.conCalcVuelto1.TabIndex = 69;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase6);
            this.groupBox1.Controls.Add(this.txtBase7);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.txtBase3);
            this.groupBox1.Controls.Add(this.lblBase29);
            this.groupBox1.Controls.Add(this.cboMotivoOperacion);
            this.groupBox1.Controls.Add(this.lblBase25);
            this.groupBox1.Controls.Add(this.cboTipoPago);
            this.groupBox1.Controls.Add(this.conPagoBcos);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.txtBase2);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.txtBase1);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.conCalcVuelto1);
            this.groupBox1.Controls.Add(this.txtBase6);
            this.groupBox1.Controls.Add(this.btnSalir1);
            this.groupBox1.Controls.Add(this.btnGrabar1);
            this.groupBox1.Controls.Add(this.btnCancelar1);
            this.groupBox1.Location = new System.Drawing.Point(21, 522);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 205);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 19);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(89, 13);
            this.lblBase6.TabIndex = 88;
            this.lblBase6.Text = "MONTO NETO:";
            // 
            // txtBase7
            // 
            this.txtBase7.Enabled = false;
            this.txtBase7.Location = new System.Drawing.Point(9, 35);
            this.txtBase7.Name = "txtBase7";
            this.txtBase7.Size = new System.Drawing.Size(100, 20);
            this.txtBase7.TabIndex = 87;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(218, 19);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(78, 13);
            this.lblBase5.TabIndex = 86;
            this.lblBase5.Text = "REDONDEO:";
            // 
            // txtBase3
            // 
            this.txtBase3.Enabled = false;
            this.txtBase3.Location = new System.Drawing.Point(221, 35);
            this.txtBase3.Name = "txtBase3";
            this.txtBase3.Size = new System.Drawing.Size(100, 20);
            this.txtBase3.TabIndex = 85;
            // 
            // lblBase29
            // 
            this.lblBase29.AutoSize = true;
            this.lblBase29.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase29.ForeColor = System.Drawing.Color.Navy;
            this.lblBase29.Location = new System.Drawing.Point(11, 63);
            this.lblBase29.Name = "lblBase29";
            this.lblBase29.Size = new System.Drawing.Size(98, 13);
            this.lblBase29.TabIndex = 84;
            this.lblBase29.Text = "Mot. Operación:";
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoOperacion.Enabled = false;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(113, 60);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(173, 21);
            this.cboMotivoOperacion.TabIndex = 80;
            // 
            // lblBase25
            // 
            this.lblBase25.AutoSize = true;
            this.lblBase25.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase25.ForeColor = System.Drawing.Color.Navy;
            this.lblBase25.Location = new System.Drawing.Point(11, 87);
            this.lblBase25.Name = "lblBase25";
            this.lblBase25.Size = new System.Drawing.Size(68, 13);
            this.lblBase25.TabIndex = 83;
            this.lblBase25.Text = "Tipo pago:";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.Enabled = false;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(113, 83);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(173, 21);
            this.cboTipoPago.TabIndex = 81;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // conPagoBcos
            // 
            this.conPagoBcos.AutoSize = true;
            this.conPagoBcos.Controls.Add(this.grbBase1);
            this.conPagoBcos.Location = new System.Drawing.Point(14, 107);
            this.conPagoBcos.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.conPagoBcos.Name = "conPagoBcos";
            this.conPagoBcos.Size = new System.Drawing.Size(259, 96);
            this.conPagoBcos.TabIndex = 82;
            this.conPagoBcos.Tag = "";
            this.conPagoBcos.Visible = false;
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(256, 93);
            this.grbBase1.TabIndex = 60;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle Medio de Pago";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(112, 19);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(30, 13);
            this.lblBase4.TabIndex = 79;
            this.lblBase4.Text = "ITF:";
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(115, 35);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(100, 20);
            this.txtBase2.TabIndex = 78;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(324, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(91, 13);
            this.lblBase2.TabIndex = 77;
            this.lblBase2.Text = "MONTO PAGO:";
            // 
            // txtBase1
            // 
            this.txtBase1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase1.Location = new System.Drawing.Point(327, 35);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(100, 20);
            this.txtBase1.TabIndex = 76;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(433, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 75;
            this.lblBase1.Text = "TOTAL A PAGAR:";
            // 
            // conDatPerReaOperac
            // 
            this.conDatPerReaOperac.AutoSize = true;
            this.conDatPerReaOperac.Controls.Add(this.txtDocIdePerson);
            this.conDatPerReaOperac.Controls.Add(this.txtDireccPerson);
            this.conDatPerReaOperac.Controls.Add(this.txtNombrePerson);
            this.conDatPerReaOperac.Location = new System.Drawing.Point(21, 448);
            this.conDatPerReaOperac.Name = "conDatPerReaOperac";
            this.conDatPerReaOperac.Size = new System.Drawing.Size(381, 77);
            this.conDatPerReaOperac.TabIndex = 76;
            // 
            // txtDocIdePerson
            // 
            this.txtDocIdePerson.Location = new System.Drawing.Point(78, 7);
            this.txtDocIdePerson.MaxLength = 15;
            this.txtDocIdePerson.Name = "txtDocIdePerson";
            this.txtDocIdePerson.Size = new System.Drawing.Size(131, 20);
            this.txtDocIdePerson.TabIndex = 0;
            // 
            // txtDireccPerson
            // 
            this.txtDireccPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccPerson.Enabled = false;
            this.txtDireccPerson.Location = new System.Drawing.Point(77, 54);
            this.txtDireccPerson.Name = "txtDireccPerson";
            this.txtDireccPerson.Size = new System.Drawing.Size(299, 20);
            this.txtDireccPerson.TabIndex = 2;
            // 
            // txtNombrePerson
            // 
            this.txtNombrePerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombrePerson.Enabled = false;
            this.txtNombrePerson.Location = new System.Drawing.Point(77, 30);
            this.txtNombrePerson.Name = "txtNombrePerson";
            this.txtNombrePerson.Size = new System.Drawing.Size(299, 20);
            this.txtNombrePerson.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(27, 432);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(117, 13);
            this.lblBase3.TabIndex = 77;
            this.lblBase3.Text = "Datos del Pagador:";
            // 
            // frmCobroCreditosGrupales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 760);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.conDatPerReaOperac);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.conSplaf1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbcCobranza);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.conBusGrupoSol);
            this.Name = "frmCobroCreditosGrupales";
            this.Text = "Cobro de Créditos Grupales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCobroCreditosGrupales_FormClosing);
            this.Load += new System.EventHandler(this.frmCobroCreditosGrupales_Load);
            this.Controls.SetChildIndex(this.conBusGrupoSol, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.tbcCobranza, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.conSplaf1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.conDatPerReaOperac, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.tbcCobranza.ResumeLayout(false);
            this.tbpPpg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPpg)).EndInit();
            this.tbpKardex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgKardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.conBusGrupoSol.ResumeLayout(false);
            this.conBusGrupoSol.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.conPagoBcos.ResumeLayout(false);
            this.conDatPerReaOperac.ResumeLayout(false);
            this.conDatPerReaOperac.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcCobranza;
        private System.Windows.Forms.TabPage tbpPpg;
        private GEN.ControlesBase.dtgBase dtgPpg;
        private System.Windows.Forms.TabPage tbpKardex;
        private GEN.ControlesBase.dtgBase dtgKardex;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboGrupoSolidarioCiclo1;
        private GEN.ControlesBase.cboTipoGrupoSolidario cboTipoGrupoSolidario1;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtNombreGrupo;
        private GEN.ControlesBase.txtNumerico txtIdGrupoSolidario;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboGrupoSolidarioCiclo2;
        private GEN.ControlesBase.cboTipoGrupoSolidario cboTipoGrupoSolidario2;
        private GEN.ControlesBase.txtBase txtBase4;
        private GEN.ControlesBase.txtBase txtBase5;
        private GEN.ControlesBase.txtNumerico txtNumerico1;
        private System.Windows.Forms.CheckBox checkBox1;
        private GEN.ControlesBase.conSplaf conSplaf1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtBase txtBase6;
        private GEN.ControlesBase.conCalcVuelto conCalcVuelto1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.ConDatPerReaOperac conDatPerReaOperac;
        private GEN.ControlesBase.txtBase txtDocIdePerson;
        private GEN.ControlesBase.txtBase txtDireccPerson;
        private GEN.ControlesBase.txtBase txtNombrePerson;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.lblBase lblBase29;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;
        private GEN.ControlesBase.lblBase lblBase25;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private GEN.ControlesBase.conPagoBcos conPagoBcos;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtBase7;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtBase3;

    }
}