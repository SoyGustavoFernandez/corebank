namespace CRE.Presentacion
{
    partial class frmRecatOficina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecatOficina));
            this.grbCategoriaOficina = new System.Windows.Forms.GroupBox();
            this.lblValorClasificacion = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblClasificacion = new GEN.ControlesBase.lblBase();
            this.dtgCategoriasOficinas = new GEN.ControlesBase.dtgBase(this.components);
            this.grbActivo = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniAdjuntar = new GEN.BotonesBase.btnMiniAgregar();
            this.dtpFechaCreacion = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaCreacion = new GEN.ControlesBase.lblBase();
            this.lblValorAutomatico = new System.Windows.Forms.Label();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnMiniDescargar = new GEN.BotonesBase.btnMiniDescargar(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.lblAutomatico = new GEN.ControlesBase.lblBase();
            this.cboCategoria = new GEN.ControlesBase.cboBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.txtOficina = new GEN.ControlesBase.txtBase(this.components);
            this.btnPendiente = new GEN.BotonesBase.btnEliLista(this.components);
            this.lblOficina = new GEN.ControlesBase.lblBase();
            this.txtGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.txtJustificacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblGrupo = new GEN.ControlesBase.lblBase();
            this.lblJustificacion = new GEN.ControlesBase.lblBase();
            this.lblDesde = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblFin = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtColaborador = new GEN.ControlesBase.txtBase(this.components);
            this.lblColaborador = new GEN.ControlesBase.lblBase();
            this.btnRecategorizar = new GEN.BotonesBase.btnActualizar();
            this.txtDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblDocumento = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblCategoria = new GEN.ControlesBase.lblBase();
            this.grbCategoriaOficina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCategoriasOficinas)).BeginInit();
            this.grbActivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCategoriaOficina
            // 
            this.grbCategoriaOficina.Controls.Add(this.lblValorClasificacion);
            this.grbCategoriaOficina.Controls.Add(this.lblClasificacion);
            this.grbCategoriaOficina.Controls.Add(this.dtgCategoriasOficinas);
            this.grbCategoriaOficina.Location = new System.Drawing.Point(12, 12);
            this.grbCategoriaOficina.Name = "grbCategoriaOficina";
            this.grbCategoriaOficina.Size = new System.Drawing.Size(664, 595);
            this.grbCategoriaOficina.TabIndex = 1;
            this.grbCategoriaOficina.TabStop = false;
            this.grbCategoriaOficina.Text = "Categorías de oficina";
            // 
            // lblValorClasificacion
            // 
            this.lblValorClasificacion.AutoSize = true;
            this.lblValorClasificacion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblValorClasificacion.ForeColor = System.Drawing.Color.Navy;
            this.lblValorClasificacion.Location = new System.Drawing.Point(280, 16);
            this.lblValorClasificacion.Name = "lblValorClasificacion";
            this.lblValorClasificacion.Size = new System.Drawing.Size(13, 13);
            this.lblValorClasificacion.TabIndex = 0;
            this.lblValorClasificacion.Text = "-";
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblClasificacion.ForeColor = System.Drawing.Color.Navy;
            this.lblClasificacion.Location = new System.Drawing.Point(83, 16);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(191, 13);
            this.lblClasificacion.TabIndex = 0;
            this.lblClasificacion.Text = "Periodo de clasificación vigente:";
            // 
            // dtgCategoriasOficinas
            // 
            this.dtgCategoriasOficinas.AllowUserToAddRows = false;
            this.dtgCategoriasOficinas.AllowUserToDeleteRows = false;
            this.dtgCategoriasOficinas.AllowUserToResizeColumns = false;
            this.dtgCategoriasOficinas.AllowUserToResizeRows = false;
            this.dtgCategoriasOficinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCategoriasOficinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCategoriasOficinas.Location = new System.Drawing.Point(6, 40);
            this.dtgCategoriasOficinas.MultiSelect = false;
            this.dtgCategoriasOficinas.Name = "dtgCategoriasOficinas";
            this.dtgCategoriasOficinas.ReadOnly = true;
            this.dtgCategoriasOficinas.RowHeadersVisible = false;
            this.dtgCategoriasOficinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCategoriasOficinas.Size = new System.Drawing.Size(652, 541);
            this.dtgCategoriasOficinas.TabIndex = 1;
            this.dtgCategoriasOficinas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCategoriasOficinas_RowEnter);
            this.dtgCategoriasOficinas.Sorted += new System.EventHandler(this.dtgCategoriasOficinas_Sorted);
            // 
            // grbActivo
            // 
            this.grbActivo.Controls.Add(this.btnMiniAdjuntar);
            this.grbActivo.Controls.Add(this.dtpFechaCreacion);
            this.grbActivo.Controls.Add(this.lblFechaCreacion);
            this.grbActivo.Controls.Add(this.lblValorAutomatico);
            this.grbActivo.Controls.Add(this.btnEliminar);
            this.grbActivo.Controls.Add(this.btnMiniDescargar);
            this.grbActivo.Controls.Add(this.btnEditar);
            this.grbActivo.Controls.Add(this.lblAutomatico);
            this.grbActivo.Controls.Add(this.cboCategoria);
            this.grbActivo.Controls.Add(this.btnGrabar);
            this.grbActivo.Controls.Add(this.txtOficina);
            this.grbActivo.Controls.Add(this.btnPendiente);
            this.grbActivo.Controls.Add(this.lblOficina);
            this.grbActivo.Controls.Add(this.txtGrupo);
            this.grbActivo.Controls.Add(this.txtJustificacion);
            this.grbActivo.Controls.Add(this.lblGrupo);
            this.grbActivo.Controls.Add(this.lblJustificacion);
            this.grbActivo.Controls.Add(this.lblDesde);
            this.grbActivo.Controls.Add(this.btnCancelar);
            this.grbActivo.Controls.Add(this.lblFin);
            this.grbActivo.Controls.Add(this.btnSalir);
            this.grbActivo.Controls.Add(this.txtColaborador);
            this.grbActivo.Controls.Add(this.lblColaborador);
            this.grbActivo.Controls.Add(this.btnRecategorizar);
            this.grbActivo.Controls.Add(this.txtDocumento);
            this.grbActivo.Controls.Add(this.dtpFin);
            this.grbActivo.Controls.Add(this.lblDocumento);
            this.grbActivo.Controls.Add(this.dtpDesde);
            this.grbActivo.Controls.Add(this.lblCategoria);
            this.grbActivo.Location = new System.Drawing.Point(682, 31);
            this.grbActivo.Name = "grbActivo";
            this.grbActivo.Size = new System.Drawing.Size(317, 576);
            this.grbActivo.TabIndex = 2;
            this.grbActivo.TabStop = false;
            this.grbActivo.Text = "Categorización Vigente";
            // 
            // btnMiniAdjuntar
            // 
            this.btnMiniAdjuntar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAdjuntar.BackgroundImage")));
            this.btnMiniAdjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAdjuntar.Location = new System.Drawing.Point(271, 235);
            this.btnMiniAdjuntar.Name = "btnMiniAdjuntar";
            this.btnMiniAdjuntar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAdjuntar.TabIndex = 18;
            this.btnMiniAdjuntar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAdjuntar.UseVisualStyleBackColor = true;
            this.btnMiniAdjuntar.Click += new System.EventHandler(this.btnMiniAdjuntar_Click);
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Enabled = false;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(123, 46);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(112, 20);
            this.dtpFechaCreacion.TabIndex = 3;
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaCreacion.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaCreacion.Location = new System.Drawing.Point(12, 54);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(97, 13);
            this.lblFechaCreacion.TabIndex = 2;
            this.lblFechaCreacion.Text = "Fecha creación:";
            // 
            // lblValorAutomatico
            // 
            this.lblValorAutomatico.AutoSize = true;
            this.lblValorAutomatico.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAutomatico.ForeColor = System.Drawing.Color.Sienna;
            this.lblValorAutomatico.Location = new System.Drawing.Point(126, 81);
            this.lblValorAutomatico.Name = "lblValorAutomatico";
            this.lblValorAutomatico.Size = new System.Drawing.Size(0, 14);
            this.lblValorAutomatico.TabIndex = 5;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(43, 512);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMiniDescargar
            // 
            this.btnMiniDescargar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDescargar.BackgroundImage")));
            this.btnMiniDescargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDescargar.Location = new System.Drawing.Point(271, 236);
            this.btnMiniDescargar.Name = "btnMiniDescargar";
            this.btnMiniDescargar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDescargar.TabIndex = 35;
            this.btnMiniDescargar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMiniDescargar.UseVisualStyleBackColor = true;
            this.btnMiniDescargar.Click += new System.EventHandler(this.btnMiniDescargar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(109, 512);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblAutomatico
            // 
            this.lblAutomatico.AutoSize = true;
            this.lblAutomatico.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAutomatico.ForeColor = System.Drawing.Color.Navy;
            this.lblAutomatico.Location = new System.Drawing.Point(11, 80);
            this.lblAutomatico.Name = "lblAutomatico";
            this.lblAutomatico.Size = new System.Drawing.Size(109, 13);
            this.lblAutomatico.TabIndex = 4;
            this.lblAutomatico.Text = "Recategorizacion:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(123, 129);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(184, 21);
            this.cboCategoria.TabIndex = 9;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(109, 512);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 25;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtOficina
            // 
            this.txtOficina.Enabled = false;
            this.txtOficina.Location = new System.Drawing.Point(123, 21);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(184, 20);
            this.txtOficina.TabIndex = 1;
            // 
            // btnPendiente
            // 
            this.btnPendiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPendiente.BackgroundImage")));
            this.btnPendiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPendiente.Location = new System.Drawing.Point(43, 512);
            this.btnPendiente.Name = "btnPendiente";
            this.btnPendiente.Size = new System.Drawing.Size(60, 50);
            this.btnPendiente.TabIndex = 21;
            this.btnPendiente.Text = "Pend.";
            this.btnPendiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPendiente.UseVisualStyleBackColor = true;
            this.btnPendiente.Click += new System.EventHandler(this.btnPendiente_Click);
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblOficina.ForeColor = System.Drawing.Color.Navy;
            this.lblOficina.Location = new System.Drawing.Point(11, 24);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(51, 13);
            this.lblOficina.TabIndex = 0;
            this.lblOficina.Text = "Oficina:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Enabled = false;
            this.txtGrupo.Location = new System.Drawing.Point(123, 102);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(184, 20);
            this.txtGrupo.TabIndex = 7;
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(14, 291);
            this.txtJustificacion.Multiline = true;
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(293, 195);
            this.txtJustificacion.TabIndex = 20;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblGrupo.ForeColor = System.Drawing.Color.Navy;
            this.lblGrupo.Location = new System.Drawing.Point(11, 105);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(47, 13);
            this.lblGrupo.TabIndex = 6;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblJustificacion
            // 
            this.lblJustificacion.AutoSize = true;
            this.lblJustificacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblJustificacion.ForeColor = System.Drawing.Color.Navy;
            this.lblJustificacion.Location = new System.Drawing.Point(10, 270);
            this.lblJustificacion.Name = "lblJustificacion";
            this.lblJustificacion.Size = new System.Drawing.Size(80, 13);
            this.lblJustificacion.TabIndex = 19;
            this.lblJustificacion.Text = "Justificacion:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDesde.ForeColor = System.Drawing.Color.Navy;
            this.lblDesde.Location = new System.Drawing.Point(12, 160);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(80, 13);
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "Fecha Inicio:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(175, 512);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFin.ForeColor = System.Drawing.Color.Navy;
            this.lblFin.Location = new System.Drawing.Point(11, 187);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(65, 13);
            this.lblFin.TabIndex = 12;
            this.lblFin.Text = "Fecha Fin:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(241, 513);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtColaborador
            // 
            this.txtColaborador.Enabled = false;
            this.txtColaborador.Location = new System.Drawing.Point(123, 210);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.Size = new System.Drawing.Size(184, 20);
            this.txtColaborador.TabIndex = 15;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblColaborador.ForeColor = System.Drawing.Color.Navy;
            this.lblColaborador.Location = new System.Drawing.Point(11, 213);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(109, 13);
            this.lblColaborador.TabIndex = 14;
            this.lblColaborador.Text = "Reclasificado por:";
            // 
            // btnRecategorizar
            // 
            this.btnRecategorizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecategorizar.BackgroundImage")));
            this.btnRecategorizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecategorizar.Location = new System.Drawing.Point(43, 512);
            this.btnRecategorizar.Name = "btnRecategorizar";
            this.btnRecategorizar.Size = new System.Drawing.Size(60, 50);
            this.btnRecategorizar.TabIndex = 23;
            this.btnRecategorizar.Text = "Recateg.";
            this.btnRecategorizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecategorizar.texto = "Recateg.";
            this.btnRecategorizar.UseVisualStyleBackColor = true;
            this.btnRecategorizar.Click += new System.EventHandler(this.btnRecategorizar_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(122, 243);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(143, 20);
            this.txtDocumento.TabIndex = 17;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(123, 181);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFin.TabIndex = 13;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDocumento.ForeColor = System.Drawing.Color.Navy;
            this.lblDocumento.Location = new System.Drawing.Point(10, 245);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(86, 13);
            this.lblDocumento.TabIndex = 16;
            this.lblDocumento.Text = "Doc. Adjunto:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(123, 154);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 11;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCategoria.ForeColor = System.Drawing.Color.Navy;
            this.lblCategoria.Location = new System.Drawing.Point(12, 131);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(68, 13);
            this.lblCategoria.TabIndex = 8;
            this.lblCategoria.Text = "Categoria:";
            // 
            // frmRecatOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 637);
            this.Controls.Add(this.grbActivo);
            this.Controls.Add(this.grbCategoriaOficina);
            this.Name = "frmRecatOficina";
            this.Text = "Recategorización  de oficinas";
            this.Load += new System.EventHandler(this.frmRecatOficina_Load);
            this.Controls.SetChildIndex(this.grbCategoriaOficina, 0);
            this.Controls.SetChildIndex(this.grbActivo, 0);
            this.grbCategoriaOficina.ResumeLayout(false);
            this.grbCategoriaOficina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCategoriasOficinas)).EndInit();
            this.grbActivo.ResumeLayout(false);
            this.grbActivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCategoriaOficina;
        private GEN.ControlesBase.dtgBase dtgCategoriasOficinas;
        private GEN.ControlesBase.grbBase grbActivo;
        private GEN.ControlesBase.lblBase lblAutomatico;
        private GEN.ControlesBase.cboBase cboCategoria;
        private GEN.ControlesBase.txtBase txtOficina;
        private GEN.BotonesBase.btnEliLista btnPendiente;
        private GEN.ControlesBase.lblBase lblOficina;
        private GEN.ControlesBase.txtBase txtGrupo;
        private GEN.ControlesBase.txtBase txtJustificacion;
        private GEN.ControlesBase.lblBase lblGrupo;
        private GEN.ControlesBase.lblBase lblJustificacion;
        private GEN.ControlesBase.lblBase lblDesde;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblFin;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtBase txtColaborador;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblColaborador;
        private GEN.BotonesBase.btnActualizar btnRecategorizar;
        private GEN.ControlesBase.txtBase txtDocumento;
        private GEN.ControlesBase.dtpCorto dtpFin;
        private GEN.ControlesBase.lblBase lblDocumento;
        private GEN.ControlesBase.dtpCorto dtpDesde;
        private GEN.ControlesBase.lblBase lblCategoria;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnMiniDescargar btnMiniDescargar;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private System.Windows.Forms.Label lblValorAutomatico;
        private GEN.ControlesBase.lblBaseCustom lblValorClasificacion;
        private GEN.ControlesBase.lblBase lblClasificacion;
        private GEN.ControlesBase.dtpCorto dtpFechaCreacion;
        private GEN.ControlesBase.lblBase lblFechaCreacion;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAdjuntar;
    }
}