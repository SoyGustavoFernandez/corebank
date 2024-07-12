namespace DEP.Presentacion
{
    partial class frmExtornoOpeAho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtornoOpeAho));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtEstadoOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.nudNroKardex = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.txtModulo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboTipoOperacion = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMonOpe = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.conSolesDolar = new GEN.ControlesBase.ConSolesDolar();
            this.txtFechaOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNombrePerson = new GEN.ControlesBase.txtBase(this.components);
            this.txtDocIdePerson = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnExtorno = new GEN.BotonesBase.btnExtorno();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroKardex)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtEstadoOpe);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.nudNroKardex);
            this.grbBase1.Controls.Add(this.lblBase32);
            this.grbBase1.Location = new System.Drawing.Point(7, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(466, 72);
            this.grbBase1.TabIndex = 133;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar Operación";
            // 
            // txtEstadoOpe
            // 
            this.txtEstadoOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstadoOpe.Enabled = false;
            this.txtEstadoOpe.Location = new System.Drawing.Point(142, 45);
            this.txtEstadoOpe.Name = "txtEstadoOpe";
            this.txtEstadoOpe.Size = new System.Drawing.Size(210, 20);
            this.txtEstadoOpe.TabIndex = 141;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 167;
            this.lblBase1.Text = "Estado Operación:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(391, 15);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 166;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // nudNroKardex
            // 
            this.nudNroKardex.Enabled = false;
            this.nudNroKardex.Location = new System.Drawing.Point(143, 19);
            this.nudNroKardex.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudNroKardex.Name = "nudNroKardex";
            this.nudNroKardex.Size = new System.Drawing.Size(120, 20);
            this.nudNroKardex.TabIndex = 137;
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(8, 22);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(137, 13);
            this.lblBase32.TabIndex = 132;
            this.lblBase32.Text = "Número de Operación:";
            // 
            // txtModulo
            // 
            this.txtModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(139, 195);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(319, 20);
            this.txtModulo.TabIndex = 149;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(21, 41);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(52, 13);
            this.lblBase11.TabIndex = 150;
            this.lblBase11.Text = "Módulo:";
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.Enabled = false;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(139, 245);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(212, 21);
            this.cboTipoOperacion.TabIndex = 148;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(139, 271);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(212, 21);
            this.cboMoneda.TabIndex = 147;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(63, 118);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 146;
            this.lblBase7.Text = "Moneda:";
            // 
            // txtMonOpe
            // 
            this.txtMonOpe.Enabled = false;
            this.txtMonOpe.FormatoDecimal = false;
            this.txtMonOpe.Location = new System.Drawing.Point(134, 141);
            this.txtMonOpe.Name = "txtMonOpe";
            this.txtMonOpe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonOpe.nNumDecimales = 4;
            this.txtMonOpe.nvalor = 0D;
            this.txtMonOpe.Size = new System.Drawing.Size(145, 20);
            this.txtMonOpe.TabIndex = 144;
            this.txtMonOpe.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(63, 137);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(70, 29);
            this.lblBase6.TabIndex = 143;
            this.lblBase6.Text = "Monto Operación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 91);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 142;
            this.lblBase2.Text = "Tipo Operación:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.conSolesDolar);
            this.grbBase2.Controls.Add(this.txtFechaOpe);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.txtProducto);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.grbBase3);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.txtMonOpe);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Location = new System.Drawing.Point(5, 157);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(467, 172);
            this.grbBase2.TabIndex = 145;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Operación";
            // 
            // conSolesDolar
            // 
            this.conSolesDolar.Location = new System.Drawing.Point(5, 118);
            this.conSolesDolar.Name = "conSolesDolar";
            this.conSolesDolar.Size = new System.Drawing.Size(55, 48);
            this.conSolesDolar.TabIndex = 169;
            // 
            // txtFechaOpe
            // 
            this.txtFechaOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaOpe.Enabled = false;
            this.txtFechaOpe.Location = new System.Drawing.Point(133, 14);
            this.txtFechaOpe.Name = "txtFechaOpe";
            this.txtFechaOpe.Size = new System.Drawing.Size(209, 20);
            this.txtFechaOpe.TabIndex = 168;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(107, 13);
            this.lblBase4.TabIndex = 169;
            this.lblBase4.Text = "Fecha Operación:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(132, 63);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(321, 20);
            this.txtProducto.TabIndex = 170;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(21, 66);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(62, 13);
            this.lblBase3.TabIndex = 169;
            this.lblBase3.Text = "Producto:";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(1, -69);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(461, 64);
            this.grbBase3.TabIndex = 146;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Operación";
            // 
            // txtNombrePerson
            // 
            this.txtNombrePerson.Enabled = false;
            this.txtNombrePerson.Location = new System.Drawing.Point(127, 125);
            this.txtNombrePerson.Name = "txtNombrePerson";
            this.txtNombrePerson.Size = new System.Drawing.Size(331, 20);
            this.txtNombrePerson.TabIndex = 154;
            // 
            // txtDocIdePerson
            // 
            this.txtDocIdePerson.Enabled = false;
            this.txtDocIdePerson.Location = new System.Drawing.Point(127, 101);
            this.txtDocIdePerson.MaxLength = 11;
            this.txtDocIdePerson.Name = "txtDocIdePerson";
            this.txtDocIdePerson.Size = new System.Drawing.Size(110, 20);
            this.txtDocIdePerson.TabIndex = 153;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(8, 44);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(57, 13);
            this.lblBase16.TabIndex = 152;
            this.lblBase16.Text = "Nombre:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(8, 20);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(34, 13);
            this.lblBase17.TabIndex = 151;
            this.lblBase17.Text = "DNI:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(345, 338);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 167;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExtorno
            // 
            this.btnExtorno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno.BackgroundImage")));
            this.btnExtorno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno.Enabled = false;
            this.btnExtorno.Location = new System.Drawing.Point(283, 338);
            this.btnExtorno.Name = "btnExtorno";
            this.btnExtorno.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno.TabIndex = 166;
            this.btnExtorno.Text = "&Extornar";
            this.btnExtorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno.UseVisualStyleBackColor = true;
            this.btnExtorno.Click += new System.EventHandler(this.btnExtorno_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(407, 338);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 165;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblBase17);
            this.grbBase4.Controls.Add(this.lblBase16);
            this.grbBase4.Location = new System.Drawing.Point(7, 84);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(464, 69);
            this.grbBase4.TabIndex = 168;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Cliente que Realizó Operación";
            // 
            // frmExtornoOpeAho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 416);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExtorno);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNombrePerson);
            this.Controls.Add(this.txtDocIdePerson);
            this.Controls.Add(this.txtModulo);
            this.Controls.Add(this.cboTipoOperacion);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase4);
            this.Name = "frmExtornoOpeAho";
            this.Text = "Extorno Operaciones de Ahorros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExtornoOpeAho_FormClosed);
            this.Load += new System.EventHandler(this.frmExtornoOpeAho_Load);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.cboTipoOperacion, 0);
            this.Controls.SetChildIndex(this.txtModulo, 0);
            this.Controls.SetChildIndex(this.txtDocIdePerson, 0);
            this.Controls.SetChildIndex(this.txtNombrePerson, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroKardex)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.nudBase nudNroKardex;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtBase txtEstadoOpe;
        private GEN.ControlesBase.txtBase txtModulo;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtMonOpe;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        public GEN.ControlesBase.txtBase txtNombrePerson;
        public GEN.ControlesBase.txtCBDNI txtDocIdePerson;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnExtorno btnExtorno;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase4;
        public GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtFechaOpe;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.ConSolesDolar conSolesDolar;
    }
}