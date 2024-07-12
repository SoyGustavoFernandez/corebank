namespace GEN.ControlesBase
{
    partial class frmConfigurarParametroArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarParametroArchivo));
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar2 = new GEN.BotonesBase.btnGrabar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMontoExposicionJuridica = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMontoExposicionNatural = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.Location = new System.Drawing.Point(517, 102);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 61;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            this.btnSalir2.Click += new System.EventHandler(this.btnSalir2_Click);
            // 
            // btnGrabar2
            // 
            this.btnGrabar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar2.BackgroundImage")));
            this.btnGrabar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar2.Location = new System.Drawing.Point(451, 102);
            this.btnGrabar2.Name = "btnGrabar2";
            this.btnGrabar2.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar2.TabIndex = 60;
            this.btnGrabar2.Text = "&Grabar";
            this.btnGrabar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar2.UseVisualStyleBackColor = true;
            this.btnGrabar2.Click += new System.EventHandler(this.btnGrabar2_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtMontoExposicionJuridica);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.txtMontoExposicionNatural);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Location = new System.Drawing.Point(15, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(562, 84);
            this.grbBase1.TabIndex = 59;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Parametro Carga Pagaré";
            // 
            // txtMontoExposicionJuridica
            // 
            this.txtMontoExposicionJuridica.FormatoDecimal = false;
            this.txtMontoExposicionJuridica.Location = new System.Drawing.Point(304, 43);
            this.txtMontoExposicionJuridica.Name = "txtMontoExposicionJuridica";
            this.txtMontoExposicionJuridica.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoExposicionJuridica.nNumDecimales = 4;
            this.txtMontoExposicionJuridica.nvalor = 0D;
            this.txtMontoExposicionJuridica.Size = new System.Drawing.Size(142, 20);
            this.txtMontoExposicionJuridica.TabIndex = 3;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(15, 47);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(289, 13);
            this.lblBase7.TabIndex = 2;
            this.lblBase7.Text = "Exposición Interna del Cliente - Persona Juridica:";
            // 
            // txtMontoExposicionNatural
            // 
            this.txtMontoExposicionNatural.FormatoDecimal = false;
            this.txtMontoExposicionNatural.Location = new System.Drawing.Point(304, 20);
            this.txtMontoExposicionNatural.Name = "txtMontoExposicionNatural";
            this.txtMontoExposicionNatural.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoExposicionNatural.nNumDecimales = 4;
            this.txtMontoExposicionNatural.nvalor = 0D;
            this.txtMontoExposicionNatural.Size = new System.Drawing.Size(142, 20);
            this.txtMontoExposicionNatural.TabIndex = 1;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 24);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(287, 13);
            this.lblBase6.TabIndex = 0;
            this.lblBase6.Text = "Exposición Interna del Cliente - Persona Natural:";
            // 
            // frmConfigurarParametroArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 197);
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.btnGrabar2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmConfigurarParametroArchivo";
            this.Text = "Configuración de Parametros de Carga de Archivos";
            this.Load += new System.EventHandler(this.frmConfigurarParametroArchivo_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar2, 0);
            this.Controls.SetChildIndex(this.btnSalir2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnSalir btnSalir2;
        private BotonesBase.btnGrabar btnGrabar2;
        private grbBase grbBase1;
        private txtNumRea txtMontoExposicionJuridica;
        private lblBase lblBase7;
        private txtNumRea txtMontoExposicionNatural;
        private lblBase lblBase6;
    }
}