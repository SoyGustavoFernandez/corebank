namespace GEN.ControlesBase
{
    partial class ConSemaforoLimOpe
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
            this.pnlContSem = new System.Windows.Forms.Panel();
            this.lblVal = new GEN.ControlesBase.lblBase();
            this.conCirculoSemaforo = new GEN.ControlesBase.ConCirculoSemaforo();
            this.lblNombre = new GEN.ControlesBase.lblBase();
            this.pnlContSem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContSem
            // 
            this.pnlContSem.Controls.Add(this.lblVal);
            this.pnlContSem.Controls.Add(this.conCirculoSemaforo);
            this.pnlContSem.Controls.Add(this.lblNombre);
            this.pnlContSem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContSem.Location = new System.Drawing.Point(0, 0);
            this.pnlContSem.Name = "pnlContSem";
            this.pnlContSem.Size = new System.Drawing.Size(261, 36);
            this.pnlContSem.TabIndex = 0;
            // 
            // lblVal
            // 
            this.lblVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVal.AutoSize = true;
            this.lblVal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblVal.ForeColor = System.Drawing.Color.Navy;
            this.lblVal.Location = new System.Drawing.Point(214, 12);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(44, 13);
            this.lblVal.TabIndex = 2;
            this.lblVal.Text = "0.00%";
            // 
            // conCirculoSemaforo
            // 
            this.conCirculoSemaforo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.conCirculoSemaforo.Color = System.Drawing.Color.Green;
            this.conCirculoSemaforo.Location = new System.Drawing.Point(183, 3);
            this.conCirculoSemaforo.Name = "conCirculoSemaforo";
            this.conCirculoSemaforo.Size = new System.Drawing.Size(30, 30);
            this.conCirculoSemaforo.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombre.ForeColor = System.Drawing.Color.Navy;
            this.lblNombre.Location = new System.Drawing.Point(8, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "NombreLimite";
            // 
            // ConSemaforoLimOpe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContSem);
            this.Name = "ConSemaforoLimOpe";
            this.Size = new System.Drawing.Size(261, 36);
            this.pnlContSem.ResumeLayout(false);
            this.pnlContSem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContSem;
        private lblBase lblNombre;
        private ConCirculoSemaforo conCirculoSemaforo;
        private lblBase lblVal;
    }
}
