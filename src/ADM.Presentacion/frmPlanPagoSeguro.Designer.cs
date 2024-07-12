namespace ADM.Presentacion
{
    partial class frmPlanPagoSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanPagoSeguro));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipoSeguro = new System.Windows.Forms.TextBox();
            this.txtNombrePlan = new System.Windows.Forms.TextBox();
            this.txtMesesMinimo = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtMesesMaximo = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtMeses = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtPrecio = new GEN.ControlesBase.txtNumRea(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cboAsociarCredito = new System.Windows.Forms.ComboBox();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.chkVigente = new System.Windows.Forms.CheckBox();
            this.chkRedondear = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de Seguro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre del plan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rango meses:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Meses:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio mensual:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Asociar a crédito:";
            // 
            // txtTipoSeguro
            // 
            this.txtTipoSeguro.Location = new System.Drawing.Point(132, 12);
            this.txtTipoSeguro.Name = "txtTipoSeguro";
            this.txtTipoSeguro.Size = new System.Drawing.Size(189, 20);
            this.txtTipoSeguro.TabIndex = 1;
            // 
            // txtNombrePlan
            // 
            this.txtNombrePlan.Location = new System.Drawing.Point(131, 42);
            this.txtNombrePlan.Name = "txtNombrePlan";
            this.txtNombrePlan.Size = new System.Drawing.Size(190, 20);
            this.txtNombrePlan.TabIndex = 2;
            // 
            // txtMesesMinimo
            // 
            this.txtMesesMinimo.Format = "n2";
            this.txtMesesMinimo.Location = new System.Drawing.Point(132, 72);
            this.txtMesesMinimo.Name = "txtMesesMinimo";
            this.txtMesesMinimo.Size = new System.Drawing.Size(70, 20);
            this.txtMesesMinimo.TabIndex = 3;
            // 
            // txtMesesMaximo
            // 
            this.txtMesesMaximo.Format = "n2";
            this.txtMesesMaximo.Location = new System.Drawing.Point(251, 72);
            this.txtMesesMaximo.Name = "txtMesesMaximo";
            this.txtMesesMaximo.Size = new System.Drawing.Size(70, 20);
            this.txtMesesMaximo.TabIndex = 4;
            // 
            // txtMeses
            // 
            this.txtMeses.Format = "n2";
            this.txtMeses.Location = new System.Drawing.Point(132, 102);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(189, 20);
            this.txtMeses.TabIndex = 5;
            // 
            // txtPrecio
            // 
            this.txtPrecio.FormatoDecimal = false;
            this.txtPrecio.Location = new System.Drawing.Point(132, 132);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecio.nNumDecimales = 4;
            this.txtPrecio.nvalor = 0D;
            this.txtPrecio.Size = new System.Drawing.Size(189, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "---";
            // 
            // cboAsociarCredito
            // 
            this.cboAsociarCredito.FormattingEnabled = true;
            this.cboAsociarCredito.Location = new System.Drawing.Point(132, 162);
            this.cboAsociarCredito.Name = "cboAsociarCredito";
            this.cboAsociarCredito.Size = new System.Drawing.Size(189, 21);
            this.cboAsociarCredito.TabIndex = 7;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(261, 229);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(195, 229);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // chkVigente
            // 
            this.chkVigente.AutoSize = true;
            this.chkVigente.Location = new System.Drawing.Point(120, 200);
            this.chkVigente.Name = "chkVigente";
            this.chkVigente.Size = new System.Drawing.Size(62, 17);
            this.chkVigente.TabIndex = 8;
            this.chkVigente.Text = "Vigente";
            this.chkVigente.UseVisualStyleBackColor = true;
            // 
            // chkRedondear
            // 
            this.chkRedondear.AutoSize = true;
            this.chkRedondear.Checked = true;
            this.chkRedondear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRedondear.Location = new System.Drawing.Point(22, 196);
            this.chkRedondear.Name = "chkRedondear";
            this.chkRedondear.Size = new System.Drawing.Size(118, 17);
            this.chkRedondear.TabIndex = 14;
            this.chkRedondear.Text = "Redondear (entero)";
            this.chkRedondear.UseVisualStyleBackColor = true;
            this.chkRedondear.Visible = false;
            // 
            // frmPlanPagoSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 317);
            this.Controls.Add(this.chkRedondear);
            this.Controls.Add(this.chkVigente);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.cboAsociarCredito);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtMeses);
            this.Controls.Add(this.txtMesesMaximo);
            this.Controls.Add(this.txtMesesMinimo);
            this.Controls.Add(this.txtNombrePlan);
            this.Controls.Add(this.txtTipoSeguro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPlanPagoSeguro";
            this.Text = "Plan de Pagos de Seguro";
            this.Load += new System.EventHandler(this.frmPlanPagoSeguro_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTipoSeguro, 0);
            this.Controls.SetChildIndex(this.txtNombrePlan, 0);
            this.Controls.SetChildIndex(this.txtMesesMinimo, 0);
            this.Controls.SetChildIndex(this.txtMesesMaximo, 0);
            this.Controls.SetChildIndex(this.txtMeses, 0);
            this.Controls.SetChildIndex(this.txtPrecio, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboAsociarCredito, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.chkVigente, 0);
            this.Controls.SetChildIndex(this.chkRedondear, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTipoSeguro;
        private System.Windows.Forms.TextBox txtNombrePlan;
        private GEN.ControlesBase.txtNumerico txtMesesMinimo;
        private GEN.ControlesBase.txtNumerico txtMesesMaximo;
        private GEN.ControlesBase.txtNumerico txtMeses;
        private GEN.ControlesBase.txtNumRea txtPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAsociarCredito;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private System.Windows.Forms.CheckBox chkVigente;
        private System.Windows.Forms.CheckBox chkRedondear;
    }
}