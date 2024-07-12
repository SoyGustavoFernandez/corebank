namespace RPT.Presentacion
{
    partial class frmCargaExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaExcel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.txtArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgDatoExl = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImportar1 = new GEN.BotonesBase.btnImportar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.cCtaCtb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipIns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecNeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecLiq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCosTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cClaRie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmpCla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoExl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackColor = System.Drawing.SystemColors.Control;
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(654, 43);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 1;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = false;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Enabled = false;
            this.txtArchivo.Location = new System.Drawing.Point(128, 43);
            this.txtArchivo.Multiline = true;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(520, 42);
            this.txtArchivo.TabIndex = 26;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(119, 13);
            this.lblBase2.TabIndex = 27;
            this.lblBase2.Text = "Archivo a exportar:";
            // 
            // dtgDatoExl
            // 
            this.dtgDatoExl.AllowUserToAddRows = false;
            this.dtgDatoExl.AllowUserToDeleteRows = false;
            this.dtgDatoExl.AllowUserToResizeColumns = false;
            this.dtgDatoExl.AllowUserToResizeRows = false;
            this.dtgDatoExl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDatoExl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDatoExl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatoExl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCtaCtb,
            this.cTipIns,
            this.cEmisor,
            this.dFecNeg,
            this.dFecLiq,
            this.nCosTot,
            this.cClaRie,
            this.cEmpCla});
            this.dtgDatoExl.Location = new System.Drawing.Point(12, 99);
            this.dtgDatoExl.MultiSelect = false;
            this.dtgDatoExl.Name = "dtgDatoExl";
            this.dtgDatoExl.ReadOnly = true;
            this.dtgDatoExl.RowHeadersVisible = false;
            this.dtgDatoExl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatoExl.Size = new System.Drawing.Size(702, 202);
            this.dtgDatoExl.TabIndex = 28;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(654, 310);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // btnImportar1
            // 
            this.btnImportar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar1.BackgroundImage")));
            this.btnImportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar1.Location = new System.Drawing.Point(588, 310);
            this.btnImportar1.Name = "btnImportar1";
            this.btnImportar1.Size = new System.Drawing.Size(60, 50);
            this.btnImportar1.TabIndex = 2;
            this.btnImportar1.Text = "&Importar";
            this.btnImportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar1.UseVisualStyleBackColor = false;
            this.btnImportar1.Click += new System.EventHandler(this.btnImportar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 31;
            this.lblBase1.Text = "Fecha Proceso:";
            // 
            // dtpFecProceso
            // 
            this.dtpFecProceso.Location = new System.Drawing.Point(128, 15);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(114, 20);
            this.dtpFecProceso.TabIndex = 0;
            // 
            // cCtaCtb
            // 
            this.cCtaCtb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cCtaCtb.DataPropertyName = "cCtaCtb";
            this.cCtaCtb.HeaderText = "Cuenta Contable";
            this.cCtaCtb.Name = "cCtaCtb";
            this.cCtaCtb.ReadOnly = true;
            this.cCtaCtb.Width = 102;
            // 
            // cTipIns
            // 
            this.cTipIns.DataPropertyName = "cTipIns";
            this.cTipIns.HeaderText = "Tipo de Instrumento";
            this.cTipIns.Name = "cTipIns";
            this.cTipIns.ReadOnly = true;
            this.cTipIns.Width = 115;
            // 
            // cEmisor
            // 
            this.cEmisor.DataPropertyName = "cEmisor";
            this.cEmisor.HeaderText = "Emisor";
            this.cEmisor.Name = "cEmisor";
            this.cEmisor.ReadOnly = true;
            this.cEmisor.Width = 63;
            // 
            // dFecNeg
            // 
            this.dFecNeg.DataPropertyName = "dFecNeg";
            this.dFecNeg.HeaderText = "Fecha de Negociación";
            this.dFecNeg.Name = "dFecNeg";
            this.dFecNeg.ReadOnly = true;
            this.dFecNeg.Width = 128;
            // 
            // dFecLiq
            // 
            this.dFecLiq.DataPropertyName = "dFecLiq";
            this.dFecLiq.HeaderText = "Fecha de Liquidación";
            this.dFecLiq.Name = "dFecLiq";
            this.dFecLiq.ReadOnly = true;
            this.dFecLiq.Width = 123;
            // 
            // nCosTot
            // 
            this.nCosTot.DataPropertyName = "nCosTot";
            this.nCosTot.HeaderText = "Costo Total (en MN)";
            this.nCosTot.Name = "nCosTot";
            this.nCosTot.ReadOnly = true;
            this.nCosTot.Width = 98;
            // 
            // cClaRie
            // 
            this.cClaRie.DataPropertyName = "cClaRie";
            this.cClaRie.HeaderText = "Clasificación de Riesgo";
            this.cClaRie.Name = "cClaRie";
            this.cClaRie.ReadOnly = true;
            // 
            // cEmpCla
            // 
            this.cEmpCla.DataPropertyName = "cEmpCla";
            this.cEmpCla.HeaderText = "Empresa Clasificadora de Riesgo";
            this.cEmpCla.Name = "cEmpCla";
            this.cEmpCla.ReadOnly = true;
            this.cEmpCla.Width = 141;
            // 
            // frmCargaExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 392);
            this.Controls.Add(this.dtpFecProceso);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnImportar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgDatoExl);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnExporExcel1);
            this.Name = "frmCargaExcel";
            this.Text = "Importar datos Anexo 01 A";
            this.Load += new System.EventHandler(this.frmCargaExcel_Load);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtArchivo, 0);
            this.Controls.SetChildIndex(this.dtgDatoExl, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImportar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFecProceso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoExl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.ControlesBase.txtBase txtArchivo;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgDatoExl;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImportar btnImportar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtaCtb;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipIns;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecNeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecLiq;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCosTot;
        private System.Windows.Forms.DataGridViewTextBoxColumn cClaRie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmpCla;
    }
}