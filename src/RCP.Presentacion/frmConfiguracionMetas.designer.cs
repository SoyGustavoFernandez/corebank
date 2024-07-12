namespace RCP.Presentacion
{
    partial class frmConfiguracionMetas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionMetas));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboUsuRecuperadores1 = new GEN.ControlesBase.cboUsuRecuperadores(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboVariableRecuperaciones1 = new GEN.ControlesBase.cboVariableRecuperaciones(this.components);
            this.cboPeriodo1 = new GEN.ControlesBase.cboPeriodo(this.components);
            this.dtgConfigMetas = new GEN.ControlesBase.dtgBase(this.components);
            this.idConfigMetasRecuperaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVariableRecuperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVariableRecuperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPorcMeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPorcMinMetaComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPorcMetaBono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nBono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbTodasAgencias = new System.Windows.Forms.CheckBox();
            this.clbAgencias = new System.Windows.Forms.CheckedListBox();
            this.cboTramo1 = new GEN.ControlesBase.cboTramo(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigMetas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Gestor:";
            // 
            // cboUsuRecuperadores1
            // 
            this.cboUsuRecuperadores1.FormattingEnabled = true;
            this.cboUsuRecuperadores1.Location = new System.Drawing.Point(67, 19);
            this.cboUsuRecuperadores1.Name = "cboUsuRecuperadores1";
            this.cboUsuRecuperadores1.Size = new System.Drawing.Size(689, 21);
            this.cboUsuRecuperadores1.TabIndex = 0;
            this.cboUsuRecuperadores1.SelectedIndexChanged += new System.EventHandler(this.cboUsuRecuperadores1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(393, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 49);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Periodo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(7, 102);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(58, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Variable:";
            // 
            // cboVariableRecuperaciones1
            // 
            this.cboVariableRecuperaciones1.FormattingEnabled = true;
            this.cboVariableRecuperaciones1.Location = new System.Drawing.Point(67, 99);
            this.cboVariableRecuperaciones1.Name = "cboVariableRecuperaciones1";
            this.cboVariableRecuperaciones1.Size = new System.Drawing.Size(320, 21);
            this.cboVariableRecuperaciones1.TabIndex = 3;
            this.cboVariableRecuperaciones1.SelectedIndexChanged += new System.EventHandler(this.cboVariableRecuperaciones1_SelectedIndexChanged);
            // 
            // cboPeriodo1
            // 
            this.cboPeriodo1.FormattingEnabled = true;
            this.cboPeriodo1.Location = new System.Drawing.Point(67, 46);
            this.cboPeriodo1.Name = "cboPeriodo1";
            this.cboPeriodo1.Size = new System.Drawing.Size(320, 21);
            this.cboPeriodo1.TabIndex = 1;
            this.cboPeriodo1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodo1_SelectedIndexChanged);
            // 
            // dtgConfigMetas
            // 
            this.dtgConfigMetas.AllowUserToAddRows = false;
            this.dtgConfigMetas.AllowUserToDeleteRows = false;
            this.dtgConfigMetas.AllowUserToResizeColumns = false;
            this.dtgConfigMetas.AllowUserToResizeRows = false;
            this.dtgConfigMetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfigMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigMetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConfigMetasRecuperaciones,
            this.idAgencia,
            this.cNombreAge,
            this.idTramo,
            this.cNombre,
            this.cPeriodo,
            this.idVariableRecuperacion,
            this.cVariableRecuperacion,
            this.nPorcMeta,
            this.nPorcMinMetaComision,
            this.nComision,
            this.nPorcMetaBono,
            this.nBono});
            this.dtgConfigMetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgConfigMetas.Location = new System.Drawing.Point(3, 16);
            this.dtgConfigMetas.MultiSelect = false;
            this.dtgConfigMetas.Name = "dtgConfigMetas";
            this.dtgConfigMetas.ReadOnly = true;
            this.dtgConfigMetas.RowHeadersVisible = false;
            this.dtgConfigMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigMetas.Size = new System.Drawing.Size(768, 275);
            this.dtgConfigMetas.TabIndex = 0;
            // 
            // idConfigMetasRecuperaciones
            // 
            this.idConfigMetasRecuperaciones.DataPropertyName = "idConfigMetasRecuperaciones";
            this.idConfigMetasRecuperaciones.HeaderText = "idConfigMetasRecuperaciones";
            this.idConfigMetasRecuperaciones.Name = "idConfigMetasRecuperaciones";
            this.idConfigMetasRecuperaciones.ReadOnly = true;
            this.idConfigMetasRecuperaciones.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // cNombreAge
            // 
            this.cNombreAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.HeaderText = "Agencia";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            this.cNombreAge.Width = 71;
            // 
            // idTramo
            // 
            this.idTramo.DataPropertyName = "idTramo";
            this.idTramo.HeaderText = "idTramo";
            this.idTramo.Name = "idTramo";
            this.idTramo.ReadOnly = true;
            this.idTramo.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Tramo";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 62;
            // 
            // cPeriodo
            // 
            this.cPeriodo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cPeriodo.DataPropertyName = "cPeriodo";
            this.cPeriodo.HeaderText = "Periodo";
            this.cPeriodo.Name = "cPeriodo";
            this.cPeriodo.ReadOnly = true;
            this.cPeriodo.Width = 68;
            // 
            // idVariableRecuperacion
            // 
            this.idVariableRecuperacion.DataPropertyName = "idVariableRecuperacion";
            this.idVariableRecuperacion.HeaderText = "idVariableRecuperacion";
            this.idVariableRecuperacion.Name = "idVariableRecuperacion";
            this.idVariableRecuperacion.ReadOnly = true;
            this.idVariableRecuperacion.Visible = false;
            // 
            // cVariableRecuperacion
            // 
            this.cVariableRecuperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cVariableRecuperacion.DataPropertyName = "cVariableRecuperacion";
            this.cVariableRecuperacion.HeaderText = "Variable";
            this.cVariableRecuperacion.Name = "cVariableRecuperacion";
            this.cVariableRecuperacion.ReadOnly = true;
            this.cVariableRecuperacion.Width = 70;
            // 
            // nPorcMeta
            // 
            this.nPorcMeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nPorcMeta.DataPropertyName = "nPorcMeta";
            this.nPorcMeta.HeaderText = "Meta (%)";
            this.nPorcMeta.Name = "nPorcMeta";
            this.nPorcMeta.ReadOnly = true;
            this.nPorcMeta.Width = 68;
            // 
            // nPorcMinMetaComision
            // 
            this.nPorcMinMetaComision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nPorcMinMetaComision.DataPropertyName = "nPorcMinMetaComision";
            this.nPorcMinMetaComision.HeaderText = "Min. Para Comisión (%)";
            this.nPorcMinMetaComision.Name = "nPorcMinMetaComision";
            this.nPorcMinMetaComision.ReadOnly = true;
            this.nPorcMinMetaComision.Width = 114;
            // 
            // nComision
            // 
            this.nComision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nComision.DataPropertyName = "nComision";
            this.nComision.HeaderText = "Comision (%)";
            this.nComision.Name = "nComision";
            this.nComision.ReadOnly = true;
            this.nComision.Width = 84;
            // 
            // nPorcMetaBono
            // 
            this.nPorcMetaBono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nPorcMetaBono.DataPropertyName = "nPorcMetaBono";
            this.nPorcMetaBono.HeaderText = "Meta Bono (%)";
            this.nPorcMetaBono.Name = "nPorcMetaBono";
            this.nPorcMetaBono.ReadOnly = true;
            this.nPorcMetaBono.Width = 80;
            // 
            // nBono
            // 
            this.nBono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nBono.DataPropertyName = "nBono";
            this.nBono.HeaderText = "Bono (%)";
            this.nBono.Name = "nBono";
            this.nBono.ReadOnly = true;
            this.nBono.Width = 69;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbTodasAgencias);
            this.groupBox1.Controls.Add(this.clbAgencias);
            this.groupBox1.Controls.Add(this.cboTramo1);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.cboUsuRecuperadores1);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboPeriodo1);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.cboVariableRecuperaciones1);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // chbTodasAgencias
            // 
            this.chbTodasAgencias.AutoSize = true;
            this.chbTodasAgencias.Location = new System.Drawing.Point(450, 110);
            this.chbTodasAgencias.Name = "chbTodasAgencias";
            this.chbTodasAgencias.Size = new System.Drawing.Size(119, 17);
            this.chbTodasAgencias.TabIndex = 4;
            this.chbTodasAgencias.Text = "Todas las Agencias";
            this.chbTodasAgencias.UseVisualStyleBackColor = true;
            this.chbTodasAgencias.CheckedChanged += new System.EventHandler(this.chbTodasAgencias_CheckedChanged);
            // 
            // clbAgencias
            // 
            this.clbAgencias.CheckOnClick = true;
            this.clbAgencias.FormattingEnabled = true;
            this.clbAgencias.Location = new System.Drawing.Point(450, 46);
            this.clbAgencias.Name = "clbAgencias";
            this.clbAgencias.Size = new System.Drawing.Size(306, 49);
            this.clbAgencias.TabIndex = 5;
            this.clbAgencias.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbAgencias_ItemCheck);
            this.clbAgencias.SelectedValueChanged += new System.EventHandler(this.clbAgencias_SelectedValueChanged);
            // 
            // cboTramo1
            // 
            this.cboTramo1.FormattingEnabled = true;
            this.cboTramo1.Location = new System.Drawing.Point(67, 72);
            this.cboTramo1.Name = "cboTramo1";
            this.cboTramo1.Size = new System.Drawing.Size(320, 21);
            this.cboTramo1.TabIndex = 2;
            this.cboTramo1.SelectedIndexChanged += new System.EventHandler(this.cboTramo1_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 76);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(48, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Tramo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgConfigMetas);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración";
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(606, 450);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 2;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(672, 450);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(738, 450);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmConfiguracionMetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 533);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConfiguracionMetas";
            this.Text = "Configuración Metas";
            this.Load += new System.EventHandler(this.frmConfiguracionMetas_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigMetas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboUsuRecuperadores cboUsuRecuperadores1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboVariableRecuperaciones cboVariableRecuperaciones1;
        private GEN.ControlesBase.cboPeriodo cboPeriodo1;
        private GEN.ControlesBase.dtgBase dtgConfigMetas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboTramo cboTramo1;
        private System.Windows.Forms.CheckedListBox clbAgencias;
        private System.Windows.Forms.CheckBox chbTodasAgencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConfigMetasRecuperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVariableRecuperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVariableRecuperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPorcMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPorcMinMetaComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn nComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPorcMetaBono;
        private System.Windows.Forms.DataGridViewTextBoxColumn nBono;
    }
}