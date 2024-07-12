﻿namespace RPT.Presentacion
{
    partial class frmAnexo13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnexo13));
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtFSD = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnExportar1 = new GEN.BotonesBase.btnExportar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(204, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(89, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(136, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Fecha:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(164, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "FSD a la Fecha de Proceso:";
            // 
            // txtFSD
            // 
            this.txtFSD.Enabled = false;
            this.txtFSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFSD.FormatoDecimal = true;
            this.txtFSD.Location = new System.Drawing.Point(204, 51);
            this.txtFSD.Name = "txtFSD";
            this.txtFSD.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFSD.nNumDecimales = 2;
            this.txtFSD.nvalor = 0D;
            this.txtFSD.Size = new System.Drawing.Size(111, 26);
            this.txtFSD.TabIndex = 5;
            this.txtFSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(215, 94);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            //this.btnSalir1.texto = "";
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(79, 94);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 1;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
           // this.btnImprimir1.texto = "";
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnExportar1
            // 
            this.btnExportar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar1.BackgroundImage")));
            this.btnExportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar1.Location = new System.Drawing.Point(147, 94);
            this.btnExportar1.Name = "btnExportar1";
            this.btnExportar1.Size = new System.Drawing.Size(60, 50);
            this.btnExportar1.TabIndex = 2;
            this.btnExportar1.Text = "E&xportar";
            this.btnExportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
           // this.btnExportar1.texto = "";
            this.btnExportar1.UseVisualStyleBackColor = true;
            this.btnExportar1.Click += new System.EventHandler(this.btnExportar1_Click);
            // 
            // frmAnexo13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 182);
            this.Controls.Add(this.btnExportar1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.txtFSD);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmAnexo13";
            this.Text = "Depósitos según escala de montos";
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtFSD, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnExportar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtFSD;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnExportar btnExportar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}