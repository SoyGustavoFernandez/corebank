namespace CRE.Presentacion
{
    partial class frmSalidaGarantia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalidaGarantia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgPropietarios = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.pbxAyuda1 = new GEN.ControlesBase.pbxAyuda();
            this.cboMotivoSalida = new GEN.ControlesBase.cboBase(this.components);
            this.cboModalidadVEnta = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtValorAdjudicacion = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtGastoAdjudicacion = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtVentaGarantia = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtGastoVenta = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelarSalida = new GEN.BotonesBase.btnCancelar();
            this.btnEditarSalida = new GEN.BotonesBase.btnEditar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPropietarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(697, 504);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 17;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(763, 504);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 18;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(829, 504);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 19;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantias.Location = new System.Drawing.Point(12, 138);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.dtgGarantias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(877, 113);
            this.dtgGarantias.TabIndex = 2;
            this.dtgGarantias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellClick);
            this.dtgGarantias.SelectionChanged += new System.EventHandler(this.dtgBase1_SelectionChanged);
            // 
            // dtgPropietarios
            // 
            this.dtgPropietarios.AllowUserToAddRows = false;
            this.dtgPropietarios.AllowUserToDeleteRows = false;
            this.dtgPropietarios.AllowUserToResizeColumns = false;
            this.dtgPropietarios.AllowUserToResizeRows = false;
            this.dtgPropietarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPropietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPropietarios.Enabled = false;
            this.dtgPropietarios.Location = new System.Drawing.Point(12, 267);
            this.dtgPropietarios.MultiSelect = false;
            this.dtgPropietarios.Name = "dtgPropietarios";
            this.dtgPropietarios.ReadOnly = true;
            this.dtgPropietarios.RowHeadersVisible = false;
            this.dtgPropietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPropietarios.Size = new System.Drawing.Size(877, 108);
            this.dtgPropietarios.TabIndex = 4;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 252);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(165, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Propietarios de la Garantía:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 123);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(67, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Garantías:";
            // 
            // lblBase3
            // 
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(33, 523);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(377, 31);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Tener en cuenta que al realizar la salida de una garantía, \r\nya no podrá utilizar" +
    " dicho registro en posteriores otorgamientos.";
            // 
            // pbxAyuda1
            // 
            this.pbxAyuda1.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda1.Image")));
            this.pbxAyuda1.Location = new System.Drawing.Point(14, 526);
            this.pbxAyuda1.Name = "pbxAyuda1";
            this.pbxAyuda1.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda1.TabIndex = 12;
            this.pbxAyuda1.TabStop = false;
            // 
            // cboMotivoSalida
            // 
            this.cboMotivoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoSalida.DropDownWidth = 600;
            this.cboMotivoSalida.FormattingEnabled = true;
            this.cboMotivoSalida.Location = new System.Drawing.Point(121, 18);
            this.cboMotivoSalida.Name = "cboMotivoSalida";
            this.cboMotivoSalida.Size = new System.Drawing.Size(505, 21);
            this.cboMotivoSalida.TabIndex = 6;
            this.cboMotivoSalida.SelectedIndexChanged += new System.EventHandler(this.cboMotivoSalida_SelectedIndexChanged);
            // 
            // cboModalidadVEnta
            // 
            this.cboModalidadVEnta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadVEnta.DropDownWidth = 600;
            this.cboModalidadVEnta.FormattingEnabled = true;
            this.cboModalidadVEnta.Location = new System.Drawing.Point(121, 45);
            this.cboModalidadVEnta.Name = "cboModalidadVEnta";
            this.cboModalidadVEnta.Size = new System.Drawing.Size(505, 21);
            this.cboModalidadVEnta.TabIndex = 8;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(3, 21);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(88, 13);
            this.lblBase4.TabIndex = 5;
            this.lblBase4.Text = "Motivo Salida:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(3, 48);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(105, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Modalidad Venta:";
            // 
            // txtValorAdjudicacion
            // 
            this.txtValorAdjudicacion.FormatoDecimal = false;
            this.txtValorAdjudicacion.Location = new System.Drawing.Point(8, 96);
            this.txtValorAdjudicacion.Name = "txtValorAdjudicacion";
            this.txtValorAdjudicacion.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorAdjudicacion.nNumDecimales = 2;
            this.txtValorAdjudicacion.nvalor = 0D;
            this.txtValorAdjudicacion.Size = new System.Drawing.Size(121, 20);
            this.txtValorAdjudicacion.TabIndex = 10;
            this.txtValorAdjudicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorAdjudicacion.Leave += new System.EventHandler(this.txtValorAdjudicacion_Leave);
            // 
            // txtGastoAdjudicacion
            // 
            this.txtGastoAdjudicacion.FormatoDecimal = false;
            this.txtGastoAdjudicacion.Location = new System.Drawing.Point(161, 96);
            this.txtGastoAdjudicacion.Name = "txtGastoAdjudicacion";
            this.txtGastoAdjudicacion.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGastoAdjudicacion.nNumDecimales = 2;
            this.txtGastoAdjudicacion.nvalor = 0D;
            this.txtGastoAdjudicacion.Size = new System.Drawing.Size(121, 20);
            this.txtGastoAdjudicacion.TabIndex = 12;
            this.txtGastoAdjudicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastoAdjudicacion.Leave += new System.EventHandler(this.txtGastoAdjudicacion_Leave);
            // 
            // txtVentaGarantia
            // 
            this.txtVentaGarantia.FormatoDecimal = false;
            this.txtVentaGarantia.Location = new System.Drawing.Point(313, 96);
            this.txtVentaGarantia.Name = "txtVentaGarantia";
            this.txtVentaGarantia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVentaGarantia.nNumDecimales = 2;
            this.txtVentaGarantia.nvalor = 0D;
            this.txtVentaGarantia.Size = new System.Drawing.Size(121, 20);
            this.txtVentaGarantia.TabIndex = 14;
            this.txtVentaGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVentaGarantia.Leave += new System.EventHandler(this.txtVentaGarantia_Leave);
            // 
            // txtGastoVenta
            // 
            this.txtGastoVenta.FormatoDecimal = false;
            this.txtGastoVenta.Location = new System.Drawing.Point(505, 96);
            this.txtGastoVenta.Name = "txtGastoVenta";
            this.txtGastoVenta.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGastoVenta.nNumDecimales = 2;
            this.txtGastoVenta.nvalor = 0D;
            this.txtGastoVenta.Size = new System.Drawing.Size(121, 20);
            this.txtGastoVenta.TabIndex = 16;
            this.txtGastoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGastoVenta.Leave += new System.EventHandler(this.txtGastoVenta_Leave);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(3, 80);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(117, 13);
            this.lblBase6.TabIndex = 9;
            this.lblBase6.Text = "Valor Adjudicación:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(158, 80);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(127, 13);
            this.lblBase7.TabIndex = 11;
            this.lblBase7.Text = "Gastos Adjudicación:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(310, 80);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(173, 13);
            this.lblBase8.TabIndex = 13;
            this.lblBase8.Text = "Venta Garantía sin impuesto:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(502, 80);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(87, 13);
            this.lblBase9.TabIndex = 15;
            this.lblBase9.Text = "Gastos Venta:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnCancelarSalida);
            this.grbBase1.Controls.Add(this.btnEditarSalida);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtGastoVenta);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.txtVentaGarantia);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.txtGastoAdjudicacion);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.txtValorAdjudicacion);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.cboModalidadVEnta);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboMotivoSalida);
            this.grbBase1.Location = new System.Drawing.Point(12, 376);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(768, 122);
            this.grbBase1.TabIndex = 20;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalles salida";
            // 
            // btnCancelarSalida
            // 
            this.btnCancelarSalida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarSalida.BackgroundImage")));
            this.btnCancelarSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarSalida.Location = new System.Drawing.Point(698, 18);
            this.btnCancelarSalida.Name = "btnCancelarSalida";
            this.btnCancelarSalida.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarSalida.TabIndex = 18;
            this.btnCancelarSalida.Text = "&Cancelar";
            this.btnCancelarSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarSalida.UseVisualStyleBackColor = true;
            this.btnCancelarSalida.Click += new System.EventHandler(this.btnCancelarSalida_Click);
            // 
            // btnEditarSalida
            // 
            this.btnEditarSalida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarSalida.BackgroundImage")));
            this.btnEditarSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarSalida.Location = new System.Drawing.Point(632, 18);
            this.btnEditarSalida.Name = "btnEditarSalida";
            this.btnEditarSalida.Size = new System.Drawing.Size(60, 50);
            this.btnEditarSalida.TabIndex = 17;
            this.btnEditarSalida.Text = "&Editar";
            this.btnEditarSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarSalida.UseVisualStyleBackColor = true;
            this.btnEditarSalida.Click += new System.EventHandler(this.btnEditarSalida_Click);
            // 
            // frmSalidaGarantia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 591);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.pbxAyuda1);
            this.Controls.Add(this.dtgPropietarios);
            this.Controls.Add(this.dtgGarantias);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmSalidaGarantia";
            this.Text = "Registrar Salida de Garantía";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.dtgGarantias, 0);
            this.Controls.SetChildIndex(this.dtgPropietarios, 0);
            this.Controls.SetChildIndex(this.pbxAyuda1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPropietarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.dtgBase dtgGarantias;
        private GEN.ControlesBase.dtgBase dtgPropietarios;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.pbxAyuda pbxAyuda1;
        private GEN.ControlesBase.cboBase cboMotivoSalida;
        private GEN.ControlesBase.cboBase cboModalidadVEnta;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtValorAdjudicacion;
        private GEN.ControlesBase.txtNumRea txtGastoAdjudicacion;
        private GEN.ControlesBase.txtNumRea txtVentaGarantia;
        private GEN.ControlesBase.txtNumRea txtGastoVenta;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnCancelar btnCancelarSalida;
        private GEN.BotonesBase.btnEditar btnEditarSalida;
    }
}

