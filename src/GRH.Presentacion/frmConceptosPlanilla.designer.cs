namespace GRH.Presentacion
{
    partial class frmConceptosPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConceptosPlanilla));
            this.dtgConceptoPlanilla = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.cboRelacionLabInst = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.dtgtxtIdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgchcAfectoSNP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgchcAfectoSPP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgchcAfectoQuinta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgchcAfectoEssalud = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgchcAfectoIES = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgtxtCodSunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgchcVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoPlanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgConceptoPlanilla
            // 
            this.dtgConceptoPlanilla.AllowUserToAddRows = false;
            this.dtgConceptoPlanilla.AllowUserToDeleteRows = false;
            this.dtgConceptoPlanilla.AllowUserToResizeColumns = false;
            this.dtgConceptoPlanilla.AllowUserToResizeRows = false;
            this.dtgConceptoPlanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgConceptoPlanilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgConceptoPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptoPlanilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdConcepto,
            this.dtgtxtConcepto,
            this.dtgtxtIdTipoConcepto,
            this.dtgtxtTipoConcepto,
            this.dtgchcAfectoSNP,
            this.dtgchcAfectoSPP,
            this.dtgchcAfectoQuinta,
            this.dtgchcAfectoEssalud,
            this.dtgchcAfectoIES,
            this.dtgtxtCodSunat,
            this.dtgchcVigente});
            this.dtgConceptoPlanilla.Location = new System.Drawing.Point(7, 42);
            this.dtgConceptoPlanilla.MultiSelect = false;
            this.dtgConceptoPlanilla.Name = "dtgConceptoPlanilla";
            this.dtgConceptoPlanilla.ReadOnly = true;
            this.dtgConceptoPlanilla.RowHeadersVisible = false;
            this.dtgConceptoPlanilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptoPlanilla.Size = new System.Drawing.Size(700, 408);
            this.dtgConceptoPlanilla.TabIndex = 15;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(443, 456);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(505, 456);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 28;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(567, 456);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(629, 456);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(338, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 34;
            this.lblBase2.Text = "Tipo de Planilla:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 33;
            this.lblBase1.Text = "Clasificación:";
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(439, 12);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(250, 21);
            this.cboTipoPlanilla.TabIndex = 32;
            this.cboTipoPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla_SelectedIndexChanged);
            // 
            // cboRelacionLabInst
            // 
            this.cboRelacionLabInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst.FormattingEnabled = true;
            this.cboRelacionLabInst.Location = new System.Drawing.Point(112, 12);
            this.cboRelacionLabInst.Name = "cboRelacionLabInst";
            this.cboRelacionLabInst.Size = new System.Drawing.Size(200, 21);
            this.cboRelacionLabInst.TabIndex = 31;
            this.cboRelacionLabInst.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst_SelectedIndexChanged);
            // 
            // dtgtxtIdConcepto
            // 
            this.dtgtxtIdConcepto.DataPropertyName = "idConcepto";
            this.dtgtxtIdConcepto.HeaderText = "idConcepto";
            this.dtgtxtIdConcepto.Name = "dtgtxtIdConcepto";
            this.dtgtxtIdConcepto.ReadOnly = true;
            this.dtgtxtIdConcepto.Visible = false;
            // 
            // dtgtxtConcepto
            // 
            this.dtgtxtConcepto.DataPropertyName = "cConcepto";
            this.dtgtxtConcepto.FillWeight = 6500F;
            this.dtgtxtConcepto.HeaderText = "Concepto";
            this.dtgtxtConcepto.MinimumWidth = 180;
            this.dtgtxtConcepto.Name = "dtgtxtConcepto";
            this.dtgtxtConcepto.ReadOnly = true;
            // 
            // dtgtxtIdTipoConcepto
            // 
            this.dtgtxtIdTipoConcepto.DataPropertyName = "idTipoConcepto";
            this.dtgtxtIdTipoConcepto.HeaderText = "idTipoConcepto";
            this.dtgtxtIdTipoConcepto.Name = "dtgtxtIdTipoConcepto";
            this.dtgtxtIdTipoConcepto.ReadOnly = true;
            this.dtgtxtIdTipoConcepto.Visible = false;
            // 
            // dtgtxtTipoConcepto
            // 
            this.dtgtxtTipoConcepto.DataPropertyName = "cTipoConcepto";
            this.dtgtxtTipoConcepto.HeaderText = "Tipo de Concepto";
            this.dtgtxtTipoConcepto.MinimumWidth = 145;
            this.dtgtxtTipoConcepto.Name = "dtgtxtTipoConcepto";
            this.dtgtxtTipoConcepto.ReadOnly = true;
            // 
            // dtgchcAfectoSNP
            // 
            this.dtgchcAfectoSNP.DataPropertyName = "lAfectoSNP";
            this.dtgchcAfectoSNP.HeaderText = "Afecto SNP";
            this.dtgchcAfectoSNP.MinimumWidth = 42;
            this.dtgchcAfectoSNP.Name = "dtgchcAfectoSNP";
            this.dtgchcAfectoSNP.ReadOnly = true;
            this.dtgchcAfectoSNP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcAfectoSNP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgchcAfectoSNP.ToolTipText = "Sistema Nacional de Pensiones";
            // 
            // dtgchcAfectoSPP
            // 
            this.dtgchcAfectoSPP.DataPropertyName = "lAfectoSPP";
            this.dtgchcAfectoSPP.HeaderText = "Afecto SPP";
            this.dtgchcAfectoSPP.MinimumWidth = 42;
            this.dtgchcAfectoSPP.Name = "dtgchcAfectoSPP";
            this.dtgchcAfectoSPP.ReadOnly = true;
            this.dtgchcAfectoSPP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcAfectoSPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgchcAfectoSPP.ToolTipText = "Sistema Privado de Pensiones";
            // 
            // dtgchcAfectoQuinta
            // 
            this.dtgchcAfectoQuinta.DataPropertyName = "lAfectoQuinta";
            this.dtgchcAfectoQuinta.HeaderText = "Afecto Quinta";
            this.dtgchcAfectoQuinta.MinimumWidth = 42;
            this.dtgchcAfectoQuinta.Name = "dtgchcAfectoQuinta";
            this.dtgchcAfectoQuinta.ReadOnly = true;
            this.dtgchcAfectoQuinta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcAfectoQuinta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgchcAfectoQuinta.ToolTipText = "Renta de Quinta Categoria";
            // 
            // dtgchcAfectoEssalud
            // 
            this.dtgchcAfectoEssalud.DataPropertyName = "lAfectoEssalud";
            this.dtgchcAfectoEssalud.HeaderText = "Afecto Essalud";
            this.dtgchcAfectoEssalud.MinimumWidth = 42;
            this.dtgchcAfectoEssalud.Name = "dtgchcAfectoEssalud";
            this.dtgchcAfectoEssalud.ReadOnly = true;
            this.dtgchcAfectoEssalud.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcAfectoEssalud.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgchcAfectoEssalud.ToolTipText = "Essalud";
            // 
            // dtgchcAfectoIES
            // 
            this.dtgchcAfectoIES.DataPropertyName = "lAfectoIES";
            this.dtgchcAfectoIES.HeaderText = "Afecto IES";
            this.dtgchcAfectoIES.MinimumWidth = 42;
            this.dtgchcAfectoIES.Name = "dtgchcAfectoIES";
            this.dtgchcAfectoIES.ReadOnly = true;
            this.dtgchcAfectoIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcAfectoIES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgchcAfectoIES.ToolTipText = "Impuesto Extraordinario de Solidaridad ";
            // 
            // dtgtxtCodSunat
            // 
            this.dtgtxtCodSunat.DataPropertyName = "cCodSunat";
            this.dtgtxtCodSunat.HeaderText = "Código PLAME";
            this.dtgtxtCodSunat.MinimumWidth = 45;
            this.dtgtxtCodSunat.Name = "dtgtxtCodSunat";
            this.dtgtxtCodSunat.ReadOnly = true;
            // 
            // dtgchcVigente
            // 
            this.dtgchcVigente.DataPropertyName = "lVigente";
            this.dtgchcVigente.HeaderText = "Vigente";
            this.dtgchcVigente.MinimumWidth = 44;
            this.dtgchcVigente.Name = "dtgchcVigente";
            this.dtgchcVigente.ReadOnly = true;
            this.dtgchcVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmConceptosPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 534);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoPlanilla);
            this.Controls.Add(this.cboRelacionLabInst);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgConceptoPlanilla);
            this.Name = "frmConceptosPlanilla";
            this.Text = "Configuración de Conceptos por Planilla";
            this.Load += new System.EventHandler(this.frmConceptosPlanilla_Load);
            this.Controls.SetChildIndex(this.dtgConceptoPlanilla, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboRelacionLabInst, 0);
            this.Controls.SetChildIndex(this.cboTipoPlanilla, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoPlanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgConceptoPlanilla;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoConcepto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcAfectoSNP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcAfectoSPP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcAfectoQuinta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcAfectoEssalud;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcAfectoIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtCodSunat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcVigente;
    }
}

