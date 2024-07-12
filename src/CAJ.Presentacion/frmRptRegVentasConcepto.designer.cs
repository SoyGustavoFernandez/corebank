﻿namespace CAJ.Presentacion
{
    partial class frmRptRegVentasConcepto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRegVentasConcepto));
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboEstadoComprobante1 = new GEN.ControlesBase.cboEstadoComprobante(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(120, 150);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(186, 150);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboEstadoComprobante1);
            this.grbBase1.Controls.Add(this.dtpFecFinal);
            this.grbBase1.Controls.Add(this.dtpFecInicial);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(316, 132);
            this.grbBase1.TabIndex = 8;
            this.grbBase1.TabStop = false;
            // 
            // dtpFecFinal
            // 
            this.dtpFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinal.Location = new System.Drawing.Point(108, 100);
            this.dtpFecFinal.Name = "dtpFecFinal";
            this.dtpFecFinal.Size = new System.Drawing.Size(182, 20);
            this.dtpFecFinal.TabIndex = 5;
            // 
            // dtpFecInicial
            // 
            this.dtpFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicial.Location = new System.Drawing.Point(108, 74);
            this.dtpFecInicial.Name = "dtpFecInicial";
            this.dtpFecInicial.Size = new System.Drawing.Size(182, 20);
            this.dtpFecInicial.TabIndex = 4;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(108, 19);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(182, 21);
            this.cboAgencia.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 104);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 78);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(15, 49);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(50, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Estado:";
            // 
            // cboEstadoComprobante1
            // 
            this.cboEstadoComprobante1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoComprobante1.FormattingEnabled = true;
            this.cboEstadoComprobante1.Location = new System.Drawing.Point(108, 46);
            this.cboEstadoComprobante1.Name = "cboEstadoComprobante1";
            this.cboEstadoComprobante1.Size = new System.Drawing.Size(182, 21);
            this.cboEstadoComprobante1.TabIndex = 20;
            // 
            // frmRptRegVentasConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 229);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptRegVentasConcepto";
            this.Text = "Reporte de Registro Ventas por Concepto";
            this.Load += new System.EventHandler(this.frmRptRegVentasConcepto_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecFinal;
        private GEN.ControlesBase.dtpCorto dtpFecInicial;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboEstadoComprobante cboEstadoComprobante1;
    }
}