namespace GRH.Presentacion
{
    partial class frmGeneracionPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneracionPlanilla));
            this.cboPeriodoPlanilla = new GEN.ControlesBase.cboPeriodoPlanilla(this.components);
            this.cboModalidadPlanilla = new GEN.ControlesBase.cboModalidadPlanilla(this.components);
            this.cboRelacionLabInst = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtgPlanillaPersona = new GEN.ControlesBase.dtgBase(this.components);
            this.cmsPlanillaPersona = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiCargaIndividual = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboPeriodoDeclaracion = new GEN.ControlesBase.cboPeriodoDeclaracion(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnCerrar = new GEN.BotonesBase.btnCerrar();
            this.dtgtxtTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtDiaComputable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMinDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtRemuneraBasica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMontoIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMontoDescuentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMontoAportes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMontoDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillaPersona)).BeginInit();
            this.cmsPlanillaPersona.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPeriodoPlanilla
            // 
            this.cboPeriodoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoPlanilla.FormattingEnabled = true;
            this.cboPeriodoPlanilla.Location = new System.Drawing.Point(463, 10);
            this.cboPeriodoPlanilla.Name = "cboPeriodoPlanilla";
            this.cboPeriodoPlanilla.Size = new System.Drawing.Size(100, 21);
            this.cboPeriodoPlanilla.TabIndex = 2;
            // 
            // cboModalidadPlanilla
            // 
            this.cboModalidadPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadPlanilla.FormattingEnabled = true;
            this.cboModalidadPlanilla.Location = new System.Drawing.Point(116, 56);
            this.cboModalidadPlanilla.Name = "cboModalidadPlanilla";
            this.cboModalidadPlanilla.Size = new System.Drawing.Size(200, 21);
            this.cboModalidadPlanilla.TabIndex = 3;
            // 
            // cboRelacionLabInst
            // 
            this.cboRelacionLabInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst.FormattingEnabled = true;
            this.cboRelacionLabInst.Location = new System.Drawing.Point(116, 10);
            this.cboRelacionLabInst.Name = "cboRelacionLabInst";
            this.cboRelacionLabInst.Size = new System.Drawing.Size(200, 21);
            this.cboRelacionLabInst.TabIndex = 4;
            this.cboRelacionLabInst.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst_SelectedIndexChanged);
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(116, 33);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(200, 21);
            this.cboTipoPlanilla.TabIndex = 5;
            this.cboTipoPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Clasificación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 37);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Tipo de Planilla:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 60);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(69, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Modalidad:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(335, 14);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(99, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Periodo Planilla:";
            // 
            // dtgPlanillaPersona
            // 
            this.dtgPlanillaPersona.AllowUserToAddRows = false;
            this.dtgPlanillaPersona.AllowUserToDeleteRows = false;
            this.dtgPlanillaPersona.AllowUserToResizeColumns = false;
            this.dtgPlanillaPersona.AllowUserToResizeRows = false;
            this.dtgPlanillaPersona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanillaPersona.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPlanillaPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillaPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtTipoPlanilla,
            this.dtgtxtIdUsuario,
            this.dtgtxtNombre,
            this.dtgtxtIdAgencia,
            this.dtgtxtIdCargo,
            this.dtgtxtDiaComputable,
            this.dtgtxtMinDescuento,
            this.dtgtxtRemuneraBasica,
            this.dtgtxtMontoIngresos,
            this.dtgtxtMontoDescuentos,
            this.dtgtxtMontoAportes,
            this.dtgtxtMontoDeposito});
            this.dtgPlanillaPersona.ContextMenuStrip = this.cmsPlanillaPersona;
            this.dtgPlanillaPersona.Location = new System.Drawing.Point(8, 85);
            this.dtgPlanillaPersona.MultiSelect = false;
            this.dtgPlanillaPersona.Name = "dtgPlanillaPersona";
            this.dtgPlanillaPersona.ReadOnly = true;
            this.dtgPlanillaPersona.RowHeadersVisible = false;
            this.dtgPlanillaPersona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillaPersona.Size = new System.Drawing.Size(700, 301);
            this.dtgPlanillaPersona.TabIndex = 10;
            this.dtgPlanillaPersona.DoubleClick += new System.EventHandler(this.dtgPlanillaPersona_DoubleClick);
            // 
            // cmsPlanillaPersona
            // 
            this.cmsPlanillaPersona.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiCargaIndividual,
            this.smiEliminar});
            this.cmsPlanillaPersona.Name = "cmsPlanillaPersona";
            this.cmsPlanillaPersona.Size = new System.Drawing.Size(161, 48);
            // 
            // smiCargaIndividual
            // 
            this.smiCargaIndividual.Name = "smiCargaIndividual";
            this.smiCargaIndividual.Size = new System.Drawing.Size(160, 22);
            this.smiCargaIndividual.Text = "Carga Individual";
            this.smiCargaIndividual.Click += new System.EventHandler(this.smiCargaIndividual_Click);
            // 
            // smiEliminar
            // 
            this.smiEliminar.Name = "smiEliminar";
            this.smiEliminar.Size = new System.Drawing.Size(160, 22);
            this.smiEliminar.Text = "Eliminar";
            this.smiEliminar.Click += new System.EventHandler(this.smiEliminar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(584, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(335, 37);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(126, 13);
            this.lblBase5.TabIndex = 14;
            this.lblBase5.Text = "Periodo Declaración:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(648, 393);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboPeriodoDeclaracion
            // 
            this.cboPeriodoDeclaracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoDeclaracion.FormattingEnabled = true;
            this.cboPeriodoDeclaracion.Location = new System.Drawing.Point(463, 33);
            this.cboPeriodoDeclaracion.Name = "cboPeriodoDeclaracion";
            this.cboPeriodoDeclaracion.Size = new System.Drawing.Size(100, 21);
            this.cboPeriodoDeclaracion.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(648, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.BackgroundImage")));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCerrar.Location = new System.Drawing.Point(328, 393);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 50);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Ce&rrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dtgtxtTipoPlanilla
            // 
            this.dtgtxtTipoPlanilla.DataPropertyName = "idTipoPlanilla";
            this.dtgtxtTipoPlanilla.HeaderText = "idTipoPlanilla";
            this.dtgtxtTipoPlanilla.Name = "dtgtxtTipoPlanilla";
            this.dtgtxtTipoPlanilla.ReadOnly = true;
            this.dtgtxtTipoPlanilla.Visible = false;
            // 
            // dtgtxtIdUsuario
            // 
            this.dtgtxtIdUsuario.DataPropertyName = "idUsuario";
            this.dtgtxtIdUsuario.HeaderText = "idUsuario";
            this.dtgtxtIdUsuario.Name = "dtgtxtIdUsuario";
            this.dtgtxtIdUsuario.ReadOnly = true;
            this.dtgtxtIdUsuario.Visible = false;
            // 
            // dtgtxtNombre
            // 
            this.dtgtxtNombre.DataPropertyName = "cNombre";
            this.dtgtxtNombre.HeaderText = "Apellidos y Nombres";
            this.dtgtxtNombre.MinimumWidth = 180;
            this.dtgtxtNombre.Name = "dtgtxtNombre";
            this.dtgtxtNombre.ReadOnly = true;
            // 
            // dtgtxtIdAgencia
            // 
            this.dtgtxtIdAgencia.DataPropertyName = "idAgencia";
            this.dtgtxtIdAgencia.HeaderText = "idAgencia";
            this.dtgtxtIdAgencia.Name = "dtgtxtIdAgencia";
            this.dtgtxtIdAgencia.ReadOnly = true;
            this.dtgtxtIdAgencia.Visible = false;
            // 
            // dtgtxtIdCargo
            // 
            this.dtgtxtIdCargo.DataPropertyName = "idCargo";
            this.dtgtxtIdCargo.HeaderText = "idCargo";
            this.dtgtxtIdCargo.Name = "dtgtxtIdCargo";
            this.dtgtxtIdCargo.ReadOnly = true;
            this.dtgtxtIdCargo.Visible = false;
            // 
            // dtgtxtDiaComputable
            // 
            this.dtgtxtDiaComputable.DataPropertyName = "nDiaComputable";
            this.dtgtxtDiaComputable.HeaderText = "Días Comp.";
            this.dtgtxtDiaComputable.MinimumWidth = 70;
            this.dtgtxtDiaComputable.Name = "dtgtxtDiaComputable";
            this.dtgtxtDiaComputable.ReadOnly = true;
            // 
            // dtgtxtMinDescuento
            // 
            this.dtgtxtMinDescuento.DataPropertyName = "nMinDescuento";
            this.dtgtxtMinDescuento.HeaderText = "nMinDescuento";
            this.dtgtxtMinDescuento.Name = "dtgtxtMinDescuento";
            this.dtgtxtMinDescuento.ReadOnly = true;
            this.dtgtxtMinDescuento.Visible = false;
            // 
            // dtgtxtRemuneraBasica
            // 
            this.dtgtxtRemuneraBasica.DataPropertyName = "nRemuneraBasica";
            this.dtgtxtRemuneraBasica.HeaderText = "Remuneración Básica";
            this.dtgtxtRemuneraBasica.MinimumWidth = 80;
            this.dtgtxtRemuneraBasica.Name = "dtgtxtRemuneraBasica";
            this.dtgtxtRemuneraBasica.ReadOnly = true;
            // 
            // dtgtxtMontoIngresos
            // 
            this.dtgtxtMontoIngresos.DataPropertyName = "nMontoIngresos";
            this.dtgtxtMontoIngresos.HeaderText = "Total Ingresos";
            this.dtgtxtMontoIngresos.MinimumWidth = 70;
            this.dtgtxtMontoIngresos.Name = "dtgtxtMontoIngresos";
            this.dtgtxtMontoIngresos.ReadOnly = true;
            // 
            // dtgtxtMontoDescuentos
            // 
            this.dtgtxtMontoDescuentos.DataPropertyName = "nMontoDescuentos";
            this.dtgtxtMontoDescuentos.HeaderText = "Total Descuentos";
            this.dtgtxtMontoDescuentos.MinimumWidth = 70;
            this.dtgtxtMontoDescuentos.Name = "dtgtxtMontoDescuentos";
            this.dtgtxtMontoDescuentos.ReadOnly = true;
            // 
            // dtgtxtMontoAportes
            // 
            this.dtgtxtMontoAportes.DataPropertyName = "nMontoAportes";
            this.dtgtxtMontoAportes.HeaderText = "Total Aportes";
            this.dtgtxtMontoAportes.MinimumWidth = 70;
            this.dtgtxtMontoAportes.Name = "dtgtxtMontoAportes";
            this.dtgtxtMontoAportes.ReadOnly = true;
            // 
            // dtgtxtMontoDeposito
            // 
            this.dtgtxtMontoDeposito.DataPropertyName = "nMontoDeposito";
            this.dtgtxtMontoDeposito.HeaderText = "Monto a Depositar";
            this.dtgtxtMontoDeposito.MinimumWidth = 70;
            this.dtgtxtMontoDeposito.Name = "dtgtxtMontoDeposito";
            this.dtgtxtMontoDeposito.ReadOnly = true;
            // 
            // frmGeneracionPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 470);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboPeriodoDeclaracion);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgPlanillaPersona);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoPlanilla);
            this.Controls.Add(this.cboRelacionLabInst);
            this.Controls.Add(this.cboModalidadPlanilla);
            this.Controls.Add(this.cboPeriodoPlanilla);
            this.Name = "frmGeneracionPlanilla";
            this.Text = "Generación de Planilla";
            this.Load += new System.EventHandler(this.frmGeneracionPlanilla_Load);
            this.Controls.SetChildIndex(this.cboPeriodoPlanilla, 0);
            this.Controls.SetChildIndex(this.cboModalidadPlanilla, 0);
            this.Controls.SetChildIndex(this.cboRelacionLabInst, 0);
            this.Controls.SetChildIndex(this.cboTipoPlanilla, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtgPlanillaPersona, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.cboPeriodoDeclaracion, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillaPersona)).EndInit();
            this.cmsPlanillaPersona.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboPeriodoPlanilla cboPeriodoPlanilla;
        private GEN.ControlesBase.cboModalidadPlanilla cboModalidadPlanilla;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtgBase dtgPlanillaPersona;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboPeriodoDeclaracion cboPeriodoDeclaracion;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.ContextMenuStrip cmsPlanillaPersona;
        private System.Windows.Forms.ToolStripMenuItem smiCargaIndividual;
        private System.Windows.Forms.ToolStripMenuItem smiEliminar;
        private GEN.BotonesBase.btnCerrar btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtDiaComputable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMinDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtRemuneraBasica;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMontoIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMontoDescuentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMontoAportes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMontoDeposito;
    }
}

