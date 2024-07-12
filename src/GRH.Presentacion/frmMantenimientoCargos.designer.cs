namespace GRH.Presentacion
{
    partial class frmMantenimientoCargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoCargos));
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgCargos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNombCargo = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtPorcentaje = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboArea1 = new GEN.ControlesBase.cboArea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCorreoB = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoCargo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.CBVigente = new System.Windows.Forms.CheckBox();
            this.cboNivelPersonal1 = new GEN.ControlesBase.cboNivelPersonal(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(257, 465);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(195, 465);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(443, 465);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(319, 465);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
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
            this.btnCancelar.Location = new System.Drawing.Point(381, 465);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgCargos
            // 
            this.dtgCargos.AllowUserToAddRows = false;
            this.dtgCargos.AllowUserToDeleteRows = false;
            this.dtgCargos.AllowUserToResizeColumns = false;
            this.dtgCargos.AllowUserToResizeRows = false;
            this.dtgCargos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCargos.Location = new System.Drawing.Point(12, 152);
            this.dtgCargos.MultiSelect = false;
            this.dtgCargos.Name = "dtgCargos";
            this.dtgCargos.ReadOnly = true;
            this.dtgCargos.RowHeadersVisible = false;
            this.dtgCargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCargos.Size = new System.Drawing.Size(491, 307);
            this.dtgCargos.TabIndex = 1;
            this.dtgCargos.SelectionChanged += new System.EventHandler(this.dtgCargos_SelectionChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(18, 26);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 38;
            this.lblBase5.Text = "Nombre:";
            // 
            // txtNombCargo
            // 
            this.txtNombCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombCargo.Location = new System.Drawing.Point(81, 23);
            this.txtNombCargo.MaxLength = 80;
            this.txtNombCargo.Name = "txtNombCargo";
            this.txtNombCargo.Size = new System.Drawing.Size(395, 20);
            this.txtNombCargo.TabIndex = 0;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(401, 76);
            this.txtPorcentaje.MaxLength = 5;
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(53, 20);
            this.txtPorcentaje.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(457, 81);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(19, 13);
            this.lblBase2.TabIndex = 42;
            this.lblBase2.Text = "%";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 52);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(39, 13);
            this.lblBase3.TabIndex = 43;
            this.lblBase3.Text = "Área:";
            // 
            // cboArea1
            // 
            this.cboArea1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea1.FormattingEnabled = true;
            this.cboArea1.Location = new System.Drawing.Point(81, 49);
            this.cboArea1.Name = "cboArea1";
            this.cboArea1.Size = new System.Drawing.Size(129, 21);
            this.cboArea1.TabIndex = 1;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(18, 79);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(40, 13);
            this.lblBase4.TabIndex = 45;
            this.lblBase4.Text = "Nivel:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtCorreoB);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboTipoCargo);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.cboNivelPersonal1);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtPorcentaje);
            this.grbBase1.Controls.Add(this.txtNombCargo);
            this.grbBase1.Controls.Add(this.cboArea1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 11);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(491, 135);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cargo";
            // 
            // txtCorreoB
            // 
            this.txtCorreoB.Location = new System.Drawing.Point(139, 106);
            this.txtCorreoB.MaxLength = 200;
            this.txtCorreoB.Name = "txtCorreoB";
            this.txtCorreoB.Size = new System.Drawing.Size(256, 20);
            this.txtCorreoB.TabIndex = 53;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(18, 108);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(115, 13);
            this.lblBase1.TabIndex = 52;
            this.lblBase1.Tag = "";
            this.lblBase1.Text = "Grupo de Correos:";
            // 
            // cboTipoCargo
            // 
            this.cboTipoCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCargo.FormattingEnabled = true;
            this.cboTipoCargo.Location = new System.Drawing.Point(355, 49);
            this.cboTipoCargo.Name = "cboTipoCargo";
            this.cboTipoCargo.Size = new System.Drawing.Size(121, 21);
            this.cboTipoCargo.TabIndex = 50;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(256, 52);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(93, 13);
            this.lblBase7.TabIndex = 49;
            this.lblBase7.Text = "Tipo de Cargo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(256, 79);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(139, 13);
            this.lblBase6.TabIndex = 48;
            this.lblBase6.Text = "Porcentaje de Viáticos:";
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.Location = new System.Drawing.Point(416, 108);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 4;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // cboNivelPersonal1
            // 
            this.cboNivelPersonal1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelPersonal1.FormattingEnabled = true;
            this.cboNivelPersonal1.Location = new System.Drawing.Point(81, 76);
            this.cboNivelPersonal1.Name = "cboNivelPersonal1";
            this.cboNivelPersonal1.Size = new System.Drawing.Size(129, 21);
            this.cboNivelPersonal1.TabIndex = 2;
            // 
            // frmMantenimientoCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 541);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgCargos);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmMantenimientoCargos";
            this.Text = "Mantenimiento de Cargos";
            this.Load += new System.EventHandler(this.frmMantenimientoCargos_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.dtgCargos, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgCargos;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtCBLetra txtNombCargo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtPorcentaje;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboArea cboArea1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.CheckBox CBVigente;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboNivelPersonal cboNivelPersonal1;
        private GEN.ControlesBase.cboBase cboTipoCargo;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCorreoB;
    }
}