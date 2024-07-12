namespace GEN.ControlesBase
{
    partial class frmMotivoAutUsoDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotivoAutUsoDatos));
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMotivoAutUsoDatos1 = new GEN.ControlesBase.cboMotivoAutUsoDatos(this.components);
            this.btnAdjuntarFile1 = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            this.btnLeer1 = new GEN.BotonesBase.btnLeer();
            this.SuspendLayout();
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(157, 115);
            this.btnAceptar1.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 24);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Motivo:";
            // 
            // cboMotivoAutUsoDatos1
            // 
            this.cboMotivoAutUsoDatos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoAutUsoDatos1.FormattingEnabled = true;
            this.cboMotivoAutUsoDatos1.Location = new System.Drawing.Point(64, 21);
            this.cboMotivoAutUsoDatos1.Margin = new System.Windows.Forms.Padding(2);
            this.cboMotivoAutUsoDatos1.Name = "cboMotivoAutUsoDatos1";
            this.cboMotivoAutUsoDatos1.Size = new System.Drawing.Size(259, 21);
            this.cboMotivoAutUsoDatos1.TabIndex = 4;
            // 
            // btnAdjuntarFile1
            // 
            this.btnAdjuntarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdjuntarFile1.BackgroundImage")));
            this.btnAdjuntarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdjuntarFile1.Enabled = false;
            this.btnAdjuntarFile1.Location = new System.Drawing.Point(157, 53);
            this.btnAdjuntarFile1.Name = "btnAdjuntarFile1";
            this.btnAdjuntarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnAdjuntarFile1.TabIndex = 5;
            this.btnAdjuntarFile1.Text = "Importar";
            this.btnAdjuntarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdjuntarFile1.UseVisualStyleBackColor = true;
            this.btnAdjuntarFile1.Click += new System.EventHandler(this.btnAdjuntarFile1_Click);
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(91, 53);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 8;
            this.btnImprimir2.Text = "Imprimir";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // btnLeer1
            // 
            this.btnLeer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeer1.BackgroundImage")));
            this.btnLeer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLeer1.Location = new System.Drawing.Point(223, 53);
            this.btnLeer1.Name = "btnLeer1";
            this.btnLeer1.Size = new System.Drawing.Size(60, 50);
            this.btnLeer1.TabIndex = 12;
            this.btnLeer1.Text = "&Leer";
            this.btnLeer1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeer1.UseVisualStyleBackColor = true;
            this.btnLeer1.Click += new System.EventHandler(this.btnLeer1_Click);
            // 
            // frmMotivoAutUsoDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 198);
            this.Controls.Add(this.btnLeer1);
            this.Controls.Add(this.btnImprimir2);
            this.Controls.Add(this.btnAdjuntarFile1);
            this.Controls.Add(this.cboMotivoAutUsoDatos1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnAceptar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMotivoAutUsoDatos";
            this.Text = "Motivo autorización de uso de datos";
            this.Load += new System.EventHandler(this.frmMotivoAutUsoDatos_Load);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboMotivoAutUsoDatos1, 0);
            this.Controls.SetChildIndex(this.btnAdjuntarFile1, 0);
            this.Controls.SetChildIndex(this.btnImprimir2, 0);
            this.Controls.SetChildIndex(this.btnLeer1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.BtnAceptar btnAceptar1;
        private lblBase lblBase1;
        private cboMotivoAutUsoDatos cboMotivoAutUsoDatos1;
        private BotonesBase.btnAdjuntarFile btnAdjuntarFile1;
        private BotonesBase.btnImprimir btnImprimir2;
        private BotonesBase.btnLeer btnLeer1;
    }
}