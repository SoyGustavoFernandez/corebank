namespace SER.Presentacion
{
    partial class frmCambioDestinoGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioDestinoGiro));
            this.dtgGiros = new GEN.ControlesBase.dtgBase(this.components);
            this.grbDatosDestinatario = new GEN.ControlesBase.grbBase(this.components);
            this.conBusPersonaRemitente = new GEN.ControlesBase.ConBusPersonaConServicios();
            this.chcNoCliente = new GEN.ControlesBase.chcBase(this.components);
            this.txtCelular = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase3 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase4 = new GEN.ControlesBase.txtBase(this.components);
            this.grbDatos = new GEN.ControlesBase.grbBase(this.components);
            this.txtMontoComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboEstablecimiento = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboMotivoOperacion1 = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).BeginInit();
            this.grbDatosDestinatario.SuspendLayout();
            this.conBusPersonaRemitente.SuspendLayout();
            this.grbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgGiros
            // 
            this.dtgGiros.AllowUserToAddRows = false;
            this.dtgGiros.AllowUserToDeleteRows = false;
            this.dtgGiros.AllowUserToResizeColumns = false;
            this.dtgGiros.AllowUserToResizeRows = false;
            this.dtgGiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGiros.Location = new System.Drawing.Point(11, 141);
            this.dtgGiros.MultiSelect = false;
            this.dtgGiros.Name = "dtgGiros";
            this.dtgGiros.ReadOnly = true;
            this.dtgGiros.RowHeadersVisible = false;
            this.dtgGiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGiros.Size = new System.Drawing.Size(701, 150);
            this.dtgGiros.TabIndex = 6;
            this.dtgGiros.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGiros_CellEnter);
            // 
            // grbDatosDestinatario
            // 
            this.grbDatosDestinatario.Controls.Add(this.conBusPersonaRemitente);
            this.grbDatosDestinatario.Location = new System.Drawing.Point(11, 11);
            this.grbDatosDestinatario.Margin = new System.Windows.Forms.Padding(2);
            this.grbDatosDestinatario.Name = "grbDatosDestinatario";
            this.grbDatosDestinatario.Padding = new System.Windows.Forms.Padding(2);
            this.grbDatosDestinatario.Size = new System.Drawing.Size(701, 124);
            this.grbDatosDestinatario.TabIndex = 5;
            this.grbDatosDestinatario.TabStop = false;
            this.grbDatosDestinatario.Text = "Datos remitente";
            // 
            // conBusPersonaRemitente
            // 
            this.conBusPersonaRemitente.Controls.Add(this.chcNoCliente);
            this.conBusPersonaRemitente.Controls.Add(this.txtCelular);
            this.conBusPersonaRemitente.Controls.Add(this.txtDireccion);
            this.conBusPersonaRemitente.Controls.Add(this.txtNombre);
            this.conBusPersonaRemitente.Controls.Add(this.txtNumeroDocumento);
            this.conBusPersonaRemitente.Controls.Add(this.txtBase1);
            this.conBusPersonaRemitente.Controls.Add(this.txtBase2);
            this.conBusPersonaRemitente.Controls.Add(this.txtBase3);
            this.conBusPersonaRemitente.Controls.Add(this.txtBase4);
            this.conBusPersonaRemitente.lConsiderarRUC = true;
            this.conBusPersonaRemitente.lModoEdicion = false;
            this.conBusPersonaRemitente.Location = new System.Drawing.Point(92, 24);
            this.conBusPersonaRemitente.Margin = new System.Windows.Forms.Padding(2);
            this.conBusPersonaRemitente.Name = "conBusPersonaRemitente";
            this.conBusPersonaRemitente.Size = new System.Drawing.Size(531, 100);
            this.conBusPersonaRemitente.TabIndex = 0;
            this.conBusPersonaRemitente.ehEncontrado += new System.EventHandler(this.conBusPersonaRemitente_ehEncontrado);
            // 
            // chcNoCliente
            // 
            this.chcNoCliente.AutoSize = true;
            this.chcNoCliente.Enabled = false;
            this.chcNoCliente.Location = new System.Drawing.Point(435, 77);
            this.chcNoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.chcNoCliente.Name = "chcNoCliente";
            this.chcNoCliente.Size = new System.Drawing.Size(94, 17);
            this.chcNoCliente.TabIndex = 22;
            this.chcNoCliente.Text = "No es cliente?";
            this.chcNoCliente.UseVisualStyleBackColor = true;
            // 
            // txtCelular
            // 
            this.txtCelular.Enabled = false;
            this.txtCelular.Location = new System.Drawing.Point(143, 74);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(2);
            this.txtCelular.MaxLength = 9;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(282, 20);
            this.txtCelular.TabIndex = 5;
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(143, 50);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(282, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(143, 26);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(282, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(286, 2);
            this.txtNumeroDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(113, 20);
            this.txtNumeroDocumento.TabIndex = 0;
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(143, 74);
            this.txtBase1.Margin = new System.Windows.Forms.Padding(2);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(282, 20);
            this.txtBase1.TabIndex = 5;
            // 
            // txtBase2
            // 
            this.txtBase2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBase2.Enabled = false;
            this.txtBase2.Location = new System.Drawing.Point(143, 50);
            this.txtBase2.Margin = new System.Windows.Forms.Padding(2);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(282, 20);
            this.txtBase2.TabIndex = 4;
            // 
            // txtBase3
            // 
            this.txtBase3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBase3.Enabled = false;
            this.txtBase3.Location = new System.Drawing.Point(143, 26);
            this.txtBase3.Margin = new System.Windows.Forms.Padding(2);
            this.txtBase3.Name = "txtBase3";
            this.txtBase3.Size = new System.Drawing.Size(282, 20);
            this.txtBase3.TabIndex = 3;
            // 
            // txtBase4
            // 
            this.txtBase4.Location = new System.Drawing.Point(286, 2);
            this.txtBase4.Margin = new System.Windows.Forms.Padding(2);
            this.txtBase4.Name = "txtBase4";
            this.txtBase4.Size = new System.Drawing.Size(113, 20);
            this.txtBase4.TabIndex = 0;
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.txtMontoComision);
            this.grbDatos.Controls.Add(this.lblBase2);
            this.grbDatos.Controls.Add(this.cboEstablecimiento);
            this.grbDatos.Controls.Add(this.lblBase1);
            this.grbDatos.Location = new System.Drawing.Point(12, 297);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(700, 61);
            this.grbDatos.TabIndex = 7;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos del giro";
            // 
            // txtMontoComision
            // 
            this.txtMontoComision.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoComision.Enabled = false;
            this.txtMontoComision.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoComision.FormatoDecimal = true;
            this.txtMontoComision.Location = new System.Drawing.Point(522, 25);
            this.txtMontoComision.Name = "txtMontoComision";
            this.txtMontoComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoComision.nNumDecimales = 2;
            this.txtMontoComision.nvalor = 0D;
            this.txtMontoComision.Size = new System.Drawing.Size(74, 22);
            this.txtMontoComision.TabIndex = 134;
            this.txtMontoComision.Text = "0.00";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(348, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(168, 13);
            this.lblBase2.TabIndex = 133;
            this.lblBase2.Text = "Comisión cambio de destino";
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(154, 26);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(180, 21);
            this.cboEstablecimiento.TabIndex = 132;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(60, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(88, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nuevo destino";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(652, 364);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(578, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(518, 364);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(457, 364);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(12, 377);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(109, 13);
            this.lblBase13.TabIndex = 171;
            this.lblBase13.Text = "Motivo operación:";
            // 
            // cboMotivoOperacion1
            // 
            this.cboMotivoOperacion1.Enabled = false;
            this.cboMotivoOperacion1.FormattingEnabled = true;
            this.cboMotivoOperacion1.Location = new System.Drawing.Point(14, 393);
            this.cboMotivoOperacion1.Name = "cboMotivoOperacion1";
            this.cboMotivoOperacion1.Size = new System.Drawing.Size(265, 21);
            this.cboMotivoOperacion1.TabIndex = 170;
            // 
            // frmCambioDestinoGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 443);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.cboMotivoOperacion1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbDatos);
            this.Controls.Add(this.dtgGiros);
            this.Controls.Add(this.grbDatosDestinatario);
            this.Name = "frmCambioDestinoGiro";
            this.Text = "Cambio Destino Giro";
            this.Load += new System.EventHandler(this.frmCambioDestinoGiro_Load);
            this.Controls.SetChildIndex(this.grbDatosDestinatario, 0);
            this.Controls.SetChildIndex(this.dtgGiros, 0);
            this.Controls.SetChildIndex(this.grbDatos, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboMotivoOperacion1, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).EndInit();
            this.grbDatosDestinatario.ResumeLayout(false);
            this.conBusPersonaRemitente.ResumeLayout(false);
            this.conBusPersonaRemitente.PerformLayout();
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgGiros;
        private GEN.ControlesBase.grbBase grbDatosDestinatario;
        private GEN.ControlesBase.ConBusPersonaConServicios conBusPersonaRemitente;
        private GEN.ControlesBase.chcBase chcNoCliente;
        private GEN.ControlesBase.txtBase txtCelular;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNumeroDocumento;        
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.txtBase txtBase3;
        private GEN.ControlesBase.txtBase txtBase4;
        private GEN.ControlesBase.grbBase grbDatos;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtMontoComision;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion1;
    }
}