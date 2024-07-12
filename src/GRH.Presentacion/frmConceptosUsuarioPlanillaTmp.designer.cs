namespace GRH.Presentacion
{
    partial class frmConceptosUsuarioPlanillaTmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConceptosUsuarioPlanillaTmp));
            this.dtgConceptosPlanilla = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMontoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.conBusPersonal = new GEN.ControlesBase.ConBusCol();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptosPlanilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgConceptosPlanilla
            // 
            this.dtgConceptosPlanilla.AllowUserToAddRows = false;
            this.dtgConceptosPlanilla.AllowUserToDeleteRows = false;
            this.dtgConceptosPlanilla.AllowUserToResizeColumns = false;
            this.dtgConceptosPlanilla.AllowUserToResizeRows = false;
            this.dtgConceptosPlanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgConceptosPlanilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgConceptosPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptosPlanilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdTipoPlanilla,
            this.dtgtxtIdUsuario,
            this.dtgtxtIdTipoConcepto,
            this.dtgtxtTipoConcepto,
            this.dtgtxtIdConcepto,
            this.dtgtxtConcepto,
            this.dtgtxtMontoConcepto});
            this.dtgConceptosPlanilla.Location = new System.Drawing.Point(8, 95);
            this.dtgConceptosPlanilla.MultiSelect = false;
            this.dtgConceptosPlanilla.Name = "dtgConceptosPlanilla";
            this.dtgConceptosPlanilla.ReadOnly = true;
            this.dtgConceptosPlanilla.RowHeadersVisible = false;
            this.dtgConceptosPlanilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptosPlanilla.Size = new System.Drawing.Size(385, 284);
            this.dtgConceptosPlanilla.TabIndex = 2;
            this.dtgConceptosPlanilla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConceptosPlanilla_CellValueChanged);
            this.dtgConceptosPlanilla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgConceptosPlanilla_EditingControlShowing);
            // 
            // dtgtxtIdTipoPlanilla
            // 
            this.dtgtxtIdTipoPlanilla.DataPropertyName = "idTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.HeaderText = "idTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.Name = "dtgtxtIdTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.ReadOnly = true;
            this.dtgtxtIdTipoPlanilla.Visible = false;
            // 
            // dtgtxtIdUsuario
            // 
            this.dtgtxtIdUsuario.DataPropertyName = "idUsuario";
            this.dtgtxtIdUsuario.HeaderText = "idUsuario";
            this.dtgtxtIdUsuario.Name = "dtgtxtIdUsuario";
            this.dtgtxtIdUsuario.ReadOnly = true;
            this.dtgtxtIdUsuario.Visible = false;
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
            this.dtgtxtConcepto.FillWeight = 280F;
            this.dtgtxtConcepto.HeaderText = "Concepto";
            this.dtgtxtConcepto.MinimumWidth = 120;
            this.dtgtxtConcepto.Name = "dtgtxtConcepto";
            this.dtgtxtConcepto.ReadOnly = true;
            // 
            // dtgtxtMontoConcepto
            // 
            this.dtgtxtMontoConcepto.DataPropertyName = "nMontoConcepto";
            this.dtgtxtMontoConcepto.HeaderText = "Monto";
            this.dtgtxtMontoConcepto.MinimumWidth = 60;
            this.dtgtxtMontoConcepto.Name = "dtgtxtMontoConcepto";
            this.dtgtxtMontoConcepto.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(7, 384);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(129, 384);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(68, 384);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(333, 384);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // conBusPersonal
            // 
            this.conBusPersonal.Location = new System.Drawing.Point(7, 3);
            this.conBusPersonal.Name = "conBusPersonal";
            this.conBusPersonal.Size = new System.Drawing.Size(390, 86);
            this.conBusPersonal.TabIndex = 7;
            // 
            // frmConceptosUsuarioPlanillaTmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 462);
            this.Controls.Add(this.dtgConceptosPlanilla);
            this.Controls.Add(this.conBusPersonal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Name = "frmConceptosUsuarioPlanillaTmp";
            this.Text = "Detalle de Conceptos por Persona";
            this.Load += new System.EventHandler(this.frmConceptosUsuarioPlanillaTmp_Load);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conBusPersonal, 0);
            this.Controls.SetChildIndex(this.dtgConceptosPlanilla, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptosPlanilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgConceptosPlanilla;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.ConBusCol conBusPersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMontoConcepto;
    }
}

