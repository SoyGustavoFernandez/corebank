namespace CRE.Presentacion
{
    partial class frmRptCreditosDctoPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCreditosDctoPlanilla));
            this.dtpFechaProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.rbtnCesados = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnActivos = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbEstadoEmpleado = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnExporTxt = new GEN.BotonesBase.btnExporTxt();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnExporPdf = new GEN.BotonesBase.btnExporPdf();
            this.grbEstadoEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaProceso
            // 
            this.dtpFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaProceso.Location = new System.Drawing.Point(97, 19);
            this.dtpFechaProceso.Name = "dtpFechaProceso";
            this.dtpFechaProceso.Size = new System.Drawing.Size(82, 20);
            this.dtpFechaProceso.TabIndex = 3;
            // 
            // rbtnCesados
            // 
            this.rbtnCesados.AutoSize = true;
            this.rbtnCesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnCesados.Location = new System.Drawing.Point(84, 13);
            this.rbtnCesados.Name = "rbtnCesados";
            this.rbtnCesados.Size = new System.Drawing.Size(66, 17);
            this.rbtnCesados.TabIndex = 9;
            this.rbtnCesados.Text = "Cesados";
            this.rbtnCesados.UseVisualStyleBackColor = true;
            // 
            // rbtnActivos
            // 
            this.rbtnActivos.AutoSize = true;
            this.rbtnActivos.Checked = true;
            this.rbtnActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnActivos.Location = new System.Drawing.Point(10, 13);
            this.rbtnActivos.Name = "rbtnActivos";
            this.rbtnActivos.Size = new System.Drawing.Size(60, 17);
            this.rbtnActivos.TabIndex = 8;
            this.rbtnActivos.TabStop = true;
            this.rbtnActivos.Text = "Activos";
            this.rbtnActivos.UseVisualStyleBackColor = true;
            // 
            // grbEstadoEmpleado
            // 
            this.grbEstadoEmpleado.Controls.Add(this.rbtnCesados);
            this.grbEstadoEmpleado.Controls.Add(this.rbtnActivos);
            this.grbEstadoEmpleado.Location = new System.Drawing.Point(27, 47);
            this.grbEstadoEmpleado.Name = "grbEstadoEmpleado";
            this.grbEstadoEmpleado.Size = new System.Drawing.Size(160, 38);
            this.grbEstadoEmpleado.TabIndex = 10;
            this.grbEstadoEmpleado.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(147, 100);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(36, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 14;
            this.lblBase1.Text = "Fecha:";
            // 
            // btnExporTxt
            // 
            this.btnExporTxt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporTxt.BackgroundImage")));
            this.btnExporTxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporTxt.Location = new System.Drawing.Point(70, 100);
            this.btnExporTxt.Name = "btnExporTxt";
            this.btnExporTxt.Size = new System.Drawing.Size(60, 50);
            this.btnExporTxt.TabIndex = 15;
            this.btnExporTxt.Text = "A&rchivo";
            this.btnExporTxt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporTxt.UseVisualStyleBackColor = true;
            this.btnExporTxt.Click += new System.EventHandler(this.btnExporTxt_Click);
            // 
            // btnExporPdf
            // 
            this.btnExporPdf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporPdf.BackgroundImage")));
            this.btnExporPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporPdf.Location = new System.Drawing.Point(8, 100);
            this.btnExporPdf.Name = "btnExporPdf";
            this.btnExporPdf.Size = new System.Drawing.Size(60, 50);
            this.btnExporPdf.TabIndex = 16;
            this.btnExporPdf.Text = "P&df";
            this.btnExporPdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporPdf.UseVisualStyleBackColor = true;
            this.btnExporPdf.Click += new System.EventHandler(this.btnExporPdf_Click);
            // 
            // frmRptCreditosDctoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 182);
            this.Controls.Add(this.btnExporPdf);
            this.Controls.Add(this.btnExporTxt);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbEstadoEmpleado);
            this.Controls.Add(this.dtpFechaProceso);
            this.Name = "frmRptCreditosDctoPlanilla";
            this.Text = "Creditos Dcto Planillas";
            this.Load += new System.EventHandler(this.frmRptCreditosDctoPlanilla_Load);
            this.Controls.SetChildIndex(this.dtpFechaProceso, 0);
            this.Controls.SetChildIndex(this.grbEstadoEmpleado, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnExporTxt, 0);
            this.Controls.SetChildIndex(this.btnExporPdf, 0);
            this.grbEstadoEmpleado.ResumeLayout(false);
            this.grbEstadoEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFechaProceso;
        private GEN.ControlesBase.rbtnBase rbtnCesados;
        private GEN.ControlesBase.rbtnBase rbtnActivos;
        private GEN.ControlesBase.grbBase grbEstadoEmpleado;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnExporTxt btnExporTxt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private GEN.BotonesBase.btnExporPdf btnExporPdf;

    }
}

