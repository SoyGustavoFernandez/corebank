
namespace CNT.Presentacion.CPE
{
    partial class frmEnvioSunatCPE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioSunatCPE));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.DtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.CboEstadoEnvio = new GEN.ControlesBase.cboEstadoEnvioCPE(this.components);
            this.txtNombreCDR = new GEN.ControlesBase.txtBase(this.components);
            this.BtnSalir = new GEN.BotonesBase.btnSalir();
            this.BtnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNombreCDR);
            this.grbBase1.Controls.Add(this.CboEstadoEnvio);
            this.grbBase1.Controls.Add(this.DtpFecha);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(294, 107);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(56, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(51, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Estado:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 71);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(87, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Nombre CDR:";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(107, 25);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(150, 20);
            this.DtpFecha.TabIndex = 1;
            // 
            // CboEstadoEnvio
            // 
            this.CboEstadoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstadoEnvio.FormattingEnabled = true;
            this.CboEstadoEnvio.Location = new System.Drawing.Point(107, 46);
            this.CboEstadoEnvio.Name = "CboEstadoEnvio";
            this.CboEstadoEnvio.Size = new System.Drawing.Size(150, 21);
            this.CboEstadoEnvio.TabIndex = 2;
            // 
            // txtNombreCDR
            // 
            this.txtNombreCDR.Location = new System.Drawing.Point(107, 68);
            this.txtNombreCDR.Name = "txtNombreCDR";
            this.txtNombreCDR.Size = new System.Drawing.Size(150, 20);
            this.txtNombreCDR.TabIndex = 3;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSalir.BackgroundImage")));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.Location = new System.Drawing.Point(246, 125);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(60, 50);
            this.BtnSalir.TabIndex = 3;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGrabar.BackgroundImage")));
            this.BtnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnGrabar.Location = new System.Drawing.Point(180, 125);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(60, 50);
            this.BtnGrabar.TabIndex = 4;
            this.BtnGrabar.Text = "&Grabar";
            this.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // frmEnvioSunatCPE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 203);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmEnvioSunatCPE";
            this.Text = "Registro de envío a SUNAT";
            this.Load += new System.EventHandler(this.frmEnvioSunatCPE_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.BtnSalir, 0);
            this.Controls.SetChildIndex(this.BtnGrabar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombreCDR;
        private GEN.ControlesBase.cboEstadoEnvioCPE CboEstadoEnvio;
        private GEN.ControlesBase.dtpCorto DtpFecha;
        private GEN.BotonesBase.btnSalir BtnSalir;
        private GEN.BotonesBase.btnGrabar BtnGrabar;
    }
}