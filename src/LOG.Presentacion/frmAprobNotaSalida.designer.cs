﻿namespace LOG.Presentacion
{
    partial class frmAprobNotaSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobNotaSalida));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgNotSalida = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboAgeNS = new GEN.ControlesBase.cboAgencia(this.components);
            this.txtActividad = new GEN.ControlesBase.txtBase(this.components);
            this.txtUsuReg = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtpFechaNS = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtUsuAprob = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumNS = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnBusqNotSalida = new GEN.BotonesBase.btnBusqueda();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgItems = new GEN.ControlesBase.dtgBase(this.components);
            this.idDetalleNotaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUniMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadApro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDenegar = new GEN.BotonesBase.btnDenegar();
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.txtAlmacen = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotSalida)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(865, 380);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgNotSalida
            // 
            this.dtgNotSalida.AllowUserToAddRows = false;
            this.dtgNotSalida.AllowUserToDeleteRows = false;
            this.dtgNotSalida.AllowUserToResizeColumns = false;
            this.dtgNotSalida.AllowUserToResizeRows = false;
            this.dtgNotSalida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNotSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotSalida.Location = new System.Drawing.Point(12, 20);
            this.dtgNotSalida.MultiSelect = false;
            this.dtgNotSalida.Name = "dtgNotSalida";
            this.dtgNotSalida.ReadOnly = true;
            this.dtgNotSalida.RowHeadersVisible = false;
            this.dtgNotSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotSalida.Size = new System.Drawing.Size(483, 410);
            this.dtgNotSalida.TabIndex = 54;
            this.dtgNotSalida.SelectionChanged += new System.EventHandler(this.dtgNotSalida_SelectionChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboAgencia);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.dtpFechaFin);
            this.grbBase2.Controls.Add(this.dtpFechaIni);
            this.grbBase2.Location = new System.Drawing.Point(498, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(370, 68);
            this.grbBase2.TabIndex = 55;
            this.grbBase2.TabStop = false;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.Enabled = false;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(76, 12);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(284, 21);
            this.cboAgencia.TabIndex = 51;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 16);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(57, 13);
            this.lblBase7.TabIndex = 50;
            this.lblBase7.Text = "Agencia:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(190, 43);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(65, 13);
            this.lblBase6.TabIndex = 49;
            this.lblBase6.Text = "Fecha Fin:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(64, 13);
            this.lblBase2.TabIndex = 48;
            this.lblBase2.Text = "Fecha Ini:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(261, 39);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(99, 20);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(76, 39);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(99, 20);
            this.dtpFechaIni.TabIndex = 0;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(502, 117);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(57, 13);
            this.lblBase9.TabIndex = 67;
            this.lblBase9.Text = "Agencia:";
            // 
            // cboAgeNS
            // 
            this.cboAgeNS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeNS.Enabled = false;
            this.cboAgeNS.FormattingEnabled = true;
            this.cboAgeNS.Location = new System.Drawing.Point(575, 114);
            this.cboAgeNS.Name = "cboAgeNS";
            this.cboAgeNS.Size = new System.Drawing.Size(122, 21);
            this.cboAgeNS.TabIndex = 66;
            // 
            // txtActividad
            // 
            this.txtActividad.Enabled = false;
            this.txtActividad.Location = new System.Drawing.Point(575, 161);
            this.txtActividad.Name = "txtActividad";
            this.txtActividad.ReadOnly = true;
            this.txtActividad.Size = new System.Drawing.Size(348, 20);
            this.txtActividad.TabIndex = 65;
            // 
            // txtUsuReg
            // 
            this.txtUsuReg.Enabled = false;
            this.txtUsuReg.Location = new System.Drawing.Point(575, 138);
            this.txtUsuReg.Name = "txtUsuReg";
            this.txtUsuReg.ReadOnly = true;
            this.txtUsuReg.Size = new System.Drawing.Size(122, 20);
            this.txtUsuReg.TabIndex = 64;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(499, 164);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(64, 13);
            this.lblBase1.TabIndex = 63;
            this.lblBase1.Text = "Actividad:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(499, 141);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(67, 13);
            this.lblBase8.TabIndex = 62;
            this.lblBase8.Text = "Usu. Reg.:";
            // 
            // dtpFechaNS
            // 
            this.dtpFechaNS.Enabled = false;
            this.dtpFechaNS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNS.Location = new System.Drawing.Point(778, 138);
            this.dtpFechaNS.Name = "dtpFechaNS";
            this.dtpFechaNS.Size = new System.Drawing.Size(145, 20);
            this.dtpFechaNS.TabIndex = 57;
            // 
            // txtUsuAprob
            // 
            this.txtUsuAprob.Enabled = false;
            this.txtUsuAprob.Location = new System.Drawing.Point(778, 114);
            this.txtUsuAprob.Name = "txtUsuAprob";
            this.txtUsuAprob.ReadOnly = true;
            this.txtUsuAprob.Size = new System.Drawing.Size(145, 20);
            this.txtUsuAprob.TabIndex = 58;
            // 
            // txtNumNS
            // 
            this.txtNumNS.Enabled = false;
            this.txtNumNS.Location = new System.Drawing.Point(575, 92);
            this.txtNumNS.Name = "txtNumNS";
            this.txtNumNS.ReadOnly = true;
            this.txtNumNS.Size = new System.Drawing.Size(122, 20);
            this.txtNumNS.TabIndex = 59;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(727, 141);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 61;
            this.lblBase5.Text = "Fecha:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(499, 96);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(70, 13);
            this.lblBase4.TabIndex = 60;
            this.lblBase4.Text = "Nro de NS:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(703, 117);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(71, 13);
            this.lblBase3.TabIndex = 56;
            this.lblBase3.Text = "Usu.Aprob:";
            // 
            // btnBusqNotSalida
            // 
            this.btnBusqNotSalida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqNotSalida.BackgroundImage")));
            this.btnBusqNotSalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqNotSalida.Location = new System.Drawing.Point(874, 21);
            this.btnBusqNotSalida.Name = "btnBusqNotSalida";
            this.btnBusqNotSalida.Size = new System.Drawing.Size(60, 50);
            this.btnBusqNotSalida.TabIndex = 68;
            this.btnBusqNotSalida.Text = "&Buscar";
            this.btnBusqNotSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqNotSalida.UseVisualStyleBackColor = true;
            this.btnBusqNotSalida.Click += new System.EventHandler(this.btnBusqNotSalida_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgItems);
            this.grbBase1.Location = new System.Drawing.Point(498, 189);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(437, 185);
            this.grbBase1.TabIndex = 76;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Items:";
            // 
            // dtgItems
            // 
            this.dtgItems.AllowUserToAddRows = false;
            this.dtgItems.AllowUserToDeleteRows = false;
            this.dtgItems.AllowUserToResizeColumns = false;
            this.dtgItems.AllowUserToResizeRows = false;
            this.dtgItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleNotaSalida,
            this.idUniMedida,
            this.cUnidMedida,
            this.objCatalogo,
            this.cProducto,
            this.nStock,
            this.nCantidadSol,
            this.nCantidadApro,
            this.lVigente});
            this.dtgItems.Location = new System.Drawing.Point(10, 19);
            this.dtgItems.MultiSelect = false;
            this.dtgItems.Name = "dtgItems";
            this.dtgItems.ReadOnly = true;
            this.dtgItems.RowHeadersVisible = false;
            this.dtgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgItems.Size = new System.Drawing.Size(417, 160);
            this.dtgItems.TabIndex = 9;
            this.dtgItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgItems_CellValidating);
            this.dtgItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItems_CellValueChanged);
            this.dtgItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgItems_DataBindingComplete);
            this.dtgItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgItems_EditingControlShowing);
            // 
            // idDetalleNotaSalida
            // 
            this.idDetalleNotaSalida.DataPropertyName = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.HeaderText = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.Name = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.ReadOnly = true;
            this.idDetalleNotaSalida.Visible = false;
            // 
            // idUniMedida
            // 
            this.idUniMedida.DataPropertyName = "idUniMedida";
            this.idUniMedida.HeaderText = "idUniMedida ";
            this.idUniMedida.Name = "idUniMedida";
            this.idUniMedida.ReadOnly = true;
            this.idUniMedida.Visible = false;
            // 
            // cUnidMedida
            // 
            this.cUnidMedida.DataPropertyName = "cUnidMedida";
            this.cUnidMedida.FillWeight = 45F;
            this.cUnidMedida.HeaderText = "Unidad";
            this.cUnidMedida.Name = "cUnidMedida";
            this.cUnidMedida.ReadOnly = true;
            // 
            // objCatalogo
            // 
            this.objCatalogo.DataPropertyName = "objCatalogo";
            this.objCatalogo.HeaderText = "objCatalogo ";
            this.objCatalogo.Name = "objCatalogo";
            this.objCatalogo.ReadOnly = true;
            this.objCatalogo.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.FillWeight = 200F;
            this.cProducto.HeaderText = "Producto ";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // nStock
            // 
            this.nStock.DataPropertyName = "nStock";
            this.nStock.FillWeight = 50F;
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            // 
            // nCantidadSol
            // 
            this.nCantidadSol.DataPropertyName = "nCantidadSol";
            this.nCantidadSol.FillWeight = 60F;
            this.nCantidadSol.HeaderText = "Cant. Solicitada";
            this.nCantidadSol.Name = "nCantidadSol";
            this.nCantidadSol.ReadOnly = true;
            // 
            // nCantidadApro
            // 
            this.nCantidadApro.DataPropertyName = "nCantidadApro";
            this.nCantidadApro.FillWeight = 60F;
            this.nCantidadApro.HeaderText = "Cant. Aprobada";
            this.nCantidadApro.Name = "nCantidadApro";
            this.nCantidadApro.ReadOnly = true;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar.BackgroundImage")));
            this.btnDenegar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar.Location = new System.Drawing.Point(787, 380);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar.TabIndex = 78;
            this.btnDenegar.Text = "&Denegar";
            this.btnDenegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Location = new System.Drawing.Point(725, 380);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 77;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.Enabled = false;
            this.txtAlmacen.Location = new System.Drawing.Point(778, 93);
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.ReadOnly = true;
            this.txtAlmacen.Size = new System.Drawing.Size(145, 20);
            this.txtAlmacen.TabIndex = 80;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(711, 96);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(61, 13);
            this.lblBase10.TabIndex = 79;
            this.lblBase10.Text = "Almacén:";
            // 
            // frmAprobNotaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 456);
            this.Controls.Add(this.txtAlmacen);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.btnDenegar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnBusqNotSalida);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.cboAgeNS);
            this.Controls.Add(this.txtActividad);
            this.Controls.Add(this.txtUsuReg);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.dtpFechaNS);
            this.Controls.Add(this.txtUsuAprob);
            this.Controls.Add(this.txtNumNS);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.dtgNotSalida);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAprobNotaSalida";
            this.Text = "Aprobación o Denegación de Requerimiento";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgNotSalida, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtNumNS, 0);
            this.Controls.SetChildIndex(this.txtUsuAprob, 0);
            this.Controls.SetChildIndex(this.dtpFechaNS, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtUsuReg, 0);
            this.Controls.SetChildIndex(this.txtActividad, 0);
            this.Controls.SetChildIndex(this.cboAgeNS, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.btnBusqNotSalida, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.btnDenegar, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtAlmacen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotSalida)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgNotSalida;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboAgencia cboAgeNS;
        private GEN.ControlesBase.txtBase txtActividad;
        private GEN.ControlesBase.txtBase txtUsuReg;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtpCorto dtpFechaNS;
        private GEN.ControlesBase.txtBase txtUsuAprob;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumNS;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnBusqueda btnBusqNotSalida;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgItems;
        private GEN.BotonesBase.btnDenegar btnDenegar;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleNotaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUniMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn objCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadApro;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
        private GEN.ControlesBase.txtBase txtAlmacen;
        private GEN.ControlesBase.lblBase lblBase10;
    }
}

