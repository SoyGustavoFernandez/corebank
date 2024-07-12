namespace CAJ.Presentacion
{
    partial class frmRegistroCheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroCheques));
            this.grbDatosCuenta = new GEN.ControlesBase.grbBase(this.components);
            this.dtgTalonarios = new GEN.ControlesBase.dtgBase(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.btnBuscarCuenta = new GEN.BotonesBase.btnBusqueda();
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblNumeroCuenta = new GEN.ControlesBase.lblBase();
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.grbDatosCheques = new GEN.ControlesBase.grbBase(this.components);
            this.txtCantCheques = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNroInicial = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumFinal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblNroFinal = new GEN.ControlesBase.lblBase();
            this.lblCantCheques = new GEN.ControlesBase.lblBase();
            this.lblNroInicial = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbDatosCuenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTalonarios)).BeginInit();
            this.grbDatosCheques.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosCuenta
            // 
            this.grbDatosCuenta.Controls.Add(this.dtgTalonarios);
            this.grbDatosCuenta.Controls.Add(this.cboEntidad);
            this.grbDatosCuenta.Controls.Add(this.lblMoneda);
            this.grbDatosCuenta.Controls.Add(this.cboMoneda);
            this.grbDatosCuenta.Controls.Add(this.btnBuscarCuenta);
            this.grbDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblNumeroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblEntidad);
            this.grbDatosCuenta.Location = new System.Drawing.Point(11, 12);
            this.grbDatosCuenta.Name = "grbDatosCuenta";
            this.grbDatosCuenta.Size = new System.Drawing.Size(486, 211);
            this.grbDatosCuenta.TabIndex = 2;
            this.grbDatosCuenta.TabStop = false;
            this.grbDatosCuenta.Text = "Datos Cuenta";
            // 
            // dtgTalonarios
            // 
            this.dtgTalonarios.AllowUserToAddRows = false;
            this.dtgTalonarios.AllowUserToDeleteRows = false;
            this.dtgTalonarios.AllowUserToResizeColumns = false;
            this.dtgTalonarios.AllowUserToResizeRows = false;
            this.dtgTalonarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTalonarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTalonarios.Location = new System.Drawing.Point(21, 91);
            this.dtgTalonarios.MultiSelect = false;
            this.dtgTalonarios.Name = "dtgTalonarios";
            this.dtgTalonarios.ReadOnly = true;
            this.dtgTalonarios.RowHeadersVisible = false;
            this.dtgTalonarios.RowTemplate.Height = 18;
            this.dtgTalonarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTalonarios.Size = new System.Drawing.Size(450, 114);
            this.dtgTalonarios.TabIndex = 12;
            // 
            // cboEntidad
            // 
            this.cboEntidad.Enabled = false;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(112, 15);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(273, 21);
            this.cboEntidad.TabIndex = 11;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(18, 67);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 7;
            this.lblMoneda.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(112, 64);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.BackgroundImage")));
            this.btnBuscarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(411, 15);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarCuenta.TabIndex = 5;
            this.btnBuscarCuenta.Text = "&Buscar";
            this.btnBuscarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(112, 40);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(273, 20);
            this.txtNroCuenta.TabIndex = 4;
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumeroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(18, 43);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblNumeroCuenta.TabIndex = 2;
            this.lblNumeroCuenta.Text = "Nro. Cuenta:";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(18, 18);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 1;
            this.lblEntidad.Text = "Entidad:";
            // 
            // grbDatosCheques
            // 
            this.grbDatosCheques.Controls.Add(this.txtCantCheques);
            this.grbDatosCheques.Controls.Add(this.txtNroInicial);
            this.grbDatosCheques.Controls.Add(this.txtNumFinal);
            this.grbDatosCheques.Controls.Add(this.lblNroFinal);
            this.grbDatosCheques.Controls.Add(this.lblCantCheques);
            this.grbDatosCheques.Controls.Add(this.lblNroInicial);
            this.grbDatosCheques.Location = new System.Drawing.Point(11, 229);
            this.grbDatosCheques.Name = "grbDatosCheques";
            this.grbDatosCheques.Size = new System.Drawing.Size(486, 111);
            this.grbDatosCheques.TabIndex = 3;
            this.grbDatosCheques.TabStop = false;
            this.grbDatosCheques.Text = "Datos Cheques";
            // 
            // txtCantCheques
            // 
            this.txtCantCheques.Location = new System.Drawing.Point(112, 48);
            this.txtCantCheques.Name = "txtCantCheques";
            this.txtCantCheques.Size = new System.Drawing.Size(121, 20);
            this.txtCantCheques.TabIndex = 7;
            this.txtCantCheques.TextChanged += new System.EventHandler(this.txtCantCheques_TextChanged);
            // 
            // txtNroInicial
            // 
            this.txtNroInicial.Enabled = false;
            this.txtNroInicial.Location = new System.Drawing.Point(112, 22);
            this.txtNroInicial.MaxLength = 9;
            this.txtNroInicial.Name = "txtNroInicial";
            this.txtNroInicial.Size = new System.Drawing.Size(121, 20);
            this.txtNroInicial.TabIndex = 6;
            this.txtNroInicial.TextChanged += new System.EventHandler(this.txtNroInicial_TextChanged);
            this.txtNroInicial.Leave += new System.EventHandler(this.txtNroInicial_Leave);
            // 
            // txtNumFinal
            // 
            this.txtNumFinal.Location = new System.Drawing.Point(112, 74);
            this.txtNumFinal.MaxLength = 9;
            this.txtNumFinal.Name = "txtNumFinal";
            this.txtNumFinal.ReadOnly = true;
            this.txtNumFinal.Size = new System.Drawing.Size(121, 20);
            this.txtNumFinal.TabIndex = 5;
            // 
            // lblNroFinal
            // 
            this.lblNroFinal.AutoSize = true;
            this.lblNroFinal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroFinal.ForeColor = System.Drawing.Color.Navy;
            this.lblNroFinal.Location = new System.Drawing.Point(18, 77);
            this.lblNroFinal.Name = "lblNroFinal";
            this.lblNroFinal.Size = new System.Drawing.Size(66, 13);
            this.lblNroFinal.TabIndex = 2;
            this.lblNroFinal.Text = "Nro. Final:";
            // 
            // lblCantCheques
            // 
            this.lblCantCheques.AutoSize = true;
            this.lblCantCheques.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCantCheques.ForeColor = System.Drawing.Color.Navy;
            this.lblCantCheques.Location = new System.Drawing.Point(18, 51);
            this.lblCantCheques.Name = "lblCantCheques";
            this.lblCantCheques.Size = new System.Drawing.Size(97, 13);
            this.lblCantCheques.TabIndex = 1;
            this.lblCantCheques.Text = "Cant. Cheques:";
            // 
            // lblNroInicial
            // 
            this.lblNroInicial.AutoSize = true;
            this.lblNroInicial.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroInicial.ForeColor = System.Drawing.Color.Navy;
            this.lblNroInicial.Location = new System.Drawing.Point(18, 25);
            this.lblNroInicial.Name = "lblNroInicial";
            this.lblNroInicial.Size = new System.Drawing.Size(74, 13);
            this.lblNroInicial.TabIndex = 0;
            this.lblNroInicial.Text = "Nro. Inicial:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(371, 346);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(437, 346);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(305, 346);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(239, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmRegistroCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 421);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbDatosCheques);
            this.Controls.Add(this.grbDatosCuenta);
            this.Name = "frmRegistroCheques";
            this.Text = "Registro Cheques";
            this.Load += new System.EventHandler(this.frmRegistroCheques_Load);
            this.Controls.SetChildIndex(this.grbDatosCuenta, 0);
            this.Controls.SetChildIndex(this.grbDatosCheques, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbDatosCuenta.ResumeLayout(false);
            this.grbDatosCuenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTalonarios)).EndInit();
            this.grbDatosCheques.ResumeLayout(false);
            this.grbDatosCheques.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosCuenta;
        private GEN.ControlesBase.lblBase lblNumeroCuenta;
        private GEN.ControlesBase.lblBase lblEntidad;
        private GEN.BotonesBase.btnBusqueda btnBuscarCuenta;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.grbBase grbDatosCheques;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCantCheques;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroInicial;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumFinal;
        private GEN.ControlesBase.lblBase lblNroFinal;
        private GEN.ControlesBase.lblBase lblCantCheques;
        private GEN.ControlesBase.lblBase lblNroInicial;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.dtgBase dtgTalonarios;
    }
}