namespace GEN.ControlesBase
{
    partial class conPopUpVoucher
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblVoucher = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.SuspendLayout();
            // 
            // lblVoucher
            // 
            this.lblVoucher.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucher.ForeColor = System.Drawing.Color.Black;
            this.lblVoucher.Location = new System.Drawing.Point(3, 6);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(340, 485);
            this.lblVoucher.TabIndex = 0;
            this.lblVoucher.Text = "Contenido Voucher";
            // 
            // conPopUpVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblVoucher);
            this.Name = "conPopUpVoucher";
            this.Size = new System.Drawing.Size(350, 500);
            this.Load += new System.EventHandler(this.conPopUpVoucher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private lblBaseCustom lblVoucher;
    }
}
