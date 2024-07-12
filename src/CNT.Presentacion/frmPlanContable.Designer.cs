namespace CNT.Presentacion
{
    partial class frmPlanContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanContable));
            this.conTreeRecusivo1 = new GEN.ControlesBase.conTreeRecusivo();
            this.btnBuscar = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtBusCtaCtb = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCtaCtb = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcAgencia = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.nIDDesAut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIDPlaCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCueAmaAut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCueDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipDat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nPorImpCuen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtValIntegrado = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtValDolares = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtValSoles = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.chcIndicaSBS = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboNaturalezaCnt = new GEN.ControlesBase.cboNaturalezaCnt(this.components);
            this.btnImprimirSBS = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirAli = new GEN.BotonesBase.btnImprimir();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // conTreeRecusivo1
            // 
            this.conTreeRecusivo1.Location = new System.Drawing.Point(12, 68);
            this.conTreeRecusivo1.Name = "conTreeRecusivo1";
            this.conTreeRecusivo1.Size = new System.Drawing.Size(442, 392);
            this.conTreeRecusivo1.TabIndex = 2;
            this.conTreeRecusivo1.DblClick += new System.EventHandler(this.conTreeRecusivo1_DblClick);
            this.conTreeRecusivo1.KeyTrv += new System.Windows.Forms.KeyPressEventHandler(this.conTreeRecusivo1_KeyTrv);
            this.conTreeRecusivo1.Load += new System.EventHandler(this.conTreeRecusivo1_Load);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Location = new System.Drawing.Point(264, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 50);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(704, 410);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtBusCtaCtb
            // 
            this.txtBusCtaCtb.Location = new System.Drawing.Point(12, 12);
            this.txtBusCtaCtb.Name = "txtBusCtaCtb";
            this.txtBusCtaCtb.Size = new System.Drawing.Size(201, 20);
            this.txtBusCtaCtb.TabIndex = 0;
            this.txtBusCtaCtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusCtaCtb_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(108, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Cuenta Contable:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcVigente);
            this.grbBase1.Controls.Add(this.txtCtaCtb);
            this.grbBase1.Controls.Add(this.chcAgencia);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtDescripcion);
            this.grbBase1.Location = new System.Drawing.Point(458, 68);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(306, 170);
            this.grbBase1.TabIndex = 7;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle";
            // 
            // txtCtaCtb
            // 
            this.txtCtaCtb.Enabled = false;
            this.txtCtaCtb.FormatoDecimal = false;
            this.txtCtaCtb.Location = new System.Drawing.Point(109, 21);
            this.txtCtaCtb.Name = "txtCtaCtb";
            this.txtCtaCtb.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCtaCtb.nNumDecimales = 4;
            this.txtCtaCtb.nvalor = 0D;
            this.txtCtaCtb.Size = new System.Drawing.Size(189, 20);
            this.txtCtaCtb.TabIndex = 0;
            // 
            // chcAgencia
            // 
            this.chcAgencia.AutoSize = true;
            this.chcAgencia.Enabled = false;
            this.chcAgencia.ForeColor = System.Drawing.Color.Navy;
            this.chcAgencia.Location = new System.Drawing.Point(109, 143);
            this.chcAgencia.Name = "chcAgencia";
            this.chcAgencia.Size = new System.Drawing.Size(112, 17);
            this.chcAgencia.TabIndex = 2;
            this.chcAgencia.Text = "Activar Agencias?";
            this.chcAgencia.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 57);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(109, 54);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(189, 76);
            this.txtDescripcion.TabIndex = 1;
            // 
            // nIDDesAut
            // 
            this.nIDDesAut.DataPropertyName = "nIDDesAut";
            this.nIDDesAut.HeaderText = "nIDDesAut";
            this.nIDDesAut.Name = "nIDDesAut";
            this.nIDDesAut.Visible = false;
            // 
            // nIDPlaCon
            // 
            this.nIDPlaCon.DataPropertyName = "nIDPlaCon";
            this.nIDPlaCon.HeaderText = "nIDPlaCon";
            this.nIDPlaCon.Name = "nIDPlaCon";
            this.nIDPlaCon.Visible = false;
            // 
            // nCueAmaAut
            // 
            this.nCueAmaAut.DataPropertyName = "nCueAmaAut";
            this.nCueAmaAut.HeaderText = "nCueAmaAut";
            this.nCueAmaAut.Name = "nCueAmaAut";
            this.nCueAmaAut.Visible = false;
            // 
            // nCueDes
            // 
            this.nCueDes.DataPropertyName = "nCueDes";
            this.nCueDes.HeaderText = "Destino";
            this.nCueDes.Name = "nCueDes";
            // 
            // TipDat
            // 
            this.TipDat.DataPropertyName = "cIDTipDat";
            this.TipDat.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TipDat.HeaderText = "Tipo";
            this.TipDat.Name = "TipDat";
            this.TipDat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipDat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nPorImpCuen
            // 
            this.nPorImpCuen.DataPropertyName = "nPorImpCuen";
            this.nPorImpCuen.HeaderText = "nPorImpCuen";
            this.nPorImpCuen.Name = "nPorImpCuen";
            this.nPorImpCuen.Visible = false;
            // 
            // lEstado
            // 
            this.lEstado.DataPropertyName = "lEstado";
            this.lEstado.HeaderText = "Estado";
            this.lEstado.Name = "lEstado";
            this.lEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lEstado.Visible = false;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(638, 410);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtValIntegrado);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtValDolares);
            this.grbBase2.Controls.Add(this.txtValSoles);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Location = new System.Drawing.Point(458, 305);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(306, 99);
            this.grbBase2.TabIndex = 10;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Saldos";
            // 
            // txtValIntegrado
            // 
            this.txtValIntegrado.Enabled = false;
            this.txtValIntegrado.FormatoDecimal = false;
            this.txtValIntegrado.Location = new System.Drawing.Point(162, 68);
            this.txtValIntegrado.Name = "txtValIntegrado";
            this.txtValIntegrado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValIntegrado.nNumDecimales = 2;
            this.txtValIntegrado.nvalor = 0D;
            this.txtValIntegrado.Size = new System.Drawing.Size(140, 20);
            this.txtValIntegrado.TabIndex = 10;
            this.txtValIntegrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 72);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(152, 13);
            this.lblBase6.TabIndex = 9;
            this.lblBase6.Text = "Saldo moneda integrado:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(145, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Saldo moneda nacional:";
            // 
            // txtValDolares
            // 
            this.txtValDolares.Enabled = false;
            this.txtValDolares.FormatoDecimal = false;
            this.txtValDolares.Location = new System.Drawing.Point(162, 42);
            this.txtValDolares.Name = "txtValDolares";
            this.txtValDolares.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValDolares.nNumDecimales = 2;
            this.txtValDolares.nvalor = 0D;
            this.txtValDolares.Size = new System.Drawing.Size(140, 20);
            this.txtValDolares.TabIndex = 1;
            this.txtValDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValSoles
            // 
            this.txtValSoles.Enabled = false;
            this.txtValSoles.FormatoDecimal = false;
            this.txtValSoles.Location = new System.Drawing.Point(162, 16);
            this.txtValSoles.Name = "txtValSoles";
            this.txtValSoles.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValSoles.nNumDecimales = 2;
            this.txtValSoles.nvalor = 0D;
            this.txtValSoles.Size = new System.Drawing.Size(140, 20);
            this.txtValSoles.TabIndex = 0;
            this.txtValSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(158, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Saldo moneda extranjera:";
            // 
            // chcIndicaSBS
            // 
            this.chcIndicaSBS.AutoSize = true;
            this.chcIndicaSBS.Enabled = false;
            this.chcIndicaSBS.ForeColor = System.Drawing.Color.Navy;
            this.chcIndicaSBS.Location = new System.Drawing.Point(109, 40);
            this.chcIndicaSBS.Name = "chcIndicaSBS";
            this.chcIndicaSBS.Size = new System.Drawing.Size(79, 17);
            this.chcIndicaSBS.TabIndex = 7;
            this.chcIndicaSBS.Text = "Indica SBS";
            this.chcIndicaSBS.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 19);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(94, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Naturaleza cta:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboNaturalezaCnt);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.chcIndicaSBS);
            this.grbBase3.Location = new System.Drawing.Point(458, 235);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(306, 64);
            this.grbBase3.TabIndex = 11;
            this.grbBase3.TabStop = false;
            // 
            // cboNaturalezaCnt
            // 
            this.cboNaturalezaCnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNaturalezaCnt.Enabled = false;
            this.cboNaturalezaCnt.FormattingEnabled = true;
            this.cboNaturalezaCnt.Location = new System.Drawing.Point(109, 14);
            this.cboNaturalezaCnt.Name = "cboNaturalezaCnt";
            this.cboNaturalezaCnt.Size = new System.Drawing.Size(189, 21);
            this.cboNaturalezaCnt.TabIndex = 8;
            // 
            // btnImprimirSBS
            // 
            this.btnImprimirSBS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirSBS.BackgroundImage")));
            this.btnImprimirSBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirSBS.Location = new System.Drawing.Point(572, 410);
            this.btnImprimirSBS.Name = "btnImprimirSBS";
            this.btnImprimirSBS.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirSBS.TabIndex = 12;
            this.btnImprimirSBS.Text = "Imp. SBS";
            this.btnImprimirSBS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirSBS.UseVisualStyleBackColor = true;
            this.btnImprimirSBS.Click += new System.EventHandler(this.btnImprimirSBS_Click);
            // 
            // btnImprimirAli
            // 
            this.btnImprimirAli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirAli.BackgroundImage")));
            this.btnImprimirAli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirAli.Location = new System.Drawing.Point(506, 410);
            this.btnImprimirAli.Name = "btnImprimirAli";
            this.btnImprimirAli.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirAli.TabIndex = 13;
            this.btnImprimirAli.Text = "Alineado";
            this.btnImprimirAli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirAli.UseVisualStyleBackColor = true;
            this.btnImprimirAli.Click += new System.EventHandler(this.btnImprimirAli_Click);
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.ForeColor = System.Drawing.Color.Navy;
            this.chcVigente.Location = new System.Drawing.Point(230, 143);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 14;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // frmPlanContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 485);
            this.Controls.Add(this.btnImprimirAli);
            this.Controls.Add(this.btnImprimirSBS);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.txtBusCtaCtb);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.conTreeRecusivo1);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmPlanContable";
            this.Text = "Plan Contable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlanContable_FormClosed);
            this.Load += new System.EventHandler(this.Solintels_Form1_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.conTreeRecusivo1, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.txtBusCtaCtb, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimirSBS, 0);
            this.Controls.SetChildIndex(this.btnImprimirAli, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conTreeRecusivo conTreeRecusivo1;
        private GEN.BotonesBase.btnBusqueda btnBuscar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtBusCtaCtb;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDDesAut;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIDPlaCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCueAmaAut;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCueDes;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPorImpCuen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lEstado;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.chcBase chcAgencia;
        private GEN.ControlesBase.txtNumRea txtCtaCtb;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtValDolares;
        private GEN.ControlesBase.txtNumRea txtValSoles;
        private GEN.ControlesBase.txtNumRea txtValIntegrado;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chcBase chcIndicaSBS;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboNaturalezaCnt cboNaturalezaCnt;
        private GEN.BotonesBase.btnImprimir btnImprimirSBS;
        private GEN.BotonesBase.btnImprimir btnImprimirAli;
        private GEN.ControlesBase.chcBase chcVigente;
    }
}

