namespace CRE.Presentacion
{
    partial class frmEgresosAgricola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEgresosAgricola));
            this.btnAceptar = new GEN.BotonesBase.btnMiniAcept(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNIngreso = new GEN.ControlesBase.txtNumerico(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnMiniCancelEst();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMesesCultivo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboEtapaCultivoEval = new GEN.ControlesBase.cboEtapaCultivoEval(this.components);
            this.cboActividadPorEtapaCultivoEval = new GEN.ControlesBase.cboActividadPorEtapaCultivoEval(this.components);
            this.cboUnidadProd = new GEN.ControlesBase.cboUnidadProductivaEval(this.components);
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgEgresos = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.txtNTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbGrupoForm = new GEN.ControlesBase.grbBase(this.components);
            this.txtNTotalEgreso = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtNUnidadesFinanciadas = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnEditar = new GEN.BotonesBase.btnMiniEditar();
            this.btnNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEgresos)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.grbGrupoForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(235, 202);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(36, 28);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(85, 149);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(99, 13);
            this.lblBase7.TabIndex = 52;
            this.lblBase7.Text = "Egreso/Uni Prod";
            // 
            // txtNIngreso
            // 
            this.txtNIngreso.Format = "n2";
            this.txtNIngreso.Location = new System.Drawing.Point(192, 146);
            this.txtNIngreso.MaxLength = 10;
            this.txtNIngreso.Name = "txtNIngreso";
            this.txtNIngreso.Size = new System.Drawing.Size(99, 20);
            this.txtNIngreso.TabIndex = 6;
            this.txtNIngreso.TextChanged += new System.EventHandler(this.txtNIngreso_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(277, 202);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 28);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(74, 97);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(110, 13);
            this.lblBase2.TabIndex = 39;
            this.lblBase2.Text = "Unidad Productiva";
            // 
            // cboMesesCultivo
            // 
            this.cboMesesCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesesCultivo.FormattingEnabled = true;
            this.cboMesesCultivo.Location = new System.Drawing.Point(192, 13);
            this.cboMesesCultivo.Name = "cboMesesCultivo";
            this.cboMesesCultivo.Size = new System.Drawing.Size(163, 21);
            this.cboMesesCultivo.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(94, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(90, 13);
            this.lblBase1.TabIndex = 32;
            this.lblBase1.Text = "Mes de egreso";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(63, 70);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(121, 13);
            this.lblBase3.TabIndex = 55;
            this.lblBase3.Text = "Actividad de Cultivo";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(83, 43);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(101, 13);
            this.lblBase4.TabIndex = 56;
            this.lblBase4.Text = "Etapa de Cultivo";
            // 
            // cboEtapaCultivoEval
            // 
            this.cboEtapaCultivoEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtapaCultivoEval.FormattingEnabled = true;
            this.cboEtapaCultivoEval.Location = new System.Drawing.Point(192, 40);
            this.cboEtapaCultivoEval.Name = "cboEtapaCultivoEval";
            this.cboEtapaCultivoEval.Size = new System.Drawing.Size(163, 21);
            this.cboEtapaCultivoEval.TabIndex = 2;
            this.cboEtapaCultivoEval.SelectedIndexChanged += new System.EventHandler(this.cboEtapaCultivoEval_SelectedIndexChanged);
            // 
            // cboActividadPorEtapaCultivoEval
            // 
            this.cboActividadPorEtapaCultivoEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadPorEtapaCultivoEval.FormattingEnabled = true;
            this.cboActividadPorEtapaCultivoEval.Location = new System.Drawing.Point(192, 67);
            this.cboActividadPorEtapaCultivoEval.Name = "cboActividadPorEtapaCultivoEval";
            this.cboActividadPorEtapaCultivoEval.Size = new System.Drawing.Size(163, 21);
            this.cboActividadPorEtapaCultivoEval.TabIndex = 3;
            // 
            // cboUnidadProd
            // 
            this.cboUnidadProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadProd.FormattingEnabled = true;
            this.cboUnidadProd.Location = new System.Drawing.Point(192, 94);
            this.cboUnidadProd.Name = "cboUnidadProd";
            this.cboUnidadProd.Size = new System.Drawing.Size(163, 21);
            this.cboUnidadProd.TabIndex = 4;
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(11, 262);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(693, 167);
            this.panelGlobal.TabIndex = 60;
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(691, 165);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgEgresos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 141);
            this.panel2.TabIndex = 25;
            // 
            // dtgEgresos
            // 
            this.dtgEgresos.AllowUserToAddRows = false;
            this.dtgEgresos.AllowUserToDeleteRows = false;
            this.dtgEgresos.AllowUserToResizeColumns = false;
            this.dtgEgresos.AllowUserToResizeRows = false;
            this.dtgEgresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEgresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgEgresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEgresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEgresos.Location = new System.Drawing.Point(0, 0);
            this.dtgEgresos.MultiSelect = false;
            this.dtgEgresos.Name = "dtgEgresos";
            this.dtgEgresos.ReadOnly = true;
            this.dtgEgresos.RowHeadersVisible = false;
            this.dtgEgresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEgresos.Size = new System.Drawing.Size(691, 141);
            this.dtgEgresos.TabIndex = 28;
            this.dtgEgresos.TabStop = false;
            this.dtgEgresos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEgresos_CellClick);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(691, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 101;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 100;
            this.label2.Text = "Egresos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(643, 471);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 61;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtNTotal
            // 
            this.txtNTotal.Enabled = false;
            this.txtNTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNTotal.FormatoDecimal = false;
            this.txtNTotal.Location = new System.Drawing.Point(592, 435);
            this.txtNTotal.Name = "txtNTotal";
            this.txtNTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNTotal.nNumDecimales = 4;
            this.txtNTotal.nvalor = 0D;
            this.txtNTotal.ReadOnly = true;
            this.txtNTotal.Size = new System.Drawing.Size(110, 20);
            this.txtNTotal.TabIndex = 62;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(552, 438);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(34, 13);
            this.lblBase5.TabIndex = 63;
            this.lblBase5.Text = "Total";
            // 
            // grbGrupoForm
            // 
            this.grbGrupoForm.BackColor = System.Drawing.SystemColors.Control;
            this.grbGrupoForm.Controls.Add(this.txtNTotalEgreso);
            this.grbGrupoForm.Controls.Add(this.lblBase8);
            this.grbGrupoForm.Controls.Add(this.txtNUnidadesFinanciadas);
            this.grbGrupoForm.Controls.Add(this.lblBase6);
            this.grbGrupoForm.Controls.Add(this.btnQuitar);
            this.grbGrupoForm.Controls.Add(this.btnEditar);
            this.grbGrupoForm.Controls.Add(this.cboEtapaCultivoEval);
            this.grbGrupoForm.Controls.Add(this.lblBase4);
            this.grbGrupoForm.Controls.Add(this.btnNuevo);
            this.grbGrupoForm.Controls.Add(this.lblBase3);
            this.grbGrupoForm.Controls.Add(this.cboMesesCultivo);
            this.grbGrupoForm.Controls.Add(this.cboActividadPorEtapaCultivoEval);
            this.grbGrupoForm.Controls.Add(this.lblBase1);
            this.grbGrupoForm.Controls.Add(this.lblBase2);
            this.grbGrupoForm.Controls.Add(this.btnCancelar);
            this.grbGrupoForm.Controls.Add(this.txtNIngreso);
            this.grbGrupoForm.Controls.Add(this.cboUnidadProd);
            this.grbGrupoForm.Controls.Add(this.lblBase7);
            this.grbGrupoForm.Controls.Add(this.btnAceptar);
            this.grbGrupoForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGrupoForm.Location = new System.Drawing.Point(12, 12);
            this.grbGrupoForm.Name = "grbGrupoForm";
            this.grbGrupoForm.Size = new System.Drawing.Size(404, 244);
            this.grbGrupoForm.TabIndex = 64;
            this.grbGrupoForm.TabStop = false;
            this.grbGrupoForm.Text = "Egreso";
            // 
            // txtNTotalEgreso
            // 
            this.txtNTotalEgreso.Enabled = false;
            this.txtNTotalEgreso.FormatoDecimal = false;
            this.txtNTotalEgreso.Location = new System.Drawing.Point(192, 170);
            this.txtNTotalEgreso.Name = "txtNTotalEgreso";
            this.txtNTotalEgreso.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNTotalEgreso.nNumDecimales = 4;
            this.txtNTotalEgreso.nvalor = 0D;
            this.txtNTotalEgreso.Size = new System.Drawing.Size(100, 20);
            this.txtNTotalEgreso.TabIndex = 7;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(107, 173);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(77, 13);
            this.lblBase8.TabIndex = 59;
            this.lblBase8.Text = "Egreso Total";
            // 
            // txtNUnidadesFinanciadas
            // 
            this.txtNUnidadesFinanciadas.Enabled = false;
            this.txtNUnidadesFinanciadas.Format = "n2";
            this.txtNUnidadesFinanciadas.Location = new System.Drawing.Point(192, 121);
            this.txtNUnidadesFinanciadas.MaxLength = 10;
            this.txtNUnidadesFinanciadas.Name = "txtNUnidadesFinanciadas";
            this.txtNUnidadesFinanciadas.Size = new System.Drawing.Size(99, 20);
            this.txtNUnidadesFinanciadas.TabIndex = 5;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(77, 124);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(107, 13);
            this.lblBase6.TabIndex = 58;
            this.lblBase6.Text = "N° Unidades Prod";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(319, 202);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(193, 202);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(36, 28);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(151, 202);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmEgresosAgricola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(716, 549);
            this.Controls.Add(this.grbGrupoForm);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtNTotal);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.panelGlobal);
            this.Name = "frmEgresosAgricola";
            this.Text = "Registro de Egresos";
            this.Load += new System.EventHandler(this.frmEgresosAgricola_Load);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.txtNTotal, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.grbGrupoForm, 0);
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEgresos)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.grbGrupoForm.ResumeLayout(false);
            this.grbGrupoForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnMiniAcept btnAceptar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumerico txtNIngreso;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboMesesCultivo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboEtapaCultivoEval cboEtapaCultivoEval;
        private GEN.ControlesBase.cboActividadPorEtapaCultivoEval cboActividadPorEtapaCultivoEval;
        private GEN.ControlesBase.cboUnidadProductivaEval cboUnidadProd;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgEgresos;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label2;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtNumRea txtNTotal;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbGrupoForm;
        private GEN.BotonesBase.btnMiniQuitar btnQuitar;
        private GEN.BotonesBase.btnMiniEditar btnEditar;
        private GEN.BotonesBase.btnMiniNuevo btnNuevo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private GEN.ControlesBase.txtNumerico txtNUnidadesFinanciadas;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtNTotalEgreso;
        private GEN.ControlesBase.lblBase lblBase8;

    }
}