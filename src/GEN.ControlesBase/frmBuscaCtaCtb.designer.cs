namespace GEN.ControlesBase
{
    partial class frmBuscaCtaCtb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaCtaCtb));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtBusCtaCtb = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conTreePlanCtb = new GEN.ControlesBase.conTreeRecusivo();
            this.lblInidicaUltimoNivel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(53, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Cuenta:";
            // 
            // txtBusCtaCtb
            // 
            this.txtBusCtaCtb.FormatoDecimal = false;
            this.txtBusCtaCtb.Location = new System.Drawing.Point(94, 12);
            this.txtBusCtaCtb.Name = "txtBusCtaCtb";
            this.txtBusCtaCtb.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBusCtaCtb.nNumDecimales = 4;
            this.txtBusCtaCtb.nvalor = 0D;
            this.txtBusCtaCtb.Size = new System.Drawing.Size(186, 20);
            this.txtBusCtaCtb.TabIndex = 4;
            this.txtBusCtaCtb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusCtaCtb_KeyDown);
            this.txtBusCtaCtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(399, 314);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 5;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(467, 314);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conTreePlanCtb
            // 
            this.conTreePlanCtb.Location = new System.Drawing.Point(16, 42);
            this.conTreePlanCtb.Name = "conTreePlanCtb";
            this.conTreePlanCtb.Size = new System.Drawing.Size(511, 263);
            this.conTreePlanCtb.TabIndex = 7;
            this.conTreePlanCtb.Load += new System.EventHandler(this.conTreePlanCtb_Load);
            // 
            // lblInidicaUltimoNivel
            // 
            this.lblInidicaUltimoNivel.AutoSize = true;
            this.lblInidicaUltimoNivel.ForeColor = System.Drawing.Color.Red;
            this.lblInidicaUltimoNivel.Location = new System.Drawing.Point(16, 308);
            this.lblInidicaUltimoNivel.Name = "lblInidicaUltimoNivel";
            this.lblInidicaUltimoNivel.Size = new System.Drawing.Size(124, 13);
            this.lblInidicaUltimoNivel.TabIndex = 8;
            this.lblInidicaUltimoNivel.Text = "cuenta es de último nivel";
            this.lblInidicaUltimoNivel.Visible = false;
            // 
            // frmBuscaCtaCtb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 396);
            this.Controls.Add(this.lblInidicaUltimoNivel);
            this.Controls.Add(this.conTreePlanCtb);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.txtBusCtaCtb);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmBuscaCtaCtb";
            this.Text = "Buscar Cuenta Contable";
            this.Load += new System.EventHandler(this.frmBuscaCtaCtb_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtBusCtaCtb, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conTreePlanCtb, 0);
            this.Controls.SetChildIndex(this.lblInidicaUltimoNivel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private txtNumRea txtBusCtaCtb;
        private BotonesBase.BtnAceptar btnAceptar1;
        private BotonesBase.btnSalir btnSalir1;
        private conTreeRecusivo conTreePlanCtb;
        private System.Windows.Forms.Label lblInidicaUltimoNivel;
    }
}