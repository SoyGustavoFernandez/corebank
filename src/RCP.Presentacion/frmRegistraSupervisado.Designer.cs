namespace RCP.Presentacion
{
    partial class frmRegistraSupervisado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistraSupervisado));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(61, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Agencia: ";
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(195, 54);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(261, 54);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(104, 18);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(217, 21);
            this.cboAgencia1.TabIndex = 6;
            // 
            // frmRegistraSupervisado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 150);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRegistraSupervisado";
            this.Text = "Registra Supervisado";
            this.Load += new System.EventHandler(this.frmRegistraSupervisado_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
    }
}