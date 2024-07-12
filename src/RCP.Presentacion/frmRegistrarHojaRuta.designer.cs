using EntityLayer;
using GEN.CapaNegocio;
namespace RCP.Presentacion
{
    partial class frmRegistrarHojaRuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarHojaRuta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKilometrajeInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.DatePicker();
            this.dtpFechaInicio = new GEN.ControlesBase.DatePicker();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.btnBlanco1 = new GEN.BotonesBase.btnBlanco();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cboTipoIntervCre1 = new GEN.ControlesBase.cboTipoIntervCre(this.components);
            this.chbTodosIntervinientes = new System.Windows.Forms.CheckBox();
            this.btnConsultar1 = new GEN.BotonesBase.btnConsultar();
            this.chbDireccionPrincipal = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtAtrazoMax = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAtrazoMin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSaldoCapitalMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSaldoCapitalMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtgCarteraCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtgHojaRuta = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnAgregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idDetalleHojaRutaCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idIntervCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDirPrincipal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lDireccionRecuperaCre = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDistrito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAnexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idDetalleHojaRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idIntervCreHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDireccionHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalPagarhr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuentaHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencionHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDirHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDirPrincipalHR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lDireccionRecupera = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDireccionHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtrasoHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimboloHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapitalHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUbigeoHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacionHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAnexoHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDistritoHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProvinciaHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartamentoHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoIntervHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.grbFiltros.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraCreditos)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHojaRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKilometrajeInicio);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(15, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales de la Hoja de Ruta";
            // 
            // txtKilometrajeInicio
            // 
            this.txtKilometrajeInicio.Location = new System.Drawing.Point(696, 24);
            this.txtKilometrajeInicio.MaxLength = 6;
            this.txtKilometrajeInicio.Name = "txtKilometrajeInicio";
            this.txtKilometrajeInicio.Size = new System.Drawing.Size(148, 20);
            this.txtKilometrajeInicio.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(370, 24);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(195, 20);
            this.dtpFechaFin.TabIndex = 1;
            this.dtpFechaFin.Value = new System.DateTime(2015, 7, 20, 12, 39, 12, 428);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(94, 24);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(195, 20);
            this.dtpFechaInicio.TabIndex = 0;
            this.dtpFechaInicio.Value = new System.DateTime(2015, 7, 20, 12, 39, 0, 974);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(577, 28);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(113, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Kilometraje Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(299, 28);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.btnBlanco1);
            this.grbFiltros.Controls.Add(this.groupBox8);
            this.grbFiltros.Controls.Add(this.btnConsultar1);
            this.grbFiltros.Controls.Add(this.chbDireccionPrincipal);
            this.grbFiltros.Controls.Add(this.groupBox5);
            this.grbFiltros.Controls.Add(this.groupBox4);
            this.grbFiltros.Controls.Add(this.groupBox3);
            this.grbFiltros.Location = new System.Drawing.Point(15, 67);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(870, 168);
            this.grbFiltros.TabIndex = 2;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros";
            // 
            // btnBlanco1
            // 
            this.btnBlanco1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlanco1.Location = new System.Drawing.Point(793, 75);
            this.btnBlanco1.Name = "btnBlanco1";
            this.btnBlanco1.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco1.TabIndex = 6;
            this.btnBlanco1.Text = "Pendientes";
            this.btnBlanco1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco1.UseVisualStyleBackColor = true;
            this.btnBlanco1.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cboTipoIntervCre1);
            this.groupBox8.Controls.Add(this.chbTodosIntervinientes);
            this.groupBox8.Location = new System.Drawing.Point(470, 115);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(305, 46);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Intervinientes";
            // 
            // cboTipoIntervCre1
            // 
            this.cboTipoIntervCre1.FormattingEnabled = true;
            this.cboTipoIntervCre1.Location = new System.Drawing.Point(14, 16);
            this.cboTipoIntervCre1.Name = "cboTipoIntervCre1";
            this.cboTipoIntervCre1.Size = new System.Drawing.Size(212, 21);
            this.cboTipoIntervCre1.TabIndex = 0;
            // 
            // chbTodosIntervinientes
            // 
            this.chbTodosIntervinientes.AutoSize = true;
            this.chbTodosIntervinientes.Checked = true;
            this.chbTodosIntervinientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTodosIntervinientes.ForeColor = System.Drawing.Color.Navy;
            this.chbTodosIntervinientes.Location = new System.Drawing.Point(244, 18);
            this.chbTodosIntervinientes.Name = "chbTodosIntervinientes";
            this.chbTodosIntervinientes.Size = new System.Drawing.Size(56, 17);
            this.chbTodosIntervinientes.TabIndex = 1;
            this.chbTodosIntervinientes.Text = "Todos";
            this.chbTodosIntervinientes.UseVisualStyleBackColor = true;
            this.chbTodosIntervinientes.CheckedChanged += new System.EventHandler(this.chbTodosIntervinientes_CheckedChanged);
            // 
            // btnConsultar1
            // 
            this.btnConsultar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar1.BackgroundImage")));
            this.btnConsultar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar1.Location = new System.Drawing.Point(793, 19);
            this.btnConsultar1.Name = "btnConsultar1";
            this.btnConsultar1.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar1.TabIndex = 5;
            this.btnConsultar1.Text = "&Consultar";
            this.btnConsultar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar1.UseVisualStyleBackColor = true;
            this.btnConsultar1.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // chbDireccionPrincipal
            // 
            this.chbDireccionPrincipal.AutoSize = true;
            this.chbDireccionPrincipal.Checked = true;
            this.chbDireccionPrincipal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDireccionPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.chbDireccionPrincipal.Location = new System.Drawing.Point(304, 133);
            this.chbDireccionPrincipal.Name = "chbDireccionPrincipal";
            this.chbDireccionPrincipal.Size = new System.Drawing.Size(160, 17);
            this.chbDireccionPrincipal.TabIndex = 3;
            this.chbDireccionPrincipal.Text = "Solo Direcciones Principales";
            this.chbDireccionPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtAtrazoMax);
            this.groupBox5.Controls.Add(this.txtAtrazoMin);
            this.groupBox5.Controls.Add(this.lblBase7);
            this.groupBox5.Controls.Add(this.lblBase8);
            this.groupBox5.Location = new System.Drawing.Point(295, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(480, 46);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Atraso";
            // 
            // txtAtrazoMax
            // 
            this.txtAtrazoMax.Location = new System.Drawing.Point(329, 17);
            this.txtAtrazoMax.Name = "txtAtrazoMax";
            this.txtAtrazoMax.Size = new System.Drawing.Size(132, 20);
            this.txtAtrazoMax.TabIndex = 1;
            // 
            // txtAtrazoMin
            // 
            this.txtAtrazoMin.Location = new System.Drawing.Point(75, 17);
            this.txtAtrazoMin.Name = "txtAtrazoMin";
            this.txtAtrazoMin.Size = new System.Drawing.Size(132, 20);
            this.txtAtrazoMin.TabIndex = 0;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(267, 21);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 3;
            this.lblBase7.Text = "Maximo:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(17, 21);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 2;
            this.lblBase8.Text = "Minimo:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSaldoCapitalMax);
            this.groupBox4.Controls.Add(this.txtSaldoCapitalMin);
            this.groupBox4.Controls.Add(this.lblBase6);
            this.groupBox4.Controls.Add(this.lblBase5);
            this.groupBox4.Location = new System.Drawing.Point(295, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(480, 46);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Saldo Capital:";
            // 
            // txtSaldoCapitalMax
            // 
            this.txtSaldoCapitalMax.FormatoDecimal = false;
            this.txtSaldoCapitalMax.Location = new System.Drawing.Point(329, 17);
            this.txtSaldoCapitalMax.Name = "txtSaldoCapitalMax";
            this.txtSaldoCapitalMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoCapitalMax.nNumDecimales = 4;
            this.txtSaldoCapitalMax.nvalor = 0D;
            this.txtSaldoCapitalMax.Size = new System.Drawing.Size(132, 20);
            this.txtSaldoCapitalMax.TabIndex = 1;
            // 
            // txtSaldoCapitalMin
            // 
            this.txtSaldoCapitalMin.FormatoDecimal = false;
            this.txtSaldoCapitalMin.Location = new System.Drawing.Point(75, 17);
            this.txtSaldoCapitalMin.Name = "txtSaldoCapitalMin";
            this.txtSaldoCapitalMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoCapitalMin.nNumDecimales = 4;
            this.txtSaldoCapitalMin.nvalor = 0D;
            this.txtSaldoCapitalMin.Size = new System.Drawing.Size(132, 20);
            this.txtSaldoCapitalMin.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(267, 21);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(56, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Maximo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(52, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Minimo:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.conBusUbig1);
            this.groupBox3.Location = new System.Drawing.Point(14, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 147);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ubigeo";
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.Color.Transparent;
            this.conBusUbig1.Location = new System.Drawing.Point(23, 12);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 130);
            this.conBusUbig1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtgCarteraCreditos);
            this.groupBox6.Location = new System.Drawing.Point(12, 241);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(873, 180);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cartera";
            // 
            // dtgCarteraCreditos
            // 
            this.dtgCarteraCreditos.AllowUserToAddRows = false;
            this.dtgCarteraCreditos.AllowUserToDeleteRows = false;
            this.dtgCarteraCreditos.AllowUserToResizeColumns = false;
            this.dtgCarteraCreditos.AllowUserToResizeRows = false;
            this.dtgCarteraCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCarteraCreditos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCarteraCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarteraCreditos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnAgregar,
            this.idDetalleHojaRutaCre,
            this.idIntervCre,
            this.idDireccion,
            this.nTotalPagar,
            this.idCli,
            this.idCuenta,
            this.cTipoIntervencion,
            this.cNombre,
            this.cTipoDir,
            this.lDirPrincipal,
            this.lDireccionRecuperaCre,
            this.cDireccion,
            this.nAtraso,
            this.cSimbolo,
            this.nSaldoCapital,
            this.cUbigeo,
            this.cDepartamento,
            this.cProvincia,
            this.cDistrito,
            this.cAnexo,
            this.cObservacion,
            this.idTipoInterv});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCarteraCreditos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCarteraCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCarteraCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCarteraCreditos.MultiSelect = false;
            this.dtgCarteraCreditos.Name = "dtgCarteraCreditos";
            this.dtgCarteraCreditos.ReadOnly = true;
            this.dtgCarteraCreditos.RowHeadersVisible = false;
            this.dtgCarteraCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCarteraCreditos.Size = new System.Drawing.Size(867, 161);
            this.dtgCarteraCreditos.TabIndex = 0;
            this.dtgCarteraCreditos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCarteraCreditos_CellClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtgHojaRuta);
            this.groupBox7.Location = new System.Drawing.Point(12, 427);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(873, 180);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Hoja de Ruta";
            // 
            // dtgHojaRuta
            // 
            this.dtgHojaRuta.AllowUserToAddRows = false;
            this.dtgHojaRuta.AllowUserToDeleteRows = false;
            this.dtgHojaRuta.AllowUserToResizeColumns = false;
            this.dtgHojaRuta.AllowUserToResizeRows = false;
            this.dtgHojaRuta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHojaRuta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgHojaRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHojaRuta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnQuitar,
            this.idDetalleHojaRuta,
            this.idIntervCreHR,
            this.idDireccionHR,
            this.nTotalPagarhr,
            this.idAccion,
            this.cAccion,
            this.idTipoNotificacion,
            this.cTipoNotificacion,
            this.idCliHR,
            this.idCuentaHR,
            this.cTipoIntervencionHR,
            this.cNombreHR,
            this.cTipoDirHR,
            this.lDirPrincipalHR,
            this.lDireccionRecupera,
            this.cDireccionHR,
            this.nAtrasoHR,
            this.cSimboloHR,
            this.nSaldoCapitalHR,
            this.cUbigeoHR,
            this.cObservacionHR,
            this.cAnexoHR,
            this.cDistritoHR,
            this.cProvinciaHR,
            this.cDepartamentoHR,
            this.idTipoIntervHR});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHojaRuta.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgHojaRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHojaRuta.Location = new System.Drawing.Point(3, 16);
            this.dtgHojaRuta.MultiSelect = false;
            this.dtgHojaRuta.Name = "dtgHojaRuta";
            this.dtgHojaRuta.ReadOnly = true;
            this.dtgHojaRuta.RowHeadersVisible = false;
            this.dtgHojaRuta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHojaRuta.Size = new System.Drawing.Size(867, 161);
            this.dtgHojaRuta.TabIndex = 0;
            this.dtgHojaRuta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHojaRuta_CellClick);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(825, 613);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(697, 613);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(633, 613);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 1;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(761, 613);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnAgregar.DataPropertyName = "btnAgregar";
            this.btnAgregar.FillWeight = 20F;
            this.btnAgregar.HeaderText = "Agregar";
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ReadOnly = true;
            this.btnAgregar.Width = 50;
            // 
            // idDetalleHojaRutaCre
            // 
            this.idDetalleHojaRutaCre.DataPropertyName = "idDetalleHojaRuta";
            this.idDetalleHojaRutaCre.HeaderText = "idDetalleHojaRuta";
            this.idDetalleHojaRutaCre.Name = "idDetalleHojaRutaCre";
            this.idDetalleHojaRutaCre.ReadOnly = true;
            this.idDetalleHojaRutaCre.Visible = false;
            // 
            // idIntervCre
            // 
            this.idIntervCre.DataPropertyName = "idIntervCre";
            this.idIntervCre.HeaderText = "idIntervCre";
            this.idIntervCre.Name = "idIntervCre";
            this.idIntervCre.ReadOnly = true;
            this.idIntervCre.Visible = false;
            // 
            // idDireccion
            // 
            this.idDireccion.DataPropertyName = "idDireccion";
            this.idDireccion.HeaderText = "idDireccion";
            this.idDireccion.Name = "idDireccion";
            this.idDireccion.ReadOnly = true;
            this.idDireccion.Visible = false;
            // 
            // nTotalPagar
            // 
            this.nTotalPagar.DataPropertyName = "nTotalPagar";
            this.nTotalPagar.HeaderText = "nTotalPagar";
            this.nTotalPagar.Name = "nTotalPagar";
            this.nTotalPagar.ReadOnly = true;
            this.nTotalPagar.Visible = false;
            // 
            // idCli
            // 
            this.idCli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "Cod. Cliente";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Width = 89;
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Width = 66;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "Tipo Interv";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            this.cTipoIntervencion.Width = 81;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Nombres";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 73;
            // 
            // cTipoDir
            // 
            this.cTipoDir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoDir.DataPropertyName = "cTipoDir";
            this.cTipoDir.HeaderText = "Tipo Dirección";
            this.cTipoDir.Name = "cTipoDir";
            this.cTipoDir.ReadOnly = true;
            this.cTipoDir.Width = 97;
            // 
            // lDirPrincipal
            // 
            this.lDirPrincipal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lDirPrincipal.DataPropertyName = "lDirPrincipal";
            this.lDirPrincipal.HeaderText = "Dir. Princ.";
            this.lDirPrincipal.Name = "lDirPrincipal";
            this.lDirPrincipal.ReadOnly = true;
            this.lDirPrincipal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lDirPrincipal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lDirPrincipal.Width = 77;
            // 
            // lDireccionRecuperaCre
            // 
            this.lDireccionRecuperaCre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lDireccionRecuperaCre.DataPropertyName = "lDireccionRecupera";
            this.lDireccionRecuperaCre.HeaderText = "Dir. Recupera";
            this.lDireccionRecuperaCre.Name = "lDireccionRecuperaCre";
            this.lDireccionRecuperaCre.ReadOnly = true;
            this.lDireccionRecuperaCre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lDireccionRecuperaCre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lDireccionRecuperaCre.Width = 96;
            // 
            // cDireccion
            // 
            this.cDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDireccion.DataPropertyName = "cDireccion";
            this.cDireccion.HeaderText = "Direccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Width = 75;
            // 
            // nAtraso
            // 
            this.nAtraso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtraso.DataPropertyName = "nAtraso";
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            this.nAtraso.Width = 62;
            // 
            // cSimbolo
            // 
            this.cSimbolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSimbolo.DataPropertyName = "cSimbolo";
            this.cSimbolo.HeaderText = "Moneda";
            this.cSimbolo.Name = "cSimbolo";
            this.cSimbolo.ReadOnly = true;
            this.cSimbolo.Width = 71;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            this.nSaldoCapital.Width = 94;
            // 
            // cUbigeo
            // 
            this.cUbigeo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cUbigeo.DataPropertyName = "cUbigeo";
            this.cUbigeo.HeaderText = "Ubigeo";
            this.cUbigeo.Name = "cUbigeo";
            this.cUbigeo.ReadOnly = true;
            this.cUbigeo.Visible = false;
            this.cUbigeo.Width = 65;
            // 
            // cDepartamento
            // 
            this.cDepartamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDepartamento.DataPropertyName = "cDepartamento";
            this.cDepartamento.HeaderText = "Departamento";
            this.cDepartamento.Name = "cDepartamento";
            this.cDepartamento.ReadOnly = true;
            this.cDepartamento.Width = 99;
            // 
            // cProvincia
            // 
            this.cProvincia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cProvincia.DataPropertyName = "cProvincia";
            this.cProvincia.HeaderText = "Provincia";
            this.cProvincia.Name = "cProvincia";
            this.cProvincia.ReadOnly = true;
            this.cProvincia.Width = 75;
            // 
            // cDistrito
            // 
            this.cDistrito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDistrito.DataPropertyName = "cDistrito";
            this.cDistrito.HeaderText = "Distrito";
            this.cDistrito.Name = "cDistrito";
            this.cDistrito.ReadOnly = true;
            this.cDistrito.Width = 64;
            // 
            // cAnexo
            // 
            this.cAnexo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cAnexo.DataPropertyName = "cAnexo";
            this.cAnexo.HeaderText = "Anexo";
            this.cAnexo.Name = "cAnexo";
            this.cAnexo.ReadOnly = true;
            this.cAnexo.Width = 62;
            // 
            // cObservacion
            // 
            this.cObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cObservacion.DataPropertyName = "cObservacion";
            this.cObservacion.HeaderText = "Observación";
            this.cObservacion.Name = "cObservacion";
            this.cObservacion.ReadOnly = true;
            this.cObservacion.Width = 91;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.btnQuitar.DataPropertyName = "btnQuitar";
            this.btnQuitar.HeaderText = "Quitar";
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.ReadOnly = true;
            this.btnQuitar.Width = 41;
            // 
            // idDetalleHojaRuta
            // 
            this.idDetalleHojaRuta.DataPropertyName = "idDetalleHojaRuta";
            this.idDetalleHojaRuta.HeaderText = "idDetalleHojaRuta";
            this.idDetalleHojaRuta.Name = "idDetalleHojaRuta";
            this.idDetalleHojaRuta.ReadOnly = true;
            this.idDetalleHojaRuta.Visible = false;
            // 
            // idIntervCreHR
            // 
            this.idIntervCreHR.DataPropertyName = "idIntervCre";
            this.idIntervCreHR.HeaderText = "idIntervCre";
            this.idIntervCreHR.Name = "idIntervCreHR";
            this.idIntervCreHR.ReadOnly = true;
            this.idIntervCreHR.Visible = false;
            // 
            // idDireccionHR
            // 
            this.idDireccionHR.DataPropertyName = "idDireccion";
            this.idDireccionHR.HeaderText = "idDireccion";
            this.idDireccionHR.Name = "idDireccionHR";
            this.idDireccionHR.ReadOnly = true;
            this.idDireccionHR.Visible = false;
            // 
            // nTotalPagarhr
            // 
            this.nTotalPagarhr.DataPropertyName = "nTotalPagar";
            this.nTotalPagarhr.HeaderText = "nTotalPagar";
            this.nTotalPagarhr.Name = "nTotalPagarhr";
            this.nTotalPagarhr.ReadOnly = true;
            this.nTotalPagarhr.Visible = false;
            // 
            // idAccion
            // 
            this.idAccion.DataPropertyName = "idAccion";
            this.idAccion.HeaderText = "idAccion";
            this.idAccion.Name = "idAccion";
            this.idAccion.ReadOnly = true;
            this.idAccion.Visible = false;
            // 
            // cAccion
            // 
            this.cAccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cAccion.DataPropertyName = "cAccion";
            this.cAccion.HeaderText = "Accion";
            this.cAccion.Name = "cAccion";
            this.cAccion.ReadOnly = true;
            this.cAccion.Width = 63;
            // 
            // idTipoNotificacion
            // 
            this.idTipoNotificacion.DataPropertyName = "idTipoNotificacion";
            this.idTipoNotificacion.HeaderText = "idTipoNotificacion";
            this.idTipoNotificacion.Name = "idTipoNotificacion";
            this.idTipoNotificacion.ReadOnly = true;
            this.idTipoNotificacion.Visible = false;
            // 
            // cTipoNotificacion
            // 
            this.cTipoNotificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoNotificacion.DataPropertyName = "cTipoNotificacion";
            this.cTipoNotificacion.HeaderText = "Notificación";
            this.cTipoNotificacion.Name = "cTipoNotificacion";
            this.cTipoNotificacion.ReadOnly = true;
            this.cTipoNotificacion.Width = 85;
            // 
            // idCliHR
            // 
            this.idCliHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCliHR.DataPropertyName = "idCli";
            this.idCliHR.HeaderText = "Cod. Cliente";
            this.idCliHR.Name = "idCliHR";
            this.idCliHR.ReadOnly = true;
            this.idCliHR.Width = 89;
            // 
            // idCuentaHR
            // 
            this.idCuentaHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuentaHR.DataPropertyName = "idCuenta";
            this.idCuentaHR.HeaderText = "Cuenta";
            this.idCuentaHR.Name = "idCuentaHR";
            this.idCuentaHR.ReadOnly = true;
            this.idCuentaHR.Width = 66;
            // 
            // cTipoIntervencionHR
            // 
            this.cTipoIntervencionHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoIntervencionHR.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencionHR.HeaderText = "Tip Interv";
            this.cTipoIntervencionHR.Name = "cTipoIntervencionHR";
            this.cTipoIntervencionHR.ReadOnly = true;
            this.cTipoIntervencionHR.Width = 75;
            // 
            // cNombreHR
            // 
            this.cNombreHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombreHR.DataPropertyName = "cNombre";
            this.cNombreHR.HeaderText = "Nombres";
            this.cNombreHR.Name = "cNombreHR";
            this.cNombreHR.ReadOnly = true;
            this.cNombreHR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cNombreHR.Width = 73;
            // 
            // cTipoDirHR
            // 
            this.cTipoDirHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoDirHR.DataPropertyName = "cTipoDir";
            this.cTipoDirHR.HeaderText = "Tipo Dirección";
            this.cTipoDirHR.Name = "cTipoDirHR";
            this.cTipoDirHR.ReadOnly = true;
            this.cTipoDirHR.Width = 97;
            // 
            // lDirPrincipalHR
            // 
            this.lDirPrincipalHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lDirPrincipalHR.DataPropertyName = "lDirPrincipal";
            this.lDirPrincipalHR.HeaderText = "Dir. Prin.";
            this.lDirPrincipalHR.Name = "lDirPrincipalHR";
            this.lDirPrincipalHR.ReadOnly = true;
            this.lDirPrincipalHR.Width = 53;
            // 
            // lDireccionRecupera
            // 
            this.lDireccionRecupera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lDireccionRecupera.DataPropertyName = "lDireccionRecupera";
            this.lDireccionRecupera.HeaderText = "Dir. Recupera";
            this.lDireccionRecupera.Name = "lDireccionRecupera";
            this.lDireccionRecupera.ReadOnly = true;
            this.lDireccionRecupera.Width = 77;
            // 
            // cDireccionHR
            // 
            this.cDireccionHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDireccionHR.DataPropertyName = "cDireccion";
            this.cDireccionHR.HeaderText = "Direccion";
            this.cDireccionHR.Name = "cDireccionHR";
            this.cDireccionHR.ReadOnly = true;
            this.cDireccionHR.Width = 75;
            // 
            // nAtrasoHR
            // 
            this.nAtrasoHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtrasoHR.DataPropertyName = "nAtraso";
            this.nAtrasoHR.HeaderText = "Atraso";
            this.nAtrasoHR.Name = "nAtrasoHR";
            this.nAtrasoHR.ReadOnly = true;
            this.nAtrasoHR.Width = 62;
            // 
            // cSimboloHR
            // 
            this.cSimboloHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSimboloHR.DataPropertyName = "cSimbolo";
            this.cSimboloHR.HeaderText = "Moneda";
            this.cSimboloHR.Name = "cSimboloHR";
            this.cSimboloHR.ReadOnly = true;
            this.cSimboloHR.Width = 71;
            // 
            // nSaldoCapitalHR
            // 
            this.nSaldoCapitalHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapitalHR.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapitalHR.HeaderText = "Saldo Capital";
            this.nSaldoCapitalHR.Name = "nSaldoCapitalHR";
            this.nSaldoCapitalHR.ReadOnly = true;
            this.nSaldoCapitalHR.Width = 94;
            // 
            // cUbigeoHR
            // 
            this.cUbigeoHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cUbigeoHR.DataPropertyName = "cUbigeo";
            this.cUbigeoHR.HeaderText = "Ubigeo";
            this.cUbigeoHR.Name = "cUbigeoHR";
            this.cUbigeoHR.ReadOnly = true;
            this.cUbigeoHR.Visible = false;
            this.cUbigeoHR.Width = 65;
            // 
            // cObservacionHR
            // 
            this.cObservacionHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cObservacionHR.DataPropertyName = "cObservacion";
            this.cObservacionHR.HeaderText = "Observación";
            this.cObservacionHR.Name = "cObservacionHR";
            this.cObservacionHR.ReadOnly = true;
            this.cObservacionHR.Width = 91;
            // 
            // cAnexoHR
            // 
            this.cAnexoHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cAnexoHR.DataPropertyName = "cAnexo";
            this.cAnexoHR.HeaderText = "Anexo";
            this.cAnexoHR.Name = "cAnexoHR";
            this.cAnexoHR.ReadOnly = true;
            this.cAnexoHR.Width = 62;
            // 
            // cDistritoHR
            // 
            this.cDistritoHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDistritoHR.DataPropertyName = "cDistrito";
            this.cDistritoHR.HeaderText = "Distrito";
            this.cDistritoHR.Name = "cDistritoHR";
            this.cDistritoHR.ReadOnly = true;
            this.cDistritoHR.Width = 64;
            // 
            // cProvinciaHR
            // 
            this.cProvinciaHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cProvinciaHR.DataPropertyName = "cProvincia";
            this.cProvinciaHR.HeaderText = "Provincia";
            this.cProvinciaHR.Name = "cProvinciaHR";
            this.cProvinciaHR.ReadOnly = true;
            this.cProvinciaHR.Width = 75;
            // 
            // cDepartamentoHR
            // 
            this.cDepartamentoHR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDepartamentoHR.DataPropertyName = "cDepartamento";
            this.cDepartamentoHR.HeaderText = "Departamento";
            this.cDepartamentoHR.Name = "cDepartamentoHR";
            this.cDepartamentoHR.ReadOnly = true;
            this.cDepartamentoHR.Width = 99;
            // 
            // idTipoIntervHR
            // 
            this.idTipoIntervHR.DataPropertyName = "idTipoInterv";
            this.idTipoIntervHR.HeaderText = "idTipoInterv";
            this.idTipoIntervHR.Name = "idTipoIntervHR";
            this.idTipoIntervHR.ReadOnly = true;
            this.idTipoIntervHR.Visible = false;
            // 
            // frmRegistrarHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 692);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRegistrarHojaRuta";
            this.Text = "Registrar Hoja de Ruta";
            this.Load += new System.EventHandler(this.frmRegistrarHojaRuta_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grbFiltros, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.groupBox7, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraCreditos)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHojaRuta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBNumerosEnteros txtKilometrajeInicio;
        private GEN.ControlesBase.DatePicker dtpFechaFin;
        private GEN.ControlesBase.DatePicker dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.GroupBox grbFiltros;
        private GEN.BotonesBase.btnConsultar btnConsultar1;
        private System.Windows.Forms.GroupBox groupBox5;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrazoMax;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrazoMin;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.GroupBox groupBox4;
        private GEN.ControlesBase.txtNumRea txtSaldoCapitalMax;
        private GEN.ControlesBase.txtNumRea txtSaldoCapitalMin;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.GroupBox groupBox3;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.GroupBox groupBox6;
        private GEN.ControlesBase.dtgBase dtgCarteraCreditos;
        private System.Windows.Forms.GroupBox groupBox7;
        private GEN.ControlesBase.dtgBase dtgHojaRuta;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnBlanco btnBlanco1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox chbTodosIntervinientes;
        private System.Windows.Forms.CheckBox chbDireccionPrincipal;
        private GEN.ControlesBase.cboTipoIntervCre cboTipoIntervCre1;
        private System.Windows.Forms.DataGridViewButtonColumn btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleHojaRutaCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIntervCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDirPrincipal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDireccionRecuperaCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDistrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAnexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewButtonColumn btnQuitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleHojaRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIntervCreHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDireccionHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalPagarhr;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoNotificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoNotificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuentaHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencionHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDirHR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDirPrincipalHR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDireccionRecupera;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccionHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtrasoHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimboloHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapitalHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUbigeoHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacionHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAnexoHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDistritoHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProvinciaHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartamentoHR;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoIntervHR;
    }
}