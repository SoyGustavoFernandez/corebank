namespace GEN.ControlesBase
{
    partial class frmBuscarReglaNegocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarReglaNegocio));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgReglaNegocio = new System.Windows.Forms.DataGridView();
            this.bsReglaNegocio = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboMetodoBusqueda = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblNroRegla = new GEN.ControlesBase.lblBase();
            this.txtIdRegla = new GEN.ControlesBase.txtNumerico(this.components);
            this.nIdReglaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIdOpcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCaracteristicaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReglaNegocioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMensajeErrorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lIndExcepcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCampoExcepcionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lNoExcepcionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cGrupoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nIdReglaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAcronimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMensajeErrorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReglaNegocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReglaNegocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 355);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Location = new System.Drawing.Point(3, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 55);
            this.panel3.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(552, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(486, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgReglaNegocio);
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 222);
            this.panel2.TabIndex = 1;
            // 
            // dtgReglaNegocio
            // 
            this.dtgReglaNegocio.AllowUserToAddRows = false;
            this.dtgReglaNegocio.AllowUserToDeleteRows = false;
            this.dtgReglaNegocio.AllowUserToResizeRows = false;
            this.dtgReglaNegocio.AutoGenerateColumns = false;
            this.dtgReglaNegocio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgReglaNegocio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgReglaNegocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReglaNegocio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nIdReglaDataGridViewTextBoxColumn,
            this.cAcronimo,
            this.cMensajeErrorDataGridViewTextBoxColumn,
            this.cGrupoDataGridViewTextBoxColumn});
            this.dtgReglaNegocio.DataSource = this.bsReglaNegocio;
            this.dtgReglaNegocio.Location = new System.Drawing.Point(3, 3);
            this.dtgReglaNegocio.MultiSelect = false;
            this.dtgReglaNegocio.Name = "dtgReglaNegocio";
            this.dtgReglaNegocio.ReadOnly = true;
            this.dtgReglaNegocio.RowHeadersVisible = false;
            this.dtgReglaNegocio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReglaNegocio.Size = new System.Drawing.Size(609, 216);
            this.dtgReglaNegocio.TabIndex = 0;
            this.dtgReglaNegocio.SelectionChanged += new System.EventHandler(this.dtgReglaNegocio_SelectionChanged);
            // 
            // bsReglaNegocio
            // 
            this.bsReglaNegocio.DataSource = typeof(EntityLayer.clsReglaNegocio);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboMetodoBusqueda);
            this.splitContainer1.Panel1.Controls.Add(this.lblBase2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnBusqueda);
            this.splitContainer1.Panel2.Controls.Add(this.lblNroRegla);
            this.splitContainer1.Panel2.Controls.Add(this.txtIdRegla);
            this.splitContainer1.Size = new System.Drawing.Size(616, 60);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.TabIndex = 3;
            // 
            // cboMetodoBusqueda
            // 
            this.cboMetodoBusqueda.FormattingEnabled = true;
            this.cboMetodoBusqueda.Items.AddRange(new object[] {
            "--Seleccione--",
            "Reglas del Formulario",
            "Reglas Manuales",
            "Todas las Reglas",
            "Reglas del Formulario y Manuales"});
            this.cboMetodoBusqueda.Location = new System.Drawing.Point(13, 22);
            this.cboMetodoBusqueda.Name = "cboMetodoBusqueda";
            this.cboMetodoBusqueda.Size = new System.Drawing.Size(214, 21);
            this.cboMetodoBusqueda.TabIndex = 1;
            this.cboMetodoBusqueda.SelectionChangeCommitted += new System.EventHandler(this.cboMetodoBusqueda_SelectionChangeCommitted);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 7);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(131, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Metodo de Busqueda:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(137, 5);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblNroRegla
            // 
            this.lblNroRegla.AutoSize = true;
            this.lblNroRegla.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroRegla.ForeColor = System.Drawing.Color.Navy;
            this.lblNroRegla.Location = new System.Drawing.Point(9, 5);
            this.lblNroRegla.Name = "lblNroRegla";
            this.lblNroRegla.Size = new System.Drawing.Size(68, 13);
            this.lblNroRegla.TabIndex = 1;
            this.lblNroRegla.Text = "Nro Regla:";
            // 
            // txtIdRegla
            // 
            this.txtIdRegla.Format = "n2";
            this.txtIdRegla.Location = new System.Drawing.Point(12, 23);
            this.txtIdRegla.MaxLength = 6;
            this.txtIdRegla.Name = "txtIdRegla";
            this.txtIdRegla.Size = new System.Drawing.Size(119, 20);
            this.txtIdRegla.TabIndex = 0;
            this.txtIdRegla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdRegla_KeyPress);
            // 
            // nIdReglaDataGridViewTextBoxColumn1
            // 
            this.nIdReglaDataGridViewTextBoxColumn1.DataPropertyName = "nIdRegla";
            this.nIdReglaDataGridViewTextBoxColumn1.HeaderText = "nIdRegla";
            this.nIdReglaDataGridViewTextBoxColumn1.Name = "nIdReglaDataGridViewTextBoxColumn1";
            this.nIdReglaDataGridViewTextBoxColumn1.Width = 75;
            // 
            // nIdOpcionDataGridViewTextBoxColumn
            // 
            this.nIdOpcionDataGridViewTextBoxColumn.DataPropertyName = "nIdOpcion";
            this.nIdOpcionDataGridViewTextBoxColumn.HeaderText = "nIdOpcion";
            this.nIdOpcionDataGridViewTextBoxColumn.Name = "nIdOpcionDataGridViewTextBoxColumn";
            this.nIdOpcionDataGridViewTextBoxColumn.Width = 81;
            // 
            // cCaracteristicaDataGridViewTextBoxColumn1
            // 
            this.cCaracteristicaDataGridViewTextBoxColumn1.DataPropertyName = "cCaracteristica";
            this.cCaracteristicaDataGridViewTextBoxColumn1.HeaderText = "cCaracteristica";
            this.cCaracteristicaDataGridViewTextBoxColumn1.Name = "cCaracteristicaDataGridViewTextBoxColumn1";
            this.cCaracteristicaDataGridViewTextBoxColumn1.Width = 102;
            // 
            // cReglaNegocioDataGridViewTextBoxColumn1
            // 
            this.cReglaNegocioDataGridViewTextBoxColumn1.DataPropertyName = "cReglaNegocio";
            this.cReglaNegocioDataGridViewTextBoxColumn1.HeaderText = "cReglaNegocio";
            this.cReglaNegocioDataGridViewTextBoxColumn1.Name = "cReglaNegocioDataGridViewTextBoxColumn1";
            this.cReglaNegocioDataGridViewTextBoxColumn1.Width = 106;
            // 
            // cMensajeErrorDataGridViewTextBoxColumn1
            // 
            this.cMensajeErrorDataGridViewTextBoxColumn1.DataPropertyName = "cMensajeError";
            this.cMensajeErrorDataGridViewTextBoxColumn1.HeaderText = "cMensajeError";
            this.cMensajeErrorDataGridViewTextBoxColumn1.Name = "cMensajeErrorDataGridViewTextBoxColumn1";
            // 
            // lIndExcepcionDataGridViewTextBoxColumn1
            // 
            this.lIndExcepcionDataGridViewTextBoxColumn1.DataPropertyName = "lIndExcepcion";
            this.lIndExcepcionDataGridViewTextBoxColumn1.HeaderText = "lIndExcepcion";
            this.lIndExcepcionDataGridViewTextBoxColumn1.Name = "lIndExcepcionDataGridViewTextBoxColumn1";
            this.lIndExcepcionDataGridViewTextBoxColumn1.Width = 99;
            // 
            // cCampoExcepcionDataGridViewTextBoxColumn1
            // 
            this.cCampoExcepcionDataGridViewTextBoxColumn1.DataPropertyName = "cCampoExcepcion";
            this.cCampoExcepcionDataGridViewTextBoxColumn1.HeaderText = "cCampoExcepcion";
            this.cCampoExcepcionDataGridViewTextBoxColumn1.Name = "cCampoExcepcionDataGridViewTextBoxColumn1";
            this.cCampoExcepcionDataGridViewTextBoxColumn1.Width = 121;
            // 
            // lNoExcepcionDataGridViewCheckBoxColumn
            // 
            this.lNoExcepcionDataGridViewCheckBoxColumn.DataPropertyName = "lNoExcepcion";
            this.lNoExcepcionDataGridViewCheckBoxColumn.HeaderText = "lNoExcepcion";
            this.lNoExcepcionDataGridViewCheckBoxColumn.Name = "lNoExcepcionDataGridViewCheckBoxColumn";
            this.lNoExcepcionDataGridViewCheckBoxColumn.Width = 79;
            // 
            // cGrupoDataGridViewTextBoxColumn1
            // 
            this.cGrupoDataGridViewTextBoxColumn1.DataPropertyName = "cGrupo";
            this.cGrupoDataGridViewTextBoxColumn1.HeaderText = "cGrupo";
            this.cGrupoDataGridViewTextBoxColumn1.Name = "cGrupoDataGridViewTextBoxColumn1";
            this.cGrupoDataGridViewTextBoxColumn1.Width = 67;
            // 
            // lVigenteDataGridViewCheckBoxColumn1
            // 
            this.lVigenteDataGridViewCheckBoxColumn1.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.Name = "lVigenteDataGridViewCheckBoxColumn1";
            this.lVigenteDataGridViewCheckBoxColumn1.Width = 51;
            // 
            // nIdReglaDataGridViewTextBoxColumn
            // 
            this.nIdReglaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nIdReglaDataGridViewTextBoxColumn.DataPropertyName = "nIdRegla";
            this.nIdReglaDataGridViewTextBoxColumn.HeaderText = "N°Regla";
            this.nIdReglaDataGridViewTextBoxColumn.Name = "nIdReglaDataGridViewTextBoxColumn";
            this.nIdReglaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nIdReglaDataGridViewTextBoxColumn.Width = 60;
            // 
            // cAcronimo
            // 
            this.cAcronimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cAcronimo.DataPropertyName = "cNombreCorto";
            this.cAcronimo.HeaderText = "Canal";
            this.cAcronimo.Name = "cAcronimo";
            this.cAcronimo.ReadOnly = true;
            this.cAcronimo.Width = 70;
            // 
            // cMensajeErrorDataGridViewTextBoxColumn
            // 
            this.cMensajeErrorDataGridViewTextBoxColumn.DataPropertyName = "cMensajeError";
            this.cMensajeErrorDataGridViewTextBoxColumn.HeaderText = "Mensaje de Regla";
            this.cMensajeErrorDataGridViewTextBoxColumn.MinimumWidth = 400;
            this.cMensajeErrorDataGridViewTextBoxColumn.Name = "cMensajeErrorDataGridViewTextBoxColumn";
            this.cMensajeErrorDataGridViewTextBoxColumn.ReadOnly = true;
            this.cMensajeErrorDataGridViewTextBoxColumn.Width = 400;
            // 
            // cGrupoDataGridViewTextBoxColumn
            // 
            this.cGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cGrupoDataGridViewTextBoxColumn.DataPropertyName = "cGrupo";
            this.cGrupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.cGrupoDataGridViewTextBoxColumn.Name = "cGrupoDataGridViewTextBoxColumn";
            this.cGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cGrupoDataGridViewTextBoxColumn.Width = 60;
            // 
            // frmBuscarReglaNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 382);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmBuscarReglaNegocio";
            this.Text = "Buscador de Regla de Negocio";
            this.Load += new System.EventHandler(this.frmBuscarReglaNegocio_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReglaNegocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReglaNegocio)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.lblBase lblNroRegla;
        private GEN.ControlesBase.txtNumerico txtIdRegla;
        private System.Windows.Forms.BindingSource bsReglaNegocio;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private cboBase cboMetodoBusqueda;
        private lblBase lblBase2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgReglaNegocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdReglaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdOpcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCaracteristicaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReglaNegocioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMensajeErrorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lIndExcepcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCampoExcepcionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lNoExcepcionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGrupoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIdReglaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAcronimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMensajeErrorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGrupoDataGridViewTextBoxColumn;
    }
}