namespace SPL.Presentacion
{
    partial class frmVisitasClientesRegimenReforzado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitasClientesRegimenReforzado));
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoRiesgoSPLAFT = new GEN.ControlesBase.cboTipoRiesgoSPLAFT(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(17, 21);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(264, 40);
            this.lblBaseCustom1.TabIndex = 2;
            this.lblBaseCustom1.Text = "REPORTE DE VISITAS A CLIENTES DE RÉGIMEN REFORZADO";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.cboTipoRiesgoSPLAFT);
            this.grbBase1.Controls.Add(this.cboModulo);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(19, 75);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(261, 168);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(108, 103);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(121, 21);
            this.cboModulo.TabIndex = 6;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(108, 44);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFecFin.TabIndex = 5;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(108, 15);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(121, 20);
            this.dtpFecIni.TabIndex = 4;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(24, 137);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(78, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Tipo Riesgo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 107);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(90, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Tipo Producto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(37, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(22, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // cboTipoRiesgoSPLAFT
            // 
            this.cboTipoRiesgoSPLAFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRiesgoSPLAFT.FormattingEnabled = true;
            this.cboTipoRiesgoSPLAFT.lAgregarTodos = true;
            this.cboTipoRiesgoSPLAFT.Location = new System.Drawing.Point(108, 133);
            this.cboTipoRiesgoSPLAFT.Name = "cboTipoRiesgoSPLAFT";
            this.cboTipoRiesgoSPLAFT.Size = new System.Drawing.Size(121, 21);
            this.cboTipoRiesgoSPLAFT.TabIndex = 7;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(84, 249);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(154, 249);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(108, 73);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(121, 21);
            this.cboAgencias.TabIndex = 8;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(45, 77);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Agencia:";
            // 
            // frmVisitasClientesRegimenReforzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 333);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBaseCustom1);
            this.Name = "frmVisitasClientesRegimenReforzado";
            this.Text = "Visitas a clientes de regimen reforzado";
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoRiesgoSPLAFT cboTipoRiesgoSPLAFT;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
    }
}