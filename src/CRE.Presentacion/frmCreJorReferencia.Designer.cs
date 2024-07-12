namespace CRE.Presentacion
{
    partial class frmCreJorReferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreJorReferencia));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.cboVinculo = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgReferencias = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.grbFormulario = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.txtTelefCel1 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoVinculo = new GEN.ControlesBase.cboBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCerrar1 = new GEN.BotonesBase.btnCerrar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferencias)).BeginInit();
            this.grbFormulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(124, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Nombres y Apellidos";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 64);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(60, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Dirección";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 103);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(112, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Celular o Teléfono";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(119, 142);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(48, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Vínculo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(9, 41);
            this.txtNombre.MaxLength = 200;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(309, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(9, 80);
            this.txtDireccion.MaxLength = 120;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(309, 20);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // cboVinculo
            // 
            this.cboVinculo.FormattingEnabled = true;
            this.cboVinculo.Location = new System.Drawing.Point(122, 158);
            this.cboVinculo.Name = "cboVinculo";
            this.cboVinculo.Size = new System.Drawing.Size(112, 21);
            this.cboVinculo.TabIndex = 4;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgReferencias);
            this.grbBase1.Location = new System.Drawing.Point(12, 205);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(324, 205);
            this.grbBase1.TabIndex = 7;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Referencias Registradas";
            // 
            // dtgReferencias
            // 
            this.dtgReferencias.AllowUserToAddRows = false;
            this.dtgReferencias.AllowUserToDeleteRows = false;
            this.dtgReferencias.AllowUserToResizeColumns = false;
            this.dtgReferencias.AllowUserToResizeRows = false;
            this.dtgReferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReferencias.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtgReferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReferencias.Location = new System.Drawing.Point(6, 19);
            this.dtgReferencias.MultiSelect = false;
            this.dtgReferencias.Name = "dtgReferencias";
            this.dtgReferencias.ReadOnly = true;
            this.dtgReferencias.RowHeadersVisible = false;
            this.dtgReferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReferencias.ShowCellToolTips = false;
            this.dtgReferencias.Size = new System.Drawing.Size(312, 180);
            this.dtgReferencias.TabIndex = 0;
            this.dtgReferencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReferencias_CellContentClick);
            this.dtgReferencias.SelectionChanged += new System.EventHandler(this.dtgReferencias_SelectionChanged);
            this.dtgReferencias.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgReferencias_KeyDown);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(12, 416);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 10;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // grbFormulario
            // 
            this.grbFormulario.Controls.Add(this.btnMiniQuitar1);
            this.grbFormulario.Controls.Add(this.btnMiniAgregar1);
            this.grbFormulario.Controls.Add(this.txtTelefCel1);
            this.grbFormulario.Controls.Add(this.lblBase1);
            this.grbFormulario.Controls.Add(this.lblBase2);
            this.grbFormulario.Controls.Add(this.lblBase3);
            this.grbFormulario.Controls.Add(this.lblBase5);
            this.grbFormulario.Controls.Add(this.lblBase4);
            this.grbFormulario.Controls.Add(this.cboTipoVinculo);
            this.grbFormulario.Controls.Add(this.txtNombre);
            this.grbFormulario.Controls.Add(this.cboVinculo);
            this.grbFormulario.Controls.Add(this.txtDireccion);
            this.grbFormulario.Location = new System.Drawing.Point(12, 12);
            this.grbFormulario.Name = "grbFormulario";
            this.grbFormulario.Size = new System.Drawing.Size(324, 187);
            this.grbFormulario.TabIndex = 10;
            this.grbFormulario.TabStop = false;
            this.grbFormulario.Text = "Formulario";
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(282, 151);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 6;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(240, 151);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 5;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtTelefCel1
            // 
            this.txtTelefCel1.Location = new System.Drawing.Point(9, 119);
            this.txtTelefCel1.MaxLength = 12;
            this.txtTelefCel1.Name = "txtTelefCel1";
            this.txtTelefCel1.Size = new System.Drawing.Size(309, 20);
            this.txtTelefCel1.TabIndex = 3;
            this.txtTelefCel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 142);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(76, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Tipo Vínculo";
            // 
            // cboTipoVinculo
            // 
            this.cboTipoVinculo.FormattingEnabled = true;
            this.cboTipoVinculo.Location = new System.Drawing.Point(9, 158);
            this.cboTipoVinculo.Name = "cboTipoVinculo";
            this.cboTipoVinculo.Size = new System.Drawing.Size(107, 21);
            this.cboTipoVinculo.TabIndex = 4;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(210, 416);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 13;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(360, 416);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(78, 416);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 11;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCerrar1
            // 
            this.btnCerrar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar1.BackgroundImage")));
            this.btnCerrar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCerrar1.Location = new System.Drawing.Point(276, 416);
            this.btnCerrar1.Name = "btnCerrar1";
            this.btnCerrar1.Size = new System.Drawing.Size(60, 50);
            this.btnCerrar1.TabIndex = 14;
            this.btnCerrar1.Text = "Cerrar";
            this.btnCerrar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar1.UseVisualStyleBackColor = true;
            this.btnCerrar1.Click += new System.EventHandler(this.btnCerrar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(144, 416);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 12;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Visible = false;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // frmCreJorReferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 497);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbFormulario);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmCreJorReferencia";
            this.Text = "Crédito Jornalero - Referencias del Cliente";
            this.Shown += new System.EventHandler(this.frmCreJorReferencia_Shown);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.grbFormulario, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCerrar1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferencias)).EndInit();
            this.grbFormulario.ResumeLayout(false);
            this.grbFormulario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.cboBase cboVinculo;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgReferencias;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.grbBase grbFormulario;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtTelefCel txtTelefCel1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCerrar btnCerrar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboTipoVinculo;
        private GEN.BotonesBase.btnGrabar btnGrabar1;

    }
}