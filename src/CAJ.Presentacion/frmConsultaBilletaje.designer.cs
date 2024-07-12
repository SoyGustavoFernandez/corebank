namespace CAJ.Presentacion
{
    partial class frmConsultaBilletaje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaBilletaje));
            this.tbcCorte = new GEN.ControlesBase.tbcBase(this.components);
            this.tabSoles = new System.Windows.Forms.TabPage();
            this.dtgBilletes = new GEN.ControlesBase.dtgBase(this.components);
            this.idMonedaB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipBillMonB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcionB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMonTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMonBillete = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonMoneda = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgMonedas = new GEN.ControlesBase.dtgBase(this.components);
            this.idMonedaM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipBillMonSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcionSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDolares = new System.Windows.Forms.TabPage();
            this.dtgBillDolares = new GEN.ControlesBase.dtgBase(this.components);
            this.idMonedaDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipBillMonDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcionDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotDolar = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtBillDol = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.dtpProceso = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboTipResponsableCaja1 = new GEN.ControlesBase.cboTipResponsableCaja(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.tbcCorte.SuspendLayout();
            this.tabSoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBilletes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonedas)).BeginInit();
            this.tabDolares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBillDolares)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcCorte
            // 
            this.tbcCorte.Controls.Add(this.tabSoles);
            this.tbcCorte.Controls.Add(this.tabDolares);
            this.tbcCorte.Location = new System.Drawing.Point(3, 150);
            this.tbcCorte.Name = "tbcCorte";
            this.tbcCorte.SelectedIndex = 0;
            this.tbcCorte.Size = new System.Drawing.Size(571, 311);
            this.tbcCorte.TabIndex = 3;
            // 
            // tabSoles
            // 
            this.tabSoles.Controls.Add(this.dtgBilletes);
            this.tabSoles.Controls.Add(this.txtMonTotal);
            this.tabSoles.Controls.Add(this.lblBase5);
            this.tabSoles.Controls.Add(this.txtMonBillete);
            this.tabSoles.Controls.Add(this.lblBase4);
            this.tabSoles.Controls.Add(this.txtMonMoneda);
            this.tabSoles.Controls.Add(this.lblBase6);
            this.tabSoles.Controls.Add(this.dtgMonedas);
            this.tabSoles.Location = new System.Drawing.Point(4, 22);
            this.tabSoles.Name = "tabSoles";
            this.tabSoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabSoles.Size = new System.Drawing.Size(563, 285);
            this.tabSoles.TabIndex = 0;
            this.tabSoles.Text = "Billetaje en Soles (S/.)";
            this.tabSoles.UseVisualStyleBackColor = true;
            // 
            // dtgBilletes
            // 
            this.dtgBilletes.AllowUserToAddRows = false;
            this.dtgBilletes.AllowUserToDeleteRows = false;
            this.dtgBilletes.AllowUserToResizeColumns = false;
            this.dtgBilletes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBilletes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBilletes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBilletes.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgBilletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBilletes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMonedaB,
            this.idTipBillMonB,
            this.nValorB,
            this.cDescripcionB,
            this.nCantidadB,
            this.nTotalB});
            this.dtgBilletes.Enabled = false;
            this.dtgBilletes.Location = new System.Drawing.Point(5, 21);
            this.dtgBilletes.MultiSelect = false;
            this.dtgBilletes.Name = "dtgBilletes";
            this.dtgBilletes.ReadOnly = true;
            this.dtgBilletes.RowHeadersVisible = false;
            this.dtgBilletes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBilletes.Size = new System.Drawing.Size(273, 201);
            this.dtgBilletes.TabIndex = 0;
            // 
            // idMonedaB
            // 
            this.idMonedaB.DataPropertyName = "idMoneda";
            this.idMonedaB.HeaderText = "idMoneda";
            this.idMonedaB.Name = "idMonedaB";
            this.idMonedaB.ReadOnly = true;
            this.idMonedaB.Visible = false;
            // 
            // idTipBillMonB
            // 
            this.idTipBillMonB.DataPropertyName = "idTipBillMon";
            this.idTipBillMonB.HeaderText = "idTipBillMon";
            this.idTipBillMonB.Name = "idTipBillMonB";
            this.idTipBillMonB.ReadOnly = true;
            this.idTipBillMonB.Visible = false;
            // 
            // nValorB
            // 
            this.nValorB.DataPropertyName = "nValor";
            this.nValorB.HeaderText = "nValor";
            this.nValorB.Name = "nValorB";
            this.nValorB.ReadOnly = true;
            this.nValorB.Visible = false;
            // 
            // cDescripcionB
            // 
            this.cDescripcionB.DataPropertyName = "cDescripcion";
            this.cDescripcionB.FillWeight = 149.2386F;
            this.cDescripcionB.HeaderText = "Denominaciones";
            this.cDescripcionB.Name = "cDescripcionB";
            this.cDescripcionB.ReadOnly = true;
            // 
            // nCantidadB
            // 
            this.nCantidadB.DataPropertyName = "nCantidad";
            this.nCantidadB.FillWeight = 67.29522F;
            this.nCantidadB.HeaderText = "Cantidad";
            this.nCantidadB.Name = "nCantidadB";
            this.nCantidadB.ReadOnly = true;
            // 
            // nTotalB
            // 
            this.nTotalB.DataPropertyName = "nTotal";
            this.nTotalB.FillWeight = 83.46619F;
            this.nTotalB.HeaderText = "Total";
            this.nTotalB.Name = "nTotalB";
            this.nTotalB.ReadOnly = true;
            // 
            // txtMonTotal
            // 
            this.txtMonTotal.Enabled = false;
            this.txtMonTotal.FormatoDecimal = false;
            this.txtMonTotal.Location = new System.Drawing.Point(154, 255);
            this.txtMonTotal.Name = "txtMonTotal";
            this.txtMonTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonTotal.nNumDecimales = 4;
            this.txtMonTotal.nvalor = 0D;
            this.txtMonTotal.Size = new System.Drawing.Size(124, 20);
            this.txtMonTotal.TabIndex = 27;
            this.txtMonTotal.Text = "0.00";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(2, 258);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(143, 13);
            this.lblBase5.TabIndex = 26;
            this.lblBase5.Text = "TOTAL BILLETAJE (S/.):";
            // 
            // txtMonBillete
            // 
            this.txtMonBillete.Enabled = false;
            this.txtMonBillete.FormatoDecimal = false;
            this.txtMonBillete.Location = new System.Drawing.Point(154, 223);
            this.txtMonBillete.Name = "txtMonBillete";
            this.txtMonBillete.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonBillete.nNumDecimales = 4;
            this.txtMonBillete.nvalor = 0D;
            this.txtMonBillete.Size = new System.Drawing.Size(124, 20);
            this.txtMonBillete.TabIndex = 25;
            this.txtMonBillete.Text = "0.00";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(318, 226);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(111, 13);
            this.lblBase4.TabIndex = 24;
            this.lblBase4.Text = "TOTAL MONEDAS:";
            // 
            // txtMonMoneda
            // 
            this.txtMonMoneda.Enabled = false;
            this.txtMonMoneda.FormatoDecimal = false;
            this.txtMonMoneda.Location = new System.Drawing.Point(434, 223);
            this.txtMonMoneda.Name = "txtMonMoneda";
            this.txtMonMoneda.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonMoneda.nNumDecimales = 4;
            this.txtMonMoneda.nvalor = 0D;
            this.txtMonMoneda.Size = new System.Drawing.Size(124, 20);
            this.txtMonMoneda.TabIndex = 23;
            this.txtMonMoneda.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(41, 226);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(107, 13);
            this.lblBase6.TabIndex = 22;
            this.lblBase6.Text = "TOTAL BILLETES:";
            // 
            // dtgMonedas
            // 
            this.dtgMonedas.AllowUserToAddRows = false;
            this.dtgMonedas.AllowUserToDeleteRows = false;
            this.dtgMonedas.AllowUserToResizeColumns = false;
            this.dtgMonedas.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMonedas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMonedas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMonedas.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgMonedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMonedas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMonedaM,
            this.idTipBillMonSI,
            this.nValorSI,
            this.cDescripcionSI,
            this.nCantidadSI,
            this.nTotalSI});
            this.dtgMonedas.Enabled = false;
            this.dtgMonedas.Location = new System.Drawing.Point(285, 21);
            this.dtgMonedas.MultiSelect = false;
            this.dtgMonedas.Name = "dtgMonedas";
            this.dtgMonedas.ReadOnly = true;
            this.dtgMonedas.RowHeadersVisible = false;
            this.dtgMonedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMonedas.Size = new System.Drawing.Size(273, 201);
            this.dtgMonedas.TabIndex = 1;
            // 
            // idMonedaM
            // 
            this.idMonedaM.DataPropertyName = "idMoneda";
            this.idMonedaM.HeaderText = "idMoneda";
            this.idMonedaM.Name = "idMonedaM";
            this.idMonedaM.ReadOnly = true;
            this.idMonedaM.Visible = false;
            // 
            // idTipBillMonSI
            // 
            this.idTipBillMonSI.DataPropertyName = "idTipBillMon";
            this.idTipBillMonSI.HeaderText = "idTipBillMon";
            this.idTipBillMonSI.Name = "idTipBillMonSI";
            this.idTipBillMonSI.ReadOnly = true;
            this.idTipBillMonSI.Visible = false;
            // 
            // nValorSI
            // 
            this.nValorSI.DataPropertyName = "nValor";
            this.nValorSI.HeaderText = "nValor";
            this.nValorSI.Name = "nValorSI";
            this.nValorSI.ReadOnly = true;
            this.nValorSI.Visible = false;
            // 
            // cDescripcionSI
            // 
            this.cDescripcionSI.DataPropertyName = "cDescripcion";
            this.cDescripcionSI.FillWeight = 149.2386F;
            this.cDescripcionSI.HeaderText = "Denominaciones";
            this.cDescripcionSI.Name = "cDescripcionSI";
            this.cDescripcionSI.ReadOnly = true;
            // 
            // nCantidadSI
            // 
            this.nCantidadSI.DataPropertyName = "nCantidad";
            this.nCantidadSI.FillWeight = 67.29522F;
            this.nCantidadSI.HeaderText = "Cantidad";
            this.nCantidadSI.Name = "nCantidadSI";
            this.nCantidadSI.ReadOnly = true;
            // 
            // nTotalSI
            // 
            this.nTotalSI.DataPropertyName = "nTotal";
            this.nTotalSI.FillWeight = 83.46619F;
            this.nTotalSI.HeaderText = "Total";
            this.nTotalSI.Name = "nTotalSI";
            this.nTotalSI.ReadOnly = true;
            // 
            // tabDolares
            // 
            this.tabDolares.Controls.Add(this.dtgBillDolares);
            this.tabDolares.Controls.Add(this.txtTotDolar);
            this.tabDolares.Controls.Add(this.lblBase7);
            this.tabDolares.Controls.Add(this.txtBillDol);
            this.tabDolares.Controls.Add(this.lblBase8);
            this.tabDolares.Location = new System.Drawing.Point(4, 22);
            this.tabDolares.Name = "tabDolares";
            this.tabDolares.Padding = new System.Windows.Forms.Padding(3);
            this.tabDolares.Size = new System.Drawing.Size(563, 285);
            this.tabDolares.TabIndex = 1;
            this.tabDolares.Text = "Billetaje en Dólares ($)";
            this.tabDolares.UseVisualStyleBackColor = true;
            // 
            // dtgBillDolares
            // 
            this.dtgBillDolares.AllowUserToAddRows = false;
            this.dtgBillDolares.AllowUserToDeleteRows = false;
            this.dtgBillDolares.AllowUserToResizeColumns = false;
            this.dtgBillDolares.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBillDolares.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgBillDolares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBillDolares.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgBillDolares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBillDolares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMonedaDB,
            this.idTipBillMonDB,
            this.nValorDB,
            this.cDescripcionDB,
            this.nCantidadDB,
            this.nTotalDB});
            this.dtgBillDolares.Enabled = false;
            this.dtgBillDolares.Location = new System.Drawing.Point(97, 13);
            this.dtgBillDolares.MultiSelect = false;
            this.dtgBillDolares.Name = "dtgBillDolares";
            this.dtgBillDolares.ReadOnly = true;
            this.dtgBillDolares.RowHeadersVisible = false;
            this.dtgBillDolares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBillDolares.Size = new System.Drawing.Size(317, 201);
            this.dtgBillDolares.TabIndex = 33;
            // 
            // idMonedaDB
            // 
            this.idMonedaDB.DataPropertyName = "idMoneda";
            this.idMonedaDB.HeaderText = "idMoneda";
            this.idMonedaDB.Name = "idMonedaDB";
            this.idMonedaDB.ReadOnly = true;
            this.idMonedaDB.Visible = false;
            // 
            // idTipBillMonDB
            // 
            this.idTipBillMonDB.DataPropertyName = "idTipBillMon";
            this.idTipBillMonDB.HeaderText = "idTipBillMon";
            this.idTipBillMonDB.Name = "idTipBillMonDB";
            this.idTipBillMonDB.ReadOnly = true;
            this.idTipBillMonDB.Visible = false;
            // 
            // nValorDB
            // 
            this.nValorDB.DataPropertyName = "nValor";
            this.nValorDB.HeaderText = "nValor";
            this.nValorDB.Name = "nValorDB";
            this.nValorDB.ReadOnly = true;
            this.nValorDB.Visible = false;
            // 
            // cDescripcionDB
            // 
            this.cDescripcionDB.DataPropertyName = "cDescripcion";
            this.cDescripcionDB.FillWeight = 149.2386F;
            this.cDescripcionDB.HeaderText = "Denominaciones";
            this.cDescripcionDB.Name = "cDescripcionDB";
            this.cDescripcionDB.ReadOnly = true;
            // 
            // nCantidadDB
            // 
            this.nCantidadDB.DataPropertyName = "nCantidad";
            this.nCantidadDB.FillWeight = 67.29522F;
            this.nCantidadDB.HeaderText = "Cantidad";
            this.nCantidadDB.Name = "nCantidadDB";
            this.nCantidadDB.ReadOnly = true;
            // 
            // nTotalDB
            // 
            this.nTotalDB.DataPropertyName = "nTotal";
            this.nTotalDB.FillWeight = 83.46619F;
            this.nTotalDB.HeaderText = "Total";
            this.nTotalDB.Name = "nTotalDB";
            this.nTotalDB.ReadOnly = true;
            // 
            // txtTotDolar
            // 
            this.txtTotDolar.Enabled = false;
            this.txtTotDolar.FormatoDecimal = false;
            this.txtTotDolar.Location = new System.Drawing.Point(301, 251);
            this.txtTotDolar.Name = "txtTotDolar";
            this.txtTotDolar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotDolar.nNumDecimales = 4;
            this.txtTotDolar.nvalor = 0D;
            this.txtTotDolar.Size = new System.Drawing.Size(113, 20);
            this.txtTotDolar.TabIndex = 32;
            this.txtTotDolar.Text = "0.00";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(162, 254);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(133, 13);
            this.lblBase7.TabIndex = 31;
            this.lblBase7.Text = "TOTAL BILLETAJE ($):";
            // 
            // txtBillDol
            // 
            this.txtBillDol.Enabled = false;
            this.txtBillDol.FormatoDecimal = false;
            this.txtBillDol.Location = new System.Drawing.Point(306, 215);
            this.txtBillDol.Name = "txtBillDol";
            this.txtBillDol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtBillDol.nNumDecimales = 4;
            this.txtBillDol.nvalor = 0D;
            this.txtBillDol.Size = new System.Drawing.Size(108, 20);
            this.txtBillDol.TabIndex = 30;
            this.txtBillDol.Text = "0.00";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(169, 218);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(107, 13);
            this.lblBase8.TabIndex = 29;
            this.lblBase8.Text = "TOTAL BILLETES:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(513, 463);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(101, 39);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(394, 20);
            this.txtNomUsu.TabIndex = 72;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 42);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 71;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(260, 15);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(63, 20);
            this.txtCodUsu.TabIndex = 70;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(213, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 69;
            this.lblBase2.Text = "Código:";
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Enabled = false;
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(101, 15);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaSis.TabIndex = 67;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 68;
            this.lblBase3.Text = "Fecha:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtUsuario);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.txtNomUsu);
            this.grbBase3.Controls.Add(this.txtCodUsu);
            this.grbBase3.Controls.Add(this.dtpFechaSis);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Location = new System.Drawing.Point(5, -2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(565, 62);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(387, 15);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(108, 20);
            this.txtUsuario.TabIndex = 50;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(330, 18);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(55, 13);
            this.lblBase10.TabIndex = 49;
            this.lblBase10.Text = "Usuario:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(498, 37);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 2;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(451, 463);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dtpProceso
            // 
            this.dtpProceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpProceso.Location = new System.Drawing.Point(101, 38);
            this.dtpProceso.Name = "dtpProceso";
            this.dtpProceso.Size = new System.Drawing.Size(100, 20);
            this.dtpProceso.TabIndex = 2;
            this.dtpProceso.ValueChanged += new System.EventHandler(this.dtpProceso_ValueChanged);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(12, 42);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(45, 13);
            this.lblBase9.TabIndex = 79;
            this.lblBase9.Text = "Fecha:";
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(98, 63);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(394, 21);
            this.cboColaborador.TabIndex = 1;
            this.cboColaborador.SelectedIndexChanged += new System.EventHandler(this.cboColaborador_SelectedIndexChanged);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(12, 66);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(83, 13);
            this.lblBase11.TabIndex = 100;
            this.lblBase11.Text = "Colaborador:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase12);
            this.grbBase1.Controls.Add(this.btnProcesar);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.dtpProceso);
            this.grbBase1.Controls.Add(this.cboTipResponsableCaja1);
            this.grbBase1.Controls.Add(this.lblBase23);
            this.grbBase1.Controls.Add(this.cboColaborador);
            this.grbBase1.Controls.Add(this.lblBase11);
            this.grbBase1.Location = new System.Drawing.Point(5, 55);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(564, 89);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Enter += new System.EventHandler(this.grbBase1_Enter);
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(12, 16);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(57, 13);
            this.lblBase12.TabIndex = 110;
            this.lblBase12.Text = "Agencia:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(101, 11);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(391, 21);
            this.cboAgencias.TabIndex = 29;
            this.cboAgencias.SelectionChangeCommitted += new System.EventHandler(this.cboAgencias1_SelectionChangeCommitted);
            // 
            // cboTipResponsableCaja1
            // 
            this.cboTipResponsableCaja1.FormattingEnabled = true;
            this.cboTipResponsableCaja1.Location = new System.Drawing.Point(323, 37);
            this.cboTipResponsableCaja1.Name = "cboTipResponsableCaja1";
            this.cboTipResponsableCaja1.Size = new System.Drawing.Size(169, 21);
            this.cboTipResponsableCaja1.TabIndex = 0;
            this.cboTipResponsableCaja1.SelectedIndexChanged += new System.EventHandler(this.cboTipResponsableCaja1_SelectedIndexChanged);
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(208, 42);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(112, 13);
            this.lblBase23.TabIndex = 109;
            this.lblBase23.Text = "Tipo Responsable:";
            // 
            // frmConsultaBilletaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 536);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tbcCorte);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmConsultaBilletaje";
            this.Text = "Consulta billetaje";
            this.Load += new System.EventHandler(this.frmCorteFraccionario_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.tbcCorte, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.tbcCorte.ResumeLayout(false);
            this.tabSoles.ResumeLayout(false);
            this.tabSoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBilletes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonedas)).EndInit();
            this.tabDolares.ResumeLayout(false);
            this.tabDolares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBillDolares)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcCorte;
        private System.Windows.Forms.TabPage tabSoles;
        private System.Windows.Forms.TabPage tabDolares;
        private GEN.ControlesBase.dtgBase dtgMonedas;
        private GEN.ControlesBase.txtNumRea txtMonTotal;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMonBillete;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMonMoneda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtTotDolar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtBillDol;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase2;
        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        public GEN.ControlesBase.dtpCorto dtpProceso;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgBilletes;
        private GEN.ControlesBase.dtgBase dtgBillDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipBillMonB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorB;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcionB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaM;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipBillMonSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcionSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipBillMonDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcionDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalDB;
        private GEN.ControlesBase.cboTipResponsableCaja cboTipResponsableCaja1;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase12;
    }
}