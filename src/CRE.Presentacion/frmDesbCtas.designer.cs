namespace CRE.Presentacion
{
    partial class frmDesbCtas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesbCtas));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtAgeBlo = new System.Windows.Forms.TextBox();
            this.txtUsuarioBlo = new System.Windows.Forms.TextBox();
            this.conBusCtaCliSinBloq1 = new GEN.ControlesBase.ConBusCtaCliSinBloq();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnLiberar = new GEN.BotonesBase.btnLiberar();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtAgeBlo);
            this.grbBase1.Controls.Add(this.txtUsuarioBlo);
            this.grbBase1.Location = new System.Drawing.Point(5, 135);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(369, 73);
            this.grbBase1.TabIndex = 18;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Bloqueo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Usuario:";
            // 
            // txtAgeBlo
            // 
            this.txtAgeBlo.BackColor = System.Drawing.SystemColors.Control;
            this.txtAgeBlo.Enabled = false;
            this.txtAgeBlo.Location = new System.Drawing.Point(69, 45);
            this.txtAgeBlo.Name = "txtAgeBlo";
            this.txtAgeBlo.Size = new System.Drawing.Size(177, 20);
            this.txtAgeBlo.TabIndex = 15;
            // 
            // txtUsuarioBlo
            // 
            this.txtUsuarioBlo.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuarioBlo.Enabled = false;
            this.txtUsuarioBlo.Location = new System.Drawing.Point(69, 19);
            this.txtUsuarioBlo.Name = "txtUsuarioBlo";
            this.txtUsuarioBlo.Size = new System.Drawing.Size(294, 20);
            this.txtUsuarioBlo.TabIndex = 14;
            // 
            // conBusCtaCliSinBloq1
            // 
            this.conBusCtaCliSinBloq1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCtaCliSinBloq1.Location = new System.Drawing.Point(2, 5);
            this.conBusCtaCliSinBloq1.Name = "conBusCtaCliSinBloq1";
            this.conBusCtaCliSinBloq1.Size = new System.Drawing.Size(572, 124);
            this.conBusCtaCliSinBloq1.TabIndex = 1;
            this.conBusCtaCliSinBloq1.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCtaCliSinBloq1_MyKey);
            this.conBusCtaCliSinBloq1.MyClic += new System.EventHandler(this.conBusCtaCliSinBloq1_MyClic);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(504, 157);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(442, 158);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 19;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar.BackgroundImage")));
            this.btnLiberar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiberar.Enabled = false;
            this.btnLiberar.Location = new System.Drawing.Point(380, 158);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(60, 50);
            this.btnLiberar.TabIndex = 20;
            this.btnLiberar.Text = "&Liberar";
            this.btnLiberar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // frmDesbCtas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 239);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.conBusCtaCliSinBloq1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmDesbCtas";
            this.Text = "Desbloqueo de Cuentas";
            this.Load += new System.EventHandler(this.frmDesbCtas_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusCtaCliSinBloq1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnLiberar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.TextBox txtUsuarioBlo;
        private GEN.ControlesBase.ConBusCtaCliSinBloq conBusCtaCliSinBloq1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.TextBox txtAgeBlo;
        private GEN.BotonesBase.btnLiberar btnLiberar;

    }
}