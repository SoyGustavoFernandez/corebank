namespace GEN.ControlesBase
{
    partial class ConReferencias
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConReferencias));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboTipVinculoEval = new GEN.ControlesBase.cboBase(this.components);
            this.txtTelefono = new GEN.ControlesBase.txtTelefCel(this.components);
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.bindingReferencia = new System.Windows.Forms.BindingSource(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtComentarios = new GEN.ControlesBase.txtBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgReferencia = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEstado = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipReferEval = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingReferencia)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferencia)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // cboTipVinculoEval
            // 
            this.cboTipVinculoEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipVinculoEval.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboTipVinculoEval, -28);
            this.cboTipVinculoEval.Location = new System.Drawing.Point(135, 105);
            this.cboTipVinculoEval.Name = "cboTipVinculoEval";
            this.cboTipVinculoEval.Size = new System.Drawing.Size(121, 21);
            this.cboTipVinculoEval.TabIndex = 5;
            this.cboTipVinculoEval.Validating += new System.ComponentModel.CancelEventHandler(this.cboTipVinculoEval_Validating);
            // 
            // txtTelefono
            // 
            this.errorProvider.SetIconPadding(this.txtTelefono, -20);
            this.txtTelefono.Location = new System.Drawing.Point(135, 83);
            this.txtTelefono.MaxLength = 9;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(84, 20);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorProvider.SetIconPadding(this.txtDireccion, -20);
            this.txtDireccion.Location = new System.Drawing.Point(135, 61);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(344, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorProvider.SetIconPadding(this.txtEmpresa, -18);
            this.txtEmpresa.Location = new System.Drawing.Point(135, 39);
            this.txtEmpresa.MaxLength = 100;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(344, 20);
            this.txtEmpresa.TabIndex = 2;
            this.txtEmpresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.txtComentarios);
            this.grbBase2.Controls.Add(this.cboTipVinculoEval);
            this.grbBase2.Controls.Add(this.btnNuevo);
            this.grbBase2.Controls.Add(this.panelGlobal);
            this.grbBase2.Controls.Add(this.txtTelefono);
            this.grbBase2.Controls.Add(this.txtDireccion);
            this.grbBase2.Controls.Add(this.cboEstado);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.cboTipReferEval);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.txtEmpresa);
            this.grbBase2.Location = new System.Drawing.Point(3, 3);
            this.grbBase2.Margin = new System.Windows.Forms.Padding(5);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(484, 353);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Referencias";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(53, 151);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(80, 13);
            this.lblBase8.TabIndex = 109;
            this.lblBase8.Text = "Comentarios";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(135, 151);
            this.txtComentarios.MaxLength = 200;
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(342, 58);
            this.txtComentarios.TabIndex = 7;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(443, 117);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(4, 211);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(474, 138);
            this.panelGlobal.TabIndex = 24;
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(472, 136);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgReferencia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 112);
            this.panel2.TabIndex = 25;
            // 
            // dtgReferencia
            // 
            this.dtgReferencia.AllowUserToAddRows = false;
            this.dtgReferencia.AllowUserToDeleteRows = false;
            this.dtgReferencia.AllowUserToResizeColumns = false;
            this.dtgReferencia.AllowUserToResizeRows = false;
            this.dtgReferencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReferencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgReferencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReferencia.Location = new System.Drawing.Point(0, 0);
            this.dtgReferencia.MultiSelect = false;
            this.dtgReferencia.Name = "dtgReferencia";
            this.dtgReferencia.RowHeadersVisible = false;
            this.dtgReferencia.Size = new System.Drawing.Size(472, 112);
            this.dtgReferencia.TabIndex = 0;
            this.dtgReferencia.TabStop = false;
            this.dtgReferencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRefCliente_CellClick);
            this.dtgReferencia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRefCliente_CellDoubleClick);
            this.dtgReferencia.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dtgRefCliente_RowPrePaint);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(472, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCancelar,
            this.tsmQuitar,
            this.tsmAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(272, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmCancelar
            // 
            this.tsmCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmCancelar.Enabled = false;
            this.tsmCancelar.Image = global::GEN.ControlesBase.Properties.Resources.delete;
            this.tsmCancelar.Name = "tsmCancelar";
            this.tsmCancelar.Size = new System.Drawing.Size(28, 20);
            this.tsmCancelar.Text = "tsmCancelar";
            this.tsmCancelar.ToolTipText = "Cancelar edición.";
            this.tsmCancelar.Click += new System.EventHandler(this.tsmCancelar_Click);
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.Checked = true;
            this.tsmQuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Image = global::GEN.ControlesBase.Properties.Resources.btn_quitar;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(28, 20);
            this.tsmQuitar.Text = "Quitar";
            this.tsmQuitar.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitar.Click += new System.EventHandler(this.tsmQuitar_Click);
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Enabled = false;
            this.tsmAgregar.Image = global::GEN.ControlesBase.Properties.Resources.btn_agregar;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(28, 20);
            this.tsmAgregar.Text = "Agregar";
            this.tsmAgregar.ToolTipText = "Agregar registro del formulario.";
            this.tsmAgregar.Click += new System.EventHandler(this.tsmAgregar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Referencias Personales/Comerciales";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(135, 128);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 21);
            this.cboEstado.TabIndex = 6;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(88, 132);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(45, 13);
            this.lblBase7.TabIndex = 106;
            this.lblBase7.Text = "Estado";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(78, 86);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(55, 13);
            this.lblBase6.TabIndex = 104;
            this.lblBase6.Text = "Teléfono";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(85, 108);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(48, 13);
            this.lblBase5.TabIndex = 105;
            this.lblBase5.Text = "Vínculo";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(1, 65);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(132, 13);
            this.lblBase4.TabIndex = 103;
            this.lblBase4.Text = "Dirección/Referencias";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 42);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(107, 13);
            this.lblBase3.TabIndex = 102;
            this.lblBase3.Text = "Nombre/Empresa";
            // 
            // cboTipReferEval
            // 
            this.cboTipReferEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipReferEval.FormattingEnabled = true;
            this.cboTipReferEval.Location = new System.Drawing.Point(135, 16);
            this.cboTipReferEval.Name = "cboTipReferEval";
            this.cboTipReferEval.Size = new System.Drawing.Size(161, 21);
            this.cboTipReferEval.TabIndex = 1;
            this.cboTipReferEval.SelectedIndexChanged += new System.EventHandler(this.cboTiposRefCli_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(102, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(31, 13);
            this.lblBase2.TabIndex = 101;
            this.lblBase2.Text = "Tipo";
            // 
            // ConReferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbBase2);
            this.Name = "ConReferencias";
            this.Size = new System.Drawing.Size(492, 361);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingReferencia)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferencia)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private GEN.ControlesBase.txtTelefCel txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private GEN.ControlesBase.cboBase cboEstado;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboTipReferEval;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private GEN.BotonesBase.btnMiniNuevo btnNuevo;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelar;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgReferencia;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelDG;
        private GEN.ControlesBase.cboBase cboTipVinculoEval;
        private System.Windows.Forms.BindingSource bindingReferencia;
        private GEN.ControlesBase.lblBase lblBase8;
        private txtBase txtComentarios;
        
    }
}
