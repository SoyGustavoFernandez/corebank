namespace GEN.ControlesBase
{
    partial class ConReferenciasSimp
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
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgReferencia = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.msAcciones = new System.Windows.Forms.MenuStrip();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingReferencia = new System.Windows.Forms.BindingSource(this.components);
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferencia)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.msAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingReferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(3, 3);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(474, 138);
            this.panelGlobal.TabIndex = 25;
            // 
            // panelDG
            // 
            this.panelDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(472, 136);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dtgReferencia);
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 112);
            this.panel2.TabIndex = 25;
            // 
            // dtgReferencia
            // 
            this.dtgReferencia.AllowUserToAddRows = false;
            this.dtgReferencia.AllowUserToDeleteRows = false;
            this.dtgReferencia.AllowUserToResizeColumns = false;
            this.dtgReferencia.AllowUserToResizeRows = false;
            this.dtgReferencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReferencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReferencia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgReferencia.Location = new System.Drawing.Point(0, 0);
            this.dtgReferencia.MultiSelect = false;
            this.dtgReferencia.Name = "dtgReferencia";
            this.dtgReferencia.RowHeadersVisible = false;
            this.dtgReferencia.Size = new System.Drawing.Size(472, 112);
            this.dtgReferencia.TabIndex = 0;
            this.dtgReferencia.TabStop = false;
            this.dtgReferencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRefCliente_CellClick);
            this.dtgReferencia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReferencia_CellValueChanged);
            this.dtgReferencia.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgReferencia_CurrentCellDirtyStateChanged);
            this.dtgReferencia.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgReferencia_DataBindingComplete);
            this.dtgReferencia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgReferencia_DataError);
            this.dtgReferencia.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgReferencia_EditingControlShowing);
            this.dtgReferencia.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dtgRefCliente_RowPrePaint);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.Controls.Add(this.msAcciones);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(472, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // msAcciones
            // 
            this.msAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.msAcciones.BackColor = System.Drawing.Color.White;
            this.msAcciones.Dock = System.Windows.Forms.DockStyle.None;
            this.msAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQuitar,
            this.tsmAgregar});
            this.msAcciones.Location = new System.Drawing.Point(405, 0);
            this.msAcciones.Name = "msAcciones";
            this.msAcciones.Size = new System.Drawing.Size(64, 24);
            this.msAcciones.TabIndex = 0;
            this.msAcciones.TabStop = true;
            this.msAcciones.Text = "menuStrip1";
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.Checked = true;
            this.tsmQuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Image = global::GEN.ControlesBase.Properties.Resources.btn_quitar;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(28, 20);
            this.tsmQuitar.Text = "Quitar";
            this.tsmQuitar.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitar.Click += new System.EventHandler(this.tsmQuitar_Click);
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Image = global::GEN.ControlesBase.Properties.Resources.btn_agregar;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(28, 20);
            this.tsmAgregar.Text = "Agregar";
            this.tsmAgregar.ToolTipText = "Guarda el registro del formulario.";
            this.tsmAgregar.Click += new System.EventHandler(this.tsmAgregar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Referencias Personales/Comerciales";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConReferenciasSimp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGlobal);
            this.Name = "ConReferenciasSimp";
            this.Size = new System.Drawing.Size(480, 145);
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferencia)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.msAcciones.ResumeLayout(false);
            this.msAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingReferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bindingReferencia;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgReferencia;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip msAcciones;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label1;
    }
}
