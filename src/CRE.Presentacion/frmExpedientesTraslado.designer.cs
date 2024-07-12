namespace CRE.Presentacion
{
    partial class frmExpedientesTraslado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedientesTraslado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtCBFiltro = new GEN.ControlesBase.txtCBLetra(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgTrasladoExp = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciaDes = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboPersCustodiaDes = new GEN.ControlesBase.cboPersonalGen(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPersonalCreditos = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.cboAgenciaOrig = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboPersCustodiaOrig = new GEN.ControlesBase.cboPersonalGen(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroExpediente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtFechaTraslado = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTrasladoExp)).BeginInit();
            this.grbBase4.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniBusq1);
            this.grbBase1.Controls.Add(this.txtCBFiltro);
            this.grbBase1.Controls.Add(this.chcTodos);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dtgTrasladoExp);
            this.grbBase1.Controls.Add(this.grbBase4);
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Controls.Add(this.txtNroExpediente);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtFechaTraslado);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(13, 13);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(673, 436);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos generales de la entrega de expedientes";
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(620, 149);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 90;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // txtCBFiltro
            // 
            this.txtCBFiltro.Location = new System.Drawing.Point(491, 157);
            this.txtCBFiltro.MaxLength = 10;
            this.txtCBFiltro.Name = "txtCBFiltro";
            this.txtCBFiltro.Size = new System.Drawing.Size(123, 20);
            this.txtCBFiltro.TabIndex = 89;
            this.txtCBFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCBFiltro.TextChanged += new System.EventHandler(this.txtCBFiltro_TextChanged);
            this.txtCBFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCBFiltro_KeyPress);
            this.txtCBFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCBFiltro_KeyUp);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(16, 412);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 88;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(354, 160);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(130, 13);
            this.lblBase8.TabIndex = 25;
            this.lblBase8.Text = "Filtro nro expediente:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 160);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(81, 13);
            this.lblBase5.TabIndex = 25;
            this.lblBase5.Text = "Expedientes:";
            // 
            // dtgTrasladoExp
            // 
            this.dtgTrasladoExp.AllowUserToAddRows = false;
            this.dtgTrasladoExp.AllowUserToDeleteRows = false;
            this.dtgTrasladoExp.AllowUserToResizeColumns = false;
            this.dtgTrasladoExp.AllowUserToResizeRows = false;
            this.dtgTrasladoExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTrasladoExp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgTrasladoExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTrasladoExp.DefaultCellStyle = dataGridViewCellStyle17;
            this.dtgTrasladoExp.Location = new System.Drawing.Point(16, 183);
            this.dtgTrasladoExp.MultiSelect = false;
            this.dtgTrasladoExp.Name = "dtgTrasladoExp";
            this.dtgTrasladoExp.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTrasladoExp.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgTrasladoExp.RowHeadersVisible = false;
            this.dtgTrasladoExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTrasladoExp.Size = new System.Drawing.Size(639, 223);
            this.dtgTrasladoExp.TabIndex = 24;
            this.dtgTrasladoExp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTrasladoExp_CellContentClick);
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.cboAgenciaDes);
            this.grbBase4.Controls.Add(this.cboPersCustodiaDes);
            this.grbBase4.Controls.Add(this.lblBase1);
            this.grbBase4.Controls.Add(this.lblBase7);
            this.grbBase4.Location = new System.Drawing.Point(334, 55);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(321, 75);
            this.grbBase4.TabIndex = 23;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Destino";
            // 
            // cboAgenciaDes
            // 
            this.cboAgenciaDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaDes.FormattingEnabled = true;
            this.cboAgenciaDes.Location = new System.Drawing.Point(129, 17);
            this.cboAgenciaDes.Name = "cboAgenciaDes";
            this.cboAgenciaDes.Size = new System.Drawing.Size(148, 21);
            this.cboAgenciaDes.TabIndex = 22;
            this.cboAgenciaDes.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaDes_SelectedIndexChanged);
            // 
            // cboPersCustodiaDes
            // 
            this.cboPersCustodiaDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersCustodiaDes.FormattingEnabled = true;
            this.cboPersCustodiaDes.Location = new System.Drawing.Point(129, 44);
            this.cboPersCustodiaDes.Name = "cboPersCustodiaDes";
            this.cboPersCustodiaDes.Size = new System.Drawing.Size(181, 21);
            this.cboPersCustodiaDes.TabIndex = 21;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 47);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(114, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Recepcionado por:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 20);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(51, 13);
            this.lblBase7.TabIndex = 19;
            this.lblBase7.Text = "Oficina:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboPersonalCreditos);
            this.grbBase2.Controls.Add(this.cboAgenciaOrig);
            this.grbBase2.Controls.Add(this.cboPersCustodiaOrig);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Location = new System.Drawing.Point(16, 55);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(312, 104);
            this.grbBase2.TabIndex = 22;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Orígen";
            // 
            // cboPersonalCreditos
            // 
            this.cboPersonalCreditos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonalCreditos.FormattingEnabled = true;
            this.cboPersonalCreditos.Location = new System.Drawing.Point(106, 44);
            this.cboPersonalCreditos.Name = "cboPersonalCreditos";
            this.cboPersonalCreditos.Size = new System.Drawing.Size(196, 21);
            this.cboPersonalCreditos.TabIndex = 21;
            this.cboPersonalCreditos.SelectedIndexChanged += new System.EventHandler(this.cboPersonalCreditos_SelectedIndexChanged);
            // 
            // cboAgenciaOrig
            // 
            this.cboAgenciaOrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaOrig.Enabled = false;
            this.cboAgenciaOrig.FormattingEnabled = true;
            this.cboAgenciaOrig.Location = new System.Drawing.Point(106, 17);
            this.cboAgenciaOrig.Name = "cboAgenciaOrig";
            this.cboAgenciaOrig.Size = new System.Drawing.Size(169, 21);
            this.cboAgenciaOrig.TabIndex = 20;
            this.cboAgenciaOrig.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaOrig_SelectedIndexChanged);
            // 
            // cboPersCustodiaOrig
            // 
            this.cboPersCustodiaOrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersCustodiaOrig.Enabled = false;
            this.cboPersCustodiaOrig.FormattingEnabled = true;
            this.cboPersCustodiaOrig.Location = new System.Drawing.Point(106, 70);
            this.cboPersCustodiaOrig.Name = "cboPersCustodiaOrig";
            this.cboPersCustodiaOrig.Size = new System.Drawing.Size(196, 21);
            this.cboPersCustodiaOrig.TabIndex = 12;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(6, 47);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(51, 13);
            this.lblBase9.TabIndex = 16;
            this.lblBase9.Text = "Asesor:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Oficina:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 73);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(93, 13);
            this.lblBase4.TabIndex = 17;
            this.lblBase4.Text = "Entregado por:";
            // 
            // txtNroExpediente
            // 
            this.txtNroExpediente.Location = new System.Drawing.Point(498, 29);
            this.txtNroExpediente.Name = "txtNroExpediente";
            this.txtNroExpediente.ReadOnly = true;
            this.txtNroExpediente.Size = new System.Drawing.Size(58, 20);
            this.txtNroExpediente.TabIndex = 15;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(340, 32);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(154, 13);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "Cantidad de expedientes:";
            // 
            // dtFechaTraslado
            // 
            this.dtFechaTraslado.Location = new System.Drawing.Point(139, 29);
            this.dtFechaTraslado.Name = "dtFechaTraslado";
            this.dtFechaTraslado.Size = new System.Drawing.Size(169, 20);
            this.dtFechaTraslado.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(22, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(111, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Fecha de entrega:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(624, 455);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(564, 455);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 19;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(504, 455);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 20;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmExpedientesTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 540);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmExpedientesTraslado";
            this.Text = "Traslado de expedientes";
            this.Load += new System.EventHandler(this.frmExpedientesTraslado_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTrasladoExp)).EndInit();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtNroExpediente;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboPersonalGen cboPersCustodiaOrig;
        private GEN.ControlesBase.dtLargoBase dtFechaTraslado;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAgencias cboAgenciaOrig;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgTrasladoExp;
        private GEN.ControlesBase.cboAgencias cboAgenciaDes;
        private GEN.ControlesBase.cboPersonalGen cboPersCustodiaDes;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtCBLetra txtCBFiltro;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditos;
    }
}