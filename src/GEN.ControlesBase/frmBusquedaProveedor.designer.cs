namespace GEN.ControlesBase
{
    partial class frmBusquedaProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaProveedor));
            this.btnBusProveedor = new GEN.BotonesBase.btnBusCliente();
            this.cboCriBusCli = new GEN.ControlesBase.cboCriBusCli(this.components);
            this.txtDniNom = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgProveedores = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtaDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCuentaCorriente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBusProveedor
            // 
            this.btnBusProveedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusProveedor.BackgroundImage")));
            this.btnBusProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusProveedor.Location = new System.Drawing.Point(416, 6);
            this.btnBusProveedor.Name = "btnBusProveedor";
            this.btnBusProveedor.Size = new System.Drawing.Size(60, 50);
            this.btnBusProveedor.TabIndex = 6;
            this.btnBusProveedor.Text = "Cliente";
            this.btnBusProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusProveedor.UseVisualStyleBackColor = true;
            this.btnBusProveedor.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // cboCriBusCli
            // 
            this.cboCriBusCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriBusCli.FormattingEnabled = true;
            this.cboCriBusCli.Location = new System.Drawing.Point(134, 6);
            this.cboCriBusCli.Name = "cboCriBusCli";
            this.cboCriBusCli.Size = new System.Drawing.Size(276, 21);
            this.cboCriBusCli.TabIndex = 11;
            this.cboCriBusCli.SelectedIndexChanged += new System.EventHandler(this.cboCriBusCli_SelectedIndexChanged);
            // 
            // txtDniNom
            // 
            this.txtDniNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDniNom.Location = new System.Drawing.Point(134, 34);
            this.txtDniNom.Name = "txtDniNom";
            this.txtDniNom.Size = new System.Drawing.Size(276, 20);
            this.txtDniNom.TabIndex = 5;
            this.txtDniNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniNom_KeyPress);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(556, 251);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgProveedores
            // 
            this.dtgProveedores.AllowUserToAddRows = false;
            this.dtgProveedores.AllowUserToDeleteRows = false;
            this.dtgProveedores.AllowUserToResizeColumns = false;
            this.dtgProveedores.AllowUserToResizeRows = false;
            this.dtgProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProveedor,
            this.cCtaDetraccion,
            this.cCuentaCorriente,
            this.cNombre,
            this.cDocumentoID,
            this.idCli,
            this.cNombreComercial,
            this.cDireccion,
            this.IdTipoPersona,
            this.cCodCliente,
            this.idTipoDocumento});
            this.dtgProveedores.Location = new System.Drawing.Point(10, 69);
            this.dtgProveedores.MultiSelect = false;
            this.dtgProveedores.Name = "dtgProveedores";
            this.dtgProveedores.ReadOnly = true;
            this.dtgProveedores.RowHeadersVisible = false;
            this.dtgProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProveedores.Size = new System.Drawing.Size(645, 176);
            this.dtgProveedores.TabIndex = 10;
            this.dtgProveedores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgClientes_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(490, 251);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(10, 37);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(34, 13);
            this.lblCriterio.TabIndex = 12;
            this.lblCriterio.Text = "DNI:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(115, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Criterio Busqueda:";
            // 
            // idProveedor
            // 
            this.idProveedor.DataPropertyName = "idProveedor";
            this.idProveedor.FillWeight = 40F;
            this.idProveedor.HeaderText = "Cod. Prov.";
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            // 
            // cCtaDetraccion
            // 
            this.cCtaDetraccion.DataPropertyName = "cCtaDetraccion";
            this.cCtaDetraccion.FillWeight = 140F;
            this.cCtaDetraccion.HeaderText = "Cta. Detraccion";
            this.cCtaDetraccion.Name = "cCtaDetraccion";
            this.cCtaDetraccion.ReadOnly = true;
            // 
            // cCuentaCorriente
            // 
            this.cCuentaCorriente.DataPropertyName = "cCuentaCorriente";
            this.cCuentaCorriente.HeaderText = "Cta. Corriente";
            this.cCuentaCorriente.Name = "cCuentaCorriente";
            this.cCuentaCorriente.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 150F;
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.HeaderText = "Num. Doc.";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // cNombreComercial
            // 
            this.cNombreComercial.DataPropertyName = "cNombreComercial";
            this.cNombreComercial.HeaderText = "cNombreComercial";
            this.cNombreComercial.Name = "cNombreComercial";
            this.cNombreComercial.ReadOnly = true;
            this.cNombreComercial.Visible = false;
            // 
            // cDireccion
            // 
            this.cDireccion.DataPropertyName = "cDireccion";
            this.cDireccion.HeaderText = "cDireccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Visible = false;
            // 
            // IdTipoPersona
            // 
            this.IdTipoPersona.DataPropertyName = "IdTipoPersona";
            this.IdTipoPersona.HeaderText = "IdTipoPersona";
            this.IdTipoPersona.Name = "IdTipoPersona";
            this.IdTipoPersona.ReadOnly = true;
            this.IdTipoPersona.Visible = false;
            // 
            // cCodCliente
            // 
            this.cCodCliente.DataPropertyName = "cCodCliente";
            this.cCodCliente.HeaderText = "cCodCliente";
            this.cCodCliente.Name = "cCodCliente";
            this.cCodCliente.ReadOnly = true;
            this.cCodCliente.Visible = false;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // frmBusquedaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 333);
            this.Controls.Add(this.btnBusProveedor);
            this.Controls.Add(this.cboCriBusCli);
            this.Controls.Add(this.txtDniNom);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgProveedores);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmBusquedaProveedor";
            this.Text = "Buscar Proveedor";
            this.Load += new System.EventHandler(this.frmSeleccionarProveedor_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.dtgProveedores, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtDniNom, 0);
            this.Controls.SetChildIndex(this.cboCriBusCli, 0);
            this.Controls.SetChildIndex(this.btnBusProveedor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnBusCliente btnBusProveedor;
        private cboCriBusCli cboCriBusCli;
        private txtBase txtDniNom;
        private BotonesBase.btnSalir btnSalir1;
        private dtgBase dtgProveedores;
        private BotonesBase.BtnAceptar btnAceptar;
        private lblBase lblCriterio;
        private lblBase lblBase1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtaDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCuentaCorriente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreComercial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;

    }
}