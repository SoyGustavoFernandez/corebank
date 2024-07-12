namespace CAJ.Presentacion
{
    partial class frmRegistroRemesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroRemesas));
            this.dtgListaRemesa = new GEN.ControlesBase.dtgBase(this.components);
            this.grbFiltro = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstadoRemesa = new GEN.ControlesBase.cboEstadoRemesa(this.components);
            this.cboTipoRemesa = new GEN.ControlesBase.cboTipoRemesa(this.components);
            this.txtEstablecimiento = new GEN.ControlesBase.txtBase(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnAbrirEstab = new System.Windows.Forms.Button();
            this.dtpFechaDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnRemesaTodos = new System.Windows.Forms.Button();
            this.lblFechaHasta = new GEN.ControlesBase.lblBase();
            this.lblOficinaEOB = new GEN.ControlesBase.lblBase();
            this.lblFechaDesde = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnFiltrarRemesa = new GEN.BotonesBase.btnBusqueda();
            this.btnRevisar = new GEN.BotonesBase.btnRevisar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRemesa)).BeginInit();
            this.grbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgListaRemesa
            // 
            this.dtgListaRemesa.AllowUserToAddRows = false;
            this.dtgListaRemesa.AllowUserToDeleteRows = false;
            this.dtgListaRemesa.AllowUserToResizeColumns = false;
            this.dtgListaRemesa.AllowUserToResizeRows = false;
            this.dtgListaRemesa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaRemesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaRemesa.Location = new System.Drawing.Point(12, 86);
            this.dtgListaRemesa.MultiSelect = false;
            this.dtgListaRemesa.Name = "dtgListaRemesa";
            this.dtgListaRemesa.ReadOnly = true;
            this.dtgListaRemesa.RowHeadersVisible = false;
            this.dtgListaRemesa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaRemesa.Size = new System.Drawing.Size(938, 210);
            this.dtgListaRemesa.TabIndex = 69;
            // 
            // grbFiltro
            // 
            this.grbFiltro.Controls.Add(this.cboEstadoRemesa);
            this.grbFiltro.Controls.Add(this.cboTipoRemesa);
            this.grbFiltro.Controls.Add(this.txtEstablecimiento);
            this.grbFiltro.Controls.Add(this.lblEstado);
            this.grbFiltro.Controls.Add(this.lblTipo);
            this.grbFiltro.Controls.Add(this.dtpFechaHasta);
            this.grbFiltro.Controls.Add(this.btnAbrirEstab);
            this.grbFiltro.Controls.Add(this.dtpFechaDesde);
            this.grbFiltro.Controls.Add(this.btnRemesaTodos);
            this.grbFiltro.Controls.Add(this.lblFechaHasta);
            this.grbFiltro.Controls.Add(this.lblOficinaEOB);
            this.grbFiltro.Controls.Add(this.lblFechaDesde);
            this.grbFiltro.Location = new System.Drawing.Point(12, 3);
            this.grbFiltro.Name = "grbFiltro";
            this.grbFiltro.Size = new System.Drawing.Size(817, 75);
            this.grbFiltro.TabIndex = 74;
            this.grbFiltro.TabStop = false;
            this.grbFiltro.Text = "Datos a Filtrar";
            // 
            // cboEstadoRemesa
            // 
            this.cboEstadoRemesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoRemesa.FormattingEnabled = true;
            this.cboEstadoRemesa.Location = new System.Drawing.Point(552, 46);
            this.cboEstadoRemesa.Name = "cboEstadoRemesa";
            this.cboEstadoRemesa.Size = new System.Drawing.Size(242, 21);
            this.cboEstadoRemesa.TabIndex = 75;
            // 
            // cboTipoRemesa
            // 
            this.cboTipoRemesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRemesa.FormattingEnabled = true;
            this.cboTipoRemesa.Location = new System.Drawing.Point(552, 19);
            this.cboTipoRemesa.Name = "cboTipoRemesa";
            this.cboTipoRemesa.Size = new System.Drawing.Size(242, 21);
            this.cboTipoRemesa.TabIndex = 62;
            this.cboTipoRemesa.SelectedIndexChanged += new System.EventHandler(this.cboTipoRemesa_SelectedIndexChanged);
            // 
            // txtEstablecimiento
            // 
            this.txtEstablecimiento.Location = new System.Drawing.Point(148, 19);
            this.txtEstablecimiento.Name = "txtEstablecimiento";
            this.txtEstablecimiento.ReadOnly = true;
            this.txtEstablecimiento.Size = new System.Drawing.Size(259, 20);
            this.txtEstablecimiento.TabIndex = 48;
            this.txtEstablecimiento.Text = "-* Todos *-";
            this.txtEstablecimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(494, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 60;
            this.lblEstado.Text = "Estado";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.Navy;
            this.lblTipo.Location = new System.Drawing.Point(506, 22);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 10;
            this.lblTipo.Text = "Tipo";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(275, 50);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaHasta.TabIndex = 58;
            // 
            // btnAbrirEstab
            // 
            this.btnAbrirEstab.Location = new System.Drawing.Point(115, 18);
            this.btnAbrirEstab.Name = "btnAbrirEstab";
            this.btnAbrirEstab.Size = new System.Drawing.Size(36, 22);
            this.btnAbrirEstab.TabIndex = 50;
            this.btnAbrirEstab.Text = "...";
            this.btnAbrirEstab.UseVisualStyleBackColor = true;
            this.btnAbrirEstab.Click += new System.EventHandler(this.btnAbrirEstab_Click);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(118, 50);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaDesde.TabIndex = 59;
            // 
            // btnRemesaTodos
            // 
            this.btnRemesaTodos.Location = new System.Drawing.Point(406, 18);
            this.btnRemesaTodos.Name = "btnRemesaTodos";
            this.btnRemesaTodos.Size = new System.Drawing.Size(27, 22);
            this.btnRemesaTodos.TabIndex = 49;
            this.btnRemesaTodos.Text = "X";
            this.btnRemesaTodos.UseVisualStyleBackColor = true;
            this.btnRemesaTodos.Click += new System.EventHandler(this.btnRemesaTodos_Click);
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaHasta.Location = new System.Drawing.Point(226, 54);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(43, 13);
            this.lblFechaHasta.TabIndex = 56;
            this.lblFechaHasta.Text = "hasta:";
            // 
            // lblOficinaEOB
            // 
            this.lblOficinaEOB.AutoSize = true;
            this.lblOficinaEOB.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblOficinaEOB.ForeColor = System.Drawing.Color.Navy;
            this.lblOficinaEOB.Location = new System.Drawing.Point(21, 23);
            this.lblOficinaEOB.Name = "lblOficinaEOB";
            this.lblOficinaEOB.Size = new System.Drawing.Size(88, 13);
            this.lblOficinaEOB.TabIndex = 47;
            this.lblOficinaEOB.Text = "Oficina / EOB:";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaDesde.Location = new System.Drawing.Point(29, 54);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(83, 13);
            this.lblFechaDesde.TabIndex = 57;
            this.lblFechaDesde.Text = "Fecha desde:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(757, 309);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 72;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnFiltrarRemesa
            // 
            this.btnFiltrarRemesa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiltrarRemesa.BackgroundImage")));
            this.btnFiltrarRemesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiltrarRemesa.Location = new System.Drawing.Point(835, 21);
            this.btnFiltrarRemesa.Name = "btnFiltrarRemesa";
            this.btnFiltrarRemesa.Size = new System.Drawing.Size(60, 50);
            this.btnFiltrarRemesa.TabIndex = 73;
            this.btnFiltrarRemesa.Text = "&Buscar";
            this.btnFiltrarRemesa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltrarRemesa.UseVisualStyleBackColor = true;
            this.btnFiltrarRemesa.Click += new System.EventHandler(this.btnFiltrarRemesa_Click);
            // 
            // btnRevisar
            // 
            this.btnRevisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRevisar.BackgroundImage")));
            this.btnRevisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRevisar.Location = new System.Drawing.Point(823, 309);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(60, 50);
            this.btnRevisar.TabIndex = 71;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevisar.UseVisualStyleBackColor = true;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(889, 309);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 70;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmRegistroRemesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 390);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnFiltrarRemesa);
            this.Controls.Add(this.btnRevisar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgListaRemesa);
            this.Controls.Add(this.grbFiltro);
            this.Name = "frmRegistroRemesas";
            this.Text = "Registro de Remesas";
            this.Load += new System.EventHandler(this.frmRegistroRemesas_Load);
            this.Controls.SetChildIndex(this.grbFiltro, 0);
            this.Controls.SetChildIndex(this.dtgListaRemesa, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnRevisar, 0);
            this.Controls.SetChildIndex(this.btnFiltrarRemesa, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaRemesa)).EndInit();
            this.grbFiltro.ResumeLayout(false);
            this.grbFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnBusqueda btnFiltrarRemesa;
        private GEN.BotonesBase.btnRevisar btnRevisar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtgBase dtgListaRemesa;
        private GEN.ControlesBase.grbBase grbFiltro;
        private GEN.ControlesBase.txtBase txtEstablecimiento;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTipo;
        private GEN.ControlesBase.dtpCorto dtpFechaHasta;
        private System.Windows.Forms.Button btnAbrirEstab;
        private GEN.ControlesBase.dtpCorto dtpFechaDesde;
        private System.Windows.Forms.Button btnRemesaTodos;
        private GEN.ControlesBase.lblBase lblFechaHasta;
        private GEN.ControlesBase.lblBase lblOficinaEOB;
        private GEN.ControlesBase.lblBase lblFechaDesde;
        private GEN.ControlesBase.cboTipoRemesa cboTipoRemesa;
        private GEN.ControlesBase.cboEstadoRemesa cboEstadoRemesa;
    }
}