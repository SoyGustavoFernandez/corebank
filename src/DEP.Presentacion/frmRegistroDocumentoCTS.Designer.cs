namespace DEP.Presentacion
{
    partial class frmRegistroDocumentoCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroDocumentoCTS));
            this.dtgListRegDoc = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.cboTipoDocumento = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtPromotor = new GEN.ControlesBase.txtBase(this.components);
            this.idRegDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocumentoCTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEnviado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bFirmado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListRegDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListRegDoc
            // 
            this.dtgListRegDoc.AllowUserToAddRows = false;
            this.dtgListRegDoc.AllowUserToDeleteRows = false;
            this.dtgListRegDoc.AllowUserToResizeColumns = false;
            this.dtgListRegDoc.AllowUserToResizeRows = false;
            this.dtgListRegDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListRegDoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListRegDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListRegDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRegDoc,
            this.idCuenta,
            this.idDoc,
            this.cDenominacion,
            this.idTipoDocumentoCTS,
            this.cTipo,
            this.bEnviado,
            this.bFirmado,
            this.lVigente});
            this.dtgListRegDoc.Location = new System.Drawing.Point(7, 149);
            this.dtgListRegDoc.MultiSelect = false;
            this.dtgListRegDoc.Name = "dtgListRegDoc";
            this.dtgListRegDoc.RowHeadersVisible = false;
            this.dtgListRegDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListRegDoc.Size = new System.Drawing.Size(557, 134);
            this.dtgListRegDoc.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(438, 288);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(500, 288);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(376, 288);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Location = new System.Drawing.Point(4, 4);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho.TabIndex = 8;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(123, 122);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(206, 21);
            this.cboTipoDocumento.TabIndex = 9;
            this.cboTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocumento_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 125);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Tipo Documento:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 298);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Promotor:";
            // 
            // txtPromotor
            // 
            this.txtPromotor.Enabled = false;
            this.txtPromotor.Location = new System.Drawing.Point(83, 295);
            this.txtPromotor.Name = "txtPromotor";
            this.txtPromotor.Size = new System.Drawing.Size(287, 20);
            this.txtPromotor.TabIndex = 12;
            // 
            // idRegDoc
            // 
            this.idRegDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idRegDoc.DataPropertyName = "idRegDoc";
            this.idRegDoc.HeaderText = "Id";
            this.idRegDoc.MinimumWidth = 40;
            this.idRegDoc.Name = "idRegDoc";
            this.idRegDoc.ReadOnly = true;
            this.idRegDoc.Visible = false;
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "idCuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Visible = false;
            // 
            // idDoc
            // 
            this.idDoc.DataPropertyName = "idDoc";
            this.idDoc.HeaderText = "idDoc";
            this.idDoc.Name = "idDoc";
            this.idDoc.ReadOnly = true;
            this.idDoc.Visible = false;
            // 
            // cDenominacion
            // 
            this.cDenominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDenominacion.DataPropertyName = "cDenominacion";
            this.cDenominacion.FillWeight = 600F;
            this.cDenominacion.HeaderText = "Denominacion";
            this.cDenominacion.MinimumWidth = 200;
            this.cDenominacion.Name = "cDenominacion";
            this.cDenominacion.ReadOnly = true;
            // 
            // idTipoDocumentoCTS
            // 
            this.idTipoDocumentoCTS.DataPropertyName = "idTipoDocumentoCTS";
            this.idTipoDocumentoCTS.HeaderText = "idTipoDocumentoCTS";
            this.idTipoDocumentoCTS.Name = "idTipoDocumentoCTS";
            this.idTipoDocumentoCTS.ReadOnly = true;
            this.idTipoDocumentoCTS.Visible = false;
            // 
            // cTipo
            // 
            this.cTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTipo.DataPropertyName = "cTipo";
            this.cTipo.HeaderText = "Tipo";
            this.cTipo.MinimumWidth = 100;
            this.cTipo.Name = "cTipo";
            this.cTipo.ReadOnly = true;
            // 
            // bEnviado
            // 
            this.bEnviado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bEnviado.DataPropertyName = "bEnviado";
            this.bEnviado.HeaderText = "Enviado";
            this.bEnviado.MinimumWidth = 50;
            this.bEnviado.Name = "bEnviado";
            this.bEnviado.ReadOnly = true;
            // 
            // bFirmado
            // 
            this.bFirmado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bFirmado.DataPropertyName = "bFirmado";
            this.bFirmado.HeaderText = "Firmado";
            this.bFirmado.MinimumWidth = 50;
            this.bFirmado.Name = "bFirmado";
            this.bFirmado.ReadOnly = true;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "Vigente";
            this.lVigente.Name = "lVigente";
            // 
            // frmRegistroDocumentoCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 364);
            this.Controls.Add(this.txtPromotor);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtgListRegDoc);
            this.Name = "frmRegistroDocumentoCTS";
            this.Text = "Registro de Documentos CTS";
            this.Load += new System.EventHandler(this.frmRegistroDocumentoCTS_Load);
            this.Controls.SetChildIndex(this.dtgListRegDoc, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.cboTipoDocumento, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtPromotor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListRegDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgListRegDoc;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.cboBase cboTipoDocumento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtPromotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRegDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumentoCTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bEnviado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bFirmado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigente;
    }
}