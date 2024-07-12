namespace ADM.Presentacion
{
    partial class frmAuditoriaTablas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuditoriaTablas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitar = new GEN.BotonesBase.btnRegresar();
            this.btnAgregar = new GEN.BotonesBase.btnContinuar();
            this.dtgTblAuditadas = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgTxtTablaAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgChcFlagAudit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgTblNoAuditadas = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgTxtTablaNoAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgChcFlagNoAudit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.grbBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTblAuditadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTblNoAuditadas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(428, 318);
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
            this.btnCancelar.Location = new System.Drawing.Point(366, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(490, 318);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase
            // 
            this.grbBase.Controls.Add(this.btnQuitar);
            this.grbBase.Controls.Add(this.btnAgregar);
            this.grbBase.Controls.Add(this.dtgTblAuditadas);
            this.grbBase.Controls.Add(this.dtgTblNoAuditadas);
            this.grbBase.Location = new System.Drawing.Point(10, 3);
            this.grbBase.Name = "grbBase";
            this.grbBase.Size = new System.Drawing.Size(550, 309);
            this.grbBase.TabIndex = 9;
            this.grbBase.TabStop = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(245, 178);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(245, 80);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "A&gregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgTblAuditadas
            // 
            this.dtgTblAuditadas.AllowUserToAddRows = false;
            this.dtgTblAuditadas.AllowUserToDeleteRows = false;
            this.dtgTblAuditadas.AllowUserToResizeColumns = false;
            this.dtgTblAuditadas.AllowUserToResizeRows = false;
            this.dtgTblAuditadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTblAuditadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTblAuditadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTblAuditadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgTxtTablaAudit,
            this.dtgChcFlagAudit});
            this.dtgTblAuditadas.Location = new System.Drawing.Point(310, 16);
            this.dtgTblAuditadas.MultiSelect = false;
            this.dtgTblAuditadas.Name = "dtgTblAuditadas";
            this.dtgTblAuditadas.ReadOnly = true;
            this.dtgTblAuditadas.RowHeadersVisible = false;
            this.dtgTblAuditadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTblAuditadas.Size = new System.Drawing.Size(230, 284);
            this.dtgTblAuditadas.TabIndex = 7;
            // 
            // dtgTxtTablaAudit
            // 
            this.dtgTxtTablaAudit.DataPropertyName = "cTablaAudit";
            this.dtgTxtTablaAudit.HeaderText = "Tablas Auditadas";
            this.dtgTxtTablaAudit.Name = "dtgTxtTablaAudit";
            this.dtgTxtTablaAudit.ReadOnly = true;
            // 
            // dtgChcFlagAudit
            // 
            this.dtgChcFlagAudit.DataPropertyName = "lFlagAudit";
            this.dtgChcFlagAudit.HeaderText = "lFlagAudit";
            this.dtgChcFlagAudit.Name = "dtgChcFlagAudit";
            this.dtgChcFlagAudit.ReadOnly = true;
            this.dtgChcFlagAudit.Visible = false;
            // 
            // dtgTblNoAuditadas
            // 
            this.dtgTblNoAuditadas.AllowUserToAddRows = false;
            this.dtgTblNoAuditadas.AllowUserToDeleteRows = false;
            this.dtgTblNoAuditadas.AllowUserToResizeColumns = false;
            this.dtgTblNoAuditadas.AllowUserToResizeRows = false;
            this.dtgTblNoAuditadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTblNoAuditadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTblNoAuditadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTblNoAuditadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgTxtTablaNoAudit,
            this.dtgChcFlagNoAudit});
            this.dtgTblNoAuditadas.Location = new System.Drawing.Point(10, 16);
            this.dtgTblNoAuditadas.MultiSelect = false;
            this.dtgTblNoAuditadas.Name = "dtgTblNoAuditadas";
            this.dtgTblNoAuditadas.ReadOnly = true;
            this.dtgTblNoAuditadas.RowHeadersVisible = false;
            this.dtgTblNoAuditadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTblNoAuditadas.Size = new System.Drawing.Size(230, 284);
            this.dtgTblNoAuditadas.TabIndex = 6;
            // 
            // dtgTxtTablaNoAudit
            // 
            this.dtgTxtTablaNoAudit.DataPropertyName = "cTablaNoAudit";
            this.dtgTxtTablaNoAudit.HeaderText = "Tablas no Auditadas";
            this.dtgTxtTablaNoAudit.Name = "dtgTxtTablaNoAudit";
            this.dtgTxtTablaNoAudit.ReadOnly = true;
            // 
            // dtgChcFlagNoAudit
            // 
            this.dtgChcFlagNoAudit.DataPropertyName = "lFlagNoAudit";
            this.dtgChcFlagNoAudit.HeaderText = "lFlagNoAudit";
            this.dtgChcFlagNoAudit.Name = "dtgChcFlagNoAudit";
            this.dtgChcFlagNoAudit.ReadOnly = true;
            this.dtgChcFlagNoAudit.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nota: Opción exclusiva para Administrador de Base de Datos";
            // 
            // frmAuditoriaTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbBase);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmAuditoriaTablas";
            this.Text = "Auditoría de Tablas - BD";
            this.Load += new System.EventHandler(this.frmAuditoriaTablas_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.grbBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTblAuditadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTblNoAuditadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase;
        private GEN.BotonesBase.btnRegresar btnQuitar;
        private GEN.BotonesBase.btnContinuar btnAgregar;
        private GEN.ControlesBase.dtgBase dtgTblAuditadas;
        private GEN.ControlesBase.dtgBase dtgTblNoAuditadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtTablaNoAudit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgChcFlagNoAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtTablaAudit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgChcFlagAudit;
        private System.Windows.Forms.Label label1;
    }
}

