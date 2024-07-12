namespace CRE.Presentacion
{
    partial class frmGrupoSolidarioBono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolidarioBono));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.gbxSolicitudExcepcion = new System.Windows.Forms.GroupBox();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtFechaSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.btnSolicitar = new GEN.BotonesBase.btnSolicitar();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtJustificacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.pgbProbabilidadBono = new System.Windows.Forms.ProgressBar();
            this.nudPromedioMeses = new GEN.ControlesBase.nudBase(this.components);
            this.nudPromedioAtraso = new GEN.ControlesBase.nudBase(this.components);
            this.nudMaxAtraso = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.nudBonoTotal = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.nudProbabilidadBono = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgBonoEstimado = new GEN.ControlesBase.dtgBase(this.components);
            this.gbxBuscador = new System.Windows.Forms.GroupBox();
            this.conBusGrupoSol = new GEN.ControlesBase.ConBusGrupoSol();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.sstFormularioNombre = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsstNombreFormulario = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbxSolicitudExcepcion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPromedioMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPromedioAtraso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAtraso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonoTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProbabilidadBono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBonoEstimado)).BeginInit();
            this.gbxBuscador.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sstFormularioNombre.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(957, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbxSolicitudExcepcion
            // 
            this.gbxSolicitudExcepcion.Controls.Add(this.txtEstado);
            this.gbxSolicitudExcepcion.Controls.Add(this.lblBase7);
            this.gbxSolicitudExcepcion.Controls.Add(this.txtFechaSolicitud);
            this.gbxSolicitudExcepcion.Controls.Add(this.btnSolicitar);
            this.gbxSolicitudExcepcion.Controls.Add(this.lblBase9);
            this.gbxSolicitudExcepcion.Controls.Add(this.txtJustificacion);
            this.gbxSolicitudExcepcion.Controls.Add(this.lblBase8);
            this.gbxSolicitudExcepcion.Location = new System.Drawing.Point(3, 428);
            this.gbxSolicitudExcepcion.Name = "gbxSolicitudExcepcion";
            this.gbxSolicitudExcepcion.Size = new System.Drawing.Size(1020, 100);
            this.gbxSolicitudExcepcion.TabIndex = 4;
            this.gbxSolicitudExcepcion.TabStop = false;
            this.gbxSolicitudExcepcion.Text = "Solicitud de excepción";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Info;
            this.txtEstado.Location = new System.Drawing.Point(544, 70);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(149, 20);
            this.txtEstado.TabIndex = 9;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(182, 12);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(166, 13);
            this.lblBase7.TabIndex = 5;
            this.lblBase7.Text = "Justificación para excepción";
            // 
            // txtFechaSolicitud
            // 
            this.txtFechaSolicitud.BackColor = System.Drawing.SystemColors.Info;
            this.txtFechaSolicitud.Location = new System.Drawing.Point(544, 31);
            this.txtFechaSolicitud.Name = "txtFechaSolicitud";
            this.txtFechaSolicitud.ReadOnly = true;
            this.txtFechaSolicitud.Size = new System.Drawing.Size(149, 20);
            this.txtFechaSolicitud.TabIndex = 8;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolicitar.BackgroundImage")));
            this.btnSolicitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolicitar.Location = new System.Drawing.Point(699, 32);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(60, 50);
            this.btnSolicitar.TabIndex = 3;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolicitar.UseVisualStyleBackColor = true;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(567, 54);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(97, 13);
            this.lblBase9.TabIndex = 7;
            this.lblBase9.Text = "Estado Solicitud";
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(6, 28);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(524, 61);
            this.txtJustificacion.TabIndex = 4;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(561, 12);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(110, 13);
            this.lblBase8.TabIndex = 6;
            this.lblBase8.Text = "Fecha de Solicitud";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMensaje);
            this.groupBox2.Controls.Add(this.nudPromedioMeses);
            this.groupBox2.Controls.Add(this.nudPromedioAtraso);
            this.groupBox2.Controls.Add(this.nudMaxAtraso);
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Controls.Add(this.nudBonoTotal);
            this.groupBox2.Controls.Add(this.lblBase2);
            this.groupBox2.Controls.Add(this.dtgBonoEstimado);
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 323);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bonos estimados a la fecha";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensaje.Location = new System.Drawing.Point(15, 25);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(54, 13);
            this.lblMensaje.TabIndex = 13;
            this.lblMensaje.Text = "* Mensaje";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(608, 18);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(19, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "%";
            this.lblBase6.Visible = false;
            // 
            // pgbProbabilidadBono
            // 
            this.pgbProbabilidadBono.Location = new System.Drawing.Point(185, 15);
            this.pgbProbabilidadBono.Name = "pgbProbabilidadBono";
            this.pgbProbabilidadBono.Size = new System.Drawing.Size(357, 20);
            this.pgbProbabilidadBono.TabIndex = 11;
            this.pgbProbabilidadBono.Visible = false;
            // 
            // nudPromedioMeses
            // 
            this.nudPromedioMeses.BackColor = System.Drawing.SystemColors.Info;
            this.nudPromedioMeses.DecimalPlaces = 2;
            this.nudPromedioMeses.Enabled = false;
            this.nudPromedioMeses.Location = new System.Drawing.Point(531, 41);
            this.nudPromedioMeses.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPromedioMeses.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPromedioMeses.Name = "nudPromedioMeses";
            this.nudPromedioMeses.ReadOnly = true;
            this.nudPromedioMeses.Size = new System.Drawing.Size(86, 20);
            this.nudPromedioMeses.TabIndex = 10;
            this.nudPromedioMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudPromedioAtraso
            // 
            this.nudPromedioAtraso.BackColor = System.Drawing.SystemColors.Info;
            this.nudPromedioAtraso.DecimalPlaces = 2;
            this.nudPromedioAtraso.Enabled = false;
            this.nudPromedioAtraso.Location = new System.Drawing.Point(736, 41);
            this.nudPromedioAtraso.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPromedioAtraso.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPromedioAtraso.Name = "nudPromedioAtraso";
            this.nudPromedioAtraso.ReadOnly = true;
            this.nudPromedioAtraso.Size = new System.Drawing.Size(86, 20);
            this.nudPromedioAtraso.TabIndex = 9;
            this.nudPromedioAtraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudMaxAtraso
            // 
            this.nudMaxAtraso.BackColor = System.Drawing.SystemColors.Info;
            this.nudMaxAtraso.DecimalPlaces = 2;
            this.nudMaxAtraso.Enabled = false;
            this.nudMaxAtraso.Location = new System.Drawing.Point(328, 41);
            this.nudMaxAtraso.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxAtraso.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudMaxAtraso.Name = "nudMaxAtraso";
            this.nudMaxAtraso.ReadOnly = true;
            this.nudMaxAtraso.Size = new System.Drawing.Size(86, 20);
            this.nudMaxAtraso.TabIndex = 8;
            this.nudMaxAtraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(420, 45);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(105, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Promedio Meses:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(623, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(107, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Promedio Atraso:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(242, 45);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Max. Atraso:";
            // 
            // nudBonoTotal
            // 
            this.nudBonoTotal.BackColor = System.Drawing.SystemColors.Info;
            this.nudBonoTotal.DecimalPlaces = 2;
            this.nudBonoTotal.Enabled = false;
            this.nudBonoTotal.Location = new System.Drawing.Point(931, 41);
            this.nudBonoTotal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBonoTotal.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudBonoTotal.Name = "nudBonoTotal";
            this.nudBonoTotal.ReadOnly = true;
            this.nudBonoTotal.Size = new System.Drawing.Size(86, 20);
            this.nudBonoTotal.TabIndex = 4;
            this.nudBonoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(828, 45);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(97, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Bono total (S/):";
            // 
            // nudProbabilidadBono
            // 
            this.nudProbabilidadBono.BackColor = System.Drawing.SystemColors.Info;
            this.nudProbabilidadBono.DecimalPlaces = 2;
            this.nudProbabilidadBono.Enabled = false;
            this.nudProbabilidadBono.Location = new System.Drawing.Point(544, 15);
            this.nudProbabilidadBono.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudProbabilidadBono.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudProbabilidadBono.Name = "nudProbabilidadBono";
            this.nudProbabilidadBono.ReadOnly = true;
            this.nudProbabilidadBono.Size = new System.Drawing.Size(61, 20);
            this.nudProbabilidadBono.TabIndex = 2;
            this.nudProbabilidadBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudProbabilidadBono.Visible = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(171, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Probabilidad de bonificación:";
            this.lblBase1.Visible = false;
            // 
            // dtgBonoEstimado
            // 
            this.dtgBonoEstimado.AllowUserToAddRows = false;
            this.dtgBonoEstimado.AllowUserToDeleteRows = false;
            this.dtgBonoEstimado.AllowUserToResizeColumns = false;
            this.dtgBonoEstimado.AllowUserToResizeRows = false;
            this.dtgBonoEstimado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBonoEstimado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBonoEstimado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgBonoEstimado.Location = new System.Drawing.Point(3, 63);
            this.dtgBonoEstimado.MultiSelect = false;
            this.dtgBonoEstimado.Name = "dtgBonoEstimado";
            this.dtgBonoEstimado.ReadOnly = true;
            this.dtgBonoEstimado.RowHeadersVisible = false;
            this.dtgBonoEstimado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBonoEstimado.Size = new System.Drawing.Size(1014, 257);
            this.dtgBonoEstimado.TabIndex = 0;
            // 
            // gbxBuscador
            // 
            this.gbxBuscador.Controls.Add(this.conBusGrupoSol);
            this.gbxBuscador.Location = new System.Drawing.Point(3, 3);
            this.gbxBuscador.Name = "gbxBuscador";
            this.gbxBuscador.Size = new System.Drawing.Size(1020, 90);
            this.gbxBuscador.TabIndex = 0;
            this.gbxBuscador.TabStop = false;
            this.gbxBuscador.Text = "Buscador de grupo solidario";
            // 
            // conBusGrupoSol
            // 
            this.conBusGrupoSol.Location = new System.Drawing.Point(6, 12);
            this.conBusGrupoSol.Name = "conBusGrupoSol";
            this.conBusGrupoSol.Size = new System.Drawing.Size(613, 73);
            this.conBusGrupoSol.TabIndex = 0;
            this.conBusGrupoSol.ClicBuscar += new System.EventHandler(this.conBusGrupoSol_ClicBuscar);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 595F));
            this.tableLayoutPanel1.Controls.Add(this.gbxBuscador, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbxSolicitudExcepcion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 329F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1026, 613);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.lblBase6);
            this.panel1.Controls.Add(this.sstFormularioNombre);
            this.panel1.Controls.Add(this.pgbProbabilidadBono);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.nudProbabilidadBono);
            this.panel1.Location = new System.Drawing.Point(3, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 76);
            this.panel1.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(879, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // sstFormularioNombre
            // 
            this.sstFormularioNombre.BackColor = System.Drawing.Color.Green;
            this.sstFormularioNombre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsstNombreFormulario});
            this.sstFormularioNombre.Location = new System.Drawing.Point(0, 54);
            this.sstFormularioNombre.Name = "sstFormularioNombre";
            this.sstFormularioNombre.Size = new System.Drawing.Size(1020, 22);
            this.sstFormularioNombre.TabIndex = 3;
            this.sstFormularioNombre.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(943, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // tsstNombreFormulario
            // 
            this.tsstNombreFormulario.Name = "tsstNombreFormulario";
            this.tsstNombreFormulario.Size = new System.Drawing.Size(62, 17);
            this.tsstNombreFormulario.Text = "NomForm";
            // 
            // frmGrupoSolidarioBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1028, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGrupoSolidarioBono";
            this.Text = "Bono de Grupo Solidario";
            this.Shown += new System.EventHandler(this.frmGrupoSolidarioBono_Shown);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.gbxSolicitudExcepcion.ResumeLayout(false);
            this.gbxSolicitudExcepcion.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPromedioMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPromedioAtraso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAtraso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonoTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProbabilidadBono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBonoEstimado)).EndInit();
            this.gbxBuscador.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sstFormularioNombre.ResumeLayout(false);
            this.sstFormularioNombre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxBuscador;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgBonoEstimado;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol;
        private GEN.ControlesBase.nudBase nudBonoTotal;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.nudBase nudProbabilidadBono;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase nudPromedioMeses;
        private GEN.ControlesBase.nudBase nudPromedioAtraso;
        private GEN.ControlesBase.nudBase nudMaxAtraso;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.ProgressBar pgbProbabilidadBono;
        private System.Windows.Forms.Label lblMensaje;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.GroupBox gbxSolicitudExcepcion;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtFechaSolicitud;
        private GEN.BotonesBase.btnSolicitar btnSolicitar;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtJustificacion;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.StatusStrip sstFormularioNombre;
        protected System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        protected System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        protected System.Windows.Forms.ToolStripStatusLabel tsstNombreFormulario;
        private GEN.BotonesBase.btnCancelar btnCancelar;
    }
}