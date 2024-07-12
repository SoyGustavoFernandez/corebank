namespace LOG.Presentacion
{
    partial class frmBuscarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarProveedor));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblNroDoc = new GEN.ControlesBase.lblBase();
            this.txtNroDoc = new GEN.ControlesBase.txtCBNroDocumentos(this.components);
            this.txtProveedor = new GEN.ControlesBase.txtCBLetra(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.dtgProveedor = new GEN.ControlesBase.dtgBase(this.components);
            this.idProveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreComercialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRubroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsListaProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboTipDocumento = new GEN.ControlesBase.cboTipDocumento(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtBase2 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtBase1 = new GEN.ControlesBase.rbtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsListaProveedoresBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 94);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(71, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Proveedor:";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroDoc.ForeColor = System.Drawing.Color.Navy;
            this.lblNroDoc.Location = new System.Drawing.Point(11, 69);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(101, 13);
            this.lblNroDoc.TabIndex = 3;
            this.lblNroDoc.Text = "Nro Documento:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(141, 66);
            this.txtNroDoc.MaxLength = 13;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(189, 20);
            this.txtNroDoc.TabIndex = 5;
            this.txtNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDoc_KeyPress);
            // 
            // txtProveedor
            // 
            this.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedor.Location = new System.Drawing.Point(141, 91);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(339, 20);
            this.txtProveedor.TabIndex = 6;
            this.txtProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProveedor_KeyPress);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(486, 61);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 7;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // dtgProveedor
            // 
            this.dtgProveedor.AllowUserToAddRows = false;
            this.dtgProveedor.AllowUserToDeleteRows = false;
            this.dtgProveedor.AllowUserToResizeColumns = false;
            this.dtgProveedor.AllowUserToResizeRows = false;
            this.dtgProveedor.AutoGenerateColumns = false;
            this.dtgProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProveedorDataGridViewTextBoxColumn,
            this.cNombreDataGridViewTextBoxColumn,
            this.cDocumentoIDDataGridViewTextBoxColumn,
            this.cNombreComercialDataGridViewTextBoxColumn,
            this.cRubroDataGridViewTextBoxColumn});
            this.dtgProveedor.DataSource = this.clsListaProveedoresBindingSource;
            this.dtgProveedor.Location = new System.Drawing.Point(15, 117);
            this.dtgProveedor.MultiSelect = false;
            this.dtgProveedor.Name = "dtgProveedor";
            this.dtgProveedor.ReadOnly = true;
            this.dtgProveedor.RowHeadersVisible = false;
            this.dtgProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProveedor.Size = new System.Drawing.Size(531, 135);
            this.dtgProveedor.TabIndex = 8;
            // 
            // idProveedorDataGridViewTextBoxColumn
            // 
            this.idProveedorDataGridViewTextBoxColumn.DataPropertyName = "idProveedor";
            this.idProveedorDataGridViewTextBoxColumn.FillWeight = 60F;
            this.idProveedorDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idProveedorDataGridViewTextBoxColumn.Name = "idProveedorDataGridViewTextBoxColumn";
            this.idProveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNombreDataGridViewTextBoxColumn
            // 
            this.cNombreDataGridViewTextBoxColumn.DataPropertyName = "cNombre";
            this.cNombreDataGridViewTextBoxColumn.HeaderText = "Nombre Proveedor";
            this.cNombreDataGridViewTextBoxColumn.Name = "cNombreDataGridViewTextBoxColumn";
            this.cNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDocumentoIDDataGridViewTextBoxColumn
            // 
            this.cDocumentoIDDataGridViewTextBoxColumn.DataPropertyName = "cDocumentoID";
            this.cDocumentoIDDataGridViewTextBoxColumn.HeaderText = "Nro Documento";
            this.cDocumentoIDDataGridViewTextBoxColumn.Name = "cDocumentoIDDataGridViewTextBoxColumn";
            this.cDocumentoIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNombreComercialDataGridViewTextBoxColumn
            // 
            this.cNombreComercialDataGridViewTextBoxColumn.DataPropertyName = "cNombreComercial";
            this.cNombreComercialDataGridViewTextBoxColumn.HeaderText = "Nombre Comercial";
            this.cNombreComercialDataGridViewTextBoxColumn.Name = "cNombreComercialDataGridViewTextBoxColumn";
            this.cNombreComercialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cRubroDataGridViewTextBoxColumn
            // 
            this.cRubroDataGridViewTextBoxColumn.DataPropertyName = "cRubro";
            this.cRubroDataGridViewTextBoxColumn.HeaderText = "Rubro";
            this.cRubroDataGridViewTextBoxColumn.Name = "cRubroDataGridViewTextBoxColumn";
            this.cRubroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clsListaProveedoresBindingSource
            // 
            this.clsListaProveedoresBindingSource.DataSource = typeof(EntityLayer.clsListaProveedores);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(426, 258);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 9;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(486, 258);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboTipDocumento
            // 
            this.cboTipDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocumento.FormattingEnabled = true;
            this.cboTipDocumento.Location = new System.Drawing.Point(141, 41);
            this.cboTipDocumento.Name = "cboTipDocumento";
            this.cboTipDocumento.Size = new System.Drawing.Size(189, 21);
            this.cboTipDocumento.TabIndex = 12;
            this.cboTipDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipDocumento_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 44);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(105, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Tipo Documento:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 13);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(114, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Tipo de Busqueda:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtBase2);
            this.grbBase1.Controls.Add(this.rbtBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(9, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(537, 32);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            // 
            // rbtBase2
            // 
            this.rbtBase2.AutoSize = true;
            this.rbtBase2.ForeColor = System.Drawing.Color.Navy;
            this.rbtBase2.Location = new System.Drawing.Point(315, 11);
            this.rbtBase2.Name = "rbtBase2";
            this.rbtBase2.Size = new System.Drawing.Size(93, 17);
            this.rbtBase2.TabIndex = 15;
            this.rbtBase2.TabStop = true;
            this.rbtBase2.Text = "Por Proveedor";
            this.rbtBase2.UseVisualStyleBackColor = true;
            this.rbtBase2.CheckedChanged += new System.EventHandler(this.rbtBase2_CheckedChanged);
            // 
            // rbtBase1
            // 
            this.rbtBase1.AutoSize = true;
            this.rbtBase1.Checked = true;
            this.rbtBase1.ForeColor = System.Drawing.Color.Navy;
            this.rbtBase1.Location = new System.Drawing.Point(132, 11);
            this.rbtBase1.Name = "rbtBase1";
            this.rbtBase1.Size = new System.Drawing.Size(138, 17);
            this.rbtBase1.TabIndex = 14;
            this.rbtBase1.TabStop = true;
            this.rbtBase1.Text = "Por Tipo de Documento";
            this.rbtBase1.UseVisualStyleBackColor = true;
            this.rbtBase1.CheckedChanged += new System.EventHandler(this.rbtBase1_CheckedChanged);
            // 
            // frmBuscarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 337);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.cboTipDocumento);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.dtgProveedor);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.lblNroDoc);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmBuscarProveedor";
            this.Text = "Buscar Proveedor";
            this.Load += new System.EventHandler(this.frmBuscarProveedor_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblNroDoc, 0);
            this.Controls.SetChildIndex(this.txtNroDoc, 0);
            this.Controls.SetChildIndex(this.txtProveedor, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.dtgProveedor, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipDocumento, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsListaProveedoresBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblNroDoc;
        private GEN.ControlesBase.txtCBNroDocumentos txtNroDoc;
        private GEN.ControlesBase.txtCBLetra txtProveedor;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtgBase dtgProveedor;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreComercialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRubroDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clsListaProveedoresBindingSource;
        private GEN.ControlesBase.cboTipDocumento cboTipDocumento;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtBase2;
        private GEN.ControlesBase.rbtBase rbtBase1;
    }
}