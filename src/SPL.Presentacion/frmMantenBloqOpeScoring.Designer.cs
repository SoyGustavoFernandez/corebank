namespace SPL.Presentacion
{
    partial class frmMantenBloqOpeScoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenBloqOpeScoring));
            this.cboDiasSemana = new GEN.ControlesBase.cboDiasSemana(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.grbReglas = new GEN.ControlesBase.grbBase(this.components);
            this.grbMiniCombos = new GEN.ControlesBase.grbBase(this.components);
            this.chcBloqueo = new GEN.ControlesBase.chcBase(this.components);
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.cboTipoOperacion = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnMiniCancelEst = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.dtgDetalleBloq = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcVigencia = new GEN.ControlesBase.chcBase(this.components);
            this.dtpVigHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpVigDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.dtgGrupoBloqueo = new GEN.ControlesBase.dtgBase(this.components);
            this.grbReglas.SuspendLayout();
            this.grbMiniCombos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleBloq)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoBloqueo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDiasSemana
            // 
            this.cboDiasSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiasSemana.FormattingEnabled = true;
            this.cboDiasSemana.Location = new System.Drawing.Point(109, 88);
            this.cboDiasSemana.Name = "cboDiasSemana";
            this.cboDiasSemana.Size = new System.Drawing.Size(121, 21);
            this.cboDiasSemana.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 91);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(98, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Día de semana:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(450, 467);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(516, 467);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 16;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(582, 467);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(648, 467);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(384, 467);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grbReglas
            // 
            this.grbReglas.Controls.Add(this.grbMiniCombos);
            this.grbReglas.Controls.Add(this.cboAgencias);
            this.grbReglas.Controls.Add(this.lblBase3);
            this.grbReglas.Controls.Add(this.btnMiniCancelEst);
            this.grbReglas.Controls.Add(this.btnMiniAgregar);
            this.grbReglas.Controls.Add(this.btnMiniQuitar);
            this.grbReglas.Controls.Add(this.btnMiniNuevo);
            this.grbReglas.Controls.Add(this.dtgDetalleBloq);
            this.grbReglas.Location = new System.Drawing.Point(12, 206);
            this.grbReglas.Name = "grbReglas";
            this.grbReglas.Size = new System.Drawing.Size(703, 255);
            this.grbReglas.TabIndex = 12;
            this.grbReglas.TabStop = false;
            this.grbReglas.Text = "Detalle de bloqueo por operación";
            // 
            // grbMiniCombos
            // 
            this.grbMiniCombos.Controls.Add(this.chcBloqueo);
            this.grbMiniCombos.Controls.Add(this.cboDiasSemana);
            this.grbMiniCombos.Controls.Add(this.cboModulo);
            this.grbMiniCombos.Controls.Add(this.lblBase1);
            this.grbMiniCombos.Controls.Add(this.cboTipoOperacion);
            this.grbMiniCombos.Controls.Add(this.lblBase8);
            this.grbMiniCombos.Controls.Add(this.lblBase7);
            this.grbMiniCombos.Location = new System.Drawing.Point(385, 49);
            this.grbMiniCombos.Name = "grbMiniCombos";
            this.grbMiniCombos.Size = new System.Drawing.Size(270, 148);
            this.grbMiniCombos.TabIndex = 77;
            this.grbMiniCombos.TabStop = false;
            // 
            // chcBloqueo
            // 
            this.chcBloqueo.AutoSize = true;
            this.chcBloqueo.Location = new System.Drawing.Point(8, 120);
            this.chcBloqueo.Name = "chcBloqueo";
            this.chcBloqueo.Size = new System.Drawing.Size(113, 17);
            this.chcBloqueo.TabIndex = 32;
            this.chcBloqueo.Text = "Detiene operación";
            this.chcBloqueo.UseVisualStyleBackColor = true;
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(63, 15);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(121, 21);
            this.cboModulo.TabIndex = 76;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(8, 55);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(257, 21);
            this.cboTipoOperacion.TabIndex = 75;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(5, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 74;
            this.lblBase8.Text = "Modulo:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(5, 39);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(70, 13);
            this.lblBase7.TabIndex = 73;
            this.lblBase7.Text = "Operación:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(459, 22);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(130, 21);
            this.cboAgencias.TabIndex = 71;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(389, 25);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 70;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnMiniCancelEst
            // 
            this.btnMiniCancelEst.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelEst.BackgroundImage")));
            this.btnMiniCancelEst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelEst.Location = new System.Drawing.Point(661, 158);
            this.btnMiniCancelEst.Name = "btnMiniCancelEst";
            this.btnMiniCancelEst.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelEst.TabIndex = 69;
            this.btnMiniCancelEst.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelEst.UseVisualStyleBackColor = true;
            this.btnMiniCancelEst.Click += new System.EventHandler(this.btnMiniCancelEst_Click);
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(661, 90);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 67;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            this.btnMiniAgregar.Click += new System.EventHandler(this.btnMiniAgregar_Click);
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(661, 124);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 66;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // btnMiniNuevo
            // 
            this.btnMiniNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniNuevo.BackgroundImage")));
            this.btnMiniNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniNuevo.Location = new System.Drawing.Point(661, 56);
            this.btnMiniNuevo.Name = "btnMiniNuevo";
            this.btnMiniNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnMiniNuevo.TabIndex = 65;
            this.btnMiniNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniNuevo.UseVisualStyleBackColor = true;
            this.btnMiniNuevo.Click += new System.EventHandler(this.btnMiniNuevo_Click);
            // 
            // dtgDetalleBloq
            // 
            this.dtgDetalleBloq.AllowUserToAddRows = false;
            this.dtgDetalleBloq.AllowUserToDeleteRows = false;
            this.dtgDetalleBloq.AllowUserToResizeColumns = false;
            this.dtgDetalleBloq.AllowUserToResizeRows = false;
            this.dtgDetalleBloq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleBloq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleBloq.Location = new System.Drawing.Point(12, 19);
            this.dtgDetalleBloq.MultiSelect = false;
            this.dtgDetalleBloq.Name = "dtgDetalleBloq";
            this.dtgDetalleBloq.ReadOnly = true;
            this.dtgDetalleBloq.RowHeadersVisible = false;
            this.dtgDetalleBloq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleBloq.Size = new System.Drawing.Size(367, 230);
            this.dtgDetalleBloq.TabIndex = 0;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcVigencia);
            this.grbBase1.Controls.Add(this.dtpVigHasta);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpVigDesde);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtNombre);
            this.grbBase1.Controls.Add(this.lblBase14);
            this.grbBase1.Location = new System.Drawing.Point(403, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(310, 185);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Grupo de bloqueo";
            // 
            // chcVigencia
            // 
            this.chcVigencia.AutoSize = true;
            this.chcVigencia.Location = new System.Drawing.Point(237, 72);
            this.chcVigencia.Name = "chcVigencia";
            this.chcVigencia.Size = new System.Drawing.Size(67, 17);
            this.chcVigencia.TabIndex = 31;
            this.chcVigencia.Text = "Vigencia";
            this.chcVigencia.UseVisualStyleBackColor = true;
            // 
            // dtpVigHasta
            // 
            this.dtpVigHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVigHasta.Location = new System.Drawing.Point(110, 70);
            this.dtpVigHasta.Name = "dtpVigHasta";
            this.dtpVigHasta.Size = new System.Drawing.Size(101, 20);
            this.dtpVigHasta.TabIndex = 29;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(60, 73);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 30;
            this.lblBase4.Text = "Hasta:";
            // 
            // dtpVigDesde
            // 
            this.dtpVigDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVigDesde.Location = new System.Drawing.Point(110, 47);
            this.dtpVigDesde.Name = "dtpVigDesde";
            this.dtpVigDesde.Size = new System.Drawing.Size(101, 20);
            this.dtpVigDesde.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 51);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 28;
            this.lblBase2.Text = "Vigencia desde:";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(67, 19);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(237, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(6, 22);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(57, 13);
            this.lblBase14.TabIndex = 28;
            this.lblBase14.Text = "Nombre:";
            // 
            // dtgGrupoBloqueo
            // 
            this.dtgGrupoBloqueo.AllowUserToAddRows = false;
            this.dtgGrupoBloqueo.AllowUserToDeleteRows = false;
            this.dtgGrupoBloqueo.AllowUserToResizeColumns = false;
            this.dtgGrupoBloqueo.AllowUserToResizeRows = false;
            this.dtgGrupoBloqueo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupoBloqueo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoBloqueo.Location = new System.Drawing.Point(12, 12);
            this.dtgGrupoBloqueo.MultiSelect = false;
            this.dtgGrupoBloqueo.Name = "dtgGrupoBloqueo";
            this.dtgGrupoBloqueo.ReadOnly = true;
            this.dtgGrupoBloqueo.RowHeadersVisible = false;
            this.dtgGrupoBloqueo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoBloqueo.Size = new System.Drawing.Size(385, 188);
            this.dtgGrupoBloqueo.TabIndex = 10;
            this.dtgGrupoBloqueo.SelectionChanged += new System.EventHandler(this.dtgGrupoBloqueo_SelectionChanged);
            // 
            // frmMantenBloqOpeScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 542);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbReglas);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgGrupoBloqueo);
            this.Name = "frmMantenBloqOpeScoring";
            this.Text = "Mantenimiento bloqueo de operaciones por Scoring";
            this.Load += new System.EventHandler(this.frmVerifDatosActualCli_Load);
            this.Controls.SetChildIndex(this.dtgGrupoBloqueo, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbReglas, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.grbReglas.ResumeLayout(false);
            this.grbReglas.PerformLayout();
            this.grbMiniCombos.ResumeLayout(false);
            this.grbMiniCombos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleBloq)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoBloqueo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboDiasSemana cboDiasSemana;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.grbBase grbReglas;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelEst;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniNuevo btnMiniNuevo;
        private GEN.ControlesBase.dtgBase dtgDetalleBloq;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpVigHasta;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpVigDesde;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.dtgBase dtgGrupoBloqueo;
        private GEN.ControlesBase.chcBase chcVigencia;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbMiniCombos;
        private GEN.ControlesBase.chcBase chcBloqueo;
    }
}