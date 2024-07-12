namespace CRE.Presentacion
{
    partial class frmRegistroSiniestro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroSiniestro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSeguros = new GEN.ControlesBase.cboSeguros();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSaldoCapital = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumCredito = new System.Windows.Forms.TextBox();
            this.labelNumCred = new System.Windows.Forms.Label();
            this.txtOficina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.tmpFinCobertura = new GEN.ControlesBase.TimerPicker();
            this.tmpIniCobertura = new GEN.ControlesBase.TimerPicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboEstadoSiniestro = new GEN.ControlesBase.cboSeguros();
            this.tmpFechaRegistro = new GEN.ControlesBase.TimerPicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgSiniestros = new GEN.ControlesBase.dtgBase(this.components);
            this.lblSeguroLibre = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.conBusCli.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSiniestros)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSeguros);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSaldoCapital);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumCredito);
            this.groupBox1.Controls.Add(this.labelNumCred);
            this.groupBox1.Controls.Add(this.txtOficina);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRegion);
            this.groupBox1.Controls.Add(this.tmpFinCobertura);
            this.groupBox1.Controls.Add(this.tmpIniCobertura);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 239);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Seguro";
            // 
            // cboSeguros
            // 
            this.cboSeguros.FormattingEnabled = true;
            this.cboSeguros.Location = new System.Drawing.Point(153, 23);
            this.cboSeguros.Name = "cboSeguros";
            this.cboSeguros.Size = new System.Drawing.Size(375, 21);
            this.cboSeguros.TabIndex = 7;
            this.cboSeguros.SelectedIndexChanged += new System.EventHandler(this.cboSeguros_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 13;
            this.label9.Tag = "Seguro:";
            this.label9.Text = "Seguro:";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.Enabled = false;
            this.txtSaldoCapital.Location = new System.Drawing.Point(153, 203);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.Size = new System.Drawing.Size(375, 20);
            this.txtSaldoCapital.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Saldo Capital:";
            // 
            // txtNumCredito
            // 
            this.txtNumCredito.Enabled = false;
            this.txtNumCredito.Location = new System.Drawing.Point(153, 173);
            this.txtNumCredito.Name = "txtNumCredito";
            this.txtNumCredito.Size = new System.Drawing.Size(375, 20);
            this.txtNumCredito.TabIndex = 12;
            // 
            // labelNumCred
            // 
            this.labelNumCred.AutoSize = true;
            this.labelNumCred.Location = new System.Drawing.Point(6, 178);
            this.labelNumCred.Name = "labelNumCred";
            this.labelNumCred.Size = new System.Drawing.Size(97, 13);
            this.labelNumCred.TabIndex = 9;
            this.labelNumCred.Text = "Número de crédito:";
            // 
            // txtOficina
            // 
            this.txtOficina.Enabled = false;
            this.txtOficina.Location = new System.Drawing.Point(153, 143);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(375, 20);
            this.txtOficina.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Oficina:";
            // 
            // txtRegion
            // 
            this.txtRegion.Enabled = false;
            this.txtRegion.Location = new System.Drawing.Point(153, 113);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(375, 20);
            this.txtRegion.TabIndex = 10;
            // 
            // tmpFinCobertura
            // 
            this.tmpFinCobertura.Enabled = false;
            this.tmpFinCobertura.Location = new System.Drawing.Point(153, 83);
            this.tmpFinCobertura.Name = "tmpFinCobertura";
            this.tmpFinCobertura.Size = new System.Drawing.Size(375, 20);
            this.tmpFinCobertura.TabIndex = 9;
            this.tmpFinCobertura.Value = new System.DateTime(2023, 12, 12, 15, 30, 34, 902);
            // 
            // tmpIniCobertura
            // 
            this.tmpIniCobertura.Enabled = false;
            this.tmpIniCobertura.Location = new System.Drawing.Point(153, 53);
            this.tmpIniCobertura.Name = "tmpIniCobertura";
            this.tmpIniCobertura.Size = new System.Drawing.Size(375, 20);
            this.tmpIniCobertura.TabIndex = 8;
            this.tmpIniCobertura.Value = new System.DateTime(2023, 12, 12, 15, 30, 28, 146);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Región:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Fin Cobertura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio Cobertura:";
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Location = new System.Drawing.Point(12, 12);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(557, 552);
            this.tbcBase1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.conBusCli);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 526);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nuevo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodInst);
            this.conBusCli.Controls.Add(this.txtCodAge);
            this.conBusCli.Controls.Add(this.txtDireccion);
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.Controls.Add(this.txtNombre);
            this.conBusCli.Controls.Add(this.txtNroDoc);
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(6, 7);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(534, 105);
            this.conBusCli.TabIndex = 4;
            this.conBusCli.ChangeDocumentoID += new System.EventHandler(this.conBusCli_ChangeDocumentoID);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 1;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 6;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSeguroLibre);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnGrabar);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnSalir);
            this.groupBox2.Controls.Add(this.cboEstadoSiniestro);
            this.groupBox2.Controls.Add(this.tmpFechaRegistro);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(6, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 149);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Siniestro";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(204, 93);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(402, 93);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 19;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(270, 93);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(336, 93);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(468, 93);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboEstadoSiniestro
            // 
            this.cboEstadoSiniestro.FormattingEnabled = true;
            this.cboEstadoSiniestro.Location = new System.Drawing.Point(153, 50);
            this.cboEstadoSiniestro.Name = "cboEstadoSiniestro";
            this.cboEstadoSiniestro.Size = new System.Drawing.Size(375, 21);
            this.cboEstadoSiniestro.TabIndex = 15;
            // 
            // tmpFechaRegistro
            // 
            this.tmpFechaRegistro.Location = new System.Drawing.Point(153, 20);
            this.tmpFechaRegistro.Name = "tmpFechaRegistro";
            this.tmpFechaRegistro.Size = new System.Drawing.Size(375, 20);
            this.tmpFechaRegistro.TabIndex = 14;
            this.tmpFechaRegistro.Value = new System.DateTime(2023, 12, 12, 15, 30, 28, 146);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Estado del Siniestro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Fecha de Registro:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEditar1);
            this.tabPage2.Controls.Add(this.dtgSiniestros);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(549, 526);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista";
            this.tabPage2.UseVisualStyleBackColor = true;
            //
            // dtgSiniestros
            // 
            this.dtgSiniestros.AllowUserToAddRows = false;
            this.dtgSiniestros.AllowUserToDeleteRows = false;
            this.dtgSiniestros.AllowUserToResizeColumns = false;
            this.dtgSiniestros.AllowUserToResizeRows = false;
            this.dtgSiniestros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSiniestros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSiniestros.Location = new System.Drawing.Point(6, 6);
            this.dtgSiniestros.MultiSelect = false;
            this.dtgSiniestros.Name = "dtgSiniestros";
            this.dtgSiniestros.ReadOnly = true;
            this.dtgSiniestros.RowHeadersVisible = false;
            this.dtgSiniestros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSiniestros.Size = new System.Drawing.Size(537, 458);
            this.dtgSiniestros.TabIndex = 0;
            this.dtgSiniestros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSiniestros_CellDoubleClick);
            // 
            // lblSeguroLibre
            // 
            this.lblSeguroLibre.AutoSize = true;
            this.lblSeguroLibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeguroLibre.ForeColor = System.Drawing.Color.Red;
            this.lblSeguroLibre.Location = new System.Drawing.Point(161, 76);
            this.lblSeguroLibre.Name = "lblSeguroLibre";
            this.lblSeguroLibre.Size = new System.Drawing.Size(216, 13);
            this.lblSeguroLibre.TabIndex = 21;
            this.lblSeguroLibre.Text = "El seguro se adquirió por venta libre.";
            this.lblSeguroLibre.Visible = false;
            //  
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(483, 470);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 1;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // frmRegistroSiniestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 589);
            this.Controls.Add(this.tbcBase1);
            this.Name = "frmRegistroSiniestro";
            this.Text = "Siniestros";
            this.Load += new System.EventHandler(this.frmRegistroSiniestro_Load);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSiniestros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRegion;
        private GEN.ControlesBase.TimerPicker tmpFinCobertura;
        private GEN.ControlesBase.TimerPicker tmpIniCobertura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private System.Windows.Forms.TextBox txtSaldoCapital;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumCredito;
        private System.Windows.Forms.Label labelNumCred;
        private System.Windows.Forms.TextBox txtOficina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboSeguros cboEstadoSiniestro;
        private GEN.ControlesBase.TimerPicker tmpFechaRegistro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private GEN.ControlesBase.cboSeguros cboSeguros;
        private System.Windows.Forms.Label label9;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.dtgBase dtgSiniestros;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private System.Windows.Forms.Label lblSeguroLibre;
        private GEN.BotonesBase.btnEditar btnEditar1;
    }
}