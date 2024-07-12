namespace DEP.Presentacion
{
    partial class frmActualizaDatosTipEnvioAhorros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizaDatosTipEnvioAhorros));
            this.conBusCtaAho1 = new GEN.ControlesBase.conBusCtaAho();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.grbBase11 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.txtDireccionEnvioEstCta = new GEN.ControlesBase.txtBase(this.components);
            this.cboEnvioEstCta = new GEN.ControlesBase.cboEnvioEstCta(this.components);
            this.lblBase56 = new GEN.ControlesBase.lblBase();
            this.lblBase55 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtBase3 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCtaAho1
            // 
            this.conBusCtaAho1.Location = new System.Drawing.Point(12, 12);
            this.conBusCtaAho1.Name = "conBusCtaAho1";
            this.conBusCtaAho1.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho1.TabIndex = 2;
            this.conBusCtaAho1.ClicBusCta += new System.EventHandler(this.conBusCtaAho1_ClicBusCta);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(383, 378);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(515, 378);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(317, 378);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 5;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // grbBase11
            // 
            this.grbBase11.Controls.Add(this.btnMiniEditar1);
            this.grbBase11.Controls.Add(this.txtDireccionEnvioEstCta);
            this.grbBase11.Controls.Add(this.cboEnvioEstCta);
            this.grbBase11.Controls.Add(this.lblBase56);
            this.grbBase11.Controls.Add(this.lblBase55);
            this.grbBase11.Location = new System.Drawing.Point(12, 218);
            this.grbBase11.Name = "grbBase11";
            this.grbBase11.Size = new System.Drawing.Size(560, 68);
            this.grbBase11.TabIndex = 6;
            this.grbBase11.TabStop = false;
            this.grbBase11.Text = "Envío de Estado de Cuentas";
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.Location = new System.Drawing.Point(458, 34);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 122;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = true;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditar1_Click);
            // 
            // txtDireccionEnvioEstCta
            // 
            this.txtDireccionEnvioEstCta.Location = new System.Drawing.Point(118, 41);
            this.txtDireccionEnvioEstCta.Name = "txtDireccionEnvioEstCta";
            this.txtDireccionEnvioEstCta.Size = new System.Drawing.Size(334, 20);
            this.txtDireccionEnvioEstCta.TabIndex = 121;
            // 
            // cboEnvioEstCta
            // 
            this.cboEnvioEstCta.FormattingEnabled = true;
            this.cboEnvioEstCta.Location = new System.Drawing.Point(118, 14);
            this.cboEnvioEstCta.Name = "cboEnvioEstCta";
            this.cboEnvioEstCta.Size = new System.Drawing.Size(334, 21);
            this.cboEnvioEstCta.TabIndex = 0;
            this.cboEnvioEstCta.SelectedIndexChanged += new System.EventHandler(this.cboEnvioEstCta_SelectedIndexChanged);
            // 
            // lblBase56
            // 
            this.lblBase56.AutoSize = true;
            this.lblBase56.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase56.ForeColor = System.Drawing.Color.Navy;
            this.lblBase56.Location = new System.Drawing.Point(50, 43);
            this.lblBase56.Name = "lblBase56";
            this.lblBase56.Size = new System.Drawing.Size(65, 13);
            this.lblBase56.TabIndex = 120;
            this.lblBase56.Text = "Dirección:";
            // 
            // lblBase55
            // 
            this.lblBase55.AutoSize = true;
            this.lblBase55.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase55.ForeColor = System.Drawing.Color.Navy;
            this.lblBase55.Location = new System.Drawing.Point(20, 17);
            this.lblBase55.Name = "lblBase55";
            this.lblBase55.Size = new System.Drawing.Size(95, 13);
            this.lblBase55.TabIndex = 119;
            this.lblBase55.Text = "Estado Cuenta:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(449, 378);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.txtBase3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.txtBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.txtBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Cuenta";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(48, 49);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(62, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Producto:";
            // 
            // txtBase3
            // 
            this.txtBase3.Location = new System.Drawing.Point(116, 49);
            this.txtBase3.Name = "txtBase3";
            this.txtBase3.Size = new System.Drawing.Size(254, 20);
            this.txtBase3.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(263, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Tipo de Cuenta:";
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(368, 26);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(100, 20);
            this.txtBase2.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Nro de Cuenta:";
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(116, 23);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(100, 20);
            this.txtBase1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtObservacion);
            this.groupBox2.Location = new System.Drawing.Point(12, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 80);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sustento";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(37, 19);
            this.txtObservacion.MaxLength = 1000;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(474, 55);
            this.txtObservacion.TabIndex = 60;
            // 
            // frmActualizaDatosTipEnvioAhorros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase11);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.conBusCtaAho1);
            this.Name = "frmActualizaDatosTipEnvioAhorros";
            this.Text = "Actualizar Datos de Tipo de Envío de EE.CC. de Ahorros";
            this.Load += new System.EventHandler(this.frmActualizaDatosTipEnvioAhorros_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.grbBase11, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbBase11.ResumeLayout(false);
            this.grbBase11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.grbBase grbBase11;
        private GEN.ControlesBase.txtBase txtDireccionEnvioEstCta;
        private GEN.ControlesBase.cboEnvioEstCta cboEnvioEstCta;
        private GEN.ControlesBase.lblBase lblBase56;
        private GEN.ControlesBase.lblBase lblBase55;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtObservacion;
    }
}