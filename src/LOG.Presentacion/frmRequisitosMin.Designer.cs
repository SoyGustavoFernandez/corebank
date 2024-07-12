namespace LOG.Presentacion
{
    partial class frmRequisitosMin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequisitosMin));
            this.dtgDetalleNP = new GEN.ControlesBase.dtgBase(this.components);
            this.idCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgTipoRequisito = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDetalleReq = new GEN.ControlesBase.txtBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lIndAplica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoRequisito)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDetalleNP
            // 
            this.dtgDetalleNP.AllowUserToAddRows = false;
            this.dtgDetalleNP.AllowUserToDeleteRows = false;
            this.dtgDetalleNP.AllowUserToResizeColumns = false;
            this.dtgDetalleNP.AllowUserToResizeRows = false;
            this.dtgDetalleNP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCatalogo});
            this.dtgDetalleNP.Location = new System.Drawing.Point(6, 18);
            this.dtgDetalleNP.MultiSelect = false;
            this.dtgDetalleNP.Name = "dtgDetalleNP";
            this.dtgDetalleNP.ReadOnly = true;
            this.dtgDetalleNP.RowHeadersVisible = false;
            this.dtgDetalleNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNP.Size = new System.Drawing.Size(576, 135);
            this.dtgDetalleNP.TabIndex = 2;
            this.dtgDetalleNP.SelectionChanged += new System.EventHandler(this.dtgDetalleNP_SelectionChanged);
            // 
            // idCatalogo
            // 
            this.idCatalogo.DataPropertyName = "idCatalogo";
            this.idCatalogo.FillWeight = 35F;
            this.idCatalogo.HeaderText = "Código";
            this.idCatalogo.Name = "idCatalogo";
            this.idCatalogo.ReadOnly = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(528, 304);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 27;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtgTipoRequisito);
            this.grbBase1.Location = new System.Drawing.Point(6, 166);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(182, 131);
            this.grbBase1.TabIndex = 33;
            this.grbBase1.TabStop = false;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(110, 13);
            this.lblBase3.TabIndex = 35;
            this.lblBase3.Text = "Tipo de Requisito:";
            // 
            // dtgTipoRequisito
            // 
            this.dtgTipoRequisito.AllowUserToAddRows = false;
            this.dtgTipoRequisito.AllowUserToDeleteRows = false;
            this.dtgTipoRequisito.AllowUserToResizeColumns = false;
            this.dtgTipoRequisito.AllowUserToResizeRows = false;
            this.dtgTipoRequisito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTipoRequisito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoRequisito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lIndAplica});
            this.dtgTipoRequisito.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgTipoRequisito.Location = new System.Drawing.Point(7, 17);
            this.dtgTipoRequisito.MultiSelect = false;
            this.dtgTipoRequisito.Name = "dtgTipoRequisito";
            this.dtgTipoRequisito.ReadOnly = true;
            this.dtgTipoRequisito.RowHeadersVisible = false;
            this.dtgTipoRequisito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoRequisito.Size = new System.Drawing.Size(168, 108);
            this.dtgTipoRequisito.TabIndex = 33;
            this.dtgTipoRequisito.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTipoRequisito_CellValueChanged);
            this.dtgTipoRequisito.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgTipoRequisito_CurrentCellDirtyStateChanged);
            this.dtgTipoRequisito.SelectionChanged += new System.EventHandler(this.dtgTipoRequisito_SelectionChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.txtDetalleReq);
            this.grbBase2.Location = new System.Drawing.Point(188, 166);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(406, 131);
            this.grbBase2.TabIndex = 34;
            this.grbBase2.TabStop = false;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(126, 13);
            this.lblBase2.TabIndex = 35;
            this.lblBase2.Text = "Detalle de Requisito:";
            // 
            // txtDetalleReq
            // 
            this.txtDetalleReq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalleReq.Enabled = false;
            this.txtDetalleReq.Location = new System.Drawing.Point(7, 17);
            this.txtDetalleReq.Multiline = true;
            this.txtDetalleReq.Name = "txtDetalleReq";
            this.txtDetalleReq.Size = new System.Drawing.Size(393, 108);
            this.txtDetalleReq.TabIndex = 27;
            this.txtDetalleReq.Leave += new System.EventHandler(this.txtDetalleReq_Leave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(462, 303);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 57;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgDetalleNP);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(6, 4);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(588, 159);
            this.grbBase3.TabIndex = 58;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Items";
            // 
            // lIndAplica
            // 
            this.lIndAplica.DataPropertyName = "lIndAplica";
            this.lIndAplica.FillWeight = 25F;
            this.lIndAplica.HeaderText = "X";
            this.lIndAplica.Name = "lIndAplica";
            this.lIndAplica.ReadOnly = true;
            // 
            // frmRequisitosMin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 385);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRequisitosMin";
            this.Text = "Requisitos Mínimos";
            this.Load += new System.EventHandler(this.frmRequisitosMin_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoRequisito)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgDetalleNP;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgTipoRequisito;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtDetalleReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVinculoProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDeseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorRefDataGridViewTextBoxColumn;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoEvaDataGridViewTextBoxColumn;
        private GEN.ControlesBase.grbBase grbBase3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lIndAplica;
    }
}