namespace ADM.Presentacion
{
    partial class frmMantProvisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantProvisiones));
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnConsultar1 = new GEN.BotonesBase.btnConsultar();
            this.dtgGenerica = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.cboMesBusq = new GEN.ControlesBase.cboMeses(this.components);
            this.dtgEspecifica = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtAnioBusq = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTasaGenerica = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtTasaMesGenerica = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTablaEspecif = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGenerica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEspecifica)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(258, 478);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(390, 478);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnConsultar1
            // 
            this.btnConsultar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar1.BackgroundImage")));
            this.btnConsultar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar1.Location = new System.Drawing.Point(227, 20);
            this.btnConsultar1.Name = "btnConsultar1";
            this.btnConsultar1.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar1.TabIndex = 2;
            this.btnConsultar1.Text = "&Consultar";
            this.btnConsultar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar1.UseVisualStyleBackColor = true;
            this.btnConsultar1.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // dtgGenerica
            // 
            this.dtgGenerica.AllowUserToAddRows = false;
            this.dtgGenerica.AllowUserToDeleteRows = false;
            this.dtgGenerica.AllowUserToResizeColumns = false;
            this.dtgGenerica.AllowUserToResizeRows = false;
            this.dtgGenerica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGenerica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGenerica.Location = new System.Drawing.Point(23, 39);
            this.dtgGenerica.MultiSelect = false;
            this.dtgGenerica.Name = "dtgGenerica";
            this.dtgGenerica.ReadOnly = true;
            this.dtgGenerica.RowHeadersVisible = false;
            this.dtgGenerica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGenerica.Size = new System.Drawing.Size(222, 111);
            this.dtgGenerica.TabIndex = 7;
            this.dtgGenerica.SelectionChanged += new System.EventHandler(this.dtgGenerica_SelectionChanged);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(192, 478);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // cboMesBusq
            // 
            this.cboMesBusq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesBusq.FormattingEnabled = true;
            this.cboMesBusq.Location = new System.Drawing.Point(70, 49);
            this.cboMesBusq.Name = "cboMesBusq";
            this.cboMesBusq.Size = new System.Drawing.Size(121, 21);
            this.cboMesBusq.TabIndex = 1;
            // 
            // dtgEspecifica
            // 
            this.dtgEspecifica.AllowUserToAddRows = false;
            this.dtgEspecifica.AllowUserToDeleteRows = false;
            this.dtgEspecifica.AllowUserToResizeColumns = false;
            this.dtgEspecifica.AllowUserToResizeRows = false;
            this.dtgEspecifica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEspecifica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEspecifica.Location = new System.Drawing.Point(23, 37);
            this.dtgEspecifica.MultiSelect = false;
            this.dtgEspecifica.Name = "dtgEspecifica";
            this.dtgEspecifica.ReadOnly = true;
            this.dtgEspecifica.RowHeadersVisible = false;
            this.dtgEspecifica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEspecifica.Size = new System.Drawing.Size(393, 111);
            this.dtgEspecifica.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Mes:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(25, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Año:";
            // 
            // txtAnioBusq
            // 
            this.txtAnioBusq.Location = new System.Drawing.Point(70, 20);
            this.txtAnioBusq.MaxLength = 4;
            this.txtAnioBusq.Name = "txtAnioBusq";
            this.txtAnioBusq.Size = new System.Drawing.Size(67, 20);
            this.txtAnioBusq.TabIndex = 0;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboMesBusq);
            this.grbBase1.Controls.Add(this.txtAnioBusq);
            this.grbBase1.Controls.Add(this.btnConsultar1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 9);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(305, 80);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de búsqueda";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(258, 47);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(95, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Tasa Provisión:";
            // 
            // txtTasaGenerica
            // 
            this.txtTasaGenerica.FormatoDecimal = false;
            this.txtTasaGenerica.Location = new System.Drawing.Point(354, 44);
            this.txtTasaGenerica.Name = "txtTasaGenerica";
            this.txtTasaGenerica.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaGenerica.nNumDecimales = 4;
            this.txtTasaGenerica.nvalor = 0D;
            this.txtTasaGenerica.Size = new System.Drawing.Size(43, 20);
            this.txtTasaGenerica.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(258, 82);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(86, 13);
            this.lblBase6.TabIndex = 4;
            this.lblBase6.Text = "Tasa del Mes:";
            // 
            // txtTasaMesGenerica
            // 
            this.txtTasaMesGenerica.FormatoDecimal = false;
            this.txtTasaMesGenerica.Location = new System.Drawing.Point(354, 79);
            this.txtTasaMesGenerica.Name = "txtTasaMesGenerica";
            this.txtTasaMesGenerica.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMesGenerica.nNumDecimales = 4;
            this.txtTasaMesGenerica.nvalor = 0D;
            this.txtTasaMesGenerica.Size = new System.Drawing.Size(43, 20);
            this.txtTasaMesGenerica.TabIndex = 1;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(399, 47);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(19, 13);
            this.lblBase7.TabIndex = 5;
            this.lblBase7.Text = "%";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(399, 82);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(19, 13);
            this.lblBase8.TabIndex = 6;
            this.lblBase8.Text = "%";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.dtgGenerica);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.txtTasaGenerica);
            this.grbBase2.Controls.Add(this.txtTasaMesGenerica);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Location = new System.Drawing.Point(12, 94);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(437, 164);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            // 
            // lblBase11
            // 
            this.lblBase11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(0, 7);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(437, 19);
            this.lblBase11.TabIndex = 2;
            this.lblBase11.Text = "PROVISIÓN GENÉRICA";
            this.lblBase11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.cboTablaEspecif);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.dtgEspecifica);
            this.grbBase3.Location = new System.Drawing.Point(12, 270);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(437, 202);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            // 
            // lblBase3
            // 
            this.lblBase3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(0, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(437, 19);
            this.lblBase3.TabIndex = 1;
            this.lblBase3.Text = "PROVISIÓN ESPECÍFICA";
            this.lblBase3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboTablaEspecif
            // 
            this.cboTablaEspecif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTablaEspecif.FormattingEnabled = true;
            this.cboTablaEspecif.Location = new System.Drawing.Point(108, 165);
            this.cboTablaEspecif.Name = "cboTablaEspecif";
            this.cboTablaEspecif.Size = new System.Drawing.Size(137, 21);
            this.cboTablaEspecif.TabIndex = 0;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(20, 168);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(82, 13);
            this.lblBase9.TabIndex = 3;
            this.lblBase9.Text = "Tabla Activa:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(324, 478);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmMantProvisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 557);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmMantProvisiones";
            this.Text = "Mantenimiento Tasas de Provisiones";
            this.Load += new System.EventHandler(this.frmMantProvisiones_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGenerica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEspecifica)).EndInit();
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

        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnConsultar btnConsultar1;
        private GEN.ControlesBase.dtgBase dtgGenerica;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.cboMeses cboMesBusq;
        private GEN.ControlesBase.dtgBase dtgEspecifica;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAnioBusq;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtTasaGenerica;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtTasaMesGenerica;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboBase cboTablaEspecif;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}