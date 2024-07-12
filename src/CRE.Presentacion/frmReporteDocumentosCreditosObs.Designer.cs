namespace CRE.Presentacion
{
    partial class frmReporteDocumentosCreditosObs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteDocumentosCreditosObs));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.chbHistorial = new System.Windows.Forms.CheckBox();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.chbRegion = new GEN.ControlesBase.chklbBase(this.components);
            this.chbOficina = new GEN.ControlesBase.chklbBase(this.components);
            this.chbTodosRegion = new GEN.ControlesBase.chcBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbTodosOficina = new GEN.ControlesBase.chcBase(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.chbEstablecimiento = new GEN.ControlesBase.chklbBase(this.components);
            this.chbTodosEstablecimiento = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(59, 438);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(87, 13);
            this.lblBase2.TabIndex = 32;
            this.lblBase2.Text = "FECHA FINAL:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(59, 410);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 31;
            this.lblBase1.Text = "FECHA INICIO:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(191, 432);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(143, 20);
            this.dtpFechaFinal.TabIndex = 30;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(191, 404);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(143, 20);
            this.dtpFechaInicio.TabIndex = 29;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(59, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(58, 13);
            this.lblBase3.TabIndex = 34;
            this.lblBase3.Text = "REGIÓN:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(59, 383);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(59, 13);
            this.lblBase4.TabIndex = 35;
            this.lblBase4.Text = "ESTADO:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(274, 489);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 38;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(191, 489);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 37;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(59, 461);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(76, 13);
            this.lblBase5.TabIndex = 32;
            this.lblBase5.Text = "HISTORIAL:";
            // 
            // chbHistorial
            // 
            this.chbHistorial.AutoSize = true;
            this.chbHistorial.Location = new System.Drawing.Point(191, 460);
            this.chbHistorial.Name = "chbHistorial";
            this.chbHistorial.Size = new System.Drawing.Size(15, 14);
            this.chbHistorial.TabIndex = 39;
            this.chbHistorial.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(59, 134);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(62, 13);
            this.lblBase6.TabIndex = 34;
            this.lblBase6.Text = "OFICINA:";
            // 
            // chbRegion
            // 
            this.chbRegion.CheckOnClick = true;
            this.chbRegion.FormattingEnabled = true;
            this.chbRegion.Location = new System.Drawing.Point(3, 0);
            this.chbRegion.Name = "chbRegion";
            this.chbRegion.Size = new System.Drawing.Size(235, 109);
            this.chbRegion.TabIndex = 45;
            this.chbRegion.SelectedIndexChanged += new System.EventHandler(this.chbRegion_SelectedIndexChanged);
            // 
            // chbOficina
            // 
            this.chbOficina.CheckOnClick = true;
            this.chbOficina.FormattingEnabled = true;
            this.chbOficina.Location = new System.Drawing.Point(3, 3);
            this.chbOficina.Name = "chbOficina";
            this.chbOficina.Size = new System.Drawing.Size(235, 109);
            this.chbOficina.TabIndex = 46;
            this.chbOficina.SelectedIndexChanged += new System.EventHandler(this.chbOficina_SelectedIndexChanged);
            // 
            // chbTodosRegion
            // 
            this.chbTodosRegion.AutoSize = true;
            this.chbTodosRegion.Location = new System.Drawing.Point(241, 3);
            this.chbTodosRegion.Name = "chbTodosRegion";
            this.chbTodosRegion.Size = new System.Drawing.Size(56, 17);
            this.chbTodosRegion.TabIndex = 48;
            this.chbTodosRegion.Text = "Todos";
            this.chbTodosRegion.UseVisualStyleBackColor = true;
            this.chbTodosRegion.CheckedChanged += new System.EventHandler(this.chcTodosRegion_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbTodosRegion);
            this.panel1.Controls.Add(this.chbRegion);
            this.panel1.Location = new System.Drawing.Point(188, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 111);
            this.panel1.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chbTodosOficina);
            this.panel2.Controls.Add(this.chbOficina);
            this.panel2.Location = new System.Drawing.Point(188, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(303, 115);
            this.panel2.TabIndex = 50;
            // 
            // chbTodosOficina
            // 
            this.chbTodosOficina.AutoSize = true;
            this.chbTodosOficina.Location = new System.Drawing.Point(240, 3);
            this.chbTodosOficina.Name = "chbTodosOficina";
            this.chbTodosOficina.Size = new System.Drawing.Size(56, 17);
            this.chbTodosOficina.TabIndex = 47;
            this.chbTodosOficina.Text = "Todos";
            this.chbTodosOficina.UseVisualStyleBackColor = true;
            this.chbTodosOficina.CheckedChanged += new System.EventHandler(this.chcTodosOficina_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chbEstablecimiento);
            this.panel3.Controls.Add(this.chbTodosEstablecimiento);
            this.panel3.Location = new System.Drawing.Point(187, 245);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 117);
            this.panel3.TabIndex = 51;
            // 
            // chbEstablecimiento
            // 
            this.chbEstablecimiento.CheckOnClick = true;
            this.chbEstablecimiento.FormattingEnabled = true;
            this.chbEstablecimiento.Location = new System.Drawing.Point(4, 4);
            this.chbEstablecimiento.Name = "chbEstablecimiento";
            this.chbEstablecimiento.Size = new System.Drawing.Size(235, 109);
            this.chbEstablecimiento.TabIndex = 1;
            this.chbEstablecimiento.SelectedValueChanged += new System.EventHandler(this.chbEstablecimiento_SelectedIndexChanged);
            // 
            // chbTodosEstablecimiento
            // 
            this.chbTodosEstablecimiento.AutoSize = true;
            this.chbTodosEstablecimiento.Location = new System.Drawing.Point(242, 4);
            this.chbTodosEstablecimiento.Name = "chbTodosEstablecimiento";
            this.chbTodosEstablecimiento.Size = new System.Drawing.Size(56, 17);
            this.chbTodosEstablecimiento.TabIndex = 0;
            this.chbTodosEstablecimiento.Text = "Todos";
            this.chbTodosEstablecimiento.UseVisualStyleBackColor = true;
            this.chbTodosEstablecimiento.CheckedChanged += new System.EventHandler(this.chcTodosEstablecimiento_CheckedChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(59, 253);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(121, 13);
            this.lblBase7.TabIndex = 34;
            this.lblBase7.Text = "ESTABLECIMIENTO:";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(191, 375);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(143, 21);
            this.cboEstado.TabIndex = 52;
            // 
            // frmReporteDocumentosCreditosObs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 569);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chbHistorial);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicio);
            this.Name = "frmReporteDocumentosCreditosObs";
            this.Text = "Reporte de Documentos de Créditos Observados";
            this.Load += new System.EventHandler(this.frmReporteDocumentosCreditosObs_Load);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFinal, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.chbHistorial, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.cboEstado, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaFinal;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.CheckBox chbHistorial;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chklbBase chbRegion;
        private GEN.ControlesBase.chklbBase chbOficina;
        private GEN.ControlesBase.chcBase chbTodosRegion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GEN.ControlesBase.chcBase chbTodosOficina;
        private System.Windows.Forms.Panel panel3;
        private GEN.ControlesBase.chklbBase chbEstablecimiento;
        private GEN.ControlesBase.chcBase chbTodosEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.ComboBox cboEstado;
    }
}