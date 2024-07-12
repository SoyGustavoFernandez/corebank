namespace RSG.Presentacion
{
    partial class frmRptCreditosRiesgoPotencial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCreditosRiesgoPotencial));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dFechaIni = new GEN.ControlesBase.DatePicker();
            this.cboPersonalCreditos1 = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dFechaIni);
            this.grbBase1.Controls.Add(this.cboPersonalCreditos1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboZona1);
            this.grbBase1.Controls.Add(this.cboAgencias1);
            this.grbBase1.Location = new System.Drawing.Point(7, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(298, 164);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Créditos en RIesgo Potencial";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(21, 25);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 20;
            this.lblBase5.Text = "Fecha:";
            // 
            // dFechaIni
            // 
            this.dFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaIni.Location = new System.Drawing.Point(75, 19);
            this.dFechaIni.Name = "dFechaIni";
            this.dFechaIni.Size = new System.Drawing.Size(111, 20);
            this.dFechaIni.TabIndex = 18;
            this.dFechaIni.Value = new System.DateTime(2016, 8, 11, 18, 46, 13, 629);
            // 
            // cboPersonalCreditos1
            // 
            this.cboPersonalCreditos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonalCreditos1.FormattingEnabled = true;
            this.cboPersonalCreditos1.Location = new System.Drawing.Point(75, 112);
            this.cboPersonalCreditos1.Name = "cboPersonalCreditos1";
            this.cboPersonalCreditos1.Size = new System.Drawing.Size(208, 21);
            this.cboPersonalCreditos1.TabIndex = 14;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(25, 59);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(41, 13);
            this.lblBase3.TabIndex = 15;
            this.lblBase3.Text = "Zona:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 116);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Asesor:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 85);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Oficina:";
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(75, 51);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(208, 21);
            this.cboZona1.TabIndex = 12;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(75, 81);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(208, 21);
            this.cboAgencias1.TabIndex = 13;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(98, 192);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 3;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(230, 192);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(164, 192);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmRptCreditosRiesgoPotencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 291);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptCreditosRiesgoPotencial";
            this.Text = "Créditos en Riesgo Potencial";
            this.Load += new System.EventHandler(this.frmRptCreditosRiesgoPotencial_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditos1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.DatePicker dFechaIni;
    }
}