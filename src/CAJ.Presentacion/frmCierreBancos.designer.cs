namespace CAJ.Presentacion
{
    partial class frmCierreBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreBancos));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcPeriodoActual = new GEN.ControlesBase.chcBase(this.components);
            this.lblMsje = new System.Windows.Forms.Label();
            this.cboPeriodProc = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecCierre = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.dtgDatCierreBcos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatCierreBcos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(511, 291);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcPeriodoActual);
            this.grbBase1.Controls.Add(this.lblMsje);
            this.grbBase1.Controls.Add(this.cboPeriodProc);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFecCierre);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(13, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(558, 81);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            // 
            // chcPeriodoActual
            // 
            this.chcPeriodoActual.AutoSize = true;
            this.chcPeriodoActual.Location = new System.Drawing.Point(9, 58);
            this.chcPeriodoActual.Name = "chcPeriodoActual";
            this.chcPeriodoActual.Size = new System.Drawing.Size(95, 17);
            this.chcPeriodoActual.TabIndex = 5;
            this.chcPeriodoActual.Text = "Periodo Actual";
            this.chcPeriodoActual.UseVisualStyleBackColor = true;
            this.chcPeriodoActual.CheckedChanged += new System.EventHandler(this.chcPeriodoActual_CheckedChanged);
            // 
            // lblMsje
            // 
            this.lblMsje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsje.ForeColor = System.Drawing.Color.Red;
            this.lblMsje.Location = new System.Drawing.Point(279, 16);
            this.lblMsje.Name = "lblMsje";
            this.lblMsje.Size = new System.Drawing.Size(273, 42);
            this.lblMsje.TabIndex = 4;
            this.lblMsje.Text = "label1";
            this.lblMsje.Visible = false;
            // 
            // cboPeriodProc
            // 
            this.cboPeriodProc.FormattingEnabled = true;
            this.cboPeriodProc.Location = new System.Drawing.Point(142, 31);
            this.cboPeriodProc.Name = "cboPeriodProc";
            this.cboPeriodProc.Size = new System.Drawing.Size(113, 21);
            this.cboPeriodProc.TabIndex = 3;
            this.cboPeriodProc.SelectedIndexChanged += new System.EventHandler(this.cboPeriodProc_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(139, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(116, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Meses Procesados:";
            // 
            // dtpFecCierre
            // 
            this.dtpFecCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecCierre.Location = new System.Drawing.Point(9, 32);
            this.dtpFecCierre.Name = "dtpFecCierre";
            this.dtpFecCierre.Size = new System.Drawing.Size(97, 20);
            this.dtpFecCierre.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(85, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Cierre:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(445, 291);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dtgDatCierreBcos
            // 
            this.dtgDatCierreBcos.AllowUserToAddRows = false;
            this.dtgDatCierreBcos.AllowUserToDeleteRows = false;
            this.dtgDatCierreBcos.AllowUserToResizeColumns = false;
            this.dtgDatCierreBcos.AllowUserToResizeRows = false;
            this.dtgDatCierreBcos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatCierreBcos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatCierreBcos.Location = new System.Drawing.Point(13, 91);
            this.dtgDatCierreBcos.MultiSelect = false;
            this.dtgDatCierreBcos.Name = "dtgDatCierreBcos";
            this.dtgDatCierreBcos.ReadOnly = true;
            this.dtgDatCierreBcos.RowHeadersVisible = false;
            this.dtgDatCierreBcos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatCierreBcos.Size = new System.Drawing.Size(558, 194);
            this.dtgDatCierreBcos.TabIndex = 7;
            // 
            // frmCierreBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 370);
            this.Controls.Add(this.dtgDatCierreBcos);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmCierreBancos";
            this.Text = "Cierre Bancos";
            this.Load += new System.EventHandler(this.frmCierreBancos_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.dtgDatCierreBcos, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatCierreBcos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecCierre;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.ControlesBase.dtgBase dtgDatCierreBcos;
        private System.Windows.Forms.Label lblMsje;
        private GEN.ControlesBase.cboBase cboPeriodProc;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chcBase chcPeriodoActual;
    }
}