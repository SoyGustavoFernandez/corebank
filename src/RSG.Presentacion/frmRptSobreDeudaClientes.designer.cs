namespace RSG.Presentacion
{
    partial class frmRptSobreDeudaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSobreDeudaClientes));
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.cboTipoPersona1 = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.conFechaAñoMesCorte = new GEN.ControlesBase.ConFechaAñoMes();
            this.cboMeses = new GEN.ControlesBase.cboMeses(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.cboMeses1 = new GEN.ControlesBase.cboMeses(this.components);
            this.nudBase1 = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.conFechaAñoMesCorte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(306, 141);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(372, 141);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(182, 37);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(121, 21);
            this.cboAgencia1.TabIndex = 28;
            // 
            // cboTipoPersona1
            // 
            this.cboTipoPersona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona1.FormattingEnabled = true;
            this.cboTipoPersona1.Location = new System.Drawing.Point(182, 64);
            this.cboTipoPersona1.Name = "cboTipoPersona1";
            this.cboTipoPersona1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoPersona1.TabIndex = 29;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(119, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 30;
            this.lblBase1.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(90, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(86, 13);
            this.lblBase2.TabIndex = 31;
            this.lblBase2.Text = "Tipo Persona:";
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(12, 9);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(420, 25);
            this.lblBaseCustom1.TabIndex = 32;
            this.lblBaseCustom1.Text = "REPORTE DE CLIENTES EXPUESTOS A SOBREENDEUDAMIENTO";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conFechaAñoMesCorte
            // 
            this.conFechaAñoMesCorte.anio = 1;
            this.conFechaAñoMesCorte.cMes = "ENERO";
            this.conFechaAñoMesCorte.Controls.Add(this.cboMeses);
            this.conFechaAñoMesCorte.Controls.Add(this.nudAnio);
            this.conFechaAñoMesCorte.Controls.Add(this.cboMeses1);
            this.conFechaAñoMesCorte.Controls.Add(this.nudBase1);
            this.conFechaAñoMesCorte.idMes = 1;
            this.conFechaAñoMesCorte.Location = new System.Drawing.Point(182, 91);
            this.conFechaAñoMesCorte.Name = "conFechaAñoMesCorte";
            this.conFechaAñoMesCorte.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesCorte.TabIndex = 33;
            // 
            // cboMeses
            // 
            this.cboMeses.DisplayMember = "cMes";
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(1, 15);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(106, 21);
            this.cboMeses.TabIndex = 2;
            this.cboMeses.ValueMember = "idMeses";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(110, 15);
            this.nudAnio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(51, 20);
            this.nudAnio.TabIndex = 1;
            this.nudAnio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboMeses1
            // 
            this.cboMeses1.DisplayMember = "cMes";
            this.cboMeses1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses1.FormattingEnabled = true;
            this.cboMeses1.Location = new System.Drawing.Point(1, 15);
            this.cboMeses1.Name = "cboMeses1";
            this.cboMeses1.Size = new System.Drawing.Size(106, 21);
            this.cboMeses1.TabIndex = 2;
            this.cboMeses1.ValueMember = "idMeses";
            // 
            // nudBase1
            // 
            this.nudBase1.Location = new System.Drawing.Point(110, 15);
            this.nudBase1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBase1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBase1.Name = "nudBase1";
            this.nudBase1.Size = new System.Drawing.Size(51, 20);
            this.nudBase1.TabIndex = 1;
            this.nudBase1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(156, 106);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(20, 13);
            this.lblBase3.TabIndex = 34;
            this.lblBase3.Text = "A:";
            // 
            // frmRptSobreDeudaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 216);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.conFechaAñoMesCorte);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoPersona1);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptSobreDeudaClientes";
            this.Text = "Reporte de clientes expuestos a sobreendeudamiento";
            this.Load += new System.EventHandler(this.frmRptSobreDeudaClientes_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.cboTipoPersona1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMesCorte, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.conFechaAñoMesCorte.ResumeLayout(false);
            this.conFechaAñoMesCorte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesCorte;
        private GEN.ControlesBase.cboMeses cboMeses;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.cboMeses cboMeses1;
        private GEN.ControlesBase.nudBase nudBase1;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}