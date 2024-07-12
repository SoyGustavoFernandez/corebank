namespace GEN.ControlesBase
{
    partial class frmConRanMonCarArc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConRanMonCarArc));
            this.txtDescripcionMonto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMontoMinimo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoMaximo = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // txtDescripcionMonto
            // 
            this.txtDescripcionMonto.Location = new System.Drawing.Point(108, 24);
            this.txtDescripcionMonto.Name = "txtDescripcionMonto";
            this.txtDescripcionMonto.Size = new System.Drawing.Size(308, 20);
            this.txtDescripcionMonto.TabIndex = 0;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(10, 27);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(78, 13);
            this.lblBase9.TabIndex = 220;
            this.lblBase9.Text = "Descripción:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 61);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(92, 13);
            this.lblBase1.TabIndex = 222;
            this.lblBase1.Text = "Monto mínimo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(214, 62);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(96, 13);
            this.lblBase2.TabIndex = 223;
            this.lblBase2.Text = "Monto máximo:";
            // 
            // txtMontoMinimo
            // 
            this.txtMontoMinimo.FormatoDecimal = false;
            this.txtMontoMinimo.Location = new System.Drawing.Point(108, 58);
            this.txtMontoMinimo.MaxLength = 40;
            this.txtMontoMinimo.Name = "txtMontoMinimo";
            this.txtMontoMinimo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMinimo.nNumDecimales = 4;
            this.txtMontoMinimo.nvalor = 0D;
            this.txtMontoMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtMontoMinimo.TabIndex = 1;
            // 
            // txtMontoMaximo
            // 
            this.txtMontoMaximo.FormatoDecimal = false;
            this.txtMontoMaximo.Location = new System.Drawing.Point(316, 59);
            this.txtMontoMaximo.MaxLength = 40;
            this.txtMontoMaximo.Name = "txtMontoMaximo";
            this.txtMontoMaximo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMaximo.nNumDecimales = 4;
            this.txtMontoMaximo.nvalor = 0D;
            this.txtMontoMaximo.Size = new System.Drawing.Size(100, 20);
            this.txtMontoMaximo.TabIndex = 2;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(290, 85);
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
            this.btnSalir1.Location = new System.Drawing.Point(356, 85);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmConRanMonCarArc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 163);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.txtMontoMaximo);
            this.Controls.Add(this.txtMontoMinimo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDescripcionMonto);
            this.Controls.Add(this.lblBase9);
            this.Name = "frmConRanMonCarArc";
            this.Text = "Configuación de rango de montos";
            this.Load += new System.EventHandler(this.frmConRanMonCarArc_Load);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtDescripcionMonto, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtMontoMinimo, 0);
            this.Controls.SetChildIndex(this.txtMontoMaximo, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private txtBase txtDescripcionMonto;
        private lblBase lblBase9;
        private lblBase lblBase1;
        private lblBase lblBase2;
        private txtNumRea txtMontoMinimo;
        private txtNumRea txtMontoMaximo;
        private BotonesBase.btnGrabar btnGrabar1;
        private BotonesBase.btnSalir btnSalir1;
    }
}