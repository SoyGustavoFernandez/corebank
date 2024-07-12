namespace GEN.ControlesBase
{
    partial class frmCalculadoraInversionRealizada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculadoraInversionRealizada));
            this.conCalculadoraInversionRealizada = new GEN.ControlesBase.ConCalculadoraInversionRealizada();
            this.txtParcela = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.txtVariedad = new GEN.ControlesBase.txtCBDNI(this.components);
            this.txtCultivo = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.SuspendLayout();
            // 
            // conCalculadoraInversionRealizada
            // 
            this.conCalculadoraInversionRealizada.Location = new System.Drawing.Point(25, 66);
            this.conCalculadoraInversionRealizada.Name = "conCalculadoraInversionRealizada";
            this.conCalculadoraInversionRealizada.Size = new System.Drawing.Size(628, 255);
            this.conCalculadoraInversionRealizada.TabIndex = 107;
            // 
            // txtParcela
            // 
            this.txtParcela.Location = new System.Drawing.Point(498, 29);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(124, 20);
            this.txtParcela.TabIndex = 104;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(446, 33);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 105;
            this.lblBase2.Text = "Parcela";
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(46, 33);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(47, 13);
            this.lblBase32.TabIndex = 101;
            this.lblBase32.Text = "Cultivo";
            // 
            // txtVariedad
            // 
            this.txtVariedad.Location = new System.Drawing.Point(302, 29);
            this.txtVariedad.Name = "txtVariedad";
            this.txtVariedad.Size = new System.Drawing.Size(124, 20);
            this.txtVariedad.TabIndex = 102;
            // 
            // txtCultivo
            // 
            this.txtCultivo.Location = new System.Drawing.Point(93, 29);
            this.txtCultivo.Name = "txtCultivo";
            this.txtCultivo.Size = new System.Drawing.Size(124, 20);
            this.txtCultivo.TabIndex = 100;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(245, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 103;
            this.lblBase1.Text = "Variedad";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(593, 319);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 110;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_click);
            // 
            // frmCalculadoraInversionRealizada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 400);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.conCalculadoraInversionRealizada);
            this.Controls.Add(this.txtParcela);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase32);
            this.Controls.Add(this.txtVariedad);
            this.Controls.Add(this.txtCultivo);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmCalculadoraInversionRealizada";
            this.Text = "frmCalculadoraInversionRealizada";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCalculadoraInversionRealizada_FormClosing);
            this.Load += new System.EventHandler(this.frmCalculadoraInversionRealizada_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtCultivo, 0);
            this.Controls.SetChildIndex(this.txtVariedad, 0);
            this.Controls.SetChildIndex(this.lblBase32, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtParcela, 0);
            this.Controls.SetChildIndex(this.conCalculadoraInversionRealizada, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private txtCBDNI txtParcela;
        private lblBase lblBase2;
        private lblBase lblBase32;
        private txtCBDNI txtVariedad;
        private txtCBDNI txtCultivo;
        private lblBase lblBase1;
        private ConCalculadoraInversionRealizada conCalculadoraInversionRealizada;
        private BotonesBase.BtnAceptar btnAceptar;
    }
}