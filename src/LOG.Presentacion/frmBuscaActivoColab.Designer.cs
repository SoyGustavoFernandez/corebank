namespace LOG.Presentacion
{
    partial class frmBuscaActivoColab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaActivoColab));
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.btnBusqCol = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtColabResp = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCodActivo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.chcSerieActivo = new GEN.ControlesBase.chcBase(this.components);
            this.chcCodActivo = new GEN.ControlesBase.chcBase(this.components);
            this.chcPersResponsable = new GEN.ControlesBase.chcBase(this.components);
            this.txtSerie = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgActivoOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreColReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreColResp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.Enabled = false;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(185, 43);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(190, 21);
            this.cboAgencias.TabIndex = 23;
            // 
            // btnBusqCol
            // 
            this.btnBusqCol.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqCol.BackgroundImage")));
            this.btnBusqCol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqCol.Location = new System.Drawing.Point(477, 17);
            this.btnBusqCol.Name = "btnBusqCol";
            this.btnBusqCol.Size = new System.Drawing.Size(39, 24);
            this.btnBusqCol.TabIndex = 22;
            this.btnBusqCol.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqCol.UseVisualStyleBackColor = true;
            this.btnBusqCol.Click += new System.EventHandler(this.btnBusqCol_Click);
            // 
            // txtColabResp
            // 
            this.txtColabResp.Enabled = false;
            this.txtColabResp.Location = new System.Drawing.Point(185, 19);
            this.txtColabResp.Name = "txtColabResp";
            this.txtColabResp.Size = new System.Drawing.Size(286, 20);
            this.txtColabResp.TabIndex = 21;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtCodActivo);
            this.grbBase1.Controls.Add(this.chcSerieActivo);
            this.grbBase1.Controls.Add(this.chcCodActivo);
            this.grbBase1.Controls.Add(this.chcPersResponsable);
            this.grbBase1.Controls.Add(this.txtSerie);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtColabResp);
            this.grbBase1.Controls.Add(this.btnBusqCol);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(531, 128);
            this.grbBase1.TabIndex = 24;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtro de Busqueda";
            // 
            // txtCodActivo
            // 
            this.txtCodActivo.Location = new System.Drawing.Point(185, 70);
            this.txtCodActivo.Name = "txtCodActivo";
            this.txtCodActivo.Size = new System.Drawing.Size(129, 20);
            this.txtCodActivo.TabIndex = 34;
            this.txtCodActivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodActivo_KeyPress);
            // 
            // chcSerieActivo
            // 
            this.chcSerieActivo.AutoSize = true;
            this.chcSerieActivo.Location = new System.Drawing.Point(16, 97);
            this.chcSerieActivo.Name = "chcSerieActivo";
            this.chcSerieActivo.Size = new System.Drawing.Size(15, 14);
            this.chcSerieActivo.TabIndex = 33;
            this.chcSerieActivo.UseVisualStyleBackColor = true;
            this.chcSerieActivo.CheckedChanged += new System.EventHandler(this.chcSerieActivo_CheckedChanged);
            // 
            // chcCodActivo
            // 
            this.chcCodActivo.AutoSize = true;
            this.chcCodActivo.Location = new System.Drawing.Point(16, 74);
            this.chcCodActivo.Name = "chcCodActivo";
            this.chcCodActivo.Size = new System.Drawing.Size(15, 14);
            this.chcCodActivo.TabIndex = 32;
            this.chcCodActivo.UseVisualStyleBackColor = true;
            this.chcCodActivo.CheckedChanged += new System.EventHandler(this.chcCodActivo_CheckedChanged);
            // 
            // chcPersResponsable
            // 
            this.chcPersResponsable.AutoSize = true;
            this.chcPersResponsable.Location = new System.Drawing.Point(16, 23);
            this.chcPersResponsable.Name = "chcPersResponsable";
            this.chcPersResponsable.Size = new System.Drawing.Size(15, 14);
            this.chcPersResponsable.TabIndex = 31;
            this.chcPersResponsable.UseVisualStyleBackColor = true;
            this.chcPersResponsable.CheckedChanged += new System.EventHandler(this.chcPersResponsable_CheckedChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(185, 94);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(190, 20);
            this.txtSerie.TabIndex = 30;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(37, 73);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(91, 13);
            this.lblBase3.TabIndex = 27;
            this.lblBase3.Text = "Código Activo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(37, 97);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(81, 13);
            this.lblBase4.TabIndex = 28;
            this.lblBase4.Text = "Serie Activo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(37, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 26;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(37, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(137, 13);
            this.lblBase1.TabIndex = 25;
            this.lblBase1.Text = "Personal Responsable:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "ORIGEN DEL ACTIVO:";
            // 
            // dtgActivoOrigen
            // 
            this.dtgActivoOrigen.AllowUserToAddRows = false;
            this.dtgActivoOrigen.AllowUserToDeleteRows = false;
            this.dtgActivoOrigen.AllowUserToResizeColumns = false;
            this.dtgActivoOrigen.AllowUserToResizeRows = false;
            this.dtgActivoOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivoOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivoOrigen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.idActivo,
            this.idCatalogo,
            this.cProducto,
            this.cNombreColReg,
            this.cNombreColResp});
            this.dtgActivoOrigen.Location = new System.Drawing.Point(12, 169);
            this.dtgActivoOrigen.MultiSelect = false;
            this.dtgActivoOrigen.Name = "dtgActivoOrigen";
            this.dtgActivoOrigen.ReadOnly = true;
            this.dtgActivoOrigen.RowHeadersVisible = false;
            this.dtgActivoOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivoOrigen.Size = new System.Drawing.Size(810, 146);
            this.dtgActivoOrigen.TabIndex = 25;
            this.dtgActivoOrigen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActivoOrigen_CellContentClick);
            // 
            // chk
            // 
            this.chk.DataPropertyName = "chk";
            this.chk.FillWeight = 38.09899F;
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            // 
            // idActivo
            // 
            this.idActivo.DataPropertyName = "idActivo";
            this.idActivo.FillWeight = 48.20542F;
            this.idActivo.HeaderText = "Cod Activo";
            this.idActivo.Name = "idActivo";
            this.idActivo.ReadOnly = true;
            // 
            // idCatalogo
            // 
            this.idCatalogo.DataPropertyName = "idCatalogo";
            this.idCatalogo.FillWeight = 48.3838F;
            this.idCatalogo.HeaderText = "Cod Catálogo";
            this.idCatalogo.Name = "idCatalogo";
            this.idCatalogo.ReadOnly = true;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.FillWeight = 173.5753F;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cNombreColReg
            // 
            this.cNombreColReg.DataPropertyName = "cNombreColReg";
            this.cNombreColReg.FillWeight = 120F;
            this.cNombreColReg.HeaderText = "Colaborador Registro";
            this.cNombreColReg.Name = "cNombreColReg";
            this.cNombreColReg.ReadOnly = true;
            // 
            // cNombreColResp
            // 
            this.cNombreColResp.DataPropertyName = "cNombreColResp";
            this.cNombreColResp.FillWeight = 120F;
            this.cNombreColResp.HeaderText = "Colaborador Responsable";
            this.cNombreColResp.Name = "cNombreColResp";
            this.cNombreColResp.ReadOnly = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(696, 321);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 27;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(762, 321);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 28;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(15, 321);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 29;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // frmBuscaActivoColab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 403);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgActivoOrigen);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmBuscaActivoColab";
            this.Text = "Busca Activos por Personal";
            this.Load += new System.EventHandler(this.frmBuscaActivoColab_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgActivoOrigen, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.BotonesBase.btnMiniBusq btnBusqCol;
        private GEN.ControlesBase.txtBase txtColabResp;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtSerie;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.dtgBase dtgActivoOrigen;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.chcBase chcSerieActivo;
        private GEN.ControlesBase.chcBase chcCodActivo;
        private GEN.ControlesBase.chcBase chcPersResponsable;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodActivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreColReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreColResp;
    }
}