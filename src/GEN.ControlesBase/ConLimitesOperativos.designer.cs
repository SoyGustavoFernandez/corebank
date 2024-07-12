namespace GEN.ControlesBase
{
    partial class ConLimitesOperativos
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpControles = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpControles
            // 
            this.flpControles.AutoScroll = true;
            this.flpControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpControles.Location = new System.Drawing.Point(0, 0);
            this.flpControles.Name = "flpControles";
            this.flpControles.Size = new System.Drawing.Size(172, 265);
            this.flpControles.TabIndex = 0;
            // 
            // ConLimitesOperativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flpControles);
            this.Name = "ConLimitesOperativos";
            this.Size = new System.Drawing.Size(172, 265);
            this.Load += new System.EventHandler(this.ConLimitesOperativos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpControles;


    }
}
