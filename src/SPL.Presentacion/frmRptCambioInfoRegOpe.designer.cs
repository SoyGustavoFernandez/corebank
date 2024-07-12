namespace SPL.Presentacion
{
    partial class frmRptCambioInfoRegOpe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCambioInfoRegOpe));
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboModulo1 = new GEN.ControlesBase.cboModulo(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.conFechaAñoMesDesde = new GEN.ControlesBase.ConFechaAñoMes();
            this.conFechaAñoMesHasta = new GEN.ControlesBase.ConFechaAñoMes();
            this.cboMeses = new GEN.ControlesBase.cboMeses(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.conFechaAñoMesHasta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(112, 20);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(157, 21);
            this.cboAgencias1.TabIndex = 2;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(49, 24);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(44, 181);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 32;
            this.lblBase2.Text = "Hasta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(44, 135);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 33;
            this.lblBase1.Text = "Desde:";
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(112, 48);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(121, 21);
            this.cboModulo1.TabIndex = 34;
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(112, 76);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda1.TabIndex = 35;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(49, 51);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 5;
            this.lblBase4.Text = "Modulo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(49, 79);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 5;
            this.lblBase5.Text = "Moneda:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(242, 223);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 37;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(176, 223);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 36;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // conFechaAñoMesDesde
            // 
            this.conFechaAñoMesDesde.anio = 1;
            this.conFechaAñoMesDesde.cMes = "ENERO";
            this.conFechaAñoMesDesde.idMes = 1;
            this.conFechaAñoMesDesde.Location = new System.Drawing.Point(105, 118);
            this.conFechaAñoMesDesde.Name = "conFechaAñoMesDesde";
            this.conFechaAñoMesDesde.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesDesde.TabIndex = 38;
            // 
            // conFechaAñoMesHasta
            // 
            this.conFechaAñoMesHasta.anio = 1;
            this.conFechaAñoMesHasta.cMes = "ENERO";
            this.conFechaAñoMesHasta.Controls.Add(this.cboMeses);
            this.conFechaAñoMesHasta.Controls.Add(this.nudAnio);
            this.conFechaAñoMesHasta.idMes = 1;
            this.conFechaAñoMesHasta.Location = new System.Drawing.Point(105, 163);
            this.conFechaAñoMesHasta.Name = "conFechaAñoMesHasta";
            this.conFechaAñoMesHasta.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMesHasta.TabIndex = 39;
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
            // frmRptCambioInfoRegOpe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 298);
            this.Controls.Add(this.conFechaAñoMesHasta);
            this.Controls.Add(this.conFechaAñoMesDesde);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.cboModulo1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboAgencias1);
            this.Name = "frmRptCambioInfoRegOpe";
            this.Text = "Reporte de cambios de información";
            this.Load += new System.EventHandler(this.frmRptCambioInfoRegOpe_Load);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboModulo1, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMesDesde, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMesHasta, 0);
            this.conFechaAñoMesHasta.ResumeLayout(false);
            this.conFechaAñoMesHasta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboModulo cboModulo1;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesDesde;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMesHasta;
        private GEN.ControlesBase.cboMeses cboMeses;
        private GEN.ControlesBase.nudBase nudAnio;
    }
}