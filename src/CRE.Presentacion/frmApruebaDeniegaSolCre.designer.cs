namespace CRE.Presentacion
{
    partial class frmApruebaDeniegaSolCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApruebaDeniegaSolCre));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.btnDenegar = new GEN.BotonesBase.btnDenegar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNumSolCre = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(186, 78);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Location = new System.Drawing.Point(54, 78);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 1;
            this.btnAprobar.Tag = "2";
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobarDenegar_Click);
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar.BackgroundImage")));
            this.btnDenegar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar.Location = new System.Drawing.Point(120, 78);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar.TabIndex = 2;
            this.btnDenegar.Tag = "4";
            this.btnDenegar.Text = "&Denegar";
            this.btnDenegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnAprobarDenegar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNumSolCre);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(279, 60);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "N° de solicitud:";
            // 
            // txtNumSolCre
            // 
            this.txtNumSolCre.FormatoDecimal = false;
            this.txtNumSolCre.Location = new System.Drawing.Point(128, 19);
            this.txtNumSolCre.Name = "txtNumSolCre";
            this.txtNumSolCre.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumSolCre.nNumDecimales = 4;
            this.txtNumSolCre.nvalor = 0D;
            this.txtNumSolCre.Size = new System.Drawing.Size(108, 20);
            this.txtNumSolCre.TabIndex = 0;
            // 
            // frmApruebaDeniegaSolCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 170);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnDenegar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmApruebaDeniegaSolCre";
            this.Text = "Aprobaciones y denegaciones de créditos";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.btnDenegar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.BotonesBase.btnDenegar btnDenegar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtNumSolCre;
    }
}

