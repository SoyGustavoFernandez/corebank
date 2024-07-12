namespace GEN.Servicio
{
    partial class frmSolicitudExcepcionSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudExcepcionSMS));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMotivoExcepcionSMS = new GEN.ControlesBase.cboBase(this.components);
            this.txtSustentoExcepcionSMS = new GEN.ControlesBase.txtBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnBlanco();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Motivo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 79);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(79, 26);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Sustento de \r\nExcepción:";
            // 
            // cboMotivoExcepcionSMS
            // 
            this.cboMotivoExcepcionSMS.FormattingEnabled = true;
            this.cboMotivoExcepcionSMS.Location = new System.Drawing.Point(92, 25);
            this.cboMotivoExcepcionSMS.Name = "cboMotivoExcepcionSMS";
            this.cboMotivoExcepcionSMS.Size = new System.Drawing.Size(330, 21);
            this.cboMotivoExcepcionSMS.TabIndex = 4;
            // 
            // txtSustentoExcepcionSMS
            // 
            this.txtSustentoExcepcionSMS.Location = new System.Drawing.Point(92, 49);
            this.txtSustentoExcepcionSMS.Multiline = true;
            this.txtSustentoExcepcionSMS.Name = "txtSustentoExcepcionSMS";
            this.txtSustentoExcepcionSMS.Size = new System.Drawing.Size(330, 87);
            this.txtSustentoExcepcionSMS.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(157, 165);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = global::GEN.Servicio.Properties.Resources.btnSalir;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(217, 165);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmSolicitudExcepcionSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 256);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtSustentoExcepcionSMS);
            this.Controls.Add(this.cboMotivoExcepcionSMS);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmSolicitudExcepcionSMS";
            this.Text = "Registro de Excepción de Notificación  por SMS";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboMotivoExcepcionSMS, 0);
            this.Controls.SetChildIndex(this.txtSustentoExcepcionSMS, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlesBase.lblBase lblBase1;
        private ControlesBase.lblBase lblBase2;
        private ControlesBase.cboBase cboMotivoExcepcionSMS;
        private ControlesBase.txtBase txtSustentoExcepcionSMS;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnBlanco btnSalir;
    }
}