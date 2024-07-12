namespace ADM.Presentacion
{
    partial class frmVinculaTipPerProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVinculaTipPerProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboTipoProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboSubTipoProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.cboSubProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.dtgTipoPersona = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgTxtIdTipPerProduc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTxtIdTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTxtTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgChcVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboTipoPersona = new GEN.ControlesBase.cboTipoPersona(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(270, 294);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 57;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(10, 269);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(86, 13);
            this.lblBase6.TabIndex = 56;
            this.lblBase6.Text = "Tipo Persona:";
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(268, 267);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 55;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(140, 294);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 52;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(205, 294);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(75, 294);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 50;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(10, 294);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 49;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(118, 10);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(200, 21);
            this.cboModulo.TabIndex = 39;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(10, 105);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(88, 13);
            this.lblBase10.TabIndex = 48;
            this.lblBase10.Text = "Sub Producto:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 40;
            this.lblBase1.Text = "Módulo:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(10, 82);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 47;
            this.lblBase9.Text = "Producto:";
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.FormattingEnabled = true;
            this.cboTipoProducto.Location = new System.Drawing.Point(118, 33);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Size = new System.Drawing.Size(200, 21);
            this.cboTipoProducto.TabIndex = 41;
            this.cboTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cboTipoProducto_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 59);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(62, 13);
            this.lblBase8.TabIndex = 46;
            this.lblBase8.Text = "Sub Tipo:";
            // 
            // cboSubTipoProducto
            // 
            this.cboSubTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoProducto.FormattingEnabled = true;
            this.cboSubTipoProducto.Location = new System.Drawing.Point(118, 56);
            this.cboSubTipoProducto.Name = "cboSubTipoProducto";
            this.cboSubTipoProducto.Size = new System.Drawing.Size(200, 21);
            this.cboSubTipoProducto.TabIndex = 42;
            this.cboSubTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoProducto_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 36);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(36, 13);
            this.lblBase7.TabIndex = 45;
            this.lblBase7.Text = "Tipo:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(118, 79);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(200, 21);
            this.cboProducto.TabIndex = 43;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboSubProducto
            // 
            this.cboSubProducto.DropDownHeight = 290;
            this.cboSubProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProducto.DropDownWidth = 290;
            this.cboSubProducto.FormattingEnabled = true;
            this.cboSubProducto.IntegralHeight = false;
            this.cboSubProducto.Location = new System.Drawing.Point(118, 102);
            this.cboSubProducto.Name = "cboSubProducto";
            this.cboSubProducto.Size = new System.Drawing.Size(200, 21);
            this.cboSubProducto.TabIndex = 44;
            this.cboSubProducto.SelectedIndexChanged += new System.EventHandler(this.cboSubProducto_SelectedIndexChanged);
            // 
            // dtgTipoPersona
            // 
            this.dtgTipoPersona.AllowUserToAddRows = false;
            this.dtgTipoPersona.AllowUserToDeleteRows = false;
            this.dtgTipoPersona.AllowUserToResizeColumns = false;
            this.dtgTipoPersona.AllowUserToResizeRows = false;
            this.dtgTipoPersona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTipoPersona.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTipoPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgTxtIdTipPerProduc,
            this.dtgTxtIdTipoPersona,
            this.dtgTxtTipoPersona,
            this.dtgChcVigente});
            this.dtgTipoPersona.Location = new System.Drawing.Point(10, 130);
            this.dtgTipoPersona.MultiSelect = false;
            this.dtgTipoPersona.Name = "dtgTipoPersona";
            this.dtgTipoPersona.ReadOnly = true;
            this.dtgTipoPersona.RowHeadersVisible = false;
            this.dtgTipoPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoPersona.Size = new System.Drawing.Size(320, 130);
            this.dtgTipoPersona.TabIndex = 58;
            this.dtgTipoPersona.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTipoPersona_RowEnter);
            // 
            // dtgTxtIdTipPerProduc
            // 
            this.dtgTxtIdTipPerProduc.DataPropertyName = "idTipPerProduc";
            this.dtgTxtIdTipPerProduc.HeaderText = "idTipPerProduc";
            this.dtgTxtIdTipPerProduc.Name = "dtgTxtIdTipPerProduc";
            this.dtgTxtIdTipPerProduc.ReadOnly = true;
            this.dtgTxtIdTipPerProduc.Visible = false;
            // 
            // dtgTxtIdTipoPersona
            // 
            this.dtgTxtIdTipoPersona.DataPropertyName = "idTipoPersona";
            this.dtgTxtIdTipoPersona.HeaderText = "idTipoPersona";
            this.dtgTxtIdTipoPersona.Name = "dtgTxtIdTipoPersona";
            this.dtgTxtIdTipoPersona.ReadOnly = true;
            this.dtgTxtIdTipoPersona.Visible = false;
            // 
            // dtgTxtTipoPersona
            // 
            this.dtgTxtTipoPersona.DataPropertyName = "cTipoPersona";
            this.dtgTxtTipoPersona.HeaderText = "Tipo de Persona";
            this.dtgTxtTipoPersona.Name = "dtgTxtTipoPersona";
            this.dtgTxtTipoPersona.ReadOnly = true;
            // 
            // dtgChcVigente
            // 
            this.dtgChcVigente.DataPropertyName = "lVigente";
            this.dtgChcVigente.HeaderText = "Vigente";
            this.dtgChcVigente.Name = "dtgChcVigente";
            this.dtgChcVigente.ReadOnly = true;
            this.dtgChcVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgChcVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.DropDownWidth = 170;
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(99, 265);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(145, 21);
            this.cboTipoPersona.TabIndex = 59;
            // 
            // frmVinculaTipPerProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 372);
            this.Controls.Add(this.cboTipoPersona);
            this.Controls.Add(this.dtgTipoPersona);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cboModulo);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.cboTipoProducto);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.cboSubTipoProducto);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.cboSubProducto);
            this.Name = "frmVinculaTipPerProducto";
            this.Text = "Vincular Tipo Persona - Producto";
            this.Load += new System.EventHandler(this.frmVinculaTipPerProducto_Load);
            this.Controls.SetChildIndex(this.cboSubProducto, 0);
            this.Controls.SetChildIndex(this.cboProducto, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.cboSubTipoProducto, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.cboTipoProducto, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.cboModulo, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgTipoPersona, 0);
            this.Controls.SetChildIndex(this.cboTipoPersona, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoPersona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboProducto cboTipoProducto;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboProducto cboSubTipoProducto;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.cboProducto cboSubProducto;
        private GEN.ControlesBase.dtgBase dtgTipoPersona;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtIdTipPerProduc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtIdTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtTipoPersona;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgChcVigente;

    }
}

