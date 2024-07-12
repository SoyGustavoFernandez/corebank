namespace GRH.Presentacion
{
    partial class frmEnvioTarjetaCumpleanios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioTarjetaCumpleanios));
            this.dtgListaPersonal = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtEmail = new GEN.ControlesBase.txtBase(this.components);
            this.txtClave = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.pbxTarjeta = new System.Windows.Forms.PictureBox();
            this.btnMiniVer = new GEN.BotonesBase.btnMiniVer();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.btnCargarFile1 = new GEN.BotonesBase.btnCargarFile();
            this.btnValidar1 = new GEN.BotonesBase.btnValidar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPersonal)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTarjeta)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaPersonal
            // 
            this.dtgListaPersonal.AllowUserToAddRows = false;
            this.dtgListaPersonal.AllowUserToDeleteRows = false;
            this.dtgListaPersonal.AllowUserToResizeColumns = false;
            this.dtgListaPersonal.AllowUserToResizeRows = false;
            this.dtgListaPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPersonal.Location = new System.Drawing.Point(6, 19);
            this.dtgListaPersonal.MultiSelect = false;
            this.dtgListaPersonal.Name = "dtgListaPersonal";
            this.dtgListaPersonal.ReadOnly = true;
            this.dtgListaPersonal.RowHeadersVisible = false;
            this.dtgListaPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPersonal.Size = new System.Drawing.Size(698, 162);
            this.dtgListaPersonal.TabIndex = 8;
            this.dtgListaPersonal.SelectionChanged += new System.EventHandler(this.dtgBase1_SelectionChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniVer);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnEnviar1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.btnCargarFile1);
            this.grbBase1.Controls.Add(this.dtpFecha);
            this.grbBase1.Controls.Add(this.txtEmail);
            this.grbBase1.Controls.Add(this.txtClave);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnValidar1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(292, 225);
            this.grbBase1.TabIndex = 10;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Configuración";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(118, 13);
            this.lblBase1.TabIndex = 35;
            this.lblBase1.Text = "Correo electrónico:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 94);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(121, 13);
            this.lblBase3.TabIndex = 39;
            this.lblBase3.Text = "Fecha Considerada:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(6, 110);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 38;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(6, 32);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 33;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(6, 71);
            this.txtClave.MaxLength = 100;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(170, 20);
            this.txtClave.TabIndex = 34;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 36;
            this.lblBase2.Text = "Contraseña:";
            // 
            // grbBase2
            // 
            this.grbBase2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBase2.Controls.Add(this.pbxTarjeta);
            this.grbBase2.Location = new System.Drawing.Point(310, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(412, 225);
            this.grbBase2.TabIndex = 34;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Vista previa - tarjeta de cumpleaños (2778x1389 px)";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgListaPersonal);
            this.grbBase3.Location = new System.Drawing.Point(12, 243);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(710, 187);
            this.grbBase3.TabIndex = 10;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Lista de personal que cumplen años en la fecha considerada";
            // 
            // pbxTarjeta
            // 
            this.pbxTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxTarjeta.Location = new System.Drawing.Point(6, 19);
            this.pbxTarjeta.Name = "pbxTarjeta";
            this.pbxTarjeta.Padding = new System.Windows.Forms.Padding(1);
            this.pbxTarjeta.Size = new System.Drawing.Size(400, 200);
            this.pbxTarjeta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxTarjeta.TabIndex = 9;
            this.pbxTarjeta.TabStop = false;
            // 
            // btnMiniVer
            // 
            this.btnMiniVer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniVer.BackgroundImage")));
            this.btnMiniVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMiniVer.Location = new System.Drawing.Point(184, 70);
            this.btnMiniVer.Name = "btnMiniVer";
            this.btnMiniVer.Size = new System.Drawing.Size(22, 22);
            this.btnMiniVer.TabIndex = 40;
            this.btnMiniVer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniVer.UseVisualStyleBackColor = true;
            this.btnMiniVer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMiniVer_MouseDown);
            this.btnMiniVer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMiniVer_MouseUp);
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(146, 136);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 31;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnCargarFile1
            // 
            this.btnCargarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile1.BackgroundImage")));
            this.btnCargarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile1.Location = new System.Drawing.Point(76, 136);
            this.btnCargarFile1.Name = "btnCargarFile1";
            this.btnCargarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile1.TabIndex = 32;
            this.btnCargarFile1.Text = "Cargar Imagen";
            this.btnCargarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile1.UseVisualStyleBackColor = true;
            this.btnCargarFile1.Click += new System.EventHandler(this.btnCargarFile1_Click);
            // 
            // btnValidar1
            // 
            this.btnValidar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar1.BackgroundImage")));
            this.btnValidar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar1.Location = new System.Drawing.Point(6, 136);
            this.btnValidar1.Name = "btnValidar1";
            this.btnValidar1.Size = new System.Drawing.Size(60, 50);
            this.btnValidar1.TabIndex = 37;
            this.btnValidar1.Text = "&Validar";
            this.btnValidar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar1.UseVisualStyleBackColor = true;
            this.btnValidar1.Click += new System.EventHandler(this.btnValidar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(596, 436);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 28;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(464, 436);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 4;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(530, 436);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(662, 436);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmEnvioTarjetaCumpleanios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmEnvioTarjetaCumpleanios";
            this.Text = "Envío de Tarjetas de Cumpleaños";
            this.Load += new System.EventHandler(this.frmEnvioTarjetaCumpleanios_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPersonal)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTarjeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.dtgBase dtgListaPersonal;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnCargarFile btnCargarFile1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.txtBase txtEmail;
        private GEN.ControlesBase.txtBase txtClave;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnValidar btnValidar1;
        private System.Windows.Forms.PictureBox pbxTarjeta;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnMiniVer btnMiniVer;
    }
}