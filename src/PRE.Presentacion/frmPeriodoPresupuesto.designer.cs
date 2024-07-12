namespace PRE.Presentacion
{
    partial class frmPeriodoPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeriodoPresupuesto));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtAnioPeriodo = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboEstadoPeriodoPresupuesto1 = new GEN.ControlesBase.cboEstadoPeriodoPresupuesto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgPeriodos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtAnioPeriodo);
            this.grbBase1.Controls.Add(this.cboEstadoPeriodoPresupuesto1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(11, 236);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(324, 80);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalles de Periodo";
            // 
            // txtAnioPeriodo
            // 
            this.txtAnioPeriodo.FormatoDecimal = false;
            this.txtAnioPeriodo.Location = new System.Drawing.Point(75, 17);
            this.txtAnioPeriodo.Name = "txtAnioPeriodo";
            this.txtAnioPeriodo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAnioPeriodo.nNumDecimales = 4;
            this.txtAnioPeriodo.nvalor = 0D;
            this.txtAnioPeriodo.Size = new System.Drawing.Size(100, 20);
            this.txtAnioPeriodo.TabIndex = 5;
            // 
            // cboEstadoPeriodoPresupuesto1
            // 
            this.cboEstadoPeriodoPresupuesto1.FormattingEnabled = true;
            this.cboEstadoPeriodoPresupuesto1.Location = new System.Drawing.Point(75, 44);
            this.cboEstadoPeriodoPresupuesto1.Name = "cboEstadoPeriodoPresupuesto1";
            this.cboEstadoPeriodoPresupuesto1.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoPeriodoPresupuesto1.TabIndex = 4;
            this.cboEstadoPeriodoPresupuesto1.SelectionChangeCommitted += new System.EventHandler(this.cboEstadoPeriodoPresupuesto1_SelectionChangeCommitted);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(18, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Estado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(18, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Año:";
            // 
            // dtgPeriodos
            // 
            this.dtgPeriodos.AllowUserToAddRows = false;
            this.dtgPeriodos.AllowUserToDeleteRows = false;
            this.dtgPeriodos.AllowUserToResizeColumns = false;
            this.dtgPeriodos.AllowUserToResizeRows = false;
            this.dtgPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPeriodos.Location = new System.Drawing.Point(11, 40);
            this.dtgPeriodos.MultiSelect = false;
            this.dtgPeriodos.Name = "dtgPeriodos";
            this.dtgPeriodos.ReadOnly = true;
            this.dtgPeriodos.RowHeadersVisible = false;
            this.dtgPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPeriodos.Size = new System.Drawing.Size(324, 190);
            this.dtgPeriodos.TabIndex = 3;
            this.dtgPeriodos.SelectionChanged += new System.EventHandler(this.dtgPeriodos_SelectionChanged);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(11, 337);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 4;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = false;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(209, 337);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = false;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(143, 337);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = false;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(275, 337);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = false;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(77, 337);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 6;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = false;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // frmPeriodoPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 412);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.dtgPeriodos);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmPeriodoPresupuesto";
            this.Text = "Periodos Presupuestales";
            this.Load += new System.EventHandler(this.frmPeriodoPresupuesto_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgPeriodos, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgPeriodos;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboEstadoPeriodoPresupuesto cboEstadoPeriodoPresupuesto1;
        private GEN.ControlesBase.txtNumRea txtAnioPeriodo;
        private GEN.BotonesBase.btnEditar btnEditar1;
    }
}