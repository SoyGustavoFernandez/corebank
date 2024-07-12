namespace RCP.Presentacion
{
    partial class frmAlertaVisitaRecup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertaVisitaRecup));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtDiasVencer = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.cboPersonalCargo1 = new GEN.ControlesBase.cboPersonalCargo(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(171, 121);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(24, 31);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(100, 31);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Días antes de vencer:";
            // 
            // txtDiasVencer
            // 
            this.txtDiasVencer.FormatoDecimal = false;
            this.txtDiasVencer.Location = new System.Drawing.Point(115, 31);
            this.txtDiasVencer.Name = "txtDiasVencer";
            this.txtDiasVencer.nDecValor = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDiasVencer.nNumDecimales = 0;
            this.txtDiasVencer.nvalor = 1D;
            this.txtDiasVencer.Size = new System.Drawing.Size(44, 20);
            this.txtDiasVencer.TabIndex = 7;
            this.txtDiasVencer.Text = "1";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(99, 121);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 8;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // cboPersonalCargo1
            // 
            this.cboPersonalCargo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonalCargo1.FormattingEnabled = true;
            this.cboPersonalCargo1.Location = new System.Drawing.Point(115, 71);
            this.cboPersonalCargo1.Name = "cboPersonalCargo1";
            this.cboPersonalCargo1.Size = new System.Drawing.Size(207, 21);
            this.cboPersonalCargo1.TabIndex = 9;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(24, 74);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(85, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Recuperador:";
            // 
            // frmAlertaVisitaRecup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 205);
            this.Controls.Add(this.cboPersonalCargo1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.txtDiasVencer);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAlertaVisitaRecup";
            this.Text = "Reporte de Alerta de Visita a Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtDiasVencer, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.cboPersonalCargo1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtDiasVencer;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.cboPersonalCargo cboPersonalCargo1;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}

