namespace RPT.Presentacion
{
    partial class frmAnexo06
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnexo06));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRCA = new GEN.BotonesBase.btnBlanco();
            this.btnRCCOD = new GEN.BotonesBase.btnBlanco();
            this.btnRCD = new GEN.BotonesBase.btnBlanco();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(221, 92);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(138, 31);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(103, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(37, 35);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Fecha Proceso:";
            // 
            // btnRCA
            // 
            this.btnRCA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRCA.Enabled = false;
            this.btnRCA.Location = new System.Drawing.Point(85, 92);
            this.btnRCA.Name = "btnRCA";
            this.btnRCA.Size = new System.Drawing.Size(60, 50);
            this.btnRCA.TabIndex = 6;
            this.btnRCA.Text = "RC&A";
            this.btnRCA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRCA.UseVisualStyleBackColor = true;
            this.btnRCA.Click += new System.EventHandler(this.btnRCA_Click);
            // 
            // btnRCCOD
            // 
            this.btnRCCOD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRCCOD.Enabled = false;
            this.btnRCCOD.Location = new System.Drawing.Point(153, 92);
            this.btnRCCOD.Name = "btnRCCOD";
            this.btnRCCOD.Size = new System.Drawing.Size(60, 50);
            this.btnRCCOD.TabIndex = 7;
            this.btnRCCOD.Text = "RCC&OD";
            this.btnRCCOD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRCCOD.UseVisualStyleBackColor = true;
            this.btnRCCOD.Click += new System.EventHandler(this.btnRCCOD_Click);
            // 
            // btnRCD
            // 
            this.btnRCD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRCD.Location = new System.Drawing.Point(17, 92);
            this.btnRCD.Name = "btnRCD";
            this.btnRCD.Size = new System.Drawing.Size(60, 50);
            this.btnRCD.TabIndex = 8;
            this.btnRCD.Text = "RC&D";
            this.btnRCD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRCD.UseVisualStyleBackColor = true;
            this.btnRCD.Click += new System.EventHandler(this.btnRCD_Click);
            // 
            // frmAnexo06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 180);
            this.Controls.Add(this.btnRCD);
            this.Controls.Add(this.btnRCCOD);
            this.Controls.Add(this.btnRCA);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAnexo06";
            this.Text = "Reporte Crediticio de Deudores";
            this.Load += new System.EventHandler(this.frmAnexo06_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnRCA, 0);
            this.Controls.SetChildIndex(this.btnRCCOD, 0);
            this.Controls.SetChildIndex(this.btnRCD, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.BotonesBase.btnBlanco btnRCA;
        private GEN.BotonesBase.btnBlanco btnRCCOD;
        private GEN.BotonesBase.btnBlanco btnRCD;
    }
}