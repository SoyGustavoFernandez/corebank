namespace GEN.ControlesBase
{
    partial class frmDetalleOtrosGastos
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
            this.dtgDetalleGastos = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleGastos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDetalleGastos
            // 
            this.dtgDetalleGastos.AllowUserToAddRows = false;
            this.dtgDetalleGastos.AllowUserToDeleteRows = false;
            this.dtgDetalleGastos.AllowUserToResizeColumns = false;
            this.dtgDetalleGastos.AllowUserToResizeRows = false;
            this.dtgDetalleGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleGastos.Location = new System.Drawing.Point(18, 12);
            this.dtgDetalleGastos.MultiSelect = false;
            this.dtgDetalleGastos.Name = "dtgDetalleGastos";
            this.dtgDetalleGastos.ReadOnly = true;
            this.dtgDetalleGastos.RowHeadersVisible = false;
            this.dtgDetalleGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleGastos.Size = new System.Drawing.Size(480, 354);
            this.dtgDetalleGastos.TabIndex = 0;
            // 
            // frmDetalleOtrosGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 392);
            this.Controls.Add(this.dtgDetalleGastos);
            this.Name = "frmDetalleOtrosGastos";
            this.Text = "Detalle de Gastos";
            this.Controls.SetChildIndex(this.dtgDetalleGastos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleGastos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public dtgBase dtgDetalleGastos;
    }
}