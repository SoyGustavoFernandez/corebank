namespace CRE.Presentacion
{
    partial class FrmRevisarDocCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRevisarDocCred));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbDatRev = new GEN.ControlesBase.grbBase(this.components);
            this.lblEstado = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase(this.components);
            this.cNomArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iconDoc = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grbDatSol = new GEN.ControlesBase.grbBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMonedas(this.components);
            this.cboAsesor = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtComentRev = new GEN.ControlesBase.txtBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.conBusCuentaCli.SuspendLayout();
            this.grbDatRev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.grbDatSol.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Controls.Add(this.grbBase1);
            this.conBusCuentaCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(564, 100);
            this.conBusCuentaCli.TabIndex = 0;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_OnCuentaChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(554, 99);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(508, 538);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(377, 538);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grbDatRev
            // 
            this.grbDatRev.Controls.Add(this.lblEstado);
            this.grbDatRev.Controls.Add(this.lblBase5);
            this.grbDatRev.Controls.Add(this.txtMotivo);
            this.grbDatRev.Controls.Add(this.dtgDocumentos);
            this.grbDatRev.Location = new System.Drawing.Point(12, 224);
            this.grbDatRev.Name = "grbDatRev";
            this.grbDatRev.Size = new System.Drawing.Size(556, 217);
            this.grbDatRev.TabIndex = 2;
            this.grbDatRev.TabStop = false;
            this.grbDatRev.Text = "Documentos";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(423, 19);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(67, 13);
            this.lblEstado.TabIndex = 71;
            this.lblEstado.Text = "lblEstado";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 19);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(49, 13);
            this.lblBase5.TabIndex = 70;
            this.lblBase5.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(9, 35);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(541, 44);
            this.txtMotivo.TabIndex = 0;
            // 
            // dtgDocumentos
            // 
            this.dtgDocumentos.AllowUserToAddRows = false;
            this.dtgDocumentos.AllowUserToDeleteRows = false;
            this.dtgDocumentos.AllowUserToResizeColumns = false;
            this.dtgDocumentos.AllowUserToResizeRows = false;
            this.dtgDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNomArchivo,
            this.iconDoc,
            this.btnVer});
            this.dtgDocumentos.Location = new System.Drawing.Point(6, 85);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(544, 124);
            this.dtgDocumentos.TabIndex = 1;
            this.dtgDocumentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentos_CellContentClick);
            this.dtgDocumentos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgDocumentos_DataBindingComplete);
            // 
            // cNomArchivo
            // 
            this.cNomArchivo.DataPropertyName = "cNomArchivo";
            this.cNomArchivo.FillWeight = 75F;
            this.cNomArchivo.HeaderText = "Archivo";
            this.cNomArchivo.Name = "cNomArchivo";
            this.cNomArchivo.ReadOnly = true;
            // 
            // iconDoc
            // 
            this.iconDoc.DataPropertyName = "iconDoc";
            this.iconDoc.FillWeight = 15F;
            this.iconDoc.HeaderText = "Icono";
            this.iconDoc.Name = "iconDoc";
            this.iconDoc.ReadOnly = true;
            this.iconDoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnVer
            // 
            this.btnVer.FillWeight = 10F;
            this.btnVer.HeaderText = "Ver";
            this.btnVer.Name = "btnVer";
            this.btnVer.ReadOnly = true;
            this.btnVer.Text = "Ver";
            this.btnVer.UseColumnTextForButtonValue = true;
            // 
            // grbDatSol
            // 
            this.grbDatSol.Controls.Add(this.txtMonto);
            this.grbDatSol.Controls.Add(this.cboMoneda);
            this.grbDatSol.Controls.Add(this.cboAsesor);
            this.grbDatSol.Controls.Add(this.lblBase4);
            this.grbDatSol.Controls.Add(this.lblBase3);
            this.grbDatSol.Controls.Add(this.lblBase2);
            this.grbDatSol.Controls.Add(this.lblBase1);
            this.grbDatSol.Controls.Add(this.cboAgencia);
            this.grbDatSol.Location = new System.Drawing.Point(12, 118);
            this.grbDatSol.Name = "grbDatSol";
            this.grbDatSol.Size = new System.Drawing.Size(555, 100);
            this.grbDatSol.TabIndex = 1;
            this.grbDatSol.TabStop = false;
            this.grbDatSol.Text = "Datos de la solicitud";
            // 
            // txtMonto
            // 
            this.txtMonto.FormatoDecimal = true;
            this.txtMonto.Location = new System.Drawing.Point(343, 73);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 2;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(206, 20);
            this.txtMonto.TabIndex = 3;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(79, 73);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(182, 21);
            this.cboMoneda.TabIndex = 2;
            // 
            // cboAsesor
            // 
            this.cboAsesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesor.FormattingEnabled = true;
            this.cboAsesor.Location = new System.Drawing.Point(79, 46);
            this.cboAsesor.Name = "cboAsesor";
            this.cboAsesor.Size = new System.Drawing.Size(470, 21);
            this.cboAsesor.TabIndex = 1;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(291, 77);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(46, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Monto:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(22, 77);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Moneda:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(27, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Asesor:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(79, 19);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(470, 21);
            this.cboAgencia.TabIndex = 0;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.txtComentRev);
            this.grbBase2.Location = new System.Drawing.Point(12, 447);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(555, 85);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la revisión";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 20);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(185, 13);
            this.lblBase6.TabIndex = 72;
            this.lblBase6.Text = "Comentario resultado revisión:";
            // 
            // txtComentRev
            // 
            this.txtComentRev.Location = new System.Drawing.Point(9, 36);
            this.txtComentRev.Multiline = true;
            this.txtComentRev.Name = "txtComentRev";
            this.txtComentRev.Size = new System.Drawing.Size(541, 44);
            this.txtComentRev.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(438, 538);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmRevisarDocCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 614);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbDatRev);
            this.Controls.Add(this.grbDatSol);
            this.Name = "FrmRevisarDocCred";
            this.Text = "Revisión de documentos de créditos";
            this.Load += new System.EventHandler(this.FrmSolictudRevisionDocumentos_Load);
            this.Controls.SetChildIndex(this.grbDatSol, 0);
            this.Controls.SetChildIndex(this.grbDatRev, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.conBusCuentaCli.ResumeLayout(false);
            this.grbDatRev.ResumeLayout(false);
            this.grbDatRev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.grbDatSol.ResumeLayout(false);
            this.grbDatSol.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.grbBase grbDatRev;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomArchivo;
        private System.Windows.Forms.DataGridViewImageColumn iconDoc;
        private System.Windows.Forms.DataGridViewButtonColumn btnVer;
        private GEN.ControlesBase.grbBase grbDatSol;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.cboMonedas cboMoneda;
        private GEN.ControlesBase.cboPersonalCreditos cboAsesor;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtComentRev;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBaseCustom lblEstado;
    }
}