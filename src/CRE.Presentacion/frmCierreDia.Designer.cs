namespace CRE.Presentacion
{
    partial class frmCierreDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreDia));
            this.dtgLisProCierre = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblFechaSistema = new System.Windows.Forms.Label();
            this.lblTotalProcesos = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisProCierre)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgLisProCierre
            // 
            this.dtgLisProCierre.AllowUserToAddRows = false;
            this.dtgLisProCierre.AllowUserToDeleteRows = false;
            this.dtgLisProCierre.AllowUserToResizeColumns = false;
            this.dtgLisProCierre.AllowUserToResizeRows = false;
            this.dtgLisProCierre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLisProCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLisProCierre.Location = new System.Drawing.Point(6, 52);
            this.dtgLisProCierre.MultiSelect = false;
            this.dtgLisProCierre.Name = "dtgLisProCierre";
            this.dtgLisProCierre.ReadOnly = true;
            this.dtgLisProCierre.RowHeadersVisible = false;
            this.dtgLisProCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLisProCierre.Size = new System.Drawing.Size(568, 415);
            this.dtgLisProCierre.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(182, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(219, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Proceso de Cierre Diario del Sistema";
            // 
            // lblFechaSistema
            // 
            this.lblFechaSistema.AutoSize = true;
            this.lblFechaSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFechaSistema.Location = new System.Drawing.Point(169, 29);
            this.lblFechaSistema.Name = "lblFechaSistema";
            this.lblFechaSistema.Size = new System.Drawing.Size(57, 20);
            this.lblFechaSistema.TabIndex = 4;
            this.lblFechaSistema.Text = "label1";
            // 
            // lblTotalProcesos
            // 
            this.lblTotalProcesos.AutoSize = true;
            this.lblTotalProcesos.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTotalProcesos.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalProcesos.Location = new System.Drawing.Point(3, 482);
            this.lblTotalProcesos.Name = "lblTotalProcesos";
            this.lblTotalProcesos.Size = new System.Drawing.Size(94, 13);
            this.lblTotalProcesos.TabIndex = 3;
            this.lblTotalProcesos.Text = "Total Procesos:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(514, 473);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(448, 473);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 5;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // frmCierreDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 548);
            this.Controls.Add(this.dtgLisProCierre);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblFechaSistema);
            this.Controls.Add(this.lblTotalProcesos);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmCierreDia";
            this.Text = "Cierre Diario";
            this.Load += new System.EventHandler(this.frmCierreDia_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblTotalProcesos, 0);
            this.Controls.SetChildIndex(this.lblFechaSistema, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgLisProCierre, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisProCierre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgLisProCierre;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.Label lblFechaSistema;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblTotalProcesos;
    }
}