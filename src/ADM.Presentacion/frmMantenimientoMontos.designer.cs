namespace ADM.Presentacion
{
    partial class frmMantenimientoMontos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoMontos));
            this.txtMontoMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgMontos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.CBaMas = new System.Windows.Forms.CheckBox();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.cboModulo1 = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMontos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMontoMin
            // 
            this.txtMontoMin.FormatoDecimal = false;
            this.txtMontoMin.Location = new System.Drawing.Point(99, 22);
            this.txtMontoMin.MaxLength = 12;
            this.txtMontoMin.Name = "txtMontoMin";
            this.txtMontoMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMin.nNumDecimales = 4;
            this.txtMontoMin.nvalor = 0D;
            this.txtMontoMin.Size = new System.Drawing.Size(71, 20);
            this.txtMontoMin.TabIndex = 0;
            this.txtMontoMin.Validating += new System.ComponentModel.CancelEventHandler(this.txtMontoMin_Validating);
            // 
            // txtMontoMax
            // 
            this.txtMontoMax.FormatoDecimal = false;
            this.txtMontoMax.Location = new System.Drawing.Point(365, 23);
            this.txtMontoMax.MaxLength = 12;
            this.txtMontoMax.Name = "txtMontoMax";
            this.txtMontoMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMax.nNumDecimales = 4;
            this.txtMontoMax.nvalor = 0D;
            this.txtMontoMax.Size = new System.Drawing.Size(71, 20);
            this.txtMontoMax.TabIndex = 1;
            this.txtMontoMax.Validating += new System.ComponentModel.CancelEventHandler(this.txtMontoMax_Validating);
            // 
            // dtgMontos
            // 
            this.dtgMontos.AllowUserToAddRows = false;
            this.dtgMontos.AllowUserToDeleteRows = false;
            this.dtgMontos.AllowUserToResizeColumns = false;
            this.dtgMontos.AllowUserToResizeRows = false;
            this.dtgMontos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMontos.Location = new System.Drawing.Point(13, 125);
            this.dtgMontos.MultiSelect = false;
            this.dtgMontos.Name = "dtgMontos";
            this.dtgMontos.ReadOnly = true;
            this.dtgMontos.RowHeadersVisible = false;
            this.dtgMontos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMontos.Size = new System.Drawing.Size(370, 337);
            this.dtgMontos.TabIndex = 5;
            this.dtgMontos.SelectionChanged += new System.EventHandler(this.dtgMontos_SelectionChanged);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(389, 125);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 2;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(389, 181);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 3;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(101, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Escoger Módulo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(90, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Monto Mínimo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(272, 26);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(94, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Monto Máximo:";
            // 
            // CBaMas
            // 
            this.CBaMas.AutoSize = true;
            this.CBaMas.Location = new System.Drawing.Point(365, 46);
            this.CBaMas.Name = "CBaMas";
            this.CBaMas.Size = new System.Drawing.Size(54, 17);
            this.CBaMas.TabIndex = 2;
            this.CBaMas.Text = "a más";
            this.CBaMas.UseVisualStyleBackColor = true;
            this.CBaMas.CheckedChanged += new System.EventHandler(this.CBaMas_CheckedChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(389, 474);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(257, 474);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.CBaMas);
            this.grbBase1.Controls.Add(this.txtMontoMin);
            this.grbBase1.Controls.Add(this.txtMontoMax);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(13, 42);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(446, 71);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Rango de Monto";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(191, 474);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 4;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(323, 474);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(127, 12);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(121, 21);
            this.cboModulo1.TabIndex = 8;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // frmMantenimientoMontos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 574);
            this.Controls.Add(this.cboModulo1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.dtgMontos);
            this.Name = "frmMantenimientoMontos";
            this.Text = "Mantenimiento de Montos";
            this.Load += new System.EventHandler(this.frmMantenimientoMontos_Load);
            this.Controls.SetChildIndex(this.dtgMontos, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.cboModulo1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMontos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtMontoMin;
        private GEN.ControlesBase.txtNumRea txtMontoMax;
        private GEN.ControlesBase.dtgBase dtgMontos;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.CheckBox CBaMas;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.cboBase cboModulo1;
    }
}