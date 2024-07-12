namespace CAJ.Presentacion
{
    partial class frmConsultaBilHab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaBilHab));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMonTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonMoneda = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMonBillete = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgBilletes = new GEN.ControlesBase.dtgBase(this.components);
            this.idMonedaB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipBillMonB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcionB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgMonedas = new GEN.ControlesBase.dtgBase(this.components);
            this.idMonedaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipBillMonM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcionM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBilletes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonedas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMonTotal
            // 
            this.txtMonTotal.Enabled = false;
            this.txtMonTotal.FormatoDecimal = true;
            this.txtMonTotal.Location = new System.Drawing.Point(439, 234);
            this.txtMonTotal.Name = "txtMonTotal";
            this.txtMonTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonTotal.nNumDecimales = 2;
            this.txtMonTotal.nvalor = 0D;
            this.txtMonTotal.Size = new System.Drawing.Size(124, 20);
            this.txtMonTotal.TabIndex = 34;
            this.txtMonTotal.Text = "0.00";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(328, 238);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(108, 13);
            this.lblBase5.TabIndex = 33;
            this.lblBase5.Text = "Total habilitación:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(78, 215);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(78, 13);
            this.lblBase4.TabIndex = 31;
            this.lblBase4.Text = "Total billete:";
            // 
            // txtMonMoneda
            // 
            this.txtMonMoneda.Enabled = false;
            this.txtMonMoneda.FormatoDecimal = true;
            this.txtMonMoneda.Location = new System.Drawing.Point(439, 211);
            this.txtMonMoneda.Name = "txtMonMoneda";
            this.txtMonMoneda.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonMoneda.nNumDecimales = 2;
            this.txtMonMoneda.nvalor = 0D;
            this.txtMonMoneda.Size = new System.Drawing.Size(124, 20);
            this.txtMonMoneda.TabIndex = 30;
            this.txtMonMoneda.Text = "0.00";
            // 
            // txtMonBillete
            // 
            this.txtMonBillete.Enabled = false;
            this.txtMonBillete.FormatoDecimal = true;
            this.txtMonBillete.Location = new System.Drawing.Point(159, 211);
            this.txtMonBillete.Name = "txtMonBillete";
            this.txtMonBillete.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonBillete.nNumDecimales = 2;
            this.txtMonBillete.nvalor = 0D;
            this.txtMonBillete.Size = new System.Drawing.Size(124, 20);
            this.txtMonBillete.TabIndex = 32;
            this.txtMonBillete.Text = "0.00";
            // 
            // dtgBilletes
            // 
            this.dtgBilletes.AllowUserToAddRows = false;
            this.dtgBilletes.AllowUserToDeleteRows = false;
            this.dtgBilletes.AllowUserToResizeColumns = false;
            this.dtgBilletes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBilletes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBilletes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBilletes.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgBilletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBilletes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMonedaB,
            this.idTipBillMonB,
            this.nValorB,
            this.cDescripcionB,
            this.nCantidadB,
            this.nTotalB});
            this.dtgBilletes.Location = new System.Drawing.Point(12, 9);
            this.dtgBilletes.MultiSelect = false;
            this.dtgBilletes.Name = "dtgBilletes";
            this.dtgBilletes.ReadOnly = true;
            this.dtgBilletes.RowHeadersVisible = false;
            this.dtgBilletes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBilletes.Size = new System.Drawing.Size(273, 201);
            this.dtgBilletes.TabIndex = 28;
            // 
            // idMonedaB
            // 
            this.idMonedaB.DataPropertyName = "idMoneda";
            this.idMonedaB.HeaderText = "idMoneda";
            this.idMonedaB.Name = "idMonedaB";
            this.idMonedaB.ReadOnly = true;
            this.idMonedaB.Visible = false;
            // 
            // idTipBillMonB
            // 
            this.idTipBillMonB.DataPropertyName = "idTipBillMon";
            this.idTipBillMonB.HeaderText = "idTipBillMon";
            this.idTipBillMonB.Name = "idTipBillMonB";
            this.idTipBillMonB.ReadOnly = true;
            this.idTipBillMonB.Visible = false;
            // 
            // nValorB
            // 
            this.nValorB.DataPropertyName = "nValor";
            this.nValorB.HeaderText = "nValor";
            this.nValorB.Name = "nValorB";
            this.nValorB.ReadOnly = true;
            this.nValorB.Visible = false;
            // 
            // cDescripcionB
            // 
            this.cDescripcionB.DataPropertyName = "cDescripcion";
            this.cDescripcionB.FillWeight = 139F;
            this.cDescripcionB.HeaderText = "Descripción";
            this.cDescripcionB.Name = "cDescripcionB";
            this.cDescripcionB.ReadOnly = true;
            // 
            // nCantidadB
            // 
            this.nCantidadB.DataPropertyName = "nCantidad";
            this.nCantidadB.FillWeight = 55.80457F;
            this.nCantidadB.HeaderText = "Cantidad";
            this.nCantidadB.Name = "nCantidadB";
            this.nCantidadB.ReadOnly = true;
            // 
            // nTotalB
            // 
            this.nTotalB.DataPropertyName = "nTotal";
            this.nTotalB.FillWeight = 55.80457F;
            this.nTotalB.HeaderText = "Total";
            this.nTotalB.Name = "nTotalB";
            this.nTotalB.ReadOnly = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(340, 215);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(96, 13);
            this.lblBase1.TabIndex = 35;
            this.lblBase1.Text = "Total monedas:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(503, 259);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 37;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgMonedas
            // 
            this.dtgMonedas.AllowUserToAddRows = false;
            this.dtgMonedas.AllowUserToDeleteRows = false;
            this.dtgMonedas.AllowUserToResizeColumns = false;
            this.dtgMonedas.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMonedas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMonedas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMonedas.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgMonedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMonedas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMonedaM,
            this.idTipBillMonM,
            this.nValorM,
            this.cDescripcionM,
            this.nCantidadM,
            this.nTotalM});
            this.dtgMonedas.Location = new System.Drawing.Point(288, 9);
            this.dtgMonedas.MultiSelect = false;
            this.dtgMonedas.Name = "dtgMonedas";
            this.dtgMonedas.ReadOnly = true;
            this.dtgMonedas.RowHeadersVisible = false;
            this.dtgMonedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMonedas.Size = new System.Drawing.Size(273, 201);
            this.dtgMonedas.TabIndex = 38;
            // 
            // idMonedaM
            // 
            this.idMonedaM.DataPropertyName = "idMoneda";
            this.idMonedaM.HeaderText = "idMoneda";
            this.idMonedaM.MinimumWidth = 134;
            this.idMonedaM.Name = "idMonedaM";
            this.idMonedaM.ReadOnly = true;
            this.idMonedaM.Visible = false;
            // 
            // idTipBillMonM
            // 
            this.idTipBillMonM.DataPropertyName = "idTipBillMon";
            this.idTipBillMonM.HeaderText = "idTipBillMon";
            this.idTipBillMonM.Name = "idTipBillMonM";
            this.idTipBillMonM.ReadOnly = true;
            this.idTipBillMonM.Visible = false;
            // 
            // nValorM
            // 
            this.nValorM.DataPropertyName = "nValor";
            this.nValorM.HeaderText = "nValor";
            this.nValorM.Name = "nValorM";
            this.nValorM.ReadOnly = true;
            this.nValorM.Visible = false;
            // 
            // cDescripcionM
            // 
            this.cDescripcionM.DataPropertyName = "cDescripcion";
            this.cDescripcionM.FillWeight = 118.0229F;
            this.cDescripcionM.HeaderText = "Descripción";
            this.cDescripcionM.Name = "cDescripcionM";
            this.cDescripcionM.ReadOnly = true;
            // 
            // nCantidadM
            // 
            this.nCantidadM.DataPropertyName = "nCantidad";
            this.nCantidadM.FillWeight = 37.86567F;
            this.nCantidadM.HeaderText = "Cantidad";
            this.nCantidadM.Name = "nCantidadM";
            this.nCantidadM.ReadOnly = true;
            // 
            // nTotalM
            // 
            this.nTotalM.DataPropertyName = "nTotal";
            this.nTotalM.FillWeight = 37.86567F;
            this.nTotalM.HeaderText = "Total";
            this.nTotalM.Name = "nTotalM";
            this.nTotalM.ReadOnly = true;
            // 
            // frmConsultaBilHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 334);
            this.Controls.Add(this.dtgMonedas);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtMonTotal);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMonMoneda);
            this.Controls.Add(this.txtMonBillete);
            this.Controls.Add(this.dtgBilletes);
            this.Name = "frmConsultaBilHab";
            this.Text = "Billetaje de habilitaciones";
            this.Load += new System.EventHandler(this.frmConsultaBilHab_Load);
            this.Controls.SetChildIndex(this.dtgBilletes, 0);
            this.Controls.SetChildIndex(this.txtMonBillete, 0);
            this.Controls.SetChildIndex(this.txtMonMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtMonTotal, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgMonedas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBilletes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonedas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtMonTotal;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMonMoneda;
        private GEN.ControlesBase.txtNumRea txtMonBillete;
        private GEN.ControlesBase.dtgBase dtgBilletes;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgMonedas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipBillMonB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorB;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcionB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaM;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipBillMonM;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorM;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcionM;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadM;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalM;
    }
}