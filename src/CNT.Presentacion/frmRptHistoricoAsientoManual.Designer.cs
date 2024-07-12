namespace CNT.Presentacion
{
    partial class frmRptHistoricoAsientoManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptHistoricoAsientoManual));
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblFecIni = new GEN.ControlesBase.lblBase();
            this.lblFecFin = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNumVoucher = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(126, 132);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(230, 133);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblFecIni
            // 
            this.lblFecIni.AutoSize = true;
            this.lblFecIni.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecIni.ForeColor = System.Drawing.Color.Navy;
            this.lblFecIni.Location = new System.Drawing.Point(13, 25);
            this.lblFecIni.Name = "lblFecIni";
            this.lblFecIni.Size = new System.Drawing.Size(60, 13);
            this.lblFecIni.TabIndex = 4;
            this.lblFecIni.Text = "Desde :  ";
            // 
            // lblFecFin
            // 
            this.lblFecFin.AutoSize = true;
            this.lblFecFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecFin.ForeColor = System.Drawing.Color.Navy;
            this.lblFecFin.Location = new System.Drawing.Point(13, 52);
            this.lblFecFin.Name = "lblFecFin";
            this.lblFecFin.Size = new System.Drawing.Size(56, 13);
            this.lblFecFin.TabIndex = 5;
            this.lblFecFin.Text = "Hasta :  ";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(79, 22);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(137, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(79, 49);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(137, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.lblFecIni);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblFecFin);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 43);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(278, 83);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Fecha";
            // 
            // txtNumVoucher
            // 
            this.txtNumVoucher.FormatoDecimal = false;
            this.txtNumVoucher.Location = new System.Drawing.Point(78, 12);
            this.txtNumVoucher.MaxLength = 9;
            this.txtNumVoucher.Name = "txtNumVoucher";
            this.txtNumVoucher.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumVoucher.nNumDecimales = 0;
            this.txtNumVoucher.nvalor = 0D;
            this.txtNumVoucher.Size = new System.Drawing.Size(137, 20);
            this.txtNumVoucher.TabIndex = 0;
            this.txtNumVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 16);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(72, 13);
            this.lblBase4.TabIndex = 16;
            this.lblBase4.Text = "N° Asiento:";
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.ForeColor = System.Drawing.Color.Navy;
            this.chcTodos.Location = new System.Drawing.Point(216, 14);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 1;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.chcTodos);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.txtNumVoucher);
            this.grbBase2.Location = new System.Drawing.Point(12, 4);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(278, 37);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            // 
            // frmRptHistoricoAsientoManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 213);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptHistoricoAsientoManual";
            this.Text = "Histórico de cambios de los asientos";
            this.Load += new System.EventHandler(this.frmRptHistoricoAsientoManual_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblFecIni;
        private GEN.ControlesBase.lblBase lblFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtNumRea txtNumVoucher;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.grbBase grbBase2;
    }
}