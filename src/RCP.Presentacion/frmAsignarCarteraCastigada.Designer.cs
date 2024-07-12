namespace RCP.Presentacion
{
    partial class frmAsignarCarteraCastigada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarCarteraCastigada));
            this.txtMotivoTransferencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNroCreditosDestino = new GEN.ControlesBase.lblBase();
            this.dtgCarteraDestino = new GEN.ControlesBase.dtgBase(this.components);
            this.idCuentaDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lSeleCta1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAsigCartRecuperaciones1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTramoActual1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtrasoDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCapitalDesembolsoDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapitalDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUbigeoDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboUsuRecuperadoresDestino = new GEN.ControlesBase.cboUsuRecuperadores(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.cboAnexo = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDepartamento = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboPais = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblNroCreditosOrigen = new GEN.ControlesBase.lblBase();
            this.dtgCarteraOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraDestino)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.conBusUbig1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraOrigen)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMotivoTransferencia
            // 
            this.txtMotivoTransferencia.Location = new System.Drawing.Point(73, 650);
            this.txtMotivoTransferencia.Multiline = true;
            this.txtMotivoTransferencia.Name = "txtMotivoTransferencia";
            this.txtMotivoTransferencia.Size = new System.Drawing.Size(410, 50);
            this.txtMotivoTransferencia.TabIndex = 12;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 653);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Motivo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNroCreditosDestino);
            this.groupBox2.Controls.Add(this.dtgCarteraDestino);
            this.groupBox2.Controls.Add(this.lblBase2);
            this.groupBox2.Controls.Add(this.cboUsuRecuperadoresDestino);
            this.groupBox2.Location = new System.Drawing.Point(14, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 259);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino";
            // 
            // lblNroCreditosDestino
            // 
            this.lblNroCreditosDestino.AutoSize = true;
            this.lblNroCreditosDestino.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCreditosDestino.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCreditosDestino.Location = new System.Drawing.Point(23, 241);
            this.lblNroCreditosDestino.Name = "lblNroCreditosDestino";
            this.lblNroCreditosDestino.Size = new System.Drawing.Size(65, 13);
            this.lblNroCreditosDestino.TabIndex = 7;
            this.lblNroCreditosDestino.Text = "Credito(s)";
            // 
            // dtgCarteraDestino
            // 
            this.dtgCarteraDestino.AllowUserToAddRows = false;
            this.dtgCarteraDestino.AllowUserToDeleteRows = false;
            this.dtgCarteraDestino.AllowUserToResizeColumns = false;
            this.dtgCarteraDestino.AllowUserToResizeRows = false;
            this.dtgCarteraDestino.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCarteraDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarteraDestino.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuentaDes,
            this.lSeleCta1,
            this.idAsigCartRecuperaciones1,
            this.idTramoActual1,
            this.idCliDes,
            this.cNombreDes,
            this.nAtrasoDes,
            this.nCapitalDesembolsoDes,
            this.nSaldoCapitalDes,
            this.nUbigeoDes});
            this.dtgCarteraDestino.Location = new System.Drawing.Point(6, 59);
            this.dtgCarteraDestino.MultiSelect = false;
            this.dtgCarteraDestino.Name = "dtgCarteraDestino";
            this.dtgCarteraDestino.ReadOnly = true;
            this.dtgCarteraDestino.RowHeadersVisible = false;
            this.dtgCarteraDestino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCarteraDestino.Size = new System.Drawing.Size(667, 179);
            this.dtgCarteraDestino.TabIndex = 1;
            // 
            // idCuentaDes
            // 
            this.idCuentaDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuentaDes.DataPropertyName = "idCuenta";
            this.idCuentaDes.FillWeight = 68.10113F;
            this.idCuentaDes.HeaderText = "Cuenta";
            this.idCuentaDes.Name = "idCuentaDes";
            this.idCuentaDes.ReadOnly = true;
            this.idCuentaDes.Width = 66;
            // 
            // lSeleCta1
            // 
            this.lSeleCta1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lSeleCta1.DataPropertyName = "lSeleCta";
            this.lSeleCta1.HeaderText = "lSeleCta";
            this.lSeleCta1.Name = "lSeleCta1";
            this.lSeleCta1.ReadOnly = true;
            this.lSeleCta1.Visible = false;
            // 
            // idAsigCartRecuperaciones1
            // 
            this.idAsigCartRecuperaciones1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idAsigCartRecuperaciones1.DataPropertyName = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones1.HeaderText = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones1.Name = "idAsigCartRecuperaciones1";
            this.idAsigCartRecuperaciones1.ReadOnly = true;
            this.idAsigCartRecuperaciones1.Visible = false;
            // 
            // idTramoActual1
            // 
            this.idTramoActual1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idTramoActual1.DataPropertyName = "idTramoActual";
            this.idTramoActual1.HeaderText = "idTramoActual";
            this.idTramoActual1.Name = "idTramoActual1";
            this.idTramoActual1.ReadOnly = true;
            this.idTramoActual1.Visible = false;
            // 
            // idCliDes
            // 
            this.idCliDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCliDes.DataPropertyName = "idCli";
            this.idCliDes.FillWeight = 55.37734F;
            this.idCliDes.HeaderText = "Cod. Cli.";
            this.idCliDes.Name = "idCliDes";
            this.idCliDes.ReadOnly = true;
            this.idCliDes.Width = 66;
            // 
            // cNombreDes
            // 
            this.cNombreDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNombreDes.DataPropertyName = "cNombre";
            this.cNombreDes.FillWeight = 246.4382F;
            this.cNombreDes.HeaderText = "Nombre";
            this.cNombreDes.Name = "cNombreDes";
            this.cNombreDes.ReadOnly = true;
            // 
            // nAtrasoDes
            // 
            this.nAtrasoDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtrasoDes.DataPropertyName = "nAtraso";
            this.nAtrasoDes.FillWeight = 65.71098F;
            this.nAtrasoDes.HeaderText = "Atraso";
            this.nAtrasoDes.Name = "nAtrasoDes";
            this.nAtrasoDes.ReadOnly = true;
            this.nAtrasoDes.Width = 62;
            // 
            // nCapitalDesembolsoDes
            // 
            this.nCapitalDesembolsoDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nCapitalDesembolsoDes.DataPropertyName = "nCapitalDesembolso";
            this.nCapitalDesembolsoDes.FillWeight = 86.29195F;
            this.nCapitalDesembolsoDes.HeaderText = "Capital Desembolso";
            this.nCapitalDesembolsoDes.Name = "nCapitalDesembolsoDes";
            this.nCapitalDesembolsoDes.ReadOnly = true;
            this.nCapitalDesembolsoDes.Width = 114;
            // 
            // nSaldoCapitalDes
            // 
            this.nSaldoCapitalDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapitalDes.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapitalDes.FillWeight = 88.8325F;
            this.nSaldoCapitalDes.HeaderText = "Saldo Capital";
            this.nSaldoCapitalDes.Name = "nSaldoCapitalDes";
            this.nSaldoCapitalDes.ReadOnly = true;
            this.nSaldoCapitalDes.Width = 87;
            // 
            // nUbigeoDes
            // 
            this.nUbigeoDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nUbigeoDes.DataPropertyName = "nUbigeo";
            this.nUbigeoDes.FillWeight = 89.24798F;
            this.nUbigeoDes.HeaderText = "Ubigeo";
            this.nUbigeoDes.Name = "nUbigeoDes";
            this.nUbigeoDes.ReadOnly = true;
            this.nUbigeoDes.Width = 66;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(23, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Usuario:";
            // 
            // cboUsuRecuperadoresDestino
            // 
            this.cboUsuRecuperadoresDestino.FormattingEnabled = true;
            this.cboUsuRecuperadoresDestino.Location = new System.Drawing.Point(84, 19);
            this.cboUsuRecuperadoresDestino.Name = "cboUsuRecuperadoresDestino";
            this.cboUsuRecuperadoresDestino.Size = new System.Drawing.Size(282, 21);
            this.cboUsuRecuperadoresDestino.TabIndex = 0;
            this.cboUsuRecuperadoresDestino.SelectedIndexChanged += new System.EventHandler(this.cboUsuRecuperadoresDestino_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAgencia1);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.conBusUbig1);
            this.groupBox1.Controls.Add(this.lblNroCreditosOrigen);
            this.groupBox1.Controls.Add(this.dtgCarteraOrigen);
            this.groupBox1.Location = new System.Drawing.Point(14, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 366);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origen";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(84, 23);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(290, 21);
            this.cboAgencia1.TabIndex = 1;
            this.cboAgencia1.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(24, 26);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(51, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Oficina:";
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.Color.Transparent;
            this.conBusUbig1.Controls.Add(this.cboAnexo);
            this.conBusUbig1.Controls.Add(this.cboDistrito);
            this.conBusUbig1.Controls.Add(this.cboProvincia);
            this.conBusUbig1.Controls.Add(this.cboDepartamento);
            this.conBusUbig1.Controls.Add(this.cboPais);
            this.conBusUbig1.Location = new System.Drawing.Point(426, 17);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(234, 132);
            this.conBusUbig1.TabIndex = 2;
            // 
            // cboAnexo
            // 
            this.cboAnexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnexo.FormattingEnabled = true;
            this.cboAnexo.Location = new System.Drawing.Point(103, 106);
            this.cboAnexo.Name = "cboAnexo";
            this.cboAnexo.Size = new System.Drawing.Size(121, 21);
            this.cboAnexo.TabIndex = 4;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(103, 81);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(121, 21);
            this.cboDistrito.TabIndex = 3;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(103, 56);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 2;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(103, 31);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cboDepartamento.TabIndex = 1;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(103, 6);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(121, 21);
            this.cboPais.TabIndex = 0;
            // 
            // lblNroCreditosOrigen
            // 
            this.lblNroCreditosOrigen.AutoSize = true;
            this.lblNroCreditosOrigen.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCreditosOrigen.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCreditosOrigen.Location = new System.Drawing.Point(16, 348);
            this.lblNroCreditosOrigen.Name = "lblNroCreditosOrigen";
            this.lblNroCreditosOrigen.Size = new System.Drawing.Size(65, 13);
            this.lblNroCreditosOrigen.TabIndex = 6;
            this.lblNroCreditosOrigen.Text = "Credito(s)";
            // 
            // dtgCarteraOrigen
            // 
            this.dtgCarteraOrigen.AllowUserToAddRows = false;
            this.dtgCarteraOrigen.AllowUserToDeleteRows = false;
            this.dtgCarteraOrigen.AllowUserToResizeColumns = false;
            this.dtgCarteraOrigen.AllowUserToResizeRows = false;
            this.dtgCarteraOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCarteraOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarteraOrigen.Location = new System.Drawing.Point(6, 161);
            this.dtgCarteraOrigen.MultiSelect = false;
            this.dtgCarteraOrigen.Name = "dtgCarteraOrigen";
            this.dtgCarteraOrigen.ReadOnly = true;
            this.dtgCarteraOrigen.RowHeadersVisible = false;
            this.dtgCarteraOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCarteraOrigen.Size = new System.Drawing.Size(667, 179);
            this.dtgCarteraOrigen.TabIndex = 3;
            this.dtgCarteraOrigen.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCarteraOrigen_CellValueChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(501, 650);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 13;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(567, 650);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 14;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(633, 650);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 15;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmAsignarCarteraCastigada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(703, 734);
            this.Controls.Add(this.txtMotivoTransferencia);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAsignarCarteraCastigada";
            this.Text = "Asignación de Cartera Castigada";
            this.Load += new System.EventHandler(this.frmReasinarCartera_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtMotivoTransferencia, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraDestino)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.conBusUbig1.ResumeLayout(false);
            this.conBusUbig1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraOrigen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtMotivoTransferencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.lblBase lblNroCreditosDestino;
        private GEN.ControlesBase.dtgBase dtgCarteraDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuentaDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn lSeleCta1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsigCartRecuperaciones1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTramoActual1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtrasoDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCapitalDesembolsoDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapitalDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUbigeoDes;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboUsuRecuperadores cboUsuRecuperadoresDestino;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.ControlesBase.cboUbigeo cboAnexo;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.cboUbigeo cboDepartamento;
        private GEN.ControlesBase.cboUbigeo cboPais;
        private GEN.ControlesBase.lblBase lblNroCreditosOrigen;
        private GEN.ControlesBase.dtgBase dtgCarteraOrigen;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}