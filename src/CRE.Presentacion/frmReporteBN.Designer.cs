namespace CRE.Presentacion
{
    partial class frmReporteBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteBN));
            this.dtpFechaProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCobranza = new GEN.BotonesBase.btnBlanco();
            this.btnDesembolso = new GEN.BotonesBase.btnBlanco();
            this.SuspendLayout();
            // 
            // dtpFechaProceso
            // 
            this.dtpFechaProceso.Location = new System.Drawing.Point(139, 33);
            this.dtpFechaProceso.Name = "dtpFechaProceso";
            this.dtpFechaProceso.Size = new System.Drawing.Size(94, 20);
            this.dtpFechaProceso.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(34, 37);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Fecha Proceso:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(170, 79);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCobranza
            // 
            this.btnCobranza.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnCobranza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCobranza.Location = new System.Drawing.Point(102, 79);
            this.btnCobranza.Name = "btnCobranza";
            this.btnCobranza.Size = new System.Drawing.Size(60, 50);
            this.btnCobranza.TabIndex = 5;
            this.btnCobranza.Text = "&Cobranza";
            this.btnCobranza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCobranza.UseVisualStyleBackColor = true;
            this.btnCobranza.Click += new System.EventHandler(this.btnCobranza_Click);
            // 
            // btnDesembolso
            // 
            this.btnDesembolso.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnDesembolso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDesembolso.Location = new System.Drawing.Point(34, 79);
            this.btnDesembolso.Name = "btnDesembolso";
            this.btnDesembolso.Size = new System.Drawing.Size(60, 50);
            this.btnDesembolso.TabIndex = 6;
            this.btnDesembolso.Text = "&Desem";
            this.btnDesembolso.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesembolso.UseVisualStyleBackColor = true;
            this.btnDesembolso.Click += new System.EventHandler(this.btnDesembolso_Click);
            // 
            // frmReporteBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 171);
            this.Controls.Add(this.btnDesembolso);
            this.Controls.Add(this.btnCobranza);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaProceso);
            this.Name = "frmReporteBN";
            this.Text = "Archivos procesados BN";
            this.Controls.SetChildIndex(this.dtpFechaProceso, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCobranza, 0);
            this.Controls.SetChildIndex(this.btnDesembolso, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFechaProceso;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnBlanco btnCobranza;
        private GEN.BotonesBase.btnBlanco btnDesembolso;
    }
}