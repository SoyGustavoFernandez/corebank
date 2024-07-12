namespace CRE.Presentacion
{
    partial class frmHistorialTasacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialTasacion));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgHistorico = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(744, 238);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgHistorico
            // 
            this.dtgHistorico.AllowUserToAddRows = false;
            this.dtgHistorico.AllowUserToDeleteRows = false;
            this.dtgHistorico.AllowUserToResizeColumns = false;
            this.dtgHistorico.AllowUserToResizeRows = false;
            this.dtgHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorico.Location = new System.Drawing.Point(12, 12);
            this.dtgHistorico.MultiSelect = false;
            this.dtgHistorico.Name = "dtgHistorico";
            this.dtgHistorico.ReadOnly = true;
            this.dtgHistorico.RowHeadersVisible = false;
            this.dtgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistorico.Size = new System.Drawing.Size(792, 220);
            this.dtgHistorico.TabIndex = 3;
            // 
            // frmHistorialTasacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 320);
            this.Controls.Add(this.dtgHistorico);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmHistorialTasacion";
            this.Text = "Detalle de Tasación de Garantía";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgHistorico, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgHistorico;
    }
}

