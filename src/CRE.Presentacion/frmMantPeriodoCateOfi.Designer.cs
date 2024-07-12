namespace CRE.Presentacion
{
    partial class frmMantPeriodoCateOfi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantPeriodoCateOfi));
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblPeriodo = new GEN.ControlesBase.lblBase();
            this.lblNombre = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblDescripcion = new GEN.ControlesBase.lblBase();
            this.cboEstado = new GEN.ControlesBase.cboBase(this.components);
            this.lblEstado = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaInicio = new GEN.ControlesBase.lblBase();
            this.cboPeriodoCateOfi = new GEN.ControlesBase.cboPeriodoCateOfi(this.components);
            this.chbVigente = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(148, 272);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(280, 272);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(214, 272);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(82, 272);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(16, 272);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.Navy;
            this.lblPeriodo.Location = new System.Drawing.Point(20, 13);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(83, 13);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Clasificación:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombre.ForeColor = System.Drawing.Color.Navy;
            this.lblNombre.Location = new System.Drawing.Point(19, 47);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(109, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(224, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(107, 139);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(231, 93);
            this.txtDescripcion.TabIndex = 9;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 139);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // cboEstado
            // 
            this.cboEstado.Enabled = false;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(109, 73);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(224, 21);
            this.cboEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(20, 76);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 13);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(107, 107);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaInicio.TabIndex = 7;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaInicio.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaInicio.Location = new System.Drawing.Point(19, 107);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(78, 13);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // cboPeriodoCateOfi
            // 
            this.cboPeriodoCateOfi.FormattingEnabled = true;
            this.cboPeriodoCateOfi.Location = new System.Drawing.Point(110, 13);
            this.cboPeriodoCateOfi.Name = "cboPeriodoCateOfi";
            this.cboPeriodoCateOfi.Size = new System.Drawing.Size(223, 21);
            this.cboPeriodoCateOfi.TabIndex = 1;
            this.cboPeriodoCateOfi.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoCateOfi_SelectedIndexChanged);
            // 
            // chbVigente
            // 
            this.chbVigente.AutoSize = true;
            this.chbVigente.Location = new System.Drawing.Point(107, 238);
            this.chbVigente.Name = "chbVigente";
            this.chbVigente.Size = new System.Drawing.Size(62, 17);
            this.chbVigente.TabIndex = 10;
            this.chbVigente.Text = "Vigente";
            this.chbVigente.UseVisualStyleBackColor = true;
            // 
            // frmMantPeriodoCateOfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 354);
            this.Controls.Add(this.chbVigente);
            this.Controls.Add(this.cboPeriodoCateOfi);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Name = "frmMantPeriodoCateOfi";
            this.Text = "frmMantPeriodoCateOfi";
            this.Load += new System.EventHandler(this.frmMantPeriodoCateOfi_Load);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.lblPeriodo, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.cboEstado, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.lblFechaInicio, 0);
            this.Controls.SetChildIndex(this.cboPeriodoCateOfi, 0);
            this.Controls.SetChildIndex(this.chbVigente, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.lblBase lblPeriodo;
        private GEN.ControlesBase.lblBase lblNombre;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblDescripcion;
        private GEN.ControlesBase.cboBase cboEstado;
        private GEN.ControlesBase.lblBase lblEstado;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblFechaInicio;
        private GEN.ControlesBase.cboPeriodoCateOfi cboPeriodoCateOfi;
        private System.Windows.Forms.CheckBox chbVigente;
    }
}