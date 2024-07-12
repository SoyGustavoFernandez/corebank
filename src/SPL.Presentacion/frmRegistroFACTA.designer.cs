namespace SPL.Presentacion
{
    partial class frmRegistroFACTA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroFACTA));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnFactaNo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnFactaSi = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnResiUSNo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnResiUSSi = new GEN.ControlesBase.rbtnBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(502, 250);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtnFactaNo);
            this.grbBase1.Controls.Add(this.rbtnFactaSi);
            this.grbBase1.Location = new System.Drawing.Point(16, 19);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(359, 43);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Acepta ser Afecto al Régimen FATCA";
            // 
            // rbtnFactaNo
            // 
            this.rbtnFactaNo.AutoSize = true;
            this.rbtnFactaNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnFactaNo.Location = new System.Drawing.Point(92, 19);
            this.rbtnFactaNo.Name = "rbtnFactaNo";
            this.rbtnFactaNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnFactaNo.TabIndex = 0;
            this.rbtnFactaNo.TabStop = true;
            this.rbtnFactaNo.Text = "No";
            this.rbtnFactaNo.UseVisualStyleBackColor = true;
            this.rbtnFactaNo.CheckedChanged += new System.EventHandler(this.rbtnFactaNo_CheckedChanged);
            // 
            // rbtnFactaSi
            // 
            this.rbtnFactaSi.AutoSize = true;
            this.rbtnFactaSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnFactaSi.Location = new System.Drawing.Point(15, 19);
            this.rbtnFactaSi.Name = "rbtnFactaSi";
            this.rbtnFactaSi.Size = new System.Drawing.Size(36, 17);
            this.rbtnFactaSi.TabIndex = 0;
            this.rbtnFactaSi.TabStop = true;
            this.rbtnFactaSi.Text = "Sí";
            this.rbtnFactaSi.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtnResiUSNo);
            this.grbBase2.Controls.Add(this.rbtnResiUSSi);
            this.grbBase2.Location = new System.Drawing.Point(16, 68);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(359, 43);
            this.grbBase2.TabIndex = 4;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "El Cliente Declara Ser Residente en los Estados Unidos";
            // 
            // rbtnResiUSNo
            // 
            this.rbtnResiUSNo.AutoSize = true;
            this.rbtnResiUSNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnResiUSNo.Location = new System.Drawing.Point(92, 19);
            this.rbtnResiUSNo.Name = "rbtnResiUSNo";
            this.rbtnResiUSNo.Size = new System.Drawing.Size(39, 17);
            this.rbtnResiUSNo.TabIndex = 0;
            this.rbtnResiUSNo.TabStop = true;
            this.rbtnResiUSNo.Text = "No";
            this.rbtnResiUSNo.UseVisualStyleBackColor = true;
            // 
            // rbtnResiUSSi
            // 
            this.rbtnResiUSSi.AutoSize = true;
            this.rbtnResiUSSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnResiUSSi.Location = new System.Drawing.Point(15, 19);
            this.rbtnResiUSSi.Name = "rbtnResiUSSi";
            this.rbtnResiUSSi.Size = new System.Drawing.Size(36, 17);
            this.rbtnResiUSSi.TabIndex = 0;
            this.rbtnResiUSSi.TabStop = true;
            this.rbtnResiUSSi.Text = "Sí";
            this.rbtnResiUSSi.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(184, 117);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 6;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(250, 117);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 7;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.Location = new System.Drawing.Point(316, 117);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 8;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // frmRegistroFACTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 201);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegistroFACTA";
            this.Text = "Registro US Person";
            this.Load += new System.EventHandler(this.frmRegistroFACTA_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtnBase rbtnFactaNo;
        private GEN.ControlesBase.rbtnBase rbtnFactaSi;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.rbtnBase rbtnResiUSNo;
        private GEN.ControlesBase.rbtnBase rbtnResiUSSi;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir2;
    }
}