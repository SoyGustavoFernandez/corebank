namespace GEN.ControlesBase
{
    partial class ConPropuestaSimpCred
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
            this.lblDatosCredito = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtDatosCredito = new GEN.ControlesBase.txtBase(this.components);
            this.lblActividadPrincipal = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblDatosCliente = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtDatosCliente = new GEN.ControlesBase.txtBase(this.components);
            this.pbxDatosCredito = new System.Windows.Forms.PictureBox();
            this.pbxActividadPrincipal = new System.Windows.Forms.PictureBox();
            this.pbxDatosCliente = new System.Windows.Forms.PictureBox();
            this.conActPrincipal = new CRE.ControlBase.ConActEconomica();
            this.ttpPropuesta = new GEN.ControlesBase.ttpToolTip();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxActividadPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatosCredito
            // 
            this.lblDatosCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatosCredito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCredito.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDatosCredito.Location = new System.Drawing.Point(250, 173);
            this.lblDatosCredito.Name = "lblDatosCredito";
            this.lblDatosCredito.Size = new System.Drawing.Size(224, 18);
            this.lblDatosCredito.TabIndex = 27;
            this.lblDatosCredito.Text = "3. Sobre el Crédito.";
            // 
            // txtDatosCredito
            // 
            this.txtDatosCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatosCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatosCredito.Location = new System.Drawing.Point(249, 192);
            this.txtDatosCredito.Multiline = true;
            this.txtDatosCredito.Name = "txtDatosCredito";
            this.txtDatosCredito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDatosCredito.Size = new System.Drawing.Size(225, 56);
            this.txtDatosCredito.TabIndex = 25;
            // 
            // lblActividadPrincipal
            // 
            this.lblActividadPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActividadPrincipal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActividadPrincipal.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblActividadPrincipal.Location = new System.Drawing.Point(5, 5);
            this.lblActividadPrincipal.Name = "lblActividadPrincipal";
            this.lblActividadPrincipal.Size = new System.Drawing.Size(474, 18);
            this.lblActividadPrincipal.TabIndex = 23;
            this.lblActividadPrincipal.Text = "1. Sobre la Actividad.";
            // 
            // lblDatosCliente
            // 
            this.lblDatosCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatosCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosCliente.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDatosCliente.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDatosCliente.Location = new System.Drawing.Point(5, 171);
            this.lblDatosCliente.Name = "lblDatosCliente";
            this.lblDatosCliente.Size = new System.Drawing.Size(225, 18);
            this.lblDatosCliente.TabIndex = 21;
            this.lblDatosCliente.Text = "2. Sobre el cliente.";
            // 
            // txtDatosCliente
            // 
            this.txtDatosCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDatosCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDatosCliente.Location = new System.Drawing.Point(5, 190);
            this.txtDatosCliente.Multiline = true;
            this.txtDatosCliente.Name = "txtDatosCliente";
            this.txtDatosCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDatosCliente.Size = new System.Drawing.Size(225, 58);
            this.txtDatosCliente.TabIndex = 24;
            // 
            // pbxDatosCredito
            // 
            this.pbxDatosCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxDatosCredito.Image = global::GEN.ControlesBase.Properties.Resources.FAQ_16;
            this.pbxDatosCredito.Location = new System.Drawing.Point(458, 174);
            this.pbxDatosCredito.Name = "pbxDatosCredito";
            this.pbxDatosCredito.Size = new System.Drawing.Size(16, 16);
            this.pbxDatosCredito.TabIndex = 31;
            this.pbxDatosCredito.TabStop = false;
            // 
            // pbxActividadPrincipal
            // 
            this.pbxActividadPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxActividadPrincipal.Image = global::GEN.ControlesBase.Properties.Resources.FAQ_16;
            this.pbxActividadPrincipal.Location = new System.Drawing.Point(458, 6);
            this.pbxActividadPrincipal.Name = "pbxActividadPrincipal";
            this.pbxActividadPrincipal.Size = new System.Drawing.Size(16, 16);
            this.pbxActividadPrincipal.TabIndex = 30;
            this.pbxActividadPrincipal.TabStop = false;
            // 
            // pbxDatosCliente
            // 
            this.pbxDatosCliente.Image = global::GEN.ControlesBase.Properties.Resources.FAQ_16;
            this.pbxDatosCliente.Location = new System.Drawing.Point(214, 172);
            this.pbxDatosCliente.Name = "pbxDatosCliente";
            this.pbxDatosCliente.Size = new System.Drawing.Size(16, 16);
            this.pbxDatosCliente.TabIndex = 29;
            this.pbxDatosCliente.TabStop = false;
            // 
            // conActPrincipal
            // 
            this.conActPrincipal.ActividadInternaEnabled = true;
            this.conActPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conActPrincipal.Checked = true;
            this.conActPrincipal.CheckedEnabled = false;
            this.conActPrincipal.Location = new System.Drawing.Point(5, 22);
            this.conActPrincipal.lTipoActividadHabilitado = true;
            this.conActPrincipal.Name = "conActPrincipal";
            this.conActPrincipal.Size = new System.Drawing.Size(474, 148);
            this.conActPrincipal.TabIndex = 33;
            this.conActPrincipal.Titulo = "     Actividad Principal";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConPropuestaSimpCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.conActPrincipal);
            this.Controls.Add(this.pbxDatosCredito);
            this.Controls.Add(this.pbxActividadPrincipal);
            this.Controls.Add(this.pbxDatosCliente);
            this.Controls.Add(this.lblDatosCredito);
            this.Controls.Add(this.txtDatosCredito);
            this.Controls.Add(this.lblActividadPrincipal);
            this.Controls.Add(this.lblDatosCliente);
            this.Controls.Add(this.txtDatosCliente);
            this.Name = "ConPropuestaSimpCred";
            this.Size = new System.Drawing.Size(484, 251);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxActividadPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDatosCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxDatosCredito;
        private System.Windows.Forms.PictureBox pbxActividadPrincipal;
        private System.Windows.Forms.PictureBox pbxDatosCliente;
        private lblBaseCustom lblDatosCredito;
        private txtBase txtDatosCredito;
        private lblBaseCustom lblActividadPrincipal;
        private lblBaseCustom lblDatosCliente;
        private txtBase txtDatosCliente;
        private CRE.ControlBase.ConActEconomica conActPrincipal;
        private ttpToolTip ttpPropuesta;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
