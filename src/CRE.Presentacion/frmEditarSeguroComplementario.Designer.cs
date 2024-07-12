namespace CRE.Presentacion
{
    partial class frmEditarSeguroComplementario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarSeguroComplementario));
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.chcSegComplementario = new GEN.ControlesBase.chcBase(this.components);
            this.txtPrecio = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(256, 134);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 0;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(322, 134);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 1;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(23, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(97, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Nombre Seguro";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(46, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(74, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Abreviatura";
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(318, 105);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 4;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(126, 19);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(256, 20);
            this.txtBase1.TabIndex = 5;
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(126, 46);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(256, 20);
            this.txtBase2.TabIndex = 6;
            // 
            // chcSegComplementario
            // 
            this.chcSegComplementario.AutoSize = true;
            this.chcSegComplementario.Location = new System.Drawing.Point(126, 105);
            this.chcSegComplementario.Name = "chcSegComplementario";
            this.chcSegComplementario.Size = new System.Drawing.Size(101, 17);
            this.chcSegComplementario.TabIndex = 7;
            this.chcSegComplementario.Text = "Complementario";
            this.chcSegComplementario.UseVisualStyleBackColor = true;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(126, 72);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(256, 20);
            this.txtPrecio.TabIndex = 9;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(78, 75);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(42, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Precio";
            // 
            // frmEditarSeguroComplementario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 213);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.chcSegComplementario);
            this.Controls.Add(this.txtBase2);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmEditarSeguroComplementario";
            this.Text = "Seguro Complementario";
            this.Load += new System.EventHandler(this.frmEditarSeguroComplementario_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.txtBase2, 0);
            this.Controls.SetChildIndex(this.chcSegComplementario, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtPrecio, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.chcBase chcSegComplementario;
        private GEN.ControlesBase.txtNumRea txtPrecio;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}