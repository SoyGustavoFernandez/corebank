namespace RSG.Presentacion
{
    partial class frmRptConcTipCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptConcTipCred));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnConc = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnHistCap = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnHistCapMora = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnHistMora = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbRango = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbFecha = new GEN.ControlesBase.grbBase(this.components);
            this.lblFecha = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtGrafico = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtDetalle = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.grbRango.SuspendLayout();
            this.grbFecha.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.grbBase4);
            this.grbBase1.Controls.Add(this.grbRango);
            this.grbBase1.Controls.Add(this.grbFecha);
            this.grbBase1.Controls.Add(this.lblBaseCustom1);
            this.grbBase1.Location = new System.Drawing.Point(10, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(419, 224);
            this.grbBase1.TabIndex = 24;
            this.grbBase1.TabStop = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.rbtnConc);
            this.grbBase4.Controls.Add(this.rbtnHistCap);
            this.grbBase4.Controls.Add(this.rbtnHistCapMora);
            this.grbBase4.Controls.Add(this.rbtnHistMora);
            this.grbBase4.Location = new System.Drawing.Point(24, 47);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(178, 165);
            this.grbBase4.TabIndex = 23;
            this.grbBase4.TabStop = false;
            // 
            // rbtnConc
            // 
            this.rbtnConc.AutoSize = true;
            this.rbtnConc.Checked = true;
            this.rbtnConc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnConc.Location = new System.Drawing.Point(19, 29);
            this.rbtnConc.Name = "rbtnConc";
            this.rbtnConc.Size = new System.Drawing.Size(145, 17);
            this.rbtnConc.TabIndex = 3;
            this.rbtnConc.TabStop = true;
            this.rbtnConc.Text = "Concentración de cartera";
            this.rbtnConc.UseVisualStyleBackColor = true;
            this.rbtnConc.CheckedChanged += new System.EventHandler(this.rbtnConc_CheckedChanged);
            // 
            // rbtnHistCap
            // 
            this.rbtnHistCap.AutoSize = true;
            this.rbtnHistCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnHistCap.Location = new System.Drawing.Point(19, 60);
            this.rbtnHistCap.Name = "rbtnHistCap";
            this.rbtnHistCap.Size = new System.Drawing.Size(100, 17);
            this.rbtnHistCap.TabIndex = 4;
            this.rbtnHistCap.Text = "Histórico capital";
            this.rbtnHistCap.UseVisualStyleBackColor = true;
            this.rbtnHistCap.CheckedChanged += new System.EventHandler(this.rbtnHistCap_CheckedChanged);
            // 
            // rbtnHistCapMora
            // 
            this.rbtnHistCapMora.AutoSize = true;
            this.rbtnHistCapMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnHistCapMora.Location = new System.Drawing.Point(19, 91);
            this.rbtnHistCapMora.Name = "rbtnHistCapMora";
            this.rbtnHistCapMora.Size = new System.Drawing.Size(141, 17);
            this.rbtnHistCapMora.TabIndex = 5;
            this.rbtnHistCapMora.Text = "Histórico capital vencido";
            this.rbtnHistCapMora.UseVisualStyleBackColor = true;
            this.rbtnHistCapMora.CheckedChanged += new System.EventHandler(this.rbtnHistCapMora_CheckedChanged);
            // 
            // rbtnHistMora
            // 
            this.rbtnHistMora.AutoSize = true;
            this.rbtnHistMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnHistMora.Location = new System.Drawing.Point(19, 122);
            this.rbtnHistMora.Name = "rbtnHistMora";
            this.rbtnHistMora.Size = new System.Drawing.Size(103, 17);
            this.rbtnHistMora.TabIndex = 6;
            this.rbtnHistMora.Text = "Histórico % mora";
            this.rbtnHistMora.UseVisualStyleBackColor = true;
            this.rbtnHistMora.CheckedChanged += new System.EventHandler(this.rbtnHistMora_CheckedChanged);
            // 
            // grbRango
            // 
            this.grbRango.Controls.Add(this.lblBase1);
            this.grbRango.Controls.Add(this.dtpFecIni);
            this.grbRango.Controls.Add(this.dtpFecFin);
            this.grbRango.Controls.Add(this.lblBase2);
            this.grbRango.Location = new System.Drawing.Point(230, 112);
            this.grbRango.Name = "grbRango";
            this.grbRango.Size = new System.Drawing.Size(164, 100);
            this.grbRango.TabIndex = 22;
            this.grbRango.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Fecha inicio:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(15, 32);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(135, 20);
            this.dtpFecIni.TabIndex = 9;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(15, 71);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(135, 20);
            this.dtpFecFin.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(63, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Fecha fin:";
            // 
            // grbFecha
            // 
            this.grbFecha.Controls.Add(this.lblFecha);
            this.grbFecha.Controls.Add(this.dtpFecha);
            this.grbFecha.Location = new System.Drawing.Point(230, 47);
            this.grbFecha.Name = "grbFecha";
            this.grbFecha.Size = new System.Drawing.Size(164, 64);
            this.grbFecha.TabIndex = 22;
            this.grbFecha.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(15, 17);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(15, 33);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(135, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(7, 16);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(405, 25);
            this.lblBaseCustom1.TabIndex = 0;
            this.lblBaseCustom1.Text = "REPORTE DE CONCENTRACIÓN DE CARTERA POR TIPO CRÉDITO";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(302, 234);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 23;
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
            this.btnSalir.Location = new System.Drawing.Point(368, 234);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtGrafico);
            this.grbBase2.Controls.Add(this.rbtDetalle);
            this.grbBase2.Location = new System.Drawing.Point(34, 235);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(178, 49);
            this.grbBase2.TabIndex = 32;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Tipo de reporte:";
            // 
            // rbtGrafico
            // 
            this.rbtGrafico.AutoSize = true;
            this.rbtGrafico.ForeColor = System.Drawing.Color.Navy;
            this.rbtGrafico.Location = new System.Drawing.Point(93, 19);
            this.rbtGrafico.Name = "rbtGrafico";
            this.rbtGrafico.Size = new System.Drawing.Size(59, 17);
            this.rbtGrafico.TabIndex = 0;
            this.rbtGrafico.Text = "Gráfico";
            this.rbtGrafico.UseVisualStyleBackColor = true;
            // 
            // rbtDetalle
            // 
            this.rbtDetalle.AutoSize = true;
            this.rbtDetalle.Checked = true;
            this.rbtDetalle.ForeColor = System.Drawing.Color.Navy;
            this.rbtDetalle.Location = new System.Drawing.Point(11, 19);
            this.rbtDetalle.Name = "rbtDetalle";
            this.rbtDetalle.Size = new System.Drawing.Size(58, 17);
            this.rbtDetalle.TabIndex = 0;
            this.rbtDetalle.TabStop = true;
            this.rbtDetalle.Text = "Detalle";
            this.rbtDetalle.UseVisualStyleBackColor = true;
            // 
            // frmRptConcTipCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 314);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptConcTipCred";
            this.Text = "Reporte concentración por tipo de crédito";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbRango.ResumeLayout(false);
            this.grbRango.PerformLayout();
            this.grbFecha.ResumeLayout(false);
            this.grbFecha.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.rbtnBase rbtnConc;
        private GEN.ControlesBase.rbtnBase rbtnHistCap;
        private GEN.ControlesBase.rbtnBase rbtnHistCapMora;
        private GEN.ControlesBase.rbtnBase rbtnHistMora;
        private GEN.ControlesBase.grbBase grbRango;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbFecha;
        private GEN.ControlesBase.lblBase lblFecha;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.rbtBase rbtGrafico;
        private GEN.ControlesBase.rbtBase rbtDetalle;

    }
}

