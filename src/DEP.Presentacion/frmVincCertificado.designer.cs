namespace DEP.Presentacion
{
    partial class frmVincCertificado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincCertificado));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtCBNumCerti = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnMiniAceptar1 = new GEN.BotonesBase.btnMiniAceptar();
            this.btnMiniCancelar1 = new GEN.BotonesBase.btnMiniCancelar();
            this.btnContinuar1 = new GEN.BotonesBase.btnContinuar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 49);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(116, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Nro de Certificado:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 21);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(95, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Nro de Cuenta:";
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCuenta.Location = new System.Drawing.Point(134, 16);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.ReadOnly = true;
            this.txtNroCuenta.Size = new System.Drawing.Size(186, 22);
            this.txtNroCuenta.TabIndex = 6;
            this.txtNroCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCBNumCerti
            // 
            this.txtCBNumCerti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBNumCerti.Location = new System.Drawing.Point(134, 45);
            this.txtCBNumCerti.Name = "txtCBNumCerti";
            this.txtCBNumCerti.Size = new System.Drawing.Size(129, 22);
            this.txtCBNumCerti.TabIndex = 1;
            this.txtCBNumCerti.Text = "0000000";
            this.txtCBNumCerti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCBNumCerti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCBNumCerti_KeyPress);
            this.txtCBNumCerti.Validating += new System.ComponentModel.CancelEventHandler(this.txtCBNumCerti_Validating);
            // 
            // btnMiniAceptar1
            // 
            this.btnMiniAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAceptar1.BackgroundImage")));
            this.btnMiniAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAceptar1.Location = new System.Drawing.Point(269, 45);
            this.btnMiniAceptar1.Name = "btnMiniAceptar1";
            this.btnMiniAceptar1.Size = new System.Drawing.Size(24, 22);
            this.btnMiniAceptar1.TabIndex = 2;
            this.btnMiniAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAceptar1.UseVisualStyleBackColor = true;
            this.btnMiniAceptar1.Click += new System.EventHandler(this.btnMiniAceptar1_Click);
            // 
            // btnMiniCancelar1
            // 
            this.btnMiniCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelar1.BackgroundImage")));
            this.btnMiniCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelar1.Enabled = false;
            this.btnMiniCancelar1.Location = new System.Drawing.Point(296, 45);
            this.btnMiniCancelar1.Name = "btnMiniCancelar1";
            this.btnMiniCancelar1.Size = new System.Drawing.Size(24, 22);
            this.btnMiniCancelar1.TabIndex = 3;
            this.btnMiniCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelar1.UseVisualStyleBackColor = true;
            this.btnMiniCancelar1.Click += new System.EventHandler(this.btnMiniCancelar1_Click);
            // 
            // btnContinuar1
            // 
            this.btnContinuar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinuar1.BackgroundImage")));
            this.btnContinuar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContinuar1.Location = new System.Drawing.Point(337, 16);
            this.btnContinuar1.Name = "btnContinuar1";
            this.btnContinuar1.Size = new System.Drawing.Size(60, 50);
            this.btnContinuar1.TabIndex = 4;
            this.btnContinuar1.Text = "Continuar";
            this.btnContinuar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContinuar1.UseVisualStyleBackColor = true;
            this.btnContinuar1.Click += new System.EventHandler(this.btnContinuar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(403, 16);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // frmVincCertificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 102);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnContinuar1);
            this.Controls.Add(this.btnMiniCancelar1);
            this.Controls.Add(this.btnMiniAceptar1);
            this.Controls.Add(this.txtCBNumCerti);
            this.Controls.Add(this.txtNroCuenta);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVincCertificado";
            this.Text = "Vinculación de Certificado";
            this.Load += new System.EventHandler(this.frmVincCertificado_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtNroCuenta, 0);
            this.Controls.SetChildIndex(this.txtCBNumCerti, 0);
            this.Controls.SetChildIndex(this.btnMiniAceptar1, 0);
            this.Controls.SetChildIndex(this.btnMiniCancelar1, 0);
            this.Controls.SetChildIndex(this.btnContinuar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNumCerti;
        private GEN.BotonesBase.btnMiniAceptar btnMiniAceptar1;
        private GEN.BotonesBase.btnMiniCancelar btnMiniCancelar1;
        private GEN.BotonesBase.btnContinuar btnContinuar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}