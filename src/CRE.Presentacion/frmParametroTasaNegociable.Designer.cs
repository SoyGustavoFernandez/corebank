namespace CRE.Presentacion
{
    partial class frmParametroTasaNegociable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametroTasaNegociable));
            this.dtgAprobacion = new GEN.ControlesBase.dtgBase(this.components);
            this.cboTipoTasaAprobacion = new GEN.ControlesBase.cboBase(this.components);
            this.lblTipoTasa = new GEN.ControlesBase.lblBase();
            this.btnGrabarAprobacion = new GEN.BotonesBase.btnGrabar();
            this.btnCancelarAprobacion = new GEN.BotonesBase.btnCancelar();
            this.btnSalirAprobacion = new GEN.BotonesBase.btnSalir();
            this.btnEditarAprobacion = new GEN.BotonesBase.btnEditar();
            this.btnNuevoAprobacion = new GEN.BotonesBase.btnNuevo();
            this.tbcParametrosTasaNegociable = new GEN.ControlesBase.tbcBase(this.components);
            this.tabAprobacion = new System.Windows.Forms.TabPage();
            this.tabVistoBueno = new System.Windows.Forms.TabPage();
            this.grbListaAprobacionTasaNegociable = new GEN.ControlesBase.grbBase(this.components);
            this.grbAprobacionTasaNegociable = new GEN.ControlesBase.grbBase(this.components);
            this.lblPerfil = new GEN.ControlesBase.lblBase();
            this.btnSalirVistoBueno = new GEN.BotonesBase.btnSalir();
            this.grbVistoBuenoTasaNegociable = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoTasaVistoBueno = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnNuevoVistoBueno = new GEN.BotonesBase.btnNuevo();
            this.btnCancelarVistoBueno = new GEN.BotonesBase.btnCancelar();
            this.btnEditarVistoBueno = new GEN.BotonesBase.btnEditar();
            this.btnGrabarVistoBueno = new GEN.BotonesBase.btnGrabar();
            this.grbListaVistoBuenoTasaNegociable = new GEN.ControlesBase.grbBase(this.components);
            this.dtgVistoBueno = new GEN.ControlesBase.dtgBase(this.components);
            this.nudMaxVistoBueno = new GEN.ControlesBase.nudBase(this.components);
            this.cboListaPerfil = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblVigente = new GEN.ControlesBase.lblBase();
            this.chcVigenteAprobacion = new GEN.ControlesBase.chcBase(this.components);
            this.chcVigenteVistoBueno = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobacion)).BeginInit();
            this.tbcParametrosTasaNegociable.SuspendLayout();
            this.tabAprobacion.SuspendLayout();
            this.tabVistoBueno.SuspendLayout();
            this.grbListaAprobacionTasaNegociable.SuspendLayout();
            this.grbAprobacionTasaNegociable.SuspendLayout();
            this.grbVistoBuenoTasaNegociable.SuspendLayout();
            this.grbListaVistoBuenoTasaNegociable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVistoBueno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVistoBueno)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAprobacion
            // 
            this.dtgAprobacion.AllowUserToAddRows = false;
            this.dtgAprobacion.AllowUserToDeleteRows = false;
            this.dtgAprobacion.AllowUserToResizeColumns = false;
            this.dtgAprobacion.AllowUserToResizeRows = false;
            this.dtgAprobacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAprobacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAprobacion.Location = new System.Drawing.Point(6, 19);
            this.dtgAprobacion.MultiSelect = false;
            this.dtgAprobacion.Name = "dtgAprobacion";
            this.dtgAprobacion.ReadOnly = true;
            this.dtgAprobacion.RowHeadersVisible = false;
            this.dtgAprobacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAprobacion.Size = new System.Drawing.Size(568, 144);
            this.dtgAprobacion.TabIndex = 0;
            this.dtgAprobacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAprobacion_CellClick);
            // 
            // cboTipoTasaAprobacion
            // 
            this.cboTipoTasaAprobacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaAprobacion.FormattingEnabled = true;
            this.cboTipoTasaAprobacion.Location = new System.Drawing.Point(198, 14);
            this.cboTipoTasaAprobacion.Name = "cboTipoTasaAprobacion";
            this.cboTipoTasaAprobacion.Size = new System.Drawing.Size(250, 21);
            this.cboTipoTasaAprobacion.TabIndex = 2;
            // 
            // lblTipoTasa
            // 
            this.lblTipoTasa.AutoSize = true;
            this.lblTipoTasa.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoTasa.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoTasa.Location = new System.Drawing.Point(132, 18);
            this.lblTipoTasa.Name = "lblTipoTasa";
            this.lblTipoTasa.Size = new System.Drawing.Size(66, 13);
            this.lblTipoTasa.TabIndex = 3;
            this.lblTipoTasa.Text = "Tipo Tasa:";
            // 
            // btnGrabarAprobacion
            // 
            this.btnGrabarAprobacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarAprobacion.BackgroundImage")));
            this.btnGrabarAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarAprobacion.Location = new System.Drawing.Point(340, 267);
            this.btnGrabarAprobacion.Name = "btnGrabarAprobacion";
            this.btnGrabarAprobacion.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarAprobacion.TabIndex = 4;
            this.btnGrabarAprobacion.Text = "&Grabar";
            this.btnGrabarAprobacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarAprobacion.UseVisualStyleBackColor = true;
            this.btnGrabarAprobacion.Click += new System.EventHandler(this.btnGrabarAprobacion_Click);
            // 
            // btnCancelarAprobacion
            // 
            this.btnCancelarAprobacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarAprobacion.BackgroundImage")));
            this.btnCancelarAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarAprobacion.Location = new System.Drawing.Point(464, 267);
            this.btnCancelarAprobacion.Name = "btnCancelarAprobacion";
            this.btnCancelarAprobacion.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarAprobacion.TabIndex = 5;
            this.btnCancelarAprobacion.Text = "&Cancelar";
            this.btnCancelarAprobacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarAprobacion.UseVisualStyleBackColor = true;
            this.btnCancelarAprobacion.Click += new System.EventHandler(this.btnCancelarAprobacion_Click);
            // 
            // btnSalirAprobacion
            // 
            this.btnSalirAprobacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirAprobacion.BackgroundImage")));
            this.btnSalirAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirAprobacion.Location = new System.Drawing.Point(526, 267);
            this.btnSalirAprobacion.Name = "btnSalirAprobacion";
            this.btnSalirAprobacion.Size = new System.Drawing.Size(60, 50);
            this.btnSalirAprobacion.TabIndex = 3;
            this.btnSalirAprobacion.Text = "&Salir";
            this.btnSalirAprobacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirAprobacion.UseVisualStyleBackColor = true;
            this.btnSalirAprobacion.Click += new System.EventHandler(this.btnSalirAprobacion_Click);
            // 
            // btnEditarAprobacion
            // 
            this.btnEditarAprobacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarAprobacion.BackgroundImage")));
            this.btnEditarAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarAprobacion.Location = new System.Drawing.Point(402, 267);
            this.btnEditarAprobacion.Name = "btnEditarAprobacion";
            this.btnEditarAprobacion.Size = new System.Drawing.Size(60, 50);
            this.btnEditarAprobacion.TabIndex = 6;
            this.btnEditarAprobacion.Text = "&Editar";
            this.btnEditarAprobacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarAprobacion.UseVisualStyleBackColor = true;
            this.btnEditarAprobacion.Click += new System.EventHandler(this.btnEditarAprobacion_Click);
            // 
            // btnNuevoAprobacion
            // 
            this.btnNuevoAprobacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoAprobacion.BackgroundImage")));
            this.btnNuevoAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoAprobacion.Location = new System.Drawing.Point(278, 267);
            this.btnNuevoAprobacion.Name = "btnNuevoAprobacion";
            this.btnNuevoAprobacion.Size = new System.Drawing.Size(60, 50);
            this.btnNuevoAprobacion.TabIndex = 7;
            this.btnNuevoAprobacion.Text = "&Nuevo";
            this.btnNuevoAprobacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoAprobacion.UseVisualStyleBackColor = true;
            this.btnNuevoAprobacion.Click += new System.EventHandler(this.btnNuevoAprobacion_Click);
            // 
            // tbcParametrosTasaNegociable
            // 
            this.tbcParametrosTasaNegociable.Controls.Add(this.tabAprobacion);
            this.tbcParametrosTasaNegociable.Controls.Add(this.tabVistoBueno);
            this.tbcParametrosTasaNegociable.Location = new System.Drawing.Point(5, 5);
            this.tbcParametrosTasaNegociable.Name = "tbcParametrosTasaNegociable";
            this.tbcParametrosTasaNegociable.SelectedIndex = 0;
            this.tbcParametrosTasaNegociable.Size = new System.Drawing.Size(600, 352);
            this.tbcParametrosTasaNegociable.TabIndex = 4;
            this.tbcParametrosTasaNegociable.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbcParametrosTasaNegociable_Selected);
            // 
            // tabAprobacion
            // 
            this.tabAprobacion.Controls.Add(this.grbListaAprobacionTasaNegociable);
            this.tabAprobacion.Controls.Add(this.btnSalirAprobacion);
            this.tabAprobacion.Controls.Add(this.grbAprobacionTasaNegociable);
            this.tabAprobacion.Controls.Add(this.btnNuevoAprobacion);
            this.tabAprobacion.Controls.Add(this.btnCancelarAprobacion);
            this.tabAprobacion.Controls.Add(this.btnEditarAprobacion);
            this.tabAprobacion.Controls.Add(this.btnGrabarAprobacion);
            this.tabAprobacion.Location = new System.Drawing.Point(4, 22);
            this.tabAprobacion.Name = "tabAprobacion";
            this.tabAprobacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabAprobacion.Size = new System.Drawing.Size(592, 326);
            this.tabAprobacion.TabIndex = 0;
            this.tabAprobacion.Text = "Aprobación Tasa Negociable";
            this.tabAprobacion.UseVisualStyleBackColor = true;
            // 
            // tabVistoBueno
            // 
            this.tabVistoBueno.Controls.Add(this.grbListaVistoBuenoTasaNegociable);
            this.tabVistoBueno.Controls.Add(this.btnSalirVistoBueno);
            this.tabVistoBueno.Controls.Add(this.grbVistoBuenoTasaNegociable);
            this.tabVistoBueno.Controls.Add(this.btnNuevoVistoBueno);
            this.tabVistoBueno.Controls.Add(this.btnCancelarVistoBueno);
            this.tabVistoBueno.Controls.Add(this.btnEditarVistoBueno);
            this.tabVistoBueno.Controls.Add(this.btnGrabarVistoBueno);
            this.tabVistoBueno.Location = new System.Drawing.Point(4, 22);
            this.tabVistoBueno.Name = "tabVistoBueno";
            this.tabVistoBueno.Padding = new System.Windows.Forms.Padding(3);
            this.tabVistoBueno.Size = new System.Drawing.Size(592, 326);
            this.tabVistoBueno.TabIndex = 1;
            this.tabVistoBueno.Text = "Visto Bueno Tasa Negociable";
            this.tabVistoBueno.UseVisualStyleBackColor = true;
            // 
            // grbListaAprobacionTasaNegociable
            // 
            this.grbListaAprobacionTasaNegociable.Controls.Add(this.dtgAprobacion);
            this.grbListaAprobacionTasaNegociable.Location = new System.Drawing.Point(6, 97);
            this.grbListaAprobacionTasaNegociable.Name = "grbListaAprobacionTasaNegociable";
            this.grbListaAprobacionTasaNegociable.Size = new System.Drawing.Size(580, 169);
            this.grbListaAprobacionTasaNegociable.TabIndex = 5;
            this.grbListaAprobacionTasaNegociable.TabStop = false;
            this.grbListaAprobacionTasaNegociable.Text = "Aprobación de Tasa Negociables";
            // 
            // grbAprobacionTasaNegociable
            // 
            this.grbAprobacionTasaNegociable.Controls.Add(this.chcVigenteAprobacion);
            this.grbAprobacionTasaNegociable.Controls.Add(this.lblVigente);
            this.grbAprobacionTasaNegociable.Controls.Add(this.cboListaPerfil);
            this.grbAprobacionTasaNegociable.Controls.Add(this.lblPerfil);
            this.grbAprobacionTasaNegociable.Controls.Add(this.lblTipoTasa);
            this.grbAprobacionTasaNegociable.Controls.Add(this.cboTipoTasaAprobacion);
            this.grbAprobacionTasaNegociable.Location = new System.Drawing.Point(6, 6);
            this.grbAprobacionTasaNegociable.Name = "grbAprobacionTasaNegociable";
            this.grbAprobacionTasaNegociable.Size = new System.Drawing.Size(580, 90);
            this.grbAprobacionTasaNegociable.TabIndex = 8;
            this.grbAprobacionTasaNegociable.TabStop = false;
            this.grbAprobacionTasaNegociable.Text = "Aprobación Tasa Negociable";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPerfil.ForeColor = System.Drawing.Color.Navy;
            this.lblPerfil.Location = new System.Drawing.Point(132, 43);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(41, 13);
            this.lblPerfil.TabIndex = 4;
            this.lblPerfil.Text = "Perfil:";
            // 
            // btnSalirVistoBueno
            // 
            this.btnSalirVistoBueno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalirVistoBueno.BackgroundImage")));
            this.btnSalirVistoBueno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalirVistoBueno.Location = new System.Drawing.Point(526, 269);
            this.btnSalirVistoBueno.Name = "btnSalirVistoBueno";
            this.btnSalirVistoBueno.Size = new System.Drawing.Size(60, 50);
            this.btnSalirVistoBueno.TabIndex = 9;
            this.btnSalirVistoBueno.Text = "&Salir";
            this.btnSalirVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirVistoBueno.UseVisualStyleBackColor = true;
            this.btnSalirVistoBueno.Click += new System.EventHandler(this.btnSalirVistoBueno_Click);
            // 
            // grbVistoBuenoTasaNegociable
            // 
            this.grbVistoBuenoTasaNegociable.Controls.Add(this.chcVigenteVistoBueno);
            this.grbVistoBuenoTasaNegociable.Controls.Add(this.lblBase3);
            this.grbVistoBuenoTasaNegociable.Controls.Add(this.nudMaxVistoBueno);
            this.grbVistoBuenoTasaNegociable.Controls.Add(this.lblBase1);
            this.grbVistoBuenoTasaNegociable.Controls.Add(this.cboTipoTasaVistoBueno);
            this.grbVistoBuenoTasaNegociable.Controls.Add(this.lblBase2);
            this.grbVistoBuenoTasaNegociable.Location = new System.Drawing.Point(6, 8);
            this.grbVistoBuenoTasaNegociable.Name = "grbVistoBuenoTasaNegociable";
            this.grbVistoBuenoTasaNegociable.Size = new System.Drawing.Size(580, 85);
            this.grbVistoBuenoTasaNegociable.TabIndex = 14;
            this.grbVistoBuenoTasaNegociable.TabStop = false;
            this.grbVistoBuenoTasaNegociable.Text = "Vistos Buenos Tasa Negociable";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(74, 41);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(183, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Nro. de Niveles Vistos Buenos:";
            // 
            // cboTipoTasaVistoBueno
            // 
            this.cboTipoTasaVistoBueno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaVistoBueno.FormattingEnabled = true;
            this.cboTipoTasaVistoBueno.Location = new System.Drawing.Point(257, 14);
            this.cboTipoTasaVistoBueno.Name = "cboTipoTasaVistoBueno";
            this.cboTipoTasaVistoBueno.Size = new System.Drawing.Size(250, 21);
            this.cboTipoTasaVistoBueno.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(74, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Tipo Tasa:";
            // 
            // btnNuevoVistoBueno
            // 
            this.btnNuevoVistoBueno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoVistoBueno.BackgroundImage")));
            this.btnNuevoVistoBueno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoVistoBueno.Location = new System.Drawing.Point(278, 269);
            this.btnNuevoVistoBueno.Name = "btnNuevoVistoBueno";
            this.btnNuevoVistoBueno.Size = new System.Drawing.Size(60, 50);
            this.btnNuevoVistoBueno.TabIndex = 13;
            this.btnNuevoVistoBueno.Text = "&Nuevo";
            this.btnNuevoVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoVistoBueno.UseVisualStyleBackColor = true;
            this.btnNuevoVistoBueno.Click += new System.EventHandler(this.btnNuevoVistoBueno_Click);
            // 
            // btnCancelarVistoBueno
            // 
            this.btnCancelarVistoBueno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarVistoBueno.BackgroundImage")));
            this.btnCancelarVistoBueno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarVistoBueno.Location = new System.Drawing.Point(464, 269);
            this.btnCancelarVistoBueno.Name = "btnCancelarVistoBueno";
            this.btnCancelarVistoBueno.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarVistoBueno.TabIndex = 11;
            this.btnCancelarVistoBueno.Text = "&Cancelar";
            this.btnCancelarVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarVistoBueno.UseVisualStyleBackColor = true;
            this.btnCancelarVistoBueno.Click += new System.EventHandler(this.btnCancelarVistoBueno_Click);
            // 
            // btnEditarVistoBueno
            // 
            this.btnEditarVistoBueno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarVistoBueno.BackgroundImage")));
            this.btnEditarVistoBueno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarVistoBueno.Location = new System.Drawing.Point(402, 269);
            this.btnEditarVistoBueno.Name = "btnEditarVistoBueno";
            this.btnEditarVistoBueno.Size = new System.Drawing.Size(60, 50);
            this.btnEditarVistoBueno.TabIndex = 12;
            this.btnEditarVistoBueno.Text = "&Editar";
            this.btnEditarVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarVistoBueno.UseVisualStyleBackColor = true;
            this.btnEditarVistoBueno.Click += new System.EventHandler(this.btnEditarVistoBueno_Click);
            // 
            // btnGrabarVistoBueno
            // 
            this.btnGrabarVistoBueno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarVistoBueno.BackgroundImage")));
            this.btnGrabarVistoBueno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarVistoBueno.Location = new System.Drawing.Point(340, 269);
            this.btnGrabarVistoBueno.Name = "btnGrabarVistoBueno";
            this.btnGrabarVistoBueno.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarVistoBueno.TabIndex = 10;
            this.btnGrabarVistoBueno.Text = "&Grabar";
            this.btnGrabarVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarVistoBueno.UseVisualStyleBackColor = true;
            this.btnGrabarVistoBueno.Click += new System.EventHandler(this.btnGrabarVistoBueno_Click);
            // 
            // grbListaVistoBuenoTasaNegociable
            // 
            this.grbListaVistoBuenoTasaNegociable.Controls.Add(this.dtgVistoBueno);
            this.grbListaVistoBuenoTasaNegociable.Location = new System.Drawing.Point(6, 94);
            this.grbListaVistoBuenoTasaNegociable.Name = "grbListaVistoBuenoTasaNegociable";
            this.grbListaVistoBuenoTasaNegociable.Size = new System.Drawing.Size(580, 169);
            this.grbListaVistoBuenoTasaNegociable.TabIndex = 15;
            this.grbListaVistoBuenoTasaNegociable.TabStop = false;
            this.grbListaVistoBuenoTasaNegociable.Text = "Visto Bueno de Tasa Negociables";
            // 
            // dtgVistoBueno
            // 
            this.dtgVistoBueno.AllowUserToAddRows = false;
            this.dtgVistoBueno.AllowUserToDeleteRows = false;
            this.dtgVistoBueno.AllowUserToResizeColumns = false;
            this.dtgVistoBueno.AllowUserToResizeRows = false;
            this.dtgVistoBueno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVistoBueno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVistoBueno.Location = new System.Drawing.Point(6, 19);
            this.dtgVistoBueno.MultiSelect = false;
            this.dtgVistoBueno.Name = "dtgVistoBueno";
            this.dtgVistoBueno.ReadOnly = true;
            this.dtgVistoBueno.RowHeadersVisible = false;
            this.dtgVistoBueno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVistoBueno.Size = new System.Drawing.Size(568, 144);
            this.dtgVistoBueno.TabIndex = 0;
            this.dtgVistoBueno.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVistoBueno_CellClick);
            // 
            // nudMaxVistoBueno
            // 
            this.nudMaxVistoBueno.Location = new System.Drawing.Point(257, 37);
            this.nudMaxVistoBueno.Name = "nudMaxVistoBueno";
            this.nudMaxVistoBueno.Size = new System.Drawing.Size(250, 20);
            this.nudMaxVistoBueno.TabIndex = 5;
            this.nudMaxVistoBueno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboListaPerfil
            // 
            this.cboListaPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil.FormattingEnabled = true;
            this.cboListaPerfil.Location = new System.Drawing.Point(198, 39);
            this.cboListaPerfil.Name = "cboListaPerfil";
            this.cboListaPerfil.Size = new System.Drawing.Size(250, 21);
            this.cboListaPerfil.TabIndex = 5;
            // 
            // lblVigente
            // 
            this.lblVigente.AutoSize = true;
            this.lblVigente.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblVigente.ForeColor = System.Drawing.Color.Navy;
            this.lblVigente.Location = new System.Drawing.Point(132, 67);
            this.lblVigente.Name = "lblVigente";
            this.lblVigente.Size = new System.Drawing.Size(55, 13);
            this.lblVigente.TabIndex = 6;
            this.lblVigente.Text = "Vigente:";
            // 
            // chcVigenteAprobacion
            // 
            this.chcVigenteAprobacion.AutoSize = true;
            this.chcVigenteAprobacion.Location = new System.Drawing.Point(198, 66);
            this.chcVigenteAprobacion.Name = "chcVigenteAprobacion";
            this.chcVigenteAprobacion.Size = new System.Drawing.Size(15, 14);
            this.chcVigenteAprobacion.TabIndex = 7;
            this.chcVigenteAprobacion.UseVisualStyleBackColor = true;
            // 
            // chcVigenteVistoBueno
            // 
            this.chcVigenteVistoBueno.AutoSize = true;
            this.chcVigenteVistoBueno.Location = new System.Drawing.Point(257, 63);
            this.chcVigenteVistoBueno.Name = "chcVigenteVistoBueno";
            this.chcVigenteVistoBueno.Size = new System.Drawing.Size(15, 14);
            this.chcVigenteVistoBueno.TabIndex = 9;
            this.chcVigenteVistoBueno.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(74, 64);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Vigente:";
            // 
            // frmParametroTasaNegociable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 378);
            this.Controls.Add(this.tbcParametrosTasaNegociable);
            this.Name = "frmParametroTasaNegociable";
            this.Text = "Configuración de Flujo de Tasas Negociables";
            this.Load += new System.EventHandler(this.frmParametroTasaNegociable_Load);
            this.Controls.SetChildIndex(this.tbcParametrosTasaNegociable, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobacion)).EndInit();
            this.tbcParametrosTasaNegociable.ResumeLayout(false);
            this.tabAprobacion.ResumeLayout(false);
            this.tabVistoBueno.ResumeLayout(false);
            this.grbListaAprobacionTasaNegociable.ResumeLayout(false);
            this.grbAprobacionTasaNegociable.ResumeLayout(false);
            this.grbAprobacionTasaNegociable.PerformLayout();
            this.grbVistoBuenoTasaNegociable.ResumeLayout(false);
            this.grbVistoBuenoTasaNegociable.PerformLayout();
            this.grbListaVistoBuenoTasaNegociable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVistoBueno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVistoBueno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgAprobacion;
        private GEN.ControlesBase.cboBase cboTipoTasaAprobacion;
        private GEN.ControlesBase.lblBase lblTipoTasa;
        private GEN.BotonesBase.btnGrabar btnGrabarAprobacion;
        private GEN.BotonesBase.btnCancelar btnCancelarAprobacion;
        private GEN.BotonesBase.btnSalir btnSalirAprobacion;
        private GEN.BotonesBase.btnEditar btnEditarAprobacion;
        private GEN.BotonesBase.btnNuevo btnNuevoAprobacion;
        private GEN.ControlesBase.tbcBase tbcParametrosTasaNegociable;
        private System.Windows.Forms.TabPage tabAprobacion;
        private GEN.ControlesBase.grbBase grbListaAprobacionTasaNegociable;
        private GEN.ControlesBase.grbBase grbAprobacionTasaNegociable;
        private GEN.ControlesBase.lblBase lblPerfil;
        private System.Windows.Forms.TabPage tabVistoBueno;
        private GEN.ControlesBase.grbBase grbListaVistoBuenoTasaNegociable;
        private GEN.ControlesBase.dtgBase dtgVistoBueno;
        private GEN.BotonesBase.btnSalir btnSalirVistoBueno;
        private GEN.ControlesBase.grbBase grbVistoBuenoTasaNegociable;
        private GEN.ControlesBase.nudBase nudMaxVistoBueno;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipoTasaVistoBueno;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnNuevo btnNuevoVistoBueno;
        private GEN.BotonesBase.btnCancelar btnCancelarVistoBueno;
        private GEN.BotonesBase.btnEditar btnEditarVistoBueno;
        private GEN.BotonesBase.btnGrabar btnGrabarVistoBueno;
        private GEN.ControlesBase.cboListaPerfil cboListaPerfil;
        private GEN.ControlesBase.chcBase chcVigenteAprobacion;
        private GEN.ControlesBase.lblBase lblVigente;
        private GEN.ControlesBase.chcBase chcVigenteVistoBueno;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}