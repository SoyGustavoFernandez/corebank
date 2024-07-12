namespace CAJ.Presentacion
{
    partial class frmManCajaChica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManCajaChica));
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.txtNomCajChi = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMonMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboEstCajChica = new GEN.ControlesBase.cboBase(this.components);
            this.dtgLisCajChi = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMonCpg = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.conBusCol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisCajChi)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 13);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(78, 10);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(220, 21);
            this.cboAgencias.TabIndex = 1;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // txtNomCajChi
            // 
            this.txtNomCajChi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCajChi.Enabled = false;
            this.txtNomCajChi.Location = new System.Drawing.Point(437, 11);
            this.txtNomCajChi.MaxLength = 200;
            this.txtNomCajChi.Name = "txtNomCajChi";
            this.txtNomCajChi.Size = new System.Drawing.Size(286, 20);
            this.txtNomCajChi.TabIndex = 3;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(310, 14);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(124, 13);
            this.lblBase7.TabIndex = 2;
            this.lblBase7.Text = "Nombre Caja Chica:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(78, 13);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(220, 21);
            this.cboMoneda.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Moneda:";
            // 
            // txtMonMax
            // 
            this.txtMonMax.FormatoDecimal = false;
            this.txtMonMax.Location = new System.Drawing.Point(164, 64);
            this.txtMonMax.MaxLength = 10;
            this.txtMonMax.Name = "txtMonMax";
            this.txtMonMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonMax.nNumDecimales = 2;
            this.txtMonMax.nvalor = 0D;
            this.txtMonMax.Size = new System.Drawing.Size(134, 20);
            this.txtMonMax.TabIndex = 2;
            this.txtMonMax.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 67);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 4;
            this.lblBase6.Text = "Monto Fondo Fijo:";
            // 
            // conBusCol
            // 
            this.conBusCol.Controls.Add(this.grbBase1);
            this.conBusCol.Location = new System.Drawing.Point(331, 56);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(398, 87);
            this.conBusCol.TabIndex = 3;
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(387, 86);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Colaborador";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Estado:";
            // 
            // cboEstCajChica
            // 
            this.cboEstCajChica.Enabled = false;
            this.cboEstCajChica.FormattingEnabled = true;
            this.cboEstCajChica.Location = new System.Drawing.Point(78, 39);
            this.cboEstCajChica.Name = "cboEstCajChica";
            this.cboEstCajChica.Size = new System.Drawing.Size(220, 21);
            this.cboEstCajChica.TabIndex = 1;
            // 
            // dtgLisCajChi
            // 
            this.dtgLisCajChi.AllowUserToAddRows = false;
            this.dtgLisCajChi.AllowUserToDeleteRows = false;
            this.dtgLisCajChi.AllowUserToResizeColumns = false;
            this.dtgLisCajChi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgLisCajChi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgLisCajChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLisCajChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLisCajChi.Location = new System.Drawing.Point(6, 157);
            this.dtgLisCajChi.MultiSelect = false;
            this.dtgLisCajChi.Name = "dtgLisCajChi";
            this.dtgLisCajChi.ReadOnly = true;
            this.dtgLisCajChi.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dtgLisCajChi.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgLisCajChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLisCajChi.Size = new System.Drawing.Size(729, 145);
            this.dtgLisCajChi.TabIndex = 3;
            this.dtgLisCajChi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLisCajChi_CellContentClick);
            this.dtgLisCajChi.SelectionChanged += new System.EventHandler(this.dtgLisCajChi_SelectionChanged);
            this.dtgLisCajChi.Click += new System.EventHandler(this.dtgLisCajChi_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(370, 308);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(675, 308);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(492, 308);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(553, 308);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(431, 308);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grbBase2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(327, 38);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(408, 110);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Responsable de Caja Chica";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboAgencias);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.txtNomCajChi);
            this.grbBase3.Location = new System.Drawing.Point(6, -3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(729, 37);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.txtMonCpg);
            this.grbBase4.Controls.Add(this.lblBase3);
            this.grbBase4.Controls.Add(this.lblBase1);
            this.grbBase4.Controls.Add(this.cboMoneda);
            this.grbBase4.Controls.Add(this.lblBase6);
            this.grbBase4.Controls.Add(this.txtMonMax);
            this.grbBase4.Controls.Add(this.lblBase2);
            this.grbBase4.Controls.Add(this.cboEstCajChica);
            this.grbBase4.Location = new System.Drawing.Point(6, 33);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(315, 118);
            this.grbBase4.TabIndex = 1;
            this.grbBase4.TabStop = false;
            // 
            // txtMonCpg
            // 
            this.txtMonCpg.FormatoDecimal = false;
            this.txtMonCpg.Location = new System.Drawing.Point(164, 90);
            this.txtMonCpg.MaxLength = 10;
            this.txtMonCpg.Name = "txtMonCpg";
            this.txtMonCpg.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonCpg.nNumDecimales = 2;
            this.txtMonCpg.nvalor = 0D;
            this.txtMonCpg.Size = new System.Drawing.Size(134, 20);
            this.txtMonCpg.TabIndex = 3;
            this.txtMonCpg.Text = "0.00";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 94);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(146, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Monto Máximo por CPG:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(614, 308);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmManCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 386);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgLisCajChi);
            this.Controls.Add(this.conBusCol);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase4);
            this.Name = "frmManCajaChica";
            this.Text = "Mantenimiento de Fondo Fijo";
            this.Load += new System.EventHandler(this.frmManCajaChica_Load);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.conBusCol, 0);
            this.Controls.SetChildIndex(this.dtgLisCajChi, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.conBusCol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisCajChi)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.txtBase txtNomCajChi;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboEstCajChica;
        private GEN.ControlesBase.dtgBase dtgLisCajChi;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.txtNumRea txtMonCpg;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMonMax;
        private GEN.BotonesBase.btnEliminar btnEliminar;
    }
}