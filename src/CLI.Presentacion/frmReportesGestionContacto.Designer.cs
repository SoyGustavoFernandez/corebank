namespace CLI.Presentacion
{
    partial class frmReportesGestionContacto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportesGestionContacto));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.datePicker2 = new GEN.ControlesBase.DatePicker();
            this.datePicker1 = new GEN.ControlesBase.DatePicker();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboEstablecimiento1 = new GEN.ControlesBase.cboEstablecimiento(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(331, 151);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(265, 151);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAgencia1);
            this.groupBox1.Controls.Add(this.lblBase6);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.datePicker2);
            this.groupBox1.Controls.Add(this.datePicker1);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboEstablecimiento1);
            this.groupBox1.Location = new System.Drawing.Point(20, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(371, 131);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte Gestión de Contacto";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(117, 29);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(236, 21);
            this.cboAgencia1.TabIndex = 19;
            this.cboAgencia1.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(246, 79);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(44, 13);
            this.lblBase6.TabIndex = 21;
            this.lblBase6.Text = "Hasta:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(114, 79);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(48, 13);
            this.lblBase5.TabIndex = 20;
            this.lblBase5.Text = "Desde:";
            // 
            // datePicker2
            // 
            this.datePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker2.Location = new System.Drawing.Point(237, 96);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(116, 20);
            this.datePicker2.TabIndex = 19;
            this.datePicker2.Value = new System.DateTime(2016, 8, 11, 18, 46, 38, 407);
            // 
            // datePicker1
            // 
            this.datePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker1.Location = new System.Drawing.Point(117, 96);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(119, 20);
            this.datePicker1.TabIndex = 18;
            this.datePicker1.Value = new System.DateTime(2016, 8, 11, 18, 46, 13, 629);
            this.datePicker1.ValueChanged += new System.EventHandler(this.datePicker1_ValueChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(60, 32);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Oficina:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 58);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(101, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Establecimiento:";
            // 
            // cboEstablecimiento1
            // 
            this.cboEstablecimiento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento1.FormattingEnabled = true;
            this.cboEstablecimiento1.Location = new System.Drawing.Point(117, 55);
            this.cboEstablecimiento1.Name = "cboEstablecimiento1";
            this.cboEstablecimiento1.Size = new System.Drawing.Size(236, 21);
            this.cboEstablecimiento1.TabIndex = 16;
            // 
            // frmReportesGestionContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 228);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmReportesGestionContacto";
            this.Text = "Reportes de Gestión de Contacto de Clientes";
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboEstablecimiento cboEstablecimiento1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.DatePicker datePicker2;
        private GEN.ControlesBase.DatePicker datePicker1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
    }
}