namespace DEP.Presentacion
{
    partial class frmConfirmarRetiroCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmarRetiroCTS));
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFecSolicitud = new System.Windows.Forms.DateTimePicker();
            this.txtColaborador = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.txtMonRetiro = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMotCambio = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.dtgAprobadores = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobadores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(665, 318);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 69;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 27);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(87, 13);
            this.lblBase3.TabIndex = 146;
            this.lblBase3.Text = "Fec. Solicitud:";
            // 
            // dtpFecSolicitud
            // 
            this.dtpFecSolicitud.Enabled = false;
            this.dtpFecSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecSolicitud.Location = new System.Drawing.Point(104, 25);
            this.dtpFecSolicitud.Name = "dtpFecSolicitud";
            this.dtpFecSolicitud.Size = new System.Drawing.Size(97, 20);
            this.dtpFecSolicitud.TabIndex = 147;
            // 
            // txtColaborador
            // 
            this.txtColaborador.Enabled = false;
            this.txtColaborador.Location = new System.Drawing.Point(373, 27);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.Size = new System.Drawing.Size(356, 20);
            this.txtColaborador.TabIndex = 17;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(217, 30);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(153, 13);
            this.lblBase5.TabIndex = 18;
            this.lblBase5.Text = "Colaborador que Solicitó:";
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.cboMotivoOperacion);
            this.grbBase5.Controls.Add(this.txtMonRetiro);
            this.grbBase5.Controls.Add(this.lblBase8);
            this.grbBase5.Controls.Add(this.lblBase1);
            this.grbBase5.Controls.Add(this.txtMotCambio);
            this.grbBase5.Controls.Add(this.lblBase22);
            this.grbBase5.Location = new System.Drawing.Point(10, 58);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(718, 119);
            this.grbBase5.TabIndex = 148;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Datos de la Solicitud";
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.Enabled = false;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(132, 19);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(283, 21);
            this.cboMotivoOperacion.TabIndex = 0;
            // 
            // txtMonRetiro
            // 
            this.txtMonRetiro.Enabled = false;
            this.txtMonRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonRetiro.FormatoDecimal = false;
            this.txtMonRetiro.Location = new System.Drawing.Point(133, 46);
            this.txtMonRetiro.Name = "txtMonRetiro";
            this.txtMonRetiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonRetiro.nNumDecimales = 2;
            this.txtMonRetiro.nvalor = 0D;
            this.txtMonRetiro.Size = new System.Drawing.Size(136, 20);
            this.txtMonRetiro.TabIndex = 1;
            this.txtMonRetiro.Text = "0.00";
            this.txtMonRetiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 49);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(100, 13);
            this.lblBase8.TabIndex = 150;
            this.lblBase8.Text = "Monto a Retirar:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 73);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 151;
            this.lblBase1.Text = "Detalle:";
            // 
            // txtMotCambio
            // 
            this.txtMotCambio.Enabled = false;
            this.txtMotCambio.Location = new System.Drawing.Point(132, 71);
            this.txtMotCambio.Multiline = true;
            this.txtMotCambio.Name = "txtMotCambio";
            this.txtMotCambio.Size = new System.Drawing.Size(558, 40);
            this.txtMotCambio.TabIndex = 2;
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(9, 23);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(115, 13);
            this.lblBase22.TabIndex = 152;
            this.lblBase22.Text = "Motivo Retiro CTS:";
            // 
            // dtgAprobadores
            // 
            this.dtgAprobadores.AllowUserToAddRows = false;
            this.dtgAprobadores.AllowUserToDeleteRows = false;
            this.dtgAprobadores.AllowUserToResizeColumns = false;
            this.dtgAprobadores.AllowUserToResizeRows = false;
            this.dtgAprobadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAprobadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAprobadores.Enabled = false;
            this.dtgAprobadores.Location = new System.Drawing.Point(12, 205);
            this.dtgAprobadores.MultiSelect = false;
            this.dtgAprobadores.Name = "dtgAprobadores";
            this.dtgAprobadores.ReadOnly = true;
            this.dtgAprobadores.RowHeadersVisible = false;
            this.dtgAprobadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAprobadores.Size = new System.Drawing.Size(713, 98);
            this.dtgAprobadores.TabIndex = 149;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(9, 183);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(719, 126);
            this.grbBase1.TabIndex = 150;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Aprobadores";
            // 
            // frmConfirmarRetiroCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 398);
            this.ControlBox = false;
            this.Controls.Add(this.dtgAprobadores);
            this.Controls.Add(this.grbBase5);
            this.Controls.Add(this.txtColaborador);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFecSolicitud);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmConfirmarRetiroCTS";
            this.Text = "Información de la Solicitud de Retiro de CTS APROBADO";
            this.Load += new System.EventHandler(this.frmConfirmarRetiroCTS_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.dtpFecSolicitud, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtColaborador, 0);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.dtgAprobadores, 0);
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.DateTimePicker dtpFecSolicitud;
        private GEN.ControlesBase.txtBase txtColaborador;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;
        private GEN.ControlesBase.txtNumRea txtMonRetiro;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtMotCambio;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.dtgBase dtgAprobadores;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}