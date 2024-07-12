namespace RCP.Presentacion
{
    partial class frmRegistrarPlanTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarPlanTrabajo));
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.tbcDatosPlanTrabajo = new GEN.ControlesBase.tbcBase(this.components);
            this.tabObjetivosGenerales = new System.Windows.Forms.TabPage();
            this.btnMiniEditarGeneral = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniQuitarGeneral = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregarGeneral = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgObjetivoGeneral = new GEN.ControlesBase.dtgBase(this.components);
            this.tabObjetivoEspecificos = new System.Windows.Forms.TabPage();
            this.btnMiniEditarEspecifico = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniQuitarEspecifico = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregarEspecifico = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgObjetivoEspecifico = new GEN.ControlesBase.dtgBase(this.components);
            this.tabDetalleAccion = new System.Windows.Forms.TabPage();
            this.btnMiniQuitarAccion = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniEditarAccion = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniAgregarAccion = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgDetalleAccion = new GEN.ControlesBase.dtgBase(this.components);
            this.tabZonaVisita = new System.Windows.Forms.TabPage();
            this.dtgZonaVisita = new GEN.ControlesBase.dtgBase(this.components);
            this.btnMiniQuitarVisita = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniEditarVisita = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniAgregarVisita = new GEN.BotonesBase.btnMiniAgregar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.conBusColaborador = new GEN.ControlesBase.ConBusCol();
            this.cboEstadoSolicitud = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.lblEstado = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbDatosPlanTrabajo = new System.Windows.Forms.GroupBox();
            this.lblFechaResolucion = new GEN.ControlesBase.lblBase();
            this.dtpFechaResolucion = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.btnListarSolicitud = new GEN.BotonesBase.Boton();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnRechazar = new GEN.BotonesBase.btnRechazar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.tbcDatosPlanTrabajo.SuspendLayout();
            this.tabObjetivosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObjetivoGeneral)).BeginInit();
            this.tabObjetivoEspecificos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObjetivoEspecifico)).BeginInit();
            this.tabDetalleAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAccion)).BeginInit();
            this.tabZonaVisita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonaVisita)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbDatosPlanTrabajo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(582, 431);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(708, 431);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(642, 431);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(522, 431);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(7, 436);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // tbcDatosPlanTrabajo
            // 
            this.tbcDatosPlanTrabajo.Controls.Add(this.tabObjetivosGenerales);
            this.tbcDatosPlanTrabajo.Controls.Add(this.tabObjetivoEspecificos);
            this.tbcDatosPlanTrabajo.Controls.Add(this.tabDetalleAccion);
            this.tbcDatosPlanTrabajo.Controls.Add(this.tabZonaVisita);
            this.tbcDatosPlanTrabajo.Location = new System.Drawing.Point(8, 19);
            this.tbcDatosPlanTrabajo.Name = "tbcDatosPlanTrabajo";
            this.tbcDatosPlanTrabajo.SelectedIndex = 0;
            this.tbcDatosPlanTrabajo.Size = new System.Drawing.Size(757, 276);
            this.tbcDatosPlanTrabajo.TabIndex = 0;
            // 
            // tabObjetivosGenerales
            // 
            this.tabObjetivosGenerales.Controls.Add(this.btnMiniEditarGeneral);
            this.tabObjetivosGenerales.Controls.Add(this.btnMiniQuitarGeneral);
            this.tabObjetivosGenerales.Controls.Add(this.btnMiniAgregarGeneral);
            this.tabObjetivosGenerales.Controls.Add(this.dtgObjetivoGeneral);
            this.tabObjetivosGenerales.Location = new System.Drawing.Point(4, 22);
            this.tabObjetivosGenerales.Name = "tabObjetivosGenerales";
            this.tabObjetivosGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabObjetivosGenerales.Size = new System.Drawing.Size(749, 250);
            this.tabObjetivosGenerales.TabIndex = 0;
            this.tabObjetivosGenerales.Text = "Objetivos Generales";
            this.tabObjetivosGenerales.UseVisualStyleBackColor = true;
            // 
            // btnMiniEditarGeneral
            // 
            this.btnMiniEditarGeneral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditarGeneral.BackgroundImage")));
            this.btnMiniEditarGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditarGeneral.Enabled = false;
            this.btnMiniEditarGeneral.Location = new System.Drawing.Point(704, 34);
            this.btnMiniEditarGeneral.Name = "btnMiniEditarGeneral";
            this.btnMiniEditarGeneral.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditarGeneral.TabIndex = 2;
            this.btnMiniEditarGeneral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditarGeneral.UseVisualStyleBackColor = true;
            this.btnMiniEditarGeneral.Click += new System.EventHandler(this.btnMiniEditarGeneral_Click);
            // 
            // btnMiniQuitarGeneral
            // 
            this.btnMiniQuitarGeneral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarGeneral.BackgroundImage")));
            this.btnMiniQuitarGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarGeneral.Enabled = false;
            this.btnMiniQuitarGeneral.Location = new System.Drawing.Point(704, 62);
            this.btnMiniQuitarGeneral.Name = "btnMiniQuitarGeneral";
            this.btnMiniQuitarGeneral.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarGeneral.TabIndex = 3;
            this.btnMiniQuitarGeneral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarGeneral.UseVisualStyleBackColor = true;
            this.btnMiniQuitarGeneral.Click += new System.EventHandler(this.btnMiniQuitarGeneral_Click);
            // 
            // btnMiniAgregarGeneral
            // 
            this.btnMiniAgregarGeneral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarGeneral.BackgroundImage")));
            this.btnMiniAgregarGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarGeneral.Enabled = false;
            this.btnMiniAgregarGeneral.Location = new System.Drawing.Point(704, 5);
            this.btnMiniAgregarGeneral.Name = "btnMiniAgregarGeneral";
            this.btnMiniAgregarGeneral.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarGeneral.TabIndex = 1;
            this.btnMiniAgregarGeneral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarGeneral.UseVisualStyleBackColor = true;
            this.btnMiniAgregarGeneral.Click += new System.EventHandler(this.btnMiniAgregarGeneral_Click);
            // 
            // dtgObjetivoGeneral
            // 
            this.dtgObjetivoGeneral.AllowUserToAddRows = false;
            this.dtgObjetivoGeneral.AllowUserToDeleteRows = false;
            this.dtgObjetivoGeneral.AllowUserToResizeColumns = false;
            this.dtgObjetivoGeneral.AllowUserToResizeRows = false;
            this.dtgObjetivoGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObjetivoGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObjetivoGeneral.Location = new System.Drawing.Point(5, 5);
            this.dtgObjetivoGeneral.MultiSelect = false;
            this.dtgObjetivoGeneral.Name = "dtgObjetivoGeneral";
            this.dtgObjetivoGeneral.ReadOnly = true;
            this.dtgObjetivoGeneral.RowHeadersVisible = false;
            this.dtgObjetivoGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgObjetivoGeneral.Size = new System.Drawing.Size(690, 235);
            this.dtgObjetivoGeneral.TabIndex = 0;
            this.dtgObjetivoGeneral.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgObjetivoGeneral_CellDoubleClick);
            // 
            // tabObjetivoEspecificos
            // 
            this.tabObjetivoEspecificos.Controls.Add(this.btnMiniEditarEspecifico);
            this.tabObjetivoEspecificos.Controls.Add(this.btnMiniQuitarEspecifico);
            this.tabObjetivoEspecificos.Controls.Add(this.btnMiniAgregarEspecifico);
            this.tabObjetivoEspecificos.Controls.Add(this.dtgObjetivoEspecifico);
            this.tabObjetivoEspecificos.Location = new System.Drawing.Point(4, 22);
            this.tabObjetivoEspecificos.Name = "tabObjetivoEspecificos";
            this.tabObjetivoEspecificos.Padding = new System.Windows.Forms.Padding(3);
            this.tabObjetivoEspecificos.Size = new System.Drawing.Size(749, 250);
            this.tabObjetivoEspecificos.TabIndex = 1;
            this.tabObjetivoEspecificos.Text = "Objetivos Especificos";
            this.tabObjetivoEspecificos.UseVisualStyleBackColor = true;
            // 
            // btnMiniEditarEspecifico
            // 
            this.btnMiniEditarEspecifico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditarEspecifico.BackgroundImage")));
            this.btnMiniEditarEspecifico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditarEspecifico.Enabled = false;
            this.btnMiniEditarEspecifico.Location = new System.Drawing.Point(705, 33);
            this.btnMiniEditarEspecifico.Name = "btnMiniEditarEspecifico";
            this.btnMiniEditarEspecifico.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditarEspecifico.TabIndex = 1;
            this.btnMiniEditarEspecifico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditarEspecifico.UseVisualStyleBackColor = true;
            this.btnMiniEditarEspecifico.Click += new System.EventHandler(this.btnMiniEditarEspecifico_Click);
            // 
            // btnMiniQuitarEspecifico
            // 
            this.btnMiniQuitarEspecifico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarEspecifico.BackgroundImage")));
            this.btnMiniQuitarEspecifico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarEspecifico.Enabled = false;
            this.btnMiniQuitarEspecifico.Location = new System.Drawing.Point(705, 61);
            this.btnMiniQuitarEspecifico.Name = "btnMiniQuitarEspecifico";
            this.btnMiniQuitarEspecifico.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarEspecifico.TabIndex = 2;
            this.btnMiniQuitarEspecifico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarEspecifico.UseVisualStyleBackColor = true;
            this.btnMiniQuitarEspecifico.Click += new System.EventHandler(this.btnMiniQuitarEspecifico_Click);
            // 
            // btnMiniAgregarEspecifico
            // 
            this.btnMiniAgregarEspecifico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarEspecifico.BackgroundImage")));
            this.btnMiniAgregarEspecifico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarEspecifico.Enabled = false;
            this.btnMiniAgregarEspecifico.Location = new System.Drawing.Point(705, 5);
            this.btnMiniAgregarEspecifico.Name = "btnMiniAgregarEspecifico";
            this.btnMiniAgregarEspecifico.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarEspecifico.TabIndex = 0;
            this.btnMiniAgregarEspecifico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarEspecifico.UseVisualStyleBackColor = true;
            this.btnMiniAgregarEspecifico.Click += new System.EventHandler(this.btnMiniAgregarEspecifico_Click);
            // 
            // dtgObjetivoEspecifico
            // 
            this.dtgObjetivoEspecifico.AllowUserToAddRows = false;
            this.dtgObjetivoEspecifico.AllowUserToDeleteRows = false;
            this.dtgObjetivoEspecifico.AllowUserToResizeColumns = false;
            this.dtgObjetivoEspecifico.AllowUserToResizeRows = false;
            this.dtgObjetivoEspecifico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObjetivoEspecifico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObjetivoEspecifico.Enabled = false;
            this.dtgObjetivoEspecifico.Location = new System.Drawing.Point(5, 5);
            this.dtgObjetivoEspecifico.MultiSelect = false;
            this.dtgObjetivoEspecifico.Name = "dtgObjetivoEspecifico";
            this.dtgObjetivoEspecifico.ReadOnly = true;
            this.dtgObjetivoEspecifico.RowHeadersVisible = false;
            this.dtgObjetivoEspecifico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgObjetivoEspecifico.Size = new System.Drawing.Size(690, 235);
            this.dtgObjetivoEspecifico.TabIndex = 1;
            this.dtgObjetivoEspecifico.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgObjetivoEspecifico_CellDoubleClick);
            // 
            // tabDetalleAccion
            // 
            this.tabDetalleAccion.Controls.Add(this.btnMiniQuitarAccion);
            this.tabDetalleAccion.Controls.Add(this.btnMiniEditarAccion);
            this.tabDetalleAccion.Controls.Add(this.btnMiniAgregarAccion);
            this.tabDetalleAccion.Controls.Add(this.dtgDetalleAccion);
            this.tabDetalleAccion.Location = new System.Drawing.Point(4, 22);
            this.tabDetalleAccion.Name = "tabDetalleAccion";
            this.tabDetalleAccion.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetalleAccion.Size = new System.Drawing.Size(749, 250);
            this.tabDetalleAccion.TabIndex = 2;
            this.tabDetalleAccion.Text = "Detalle de Acciones";
            this.tabDetalleAccion.UseVisualStyleBackColor = true;
            // 
            // btnMiniQuitarAccion
            // 
            this.btnMiniQuitarAccion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarAccion.BackgroundImage")));
            this.btnMiniQuitarAccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarAccion.Enabled = false;
            this.btnMiniQuitarAccion.Location = new System.Drawing.Point(705, 61);
            this.btnMiniQuitarAccion.Name = "btnMiniQuitarAccion";
            this.btnMiniQuitarAccion.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarAccion.TabIndex = 2;
            this.btnMiniQuitarAccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarAccion.UseVisualStyleBackColor = true;
            this.btnMiniQuitarAccion.Click += new System.EventHandler(this.btnMiniQuitarAccion_Click);
            // 
            // btnMiniEditarAccion
            // 
            this.btnMiniEditarAccion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditarAccion.BackgroundImage")));
            this.btnMiniEditarAccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditarAccion.Enabled = false;
            this.btnMiniEditarAccion.Location = new System.Drawing.Point(705, 33);
            this.btnMiniEditarAccion.Name = "btnMiniEditarAccion";
            this.btnMiniEditarAccion.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditarAccion.TabIndex = 1;
            this.btnMiniEditarAccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditarAccion.UseVisualStyleBackColor = true;
            this.btnMiniEditarAccion.Click += new System.EventHandler(this.btnMiniEditarAccion_Click);
            // 
            // btnMiniAgregarAccion
            // 
            this.btnMiniAgregarAccion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarAccion.BackgroundImage")));
            this.btnMiniAgregarAccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarAccion.Enabled = false;
            this.btnMiniAgregarAccion.Location = new System.Drawing.Point(705, 5);
            this.btnMiniAgregarAccion.Name = "btnMiniAgregarAccion";
            this.btnMiniAgregarAccion.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarAccion.TabIndex = 0;
            this.btnMiniAgregarAccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarAccion.UseVisualStyleBackColor = true;
            this.btnMiniAgregarAccion.Click += new System.EventHandler(this.btnMiniAgregarAccion_Click);
            // 
            // dtgDetalleAccion
            // 
            this.dtgDetalleAccion.AllowUserToAddRows = false;
            this.dtgDetalleAccion.AllowUserToDeleteRows = false;
            this.dtgDetalleAccion.AllowUserToResizeColumns = false;
            this.dtgDetalleAccion.AllowUserToResizeRows = false;
            this.dtgDetalleAccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleAccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleAccion.Enabled = false;
            this.dtgDetalleAccion.Location = new System.Drawing.Point(5, 5);
            this.dtgDetalleAccion.MultiSelect = false;
            this.dtgDetalleAccion.Name = "dtgDetalleAccion";
            this.dtgDetalleAccion.ReadOnly = true;
            this.dtgDetalleAccion.RowHeadersVisible = false;
            this.dtgDetalleAccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleAccion.Size = new System.Drawing.Size(690, 235);
            this.dtgDetalleAccion.TabIndex = 0;
            this.dtgDetalleAccion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleAccion_CellDoubleClick);
            // 
            // tabZonaVisita
            // 
            this.tabZonaVisita.Controls.Add(this.dtgZonaVisita);
            this.tabZonaVisita.Controls.Add(this.btnMiniQuitarVisita);
            this.tabZonaVisita.Controls.Add(this.btnMiniEditarVisita);
            this.tabZonaVisita.Controls.Add(this.btnMiniAgregarVisita);
            this.tabZonaVisita.Location = new System.Drawing.Point(4, 22);
            this.tabZonaVisita.Name = "tabZonaVisita";
            this.tabZonaVisita.Padding = new System.Windows.Forms.Padding(3);
            this.tabZonaVisita.Size = new System.Drawing.Size(749, 250);
            this.tabZonaVisita.TabIndex = 3;
            this.tabZonaVisita.Text = "Zona a Visitar";
            this.tabZonaVisita.UseVisualStyleBackColor = true;
            // 
            // dtgZonaVisita
            // 
            this.dtgZonaVisita.AllowUserToAddRows = false;
            this.dtgZonaVisita.AllowUserToDeleteRows = false;
            this.dtgZonaVisita.AllowUserToResizeColumns = false;
            this.dtgZonaVisita.AllowUserToResizeRows = false;
            this.dtgZonaVisita.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgZonaVisita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgZonaVisita.Enabled = false;
            this.dtgZonaVisita.Location = new System.Drawing.Point(5, 5);
            this.dtgZonaVisita.MultiSelect = false;
            this.dtgZonaVisita.Name = "dtgZonaVisita";
            this.dtgZonaVisita.ReadOnly = true;
            this.dtgZonaVisita.RowHeadersVisible = false;
            this.dtgZonaVisita.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgZonaVisita.Size = new System.Drawing.Size(690, 235);
            this.dtgZonaVisita.TabIndex = 3;
            this.dtgZonaVisita.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgZonaVisita_CellDoubleClick);
            // 
            // btnMiniQuitarVisita
            // 
            this.btnMiniQuitarVisita.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarVisita.BackgroundImage")));
            this.btnMiniQuitarVisita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarVisita.Enabled = false;
            this.btnMiniQuitarVisita.Location = new System.Drawing.Point(705, 61);
            this.btnMiniQuitarVisita.Name = "btnMiniQuitarVisita";
            this.btnMiniQuitarVisita.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarVisita.TabIndex = 2;
            this.btnMiniQuitarVisita.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarVisita.UseVisualStyleBackColor = true;
            this.btnMiniQuitarVisita.Click += new System.EventHandler(this.btnMiniQuitarVisita_Click);
            // 
            // btnMiniEditarVisita
            // 
            this.btnMiniEditarVisita.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditarVisita.BackgroundImage")));
            this.btnMiniEditarVisita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditarVisita.Enabled = false;
            this.btnMiniEditarVisita.Location = new System.Drawing.Point(705, 33);
            this.btnMiniEditarVisita.Name = "btnMiniEditarVisita";
            this.btnMiniEditarVisita.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditarVisita.TabIndex = 1;
            this.btnMiniEditarVisita.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditarVisita.UseVisualStyleBackColor = true;
            this.btnMiniEditarVisita.Click += new System.EventHandler(this.btnMiniEditarVisita_Click);
            // 
            // btnMiniAgregarVisita
            // 
            this.btnMiniAgregarVisita.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarVisita.BackgroundImage")));
            this.btnMiniAgregarVisita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarVisita.Enabled = false;
            this.btnMiniAgregarVisita.Location = new System.Drawing.Point(705, 5);
            this.btnMiniAgregarVisita.Name = "btnMiniAgregarVisita";
            this.btnMiniAgregarVisita.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarVisita.TabIndex = 0;
            this.btnMiniAgregarVisita.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarVisita.UseVisualStyleBackColor = true;
            this.btnMiniAgregarVisita.Click += new System.EventHandler(this.btnMiniAgregarVisita_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbcDatosPlanTrabajo);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 300);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plan de Trabajo";
            // 
            // conBusColaborador
            // 
            this.conBusColaborador.cEstado = "0";
            this.conBusColaborador.Enabled = false;
            this.conBusColaborador.Location = new System.Drawing.Point(20, 12);
            this.conBusColaborador.Name = "conBusColaborador";
            this.conBusColaborador.Size = new System.Drawing.Size(390, 86);
            this.conBusColaborador.TabIndex = 0;
            this.conBusColaborador.BuscarUsuario += new System.EventHandler(this.conBusColaborador_BuscarUsuario);
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.Enabled = false;
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(169, 11);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoSolicitud.TabIndex = 8;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(5, 15);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(164, 13);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Estado del Plan de Trabajo:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(169, 34);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaInicio.TabIndex = 10;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(169, 56);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaFin.TabIndex = 11;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 38);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 60);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // grbDatosPlanTrabajo
            // 
            this.grbDatosPlanTrabajo.Controls.Add(this.lblFechaResolucion);
            this.grbDatosPlanTrabajo.Controls.Add(this.dtpFechaResolucion);
            this.grbDatosPlanTrabajo.Controls.Add(this.lblEstado);
            this.grbDatosPlanTrabajo.Controls.Add(this.lblBase2);
            this.grbDatosPlanTrabajo.Controls.Add(this.cboEstadoSolicitud);
            this.grbDatosPlanTrabajo.Controls.Add(this.lblBase1);
            this.grbDatosPlanTrabajo.Controls.Add(this.dtpFechaInicio);
            this.grbDatosPlanTrabajo.Controls.Add(this.dtpFechaFin);
            this.grbDatosPlanTrabajo.Location = new System.Drawing.Point(479, 12);
            this.grbDatosPlanTrabajo.Name = "grbDatosPlanTrabajo";
            this.grbDatosPlanTrabajo.Size = new System.Drawing.Size(297, 112);
            this.grbDatosPlanTrabajo.TabIndex = 14;
            this.grbDatosPlanTrabajo.TabStop = false;
            this.grbDatosPlanTrabajo.Text = "Datos del Plan de Trabajo";
            // 
            // lblFechaResolucion
            // 
            this.lblFechaResolucion.AutoSize = true;
            this.lblFechaResolucion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaResolucion.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaResolucion.Location = new System.Drawing.Point(5, 82);
            this.lblFechaResolucion.Name = "lblFechaResolucion";
            this.lblFechaResolucion.Size = new System.Drawing.Size(128, 13);
            this.lblFechaResolucion.TabIndex = 15;
            this.lblFechaResolucion.Text = "Fecha de Resolución:";
            // 
            // dtpFechaResolucion
            // 
            this.dtpFechaResolucion.Enabled = false;
            this.dtpFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaResolucion.Location = new System.Drawing.Point(169, 78);
            this.dtpFechaResolucion.Name = "dtpFechaResolucion";
            this.dtpFechaResolucion.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaResolucion.TabIndex = 14;
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Enabled = false;
            this.btnAprobar.Location = new System.Drawing.Point(67, 436);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 8;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnListarSolicitud
            // 
            this.btnListarSolicitud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListarSolicitud.BackgroundImage")));
            this.btnListarSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListarSolicitud.Enabled = false;
            this.btnListarSolicitud.Location = new System.Drawing.Point(418, 23);
            this.btnListarSolicitud.Name = "btnListarSolicitud";
            this.btnListarSolicitud.Size = new System.Drawing.Size(60, 50);
            this.btnListarSolicitud.TabIndex = 1;
            this.btnListarSolicitud.Text = "Lista Sol.";
            this.btnListarSolicitud.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListarSolicitud.UseVisualStyleBackColor = true;
            this.btnListarSolicitud.Click += new System.EventHandler(this.btnListarSolicitud_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(396, 431);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazar.BackgroundImage")));
            this.btnRechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar.Location = new System.Drawing.Point(127, 436);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar.TabIndex = 15;
            this.btnRechazar.Text = "&Rechaza";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(456, 431);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmRegistrarPlanTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnListarSolicitud);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.grbDatosPlanTrabajo);
            this.Controls.Add(this.conBusColaborador);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRegistrarPlanTrabajo";
            this.Text = "Registro de Plan de Trabajo:";
            this.Load += new System.EventHandler(this.frmRegistrarPlanTrabajo_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.conBusColaborador, 0);
            this.Controls.SetChildIndex(this.grbDatosPlanTrabajo, 0);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.btnListarSolicitud, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnRechazar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.tbcDatosPlanTrabajo.ResumeLayout(false);
            this.tabObjetivosGenerales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObjetivoGeneral)).EndInit();
            this.tabObjetivoEspecificos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObjetivoEspecifico)).EndInit();
            this.tabDetalleAccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAccion)).EndInit();
            this.tabZonaVisita.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgZonaVisita)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grbDatosPlanTrabajo.ResumeLayout(false);
            this.grbDatosPlanTrabajo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.tbcBase tbcDatosPlanTrabajo;
        private System.Windows.Forms.TabPage tabObjetivosGenerales;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarGeneral;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarGeneral;
        private GEN.ControlesBase.dtgBase dtgObjetivoGeneral;
        private System.Windows.Forms.TabPage tabObjetivoEspecificos;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarEspecifico;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarEspecifico;
        private GEN.ControlesBase.dtgBase dtgObjetivoEspecifico;
        private System.Windows.Forms.TabPage tabDetalleAccion;
        private System.Windows.Forms.TabPage tabZonaVisita;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.ConBusCol conBusColaborador;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditarGeneral;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditarEspecifico;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarAccion;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditarAccion;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarAccion;
        private GEN.ControlesBase.dtgBase dtgDetalleAccion;
        private GEN.ControlesBase.dtgBase dtgZonaVisita;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarVisita;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditarVisita;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarVisita;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolicitud;
        private GEN.ControlesBase.lblBase lblEstado;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.GroupBox grbDatosPlanTrabajo;
        private GEN.ControlesBase.lblBase lblFechaResolucion;
        private GEN.ControlesBase.dtpCorto dtpFechaResolucion;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.BotonesBase.Boton btnListarSolicitud;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnRechazar btnRechazar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
    }
}