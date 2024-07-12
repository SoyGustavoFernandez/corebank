namespace CAJ.Presentacion
{
    partial class frmBusquedaCuentaInst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaCuentaInst));
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.dtgCuentasInst = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblTipoCuenta = new GEN.ControlesBase.lblBase();
            this.lblTipoEntidad = new GEN.ControlesBase.lblBase();
            this.cboTipoEntidad = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboTipoCuentaBco = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.txtNumeroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.chcBuscarCuenta = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasInst)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(13, 71);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 2;
            this.lblEntidad.Text = "Entidad:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(13, 125);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(77, 13);
            this.lblCriterio.TabIndex = 3;
            this.lblCriterio.Text = "Nro Cuenta:";
            // 
            // dtgCuentasInst
            // 
            this.dtgCuentasInst.AllowUserToAddRows = false;
            this.dtgCuentasInst.AllowUserToDeleteRows = false;
            this.dtgCuentasInst.AllowUserToResizeColumns = false;
            this.dtgCuentasInst.AllowUserToResizeRows = false;
            this.dtgCuentasInst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentasInst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentasInst.Location = new System.Drawing.Point(13, 158);
            this.dtgCuentasInst.MultiSelect = false;
            this.dtgCuentasInst.Name = "dtgCuentasInst";
            this.dtgCuentasInst.ReadOnly = true;
            this.dtgCuentasInst.RowHeadersVisible = false;
            this.dtgCuentasInst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentasInst.Size = new System.Drawing.Size(517, 184);
            this.dtgCuentasInst.TabIndex = 7;
            this.dtgCuentasInst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgCuentasInst_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(404, 348);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(470, 348);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoCuenta.Location = new System.Drawing.Point(13, 98);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblTipoCuenta.TabIndex = 11;
            this.lblTipoCuenta.Text = "Tipo Cuenta:";
            // 
            // lblTipoEntidad
            // 
            this.lblTipoEntidad.AutoSize = true;
            this.lblTipoEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoEntidad.Location = new System.Drawing.Point(13, 44);
            this.lblTipoEntidad.Name = "lblTipoEntidad";
            this.lblTipoEntidad.Size = new System.Drawing.Size(82, 13);
            this.lblTipoEntidad.TabIndex = 12;
            this.lblTipoEntidad.Text = "Tipo Entidad:";
            // 
            // cboTipoEntidad
            // 
            this.cboTipoEntidad.FormattingEnabled = true;
            this.cboTipoEntidad.Location = new System.Drawing.Point(106, 41);
            this.cboTipoEntidad.Name = "cboTipoEntidad";
            this.cboTipoEntidad.Size = new System.Drawing.Size(258, 21);
            this.cboTipoEntidad.TabIndex = 13;
            this.cboTipoEntidad.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad_SelectedIndexChanged);
            // 
            // cboEntidad
            // 
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(106, 68);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(258, 21);
            this.cboEntidad.TabIndex = 14;
            this.cboEntidad.SelectedIndexChanged += new System.EventHandler(this.cboEntidad_SelectedIndexChanged);
            // 
            // cboTipoCuentaBco
            // 
            this.cboTipoCuentaBco.FormattingEnabled = true;
            this.cboTipoCuentaBco.Location = new System.Drawing.Point(106, 95);
            this.cboTipoCuentaBco.Name = "cboTipoCuentaBco";
            this.cboTipoCuentaBco.Size = new System.Drawing.Size(183, 21);
            this.cboTipoCuentaBco.TabIndex = 16;
            this.cboTipoCuentaBco.SelectedIndexChanged += new System.EventHandler(this.cboTipoCuentaBco_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Agencia";
            // 
            // cboAgencia
            // 
            this.cboAgencia.Enabled = false;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(106, 14);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(258, 21);
            this.cboAgencia.TabIndex = 19;
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(106, 122);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(258, 20);
            this.txtNumeroCuenta.TabIndex = 20;
            this.txtNumeroCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCuenta_KeyPress);
            // 
            // chcBuscarCuenta
            // 
            this.chcBuscarCuenta.AutoSize = true;
            this.chcBuscarCuenta.Location = new System.Drawing.Point(409, 125);
            this.chcBuscarCuenta.Name = "chcBuscarCuenta";
            this.chcBuscarCuenta.Size = new System.Drawing.Size(121, 17);
            this.chcBuscarCuenta.TabIndex = 21;
            this.chcBuscarCuenta.Text = "Buscar Numero Cta.";
            this.chcBuscarCuenta.UseVisualStyleBackColor = true;
            this.chcBuscarCuenta.CheckedChanged += new System.EventHandler(this.chcBuscarCuenta_CheckedChanged);
            // 
            // frmBusquedaCuentaInst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 434);
            this.Controls.Add(this.chcBuscarCuenta);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoCuentaBco);
            this.Controls.Add(this.cboEntidad);
            this.Controls.Add(this.cboTipoEntidad);
            this.Controls.Add(this.lblTipoEntidad);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgCuentasInst);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblEntidad);
            this.Name = "frmBusquedaCuentaInst";
            this.Text = "Buscar Cuenta Otra Institucion";
            this.Load += new System.EventHandler(this.frmBusquedaCuentaInst_Load);
            this.Controls.SetChildIndex(this.lblEntidad, 0);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.dtgCuentasInst, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblTipoCuenta, 0);
            this.Controls.SetChildIndex(this.lblTipoEntidad, 0);
            this.Controls.SetChildIndex(this.cboTipoEntidad, 0);
            this.Controls.SetChildIndex(this.cboEntidad, 0);
            this.Controls.SetChildIndex(this.cboTipoCuentaBco, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.txtNumeroCuenta, 0);
            this.Controls.SetChildIndex(this.chcBuscarCuenta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentasInst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblEntidad;
        private GEN.ControlesBase.lblBase lblCriterio;
        private GEN.ControlesBase.dtgBase dtgCuentasInst;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblTipoCuenta;
        private GEN.ControlesBase.lblBase lblTipoEntidad;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBco;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.txtBase txtNumeroCuenta;
        private GEN.ControlesBase.chcBase chcBuscarCuenta;
    }
}