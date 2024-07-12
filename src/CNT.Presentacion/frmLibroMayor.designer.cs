namespace CNT.Presentacion
{
    partial class frmLibroMayor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroMayor));
            this.txtCtaCtbFin = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbFiltros = new GEN.ControlesBase.grbBase(this.components);
            this.grbCtaContable = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCtaCtbIni = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.dtgLibroMayor = new GEN.ControlesBase.dtgBase(this.components);
            this.txtSubHaber = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSubDebe = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExportar = new GEN.BotonesBase.btnExportar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.chcActExpot = new GEN.ControlesBase.chcBase(this.components);
            this.grbFiltros.SuspendLayout();
            this.grbCtaContable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLibroMayor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCtaCtbFin
            // 
            this.txtCtaCtbFin.FormatoDecimal = false;
            this.txtCtaCtbFin.Location = new System.Drawing.Point(77, 45);
            this.txtCtaCtbFin.Name = "txtCtaCtbFin";
            this.txtCtaCtbFin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCtaCtbFin.nNumDecimales = 4;
            this.txtCtaCtbFin.nvalor = 0D;
            this.txtCtaCtbFin.Size = new System.Drawing.Size(139, 20);
            this.txtCtaCtbFin.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtCtaCtbFin, "Presione Enter para consultar");
            this.txtCtaCtbFin.TextChanged += new System.EventHandler(this.txtCtaCtbFin_TextChanged);
            this.txtCtaCtbFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaCtb_KeyPress);
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(95, 17);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(121, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(95, 44);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 47);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(44, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Hasta:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 74);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Moneda:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Fecha Inicial:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 47);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(75, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Fecha Final:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(600, 335);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(724, 335);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.grbCtaContable);
            this.grbFiltros.Controls.Add(this.cboMoneda);
            this.grbFiltros.Controls.Add(this.lblBase4);
            this.grbFiltros.Controls.Add(this.dtpFecIni);
            this.grbFiltros.Controls.Add(this.lblBase3);
            this.grbFiltros.Controls.Add(this.dtpFecFin);
            this.grbFiltros.Controls.Add(this.lblBase2);
            this.grbFiltros.Location = new System.Drawing.Point(137, 3);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(473, 101);
            this.grbFiltros.TabIndex = 0;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Datos de la Cuenta Contable";
            // 
            // grbCtaContable
            // 
            this.grbCtaContable.Controls.Add(this.txtCtaCtbFin);
            this.grbCtaContable.Controls.Add(this.lblBase6);
            this.grbCtaContable.Controls.Add(this.lblBase1);
            this.grbCtaContable.Controls.Add(this.txtCtaCtbIni);
            this.grbCtaContable.Location = new System.Drawing.Point(227, 21);
            this.grbCtaContable.Name = "grbCtaContable";
            this.grbCtaContable.Size = new System.Drawing.Size(228, 71);
            this.grbCtaContable.TabIndex = 3;
            this.grbCtaContable.TabStop = false;
            this.grbCtaContable.Text = "Cuenta Contable:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(19, 19);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(48, 13);
            this.lblBase6.TabIndex = 11;
            this.lblBase6.Text = "Desde:";
            // 
            // txtCtaCtbIni
            // 
            this.txtCtaCtbIni.FormatoDecimal = false;
            this.txtCtaCtbIni.Location = new System.Drawing.Point(77, 17);
            this.txtCtaCtbIni.Name = "txtCtaCtbIni";
            this.txtCtaCtbIni.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCtaCtbIni.nNumDecimales = 4;
            this.txtCtaCtbIni.nvalor = 0D;
            this.txtCtaCtbIni.Size = new System.Drawing.Size(139, 20);
            this.txtCtaCtbIni.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtCtaCtbIni, "Presione Enter para consultar");
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(95, 71);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 2;
            // 
            // dtgLibroMayor
            // 
            this.dtgLibroMayor.AllowUserToAddRows = false;
            this.dtgLibroMayor.AllowUserToDeleteRows = false;
            this.dtgLibroMayor.AllowUserToResizeColumns = false;
            this.dtgLibroMayor.AllowUserToResizeRows = false;
            this.dtgLibroMayor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLibroMayor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLibroMayor.Location = new System.Drawing.Point(15, 110);
            this.dtgLibroMayor.MultiSelect = false;
            this.dtgLibroMayor.Name = "dtgLibroMayor";
            this.dtgLibroMayor.ReadOnly = true;
            this.dtgLibroMayor.RowHeadersVisible = false;
            this.dtgLibroMayor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLibroMayor.Size = new System.Drawing.Size(769, 197);
            this.dtgLibroMayor.TabIndex = 3;
            this.dtgLibroMayor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLibroMayor_CellDoubleClick);
            // 
            // txtSubHaber
            // 
            this.txtSubHaber.Enabled = false;
            this.txtSubHaber.FormatoDecimal = false;
            this.txtSubHaber.Location = new System.Drawing.Point(454, 311);
            this.txtSubHaber.Name = "txtSubHaber";
            this.txtSubHaber.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSubHaber.nNumDecimales = 2;
            this.txtSubHaber.nvalor = 0D;
            this.txtSubHaber.Size = new System.Drawing.Size(95, 20);
            this.txtSubHaber.TabIndex = 3;
            this.txtSubHaber.Text = "0.00";
            this.txtSubHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubDebe
            // 
            this.txtSubDebe.Enabled = false;
            this.txtSubDebe.FormatoDecimal = false;
            this.txtSubDebe.Location = new System.Drawing.Point(356, 311);
            this.txtSubDebe.Name = "txtSubDebe";
            this.txtSubDebe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSubDebe.nNumDecimales = 2;
            this.txtSubDebe.nvalor = 0D;
            this.txtSubDebe.Size = new System.Drawing.Size(95, 20);
            this.txtSubDebe.TabIndex = 2;
            this.txtSubDebe.Text = "0.00";
            this.txtSubDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(283, 314);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(65, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Sub Total:";
            // 
            // btnExportar
            // 
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar.Location = new System.Drawing.Point(537, 335);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(60, 50);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "E&xportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(616, 54);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 2;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(662, 335);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // chcActExpot
            // 
            this.chcActExpot.AutoSize = true;
            this.chcActExpot.ForeColor = System.Drawing.Color.Navy;
            this.chcActExpot.Location = new System.Drawing.Point(616, 34);
            this.chcActExpot.Name = "chcActExpot";
            this.chcActExpot.Size = new System.Drawing.Size(118, 17);
            this.chcActExpot.TabIndex = 1;
            this.chcActExpot.Text = "Activar Exportación";
            this.chcActExpot.UseVisualStyleBackColor = true;
            this.chcActExpot.CheckedChanged += new System.EventHandler(this.chcActExpot_CheckedChanged);
            // 
            // frmLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 410);
            this.Controls.Add(this.chcActExpot);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dtgLibroMayor);
            this.Controls.Add(this.txtSubDebe);
            this.Controls.Add(this.txtSubHaber);
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase5);
            this.Name = "frmLibroMayor";
            this.Text = "Libro Mayor";
            this.Load += new System.EventHandler(this.frmLibroMayor_Load);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbFiltros, 0);
            this.Controls.SetChildIndex(this.txtSubHaber, 0);
            this.Controls.SetChildIndex(this.txtSubDebe, 0);
            this.Controls.SetChildIndex(this.dtgLibroMayor, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.chcActExpot, 0);
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            this.grbCtaContable.ResumeLayout(false);
            this.grbCtaContable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLibroMayor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtCtaCtbFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbFiltros;
        private GEN.ControlesBase.dtgBase dtgLibroMayor;
        private GEN.ControlesBase.txtNumRea txtSubHaber;
        private GEN.ControlesBase.txtNumRea txtSubDebe;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.ToolTip toolTip1;
        private GEN.BotonesBase.btnExportar btnExportar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.grbBase grbCtaContable;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtCtaCtbIni;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.chcBase chcActExpot;
    }
}