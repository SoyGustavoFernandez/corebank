namespace DEP.Presentacion
{
    partial class frmControlSolApertura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlSolApertura));
            this.dtgListSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnRechazar = new GEN.BotonesBase.btnRechazar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNrocuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReqFirma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nEdadCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListSolicitudes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListSolicitudes
            // 
            this.dtgListSolicitudes.AllowUserToAddRows = false;
            this.dtgListSolicitudes.AllowUserToDeleteRows = false;
            this.dtgListSolicitudes.AllowUserToResizeColumns = false;
            this.dtgListSolicitudes.AllowUserToResizeRows = false;
            this.dtgListSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListSolicitudes.Location = new System.Drawing.Point(12, 24);
            this.dtgListSolicitudes.MultiSelect = false;
            this.dtgListSolicitudes.Name = "dtgListSolicitudes";
            this.dtgListSolicitudes.ReadOnly = true;
            this.dtgListSolicitudes.RowHeadersVisible = false;
            this.dtgListSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListSolicitudes.Size = new System.Drawing.Size(275, 276);
            this.dtgListSolicitudes.TabIndex = 2;
            this.dtgListSolicitudes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListSolicitudes_CellEndEdit);
            this.dtgListSolicitudes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListSolicitudes_CellValueChanged);
            this.dtgListSolicitudes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgListSolicitudes_CurrentCellDirtyStateChanged);
            this.dtgListSolicitudes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListSolicitudes_RowEnter);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(763, 306);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazar.BackgroundImage")));
            this.btnRechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar.Enabled = false;
            this.btnRechazar.Location = new System.Drawing.Point(697, 306);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar.TabIndex = 4;
            this.btnRechazar.Text = "&Rechaza";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(295, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Nro de Cuenta:";
            // 
            // txtNrocuenta
            // 
            this.txtNrocuenta.Enabled = false;
            this.txtNrocuenta.Location = new System.Drawing.Point(103, 20);
            this.txtNrocuenta.Name = "txtNrocuenta";
            this.txtNrocuenta.Size = new System.Drawing.Size(257, 20);
            this.txtNrocuenta.TabIndex = 7;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(338, 54);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(392, 50);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(453, 20);
            this.txtCliente.TabIndex = 9;
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(103, 74);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(257, 20);
            this.txtProducto.TabIndex = 10;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(328, 81);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(62, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Producto:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(361, 77);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(46, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(698, 78);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(147, 20);
            this.txtMonto.TabIndex = 12;
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(392, 106);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(195, 21);
            this.cboTipoCuenta.TabIndex = 14;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(653, 106);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(192, 21);
            this.cboMoneda.TabIndex = 15;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(301, 104);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Moneda:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(291, 110);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(99, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Tipo de Cuenta:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNrocuenta);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtProducto);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(289, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(562, 140);
            this.grbBase1.TabIndex = 18;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Cuenta:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 5);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(145, 13);
            this.lblBase7.TabIndex = 19;
            this.lblBase7.Text = "Solicitudes de Apertura:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.dtgIntervinientes);
            this.grbBase4.Location = new System.Drawing.Point(289, 150);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(562, 150);
            this.grbBase4.TabIndex = 88;
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
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCli,
            this.idTipoDocumento,
            this.idTipoInterv,
            this.idSolicitud,
            this.cTipoDocumento,
            this.cDocumentoID,
            this.cNombre,
            this.cTipoIntervencion,
            this.lCliAfeITF,
            this.isReqFirma,
            this.idTipoPersona,
            this.nEdadCli});
            this.dtgIntervinientes.Location = new System.Drawing.Point(4, 19);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(552, 122);
            this.dtgIntervinientes.TabIndex = 4;
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(231, 306);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(56, 17);
            this.chcBase1.TabIndex = 89;
            this.chcBase1.Text = "Todos";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.FillWeight = 80F;
            this.idSolicitud.HeaderText = "CUENTA";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            // 
            // cTipoDocumento
            // 
            this.cTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumento.HeaderText = "TIPO DOCUMENTO";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.HeaderText = "DOCUMENTO";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 300F;
            this.cNombre.HeaderText = "NOMBRE CLIENTE";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "INTERVINIENTE";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            // 
            // lCliAfeITF
            // 
            this.lCliAfeITF.DataPropertyName = "lCliAfeITF";
            this.lCliAfeITF.FillWeight = 30F;
            this.lCliAfeITF.HeaderText = "ITF";
            this.lCliAfeITF.Name = "lCliAfeITF";
            this.lCliAfeITF.ReadOnly = true;
            this.lCliAfeITF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCliAfeITF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isReqFirma
            // 
            this.isReqFirma.DataPropertyName = "isReqFirma";
            this.isReqFirma.HeaderText = "isReqFirma";
            this.isReqFirma.Name = "isReqFirma";
            this.isReqFirma.ReadOnly = true;
            this.isReqFirma.Visible = false;
            // 
            // idTipoPersona
            // 
            this.idTipoPersona.DataPropertyName = "idTipoPersona";
            this.idTipoPersona.HeaderText = "idTipoPersona";
            this.idTipoPersona.Name = "idTipoPersona";
            this.idTipoPersona.ReadOnly = true;
            this.idTipoPersona.Visible = false;
            // 
            // nEdadCli
            // 
            this.nEdadCli.DataPropertyName = "nEdadCli";
            this.nEdadCli.HeaderText = "nEdadCli";
            this.nEdadCli.Name = "nEdadCli";
            this.nEdadCli.ReadOnly = true;
            this.nEdadCli.Visible = false;
            // 
            // frmControlSolApertura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 386);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.dtgListSolicitudes);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.cboTipoCuenta);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmControlSolApertura";
            this.Text = "Control de Solicitudes de Apertura";
            this.Load += new System.EventHandler(this.frmControlSolApertura_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtMonto, 0);
            this.Controls.SetChildIndex(this.cboTipoCuenta, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnRechazar, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.dtgListSolicitudes, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListSolicitudes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgListSolicitudes;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnRechazar btnRechazar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNrocuenta;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtCliente;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtMonto;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase4;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private GEN.ControlesBase.chcBase chcBase1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReqFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn nEdadCli;
    }
}