namespace GEN.ControlesBase
{
    partial class conDatCredito
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtFechaDesembolso = new GEN.ControlesBase.dtLargoBase(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.cboProducto1 = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodSolicitud = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasaVigente = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNumCuotas = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMonDesembolsado = new GEN.ControlesBase.txtNumRea(this.components);
            this.SuspendLayout();
            // 
            // dtFechaDesembolso
            // 
            this.dtFechaDesembolso.Enabled = false;
            this.dtFechaDesembolso.Location = new System.Drawing.Point(143, 28);
            this.dtFechaDesembolso.Name = "dtFechaDesembolso";
            this.dtFechaDesembolso.Size = new System.Drawing.Size(195, 20);
            this.dtFechaDesembolso.TabIndex = 40;
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(405, 50);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(108, 21);
            this.cboMoneda1.TabIndex = 39;
            // 
            // cboProducto1
            // 
            this.cboProducto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto1.DropDownWidth = 350;
            this.cboProducto1.Enabled = false;
            this.cboProducto1.FormattingEnabled = true;
            this.cboProducto1.Location = new System.Drawing.Point(92, 73);
            this.cboProducto1.Name = "cboProducto1";
            this.cboProducto1.Size = new System.Drawing.Size(421, 21);
            this.cboProducto1.TabIndex = 38;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(344, 30);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(88, 13);
            this.lblBase7.TabIndex = 36;
            this.lblBase7.Text = "Nro. Solicitud:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(3, 53);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(86, 13);
            this.lblBase6.TabIndex = 36;
            this.lblBase6.Text = "Tasa Vigente:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(344, 9);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(98, 13);
            this.lblBase5.TabIndex = 36;
            this.lblBase5.Text = "Nro. de Cuotas:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(3, 30);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(119, 13);
            this.lblBase4.TabIndex = 36;
            this.lblBase4.Text = "Fecha Desembolso:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(344, 53);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 36;
            this.lblBase3.Text = "Moneda:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 74);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(62, 13);
            this.lblBase2.TabIndex = 36;
            this.lblBase2.Text = "Producto:";
            this.lblBase2.Click += new System.EventHandler(this.lblBase2_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(134, 13);
            this.lblBase1.TabIndex = 36;
            this.lblBase1.Text = "Monto Desembolsado:";
            // 
            // txtCodSolicitud
            // 
            this.txtCodSolicitud.Enabled = false;
            this.txtCodSolicitud.FormatoDecimal = false;
            this.txtCodSolicitud.Location = new System.Drawing.Point(448, 28);
            this.txtCodSolicitud.Name = "txtCodSolicitud";
            this.txtCodSolicitud.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCodSolicitud.nNumDecimales = 4;
            this.txtCodSolicitud.nvalor = 0D;
            this.txtCodSolicitud.Size = new System.Drawing.Size(65, 20);
            this.txtCodSolicitud.TabIndex = 37;
            // 
            // txtTasaVigente
            // 
            this.txtTasaVigente.Enabled = false;
            this.txtTasaVigente.FormatoDecimal = false;
            this.txtTasaVigente.Location = new System.Drawing.Point(143, 50);
            this.txtTasaVigente.Name = "txtTasaVigente";
            this.txtTasaVigente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaVigente.nNumDecimales = 4;
            this.txtTasaVigente.nvalor = 0D;
            this.txtTasaVigente.Size = new System.Drawing.Size(195, 20);
            this.txtTasaVigente.TabIndex = 37;
            // 
            // txtNumCuotas
            // 
            this.txtNumCuotas.CausesValidation = false;
            this.txtNumCuotas.Enabled = false;
            this.txtNumCuotas.FormatoDecimal = false;
            this.txtNumCuotas.Location = new System.Drawing.Point(448, 6);
            this.txtNumCuotas.Name = "txtNumCuotas";
            this.txtNumCuotas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumCuotas.nNumDecimales = 0;
            this.txtNumCuotas.nvalor = 0D;
            this.txtNumCuotas.Size = new System.Drawing.Size(65, 20);
            this.txtNumCuotas.TabIndex = 37;
            // 
            // txtMonDesembolsado
            // 
            this.txtMonDesembolsado.Enabled = false;
            this.txtMonDesembolsado.FormatoDecimal = false;
            this.txtMonDesembolsado.Location = new System.Drawing.Point(143, 6);
            this.txtMonDesembolsado.Name = "txtMonDesembolsado";
            this.txtMonDesembolsado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonDesembolsado.nNumDecimales = 2;
            this.txtMonDesembolsado.nvalor = 0D;
            this.txtMonDesembolsado.Size = new System.Drawing.Size(195, 20);
            this.txtMonDesembolsado.TabIndex = 37;
            // 
            // conDatCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtFechaDesembolso);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.cboProducto1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtCodSolicitud);
            this.Controls.Add(this.txtTasaVigente);
            this.Controls.Add(this.txtNumCuotas);
            this.Controls.Add(this.txtMonDesembolsado);
            this.Name = "conDatCredito";
            this.Size = new System.Drawing.Size(522, 106);
            this.Load += new System.EventHandler(this.conDatCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        public txtNumRea txtMonDesembolsado;
        private lblBase lblBase2;
        private lblBase lblBase3;
        private lblBase lblBase4;
        private lblBase lblBase5;
        private lblBase lblBase6;
        public txtNumRea txtNumCuotas;
        public txtNumRea txtTasaVigente;
        private lblBase lblBase7;
        public txtNumRea txtCodSolicitud;
        public cboProducto cboProducto1;
        public cboMoneda cboMoneda1;
        public dtLargoBase dtFechaDesembolso;
    }
}
