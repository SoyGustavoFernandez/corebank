namespace CRE.Presentacion
{
    partial class frmDocumentosCreditosObs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentosCreditosObs));
            this.dtgListaSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaSolicitudes
            // 
            this.dtgListaSolicitudes.AllowUserToAddRows = false;
            this.dtgListaSolicitudes.AllowUserToDeleteRows = false;
            this.dtgListaSolicitudes.AllowUserToResizeColumns = false;
            this.dtgListaSolicitudes.AllowUserToResizeRows = false;
            this.dtgListaSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaSolicitudes.Location = new System.Drawing.Point(13, 13);
            this.dtgListaSolicitudes.MultiSelect = false;
            this.dtgListaSolicitudes.Name = "dtgListaSolicitudes";
            this.dtgListaSolicitudes.ReadOnly = true;
            this.dtgListaSolicitudes.RowHeadersVisible = false;
            this.dtgListaSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaSolicitudes.Size = new System.Drawing.Size(249, 150);
            this.dtgListaSolicitudes.TabIndex = 4;
            this.dtgListaSolicitudes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaSolicitudes_CellClick);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(281, 12);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // frmDocumentosCreditosObs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 191);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgListaSolicitudes);
            this.Name = "frmDocumentosCreditosObs";
            this.Text = "Documentos de Créditos Observados";
            this.Load += new System.EventHandler(this.frmDocumentosCreditosObs_Load);
            this.Controls.SetChildIndex(this.dtgListaSolicitudes, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgListaSolicitudes;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}