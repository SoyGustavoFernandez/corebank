namespace CRE.Presentacion
{
    partial class frmCobroCreditosDctoPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobroCreditosDctoPlanilla));
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtTotalCreditos = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTotalPago = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgPagoCreditosConvenio = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dtpFecVen = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboConvenio = new GEN.ControlesBase.cboConvenio(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoPago = new GEN.ControlesBase.cboTipoPago(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.conPagoBcos = new GEN.ControlesBase.conPagoBcos();
            this.grbPagoIns = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroOpeIns = new GEN.ControlesBase.txtBase(this.components);
            this.txtCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtEntidad = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase29 = new GEN.ControlesBase.lblBase();
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCreditosConvenio)).BeginInit();
            this.grbPagoIns.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 399);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(144, 13);
            this.lblBase7.TabIndex = 34;
            this.lblBase7.Text = "Nro Créditos por Pagar:";
            // 
            // txtTotalCreditos
            // 
            this.txtTotalCreditos.Enabled = false;
            this.txtTotalCreditos.FormatoDecimal = false;
            this.txtTotalCreditos.Location = new System.Drawing.Point(165, 395);
            this.txtTotalCreditos.Name = "txtTotalCreditos";
            this.txtTotalCreditos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCreditos.nNumDecimales = 4;
            this.txtTotalCreditos.nvalor = 0D;
            this.txtTotalCreditos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCreditos.TabIndex = 32;
            this.txtTotalCreditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(270, 399);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 30;
            this.lblBase5.Text = "A Pagar:";
            // 
            // txtTotalPago
            // 
            this.txtTotalPago.Enabled = false;
            this.txtTotalPago.FormatoDecimal = false;
            this.txtTotalPago.Location = new System.Drawing.Point(333, 395);
            this.txtTotalPago.Name = "txtTotalPago";
            this.txtTotalPago.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalPago.nNumDecimales = 4;
            this.txtTotalPago.nvalor = 0D;
            this.txtTotalPago.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPago.TabIndex = 27;
            this.txtTotalPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgPagoCreditosConvenio
            // 
            this.dtgPagoCreditosConvenio.AllowUserToAddRows = false;
            this.dtgPagoCreditosConvenio.AllowUserToDeleteRows = false;
            this.dtgPagoCreditosConvenio.AllowUserToOrderColumns = true;
            this.dtgPagoCreditosConvenio.AllowUserToResizeColumns = false;
            this.dtgPagoCreditosConvenio.AllowUserToResizeRows = false;
            this.dtgPagoCreditosConvenio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgPagoCreditosConvenio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagoCreditosConvenio.Location = new System.Drawing.Point(10, 116);
            this.dtgPagoCreditosConvenio.MultiSelect = false;
            this.dtgPagoCreditosConvenio.Name = "dtgPagoCreditosConvenio";
            this.dtgPagoCreditosConvenio.ReadOnly = true;
            this.dtgPagoCreditosConvenio.RowHeadersVisible = false;
            this.dtgPagoCreditosConvenio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPagoCreditosConvenio.Size = new System.Drawing.Size(904, 272);
            this.dtgPagoCreditosConvenio.TabIndex = 21;
            this.dtgPagoCreditosConvenio.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPagoCreditosConvenio_CellValueChanged);
            this.dtgPagoCreditosConvenio.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgPagoCreditosConvenio_EditingControlShowing);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(650, 394);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 22;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(786, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(854, 394);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Location = new System.Drawing.Point(582, 394);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 35;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Archivo txt (*.txt)|*.txt";
            this.openFileDialog.Title = "Planilla Convenio";
            // 
            // dtpFecVen
            // 
            this.dtpFecVen.Location = new System.Drawing.Point(107, 32);
            this.dtpFecVen.Name = "dtpFecVen";
            this.dtpFecVen.Size = new System.Drawing.Size(173, 20);
            this.dtpFecVen.TabIndex = 36;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 36);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(93, 13);
            this.lblBase1.TabIndex = 37;
            this.lblBase1.Text = "F. Vencimiento:";
            // 
            // cboConvenio
            // 
            this.cboConvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvenio.FormattingEnabled = true;
            this.cboConvenio.Location = new System.Drawing.Point(107, 6);
            this.cboConvenio.Name = "cboConvenio";
            this.cboConvenio.Size = new System.Drawing.Size(317, 21);
            this.cboConvenio.TabIndex = 38;
            this.cboConvenio.SelectedIndexChanged += new System.EventHandler(this.cboConvenio_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(35, 10);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 39;
            this.lblBase2.Text = "Convenio:";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(107, 83);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(176, 21);
            this.cboTipoPago.TabIndex = 40;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(33, 87);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(68, 13);
            this.lblBase3.TabIndex = 41;
            this.lblBase3.Text = "Tipo Pago:";
            // 
            // conPagoBcos
            // 
            this.conPagoBcos.Location = new System.Drawing.Point(464, 17);
            this.conPagoBcos.Name = "conPagoBcos";
            this.conPagoBcos.Size = new System.Drawing.Size(256, 93);
            this.conPagoBcos.TabIndex = 42;
            this.conPagoBcos.Tag = "";
            // 
            // grbPagoIns
            // 
            this.grbPagoIns.Controls.Add(this.txtNroOpeIns);
            this.grbPagoIns.Controls.Add(this.txtCuenta);
            this.grbPagoIns.Controls.Add(this.txtEntidad);
            this.grbPagoIns.Controls.Add(this.lblBase8);
            this.grbPagoIns.Controls.Add(this.lblBase6);
            this.grbPagoIns.Controls.Add(this.lblBase4);
            this.grbPagoIns.Enabled = false;
            this.grbPagoIns.Location = new System.Drawing.Point(464, 17);
            this.grbPagoIns.Name = "grbPagoIns";
            this.grbPagoIns.Size = new System.Drawing.Size(349, 93);
            this.grbPagoIns.TabIndex = 43;
            this.grbPagoIns.TabStop = false;
            this.grbPagoIns.Text = "Detalle Medio de Pago";
            this.grbPagoIns.Visible = false;
            // 
            // txtNroOpeIns
            // 
            this.txtNroOpeIns.Location = new System.Drawing.Point(106, 66);
            this.txtNroOpeIns.Name = "txtNroOpeIns";
            this.txtNroOpeIns.Size = new System.Drawing.Size(237, 20);
            this.txtNroOpeIns.TabIndex = 5;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(80, 46);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(263, 20);
            this.txtCuenta.TabIndex = 4;
            // 
            // txtEntidad
            // 
            this.txtEntidad.Location = new System.Drawing.Point(80, 26);
            this.txtEntidad.Name = "txtEntidad";
            this.txtEntidad.Size = new System.Drawing.Size(263, 20);
            this.txtEntidad.TabIndex = 3;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(6, 74);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(94, 13);
            this.lblBase8.TabIndex = 2;
            this.lblBase8.Text = "Nro Operación:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 51);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(53, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Cuenta:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 29);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(54, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Entidad:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(718, 394);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 44;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase29
            // 
            this.lblBase29.AutoSize = true;
            this.lblBase29.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase29.ForeColor = System.Drawing.Color.Navy;
            this.lblBase29.Location = new System.Drawing.Point(5, 61);
            this.lblBase29.Name = "lblBase29";
            this.lblBase29.Size = new System.Drawing.Size(98, 13);
            this.lblBase29.TabIndex = 46;
            this.lblBase29.Text = "Mot. Operación:";
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(107, 57);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(173, 21);
            this.cboMotivoOperacion.TabIndex = 45;
            // 
            // frmCobroCreditosDctoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 473);
            this.Controls.Add(this.lblBase29);
            this.Controls.Add(this.cboMotivoOperacion);
            this.Controls.Add(this.conPagoBcos);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboTipoPago);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboConvenio);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecVen);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtTotalCreditos);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtTotalPago);
            this.Controls.Add(this.dtgPagoCreditosConvenio);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbPagoIns);
            this.Name = "frmCobroCreditosDctoPlanilla";
            this.Text = "Cobro Masivo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCobroCreditosDctoPlanilla_FormClosed);
            this.Load += new System.EventHandler(this.frmCobroCreditosDctoPlanilla_Load);
            this.Controls.SetChildIndex(this.grbPagoIns, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.dtgPagoCreditosConvenio, 0);
            this.Controls.SetChildIndex(this.txtTotalPago, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtTotalCreditos, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.dtpFecVen, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboConvenio, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoPago, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.conPagoBcos, 0);
            this.Controls.SetChildIndex(this.cboMotivoOperacion, 0);
            this.Controls.SetChildIndex(this.lblBase29, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoCreditosConvenio)).EndInit();
            this.grbPagoIns.ResumeLayout(false);
            this.grbPagoIns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtTotalCreditos;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtTotalPago;
        private GEN.ControlesBase.dtgBase dtgPagoCreditosConvenio;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImportar btnImportar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private GEN.ControlesBase.dtpCorto dtpFecVen;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboConvenio cboConvenio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoPago cboTipoPago;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.conPagoBcos conPagoBcos;
        private GEN.ControlesBase.grbBase grbPagoIns;
        private GEN.ControlesBase.txtBase txtNroOpeIns;
        private GEN.ControlesBase.txtBase txtCuenta;
        private GEN.ControlesBase.txtBase txtEntidad;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase29;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;

    }
}

