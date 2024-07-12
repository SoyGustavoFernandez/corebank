namespace CRE.Presentacion
{
    partial class frmRptConcCarteraZonaDistrito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptConcCarteraZonaDistrito));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.dtpFecReporte = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.rbtDistrito = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtProvincia = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(195, 122);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(108, 122);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // dtpFecReporte
            // 
            this.dtpFecReporte.Location = new System.Drawing.Point(94, 10);
            this.dtpFecReporte.Name = "dtpFecReporte";
            this.dtpFecReporte.Size = new System.Drawing.Size(131, 20);
            this.dtpFecReporte.TabIndex = 8;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Fecha:";
            // 
            // rbtDistrito
            // 
            this.rbtDistrito.AutoSize = true;
            this.rbtDistrito.Checked = true;
            this.rbtDistrito.ForeColor = System.Drawing.Color.Navy;
            this.rbtDistrito.Location = new System.Drawing.Point(29, 47);
            this.rbtDistrito.Name = "rbtDistrito";
            this.rbtDistrito.Size = new System.Drawing.Size(107, 17);
            this.rbtDistrito.TabIndex = 10;
            this.rbtDistrito.TabStop = true;
            this.rbtDistrito.Text = "A nivel de Distrito";
            this.rbtDistrito.UseVisualStyleBackColor = true;
            // 
            // rbtProvincia
            // 
            this.rbtProvincia.AutoSize = true;
            this.rbtProvincia.ForeColor = System.Drawing.Color.Navy;
            this.rbtProvincia.Location = new System.Drawing.Point(29, 70);
            this.rbtProvincia.Name = "rbtProvincia";
            this.rbtProvincia.Size = new System.Drawing.Size(119, 17);
            this.rbtProvincia.TabIndex = 11;
            this.rbtProvincia.Text = "A nivel de Provincia";
            this.rbtProvincia.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtDistrito);
            this.grbBase1.Controls.Add(this.rbtProvincia);
            this.grbBase1.Controls.Add(this.dtpFecReporte);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(31, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(294, 104);
            this.grbBase1.TabIndex = 12;
            this.grbBase1.TabStop = false;
            // 
            // frmRptConcCarteraZonaDistrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 203);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRptConcCarteraZonaDistrito";
            this.Text = "Reporte de concentración de cartera";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.dtpCorto dtpFecReporte;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.rbtBase rbtDistrito;
        private GEN.ControlesBase.rbtBase rbtProvincia;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}

