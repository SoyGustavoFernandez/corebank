namespace ADM.Presentacion
{
    partial class frmMantenimientoTipoZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTipoZona));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnBajar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodSunat = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtId = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboSector1 = new GEN.ControlesBase.cboSector(this.components);
            this.rbtActivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnInactivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgTipoZona = new System.Windows.Forms.DataGridView();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoZona)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(208, 511);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 11;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(268, 511);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(328, 511);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(88, 511);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 8;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(388, 511);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnSubir
            // 
            this.btnSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubir.ImageKey = "(none)";
            this.btnSubir.Location = new System.Drawing.Point(438, 19);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(31, 42);
            this.btnSubir.TabIndex = 13;
            this.btnSubir.Text = "↑";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnBajar
            // 
            this.btnBajar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajar.ImageKey = "(none)";
            this.btnBajar.Location = new System.Drawing.Point(438, 63);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.Size = new System.Drawing.Size(31, 42);
            this.btnBajar.TabIndex = 14;
            this.btnBajar.Text = "↓";
            this.btnBajar.UseVisualStyleBackColor = true;
            this.btnBajar.Click += new System.EventHandler(this.btnBajar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtCodSunat);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.cboSector1);
            this.groupBox1.Controls.Add(this.rbtActivo);
            this.groupBox1.Controls.Add(this.rbtnInactivo);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.btnBajar);
            this.groupBox1.Controls.Add(this.btnSubir);
            this.groupBox1.Controls.Add(this.dtgTipoZona);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 493);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Zona";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(105, 403);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(331, 20);
            this.txtDescripcion.TabIndex = 168;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtCodSunat
            // 
            this.txtCodSunat.Enabled = false;
            this.txtCodSunat.Location = new System.Drawing.Point(391, 429);
            this.txtCodSunat.MaxLength = 2;
            this.txtCodSunat.Name = "txtCodSunat";
            this.txtCodSunat.Size = new System.Drawing.Size(45, 20);
            this.txtCodSunat.TabIndex = 165;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(104, 403);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(38, 20);
            this.txtId.TabIndex = 163;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(294, 432);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(89, 13);
            this.lblBase3.TabIndex = 161;
            this.lblBase3.Text = "Código Sunat:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(49, 432);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 159;
            this.lblBase2.Text = "Sector:";
            // 
            // cboSector1
            // 
            this.cboSector1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSector1.Enabled = false;
            this.cboSector1.FormattingEnabled = true;
            this.cboSector1.Location = new System.Drawing.Point(104, 429);
            this.cboSector1.Name = "cboSector1";
            this.cboSector1.Size = new System.Drawing.Size(184, 21);
            this.cboSector1.TabIndex = 158;
            // 
            // rbtActivo
            // 
            this.rbtActivo.AutoSize = true;
            this.rbtActivo.Enabled = false;
            this.rbtActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtActivo.ForeColor = System.Drawing.Color.Navy;
            this.rbtActivo.Location = new System.Drawing.Point(102, 460);
            this.rbtActivo.Name = "rbtActivo";
            this.rbtActivo.Size = new System.Drawing.Size(55, 17);
            this.rbtActivo.TabIndex = 17;
            this.rbtActivo.TabStop = true;
            this.rbtActivo.Text = "Activo";
            this.rbtActivo.UseVisualStyleBackColor = true;
            // 
            // rbtnInactivo
            // 
            this.rbtnInactivo.AutoSize = true;
            this.rbtnInactivo.Enabled = false;
            this.rbtnInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnInactivo.ForeColor = System.Drawing.Color.Navy;
            this.rbtnInactivo.Location = new System.Drawing.Point(163, 460);
            this.rbtnInactivo.Name = "rbtnInactivo";
            this.rbtnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbtnInactivo.TabIndex = 18;
            this.rbtnInactivo.TabStop = true;
            this.rbtnInactivo.Text = "Inactivo";
            this.rbtnInactivo.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(48, 462);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 19;
            this.lblBase4.Text = "Estado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(58, 406);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(41, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Zona:";
            // 
            // dtgTipoZona
            // 
            this.dtgTipoZona.AllowUserToAddRows = false;
            this.dtgTipoZona.AllowUserToDeleteRows = false;
            this.dtgTipoZona.AllowUserToResizeColumns = false;
            this.dtgTipoZona.AllowUserToResizeRows = false;
            this.dtgTipoZona.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgTipoZona.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTipoZona.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTipoZona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTipoZona.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTipoZona.Location = new System.Drawing.Point(19, 19);
            this.dtgTipoZona.MultiSelect = false;
            this.dtgTipoZona.Name = "dtgTipoZona";
            this.dtgTipoZona.ReadOnly = true;
            this.dtgTipoZona.RowHeadersVisible = false;
            this.dtgTipoZona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoZona.Size = new System.Drawing.Size(415, 378);
            this.dtgTipoZona.TabIndex = 157;
            this.dtgTipoZona.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTipoZona_CellClick);
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(148, 511);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 23;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // frmMantenimientoTipoZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 598);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMantenimientoTipoZona";
            this.Text = "Mantenimiento de Zona";
            this.Load += new System.EventHandler(this.frmMantenimientoTipoZona_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoZona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnBajar;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.rbtnBase rbtActivo;
        private GEN.ControlesBase.rbtnBase rbtnInactivo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.DataGridView dtgTipoZona;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboSector cboSector1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtId;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodSunat;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
    }
}