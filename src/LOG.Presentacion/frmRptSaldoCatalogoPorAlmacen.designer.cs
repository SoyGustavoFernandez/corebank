namespace LOG.Presentacion
{
    partial class frmRptSaldoCatalogoPorAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptSaldoCatalogoPorAlmacen));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.chcHistorico = new GEN.ControlesBase.chcBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSubGrupo = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoBien = new GEN.ControlesBase.cboTipoBien(this.components);
            this.cboGrupoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.cboSubTipoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtDetalle = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtAgrupado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtGeneral = new GEN.ControlesBase.rbtBase(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(87, 12);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(232, 21);
            this.cboAgencia.TabIndex = 5;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(87, 38);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(232, 21);
            this.cboAlmacen.TabIndex = 7;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(61, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Almacen:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(230, 268);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 9;
            // 
            // chcHistorico
            // 
            this.chcHistorico.AutoSize = true;
            this.chcHistorico.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcHistorico.ForeColor = System.Drawing.Color.Navy;
            this.chcHistorico.Location = new System.Drawing.Point(12, 270);
            this.chcHistorico.Name = "chcHistorico";
            this.chcHistorico.Size = new System.Drawing.Size(166, 17);
            this.chcHistorico.TabIndex = 11;
            this.chcHistorico.Text = "Extraer reporte histórico";
            this.chcHistorico.UseVisualStyleBackColor = true;
            this.chcHistorico.CheckedChanged += new System.EventHandler(this.chcHistorico_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(204, 297);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(138, 297);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(181, 272);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Fecha:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(28, 16);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(90, 13);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(229, 21);
            this.cboMoneda.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.cboAgencia);
            this.groupBox1.Controls.Add(this.cboAlmacen);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Location = new System.Drawing.Point(12, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 67);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboSubGrupo);
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.cboTipoBien);
            this.groupBox2.Controls.Add(this.cboGrupoBien);
            this.groupBox2.Controls.Add(this.cboSubTipoBien);
            this.groupBox2.Controls.Add(this.lblBase6);
            this.groupBox2.Controls.Add(this.lblBase7);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Controls.Add(this.cboMoneda);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 148);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // cboSubGrupo
            // 
            this.cboSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubGrupo.FormattingEnabled = true;
            this.cboSubGrupo.Location = new System.Drawing.Point(90, 115);
            this.cboSubGrupo.Name = "cboSubGrupo";
            this.cboSubGrupo.Size = new System.Drawing.Size(228, 21);
            this.cboSubGrupo.TabIndex = 47;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(11, 119);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(73, 13);
            this.lblBase5.TabIndex = 51;
            this.lblBase5.Text = "Sub Grupo:";
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.Location = new System.Drawing.Point(90, 40);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(228, 21);
            this.cboTipoBien.TabIndex = 44;
            this.cboTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboTipoBien_SelectedIndexChanged);
            // 
            // cboGrupoBien
            // 
            this.cboGrupoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoBien.FormattingEnabled = true;
            this.cboGrupoBien.Location = new System.Drawing.Point(90, 90);
            this.cboGrupoBien.Name = "cboGrupoBien";
            this.cboGrupoBien.Size = new System.Drawing.Size(228, 21);
            this.cboGrupoBien.TabIndex = 46;
            this.cboGrupoBien.SelectedIndexChanged += new System.EventHandler(this.cboGrupoBien_SelectedIndexChanged);
            // 
            // cboSubTipoBien
            // 
            this.cboSubTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoBien.FormattingEnabled = true;
            this.cboSubTipoBien.Location = new System.Drawing.Point(90, 65);
            this.cboSubTipoBien.Name = "cboSubTipoBien";
            this.cboSubTipoBien.Size = new System.Drawing.Size(228, 21);
            this.cboSubTipoBien.TabIndex = 45;
            this.cboSubTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoBien_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(37, 90);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(47, 13);
            this.lblBase6.TabIndex = 50;
            this.lblBase6.Text = "Grupo:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(22, 68);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(62, 13);
            this.lblBase7.TabIndex = 49;
            this.lblBase7.Text = "Sub Tipo:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(48, 43);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(36, 13);
            this.lblBase8.TabIndex = 48;
            this.lblBase8.Text = "Tipo:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtGeneral);
            this.grbBase1.Controls.Add(this.rbtDetalle);
            this.grbBase1.Controls.Add(this.rbtAgrupado);
            this.grbBase1.Location = new System.Drawing.Point(12, 221);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(318, 41);
            this.grbBase1.TabIndex = 19;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Tipo de Reporte";
            // 
            // rbtDetalle
            // 
            this.rbtDetalle.AutoSize = true;
            this.rbtDetalle.ForeColor = System.Drawing.Color.Navy;
            this.rbtDetalle.Location = new System.Drawing.Point(118, 18);
            this.rbtDetalle.Name = "rbtDetalle";
            this.rbtDetalle.Size = new System.Drawing.Size(93, 17);
            this.rbtDetalle.TabIndex = 1;
            this.rbtDetalle.Text = "Saldos Detalle";
            this.rbtDetalle.UseVisualStyleBackColor = true;
            // 
            // rbtAgrupado
            // 
            this.rbtAgrupado.AutoSize = true;
            this.rbtAgrupado.Checked = true;
            this.rbtAgrupado.ForeColor = System.Drawing.Color.Navy;
            this.rbtAgrupado.Location = new System.Drawing.Point(6, 19);
            this.rbtAgrupado.Name = "rbtAgrupado";
            this.rbtAgrupado.Size = new System.Drawing.Size(106, 17);
            this.rbtAgrupado.TabIndex = 0;
            this.rbtAgrupado.TabStop = true;
            this.rbtAgrupado.Text = "Saldos Agrupado";
            this.rbtAgrupado.UseVisualStyleBackColor = true;
            // 
            // rbtGeneral
            // 
            this.rbtGeneral.AutoSize = true;
            this.rbtGeneral.ForeColor = System.Drawing.Color.Navy;
            this.rbtGeneral.Location = new System.Drawing.Point(217, 18);
            this.rbtGeneral.Name = "rbtGeneral";
            this.rbtGeneral.Size = new System.Drawing.Size(97, 17);
            this.rbtGeneral.TabIndex = 2;
            this.rbtGeneral.Text = "Saldos General";
            this.rbtGeneral.UseVisualStyleBackColor = true;
            // 
            // frmRptSaldoCatalogoPorAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 377);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.chcHistorico);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmRptSaldoCatalogoPorAlmacen";
            this.Text = "Reporte de Saldos por Almacen";
            this.Load += new System.EventHandler(this.frmRptSaldoCatalogoPorAlmacen_Load);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.chcHistorico, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.chcBase chcHistorico;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.cboGrupoCatalogo cboSubGrupo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboTipoBien cboTipoBien;
        private GEN.ControlesBase.cboGrupoCatalogo cboGrupoBien;
        private GEN.ControlesBase.cboGrupoCatalogo cboSubTipoBien;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtDetalle;
        private GEN.ControlesBase.rbtBase rbtAgrupado;
        private GEN.ControlesBase.rbtBase rbtGeneral;
    }
}

