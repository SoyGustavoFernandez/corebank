namespace PRE.Presentacion
{
    partial class frmRegistroValorPartida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroValorPartida));
            this.dtgValoresDePartidas = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase = new GEN.ControlesBase.lblBase();
            this.cboPeriodoPresupuestal = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblPlanificacion = new System.Windows.Forms.Label();
            this.lblReplicar = new GEN.ControlesBase.lblBase();
            this.txtPartida = new GEN.ControlesBase.txtBase(this.components);
            this.lblPartida = new GEN.ControlesBase.lblBase();
            this.btnMiniReplicar = new GEN.BotonesBase.btnMiniActualizar(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtReplicar = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnImportExcel = new GEN.BotonesBase.btnExporExcel();
            this.txtPath = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresDePartidas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgValoresDePartidas
            // 
            this.dtgValoresDePartidas.AllowUserToAddRows = false;
            this.dtgValoresDePartidas.AllowUserToDeleteRows = false;
            this.dtgValoresDePartidas.AllowUserToResizeColumns = false;
            this.dtgValoresDePartidas.AllowUserToResizeRows = false;
            this.dtgValoresDePartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgValoresDePartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValoresDePartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgValoresDePartidas.Location = new System.Drawing.Point(0, 0);
            this.dtgValoresDePartidas.MultiSelect = false;
            this.dtgValoresDePartidas.Name = "dtgValoresDePartidas";
            this.dtgValoresDePartidas.ReadOnly = true;
            this.dtgValoresDePartidas.RowHeadersVisible = false;
            this.dtgValoresDePartidas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgValoresDePartidas.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dtgValoresDePartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValoresDePartidas.Size = new System.Drawing.Size(764, 131);
            this.dtgValoresDePartidas.TabIndex = 0;
            this.dtgValoresDePartidas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValoresDePartidas_CellEndEdit);
            this.dtgValoresDePartidas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgValoresDePartidas_CellValidating);
            this.dtgValoresDePartidas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgValoresDePartidas_EditingControlShowing);
            this.dtgValoresDePartidas.Click += new System.EventHandler(this.dtgValoresDePartidas_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(643, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(577, 13);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(511, 13);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(709, 13);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase.ForeColor = System.Drawing.Color.Navy;
            this.lblBase.Location = new System.Drawing.Point(17, 19);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(55, 13);
            this.lblBase.TabIndex = 0;
            this.lblBase.Text = "Periodo:";
            // 
            // cboPeriodoPresupuestal
            // 
            this.cboPeriodoPresupuestal.FormattingEnabled = true;
            this.cboPeriodoPresupuestal.Location = new System.Drawing.Point(78, 16);
            this.cboPeriodoPresupuestal.Name = "cboPeriodoPresupuestal";
            this.cboPeriodoPresupuestal.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodoPresupuestal.TabIndex = 1;
            this.cboPeriodoPresupuestal.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoPresupuestal_SelectedIndexChanged);
            // 
            // lblPlanificacion
            // 
            this.lblPlanificacion.AutoSize = true;
            this.lblPlanificacion.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanificacion.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPlanificacion.Location = new System.Drawing.Point(214, 19);
            this.lblPlanificacion.Name = "lblPlanificacion";
            this.lblPlanificacion.Size = new System.Drawing.Size(0, 14);
            this.lblPlanificacion.TabIndex = 2;
            // 
            // lblReplicar
            // 
            this.lblReplicar.AutoSize = true;
            this.lblReplicar.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblReplicar.ForeColor = System.Drawing.Color.Navy;
            this.lblReplicar.Location = new System.Drawing.Point(14, 42);
            this.lblReplicar.Name = "lblReplicar";
            this.lblReplicar.Size = new System.Drawing.Size(58, 13);
            this.lblReplicar.TabIndex = 2;
            this.lblReplicar.Text = "Replicar:";
            // 
            // txtPartida
            // 
            this.txtPartida.Location = new System.Drawing.Point(78, 13);
            this.txtPartida.Name = "txtPartida";
            this.txtPartida.ReadOnly = true;
            this.txtPartida.Size = new System.Drawing.Size(218, 20);
            this.txtPartida.TabIndex = 1;
            // 
            // lblPartida
            // 
            this.lblPartida.AutoSize = true;
            this.lblPartida.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPartida.ForeColor = System.Drawing.Color.Navy;
            this.lblPartida.Location = new System.Drawing.Point(20, 16);
            this.lblPartida.Name = "lblPartida";
            this.lblPartida.Size = new System.Drawing.Size(52, 13);
            this.lblPartida.TabIndex = 0;
            this.lblPartida.Text = "Partida:";
            // 
            // btnMiniReplicar
            // 
            this.btnMiniReplicar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniReplicar.BackgroundImage")));
            this.btnMiniReplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniReplicar.Location = new System.Drawing.Point(184, 35);
            this.btnMiniReplicar.Name = "btnMiniReplicar";
            this.btnMiniReplicar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniReplicar.TabIndex = 4;
            this.btnMiniReplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniReplicar.UseVisualStyleBackColor = true;
            this.btnMiniReplicar.Click += new System.EventHandler(this.btnMiniReplicar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 273);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.btnImportExcel);
            this.panel1.Controls.Add(this.lblPlanificacion);
            this.panel1.Controls.Add(this.lblBase);
            this.panel1.Controls.Add(this.cboPeriodoPresupuestal);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 55);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgValoresDePartidas);
            this.panel2.Location = new System.Drawing.Point(10, 64);
            this.panel2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 131);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtReplicar);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnEditar);
            this.panel3.Controls.Add(this.btnMiniReplicar);
            this.panel3.Controls.Add(this.btnGrabar);
            this.panel3.Controls.Add(this.lblReplicar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.txtPartida);
            this.panel3.Controls.Add(this.lblPartida);
            this.panel3.Location = new System.Drawing.Point(3, 201);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 68);
            this.panel3.TabIndex = 0;
            // 
            // txtReplicar
            // 
            this.txtReplicar.FormatoDecimal = false;
            this.txtReplicar.Location = new System.Drawing.Point(78, 40);
            this.txtReplicar.Name = "txtReplicar";
            this.txtReplicar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtReplicar.nNumDecimales = 4;
            this.txtReplicar.nvalor = 0D;
            this.txtReplicar.Size = new System.Drawing.Size(100, 20);
            this.txtReplicar.TabIndex = 3;
            this.txtReplicar.Enter += new System.EventHandler(this.txtReplicar_Enter);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportExcel.BackgroundImage")));
            this.btnImportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportExcel.Location = new System.Drawing.Point(709, 3);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(60, 50);
            this.btnImportExcel.TabIndex = 3;
            this.btnImportExcel.Text = "E&xcel";
            this.btnImportExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // txtPath
            // 
            this.txtPath.AllowDrop = true;
            this.txtPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(267, 16);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(436, 20);
            this.txtPath.TabIndex = 7;
            this.txtPath.Visible = false;
            // 
            // frmRegistroValorPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 295);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(800, 580);
            this.Name = "frmRegistroValorPartida";
            this.Text = "Carga valor de partida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistroValorPartida_FormClosing);
            this.Load += new System.EventHandler(this.frmRegistroValorPartida_Load);
            this.Shown += new System.EventHandler(this.frmRegistroValorPartida_Shown);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresDePartidas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgValoresDePartidas;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal;
        private System.Windows.Forms.Label lblPlanificacion;
        private GEN.ControlesBase.lblBase lblReplicar;
        private GEN.ControlesBase.txtBase txtPartida;
        private GEN.ControlesBase.lblBase lblPartida;
        private GEN.BotonesBase.btnMiniActualizar btnMiniReplicar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private GEN.ControlesBase.txtNumRea txtReplicar;
        private GEN.BotonesBase.btnExporExcel btnImportExcel;
        private GEN.ControlesBase.txtBase txtPath;
    }
}