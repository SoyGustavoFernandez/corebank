namespace CNT.Presentacion
{
    partial class frmRptContabilidad2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptContabilidad2));
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.NumDig = new GEN.ControlesBase.nudBase(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblFechaFin = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaIni = new GEN.ControlesBase.lblBase();
            this.cboMonedas = new GEN.ControlesBase.cboMoneda(this.components);
            this.btnFrmCentroCosto = new System.Windows.Forms.Button();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCentroCostos = new System.Windows.Forms.TextBox();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboCentroResp = new GEN.ControlesBase.cboBase(this.components);
            this.cboEstablecimiento1 = new GEN.ControlesBase.cboEstablecimiento(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtProyecto = new System.Windows.Forms.TextBox();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnProyecto = new System.Windows.Forms.Button();
            this.rptAcumulado = new System.Windows.Forms.RadioButton();
            this.rptHistorico = new System.Windows.Forms.RadioButton();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.lblAnio = new GEN.ControlesBase.lblBase();
            this.btnCentroCostosCancel = new System.Windows.Forms.Button();
            this.btnProyectoCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumDig)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(65, 121);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(132, 113);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(187, 21);
            this.cboAgencia.TabIndex = 7;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(22, 264);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(100, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Numero Dígitos:";
            // 
            // NumDig
            // 
            this.NumDig.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumDig.Location = new System.Drawing.Point(132, 257);
            this.NumDig.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumDig.Name = "NumDig";
            this.NumDig.Size = new System.Drawing.Size(51, 20);
            this.NumDig.TabIndex = 9;
            this.NumDig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumDig.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(132, 61);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(188, 20);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(67, 238);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Moneda:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaFin.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaFin.Location = new System.Drawing.Point(57, 67);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(65, 13);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(258, 291);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(192, 291);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Location = new System.Drawing.Point(132, 35);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(188, 20);
            this.dtpFechaIni.TabIndex = 1;
            this.dtpFechaIni.ValueChanged += new System.EventHandler(this.dtpFechaIni_ValueChanged);
            // 
            // lblFechaIni
            // 
            this.lblFechaIni.AutoSize = true;
            this.lblFechaIni.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaIni.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaIni.Location = new System.Drawing.Point(43, 42);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(80, 13);
            this.lblFechaIni.TabIndex = 0;
            this.lblFechaIni.Text = "Fecha Inicio:";
            // 
            // cboMonedas
            // 
            this.cboMonedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonedas.FormattingEnabled = true;
            this.cboMonedas.Location = new System.Drawing.Point(132, 230);
            this.cboMonedas.Name = "cboMonedas";
            this.cboMonedas.Size = new System.Drawing.Size(188, 21);
            this.cboMonedas.TabIndex = 5;
            // 
            // btnFrmCentroCosto
            // 
            this.btnFrmCentroCosto.Location = new System.Drawing.Point(130, 85);
            this.btnFrmCentroCosto.Name = "btnFrmCentroCosto";
            this.btnFrmCentroCosto.Size = new System.Drawing.Size(24, 23);
            this.btnFrmCentroCosto.TabIndex = 11;
            this.btnFrmCentroCosto.Text = "...";
            this.btnFrmCentroCosto.UseVisualStyleBackColor = true;
            this.btnFrmCentroCosto.Click += new System.EventHandler(this.btnFrmCentroCosto_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(28, 95);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(94, 13);
            this.lblBase6.TabIndex = 10;
            this.lblBase6.Text = "Centro Costos:";
            // 
            // txtCentroCostos
            // 
            this.txtCentroCostos.Enabled = false;
            this.txtCentroCostos.Location = new System.Drawing.Point(153, 87);
            this.txtCentroCostos.Name = "txtCentroCostos";
            this.txtCentroCostos.Size = new System.Drawing.Size(146, 20);
            this.txtCentroCostos.TabIndex = 12;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(20, 211);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(103, 13);
            this.lblBase7.TabIndex = 13;
            this.lblBase7.Text = "Centro Respons:";
            // 
            // cboCentroResp
            // 
            this.cboCentroResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentroResp.FormattingEnabled = true;
            this.cboCentroResp.Location = new System.Drawing.Point(132, 203);
            this.cboCentroResp.Name = "cboCentroResp";
            this.cboCentroResp.Size = new System.Drawing.Size(188, 21);
            this.cboCentroResp.TabIndex = 14;
            // 
            // cboEstablecimiento1
            // 
            this.cboEstablecimiento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento1.FormattingEnabled = true;
            this.cboEstablecimiento1.Location = new System.Drawing.Point(132, 141);
            this.cboEstablecimiento1.Name = "cboEstablecimiento1";
            this.cboEstablecimiento1.Size = new System.Drawing.Size(187, 21);
            this.cboEstablecimiento1.TabIndex = 17;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(21, 149);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(101, 13);
            this.lblBase8.TabIndex = 18;
            this.lblBase8.Text = "Establecimiento:";
            // 
            // txtProyecto
            // 
            this.txtProyecto.Enabled = false;
            this.txtProyecto.Location = new System.Drawing.Point(153, 170);
            this.txtProyecto.Name = "txtProyecto";
            this.txtProyecto.Size = new System.Drawing.Size(146, 20);
            this.txtProyecto.TabIndex = 21;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(60, 178);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 19;
            this.lblBase9.Text = "Proyecto:";
            // 
            // btnProyecto
            // 
            this.btnProyecto.Location = new System.Drawing.Point(130, 168);
            this.btnProyecto.Name = "btnProyecto";
            this.btnProyecto.Size = new System.Drawing.Size(24, 23);
            this.btnProyecto.TabIndex = 20;
            this.btnProyecto.Text = "...";
            this.btnProyecto.UseVisualStyleBackColor = true;
            this.btnProyecto.Click += new System.EventHandler(this.btnProyecto_Click);
            // 
            // rptAcumulado
            // 
            this.rptAcumulado.AutoSize = true;
            this.rptAcumulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rptAcumulado.Checked = true;
            this.rptAcumulado.Location = new System.Drawing.Point(60, 12);
            this.rptAcumulado.Name = "rptAcumulado";
            this.rptAcumulado.Size = new System.Drawing.Size(119, 17);
            this.rptAcumulado.TabIndex = 22;
            this.rptAcumulado.TabStop = true;
            this.rptAcumulado.Text = "Reporte Acumulado";
            this.rptAcumulado.UseVisualStyleBackColor = true;
            this.rptAcumulado.CheckedChanged += new System.EventHandler(this.rptAcumulado_CheckedChanged);
            // 
            // rptHistorico
            // 
            this.rptHistorico.AutoSize = true;
            this.rptHistorico.Location = new System.Drawing.Point(211, 12);
            this.rptHistorico.Name = "rptHistorico";
            this.rptHistorico.Size = new System.Drawing.Size(107, 17);
            this.rptHistorico.TabIndex = 23;
            this.rptHistorico.Text = "Reporte Histórico";
            this.rptHistorico.UseVisualStyleBackColor = true;
            this.rptHistorico.CheckedChanged += new System.EventHandler(this.rptHistorico_CheckedChanged);
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(132, 42);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(188, 21);
            this.cboAnio.TabIndex = 56;
            this.cboAnio.Visible = false;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAnio.ForeColor = System.Drawing.Color.Navy;
            this.lblAnio.Location = new System.Drawing.Point(73, 50);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(49, 13);
            this.lblAnio.TabIndex = 55;
            this.lblAnio.Text = "Fecha :";
            this.lblAnio.Visible = false;
            // 
            // btnCentroCostosCancel
            // 
            this.btnCentroCostosCancel.Location = new System.Drawing.Point(296, 85);
            this.btnCentroCostosCancel.Name = "btnCentroCostosCancel";
            this.btnCentroCostosCancel.Size = new System.Drawing.Size(24, 23);
            this.btnCentroCostosCancel.TabIndex = 57;
            this.btnCentroCostosCancel.Text = "X";
            this.btnCentroCostosCancel.UseVisualStyleBackColor = true;
            this.btnCentroCostosCancel.Click += new System.EventHandler(this.btnCentroCostosCancel_Click);
            // 
            // btnProyectoCancelar
            // 
            this.btnProyectoCancelar.Location = new System.Drawing.Point(294, 167);
            this.btnProyectoCancelar.Name = "btnProyectoCancelar";
            this.btnProyectoCancelar.Size = new System.Drawing.Size(24, 23);
            this.btnProyectoCancelar.TabIndex = 58;
            this.btnProyectoCancelar.Text = "X";
            this.btnProyectoCancelar.UseVisualStyleBackColor = true;
            this.btnProyectoCancelar.Click += new System.EventHandler(this.btnProyectoCancelar_Click);
            // 
            // frmRptContabilidad2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 368);
            this.Controls.Add(this.btnProyectoCancelar);
            this.Controls.Add(this.btnCentroCostosCancel);
            this.Controls.Add(this.cboAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.rptHistorico);
            this.Controls.Add(this.rptAcumulado);
            this.Controls.Add(this.txtProyecto);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.btnProyecto);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.cboEstablecimiento1);
            this.Controls.Add(this.cboCentroResp);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtCentroCostos);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnFrmCentroCosto);
            this.Controls.Add(this.cboMonedas);
            this.Controls.Add(this.dtpFechaIni);
            this.Controls.Add(this.lblFechaIni);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.NumDig);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblFechaFin);
            this.Name = "frmRptContabilidad2";
            this.Text = "Reporte de Centro de Responsabilidades";
            this.Load += new System.EventHandler(this.frmRptContabilidad2_Load);
            this.Controls.SetChildIndex(this.lblFechaFin, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.NumDig, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblFechaIni, 0);
            this.Controls.SetChildIndex(this.dtpFechaIni, 0);
            this.Controls.SetChildIndex(this.cboMonedas, 0);
            this.Controls.SetChildIndex(this.btnFrmCentroCosto, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtCentroCostos, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.cboCentroResp, 0);
            this.Controls.SetChildIndex(this.cboEstablecimiento1, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnProyecto, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtProyecto, 0);
            this.Controls.SetChildIndex(this.rptAcumulado, 0);
            this.Controls.SetChildIndex(this.rptHistorico, 0);
            this.Controls.SetChildIndex(this.lblAnio, 0);
            this.Controls.SetChildIndex(this.cboAnio, 0);
            this.Controls.SetChildIndex(this.btnCentroCostosCancel, 0);
            this.Controls.SetChildIndex(this.btnProyectoCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.NumDig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase NumDig;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblFechaFin;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.lblBase lblFechaIni;
        private GEN.ControlesBase.cboMoneda cboMonedas;
        private System.Windows.Forms.Button btnFrmCentroCosto;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.TextBox txtCentroCostos;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboBase cboCentroResp;
        private GEN.ControlesBase.cboEstablecimiento cboEstablecimiento1;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.TextBox txtProyecto;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.Button btnProyecto;
        private System.Windows.Forms.RadioButton rptAcumulado;
        private System.Windows.Forms.RadioButton rptHistorico;
        private System.Windows.Forms.ComboBox cboAnio;
        private GEN.ControlesBase.lblBase lblAnio;
        private System.Windows.Forms.Button btnCentroCostosCancel;
        private System.Windows.Forms.Button btnProyectoCancelar;
    }
}