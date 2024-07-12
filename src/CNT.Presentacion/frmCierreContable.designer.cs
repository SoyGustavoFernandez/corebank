namespace CNT.Presentacion
{
    partial class frmCierreContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreContable));
            this.cboMeses1 = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtAnioCNT = new GEN.ControlesBase.txtBase(this.components);
            this.dtgProcesos = new GEN.ControlesBase.dtgBase(this.components);
            this.idProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOrdenEjecucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStoreProc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcesos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMeses1
            // 
            this.cboMeses1.Enabled = false;
            this.cboMeses1.FormattingEnabled = true;
            this.cboMeses1.Location = new System.Drawing.Point(132, 53);
            this.cboMeses1.Name = "cboMeses1";
            this.cboMeses1.Size = new System.Drawing.Size(133, 21);
            this.cboMeses1.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(92, 57);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Mes:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(92, 25);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Año:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(219, 258);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 6;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(285, 258);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtAnioCNT
            // 
            this.txtAnioCNT.Enabled = false;
            this.txtAnioCNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnioCNT.Location = new System.Drawing.Point(132, 22);
            this.txtAnioCNT.Name = "txtAnioCNT";
            this.txtAnioCNT.Size = new System.Drawing.Size(88, 26);
            this.txtAnioCNT.TabIndex = 8;
            this.txtAnioCNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtgProcesos
            // 
            this.dtgProcesos.AllowUserToAddRows = false;
            this.dtgProcesos.AllowUserToDeleteRows = false;
            this.dtgProcesos.AllowUserToResizeColumns = false;
            this.dtgProcesos.AllowUserToResizeRows = false;
            this.dtgProcesos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProceso,
            this.nOrdenEjecucion,
            this.cProceso,
            this.cStoreProc,
            this.lEstado});
            this.dtgProcesos.Location = new System.Drawing.Point(12, 92);
            this.dtgProcesos.MultiSelect = false;
            this.dtgProcesos.Name = "dtgProcesos";
            this.dtgProcesos.ReadOnly = true;
            this.dtgProcesos.RowHeadersVisible = false;
            this.dtgProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcesos.Size = new System.Drawing.Size(333, 150);
            this.dtgProcesos.TabIndex = 9;
            // 
            // idProceso
            // 
            this.idProceso.DataPropertyName = "idProceso";
            this.idProceso.HeaderText = "idProceso";
            this.idProceso.Name = "idProceso";
            this.idProceso.ReadOnly = true;
            this.idProceso.Visible = false;
            // 
            // nOrdenEjecucion
            // 
            this.nOrdenEjecucion.DataPropertyName = "nOrdenEjecucion";
            this.nOrdenEjecucion.HeaderText = "nOrdenEjecucion";
            this.nOrdenEjecucion.Name = "nOrdenEjecucion";
            this.nOrdenEjecucion.ReadOnly = true;
            this.nOrdenEjecucion.Visible = false;
            // 
            // cProceso
            // 
            this.cProceso.DataPropertyName = "cProceso";
            this.cProceso.FillWeight = 179.6954F;
            this.cProceso.HeaderText = "Proceso";
            this.cProceso.Name = "cProceso";
            this.cProceso.ReadOnly = true;
            // 
            // cStoreProc
            // 
            this.cStoreProc.DataPropertyName = "cStoreProc";
            this.cStoreProc.HeaderText = "cStoreProc";
            this.cStoreProc.Name = "cStoreProc";
            this.cStoreProc.ReadOnly = true;
            this.cStoreProc.Visible = false;
            // 
            // lEstado
            // 
            this.lEstado.DataPropertyName = "lEstado";
            this.lEstado.FillWeight = 20.30457F;
            this.lEstado.HeaderText = "Est";
            this.lEstado.Name = "lEstado";
            this.lEstado.ReadOnly = true;
            // 
            // frmCierreContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 335);
            this.Controls.Add(this.dtgProcesos);
            this.Controls.Add(this.txtAnioCNT);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboMeses1);
            this.Name = "frmCierreContable";
            this.Text = "Cierre contable";
            this.Load += new System.EventHandler(this.frmCierreContable_Load);
            this.Controls.SetChildIndex(this.cboMeses1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtAnioCNT, 0);
            this.Controls.SetChildIndex(this.dtgProcesos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcesos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboMeses cboMeses1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtAnioCNT;
        private GEN.ControlesBase.dtgBase dtgProcesos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOrdenEjecucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStoreProc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lEstado;
    }
}