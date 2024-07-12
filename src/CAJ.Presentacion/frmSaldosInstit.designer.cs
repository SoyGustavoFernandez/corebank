namespace CAJ.Presentacion
{
    partial class frmSaldosInstit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaldosInstit));
            this.dtgSaldoIntit = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnImprimirLibro = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSaldoIntit)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgSaldoIntit
            // 
            this.dtgSaldoIntit.AllowUserToAddRows = false;
            this.dtgSaldoIntit.AllowUserToDeleteRows = false;
            this.dtgSaldoIntit.AllowUserToResizeColumns = false;
            this.dtgSaldoIntit.AllowUserToResizeRows = false;
            this.dtgSaldoIntit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSaldoIntit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSaldoIntit.Location = new System.Drawing.Point(9, 67);
            this.dtgSaldoIntit.MultiSelect = false;
            this.dtgSaldoIntit.Name = "dtgSaldoIntit";
            this.dtgSaldoIntit.ReadOnly = true;
            this.dtgSaldoIntit.RowHeadersVisible = false;
            this.dtgSaldoIntit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSaldoIntit.Size = new System.Drawing.Size(427, 172);
            this.dtgSaldoIntit.TabIndex = 63;
            this.dtgSaldoIntit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSaldoIntit_CellClick);
            this.dtgSaldoIntit.SelectionChanged += new System.EventHandler(this.dtgSaldoIntit_SelectionChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(376, 245);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 62;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(361, 10);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 61;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(142, 19);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(138, 20);
            this.dtpFechaSis.TabIndex = 59;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(26, 22);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(112, 13);
            this.lblBase8.TabIndex = 60;
            this.lblBase8.Text = "Fecha de Proceso:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnProcesar);
            this.grbBase1.Location = new System.Drawing.Point(9, -5);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(427, 64);
            this.grbBase1.TabIndex = 64;
            this.grbBase1.TabStop = false;
            // 
            // btnImprimirLibro
            // 
            this.btnImprimirLibro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirLibro.BackgroundImage")));
            this.btnImprimirLibro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirLibro.Enabled = false;
            this.btnImprimirLibro.Location = new System.Drawing.Point(310, 245);
            this.btnImprimirLibro.Name = "btnImprimirLibro";
            this.btnImprimirLibro.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirLibro.TabIndex = 114;
            this.btnImprimirLibro.Text = "Imprimir Libro";
            this.btnImprimirLibro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirLibro.UseVisualStyleBackColor = true;
            this.btnImprimirLibro.Click += new System.EventHandler(this.btnImprimirLibro_Click);
            // 
            // frmSaldosInstit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 320);
            this.Controls.Add(this.btnImprimirLibro);
            this.Controls.Add(this.dtgSaldoIntit);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFechaSis);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmSaldosInstit";
            this.Text = "Saldo Institucional";
            this.Load += new System.EventHandler(this.frmSaldosInstit_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.dtpFechaSis, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgSaldoIntit, 0);
            this.Controls.SetChildIndex(this.btnImprimirLibro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSaldoIntit)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgSaldoIntit;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnImprimir btnImprimirLibro;
    }
}