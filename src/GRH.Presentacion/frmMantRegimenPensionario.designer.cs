namespace GRH.Presentacion
{
    partial class frmMantRegimenPensionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantRegimenPensionario));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNomRegimen = new GEN.ControlesBase.txtCBLetra(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.CBVigente = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtPorcAporteSPP = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipoRegimenPens1 = new GEN.ControlesBase.cboTipoRegimenPens(this.components);
            this.txtPorcSeguroSPP = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPorcSNP = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPorcMixtaSPP = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPorcFlujoSPP = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgRegimen = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegimen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(401, 373);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 27);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(132, 13);
            this.lblBase1.TabIndex = 32;
            this.lblBase1.Text = "Nombre del Régimen:";
            // 
            // txtNomRegimen
            // 
            this.txtNomRegimen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomRegimen.Location = new System.Drawing.Point(143, 24);
            this.txtNomRegimen.MaxLength = 30;
            this.txtNomRegimen.Name = "txtNomRegimen";
            this.txtNomRegimen.Size = new System.Drawing.Size(358, 20);
            this.txtNomRegimen.TabIndex = 0;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtNomRegimen);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtPorcAporteSPP);
            this.grbBase1.Controls.Add(this.cboTipoRegimenPens1);
            this.grbBase1.Controls.Add(this.txtPorcSeguroSPP);
            this.grbBase1.Controls.Add(this.txtPorcSNP);
            this.grbBase1.Controls.Add(this.txtPorcMixtaSPP);
            this.grbBase1.Controls.Add(this.txtPorcFlujoSPP);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(14, 13);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(513, 162);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Régimen Pensionario";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 132);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(129, 13);
            this.lblBase5.TabIndex = 47;
            this.lblBase5.Text = "Porc. Var. Mixta SPP:";
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(439, 132);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 7;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(267, 106);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(109, 13);
            this.lblBase7.TabIndex = 46;
            this.lblBase7.Text = "Porc. Aporte SPP:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(13, 106);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(126, 13);
            this.lblBase6.TabIndex = 45;
            this.lblBase6.Text = "Porc. Var. Flujo SPP:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(267, 80);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(112, 13);
            this.lblBase4.TabIndex = 43;
            this.lblBase4.Text = "Porc. Seguro SPP:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 80);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(100, 13);
            this.lblBase3.TabIndex = 42;
            this.lblBase3.Text = "Porcentaje SNP:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 53);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(108, 13);
            this.lblBase2.TabIndex = 41;
            this.lblBase2.Text = "Tipo de Régimen:";
            // 
            // txtPorcAporteSPP
            // 
            this.txtPorcAporteSPP.FormatoDecimal = false;
            this.txtPorcAporteSPP.Location = new System.Drawing.Point(394, 103);
            this.txtPorcAporteSPP.MaxLength = 6;
            this.txtPorcAporteSPP.Name = "txtPorcAporteSPP";
            this.txtPorcAporteSPP.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcAporteSPP.nNumDecimales = 4;
            this.txtPorcAporteSPP.nvalor = 0D;
            this.txtPorcAporteSPP.Size = new System.Drawing.Size(107, 20);
            this.txtPorcAporteSPP.TabIndex = 6;
            // 
            // cboTipoRegimenPens1
            // 
            this.cboTipoRegimenPens1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRegimenPens1.FormattingEnabled = true;
            this.cboTipoRegimenPens1.Location = new System.Drawing.Point(143, 50);
            this.cboTipoRegimenPens1.Name = "cboTipoRegimenPens1";
            this.cboTipoRegimenPens1.Size = new System.Drawing.Size(358, 21);
            this.cboTipoRegimenPens1.TabIndex = 1;
            this.cboTipoRegimenPens1.SelectedIndexChanged += new System.EventHandler(this.cboTipoRegimenPens1_SelectedIndexChanged);
            // 
            // txtPorcSeguroSPP
            // 
            this.txtPorcSeguroSPP.FormatoDecimal = false;
            this.txtPorcSeguroSPP.Location = new System.Drawing.Point(394, 77);
            this.txtPorcSeguroSPP.MaxLength = 6;
            this.txtPorcSeguroSPP.Name = "txtPorcSeguroSPP";
            this.txtPorcSeguroSPP.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcSeguroSPP.nNumDecimales = 4;
            this.txtPorcSeguroSPP.nvalor = 0D;
            this.txtPorcSeguroSPP.Size = new System.Drawing.Size(107, 20);
            this.txtPorcSeguroSPP.TabIndex = 5;
            // 
            // txtPorcSNP
            // 
            this.txtPorcSNP.FormatoDecimal = false;
            this.txtPorcSNP.Location = new System.Drawing.Point(143, 77);
            this.txtPorcSNP.MaxLength = 6;
            this.txtPorcSNP.Name = "txtPorcSNP";
            this.txtPorcSNP.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcSNP.nNumDecimales = 4;
            this.txtPorcSNP.nvalor = 0D;
            this.txtPorcSNP.Size = new System.Drawing.Size(107, 20);
            this.txtPorcSNP.TabIndex = 2;
            // 
            // txtPorcMixtaSPP
            // 
            this.txtPorcMixtaSPP.FormatoDecimal = false;
            this.txtPorcMixtaSPP.Location = new System.Drawing.Point(143, 129);
            this.txtPorcMixtaSPP.MaxLength = 6;
            this.txtPorcMixtaSPP.Name = "txtPorcMixtaSPP";
            this.txtPorcMixtaSPP.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcMixtaSPP.nNumDecimales = 4;
            this.txtPorcMixtaSPP.nvalor = 0D;
            this.txtPorcMixtaSPP.Size = new System.Drawing.Size(107, 20);
            this.txtPorcMixtaSPP.TabIndex = 4;
            // 
            // txtPorcFlujoSPP
            // 
            this.txtPorcFlujoSPP.FormatoDecimal = false;
            this.txtPorcFlujoSPP.Location = new System.Drawing.Point(143, 103);
            this.txtPorcFlujoSPP.MaxLength = 6;
            this.txtPorcFlujoSPP.Name = "txtPorcFlujoSPP";
            this.txtPorcFlujoSPP.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcFlujoSPP.nNumDecimales = 4;
            this.txtPorcFlujoSPP.nvalor = 0D;
            this.txtPorcFlujoSPP.Size = new System.Drawing.Size(107, 20);
            this.txtPorcFlujoSPP.TabIndex = 3;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(269, 373);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(335, 373);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(203, 373);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(467, 373);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgRegimen
            // 
            this.dtgRegimen.AllowUserToAddRows = false;
            this.dtgRegimen.AllowUserToDeleteRows = false;
            this.dtgRegimen.AllowUserToResizeColumns = false;
            this.dtgRegimen.AllowUserToResizeRows = false;
            this.dtgRegimen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegimen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegimen.Location = new System.Drawing.Point(14, 181);
            this.dtgRegimen.MultiSelect = false;
            this.dtgRegimen.Name = "dtgRegimen";
            this.dtgRegimen.ReadOnly = true;
            this.dtgRegimen.RowHeadersVisible = false;
            this.dtgRegimen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegimen.Size = new System.Drawing.Size(513, 186);
            this.dtgRegimen.TabIndex = 25;
            this.dtgRegimen.SelectionChanged += new System.EventHandler(this.dtgRegimen_SelectionChanged);
            // 
            // frmMantRegimenPensionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 453);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgRegimen);
            this.Name = "frmMantRegimenPensionario";
            this.Text = "Mantenimiento de Régimen Pensionario";
            this.Load += new System.EventHandler(this.frmMantRegimenPensionario_Load);
            this.Controls.SetChildIndex(this.dtgRegimen, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegimen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBLetra txtNomRegimen;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase CBVigente;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtgBase dtgRegimen;
        private GEN.ControlesBase.cboTipoRegimenPens cboTipoRegimenPens1;
        private GEN.ControlesBase.txtNumRea txtPorcFlujoSPP;
        private GEN.ControlesBase.txtNumRea txtPorcMixtaSPP;
        private GEN.ControlesBase.txtNumRea txtPorcSeguroSPP;
        private GEN.ControlesBase.txtNumRea txtPorcSNP;
        private GEN.ControlesBase.txtNumRea txtPorcAporteSPP;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}