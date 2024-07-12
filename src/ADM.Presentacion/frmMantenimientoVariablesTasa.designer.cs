namespace ADM.Presentacion
{
    partial class frmMantenimientoVariablesTasa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoVariablesTasa));
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciav = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtgVariables = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValVar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCargaVarApl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtValorVariable = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.txtItem = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVariables)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.cboAgenciav);
            this.grbBase4.Controls.Add(this.lblBase7);
            this.grbBase4.Location = new System.Drawing.Point(10, 6);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(452, 46);
            this.grbBase4.TabIndex = 10;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Filtros";
            // 
            // cboAgenciav
            // 
            this.cboAgenciav.DropDownHeight = 200;
            this.cboAgenciav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciav.DropDownWidth = 284;
            this.cboAgenciav.FormattingEnabled = true;
            this.cboAgenciav.IntegralHeight = false;
            this.cboAgenciav.Location = new System.Drawing.Point(153, 17);
            this.cboAgenciav.MaxDropDownItems = 15;
            this.cboAgenciav.Name = "cboAgenciav";
            this.cboAgenciav.Size = new System.Drawing.Size(285, 21);
            this.cboAgenciav.TabIndex = 143;
            this.cboAgenciav.SelectedIndexChanged += new System.EventHandler(this.cboAgenciav_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(20, 22);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(127, 13);
            this.lblBase7.TabIndex = 124;
            this.lblBase7.Text = "Seleccionar Agencia:";
            // 
            // dtgVariables
            // 
            this.dtgVariables.AllowUserToAddRows = false;
            this.dtgVariables.AllowUserToDeleteRows = false;
            this.dtgVariables.AllowUserToResizeColumns = false;
            this.dtgVariables.AllowUserToResizeRows = false;
            this.dtgVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.idVariable,
            this.cDescripcion,
            this.cVariable,
            this.cTipoVariable,
            this.cValVar,
            this.idAgencia,
            this.lCargaVarApl,
            this.lVigente});
            this.dtgVariables.Location = new System.Drawing.Point(9, 58);
            this.dtgVariables.MultiSelect = false;
            this.dtgVariables.Name = "dtgVariables";
            this.dtgVariables.ReadOnly = true;
            this.dtgVariables.RowHeadersVisible = false;
            this.dtgVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVariables.Size = new System.Drawing.Size(453, 291);
            this.dtgVariables.TabIndex = 123;
            this.dtgVariables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVariables_CellContentClick);
            this.dtgVariables.SelectionChanged += new System.EventHandler(this.dtgVariables_SelectionChanged);
            // 
            // Item
            // 
            this.Item.DataPropertyName = "Item";
            this.Item.FillWeight = 25.38071F;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // idVariable
            // 
            this.idVariable.DataPropertyName = "idVariable";
            this.idVariable.FillWeight = 65.29341F;
            this.idVariable.HeaderText = "Codigo Variable";
            this.idVariable.Name = "idVariable";
            this.idVariable.ReadOnly = true;
            this.idVariable.Visible = false;
            // 
            // cDescripcion
            // 
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.FillWeight = 174.6193F;
            this.cDescripcion.HeaderText = "Descripcion";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // cVariable
            // 
            this.cVariable.DataPropertyName = "cVariable";
            this.cVariable.FillWeight = 125.744F;
            this.cVariable.HeaderText = "Nombre Variable";
            this.cVariable.Name = "cVariable";
            this.cVariable.ReadOnly = true;
            this.cVariable.Visible = false;
            // 
            // cTipoVariable
            // 
            this.cTipoVariable.DataPropertyName = "cTipoVariable";
            this.cTipoVariable.FillWeight = 56.6783F;
            this.cTipoVariable.HeaderText = "Tipo de Dato";
            this.cTipoVariable.Name = "cTipoVariable";
            this.cTipoVariable.ReadOnly = true;
            this.cTipoVariable.Visible = false;
            // 
            // cValVar
            // 
            this.cValVar.DataPropertyName = "cValVar";
            this.cValVar.HeaderText = "cValVar";
            this.cValVar.Name = "cValVar";
            this.cValVar.ReadOnly = true;
            this.cValVar.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // lCargaVarApl
            // 
            this.lCargaVarApl.DataPropertyName = "lCargaVarApl";
            this.lCargaVarApl.HeaderText = "lCargaVarApl";
            this.lCargaVarApl.Name = "lCargaVarApl";
            this.lCargaVarApl.ReadOnly = true;
            this.lCargaVarApl.Visible = false;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(134, 52);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(353, 40);
            this.txtDescripcion.TabIndex = 128;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(4, 55);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(128, 13);
            this.lblBase1.TabIndex = 129;
            this.lblBase1.Text = "Descripción Variable:";
            // 
            // txtValorVariable
            // 
            this.txtValorVariable.BackColor = System.Drawing.SystemColors.Window;
            this.txtValorVariable.Location = new System.Drawing.Point(134, 98);
            this.txtValorVariable.Multiline = true;
            this.txtValorVariable.Name = "txtValorVariable";
            this.txtValorVariable.Size = new System.Drawing.Size(353, 100);
            this.txtValorVariable.TabIndex = 132;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(23, 101);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 13);
            this.lblBase4.TabIndex = 133;
            this.lblBase4.Text = "Valor de Variable:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 25);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 135;
            this.lblBase5.Text = "Agencia:";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(136, 22);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(244, 21);
            this.cboAgencia1.TabIndex = 134;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.cboAgencia1);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.txtValorVariable);
            this.grbBase2.Controls.Add(this.txtDescripcion);
            this.grbBase2.Controls.Add(this.txtItem);
            this.grbBase2.Location = new System.Drawing.Point(468, 6);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(493, 212);
            this.grbBase2.TabIndex = 137;
            this.grbBase2.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(895, 224);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 142;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(835, 224);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 138;
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
            this.btnCancelar.Location = new System.Drawing.Point(775, 224);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 139;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(715, 224);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 140;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(377, 67);
            this.txtItem.Multiline = true;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(27, 25);
            this.txtItem.TabIndex = 143;
            // 
            // frmMantenimientoVariablesTasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 381);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgVariables);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmMantenimientoVariablesTasa";
            this.Text = "Mantenimiento de variables de negocio";
            this.Load += new System.EventHandler(this.frmMantenimientoVariables_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.dtgVariables, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVariables)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase4;
        private System.Windows.Forms.DataGridView dtgVariables;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtValorVariable;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValVar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn lCargaVarApl;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
        private GEN.ControlesBase.cboBase cboAgenciav;
        private GEN.ControlesBase.txtBase txtItem;
    }
}