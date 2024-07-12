namespace CNT.Presentacion
{
    partial class frmLibroCajaBco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroCajaBco));
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLibBco = new GEN.BotonesBase.btnBlanco();
            this.btnLibCaja = new GEN.BotonesBase.btnBlanco();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnExportar1 = new GEN.BotonesBase.btnExportar();
            this.btnExportar2 = new GEN.BotonesBase.btnExportar();
            this.SuspendLayout();
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(147, 29);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(121, 20);
            this.dtpFecIni.TabIndex = 2;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(147, 50);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFecFin.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(58, 33);
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
            this.lblBase2.Location = new System.Drawing.Point(58, 54);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // btnLibBco
            // 
            this.btnLibBco.BackgroundImage = global::CNT.Presentacion.Properties.Resources.btnImprimir;
            this.btnLibBco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLibBco.Location = new System.Drawing.Point(124, 106);
            this.btnLibBco.Name = "btnLibBco";
            this.btnLibBco.Size = new System.Drawing.Size(60, 50);
            this.btnLibBco.TabIndex = 12;
            this.btnLibBco.Text = "Lib&Bco";
            this.btnLibBco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLibBco.UseVisualStyleBackColor = true;
            this.btnLibBco.Click += new System.EventHandler(this.btnLibBco_Click);
            // 
            // btnLibCaja
            // 
            this.btnLibCaja.BackgroundImage = global::CNT.Presentacion.Properties.Resources.btnImprimir;
            this.btnLibCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLibCaja.Location = new System.Drawing.Point(4, 106);
            this.btnLibCaja.Name = "btnLibCaja";
            this.btnLibCaja.Size = new System.Drawing.Size(60, 50);
            this.btnLibCaja.TabIndex = 11;
            this.btnLibCaja.Text = "Lib&Caja";
            this.btnLibCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLibCaja.UseVisualStyleBackColor = true;
            this.btnLibCaja.Click += new System.EventHandler(this.btnLibCaja_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(244, 106);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(147, 76);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 13;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(58, 79);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Moneda:";
            // 
            // btnExportar1
            // 
            this.btnExportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar1.BackgroundImage")));
            this.btnExportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar1.Location = new System.Drawing.Point(64, 106);
            this.btnExportar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportar1.Name = "btnExportar1";
            this.btnExportar1.Size = new System.Drawing.Size(60, 50);
            this.btnExportar1.TabIndex = 15;
            this.btnExportar1.Text = "E&xportar";
            this.btnExportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar1.UseVisualStyleBackColor = true;
            this.btnExportar1.Click += new System.EventHandler(this.btnExportar1_Click);
            // 
            // btnExportar2
            // 
            this.btnExportar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar2.BackgroundImage")));
            this.btnExportar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar2.Location = new System.Drawing.Point(184, 106);
            this.btnExportar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportar2.Name = "btnExportar2";
            this.btnExportar2.Size = new System.Drawing.Size(60, 50);
            this.btnExportar2.TabIndex = 16;
            this.btnExportar2.Text = "E&xportar";
            this.btnExportar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar2.UseVisualStyleBackColor = true;
            this.btnExportar2.Click += new System.EventHandler(this.btnExportar2_Click);
            // 
            // frmLibroCajaBco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 193);
            this.Controls.Add(this.btnExportar2);
            this.Controls.Add(this.btnExportar1);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnLibBco);
            this.Controls.Add(this.btnLibCaja);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLibroCajaBco";
            this.Text = "Libro Caja y Bancos";
            this.Load += new System.EventHandler(this.frmLibroDia_Load);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnLibCaja, 0);
            this.Controls.SetChildIndex(this.btnLibBco, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.btnExportar1, 0);
            this.Controls.SetChildIndex(this.btnExportar2, 0);
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
        private GEN.BotonesBase.btnBlanco btnLibCaja;
        private GEN.BotonesBase.btnBlanco btnLibBco;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnExportar btnExportar1;
        private GEN.BotonesBase.btnExportar btnExportar2;
    }
}