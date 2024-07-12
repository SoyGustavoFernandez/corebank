namespace CRE.ControlBase
{
    partial class ConActEconomica
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingActEconomica = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtAnios = new GEN.ControlesBase.nudBase(this.components);
            this.txtReferencia = new GEN.ControlesBase.txtBase(this.components);
            this.cboActividadInterna = new GEN.ControlesBase.cboActividadInterna(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoActividad = new GEN.ControlesBase.cboBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.grbTitulo = new GEN.ControlesBase.grbBase(this.components);
            this.chcHabilitado = new GEN.ControlesBase.chcBase(this.components);
            this.lblBaseCustom13 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom8 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom11 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom10 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom12 = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingActEconomica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnios)).BeginInit();
            this.grbTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // txtAnios
            // 
            this.txtAnios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.errorProvider.SetIconPadding(this.txtAnios, -18);
            this.txtAnios.Location = new System.Drawing.Point(278, 32);
            this.txtAnios.Name = "txtAnios";
            this.txtAnios.Size = new System.Drawing.Size(50, 20);
            this.txtAnios.TabIndex = 4;
            this.txtAnios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnios.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnios_Validating);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorProvider.SetIconPadding(this.txtReferencia, -18);
            this.txtReferencia.Location = new System.Drawing.Point(72, 77);
            this.txtReferencia.MaxLength = 200;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(256, 20);
            this.txtReferencia.TabIndex = 6;
            this.txtReferencia.Validating += new System.ComponentModel.CancelEventHandler(this.txtReferencia_Validating);
            // 
            // cboActividadInterna
            // 
            this.cboActividadInterna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboActividadInterna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadInterna.DropDownWidth = 400;
            this.cboActividadInterna.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboActividadInterna, -28);
            this.cboActividadInterna.Location = new System.Drawing.Point(114, 32);
            this.cboActividadInterna.Name = "cboActividadInterna";
            this.cboActividadInterna.Size = new System.Drawing.Size(158, 21);
            this.cboActividadInterna.TabIndex = 3;
            this.cboActividadInterna.Validating += new System.ComponentModel.CancelEventHandler(this.cboActividadInterna_Validating);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorProvider.SetIconAlignment(this.txtDescripcion, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.errorProvider.SetIconPadding(this.txtDescripcion, -18);
            this.txtDescripcion.Location = new System.Drawing.Point(6, 99);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(322, 123);
            this.txtDescripcion.TabIndex = 7;
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcion_Validating);
            // 
            // cboTipoActividad
            // 
            this.cboTipoActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoActividad.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboTipoActividad, -28);
            this.cboTipoActividad.Location = new System.Drawing.Point(6, 32);
            this.cboTipoActividad.Name = "cboTipoActividad";
            this.cboTipoActividad.Size = new System.Drawing.Size(102, 21);
            this.cboTipoActividad.TabIndex = 2;
            this.cboTipoActividad.Validating += new System.ComponentModel.CancelEventHandler(this.cboTipoActividad_Validating);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorProvider.SetIconPadding(this.txtDireccion, -18);
            this.txtDireccion.Location = new System.Drawing.Point(72, 55);
            this.txtDireccion.MaxLength = 200;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(256, 20);
            this.txtDireccion.TabIndex = 5;
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDireccion_Validating);
            // 
            // grbTitulo
            // 
            this.grbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbTitulo.Controls.Add(this.txtAnios);
            this.grbTitulo.Controls.Add(this.chcHabilitado);
            this.grbTitulo.Controls.Add(this.txtReferencia);
            this.grbTitulo.Controls.Add(this.lblBaseCustom13);
            this.grbTitulo.Controls.Add(this.cboActividadInterna);
            this.grbTitulo.Controls.Add(this.txtDescripcion);
            this.grbTitulo.Controls.Add(this.cboTipoActividad);
            this.grbTitulo.Controls.Add(this.lblBaseCustom8);
            this.grbTitulo.Controls.Add(this.lblBaseCustom11);
            this.grbTitulo.Controls.Add(this.lblBaseCustom10);
            this.grbTitulo.Controls.Add(this.txtDireccion);
            this.grbTitulo.Controls.Add(this.lblBaseCustom12);
            this.grbTitulo.Location = new System.Drawing.Point(3, 3);
            this.grbTitulo.Name = "grbTitulo";
            this.grbTitulo.Size = new System.Drawing.Size(333, 227);
            this.grbTitulo.TabIndex = 127;
            this.grbTitulo.TabStop = false;
            this.grbTitulo.Text = "     Actividad Principal";
            // 
            // chcHabilitado
            // 
            this.chcHabilitado.AutoSize = true;
            this.chcHabilitado.Location = new System.Drawing.Point(6, 0);
            this.chcHabilitado.Name = "chcHabilitado";
            this.chcHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chcHabilitado.TabIndex = 1;
            this.chcHabilitado.UseVisualStyleBackColor = true;
            this.chcHabilitado.CheckedChanged += new System.EventHandler(this.chcHabilitado_CheckedChanged);
            // 
            // lblBaseCustom13
            // 
            this.lblBaseCustom13.AutoSize = true;
            this.lblBaseCustom13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom13.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom13.Location = new System.Drawing.Point(2, 80);
            this.lblBaseCustom13.Name = "lblBaseCustom13";
            this.lblBaseCustom13.Size = new System.Drawing.Size(68, 13);
            this.lblBaseCustom13.TabIndex = 139;
            this.lblBaseCustom13.Text = "Referencia";
            // 
            // lblBaseCustom8
            // 
            this.lblBaseCustom8.AutoSize = true;
            this.lblBaseCustom8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom8.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom8.Location = new System.Drawing.Point(14, 17);
            this.lblBaseCustom8.Name = "lblBaseCustom8";
            this.lblBaseCustom8.Size = new System.Drawing.Size(87, 13);
            this.lblBaseCustom8.TabIndex = 136;
            this.lblBaseCustom8.Text = "Tipo Actividad";
            // 
            // lblBaseCustom11
            // 
            this.lblBaseCustom11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseCustom11.AutoSize = true;
            this.lblBaseCustom11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom11.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom11.Location = new System.Drawing.Point(286, 16);
            this.lblBaseCustom11.Name = "lblBaseCustom11";
            this.lblBaseCustom11.Size = new System.Drawing.Size(35, 13);
            this.lblBaseCustom11.TabIndex = 135;
            this.lblBaseCustom11.Text = "Años";
            // 
            // lblBaseCustom10
            // 
            this.lblBaseCustom10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseCustom10.AutoSize = true;
            this.lblBaseCustom10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom10.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom10.Location = new System.Drawing.Point(139, 17);
            this.lblBaseCustom10.Name = "lblBaseCustom10";
            this.lblBaseCustom10.Size = new System.Drawing.Size(105, 13);
            this.lblBaseCustom10.TabIndex = 134;
            this.lblBaseCustom10.Text = "Actividad Interna";
            // 
            // lblBaseCustom12
            // 
            this.lblBaseCustom12.AutoSize = true;
            this.lblBaseCustom12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom12.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom12.Location = new System.Drawing.Point(10, 58);
            this.lblBaseCustom12.Name = "lblBaseCustom12";
            this.lblBaseCustom12.Size = new System.Drawing.Size(60, 13);
            this.lblBaseCustom12.TabIndex = 131;
            this.lblBaseCustom12.Text = "Dirección";
            // 
            // ConActEconomica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbTitulo);
            this.Name = "ConActEconomica";
            this.Size = new System.Drawing.Size(340, 234);
            ((System.ComponentModel.ISupportInitialize)(this.bindingActEconomica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnios)).EndInit();
            this.grbTitulo.ResumeLayout(false);
            this.grbTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GEN.ControlesBase.grbBase grbTitulo;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.cboBase cboTipoActividad;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom8;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom11;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom10;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom12;
        private GEN.ControlesBase.txtBase txtReferencia;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom13;
        private GEN.ControlesBase.cboActividadInterna cboActividadInterna;
        private GEN.ControlesBase.chcBase chcHabilitado;
        private System.Windows.Forms.BindingSource bindingActEconomica;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private GEN.ControlesBase.nudBase txtAnios;
    }
}
