namespace CRE.Presentacion
{
    partial class FrmActaAprobCredNivel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActaAprobCredNivel));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnImpActaCredito = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgSolicitudes);
            this.grbBase2.Location = new System.Drawing.Point(9, 67);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(531, 196);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Resultados";
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSolicitudes.Location = new System.Drawing.Point(3, 16);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(525, 177);
            this.dtgSolicitudes.TabIndex = 0;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniBusq);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(9, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(531, 49);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros";
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(471, 17);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 4;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(278, 21);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(111, 20);
            this.dtpFecFin.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(228, 25);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Hasta:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(80, 21);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(111, 20);
            this.dtpFecIni.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(43, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(31, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Del:";
            // 
            // btnImpActaCredito
            // 
            this.btnImpActaCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpActaCredito.BackgroundImage")));
            this.btnImpActaCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpActaCredito.Location = new System.Drawing.Point(414, 269);
            this.btnImpActaCredito.Name = "btnImpActaCredito";
            this.btnImpActaCredito.Size = new System.Drawing.Size(60, 50);
            this.btnImpActaCredito.TabIndex = 12;
            this.btnImpActaCredito.Text = "Acta credito";
            this.btnImpActaCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpActaCredito.UseVisualStyleBackColor = true;
            this.btnImpActaCredito.Click += new System.EventHandler(this.btnImpActaCredito_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(480, 269);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // FrmActaAprobCredNivel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 354);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImpActaCredito);
            this.Controls.Add(this.btnSalir1);
            this.Name = "FrmActaAprobCredNivel";
            this.Text = "frmActaAprobCredNivel";
            this.Load += new System.EventHandler(this.FrmActaAprobCredNivel_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImpActaCredito, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnImprimir btnImpActaCredito;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}