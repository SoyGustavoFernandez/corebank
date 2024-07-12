namespace RCP.Presentacion
{
    partial class frmAgregarEditarConfMeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarConfMeta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboListaPerfil1 = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.chbTodasAgencias = new System.Windows.Forms.CheckBox();
            this.clbAgencias = new System.Windows.Forms.CheckedListBox();
            this.cboTramo1 = new GEN.ControlesBase.cboTramo(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboUsuRecuperadores1 = new GEN.ControlesBase.cboUsuRecuperadores(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboPeriodo1 = new GEN.ControlesBase.cboPeriodo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboVariableRecuperaciones1 = new GEN.ControlesBase.cboVariableRecuperaciones(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMinMetaComi = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtBono = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMetaBono = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMeta = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboListaPerfil1);
            this.groupBox1.Controls.Add(this.lblBase11);
            this.groupBox1.Controls.Add(this.chbTodasAgencias);
            this.groupBox1.Controls.Add(this.clbAgencias);
            this.groupBox1.Controls.Add(this.cboTramo1);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.cboUsuRecuperadores1);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboPeriodo1);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.cboVariableRecuperaciones1);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cboListaPerfil1
            // 
            this.cboListaPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil1.FormattingEnabled = true;
            this.cboListaPerfil1.Location = new System.Drawing.Point(82, 48);
            this.cboListaPerfil1.Name = "cboListaPerfil1";
            this.cboListaPerfil1.Size = new System.Drawing.Size(256, 21);
            this.cboListaPerfil1.TabIndex = 1;
            this.cboListaPerfil1.SelectedIndexChanged += new System.EventHandler(this.cboListaPerfil1_SelectedIndexChanged);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(39, 52);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(41, 13);
            this.lblBase11.TabIndex = 13;
            this.lblBase11.Text = "Perfil:";
            // 
            // chbTodasAgencias
            // 
            this.chbTodasAgencias.AutoSize = true;
            this.chbTodasAgencias.Location = new System.Drawing.Point(407, 128);
            this.chbTodasAgencias.Name = "chbTodasAgencias";
            this.chbTodasAgencias.Size = new System.Drawing.Size(119, 17);
            this.chbTodasAgencias.TabIndex = 6;
            this.chbTodasAgencias.Text = "Todas las Agencias";
            this.chbTodasAgencias.UseVisualStyleBackColor = true;
            this.chbTodasAgencias.CheckedChanged += new System.EventHandler(this.chbTodasAgencias_CheckedChanged);
            // 
            // clbAgencias
            // 
            this.clbAgencias.CheckOnClick = true;
            this.clbAgencias.FormattingEnabled = true;
            this.clbAgencias.Location = new System.Drawing.Point(407, 49);
            this.clbAgencias.Name = "clbAgencias";
            this.clbAgencias.Size = new System.Drawing.Size(185, 64);
            this.clbAgencias.TabIndex = 5;
            this.clbAgencias.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbAgencias_ItemCheck);
            // 
            // cboTramo1
            // 
            this.cboTramo1.FormattingEnabled = true;
            this.cboTramo1.Location = new System.Drawing.Point(81, 102);
            this.cboTramo1.Name = "cboTramo1";
            this.cboTramo1.Size = new System.Drawing.Size(151, 21);
            this.cboTramo1.TabIndex = 3;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(32, 106);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(48, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Tramo:";
            // 
            // cboUsuRecuperadores1
            // 
            this.cboUsuRecuperadores1.FormattingEnabled = true;
            this.cboUsuRecuperadores1.Location = new System.Drawing.Point(81, 21);
            this.cboUsuRecuperadores1.Name = "cboUsuRecuperadores1";
            this.cboUsuRecuperadores1.Size = new System.Drawing.Size(511, 21);
            this.cboUsuRecuperadores1.TabIndex = 0;
            this.cboUsuRecuperadores1.SelectedIndexChanged += new System.EventHandler(this.cboUsuRecuperadores1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(30, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Gestor:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(350, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Agencia:";
            // 
            // cboPeriodo1
            // 
            this.cboPeriodo1.FormattingEnabled = true;
            this.cboPeriodo1.Location = new System.Drawing.Point(82, 75);
            this.cboPeriodo1.Name = "cboPeriodo1";
            this.cboPeriodo1.Size = new System.Drawing.Size(152, 21);
            this.cboPeriodo1.TabIndex = 2;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(25, 79);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Periodo:";
            // 
            // cboVariableRecuperaciones1
            // 
            this.cboVariableRecuperaciones1.FormattingEnabled = true;
            this.cboVariableRecuperaciones1.Location = new System.Drawing.Point(81, 128);
            this.cboVariableRecuperaciones1.Name = "cboVariableRecuperaciones1";
            this.cboVariableRecuperaciones1.Size = new System.Drawing.Size(250, 21);
            this.cboVariableRecuperaciones1.TabIndex = 4;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(22, 132);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(58, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Variable:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMinMetaComi);
            this.groupBox2.Controls.Add(this.lblBase10);
            this.groupBox2.Controls.Add(this.txtBono);
            this.groupBox2.Controls.Add(this.txtMetaBono);
            this.groupBox2.Controls.Add(this.txtComision);
            this.groupBox2.Controls.Add(this.txtMeta);
            this.groupBox2.Controls.Add(this.lblBase9);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Controls.Add(this.lblBase7);
            this.groupBox2.Controls.Add(this.lblBase6);
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variables";
            // 
            // txtMinMetaComi
            // 
            this.txtMinMetaComi.FormatoDecimal = false;
            this.txtMinMetaComi.Location = new System.Drawing.Point(174, 45);
            this.txtMinMetaComi.MaxLength = 6;
            this.txtMinMetaComi.Name = "txtMinMetaComi";
            this.txtMinMetaComi.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinMetaComi.nNumDecimales = 2;
            this.txtMinMetaComi.nvalor = 0D;
            this.txtMinMetaComi.Size = new System.Drawing.Size(100, 20);
            this.txtMinMetaComi.TabIndex = 1;
            this.txtMinMetaComi.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(23, 49);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(148, 13);
            this.lblBase10.TabIndex = 18;
            this.lblBase10.Text = "Min. para Comisión (%):";
            // 
            // txtBono
            // 
            this.txtBono.FormatoDecimal = false;
            this.txtBono.Location = new System.Drawing.Point(407, 71);
            this.txtBono.MaxLength = 6;
            this.txtBono.Name = "txtBono";
            this.txtBono.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBono.nNumDecimales = 2;
            this.txtBono.nvalor = 0D;
            this.txtBono.Size = new System.Drawing.Size(100, 20);
            this.txtBono.TabIndex = 4;
            this.txtBono.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtMetaBono
            // 
            this.txtMetaBono.FormatoDecimal = false;
            this.txtMetaBono.Location = new System.Drawing.Point(174, 71);
            this.txtMetaBono.MaxLength = 6;
            this.txtMetaBono.Name = "txtMetaBono";
            this.txtMetaBono.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMetaBono.nNumDecimales = 2;
            this.txtMetaBono.nvalor = 0D;
            this.txtMetaBono.Size = new System.Drawing.Size(100, 20);
            this.txtMetaBono.TabIndex = 3;
            this.txtMetaBono.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtComision
            // 
            this.txtComision.FormatoDecimal = false;
            this.txtComision.Location = new System.Drawing.Point(407, 45);
            this.txtComision.MaxLength = 6;
            this.txtComision.Name = "txtComision";
            this.txtComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtComision.nNumDecimales = 2;
            this.txtComision.nvalor = 0D;
            this.txtComision.Size = new System.Drawing.Size(100, 20);
            this.txtComision.TabIndex = 2;
            this.txtComision.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtMeta
            // 
            this.txtMeta.FormatoDecimal = false;
            this.txtMeta.Location = new System.Drawing.Point(174, 19);
            this.txtMeta.MaxLength = 6;
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMeta.nNumDecimales = 2;
            this.txtMeta.nvalor = 0D;
            this.txtMeta.Size = new System.Drawing.Size(100, 20);
            this.txtMeta.TabIndex = 0;
            this.txtMeta.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(339, 75);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(67, 13);
            this.lblBase9.TabIndex = 16;
            this.lblBase9.Text = "Bono (%):";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(73, 75);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(98, 13);
            this.lblBase8.TabIndex = 15;
            this.lblBase8.Text = "Meta Bono (%):";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(315, 49);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(91, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Comisión (%):";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(106, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(65, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Meta (%):";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(550, 294);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(484, 294);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // frmAgregarEditarConfMeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 372);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAgregarEditarConfMeta";
            this.Text = "Agregar/Editar Configuración de Metas";
            this.Load += new System.EventHandler(this.frmAgregarEditarConfMeta_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtNumRea txtMeta;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtBono;
        private GEN.ControlesBase.txtNumRea txtMetaBono;
        private GEN.ControlesBase.txtNumRea txtComision;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtNumRea txtMinMetaComi;
        private GEN.ControlesBase.lblBase lblBase10;
        public GEN.ControlesBase.cboTramo cboTramo1;
        public GEN.ControlesBase.cboUsuRecuperadores cboUsuRecuperadores1;
        public GEN.ControlesBase.cboPeriodo cboPeriodo1;
        public GEN.ControlesBase.cboVariableRecuperaciones cboVariableRecuperaciones1;
        public System.Windows.Forms.CheckedListBox clbAgencias;
        public System.Windows.Forms.CheckBox chbTodasAgencias;
        private GEN.ControlesBase.cboListaPerfil cboListaPerfil1;
        private GEN.ControlesBase.lblBase lblBase11;
    }
}