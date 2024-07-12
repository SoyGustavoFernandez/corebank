namespace CRE.Presentacion
{
    partial class FrmSolictudRevisionDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSolictudRevisionDocumentos));
            this.grbDatSol = new GEN.ControlesBase.grbBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMonedas(this.components);
            this.cboAsesor = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbDatRev = new GEN.ControlesBase.grbBase(this.components);
            this.lblEstado = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.btnQuitDoc = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgrDoc = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase(this.components);
            this.cNomArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iconDoc = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.grbDatSol.SuspendLayout();
            this.grbDatRev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.SuspendLayout();
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
            this.grbDatSol.Location = new System.Drawing.Point(12, 115);
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
            this.txtMonto.TabIndex = 7;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(79, 73);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(182, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // cboAsesor
            // 
            this.cboAsesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesor.FormattingEnabled = true;
            this.cboAsesor.Location = new System.Drawing.Point(79, 46);
            this.cboAsesor.Name = "cboAsesor";
            this.cboAsesor.Size = new System.Drawing.Size(470, 21);
            this.cboAsesor.TabIndex = 5;
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
            // grbDatRev
            // 
            this.grbDatRev.Controls.Add(this.lblEstado);
            this.grbDatRev.Controls.Add(this.lblBase5);
            this.grbDatRev.Controls.Add(this.txtMotivo);
            this.grbDatRev.Controls.Add(this.btnQuitDoc);
            this.grbDatRev.Controls.Add(this.btnAgrDoc);
            this.grbDatRev.Controls.Add(this.dtgDocumentos);
            this.grbDatRev.Location = new System.Drawing.Point(12, 221);
            this.grbDatRev.Name = "grbDatRev";
            this.grbDatRev.Size = new System.Drawing.Size(556, 248);
            this.grbDatRev.TabIndex = 4;
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
            this.lblEstado.TabIndex = 72;
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
            this.txtMotivo.Location = new System.Drawing.Point(9, 35);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(541, 44);
            this.txtMotivo.TabIndex = 0;
            // 
            // btnQuitDoc
            // 
            this.btnQuitDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitDoc.BackgroundImage")));
            this.btnQuitDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitDoc.Enabled = false;
            this.btnQuitDoc.Location = new System.Drawing.Point(514, 85);
            this.btnQuitDoc.Name = "btnQuitDoc";
            this.btnQuitDoc.Size = new System.Drawing.Size(36, 28);
            this.btnQuitDoc.TabIndex = 2;
            this.btnQuitDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitDoc.UseVisualStyleBackColor = true;
            this.btnQuitDoc.Click += new System.EventHandler(this.btnQuitDoc_Click);
            // 
            // btnAgrDoc
            // 
            this.btnAgrDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgrDoc.BackgroundImage")));
            this.btnAgrDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgrDoc.Enabled = false;
            this.btnAgrDoc.Location = new System.Drawing.Point(472, 85);
            this.btnAgrDoc.Name = "btnAgrDoc";
            this.btnAgrDoc.Size = new System.Drawing.Size(36, 28);
            this.btnAgrDoc.TabIndex = 1;
            this.btnAgrDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgrDoc.UseVisualStyleBackColor = true;
            this.btnAgrDoc.Click += new System.EventHandler(this.btnAgrDoc_Click);
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
            this.dtgDocumentos.Location = new System.Drawing.Point(6, 115);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(544, 124);
            this.dtgDocumentos.TabIndex = 3;
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
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(377, 475);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(508, 475);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(316, 475);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(255, 475);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(438, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Location = new System.Drawing.Point(12, 9);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(564, 100);
            this.conBusCuentaCli.TabIndex = 0;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_OnCuentaChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(18, 475);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // FrmSolictudRevisionDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 555);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbDatRev);
            this.Controls.Add(this.grbDatSol);
            this.Name = "FrmSolictudRevisionDocumentos";
            this.Text = "Solicitud de revisión de documentos";
            this.Load += new System.EventHandler(this.FrmSolictudRevisionDocumentos_Load);
            this.Controls.SetChildIndex(this.grbDatSol, 0);
            this.Controls.SetChildIndex(this.grbDatRev, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.grbDatSol.ResumeLayout(false);
            this.grbDatSol.PerformLayout();
            this.grbDatRev.ResumeLayout(false);
            this.grbDatRev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatSol;
        private GEN.ControlesBase.grbBase grbDatRev;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.cboPersonalCreditos cboAsesor;
        private GEN.ControlesBase.cboMonedas cboMoneda;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.BotonesBase.btnMiniQuitar btnQuitDoc;
        private GEN.BotonesBase.btnMiniAgregar btnAgrDoc;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomArchivo;
        private System.Windows.Forms.DataGridViewImageColumn iconDoc;
        private System.Windows.Forms.DataGridViewButtonColumn btnVer;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.lblBaseCustom lblEstado;
    }
}