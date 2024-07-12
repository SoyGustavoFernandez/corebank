namespace CRE.Presentacion
{
    partial class frmGrupoSolidarioDesembolso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolidarioDesembolso));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.conBusGrupoSol = new GEN.ControlesBase.ConBusGrupoSol();
            this.cboGrupoSolidarioCiclo1 = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.cboTipoGrupoSolidario1 = new GEN.ControlesBase.cboTipoGrupoSolidario(this.components);
            this.txtNombreGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdGrupoSolidario = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlMensaje = new System.Windows.Forms.Panel();
            this.lblClienteProcesado = new System.Windows.Forms.Label();
            this.lblMensajeProceso = new System.Windows.Forms.Label();
            this.lblModalidadDes = new System.Windows.Forms.Label();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblFechaSolicitud = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblFechaProg = new System.Windows.Forms.Label();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMontoTotal = new GEN.ControlesBase.txtBase(this.components);
            this.gbxITF = new System.Windows.Forms.GroupBox();
            this.rbtItfNo = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtRestarItfSi = new GEN.ControlesBase.rbtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgDesembolsoSolicitud = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDepositar = new GEN.BotonesBase.btnDepositar();
            this.btnBloquear = new GEN.BotonesBase.btnBloquear();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEjecutar = new GEN.BotonesBase.btnEjecutar();
            this.conSplaf = new GEN.ControlesBase.conSplaf();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.conBusGrupoSol.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlMensaje.SuspendLayout();
            this.gbxITF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDesembolsoSolicitud)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.0524F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.9476F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(838, 515);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.conBusGrupoSol);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de grupo solidario";
            // 
            // conBusGrupoSol
            // 
            this.conBusGrupoSol.Controls.Add(this.cboGrupoSolidarioCiclo1);
            this.conBusGrupoSol.Controls.Add(this.cboTipoGrupoSolidario1);
            this.conBusGrupoSol.Controls.Add(this.txtNombreGrupo);
            this.conBusGrupoSol.Controls.Add(this.txtIdGrupoSolidario);
            this.conBusGrupoSol.Location = new System.Drawing.Point(6, 15);
            this.conBusGrupoSol.Name = "conBusGrupoSol";
            this.conBusGrupoSol.Size = new System.Drawing.Size(613, 73);
            this.conBusGrupoSol.TabIndex = 1;
            this.conBusGrupoSol.ClicBuscar += new System.EventHandler(this.conBusGrupoSol_ClicBuscar);
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
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(87, 41);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(483, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlMensaje);
            this.groupBox2.Controls.Add(this.lblModalidadDes);
            this.groupBox2.Controls.Add(this.lblBase6);
            this.groupBox2.Controls.Add(this.lblFechaSolicitud);
            this.groupBox2.Controls.Add(this.lblMoneda);
            this.groupBox2.Controls.Add(this.lblFechaProg);
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Controls.Add(this.txtMontoTotal);
            this.groupBox2.Controls.Add(this.gbxITF);
            this.groupBox2.Controls.Add(this.lblBase2);
            this.groupBox2.Controls.Add(this.lblBase1);
            this.groupBox2.Controls.Add(this.dtgDesembolsoSolicitud);
            this.groupBox2.Location = new System.Drawing.Point(3, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 351);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solicitudes aprobadas para desembolso";
            // 
            // pnlMensaje
            // 
            this.pnlMensaje.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnlMensaje.Controls.Add(this.lblClienteProcesado);
            this.pnlMensaje.Controls.Add(this.lblMensajeProceso);
            this.pnlMensaje.Location = new System.Drawing.Point(3, 95);
            this.pnlMensaje.Name = "pnlMensaje";
            this.pnlMensaje.Size = new System.Drawing.Size(826, 20);
            this.pnlMensaje.TabIndex = 15;
            // 
            // lblClienteProcesado
            // 
            this.lblClienteProcesado.AutoSize = true;
            this.lblClienteProcesado.ForeColor = System.Drawing.Color.White;
            this.lblClienteProcesado.Location = new System.Drawing.Point(629, 3);
            this.lblClienteProcesado.Name = "lblClienteProcesado";
            this.lblClienteProcesado.Size = new System.Drawing.Size(193, 13);
            this.lblClienteProcesado.TabIndex = 1;
            this.lblClienteProcesado.Text = "NOMBRE DE CLIENTE EN PROCESO";
            this.lblClienteProcesado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMensajeProceso
            // 
            this.lblMensajeProceso.AutoSize = true;
            this.lblMensajeProceso.ForeColor = System.Drawing.Color.White;
            this.lblMensajeProceso.Location = new System.Drawing.Point(3, 3);
            this.lblMensajeProceso.Name = "lblMensajeProceso";
            this.lblMensajeProceso.Size = new System.Drawing.Size(106, 13);
            this.lblMensajeProceso.TabIndex = 0;
            this.lblMensajeProceso.Text = "Mensaje de proceso.";
            // 
            // lblModalidadDes
            // 
            this.lblModalidadDes.AutoSize = true;
            this.lblModalidadDes.BackColor = System.Drawing.SystemColors.Info;
            this.lblModalidadDes.Location = new System.Drawing.Point(534, 23);
            this.lblModalidadDes.Name = "lblModalidadDes";
            this.lblModalidadDes.Size = new System.Drawing.Size(13, 13);
            this.lblModalidadDes.TabIndex = 14;
            this.lblModalidadDes.Text = "  ";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(419, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(113, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Mod. Desembolso:";
            // 
            // lblFechaSolicitud
            // 
            this.lblFechaSolicitud.AutoSize = true;
            this.lblFechaSolicitud.BackColor = System.Drawing.SystemColors.Info;
            this.lblFechaSolicitud.Location = new System.Drawing.Point(180, 72);
            this.lblFechaSolicitud.Name = "lblFechaSolicitud";
            this.lblFechaSolicitud.Size = new System.Drawing.Size(13, 13);
            this.lblFechaSolicitud.TabIndex = 12;
            this.lblFechaSolicitud.Text = "  ";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.BackColor = System.Drawing.SystemColors.Info;
            this.lblMoneda.Location = new System.Drawing.Point(180, 48);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(13, 13);
            this.lblMoneda.TabIndex = 11;
            this.lblMoneda.Text = "  ";
            // 
            // lblFechaProg
            // 
            this.lblFechaProg.AutoSize = true;
            this.lblFechaProg.BackColor = System.Drawing.SystemColors.Info;
            this.lblFechaProg.Location = new System.Drawing.Point(180, 23);
            this.lblFechaProg.Name = "lblFechaProg";
            this.lblFechaProg.Size = new System.Drawing.Size(13, 13);
            this.lblFechaProg.TabIndex = 10;
            this.lblFechaProg.Text = "  ";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(81, 72);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(97, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Fecha Solicitud:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(122, 48);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Moneda:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(78, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(100, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Fecha 1er Pago:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtMontoTotal.Location = new System.Drawing.Point(534, 70);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(125, 20);
            this.txtMontoTotal.TabIndex = 6;
            // 
            // gbxITF
            // 
            this.gbxITF.Controls.Add(this.rbtItfNo);
            this.gbxITF.Controls.Add(this.rbtRestarItfSi);
            this.gbxITF.Enabled = false;
            this.gbxITF.Location = new System.Drawing.Point(534, 34);
            this.gbxITF.Name = "gbxITF";
            this.gbxITF.Padding = new System.Windows.Forms.Padding(0);
            this.gbxITF.Size = new System.Drawing.Size(90, 33);
            this.gbxITF.TabIndex = 5;
            this.gbxITF.TabStop = false;
            // 
            // rbtItfNo
            // 
            this.rbtItfNo.AutoSize = true;
            this.rbtItfNo.ForeColor = System.Drawing.Color.Navy;
            this.rbtItfNo.Location = new System.Drawing.Point(43, 12);
            this.rbtItfNo.Name = "rbtItfNo";
            this.rbtItfNo.Size = new System.Drawing.Size(41, 17);
            this.rbtItfNo.TabIndex = 4;
            this.rbtItfNo.Text = "NO";
            this.rbtItfNo.UseVisualStyleBackColor = true;
            // 
            // rbtRestarItfSi
            // 
            this.rbtRestarItfSi.AutoSize = true;
            this.rbtRestarItfSi.Checked = true;
            this.rbtRestarItfSi.ForeColor = System.Drawing.Color.Navy;
            this.rbtRestarItfSi.Location = new System.Drawing.Point(2, 12);
            this.rbtRestarItfSi.Name = "rbtRestarItfSi";
            this.rbtRestarItfSi.Size = new System.Drawing.Size(35, 17);
            this.rbtRestarItfSi.TabIndex = 3;
            this.rbtRestarItfSi.TabStop = true;
            this.rbtRestarItfSi.Text = "SI";
            this.rbtRestarItfSi.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(374, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(158, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "¿Descontar ITF del Monto?";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(454, 73);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Monto Total:";
            // 
            // dtgDesembolsoSolicitud
            // 
            this.dtgDesembolsoSolicitud.AllowUserToAddRows = false;
            this.dtgDesembolsoSolicitud.AllowUserToDeleteRows = false;
            this.dtgDesembolsoSolicitud.AllowUserToResizeColumns = false;
            this.dtgDesembolsoSolicitud.AllowUserToResizeRows = false;
            this.dtgDesembolsoSolicitud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDesembolsoSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDesembolsoSolicitud.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgDesembolsoSolicitud.Location = new System.Drawing.Point(3, 114);
            this.dtgDesembolsoSolicitud.MultiSelect = false;
            this.dtgDesembolsoSolicitud.Name = "dtgDesembolsoSolicitud";
            this.dtgDesembolsoSolicitud.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDesembolsoSolicitud.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDesembolsoSolicitud.RowHeadersVisible = false;
            this.dtgDesembolsoSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDesembolsoSolicitud.Size = new System.Drawing.Size(826, 234);
            this.dtgDesembolsoSolicitud.TabIndex = 0;
            this.dtgDesembolsoSolicitud.SelectionChanged += new System.EventHandler(this.dtgDesembolsoSolicitud_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDepositar);
            this.panel1.Controls.Add(this.btnBloquear);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnEjecutar);
            this.panel1.Controls.Add(this.conSplaf);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Location = new System.Drawing.Point(3, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 51);
            this.panel1.TabIndex = 2;
            // 
            // btnDepositar
            // 
            this.btnDepositar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDepositar.BackgroundImage")));
            this.btnDepositar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDepositar.Location = new System.Drawing.Point(493, 1);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(60, 50);
            this.btnDepositar.TabIndex = 6;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnBloquear
            // 
            this.btnBloquear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBloquear.BackgroundImage")));
            this.btnBloquear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBloquear.Location = new System.Drawing.Point(425, 1);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(60, 50);
            this.btnBloquear.TabIndex = 4;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBloquear.UseVisualStyleBackColor = true;
            this.btnBloquear.Click += new System.EventHandler(this.btnBloquear_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(701, 1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.BackgroundImage")));
            this.btnEjecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEjecutar.Location = new System.Drawing.Point(359, 1);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(60, 50);
            this.btnEjecutar.TabIndex = 2;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // conSplaf
            // 
            this.conSplaf.AutoSize = true;
            this.conSplaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.conSplaf.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conSplaf.Location = new System.Drawing.Point(9, 17);
            this.conSplaf.Name = "conSplaf";
            this.conSplaf.Size = new System.Drawing.Size(51, 20);
            this.conSplaf.TabIndex = 1;
            this.conSplaf.Text = "Splaf";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(767, 1);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmGrupoSolidarioDesembolso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 540);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGrupoSolidarioDesembolso";
            this.Text = "Desembolso de Grupo Solidario";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.conBusGrupoSol.ResumeLayout(false);
            this.conBusGrupoSol.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlMensaje.ResumeLayout(false);
            this.pnlMensaje.PerformLayout();
            this.gbxITF.ResumeLayout(false);
            this.gbxITF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDesembolsoSolicitud)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboGrupoSolidarioCiclo1;
        private GEN.ControlesBase.cboTipoGrupoSolidario cboTipoGrupoSolidario1;
        private GEN.ControlesBase.txtBase txtNombreGrupo;
        private GEN.ControlesBase.txtNumerico txtIdGrupoSolidario;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.dtgBase dtgDesembolsoSolicitud;
        private GEN.ControlesBase.conSplaf conSplaf;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnEjecutar btnEjecutar;
        private GEN.ControlesBase.txtBase txtMontoTotal;
        private System.Windows.Forms.GroupBox gbxITF;
        private GEN.ControlesBase.rbtBase rbtItfNo;
        private GEN.ControlesBase.rbtBase rbtRestarItfSi;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.Label lblModalidadDes;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.Label lblFechaSolicitud;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblFechaProg;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnBloquear btnBloquear;
        private System.Windows.Forms.Panel pnlMensaje;
        private System.Windows.Forms.Label lblClienteProcesado;
        private System.Windows.Forms.Label lblMensajeProceso;
        private GEN.BotonesBase.btnDepositar btnDepositar;
    }
}