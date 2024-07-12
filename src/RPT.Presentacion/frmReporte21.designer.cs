namespace RPT.Presentacion
{
    partial class frmReporte21
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporte21));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnBlanco1 = new GEN.BotonesBase.btnBlanco();
            this.btn20A = new GEN.BotonesBase.btnBlanco();
            this.dtpFecProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(176, 76);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 19;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnBlanco1
            // 
            this.btnBlanco1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            //this.btnBlanco1.BackgroundImage = global::RPT.Presentacion.Properties.Resources.btnImprimir;
            this.btnBlanco1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco1.Location = new System.Drawing.Point(56, 76);
            this.btnBlanco1.Name = "btnBlanco1";
            this.btnBlanco1.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco1.TabIndex = 25;
            this.btnBlanco1.Text = "Rep &21";
            this.btnBlanco1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco1.UseVisualStyleBackColor = true;
            this.btnBlanco1.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // btn20A
            // 
            this.btn20A.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            //this.btn20A.BackgroundImage = global::RPT.Presentacion.Properties.Resources.btnImprimir;
            this.btn20A.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn20A.Location = new System.Drawing.Point(116, 76);
            this.btn20A.Name = "btn20A";
            this.btn20A.Size = new System.Drawing.Size(60, 50);
            this.btn20A.TabIndex = 26;
            this.btn20A.Text = "Rep 21&A";
            this.btn20A.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn20A.UseVisualStyleBackColor = true;
            this.btn20A.Click += new System.EventHandler(this.btn20A_Click);
            // 
            // dtpFecProceso
            // 
            this.dtpFecProceso.Location = new System.Drawing.Point(154, 34);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(86, 20);
            this.dtpFecProceso.TabIndex = 27;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(52, 38);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 28;
            this.lblBase1.Text = "Fecha Proceso:";
            // 
            // frmReporte21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 178);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecProceso);
            this.Controls.Add(this.btn20A);
            this.Controls.Add(this.btnBlanco1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmReporte21";
            this.Text = "Reporte 21";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnBlanco1, 0);
            this.Controls.SetChildIndex(this.btn20A, 0);
            this.Controls.SetChildIndex(this.dtpFecProceso, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnBlanco btnBlanco1;
        private GEN.BotonesBase.btnBlanco btn20A;
        private GEN.ControlesBase.dtpCorto dtpFecProceso;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}

