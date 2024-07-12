namespace GEN.ControlesBase
{
    partial class conNroTarjeta
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtBind = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtProd = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNroTarj = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.SuspendLayout();
            // 
            // txtBind
            // 
            this.txtBind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBind.Location = new System.Drawing.Point(0, 0);
            this.txtBind.MaxLength = 6;
            this.txtBind.Name = "txtBind";
            this.txtBind.Size = new System.Drawing.Size(56, 23);
            this.txtBind.TabIndex = 0;
            // 
            // txtProd
            // 
            this.txtProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProd.Location = new System.Drawing.Point(57, 0);
            this.txtProd.MaxLength = 2;
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(23, 23);
            this.txtProd.TabIndex = 1;
            // 
            // txtNroTarj
            // 
            this.txtNroTarj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroTarj.Location = new System.Drawing.Point(81, 0);
            this.txtNroTarj.MaxLength = 8;
            this.txtNroTarj.Name = "txtNroTarj";
            this.txtNroTarj.Size = new System.Drawing.Size(72, 23);
            this.txtNroTarj.TabIndex = 2;
            this.txtNroTarj.TextChanged += new System.EventHandler(this.txtNroTarj_TextChanged);
            // 
            // conNroTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNroTarj);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.txtBind);
            this.Name = "conNroTarjeta";
            this.Size = new System.Drawing.Size(153, 23);
            this.Load += new System.EventHandler(this.conNroTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public txtCBNumerosEnteros txtBind;
        public txtCBNumerosEnteros txtProd;
        public txtCBNumerosEnteros txtNroTarj;
    }
}
