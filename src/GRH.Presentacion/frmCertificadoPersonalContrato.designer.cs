namespace GRH.Presentacion
{
    partial class frmCertificadoPersonalContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCertificadoPersonalContrato));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprFondo = new GEN.BotonesBase.btnImprimir();
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.conBusCol1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(216, 96);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprFondo
            // 
            this.btnImprFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprFondo.BackgroundImage")));
            this.btnImprFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprFondo.Location = new System.Drawing.Point(150, 97);
            this.btnImprFondo.Name = "btnImprFondo";
            this.btnImprFondo.Size = new System.Drawing.Size(60, 50);
            this.btnImprFondo.TabIndex = 2;
            this.btnImprFondo.Text = "&Imprimir";
            this.btnImprFondo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprFondo.UseVisualStyleBackColor = true;
            this.btnImprFondo.Click += new System.EventHandler(this.btnImprFondo_Click);
            // 
            // conBusCol1
            // 
            this.conBusCol1.Controls.Add(this.grbBase1);
            this.conBusCol1.Location = new System.Drawing.Point(7, 4);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(389, 86);
            this.conBusCol1.TabIndex = 119;
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(387, 86);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Colaborador";
            // 
            // frmCertificadoPersonalContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 180);
            this.Controls.Add(this.conBusCol1);
            this.Controls.Add(this.btnImprFondo);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmCertificadoPersonalContrato";
            this.Text = "Certificados";
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprFondo, 0);
            this.Controls.SetChildIndex(this.conBusCol1, 0);
            this.conBusCol1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprFondo;
        private GEN.ControlesBase.ConBusCol conBusCol1;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}