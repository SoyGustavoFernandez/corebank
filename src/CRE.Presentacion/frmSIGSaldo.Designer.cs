﻿namespace CRE.Presentacion
{
    partial class frmSIGSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSIGSaldo));
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAgencia = new System.Windows.Forms.Label();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.cboAgencias = new GEN.ControlesBase.cboAgencia(this.components);
            this.SuspendLayout();
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(141, 83);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(113, 20);
            this.dtpFecFin.TabIndex = 22;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(141, 59);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(113, 20);
            this.dtpFecIni.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(49, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha Inicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(49, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Fecha Final:";
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.ForeColor = System.Drawing.Color.Navy;
            this.lblAgencia.Location = new System.Drawing.Point(49, 38);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(49, 13);
            this.lblAgencia.TabIndex = 17;
            this.lblAgencia.Text = "Agencia:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(163, 129);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 24;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(95, 129);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 23;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(141, 30);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(121, 21);
            this.cboAgencias.TabIndex = 25;
            // 
            // frmSIGSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 225);
            this.Controls.Add(this.cboAgencias);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAgencia);
            this.Name = "frmSIGSaldo";
            this.Text = "Saldo";
            this.Load += new System.EventHandler(this.frmSIGSaldo_Load);
            this.Controls.SetChildIndex(this.lblAgencia, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.cboAgencias, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAgencia;
        private GEN.ControlesBase.cboAgencia cboAgencias;
    }
}