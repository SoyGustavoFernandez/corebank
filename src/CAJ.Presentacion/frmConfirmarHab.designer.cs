namespace CAJ.Presentacion
{
    partial class frmConfirmarHab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmarHab));
            this.dtgHabPen = new GEN.ControlesBase.dtgBase(this.components);
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.rbtHabPend = new System.Windows.Forms.RadioButton();
            this.rbtHabGeneradas = new System.Windows.Forms.RadioButton();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnRechazar = new GEN.BotonesBase.btnRechazar();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHabPen)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgHabPen
            // 
            this.dtgHabPen.AllowUserToAddRows = false;
            this.dtgHabPen.AllowUserToDeleteRows = false;
            this.dtgHabPen.AllowUserToResizeColumns = false;
            this.dtgHabPen.AllowUserToResizeRows = false;
            this.dtgHabPen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHabPen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHabPen.Location = new System.Drawing.Point(5, 136);
            this.dtgHabPen.MultiSelect = false;
            this.dtgHabPen.Name = "dtgHabPen";
            this.dtgHabPen.ReadOnly = true;
            this.dtgHabPen.RowHeadersVisible = false;
            this.dtgHabPen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHabPen.Size = new System.Drawing.Size(669, 170);
            this.dtgHabPen.TabIndex = 55;
            this.dtgHabPen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHabPen_CellClick);
            this.dtgHabPen.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHabPen_RowEnter);
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(75, 49);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(430, 20);
            this.txtNomUsu.TabIndex = 72;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 51);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 71;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(265, 19);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(40, 20);
            this.txtCodUsu.TabIndex = 70;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(212, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 69;
            this.lblBase2.Text = "Código:";
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Enabled = false;
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(73, 18);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaSis.TabIndex = 67;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 68;
            this.lblBase3.Text = "Fecha:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtUsuario);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Location = new System.Drawing.Point(7, 1);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(667, 77);
            this.grbBase3.TabIndex = 73;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(396, 18);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(102, 20);
            this.txtUsuario.TabIndex = 50;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(339, 21);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(55, 13);
            this.lblBase10.TabIndex = 49;
            this.lblBase10.Text = "Usuario:";
            // 
            // lblBase7
            // 
            this.lblBase7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(5, 120);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(669, 15);
            this.lblBase7.TabIndex = 74;
            this.lblBase7.Text = "HABILITACIONES PENDIENTES";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rbtHabPend
            // 
            this.rbtHabPend.AutoSize = true;
            this.rbtHabPend.Location = new System.Drawing.Point(58, 12);
            this.rbtHabPend.Name = "rbtHabPend";
            this.rbtHabPend.Size = new System.Drawing.Size(141, 17);
            this.rbtHabPend.TabIndex = 75;
            this.rbtHabPend.TabStop = true;
            this.rbtHabPend.Text = "Habilitaciones Recibidas";
            this.rbtHabPend.UseVisualStyleBackColor = true;
            this.rbtHabPend.CheckedChanged += new System.EventHandler(this.rbtHabPend_CheckedChanged);
            // 
            // rbtHabGeneradas
            // 
            this.rbtHabGeneradas.AutoSize = true;
            this.rbtHabGeneradas.Location = new System.Drawing.Point(361, 12);
            this.rbtHabGeneradas.Name = "rbtHabGeneradas";
            this.rbtHabGeneradas.Size = new System.Drawing.Size(140, 17);
            this.rbtHabGeneradas.TabIndex = 76;
            this.rbtHabGeneradas.TabStop = true;
            this.rbtHabGeneradas.Text = "Habilitaciones Remitidas";
            this.rbtHabGeneradas.UseVisualStyleBackColor = true;
            this.rbtHabGeneradas.CheckedChanged += new System.EventHandler(this.rbtHabGeneradas_CheckedChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtHabGeneradas);
            this.grbBase1.Controls.Add(this.rbtHabPend);
            this.grbBase1.Location = new System.Drawing.Point(7, 80);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(667, 35);
            this.grbBase1.TabIndex = 77;
            this.grbBase1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(614, 312);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 58;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazar.BackgroundImage")));
            this.btnRechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar.Location = new System.Drawing.Point(554, 312);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar.TabIndex = 57;
            this.btnRechazar.Text = "&Rechaza";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(494, 312);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 56;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmConfirmarHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 391);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtNomUsu);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtCodUsu);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaSis);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgHabPen);
            this.Name = "frmConfirmarHab";
            this.Text = "Confirmar o Rechazar Habilitaciones";
            this.Load += new System.EventHandler(this.frmConfirmarHab_Load);
            this.Controls.SetChildIndex(this.dtgHabPen, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnRechazar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtpFechaSis, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtCodUsu, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtNomUsu, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHabPen)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgHabPen;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnRechazar btnRechazar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase2;
        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.RadioButton rbtHabPend;
        private System.Windows.Forms.RadioButton rbtHabGeneradas;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}