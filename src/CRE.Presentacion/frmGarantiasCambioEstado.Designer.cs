namespace CRE.Presentacion
{
    partial class frmGarantiasCambioEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGarantiasCambioEstado));
            this.conBusCliente = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.idGarantiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGarantiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsGarantiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTipGar = new System.Windows.Forms.Panel();
            this.flpTiposGar = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtHipoteca = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtVehiculo = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtTituloValor = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtPersonal = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtElectros = new GEN.ControlesBase.rbtBase(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase35 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoGarantia = new GEN.ControlesBase.cboTipoGarantia(this.components);
            this.cboGrupoGarantia = new GEN.ControlesBase.cboGrupoGarantia(this.components);
            this.cboClaseGarantia = new GEN.ControlesBase.cboClaseGarantia(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.conBusCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsGarantiaBindingSource)).BeginInit();
            this.pnlTipGar.SuspendLayout();
            this.flpTiposGar.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCliente
            // 
            this.conBusCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliente.Controls.Add(this.txtCodInst);
            this.conBusCliente.Controls.Add(this.txtCodAge);
            this.conBusCliente.Controls.Add(this.txtDireccion);
            this.conBusCliente.Controls.Add(this.txtCodCli);
            this.conBusCliente.Controls.Add(this.txtNombre);
            this.conBusCliente.Controls.Add(this.txtNroDoc);
            this.conBusCliente.idCli = 0;
            this.conBusCliente.Location = new System.Drawing.Point(12, 1);
            this.conBusCliente.Name = "conBusCliente";
            this.conBusCliente.Size = new System.Drawing.Size(531, 109);
            this.conBusCliente.TabIndex = 2;
            this.conBusCliente.ClicBuscar += new System.EventHandler(this.conBusCliente_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(281, 400);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(347, 400);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(413, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idGarantiaDataGridViewTextBoxColumn,
            this.cGarantiaDataGridViewTextBoxColumn});
            this.dtgGarantias.Location = new System.Drawing.Point(12, 116);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(531, 116);
            this.dtgGarantias.TabIndex = 11;
            // 
            // idGarantiaDataGridViewTextBoxColumn
            // 
            this.idGarantiaDataGridViewTextBoxColumn.DataPropertyName = "idGarantia";
            this.idGarantiaDataGridViewTextBoxColumn.FillWeight = 25F;
            this.idGarantiaDataGridViewTextBoxColumn.HeaderText = "Código Garantía";
            this.idGarantiaDataGridViewTextBoxColumn.Name = "idGarantiaDataGridViewTextBoxColumn";
            this.idGarantiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cGarantiaDataGridViewTextBoxColumn
            // 
            this.cGarantiaDataGridViewTextBoxColumn.DataPropertyName = "cGarantia";
            this.cGarantiaDataGridViewTextBoxColumn.FillWeight = 149.2386F;
            this.cGarantiaDataGridViewTextBoxColumn.HeaderText = "Descripción Garantía";
            this.cGarantiaDataGridViewTextBoxColumn.Name = "cGarantiaDataGridViewTextBoxColumn";
            this.cGarantiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clsGarantiaBindingSource
            // 
            this.clsGarantiaBindingSource.DataSource = typeof(EntityLayer.clsGarantia);
            // 
            // pnlTipGar
            // 
            this.pnlTipGar.Controls.Add(this.flpTiposGar);
            this.pnlTipGar.Controls.Add(this.txtDescripcion);
            this.pnlTipGar.Controls.Add(this.lblBase4);
            this.pnlTipGar.Controls.Add(this.lblBase35);
            this.pnlTipGar.Controls.Add(this.lblBase2);
            this.pnlTipGar.Controls.Add(this.lblBase1);
            this.pnlTipGar.Controls.Add(this.cboTipoGarantia);
            this.pnlTipGar.Controls.Add(this.cboGrupoGarantia);
            this.pnlTipGar.Controls.Add(this.cboClaseGarantia);
            this.pnlTipGar.Location = new System.Drawing.Point(11, 14);
            this.pnlTipGar.Name = "pnlTipGar";
            this.pnlTipGar.Size = new System.Drawing.Size(488, 102);
            this.pnlTipGar.TabIndex = 12;
            // 
            // flpTiposGar
            // 
            this.flpTiposGar.Controls.Add(this.rbtHipoteca);
            this.flpTiposGar.Controls.Add(this.rbtVehiculo);
            this.flpTiposGar.Controls.Add(this.rbtTituloValor);
            this.flpTiposGar.Controls.Add(this.rbtPersonal);
            this.flpTiposGar.Controls.Add(this.rbtElectros);
            this.flpTiposGar.Location = new System.Drawing.Point(247, 25);
            this.flpTiposGar.Margin = new System.Windows.Forms.Padding(0);
            this.flpTiposGar.Name = "flpTiposGar";
            this.flpTiposGar.Size = new System.Drawing.Size(236, 46);
            this.flpTiposGar.TabIndex = 2;
            // 
            // rbtHipoteca
            // 
            this.rbtHipoteca.AutoSize = true;
            this.rbtHipoteca.Checked = true;
            this.rbtHipoteca.Enabled = false;
            this.rbtHipoteca.ForeColor = System.Drawing.Color.Navy;
            this.rbtHipoteca.Location = new System.Drawing.Point(3, 3);
            this.rbtHipoteca.Name = "rbtHipoteca";
            this.rbtHipoteca.Size = new System.Drawing.Size(68, 17);
            this.rbtHipoteca.TabIndex = 0;
            this.rbtHipoteca.TabStop = true;
            this.rbtHipoteca.Text = "Hipoteca";
            this.rbtHipoteca.UseVisualStyleBackColor = true;
            // 
            // rbtVehiculo
            // 
            this.rbtVehiculo.AutoSize = true;
            this.rbtVehiculo.Enabled = false;
            this.rbtVehiculo.ForeColor = System.Drawing.Color.Navy;
            this.rbtVehiculo.Location = new System.Drawing.Point(77, 3);
            this.rbtVehiculo.Name = "rbtVehiculo";
            this.rbtVehiculo.Size = new System.Drawing.Size(68, 17);
            this.rbtVehiculo.TabIndex = 1;
            this.rbtVehiculo.Text = "Vehículo";
            this.rbtVehiculo.UseVisualStyleBackColor = true;
            // 
            // rbtTituloValor
            // 
            this.rbtTituloValor.AutoSize = true;
            this.rbtTituloValor.Enabled = false;
            this.rbtTituloValor.ForeColor = System.Drawing.Color.Navy;
            this.rbtTituloValor.Location = new System.Drawing.Point(151, 3);
            this.rbtTituloValor.Name = "rbtTituloValor";
            this.rbtTituloValor.Size = new System.Drawing.Size(80, 17);
            this.rbtTituloValor.TabIndex = 2;
            this.rbtTituloValor.Text = "Título Valor";
            this.rbtTituloValor.UseVisualStyleBackColor = true;
            // 
            // rbtPersonal
            // 
            this.rbtPersonal.AutoSize = true;
            this.rbtPersonal.Enabled = false;
            this.rbtPersonal.ForeColor = System.Drawing.Color.Navy;
            this.rbtPersonal.Location = new System.Drawing.Point(3, 26);
            this.rbtPersonal.Name = "rbtPersonal";
            this.rbtPersonal.Size = new System.Drawing.Size(66, 17);
            this.rbtPersonal.TabIndex = 3;
            this.rbtPersonal.Text = "Personal";
            this.rbtPersonal.UseVisualStyleBackColor = true;
            // 
            // rbtElectros
            // 
            this.rbtElectros.AutoSize = true;
            this.rbtElectros.Enabled = false;
            this.rbtElectros.ForeColor = System.Drawing.Color.Navy;
            this.rbtElectros.Location = new System.Drawing.Point(75, 26);
            this.rbtElectros.Name = "rbtElectros";
            this.rbtElectros.Size = new System.Drawing.Size(63, 17);
            this.rbtElectros.TabIndex = 4;
            this.rbtElectros.Text = "Electros";
            this.rbtElectros.UseVisualStyleBackColor = true;
            this.rbtElectros.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(114, 3);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(369, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(30, 7);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(78, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Descripción:";
            // 
            // lblBase35
            // 
            this.lblBase35.AutoSize = true;
            this.lblBase35.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase35.ForeColor = System.Drawing.Color.Navy;
            this.lblBase35.Location = new System.Drawing.Point(8, 30);
            this.lblBase35.Name = "lblBase35";
            this.lblBase35.Size = new System.Drawing.Size(100, 13);
            this.lblBase35.TabIndex = 3;
            this.lblBase35.Text = "Grupo Garantía:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 54);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(97, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Clase Garantía:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 78);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(89, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Tipo Garantía:";
            // 
            // cboTipoGarantia
            // 
            this.cboTipoGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGarantia.DropDownWidth = 350;
            this.cboTipoGarantia.FormattingEnabled = true;
            this.cboTipoGarantia.Location = new System.Drawing.Point(114, 74);
            this.cboTipoGarantia.Name = "cboTipoGarantia";
            this.cboTipoGarantia.Size = new System.Drawing.Size(369, 21);
            this.cboTipoGarantia.TabIndex = 3;
            // 
            // cboGrupoGarantia
            // 
            this.cboGrupoGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoGarantia.FormattingEnabled = true;
            this.cboGrupoGarantia.Location = new System.Drawing.Point(114, 26);
            this.cboGrupoGarantia.Name = "cboGrupoGarantia";
            this.cboGrupoGarantia.Size = new System.Drawing.Size(124, 21);
            this.cboGrupoGarantia.TabIndex = 1;
            this.cboGrupoGarantia.SelectedIndexChanged += new System.EventHandler(this.cboGrupoGarantia_SelectedIndexChanged);
            // 
            // cboClaseGarantia
            // 
            this.cboClaseGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaseGarantia.DropDownWidth = 180;
            this.cboClaseGarantia.FormattingEnabled = true;
            this.cboClaseGarantia.Location = new System.Drawing.Point(114, 50);
            this.cboClaseGarantia.Name = "cboClaseGarantia";
            this.cboClaseGarantia.Size = new System.Drawing.Size(124, 21);
            this.cboClaseGarantia.TabIndex = 2;
            this.cboClaseGarantia.SelectedIndexChanged += new System.EventHandler(this.cboClaseGarantia_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlTipGar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(523, 128);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de la Grantía";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 238);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 154);
            this.tabControl1.TabIndex = 13;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(479, 400);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmGarantiasCambioEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 475);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dtgGarantias);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.conBusCliente);
            this.Name = "frmGarantiasCambioEstado";
            this.Text = "Cambio de Estado de Garanía";
            this.Load += new System.EventHandler(this.frmGarantiasCambioEstado_Load);
            this.Controls.SetChildIndex(this.conBusCliente, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.dtgGarantias, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.conBusCliente.ResumeLayout(false);
            this.conBusCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsGarantiaBindingSource)).EndInit();
            this.pnlTipGar.ResumeLayout(false);
            this.pnlTipGar.PerformLayout();
            this.flpTiposGar.ResumeLayout(false);
            this.flpTiposGar.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCliente;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgGarantias;
        private System.Windows.Forms.BindingSource clsGarantiaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGarantiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGarantiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlTipGar;
        private System.Windows.Forms.FlowLayoutPanel flpTiposGar;
        private GEN.ControlesBase.rbtBase rbtHipoteca;
        private GEN.ControlesBase.rbtBase rbtVehiculo;
        private GEN.ControlesBase.rbtBase rbtTituloValor;
        private GEN.ControlesBase.rbtBase rbtPersonal;
        private GEN.ControlesBase.rbtBase rbtElectros;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase35;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoGarantia cboTipoGarantia;
        private GEN.ControlesBase.cboGrupoGarantia cboGrupoGarantia;
        private GEN.ControlesBase.cboClaseGarantia cboClaseGarantia;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private GEN.BotonesBase.btnSalir btnSalir;
    }
}