namespace GRH.Presentacion
{
    partial class frmRPTPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPTPermisos));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtLargoBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboEstadoSolic1 = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(189, 189);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 22;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(123, 189);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 21;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(26, 123);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(61, 13);
            this.lblBase5.TabIndex = 20;
            this.lblBase5.Text = "Agencia: ";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(26, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(223, 13);
            this.lblBase4.TabIndex = 19;
            this.lblBase4.Text = "REPORTE DE PERMISOS APROBADOS";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 54);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 18;
            this.lblBase3.Text = "Periodo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(57, 70);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Desde:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(57, 95);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(44, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Hasta:";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(118, 92);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(131, 20);
            this.dtpFecFin.TabIndex = 15;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(118, 67);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(131, 20);
            this.dtpFecIni.TabIndex = 14;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(118, 120);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(131, 21);
            this.cboAgencias1.TabIndex = 23;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(26, 152);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(54, 13);
            this.lblBase6.TabIndex = 24;
            this.lblBase6.Text = "Estado: ";
            // 
            // cboEstadoSolic1
            // 
            this.cboEstadoSolic1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolic1.FormattingEnabled = true;
            this.cboEstadoSolic1.Location = new System.Drawing.Point(118, 148);
            this.cboEstadoSolic1.Name = "cboEstadoSolic1";
            this.cboEstadoSolic1.Size = new System.Drawing.Size(131, 21);
            this.cboEstadoSolic1.TabIndex = 25;
            // 
            // frmRPTPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 275);
            this.Controls.Add(this.cboEstadoSolic1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Name = "frmRPTPermisos";
            this.Text = "Reporte de Permisos";
            this.Load += new System.EventHandler(this.frmRPTPermisos_Load);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboEstadoSolic1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtLargoBase dtpFecFin;
        private GEN.ControlesBase.dtLargoBase dtpFecIni;
        private GEN.ControlesBase.cboAgencia cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolic1;
    }
}