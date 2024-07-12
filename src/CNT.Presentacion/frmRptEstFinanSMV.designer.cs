namespace CNT.Presentacion
{
    partial class frmRptEstFinanSMV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptEstFinanSMV));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtpFechaSistema = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rbtAnual = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtTrimestral = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(70, 15);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Fecha:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(178, 82);
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
            this.dtpFechaSistema.Location = new System.Drawing.Point(121, 12);
            this.dtpFechaSistema.Name = "dtpFechaSistema";
            this.dtpFechaSistema.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaSistema.TabIndex = 16;
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(88, 82);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 17;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
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
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtTrimestral);
            this.grbBase1.Controls.Add(this.rbtAnual);
            this.grbBase1.Location = new System.Drawing.Point(29, 35);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(230, 41);
            this.grbBase1.TabIndex = 20;
            this.grbBase1.TabStop = false;
            // 
            // frmRptEstFinanSMV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 160);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.dtpFechaSistema);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmRptEstFinanSMV";
            this.Text = "Estados Financieros SMV";
            this.Load += new System.EventHandler(this.frmBalanceGeneral_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpFechaSistema, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFechaSistema;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.rbtBase rbtAnual;
        private GEN.ControlesBase.rbtBase rbtTrimestral;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}