namespace GEN.ControlesBase
{
    partial class conCalcVuelto
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
            this.txtMonDiferencia = new GEN.ControlesBase.txtNumRea();
            this.txtMonEfectivo = new GEN.ControlesBase.txtNumRea();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // txtMonDiferencia
            // 
            this.txtMonDiferencia.Enabled = false;
            this.txtMonDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonDiferencia.FormatoDecimal = false;
            this.txtMonDiferencia.Location = new System.Drawing.Point(81, 35);
            this.txtMonDiferencia.Name = "txtMonDiferencia";
            this.txtMonDiferencia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonDiferencia.nNumDecimales = 2;
            this.txtMonDiferencia.nvalor = 0D;
            this.txtMonDiferencia.Size = new System.Drawing.Size(100, 20);
            this.txtMonDiferencia.TabIndex = 3;
            this.txtMonDiferencia.Text = "0.00";
            this.txtMonDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMonEfectivo
            // 
            this.txtMonEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonEfectivo.FormatoDecimal = false;
            this.txtMonEfectivo.Location = new System.Drawing.Point(81, 9);
            this.txtMonEfectivo.Name = "txtMonEfectivo";
            this.txtMonEfectivo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonEfectivo.nNumDecimales = 2;
            this.txtMonEfectivo.nvalor = 0D;
            this.txtMonEfectivo.Size = new System.Drawing.Size(100, 20);
            this.txtMonEfectivo.TabIndex = 2;
            this.txtMonEfectivo.Text = "0.00";
            this.txtMonEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonEfectivo.TextChanged += new System.EventHandler(this.txtNumRea1_TextChanged);
            this.txtMonEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonEfectivo_KeyPress);
            this.txtMonEfectivo.Leave += new System.EventHandler(this.txtMonEfectivo_Leave);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 39);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "VUELTO:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(72, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "RECIBIDO:";
            // 
            // conCalcVuelto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMonDiferencia);
            this.Controls.Add(this.txtMonEfectivo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "conCalcVuelto";
            this.Size = new System.Drawing.Size(192, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private lblBase lblBase2;
        public txtNumRea txtMonEfectivo;
        public txtNumRea txtMonDiferencia;
    }
}
