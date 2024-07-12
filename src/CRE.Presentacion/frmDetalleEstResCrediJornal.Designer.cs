namespace CRE.Presentacion
{
    partial class frmDetalleEstResCrediJornal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleEstResCrediJornal));
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlIngresos = new System.Windows.Forms.Panel();
            this.labelTotaldtgIngresos = new GEN.ControlesBase.lblBase();
            this.txtTotalIngresos = new GEN.ControlesBase.txtBase(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtgIngresos = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlGastosFamiliares = new System.Windows.Forms.Panel();
            this.labelTotaldtgGFamiliares = new GEN.ControlesBase.lblBase();
            this.txtTotalGFamiliares = new GEN.ControlesBase.txtBase(this.components);
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.dtgGFamiliares = new System.Windows.Forms.DataGridView();
            this.panel15 = new System.Windows.Forms.Panel();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.tsmQuitarGFam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregarGFam = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.bindingGFamiliares = new System.Windows.Forms.BindingSource(this.components);
            this.bindingIngresos = new System.Windows.Forms.BindingSource(this.components);
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlIngresos.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngresos)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlGastosFamiliares.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGFamiliares)).BeginInit();
            this.panel15.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingGFamiliares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Location = new System.Drawing.Point(12, 12);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(635, 281);
            this.tbcBase1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlIngresos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingresos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlIngresos
            // 
            this.pnlIngresos.Controls.Add(this.labelTotaldtgIngresos);
            this.pnlIngresos.Controls.Add(this.txtTotalIngresos);
            this.pnlIngresos.Controls.Add(this.panel2);
            this.pnlIngresos.Enabled = false;
            this.pnlIngresos.Location = new System.Drawing.Point(3, 6);
            this.pnlIngresos.Name = "pnlIngresos";
            this.pnlIngresos.Size = new System.Drawing.Size(618, 153);
            this.pnlIngresos.TabIndex = 93;
            // 
            // labelTotaldtgIngresos
            // 
            this.labelTotaldtgIngresos.Font = new System.Drawing.Font("Verdana", 8F);
            this.labelTotaldtgIngresos.ForeColor = System.Drawing.Color.Navy;
            this.labelTotaldtgIngresos.Location = new System.Drawing.Point(455, 133);
            this.labelTotaldtgIngresos.Name = "labelTotaldtgIngresos";
            this.labelTotaldtgIngresos.Size = new System.Drawing.Size(80, 13);
            this.labelTotaldtgIngresos.TabIndex = 82;
            this.labelTotaldtgIngresos.Text = "Total";
            this.labelTotaldtgIngresos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalIngresos
            // 
            this.txtTotalIngresos.Enabled = false;
            this.txtTotalIngresos.Location = new System.Drawing.Point(536, 130);
            this.txtTotalIngresos.Name = "txtTotalIngresos";
            this.txtTotalIngresos.Size = new System.Drawing.Size(81, 20);
            this.txtTotalIngresos.TabIndex = 81;
            this.txtTotalIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 124);
            this.panel2.TabIndex = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 122);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtgIngresos);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(616, 98);
            this.panel4.TabIndex = 25;
            // 
            // dtgIngresos
            // 
            this.dtgIngresos.AllowUserToAddRows = false;
            this.dtgIngresos.AllowUserToDeleteRows = false;
            this.dtgIngresos.AllowUserToResizeColumns = false;
            this.dtgIngresos.AllowUserToResizeRows = false;
            this.dtgIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIngresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIngresos.Location = new System.Drawing.Point(0, 0);
            this.dtgIngresos.MultiSelect = false;
            this.dtgIngresos.Name = "dtgIngresos";
            this.dtgIngresos.RowHeadersVisible = false;
            this.dtgIngresos.Size = new System.Drawing.Size(616, 98);
            this.dtgIngresos.TabIndex = 10;
            this.dtgIngresos.TabStop = false;
            this.dtgIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellContentClick);
            this.dtgIngresos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellValueChanged);
            this.dtgIngresos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgIngresos_CurrentCellDirtyStateChanged);
            this.dtgIngresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresos_DataBindingComplete);
            this.dtgIngresos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgIngresos_DataError);
            this.dtgIngresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresos_EditingControlShowing);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(616, 24);
            this.panel5.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Ingresos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlGastosFamiliares);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(627, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gastos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlGastosFamiliares
            // 
            this.pnlGastosFamiliares.Controls.Add(this.labelTotaldtgGFamiliares);
            this.pnlGastosFamiliares.Controls.Add(this.txtTotalGFamiliares);
            this.pnlGastosFamiliares.Controls.Add(this.panel12);
            this.pnlGastosFamiliares.Enabled = false;
            this.pnlGastosFamiliares.Location = new System.Drawing.Point(92, 6);
            this.pnlGastosFamiliares.Name = "pnlGastosFamiliares";
            this.pnlGastosFamiliares.Size = new System.Drawing.Size(442, 234);
            this.pnlGastosFamiliares.TabIndex = 95;
            // 
            // labelTotaldtgGFamiliares
            // 
            this.labelTotaldtgGFamiliares.Font = new System.Drawing.Font("Verdana", 8F);
            this.labelTotaldtgGFamiliares.ForeColor = System.Drawing.Color.Navy;
            this.labelTotaldtgGFamiliares.Location = new System.Drawing.Point(276, 215);
            this.labelTotaldtgGFamiliares.Name = "labelTotaldtgGFamiliares";
            this.labelTotaldtgGFamiliares.Size = new System.Drawing.Size(80, 13);
            this.labelTotaldtgGFamiliares.TabIndex = 84;
            this.labelTotaldtgGFamiliares.Text = "Total";
            this.labelTotaldtgGFamiliares.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalGFamiliares
            // 
            this.txtTotalGFamiliares.Enabled = false;
            this.txtTotalGFamiliares.Location = new System.Drawing.Point(357, 212);
            this.txtTotalGFamiliares.Name = "txtTotalGFamiliares";
            this.txtTotalGFamiliares.Size = new System.Drawing.Size(82, 20);
            this.txtTotalGFamiliares.TabIndex = 80;
            this.txtTotalGFamiliares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(442, 207);
            this.panel12.TabIndex = 78;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(440, 205);
            this.panel13.TabIndex = 25;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.dtgGFamiliares);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 24);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(440, 181);
            this.panel14.TabIndex = 25;
            // 
            // dtgGFamiliares
            // 
            this.dtgGFamiliares.AllowUserToAddRows = false;
            this.dtgGFamiliares.AllowUserToDeleteRows = false;
            this.dtgGFamiliares.AllowUserToResizeColumns = false;
            this.dtgGFamiliares.AllowUserToResizeRows = false;
            this.dtgGFamiliares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGFamiliares.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgGFamiliares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgGFamiliares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGFamiliares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGFamiliares.Location = new System.Drawing.Point(0, 0);
            this.dtgGFamiliares.MultiSelect = false;
            this.dtgGFamiliares.Name = "dtgGFamiliares";
            this.dtgGFamiliares.RowHeadersVisible = false;
            this.dtgGFamiliares.Size = new System.Drawing.Size(440, 181);
            this.dtgGFamiliares.TabIndex = 96;
            this.dtgGFamiliares.TabStop = false;
            this.dtgGFamiliares.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);
            this.dtgGFamiliares.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.menuStrip3);
            this.panel15.Controls.Add(this.label3);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(440, 24);
            this.panel15.TabIndex = 9;
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.White;
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQuitarGFam,
            this.tsmAgregarGFam});
            this.menuStrip3.Location = new System.Drawing.Point(326, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(114, 24);
            this.menuStrip3.TabIndex = 7;
            this.menuStrip3.TabStop = true;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // tsmQuitarGFam
            // 
            this.tsmQuitarGFam.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitarGFam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitarGFam.Enabled = false;
            this.tsmQuitarGFam.Image = global::CRE.Presentacion.Properties.Resources.btn_quitar;
            this.tsmQuitarGFam.Name = "tsmQuitarGFam";
            this.tsmQuitarGFam.Size = new System.Drawing.Size(28, 20);
            this.tsmQuitarGFam.Text = "toolStripMenuItem2";
            this.tsmQuitarGFam.Click += new System.EventHandler(this.tsmQuitarGFam_Click);
            // 
            // tsmAgregarGFam
            // 
            this.tsmAgregarGFam.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregarGFam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregarGFam.Image = global::CRE.Presentacion.Properties.Resources.btn_agregar;
            this.tsmAgregarGFam.Name = "tsmAgregarGFam";
            this.tsmAgregarGFam.Size = new System.Drawing.Size(28, 20);
            this.tsmAgregarGFam.Text = "toolStripMenuItem1";
            this.tsmAgregarGFam.Click += new System.EventHandler(this.tsmAgregarGFam_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 24);
            this.label3.TabIndex = 100;
            this.label3.Text = "Gastos Familiares";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(393, 299);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(453, 299);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(513, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(579, 299);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmDetalleEstResCrediJornal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 383);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbcBase1);
            this.Name = "frmDetalleEstResCrediJornal";
            this.Text = "Detalle de Estados de Resultados";
            this.Load += new System.EventHandler(this.frmDetalleEstResCrediJornal_Load);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlIngresos.ResumeLayout(false);
            this.pnlIngresos.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngresos)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnlGastosFamiliares.ResumeLayout(false);
            this.pnlGastosFamiliares.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGFamiliares)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingGFamiliares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingIngresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Panel pnlGastosFamiliares;
        private GEN.ControlesBase.lblBase labelTotaldtgGFamiliares;
        private GEN.ControlesBase.txtBase txtTotalGFamiliares;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.DataGridView dtgGFamiliares;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitarGFam;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarGFam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlIngresos;
        private GEN.ControlesBase.lblBase labelTotaldtgIngresos;
        private GEN.ControlesBase.txtBase txtTotalIngresos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dtgIngresos;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingGFamiliares;
        private System.Windows.Forms.BindingSource bindingIngresos;
    }
}