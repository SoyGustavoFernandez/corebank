namespace CRE.Presentacion
{
    partial class frmRegGrupoSolidario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegGrupoSolidario));
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnQuitarInteg = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarInteg = new GEN.BotonesBase.btnMiniAgregar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgIntegrantes = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.bindingIntegrantes = new System.Windows.Forms.BindingSource(this.components);
            this.conBusGrupoSol1 = new GEN.ControlesBase.ConBusGrupoSol();
            this.cboCiclo = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboGrupoSolidarioTipo = new GEN.ControlesBase.CboGrupoSolidarioTipo(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoGrupoSolidario1 = new GEN.ControlesBase.cboTipoGrupoSolidario(this.components);
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            this.panel5.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingIntegrantes)).BeginInit();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.White;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(6, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(356, 24);
            this.miniToolStrip.TabIndex = 7;
            this.miniToolStrip.TabStop = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnQuitarInteg);
            this.tabPage1.Controls.Add(this.btnAgregarInteg);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(879, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Generales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnQuitarInteg
            // 
            this.btnQuitarInteg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarInteg.BackgroundImage")));
            this.btnQuitarInteg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarInteg.Location = new System.Drawing.Point(837, 49);
            this.btnQuitarInteg.Name = "btnQuitarInteg";
            this.btnQuitarInteg.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarInteg.TabIndex = 3;
            this.btnQuitarInteg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarInteg.UseVisualStyleBackColor = true;
            this.btnQuitarInteg.Click += new System.EventHandler(this.btnQuitarInteg_Click);
            // 
            // btnAgregarInteg
            // 
            this.btnAgregarInteg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarInteg.BackgroundImage")));
            this.btnAgregarInteg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarInteg.Location = new System.Drawing.Point(837, 15);
            this.btnAgregarInteg.Name = "btnAgregarInteg";
            this.btnAgregarInteg.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarInteg.TabIndex = 2;
            this.btnAgregarInteg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarInteg.UseVisualStyleBackColor = true;
            this.btnAgregarInteg.Click += new System.EventHandler(this.btnAgregarInteg_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 233);
            this.panel1.TabIndex = 93;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 223);
            this.panel2.TabIndex = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 221);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgIntegrantes);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(814, 197);
            this.panel4.TabIndex = 25;
            // 
            // dtgIntegrantes
            // 
            this.dtgIntegrantes.AllowUserToAddRows = false;
            this.dtgIntegrantes.AllowUserToDeleteRows = false;
            this.dtgIntegrantes.AllowUserToResizeColumns = false;
            this.dtgIntegrantes.AllowUserToResizeRows = false;
            this.dtgIntegrantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntegrantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgIntegrantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIntegrantes.Location = new System.Drawing.Point(0, 0);
            this.dtgIntegrantes.MultiSelect = false;
            this.dtgIntegrantes.Name = "dtgIntegrantes";
            this.dtgIntegrantes.ReadOnly = true;
            this.dtgIntegrantes.RowHeadersVisible = false;
            this.dtgIntegrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantes.Size = new System.Drawing.Size(814, 197);
            this.dtgIntegrantes.TabIndex = 0;
            this.dtgIntegrantes.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.menuStrip1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(814, 24);
            this.panel5.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Location = new System.Drawing.Point(182, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Integrantes del Grupo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Location = new System.Drawing.Point(12, 90);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(887, 294);
            this.tbcBase1.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(12, 390);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(591, 390);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.TabStop = false;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(839, 390);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(715, 390);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
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
            this.btnCancelar.Location = new System.Drawing.Point(777, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(653, 390);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.TabStop = false;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // conBusGrupoSol1
            // 
            this.conBusGrupoSol1.Location = new System.Drawing.Point(12, 12);
            this.conBusGrupoSol1.Name = "conBusGrupoSol1";
            this.conBusGrupoSol1.Size = new System.Drawing.Size(618, 49);
            this.conBusGrupoSol1.TabIndex = 11;
            this.conBusGrupoSol1.ClicBuscar += new System.EventHandler(this.conBusGrupoSol1_ClicBuscar);
            // 
            // cboCiclo
            // 
            this.cboCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiclo.Enabled = false;
            this.cboCiclo.FormattingEnabled = true;
            this.cboCiclo.Location = new System.Drawing.Point(76, 63);
            this.cboCiclo.Name = "cboCiclo";
            this.cboCiclo.Size = new System.Drawing.Size(100, 21);
            this.cboCiclo.TabIndex = 99;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(39, 67);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(35, 13);
            this.lblBase10.TabIndex = 100;
            this.lblBase10.Text = "Ciclo";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(188, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(36, 13);
            this.lblBase2.TabIndex = 101;
            this.lblBase2.Text = "Tipo:";
            // 
            // cboGrupoSolidarioTipo
            // 
            this.cboGrupoSolidarioTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoSolidarioTipo.Enabled = false;
            this.cboGrupoSolidarioTipo.FormattingEnabled = true;
            this.cboGrupoSolidarioTipo.Location = new System.Drawing.Point(224, 63);
            this.cboGrupoSolidarioTipo.Name = "cboGrupoSolidarioTipo";
            this.cboGrupoSolidarioTipo.Size = new System.Drawing.Size(100, 21);
            this.cboGrupoSolidarioTipo.TabIndex = 102;
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(490, 63);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(59, 20);
            this.txtBase1.TabIndex = 106;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(339, 67);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(145, 13);
            this.lblBase1.TabIndex = 105;
            this.lblBase1.Text = "Número de Integrantes:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(557, 67);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(73, 13);
            this.lblBase3.TabIndex = 107;
            this.lblBase3.Text = "Tipo grupo:";
            // 
            // cboTipoGrupoSolidario1
            // 
            this.cboTipoGrupoSolidario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGrupoSolidario1.Enabled = false;
            this.cboTipoGrupoSolidario1.FormattingEnabled = true;
            this.cboTipoGrupoSolidario1.Location = new System.Drawing.Point(637, 63);
            this.cboTipoGrupoSolidario1.Name = "cboTipoGrupoSolidario1";
            this.cboTipoGrupoSolidario1.Size = new System.Drawing.Size(159, 21);
            this.cboTipoGrupoSolidario1.TabIndex = 108;
            // 
            // frmRegGrupoSolidario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 475);
            this.Controls.Add(this.cboTipoGrupoSolidario1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboGrupoSolidarioTipo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboCiclo);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.conBusGrupoSol1);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Name = "frmRegGrupoSolidario";
            this.ShowInTaskbar = false;
            this.Text = "Registro y Mantenimiento de Grupo Solidario";
            this.Load += new System.EventHandler(this.frmRegGrupoSolidario_Load);
            this.Shown += new System.EventHandler(this.frmRegGrupoSolidario_Shown);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.conBusGrupoSol1, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.cboCiclo, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboGrupoSolidarioTipo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipoGrupoSolidario1, 0);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tbcBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingIntegrantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarInteg;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarInteg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtgIntegrantes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.BindingSource bindingIntegrantes;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol1;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboCiclo;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.CboGrupoSolidarioTipo cboGrupoSolidarioTipo;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoGrupoSolidario cboTipoGrupoSolidario1;
    }
}