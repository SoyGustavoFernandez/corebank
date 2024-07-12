namespace DEP.Presentacion
{
    partial class frmAWActualizarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAWActualizarCliente));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.tbcCliente = new GEN.ControlesBase.tbcBase(this.components);
            this.tabDatos_Generales = new System.Windows.Forms.TabPage();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCBDocAdi = new GEN.ControlesBase.txtCBNroDocumentos(this.components);
            this.lblDocAdicional = new GEN.ControlesBase.lblBase();
            this.lblBase46 = new GEN.ControlesBase.lblBase();
            this.cboTipClasificacion = new GEN.ControlesBase.cboTipClasif(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoConst1 = new GEN.ControlesBase.cboTipoConst(this.components);
            this.cboTipVivienda = new GEN.ControlesBase.cboTipVivienda(this.components);
            this.txtResidencia = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboSector1 = new GEN.ControlesBase.cboSector(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.tabPer_Natural = new System.Windows.Forms.TabPage();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboClienteCargo1 = new GEN.ControlesBase.cboClienteCargo(this.components);
            this.lblBase34 = new GEN.ControlesBase.lblBase();
            this.cboProfesion = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.cboActividadInternaNat = new GEN.ControlesBase.cboActividadInterna(this.components);
            this.lblBase69 = new GEN.ControlesBase.lblBase();
            this.dtpFecIniActEcoNat = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase8 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroHijos = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNroPerDep = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.tbcCliente.SuspendLayout();
            this.tabDatos_Generales.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.tabPer_Natural.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase6.SuspendLayout();
            this.grbBase8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(274, 334);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 56;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(340, 334);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 55;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // tbcCliente
            // 
            this.tbcCliente.Controls.Add(this.tabDatos_Generales);
            this.tbcCliente.Controls.Add(this.tabPer_Natural);
            this.tbcCliente.Location = new System.Drawing.Point(12, 12);
            this.tbcCliente.Name = "tbcCliente";
            this.tbcCliente.SelectedIndex = 0;
            this.tbcCliente.Size = new System.Drawing.Size(392, 316);
            this.tbcCliente.TabIndex = 54;
            // 
            // tabDatos_Generales
            // 
            this.tabDatos_Generales.Controls.Add(this.grbBase1);
            this.tabDatos_Generales.Controls.Add(this.grbBase3);
            this.tabDatos_Generales.Location = new System.Drawing.Point(4, 22);
            this.tabDatos_Generales.Name = "tabDatos_Generales";
            this.tabDatos_Generales.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatos_Generales.Size = new System.Drawing.Size(384, 290);
            this.tabDatos_Generales.TabIndex = 0;
            this.tabDatos_Generales.Text = "Datos Generales";
            this.tabDatos_Generales.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtCBDocAdi);
            this.grbBase1.Controls.Add(this.lblDocAdicional);
            this.grbBase1.Controls.Add(this.lblBase46);
            this.grbBase1.Controls.Add(this.cboTipClasificacion);
            this.grbBase1.Location = new System.Drawing.Point(16, 11);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(355, 95);
            this.grbBase1.TabIndex = 47;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales del Cliente";
            // 
            // txtCBDocAdi
            // 
            this.txtCBDocAdi.Location = new System.Drawing.Point(163, 57);
            this.txtCBDocAdi.Name = "txtCBDocAdi";
            this.txtCBDocAdi.Size = new System.Drawing.Size(174, 20);
            this.txtCBDocAdi.TabIndex = 48;
            // 
            // lblDocAdicional
            // 
            this.lblDocAdicional.AutoSize = true;
            this.lblDocAdicional.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDocAdicional.ForeColor = System.Drawing.Color.Navy;
            this.lblDocAdicional.Location = new System.Drawing.Point(16, 60);
            this.lblDocAdicional.Name = "lblDocAdicional";
            this.lblDocAdicional.Size = new System.Drawing.Size(37, 13);
            this.lblDocAdicional.TabIndex = 47;
            this.lblDocAdicional.Text = "RUC:";
            // 
            // lblBase46
            // 
            this.lblBase46.AutoSize = true;
            this.lblBase46.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase46.ForeColor = System.Drawing.Color.Navy;
            this.lblBase46.Location = new System.Drawing.Point(16, 33);
            this.lblBase46.Name = "lblBase46";
            this.lblBase46.Size = new System.Drawing.Size(83, 13);
            this.lblBase46.TabIndex = 45;
            this.lblBase46.Text = "Clasificación:";
            // 
            // cboTipClasificacion
            // 
            this.cboTipClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipClasificacion.FormattingEnabled = true;
            this.cboTipClasificacion.Location = new System.Drawing.Point(163, 30);
            this.cboTipClasificacion.Name = "cboTipClasificacion";
            this.cboTipClasificacion.Size = new System.Drawing.Size(174, 21);
            this.cboTipClasificacion.TabIndex = 46;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboTipoConst1);
            this.grbBase3.Controls.Add(this.cboTipVivienda);
            this.grbBase3.Controls.Add(this.txtResidencia);
            this.grbBase3.Controls.Add(this.cboSector1);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Location = new System.Drawing.Point(16, 117);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(355, 142);
            this.grbBase3.TabIndex = 1;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Domicilio Reniec del Cliente";
            // 
            // cboTipoConst1
            // 
            this.cboTipoConst1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoConst1.FormattingEnabled = true;
            this.cboTipoConst1.Location = new System.Drawing.Point(163, 82);
            this.cboTipoConst1.Name = "cboTipoConst1";
            this.cboTipoConst1.Size = new System.Drawing.Size(174, 21);
            this.cboTipoConst1.TabIndex = 43;
            // 
            // cboTipVivienda
            // 
            this.cboTipVivienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipVivienda.DropDownWidth = 150;
            this.cboTipVivienda.FormattingEnabled = true;
            this.cboTipVivienda.Location = new System.Drawing.Point(163, 53);
            this.cboTipVivienda.Name = "cboTipVivienda";
            this.cboTipVivienda.Size = new System.Drawing.Size(174, 21);
            this.cboTipVivienda.TabIndex = 44;
            // 
            // txtResidencia
            // 
            this.txtResidencia.Location = new System.Drawing.Point(163, 110);
            this.txtResidencia.MaxLength = 2;
            this.txtResidencia.Name = "txtResidencia";
            this.txtResidencia.Size = new System.Drawing.Size(174, 20);
            this.txtResidencia.TabIndex = 41;
            // 
            // cboSector1
            // 
            this.cboSector1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSector1.FormattingEnabled = true;
            this.cboSector1.Location = new System.Drawing.Point(163, 25);
            this.cboSector1.Name = "cboSector1";
            this.cboSector1.Size = new System.Drawing.Size(174, 21);
            this.cboSector1.TabIndex = 42;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 113);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(123, 13);
            this.lblBase1.TabIndex = 39;
            this.lblBase1.Text = "Años de Residencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 85);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(129, 13);
            this.lblBase2.TabIndex = 31;
            this.lblBase2.Text = "Tipo de construcción:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 28);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 29;
            this.lblBase3.Text = "Sector:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 56);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(89, 13);
            this.lblBase4.TabIndex = 33;
            this.lblBase4.Text = "Tipo/vivienda:";
            // 
            // tabPer_Natural
            // 
            this.tabPer_Natural.Controls.Add(this.grbBase2);
            this.tabPer_Natural.Controls.Add(this.grbBase6);
            this.tabPer_Natural.Controls.Add(this.grbBase8);
            this.tabPer_Natural.Location = new System.Drawing.Point(4, 22);
            this.tabPer_Natural.Name = "tabPer_Natural";
            this.tabPer_Natural.Padding = new System.Windows.Forms.Padding(3);
            this.tabPer_Natural.Size = new System.Drawing.Size(384, 290);
            this.tabPer_Natural.TabIndex = 1;
            this.tabPer_Natural.Text = "P. Natural";
            this.tabPer_Natural.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboClienteCargo1);
            this.grbBase2.Controls.Add(this.lblBase34);
            this.grbBase2.Controls.Add(this.cboProfesion);
            this.grbBase2.Controls.Add(this.lblBase17);
            this.grbBase2.Location = new System.Drawing.Point(14, 91);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(351, 79);
            this.grbBase2.TabIndex = 30;
            this.grbBase2.TabStop = false;
            // 
            // cboClienteCargo1
            // 
            this.cboClienteCargo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClienteCargo1.DropDownWidth = 270;
            this.cboClienteCargo1.FormattingEnabled = true;
            this.cboClienteCargo1.Location = new System.Drawing.Point(149, 44);
            this.cboClienteCargo1.Name = "cboClienteCargo1";
            this.cboClienteCargo1.Size = new System.Drawing.Size(191, 21);
            this.cboClienteCargo1.TabIndex = 13;
            // 
            // lblBase34
            // 
            this.lblBase34.AutoSize = true;
            this.lblBase34.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase34.ForeColor = System.Drawing.Color.Navy;
            this.lblBase34.Location = new System.Drawing.Point(9, 47);
            this.lblBase34.Name = "lblBase34";
            this.lblBase34.Size = new System.Drawing.Size(47, 13);
            this.lblBase34.TabIndex = 12;
            this.lblBase34.Text = "Cargo:";
            // 
            // cboProfesion
            // 
            this.cboProfesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesion.DropDownWidth = 270;
            this.cboProfesion.FormattingEnabled = true;
            this.cboProfesion.Location = new System.Drawing.Point(149, 16);
            this.cboProfesion.Name = "cboProfesion";
            this.cboProfesion.Size = new System.Drawing.Size(191, 21);
            this.cboProfesion.TabIndex = 11;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(9, 19);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(137, 13);
            this.lblBase17.TabIndex = 10;
            this.lblBase17.Text = "Profesión u ocupación:";
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.cboActividadInternaNat);
            this.grbBase6.Controls.Add(this.lblBase69);
            this.grbBase6.Controls.Add(this.dtpFecIniActEcoNat);
            this.grbBase6.Controls.Add(this.lblBase11);
            this.grbBase6.Location = new System.Drawing.Point(14, 184);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(351, 93);
            this.grbBase6.TabIndex = 4;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "Actividad económica:";
            // 
            // cboActividadInternaNat
            // 
            this.cboActividadInternaNat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadInternaNat.FormattingEnabled = true;
            this.cboActividadInternaNat.Location = new System.Drawing.Point(104, 22);
            this.cboActividadInternaNat.Name = "cboActividadInternaNat";
            this.cboActividadInternaNat.Size = new System.Drawing.Size(236, 21);
            this.cboActividadInternaNat.TabIndex = 6;
            // 
            // lblBase69
            // 
            this.lblBase69.AutoSize = true;
            this.lblBase69.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase69.ForeColor = System.Drawing.Color.Navy;
            this.lblBase69.Location = new System.Drawing.Point(9, 25);
            this.lblBase69.Name = "lblBase69";
            this.lblBase69.Size = new System.Drawing.Size(89, 13);
            this.lblBase69.TabIndex = 5;
            this.lblBase69.Text = "CIIU Interno.:";
            // 
            // dtpFecIniActEcoNat
            // 
            this.dtpFecIniActEcoNat.CustomFormat = " ";
            this.dtpFecIniActEcoNat.Enabled = false;
            this.dtpFecIniActEcoNat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecIniActEcoNat.Location = new System.Drawing.Point(149, 52);
            this.dtpFecIniActEcoNat.Name = "dtpFecIniActEcoNat";
            this.dtpFecIniActEcoNat.Size = new System.Drawing.Size(191, 20);
            this.dtpFecIniActEcoNat.TabIndex = 16;
            this.dtpFecIniActEcoNat.ValueChanged += new System.EventHandler(this.dtpFecIniActEcoNat_ValueChanged);
            this.dtpFecIniActEcoNat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFecIniActEcoNat_KeyDown);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(9, 58);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(111, 13);
            this.lblBase11.TabIndex = 14;
            this.lblBase11.Text = "Ini.Actividad Eco.:";
            // 
            // grbBase8
            // 
            this.grbBase8.Controls.Add(this.txtNroHijos);
            this.grbBase8.Controls.Add(this.txtNroPerDep);
            this.grbBase8.Controls.Add(this.lblBase15);
            this.grbBase8.Controls.Add(this.lblBase16);
            this.grbBase8.Location = new System.Drawing.Point(14, 18);
            this.grbBase8.Name = "grbBase8";
            this.grbBase8.Size = new System.Drawing.Size(351, 67);
            this.grbBase8.TabIndex = 2;
            this.grbBase8.TabStop = false;
            // 
            // txtNroHijos
            // 
            this.txtNroHijos.Location = new System.Drawing.Point(271, 13);
            this.txtNroHijos.MaxLength = 2;
            this.txtNroHijos.Name = "txtNroHijos";
            this.txtNroHijos.Size = new System.Drawing.Size(69, 20);
            this.txtNroHijos.TabIndex = 28;
            // 
            // txtNroPerDep
            // 
            this.txtNroPerDep.FormatoDecimal = false;
            this.txtNroPerDep.Location = new System.Drawing.Point(271, 40);
            this.txtNroPerDep.MaxLength = 3;
            this.txtNroPerDep.Name = "txtNroPerDep";
            this.txtNroPerDep.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNroPerDep.nNumDecimales = 0;
            this.txtNroPerDep.nvalor = 0D;
            this.txtNroPerDep.Size = new System.Drawing.Size(69, 20);
            this.txtNroPerDep.TabIndex = 29;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(6, 43);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(170, 13);
            this.lblBase15.TabIndex = 26;
            this.lblBase15.Text = "Nro Personas Dependientes:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(6, 16);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(82, 13);
            this.lblBase16.TabIndex = 24;
            this.lblBase16.Text = "Nro de Hijos:";
            // 
            // frmAWActualizarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 412);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbcCliente);
            this.Name = "frmAWActualizarCliente";
            this.Text = "Actualizar Cliente";
            this.Load += new System.EventHandler(this.frmAWActualizarCliente_Load);
            this.Controls.SetChildIndex(this.tbcCliente, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.tbcCliente.ResumeLayout(false);
            this.tabDatos_Generales.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.tabPer_Natural.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            this.grbBase8.ResumeLayout(false);
            this.grbBase8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.tbcBase tbcCliente;
        private System.Windows.Forms.TabPage tabDatos_Generales;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtCBNroDocumentos txtCBDocAdi;
        private GEN.ControlesBase.lblBase lblDocAdicional;
        private GEN.ControlesBase.lblBase lblBase46;
        private GEN.ControlesBase.cboTipClasif cboTipClasificacion;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboTipoConst cboTipoConst1;
        private GEN.ControlesBase.cboTipVivienda cboTipVivienda;
        private GEN.ControlesBase.txtCBNumerosEnteros txtResidencia;
        private GEN.ControlesBase.cboSector cboSector1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.TabPage tabPer_Natural;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboClienteCargo cboClienteCargo1;
        private GEN.ControlesBase.lblBase lblBase34;
        private GEN.ControlesBase.cboBase cboProfesion;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.cboActividadInterna cboActividadInternaNat;
        private GEN.ControlesBase.lblBase lblBase69;
        private GEN.ControlesBase.dtpCorto dtpFecIniActEcoNat;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase8;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroHijos;
        private GEN.ControlesBase.txtNumRea txtNroPerDep;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase16;
    }
}