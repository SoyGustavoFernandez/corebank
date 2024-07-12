namespace RCP.Presentacion
{
    partial class frmSeleccionarHojaRuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarHojaRuta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.chbTodos = new System.Windows.Forms.CheckBox();
            this.dtpHasta = new GEN.ControlesBase.DatePicker();
            this.dtpDesde = new GEN.ControlesBase.DatePicker();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.idHojaRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomGestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoHojaRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCreditos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMiniBusq1);
            this.groupBox1.Controls.Add(this.chbTodos);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(588, 12);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 3;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // chbTodos
            // 
            this.chbTodos.AutoSize = true;
            this.chbTodos.Location = new System.Drawing.Point(526, 20);
            this.chbTodos.Name = "chbTodos";
            this.chbTodos.Size = new System.Drawing.Size(56, 17);
            this.chbTodos.TabIndex = 0;
            this.chbTodos.Text = "Todos";
            this.chbTodos.UseVisualStyleBackColor = true;
            this.chbTodos.CheckedChanged += new System.EventHandler(this.chbTodos_CheckedChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(307, 17);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.Value = new System.DateTime(2015, 8, 5, 16, 1, 55, 113);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(65, 17);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.Value = new System.DateTime(2015, 8, 5, 16, 1, 55, 113);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(281, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(20, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "A:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgCreditos);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hoja de rutas";
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idHojaRuta,
            this.cNomGestor,
            this.dFechaInicio,
            this.dFechaFin,
            this.idEstado,
            this.cEstadoHojaRuta,
            this.nCreditos});
            this.dtgCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(627, 161);
            this.dtgCreditos.TabIndex = 0;
            // 
            // idHojaRuta
            // 
            this.idHojaRuta.DataPropertyName = "idHojaRuta";
            this.idHojaRuta.HeaderText = "idHojaRuta";
            this.idHojaRuta.Name = "idHojaRuta";
            this.idHojaRuta.ReadOnly = true;
            this.idHojaRuta.Visible = false;
            // 
            // cNomGestor
            // 
            this.cNomGestor.DataPropertyName = "cNomGestor";
            this.cNomGestor.FillWeight = 40F;
            this.cNomGestor.HeaderText = "Nombre gestor";
            this.cNomGestor.Name = "cNomGestor";
            this.cNomGestor.ReadOnly = true;
            // 
            // dFechaInicio
            // 
            this.dFechaInicio.DataPropertyName = "dFechaInicio";
            this.dFechaInicio.FillWeight = 15F;
            this.dFechaInicio.HeaderText = "Fecha Inicio";
            this.dFechaInicio.Name = "dFechaInicio";
            this.dFechaInicio.ReadOnly = true;
            // 
            // dFechaFin
            // 
            this.dFechaFin.DataPropertyName = "dFechaFin";
            this.dFechaFin.FillWeight = 15F;
            this.dFechaFin.HeaderText = "Fecha Fin";
            this.dFechaFin.Name = "dFechaFin";
            this.dFechaFin.ReadOnly = true;
            // 
            // idEstado
            // 
            this.idEstado.DataPropertyName = "idEstado";
            this.idEstado.FillWeight = 15F;
            this.idEstado.HeaderText = "idEstado";
            this.idEstado.Name = "idEstado";
            this.idEstado.ReadOnly = true;
            this.idEstado.Visible = false;
            // 
            // cEstadoHojaRuta
            // 
            this.cEstadoHojaRuta.DataPropertyName = "cEstadoHojaRuta";
            this.cEstadoHojaRuta.FillWeight = 15F;
            this.cEstadoHojaRuta.HeaderText = "Estado";
            this.cEstadoHojaRuta.Name = "cEstadoHojaRuta";
            this.cEstadoHojaRuta.ReadOnly = true;
            // 
            // nCreditos
            // 
            this.nCreditos.DataPropertyName = "nCreditos";
            this.nCreditos.FillWeight = 10F;
            this.nCreditos.HeaderText = "Creditos";
            this.nCreditos.Name = "nCreditos";
            this.nCreditos.ReadOnly = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(516, 253);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(582, 253);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmSeleccionarHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 345);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSeleccionarHojaRuta";
            this.Text = "Seleccionar Hoja Ruta";
            this.Load += new System.EventHandler(this.frmSeleccionarHojaRuta_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbTodos;
        private GEN.ControlesBase.DatePicker dtpHasta;
        private GEN.ControlesBase.DatePicker dtpDesde;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHojaRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomGestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoHojaRuta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCreditos;
    }
}