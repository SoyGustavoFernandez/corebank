﻿namespace CRE.Presentacion
{
    partial class frmReporteCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteCartaFianza));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpDesde = new GEN.ControlesBase.DatePicker();
            this.dtpA = new GEN.ControlesBase.DatePicker();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(27, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Desde:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(31, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(20, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "A:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(84, 15);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(112, 20);
            this.dtpDesde.TabIndex = 4;
            this.dtpDesde.Value = new System.DateTime(2015, 7, 23, 16, 40, 9, 933);
            // 
            // dtpA
            // 
            this.dtpA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpA.Location = new System.Drawing.Point(84, 41);
            this.dtpA.Name = "dtpA";
            this.dtpA.Size = new System.Drawing.Size(112, 20);
            this.dtpA.TabIndex = 5;
            this.dtpA.Value = new System.DateTime(2015, 7, 23, 16, 40, 9, 933);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(149, 76);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(70, 76);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmReporteCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 165);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtpA);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmReporteCartaFianza";
            this.Text = "Reporte Carta Fianza";
            this.Load += new System.EventHandler(this.frmReporteCartaFianza_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpDesde, 0);
            this.Controls.SetChildIndex(this.dtpA, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.DatePicker dtpDesde;
        private GEN.ControlesBase.DatePicker dtpA;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}