namespace GEN.ControlesBase
{
    partial class frmControlLimitesBoveda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlLimitesBoveda));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboLimCierreBov = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblSaldos = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSolicitar1 = new GEN.BotonesBase.btnSolicitar();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 53);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Motivo:";
            // 
            // cboLimCierreBov
            // 
            this.cboLimCierreBov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimCierreBov.FormattingEnabled = true;
            this.cboLimCierreBov.Location = new System.Drawing.Point(6, 69);
            this.cboLimCierreBov.Name = "cboLimCierreBov";
            this.cboLimCierreBov.Size = new System.Drawing.Size(393, 21);
            this.cboLimCierreBov.TabIndex = 4;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblSaldos);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtBase1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboLimCierreBov);
            this.grbBase1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(409, 187);
            this.grbBase1.TabIndex = 5;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Cierre con exceso de efectivo en bóveda";
            // 
            // lblSaldos
            // 
            this.lblSaldos.AutoSize = true;
            this.lblSaldos.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldos.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldos.Location = new System.Drawing.Point(105, 197);
            this.lblSaldos.Name = "lblSaldos";
            this.lblSaldos.Size = new System.Drawing.Size(14, 13);
            this.lblSaldos.TabIndex = 9;
            this.lblSaldos.Text = "0";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 17);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(364, 26);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Usted requiere solicitar autorización para aprobar el cierre de \r\nbóveda con exce" +
    "so de efectivo\r\n";
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(6, 109);
            this.txtBase1.MaxLength = 500;
            this.txtBase1.Multiline = true;
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(393, 68);
            this.txtBase1.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 93);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Descripción:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(361, 205);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 11;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(295, 205);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 10;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSolicitar1
            // 
            this.btnSolicitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolicitar1.BackgroundImage")));
            this.btnSolicitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolicitar1.Location = new System.Drawing.Point(12, 205);
            this.btnSolicitar1.Name = "btnSolicitar1";
            this.btnSolicitar1.Size = new System.Drawing.Size(60, 50);
            this.btnSolicitar1.TabIndex = 10;
            this.btnSolicitar1.Text = "Solicitar";
            this.btnSolicitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolicitar1.UseVisualStyleBackColor = true;
            this.btnSolicitar1.Click += new System.EventHandler(this.btnSolicitar1_Click);
            // 
            // frmControlLimitesBoveda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 284);
            this.Controls.Add(this.btnSolicitar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAceptar1);
            this.Name = "frmControlLimitesBoveda";
            this.Text = "Solicitud de Autorización de Cierre de Bóveda";
            this.Shown += new System.EventHandler(this.frmControlLimitesBoveda_Shown);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSolicitar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboLimCierreBov;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblSaldos;
        private BotonesBase.BtnAceptar btnAceptar1;
        private BotonesBase.btnCancelar btnCancelar1;
        private BotonesBase.btnSolicitar btnSolicitar1;
        private lblBase lblBase3;


    }
}