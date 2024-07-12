namespace CNT.Presentacion
{
    partial class frmAsientoTrx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientoTrx));
            this.txtCuenta = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboTipoAsiento = new GEN.ControlesBase.cboTipoAsiento(this.components);
            this.SuspendLayout();
            // 
            // txtCuenta
            // 
            this.txtCuenta.FormatoDecimal = false;
            this.txtCuenta.Location = new System.Drawing.Point(174, 97);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuenta.nNumDecimales = 0;
            this.txtCuenta.nvalor = 0D;
            this.txtCuenta.Size = new System.Drawing.Size(100, 20);
            this.txtCuenta.TabIndex = 3;
            this.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(174, 12);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(100, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(174, 40);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(114, 136);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(180, 136);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(59, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(59, 40);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(59, 71);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(82, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Tipo Asiento:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(59, 100);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(115, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Código de Cuenta:";
            // 
            // cboTipoAsiento
            // 
            this.cboTipoAsiento.FormattingEnabled = true;
            this.cboTipoAsiento.Location = new System.Drawing.Point(174, 66);
            this.cboTipoAsiento.Name = "cboTipoAsiento";
            this.cboTipoAsiento.Size = new System.Drawing.Size(121, 21);
            this.cboTipoAsiento.TabIndex = 2;
            // 
            // frmAsientoTrx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 219);
            this.Controls.Add(this.cboTipoAsiento);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.txtCuenta);
            this.Name = "frmAsientoTrx";
            this.Text = "Asiento Contable Transacción";
            this.Controls.SetChildIndex(this.txtCuenta, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboTipoAsiento, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtCuenta;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboTipoAsiento cboTipoAsiento;
    }
}