namespace CRE.Presentacion
{
    partial class frmTasas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTasas));
            this.lblNombreGrupo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblIdCli = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblCliente = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase3 = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCuotaGraciaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCuotaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.txtTasaMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtTasCompensatoriaMax = new GEN.ControlesBase.txtBase(this.components);
            this.txtTasCompensatoriaMin = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoTasaCredito = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.label7 = new System.Windows.Forms.Label();
            this.grbTasa = new GEN.ControlesBase.grbBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.grbTasa.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombreGrupo
            // 
            this.lblNombreGrupo.AutoSize = true;
            this.lblNombreGrupo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombreGrupo.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreGrupo.Location = new System.Drawing.Point(6, 16);
            this.lblNombreGrupo.Name = "lblNombreGrupo";
            this.lblNombreGrupo.Size = new System.Drawing.Size(102, 13);
            this.lblNombreGrupo.TabIndex = 2;
            this.lblNombreGrupo.Text = "Nombre grupo : ";
            // 
            // lblIdCli
            // 
            this.lblIdCli.AutoSize = true;
            this.lblIdCli.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblIdCli.ForeColor = System.Drawing.Color.Navy;
            this.lblIdCli.Location = new System.Drawing.Point(48, 41);
            this.lblIdCli.Name = "lblIdCli";
            this.lblIdCli.Size = new System.Drawing.Size(53, 13);
            this.lblIdCli.TabIndex = 3;
            this.lblIdCli.Text = "ID Cli : ";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCliente.ForeColor = System.Drawing.Color.Navy;
            this.lblCliente.Location = new System.Drawing.Point(48, 66);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente : ";
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(114, 13);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(337, 20);
            this.txtBase1.TabIndex = 5;
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(114, 38);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(94, 20);
            this.txtBase2.TabIndex = 6;
            // 
            // txtBase3
            // 
            this.txtBase3.Location = new System.Drawing.Point(114, 63);
            this.txtBase3.Name = "txtBase3";
            this.txtBase3.Size = new System.Drawing.Size(337, 20);
            this.txtBase3.TabIndex = 7;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblNombreGrupo);
            this.grbBase1.Controls.Add(this.lblIdCli);
            this.grbBase1.Controls.Add(this.txtBase3);
            this.grbBase1.Controls.Add(this.lblCliente);
            this.grbBase1.Controls.Add(this.txtBase2);
            this.grbBase1.Controls.Add(this.txtBase1);
            this.grbBase1.Location = new System.Drawing.Point(3, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(463, 93);
            this.grbBase1.TabIndex = 8;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "InfoCli";
            // 
            // txtCuotaGraciaAprox
            // 
            this.txtCuotaGraciaAprox.Enabled = false;
            this.txtCuotaGraciaAprox.FormatoDecimal = false;
            this.txtCuotaGraciaAprox.Location = new System.Drawing.Point(299, 63);
            this.txtCuotaGraciaAprox.Name = "txtCuotaGraciaAprox";
            this.txtCuotaGraciaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaGraciaAprox.nNumDecimales = 4;
            this.txtCuotaGraciaAprox.nvalor = 0D;
            this.txtCuotaGraciaAprox.Size = new System.Drawing.Size(100, 20);
            this.txtCuotaGraciaAprox.TabIndex = 129;
            this.txtCuotaGraciaAprox.TabStop = false;
            this.txtCuotaGraciaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuotaGraciaAprox.Visible = false;
            // 
            // txtCuotaAprox
            // 
            this.txtCuotaAprox.Enabled = false;
            this.txtCuotaAprox.FormatoDecimal = false;
            this.txtCuotaAprox.Location = new System.Drawing.Point(299, 41);
            this.txtCuotaAprox.Name = "txtCuotaAprox";
            this.txtCuotaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaAprox.nNumDecimales = 4;
            this.txtCuotaAprox.nvalor = 0D;
            this.txtCuotaAprox.Size = new System.Drawing.Size(100, 20);
            this.txtCuotaAprox.TabIndex = 128;
            this.txtCuotaAprox.TabStop = false;
            this.txtCuotaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuotaAprox.Visible = false;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(260, 67);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(82, 13);
            this.lblBase5.TabIndex = 127;
            this.lblBase5.Text = "Cuota Gracia";
            this.lblBase5.Visible = false;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(259, 45);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(83, 13);
            this.lblBase17.TabIndex = 126;
            this.lblBase17.Text = "Cuota Aprox.";
            this.lblBase17.Visible = false;
            // 
            // txtTasaMora
            // 
            this.txtTasaMora.Enabled = false;
            this.txtTasaMora.FormatoDecimal = false;
            this.txtTasaMora.Location = new System.Drawing.Point(174, 63);
            this.txtTasaMora.Name = "txtTasaMora";
            this.txtTasaMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMora.nNumDecimales = 4;
            this.txtTasaMora.nvalor = 0D;
            this.txtTasaMora.Size = new System.Drawing.Size(55, 20);
            this.txtTasaMora.TabIndex = 119;
            // 
            // txtTEA
            // 
            this.txtTEA.FormatoDecimal = false;
            this.txtTEA.Location = new System.Drawing.Point(174, 41);
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 4;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.Size = new System.Drawing.Size(55, 20);
            this.txtTEA.TabIndex = 118;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(230, 67);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(19, 13);
            this.lblBase16.TabIndex = 114;
            this.lblBase16.Text = "%";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(230, 45);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(19, 13);
            this.lblBase11.TabIndex = 123;
            this.lblBase11.Text = "%";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(143, 45);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(29, 13);
            this.lblBase9.TabIndex = 122;
            this.lblBase9.Text = "TEA";
            // 
            // txtTasCompensatoriaMax
            // 
            this.txtTasCompensatoriaMax.Enabled = false;
            this.txtTasCompensatoriaMax.Location = new System.Drawing.Point(299, 19);
            this.txtTasCompensatoriaMax.Name = "txtTasCompensatoriaMax";
            this.txtTasCompensatoriaMax.Size = new System.Drawing.Size(55, 20);
            this.txtTasCompensatoriaMax.TabIndex = 117;
            this.txtTasCompensatoriaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTasCompensatoriaMin
            // 
            this.txtTasCompensatoriaMin.Enabled = false;
            this.txtTasCompensatoriaMin.Location = new System.Drawing.Point(174, 19);
            this.txtTasCompensatoriaMin.Name = "txtTasCompensatoriaMin";
            this.txtTasCompensatoriaMin.Size = new System.Drawing.Size(55, 20);
            this.txtTasCompensatoriaMin.TabIndex = 116;
            this.txtTasCompensatoriaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboTipoTasaCredito
            // 
            this.cboTipoTasaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaCredito.DropDownWidth = 200;
            this.cboTipoTasaCredito.FormattingEnabled = true;
            this.cboTipoTasaCredito.Location = new System.Drawing.Point(17, 19);
            this.cboTipoTasaCredito.Name = "cboTipoTasaCredito";
            this.cboTipoTasaCredito.Size = new System.Drawing.Size(112, 21);
            this.cboTipoTasaCredito.TabIndex = 115;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(146, 23);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(26, 13);
            this.lblBase13.TabIndex = 120;
            this.lblBase13.Text = "Min";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(267, 23);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(30, 13);
            this.lblBase14.TabIndex = 121;
            this.lblBase14.Text = "Max";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(81, 67);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(91, 13);
            this.lblBase15.TabIndex = 124;
            this.lblBase15.Text = "Tasa Moratoria";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "Min";
            // 
            // grbTasa
            // 
            this.grbTasa.Controls.Add(this.cboTipoTasaCredito);
            this.grbTasa.Controls.Add(this.txtCuotaGraciaAprox);
            this.grbTasa.Controls.Add(this.label7);
            this.grbTasa.Controls.Add(this.txtCuotaAprox);
            this.grbTasa.Controls.Add(this.lblBase15);
            this.grbTasa.Controls.Add(this.lblBase5);
            this.grbTasa.Controls.Add(this.lblBase14);
            this.grbTasa.Controls.Add(this.lblBase17);
            this.grbTasa.Controls.Add(this.lblBase13);
            this.grbTasa.Controls.Add(this.txtTasaMora);
            this.grbTasa.Controls.Add(this.txtTasCompensatoriaMin);
            this.grbTasa.Controls.Add(this.txtTEA);
            this.grbTasa.Controls.Add(this.txtTasCompensatoriaMax);
            this.grbTasa.Controls.Add(this.lblBase16);
            this.grbTasa.Controls.Add(this.lblBase9);
            this.grbTasa.Controls.Add(this.lblBase11);
            this.grbTasa.Location = new System.Drawing.Point(3, 101);
            this.grbTasa.Name = "grbTasa";
            this.grbTasa.Size = new System.Drawing.Size(463, 100);
            this.grbTasa.TabIndex = 130;
            this.grbTasa.TabStop = false;
            this.grbTasa.Text = "Selección tasa";
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(331, 206);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 131;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(397, 206);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 132;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmTasas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 281);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.grbTasa);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmTasas";
            this.Text = "Tasa Individual";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbTasa, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbTasa.ResumeLayout(false);
            this.grbTasa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBaseCustom lblNombreGrupo;
        private GEN.ControlesBase.lblBaseCustom lblIdCli;
        private GEN.ControlesBase.lblBaseCustom lblCliente;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.txtBase txtBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtNumRea txtCuotaGraciaAprox;
        private GEN.ControlesBase.txtNumRea txtCuotaAprox;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.txtNumRea txtTasaMora;
        private GEN.ControlesBase.txtNumRea txtTEA;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtTasCompensatoriaMax;
        private GEN.ControlesBase.txtBase txtTasCompensatoriaMin;
        private GEN.ControlesBase.cboBase cboTipoTasaCredito;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase15;
        private System.Windows.Forms.Label label7;
        private GEN.ControlesBase.grbBase grbTasa;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}