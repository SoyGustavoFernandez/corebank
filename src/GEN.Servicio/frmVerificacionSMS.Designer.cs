namespace GEN.Servicio
{
    partial class frmVerificacionSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerificacionSMS));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodigoValidacion = new GEN.ControlesBase.txtNumerico(this.components);
            this.cboNumeroEnvioSMS = new GEN.ControlesBase.cboBase(this.components);
            this.chcAutorizarPrincipal = new GEN.ControlesBase.chcBase(this.components);
            this.cboTipoOperador = new GEN.ControlesBase.cboBase(this.components);
            this.txtNumeroTelefonico = new GEN.ControlesBase.txtNumerico(this.components);
            this.grbRegistrarNumero = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbSeleccionNumero = new GEN.ControlesBase.grbBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSolExcepcion = new GEN.BotonesBase.btnBlanco();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnReenviar = new GEN.BotonesBase.btnBlanco();
            this.pnlValidacion = new System.Windows.Forms.Panel();
            this.grbRegistrarNumero.SuspendLayout();
            this.grbSeleccionNumero.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlValidacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(44, 11);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(160, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Código de Validación SMS:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(31, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(167, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Seleccione para Envío SMS:";
            // 
            // txtCodigoValidacion
            // 
            this.txtCodigoValidacion.Enabled = false;
            this.txtCodigoValidacion.Format = "n2";
            this.txtCodigoValidacion.Location = new System.Drawing.Point(204, 7);
            this.txtCodigoValidacion.MaxLength = 6;
            this.txtCodigoValidacion.Name = "txtCodigoValidacion";
            this.txtCodigoValidacion.Size = new System.Drawing.Size(182, 20);
            this.txtCodigoValidacion.TabIndex = 4;
            // 
            // cboNumeroEnvioSMS
            // 
            this.cboNumeroEnvioSMS.FormattingEnabled = true;
            this.cboNumeroEnvioSMS.Location = new System.Drawing.Point(198, 13);
            this.cboNumeroEnvioSMS.Name = "cboNumeroEnvioSMS";
            this.cboNumeroEnvioSMS.Size = new System.Drawing.Size(182, 21);
            this.cboNumeroEnvioSMS.TabIndex = 0;
            // 
            // chcAutorizarPrincipal
            // 
            this.chcAutorizarPrincipal.AutoSize = true;
            this.chcAutorizarPrincipal.Enabled = false;
            this.chcAutorizarPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.chcAutorizarPrincipal.Location = new System.Drawing.Point(252, 7);
            this.chcAutorizarPrincipal.Name = "chcAutorizarPrincipal";
            this.chcAutorizarPrincipal.Size = new System.Drawing.Size(182, 17);
            this.chcAutorizarPrincipal.TabIndex = 1;
            this.chcAutorizarPrincipal.Text = "Nuevo Número Celular - Principal";
            this.chcAutorizarPrincipal.UseVisualStyleBackColor = true;
            this.chcAutorizarPrincipal.CheckedChanged += new System.EventHandler(this.chcAutorizarPrincipal_CheckedChanged);
            // 
            // cboTipoOperador
            // 
            this.cboTipoOperador.FormattingEnabled = true;
            this.cboTipoOperador.Location = new System.Drawing.Point(180, 14);
            this.cboTipoOperador.Name = "cboTipoOperador";
            this.cboTipoOperador.Size = new System.Drawing.Size(100, 21);
            this.cboTipoOperador.TabIndex = 21;
            // 
            // txtNumeroTelefonico
            // 
            this.txtNumeroTelefonico.Format = "n2";
            this.txtNumeroTelefonico.Location = new System.Drawing.Point(282, 14);
            this.txtNumeroTelefonico.MaxLength = 9;
            this.txtNumeroTelefonico.Name = "txtNumeroTelefonico";
            this.txtNumeroTelefonico.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroTelefonico.TabIndex = 22;
            // 
            // grbRegistrarNumero
            // 
            this.grbRegistrarNumero.Controls.Add(this.lblBase3);
            this.grbRegistrarNumero.Controls.Add(this.txtNumeroTelefonico);
            this.grbRegistrarNumero.Controls.Add(this.cboTipoOperador);
            this.grbRegistrarNumero.Enabled = false;
            this.grbRegistrarNumero.Location = new System.Drawing.Point(3, 49);
            this.grbRegistrarNumero.Name = "grbRegistrarNumero";
            this.grbRegistrarNumero.Size = new System.Drawing.Size(410, 40);
            this.grbRegistrarNumero.TabIndex = 23;
            this.grbRegistrarNumero.TabStop = false;
            this.grbRegistrarNumero.Visible = false;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(171, 13);
            this.lblBase3.TabIndex = 19;
            this.lblBase3.Text = "Registre Número de Celular:";
            // 
            // grbSeleccionNumero
            // 
            this.grbSeleccionNumero.Controls.Add(this.cboNumeroEnvioSMS);
            this.grbSeleccionNumero.Controls.Add(this.lblBase1);
            this.grbSeleccionNumero.Location = new System.Drawing.Point(3, 3);
            this.grbSeleccionNumero.Name = "grbSeleccionNumero";
            this.grbSeleccionNumero.Size = new System.Drawing.Size(410, 40);
            this.grbSeleccionNumero.TabIndex = 24;
            this.grbSeleccionNumero.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 50);
            this.panel1.TabIndex = 25;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.grbSeleccionNumero);
            this.flowLayoutPanel1.Controls.Add(this.grbRegistrarNumero);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(420, 48);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSolExcepcion
            // 
            this.btnSolExcepcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolExcepcion.Image = ((System.Drawing.Image)(resources.GetObject("btnSolExcepcion.Image")));
            this.btnSolExcepcion.Location = new System.Drawing.Point(63, 124);
            this.btnSolExcepcion.Name = "btnSolExcepcion";
            this.btnSolExcepcion.Size = new System.Drawing.Size(60, 50);
            this.btnSolExcepcion.TabIndex = 20;
            this.btnSolExcepcion.Text = "Sol. Excep.";
            this.btnSolExcepcion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolExcepcion.UseVisualStyleBackColor = true;
            this.btnSolExcepcion.Click += new System.EventHandler(this.btnSolExcepcion_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(123, 124);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(243, 124);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(303, 124);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnReenviar
            // 
            this.btnReenviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReenviar.Image = ((System.Drawing.Image)(resources.GetObject("btnReenviar.Image")));
            this.btnReenviar.Location = new System.Drawing.Point(183, 124);
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(60, 50);
            this.btnReenviar.TabIndex = 6;
            this.btnReenviar.Text = "Reenviar";
            this.btnReenviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReenviar.UseVisualStyleBackColor = true;
            this.btnReenviar.Click += new System.EventHandler(this.btnReenviar_Click);
            // 
            // pnlValidacion
            // 
            this.pnlValidacion.Controls.Add(this.lblBase2);
            this.pnlValidacion.Controls.Add(this.txtCodigoValidacion);
            this.pnlValidacion.Location = new System.Drawing.Point(4, 84);
            this.pnlValidacion.Name = "pnlValidacion";
            this.pnlValidacion.Size = new System.Drawing.Size(430, 35);
            this.pnlValidacion.TabIndex = 26;
            // 
            // frmVerificacionSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 222);
            this.Controls.Add(this.pnlValidacion);
            this.Controls.Add(this.btnSolExcepcion);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.chcAutorizarPrincipal);
            this.Controls.Add(this.btnReenviar);
            this.Name = "frmVerificacionSMS";
            this.Text = "Validar Contacto";
            this.Load += new System.EventHandler(this.frmVerificacionSMS_Load);
            this.Controls.SetChildIndex(this.btnReenviar, 0);
            this.Controls.SetChildIndex(this.chcAutorizarPrincipal, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnSolExcepcion, 0);
            this.Controls.SetChildIndex(this.pnlValidacion, 0);
            this.grbRegistrarNumero.ResumeLayout(false);
            this.grbRegistrarNumero.PerformLayout();
            this.grbSeleccionNumero.ResumeLayout(false);
            this.grbSeleccionNumero.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlValidacion.ResumeLayout(false);
            this.pnlValidacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesBase.lblBase lblBase2;
        private ControlesBase.lblBase lblBase1;
        private ControlesBase.txtNumerico txtCodigoValidacion;
        private ControlesBase.cboBase cboNumeroEnvioSMS;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private BotonesBase.btnBlanco btnReenviar;
        private ControlesBase.chcBase chcAutorizarPrincipal;
        private BotonesBase.btnBlanco btnSolExcepcion;
        private ControlesBase.cboBase cboTipoOperador;
        private ControlesBase.txtNumerico txtNumeroTelefonico;
        private ControlesBase.grbBase grbRegistrarNumero;
        private ControlesBase.lblBase lblBase3;
        private ControlesBase.grbBase grbSeleccionNumero;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlValidacion;
    }
}