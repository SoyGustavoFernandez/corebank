namespace CRE.Presentacion
{
    partial class frmReporteExtornoOpe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteExtornoOpe));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.cboEstablecimiento = new GEN.ControlesBase.cboEstablecimiento(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.dFechFinExtorno = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dFechIniExtorno = new System.Windows.Forms.DateTimePicker();
            this.btnImprimirExtornoOpe = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboAgencia);
            this.groupBox1.Controls.Add(this.cboZona1);
            this.groupBox1.Controls.Add(this.cboEstablecimiento);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.cboModulo);
            this.groupBox1.Controls.Add(this.dFechFinExtorno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dFechIniExtorno);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(371, 187);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Reporte:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 89);
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
            this.lblBase2.Location = new System.Drawing.Point(16, 115);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(101, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Establecimiento:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(118, 89);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(236, 21);
            this.cboAgencia.TabIndex = 16;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(118, 61);
            this.cboZona1.Margin = new System.Windows.Forms.Padding(2);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(236, 21);
            this.cboZona1.TabIndex = 32;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(118, 115);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(236, 21);
            this.cboEstablecimiento.TabIndex = 16;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 64);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 31;
            this.lblBase1.Text = "Región:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(16, 33);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(58, 13);
            this.lblBase5.TabIndex = 30;
            this.lblBase5.Text = "Módulos:";
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(118, 31);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(236, 21);
            this.cboModulo.TabIndex = 29;
            // 
            // dFechFinExtorno
            // 
            this.dFechFinExtorno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechFinExtorno.Location = new System.Drawing.Point(269, 151);
            this.dFechFinExtorno.Margin = new System.Windows.Forms.Padding(2);
            this.dFechFinExtorno.Name = "dFechFinExtorno";
            this.dFechFinExtorno.Size = new System.Drawing.Size(84, 20);
            this.dFechFinExtorno.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(20, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(212, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // dFechIniExtorno
            // 
            this.dFechIniExtorno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechIniExtorno.Location = new System.Drawing.Point(121, 151);
            this.dFechIniExtorno.Margin = new System.Windows.Forms.Padding(2);
            this.dFechIniExtorno.Name = "dFechIniExtorno";
            this.dFechIniExtorno.Size = new System.Drawing.Size(86, 20);
            this.dFechIniExtorno.TabIndex = 2;
            // 
            // btnImprimirExtornoOpe
            // 
            this.btnImprimirExtornoOpe.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnImprimirExtornoOpe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirExtornoOpe.Location = new System.Drawing.Point(261, 223);
            this.btnImprimirExtornoOpe.Name = "btnImprimirExtornoOpe";
            this.btnImprimirExtornoOpe.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirExtornoOpe.TabIndex = 17;
            this.btnImprimirExtornoOpe.Text = "&Imprimir";
            this.btnImprimirExtornoOpe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirExtornoOpe.UseVisualStyleBackColor = true;
            this.btnImprimirExtornoOpe.Click += new System.EventHandler(this.btnImprimirExtornoOpe_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(327, 223);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 19;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmReporteExtornoOpe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 316);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimirExtornoOpe);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmReporteExtornoOpe";
            this.Text = "Reporte de Extornos";
            this.Load += new System.EventHandler(this.frmReportExtornoOpe_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnImprimirExtornoOpe, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.cboEstablecimiento cboEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboModulo cboModulo;
        private System.Windows.Forms.DateTimePicker dFechFinExtorno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dFechIniExtorno;
        private GEN.BotonesBase.btnImprimir btnImprimirExtornoOpe;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}