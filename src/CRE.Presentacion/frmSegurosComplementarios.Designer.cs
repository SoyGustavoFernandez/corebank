namespace CRE.Presentacion
{
    partial class frmSegurosComplementarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSegurosComplementarios));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtBuscarSeguroComplementario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgSeguroComplementario = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnMiniBusqueda1 = new GEN.BotonesBase.btnMiniBusqueda(this.components);
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniNuevo1 = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.cboEstados = new GEN.ControlesBase.cboEstadoVigencia(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeguroComplementario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nombre";
            // 
            // txtBuscarSeguroComplementario
            // 
            this.txtBuscarSeguroComplementario.Location = new System.Drawing.Point(74, 18);
            this.txtBuscarSeguroComplementario.Name = "txtBuscarSeguroComplementario";
            this.txtBuscarSeguroComplementario.Size = new System.Drawing.Size(227, 20);
            this.txtBuscarSeguroComplementario.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(336, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Estado";
            // 
            // dtgSeguroComplementario
            // 
            this.dtgSeguroComplementario.AllowUserToAddRows = false;
            this.dtgSeguroComplementario.AllowUserToDeleteRows = false;
            this.dtgSeguroComplementario.AllowUserToResizeColumns = false;
            this.dtgSeguroComplementario.AllowUserToResizeRows = false;
            this.dtgSeguroComplementario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSeguroComplementario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSeguroComplementario.Location = new System.Drawing.Point(15, 58);
            this.dtgSeguroComplementario.MultiSelect = false;
            this.dtgSeguroComplementario.Name = "dtgSeguroComplementario";
            this.dtgSeguroComplementario.ReadOnly = true;
            this.dtgSeguroComplementario.RowHeadersVisible = false;
            this.dtgSeguroComplementario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSeguroComplementario.Size = new System.Drawing.Size(472, 147);
            this.dtgSeguroComplementario.TabIndex = 4;
            this.dtgSeguroComplementario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSeguroComplementario_CellContentClick);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(400, 210);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 5;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(466, 210);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnMiniBusqueda1
            // 
            this.btnMiniBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusqueda1.BackgroundImage")));
            this.btnMiniBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMiniBusqueda1.Location = new System.Drawing.Point(298, 14);
            this.btnMiniBusqueda1.Name = "btnMiniBusqueda1";
            this.btnMiniBusqueda1.Size = new System.Drawing.Size(32, 25);
            this.btnMiniBusqueda1.TabIndex = 7;
            this.btnMiniBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusqueda1.UseVisualStyleBackColor = true;
            this.btnMiniBusqueda1.Click += new System.EventHandler(this.btnMiniBusqueda1_Click);
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.Location = new System.Drawing.Point(493, 58);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 9;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = true;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditar1_Click);
            // 
            // btnMiniNuevo1
            // 
            this.btnMiniNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniNuevo1.BackgroundImage")));
            this.btnMiniNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniNuevo1.Location = new System.Drawing.Point(494, 93);
            this.btnMiniNuevo1.Name = "btnMiniNuevo1";
            this.btnMiniNuevo1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniNuevo1.TabIndex = 10;
            this.btnMiniNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniNuevo1.UseVisualStyleBackColor = true;
            this.btnMiniNuevo1.Click += new System.EventHandler(this.btnMiniNuevo1_Click);
            // 
            // cboEstados
            // 
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(400, 19);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(121, 21);
            this.cboEstados.TabIndex = 11;
            this.cboEstados.SelectedIndexChanged += new System.EventHandler(this.cboEstados_SelectedIndexChanged);
            // 
            // frmSegurosComplementarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 286);
            this.Controls.Add(this.cboEstados);
            this.Controls.Add(this.btnMiniNuevo1);
            this.Controls.Add(this.btnMiniEditar1);
            this.Controls.Add(this.btnMiniBusqueda1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.dtgSeguroComplementario);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtBuscarSeguroComplementario);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmSegurosComplementarios";
            this.Text = "Seguros Complementarios";
            this.Load += new System.EventHandler(this.frmSegurosComplementarios_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtBuscarSeguroComplementario, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtgSeguroComplementario, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnMiniBusqueda1, 0);
            this.Controls.SetChildIndex(this.btnMiniEditar1, 0);
            this.Controls.SetChildIndex(this.btnMiniNuevo1, 0);
            this.Controls.SetChildIndex(this.cboEstados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeguroComplementario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtBuscarSeguroComplementario;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgSeguroComplementario;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnMiniBusqueda btnMiniBusqueda1;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private GEN.BotonesBase.btnMiniNuevo btnMiniNuevo1;
        private GEN.ControlesBase.cboEstadoVigencia cboEstados;
    }
}