namespace PRE.Presentacion
{
    partial class frmMantenimientoTipoAfec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTipoAfec));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.txtDescripcion = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblMantenimiento = new GEN.ControlesBase.lblBase();
            this.cboMantenimiento = new GEN.ControlesBase.cboBase(this.components);
            this.lblMesInicio = new GEN.ControlesBase.lblBase();
            this.lblMesFin = new GEN.ControlesBase.lblBase();
            this.cboMesInicio = new GEN.ControlesBase.cboBase(this.components);
            this.cboMesFin = new GEN.ControlesBase.cboBase(this.components);
            this.txtAbreviatura = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblAbreviatura = new GEN.ControlesBase.lblBase();
            this.txtCodigo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(217, 253);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(151, 253);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(19, 253);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(85, 253);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(104, 96);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(173, 20);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblMantenimiento
            // 
            this.lblMantenimiento.AutoSize = true;
            this.lblMantenimiento.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMantenimiento.ForeColor = System.Drawing.Color.Navy;
            this.lblMantenimiento.Location = new System.Drawing.Point(20, 99);
            this.lblMantenimiento.Name = "lblMantenimiento";
            this.lblMantenimiento.Size = new System.Drawing.Size(78, 13);
            this.lblMantenimiento.TabIndex = 3;
            this.lblMantenimiento.Text = "Descripción:";
            // 
            // cboMantenimiento
            // 
            this.cboMantenimiento.FormattingEnabled = true;
            this.cboMantenimiento.Location = new System.Drawing.Point(21, 22);
            this.cboMantenimiento.Name = "cboMantenimiento";
            this.cboMantenimiento.Size = new System.Drawing.Size(257, 21);
            this.cboMantenimiento.TabIndex = 0;
            this.cboMantenimiento.SelectedIndexChanged += new System.EventHandler(this.cboMantenimiento_SelectedIndexChanged);
            // 
            // lblMesInicio
            // 
            this.lblMesInicio.AutoSize = true;
            this.lblMesInicio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMesInicio.ForeColor = System.Drawing.Color.Navy;
            this.lblMesInicio.Location = new System.Drawing.Point(31, 170);
            this.lblMesInicio.Name = "lblMesInicio";
            this.lblMesInicio.Size = new System.Drawing.Size(67, 13);
            this.lblMesInicio.TabIndex = 7;
            this.lblMesInicio.Text = "Mes inicio:";
            // 
            // lblMesFin
            // 
            this.lblMesFin.AutoSize = true;
            this.lblMesFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMesFin.ForeColor = System.Drawing.Color.Navy;
            this.lblMesFin.Location = new System.Drawing.Point(46, 207);
            this.lblMesFin.Name = "lblMesFin";
            this.lblMesFin.Size = new System.Drawing.Size(52, 13);
            this.lblMesFin.TabIndex = 9;
            this.lblMesFin.Text = "Mes fin:";
            // 
            // cboMesInicio
            // 
            this.cboMesInicio.FormattingEnabled = true;
            this.cboMesInicio.Location = new System.Drawing.Point(105, 170);
            this.cboMesInicio.Name = "cboMesInicio";
            this.cboMesInicio.Size = new System.Drawing.Size(172, 21);
            this.cboMesInicio.TabIndex = 8;
            // 
            // cboMesFin
            // 
            this.cboMesFin.FormattingEnabled = true;
            this.cboMesFin.Location = new System.Drawing.Point(104, 207);
            this.cboMesFin.Name = "cboMesFin";
            this.cboMesFin.Size = new System.Drawing.Size(173, 21);
            this.cboMesFin.TabIndex = 10;
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.Location = new System.Drawing.Point(105, 133);
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.ReadOnly = true;
            this.txtAbreviatura.Size = new System.Drawing.Size(173, 20);
            this.txtAbreviatura.TabIndex = 6;
            // 
            // lblAbreviatura
            // 
            this.lblAbreviatura.AutoSize = true;
            this.lblAbreviatura.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAbreviatura.ForeColor = System.Drawing.Color.Navy;
            this.lblAbreviatura.Location = new System.Drawing.Point(21, 136);
            this.lblAbreviatura.Name = "lblAbreviatura";
            this.lblAbreviatura.Size = new System.Drawing.Size(79, 13);
            this.lblAbreviatura.TabIndex = 5;
            this.lblAbreviatura.Text = "Abreviatura:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(104, 61);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(59, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(46, 64);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Código:";
            // 
            // frmMantenimientoTipoAfec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 344);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtAbreviatura);
            this.Controls.Add(this.lblAbreviatura);
            this.Controls.Add(this.cboMesFin);
            this.Controls.Add(this.cboMesInicio);
            this.Controls.Add(this.lblMesFin);
            this.Controls.Add(this.lblMesInicio);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblMantenimiento);
            this.Controls.Add(this.cboMantenimiento);
            this.Name = "frmMantenimientoTipoAfec";
            this.Text = "Mantenimiento tipos de afectación";
            this.Load += new System.EventHandler(this.frmMantenimientoTipoAfec_Load);
            this.Shown += new System.EventHandler(this.frmMantenimientoTipoAfec_Shown);
            this.Controls.SetChildIndex(this.cboMantenimiento, 0);
            this.Controls.SetChildIndex(this.lblMantenimiento, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblMesInicio, 0);
            this.Controls.SetChildIndex(this.lblMesFin, 0);
            this.Controls.SetChildIndex(this.cboMesInicio, 0);
            this.Controls.SetChildIndex(this.cboMesFin, 0);
            this.Controls.SetChildIndex(this.lblAbreviatura, 0);
            this.Controls.SetChildIndex(this.txtAbreviatura, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.txtCBLetra txtDescripcion;
        private GEN.ControlesBase.lblBase lblMantenimiento;
        private GEN.ControlesBase.cboBase cboMantenimiento;
        private GEN.ControlesBase.lblBase lblMesInicio;
        private GEN.ControlesBase.lblBase lblMesFin;
        private GEN.ControlesBase.cboBase cboMesInicio;
        private GEN.ControlesBase.cboBase cboMesFin;
        private GEN.ControlesBase.txtCBLetra txtAbreviatura;
        private GEN.ControlesBase.lblBase lblAbreviatura;
        private GEN.ControlesBase.txtBase txtCodigo;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}