﻿namespace DEP.Presentacion
{
    partial class frmReporteTrasladosCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteTrasladosCTS));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.dtFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtFecInicio = new System.Windows.Forms.DateTimePicker();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboEstadoSolic1 = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(334, 106);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 33;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(397, 106);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 28;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(271, 106);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 27;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // dtFecFin
            // 
            this.dtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecFin.Location = new System.Drawing.Point(307, 19);
            this.dtFecFin.Name = "dtFecFin";
            this.dtFecFin.Size = new System.Drawing.Size(129, 20);
            this.dtFecFin.TabIndex = 42;
            // 
            // dtFecInicio
            // 
            this.dtFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecInicio.Location = new System.Drawing.Point(84, 19);
            this.dtFecInicio.Name = "dtFecInicio";
            this.dtFecInicio.Size = new System.Drawing.Size(129, 20);
            this.dtFecInicio.TabIndex = 41;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.dtFecInicio);
            this.grbBase1.Controls.Add(this.dtFecFin);
            this.grbBase1.Location = new System.Drawing.Point(8, 55);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(449, 45);
            this.grbBase1.TabIndex = 127;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Rango de Fechas:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(9, 23);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(57, 13);
            this.lblBase10.TabIndex = 35;
            this.lblBase10.Text = "Fech.Ini:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(247, 23);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(58, 13);
            this.lblBase9.TabIndex = 36;
            this.lblBase9.Text = "Fech.Fin:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboAgencias1);
            this.grbBase2.Controls.Add(this.cboEstadoSolic1);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Location = new System.Drawing.Point(8, 0);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(449, 49);
            this.grbBase2.TabIndex = 128;
            this.grbBase2.TabStop = false;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(84, 16);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(129, 21);
            this.cboAgencias1.TabIndex = 44;
            // 
            // cboEstadoSolic1
            // 
            this.cboEstadoSolic1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolic1.FormattingEnabled = true;
            this.cboEstadoSolic1.Location = new System.Drawing.Point(307, 18);
            this.cboEstadoSolic1.Name = "cboEstadoSolic1";
            this.cboEstadoSolic1.Size = new System.Drawing.Size(129, 21);
            this.cboEstadoSolic1.TabIndex = 43;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(247, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 42;
            this.lblBase1.Text = "Estado:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 41;
            this.lblBase4.Text = "Agencia:";
            // 
            // frmReporteTrasladosCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 184);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmReporteTrasladosCTS";
            this.Text = "Reporte de Traslado de CTS";
            this.Load += new System.EventHandler(this.frmReporteTrasladosCTS_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
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

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.DateTimePicker dtFecFin;
        private System.Windows.Forms.DateTimePicker dtFecInicio;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolic1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}