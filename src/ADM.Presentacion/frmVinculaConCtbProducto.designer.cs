namespace ADM.Presentacion
{
    partial class frmVinculaConCtbProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVinculaConCtbProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.dtgCondicionCtb = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgTxtIdConCtbProduc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTxtIdCondicionContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTxtContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chcTxtVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboCondicionContable = new GEN.ControlesBase.cboCondicionContable(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCondicionCtb)).BeginInit();
            this.SuspendLayout();
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(118, 10);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(200, 21);
            this.cboModulo.TabIndex = 20;
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
            this.lblBase10.TabIndex = 29;
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
            this.lblBase1.TabIndex = 21;
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
            this.lblBase9.TabIndex = 28;
            this.lblBase9.Text = "Producto:";
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.FormattingEnabled = true;
            this.cboTipoProducto.Location = new System.Drawing.Point(118, 33);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Size = new System.Drawing.Size(200, 21);
            this.cboTipoProducto.TabIndex = 22;
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
            this.lblBase8.TabIndex = 27;
            this.lblBase8.Text = "Sub Tipo:";
            // 
            // cboSubTipoProducto
            // 
            this.cboSubTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoProducto.FormattingEnabled = true;
            this.cboSubTipoProducto.Location = new System.Drawing.Point(118, 56);
            this.cboSubTipoProducto.Name = "cboSubTipoProducto";
            this.cboSubTipoProducto.Size = new System.Drawing.Size(200, 21);
            this.cboSubTipoProducto.TabIndex = 23;
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
            this.lblBase7.TabIndex = 26;
            this.lblBase7.Text = "Tipo:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(118, 79);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(200, 21);
            this.cboProducto.TabIndex = 24;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboSubProducto
            // 
            this.cboSubProducto.DropDownHeight = 270;
            this.cboSubProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProducto.DropDownWidth = 270;
            this.cboSubProducto.FormattingEnabled = true;
            this.cboSubProducto.IntegralHeight = false;
            this.cboSubProducto.Location = new System.Drawing.Point(118, 102);
            this.cboSubProducto.Name = "cboSubProducto";
            this.cboSubProducto.Size = new System.Drawing.Size(200, 21);
            this.cboSubProducto.TabIndex = 25;
            this.cboSubProducto.SelectedIndexChanged += new System.EventHandler(this.cboSubProducto_SelectedIndexChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(140, 294);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 33;
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
            this.btnCancelar.TabIndex = 32;
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
            this.btnEditar.TabIndex = 31;
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
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dtgCondicionCtb
            // 
            this.dtgCondicionCtb.AllowUserToAddRows = false;
            this.dtgCondicionCtb.AllowUserToDeleteRows = false;
            this.dtgCondicionCtb.AllowUserToResizeColumns = false;
            this.dtgCondicionCtb.AllowUserToResizeRows = false;
            this.dtgCondicionCtb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCondicionCtb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCondicionCtb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCondicionCtb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgTxtIdConCtbProduc,
            this.dtgTxtIdCondicionContable,
            this.dtgTxtContable,
            this.chcTxtVigente});
            this.dtgCondicionCtb.Location = new System.Drawing.Point(10, 130);
            this.dtgCondicionCtb.MultiSelect = false;
            this.dtgCondicionCtb.Name = "dtgCondicionCtb";
            this.dtgCondicionCtb.ReadOnly = true;
            this.dtgCondicionCtb.RowHeadersVisible = false;
            this.dtgCondicionCtb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCondicionCtb.Size = new System.Drawing.Size(320, 130);
            this.dtgCondicionCtb.TabIndex = 34;
            this.dtgCondicionCtb.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCondicionCtb_RowEnter);
            // 
            // dtgTxtIdConCtbProduc
            // 
            this.dtgTxtIdConCtbProduc.DataPropertyName = "idConCtbProduc";
            this.dtgTxtIdConCtbProduc.HeaderText = "idConCtbProduc";
            this.dtgTxtIdConCtbProduc.Name = "dtgTxtIdConCtbProduc";
            this.dtgTxtIdConCtbProduc.ReadOnly = true;
            this.dtgTxtIdConCtbProduc.Visible = false;
            // 
            // dtgTxtIdCondicionContable
            // 
            this.dtgTxtIdCondicionContable.DataPropertyName = "idCondicionContable";
            this.dtgTxtIdCondicionContable.HeaderText = "idCondicionContable";
            this.dtgTxtIdCondicionContable.Name = "dtgTxtIdCondicionContable";
            this.dtgTxtIdCondicionContable.ReadOnly = true;
            this.dtgTxtIdCondicionContable.Visible = false;
            // 
            // dtgTxtContable
            // 
            this.dtgTxtContable.DataPropertyName = "cContable";
            this.dtgTxtContable.HeaderText = "Condición Contable";
            this.dtgTxtContable.Name = "dtgTxtContable";
            this.dtgTxtContable.ReadOnly = true;
            // 
            // chcTxtVigente
            // 
            this.chcTxtVigente.DataPropertyName = "lVigente";
            this.chcTxtVigente.HeaderText = "Vigente";
            this.chcTxtVigente.Name = "chcTxtVigente";
            this.chcTxtVigente.ReadOnly = true;
            // 
            // cboCondicionContable
            // 
            this.cboCondicionContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionContable.DropDownWidth = 185;
            this.cboCondicionContable.FormattingEnabled = true;
            this.cboCondicionContable.Location = new System.Drawing.Point(105, 265);
            this.cboCondicionContable.Name = "cboCondicionContable";
            this.cboCondicionContable.Size = new System.Drawing.Size(145, 21);
            this.cboCondicionContable.TabIndex = 35;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(10, 269);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(92, 13);
            this.lblBase6.TabIndex = 37;
            this.lblBase6.Text = "Condición Ctb:";
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(268, 267);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 36;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(270, 294);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 38;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmVinculaConCtbProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 372);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.cboCondicionContable);
            this.Controls.Add(this.dtgCondicionCtb);
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
            this.Name = "frmVinculaConCtbProducto";
            this.Text = "Vincular Condición Contable - Producto";
            this.Load += new System.EventHandler(this.frmVinculaConCtbProducto_Load);
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
            this.Controls.SetChildIndex(this.dtgCondicionCtb, 0);
            this.Controls.SetChildIndex(this.cboCondicionContable, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCondicionCtb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.dtgBase dtgCondicionCtb;
        private GEN.ControlesBase.cboCondicionContable cboCondicionContable;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtIdConCtbProduc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtIdCondicionContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTxtContable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chcTxtVigente;
    }
}

