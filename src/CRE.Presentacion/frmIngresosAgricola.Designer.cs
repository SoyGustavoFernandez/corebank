namespace CRE.Presentacion
{
    partial class frmIngresosAgricola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresosAgricola));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNRendimiento = new GEN.ControlesBase.txtNumerico(this.components);
            this.cboMesesCultivo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnMiniCancelEst();
            this.txtCantidad = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNRendimientoTotal = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtNPrecio = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtNIngreso = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.btnMiniAcept(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboUnidadProductivaEval = new GEN.ControlesBase.cboUnidadProductivaEval(this.components);
            this.cboUnidadMedidaEval = new GEN.ControlesBase.cboUnidadMedidaEval(this.components);
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgIngresos = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.txtNTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.btnEditar = new GEN.BotonesBase.btnMiniEditar();
            this.btnQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNUPMax = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngresos)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(183, 34);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(29, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Mes";
            // 
            // txtNRendimiento
            // 
            this.txtNRendimiento.Format = "n2";
            this.txtNRendimiento.Location = new System.Drawing.Point(227, 137);
            this.txtNRendimiento.MaxLength = 10;
            this.txtNRendimiento.Name = "txtNRendimiento";
            this.txtNRendimiento.Size = new System.Drawing.Size(121, 20);
            this.txtNRendimiento.TabIndex = 4;
            this.txtNRendimiento.Leave += new System.EventHandler(this.txtNRendimiento_Leave);
            // 
            // cboMesesCultivo
            // 
            this.cboMesesCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesesCultivo.FormattingEnabled = true;
            this.cboMesesCultivo.Location = new System.Drawing.Point(227, 31);
            this.cboMesesCultivo.Name = "cboMesesCultivo";
            this.cboMesesCultivo.Size = new System.Drawing.Size(121, 21);
            this.cboMesesCultivo.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(102, 61);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(110, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Unidad Productiva";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(84, 113);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(128, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "N° Unidad Productiva";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(26, 140);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(186, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Rendimiento/Unidad Productiva";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(270, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 28);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Format = "n2";
            this.txtCantidad.Location = new System.Drawing.Point(227, 110);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(103, 166);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(109, 13);
            this.lblBase5.TabIndex = 18;
            this.lblBase5.Text = "Rendimiento Total";
            // 
            // txtNRendimientoTotal
            // 
            this.txtNRendimientoTotal.Format = "n2";
            this.txtNRendimientoTotal.Location = new System.Drawing.Point(227, 163);
            this.txtNRendimientoTotal.MaxLength = 10;
            this.txtNRendimientoTotal.Name = "txtNRendimientoTotal";
            this.txtNRendimientoTotal.Size = new System.Drawing.Size(121, 20);
            this.txtNRendimientoTotal.TabIndex = 5;
            this.txtNRendimientoTotal.TextChanged += new System.EventHandler(this.txtNRendimientoTotal_TextChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(90, 219);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(122, 13);
            this.lblBase6.TabIndex = 20;
            this.lblBase6.Text = "Precio/Unidad Venta";
            // 
            // txtNPrecio
            // 
            this.txtNPrecio.Format = "n2";
            this.txtNPrecio.Location = new System.Drawing.Point(227, 216);
            this.txtNPrecio.MaxLength = 10;
            this.txtNPrecio.Name = "txtNPrecio";
            this.txtNPrecio.Size = new System.Drawing.Size(121, 20);
            this.txtNPrecio.TabIndex = 7;
            this.txtNPrecio.TextChanged += new System.EventHandler(this.txtNPrecio_TextChanged);
            this.txtNPrecio.Leave += new System.EventHandler(this.txtNPrecio_Leave);
            // 
            // txtNIngreso
            // 
            this.txtNIngreso.Format = "n2";
            this.txtNIngreso.Location = new System.Drawing.Point(227, 243);
            this.txtNIngreso.MaxLength = 10;
            this.txtNIngreso.Name = "txtNIngreso";
            this.txtNIngreso.Size = new System.Drawing.Size(121, 20);
            this.txtNIngreso.TabIndex = 8;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(123, 246);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(89, 13);
            this.lblBase7.TabIndex = 23;
            this.lblBase7.Text = "Monto Ingreso";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(228, 283);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(36, 28);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(126, 192);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(86, 13);
            this.lblBase8.TabIndex = 29;
            this.lblBase8.Text = "Unidad  Venta";
            // 
            // cboUnidadProductivaEval
            // 
            this.cboUnidadProductivaEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadProductivaEval.FormattingEnabled = true;
            this.cboUnidadProductivaEval.Location = new System.Drawing.Point(227, 58);
            this.cboUnidadProductivaEval.Name = "cboUnidadProductivaEval";
            this.cboUnidadProductivaEval.Size = new System.Drawing.Size(121, 21);
            this.cboUnidadProductivaEval.TabIndex = 2;
            // 
            // cboUnidadMedidaEval
            // 
            this.cboUnidadMedidaEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadMedidaEval.Enabled = false;
            this.cboUnidadMedidaEval.FormattingEnabled = true;
            this.cboUnidadMedidaEval.Location = new System.Drawing.Point(227, 189);
            this.cboUnidadMedidaEval.Name = "cboUnidadMedidaEval";
            this.cboUnidadMedidaEval.Size = new System.Drawing.Size(121, 21);
            this.cboUnidadMedidaEval.TabIndex = 6;
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(13, 344);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(616, 145);
            this.panelGlobal.TabIndex = 61;
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(614, 143);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgIngresos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 119);
            this.panel2.TabIndex = 25;
            // 
            // dtgIngresos
            // 
            this.dtgIngresos.AllowUserToAddRows = false;
            this.dtgIngresos.AllowUserToDeleteRows = false;
            this.dtgIngresos.AllowUserToResizeColumns = false;
            this.dtgIngresos.AllowUserToResizeRows = false;
            this.dtgIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIngresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIngresos.Location = new System.Drawing.Point(0, 0);
            this.dtgIngresos.MultiSelect = false;
            this.dtgIngresos.Name = "dtgIngresos";
            this.dtgIngresos.ReadOnly = true;
            this.dtgIngresos.RowHeadersVisible = false;
            this.dtgIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIngresos.Size = new System.Drawing.Size(614, 119);
            this.dtgIngresos.TabIndex = 28;
            this.dtgIngresos.TabStop = false;
            this.dtgIngresos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellClick);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(614, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(414, 24);
            this.menuStrip1.TabIndex = 101;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 100;
            this.label2.Text = "Ingresos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(569, 521);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 62;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtNTotal
            // 
            this.txtNTotal.Enabled = false;
            this.txtNTotal.FormatoDecimal = false;
            this.txtNTotal.Location = new System.Drawing.Point(508, 495);
            this.txtNTotal.Name = "txtNTotal";
            this.txtNTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNTotal.nNumDecimales = 4;
            this.txtNTotal.nvalor = 0D;
            this.txtNTotal.Size = new System.Drawing.Size(121, 20);
            this.txtNTotal.TabIndex = 63;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(458, 498);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(34, 13);
            this.lblBase9.TabIndex = 64;
            this.lblBase9.Text = "Total";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(144, 283);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(186, 283);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(36, 28);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(312, 283);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 13;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grbBase1.Controls.Add(this.txtNUPMax);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.cboMesesCultivo);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnQuitar);
            this.grbBase1.Controls.Add(this.txtNRendimiento);
            this.grbBase1.Controls.Add(this.btnEditar);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnNuevo);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.btnCancelar);
            this.grbBase1.Controls.Add(this.txtCantidad);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboUnidadMedidaEval);
            this.grbBase1.Controls.Add(this.txtNRendimientoTotal);
            this.grbBase1.Controls.Add(this.cboUnidadProductivaEval);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtNPrecio);
            this.grbBase1.Controls.Add(this.btnAceptar);
            this.grbBase1.Controls.Add(this.txtNIngreso);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Location = new System.Drawing.Point(12, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(377, 334);
            this.grbBase1.TabIndex = 68;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Ingreso";
            // 
            // txtNUPMax
            // 
            this.txtNUPMax.Enabled = false;
            this.txtNUPMax.Location = new System.Drawing.Point(227, 85);
            this.txtNUPMax.MaxLength = 10;
            this.txtNUPMax.Name = "txtNUPMax";
            this.txtNUPMax.Size = new System.Drawing.Size(121, 20);
            this.txtNUPMax.TabIndex = 69;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(17, 88);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(195, 13);
            this.lblBase10.TabIndex = 69;
            this.lblBase10.Text = "N° Unidades Productivas Máxima";
            // 
            // frmIngresosAgricola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 596);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtNTotal);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.panelGlobal);
            this.Name = "frmIngresosAgricola";
            this.Text = "Registro de Ingresos";
            this.Load += new System.EventHandler(this.frmIngresosAgricola_Load);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.txtNTotal, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIngresos)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumerico txtNRendimiento;
        private GEN.ControlesBase.cboBase cboMesesCultivo;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelar;
        private GEN.ControlesBase.txtNumerico txtCantidad;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumerico txtNRendimientoTotal;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumerico txtNPrecio;
        private GEN.ControlesBase.txtNumerico txtNIngreso;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnMiniAcept btnAceptar;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboUnidadProductivaEval cboUnidadProductivaEval;
        private GEN.ControlesBase.cboUnidadMedidaEval cboUnidadMedidaEval;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgIngresos;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label2;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtNumRea txtNTotal;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnMiniNuevo btnNuevo;
        private GEN.BotonesBase.btnMiniEditar btnEditar;
        private GEN.BotonesBase.btnMiniQuitar btnQuitar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtNUPMax;
        private GEN.ControlesBase.lblBase lblBase10;

    }
}