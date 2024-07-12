namespace SPL.Presentacion
{
    partial class frmRptScoringSplaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptScoringSplaft));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.txtDocumentoID = new System.Windows.Forms.TextBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodigoEvaluacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblCodigoEvaluacion = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblrangeDate = new GEN.ControlesBase.lblBase();
            this.grbFielsetCliente = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbFielsetGeneral = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboCalifScoring = new GEN.ControlesBase.cboCalifScoring(this.components);
            this.cboTipoEvalScoring = new GEN.ControlesBase.cboTipoEvalScoring(this.components);
            this.lblTipoEvaluacion = new GEN.ControlesBase.lblBase();
            this.grbFielsetCliente.SuspendLayout();
            this.grbFielsetGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(188, 254);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(100, 20);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(217, 18);
            this.lblBaseCustom1.TabIndex = 3;
            this.lblBaseCustom1.Text = "Reporte de Scoring Splaft";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(122, 254);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtDocumentoID
            // 
            this.txtDocumentoID.Location = new System.Drawing.Point(143, 61);
            this.txtDocumentoID.Name = "txtDocumentoID";
            this.txtDocumentoID.Size = new System.Drawing.Size(200, 20);
            this.txtDocumentoID.TabIndex = 5;
            this.txtDocumentoID.TextChanged += new System.EventHandler(this.txtDocumentoID_TextChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 64);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(67, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "DNI / RUC";
            // 
            // txtCodigoEvaluacion
            // 
            this.txtCodigoEvaluacion.Location = new System.Drawing.Point(143, 91);
            this.txtCodigoEvaluacion.Name = "txtCodigoEvaluacion";
            this.txtCodigoEvaluacion.Size = new System.Drawing.Size(200, 20);
            this.txtCodigoEvaluacion.TabIndex = 7;
            this.txtCodigoEvaluacion.TextChanged += new System.EventHandler(this.txtCodigoEvaluacion_TextChanged);
            // 
            // lblCodigoEvaluacion
            // 
            this.lblCodigoEvaluacion.AutoSize = true;
            this.lblCodigoEvaluacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCodigoEvaluacion.ForeColor = System.Drawing.Color.Navy;
            this.lblCodigoEvaluacion.Location = new System.Drawing.Point(7, 94);
            this.lblCodigoEvaluacion.Name = "lblCodigoEvaluacion";
            this.lblCodigoEvaluacion.Size = new System.Drawing.Size(130, 13);
            this.lblCodigoEvaluacion.TabIndex = 8;
            this.lblCodigoEvaluacion.Text = "Código de evaluación";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(140, 20);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(90, 20);
            this.dtpFechaInicio.TabIndex = 9;
            this.dtpFechaInicio.Value = new System.DateTime(2018, 1, 22, 11, 35, 31, 0);
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(247, 20);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(93, 20);
            this.dtpFechaFin.TabIndex = 10;
            // 
            // lblrangeDate
            // 
            this.lblrangeDate.AutoSize = true;
            this.lblrangeDate.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblrangeDate.ForeColor = System.Drawing.Color.Navy;
            this.lblrangeDate.Location = new System.Drawing.Point(11, 150);
            this.lblrangeDate.Name = "lblrangeDate";
            this.lblrangeDate.Size = new System.Drawing.Size(40, 13);
            this.lblrangeDate.TabIndex = 11;
            this.lblrangeDate.Text = "Fecha";
            // 
            // grbFielsetCliente
            // 
            this.grbFielsetCliente.Controls.Add(this.lblBase2);
            this.grbFielsetCliente.Location = new System.Drawing.Point(1, 42);
            this.grbFielsetCliente.Name = "grbFielsetCliente";
            this.grbFielsetCliente.Size = new System.Drawing.Size(357, 76);
            this.grbFielsetCliente.TabIndex = 12;
            this.grbFielsetCliente.TabStop = false;
            this.grbFielsetCliente.Text = "Búsqueda por cliente";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(235, 89);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(12, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "-";
            // 
            // grbFielsetGeneral
            // 
            this.grbFielsetGeneral.Controls.Add(this.lblBase3);
            this.grbFielsetGeneral.Controls.Add(this.cboCalifScoring);
            this.grbFielsetGeneral.Controls.Add(this.cboTipoEvalScoring);
            this.grbFielsetGeneral.Controls.Add(this.lblTipoEvaluacion);
            this.grbFielsetGeneral.Controls.Add(this.dtpFechaFin);
            this.grbFielsetGeneral.Controls.Add(this.dtpFechaInicio);
            this.grbFielsetGeneral.Location = new System.Drawing.Point(3, 127);
            this.grbFielsetGeneral.Name = "grbFielsetGeneral";
            this.grbFielsetGeneral.Size = new System.Drawing.Size(355, 111);
            this.grbFielsetGeneral.TabIndex = 13;
            this.grbFielsetGeneral.TabStop = false;
            this.grbFielsetGeneral.Text = "Búsqueda general";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 76);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(118, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Calificativo / riesgo";
            // 
            // cboCalifScoring
            // 
            this.cboCalifScoring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalifScoring.FormattingEnabled = true;
            this.cboCalifScoring.lAgregarTodos = false;
            this.cboCalifScoring.Location = new System.Drawing.Point(140, 76);
            this.cboCalifScoring.Name = "cboCalifScoring";
            this.cboCalifScoring.Size = new System.Drawing.Size(200, 21);
            this.cboCalifScoring.TabIndex = 14;
            // 
            // cboTipoEvalScoring
            // 
            this.cboTipoEvalScoring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEvalScoring.FormattingEnabled = true;
            this.cboTipoEvalScoring.Location = new System.Drawing.Point(140, 47);
            this.cboTipoEvalScoring.Name = "cboTipoEvalScoring";
            this.cboTipoEvalScoring.Size = new System.Drawing.Size(200, 21);
            this.cboTipoEvalScoring.TabIndex = 15;
            // 
            // lblTipoEvaluacion
            // 
            this.lblTipoEvaluacion.AutoSize = true;
            this.lblTipoEvaluacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoEvaluacion.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoEvaluacion.Location = new System.Drawing.Point(9, 49);
            this.lblTipoEvaluacion.Name = "lblTipoEvaluacion";
            this.lblTipoEvaluacion.Size = new System.Drawing.Size(114, 13);
            this.lblTipoEvaluacion.TabIndex = 14;
            this.lblTipoEvaluacion.Text = "Tipo de evaluación";
            // 
            // frmRptScoringSplaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 333);
            this.Controls.Add(this.lblrangeDate);
            this.Controls.Add(this.lblCodigoEvaluacion);
            this.Controls.Add(this.txtCodigoEvaluacion);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDocumentoID);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbFielsetCliente);
            this.Controls.Add(this.grbFielsetGeneral);
            this.Name = "frmRptScoringSplaft";
            this.Text = "Reporte de Scoring Splaft";
            this.Load += new System.EventHandler(this.frmRptScoringSplaft_Load);
            this.Controls.SetChildIndex(this.grbFielsetGeneral, 0);
            this.Controls.SetChildIndex(this.grbFielsetCliente, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.txtDocumentoID, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtCodigoEvaluacion, 0);
            this.Controls.SetChildIndex(this.lblCodigoEvaluacion, 0);
            this.Controls.SetChildIndex(this.lblrangeDate, 0);
            this.grbFielsetCliente.ResumeLayout(false);
            this.grbFielsetCliente.PerformLayout();
            this.grbFielsetGeneral.ResumeLayout(false);
            this.grbFielsetGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private System.Windows.Forms.TextBox txtDocumentoID;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCodigoEvaluacion;
        private GEN.ControlesBase.lblBase lblCodigoEvaluacion;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblrangeDate;
        private GEN.ControlesBase.grbBase grbFielsetCliente;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbFielsetGeneral;
        private GEN.ControlesBase.lblBase lblTipoEvaluacion;
        private GEN.ControlesBase.cboTipoEvalScoring cboTipoEvalScoring;
        private GEN.ControlesBase.cboCalifScoring cboCalifScoring;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}