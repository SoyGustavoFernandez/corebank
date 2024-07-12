namespace CRE.Presentacion
{
    partial class FrmBuscarEv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarEv));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgEvalCred = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvalCred)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(655, 237);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 102;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(523, 236);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 101;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(8, 105);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(707, 126);
            this.panelGlobal.TabIndex = 109;
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(705, 124);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgEvalCred);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 100);
            this.panel2.TabIndex = 25;
            // 
            // dtgEvalCred
            // 
            this.dtgEvalCred.AllowUserToAddRows = false;
            this.dtgEvalCred.AllowUserToDeleteRows = false;
            this.dtgEvalCred.AllowUserToResizeColumns = false;
            this.dtgEvalCred.AllowUserToResizeRows = false;
            this.dtgEvalCred.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEvalCred.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgEvalCred.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEvalCred.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvalCred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEvalCred.Location = new System.Drawing.Point(0, 0);
            this.dtgEvalCred.MultiSelect = false;
            this.dtgEvalCred.Name = "dtgEvalCred";
            this.dtgEvalCred.ReadOnly = true;
            this.dtgEvalCred.RowHeadersVisible = false;
            this.dtgEvalCred.Size = new System.Drawing.Size(705, 100);
            this.dtgEvalCred.TabIndex = 0;
            this.dtgEvalCred.TabStop = false;
            this.dtgEvalCred.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvalCred_CellDoubleClick);
            this.dtgEvalCred.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgEvalCred_KeyDown);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(705, 24);
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
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
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
            this.label1.Text = "Evaluaciones";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(8, 10);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 79);
            this.conBusCli.TabIndex = 1;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(589, 236);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 110;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // FrmBuscarEv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 319);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.panelGlobal);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmBuscarEv";
            this.ShowInTaskbar = false;
            this.Text = "Buscar Evaluaciones";
            this.Load += new System.EventHandler(this.FrmBuscarEvPyme_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvalCred)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgEvalCred;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelar;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}