namespace CRE.Presentacion
{
    partial class frmRptMoraTramoPromotor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptMoraTramoPromotor));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFecha = new GEN.ControlesBase.lblBase();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboAgencia1);
            this.grbBase1.Controls.Add(this.dtpFecha);
            this.grbBase1.Controls.Add(this.lblFecha);
            this.grbBase1.Controls.Add(this.lblBaseCustom1);
            this.grbBase1.Location = new System.Drawing.Point(10, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(326, 133);
            this.grbBase1.TabIndex = 17;
            this.grbBase1.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(121, 61);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(135, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(70, 65);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(22, 16);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(283, 38);
            this.lblBaseCustom1.TabIndex = 0;
            this.lblBaseCustom1.Text = "REPORTE DE MORA POR TRAMO Y PROMOTOR";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(110, 145);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(176, 145);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(121, 101);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(135, 21);
            this.cboAgencia1.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(58, 104);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Agencia:";
            // 
            // frmRptMoraTramoPromotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 247);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptMoraTramoPromotor";
            this.Text = "Reporte de mora por tramo y promotor";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblFecha;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;

    }
}

