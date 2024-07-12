namespace CRE.Presentacion
{
    partial class frmRankingOtorgamientoCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRankingOtorgamientoCred));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.btnCancelacionesEsp = new System.Windows.Forms.Button();
            this.btnAmortizacionesEsp = new System.Windows.Forms.Button();
            this.btnSegColocaciones = new System.Windows.Forms.Button();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabRnkMontAcum = new System.Windows.Forms.TabPage();
            this.chtRnkComite = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtRnkAprobado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtRnkDesembolso = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grbBase1.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            this.tabRnkMontAcum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtRnkComite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtRnkAprobado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtRnkDesembolso)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.Color.AliceBlue;
            this.grbBase1.Controls.Add(this.btnImprimir);
            this.grbBase1.Controls.Add(this.btnGraficar);
            this.grbBase1.Controls.Add(this.btnCancelacionesEsp);
            this.grbBase1.Controls.Add(this.btnAmortizacionesEsp);
            this.grbBase1.Controls.Add(this.btnSegColocaciones);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboZona);
            this.grbBase1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(1291, 66);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimir.Image = global::CRE.Presentacion.Properties.Resources.btnPrint32;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImprimir.Location = new System.Drawing.Point(273, 16);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(89, 40);
            this.btnImprimir.TabIndex = 13;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.BackColor = System.Drawing.Color.White;
            this.btnGraficar.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnGraficar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraficar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnGraficar.Image = ((System.Drawing.Image)(resources.GetObject("btnGraficar.Image")));
            this.btnGraficar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGraficar.Location = new System.Drawing.Point(173, 17);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(89, 40);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Generar Gráficos";
            this.btnGraficar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGraficar.UseVisualStyleBackColor = false;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // btnCancelacionesEsp
            // 
            this.btnCancelacionesEsp.BackColor = System.Drawing.Color.White;
            this.btnCancelacionesEsp.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelacionesEsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelacionesEsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelacionesEsp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelacionesEsp.Image = global::CRE.Presentacion.Properties.Resources.btnPaid32;
            this.btnCancelacionesEsp.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelacionesEsp.Location = new System.Drawing.Point(664, 17);
            this.btnCancelacionesEsp.Name = "btnCancelacionesEsp";
            this.btnCancelacionesEsp.Size = new System.Drawing.Size(120, 40);
            this.btnCancelacionesEsp.TabIndex = 5;
            this.btnCancelacionesEsp.Text = "Cancelaciones Esperadas";
            this.btnCancelacionesEsp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelacionesEsp.UseVisualStyleBackColor = false;
            this.btnCancelacionesEsp.Click += new System.EventHandler(this.btnCancelacionesEsp_Click);
            // 
            // btnAmortizacionesEsp
            // 
            this.btnAmortizacionesEsp.BackColor = System.Drawing.Color.White;
            this.btnAmortizacionesEsp.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAmortizacionesEsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmortizacionesEsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmortizacionesEsp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAmortizacionesEsp.Image = global::CRE.Presentacion.Properties.Resources.btnDeposit32;
            this.btnAmortizacionesEsp.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAmortizacionesEsp.Location = new System.Drawing.Point(535, 17);
            this.btnAmortizacionesEsp.Name = "btnAmortizacionesEsp";
            this.btnAmortizacionesEsp.Size = new System.Drawing.Size(120, 40);
            this.btnAmortizacionesEsp.TabIndex = 4;
            this.btnAmortizacionesEsp.Text = "Amortizaciones Esperadas";
            this.btnAmortizacionesEsp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAmortizacionesEsp.UseVisualStyleBackColor = false;
            this.btnAmortizacionesEsp.Click += new System.EventHandler(this.btnAmortizacionesEsp_Click);
            // 
            // btnSegColocaciones
            // 
            this.btnSegColocaciones.BackColor = System.Drawing.Color.White;
            this.btnSegColocaciones.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSegColocaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSegColocaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSegColocaciones.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSegColocaciones.Image = global::CRE.Presentacion.Properties.Resources.btnWithdrawal32;
            this.btnSegColocaciones.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSegColocaciones.Location = new System.Drawing.Point(406, 17);
            this.btnSegColocaciones.Name = "btnSegColocaciones";
            this.btnSegColocaciones.Size = new System.Drawing.Size(120, 40);
            this.btnSegColocaciones.TabIndex = 3;
            this.btnSegColocaciones.Text = "Seg Diario Colocaciones";
            this.btnSegColocaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSegColocaciones.UseVisualStyleBackColor = false;
            this.btnSegColocaciones.Click += new System.EventHandler(this.btnSegColocaciones_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(62, 11);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Region";
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(13, 27);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(146, 21);
            this.cboZona.TabIndex = 1;
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabRnkMontAcum);
            this.tbcBase1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbcBase1.Location = new System.Drawing.Point(0, 63);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(1291, 605);
            this.tbcBase1.TabIndex = 1;
            // 
            // tabRnkMontAcum
            // 
            this.tabRnkMontAcum.AutoScroll = true;
            this.tabRnkMontAcum.BackColor = System.Drawing.Color.Transparent;
            this.tabRnkMontAcum.Controls.Add(this.chtRnkComite);
            this.tabRnkMontAcum.Controls.Add(this.chtRnkAprobado);
            this.tabRnkMontAcum.Controls.Add(this.chtRnkDesembolso);
            this.tabRnkMontAcum.Location = new System.Drawing.Point(4, 22);
            this.tabRnkMontAcum.Name = "tabRnkMontAcum";
            this.tabRnkMontAcum.Padding = new System.Windows.Forms.Padding(3);
            this.tabRnkMontAcum.Size = new System.Drawing.Size(1283, 579);
            this.tabRnkMontAcum.TabIndex = 0;
            this.tabRnkMontAcum.Text = "Rank Montos Acumulados";
            // 
            // chtRnkComite
            // 
            this.chtRnkComite.BackSecondaryColor = System.Drawing.Color.Black;
            this.chtRnkComite.BorderSkin.BackColor = System.Drawing.Color.SteelBlue;
            this.chtRnkComite.BorderSkin.BorderColor = System.Drawing.Color.DarkRed;
            this.chtRnkComite.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chtRnkComite.BorderSkin.BorderWidth = 5;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.Title = "Monto Acumulado";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.NarrowVertical;
            chartArea1.Name = "ChartArea1";
            this.chtRnkComite.ChartAreas.Add(chartArea1);
            this.chtRnkComite.Location = new System.Drawing.Point(846, 2);
            this.chtRnkComite.Name = "chtRnkComite";
            this.chtRnkComite.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.CustomProperties = "PointWidth=0.3";
            series1.EmptyPointStyle.Color = System.Drawing.Color.White;
            series1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LegendText = "Comite";
            series1.Name = "Series1";
            this.chtRnkComite.Series.Add(series1);
            this.chtRnkComite.Size = new System.Drawing.Size(413, 679);
            this.chtRnkComite.TabIndex = 2;
            this.chtRnkComite.Text = "chart2";
            // 
            // chtRnkAprobado
            // 
            this.chtRnkAprobado.BackSecondaryColor = System.Drawing.Color.Black;
            this.chtRnkAprobado.BorderSkin.BackColor = System.Drawing.Color.SteelBlue;
            this.chtRnkAprobado.BorderSkin.BorderColor = System.Drawing.Color.DarkRed;
            this.chtRnkAprobado.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chtRnkAprobado.BorderSkin.BorderWidth = 5;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.Title = "Monto Acumulado";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.NarrowVertical;
            chartArea2.Name = "ChartArea1";
            this.chtRnkAprobado.ChartAreas.Add(chartArea2);
            this.chtRnkAprobado.Location = new System.Drawing.Point(423, 2);
            this.chtRnkAprobado.Name = "chtRnkAprobado";
            this.chtRnkAprobado.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.CustomProperties = "PointWidth=0.3";
            series2.EmptyPointStyle.Color = System.Drawing.Color.White;
            series2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.Transparent;
            series2.LegendText = "Aprobado";
            series2.Name = "Series1";
            this.chtRnkAprobado.Series.Add(series2);
            this.chtRnkAprobado.Size = new System.Drawing.Size(413, 678);
            this.chtRnkAprobado.TabIndex = 1;
            this.chtRnkAprobado.Text = "chart1";
            // 
            // chtRnkDesembolso
            // 
            this.chtRnkDesembolso.BackSecondaryColor = System.Drawing.Color.Black;
            this.chtRnkDesembolso.BorderSkin.BackColor = System.Drawing.Color.SteelBlue;
            this.chtRnkDesembolso.BorderSkin.BorderColor = System.Drawing.Color.DarkRed;
            this.chtRnkDesembolso.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chtRnkDesembolso.BorderSkin.BorderWidth = 5;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY.Title = "Monto Acumulado";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            chartArea3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.NarrowVertical;
            chartArea3.Name = "ChartArea1";
            this.chtRnkDesembolso.ChartAreas.Add(chartArea3);
            this.chtRnkDesembolso.Location = new System.Drawing.Point(0, 3);
            this.chtRnkDesembolso.Name = "chtRnkDesembolso";
            this.chtRnkDesembolso.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.CustomProperties = "PointWidth=0.3";
            series3.EmptyPointStyle.Color = System.Drawing.Color.White;
            series3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.LabelBackColor = System.Drawing.Color.Transparent;
            series3.LegendText = "Desembolso";
            series3.Name = "Series1";
            this.chtRnkDesembolso.Series.Add(series3);
            this.chtRnkDesembolso.Size = new System.Drawing.Size(413, 677);
            this.chtRnkDesembolso.TabIndex = 0;
            this.chtRnkDesembolso.Text = "chart1";
            // 
            // frmRankingOtorgamientoCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1291, 690);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRankingOtorgamientoCred";
            this.Text = "Ranking Otorgamiento Creditos";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.tbcBase1.ResumeLayout(false);
            this.tabRnkMontAcum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtRnkComite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtRnkAprobado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtRnkDesembolso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabRnkMontAcum;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtRnkDesembolso;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtRnkComite;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtRnkAprobado;
        private System.Windows.Forms.Button btnCancelacionesEsp;
        private System.Windows.Forms.Button btnAmortizacionesEsp;
        private System.Windows.Forms.Button btnSegColocaciones;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Button btnImprimir;

    }
}