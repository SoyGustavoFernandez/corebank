namespace RCP.Presentacion
{
    partial class frmComisionRecuperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComisionRecuperacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.cboRecuperacionComisionTipo = new GEN.ControlesBase.cboRecuperacionComisionTipo(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgRecuperacionComision = new GEN.ControlesBase.dtgBase(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReporteSIG = new GEN.BotonesBase.btnReporte();
            this.btnContinuar = new GEN.BotonesBase.btnContinuar();
            this.dtpFechaCalculo = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblEstado = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMontoComisionTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtgGrabRecupComision = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecuperacionComision)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrabRecupComision)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(16, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 70);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.cboRecuperacionComisionTipo);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(738, 10);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cboRecuperacionComisionTipo
            // 
            this.cboRecuperacionComisionTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecuperacionComisionTipo.FormattingEnabled = true;
            this.cboRecuperacionComisionTipo.Location = new System.Drawing.Point(407, 25);
            this.cboRecuperacionComisionTipo.Name = "cboRecuperacionComisionTipo";
            this.cboRecuperacionComisionTipo.Size = new System.Drawing.Size(296, 21);
            this.cboRecuperacionComisionTipo.TabIndex = 4;
            this.cboRecuperacionComisionTipo.SelectedIndexChanged += new System.EventHandler(this.cboRecuperacionComisionTipo_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(308, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(93, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Tipo Comisión:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarForeColor = System.Drawing.Color.CornflowerBlue;
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.Khaki;
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFecha.CalendarTrailingForeColor = System.Drawing.Color.SlateBlue;
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(76, 25);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(135, 20);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgRecuperacionComision);
            this.panel2.Location = new System.Drawing.Point(1, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 470);
            this.panel2.TabIndex = 3;
            // 
            // dtgRecuperacionComision
            // 
            this.dtgRecuperacionComision.AllowUserToAddRows = false;
            this.dtgRecuperacionComision.AllowUserToDeleteRows = false;
            this.dtgRecuperacionComision.AllowUserToResizeColumns = false;
            this.dtgRecuperacionComision.AllowUserToResizeRows = false;
            this.dtgRecuperacionComision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRecuperacionComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRecuperacionComision.Location = new System.Drawing.Point(11, 9);
            this.dtgRecuperacionComision.MultiSelect = false;
            this.dtgRecuperacionComision.Name = "dtgRecuperacionComision";
            this.dtgRecuperacionComision.ReadOnly = true;
            this.dtgRecuperacionComision.RowHeadersVisible = false;
            this.dtgRecuperacionComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRecuperacionComision.Size = new System.Drawing.Size(802, 451);
            this.dtgRecuperacionComision.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnReporteSIG);
            this.panel3.Controls.Add(this.btnContinuar);
            this.panel3.Controls.Add(this.dtpFechaCalculo);
            this.panel3.Controls.Add(this.lblBase3);
            this.panel3.Controls.Add(this.btnEnviar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnGrabar);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Location = new System.Drawing.Point(1, 541);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 65);
            this.panel3.TabIndex = 4;
            // 
            // btnReporteSIG
            // 
            this.btnReporteSIG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReporteSIG.BackgroundImage")));
            this.btnReporteSIG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReporteSIG.Location = new System.Drawing.Point(327, 4);
            this.btnReporteSIG.Name = "btnReporteSIG";
            this.btnReporteSIG.Size = new System.Drawing.Size(60, 50);
            this.btnReporteSIG.TabIndex = 13;
            this.btnReporteSIG.Text = "SIG Rpte";
            this.btnReporteSIG.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporteSIG.UseVisualStyleBackColor = true;
            this.btnReporteSIG.Click += new System.EventHandler(this.btnReporteSIG_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinuar.BackgroundImage")));
            this.btnContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContinuar.Location = new System.Drawing.Point(544, 4);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(60, 50);
            this.btnContinuar.TabIndex = 12;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // dtpFechaCalculo
            // 
            this.dtpFechaCalculo.Enabled = false;
            this.dtpFechaCalculo.Location = new System.Drawing.Point(121, 19);
            this.dtpFechaCalculo.Name = "dtpFechaCalculo";
            this.dtpFechaCalculo.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCalculo.TabIndex = 11;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(113, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Fecha de Calculo: ";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(676, 5);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(912, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(610, 5);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(978, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblBase6);
            this.panel4.Controls.Add(this.lblEstado);
            this.panel4.Controls.Add(this.lblBase5);
            this.panel4.Controls.Add(this.txtMontoComisionTotal);
            this.panel4.Controls.Add(this.lblBase4);
            this.panel4.Controls.Add(this.dtgGrabRecupComision);
            this.panel4.Location = new System.Drawing.Point(824, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(243, 539);
            this.panel4.TabIndex = 5;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(50, 338);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(50, 13);
            this.lblBase6.TabIndex = 5;
            this.lblBase6.Text = "Estado:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(99, 338);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(55, 13);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "ESTADO";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(1, 304);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Monto Total S/ :";
            // 
            // txtMontoComisionTotal
            // 
            this.txtMontoComisionTotal.BackColor = System.Drawing.Color.Bisque;
            this.txtMontoComisionTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoComisionTotal.ForeColor = System.Drawing.Color.SaddleBrown;
            this.txtMontoComisionTotal.FormatoDecimal = true;
            this.txtMontoComisionTotal.Location = new System.Drawing.Point(102, 301);
            this.txtMontoComisionTotal.Name = "txtMontoComisionTotal";
            this.txtMontoComisionTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoComisionTotal.nNumDecimales = 2;
            this.txtMontoComisionTotal.nvalor = 0D;
            this.txtMontoComisionTotal.ReadOnly = true;
            this.txtMontoComisionTotal.Size = new System.Drawing.Size(129, 20);
            this.txtMontoComisionTotal.TabIndex = 2;
            this.txtMontoComisionTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(50, 53);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(133, 13);
            this.lblBase4.TabIndex = 1;
            this.lblBase4.Text = "Estado de Comisiones";
            // 
            // dtgGrabRecupComision
            // 
            this.dtgGrabRecupComision.AllowUserToAddRows = false;
            this.dtgGrabRecupComision.AllowUserToDeleteRows = false;
            this.dtgGrabRecupComision.AllowUserToResizeColumns = false;
            this.dtgGrabRecupComision.AllowUserToResizeRows = false;
            this.dtgGrabRecupComision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrabRecupComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrabRecupComision.Location = new System.Drawing.Point(3, 78);
            this.dtgGrabRecupComision.MultiSelect = false;
            this.dtgGrabRecupComision.Name = "dtgGrabRecupComision";
            this.dtgGrabRecupComision.ReadOnly = true;
            this.dtgGrabRecupComision.RowHeadersVisible = false;
            this.dtgGrabRecupComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrabRecupComision.Size = new System.Drawing.Size(228, 207);
            this.dtgGrabRecupComision.TabIndex = 0;
            // 
            // frmComisionRecuperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 618);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmComisionRecuperacion";
            this.Text = "Comisión de Recuperaciones";
            this.Shown += new System.EventHandler(this.frmComisionRecuperacion_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecuperacionComision)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrabRecupComision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.cboRecuperacionComisionTipo cboRecuperacionComisionTipo;
        private System.Windows.Forms.Panel panel2;
        private GEN.ControlesBase.dtgBase dtgRecuperacionComision;
        private System.Windows.Forms.Panel panel3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.dtpCorto dtpFechaCalculo;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.Panel panel4;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtgBase dtgGrabRecupComision;
        private GEN.BotonesBase.btnContinuar btnContinuar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMontoComisionTotal;
        private GEN.ControlesBase.lblBase lblEstado;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.BotonesBase.btnReporte btnReporteSIG;
    }
}