namespace SPL.Presentacion
{
    partial class frmEvaluacionClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluacionClientes));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.dtgCalificacion = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgConsolidado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtValorTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblTipoEvaluacion = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNroEval = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaEval = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFechaEval = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboTipoEval = new GEN.ControlesBase.cboTipoEvalScoring(this.components);
            this.grbDatEval = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboRiesgo = new GEN.ControlesBase.cboCalifScoring(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.cboGrupoFactores = new GEN.ControlesBase.cboGrupoFactoresScoring(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsolidado)).BeginInit();
            this.grbDatEval.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 3);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 16;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // dtgCalificacion
            // 
            this.dtgCalificacion.AllowUserToAddRows = false;
            this.dtgCalificacion.AllowUserToDeleteRows = false;
            this.dtgCalificacion.AllowUserToResizeColumns = false;
            this.dtgCalificacion.AllowUserToResizeRows = false;
            this.dtgCalificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCalificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCalificacion.Location = new System.Drawing.Point(12, 141);
            this.dtgCalificacion.MultiSelect = false;
            this.dtgCalificacion.Name = "dtgCalificacion";
            this.dtgCalificacion.ReadOnly = true;
            this.dtgCalificacion.RowHeadersVisible = false;
            this.dtgCalificacion.RowTemplate.Height = 18;
            this.dtgCalificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCalificacion.Size = new System.Drawing.Size(738, 248);
            this.dtgCalificacion.TabIndex = 18;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(190, 117);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(47, 13);
            this.lblBase6.TabIndex = 23;
            this.lblBase6.Text = "Grupo:";
            // 
            // dtgConsolidado
            // 
            this.dtgConsolidado.AllowUserToAddRows = false;
            this.dtgConsolidado.AllowUserToDeleteRows = false;
            this.dtgConsolidado.AllowUserToResizeColumns = false;
            this.dtgConsolidado.AllowUserToResizeRows = false;
            this.dtgConsolidado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsolidado.Location = new System.Drawing.Point(17, 19);
            this.dtgConsolidado.MultiSelect = false;
            this.dtgConsolidado.Name = "dtgConsolidado";
            this.dtgConsolidado.ReadOnly = true;
            this.dtgConsolidado.RowHeadersVisible = false;
            this.dtgConsolidado.RowTemplate.Height = 18;
            this.dtgConsolidado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConsolidado.Size = new System.Drawing.Size(350, 136);
            this.dtgConsolidado.TabIndex = 25;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(606, 529);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(684, 529);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(211, 165);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(70, 13);
            this.lblBase2.TabIndex = 30;
            this.lblBase2.Text = "Valor total:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 165);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 37;
            this.lblBase3.Text = "Riesgo:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BackColor = System.Drawing.SystemColors.Window;
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.FormatoDecimal = false;
            this.txtValorTotal.Location = new System.Drawing.Point(287, 161);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtValorTotal.nNumDecimales = 4;
            this.txtValorTotal.nvalor = 0D;
            this.txtValorTotal.Size = new System.Drawing.Size(80, 20);
            this.txtValorTotal.TabIndex = 38;
            this.txtValorTotal.Text = "0.00";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(482, 529);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 39;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(420, 529);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 40;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblTipoEvaluacion
            // 
            this.lblTipoEvaluacion.AutoSize = true;
            this.lblTipoEvaluacion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoEvaluacion.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoEvaluacion.Location = new System.Drawing.Point(370, 117);
            this.lblTipoEvaluacion.Name = "lblTipoEvaluacion";
            this.lblTipoEvaluacion.Size = new System.Drawing.Size(110, 13);
            this.lblTipoEvaluacion.TabIndex = 41;
            this.lblTipoEvaluacion.Text = "Tipo Evaluación";
            this.lblTipoEvaluacion.Visible = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 23);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(91, 13);
            this.lblBase4.TabIndex = 42;
            this.lblBase4.Text = "N° evaluación:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(24, 53);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(77, 13);
            this.lblBase5.TabIndex = 43;
            this.lblBase5.Text = "Fecha Eval.:";
            // 
            // txtNroEval
            // 
            this.txtNroEval.Enabled = false;
            this.txtNroEval.Location = new System.Drawing.Point(108, 19);
            this.txtNroEval.Name = "txtNroEval";
            this.txtNroEval.Size = new System.Drawing.Size(81, 20);
            this.txtNroEval.TabIndex = 44;
            // 
            // txtFechaEval
            // 
            this.txtFechaEval.Enabled = false;
            this.txtFechaEval.Location = new System.Drawing.Point(108, 79);
            this.txtFechaEval.Name = "txtFechaEval";
            this.txtFechaEval.Size = new System.Drawing.Size(81, 20);
            this.txtFechaEval.TabIndex = 45;
            this.txtFechaEval.Visible = false;
            // 
            // dtpFechaEval
            // 
            this.dtpFechaEval.Enabled = false;
            this.dtpFechaEval.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEval.Location = new System.Drawing.Point(108, 49);
            this.dtpFechaEval.Name = "dtpFechaEval";
            this.dtpFechaEval.Size = new System.Drawing.Size(81, 20);
            this.dtpFechaEval.TabIndex = 46;
            // 
            // cboTipoEval
            // 
            this.cboTipoEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEval.FormattingEnabled = true;
            this.cboTipoEval.Location = new System.Drawing.Point(12, 113);
            this.cboTipoEval.Name = "cboTipoEval";
            this.cboTipoEval.Size = new System.Drawing.Size(172, 21);
            this.cboTipoEval.TabIndex = 48;
            // 
            // grbDatEval
            // 
            this.grbDatEval.Controls.Add(this.txtNroEval);
            this.grbDatEval.Controls.Add(this.lblBase4);
            this.grbDatEval.Controls.Add(this.dtpFechaEval);
            this.grbDatEval.Controls.Add(this.lblBase5);
            this.grbDatEval.Controls.Add(this.txtFechaEval);
            this.grbDatEval.Location = new System.Drawing.Point(550, 3);
            this.grbDatEval.Name = "grbDatEval";
            this.grbDatEval.Size = new System.Drawing.Size(200, 105);
            this.grbDatEval.TabIndex = 49;
            this.grbDatEval.TabStop = false;
            this.grbDatEval.Text = "Datos Evaluación";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboRiesgo);
            this.grbBase1.Controls.Add(this.dtgConsolidado);
            this.grbBase1.Controls.Add(this.txtValorTotal);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(12, 398);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(379, 195);
            this.grbBase1.TabIndex = 50;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Consolidado";
            // 
            // cboRiesgo
            // 
            this.cboRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRiesgo.Enabled = false;
            this.cboRiesgo.FormattingEnabled = true;
            this.cboRiesgo.lAgregarTodos = false;
            this.cboRiesgo.Location = new System.Drawing.Point(71, 161);
            this.cboRiesgo.Name = "cboRiesgo";
            this.cboRiesgo.Size = new System.Drawing.Size(121, 21);
            this.cboRiesgo.TabIndex = 39;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(544, 529);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 51;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // cboGrupoFactores
            // 
            this.cboGrupoFactores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoFactores.FormattingEnabled = true;
            this.cboGrupoFactores.Location = new System.Drawing.Point(243, 113);
            this.cboGrupoFactores.Name = "cboGrupoFactores";
            this.cboGrupoFactores.Size = new System.Drawing.Size(121, 21);
            this.cboGrupoFactores.TabIndex = 52;
            // 
            // frmEvaluacionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 618);
            this.ControlBox = false;
            this.Controls.Add(this.cboGrupoFactores);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbDatEval);
            this.Controls.Add(this.cboTipoEval);
            this.Controls.Add(this.lblTipoEvaluacion);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.dtgCalificacion);
            this.Controls.Add(this.conBusCli);
            this.Name = "frmEvaluacionClientes";
            this.Text = "Evaluación de cliente Scoring";
            this.Load += new System.EventHandler(this.frmEvaluacionClientes_Load);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.dtgCalificacion, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblTipoEvaluacion, 0);
            this.Controls.SetChildIndex(this.cboTipoEval, 0);
            this.Controls.SetChildIndex(this.grbDatEval, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.cboGrupoFactores, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsolidado)).EndInit();
            this.grbDatEval.ResumeLayout(false);
            this.grbDatEval.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.dtgBase dtgCalificacion;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtgBase dtgConsolidado;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtValorTotal;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBaseCustom lblTipoEvaluacion;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtNroEval;
        private GEN.ControlesBase.txtBase txtFechaEval;
        private GEN.ControlesBase.dtpCorto dtpFechaEval;
        private GEN.ControlesBase.cboTipoEvalScoring cboTipoEval;
        private GEN.ControlesBase.grbBase grbDatEval;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.cboCalifScoring cboRiesgo;
        private GEN.ControlesBase.cboGrupoFactoresScoring cboGrupoFactores;
    }
}