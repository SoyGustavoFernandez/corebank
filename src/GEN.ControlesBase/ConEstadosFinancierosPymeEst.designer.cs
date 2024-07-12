namespace GEN.ControlesBase
{
    partial class ConEstadosFinancierosPymeEst
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlEstadosFinancieros = new System.Windows.Forms.Panel();
            this.tableLayoutCuerpo = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutCabecera = new System.Windows.Forms.TableLayoutPanel();
            this.dtgIncrementos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgEstResEval = new GEN.ControlesBase.dtgBase(this.components);
            this.msTitulos = new System.Windows.Forms.MenuStrip();
            this.tstbTituloEERR = new System.Windows.Forms.ToolStripTextBox();
            this.btnDeudas = new GEN.BotonesBase.btnBlanco();
            this.txtUltEvalRef = new GEN.ControlesBase.txtBase(this.components);
            this.lblCuotaAprox = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtCuotaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.conCreditoTasa = new GEN.ControlesBase.ConCreditoTasa();
            this.conIndicadores = new CRE.ControlBase.ConIndicadores();
            this.pnlEstadosFinancieros.SuspendLayout();
            this.tableLayoutCuerpo.SuspendLayout();
            this.tableLayoutCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncrementos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstResEval)).BeginInit();
            this.msTitulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEstadosFinancieros
            // 
            this.pnlEstadosFinancieros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstadosFinancieros.Controls.Add(this.tableLayoutCuerpo);
            this.pnlEstadosFinancieros.Controls.Add(this.msTitulos);
            this.pnlEstadosFinancieros.Location = new System.Drawing.Point(350, 26);
            this.pnlEstadosFinancieros.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEstadosFinancieros.Name = "pnlEstadosFinancieros";
            this.pnlEstadosFinancieros.Size = new System.Drawing.Size(720, 452);
            this.pnlEstadosFinancieros.TabIndex = 72;
            // 
            // tableLayoutCuerpo
            // 
            this.tableLayoutCuerpo.ColumnCount = 1;
            this.tableLayoutCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCuerpo.Controls.Add(this.tableLayoutCabecera, 0, 0);
            this.tableLayoutCuerpo.Controls.Add(this.dtgEstResEval, 1, 0);
            this.tableLayoutCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCuerpo.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutCuerpo.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutCuerpo.Name = "tableLayoutCuerpo";
            this.tableLayoutCuerpo.RowCount = 2;
            this.tableLayoutCuerpo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutCuerpo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCuerpo.Size = new System.Drawing.Size(718, 426);
            this.tableLayoutCuerpo.TabIndex = 24;
            // 
            // tableLayoutCabecera
            // 
            this.tableLayoutCabecera.ColumnCount = 4;
            this.tableLayoutCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCabecera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutCabecera.Controls.Add(this.dtgIncrementos, 1, 0);
            this.tableLayoutCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCabecera.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutCabecera.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutCabecera.Name = "tableLayoutCabecera";
            this.tableLayoutCabecera.RowCount = 1;
            this.tableLayoutCabecera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCabecera.Size = new System.Drawing.Size(718, 42);
            this.tableLayoutCabecera.TabIndex = 0;
            this.tableLayoutCabecera.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutCabecera_Paint);
            // 
            // dtgIncrementos
            // 
            this.dtgIncrementos.AllowUserToAddRows = false;
            this.dtgIncrementos.AllowUserToDeleteRows = false;
            this.dtgIncrementos.AllowUserToResizeColumns = false;
            this.dtgIncrementos.AllowUserToResizeRows = false;
            this.dtgIncrementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIncrementos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgIncrementos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgIncrementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIncrementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIncrementos.Location = new System.Drawing.Point(360, 0);
            this.dtgIncrementos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgIncrementos.MultiSelect = false;
            this.dtgIncrementos.Name = "dtgIncrementos";
            this.dtgIncrementos.ReadOnly = true;
            this.dtgIncrementos.RowHeadersVisible = false;
            this.dtgIncrementos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtgIncrementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIncrementos.Size = new System.Drawing.Size(70, 42);
            this.dtgIncrementos.TabIndex = 1;
            this.dtgIncrementos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIncrementos_CellValueChanged);
            this.dtgIncrementos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIncrementos_EditingControlShowing);
            this.dtgIncrementos.Leave += new System.EventHandler(this.dtgIncrementos_Leave);
            // 
            // dtgEstResEval
            // 
            this.dtgEstResEval.AllowUserToAddRows = false;
            this.dtgEstResEval.AllowUserToDeleteRows = false;
            this.dtgEstResEval.AllowUserToResizeColumns = false;
            this.dtgEstResEval.AllowUserToResizeRows = false;
            this.dtgEstResEval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEstResEval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEstResEval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstResEval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEstResEval.Location = new System.Drawing.Point(0, 42);
            this.dtgEstResEval.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEstResEval.MultiSelect = false;
            this.dtgEstResEval.Name = "dtgEstResEval";
            this.dtgEstResEval.ReadOnly = true;
            this.dtgEstResEval.RowHeadersVisible = false;
            this.dtgEstResEval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEstResEval.Size = new System.Drawing.Size(718, 384);
            this.dtgEstResEval.TabIndex = 0;
            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);
            this.dtgEstResEval.Leave += new System.EventHandler(this.dtgEstResEval_Leave);
            // 
            // msTitulos
            // 
            this.msTitulos.BackColor = System.Drawing.Color.White;
            this.msTitulos.GripMargin = new System.Windows.Forms.Padding(0);
            this.msTitulos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbTituloEERR});
            this.msTitulos.Location = new System.Drawing.Point(0, 0);
            this.msTitulos.Name = "msTitulos";
            this.msTitulos.Size = new System.Drawing.Size(718, 24);
            this.msTitulos.TabIndex = 23;
            this.msTitulos.Text = "menuStrip1";
            // 
            // tstbTituloEERR
            // 
            this.tstbTituloEERR.BackColor = System.Drawing.Color.White;
            this.tstbTituloEERR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstbTituloEERR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tstbTituloEERR.Name = "tstbTituloEERR";
            this.tstbTituloEERR.ReadOnly = true;
            this.tstbTituloEERR.Size = new System.Drawing.Size(190, 20);
            this.tstbTituloEERR.Text = "Estado de Perdidas y Ganancias";
            // 
            // btnDeudas
            // 
            this.btnDeudas.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeudas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeudas.Location = new System.Drawing.Point(285, 253);
            this.btnDeudas.Name = "btnDeudas";
            this.btnDeudas.Size = new System.Drawing.Size(60, 50);
            this.btnDeudas.TabIndex = 133;
            this.btnDeudas.Text = "Deudas";
            this.btnDeudas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeudas.UseVisualStyleBackColor = false;
            this.btnDeudas.Click += new System.EventHandler(this.btnDeudas_Click);
            // 
            // txtUltEvalRef
            // 
            this.txtUltEvalRef.Location = new System.Drawing.Point(7, 272);
            this.txtUltEvalRef.Multiline = true;
            this.txtUltEvalRef.Name = "txtUltEvalRef";
            this.txtUltEvalRef.ReadOnly = true;
            this.txtUltEvalRef.Size = new System.Drawing.Size(272, 32);
            this.txtUltEvalRef.TabIndex = 145;
            this.txtUltEvalRef.Text = "ÚLTIMA EVALUACIÓN:";
            // 
            // lblCuotaAprox
            // 
            this.lblCuotaAprox.AutoSize = true;
            this.lblCuotaAprox.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuotaAprox.ForeColor = System.Drawing.Color.Navy;
            this.lblCuotaAprox.Location = new System.Drawing.Point(17, 251);
            this.lblCuotaAprox.Name = "lblCuotaAprox";
            this.lblCuotaAprox.Size = new System.Drawing.Size(83, 13);
            this.lblCuotaAprox.TabIndex = 144;
            this.lblCuotaAprox.Text = "Cuota Aprox.";
            // 
            // txtCuotaAprox
            // 
            this.txtCuotaAprox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuotaAprox.Enabled = false;
            this.txtCuotaAprox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotaAprox.FormatoDecimal = false;
            this.txtCuotaAprox.Location = new System.Drawing.Point(165, 248);
            this.txtCuotaAprox.MaxLength = 9;
            this.txtCuotaAprox.Name = "txtCuotaAprox";
            this.txtCuotaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaAprox.nNumDecimales = 2;
            this.txtCuotaAprox.nvalor = 0D;
            this.txtCuotaAprox.ReadOnly = true;
            this.txtCuotaAprox.Size = new System.Drawing.Size(108, 20);
            this.txtCuotaAprox.TabIndex = 143;
            this.txtCuotaAprox.Text = "0";
            this.txtCuotaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // conCreditoTasa
            // 
            this.conCreditoTasa.AutoSize = true;
            this.conCreditoTasa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoTasa.CuotasEnabled = false;
            this.conCreditoTasa.CuotasGraciaEnable = false;
            this.conCreditoTasa.DiasGraciaEnabled = false;
            this.conCreditoTasa.FechaDesembolsoEnabled = true;
            this.conCreditoTasa.lMostrarTodosNivCred = false;
            this.conCreditoTasa.Location = new System.Drawing.Point(9, 14);
            this.conCreditoTasa.MonedaEnabled = false;
            this.conCreditoTasa.MontoEnabled = true;
            this.conCreditoTasa.Name = "conCreditoTasa";
            this.conCreditoTasa.NivelesProductoEnabled = false;
            this.conCreditoTasa.PlazoCuotaEnabled = false;
            this.conCreditoTasa.Size = new System.Drawing.Size(325, 229);
            this.conCreditoTasa.SubTipoPeriodoEnable = false;
            this.conCreditoTasa.TabIndex = 142;
            this.conCreditoTasa.TEAEnabled = false;
            this.conCreditoTasa.TipoPeriodoEnabled = false;
            this.conCreditoTasa.TipoTasaCreditoEnabled = false;
            this.conCreditoTasa.ChangeMonto += new System.EventHandler(this.ConCreditoTasa_ChangeMonto);
            this.conCreditoTasa.ChangeCuotaAprox += new System.EventHandler(this.ConCreditoTasa_ChangeCuotaAprox);
            this.conCreditoTasa.ValueChangedDia += new System.EventHandler(this.conCreditoTasa_ValueChangedDia);
            // 
            // conIndicadores
            // 
            this.conIndicadores.DescripcionReglaEnabled = true;
            this.conIndicadores.Location = new System.Drawing.Point(2, 307);
            this.conIndicadores.Name = "conIndicadores";
            this.conIndicadores.Size = new System.Drawing.Size(344, 182);
            this.conIndicadores.TabIndex = 141;
            this.conIndicadores.ValidacionEnabled = true;
            // 
            // ConEstadosFinancierosPymeEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtUltEvalRef);
            this.Controls.Add(this.lblCuotaAprox);
            this.Controls.Add(this.txtCuotaAprox);
            this.Controls.Add(this.pnlEstadosFinancieros);
            this.Controls.Add(this.btnDeudas);
            this.Controls.Add(this.conCreditoTasa);
            this.Controls.Add(this.conIndicadores);
            this.Name = "ConEstadosFinancierosPymeEst";
            this.Size = new System.Drawing.Size(1075, 506);
            this.pnlEstadosFinancieros.ResumeLayout(false);
            this.pnlEstadosFinancieros.PerformLayout();
            this.tableLayoutCuerpo.ResumeLayout(false);
            this.tableLayoutCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncrementos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstResEval)).EndInit();
            this.msTitulos.ResumeLayout(false);
            this.msTitulos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CRE.ControlBase.ConIndicadores conIndicadores;
        private System.Windows.Forms.Panel pnlEstadosFinancieros;
        private dtgBase dtgEstResEval;
        private ConCreditoTasa conCreditoTasa;
        private BotonesBase.btnBlanco btnDeudas;
        private System.Windows.Forms.MenuStrip msTitulos;
        private System.Windows.Forms.ToolStripTextBox tstbTituloEERR;
        private dtgBase dtgIncrementos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCuerpo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCabecera;
        private lblBaseCustom lblCuotaAprox;
        private txtNumRea txtCuotaAprox;
        private txtBase txtUltEvalRef;
    }
}
