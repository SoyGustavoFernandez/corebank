namespace SER.Presentacion
{
    partial class frmExtornoGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtornoGiro));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
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
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtNroGiro = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroKar = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.btnExtorno = new GEN.BotonesBase.btnExtorno();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboEstablecimientoGiroRem = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.cboEstablecimientoGiroDes = new GEN.ControlesBase.cboEstablecimientoGiro(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(489, 298);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 161;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtMonGiro
            // 
            this.txtMonGiro.Enabled = false;
            this.txtMonGiro.FormatoDecimal = false;
            this.txtMonGiro.Location = new System.Drawing.Point(349, 261);
            this.txtMonGiro.Name = "txtMonGiro";
            this.txtMonGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonGiro.nNumDecimales = 4;
            this.txtMonGiro.nvalor = 0D;
            this.txtMonGiro.Size = new System.Drawing.Size(87, 20);
            this.txtMonGiro.TabIndex = 159;
            this.txtMonGiro.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(274, 263);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(74, 13);
            this.lblBase6.TabIndex = 158;
            this.lblBase6.Text = "Monto Giro:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(71, 259);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(169, 21);
            this.cboMoneda.TabIndex = 157;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(14, 28);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 156;
            this.lblBase7.Text = "Moneda:";
            // 
            // txtNomCliBen
            // 
            this.txtNomCliBen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCliBen.Enabled = false;
            this.txtNomCliBen.Location = new System.Drawing.Point(152, 179);
            this.txtNomCliBen.Name = "txtNomCliBen";
            this.txtNomCliBen.Size = new System.Drawing.Size(392, 20);
            this.txtNomCliBen.TabIndex = 152;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(129, 13);
            this.lblBase2.TabIndex = 153;
            this.lblBase2.Text = "Apellidos y Nombres:";
            // 
            // txtDniBen
            // 
            this.txtDniBen.Enabled = false;
            this.txtDniBen.Location = new System.Drawing.Point(153, 204);
            this.txtDniBen.Name = "txtDniBen";
            this.txtDniBen.Size = new System.Drawing.Size(115, 20);
            this.txtDniBen.TabIndex = 150;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 44);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(105, 13);
            this.lblBase3.TabIndex = 151;
            this.lblBase3.Text = "Nro. Documento:";
            // 
            // txtDniRem
            // 
            this.txtDniRem.Enabled = false;
            this.txtDniRem.Location = new System.Drawing.Point(153, 134);
            this.txtDniRem.Name = "txtDniRem";
            this.txtDniRem.Size = new System.Drawing.Size(115, 20);
            this.txtDniRem.TabIndex = 147;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 44);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 148;
            this.lblBase1.Text = "Nro. Documento:";
            // 
            // txtNomCliRem
            // 
            this.txtNomCliRem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCliRem.Enabled = false;
            this.txtNomCliRem.Location = new System.Drawing.Point(152, 110);
            this.txtNomCliRem.Name = "txtNomCliRem";
            this.txtNomCliRem.Size = new System.Drawing.Size(392, 20);
            this.txtNomCliRem.TabIndex = 145;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(15, 19);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(129, 13);
            this.lblBase11.TabIndex = 146;
            this.lblBase11.Text = "Apellidos y Nombres:";
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(17, 18);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(141, 13);
            this.lblBase32.TabIndex = 143;
            this.lblBase32.Text = "Número de  Operación:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboEstablecimientoGiroRem);
            this.grbBase1.Controls.Add(this.lblBase11);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbBase1.Location = new System.Drawing.Point(2, 94);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(547, 65);
            this.grbBase1.TabIndex = 149;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Remitente";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(274, 42);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 72;
            this.lblBase4.Text = "Agencia:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboEstablecimientoGiroDes);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbBase2.Location = new System.Drawing.Point(2, 164);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(547, 65);
            this.grbBase2.TabIndex = 154;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Beneficiario";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(274, 43);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 73;
            this.lblBase5.Text = "Agencia:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtTipOpe);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.txtNroGiro);
            this.grbBase3.Controls.Add(this.txtNroKar);
            this.grbBase3.Location = new System.Drawing.Point(3, -1);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(531, 90);
            this.grbBase3.TabIndex = 155;
            this.grbBase3.TabStop = false;
            // 
            // txtTipOpe
            // 
            this.txtTipOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipOpe.Enabled = false;
            this.txtTipOpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipOpe.Location = new System.Drawing.Point(161, 64);
            this.txtTipOpe.Name = "txtTipOpe";
            this.txtTipOpe.Size = new System.Drawing.Size(288, 20);
            this.txtTipOpe.TabIndex = 171;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(14, 67);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(98, 13);
            this.lblBase9.TabIndex = 170;
            this.lblBase9.Text = "Tipo Operación:";
            // 
            // txtNroGiro
            // 
            this.txtNroGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroGiro.Enabled = false;
            this.txtNroGiro.Location = new System.Drawing.Point(161, 40);
            this.txtNroGiro.Name = "txtNroGiro";
            this.txtNroGiro.Size = new System.Drawing.Size(160, 20);
            this.txtNroGiro.TabIndex = 169;
            // 
            // txtNroKar
            // 
            this.txtNroKar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroKar.Enabled = false;
            this.txtNroKar.Location = new System.Drawing.Point(161, 16);
            this.txtNroKar.Name = "txtNroKar";
            this.txtNroKar.Size = new System.Drawing.Size(160, 20);
            this.txtNroKar.TabIndex = 168;
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.lblBase7);
            this.grbBase5.Location = new System.Drawing.Point(3, 236);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(546, 56);
            this.grbBase5.TabIndex = 160;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Datos del Giro";
            // 
            // btnExtorno
            // 
            this.btnExtorno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno.BackgroundImage")));
            this.btnExtorno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno.Location = new System.Drawing.Point(365, 298);
            this.btnExtorno.Name = "btnExtorno";
            this.btnExtorno.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno.TabIndex = 162;
            this.btnExtorno.Text = "&Extornar";
            this.btnExtorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno.UseVisualStyleBackColor = true;
            this.btnExtorno.Click += new System.EventHandler(this.btnExtorno_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(427, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 164;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(459, 12);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 165;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(17, 42);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(107, 13);
            this.lblBase8.TabIndex = 167;
            this.lblBase8.Text = "Número de  Giro:";
            // 
            // cboEstablecimientoGiroRem
            // 
            this.cboEstablecimientoGiroRem.Enabled = false;
            this.cboEstablecimientoGiroRem.FormattingEnabled = true;
            this.cboEstablecimientoGiroRem.Location = new System.Drawing.Point(341, 40);
            this.cboEstablecimientoGiroRem.Name = "cboEstablecimientoGiroRem";
            this.cboEstablecimientoGiroRem.Size = new System.Drawing.Size(201, 21);
            this.cboEstablecimientoGiroRem.TabIndex = 168;
            // 
            // cboEstablecimientoGiroDes
            // 
            this.cboEstablecimientoGiroDes.Enabled = false;
            this.cboEstablecimientoGiroDes.FormattingEnabled = true;
            this.cboEstablecimientoGiroDes.Location = new System.Drawing.Point(337, 40);
            this.cboEstablecimientoGiroDes.Name = "cboEstablecimientoGiroDes";
            this.cboEstablecimientoGiroDes.Size = new System.Drawing.Size(205, 21);
            this.cboEstablecimientoGiroDes.TabIndex = 169;
            // 
            // frmExtornoGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 374);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExtorno);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtMonGiro);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.txtNomCliBen);
            this.Controls.Add(this.txtDniBen);
            this.Controls.Add(this.txtDniRem);
            this.Controls.Add(this.txtNomCliRem);
            this.Controls.Add(this.lblBase32);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase5);
            this.Name = "frmExtornoGiro";
            this.Text = "Extorno de Giros Enviados y/o Pagados";
            this.Load += new System.EventHandler(this.frmExtornoGiro_Load);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase32, 0);
            this.Controls.SetChildIndex(this.txtNomCliRem, 0);
            this.Controls.SetChildIndex(this.txtDniRem, 0);
            this.Controls.SetChildIndex(this.txtDniBen, 0);
            this.Controls.SetChildIndex(this.txtNomCliBen, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonGiro, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
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

        private GEN.BotonesBase.btnSalir btnSalir;
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
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.BotonesBase.btnExtorno btnExtorno;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtBase txtNroGiro;
        private GEN.ControlesBase.txtBase txtNroKar;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtTipOpe;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoGiroRem;
        private GEN.ControlesBase.cboEstablecimientoGiro cboEstablecimientoGiroDes;
    }
}