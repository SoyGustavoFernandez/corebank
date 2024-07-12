namespace RCP.Presentacion
{
    partial class frmCreditosTransferidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditosTransferidos));
            this.dtgCreditosTransferidos = new GEN.ControlesBase.dtgBase(this.components);
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAsigCartRecuperaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombreCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtOpinionTransferencia = new GEN.ControlesBase.txtBase(this.components);
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtSaldoCapital = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotalPagar = new GEN.ControlesBase.txtBase(this.components);
            this.txtAtraso = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtUbigeo = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.cboMotivoMora1 = new GEN.ControlesBase.cboMotivoMora(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosTransferidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCreditosTransferidos
            // 
            this.dtgCreditosTransferidos.AllowUserToAddRows = false;
            this.dtgCreditosTransferidos.AllowUserToDeleteRows = false;
            this.dtgCreditosTransferidos.AllowUserToResizeColumns = false;
            this.dtgCreditosTransferidos.AllowUserToResizeRows = false;
            this.dtgCreditosTransferidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditosTransferidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosTransferidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuenta,
            this.idAsigCartRecuperaciones,
            this.idCli,
            this.cNombre,
            this.cMoneda,
            this.nSaldoCapital,
            this.nTotalPagar,
            this.nAtraso,
            this.nUbigeo,
            this.cNombreAge,
            this.cTramo});
            this.dtgCreditosTransferidos.Location = new System.Drawing.Point(13, 13);
            this.dtgCreditosTransferidos.MultiSelect = false;
            this.dtgCreditosTransferidos.Name = "dtgCreditosTransferidos";
            this.dtgCreditosTransferidos.ReadOnly = true;
            this.dtgCreditosTransferidos.RowHeadersVisible = false;
            this.dtgCreditosTransferidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosTransferidos.Size = new System.Drawing.Size(719, 198);
            this.dtgCreditosTransferidos.TabIndex = 0;
            this.dtgCreditosTransferidos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreditosTransferidos_CellEnter);
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.FillWeight = 33.30687F;
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Width = 66;
            // 
            // idAsigCartRecuperaciones
            // 
            this.idAsigCartRecuperaciones.DataPropertyName = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones.HeaderText = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones.Name = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones.ReadOnly = true;
            this.idAsigCartRecuperaciones.Visible = false;
            // 
            // idCli
            // 
            this.idCli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCli.DataPropertyName = "idCli";
            this.idCli.FillWeight = 40.93497F;
            this.idCli.HeaderText = "Cod. Cli.";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Width = 66;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 155.0552F;
            this.cNombre.HeaderText = "Nombre Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 96;
            // 
            // cMoneda
            // 
            this.cMoneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cMoneda.DataPropertyName = "cMoneda";
            this.cMoneda.FillWeight = 33.28572F;
            this.cMoneda.HeaderText = "Moneda";
            this.cMoneda.Name = "cMoneda";
            this.cMoneda.ReadOnly = true;
            this.cMoneda.Width = 71;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapital.FillWeight = 56.94323F;
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            this.nSaldoCapital.Width = 87;
            // 
            // nTotalPagar
            // 
            this.nTotalPagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nTotalPagar.DataPropertyName = "nTotalPagar";
            this.nTotalPagar.FillWeight = 65.21802F;
            this.nTotalPagar.HeaderText = "Total Pagar";
            this.nTotalPagar.Name = "nTotalPagar";
            this.nTotalPagar.ReadOnly = true;
            this.nTotalPagar.Width = 80;
            // 
            // nAtraso
            // 
            this.nAtraso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtraso.DataPropertyName = "nAtraso";
            this.nAtraso.FillWeight = 47.16211F;
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            this.nAtraso.Width = 62;
            // 
            // nUbigeo
            // 
            this.nUbigeo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nUbigeo.DataPropertyName = "nUbigeo";
            this.nUbigeo.FillWeight = 154.3084F;
            this.nUbigeo.HeaderText = "Ubigeo";
            this.nUbigeo.Name = "nUbigeo";
            this.nUbigeo.ReadOnly = true;
            this.nUbigeo.Width = 66;
            // 
            // cNombreAge
            // 
            this.cNombreAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.FillWeight = 261.5013F;
            this.cNombreAge.HeaderText = "Nombre Ofi.";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            this.cNombreAge.Width = 81;
            // 
            // cTramo
            // 
            this.cTramo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTramo.DataPropertyName = "cTramo";
            this.cTramo.FillWeight = 152.2843F;
            this.cTramo.HeaderText = "Tramo";
            this.cTramo.Name = "cTramo";
            this.cTramo.ReadOnly = true;
            this.cTramo.Width = 62;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(672, 366);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 15;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(606, 366);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 13;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 311);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(152, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Opinión de transferencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(83, 286);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(79, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Factor Mora:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(66, 337);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Observaciónes:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(24, 230);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(53, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Cuenta:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(215, 230);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(54, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Cod Cli:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(374, 230);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(52, 13);
            this.lblBase6.TabIndex = 10;
            this.lblBase6.Text = "Cliente:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(78, 226);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ReadOnly = true;
            this.txtCuenta.Size = new System.Drawing.Size(100, 20);
            this.txtCuenta.TabIndex = 1;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(427, 226);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(305, 20);
            this.txtNombreCliente.TabIndex = 3;
            // 
            // txtOpinionTransferencia
            // 
            this.txtOpinionTransferencia.Location = new System.Drawing.Point(175, 308);
            this.txtOpinionTransferencia.Name = "txtOpinionTransferencia";
            this.txtOpinionTransferencia.Size = new System.Drawing.Size(557, 20);
            this.txtOpinionTransferencia.TabIndex = 9;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(175, 334);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(557, 20);
            this.txtObservaciones.TabIndex = 10;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 255);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(65, 13);
            this.lblBase7.TabIndex = 17;
            this.lblBase7.Text = "Sal. Cap.:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(182, 255);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(88, 13);
            this.lblBase8.TabIndex = 18;
            this.lblBase8.Text = "Total a pagar:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(377, 255);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(49, 13);
            this.lblBase9.TabIndex = 19;
            this.lblBase9.Text = "Atraso:";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.Location = new System.Drawing.Point(78, 251);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.ReadOnly = true;
            this.txtSaldoCapital.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoCapital.TabIndex = 4;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(271, 226);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodCliente.TabIndex = 2;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(271, 251);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPagar.TabIndex = 5;
            // 
            // txtAtraso
            // 
            this.txtAtraso.Location = new System.Drawing.Point(427, 251);
            this.txtAtraso.Name = "txtAtraso";
            this.txtAtraso.ReadOnly = true;
            this.txtAtraso.Size = new System.Drawing.Size(40, 20);
            this.txtAtraso.TabIndex = 6;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(473, 255);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(51, 13);
            this.lblBase10.TabIndex = 23;
            this.lblBase10.Text = "Ubigeo:";
            // 
            // txtUbigeo
            // 
            this.txtUbigeo.Location = new System.Drawing.Point(525, 251);
            this.txtUbigeo.Name = "txtUbigeo";
            this.txtUbigeo.ReadOnly = true;
            this.txtUbigeo.Size = new System.Drawing.Size(207, 20);
            this.txtUbigeo.TabIndex = 7;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(540, 366);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 12;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(476, 366);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 11;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(17, 366);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 14;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboMotivoMora1
            // 
            this.cboMotivoMora1.FormattingEnabled = true;
            this.cboMotivoMora1.Location = new System.Drawing.Point(175, 281);
            this.cboMotivoMora1.Name = "cboMotivoMora1";
            this.cboMotivoMora1.Size = new System.Drawing.Size(349, 21);
            this.cboMotivoMora1.TabIndex = 8;
            // 
            // frmCreditosTransferidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 441);
            this.Controls.Add(this.cboMotivoMora1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.txtUbigeo);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.txtAtraso);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.txtSaldoCapital);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtOpinionTransferencia);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.txtCuenta);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgCreditosTransferidos);
            this.Name = "frmCreditosTransferidos";
            this.Text = "Creditos Transferidos Pendientes de Glosa";
            this.Load += new System.EventHandler(this.frmCreditosTransferidos_Load);
            this.Controls.SetChildIndex(this.dtgCreditosTransferidos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtCuenta, 0);
            this.Controls.SetChildIndex(this.txtCodCliente, 0);
            this.Controls.SetChildIndex(this.txtNombreCliente, 0);
            this.Controls.SetChildIndex(this.txtOpinionTransferencia, 0);
            this.Controls.SetChildIndex(this.txtObservaciones, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtSaldoCapital, 0);
            this.Controls.SetChildIndex(this.txtTotalPagar, 0);
            this.Controls.SetChildIndex(this.txtAtraso, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtUbigeo, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.cboMotivoMora1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosTransferidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCreditosTransferidos;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtCuenta;
        private GEN.ControlesBase.txtBase txtNombreCliente;
        private GEN.ControlesBase.txtBase txtOpinionTransferencia;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtSaldoCapital;
        private GEN.ControlesBase.txtBase txtCodCliente;
        private GEN.ControlesBase.txtBase txtTotalPagar;
        private GEN.ControlesBase.txtBase txtAtraso;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsigCartRecuperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTramo;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboMotivoMora cboMotivoMora1;
    }
}