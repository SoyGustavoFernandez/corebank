namespace CLI.Presentacion
{
    partial class frmGestionContacto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionContacto));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTelefCel1 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.txtTelefCel2 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.txtEmail1 = new GEN.ControlesBase.txtEmail(this.components);
            this.cboActualizarTelef = new GEN.ControlesBase.cboBase(this.components);
            this.cboActualizarCorr = new GEN.ControlesBase.cboBase(this.components);
            this.cboPropietTelef = new GEN.ControlesBase.cboBase(this.components);
            this.cboPropietCorreo = new GEN.ControlesBase.cboBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnContinuar1 = new GEN.BotonesBase.btnContinuar();
            this.btnCargaArhivos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grbGestionContacto = new System.Windows.Forms.GroupBox();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.grbDecisionTD = new System.Windows.Forms.GroupBox();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbGestionContacto.SuspendLayout();
            this.grbDecisionTD.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(22, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 2;
            this.conBusCli1.ChangeDocumentoID += new System.EventHandler(this.conBusCli1_ChangeDocumentoID);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(64, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Teléfono: ";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(225, 13);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "¿Actualizar?";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(303, 13);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(48, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Nuevo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(465, 13);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(74, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Propietario:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 61);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Correo: ";
            // 
            // txtTelefCel1
            // 
            this.txtTelefCel1.Location = new System.Drawing.Point(65, 30);
            this.txtTelefCel1.Name = "txtTelefCel1";
            this.txtTelefCel1.Size = new System.Drawing.Size(157, 20);
            this.txtTelefCel1.TabIndex = 15;
            // 
            // txtTelefCel2
            // 
            this.txtTelefCel2.Location = new System.Drawing.Point(306, 30);
            this.txtTelefCel2.Name = "txtTelefCel2";
            this.txtTelefCel2.Size = new System.Drawing.Size(157, 20);
            this.txtTelefCel2.TabIndex = 16;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(65, 58);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(157, 20);
            this.txtEmail1.TabIndex = 17;
            // 
            // cboActualizarTelef
            // 
            this.cboActualizarTelef.FormattingEnabled = true;
            this.cboActualizarTelef.Location = new System.Drawing.Point(228, 30);
            this.cboActualizarTelef.Name = "cboActualizarTelef";
            this.cboActualizarTelef.Size = new System.Drawing.Size(72, 21);
            this.cboActualizarTelef.TabIndex = 20;
            this.cboActualizarTelef.SelectedIndexChanged += new System.EventHandler(this.cboActualizarTelef_SelectedIndexChanged);
            // 
            // cboActualizarCorr
            // 
            this.cboActualizarCorr.FormattingEnabled = true;
            this.cboActualizarCorr.Location = new System.Drawing.Point(228, 58);
            this.cboActualizarCorr.Name = "cboActualizarCorr";
            this.cboActualizarCorr.Size = new System.Drawing.Size(72, 21);
            this.cboActualizarCorr.TabIndex = 21;
            this.cboActualizarCorr.SelectedIndexChanged += new System.EventHandler(this.cboActualizarCorr_SelectedIndexChanged);
            // 
            // cboPropietTelef
            // 
            this.cboPropietTelef.FormattingEnabled = true;
            this.cboPropietTelef.Location = new System.Drawing.Point(468, 30);
            this.cboPropietTelef.Name = "cboPropietTelef";
            this.cboPropietTelef.Size = new System.Drawing.Size(82, 21);
            this.cboPropietTelef.TabIndex = 22;
            // 
            // cboPropietCorreo
            // 
            this.cboPropietCorreo.FormattingEnabled = true;
            this.cboPropietCorreo.Location = new System.Drawing.Point(468, 58);
            this.cboPropietCorreo.Name = "cboPropietCorreo";
            this.cboPropietCorreo.Size = new System.Drawing.Size(82, 21);
            this.cboPropietCorreo.TabIndex = 23;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(362, 256);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 24;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(428, 256);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 25;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnContinuar1
            // 
            this.btnContinuar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinuar1.BackgroundImage")));
            this.btnContinuar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContinuar1.Location = new System.Drawing.Point(494, 256);
            this.btnContinuar1.Name = "btnContinuar1";
            this.btnContinuar1.Size = new System.Drawing.Size(60, 50);
            this.btnContinuar1.TabIndex = 26;
            this.btnContinuar1.Text = "Continuar";
            this.btnContinuar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContinuar1.UseVisualStyleBackColor = true;
            this.btnContinuar1.Click += new System.EventHandler(this.btnContinuar1_Click);
            // 
            // btnCargaArhivos
            // 
            this.btnCargaArhivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargaArhivos.BackgroundImage")));
            this.btnCargaArhivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaArhivos.Location = new System.Drawing.Point(296, 256);
            this.btnCargaArhivos.Name = "btnCargaArhivos";
            this.btnCargaArhivos.Size = new System.Drawing.Size(60, 50);
            this.btnCargaArhivos.TabIndex = 67;
            this.btnCargaArhivos.Text = "Carga de Archivos";
            this.btnCargaArhivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargaArhivos.UseVisualStyleBackColor = true;
            this.btnCargaArhivos.Click += new System.EventHandler(this.btnCargaArhivos_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(288, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 21);
            this.label1.TabIndex = 68;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 69;
            // 
            // grbGestionContacto
            // 
            this.grbGestionContacto.Controls.Add(this.txtEmail2);
            this.grbGestionContacto.Controls.Add(this.grbDecisionTD);
            this.grbGestionContacto.Controls.Add(this.lblBase6);
            this.grbGestionContacto.Controls.Add(this.cboPropietCorreo);
            this.grbGestionContacto.Controls.Add(this.cboPropietTelef);
            this.grbGestionContacto.Controls.Add(this.label1);
            this.grbGestionContacto.Controls.Add(this.cboActualizarCorr);
            this.grbGestionContacto.Controls.Add(this.cboActualizarTelef);
            this.grbGestionContacto.Controls.Add(this.txtEmail1);
            this.grbGestionContacto.Controls.Add(this.txtTelefCel2);
            this.grbGestionContacto.Controls.Add(this.txtTelefCel1);
            this.grbGestionContacto.Controls.Add(this.lblBase5);
            this.grbGestionContacto.Controls.Add(this.lblBase4);
            this.grbGestionContacto.Controls.Add(this.lblBase3);
            this.grbGestionContacto.Controls.Add(this.lblBase2);
            this.grbGestionContacto.Controls.Add(this.lblBase1);
            this.grbGestionContacto.Location = new System.Drawing.Point(9, 130);
            this.grbGestionContacto.Name = "grbGestionContacto";
            this.grbGestionContacto.Size = new System.Drawing.Size(566, 125);
            this.grbGestionContacto.TabIndex = 70;
            this.grbGestionContacto.TabStop = false;
            this.grbGestionContacto.Text = "Datos de Contacto del Cliente";
            // 
            // txtEmail2
            // 
            this.txtEmail2.Location = new System.Drawing.Point(306, 59);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(157, 20);
            this.txtEmail2.TabIndex = 71;
            // 
            // grbDecisionTD
            // 
            this.grbDecisionTD.Controls.Add(this.rbNo);
            this.grbDecisionTD.Controls.Add(this.rbSi);
            this.grbDecisionTD.Location = new System.Drawing.Point(184, 86);
            this.grbDecisionTD.Name = "grbDecisionTD";
            this.grbDecisionTD.Size = new System.Drawing.Size(87, 26);
            this.grbDecisionTD.TabIndex = 72;
            this.grbDecisionTD.TabStop = false;
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(43, 4);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(41, 17);
            this.rbNo.TabIndex = 71;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "NO";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Location = new System.Drawing.Point(6, 4);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(35, 17);
            this.rbSi.TabIndex = 70;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "SI";
            this.rbSi.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(5, 91);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(180, 13);
            this.lblBase6.TabIndex = 69;
            this.lblBase6.Text = "¿Autoriza envío de publicidad?";
            // 
            // frmGestionContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 332);
            this.Controls.Add(this.grbGestionContacto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCargaArhivos);
            this.Controls.Add(this.btnContinuar1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.conBusCli1);
            this.Name = "frmGestionContacto";
            this.Text = "Gestión de Contacto del Cliente";
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnContinuar1, 0);
            this.Controls.SetChildIndex(this.btnCargaArhivos, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.grbGestionContacto, 0);
            this.grbGestionContacto.ResumeLayout(false);
            this.grbGestionContacto.PerformLayout();
            this.grbDecisionTD.ResumeLayout(false);
            this.grbDecisionTD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtTelefCel txtTelefCel1;
        private GEN.ControlesBase.txtTelefCel txtTelefCel2;
        private GEN.ControlesBase.txtEmail txtEmail1;
        private GEN.ControlesBase.cboBase cboActualizarTelef;
        private GEN.ControlesBase.cboBase cboActualizarCorr;
        private GEN.ControlesBase.cboBase cboPropietTelef;
        private GEN.ControlesBase.cboBase cboPropietCorreo;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnContinuar btnContinuar1;
        private GEN.BotonesBase.btnAdjuntarFile btnCargaArhivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbGestionContacto;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbSi;
        private System.Windows.Forms.GroupBox grbDecisionTD;
        private System.Windows.Forms.TextBox txtEmail2;
    }
}