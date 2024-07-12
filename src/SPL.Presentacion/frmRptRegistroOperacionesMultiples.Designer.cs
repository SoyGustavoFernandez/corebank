namespace SPL.Presentacion
{
    partial class frmRptRegistroOperacionesMultiples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRegistroOperacionesMultiples));
            this.conFechaAñoMesInicio = new GEN.ControlesBase.ConFechaAñoMes();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.conFechaAñoMesFin = new GEN.ControlesBase.ConFechaAñoMes();
            this.cboMeses1 = new GEN.ControlesBase.cboMeses(this.components);
            this.nudBase1 = new GEN.ControlesBase.nudBase(this.components);
            this.cboMeses = new GEN.ControlesBase.cboMeses(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conFechaAñoMesFin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // conFechaAñoMesInicio
            // 
            this.conFechaAñoMesInicio.anio = 1;
            this.conFechaAñoMesInicio.cMes = "ENERO";
            this.conFechaAñoMesInicio.idMes = 1;
            this.conFechaAñoMesInicio.Location = new System.Drawing.Point(124, 48);
            this.conFechaAñoMesInicio.Name = "conFechaAñoMesInicio";
            this.conFechaAñoMesInicio.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesInicio.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(75, 62);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(43, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(80, 108);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(38, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Final:";
            // 
            // conFechaAñoMesFin
            // 
            this.conFechaAñoMesFin.anio = 1;
            this.conFechaAñoMesFin.cMes = "ENERO";
            this.conFechaAñoMesFin.Controls.Add(this.cboMeses1);
            this.conFechaAñoMesFin.Controls.Add(this.nudBase1);
            this.conFechaAñoMesFin.Controls.Add(this.cboMeses);
            this.conFechaAñoMesFin.Controls.Add(this.nudAnio);
            this.conFechaAñoMesFin.idMes = 1;
            this.conFechaAñoMesFin.Location = new System.Drawing.Point(124, 93);
            this.conFechaAñoMesFin.Name = "conFechaAñoMesFin";
            this.conFechaAñoMesFin.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesFin.TabIndex = 3;
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
            // cboAgencias1
            // 
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(124, 21);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(160, 21);
            this.cboAgencias1.TabIndex = 6;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(61, 24);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(123, 138);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(189, 138);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmRptRegistroOperacionesMultiples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 222);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conFechaAñoMesFin);
            this.Controls.Add(this.conFechaAñoMesInicio);
            this.Name = "frmRptRegistroOperacionesMultiples";
            this.Text = "Reporte de Registro de Operaciones Multiples";
            this.Controls.SetChildIndex(this.conFechaAñoMesInicio, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMesFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.conFechaAñoMesFin.ResumeLayout(false);
            this.conFechaAñoMesFin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesInicio;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesFin;
        private GEN.ControlesBase.cboMeses cboMeses1;
        private GEN.ControlesBase.nudBase nudBase1;
        private GEN.ControlesBase.cboMeses cboMeses;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;

    }
}