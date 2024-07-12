namespace SolIntEls
{
    partial class frmAprExtorno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprExtorno));
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroKardex = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtMonGiro = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMotExt = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipOpe = new GEN.ControlesBase.txtBase(this.components);
            this.txtNomMod = new GEN.ControlesBase.txtBase(this.components);
            this.txtNomAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtNomSol = new GEN.ControlesBase.txtBase(this.components);
            this.txtFecSol = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtNroSol = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnRechazar = new GEN.BotonesBase.btnExtorno();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(12, 31);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(124, 13);
            this.lblBase32.TabIndex = 132;
            this.lblBase32.Text = "Número de  Kardex:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNroKardex);
            this.grbBase1.Location = new System.Drawing.Point(5, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(434, 65);
            this.grbBase1.TabIndex = 134;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar Operación";
            // 
            // txtNroKardex
            // 
            this.txtNroKardex.Enabled = false;
            this.txtNroKardex.Location = new System.Drawing.Point(133, 27);
            this.txtNroKardex.Name = "txtNroKardex";
            this.txtNroKardex.Size = new System.Drawing.Size(132, 20);
            this.txtNroKardex.TabIndex = 150;
            this.txtNroKardex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatBus_KeyPress);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(363, 13);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 135;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtMonGiro
            // 
            this.txtMonGiro.Enabled = false;
            this.txtMonGiro.FormatoDecimal = false;
            this.txtMonGiro.Location = new System.Drawing.Point(125, 233);
            this.txtMonGiro.Name = "txtMonGiro";
            this.txtMonGiro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonGiro.nNumDecimales = 4;
            this.txtMonGiro.nvalor = 0D;
            this.txtMonGiro.Size = new System.Drawing.Size(145, 20);
            this.txtMonGiro.TabIndex = 139;
            this.txtMonGiro.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 236);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 138;
            this.lblBase6.Text = "Monto Operación:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 187);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(98, 13);
            this.lblBase1.TabIndex = 137;
            this.lblBase1.Text = "Tipo Operación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 117);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(71, 13);
            this.lblBase2.TabIndex = 141;
            this.lblBase2.Text = "Solicitante:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 140);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 143;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(12, 279);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(62, 13);
            this.lblBase13.TabIndex = 145;
            this.lblBase13.Text = "Sustento:";
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(125, 282);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(312, 76);
            this.txtSustento.TabIndex = 144;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 259);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(97, 13);
            this.lblBase4.TabIndex = 147;
            this.lblBase4.Text = "Motivo Extorno:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtMotExt);
            this.grbBase2.Controls.Add(this.txtTipOpe);
            this.grbBase2.Controls.Add(this.txtNomMod);
            this.grbBase2.Controls.Add(this.txtNomAge);
            this.grbBase2.Controls.Add(this.txtNomSol);
            this.grbBase2.Controls.Add(this.txtFecSol);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Location = new System.Drawing.Point(4, 69);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(441, 295);
            this.grbBase2.TabIndex = 148;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Solicitud";
            // 
            // txtMotExt
            // 
            this.txtMotExt.Enabled = false;
            this.txtMotExt.Location = new System.Drawing.Point(121, 189);
            this.txtMotExt.Name = "txtMotExt";
            this.txtMotExt.Size = new System.Drawing.Size(312, 20);
            this.txtMotExt.TabIndex = 159;
            // 
            // txtTipOpe
            // 
            this.txtTipOpe.Enabled = false;
            this.txtTipOpe.Location = new System.Drawing.Point(121, 116);
            this.txtTipOpe.Name = "txtTipOpe";
            this.txtTipOpe.Size = new System.Drawing.Size(312, 20);
            this.txtTipOpe.TabIndex = 158;
            // 
            // txtNomMod
            // 
            this.txtNomMod.Enabled = false;
            this.txtNomMod.Location = new System.Drawing.Point(121, 93);
            this.txtNomMod.Name = "txtNomMod";
            this.txtNomMod.Size = new System.Drawing.Size(312, 20);
            this.txtNomMod.TabIndex = 157;
            // 
            // txtNomAge
            // 
            this.txtNomAge.Enabled = false;
            this.txtNomAge.Location = new System.Drawing.Point(121, 69);
            this.txtNomAge.Name = "txtNomAge";
            this.txtNomAge.Size = new System.Drawing.Size(312, 20);
            this.txtNomAge.TabIndex = 156;
            // 
            // txtNomSol
            // 
            this.txtNomSol.Enabled = false;
            this.txtNomSol.Location = new System.Drawing.Point(121, 45);
            this.txtNomSol.Name = "txtNomSol";
            this.txtNomSol.Size = new System.Drawing.Size(312, 20);
            this.txtNomSol.TabIndex = 155;
            // 
            // txtFecSol
            // 
            this.txtFecSol.Enabled = false;
            this.txtFecSol.Location = new System.Drawing.Point(291, 22);
            this.txtFecSol.Name = "txtFecSol";
            this.txtFecSol.Size = new System.Drawing.Size(142, 20);
            this.txtFecSol.TabIndex = 153;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(8, 96);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 154;
            this.lblBase8.Text = "Módulo:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(227, 23);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(67, 13);
            this.lblBase11.TabIndex = 154;
            this.lblBase11.Text = "Fecha Sol:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(121, 139);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(195, 21);
            this.cboMoneda.TabIndex = 151;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(8, 142);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 150;
            this.lblBase7.Text = "Moneda:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(384, 370);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 149;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtNroSol
            // 
            this.txtNroSol.Enabled = false;
            this.txtNroSol.Location = new System.Drawing.Point(125, 89);
            this.txtNroSol.Name = "txtNroSol";
            this.txtNroSol.Size = new System.Drawing.Size(100, 20);
            this.txtNroSol.TabIndex = 152;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 91);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(79, 13);
            this.lblBase5.TabIndex = 151;
            this.lblBase5.Text = "Número Sol:";
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazar.BackgroundImage")));
            this.btnRechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar.Enabled = false;
            this.btnRechazar.Location = new System.Drawing.Point(322, 370);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar.TabIndex = 154;
            this.btnRechazar.Text = "&Extornar";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(260, 370);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 153;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // frmAprExtorno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 445);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNroSol);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtMonGiro);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.lblBase32);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmAprExtorno";
            this.Text = "Aprobación y Rechazo de Extornos";
            this.Load += new System.EventHandler(this.frmAprExtorno_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase32, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonGiro, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtNroSol, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnRechazar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtNumRea txtMonGiro;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtNroKardex;
        private GEN.ControlesBase.txtBase txtNroSol;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtMotExt;
        private GEN.ControlesBase.txtBase txtTipOpe;
        private GEN.ControlesBase.txtBase txtNomMod;
        private GEN.ControlesBase.txtBase txtNomAge;
        private GEN.ControlesBase.txtBase txtNomSol;
        private GEN.ControlesBase.txtBase txtFecSol;
        private GEN.BotonesBase.btnExtorno btnRechazar;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
    }
}