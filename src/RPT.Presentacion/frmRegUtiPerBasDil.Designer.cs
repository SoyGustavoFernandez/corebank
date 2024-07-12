namespace RPT.Presentacion
{
    partial class frmRegUtiPerBasDil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegUtiPerBasDil));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.txtProPonAccBas = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtUtiPerEje = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtProPonAccDil = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtUtiAccDil = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtUtiAccBas = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtCtaCtb = new GEN.ControlesBase.txtNumRea(this.components);
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(402, 191);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(334, 191);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = false;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtProPonAccBas
            // 
            this.txtProPonAccBas.Enabled = false;
            this.txtProPonAccBas.FormatoDecimal = false;
            this.txtProPonAccBas.Location = new System.Drawing.Point(362, 22);
            this.txtProPonAccBas.Name = "txtProPonAccBas";
            this.txtProPonAccBas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtProPonAccBas.nNumDecimales = 0;
            this.txtProPonAccBas.nvalor = 0D;
            this.txtProPonAccBas.Size = new System.Drawing.Size(100, 20);
            this.txtProPonAccBas.TabIndex = 0;
            this.txtProPonAccBas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProPonAccBas.Validated += new System.EventHandler(this.txtProPonAccBas_Validated);
            // 
            // txtUtiPerEje
            // 
            this.txtUtiPerEje.Enabled = false;
            this.txtUtiPerEje.FormatoDecimal = false;
            this.txtUtiPerEje.Location = new System.Drawing.Point(362, 100);
            this.txtUtiPerEje.Name = "txtUtiPerEje";
            this.txtUtiPerEje.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUtiPerEje.nNumDecimales = 2;
            this.txtUtiPerEje.nvalor = 0D;
            this.txtUtiPerEje.Size = new System.Drawing.Size(100, 20);
            this.txtUtiPerEje.TabIndex = 5;
            this.txtUtiPerEje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProPonAccDil
            // 
            this.txtProPonAccDil.Enabled = false;
            this.txtProPonAccDil.FormatoDecimal = false;
            this.txtProPonAccDil.Location = new System.Drawing.Point(362, 48);
            this.txtProPonAccDil.Name = "txtProPonAccDil";
            this.txtProPonAccDil.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtProPonAccDil.nNumDecimales = 0;
            this.txtProPonAccDil.nvalor = 0D;
            this.txtProPonAccDil.Size = new System.Drawing.Size(100, 20);
            this.txtProPonAccDil.TabIndex = 1;
            this.txtProPonAccDil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProPonAccDil.Validated += new System.EventHandler(this.txtProPonAccDil_Validated);
            // 
            // txtUtiAccDil
            // 
            this.txtUtiAccDil.Enabled = false;
            this.txtUtiAccDil.FormatoDecimal = true;
            this.txtUtiAccDil.Location = new System.Drawing.Point(362, 152);
            this.txtUtiAccDil.Name = "txtUtiAccDil";
            this.txtUtiAccDil.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUtiAccDil.nNumDecimales = 2;
            this.txtUtiAccDil.nvalor = 0D;
            this.txtUtiAccDil.Size = new System.Drawing.Size(100, 20);
            this.txtUtiAccDil.TabIndex = 7;
            this.txtUtiAccDil.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUtiAccBas
            // 
            this.txtUtiAccBas.Enabled = false;
            this.txtUtiAccBas.FormatoDecimal = true;
            this.txtUtiAccBas.Location = new System.Drawing.Point(362, 126);
            this.txtUtiAccBas.Name = "txtUtiAccBas";
            this.txtUtiAccBas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUtiAccBas.nNumDecimales = 2;
            this.txtUtiAccBas.nvalor = 0D;
            this.txtUtiAccBas.Size = new System.Drawing.Size(100, 20);
            this.txtUtiAccBas.TabIndex = 8;
            this.txtUtiAccBas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(72, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(283, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Promedio Ponderado del N° de Acciones básicas";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(27, 52);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(330, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Promedio Ponderado del N° de Acciones básicas diluidas";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(176, 104);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(179, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Utilidad (Pérdida) del Ejercicio";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(145, 130);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(210, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Utilidad (Pérdida) por Acción básica";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(144, 156);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(211, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Utilidad (Pérdida) por Acción diluida";
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(266, 191);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = false;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(195, 78);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(162, 13);
            this.lblBase7.TabIndex = 19;
            this.lblBase7.Text = "Cuenta Contable Vinculada";
            // 
            // txtCtaCtb
            // 
            this.txtCtaCtb.FormatoDecimal = false;
            this.txtCtaCtb.Location = new System.Drawing.Point(362, 74);
            this.txtCtaCtb.Name = "txtCtaCtb";
            this.txtCtaCtb.nDecValor = new decimal(new int[] {
            3901,
            0,
            0,
            0});
            this.txtCtaCtb.nNumDecimales = 0;
            this.txtCtaCtb.nvalor = 3901D;
            this.txtCtaCtb.Size = new System.Drawing.Size(100, 20);
            this.txtCtaCtb.TabIndex = 2;
            this.txtCtaCtb.Text = "3901";
            this.txtCtaCtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCtaCtb.Validated += new System.EventHandler(this.txtCtaCtb_Validated);
            // 
            // frmRegUtiPerBasDil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 273);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtCtaCtb);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtUtiAccBas);
            this.Controls.Add(this.txtUtiAccDil);
            this.Controls.Add(this.txtProPonAccDil);
            this.Controls.Add(this.txtUtiPerEje);
            this.Controls.Add(this.txtProPonAccBas);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegUtiPerBasDil";
            this.Text = "Registro de Utilidad (Pérdida) Básica y Diluida";
            this.Load += new System.EventHandler(this.frmRegUtiPerBasDil_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.txtProPonAccBas, 0);
            this.Controls.SetChildIndex(this.txtUtiPerEje, 0);
            this.Controls.SetChildIndex(this.txtProPonAccDil, 0);
            this.Controls.SetChildIndex(this.txtUtiAccDil, 0);
            this.Controls.SetChildIndex(this.txtUtiAccBas, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.txtCtaCtb, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtNumRea txtProPonAccBas;
        private GEN.ControlesBase.txtNumRea txtUtiPerEje;
        private GEN.ControlesBase.txtNumRea txtProPonAccDil;
        private GEN.ControlesBase.txtNumRea txtUtiAccDil;
        private GEN.ControlesBase.txtNumRea txtUtiAccBas;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtCtaCtb;
    }
}