namespace DEP.Presentacion
{
    partial class frmRptReasigPromotorCta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptReasigPromotorCta));
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblDel = new GEN.ControlesBase.lblBase();
            this.lblAl = new GEN.ControlesBase.lblBase();
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblAgencia = new GEN.ControlesBase.lblBase();
            this.chcPromotor = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(65, 18);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(98, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(195, 18);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(96, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(328, 193);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(196, 193);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(262, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDel
            // 
            this.lblDel.AutoSize = true;
            this.lblDel.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDel.ForeColor = System.Drawing.Color.Navy;
            this.lblDel.Location = new System.Drawing.Point(33, 22);
            this.lblDel.Name = "lblDel";
            this.lblDel.Size = new System.Drawing.Size(26, 13);
            this.lblDel.TabIndex = 9;
            this.lblDel.Text = "Del";
            // 
            // lblAl
            // 
            this.lblAl.AutoSize = true;
            this.lblAl.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAl.ForeColor = System.Drawing.Color.Navy;
            this.lblAl.Location = new System.Drawing.Point(169, 22);
            this.lblAl.Name = "lblAl";
            this.lblAl.Size = new System.Drawing.Size(18, 13);
            this.lblAl.TabIndex = 10;
            this.lblAl.Text = "Al";
            // 
            // conBusCol
            // 
            this.conBusCol.Location = new System.Drawing.Point(10, 49);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(390, 86);
            this.conBusCol.TabIndex = 2;
            this.conBusCol.BuscarUsuario += new System.EventHandler(this.conBusCol_BuscarUsuario);
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(75, 12);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(313, 21);
            this.cboAgencias.TabIndex = 0;
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAgencia.ForeColor = System.Drawing.Color.Navy;
            this.lblAgencia.Location = new System.Drawing.Point(11, 16);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(57, 13);
            this.lblAgencia.TabIndex = 13;
            this.lblAgencia.Text = "Agencia:";
            // 
            // chcPromotor
            // 
            this.chcPromotor.AutoSize = true;
            this.chcPromotor.ForeColor = System.Drawing.Color.Navy;
            this.chcPromotor.Location = new System.Drawing.Point(267, 38);
            this.chcPromotor.Name = "chcPromotor";
            this.chcPromotor.Size = new System.Drawing.Size(127, 17);
            this.chcPromotor.TabIndex = 1;
            this.chcPromotor.Text = "Todos los promotores";
            this.chcPromotor.UseVisualStyleBackColor = true;
            this.chcPromotor.CheckedChanged += new System.EventHandler(this.chcPromotor_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 49);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(127, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Datos del promotor :";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.lblDel);
            this.grbBase1.Controls.Add(this.lblAl);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(10, 143);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(384, 44);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Rango de fechas";
            // 
            // frmRptReasigPromotorCta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 282);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.chcPromotor);
            this.Controls.Add(this.lblAgencia);
            this.Controls.Add(this.cboAgencias);
            this.Controls.Add(this.conBusCol);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptReasigPromotorCta";
            this.Text = "Reporte reasignación de promotores";
            this.Load += new System.EventHandler(this.frmRptReasigPromotorCta_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.conBusCol, 0);
            this.Controls.SetChildIndex(this.cboAgencias, 0);
            this.Controls.SetChildIndex(this.lblAgencia, 0);
            this.Controls.SetChildIndex(this.chcPromotor, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblDel;
        private GEN.ControlesBase.lblBase lblAl;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblAgencia;
        private GEN.ControlesBase.chcBase chcPromotor;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}