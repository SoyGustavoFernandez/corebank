namespace CRE.Presentacion
{
    partial class frmVincAsesorPromotor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincAsesorPromotor));
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBuscarPromotor = new System.Windows.Forms.Button();
            this.txtPromotor = new GEN.ControlesBase.txtBase(this.components);
            this.lblSelecIni = new GEN.ControlesBase.lblBase();
            this.lblPromotorIni = new GEN.ControlesBase.lblBase();
            this.cboAgenPromotores = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgPromotoresIni = new GEN.ControlesBase.dtgBase(this.components);
            this.grbAsesorIni = new GEN.ControlesBase.grbBase(this.components);
            this.cboAsesorIni = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAgenciaIni = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.chcNoVinc = new GEN.ControlesBase.chcBase(this.components);
            this.grbAsesorFin = new GEN.ControlesBase.grbBase(this.components);
            this.cboAsesorFin = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAgenciaFin = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.lblPromotorFin = new GEN.ControlesBase.lblBase();
            this.dtgPromotoresFin = new GEN.ControlesBase.dtgBase(this.components);
            this.btnLiberar1 = new GEN.BotonesBase.btnLiberar();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPromotoresIni)).BeginInit();
            this.grbAsesorIni.SuspendLayout();
            this.grbAsesorFin.SuspendLayout();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPromotoresFin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(721, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(798, 381);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnBuscarPromotor);
            this.grbBase2.Controls.Add(this.txtPromotor);
            this.grbBase2.Controls.Add(this.lblSelecIni);
            this.grbBase2.Controls.Add(this.lblPromotorIni);
            this.grbBase2.Controls.Add(this.cboAgenPromotores);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.dtgPromotoresIni);
            this.grbBase2.Location = new System.Drawing.Point(12, 95);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(450, 280);
            this.grbBase2.TabIndex = 8;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Promotores origen";
            // 
            // btnBuscarPromotor
            // 
            this.btnBuscarPromotor.Location = new System.Drawing.Point(306, 14);
            this.btnBuscarPromotor.Name = "btnBuscarPromotor";
            this.btnBuscarPromotor.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPromotor.TabIndex = 12;
            this.btnBuscarPromotor.Text = "&Buscar";
            this.btnBuscarPromotor.UseVisualStyleBackColor = true;
            this.btnBuscarPromotor.Click += new System.EventHandler(this.btnBuscarPromotor_Click);
            // 
            // txtPromotor
            // 
            this.txtPromotor.Location = new System.Drawing.Point(74, 16);
            this.txtPromotor.Name = "txtPromotor";
            this.txtPromotor.Size = new System.Drawing.Size(226, 20);
            this.txtPromotor.TabIndex = 11;
            this.txtPromotor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPromotor_KeyPress);
            // 
            // lblSelecIni
            // 
            this.lblSelecIni.AutoSize = true;
            this.lblSelecIni.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSelecIni.ForeColor = System.Drawing.Color.Navy;
            this.lblSelecIni.Location = new System.Drawing.Point(328, 254);
            this.lblSelecIni.Name = "lblSelecIni";
            this.lblSelecIni.Size = new System.Drawing.Size(104, 13);
            this.lblSelecIni.TabIndex = 10;
            this.lblSelecIni.Text = "Seleccionados: 0";
            // 
            // lblPromotorIni
            // 
            this.lblPromotorIni.AutoSize = true;
            this.lblPromotorIni.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPromotorIni.ForeColor = System.Drawing.Color.Navy;
            this.lblPromotorIni.Location = new System.Drawing.Point(11, 254);
            this.lblPromotorIni.Name = "lblPromotorIni";
            this.lblPromotorIni.Size = new System.Drawing.Size(89, 13);
            this.lblPromotorIni.TabIndex = 9;
            this.lblPromotorIni.Text = "Promotores: 0";
            // 
            // cboAgenPromotores
            // 
            this.cboAgenPromotores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenPromotores.FormattingEnabled = true;
            this.cboAgenPromotores.Location = new System.Drawing.Point(72, 41);
            this.cboAgenPromotores.Name = "cboAgenPromotores";
            this.cboAgenPromotores.Size = new System.Drawing.Size(310, 21);
            this.cboAgenPromotores.TabIndex = 8;
            this.cboAgenPromotores.SelectedIndexChanged += new System.EventHandler(this.cboAgenPromotores_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(11, 19);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(65, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Promotor:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 44);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Agencia:";
            // 
            // dtgPromotoresIni
            // 
            this.dtgPromotoresIni.AllowUserToAddRows = false;
            this.dtgPromotoresIni.AllowUserToDeleteRows = false;
            this.dtgPromotoresIni.AllowUserToResizeColumns = false;
            this.dtgPromotoresIni.AllowUserToResizeRows = false;
            this.dtgPromotoresIni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPromotoresIni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPromotoresIni.Location = new System.Drawing.Point(9, 68);
            this.dtgPromotoresIni.MultiSelect = false;
            this.dtgPromotoresIni.Name = "dtgPromotoresIni";
            this.dtgPromotoresIni.ReadOnly = true;
            this.dtgPromotoresIni.RowHeadersVisible = false;
            this.dtgPromotoresIni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPromotoresIni.Size = new System.Drawing.Size(435, 174);
            this.dtgPromotoresIni.TabIndex = 6;
            this.dtgPromotoresIni.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPromotoresIni_CellContentClick);
            this.dtgPromotoresIni.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPromotoresIni_CellValueChanged);
            this.dtgPromotoresIni.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgPromotoresIni_CurrentCellDirtyStateChanged);
            // 
            // grbAsesorIni
            // 
            this.grbAsesorIni.Controls.Add(this.cboAsesorIni);
            this.grbAsesorIni.Controls.Add(this.lblBase2);
            this.grbAsesorIni.Controls.Add(this.cboAgenciaIni);
            this.grbAsesorIni.Controls.Add(this.lblBase1);
            this.grbAsesorIni.Location = new System.Drawing.Point(12, 12);
            this.grbAsesorIni.Name = "grbAsesorIni";
            this.grbAsesorIni.Size = new System.Drawing.Size(390, 77);
            this.grbAsesorIni.TabIndex = 9;
            this.grbAsesorIni.TabStop = false;
            this.grbAsesorIni.Text = "Datos asesor origen";
            // 
            // cboAsesorIni
            // 
            this.cboAsesorIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesorIni.FormattingEnabled = true;
            this.cboAsesorIni.Location = new System.Drawing.Point(72, 43);
            this.cboAsesorIni.Name = "cboAsesorIni";
            this.cboAsesorIni.Size = new System.Drawing.Size(310, 21);
            this.cboAsesorIni.TabIndex = 7;
            this.cboAsesorIni.SelectedIndexChanged += new System.EventHandler(this.cboAsesorIni_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Asesor:";
            // 
            // cboAgenciaIni
            // 
            this.cboAgenciaIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaIni.FormattingEnabled = true;
            this.cboAgenciaIni.Location = new System.Drawing.Point(72, 16);
            this.cboAgenciaIni.Name = "cboAgenciaIni";
            this.cboAgenciaIni.Size = new System.Drawing.Size(310, 21);
            this.cboAgenciaIni.TabIndex = 5;
            this.cboAgenciaIni.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaIni_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Agencia:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(659, 382);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // chcNoVinc
            // 
            this.chcNoVinc.AutoSize = true;
            this.chcNoVinc.Location = new System.Drawing.Point(12, 381);
            this.chcNoVinc.Name = "chcNoVinc";
            this.chcNoVinc.Size = new System.Drawing.Size(130, 17);
            this.chcNoVinc.TabIndex = 12;
            this.chcNoVinc.Text = "Mostrar no vinculados";
            this.chcNoVinc.UseVisualStyleBackColor = true;
            this.chcNoVinc.CheckedChanged += new System.EventHandler(this.chcNoVinc_CheckedChanged);
            // 
            // grbAsesorFin
            // 
            this.grbAsesorFin.Controls.Add(this.cboAsesorFin);
            this.grbAsesorFin.Controls.Add(this.lblBase3);
            this.grbAsesorFin.Controls.Add(this.cboAgenciaFin);
            this.grbAsesorFin.Controls.Add(this.lblBase4);
            this.grbAsesorFin.Location = new System.Drawing.Point(468, 12);
            this.grbAsesorFin.Name = "grbAsesorFin";
            this.grbAsesorFin.Size = new System.Drawing.Size(390, 77);
            this.grbAsesorFin.TabIndex = 13;
            this.grbAsesorFin.TabStop = false;
            this.grbAsesorFin.Text = "Datos asesor destino";
            // 
            // cboAsesorFin
            // 
            this.cboAsesorFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesorFin.FormattingEnabled = true;
            this.cboAsesorFin.Location = new System.Drawing.Point(72, 43);
            this.cboAsesorFin.Name = "cboAsesorFin";
            this.cboAsesorFin.Size = new System.Drawing.Size(310, 21);
            this.cboAsesorFin.TabIndex = 7;
            this.cboAsesorFin.SelectedIndexChanged += new System.EventHandler(this.cboAsesorFin_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 46);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Asesor:";
            // 
            // cboAgenciaFin
            // 
            this.cboAgenciaFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaFin.FormattingEnabled = true;
            this.cboAgenciaFin.Location = new System.Drawing.Point(72, 16);
            this.cboAgenciaFin.Name = "cboAgenciaFin";
            this.cboAgenciaFin.Size = new System.Drawing.Size(310, 21);
            this.cboAgenciaFin.TabIndex = 5;
            this.cboAgenciaFin.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaFin_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 19);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Agencia:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblPromotorFin);
            this.grbBase4.Controls.Add(this.dtgPromotoresFin);
            this.grbBase4.Location = new System.Drawing.Point(468, 95);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(390, 280);
            this.grbBase4.TabIndex = 14;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Promotores destino";
            // 
            // lblPromotorFin
            // 
            this.lblPromotorFin.AutoSize = true;
            this.lblPromotorFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPromotorFin.ForeColor = System.Drawing.Color.Navy;
            this.lblPromotorFin.Location = new System.Drawing.Point(9, 254);
            this.lblPromotorFin.Name = "lblPromotorFin";
            this.lblPromotorFin.Size = new System.Drawing.Size(89, 13);
            this.lblPromotorFin.TabIndex = 7;
            this.lblPromotorFin.Text = "Promotores: 0";
            // 
            // dtgPromotoresFin
            // 
            this.dtgPromotoresFin.AllowUserToAddRows = false;
            this.dtgPromotoresFin.AllowUserToDeleteRows = false;
            this.dtgPromotoresFin.AllowUserToResizeColumns = false;
            this.dtgPromotoresFin.AllowUserToResizeRows = false;
            this.dtgPromotoresFin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPromotoresFin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPromotoresFin.Location = new System.Drawing.Point(9, 19);
            this.dtgPromotoresFin.MultiSelect = false;
            this.dtgPromotoresFin.Name = "dtgPromotoresFin";
            this.dtgPromotoresFin.ReadOnly = true;
            this.dtgPromotoresFin.RowHeadersVisible = false;
            this.dtgPromotoresFin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPromotoresFin.Size = new System.Drawing.Size(373, 223);
            this.dtgPromotoresFin.TabIndex = 6;
            // 
            // btnLiberar1
            // 
            this.btnLiberar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar1.BackgroundImage")));
            this.btnLiberar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiberar1.Location = new System.Drawing.Point(593, 382);
            this.btnLiberar1.Name = "btnLiberar1";
            this.btnLiberar1.Size = new System.Drawing.Size(60, 50);
            this.btnLiberar1.TabIndex = 15;
            this.btnLiberar1.Text = "&Liberar";
            this.btnLiberar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiberar1.UseVisualStyleBackColor = true;
            this.btnLiberar1.Click += new System.EventHandler(this.btnLiberar1_Click);
            // 
            // frmVincAsesorPromotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 476);
            this.Controls.Add(this.btnLiberar1);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbAsesorFin);
            this.Controls.Add(this.chcNoVinc);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbAsesorIni);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmVincAsesorPromotor";
            this.Text = "Vinculación de asesores y promotores";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbAsesorIni, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.chcNoVinc, 0);
            this.Controls.SetChildIndex(this.grbAsesorFin, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.btnLiberar1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPromotoresIni)).EndInit();
            this.grbAsesorIni.ResumeLayout(false);
            this.grbAsesorIni.PerformLayout();
            this.grbAsesorFin.ResumeLayout(false);
            this.grbAsesorFin.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPromotoresFin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgPromotoresIni;
        private GEN.ControlesBase.grbBase grbAsesorIni;
        private GEN.ControlesBase.cboPersonalCreditos cboAsesorIni;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.cboAgencia cboAgenciaIni;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcNoVinc;
        private GEN.ControlesBase.grbBase grbAsesorFin;
        private GEN.ControlesBase.cboPersonalCreditos cboAsesorFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencia cboAgenciaFin;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.dtgBase dtgPromotoresFin;
        private GEN.ControlesBase.cboAgencia cboAgenPromotores;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblSelecIni;
        private GEN.ControlesBase.lblBase lblPromotorIni;
        private GEN.ControlesBase.lblBase lblPromotorFin;
        private GEN.ControlesBase.txtBase txtPromotor;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.Button btnBuscarPromotor;
        private GEN.BotonesBase.btnLiberar btnLiberar1;
    }
}

