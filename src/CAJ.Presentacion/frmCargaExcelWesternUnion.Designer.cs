namespace CAJ.Presentacion
{
    partial class frmCargaExcelWesternUnion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaExcelWesternUnion));
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgExcelWesternUnion = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcelWesternUnion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(536, 248);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 2;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(469, 248);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgExcelWesternUnion
            // 
            this.dtgExcelWesternUnion.AllowUserToAddRows = false;
            this.dtgExcelWesternUnion.AllowUserToDeleteRows = false;
            this.dtgExcelWesternUnion.AllowUserToResizeColumns = false;
            this.dtgExcelWesternUnion.AllowUserToResizeRows = false;
            this.dtgExcelWesternUnion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgExcelWesternUnion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExcelWesternUnion.Location = new System.Drawing.Point(12, 12);
            this.dtgExcelWesternUnion.MultiSelect = false;
            this.dtgExcelWesternUnion.Name = "dtgExcelWesternUnion";
            this.dtgExcelWesternUnion.ReadOnly = true;
            this.dtgExcelWesternUnion.RowHeadersVisible = false;
            this.dtgExcelWesternUnion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcelWesternUnion.Size = new System.Drawing.Size(584, 230);
            this.dtgExcelWesternUnion.TabIndex = 4;
            // 
            // frmCargaExcelWesternUnion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 325);
            this.Controls.Add(this.dtgExcelWesternUnion);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnProcesar1);
            this.Name = "frmCargaExcelWesternUnion";
            this.Text = "Carga de Excel Western Union";
            this.Load += new System.EventHandler(this.frmCargaExcelWesternUnion_Load);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgExcelWesternUnion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcelWesternUnion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgExcelWesternUnion;
    }
}