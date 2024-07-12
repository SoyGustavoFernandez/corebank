namespace GEN.ControlesBase
{
    partial class ConPropuestaCrediJornal
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
            this.conActPrincipal = new CRE.ControlBase.ConActEconomica();
            this.txtDatosCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtDatosCredito = new GEN.ControlesBase.txtBase(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom2 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom3 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.pbxActividadPrincipal = new System.Windows.Forms.PictureBox();
            this.pbxDatosCliente = new System.Windows.Forms.PictureBox();
            this.pbxDatosCredito = new System.Windows.Forms.PictureBox();
            this.ttpPropuesta = new GEN.ControlesBase.ttpToolTip();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxActividadPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // conActPrincipal
            // 
            this.conActPrincipal.ActividadInternaEnabled = true;
            this.conActPrincipal.Checked = true;
            this.conActPrincipal.CheckedEnabled = false;
            this.conActPrincipal.Location = new System.Drawing.Point(6, 33);
            this.conActPrincipal.Name = "conActPrincipal";
            this.conActPrincipal.Size = new System.Drawing.Size(340, 234);
            this.conActPrincipal.TabIndex = 0;
            this.conActPrincipal.Titulo = "     Actividad Principal";
            // 
            // txtDatosCliente
            // 
            this.txtDatosCliente.Location = new System.Drawing.Point(6, 293);
            this.txtDatosCliente.Multiline = true;
            this.txtDatosCliente.Name = "txtDatosCliente";
            this.txtDatosCliente.Size = new System.Drawing.Size(390, 80);
            this.txtDatosCliente.TabIndex = 1;
            this.txtDatosCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtDatosCliente_Validating);
            // 
            // txtDatosCredito
            // 
            this.txtDatosCredito.Location = new System.Drawing.Point(6, 399);
            this.txtDatosCredito.Multiline = true;
            this.txtDatosCredito.Name = "txtDatosCredito";
            this.txtDatosCredito.Size = new System.Drawing.Size(390, 80);
            this.txtDatosCredito.TabIndex = 2;
            this.txtDatosCredito.Validating += new System.ComponentModel.CancelEventHandler(this.txtDatosCredito_Validating);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBaseCustom1.Location = new System.Drawing.Point(6, 5);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(325, 28);
            this.lblBaseCustom1.TabIndex = 3;
            this.lblBaseCustom1.Text = "1. Sobre la Actividad";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseCustom2
            // 
            this.lblBaseCustom2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBaseCustom2.Location = new System.Drawing.Point(6, 267);
            this.lblBaseCustom2.Name = "lblBaseCustom2";
            this.lblBaseCustom2.Size = new System.Drawing.Size(390, 26);
            this.lblBaseCustom2.TabIndex = 4;
            this.lblBaseCustom2.Text = "2. Sobre el cliente ";
            this.lblBaseCustom2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaseCustom3
            // 
            this.lblBaseCustom3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBaseCustom3.Location = new System.Drawing.Point(6, 373);
            this.lblBaseCustom3.Name = "lblBaseCustom3";
            this.lblBaseCustom3.Size = new System.Drawing.Size(390, 26);
            this.lblBaseCustom3.TabIndex = 5;
            this.lblBaseCustom3.Text = "3. Sobre el Crédito";
            this.lblBaseCustom3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxActividadPrincipal
            // 
            this.pbxActividadPrincipal.Image = global::GEN.ControlesBase.Properties.Resources.FAQ_16;
            this.pbxActividadPrincipal.Location = new System.Drawing.Point(322, 11);
            this.pbxActividadPrincipal.Name = "pbxActividadPrincipal";
            this.pbxActividadPrincipal.Size = new System.Drawing.Size(16, 16);
            this.pbxActividadPrincipal.TabIndex = 6;
            this.pbxActividadPrincipal.TabStop = false;
            // 
            // pbxDatosCliente
            // 
            this.pbxDatosCliente.Image = global::GEN.ControlesBase.Properties.Resources.FAQ_16;
            this.pbxDatosCliente.Location = new System.Drawing.Point(380, 272);
            this.pbxDatosCliente.Name = "pbxDatosCliente";
            this.pbxDatosCliente.Size = new System.Drawing.Size(16, 16);
            this.pbxDatosCliente.TabIndex = 7;
            this.pbxDatosCliente.TabStop = false;
            // 
            // pbxDatosCredito
            // 
            this.pbxDatosCredito.Image = global::GEN.ControlesBase.Properties.Resources.FAQ_16;
            this.pbxDatosCredito.Location = new System.Drawing.Point(380, 378);
            this.pbxDatosCredito.Name = "pbxDatosCredito";
            this.pbxDatosCredito.Size = new System.Drawing.Size(16, 16);
            this.pbxDatosCredito.TabIndex = 8;
            this.pbxDatosCredito.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConPropuestaCrediJornal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbxDatosCredito);
            this.Controls.Add(this.pbxDatosCliente);
            this.Controls.Add(this.pbxActividadPrincipal);
            this.Controls.Add(this.lblBaseCustom3);
            this.Controls.Add(this.lblBaseCustom2);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.txtDatosCredito);
            this.Controls.Add(this.txtDatosCliente);
            this.Controls.Add(this.conActPrincipal);
            this.Name = "ConPropuestaCrediJornal";
            this.Size = new System.Drawing.Size(409, 488);
            ((System.ComponentModel.ISupportInitialize)(this.pbxActividadPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CRE.ControlBase.ConActEconomica conActPrincipal;
        private txtBase txtDatosCliente;
        private txtBase txtDatosCredito;
        private lblBaseCustom lblBaseCustom1;
        private lblBaseCustom lblBaseCustom2;
        private lblBaseCustom lblBaseCustom3;
        private System.Windows.Forms.PictureBox pbxActividadPrincipal;
        private System.Windows.Forms.PictureBox pbxDatosCliente;
        private System.Windows.Forms.PictureBox pbxDatosCredito;
        private ttpToolTip ttpPropuesta;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
