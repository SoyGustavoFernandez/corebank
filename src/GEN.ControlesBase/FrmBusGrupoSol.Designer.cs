namespace GEN.ControlesBase
{
    partial class FrmBusGrupoSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusGrupoSol));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtNombreGrupoSol = new System.Windows.Forms.TextBox();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgGrupoSolidario = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoSolidario)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Nombre del Grupo";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(575, 281);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 96;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(509, 281);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 95;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(490, 14);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 97;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // txtNombreGrupoSol
            // 
            this.txtNombreGrupoSol.Location = new System.Drawing.Point(126, 18);
            this.txtNombreGrupoSol.Name = "txtNombreGrupoSol";
            this.txtNombreGrupoSol.Size = new System.Drawing.Size(357, 20);
            this.txtNombreGrupoSol.TabIndex = 98;
            this.txtNombreGrupoSol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCBNumerosEnteros_KeyDown);
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(12, 48);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(623, 227);
            this.panelGlobal.TabIndex = 110;
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(621, 225);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgGrupoSolidario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 201);
            this.panel2.TabIndex = 25;
            // 
            // dtgGrupoSolidario
            // 
            this.dtgGrupoSolidario.AllowUserToAddRows = false;
            this.dtgGrupoSolidario.AllowUserToDeleteRows = false;
            this.dtgGrupoSolidario.AllowUserToResizeColumns = false;
            this.dtgGrupoSolidario.AllowUserToResizeRows = false;
            this.dtgGrupoSolidario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupoSolidario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgGrupoSolidario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgGrupoSolidario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoSolidario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGrupoSolidario.Location = new System.Drawing.Point(0, 0);
            this.dtgGrupoSolidario.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGrupoSolidario.MultiSelect = false;
            this.dtgGrupoSolidario.Name = "dtgGrupoSolidario";
            this.dtgGrupoSolidario.ReadOnly = true;
            this.dtgGrupoSolidario.RowHeadersVisible = false;
            this.dtgGrupoSolidario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoSolidario.Size = new System.Drawing.Size(621, 201);
            this.dtgGrupoSolidario.TabIndex = 0;
            this.dtgGrupoSolidario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgGrupoSolidario_KeyDown);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(621, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCancelar,
            this.tsmQuitar,
            this.tsmAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmCancelar
            // 
            this.tsmCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmCancelar.Enabled = false;
            this.tsmCancelar.Name = "tsmCancelar";
            this.tsmCancelar.Size = new System.Drawing.Size(12, 20);
            this.tsmCancelar.Text = "tsmCancelar";
            this.tsmCancelar.ToolTipText = "Cancelar edición.";
            this.tsmCancelar.Visible = false;
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.Checked = true;
            this.tsmQuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(12, 20);
            this.tsmQuitar.Text = "Quitar";
            this.tsmQuitar.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitar.Visible = false;
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Enabled = false;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(12, 20);
            this.tsmAgregar.Text = "Agregar";
            this.tsmAgregar.ToolTipText = "Agregar registro del formulario.";
            this.tsmAgregar.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Grupos Solidarios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmBusGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 366);
            this.Controls.Add(this.panelGlobal);
            this.Controls.Add(this.txtNombreGrupoSol);
            this.Controls.Add(this.btnMiniBusq);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase1);
            this.Name = "FrmBusGrupoSol";
            this.ShowInTaskbar = false;
            this.Text = "Buscar Grupos Solidarios";
            this.Shown += new System.EventHandler(this.FrmBusGrupoSol_Shown);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq, 0);
            this.Controls.SetChildIndex(this.txtNombreGrupoSol, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoSolidario)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.BtnAceptar btnAceptar;
        public System.Windows.Forms.TextBox txtNombreGrupoSol;
        private BotonesBase.btnMiniBusq btnMiniBusq;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgGrupoSolidario;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelar;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label1;
    }
}