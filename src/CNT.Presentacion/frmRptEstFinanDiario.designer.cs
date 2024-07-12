namespace CNT.Presentacion
{
    partial class frmRptEstFinanDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptEstFinanDiario));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtpFechaSistema = new GEN.ControlesBase.dtpCorto(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtTrimestral = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtAnual = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(68, 21);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Fecha:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(119, 90);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(208, 90);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtpFechaSistema
            // 
            this.dtpFechaSistema.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSistema.Location = new System.Drawing.Point(119, 18);
            this.dtpFechaSistema.Name = "dtpFechaSistema";
            this.dtpFechaSistema.Size = new System.Drawing.Size(92, 20);
            this.dtpFechaSistema.TabIndex = 16;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtTrimestral);
            this.grbBase1.Controls.Add(this.rbtAnual);
            this.grbBase1.Location = new System.Drawing.Point(28, 40);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(230, 41);
            this.grbBase1.TabIndex = 21;
            this.grbBase1.TabStop = false;
            // 
            // rbtTrimestral
            // 
            this.rbtTrimestral.AutoSize = true;
            this.rbtTrimestral.ForeColor = System.Drawing.Color.Navy;
            this.rbtTrimestral.Location = new System.Drawing.Point(110, 14);
            this.rbtTrimestral.Name = "rbtTrimestral";
            this.rbtTrimestral.Size = new System.Drawing.Size(107, 17);
            this.rbtTrimestral.TabIndex = 19;
            this.rbtTrimestral.Text = "Formato trimestral";
            this.rbtTrimestral.UseVisualStyleBackColor = true;
            // 
            // rbtAnual
            // 
            this.rbtAnual.AutoSize = true;
            this.rbtAnual.Checked = true;
            this.rbtAnual.ForeColor = System.Drawing.Color.Navy;
            this.rbtAnual.Location = new System.Drawing.Point(5, 14);
            this.rbtAnual.Name = "rbtAnual";
            this.rbtAnual.Size = new System.Drawing.Size(92, 17);
            this.rbtAnual.TabIndex = 18;
            this.rbtAnual.TabStop = true;
            this.rbtAnual.Text = "Formato anual";
            this.rbtAnual.UseVisualStyleBackColor = true;
            // 
            // frmRptEstFinanDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 168);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtpFechaSistema);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmRptEstFinanDiario";
            this.Text = "Estados Financieros diarios";
            this.Load += new System.EventHandler(this.frmBalanceGeneral_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpFechaSistema, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFechaSistema;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtTrimestral;
        private GEN.ControlesBase.rbtBase rbtAnual;
    }
}