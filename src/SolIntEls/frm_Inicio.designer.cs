namespace SolIntEls
{
     public partial class frm_Inicio
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Inicio));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.grbLogeo = new GEN.ControlesBase.grbBase(this.components);
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtContraseña = new GEN.ControlesBase.txtBase(this.components);
			this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
			this.lblBase2 = new GEN.ControlesBase.lblBase();
			this.lblBase1 = new GEN.ControlesBase.lblBase();
			this.pnlAgencia = new System.Windows.Forms.Panel();
			this.lblMessageAgencia = new System.Windows.Forms.Label();
			this.lblAgencia = new GEN.ControlesBase.lblBase();
			this.cboAgencias = new GEN.ControlesBase.cboBase(this.components);
			this.pnlPerfil = new System.Windows.Forms.Panel();
			this.cboPerfil = new GEN.ControlesBase.cboBase(this.components);
			this.lblPerfil = new GEN.ControlesBase.lblBase();
			this.lblMessagePerfil = new System.Windows.Forms.Label();
			this.pnlConexion = new System.Windows.Forms.Panel();
			this.cboTipoConexion = new GEN.ControlesBase.cboBase(this.components);
			this.lblBase6 = new GEN.ControlesBase.lblBase();
			this.pnlBotones = new System.Windows.Forms.Panel();
			this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
			this.btnSalir = new GEN.BotonesBase.btnSalir();
			this.pnlCambioPass = new System.Windows.Forms.Panel();
			this.lblTipCon = new GEN.ControlesBase.lblBase();
			this.lnkChangePass = new System.Windows.Forms.LinkLabel();
			this.pnlChangePass = new System.Windows.Forms.Panel();
			this.grbChangPass = new GEN.ControlesBase.grbBase(this.components);
			this.btnCancelar = new GEN.BotonesBase.btnCancelar();
			this.txtContNueCon = new GEN.ControlesBase.txtBase(this.components);
			this.lblBase3 = new GEN.ControlesBase.lblBase();
			this.txtContNue = new GEN.ControlesBase.txtBase(this.components);
			this.lblBase4 = new GEN.ControlesBase.lblBase();
			this.btnAceptarPass = new GEN.BotonesBase.BtnAceptar();
			this.txtContAct = new GEN.ControlesBase.txtBase(this.components);
			this.lblBase5 = new GEN.ControlesBase.lblBase();
			this.flowLayoutPanel1.SuspendLayout();
			this.grbLogeo.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlAgencia.SuspendLayout();
			this.pnlPerfil.SuspendLayout();
			this.pnlConexion.SuspendLayout();
			this.pnlBotones.SuspendLayout();
			this.pnlCambioPass.SuspendLayout();
			this.pnlChangePass.SuspendLayout();
			this.grbChangPass.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.grbLogeo);
			this.flowLayoutPanel1.Controls.Add(this.pnlChangePass);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(311, 515);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// grbLogeo
			// 
			this.grbLogeo.AutoSize = true;
			this.grbLogeo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grbLogeo.Controls.Add(this.flowLayoutPanel2);
			this.grbLogeo.Location = new System.Drawing.Point(3, 0);
			this.grbLogeo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.grbLogeo.Name = "grbLogeo";
			this.grbLogeo.Size = new System.Drawing.Size(307, 333);
			this.grbLogeo.TabIndex = 0;
			this.grbLogeo.TabStop = false;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.panel2);
			this.flowLayoutPanel2.Controls.Add(this.pnlAgencia);
			this.flowLayoutPanel2.Controls.Add(this.pnlPerfil);
			this.flowLayoutPanel2.Controls.Add(this.pnlConexion);
			this.flowLayoutPanel2.Controls.Add(this.pnlBotones);
			this.flowLayoutPanel2.Controls.Add(this.pnlCambioPass);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(301, 314);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtContraseña);
			this.panel2.Controls.Add(this.txtUsuario);
			this.panel2.Controls.Add(this.lblBase2);
			this.panel2.Controls.Add(this.lblBase1);
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(295, 59);
			this.panel2.TabIndex = 0;
			// 
			// txtContraseña
			// 
			this.txtContraseña.Location = new System.Drawing.Point(110, 32);
			this.txtContraseña.Name = "txtContraseña";
			this.txtContraseña.PasswordChar = '*';
			this.txtContraseña.Size = new System.Drawing.Size(160, 20);
			this.txtContraseña.TabIndex = 1;
			this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
			this.txtContraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContraseña_KeyDown);
			this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(110, 6);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(160, 20);
			this.txtUsuario.TabIndex = 0;
			this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
			this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
			// 
			// lblBase2
			// 
			this.lblBase2.AutoSize = true;
			this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblBase2.ForeColor = System.Drawing.Color.Navy;
			this.lblBase2.Location = new System.Drawing.Point(25, 36);
			this.lblBase2.Name = "lblBase2";
			this.lblBase2.Size = new System.Drawing.Size(82, 13);
			this.lblBase2.TabIndex = 31;
			this.lblBase2.Text = "Contraseña :";
			// 
			// lblBase1
			// 
			this.lblBase1.AutoSize = true;
			this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblBase1.ForeColor = System.Drawing.Color.Navy;
			this.lblBase1.Location = new System.Drawing.Point(48, 10);
			this.lblBase1.Name = "lblBase1";
			this.lblBase1.Size = new System.Drawing.Size(59, 13);
			this.lblBase1.TabIndex = 30;
			this.lblBase1.Text = "Usuario :";
			// 
			// pnlAgencia
			// 
			this.pnlAgencia.Controls.Add(this.lblMessageAgencia);
			this.pnlAgencia.Controls.Add(this.lblAgencia);
			this.pnlAgencia.Controls.Add(this.cboAgencias);
			this.pnlAgencia.Location = new System.Drawing.Point(3, 68);
			this.pnlAgencia.Name = "pnlAgencia";
			this.pnlAgencia.Size = new System.Drawing.Size(295, 47);
			this.pnlAgencia.TabIndex = 2;
			// 
			// lblMessageAgencia
			// 
			this.lblMessageAgencia.AutoSize = true;
			this.lblMessageAgencia.ForeColor = System.Drawing.Color.Green;
			this.lblMessageAgencia.Location = new System.Drawing.Point(110, 31);
			this.lblMessageAgencia.Name = "lblMessageAgencia";
			this.lblMessageAgencia.Size = new System.Drawing.Size(35, 13);
			this.lblMessageAgencia.TabIndex = 1;
			this.lblMessageAgencia.Text = "label1";
			// 
			// lblAgencia
			// 
			this.lblAgencia.AutoSize = true;
			this.lblAgencia.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblAgencia.ForeColor = System.Drawing.Color.Navy;
			this.lblAgencia.Location = new System.Drawing.Point(46, 11);
			this.lblAgencia.Name = "lblAgencia";
			this.lblAgencia.Size = new System.Drawing.Size(61, 13);
			this.lblAgencia.TabIndex = 48;
			this.lblAgencia.Text = "Agencia :";
			// 
			// cboAgencias
			// 
			this.cboAgencias.DropDownWidth = 200;
			this.cboAgencias.FormattingEnabled = true;
			this.cboAgencias.Location = new System.Drawing.Point(110, 7);
			this.cboAgencias.Name = "cboAgencias";
			this.cboAgencias.Size = new System.Drawing.Size(160, 21);
			this.cboAgencias.TabIndex = 0;
			this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
			this.cboAgencias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboAgencias_KeyDown);
			// 
			// pnlPerfil
			// 
			this.pnlPerfil.Controls.Add(this.cboPerfil);
			this.pnlPerfil.Controls.Add(this.lblPerfil);
			this.pnlPerfil.Controls.Add(this.lblMessagePerfil);
			this.pnlPerfil.Location = new System.Drawing.Point(3, 121);
			this.pnlPerfil.Name = "pnlPerfil";
			this.pnlPerfil.Size = new System.Drawing.Size(295, 45);
			this.pnlPerfil.TabIndex = 3;
			// 
			// cboPerfil
			// 
			this.cboPerfil.DropDownWidth = 200;
			this.cboPerfil.FormattingEnabled = true;
			this.cboPerfil.Location = new System.Drawing.Point(110, 2);
			this.cboPerfil.Name = "cboPerfil";
			this.cboPerfil.Size = new System.Drawing.Size(160, 21);
			this.cboPerfil.TabIndex = 0;
			this.cboPerfil.SelectedIndexChanged += new System.EventHandler(this.cboPerfil_SelectedIndexChanged);
			this.cboPerfil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPerfil_KeyDown);
			// 
			// lblPerfil
			// 
			this.lblPerfil.AutoSize = true;
			this.lblPerfil.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblPerfil.ForeColor = System.Drawing.Color.Navy;
			this.lblPerfil.Location = new System.Drawing.Point(62, 6);
			this.lblPerfil.Name = "lblPerfil";
			this.lblPerfil.Size = new System.Drawing.Size(45, 13);
			this.lblPerfil.TabIndex = 40;
			this.lblPerfil.Text = "Perfil :";
			// 
			// lblMessagePerfil
			// 
			this.lblMessagePerfil.AutoSize = true;
			this.lblMessagePerfil.ForeColor = System.Drawing.Color.Green;
			this.lblMessagePerfil.Location = new System.Drawing.Point(110, 26);
			this.lblMessagePerfil.Name = "lblMessagePerfil";
			this.lblMessagePerfil.Size = new System.Drawing.Size(35, 13);
			this.lblMessagePerfil.TabIndex = 41;
			this.lblMessagePerfil.Text = "label1";
			// 
			// pnlConexion
			// 
			this.pnlConexion.Controls.Add(this.cboTipoConexion);
			this.pnlConexion.Controls.Add(this.lblBase6);
			this.pnlConexion.Location = new System.Drawing.Point(3, 172);
			this.pnlConexion.Name = "pnlConexion";
			this.pnlConexion.Size = new System.Drawing.Size(295, 45);
			this.pnlConexion.TabIndex = 42;
			// 
			// cboTipoConexion
			// 
			this.cboTipoConexion.DropDownWidth = 200;
			this.cboTipoConexion.FormattingEnabled = true;
			this.cboTipoConexion.Location = new System.Drawing.Point(110, 2);
			this.cboTipoConexion.Name = "cboTipoConexion";
			this.cboTipoConexion.Size = new System.Drawing.Size(160, 21);
			this.cboTipoConexion.TabIndex = 0;
			this.cboTipoConexion.SelectedIndexChanged += new System.EventHandler(this.cboTipoConexion_SelectedIndexChanged);
			// 
			// lblBase6
			// 
			this.lblBase6.AutoSize = true;
			this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblBase6.ForeColor = System.Drawing.Color.Navy;
			this.lblBase6.Location = new System.Drawing.Point(36, 6);
			this.lblBase6.Name = "lblBase6";
			this.lblBase6.Size = new System.Drawing.Size(70, 13);
			this.lblBase6.TabIndex = 40;
			this.lblBase6.Text = "Conexión :";
			// 
			// pnlBotones
			// 
			this.pnlBotones.Controls.Add(this.btnAceptar);
			this.pnlBotones.Controls.Add(this.btnSalir);
			this.pnlBotones.Location = new System.Drawing.Point(3, 220);
			this.pnlBotones.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.pnlBotones.Name = "pnlBotones";
			this.pnlBotones.Size = new System.Drawing.Size(295, 58);
			this.pnlBotones.TabIndex = 1;
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
			this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
			this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAceptar.Enabled = false;
			this.btnAceptar.Location = new System.Drawing.Point(84, 3);
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
			this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
			this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
			this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnSalir.Location = new System.Drawing.Point(150, 3);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(60, 50);
			this.btnSalir.TabIndex = 1;
			this.btnSalir.Text = "&Salir";
			this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// pnlCambioPass
			// 
			this.pnlCambioPass.Controls.Add(this.lblTipCon);
			this.pnlCambioPass.Controls.Add(this.lnkChangePass);
			this.pnlCambioPass.Location = new System.Drawing.Point(3, 281);
			this.pnlCambioPass.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.pnlCambioPass.Name = "pnlCambioPass";
			this.pnlCambioPass.Size = new System.Drawing.Size(295, 30);
			this.pnlCambioPass.TabIndex = 4;
			// 
			// lblTipCon
			// 
			this.lblTipCon.AutoSize = true;
			this.lblTipCon.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblTipCon.ForeColor = System.Drawing.Color.Navy;
			this.lblTipCon.Location = new System.Drawing.Point(6, 10);
			this.lblTipCon.Name = "lblTipCon";
			this.lblTipCon.Size = new System.Drawing.Size(0, 13);
			this.lblTipCon.TabIndex = 1;
			// 
			// lnkChangePass
			// 
			this.lnkChangePass.AutoSize = true;
			this.lnkChangePass.Location = new System.Drawing.Point(190, 10);
			this.lnkChangePass.Name = "lnkChangePass";
			this.lnkChangePass.Size = new System.Drawing.Size(102, 13);
			this.lnkChangePass.TabIndex = 0;
			this.lnkChangePass.Text = "Cambiar Contraseña";
			this.lnkChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChangePass_LinkClicked);
			// 
			// pnlChangePass
			// 
			this.pnlChangePass.Controls.Add(this.grbChangPass);
			this.pnlChangePass.Location = new System.Drawing.Point(3, 339);
			this.pnlChangePass.Name = "pnlChangePass";
			this.pnlChangePass.Size = new System.Drawing.Size(303, 167);
			this.pnlChangePass.TabIndex = 1;
			// 
			// grbChangPass
			// 
			this.grbChangPass.Controls.Add(this.btnCancelar);
			this.grbChangPass.Controls.Add(this.txtContNueCon);
			this.grbChangPass.Controls.Add(this.lblBase3);
			this.grbChangPass.Controls.Add(this.txtContNue);
			this.grbChangPass.Controls.Add(this.lblBase4);
			this.grbChangPass.Controls.Add(this.btnAceptarPass);
			this.grbChangPass.Controls.Add(this.txtContAct);
			this.grbChangPass.Controls.Add(this.lblBase5);
			this.grbChangPass.Location = new System.Drawing.Point(3, 3);
			this.grbChangPass.Name = "grbChangPass";
			this.grbChangPass.Size = new System.Drawing.Size(298, 160);
			this.grbChangPass.TabIndex = 1;
			this.grbChangPass.TabStop = false;
			this.grbChangPass.Text = "Cambio de Contraseña";
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Location = new System.Drawing.Point(153, 105);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(60, 50);
			this.btnCancelar.TabIndex = 4;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// txtContNueCon
			// 
			this.txtContNueCon.Location = new System.Drawing.Point(131, 71);
			this.txtContNueCon.Name = "txtContNueCon";
			this.txtContNueCon.PasswordChar = '*';
			this.txtContNueCon.Size = new System.Drawing.Size(160, 20);
			this.txtContNueCon.TabIndex = 2;
			this.txtContNueCon.TextChanged += new System.EventHandler(this.txtContNueCon_TextChanged);
			// 
			// lblBase3
			// 
			this.lblBase3.AutoSize = true;
			this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblBase3.ForeColor = System.Drawing.Color.Navy;
			this.lblBase3.Location = new System.Drawing.Point(9, 69);
			this.lblBase3.Name = "lblBase3";
			this.lblBase3.Size = new System.Drawing.Size(105, 26);
			this.lblBase3.TabIndex = 39;
			this.lblBase3.Text = "Confirmar Nueva\r\nContraseña:";
			// 
			// txtContNue
			// 
			this.txtContNue.Location = new System.Drawing.Point(131, 45);
			this.txtContNue.Name = "txtContNue";
			this.txtContNue.PasswordChar = '*';
			this.txtContNue.Size = new System.Drawing.Size(160, 20);
			this.txtContNue.TabIndex = 1;
			this.txtContNue.TextChanged += new System.EventHandler(this.txtContNue_TextChanged);
			// 
			// lblBase4
			// 
			this.lblBase4.AutoSize = true;
			this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblBase4.ForeColor = System.Drawing.Color.Navy;
			this.lblBase4.Location = new System.Drawing.Point(9, 48);
			this.lblBase4.Name = "lblBase4";
			this.lblBase4.Size = new System.Drawing.Size(118, 13);
			this.lblBase4.TabIndex = 37;
			this.lblBase4.Text = "Nueva Contraseña:";
			// 
			// btnAceptarPass
			// 
			this.btnAceptarPass.BackColor = System.Drawing.SystemColors.Control;
			this.btnAceptarPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptarPass.BackgroundImage")));
			this.btnAceptarPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAceptarPass.Enabled = false;
			this.btnAceptarPass.Location = new System.Drawing.Point(87, 105);
			this.btnAceptarPass.Name = "btnAceptarPass";
			this.btnAceptarPass.Size = new System.Drawing.Size(60, 50);
			this.btnAceptarPass.TabIndex = 3;
			this.btnAceptarPass.Text = "&Aceptar";
			this.btnAceptarPass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAceptarPass.UseVisualStyleBackColor = true;
			this.btnAceptarPass.Click += new System.EventHandler(this.btnAceptarPass_Click);
			// 
			// txtContAct
			// 
			this.txtContAct.Location = new System.Drawing.Point(131, 19);
			this.txtContAct.Name = "txtContAct";
			this.txtContAct.PasswordChar = '*';
			this.txtContAct.Size = new System.Drawing.Size(160, 20);
			this.txtContAct.TabIndex = 0;
			this.txtContAct.TextChanged += new System.EventHandler(this.txtContAct_TextChanged);
			// 
			// lblBase5
			// 
			this.lblBase5.AutoSize = true;
			this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblBase5.ForeColor = System.Drawing.Color.Navy;
			this.lblBase5.Location = new System.Drawing.Point(9, 22);
			this.lblBase5.Name = "lblBase5";
			this.lblBase5.Size = new System.Drawing.Size(117, 13);
			this.lblBase5.TabIndex = 33;
			this.lblBase5.Text = "Contraseña Actual:";
			// 
			// frm_Inicio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(311, 537);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximumSize = new System.Drawing.Size(331, 580);
			this.Name = "frm_Inicio";
			this.Text = "..:: Validación de Usuario ::..";
			this.Load += new System.EventHandler(this.frm_Inicio_Load);
			this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.grbLogeo.ResumeLayout(false);
			this.grbLogeo.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.pnlAgencia.ResumeLayout(false);
			this.pnlAgencia.PerformLayout();
			this.pnlPerfil.ResumeLayout(false);
			this.pnlPerfil.PerformLayout();
			this.pnlConexion.ResumeLayout(false);
			this.pnlConexion.PerformLayout();
			this.pnlBotones.ResumeLayout(false);
			this.pnlCambioPass.ResumeLayout(false);
			this.pnlCambioPass.PerformLayout();
			this.pnlChangePass.ResumeLayout(false);
			this.grbChangPass.ResumeLayout(false);
			this.grbChangPass.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GEN.ControlesBase.grbBase grbLogeo;
        private System.Windows.Forms.LinkLabel lnkChangePass;
        private GEN.ControlesBase.grbBase grbChangPass;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.txtBase txtContNueCon;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtContNue;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.BtnAceptar btnAceptarPass;
        private GEN.ControlesBase.txtBase txtContAct;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.Panel pnlChangePass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private GEN.ControlesBase.txtBase txtContraseña;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.Panel pnlPerfil;
        private GEN.ControlesBase.cboBase cboPerfil;
        private GEN.ControlesBase.lblBase lblPerfil;
        private System.Windows.Forms.Label lblMessagePerfil;
        private System.Windows.Forms.Panel pnlAgencia;
        private System.Windows.Forms.Label lblMessageAgencia;
        private GEN.ControlesBase.lblBase lblAgencia;
        private GEN.ControlesBase.cboBase cboAgencias;
        private System.Windows.Forms.Panel pnlBotones;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Panel pnlCambioPass;
        private GEN.ControlesBase.lblBase lblTipCon;
		private System.Windows.Forms.Panel pnlConexion;
		private GEN.ControlesBase.cboBase cboTipoConexion;
		private GEN.ControlesBase.lblBase lblBase6;
	}
}