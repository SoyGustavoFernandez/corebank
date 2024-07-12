namespace GEN.ControlesBase
{
    partial class frmSustentoArchivoSplaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSustentoArchivoSplaft));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtIdKardex = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaO = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblIdKardex = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgSustentos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoDocSustento = new GEN.ControlesBase.cboTipoDocumentoSustento(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.txtDescSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.panelFile = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSustentos)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.cboMoneda1);
            this.grbBase1.Controls.Add(this.txtIdKardex);
            this.grbBase1.Controls.Add(this.txtCuenta);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtOperacion);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Controls.Add(this.txtFechaO);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblIdKardex);
            this.grbBase1.Location = new System.Drawing.Point(3, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(786, 56);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(431, 37);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(56, 13);
            this.lblBase10.TabIndex = 10;
            this.lblBase10.Text = "Moneda:";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(507, 34);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda1.TabIndex = 11;
            // 
            // txtIdKardex
            // 
            this.txtIdKardex.Enabled = false;
            this.txtIdKardex.FormatoDecimal = false;
            this.txtIdKardex.Location = new System.Drawing.Point(84, 12);
            this.txtIdKardex.MaxLength = 50;
            this.txtIdKardex.Name = "txtIdKardex";
            this.txtIdKardex.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIdKardex.nNumDecimales = 0;
            this.txtIdKardex.nvalor = 0D;
            this.txtIdKardex.Size = new System.Drawing.Size(160, 20);
            this.txtIdKardex.TabIndex = 1;
            this.txtIdKardex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdKardex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdKardex_KeyPress);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Enabled = false;
            this.txtCuenta.Location = new System.Drawing.Point(325, 12);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(100, 20);
            this.txtCuenta.TabIndex = 5;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(266, 15);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(53, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Cuenta:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(431, 15);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(70, 13);
            this.lblBase5.TabIndex = 8;
            this.lblBase5.Text = "Operación:";
            // 
            // txtOperacion
            // 
            this.txtOperacion.Enabled = false;
            this.txtOperacion.Location = new System.Drawing.Point(507, 12);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(247, 20);
            this.txtOperacion.TabIndex = 9;
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(325, 34);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 7;
            // 
            // txtFechaO
            // 
            this.txtFechaO.Enabled = false;
            this.txtFechaO.Location = new System.Drawing.Point(84, 34);
            this.txtFechaO.Name = "txtFechaO";
            this.txtFechaO.Size = new System.Drawing.Size(160, 20);
            this.txtFechaO.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(266, 37);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(46, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Monto:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 37);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Fecha:";
            // 
            // lblIdKardex
            // 
            this.lblIdKardex.AutoSize = true;
            this.lblIdKardex.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblIdKardex.ForeColor = System.Drawing.Color.Navy;
            this.lblIdKardex.Location = new System.Drawing.Point(7, 15);
            this.lblIdKardex.Name = "lblIdKardex";
            this.lblIdKardex.Size = new System.Drawing.Size(81, 13);
            this.lblIdKardex.TabIndex = 0;
            this.lblIdKardex.Text = "Nro. Kardex:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgSustentos);
            this.grbBase2.Location = new System.Drawing.Point(3, 134);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(786, 140);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Sustentos";
            // 
            // dtgSustentos
            // 
            this.dtgSustentos.AllowUserToAddRows = false;
            this.dtgSustentos.AllowUserToDeleteRows = false;
            this.dtgSustentos.AllowUserToResizeColumns = false;
            this.dtgSustentos.AllowUserToResizeRows = false;
            this.dtgSustentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSustentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSustentos.Location = new System.Drawing.Point(7, 14);
            this.dtgSustentos.MultiSelect = false;
            this.dtgSustentos.Name = "dtgSustentos";
            this.dtgSustentos.ReadOnly = true;
            this.dtgSustentos.RowHeadersVisible = false;
            this.dtgSustentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSustentos.Size = new System.Drawing.Size(774, 124);
            this.dtgSustentos.TabIndex = 0;
            this.dtgSustentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSustentos_CellClick);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(1, 15);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(118, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Tipo de Documento";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboTipoDocSustento);
            this.grbBase3.Controls.Add(this.btnAgregar1);
            this.grbBase3.Controls.Add(this.txtDescSustento);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Location = new System.Drawing.Point(3, 65);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(786, 63);
            this.grbBase3.TabIndex = 6;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Agregar Sustento";
            // 
            // cboTipoDocSustento
            // 
            this.cboTipoDocSustento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocSustento.FormattingEnabled = true;
            this.cboTipoDocSustento.Location = new System.Drawing.Point(7, 35);
            this.cboTipoDocSustento.Name = "cboTipoDocSustento";
            this.cboTipoDocSustento.Size = new System.Drawing.Size(184, 21);
            this.cboTipoDocSustento.TabIndex = 10;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(711, 9);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 9;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // txtDescSustento
            // 
            this.txtDescSustento.Location = new System.Drawing.Point(197, 35);
            this.txtDescSustento.Name = "txtDescSustento";
            this.txtDescSustento.Size = new System.Drawing.Size(493, 20);
            this.txtDescSustento.TabIndex = 8;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(194, 15);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(148, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Descripción del Sustento";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(723, 3);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(658, 3);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 8;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(592, 3);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 9;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(526, 3);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // panelFile
            // 
            this.panelFile.AutoSize = true;
            this.panelFile.Controls.Add(this.grbBase1);
            this.panelFile.Controls.Add(this.grbBase3);
            this.panelFile.Controls.Add(this.grbBase2);
            this.panelFile.Controls.Add(this.panel1);
            this.panelFile.Controls.Add(this.panel2);
            this.panelFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFile.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelFile.Location = new System.Drawing.Point(0, 0);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(796, 639);
            this.panelFile.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalir1);
            this.panel1.Controls.Add(this.btnCancelar1);
            this.panel1.Controls.Add(this.btnGrabar1);
            this.panel1.Controls.Add(this.btnEditar1);
            this.panel1.Location = new System.Drawing.Point(3, 277);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 56);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.contPdf);
            this.panel2.Location = new System.Drawing.Point(3, 333);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 306);
            this.panel2.TabIndex = 12;
            this.panel2.Visible = false;
            // 
            // contPdf
            // 
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(3, 3);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(780, 300);
            this.contPdf.TabIndex = 0;
            // 
            // frmSustentoArchivoSplaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(796, 661);
            this.Controls.Add(this.panelFile);
            this.Name = "frmSustentoArchivoSplaft";
            this.Text = "Carga de Sustentos y Archivos";
            this.Load += new System.EventHandler(this.frmSustentoArchivoSplaft_Load);
            this.Controls.SetChildIndex(this.panelFile, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSustentos)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.panelFile.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.txtNumRea txtIdKardex;
        private GEN.ControlesBase.txtBase txtCuenta;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtOperacion;
        private GEN.ControlesBase.txtBase txtMonto;
        private GEN.ControlesBase.txtBase txtFechaO;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblIdKardex;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgSustentos;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.txtBase txtDescSustento;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.cboTipoDocumentoSustento cboTipoDocumentoSustento1;
        private GEN.ControlesBase.cboTipoDocumentoSustento cboTipoDocSustento;
        private System.Windows.Forms.FlowLayoutPanel panelFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private AxAcroPDFLib.AxAcroPDF contPdf;

    }
}