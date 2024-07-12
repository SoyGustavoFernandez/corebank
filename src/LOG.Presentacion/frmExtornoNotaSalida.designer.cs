namespace LOG.Presentacion
{
    partial class frmExtornoNotaSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtornoNotaSalida));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnExtorno = new GEN.BotonesBase.btnExtorno();
            this.dtgDetNotaSalida = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtFechaOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.cboTipoOperacion = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.txtModulo = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMonOpe = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtEstadoOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.nudNroKardex = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetNotaSalida)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(427, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnExtorno
            // 
            this.btnExtorno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno.BackgroundImage")));
            this.btnExtorno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno.Location = new System.Drawing.Point(295, 406);
            this.btnExtorno.Name = "btnExtorno";
            this.btnExtorno.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno.TabIndex = 3;
            this.btnExtorno.Text = "&Extornar";
            this.btnExtorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno.UseVisualStyleBackColor = true;
            this.btnExtorno.Click += new System.EventHandler(this.btnExtorno_Click);
            // 
            // dtgDetNotaSalida
            // 
            this.dtgDetNotaSalida.AllowUserToAddRows = false;
            this.dtgDetNotaSalida.AllowUserToDeleteRows = false;
            this.dtgDetNotaSalida.AllowUserToResizeColumns = false;
            this.dtgDetNotaSalida.AllowUserToResizeRows = false;
            this.dtgDetNotaSalida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetNotaSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetNotaSalida.Location = new System.Drawing.Point(8, 19);
            this.dtgDetNotaSalida.MultiSelect = false;
            this.dtgDetNotaSalida.Name = "dtgDetNotaSalida";
            this.dtgDetNotaSalida.ReadOnly = true;
            this.dtgDetNotaSalida.RowHeadersVisible = false;
            this.dtgDetNotaSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetNotaSalida.Size = new System.Drawing.Size(466, 139);
            this.dtgDetNotaSalida.TabIndex = 0;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgDetNotaSalida);
            this.grbBase2.Location = new System.Drawing.Point(7, 236);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(480, 164);
            this.grbBase2.TabIndex = 5;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Detalle de nota de salida";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtFechaOpe);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.cboMoneda);
            this.grbBase3.Controls.Add(this.cboTipoOperacion);
            this.grbBase3.Controls.Add(this.txtModulo);
            this.grbBase3.Controls.Add(this.grbBase4);
            this.grbBase3.Controls.Add(this.txtMonOpe);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Location = new System.Drawing.Point(7, 85);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(480, 145);
            this.grbBase3.TabIndex = 175;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Operación";
            // 
            // txtFechaOpe
            // 
            this.txtFechaOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaOpe.Enabled = false;
            this.txtFechaOpe.Location = new System.Drawing.Point(133, 16);
            this.txtFechaOpe.Name = "txtFechaOpe";
            this.txtFechaOpe.Size = new System.Drawing.Size(144, 20);
            this.txtFechaOpe.TabIndex = 168;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(24, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(107, 13);
            this.lblBase4.TabIndex = 169;
            this.lblBase4.Text = "Fecha Operación:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(133, 91);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(144, 21);
            this.cboMoneda.TabIndex = 173;
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.Enabled = false;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(133, 66);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(144, 21);
            this.cboTipoOperacion.TabIndex = 174;
            // 
            // txtModulo
            // 
            this.txtModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(133, 40);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(144, 20);
            this.txtModulo.TabIndex = 175;
            // 
            // grbBase4
            // 
            this.grbBase4.Location = new System.Drawing.Point(1, -69);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(461, 64);
            this.grbBase4.TabIndex = 146;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Datos de la Operación";
            // 
            // txtMonOpe
            // 
            this.txtMonOpe.Enabled = false;
            this.txtMonOpe.FormatoDecimal = false;
            this.txtMonOpe.Location = new System.Drawing.Point(133, 116);
            this.txtMonOpe.Name = "txtMonOpe";
            this.txtMonOpe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonOpe.nNumDecimales = 4;
            this.txtMonOpe.nvalor = 0D;
            this.txtMonOpe.Size = new System.Drawing.Size(144, 20);
            this.txtMonOpe.TabIndex = 171;
            this.txtMonOpe.Text = "0.00";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(24, 44);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(52, 13);
            this.lblBase11.TabIndex = 150;
            this.lblBase11.Text = "Módulo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(24, 120);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 143;
            this.lblBase6.Text = "Monto Operación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(24, 70);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 142;
            this.lblBase2.Text = "Tipo Operación:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(24, 95);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 146;
            this.lblBase7.Text = "Moneda:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtEstadoOpe);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.nudNroKardex);
            this.grbBase1.Controls.Add(this.lblBase32);
            this.grbBase1.Location = new System.Drawing.Point(7, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(480, 72);
            this.grbBase1.TabIndex = 174;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar ingreso a almacén";
            // 
            // txtEstadoOpe
            // 
            this.txtEstadoOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstadoOpe.Enabled = false;
            this.txtEstadoOpe.Location = new System.Drawing.Point(205, 40);
            this.txtEstadoOpe.Name = "txtEstadoOpe";
            this.txtEstadoOpe.Size = new System.Drawing.Size(170, 20);
            this.txtEstadoOpe.TabIndex = 141;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(52, 47);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 167;
            this.lblBase1.Text = "Estado Operación:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(414, 14);
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
            this.nudNroKardex.Location = new System.Drawing.Point(205, 18);
            this.nudNroKardex.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudNroKardex.Name = "nudNroKardex";
            this.nudNroKardex.Size = new System.Drawing.Size(170, 20);
            this.nudNroKardex.TabIndex = 137;
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(52, 21);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(137, 13);
            this.lblBase32.TabIndex = 132;
            this.lblBase32.Text = "Número de Operación:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(361, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 176;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmExtornoNotaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 487);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnExtorno);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmExtornoNotaSalida";
            this.Text = "Extorno salida de almacén";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetNotaSalida)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroKardex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnExtorno btnExtorno;
        private GEN.ControlesBase.dtgBase dtgDetNotaSalida;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtFechaOpe;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion;
        private GEN.ControlesBase.txtBase txtModulo;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.txtNumRea txtMonOpe;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtEstadoOpe;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.nudBase nudNroKardex;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.BotonesBase.btnCancelar btnCancelar;
    }
}

