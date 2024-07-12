namespace LOG.Presentacion
{
    partial class frmMantenimientoTipoDocProAdqui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoTipoDocProAdqui));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.dtgTipoDocProAdqui = new GEN.ControlesBase.dtgBase(this.components);
            this.txtTipoDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.dtgtxtIdTipoDocProAdqui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoDocProAdqui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgchcVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoDocProAdqui)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(496, 227);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(246, 227);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(307, 227);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(368, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(429, 227);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dtgTipoDocProAdqui
            // 
            this.dtgTipoDocProAdqui.AllowUserToAddRows = false;
            this.dtgTipoDocProAdqui.AllowUserToDeleteRows = false;
            this.dtgTipoDocProAdqui.AllowUserToResizeColumns = false;
            this.dtgTipoDocProAdqui.AllowUserToResizeRows = false;
            this.dtgTipoDocProAdqui.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTipoDocProAdqui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTipoDocProAdqui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoDocProAdqui.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdTipoDocProAdqui,
            this.dtgtxtTipoDocProAdqui,
            this.dtgchcVigente});
            this.dtgTipoDocProAdqui.Location = new System.Drawing.Point(8, 8);
            this.dtgTipoDocProAdqui.MultiSelect = false;
            this.dtgTipoDocProAdqui.Name = "dtgTipoDocProAdqui";
            this.dtgTipoDocProAdqui.ReadOnly = true;
            this.dtgTipoDocProAdqui.RowHeadersVisible = false;
            this.dtgTipoDocProAdqui.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoDocProAdqui.Size = new System.Drawing.Size(548, 153);
            this.dtgTipoDocProAdqui.TabIndex = 7;
            this.dtgTipoDocProAdqui.SelectionChanged += new System.EventHandler(this.dtgTipoDocProAdqui_SelectionChanged);
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Location = new System.Drawing.Point(8, 185);
            this.txtTipoDocumento.Multiline = true;
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.Size = new System.Drawing.Size(475, 33);
            this.txtTipoDocumento.TabIndex = 8;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 170);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(123, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Tipo de Documento:";
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(494, 187);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 10;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // dtgtxtIdTipoDocProAdqui
            // 
            this.dtgtxtIdTipoDocProAdqui.DataPropertyName = "idTipoDocProAdqui";
            this.dtgtxtIdTipoDocProAdqui.HeaderText = "idTipoDocProAdqui";
            this.dtgtxtIdTipoDocProAdqui.Name = "dtgtxtIdTipoDocProAdqui";
            this.dtgtxtIdTipoDocProAdqui.ReadOnly = true;
            this.dtgtxtIdTipoDocProAdqui.Visible = false;
            // 
            // dtgtxtTipoDocProAdqui
            // 
            this.dtgtxtTipoDocProAdqui.DataPropertyName = "cTipoDocProAdqui";
            this.dtgtxtTipoDocProAdqui.HeaderText = "Tipo de Documento";
            this.dtgtxtTipoDocProAdqui.MinimumWidth = 300;
            this.dtgtxtTipoDocProAdqui.Name = "dtgtxtTipoDocProAdqui";
            this.dtgtxtTipoDocProAdqui.ReadOnly = true;
            // 
            // dtgchcVigente
            // 
            this.dtgchcVigente.DataPropertyName = "lVigente";
            this.dtgchcVigente.FillWeight = 1F;
            this.dtgchcVigente.HeaderText = "Vigente";
            this.dtgchcVigente.MinimumWidth = 55;
            this.dtgchcVigente.Name = "dtgchcVigente";
            this.dtgchcVigente.ReadOnly = true;
            this.dtgchcVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmMantenimientoTipoDocProAdqui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 306);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtTipoDocumento);
            this.Controls.Add(this.dtgTipoDocProAdqui);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmMantenimientoTipoDocProAdqui";
            this.Text = "Mantenimiento de Tipos de Documentos de Proceso de Adquisición";
            this.Load += new System.EventHandler(this.frmMantenimientoTipoDocProAdqui_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.dtgTipoDocProAdqui, 0);
            this.Controls.SetChildIndex(this.txtTipoDocumento, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoDocProAdqui)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.dtgBase dtgTipoDocProAdqui;
        private GEN.ControlesBase.txtBase txtTipoDocumento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoDocProAdqui;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoDocProAdqui;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcVigente;
    }
}

