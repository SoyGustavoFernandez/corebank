namespace RPT.Presentacion
{
    partial class frmAnexo03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnexo03));
            this.txtSalConsumo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSalHipoteca = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSalOtros = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnValidar1 = new GEN.BotonesBase.btnValidar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCreConsumo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCreHipo = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCreOtros = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnExportar = new GEN.BotonesBase.btnExportar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSalConsumo
            // 
            this.txtSalConsumo.Enabled = false;
            this.txtSalConsumo.FormatoDecimal = true;
            this.txtSalConsumo.Location = new System.Drawing.Point(84, 18);
            this.txtSalConsumo.Name = "txtSalConsumo";
            this.txtSalConsumo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSalConsumo.nNumDecimales = 2;
            this.txtSalConsumo.nvalor = 0D;
            this.txtSalConsumo.Size = new System.Drawing.Size(122, 20);
            this.txtSalConsumo.TabIndex = 2;
            this.txtSalConsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalHipoteca
            // 
            this.txtSalHipoteca.Enabled = false;
            this.txtSalHipoteca.FormatoDecimal = true;
            this.txtSalHipoteca.Location = new System.Drawing.Point(84, 44);
            this.txtSalHipoteca.Name = "txtSalHipoteca";
            this.txtSalHipoteca.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSalHipoteca.nNumDecimales = 2;
            this.txtSalHipoteca.nvalor = 0D;
            this.txtSalHipoteca.Size = new System.Drawing.Size(122, 20);
            this.txtSalHipoteca.TabIndex = 3;
            this.txtSalHipoteca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalOtros
            // 
            this.txtSalOtros.Enabled = false;
            this.txtSalOtros.FormatoDecimal = true;
            this.txtSalOtros.Location = new System.Drawing.Point(274, 18);
            this.txtSalOtros.Name = "txtSalOtros";
            this.txtSalOtros.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSalOtros.nNumDecimales = 2;
            this.txtSalOtros.nvalor = 0D;
            this.txtSalOtros.Size = new System.Drawing.Size(122, 20);
            this.txtSalOtros.TabIndex = 4;
            this.txtSalOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(70, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Consumo: ";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(76, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Hipotecario:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(216, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(47, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Otros: ";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtSalConsumo);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtSalHipoteca);
            this.grbBase1.Controls.Add(this.txtSalOtros);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 60);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(404, 77);
            this.grbBase1.TabIndex = 8;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Saldos Contables:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(205, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(91, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(122, 26);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(76, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Procesar al:";
            // 
            // btnValidar1
            // 
            this.btnValidar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnValidar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar1.BackgroundImage")));
            this.btnValidar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar1.Location = new System.Drawing.Point(77, 237);
            this.btnValidar1.Name = "btnValidar1";
            this.btnValidar1.Size = new System.Drawing.Size(60, 50);
            this.btnValidar1.TabIndex = 1;
            this.btnValidar1.Text = "&Validar";
            this.btnValidar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
           // this.btnValidar1.texto = "";
            this.btnValidar1.UseVisualStyleBackColor = true;
            this.btnValidar1.Click += new System.EventHandler(this.btnValidar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(281, 236);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            //this.btnSalir1.texto = "";
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtCreConsumo);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.txtCreHipo);
            this.grbBase2.Controls.Add(this.txtCreOtros);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(7, 143);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(404, 77);
            this.grbBase2.TabIndex = 14;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Saldos Créditos:";
            // 
            // txtCreConsumo
            // 
            this.txtCreConsumo.Enabled = false;
            this.txtCreConsumo.FormatoDecimal = true;
            this.txtCreConsumo.Location = new System.Drawing.Point(84, 18);
            this.txtCreConsumo.Name = "txtCreConsumo";
            this.txtCreConsumo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCreConsumo.nNumDecimales = 2;
            this.txtCreConsumo.nvalor = 0D;
            this.txtCreConsumo.Size = new System.Drawing.Size(122, 20);
            this.txtCreConsumo.TabIndex = 2;
            this.txtCreConsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(216, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(47, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Otros: ";
            // 
            // txtCreHipo
            // 
            this.txtCreHipo.Enabled = false;
            this.txtCreHipo.FormatoDecimal = true;
            this.txtCreHipo.Location = new System.Drawing.Point(84, 44);
            this.txtCreHipo.Name = "txtCreHipo";
            this.txtCreHipo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCreHipo.nNumDecimales = 2;
            this.txtCreHipo.nvalor = 0D;
            this.txtCreHipo.Size = new System.Drawing.Size(122, 20);
            this.txtCreHipo.TabIndex = 3;
            this.txtCreHipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreOtros
            // 
            this.txtCreOtros.Enabled = false;
            this.txtCreOtros.FormatoDecimal = true;
            this.txtCreOtros.Location = new System.Drawing.Point(274, 18);
            this.txtCreOtros.Name = "txtCreOtros";
            this.txtCreOtros.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCreOtros.nNumDecimales = 2;
            this.txtCreOtros.nvalor = 0D;
            this.txtCreOtros.Size = new System.Drawing.Size(122, 20);
            this.txtCreOtros.TabIndex = 4;
            this.txtCreOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 48);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(76, 13);
            this.lblBase7.TabIndex = 6;
            this.lblBase7.Text = "Hipotecario:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(7, 22);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(70, 13);
            this.lblBase8.TabIndex = 5;
            this.lblBase8.Text = "Consumo: ";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(145, 237);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         //   this.btnImprimir.texto = "";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar.Enabled = false;
            this.btnExportar.Location = new System.Drawing.Point(213, 236);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(60, 50);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "E&xportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
          //  this.btnExportar.texto = "";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmAnexo03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 327);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnValidar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmAnexo03";
            this.Text = "Stock y Flujo Crediticio por Tipo de Crédito y Sector Económico";
            this.Load += new System.EventHandler(this.frmAnexo03_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnValidar1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtSalConsumo;
        private GEN.ControlesBase.txtNumRea txtSalHipoteca;
        private GEN.ControlesBase.txtNumRea txtSalOtros;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnValidar btnValidar1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtNumRea txtCreConsumo;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtCreHipo;
        private GEN.ControlesBase.txtNumRea txtCreOtros;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnExportar btnExportar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}