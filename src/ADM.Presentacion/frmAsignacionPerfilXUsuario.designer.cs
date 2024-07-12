namespace ADM.Presentacion
{
    partial class frmAsignacionPerfilXUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionPerfilXUsuario));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.dtgPerfilNoAsignado = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgPerfilAsignado = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.dtpFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblA = new GEN.ControlesBase.lblBase();
            this.lblDe = new GEN.ControlesBase.lblBase();
            this.cboTipoPerfil = new GEN.ControlesBase.cboBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.txtDocSustento = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfilNoAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfilAsignado)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(332, 536);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(266, 536);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // conBusCol1
            // 
            this.conBusCol1.Location = new System.Drawing.Point(12, 3);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(394, 86);
            this.conBusCol1.TabIndex = 0;
            this.conBusCol1.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario);
            // 
            // dtgPerfilNoAsignado
            // 
            this.dtgPerfilNoAsignado.AllowUserToAddRows = false;
            this.dtgPerfilNoAsignado.AllowUserToDeleteRows = false;
            this.dtgPerfilNoAsignado.AllowUserToResizeColumns = false;
            this.dtgPerfilNoAsignado.AllowUserToResizeRows = false;
            this.dtgPerfilNoAsignado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPerfilNoAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPerfilNoAsignado.Location = new System.Drawing.Point(6, 20);
            this.dtgPerfilNoAsignado.MultiSelect = false;
            this.dtgPerfilNoAsignado.Name = "dtgPerfilNoAsignado";
            this.dtgPerfilNoAsignado.ReadOnly = true;
            this.dtgPerfilNoAsignado.RowHeadersVisible = false;
            this.dtgPerfilNoAsignado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgPerfilNoAsignado.RowTemplate.Height = 20;
            this.dtgPerfilNoAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPerfilNoAsignado.Size = new System.Drawing.Size(374, 172);
            this.dtgPerfilNoAsignado.TabIndex = 0;
            // 
            // dtgPerfilAsignado
            // 
            this.dtgPerfilAsignado.AllowUserToAddRows = false;
            this.dtgPerfilAsignado.AllowUserToDeleteRows = false;
            this.dtgPerfilAsignado.AllowUserToResizeColumns = false;
            this.dtgPerfilAsignado.AllowUserToResizeRows = false;
            this.dtgPerfilAsignado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPerfilAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPerfilAsignado.Location = new System.Drawing.Point(18, 379);
            this.dtgPerfilAsignado.MultiSelect = false;
            this.dtgPerfilAsignado.Name = "dtgPerfilAsignado";
            this.dtgPerfilAsignado.ReadOnly = true;
            this.dtgPerfilAsignado.RowHeadersVisible = false;
            this.dtgPerfilAsignado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgPerfilAsignado.RowTemplate.Height = 20;
            this.dtgPerfilAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPerfilAsignado.Size = new System.Drawing.Size(374, 136);
            this.dtgPerfilAsignado.TabIndex = 3;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtDocSustento);
            this.grbBase1.Controls.Add(this.btnMiniAgregar1);
            this.grbBase1.Controls.Add(this.cboTipoPerfil);
            this.grbBase1.Controls.Add(this.btnAgregar1);
            this.grbBase1.Controls.Add(this.btnEliminar1);
            this.grbBase1.Controls.Add(this.dtpFin);
            this.grbBase1.Controls.Add(this.dtpIni);
            this.grbBase1.Controls.Add(this.dtgPerfilNoAsignado);
            this.grbBase1.Controls.Add(this.lblA);
            this.grbBase1.Controls.Add(this.lblDe);
            this.grbBase1.Location = new System.Drawing.Point(12, 88);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(394, 285);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(254, 223);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 11;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Enabled = false;
            this.btnEliminar1.Location = new System.Drawing.Point(320, 223);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 8;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(289, 198);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(91, 20);
            this.dtpFin.TabIndex = 4;
            this.dtpFin.Visible = false;
            // 
            // dtpIni
            // 
            this.dtpIni.Location = new System.Drawing.Point(165, 198);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(101, 20);
            this.dtpIni.TabIndex = 3;
            this.dtpIni.Visible = false;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblA.ForeColor = System.Drawing.Color.Navy;
            this.lblA.Location = new System.Drawing.Point(270, 201);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(19, 13);
            this.lblA.TabIndex = 6;
            this.lblA.Text = "a:";
            this.lblA.Visible = false;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDe.ForeColor = System.Drawing.Color.Navy;
            this.lblDe.Location = new System.Drawing.Point(139, 201);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(28, 13);
            this.lblDe.TabIndex = 5;
            this.lblDe.Text = "De:";
            this.lblDe.Visible = false;
            // 
            // cboTipoPerfil
            // 
            this.cboTipoPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPerfil.FormattingEnabled = true;
            this.cboTipoPerfil.Location = new System.Drawing.Point(6, 198);
            this.cboTipoPerfil.Name = "cboTipoPerfil";
            this.cboTipoPerfil.Size = new System.Drawing.Size(121, 21);
            this.cboTipoPerfil.TabIndex = 12;
            this.cboTipoPerfil.SelectedIndexChanged += new System.EventHandler(this.cboTipoPerfil_SelectedIndexChanged);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Enabled = false;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(6, 223);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 13;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // txtDocSustento
            // 
            this.txtDocSustento.Enabled = false;
            this.txtDocSustento.Location = new System.Drawing.Point(48, 227);
            this.txtDocSustento.Name = "txtDocSustento";
            this.txtDocSustento.Size = new System.Drawing.Size(177, 20);
            this.txtDocSustento.TabIndex = 14;
            // 
            // frmAsignacionPerfilXUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 617);
            this.Controls.Add(this.conBusCol1);
            this.Controls.Add(this.dtgPerfilAsignado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmAsignacionPerfilXUsuario";
            this.Text = "Asignación de Perfiles a Usuario";
            this.Load += new System.EventHandler(this.frmAsignacionPerfilXUsuario_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgPerfilAsignado, 0);
            this.Controls.SetChildIndex(this.conBusCol1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfilNoAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfilAsignado)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgPerfilNoAsignado;
        private GEN.ControlesBase.dtgBase dtgPerfilAsignado;
        private GEN.ControlesBase.grbBase grbBase1;
        internal GEN.ControlesBase.ConBusCol conBusCol1;
        private GEN.ControlesBase.dtpCorto dtpFin;
        private GEN.ControlesBase.dtpCorto dtpIni;
        private GEN.ControlesBase.lblBase lblA;
        private GEN.ControlesBase.lblBase lblDe;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.cboBase cboTipoPerfil;
        private GEN.ControlesBase.txtBase txtDocSustento;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
    }
}