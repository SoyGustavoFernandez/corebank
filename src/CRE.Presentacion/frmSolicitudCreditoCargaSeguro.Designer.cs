namespace CRE.Presentacion
{
    partial class frmSolicitudCreditoCargaSeguro
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
            this.conSolicitudCargaSeguros1 = new GEN.ControlesBase.ConSolicitudCargaSeguros();
            this.SuspendLayout();
            // 
            // conSolicitudCargaSeguros1
            // 
            this.conSolicitudCargaSeguros1.Location = new System.Drawing.Point(9, 8);
            this.conSolicitudCargaSeguros1.Name = "conSolicitudCargaSeguros1";
            this.conSolicitudCargaSeguros1.objSolicitudCreditoCargaSeguro = null;
            this.conSolicitudCargaSeguros1.RechazaListaSeguro = false;
            this.conSolicitudCargaSeguros1.Size = new System.Drawing.Size(562, 410);
            this.conSolicitudCargaSeguros1.TabIndex = 18;
            // 
            // frmSolicitudCreditoCargaSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 440);
            this.Controls.Add(this.conSolicitudCargaSeguros1);
            this.Name = "frmSolicitudCreditoCargaSeguro";
            this.Text = "Carga de Seguros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSolicitudCreditoCargaSeguro_FormClosing);
            this.Load += new System.EventHandler(this.frmSolicitudCreditoCargaSeguro_Load);
            this.Controls.SetChildIndex(this.conSolicitudCargaSeguros1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.ControlesBase.ConSolicitudCargaSeguros conSolicitudCargaSeguros1;
    }
}