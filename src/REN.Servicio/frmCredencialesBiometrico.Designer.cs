namespace CLI.Servicio
{
    partial class frmCredencialesBiometrico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredencialesBiometrico));
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnHuellDig = new GEN.BotonesBase.btnHuellDig(this.components);
            this.grbLogeo = new System.Windows.Forms.GroupBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblBase2 = new System.Windows.Forms.Label();
            this.lblBase1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.grbLogeo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(67, 89);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(132, 89);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnHuellDig
            // 
            this.btnHuellDig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuellDig.BackgroundImage")));
            this.btnHuellDig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHuellDig.Location = new System.Drawing.Point(197, 89);
            this.btnHuellDig.Name = "btnHuellDig";
            this.btnHuellDig.Size = new System.Drawing.Size(60, 50);
            this.btnHuellDig.TabIndex = 2;
            this.btnHuellDig.Text = "&Leer Huella";
            this.btnHuellDig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHuellDig.UseVisualStyleBackColor = true;
            this.btnHuellDig.Click += new System.EventHandler(this.btnHuellDig_Click);
            // 
            // grbLogeo
            // 
            this.grbLogeo.Controls.Add(this.txtContraseña);
            this.grbLogeo.Controls.Add(this.lblBase2);
            this.grbLogeo.Controls.Add(this.lblBase1);
            this.grbLogeo.Controls.Add(this.txtUsuario);
            this.grbLogeo.Location = new System.Drawing.Point(12, 3);
            this.grbLogeo.Name = "grbLogeo";
            this.grbLogeo.Size = new System.Drawing.Size(301, 80);
            this.grbLogeo.TabIndex = 3;
            this.grbLogeo.TabStop = false;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(104, 46);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(160, 20);
            this.txtContraseña.TabIndex = 4;
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            this.txtContraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContraseña_KeyDown);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Location = new System.Drawing.Point(37, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(67, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Contraseña :";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Location = new System.Drawing.Point(55, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Usuario :";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(104, 20);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(160, 20);
            this.txtUsuario.TabIndex = 0;
            // 
            // frmCredencialesBiometrico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 166);
            this.Controls.Add(this.grbLogeo);
            this.Controls.Add(this.btnHuellDig);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCredencialesBiometrico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "..:: Validación de Usuario ::..";
            this.Load += new System.EventHandler(this.frmCredencialesBiometrico_Load);
            this.grbLogeo.ResumeLayout(false);
            this.grbLogeo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnHuellDig btnHuellDig;
        private System.Windows.Forms.GroupBox grbLogeo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblBase2;
        private System.Windows.Forms.Label lblBase1;
        private System.Windows.Forms.TextBox txtContraseña;
    }
}