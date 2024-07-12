namespace CRE.Presentacion
{
    partial class frmGrupoSolEvalIntegrantes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolEvalIntegrantes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgEstResEval = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmERTitulo = new System.Windows.Forms.ToolStripTextBox();
            this.tsmERFechaUltimaEval = new System.Windows.Forms.ToolStripTextBox();
            this.tsmERFechaActualEval = new System.Windows.Forms.ToolStripTextBox();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtgIndiFinanc = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgIntegrantes = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstResEval)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIndiFinanc)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(15, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(999, 285);
            this.panel3.TabIndex = 92;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.menuStrip2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(999, 280);
            this.panel5.TabIndex = 28;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtgEstResEval);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(997, 254);
            this.panel6.TabIndex = 24;
            // 
            // dtgEstResEval
            // 
            this.dtgEstResEval.AllowUserToAddRows = false;
            this.dtgEstResEval.AllowUserToDeleteRows = false;
            this.dtgEstResEval.AllowUserToResizeColumns = false;
            this.dtgEstResEval.AllowUserToResizeRows = false;
            this.dtgEstResEval.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgEstResEval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEstResEval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstResEval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEstResEval.Location = new System.Drawing.Point(0, 0);
            this.dtgEstResEval.MultiSelect = false;
            this.dtgEstResEval.Name = "dtgEstResEval";
            this.dtgEstResEval.RowHeadersVisible = false;
            this.dtgEstResEval.Size = new System.Drawing.Size(997, 254);
            this.dtgEstResEval.TabIndex = 0;
            this.dtgEstResEval.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellLeave);
            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEstResEval_DataError);
            this.dtgEstResEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmERTitulo,
            this.tsmERFechaUltimaEval,
            this.tsmERFechaActualEval});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(997, 24);
            this.menuStrip2.TabIndex = 23;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmERTitulo
            // 
            this.tsmERTitulo.BackColor = System.Drawing.Color.White;
            this.tsmERTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsmERTitulo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmERTitulo.Name = "tsmERTitulo";
            this.tsmERTitulo.ReadOnly = true;
            this.tsmERTitulo.Size = new System.Drawing.Size(134, 20);
            this.tsmERTitulo.Text = "Estado  Resultados";
            // 
            // tsmERFechaUltimaEval
            // 
            this.tsmERFechaUltimaEval.BackColor = System.Drawing.Color.White;
            this.tsmERFechaUltimaEval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsmERFechaUltimaEval.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmERFechaUltimaEval.Name = "tsmERFechaUltimaEval";
            this.tsmERFechaUltimaEval.ReadOnly = true;
            this.tsmERFechaUltimaEval.Size = new System.Drawing.Size(80, 20);
            this.tsmERFechaUltimaEval.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tsmERFechaActualEval
            // 
            this.tsmERFechaActualEval.BackColor = System.Drawing.Color.White;
            this.tsmERFechaActualEval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsmERFechaActualEval.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmERFechaActualEval.Name = "tsmERFechaActualEval";
            this.tsmERFechaActualEval.ReadOnly = true;
            this.tsmERFechaActualEval.Size = new System.Drawing.Size(80, 20);
            this.tsmERFechaActualEval.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(147, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 91;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(81, 457);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 90;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(15, 457);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 88;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(954, 457);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 89;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(15, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 106);
            this.panel1.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 97);
            this.panel2.TabIndex = 78;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 95);
            this.panel4.TabIndex = 25;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dtgIndiFinanc);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 24);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(997, 71);
            this.panel7.TabIndex = 25;
            // 
            // dtgIndiFinanc
            // 
            this.dtgIndiFinanc.AllowUserToAddRows = false;
            this.dtgIndiFinanc.AllowUserToDeleteRows = false;
            this.dtgIndiFinanc.AllowUserToResizeColumns = false;
            this.dtgIndiFinanc.AllowUserToResizeRows = false;
            this.dtgIndiFinanc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgIndiFinanc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIndiFinanc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgIndiFinanc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIndiFinanc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIndiFinanc.Location = new System.Drawing.Point(0, 0);
            this.dtgIndiFinanc.MultiSelect = false;
            this.dtgIndiFinanc.Name = "dtgIndiFinanc";
            this.dtgIndiFinanc.RowHeadersVisible = false;
            this.dtgIndiFinanc.Size = new System.Drawing.Size(997, 71);
            this.dtgIndiFinanc.TabIndex = 10;
            this.dtgIndiFinanc.TabStop = false;
            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.menuStrip1);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(997, 24);
            this.panel8.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Location = new System.Drawing.Point(182, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 7;
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
            this.label1.TabIndex = 100;
            this.label1.Text = "Indicadores Financieros";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dtgIntegrantes.Size = new System.Drawing.Size(186, 369);
            this.dtgIntegrantes.TabIndex = 1;
            this.dtgIntegrantes.TabStop = false;
            //
            // frmGrupoSolEvalIntegrantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmGrupoSolEvalIntegrantes";
            this.ShowInTaskbar = false;
            this.Text = "Grupo Solidario - Evaluación de Integrantes";
            this.Load += new System.EventHandler(this.frmGrupoSolEvalIntegrantes_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstResEval)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIndiFinanc)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dtgEstResEval;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripTextBox tsmERTitulo;
        private System.Windows.Forms.ToolStripTextBox tsmERFechaUltimaEval;
        private System.Windows.Forms.ToolStripTextBox tsmERFechaActualEval;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dtgIndiFinanc;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgIntegrantes;
    }
}