namespace DEP.Presentacion
{
    partial class frmDesbloqueoCuentasAho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesbloqueoCuentasAho));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnLiberar = new GEN.BotonesBase.btnLiberar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtUsuarioBlo = new GEN.ControlesBase.txtBase(this.components);
            this.txtAgeBlo = new System.Windows.Forms.TextBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conBusCtaCliSinBloq = new GEN.ControlesBase.ConBusCtaCliSinBloq();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(506, 151);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnLiberar
            // 
            this.btnLiberar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar.BackgroundImage")));
            this.btnLiberar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiberar.Enabled = false;
            this.btnLiberar.Location = new System.Drawing.Point(382, 151);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(60, 50);
            this.btnLiberar.TabIndex = 4;
            this.btnLiberar.Text = "&Liberar";
            this.btnLiberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(444, 151);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtUsuarioBlo);
            this.grbBase1.Controls.Add(this.txtAgeBlo);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(6, 125);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(370, 75);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Bloqueo";
            this.grbBase1.Enter += new System.EventHandler(this.grbBase1_Enter);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(4, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Agencia:";
            // 
            // txtUsuarioBlo
            // 
            this.txtUsuarioBlo.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioBlo.Enabled = false;
            this.txtUsuarioBlo.Location = new System.Drawing.Point(63, 22);
            this.txtUsuarioBlo.Name = "txtUsuarioBlo";
            this.txtUsuarioBlo.Size = new System.Drawing.Size(299, 20);
            this.txtUsuarioBlo.TabIndex = 2;
            // 
            // txtAgeBlo
            // 
            this.txtAgeBlo.BackColor = System.Drawing.SystemColors.Control;
            this.txtAgeBlo.Enabled = false;
            this.txtAgeBlo.Location = new System.Drawing.Point(63, 46);
            this.txtAgeBlo.Name = "txtAgeBlo";
            this.txtAgeBlo.Size = new System.Drawing.Size(177, 20);
            this.txtAgeBlo.TabIndex = 18;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Usuario:";
            // 
            // conBusCtaCliSinBloq
            // 
            this.conBusCtaCliSinBloq.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCtaCliSinBloq.Location = new System.Drawing.Point(6, 12);
            this.conBusCtaCliSinBloq.Name = "conBusCtaCliSinBloq";
            this.conBusCtaCliSinBloq.Size = new System.Drawing.Size(570, 125);
            this.conBusCtaCliSinBloq.TabIndex = 7;
            this.conBusCtaCliSinBloq.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCtaCliSinBloq1_MyKey);
            this.conBusCtaCliSinBloq.MyClic += new System.EventHandler(this.conBusCtaCliSinBloq1_MyClic);
            // 
            // frmDesbloqueoCuentasAho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 233);
            this.Controls.Add(this.conBusCtaCliSinBloq);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmDesbloqueoCuentasAho";
            this.Text = "Desbloqueo Lógico de Cuentas";
            this.Load += new System.EventHandler(this.frmDesbloqueoCuentasAho_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnLiberar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.conBusCtaCliSinBloq, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnLiberar btnLiberar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtUsuarioBlo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.TextBox txtAgeBlo;
        private GEN.ControlesBase.ConBusCtaCliSinBloq conBusCtaCliSinBloq;
    }
}