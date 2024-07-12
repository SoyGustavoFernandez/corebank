namespace LOG.Presentacion
{
    partial class frmRptKardexBienAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptKardexBienAlmacen));
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleCatalogo = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtBuscar = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSubGrupo = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoBien = new GEN.ControlesBase.cboTipoBien(this.components);
            this.cboGrupoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.cboSubTipoBien = new GEN.ControlesBase.cboGrupoCatalogo(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleCatalogo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(91, 15);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(307, 21);
            this.cboAgencia.TabIndex = 2;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(18, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(61, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Almacen:";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(91, 43);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(307, 21);
            this.cboAlmacen.TabIndex = 4;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Fecha Inicio:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 54);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Fecha Fin:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(249, 453);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(87, 16);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(307, 20);
            this.dtpFechaIni.TabIndex = 15;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(87, 48);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(307, 20);
            this.dtpFechaFin.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.cboAgencia);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboAlmacen);
            this.groupBox1.Location = new System.Drawing.Point(12, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 73);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Controls.Add(this.dtpFechaIni);
            this.groupBox2.Controls.Add(this.dtpFechaFin);
            this.groupBox2.Location = new System.Drawing.Point(12, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 76);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(170, 453);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleCatalogo);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtBuscar);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 203);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(406, 162);
            this.grbBase1.TabIndex = 42;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle";
            // 
            // dtgDetalleCatalogo
            // 
            this.dtgDetalleCatalogo.AllowUserToAddRows = false;
            this.dtgDetalleCatalogo.AllowUserToDeleteRows = false;
            this.dtgDetalleCatalogo.AllowUserToResizeColumns = false;
            this.dtgDetalleCatalogo.AllowUserToResizeRows = false;
            this.dtgDetalleCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleCatalogo.Location = new System.Drawing.Point(6, 37);
            this.dtgDetalleCatalogo.MultiSelect = false;
            this.dtgDetalleCatalogo.Name = "dtgDetalleCatalogo";
            this.dtgDetalleCatalogo.ReadOnly = true;
            this.dtgDetalleCatalogo.RowHeadersVisible = false;
            this.dtgDetalleCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleCatalogo.Size = new System.Drawing.Size(392, 120);
            this.dtgDetalleCatalogo.TabIndex = 27;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(6, 17);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(68, 13);
            this.lblBase8.TabIndex = 26;
            this.lblBase8.Text = "Búsqueda:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Enabled = false;
            this.txtBuscar.Location = new System.Drawing.Point(91, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(307, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboSubGrupo);
            this.groupBox3.Controls.Add(this.lblBase5);
            this.groupBox3.Controls.Add(this.cboTipoBien);
            this.groupBox3.Controls.Add(this.cboGrupoBien);
            this.groupBox3.Controls.Add(this.cboSubTipoBien);
            this.groupBox3.Controls.Add(this.lblBase6);
            this.groupBox3.Controls.Add(this.lblBase7);
            this.groupBox3.Controls.Add(this.lblBase9);
            this.groupBox3.Location = new System.Drawing.Point(12, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 121);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            // 
            // cboSubGrupo
            // 
            this.cboSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubGrupo.FormattingEnabled = true;
            this.cboSubGrupo.Location = new System.Drawing.Point(91, 91);
            this.cboSubGrupo.Name = "cboSubGrupo";
            this.cboSubGrupo.Size = new System.Drawing.Size(307, 21);
            this.cboSubGrupo.TabIndex = 47;
            this.cboSubGrupo.SelectedIndexChanged += new System.EventHandler(this.cboSubGrupo_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 95);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(73, 13);
            this.lblBase5.TabIndex = 51;
            this.lblBase5.Text = "Sub Grupo:";
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.Location = new System.Drawing.Point(91, 16);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(307, 21);
            this.cboTipoBien.TabIndex = 44;
            this.cboTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboTipoBien_SelectedIndexChanged);
            // 
            // cboGrupoBien
            // 
            this.cboGrupoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoBien.FormattingEnabled = true;
            this.cboGrupoBien.Location = new System.Drawing.Point(91, 66);
            this.cboGrupoBien.Name = "cboGrupoBien";
            this.cboGrupoBien.Size = new System.Drawing.Size(307, 21);
            this.cboGrupoBien.TabIndex = 46;
            this.cboGrupoBien.SelectedIndexChanged += new System.EventHandler(this.cboGrupoBien_SelectedIndexChanged);
            // 
            // cboSubTipoBien
            // 
            this.cboSubTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoBien.FormattingEnabled = true;
            this.cboSubTipoBien.Location = new System.Drawing.Point(91, 41);
            this.cboSubTipoBien.Name = "cboSubTipoBien";
            this.cboSubTipoBien.Size = new System.Drawing.Size(307, 21);
            this.cboSubTipoBien.TabIndex = 45;
            this.cboSubTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoBien_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(38, 66);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(47, 13);
            this.lblBase6.TabIndex = 50;
            this.lblBase6.Text = "Grupo:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(23, 44);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(62, 13);
            this.lblBase7.TabIndex = 49;
            this.lblBase7.Text = "Sub Tipo:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(49, 19);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(36, 13);
            this.lblBase9.TabIndex = 48;
            this.lblBase9.Text = "Tipo:";
            // 
            // frmRptKardexBienAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 534);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRptKardexBienAlmacen";
            this.Text = "Kardex Bienes Almacen";
            this.Load += new System.EventHandler(this.frmRptKardexBienAlmacen_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleCatalogo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgDetalleCatalogo;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private GEN.ControlesBase.cboGrupoCatalogo cboSubGrupo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboTipoBien cboTipoBien;
        private GEN.ControlesBase.cboGrupoCatalogo cboGrupoBien;
        private GEN.ControlesBase.cboGrupoCatalogo cboSubTipoBien;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase9;
    }
}