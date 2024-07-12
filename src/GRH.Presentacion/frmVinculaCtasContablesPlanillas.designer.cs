namespace GRH.Presentacion
{
    partial class frmVinculaCtasContablesPlanillas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVinculaCtasContablesPlanillas));
            this.dtgPlantillaCtaCtb = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCtaCtbHaber = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtgtxtCtaDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgcboTipSegDebe = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnCtaCtbDebe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtgtxtCtaHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgcboTipSegHaber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cboRelacionLabInst = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.cboConceptoRemunerativo = new GEN.ControlesBase.cboConceptoRemunerativo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlantillaCtaCtb)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPlantillaCtaCtb
            // 
            this.dtgPlantillaCtaCtb.AllowUserToAddRows = false;
            this.dtgPlantillaCtaCtb.AllowUserToDeleteRows = false;
            this.dtgPlantillaCtaCtb.AllowUserToResizeColumns = false;
            this.dtgPlantillaCtaCtb.AllowUserToResizeRows = false;
            this.dtgPlantillaCtaCtb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlantillaCtaCtb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPlantillaCtaCtb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlantillaCtaCtb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnCtaCtbHaber,
            this.dtgtxtCtaDebe,
            this.dtgcboTipSegDebe,
            this.btnCtaCtbDebe,
            this.dtgtxtCtaHaber,
            this.dtgcboTipSegHaber});
            this.dtgPlantillaCtaCtb.Enabled = false;
            this.dtgPlantillaCtaCtb.Location = new System.Drawing.Point(8, 58);
            this.dtgPlantillaCtaCtb.MultiSelect = false;
            this.dtgPlantillaCtaCtb.Name = "dtgPlantillaCtaCtb";
            this.dtgPlantillaCtaCtb.ReadOnly = true;
            this.dtgPlantillaCtaCtb.RowHeadersVisible = false;
            this.dtgPlantillaCtaCtb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlantillaCtaCtb.Size = new System.Drawing.Size(468, 102);
            this.dtgPlantillaCtaCtb.TabIndex = 2;
            this.dtgPlantillaCtaCtb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPlantillaCtaCtb_CellClick);
            this.dtgPlantillaCtaCtb.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgPlantillaCtaCtb_EditingControlShowing);
            // 
            // btnCtaCtbHaber
            // 
            this.btnCtaCtbHaber.FillWeight = 20F;
            this.btnCtaCtbHaber.HeaderText = "";
            this.btnCtaCtbHaber.Name = "btnCtaCtbHaber";
            this.btnCtaCtbHaber.ReadOnly = true;
            this.btnCtaCtbHaber.Text = "...";
            // 
            // dtgtxtCtaDebe
            // 
            this.dtgtxtCtaDebe.DataPropertyName = "cCtaDebe";
            this.dtgtxtCtaDebe.FillWeight = 200F;
            this.dtgtxtCtaDebe.HeaderText = "Debe";
            this.dtgtxtCtaDebe.MinimumWidth = 80;
            this.dtgtxtCtaDebe.Name = "dtgtxtCtaDebe";
            this.dtgtxtCtaDebe.ReadOnly = true;
            // 
            // dtgcboTipSegDebe
            // 
            this.dtgcboTipSegDebe.DataPropertyName = "cTipSegDebe";
            this.dtgcboTipSegDebe.HeaderText = "Afectación Debe";
            this.dtgcboTipSegDebe.MinimumWidth = 118;
            this.dtgcboTipSegDebe.Name = "dtgcboTipSegDebe";
            this.dtgcboTipSegDebe.ReadOnly = true;
            this.dtgcboTipSegDebe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgcboTipSegDebe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnCtaCtbDebe
            // 
            this.btnCtaCtbDebe.FillWeight = 20F;
            this.btnCtaCtbDebe.HeaderText = "";
            this.btnCtaCtbDebe.Name = "btnCtaCtbDebe";
            this.btnCtaCtbDebe.ReadOnly = true;
            this.btnCtaCtbDebe.Text = "...";
            // 
            // dtgtxtCtaHaber
            // 
            this.dtgtxtCtaHaber.DataPropertyName = "cCtaHaber";
            this.dtgtxtCtaHaber.FillWeight = 200F;
            this.dtgtxtCtaHaber.HeaderText = "Haber";
            this.dtgtxtCtaHaber.MinimumWidth = 80;
            this.dtgtxtCtaHaber.Name = "dtgtxtCtaHaber";
            this.dtgtxtCtaHaber.ReadOnly = true;
            // 
            // dtgcboTipSegHaber
            // 
            this.dtgcboTipSegHaber.DataPropertyName = "cTipSegHaber";
            this.dtgcboTipSegHaber.HeaderText = "Afectación Haber";
            this.dtgcboTipSegHaber.MinimumWidth = 118;
            this.dtgcboTipSegHaber.Name = "dtgcboTipSegHaber";
            this.dtgcboTipSegHaber.ReadOnly = true;
            this.dtgcboTipSegHaber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgcboTipSegHaber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboRelacionLabInst
            // 
            this.cboRelacionLabInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst.FormattingEnabled = true;
            this.cboRelacionLabInst.Location = new System.Drawing.Point(94, 6);
            this.cboRelacionLabInst.Name = "cboRelacionLabInst";
            this.cboRelacionLabInst.Size = new System.Drawing.Size(120, 21);
            this.cboRelacionLabInst.TabIndex = 3;
            this.cboRelacionLabInst.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst1_SelectedIndexChanged);
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(335, 6);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(152, 21);
            this.cboTipoPlanilla.TabIndex = 4;
            this.cboTipoPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(234, 10);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Tipo de Planilla:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 10);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Clasificación:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(155, 166);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(217, 166);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 11;
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
            this.btnCancelar.Location = new System.Drawing.Point(279, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(482, 166);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(482, 58);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(482, 110);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 15;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // cboConceptoRemunerativo
            // 
            this.cboConceptoRemunerativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoRemunerativo.FormattingEnabled = true;
            this.cboConceptoRemunerativo.Location = new System.Drawing.Point(94, 29);
            this.cboConceptoRemunerativo.Name = "cboConceptoRemunerativo";
            this.cboConceptoRemunerativo.Size = new System.Drawing.Size(393, 21);
            this.cboConceptoRemunerativo.TabIndex = 16;
            this.cboConceptoRemunerativo.SelectedIndexChanged += new System.EventHandler(this.cboConceptoRemunerativo_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 33);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(66, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Concepto:";
            // 
            // frmVinculaCtasContablesPlanillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 244);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboConceptoRemunerativo);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoPlanilla);
            this.Controls.Add(this.cboRelacionLabInst);
            this.Controls.Add(this.dtgPlantillaCtaCtb);
            this.Name = "frmVinculaCtasContablesPlanillas";
            this.Text = "Asignación de Cuentas Contables de Planillas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVinculaCtasContablesPlanillas_FormClosed);
            this.Load += new System.EventHandler(this.frmVinculaCtasContablesPlanillas_Load);
            this.Controls.SetChildIndex(this.dtgPlantillaCtaCtb, 0);
            this.Controls.SetChildIndex(this.cboRelacionLabInst, 0);
            this.Controls.SetChildIndex(this.cboTipoPlanilla, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.cboConceptoRemunerativo, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlantillaCtaCtb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgPlantillaCtaCtb;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.ControlesBase.cboConceptoRemunerativo cboConceptoRemunerativo;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.DataGridViewButtonColumn btnCtaCtbHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtCtaDebe;
        private System.Windows.Forms.DataGridViewComboBoxColumn dtgcboTipSegDebe;
        private System.Windows.Forms.DataGridViewButtonColumn btnCtaCtbDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtCtaHaber;
        private System.Windows.Forms.DataGridViewComboBoxColumn dtgcboTipSegHaber;
    }
}

