namespace LOG.Presentacion
{
    partial class frmRptStockBienesAgencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptStockBienesAgencia));
            this.cboRubros = new GEN.ControlesBase.cboBase(this.components);
            this.cboSubGrupos = new GEN.ControlesBase.cboBase(this.components);
            this.cboGrupos = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.chcHistorico = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRubros
            // 
            this.cboRubros.FormattingEnabled = true;
            this.cboRubros.Location = new System.Drawing.Point(89, 70);
            this.cboRubros.Name = "cboRubros";
            this.cboRubros.Size = new System.Drawing.Size(226, 21);
            this.cboRubros.TabIndex = 33;
            // 
            // cboSubGrupos
            // 
            this.cboSubGrupos.FormattingEnabled = true;
            this.cboSubGrupos.Location = new System.Drawing.Point(89, 43);
            this.cboSubGrupos.Name = "cboSubGrupos";
            this.cboSubGrupos.Size = new System.Drawing.Size(226, 21);
            this.cboSubGrupos.TabIndex = 32;
            this.cboSubGrupos.SelectedIndexChanged += new System.EventHandler(this.cboSubGrupos_SelectedIndexChanged);
            // 
            // cboGrupos
            // 
            this.cboGrupos.FormattingEnabled = true;
            this.cboGrupos.Location = new System.Drawing.Point(89, 16);
            this.cboGrupos.Name = "cboGrupos";
            this.cboGrupos.Size = new System.Drawing.Size(226, 21);
            this.cboGrupos.TabIndex = 31;
            this.cboGrupos.SelectedIndexChanged += new System.EventHandler(this.cboGrupos_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(178, 190);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 29;
            this.lblBase3.Text = "Fecha:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(206, 214);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(91, 214);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(8, 71);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(52, 13);
            this.lblBase7.TabIndex = 24;
            this.lblBase7.Text = "Rubros:";
            // 
            // chcHistorico
            // 
            this.chcHistorico.AutoSize = true;
            this.chcHistorico.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcHistorico.ForeColor = System.Drawing.Color.Navy;
            this.chcHistorico.Location = new System.Drawing.Point(6, 188);
            this.chcHistorico.Name = "chcHistorico";
            this.chcHistorico.Size = new System.Drawing.Size(166, 17);
            this.chcHistorico.TabIndex = 26;
            this.chcHistorico.Text = "Extraer reporte histórico";
            this.chcHistorico.UseVisualStyleBackColor = true;
            this.chcHistorico.CheckedChanged += new System.EventHandler(this.chcHistorico_CheckedChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(8, 44);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(75, 13);
            this.lblBase6.TabIndex = 23;
            this.lblBase6.Text = "SubGrupos:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(227, 186);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 25;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(8, 16);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(47, 13);
            this.lblBase5.TabIndex = 22;
            this.lblBase5.Text = "Grupo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(61, 13);
            this.lblBase2.TabIndex = 20;
            this.lblBase2.Text = "Almacen:";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(89, 45);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(226, 21);
            this.cboAlmacen.TabIndex = 19;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(89, 19);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(226, 21);
            this.cboAgencia.TabIndex = 17;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAgencia);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.cboAlmacen);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 79);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.lblBase6);
            this.groupBox2.Controls.Add(this.cboRubros);
            this.groupBox2.Controls.Add(this.lblBase7);
            this.groupBox2.Controls.Add(this.cboSubGrupos);
            this.groupBox2.Controls.Add(this.cboGrupos);
            this.groupBox2.Location = new System.Drawing.Point(12, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 100);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // frmRptStockBienesAgencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 297);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.chcHistorico);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmRptStockBienesAgencia";
            this.Text = "Reporte de Stock de Bienes por Agencia";
            this.Load += new System.EventHandler(this.frmRptStockBienesAgencia_Load);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.chcHistorico, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboRubros;
        private GEN.ControlesBase.cboBase cboSubGrupos;
        private GEN.ControlesBase.cboBase cboGrupos;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.chcBase chcHistorico;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}