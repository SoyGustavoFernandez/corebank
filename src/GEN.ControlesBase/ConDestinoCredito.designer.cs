namespace GEN.ControlesBase
{
    partial class ConDestinoCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConDestinoCredito));
            this.bindingDestCredProp = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblBaseCustom2 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtActivoAdquirir = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotalPorcentaje = new GEN.ControlesBase.txtBase(this.components);
            this.lblBaseCustom22 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgDestCredProp = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalMonto = new System.Windows.Forms.TextBox();
            this.btnNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.txtPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom19 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom17 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtPorcentajeMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipDestCredDetalle = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipDestCred = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingDestCredProp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDestCredProp)).BeginInit();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentaje)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.panel8);
            this.grbBase1.Controls.Add(this.btnNuevo);
            this.grbBase1.Controls.Add(this.txtPorcentaje);
            this.grbBase1.Controls.Add(this.lblBaseCustom1);
            this.grbBase1.Controls.Add(this.lblBaseCustom19);
            this.grbBase1.Controls.Add(this.lblBaseCustom17);
            this.grbBase1.Controls.Add(this.txtPorcentajeMonto);
            this.grbBase1.Controls.Add(this.cboTipDestCredDetalle);
            this.grbBase1.Controls.Add(this.cboTipDestCred);
            this.grbBase1.Location = new System.Drawing.Point(3, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(478, 235);
            this.grbBase1.TabIndex = 87;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Destino del Crédito";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblBaseCustom2);
            this.panel8.Controls.Add(this.txtActivoAdquirir);
            this.panel8.Controls.Add(this.txtTotalPorcentaje);
            this.panel8.Controls.Add(this.lblBaseCustom22);
            this.panel8.Controls.Add(this.panel1);
            this.panel8.Controls.Add(this.txtTotalMonto);
            this.panel8.Location = new System.Drawing.Point(3, 57);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(472, 171);
            this.panel8.TabIndex = 88;
            // 
            // lblBaseCustom2
            // 
            this.lblBaseCustom2.AutoSize = true;
            this.lblBaseCustom2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom2.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom2.Location = new System.Drawing.Point(244, 153);
            this.lblBaseCustom2.Name = "lblBaseCustom2";
            this.lblBaseCustom2.Size = new System.Drawing.Size(156, 13);
            this.lblBaseCustom2.TabIndex = 93;
            this.lblBaseCustom2.Text = "Valor de activo a adquirir:";
            // 
            // txtActivoAdquirir
            // 
            this.txtActivoAdquirir.FormatoDecimal = false;
            this.txtActivoAdquirir.Location = new System.Drawing.Point(402, 149);
            this.txtActivoAdquirir.Name = "txtActivoAdquirir";
            this.txtActivoAdquirir.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtActivoAdquirir.nNumDecimales = 2;
            this.txtActivoAdquirir.nvalor = 0D;
            this.txtActivoAdquirir.Size = new System.Drawing.Size(70, 20);
            this.txtActivoAdquirir.TabIndex = 92;
            this.txtActivoAdquirir.Text = "0";
            this.txtActivoAdquirir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPorcentaje
            // 
            this.txtTotalPorcentaje.Enabled = false;
            this.txtTotalPorcentaje.Location = new System.Drawing.Point(118, 149);
            this.txtTotalPorcentaje.Name = "txtTotalPorcentaje";
            this.txtTotalPorcentaje.Size = new System.Drawing.Size(50, 20);
            this.txtTotalPorcentaje.TabIndex = 7;
            this.txtTotalPorcentaje.TabStop = false;
            this.txtTotalPorcentaje.Text = "0";
            this.txtTotalPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBaseCustom22
            // 
            this.lblBaseCustom22.AutoSize = true;
            this.lblBaseCustom22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom22.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom22.Location = new System.Drawing.Point(83, 153);
            this.lblBaseCustom22.Name = "lblBaseCustom22";
            this.lblBaseCustom22.Size = new System.Drawing.Size(34, 13);
            this.lblBaseCustom22.TabIndex = 91;
            this.lblBaseCustom22.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 147);
            this.panel1.TabIndex = 78;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(470, 145);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgDestCredProp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 121);
            this.panel3.TabIndex = 25;
            // 
            // dtgDestCredProp
            // 
            this.dtgDestCredProp.AllowUserToAddRows = false;
            this.dtgDestCredProp.AllowUserToDeleteRows = false;
            this.dtgDestCredProp.AllowUserToResizeColumns = false;
            this.dtgDestCredProp.AllowUserToResizeRows = false;
            this.dtgDestCredProp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDestCredProp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgDestCredProp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDestCredProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDestCredProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDestCredProp.Location = new System.Drawing.Point(0, 0);
            this.dtgDestCredProp.MultiSelect = false;
            this.dtgDestCredProp.Name = "dtgDestCredProp";
            this.dtgDestCredProp.RowHeadersVisible = false;
            this.dtgDestCredProp.Size = new System.Drawing.Size(470, 121);
            this.dtgDestCredProp.TabIndex = 10;
            this.dtgDestCredProp.TabStop = false;
            this.dtgDestCredProp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDestCredProp_CellClick);
            this.dtgDestCredProp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDestCredProp_CellDoubleClick);
            this.dtgDestCredProp.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dtgDestCredProp_RowPrePaint);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.menuStrip1);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(470, 24);
            this.panel7.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCancelar,
            this.tsmQuitar,
            this.tsmAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(270, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmCancelar
            // 
            this.tsmCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmCancelar.Enabled = false;
            this.tsmCancelar.Image = global::GEN.ControlesBase.Properties.Resources.delete;
            this.tsmCancelar.Name = "tsmCancelar";
            this.tsmCancelar.Size = new System.Drawing.Size(28, 20);
            this.tsmCancelar.Text = "tsmCancelar";
            this.tsmCancelar.ToolTipText = "Cancelar edición.";
            this.tsmCancelar.Click += new System.EventHandler(this.tsmCancelar_Click);
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.Checked = true;
            this.tsmQuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Image = global::GEN.ControlesBase.Properties.Resources.btn_quitar;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(28, 20);
            this.tsmQuitar.Text = "Quitar";
            this.tsmQuitar.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitar.Click += new System.EventHandler(this.tsmQuitar_Click);
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Enabled = false;
            this.tsmAgregar.Image = global::GEN.ControlesBase.Properties.Resources.btn_agregar;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(28, 20);
            this.tsmAgregar.Text = "Agregar";
            this.tsmAgregar.ToolTipText = "Agregar registro del formulario.";
            this.tsmAgregar.Click += new System.EventHandler(this.tsmAgregar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Destinos de Crédito";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalMonto
            // 
            this.txtTotalMonto.Enabled = false;
            this.txtTotalMonto.Location = new System.Drawing.Point(167, 149);
            this.txtTotalMonto.Name = "txtTotalMonto";
            this.txtTotalMonto.Size = new System.Drawing.Size(70, 20);
            this.txtTotalMonto.TabIndex = 8;
            this.txtTotalMonto.TabStop = false;
            this.txtTotalMonto.Text = "0";
            this.txtTotalMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(439, 25);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtPorcentaje
            // 
            this.errorProvider.SetIconPadding(this.txtPorcentaje, -20);
            this.txtPorcentaje.Location = new System.Drawing.Point(118, 33);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(50, 20);
            this.txtPorcentaje.TabIndex = 2;
            this.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPorcentaje.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPorcentaje_DragEnter);
            this.txtPorcentaje.Leave += new System.EventHandler(this.txtPorcentaje_Leave);
            this.txtPorcentaje.Validating += new System.ComponentModel.CancelEventHandler(this.txtPorcentaje_Validating);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(126, 18);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(19, 13);
            this.lblBaseCustom1.TabIndex = 92;
            this.lblBaseCustom1.Text = "%";
            // 
            // lblBaseCustom19
            // 
            this.lblBaseCustom19.AutoSize = true;
            this.lblBaseCustom19.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom19.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom19.Location = new System.Drawing.Point(245, 17);
            this.lblBaseCustom19.Name = "lblBaseCustom19";
            this.lblBaseCustom19.Size = new System.Drawing.Size(179, 13);
            this.lblBaseCustom19.TabIndex = 91;
            this.lblBaseCustom19.Text = "Detalle del Destino de Crédito";
            // 
            // lblBaseCustom17
            // 
            this.lblBaseCustom17.AutoSize = true;
            this.lblBaseCustom17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom17.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom17.Location = new System.Drawing.Point(1, 17);
            this.lblBaseCustom17.Name = "lblBaseCustom17";
            this.lblBaseCustom17.Size = new System.Drawing.Size(117, 13);
            this.lblBaseCustom17.TabIndex = 90;
            this.lblBaseCustom17.Text = "Destino del Crédito";
            // 
            // txtPorcentajeMonto
            // 
            this.txtPorcentajeMonto.Enabled = false;
            this.txtPorcentajeMonto.FormatoDecimal = false;
            this.txtPorcentajeMonto.Location = new System.Drawing.Point(167, 33);
            this.txtPorcentajeMonto.Name = "txtPorcentajeMonto";
            this.txtPorcentajeMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcentajeMonto.nNumDecimales = 2;
            this.txtPorcentajeMonto.nvalor = 0D;
            this.txtPorcentajeMonto.Size = new System.Drawing.Size(70, 20);
            this.txtPorcentajeMonto.TabIndex = 3;
            this.txtPorcentajeMonto.Text = "0";
            this.txtPorcentajeMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcentajeMonto.Leave += new System.EventHandler(this.txtPorcentaje_Leave);
            // 
            // cboTipDestCredDetalle
            // 
            this.cboTipDestCredDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDestCredDetalle.DropDownWidth = 365;
            this.cboTipDestCredDetalle.Enabled = false;
            this.cboTipDestCredDetalle.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboTipDestCredDetalle, -20);
            this.cboTipDestCredDetalle.IntegralHeight = false;
            this.cboTipDestCredDetalle.Location = new System.Drawing.Point(239, 32);
            this.cboTipDestCredDetalle.MaxDropDownItems = 11;
            this.cboTipDestCredDetalle.Name = "cboTipDestCredDetalle";
            this.cboTipDestCredDetalle.Size = new System.Drawing.Size(194, 21);
            this.cboTipDestCredDetalle.TabIndex = 4;
            this.cboTipDestCredDetalle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTipDestCredDetalle_KeyUp);
            this.cboTipDestCredDetalle.Validating += new System.ComponentModel.CancelEventHandler(this.cboTipDestCredDetalle_Validating);
            // 
            // cboTipDestCred
            // 
            this.cboTipDestCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDestCred.DropDownWidth = 150;
            this.cboTipDestCred.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboTipDestCred, -20);
            this.cboTipDestCred.Location = new System.Drawing.Point(3, 32);
            this.cboTipDestCred.Name = "cboTipDestCred";
            this.cboTipDestCred.Size = new System.Drawing.Size(113, 21);
            this.cboTipDestCred.TabIndex = 1;
            this.cboTipDestCred.SelectedIndexChanged += new System.EventHandler(this.cboTipDestCred_SelectedIndexChanged);
            this.cboTipDestCred.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTipDestCred_KeyUp);
            this.cboTipDestCred.Validated += new System.EventHandler(this.cboTipDestCred_Validated);
            // 
            // ConDestinoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbBase1);
            this.Name = "ConDestinoCredito";
            this.Size = new System.Drawing.Size(484, 240);
            ((System.ComponentModel.ISupportInitialize)(this.bindingDestCredProp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDestCredProp)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentaje)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        //private GEN.ControlesBase.cboBase cboTipDestCred;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom22;
        //private GEN.ControlesBase.cboBase cboTipDestCredDetalle;
        private System.Windows.Forms.BindingSource bindingDestCredProp;
        private System.Windows.Forms.TextBox txtTotalMonto;
        private GEN.ControlesBase.txtNumRea txtPorcentajeMonto;
        private GEN.ControlesBase.cboBase cboTipDestCredDetalle;
        private GEN.ControlesBase.cboBase cboTipDestCred;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom19;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom17;
        private GEN.ControlesBase.txtBase txtTotalPorcentaje;
        private System.Windows.Forms.NumericUpDown txtPorcentaje;
        private GEN.BotonesBase.btnMiniNuevo btnNuevo;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgDestCredProp;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelar;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private txtNumRea txtActivoAdquirir;
        private lblBaseCustom lblBaseCustom2;
    }
}
