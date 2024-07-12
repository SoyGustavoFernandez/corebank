namespace GEN.ControlesBase
{
    partial class frmDeclaracionJurada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeclaracionJurada));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.txtOtrasOcupaciones = new GEN.ControlesBase.txtBase(this.components);
            this.txtIngresoMensual = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtCuentaOCSi = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtCuentaOCNo = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtEsSOSi = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtEsSONo = new GEN.ControlesBase.rbtBase(this.components);
            this.chklbOcupaciones = new GEN.ControlesBase.chklbBase(this.components);
            this.cboActividadEco1 = new GEN.ControlesBase.cboActividadEco(this.components);
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.cboAnexo = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDepartamento = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboPais = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.conDatCli1 = new GEN.ControlesBase.conDatCli();
            this.btnBusCliente1 = new GEN.BotonesBase.btnBusCliente();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.conBusUbig1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(714, 347);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(528, 347);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 7;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(588, 347);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 8;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnCancelar);
            this.grbBase1.Controls.Add(this.txtOtrasOcupaciones);
            this.grbBase1.Controls.Add(this.txtIngresoMensual);
            this.grbBase1.Controls.Add(this.btnImprimir1);
            this.grbBase1.Controls.Add(this.grbBase3);
            this.grbBase1.Controls.Add(this.btnSalir1);
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Controls.Add(this.btnGrabar1);
            this.grbBase1.Controls.Add(this.chklbOcupaciones);
            this.grbBase1.Controls.Add(this.cboActividadEco1);
            this.grbBase1.Controls.Add(this.conBusUbig1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtDireccion);
            this.grbBase1.Controls.Add(this.conDatCli1);
            this.grbBase1.Location = new System.Drawing.Point(15, 66);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(787, 407);
            this.grbBase1.TabIndex = 10;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(648, 347);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtOtrasOcupaciones
            // 
            this.txtOtrasOcupaciones.Location = new System.Drawing.Point(148, 373);
            this.txtOtrasOcupaciones.Name = "txtOtrasOcupaciones";
            this.txtOtrasOcupaciones.Size = new System.Drawing.Size(353, 20);
            this.txtOtrasOcupaciones.TabIndex = 28;
            // 
            // txtIngresoMensual
            // 
            this.txtIngresoMensual.FormatoDecimal = true;
            this.txtIngresoMensual.Location = new System.Drawing.Point(672, 213);
            this.txtIngresoMensual.Name = "txtIngresoMensual";
            this.txtIngresoMensual.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIngresoMensual.nNumDecimales = 2;
            this.txtIngresoMensual.nvalor = 0D;
            this.txtIngresoMensual.Size = new System.Drawing.Size(100, 20);
            this.txtIngresoMensual.TabIndex = 27;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.rbtCuentaOCSi);
            this.grbBase3.Controls.Add(this.rbtCuentaOCNo);
            this.grbBase3.Location = new System.Drawing.Point(248, 148);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(253, 41);
            this.grbBase3.TabIndex = 26;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "¿Cuénta con Oficial de Cumplimiento?";
            // 
            // rbtCuentaOCSi
            // 
            this.rbtCuentaOCSi.AutoSize = true;
            this.rbtCuentaOCSi.ForeColor = System.Drawing.Color.Navy;
            this.rbtCuentaOCSi.Location = new System.Drawing.Point(15, 19);
            this.rbtCuentaOCSi.Name = "rbtCuentaOCSi";
            this.rbtCuentaOCSi.Size = new System.Drawing.Size(34, 17);
            this.rbtCuentaOCSi.TabIndex = 21;
            this.rbtCuentaOCSi.TabStop = true;
            this.rbtCuentaOCSi.Text = "Si";
            this.rbtCuentaOCSi.UseVisualStyleBackColor = true;
            // 
            // rbtCuentaOCNo
            // 
            this.rbtCuentaOCNo.AutoSize = true;
            this.rbtCuentaOCNo.ForeColor = System.Drawing.Color.Navy;
            this.rbtCuentaOCNo.Location = new System.Drawing.Point(70, 19);
            this.rbtCuentaOCNo.Name = "rbtCuentaOCNo";
            this.rbtCuentaOCNo.Size = new System.Drawing.Size(39, 17);
            this.rbtCuentaOCNo.TabIndex = 21;
            this.rbtCuentaOCNo.TabStop = true;
            this.rbtCuentaOCNo.Text = "No";
            this.rbtCuentaOCNo.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtEsSOSi);
            this.grbBase2.Controls.Add(this.rbtEsSONo);
            this.grbBase2.Location = new System.Drawing.Point(22, 148);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(220, 41);
            this.grbBase2.TabIndex = 26;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "¿Es Sujeto Obligado?";
            // 
            // rbtEsSOSi
            // 
            this.rbtEsSOSi.AutoSize = true;
            this.rbtEsSOSi.ForeColor = System.Drawing.Color.Navy;
            this.rbtEsSOSi.Location = new System.Drawing.Point(15, 19);
            this.rbtEsSOSi.Name = "rbtEsSOSi";
            this.rbtEsSOSi.Size = new System.Drawing.Size(34, 17);
            this.rbtEsSOSi.TabIndex = 21;
            this.rbtEsSOSi.TabStop = true;
            this.rbtEsSOSi.Text = "Si";
            this.rbtEsSOSi.UseVisualStyleBackColor = true;
            this.rbtEsSOSi.CheckedChanged += new System.EventHandler(this.rbtEsSOSi_CheckedChanged);
            // 
            // rbtEsSONo
            // 
            this.rbtEsSONo.AutoSize = true;
            this.rbtEsSONo.ForeColor = System.Drawing.Color.Navy;
            this.rbtEsSONo.Location = new System.Drawing.Point(70, 19);
            this.rbtEsSONo.Name = "rbtEsSONo";
            this.rbtEsSONo.Size = new System.Drawing.Size(39, 17);
            this.rbtEsSONo.TabIndex = 21;
            this.rbtEsSONo.TabStop = true;
            this.rbtEsSONo.Text = "No";
            this.rbtEsSONo.UseVisualStyleBackColor = true;
            this.rbtEsSONo.CheckedChanged += new System.EventHandler(this.rbtEsSONo_CheckedChanged);
            // 
            // chklbOcupaciones
            // 
            this.chklbOcupaciones.FormattingEnabled = true;
            this.chklbOcupaciones.Location = new System.Drawing.Point(148, 213);
            this.chklbOcupaciones.Name = "chklbOcupaciones";
            this.chklbOcupaciones.Size = new System.Drawing.Size(353, 154);
            this.chklbOcupaciones.TabIndex = 24;
            // 
            // cboActividadEco1
            // 
            this.cboActividadEco1.Enabled = false;
            this.cboActividadEco1.FormattingEnabled = true;
            this.cboActividadEco1.Location = new System.Drawing.Point(113, 93);
            this.cboActividadEco1.Name = "cboActividadEco1";
            this.cboActividadEco1.Size = new System.Drawing.Size(388, 21);
            this.cboActividadEco1.TabIndex = 20;
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.conBusUbig1.Controls.Add(this.cboAnexo);
            this.conBusUbig1.Controls.Add(this.cboDistrito);
            this.conBusUbig1.Controls.Add(this.cboProvincia);
            this.conBusUbig1.Controls.Add(this.cboDepartamento);
            this.conBusUbig1.Controls.Add(this.cboPais);
            this.conBusUbig1.Enabled = false;
            this.conBusUbig1.Location = new System.Drawing.Point(540, 28);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 133);
            this.conBusUbig1.TabIndex = 17;
            // 
            // cboAnexo
            // 
            this.cboAnexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnexo.FormattingEnabled = true;
            this.cboAnexo.Location = new System.Drawing.Point(103, 106);
            this.cboAnexo.Name = "cboAnexo";
            this.cboAnexo.Size = new System.Drawing.Size(121, 21);
            this.cboAnexo.TabIndex = 36;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(103, 81);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(121, 21);
            this.cboDistrito.TabIndex = 35;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(103, 56);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 34;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(103, 31);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cboDepartamento.TabIndex = 33;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(103, 6);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(121, 21);
            this.cboPais.TabIndex = 32;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(19, 96);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(59, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Actividad";
            // 
            // lblBase5
            // 
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(528, 209);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(138, 27);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Ingresos aproximados mensuales:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(19, 380);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(119, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Otras Ocupaciones:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(19, 220);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(84, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Ocupaciones:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 122);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(60, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(113, 120);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(388, 20);
            this.txtDireccion.TabIndex = 12;
            // 
            // conDatCli1
            // 
            this.conDatCli1.cliente = null;
            this.conDatCli1.Location = new System.Drawing.Point(19, 28);
            this.conDatCli1.Name = "conDatCli1";
            this.conDatCli1.Size = new System.Drawing.Size(485, 114);
            this.conDatCli1.TabIndex = 10;
            // 
            // btnBusCliente1
            // 
            this.btnBusCliente1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente1.BackgroundImage")));
            this.btnBusCliente1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente1.Enabled = false;
            this.btnBusCliente1.Location = new System.Drawing.Point(12, 12);
            this.btnBusCliente1.Name = "btnBusCliente1";
            this.btnBusCliente1.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente1.TabIndex = 11;
            this.btnBusCliente1.Text = "Cliente";
            this.btnBusCliente1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente1.UseVisualStyleBackColor = true;
            this.btnBusCliente1.Click += new System.EventHandler(this.btnBusCliente1_Click);
            // 
            // frmDeclaracionJurada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 509);
            this.ControlBox = false;
            this.Controls.Add(this.btnBusCliente1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmDeclaracionJurada";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Declaración Jurada Sujetos Obligados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnBusCliente1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.conBusUbig1.ResumeLayout(false);
            this.conBusUbig1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.ControlesBase.cboUbigeo cboAnexo;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.cboUbigeo cboDepartamento;
        private GEN.ControlesBase.cboUbigeo cboPais;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.conDatCli conDatCli1;
        private GEN.BotonesBase.btnBusCliente btnBusCliente1;
        private GEN.ControlesBase.cboActividadEco cboActividadEco1;
        private rbtBase rbtEsSONo;
        private rbtBase rbtEsSOSi;
        private chklbBase chklbOcupaciones;
        private grbBase grbBase3;
        private rbtBase rbtCuentaOCSi;
        private rbtBase rbtCuentaOCNo;
        private grbBase grbBase2;
        private lblBase lblBase3;
        private txtNumRea txtIngresoMensual;
        private lblBase lblBase5;
        private lblBase lblBase6;
        private txtBase txtOtrasOcupaciones;
        private BotonesBase.btnCancelar btnCancelar;
    }
}

