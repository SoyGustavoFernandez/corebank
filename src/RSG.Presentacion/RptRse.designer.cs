namespace RSG.Presentacion
{
    partial class RptRse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptRse));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnEstado = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnMora = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnCliMora = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnGeneral = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnCapital = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnClientes = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnCapitalMora = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbFecha = new GEN.ControlesBase.grbBase(this.components);
            this.lblFecha = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.grbFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.grbBase4);
            this.grbBase1.Controls.Add(this.grbFecha);
            this.grbBase1.Controls.Add(this.lblBaseCustom1);
            this.grbBase1.Location = new System.Drawing.Point(10, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(259, 341);
            this.grbBase1.TabIndex = 33;
            this.grbBase1.TabStop = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.rbtnEstado);
            this.grbBase4.Controls.Add(this.rbtnMora);
            this.grbBase4.Controls.Add(this.rbtnCliMora);
            this.grbBase4.Controls.Add(this.rbtnGeneral);
            this.grbBase4.Controls.Add(this.rbtnCapital);
            this.grbBase4.Controls.Add(this.rbtnClientes);
            this.grbBase4.Controls.Add(this.rbtnCapitalMora);
            this.grbBase4.Location = new System.Drawing.Point(12, 129);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(234, 205);
            this.grbBase4.TabIndex = 23;
            this.grbBase4.TabStop = false;
            // 
            // rbtnEstado
            // 
            this.rbtnEstado.AutoSize = true;
            this.rbtnEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnEstado.Location = new System.Drawing.Point(19, 179);
            this.rbtnEstado.Name = "rbtnEstado";
            this.rbtnEstado.Size = new System.Drawing.Size(58, 17);
            this.rbtnEstado.TabIndex = 9;
            this.rbtnEstado.Text = "Estado";
            this.rbtnEstado.UseVisualStyleBackColor = true;
            this.rbtnEstado.CheckedChanged += new System.EventHandler(this.rbtnEstado_CheckedChanged);
            // 
            // rbtnMora
            // 
            this.rbtnMora.AutoSize = true;
            this.rbtnMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnMora.Location = new System.Drawing.Point(19, 152);
            this.rbtnMora.Name = "rbtnMora";
            this.rbtnMora.Size = new System.Drawing.Size(59, 17);
            this.rbtnMora.TabIndex = 8;
            this.rbtnMora.Text = "% mora";
            this.rbtnMora.UseVisualStyleBackColor = true;
            this.rbtnMora.CheckedChanged += new System.EventHandler(this.rbtnMora_CheckedChanged);
            // 
            // rbtnCliMora
            // 
            this.rbtnCliMora.AutoSize = true;
            this.rbtnCliMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnCliMora.Location = new System.Drawing.Point(18, 125);
            this.rbtnCliMora.Name = "rbtnCliMora";
            this.rbtnCliMora.Size = new System.Drawing.Size(108, 17);
            this.rbtnCliMora.TabIndex = 7;
            this.rbtnCliMora.Text = "Clientes vencidos";
            this.rbtnCliMora.UseVisualStyleBackColor = true;
            this.rbtnCliMora.CheckedChanged += new System.EventHandler(this.rbtnCliMora_CheckedChanged);
            // 
            // rbtnGeneral
            // 
            this.rbtnGeneral.AutoSize = true;
            this.rbtnGeneral.Checked = true;
            this.rbtnGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnGeneral.Location = new System.Drawing.Point(19, 17);
            this.rbtnGeneral.Name = "rbtnGeneral";
            this.rbtnGeneral.Size = new System.Drawing.Size(47, 17);
            this.rbtnGeneral.TabIndex = 3;
            this.rbtnGeneral.TabStop = true;
            this.rbtnGeneral.Text = "RSE";
            this.rbtnGeneral.UseVisualStyleBackColor = true;
            this.rbtnGeneral.CheckedChanged += new System.EventHandler(this.rbtnGeneral_CheckedChanged);
            // 
            // rbtnCapital
            // 
            this.rbtnCapital.AutoSize = true;
            this.rbtnCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnCapital.Location = new System.Drawing.Point(19, 44);
            this.rbtnCapital.Name = "rbtnCapital";
            this.rbtnCapital.Size = new System.Drawing.Size(57, 17);
            this.rbtnCapital.TabIndex = 4;
            this.rbtnCapital.Text = "Capital";
            this.rbtnCapital.UseVisualStyleBackColor = true;
            this.rbtnCapital.CheckedChanged += new System.EventHandler(this.rbtnCapital_CheckedChanged);
            // 
            // rbtnClientes
            // 
            this.rbtnClientes.AutoSize = true;
            this.rbtnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnClientes.Location = new System.Drawing.Point(19, 71);
            this.rbtnClientes.Name = "rbtnClientes";
            this.rbtnClientes.Size = new System.Drawing.Size(62, 17);
            this.rbtnClientes.TabIndex = 5;
            this.rbtnClientes.Text = "Clientes";
            this.rbtnClientes.UseVisualStyleBackColor = true;
            this.rbtnClientes.CheckedChanged += new System.EventHandler(this.rbtnClientes_CheckedChanged);
            // 
            // rbtnCapitalMora
            // 
            this.rbtnCapitalMora.AutoSize = true;
            this.rbtnCapitalMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnCapitalMora.Location = new System.Drawing.Point(19, 98);
            this.rbtnCapitalMora.Name = "rbtnCapitalMora";
            this.rbtnCapitalMora.Size = new System.Drawing.Size(98, 17);
            this.rbtnCapitalMora.TabIndex = 6;
            this.rbtnCapitalMora.Text = "Capital vencido";
            this.rbtnCapitalMora.UseVisualStyleBackColor = true;
            this.rbtnCapitalMora.CheckedChanged += new System.EventHandler(this.rbtnCapitalMora_CheckedChanged);
            // 
            // grbFecha
            // 
            this.grbFecha.Controls.Add(this.lblFecha);
            this.grbFecha.Controls.Add(this.dtpFecha);
            this.grbFecha.Location = new System.Drawing.Point(12, 81);
            this.grbFecha.Name = "grbFecha";
            this.grbFecha.Size = new System.Drawing.Size(234, 44);
            this.grbFecha.TabIndex = 22;
            this.grbFecha.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(19, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(80, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(135, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(13, 16);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(233, 52);
            this.lblBaseCustom1.TabIndex = 0;
            this.lblBaseCustom1.Text = "REPORTE DE RIESGO DE SOBREENDEUDAMIENTO";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(143, 351);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 32;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(209, 351);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // RptRse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 431);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "RptRse";
            this.Text = "Reporte de riesgo de sobreendeudamiento";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbFecha.ResumeLayout(false);
            this.grbFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.rbtnBase rbtnEstado;
        private GEN.ControlesBase.rbtnBase rbtnMora;
        private GEN.ControlesBase.rbtnBase rbtnCliMora;
        private GEN.ControlesBase.rbtnBase rbtnGeneral;
        private GEN.ControlesBase.rbtnBase rbtnCapital;
        private GEN.ControlesBase.rbtnBase rbtnClientes;
        private GEN.ControlesBase.rbtnBase rbtnCapitalMora;
        private GEN.ControlesBase.grbBase grbFecha;
        private GEN.ControlesBase.lblBase lblFecha;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;


    }
}

