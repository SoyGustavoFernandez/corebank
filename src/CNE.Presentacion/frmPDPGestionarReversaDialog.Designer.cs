namespace CNE.Presentacion
{
    partial class frmPDPGestionarReversaDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDPGestionarReversaDialog));
            this.txtMensaje = new GEN.ControlesBase.txtBase(this.components);
            this.lblMensaje = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.SuspendLayout();
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(73, 12);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(262, 147);
            this.txtMensaje.TabIndex = 2;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Navy;
            this.lblMensaje.Location = new System.Drawing.Point(13, 14);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(54, 13);
            this.lblMensaje.TabIndex = 3;
            this.lblMensaje.Text = "Mensaje";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(296, 165);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(230, 165);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmPDPGestionarReversaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 247);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.txtMensaje);
            this.Name = "frmPDPGestionarReversaDialog";
            this.Text = "frmPDPGestionarReversaDetalle";
            this.Controls.SetChildIndex(this.txtMensaje, 0);
            this.Controls.SetChildIndex(this.lblMensaje, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtMensaje;
        private GEN.ControlesBase.lblBase lblMensaje;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
    }
}