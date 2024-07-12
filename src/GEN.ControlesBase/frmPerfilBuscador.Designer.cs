namespace GEN.ControlesBase
{
    partial class frmPerfilBuscador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerfilBuscador));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtPerfil = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgPerfil = new GEN.ControlesBase.dtgBase(this.components);
            this.idPerfilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPerfilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPerfil = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerfil)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 396);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 330);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnBusqueda);
            this.splitContainer1.Panel1.Controls.Add(this.txtPerfil);
            this.splitContainer1.Panel1.Controls.Add(this.lblBase1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgPerfil);
            this.splitContainer1.Size = new System.Drawing.Size(516, 330);
            this.splitContainer1.SplitterDistance = 75;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(309, 11);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtPerfil
            // 
            this.txtPerfil.Location = new System.Drawing.Point(75, 26);
            this.txtPerfil.Name = "txtPerfil";
            this.txtPerfil.Size = new System.Drawing.Size(217, 20);
            this.txtPerfil.TabIndex = 1;
            this.txtPerfil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerfil_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(41, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Perfil:";
            // 
            // dtgPerfil
            // 
            this.dtgPerfil.AllowUserToAddRows = false;
            this.dtgPerfil.AllowUserToDeleteRows = false;
            this.dtgPerfil.AllowUserToResizeColumns = false;
            this.dtgPerfil.AllowUserToResizeRows = false;
            this.dtgPerfil.AutoGenerateColumns = false;
            this.dtgPerfil.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPerfil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPerfilDataGridViewTextBoxColumn,
            this.cPerfilDataGridViewTextBoxColumn});
            this.dtgPerfil.DataSource = this.bsPerfil;
            this.dtgPerfil.Location = new System.Drawing.Point(9, 12);
            this.dtgPerfil.MultiSelect = false;
            this.dtgPerfil.Name = "dtgPerfil";
            this.dtgPerfil.ReadOnly = true;
            this.dtgPerfil.RowHeadersVisible = false;
            this.dtgPerfil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPerfil.Size = new System.Drawing.Size(498, 219);
            this.dtgPerfil.TabIndex = 0;
            this.dtgPerfil.SelectionChanged += new System.EventHandler(this.dtgPerfil_SelectionChanged);
            // 
            // idPerfilDataGridViewTextBoxColumn
            // 
            this.idPerfilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idPerfilDataGridViewTextBoxColumn.DataPropertyName = "idPerfil";
            this.idPerfilDataGridViewTextBoxColumn.FillWeight = 15F;
            this.idPerfilDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idPerfilDataGridViewTextBoxColumn.Name = "idPerfilDataGridViewTextBoxColumn";
            this.idPerfilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPerfilDataGridViewTextBoxColumn
            // 
            this.cPerfilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPerfilDataGridViewTextBoxColumn.DataPropertyName = "cPerfil";
            this.cPerfilDataGridViewTextBoxColumn.FillWeight = 85F;
            this.cPerfilDataGridViewTextBoxColumn.HeaderText = "Perfil";
            this.cPerfilDataGridViewTextBoxColumn.Name = "cPerfilDataGridViewTextBoxColumn";
            this.cPerfilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsPerfil
            // 
            this.bsPerfil.DataSource = typeof(EntityLayer.clsPerfil);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Location = new System.Drawing.Point(3, 339);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 54);
            this.panel2.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(452, 2);
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
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(309, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmPerfilBuscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 425);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPerfilBuscador";
            this.Text = "Buscador de Perfiles";
            this.Load += new System.EventHandler(this.frmPerfilBuscador_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPerfil)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.Panel panel2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtBase txtPerfil;
        private GEN.ControlesBase.dtgBase dtgPerfil;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPerfilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPerfilDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsPerfil;
    }
}