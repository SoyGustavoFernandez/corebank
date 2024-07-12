namespace RCP.Presentacion
{
    partial class frmAprobacionSolicitudJudicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionSolicitudJudicial));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboPersonalCargo1 = new GEN.ControlesBase.cboPersonalCargo();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase();
            this.txtOpinion = new GEN.ControlesBase.txtBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase();
            this.lblBase44 = new GEN.ControlesBase.lblBase();
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase();
            this.cboUsuRecuperadores1 = new GEN.ControlesBase.cboUsuRecuperadores();
            this.grbBase1 = new GEN.ControlesBase.grbBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMotivoTransferencia = new GEN.ControlesBase.txtBase();
            this.btnDenegar1 = new GEN.BotonesBase.btnDenegar();
            this.btnAprobar1 = new GEN.BotonesBase.btnAprobar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodCliente = new GEN.ControlesBase.txtNumRea();
            this.txtNomCliente = new GEN.ControlesBase.txtNumRea();
            this.txtCuenta = new GEN.ControlesBase.txtNumRea();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 9);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(85, 13);
            this.lblBase2.TabIndex = 24;
            this.lblBase2.Text = "Recuperador:";
            this.lblBase2.Visible = false;
            // 
            // cboPersonalCargo1
            // 
            this.cboPersonalCargo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonalCargo1.FormattingEnabled = true;
            this.cboPersonalCargo1.Location = new System.Drawing.Point(104, 6);
            this.cboPersonalCargo1.Name = "cboPersonalCargo1";
            this.cboPersonalCargo1.Size = new System.Drawing.Size(282, 21);
            this.cboPersonalCargo1.TabIndex = 23;
            this.cboPersonalCargo1.Visible = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(130, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Solitudes pendientes:";
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgSolicitudes.Location = new System.Drawing.Point(11, 45);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(766, 149);
            this.dtgSolicitudes.TabIndex = 19;
            this.dtgSolicitudes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgSolicitudes_CellMouseClick);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtOpinion);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Location = new System.Drawing.Point(420, 249);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(357, 162);
            this.grbBase3.TabIndex = 26;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Motivo Pase a Judicial";
            // 
            // txtOpinion
            // 
            this.txtOpinion.Enabled = false;
            this.txtOpinion.Location = new System.Drawing.Point(9, 40);
            this.txtOpinion.Multiline = true;
            this.txtOpinion.Name = "txtOpinion";
            this.txtOpinion.Size = new System.Drawing.Size(342, 110);
            this.txtOpinion.TabIndex = 72;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 24);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 71;
            this.lblBase3.Text = "Justificación:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase44);
            this.grbBase2.Controls.Add(this.dtgDocumentos);
            this.grbBase2.Location = new System.Drawing.Point(11, 249);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(404, 162);
            this.grbBase2.TabIndex = 25;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Agregar Archivos";
            // 
            // lblBase44
            // 
            this.lblBase44.AutoSize = true;
            this.lblBase44.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase44.ForeColor = System.Drawing.Color.Navy;
            this.lblBase44.Location = new System.Drawing.Point(6, 24);
            this.lblBase44.Name = "lblBase44";
            this.lblBase44.Size = new System.Drawing.Size(136, 13);
            this.lblBase44.TabIndex = 71;
            this.lblBase44.Text = "Documentos adjuntos:";
            // 
            // dtgDocumentos
            // 
            this.dtgDocumentos.AllowUserToAddRows = false;
            this.dtgDocumentos.AllowUserToDeleteRows = false;
            this.dtgDocumentos.AllowUserToResizeColumns = false;
            this.dtgDocumentos.AllowUserToResizeRows = false;
            this.dtgDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentos.Location = new System.Drawing.Point(9, 40);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(386, 110);
            this.dtgDocumentos.TabIndex = 70;
            this.dtgDocumentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentos_CellContentClick);
            // 
            // cboUsuRecuperadores1
            // 
            this.cboUsuRecuperadores1.FormattingEnabled = true;
            this.cboUsuRecuperadores1.Location = new System.Drawing.Point(106, 23);
            this.cboUsuRecuperadores1.Name = "cboUsuRecuperadores1";
            this.cboUsuRecuperadores1.Size = new System.Drawing.Size(448, 21);
            this.cboUsuRecuperadores1.TabIndex = 27;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboUsuRecuperadores1);
            this.grbBase1.Location = new System.Drawing.Point(14, 412);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(763, 59);
            this.grbBase1.TabIndex = 28;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Asignación de Judicial";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 26);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(84, 13);
            this.lblBase4.TabIndex = 72;
            this.lblBase4.Text = "Gestor Legal:";
            // 
            // txtMotivoTransferencia
            // 
            this.txtMotivoTransferencia.Location = new System.Drawing.Point(6, 40);
            this.txtMotivoTransferencia.Multiline = true;
            this.txtMotivoTransferencia.Name = "txtMotivoTransferencia";
            this.txtMotivoTransferencia.Size = new System.Drawing.Size(345, 110);
            this.txtMotivoTransferencia.TabIndex = 72;
            // 
            // btnDenegar1
            // 
            this.btnDenegar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar1.BackgroundImage")));
            this.btnDenegar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar1.Location = new System.Drawing.Point(519, 477);
            this.btnDenegar1.Name = "btnDenegar1";
            this.btnDenegar1.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar1.TabIndex = 22;
            this.btnDenegar1.Text = "&Denegar";
            this.btnDenegar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar1.UseVisualStyleBackColor = true;
            this.btnDenegar1.Click += new System.EventHandler(this.btnDenegar1_Click);
            // 
            // btnAprobar1
            // 
            this.btnAprobar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar1.BackgroundImage")));
            this.btnAprobar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar1.Location = new System.Drawing.Point(585, 477);
            this.btnAprobar1.Name = "btnAprobar1";
            this.btnAprobar1.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar1.TabIndex = 21;
            this.btnAprobar1.Text = "&Aprobar";
            this.btnAprobar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar1.UseVisualStyleBackColor = true;
            this.btnAprobar1.Click += new System.EventHandler(this.btnAprobar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(651, 477);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 18;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(717, 477);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 17;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodCliente);
            this.groupBox1.Controls.Add(this.txtNomCliente);
            this.groupBox1.Controls.Add(this.txtCuenta);
            this.groupBox1.Controls.Add(this.lblBase7);
            this.groupBox1.Controls.Add(this.lblBase6);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Location = new System.Drawing.Point(11, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 42);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Cuenta";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Enabled = false;
            this.txtCodCliente.FormatoDecimal = false;
            this.txtCodCliente.Location = new System.Drawing.Point(314, 16);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCodCliente.nNumDecimales = 2;
            this.txtCodCliente.nvalor = 0D;
            this.txtCodCliente.Size = new System.Drawing.Size(99, 20);
            this.txtCodCliente.TabIndex = 79;
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.Enabled = false;
            this.txtNomCliente.FormatoDecimal = false;
            this.txtNomCliente.Location = new System.Drawing.Point(520, 16);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNomCliente.nNumDecimales = 2;
            this.txtNomCliente.nvalor = 0D;
            this.txtNomCliente.Size = new System.Drawing.Size(222, 20);
            this.txtNomCliente.TabIndex = 78;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Enabled = false;
            this.txtCuenta.FormatoDecimal = false;
            this.txtCuenta.Location = new System.Drawing.Point(80, 16);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuenta.nNumDecimales = 2;
            this.txtCuenta.nvalor = 0D;
            this.txtCuenta.Size = new System.Drawing.Size(99, 20);
            this.txtCuenta.TabIndex = 76;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(447, 19);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(67, 13);
            this.lblBase7.TabIndex = 75;
            this.lblBase7.Text = "Nombres :";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(212, 19);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(96, 13);
            this.lblBase6.TabIndex = 74;
            this.lblBase6.Text = "Código Cliente:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(21, 19);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(53, 13);
            this.lblBase5.TabIndex = 73;
            this.lblBase5.Text = "Cuenta:";
            // 
            // frmAprobacionSolicitudJudicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboPersonalCargo1);
            this.Controls.Add(this.btnDenegar1);
            this.Controls.Add(this.btnAprobar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgSolicitudes);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAprobacionSolicitudJudicial";
            this.Text = "Aprobación de Solicitud de Paso a Judicial";
            this.Load += new System.EventHandler(this.frmAprobacionSolicitudJudicial_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgSolicitudes, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnAprobar1, 0);
            this.Controls.SetChildIndex(this.btnDenegar1, 0);
            this.Controls.SetChildIndex(this.cboPersonalCargo1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboPersonalCargo cboPersonalCargo1;
        private GEN.BotonesBase.btnDenegar btnDenegar1;
        private GEN.BotonesBase.btnAprobar btnAprobar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtMotivoTransferencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase44;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private GEN.ControlesBase.cboUsuRecuperadores cboUsuRecuperadores1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtOpinion;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtCodCliente;
        private GEN.ControlesBase.txtNumRea txtNomCliente;
        private GEN.ControlesBase.txtNumRea txtCuenta;
    }
}