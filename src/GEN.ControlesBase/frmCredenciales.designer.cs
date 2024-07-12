namespace GEN.ControlesBase
{
    partial class frmCredenciales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredenciales));
            this.grbLogeo = new GEN.ControlesBase.grbBase();
            this.txtContraseña = new GEN.ControlesBase.txtBase();
            this.txtUsuario = new GEN.ControlesBase.txtBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnHuellDig = new GEN.BotonesBase.btnHuellDig();
            this.pnlCredenciales = new System.Windows.Forms.Panel();
            this.flpCredenciales = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMensajeInvitacion = new System.Windows.Forms.Panel();
            this.txtMensajeInvitacion = new System.Windows.Forms.TextBox();
            this.grbLogeo.SuspendLayout();
            this.pnlCredenciales.SuspendLayout();
            this.flpCredenciales.SuspendLayout();
            this.pnlMensajeInvitacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLogeo
            // 
            this.grbLogeo.Controls.Add(this.txtContraseña);
            this.grbLogeo.Controls.Add(this.txtUsuario);
            this.grbLogeo.Controls.Add(this.lblBase2);
            this.grbLogeo.Controls.Add(this.lblBase1);
            this.grbLogeo.Location = new System.Drawing.Point(11, 5);
            this.grbLogeo.Name = "grbLogeo";
            this.grbLogeo.Size = new System.Drawing.Size(301, 80);
            this.grbLogeo.TabIndex = 8;
            this.grbLogeo.TabStop = false;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(115, 46);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(160, 20);
            this.txtContraseña.TabIndex = 1;
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            this.txtContraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContraseña_KeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(115, 20);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(160, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(29, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(82, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Contraseña :";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(52, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(59, 13);
            this.lblBase1.TabIndex = 13;
            this.lblBase1.Text = "Usuario :";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(131, 91);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(66, 91);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnHuellDig
            // 
            this.btnHuellDig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuellDig.BackgroundImage")));
            this.btnHuellDig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHuellDig.Enabled = false;
            this.btnHuellDig.Location = new System.Drawing.Point(196, 91);
            this.btnHuellDig.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuellDig.Name = "btnHuellDig";
            this.btnHuellDig.Size = new System.Drawing.Size(60, 50);
            this.btnHuellDig.TabIndex = 9;
            this.btnHuellDig.Text = "&Leer Huella";
            this.btnHuellDig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHuellDig.UseVisualStyleBackColor = true;
            this.btnHuellDig.Click += new System.EventHandler(this.btnHuellDig_Click);
            // 
            // pnlCredenciales
            // 
            this.pnlCredenciales.Controls.Add(this.btnHuellDig);
            this.pnlCredenciales.Controls.Add(this.grbLogeo);
            this.pnlCredenciales.Controls.Add(this.btnSalir);
            this.pnlCredenciales.Controls.Add(this.btnAceptar);
            this.pnlCredenciales.Location = new System.Drawing.Point(3, 64);
            this.pnlCredenciales.Name = "pnlCredenciales";
            this.pnlCredenciales.Size = new System.Drawing.Size(322, 149);
            this.pnlCredenciales.TabIndex = 10;
            // 
            // flpCredenciales
            // 
            this.flpCredenciales.AutoSize = true;
            this.flpCredenciales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpCredenciales.Controls.Add(this.pnlMensajeInvitacion);
            this.flpCredenciales.Controls.Add(this.pnlCredenciales);
            this.flpCredenciales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCredenciales.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCredenciales.Location = new System.Drawing.Point(0, 0);
            this.flpCredenciales.Name = "flpCredenciales";
            this.flpCredenciales.Size = new System.Drawing.Size(325, 226);
            this.flpCredenciales.TabIndex = 11;
            // 
            // pnlMensajeInvitacion
            // 
            this.pnlMensajeInvitacion.Controls.Add(this.txtMensajeInvitacion);
            this.pnlMensajeInvitacion.Location = new System.Drawing.Point(3, 3);
            this.pnlMensajeInvitacion.Name = "pnlMensajeInvitacion";
            this.pnlMensajeInvitacion.Size = new System.Drawing.Size(322, 55);
            this.pnlMensajeInvitacion.TabIndex = 0;
            // 
            // txtMensajeInvitacion
            // 
            this.txtMensajeInvitacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtMensajeInvitacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeInvitacion.Enabled = false;
            this.txtMensajeInvitacion.Location = new System.Drawing.Point(55, 3);
            this.txtMensajeInvitacion.Multiline = true;
            this.txtMensajeInvitacion.Name = "txtMensajeInvitacion";
            this.txtMensajeInvitacion.ReadOnly = true;
            this.txtMensajeInvitacion.Size = new System.Drawing.Size(222, 50);
            this.txtMensajeInvitacion.TabIndex = 1;
            // 
            // frmCredenciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(325, 248);
            this.Controls.Add(this.flpCredenciales);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCredenciales";
            this.Text = "..:: Validación de Usuario ::..";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.flpCredenciales, 0);
            this.grbLogeo.ResumeLayout(false);
            this.grbLogeo.PerformLayout();
            this.pnlCredenciales.ResumeLayout(false);
            this.flpCredenciales.ResumeLayout(false);
            this.pnlMensajeInvitacion.ResumeLayout(false);
            this.pnlMensajeInvitacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private grbBase grbLogeo;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private txtBase txtContraseña;
        private txtBase txtUsuario;
        private lblBase lblBase2;
        private lblBase lblBase1;
        private BotonesBase.btnHuellDig btnHuellDig;
        private System.Windows.Forms.Panel pnlCredenciales;
        private System.Windows.Forms.FlowLayoutPanel flpCredenciales;
        private System.Windows.Forms.Panel pnlMensajeInvitacion;
        private System.Windows.Forms.TextBox txtMensajeInvitacion;
    }
}

