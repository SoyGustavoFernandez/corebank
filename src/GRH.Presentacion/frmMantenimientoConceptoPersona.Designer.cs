namespace GRH.Presentacion
{
    partial class frmMantenimientoConceptoPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoConceptoPersona));
            this.conBusPerson = new GEN.ControlesBase.ConBusCol();
            this.dtgConceptoPersona = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoPersona)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusPerson
            // 
            this.conBusPerson.cEstado = "0";
            this.conBusPerson.Location = new System.Drawing.Point(23, 5);
            this.conBusPerson.Name = "conBusPerson";
            this.conBusPerson.Size = new System.Drawing.Size(390, 86);
            this.conBusPerson.TabIndex = 2;
            this.conBusPerson.BuscarUsuario += new System.EventHandler(this.conBusPerson_BuscarUsuario);
            // 
            // dtgConceptoPersona
            // 
            this.dtgConceptoPersona.AllowUserToAddRows = false;
            this.dtgConceptoPersona.AllowUserToDeleteRows = false;
            this.dtgConceptoPersona.AllowUserToResizeColumns = false;
            this.dtgConceptoPersona.AllowUserToResizeRows = false;
            this.dtgConceptoPersona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgConceptoPersona.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgConceptoPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptoPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdUsuario,
            this.dtgtxtIdTipoPlanilla,
            this.dtgtxtIdTipoConcepto,
            this.dtgtxtTipoConcepto,
            this.dtgtxtIdConcepto,
            this.dtgtxtConcepto,
            this.dtgtxtMonto});
            this.dtgConceptoPersona.Location = new System.Drawing.Point(8, 99);
            this.dtgConceptoPersona.MultiSelect = false;
            this.dtgConceptoPersona.Name = "dtgConceptoPersona";
            this.dtgConceptoPersona.ReadOnly = true;
            this.dtgConceptoPersona.RowHeadersVisible = false;
            this.dtgConceptoPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptoPersona.Size = new System.Drawing.Size(420, 264);
            this.dtgConceptoPersona.TabIndex = 3;
            this.dtgConceptoPersona.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConceptoPersona_CellValueChanged);
            this.dtgConceptoPersona.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgConceptoPersona_EditingControlShowing);
            // 
            // dtgtxtIdUsuario
            // 
            this.dtgtxtIdUsuario.DataPropertyName = "idUsuario";
            this.dtgtxtIdUsuario.HeaderText = "idUsuario";
            this.dtgtxtIdUsuario.Name = "dtgtxtIdUsuario";
            this.dtgtxtIdUsuario.ReadOnly = true;
            this.dtgtxtIdUsuario.Visible = false;
            // 
            // dtgtxtIdTipoPlanilla
            // 
            this.dtgtxtIdTipoPlanilla.DataPropertyName = "idTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.HeaderText = "idTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.Name = "dtgtxtIdTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.ReadOnly = true;
            this.dtgtxtIdTipoPlanilla.Visible = false;
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
            this.dtgtxtTipoConcepto.MinimumWidth = 158;
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
            this.dtgtxtConcepto.HeaderText = "Concepto";
            this.dtgtxtConcepto.MinimumWidth = 165;
            this.dtgtxtConcepto.Name = "dtgtxtConcepto";
            this.dtgtxtConcepto.ReadOnly = true;
            // 
            // dtgtxtMonto
            // 
            this.dtgtxtMonto.DataPropertyName = "nMonto";
            this.dtgtxtMonto.HeaderText = "Monto";
            this.dtgtxtMonto.MinimumWidth = 55;
            this.dtgtxtMonto.Name = "dtgtxtMonto";
            this.dtgtxtMonto.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(179, 368);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(242, 368);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(305, 368);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(368, 367);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoConceptoPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 446);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgConceptoPersona);
            this.Controls.Add(this.conBusPerson);
            this.Name = "frmMantenimientoConceptoPersona";
            this.Text = "Mantenimiento de Conceptos por Persona";
            this.Load += new System.EventHandler(this.frmMantenimientoConceptoPersona_Load);
            this.Controls.SetChildIndex(this.conBusPerson, 0);
            this.Controls.SetChildIndex(this.dtgConceptoPersona, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoPersona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusPerson;
        private GEN.ControlesBase.dtgBase dtgConceptoPersona;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMonto;
    }
}

