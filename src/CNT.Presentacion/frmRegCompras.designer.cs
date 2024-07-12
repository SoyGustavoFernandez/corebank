namespace CNT.Presentacion
{
    partial class frmRegCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegCompras));
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLibRet = new GEN.BotonesBase.btnBlanco();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnExporTxt1 = new GEN.BotonesBase.btnExporTxt();
            this.btnExporTxt2 = new GEN.BotonesBase.btnExporTxt();
            this.SuspendLayout();
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(147, 31);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(112, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(147, 52);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(112, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(49, 35);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(49, 56);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // btnLibRet
            // 
            this.btnLibRet.BackgroundImage = global::CNT.Presentacion.Properties.Resources.btnImprimir;
            this.btnLibRet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLibRet.Location = new System.Drawing.Point(38, 98);
            this.btnLibRet.Name = "btnLibRet";
            this.btnLibRet.Size = new System.Drawing.Size(60, 50);
            this.btnLibRet.TabIndex = 2;
            this.btnLibRet.Text = "&Reg Com";
            this.btnLibRet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLibRet.UseVisualStyleBackColor = true;
            this.btnLibRet.Click += new System.EventHandler(this.btnLibCaja_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(218, 98);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnExporTxt1
            // 
            this.btnExporTxt1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporTxt1.BackgroundImage")));
            this.btnExporTxt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporTxt1.Location = new System.Drawing.Point(98, 98);
            this.btnExporTxt1.Name = "btnExporTxt1";
            this.btnExporTxt1.Size = new System.Drawing.Size(60, 50);
            this.btnExporTxt1.TabIndex = 3;
            this.btnExporTxt1.Text = "A&rchivo";
            this.btnExporTxt1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporTxt1.UseVisualStyleBackColor = true;
            this.btnExporTxt1.Click += new System.EventHandler(this.btnExporTxt1_Click);
            // 
            // btnExporTxt2
            // 
            this.btnExporTxt2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporTxt2.BackgroundImage")));
            this.btnExporTxt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporTxt2.Location = new System.Drawing.Point(158, 98);
            this.btnExporTxt2.Name = "btnExporTxt2";
            this.btnExporTxt2.Size = new System.Drawing.Size(60, 50);
            this.btnExporTxt2.TabIndex = 4;
            this.btnExporTxt2.Text = "A&rchivo";
            this.btnExporTxt2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporTxt2.UseVisualStyleBackColor = true;
            this.btnExporTxt2.Click += new System.EventHandler(this.btnExporTxt2_Click);
            // 
            // frmRegCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 193);
            this.Controls.Add(this.btnExporTxt2);
            this.Controls.Add(this.btnExporTxt1);
            this.Controls.Add(this.btnLibRet);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Name = "frmRegCompras";
            this.Text = "Registro Compras";
            this.Load += new System.EventHandler(this.frmLibroDia_Load);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnLibRet, 0);
            this.Controls.SetChildIndex(this.btnExporTxt1, 0);
            this.Controls.SetChildIndex(this.btnExporTxt2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.BotonesBase.btnBlanco btnLibRet;
        private GEN.BotonesBase.btnExporTxt btnExporTxt1;
        private GEN.BotonesBase.btnExporTxt btnExporTxt2;
    }
}