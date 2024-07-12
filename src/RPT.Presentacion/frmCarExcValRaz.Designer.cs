namespace RPT.Presentacion
{
    partial class frmCarExcValRaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarExcValRaz));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.txtArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgDatoExl = new GEN.ControlesBase.dtgBase(this.components);
            this.Nemonico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISINIdentif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorPLimpio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spreads = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLimpio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PSucio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEmisión = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MargenLibor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIRSOpc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProxCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarPLimpio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarPSucio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarTir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImportar1 = new GEN.BotonesBase.btnImportar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtXlsTeso = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnExporExcel2 = new GEN.BotonesBase.btnExporExcel();
            this.dtgDatoExlTes = new GEN.ControlesBase.dtgBase(this.components);
            this.CodValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALORCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTERES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTOAMORTIZADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAINICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAFINAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCalculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interesCalculado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoExl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoExlTes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackColor = System.Drawing.SystemColors.Control;
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(654, 12);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 1;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = false;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Enabled = false;
            this.txtArchivo.Location = new System.Drawing.Point(128, 40);
            this.txtArchivo.Multiline = true;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(520, 22);
            this.txtArchivo.TabIndex = 26;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 45);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(115, 13);
            this.lblBase2.TabIndex = 27;
            this.lblBase2.Text = "Archivo renta fija :";
            // 
            // dtgDatoExl
            // 
            this.dtgDatoExl.AllowUserToAddRows = false;
            this.dtgDatoExl.AllowUserToDeleteRows = false;
            this.dtgDatoExl.AllowUserToResizeColumns = false;
            this.dtgDatoExl.AllowUserToResizeRows = false;
            this.dtgDatoExl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDatoExl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDatoExl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatoExl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nemonico,
            this.ISINIdentif,
            this.Emisor,
            this.Moneda,
            this.PorPLimpio,
            this.TIR,
            this.Origen,
            this.Spreads,
            this.PLimpio,
            this.PSucio,
            this.IC,
            this.FEmisión,
            this.FVencimiento,
            this.Cupon,
            this.MargenLibor,
            this.TIRSOpc,
            this.RatingEmision,
            this.UltCupon,
            this.ProxCupon,
            this.Duracion,
            this.VarPLimpio,
            this.VarPSucio,
            this.VarTir});
            this.dtgDatoExl.Location = new System.Drawing.Point(12, 66);
            this.dtgDatoExl.MultiSelect = false;
            this.dtgDatoExl.Name = "dtgDatoExl";
            this.dtgDatoExl.ReadOnly = true;
            this.dtgDatoExl.RowHeadersVisible = false;
            this.dtgDatoExl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatoExl.Size = new System.Drawing.Size(702, 149);
            this.dtgDatoExl.TabIndex = 28;
            // 
            // Nemonico
            // 
            this.Nemonico.DataPropertyName = "Nemonico";
            this.Nemonico.HeaderText = "Nemónico";
            this.Nemonico.Name = "Nemonico";
            this.Nemonico.ReadOnly = true;
            this.Nemonico.Width = 80;
            // 
            // ISINIdentif
            // 
            this.ISINIdentif.DataPropertyName = "ISINIdentif";
            this.ISINIdentif.HeaderText = "ISIN/Identif.";
            this.ISINIdentif.Name = "ISINIdentif";
            this.ISINIdentif.ReadOnly = true;
            this.ISINIdentif.Width = 90;
            // 
            // Emisor
            // 
            this.Emisor.DataPropertyName = "Emisor";
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            this.Emisor.ReadOnly = true;
            this.Emisor.Width = 63;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Width = 71;
            // 
            // PorPLimpio
            // 
            this.PorPLimpio.DataPropertyName = "PorPLimpio";
            this.PorPLimpio.HeaderText = "P. Limpio (%)";
            this.PorPLimpio.Name = "PorPLimpio";
            this.PorPLimpio.ReadOnly = true;
            this.PorPLimpio.Width = 85;
            // 
            // TIR
            // 
            this.TIR.DataPropertyName = "TIR";
            this.TIR.HeaderText = "TIR %";
            this.TIR.Name = "TIR";
            this.TIR.ReadOnly = true;
            this.TIR.Width = 50;
            // 
            // Origen
            // 
            this.Origen.DataPropertyName = "Origen";
            this.Origen.HeaderText = "Origen(*)";
            this.Origen.Name = "Origen";
            this.Origen.ReadOnly = true;
            this.Origen.Width = 73;
            // 
            // Spreads
            // 
            this.Spreads.DataPropertyName = "Spreads";
            this.Spreads.HeaderText = "Spreads";
            this.Spreads.Name = "Spreads";
            this.Spreads.ReadOnly = true;
            this.Spreads.Width = 71;
            // 
            // PLimpio
            // 
            this.PLimpio.DataPropertyName = "PLimpio";
            this.PLimpio.HeaderText = "P. Limpio (Monto)";
            this.PLimpio.Name = "PLimpio";
            this.PLimpio.ReadOnly = true;
            this.PLimpio.Width = 105;
            // 
            // PSucio
            // 
            this.PSucio.DataPropertyName = "PSucio";
            this.PSucio.HeaderText = "P. Sucio (monto)";
            this.PSucio.Name = "PSucio";
            this.PSucio.ReadOnly = true;
            this.PSucio.Width = 101;
            // 
            // IC
            // 
            this.IC.DataPropertyName = "IC";
            this.IC.HeaderText = "I.C.(monto)";
            this.IC.Name = "IC";
            this.IC.ReadOnly = true;
            this.IC.Width = 83;
            // 
            // FEmisión
            // 
            this.FEmisión.DataPropertyName = "FEmisión";
            this.FEmisión.HeaderText = "F. Emisión";
            this.FEmisión.Name = "FEmisión";
            this.FEmisión.ReadOnly = true;
            this.FEmisión.Width = 74;
            // 
            // FVencimiento
            // 
            this.FVencimiento.DataPropertyName = "FVencimiento";
            this.FVencimiento.HeaderText = "F. Vencimiento";
            this.FVencimiento.Name = "FVencimiento";
            this.FVencimiento.ReadOnly = true;
            this.FVencimiento.Width = 94;
            // 
            // Cupon
            // 
            this.Cupon.DataPropertyName = "Cupon";
            this.Cupon.HeaderText = "Cupón (%)";
            this.Cupon.Name = "Cupon";
            this.Cupon.ReadOnly = true;
            this.Cupon.Width = 74;
            // 
            // MargenLibor
            // 
            this.MargenLibor.DataPropertyName = "MargenLibor";
            this.MargenLibor.HeaderText = "Margen Libor (%)";
            this.MargenLibor.Name = "MargenLibor";
            this.MargenLibor.ReadOnly = true;
            this.MargenLibor.Width = 89;
            // 
            // TIRSOpc
            // 
            this.TIRSOpc.DataPropertyName = "TIRSOpc";
            this.TIRSOpc.HeaderText = "TIR % S/Opc";
            this.TIRSOpc.Name = "TIRSOpc";
            this.TIRSOpc.ReadOnly = true;
            this.TIRSOpc.Width = 88;
            // 
            // RatingEmision
            // 
            this.RatingEmision.DataPropertyName = "RatingEmision";
            this.RatingEmision.HeaderText = "Rating Emisión";
            this.RatingEmision.Name = "RatingEmision";
            this.RatingEmision.ReadOnly = true;
            this.RatingEmision.Width = 94;
            // 
            // UltCupon
            // 
            this.UltCupon.DataPropertyName = "UltCupon";
            this.UltCupon.HeaderText = "Ult. Cupón";
            this.UltCupon.Name = "UltCupon";
            this.UltCupon.ReadOnly = true;
            this.UltCupon.Width = 76;
            // 
            // ProxCupon
            // 
            this.ProxCupon.DataPropertyName = "ProxCupon";
            this.ProxCupon.HeaderText = "Prox. Cupón";
            this.ProxCupon.Name = "ProxCupon";
            this.ProxCupon.ReadOnly = true;
            this.ProxCupon.Width = 83;
            // 
            // Duracion
            // 
            this.Duracion.DataPropertyName = "Duracion";
            this.Duracion.HeaderText = "Duración";
            this.Duracion.Name = "Duracion";
            this.Duracion.ReadOnly = true;
            this.Duracion.Width = 75;
            // 
            // VarPLimpio
            // 
            this.VarPLimpio.DataPropertyName = "VarPLimpio";
            this.VarPLimpio.HeaderText = "Var PLimpio";
            this.VarPLimpio.Name = "VarPLimpio";
            this.VarPLimpio.ReadOnly = true;
            this.VarPLimpio.Width = 81;
            // 
            // VarPSucio
            // 
            this.VarPSucio.DataPropertyName = "VarPSucio";
            this.VarPSucio.HeaderText = "Var PSucio";
            this.VarPSucio.Name = "VarPSucio";
            this.VarPSucio.ReadOnly = true;
            this.VarPSucio.Width = 78;
            // 
            // VarTir
            // 
            this.VarTir.DataPropertyName = "VarTir";
            this.VarTir.HeaderText = "Var Tir";
            this.VarTir.Name = "VarTir";
            this.VarTir.ReadOnly = true;
            this.VarTir.Width = 48;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(654, 443);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // btnImportar1
            // 
            this.btnImportar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar1.BackgroundImage")));
            this.btnImportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar1.Location = new System.Drawing.Point(588, 443);
            this.btnImportar1.Name = "btnImportar1";
            this.btnImportar1.Size = new System.Drawing.Size(60, 50);
            this.btnImportar1.TabIndex = 2;
            this.btnImportar1.Text = "&Importar";
            this.btnImportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar1.UseVisualStyleBackColor = false;
            this.btnImportar1.Click += new System.EventHandler(this.btnImportar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 31;
            this.lblBase1.Text = "Fecha Proceso:";
            // 
            // dtpFecProceso
            // 
            this.dtpFecProceso.Location = new System.Drawing.Point(128, 15);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(114, 20);
            this.dtpFecProceso.TabIndex = 0;
            // 
            // txtXlsTeso
            // 
            this.txtXlsTeso.Enabled = false;
            this.txtXlsTeso.Location = new System.Drawing.Point(128, 249);
            this.txtXlsTeso.Multiline = true;
            this.txtXlsTeso.Name = "txtXlsTeso";
            this.txtXlsTeso.Size = new System.Drawing.Size(520, 22);
            this.txtXlsTeso.TabIndex = 33;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 254);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(110, 13);
            this.lblBase3.TabIndex = 34;
            this.lblBase3.Text = "Archivo tesorería:";
            // 
            // btnExporExcel2
            // 
            this.btnExporExcel2.BackColor = System.Drawing.SystemColors.Control;
            this.btnExporExcel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel2.BackgroundImage")));
            this.btnExporExcel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel2.Location = new System.Drawing.Point(654, 221);
            this.btnExporExcel2.Name = "btnExporExcel2";
            this.btnExporExcel2.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel2.TabIndex = 32;
            this.btnExporExcel2.Text = "E&xcel";
            this.btnExporExcel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel2.UseVisualStyleBackColor = false;
            this.btnExporExcel2.Click += new System.EventHandler(this.btnExporExcel2_Click);
            // 
            // dtgDatoExlTes
            // 
            this.dtgDatoExlTes.AllowUserToAddRows = false;
            this.dtgDatoExlTes.AllowUserToDeleteRows = false;
            this.dtgDatoExlTes.AllowUserToResizeColumns = false;
            this.dtgDatoExlTes.AllowUserToResizeRows = false;
            this.dtgDatoExlTes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDatoExlTes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDatoExlTes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatoExlTes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodValor,
            this.Clasificacion,
            this.Tasa,
            this.PRECIO,
            this.PrecioPor,
            this.VALORCD,
            this.ValorActual,
            this.INTERES,
            this.COSTOAMORTIZADO,
            this.FECHAINICIO,
            this.FECHAFINAL,
            this.FechaCalculo,
            this.interesCalculado});
            this.dtgDatoExlTes.Location = new System.Drawing.Point(12, 277);
            this.dtgDatoExlTes.MultiSelect = false;
            this.dtgDatoExlTes.Name = "dtgDatoExlTes";
            this.dtgDatoExlTes.ReadOnly = true;
            this.dtgDatoExlTes.RowHeadersVisible = false;
            this.dtgDatoExlTes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatoExlTes.Size = new System.Drawing.Size(702, 160);
            this.dtgDatoExlTes.TabIndex = 35;
            // 
            // CodValor
            // 
            this.CodValor.DataPropertyName = "CodValor";
            this.CodValor.HeaderText = "CodValor";
            this.CodValor.Name = "CodValor";
            this.CodValor.ReadOnly = true;
            this.CodValor.Width = 75;
            // 
            // Clasificacion
            // 
            this.Clasificacion.DataPropertyName = "Clasificacion";
            this.Clasificacion.HeaderText = "Clasificacion";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.ReadOnly = true;
            this.Clasificacion.Width = 91;
            // 
            // Tasa
            // 
            this.Tasa.DataPropertyName = "Tasa";
            this.Tasa.HeaderText = "Tasa";
            this.Tasa.Name = "Tasa";
            this.Tasa.ReadOnly = true;
            this.Tasa.Width = 56;
            // 
            // PRECIO
            // 
            this.PRECIO.DataPropertyName = "PRECIO";
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.ReadOnly = true;
            this.PRECIO.Width = 72;
            // 
            // PrecioPor
            // 
            this.PrecioPor.DataPropertyName = "PrecioPor";
            this.PrecioPor.HeaderText = "PrecioPor";
            this.PrecioPor.Name = "PrecioPor";
            this.PrecioPor.ReadOnly = true;
            this.PrecioPor.Width = 78;
            // 
            // VALORCD
            // 
            this.VALORCD.DataPropertyName = "VALORCD";
            this.VALORCD.HeaderText = "VALORCD";
            this.VALORCD.Name = "VALORCD";
            this.VALORCD.ReadOnly = true;
            this.VALORCD.Width = 83;
            // 
            // ValorActual
            // 
            this.ValorActual.DataPropertyName = "ValorActual";
            this.ValorActual.HeaderText = "ValorActual";
            this.ValorActual.Name = "ValorActual";
            this.ValorActual.ReadOnly = true;
            this.ValorActual.Width = 86;
            // 
            // INTERES
            // 
            this.INTERES.DataPropertyName = "INTERES";
            this.INTERES.HeaderText = "INTERES";
            this.INTERES.Name = "INTERES";
            this.INTERES.ReadOnly = true;
            this.INTERES.Width = 79;
            // 
            // COSTOAMORTIZADO
            // 
            this.COSTOAMORTIZADO.DataPropertyName = "COSTOAMORTIZADO";
            this.COSTOAMORTIZADO.HeaderText = "COSTOAMORTIZADO";
            this.COSTOAMORTIZADO.Name = "COSTOAMORTIZADO";
            this.COSTOAMORTIZADO.ReadOnly = true;
            this.COSTOAMORTIZADO.Width = 141;
            // 
            // FECHAINICIO
            // 
            this.FECHAINICIO.DataPropertyName = "FECHAINICIO";
            this.FECHAINICIO.HeaderText = "FECHAINICIO";
            this.FECHAINICIO.Name = "FECHAINICIO";
            this.FECHAINICIO.ReadOnly = true;
            this.FECHAINICIO.Width = 99;
            // 
            // FECHAFINAL
            // 
            this.FECHAFINAL.DataPropertyName = "FECHAFINAL";
            this.FECHAFINAL.HeaderText = "FECHAFINAL";
            this.FECHAFINAL.Name = "FECHAFINAL";
            this.FECHAFINAL.ReadOnly = true;
            this.FECHAFINAL.Width = 97;
            // 
            // FechaCalculo
            // 
            this.FechaCalculo.DataPropertyName = "FechaCalculo";
            this.FechaCalculo.HeaderText = "FechaCalculo";
            this.FechaCalculo.Name = "FechaCalculo";
            this.FechaCalculo.ReadOnly = true;
            this.FechaCalculo.Width = 97;
            // 
            // interesCalculado
            // 
            this.interesCalculado.DataPropertyName = "interesCalculado";
            this.interesCalculado.HeaderText = "interesCalculado";
            this.interesCalculado.Name = "interesCalculado";
            this.interesCalculado.ReadOnly = true;
            this.interesCalculado.Width = 110;
            // 
            // frmCarExcValRaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 521);
            this.Controls.Add(this.dtgDatoExlTes);
            this.Controls.Add(this.txtXlsTeso);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnExporExcel2);
            this.Controls.Add(this.dtpFecProceso);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnImportar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgDatoExl);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnExporExcel1);
            this.Name = "frmCarExcValRaz";
            this.Text = "Exporta datos inversiones valor razonable";
            this.Load += new System.EventHandler(this.frmCargaExcel_Load);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtArchivo, 0);
            this.Controls.SetChildIndex(this.dtgDatoExl, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImportar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFecProceso, 0);
            this.Controls.SetChildIndex(this.btnExporExcel2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtXlsTeso, 0);
            this.Controls.SetChildIndex(this.dtgDatoExlTes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoExl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatoExlTes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.ControlesBase.txtBase txtArchivo;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgDatoExl;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImportar btnImportar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nemonico;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISINIdentif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorPLimpio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spreads;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLimpio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSucio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEmisión;
        private System.Windows.Forms.DataGridViewTextBoxColumn FVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MargenLibor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIRSOpc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltCupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProxCupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarPLimpio;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarPSucio;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarTir;
        private GEN.ControlesBase.txtBase txtXlsTeso;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnExporExcel btnExporExcel2;
        private GEN.ControlesBase.dtgBase dtgDatoExlTes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALORCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTERES;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTOAMORTIZADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAINICIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAFINAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn interesCalculado;
    }
}