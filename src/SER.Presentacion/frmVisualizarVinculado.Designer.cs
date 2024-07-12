namespace SER.Presentacion
{
    partial class frmVisualizarVinculado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarVinculado));
            this.dtgVinculados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVinculados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVinculados
            // 
            this.dtgVinculados.AllowUserToAddRows = false;
            this.dtgVinculados.AllowUserToDeleteRows = false;
            this.dtgVinculados.AllowUserToResizeColumns = false;
            this.dtgVinculados.AllowUserToResizeRows = false;
            this.dtgVinculados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVinculados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVinculados.Location = new System.Drawing.Point(12, 12);
            this.dtgVinculados.MultiSelect = false;
            this.dtgVinculados.Name = "dtgVinculados";
            this.dtgVinculados.ReadOnly = true;
            this.dtgVinculados.RowHeadersVisible = false;
            this.dtgVinculados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVinculados.Size = new System.Drawing.Size(488, 125);
            this.dtgVinculados.TabIndex = 5;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(440, 143);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmVisualizarVinculado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 220);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgVinculados);
            this.Name = "frmVisualizarVinculado";
            this.Text = "Vinculados";
            this.Load += new System.EventHandler(this.frmVisualizarVinculado_Load);
            this.Controls.SetChildIndex(this.dtgVinculados, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVinculados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgVinculados;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}