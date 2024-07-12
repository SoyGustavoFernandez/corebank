namespace CLI.Presentacion
{
    partial class frmBaseNegativaCargaLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseNegativaCargaLote));
            this.dtgClientesBaseNegativa = new GEN.ControlesBase.dtgBase(this.components);
            this.cModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtUbicacion = new GEN.ControlesBase.txtBase(this.components);
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.dtgBNError = new GEN.ControlesBase.dtgBase(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesBaseNegativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBNError)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgClientesBaseNegativa
            // 
            this.dtgClientesBaseNegativa.AllowUserToAddRows = false;
            this.dtgClientesBaseNegativa.AllowUserToDeleteRows = false;
            this.dtgClientesBaseNegativa.AllowUserToResizeColumns = false;
            this.dtgClientesBaseNegativa.AllowUserToResizeRows = false;
            this.dtgClientesBaseNegativa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgClientesBaseNegativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesBaseNegativa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cModulo,
            this.cTipoPersona,
            this.cTipoDocumento,
            this.cNroDoc,
            this.cRazonSocial,
            this.cNombres,
            this.cPaterno,
            this.cMaterno,
            this.dMotivo,
            this.cDescripcion,
            this.lVigente,
            this.cObservacion});
            this.dtgClientesBaseNegativa.Location = new System.Drawing.Point(12, 59);
            this.dtgClientesBaseNegativa.MultiSelect = false;
            this.dtgClientesBaseNegativa.Name = "dtgClientesBaseNegativa";
            this.dtgClientesBaseNegativa.ReadOnly = true;
            this.dtgClientesBaseNegativa.RowHeadersVisible = false;
            this.dtgClientesBaseNegativa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesBaseNegativa.Size = new System.Drawing.Size(913, 197);
            this.dtgClientesBaseNegativa.TabIndex = 2;
            // 
            // cModulo
            // 
            this.cModulo.DataPropertyName = "cModulo";
            this.cModulo.HeaderText = "Modulo";
            this.cModulo.Name = "cModulo";
            this.cModulo.ReadOnly = true;
            this.cModulo.Width = 67;
            // 
            // cTipoPersona
            // 
            this.cTipoPersona.DataPropertyName = "cTipoPersona";
            this.cTipoPersona.HeaderText = "Tipo Persona";
            this.cTipoPersona.Name = "cTipoPersona";
            this.cTipoPersona.ReadOnly = true;
            this.cTipoPersona.Width = 95;
            // 
            // cTipoDocumento
            // 
            this.cTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumento.HeaderText = "Tipo Doc.";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            this.cTipoDocumento.Width = 79;
            // 
            // cNroDoc
            // 
            this.cNroDoc.DataPropertyName = "cNroDoc";
            this.cNroDoc.HeaderText = "Nro. Doc.";
            this.cNroDoc.Name = "cNroDoc";
            this.cNroDoc.ReadOnly = true;
            this.cNroDoc.Width = 78;
            // 
            // cRazonSocial
            // 
            this.cRazonSocial.DataPropertyName = "cRazonSocial";
            this.cRazonSocial.HeaderText = "Razon Social";
            this.cRazonSocial.Name = "cRazonSocial";
            this.cRazonSocial.ReadOnly = true;
            this.cRazonSocial.Width = 95;
            // 
            // cNombres
            // 
            this.cNombres.DataPropertyName = "cNombres";
            this.cNombres.HeaderText = "Nombres";
            this.cNombres.Name = "cNombres";
            this.cNombres.ReadOnly = true;
            this.cNombres.Width = 74;
            // 
            // cPaterno
            // 
            this.cPaterno.DataPropertyName = "cPaterno";
            this.cPaterno.HeaderText = "Ap. Paterno";
            this.cPaterno.Name = "cPaterno";
            this.cPaterno.ReadOnly = true;
            this.cPaterno.Width = 88;
            // 
            // cMaterno
            // 
            this.cMaterno.DataPropertyName = "cMaterno";
            this.cMaterno.HeaderText = "Ap. Materno";
            this.cMaterno.Name = "cMaterno";
            this.cMaterno.ReadOnly = true;
            this.cMaterno.Width = 90;
            // 
            // dMotivo
            // 
            this.dMotivo.DataPropertyName = "dMotivo";
            this.dMotivo.HeaderText = "Motivo";
            this.dMotivo.Name = "dMotivo";
            this.dMotivo.ReadOnly = true;
            this.dMotivo.Width = 64;
            // 
            // cDescripcion
            // 
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            this.cDescripcion.Width = 88;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "Vigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            this.lVigente.Width = 68;
            // 
            // cObservacion
            // 
            this.cObservacion.DataPropertyName = "cObservacion";
            this.cObservacion.FillWeight = 180F;
            this.cObservacion.HeaderText = "Obs";
            this.cObservacion.Name = "cObservacion";
            this.cObservacion.ReadOnly = true;
            this.cObservacion.Width = 51;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(864, 497);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.SystemColors.Control;
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(732, 497);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 5;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(66, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Ubicación:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Enabled = false;
            this.txtUbicacion.Location = new System.Drawing.Point(84, 12);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(647, 20);
            this.txtUbicacion.TabIndex = 7;
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Location = new System.Drawing.Point(798, 497);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 8;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dtgBNError
            // 
            this.dtgBNError.AllowUserToAddRows = false;
            this.dtgBNError.AllowUserToDeleteRows = false;
            this.dtgBNError.AllowUserToResizeColumns = false;
            this.dtgBNError.AllowUserToResizeRows = false;
            this.dtgBNError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgBNError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBNError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.cObservacion1});
            this.dtgBNError.Location = new System.Drawing.Point(12, 294);
            this.dtgBNError.MultiSelect = false;
            this.dtgBNError.Name = "dtgBNError";
            this.dtgBNError.ReadOnly = true;
            this.dtgBNError.RowHeadersVisible = false;
            this.dtgBNError.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBNError.Size = new System.Drawing.Size(913, 197);
            this.dtgBNError.TabIndex = 22;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cModulo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Modulo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 67;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cTipoPersona";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo Persona";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 95;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cTipoDocumento";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo Doc.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 79;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "cNroDoc";
            this.dataGridViewTextBoxColumn4.HeaderText = "Nro. Doc.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cRazonSocial";
            this.dataGridViewTextBoxColumn5.HeaderText = "Razon Social";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 95;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "cNombres";
            this.dataGridViewTextBoxColumn6.HeaderText = "Nombres";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 74;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "cPaterno";
            this.dataGridViewTextBoxColumn7.HeaderText = "Ap. Paterno";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 88;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "cMaterno";
            this.dataGridViewTextBoxColumn8.HeaderText = "Ap. Materno";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "dMotivo";
            this.dataGridViewTextBoxColumn9.HeaderText = "Motivo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 64;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "cDescripcion";
            this.dataGridViewTextBoxColumn10.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 88;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "lVigente";
            this.dataGridViewTextBoxColumn11.HeaderText = "Vigente";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 68;
            // 
            // cObservacion1
            // 
            this.cObservacion1.DataPropertyName = "cObservacion";
            this.cObservacion1.HeaderText = "Observación";
            this.cObservacion1.Name = "cObservacion1";
            this.cObservacion1.ReadOnly = true;
            this.cObservacion1.Width = 92;
            // 
            // lblBase7
            // 
            this.lblBase7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 37);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(913, 21);
            this.lblBase7.TabIndex = 75;
            this.lblBase7.Text = "LISTA DE BASE NEGATIVA A CARGAR";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBase2
            // 
            this.lblBase2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 271);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(913, 23);
            this.lblBase2.TabIndex = 76;
            this.lblBase2.Text = "LISTA DE BASE NEGATIVA CON ERRORES";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(670, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 77;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmBaseNegativaCargaLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 572);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.dtgBNError);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgClientesBaseNegativa);
            this.Name = "frmBaseNegativaCargaLote";
            this.Text = "Base Negativa Carga por Lote";
            this.Load += new System.EventHandler(this.frmBaseNegativaCargaLote_Load);
            this.Controls.SetChildIndex(this.dtgClientesBaseNegativa, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtUbicacion, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.dtgBNError, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesBaseNegativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBNError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgClientesBaseNegativa;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtUbicacion;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.ControlesBase.dtgBase dtgBNError;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacion;
    }
}