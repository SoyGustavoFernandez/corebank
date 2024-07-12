namespace DEP.Presentacion
{
    partial class frmClientesPrincipales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientesPrincipales));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtCBNumTop = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.dtpFechaCorte = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFecFin = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtHistorico = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtFecha = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(221, 209);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(155, 209);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(20, 173);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(147, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Nro Clientes Principales:";
            // 
            // txtCBNumTop
            // 
            this.txtCBNumTop.Location = new System.Drawing.Point(173, 170);
            this.txtCBNumTop.Name = "txtCBNumTop";
            this.txtCBNumTop.Size = new System.Drawing.Size(100, 20);
            this.txtCBNumTop.TabIndex = 13;
            this.txtCBNumTop.Text = "0";
            this.txtCBNumTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFechaCorte
            // 
            this.dtpFechaCorte.Enabled = false;
            this.dtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCorte.Location = new System.Drawing.Point(173, 137);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaCorte.TabIndex = 14;
            // 
            // lblFecFin
            // 
            this.lblFecFin.AutoSize = true;
            this.lblFecFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecFin.ForeColor = System.Drawing.Color.Navy;
            this.lblFecFin.Location = new System.Drawing.Point(19, 140);
            this.lblFecFin.Name = "lblFecFin";
            this.lblFecFin.Size = new System.Drawing.Size(112, 13);
            this.lblFecFin.TabIndex = 15;
            this.lblFecFin.Text = "Fecha de Proceso:";
            // 
            // lblBase11
            // 
            this.lblBase11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblBase11.Location = new System.Drawing.Point(12, 9);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(273, 47);
            this.lblBase11.TabIndex = 115;
            this.lblBase11.Text = "Listado de los clientes que tienen mayor saldo. En el listado, no se considera la" +
    "s Cuentas Corrientes.";
            this.lblBase11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtHistorico);
            this.grbBase1.Controls.Add(this.rbtFecha);
            this.grbBase1.Location = new System.Drawing.Point(12, 61);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(273, 56);
            this.grbBase1.TabIndex = 116;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Criterio para el Listado";
            // 
            // rbtHistorico
            // 
            this.rbtHistorico.AutoSize = true;
            this.rbtHistorico.ForeColor = System.Drawing.Color.Navy;
            this.rbtHistorico.Location = new System.Drawing.Point(165, 26);
            this.rbtHistorico.Name = "rbtHistorico";
            this.rbtHistorico.Size = new System.Drawing.Size(66, 17);
            this.rbtHistorico.TabIndex = 1;
            this.rbtHistorico.Text = "Historico";
            this.rbtHistorico.UseVisualStyleBackColor = true;
            this.rbtHistorico.CheckedChanged += new System.EventHandler(this.rbtHistorico_CheckedChanged);
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.Checked = true;
            this.rbtFecha.ForeColor = System.Drawing.Color.Navy;
            this.rbtFecha.Location = new System.Drawing.Point(11, 26);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(76, 17);
            this.rbtFecha.TabIndex = 0;
            this.rbtFecha.TabStop = true;
            this.rbtFecha.Text = "A la Fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtBase1_CheckedChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(12, 121);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(273, 82);
            this.grbBase2.TabIndex = 117;
            this.grbBase2.TabStop = false;
            // 
            // frmClientesPrincipales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 287);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.lblFecFin);
            this.Controls.Add(this.dtpFechaCorte);
            this.Controls.Add(this.txtCBNumTop);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmClientesPrincipales";
            this.Text = "Listado de clientes principales";
            this.Load += new System.EventHandler(this.frmClientesPrincipales_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtCBNumTop, 0);
            this.Controls.SetChildIndex(this.dtpFechaCorte, 0);
            this.Controls.SetChildIndex(this.lblFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNumTop;
        private GEN.ControlesBase.dtpCorto dtpFechaCorte;
        private GEN.ControlesBase.lblBase lblFecFin;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtHistorico;
        private GEN.ControlesBase.rbtBase rbtFecha;
        private GEN.ControlesBase.grbBase grbBase2;
    }
}