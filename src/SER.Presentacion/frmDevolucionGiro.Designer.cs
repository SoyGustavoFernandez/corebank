﻿namespace SER.Presentacion
{
    partial class frmDevolucionGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolucionGiro));
            this.txtMonGiro = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNomCliBen = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDniBen = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtDniRem = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNomCliRem = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.btnBusGiro = new GEN.BotonesBase.btnBusqueda();
            this.txtNroGiro = new GEN.ControlesBase.txtCBDNI(this.components);
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTelefCelRem = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtDirRem = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTelefCelDes = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.txtDirDes = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMotivoOperacion1 = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.chcItf = new GEN.ControlesBase.chcBase(this.components);
            this.txtMontEnt = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtRedondeo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.txtITF = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.cboEstablecimientoRem = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.cboEstablecimientoGiroDes = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMonGiro
            // 
            this.txtMonGiro.Enabled = false;
            this.txtMonGiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonGiro.FormatoDecimal = false;
            this.txtMonGiro.Location = new System.Drawing.Point(373, 311);
            this.txtMonGiro.Name = "txtMonGiro";
            this.txtMonGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonGiro.nNumDecimales = 4;
            this.txtMonGiro.nvalor = 0D;
            this.txtMonGiro.Size = new System.Drawing.Size(82, 20);
            this.txtMonGiro.TabIndex = 136;
            this.txtMonGiro.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(297, 315);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(74, 13);
            this.lblBase6.TabIndex = 135;
            this.lblBase6.Text = "Monto Giro:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(71, 314);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(169, 21);
            this.cboMoneda.TabIndex = 134;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(9, 318);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 133;
            this.lblBase7.Text = "Moneda:";
            // 
            // txtNomCliBen
            // 
            this.txtNomCliBen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCliBen.Enabled = false;
            this.txtNomCliBen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomCliBen.Location = new System.Drawing.Point(137, 189);
            this.txtNomCliBen.Name = "txtNomCliBen";
            this.txtNomCliBen.Size = new System.Drawing.Size(400, 20);
            this.txtNomCliBen.TabIndex = 129;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 191);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(129, 13);
            this.lblBase2.TabIndex = 130;
            this.lblBase2.Text = "Apellidos y Nombres:";
            // 
            // txtDniBen
            // 
            this.txtDniBen.Enabled = false;
            this.txtDniBen.Location = new System.Drawing.Point(134, 41);
            this.txtDniBen.Name = "txtDniBen";
            this.txtDniBen.Size = new System.Drawing.Size(133, 20);
            this.txtDniBen.TabIndex = 127;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 217);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(105, 13);
            this.lblBase3.TabIndex = 128;
            this.lblBase3.Text = "Nro. Documento:";
            // 
            // txtDniRem
            // 
            this.txtDniRem.Enabled = false;
            this.txtDniRem.Location = new System.Drawing.Point(135, 40);
            this.txtDniRem.Name = "txtDniRem";
            this.txtDniRem.Size = new System.Drawing.Size(133, 20);
            this.txtDniRem.TabIndex = 124;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 94);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 125;
            this.lblBase1.Text = "Nro. Documento:";
            // 
            // txtNomCliRem
            // 
            this.txtNomCliRem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCliRem.Enabled = false;
            this.txtNomCliRem.Location = new System.Drawing.Point(135, 14);
            this.txtNomCliRem.Name = "txtNomCliRem";
            this.txtNomCliRem.Size = new System.Drawing.Size(402, 20);
            this.txtNomCliRem.TabIndex = 122;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(9, 69);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(129, 13);
            this.lblBase11.TabIndex = 123;
            this.lblBase11.Text = "Apellidos y Nombres:";
            // 
            // btnBusGiro
            // 
            this.btnBusGiro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusGiro.BackgroundImage")));
            this.btnBusGiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusGiro.Enabled = false;
            this.btnBusGiro.Location = new System.Drawing.Point(483, 3);
            this.btnBusGiro.Name = "btnBusGiro";
            this.btnBusGiro.Size = new System.Drawing.Size(60, 50);
            this.btnBusGiro.TabIndex = 121;
            this.btnBusGiro.Text = "&Buscar";
            this.btnBusGiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusGiro.UseVisualStyleBackColor = true;
            this.btnBusGiro.Click += new System.EventHandler(this.btnBusGiro_Click);
            // 
            // txtNroGiro
            // 
            this.txtNroGiro.Enabled = false;
            this.txtNroGiro.Location = new System.Drawing.Point(134, 17);
            this.txtNroGiro.Name = "txtNroGiro";
            this.txtNroGiro.Size = new System.Drawing.Size(111, 20);
            this.txtNroGiro.TabIndex = 119;
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(9, 18);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(107, 13);
            this.lblBase32.TabIndex = 120;
            this.lblBase32.Text = "Número de  Giro:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboEstablecimientoRem);
            this.grbBase1.Controls.Add(this.txtTelefCelRem);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.txtDirRem);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtDniRem);
            this.grbBase1.Controls.Add(this.txtNomCliRem);
            this.grbBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbBase1.Location = new System.Drawing.Point(3, 51);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(546, 115);
            this.grbBase1.TabIndex = 126;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Remitente";
            // 
            // txtTelefCelRem
            // 
            this.txtTelefCelRem.Enabled = false;
            this.txtTelefCelRem.Location = new System.Drawing.Point(437, 39);
            this.txtTelefCelRem.Name = "txtTelefCelRem";
            this.txtTelefCelRem.Size = new System.Drawing.Size(100, 20);
            this.txtTelefCelRem.TabIndex = 145;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(371, 43);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(60, 13);
            this.lblBase10.TabIndex = 144;
            this.lblBase10.Text = "Teléfono:";
            // 
            // txtDirRem
            // 
            this.txtDirRem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDirRem.Enabled = false;
            this.txtDirRem.Location = new System.Drawing.Point(135, 65);
            this.txtDirRem.Name = "txtDirRem";
            this.txtDirRem.Size = new System.Drawing.Size(402, 20);
            this.txtDirRem.TabIndex = 142;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 68);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 143;
            this.lblBase8.Text = "Dirección:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 92);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 72;
            this.lblBase4.Text = "Agencia:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboEstablecimientoGiroDes);
            this.grbBase2.Controls.Add(this.txtTelefCelDes);
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.Controls.Add(this.txtDirDes);
            this.grbBase2.Controls.Add(this.lblBase16);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.txtDniBen);
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbBase2.Location = new System.Drawing.Point(3, 174);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(546, 116);
            this.grbBase2.TabIndex = 131;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Beneficiario";
            // 
            // txtTelefCelDes
            // 
            this.txtTelefCelDes.Enabled = false;
            this.txtTelefCelDes.Location = new System.Drawing.Point(434, 41);
            this.txtTelefCelDes.Name = "txtTelefCelDes";
            this.txtTelefCelDes.Size = new System.Drawing.Size(100, 20);
            this.txtTelefCelDes.TabIndex = 144;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(369, 44);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(60, 13);
            this.lblBase15.TabIndex = 145;
            this.lblBase15.Text = "Teléfono:";
            // 
            // txtDirDes
            // 
            this.txtDirDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDirDes.Enabled = false;
            this.txtDirDes.Location = new System.Drawing.Point(134, 65);
            this.txtDirDes.Name = "txtDirDes";
            this.txtDirDes.Size = new System.Drawing.Size(400, 20);
            this.txtDirDes.TabIndex = 142;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(9, 68);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(65, 13);
            this.lblBase16.TabIndex = 143;
            this.lblBase16.Text = "Dirección:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 92);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 73;
            this.lblBase5.Text = "Agencia:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtNroGiro);
            this.grbBase3.Location = new System.Drawing.Point(3, -2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(471, 50);
            this.grbBase3.TabIndex = 132;
            this.grbBase3.TabStop = false;
            // 
            // cboMotivoOperacion1
            // 
            this.cboMotivoOperacion1.Enabled = false;
            this.cboMotivoOperacion1.FormattingEnabled = true;
            this.cboMotivoOperacion1.Location = new System.Drawing.Point(9, 516);
            this.cboMotivoOperacion1.Name = "cboMotivoOperacion1";
            this.cboMotivoOperacion1.Size = new System.Drawing.Size(249, 21);
            this.cboMotivoOperacion1.TabIndex = 120;
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.chcItf);
            this.grbBase5.Controls.Add(this.txtMontEnt);
            this.grbBase5.Controls.Add(this.lblBase12);
            this.grbBase5.Controls.Add(this.txtRedondeo);
            this.grbBase5.Controls.Add(this.lblBase23);
            this.grbBase5.Controls.Add(this.lblBase22);
            this.grbBase5.Controls.Add(this.txtITF);
            this.grbBase5.Location = new System.Drawing.Point(3, 294);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(546, 116);
            this.grbBase5.TabIndex = 137;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Datos del Giro";
            // 
            // chcItf
            // 
            this.chcItf.AutoSize = true;
            this.chcItf.Enabled = false;
            this.chcItf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcItf.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chcItf.Location = new System.Drawing.Point(12, 50);
            this.chcItf.Name = "chcItf";
            this.chcItf.Size = new System.Drawing.Size(93, 17);
            this.chcItf.TabIndex = 127;
            this.chcItf.Text = "Cobrar ITF?";
            this.chcItf.UseVisualStyleBackColor = true;
            this.chcItf.CheckedChanged += new System.EventHandler(this.chcItf_CheckedChanged);
            // 
            // txtMontEnt
            // 
            this.txtMontEnt.Enabled = false;
            this.txtMontEnt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontEnt.Location = new System.Drawing.Point(370, 88);
            this.txtMontEnt.Name = "txtMontEnt";
            this.txtMontEnt.ShortcutsEnabled = false;
            this.txtMontEnt.Size = new System.Drawing.Size(82, 22);
            this.txtMontEnt.TabIndex = 121;
            this.txtMontEnt.Text = "0.00";
            // 
            // lblBase12
            // 
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(253, 90);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(113, 18);
            this.lblBase12.TabIndex = 120;
            this.lblBase12.Text = "Monto a Entregar:";
            // 
            // txtRedondeo
            // 
            this.txtRedondeo.BackColor = System.Drawing.SystemColors.Control;
            this.txtRedondeo.Enabled = false;
            this.txtRedondeo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRedondeo.FormatoDecimal = true;
            this.txtRedondeo.Location = new System.Drawing.Point(370, 63);
            this.txtRedondeo.Name = "txtRedondeo";
            this.txtRedondeo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRedondeo.nNumDecimales = 2;
            this.txtRedondeo.nvalor = 0D;
            this.txtRedondeo.Size = new System.Drawing.Size(82, 22);
            this.txtRedondeo.TabIndex = 119;
            this.txtRedondeo.Text = "0.00";
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(295, 67);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(69, 13);
            this.lblBase23.TabIndex = 118;
            this.lblBase23.Text = "Redondeo:";
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(336, 43);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(30, 13);
            this.lblBase22.TabIndex = 117;
            this.lblBase22.Text = "ITF:";
            // 
            // txtITF
            // 
            this.txtITF.Enabled = false;
            this.txtITF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtITF.FormatoDecimal = true;
            this.txtITF.Location = new System.Drawing.Point(370, 40);
            this.txtITF.Name = "txtITF";
            this.txtITF.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtITF.nNumDecimales = 2;
            this.txtITF.nvalor = 0D;
            this.txtITF.Size = new System.Drawing.Size(82, 20);
            this.txtITF.TabIndex = 116;
            this.txtITF.Text = "0.00";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(489, 497);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 141;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(415, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 140;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(355, 497);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 139;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(294, 497);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 138;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(6, 414);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(132, 13);
            this.lblBase9.TabIndex = 133;
            this.lblBase9.Text = "Motivo de devolución:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(9, 431);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(540, 60);
            this.txtMotivo.TabIndex = 142;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(7, 500);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(109, 13);
            this.lblBase17.TabIndex = 143;
            this.lblBase17.Text = "Motivo operación:";
            // 
            // cboEstablecimientoRem
            // 
            this.cboEstablecimientoRem.Enabled = false;
            this.cboEstablecimientoRem.FormattingEnabled = true;
            this.cboEstablecimientoRem.Location = new System.Drawing.Point(134, 89);
            this.cboEstablecimientoRem.Name = "cboEstablecimientoRem";
            this.cboEstablecimientoRem.Size = new System.Drawing.Size(403, 21);
            this.cboEstablecimientoRem.TabIndex = 144;
            // 
            // cboEstablecimientoGiroDes
            // 
            this.cboEstablecimientoGiroDes.Enabled = false;
            this.cboEstablecimientoGiroDes.FormattingEnabled = true;
            this.cboEstablecimientoGiroDes.Location = new System.Drawing.Point(134, 89);
            this.cboEstablecimientoGiroDes.Name = "cboEstablecimientoGiroDes";
            this.cboEstablecimientoGiroDes.Size = new System.Drawing.Size(400, 21);
            this.cboEstablecimientoGiroDes.TabIndex = 146;
            // 
            // frmDevolucionGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 572);
            this.Controls.Add(this.lblBase17);
            this.Controls.Add(this.cboMotivoOperacion1);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtMonGiro);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtNomCliBen);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.btnBusGiro);
            this.Controls.Add(this.lblBase32);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase5);
            this.Name = "frmDevolucionGiro";
            this.Text = "Devolución de Giros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDevolucionGiro_FormClosing);
            this.Load += new System.EventHandler(this.frmDevolucionGiro_Load);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase32, 0);
            this.Controls.SetChildIndex(this.btnBusGiro, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtNomCliBen, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonGiro, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.cboMotivoOperacion1, 0);
            this.Controls.SetChildIndex(this.lblBase17, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtMonGiro;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtNomCliBen;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBDNI txtDniBen;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBDNI txtDniRem;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNomCliRem;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.BotonesBase.btnBusqueda btnBusGiro;
        private GEN.ControlesBase.txtCBDNI txtNroGiro;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.txtBase txtDirRem;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtDirDes;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion1;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.txtTelefCel txtTelefCelRem;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtTelefCel txtTelefCelDes;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.txtNumRea txtITF;
        private GEN.ControlesBase.txtNumRea txtRedondeo;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.txtBase txtMontEnt;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.chcBase chcItf;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoRem;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoGiroDes;
    }
}