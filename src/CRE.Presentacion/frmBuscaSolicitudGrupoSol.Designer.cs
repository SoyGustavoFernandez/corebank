namespace CRE.Presentacion
{
    partial class frmBuscaSolicitudGrupoSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaSolicitudGrupoSol));
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conBusGrupoSol1 = new GEN.ControlesBase.ConBusGrupoSol();
            this.cboGrupoSolidarioCiclo1 = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.cboTipoGrupoSolidario1 = new GEN.ControlesBase.cboTipoGrupoSolidario(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombreGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdGrupoSolidario = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtBase8 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.txtSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.conBusGrupoSol1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(413, 229);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 35;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(480, 229);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 36;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conBusGrupoSol1
            // 
            this.conBusGrupoSol1.Controls.Add(this.cboGrupoSolidarioCiclo1);
            this.conBusGrupoSol1.Controls.Add(this.cboTipoGrupoSolidario1);
            this.conBusGrupoSol1.Controls.Add(this.txtDireccion);
            this.conBusGrupoSol1.Controls.Add(this.txtNombreGrupo);
            this.conBusGrupoSol1.Controls.Add(this.txtIdGrupoSolidario);
            this.conBusGrupoSol1.Location = new System.Drawing.Point(0, 3);
            this.conBusGrupoSol1.Name = "conBusGrupoSol1";
            this.conBusGrupoSol1.Size = new System.Drawing.Size(613, 73);
            this.conBusGrupoSol1.TabIndex = 37;
            this.conBusGrupoSol1.ClicBuscar += new System.EventHandler(this.conBusGrupoSol1_ClicBuscar);
            // 
            // cboGrupoSolidarioCiclo1
            // 
            this.cboGrupoSolidarioCiclo1.DisplayMember = "cDescripcion";
            this.cboGrupoSolidarioCiclo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoSolidarioCiclo1.Enabled = false;
            this.cboGrupoSolidarioCiclo1.FormattingEnabled = true;
            this.cboGrupoSolidarioCiclo1.Location = new System.Drawing.Point(64, 49);
            this.cboGrupoSolidarioCiclo1.Name = "cboGrupoSolidarioCiclo1";
            this.cboGrupoSolidarioCiclo1.Size = new System.Drawing.Size(121, 21);
            this.cboGrupoSolidarioCiclo1.TabIndex = 19;
            this.cboGrupoSolidarioCiclo1.ValueMember = "idGrupoSolidarioCiclo";
            // 
            // cboTipoGrupoSolidario1
            // 
            this.cboTipoGrupoSolidario1.DisplayMember = "cTipoGrupoSolidario";
            this.cboTipoGrupoSolidario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGrupoSolidario1.Enabled = false;
            this.cboTipoGrupoSolidario1.FormattingEnabled = true;
            this.cboTipoGrupoSolidario1.Location = new System.Drawing.Point(273, 49);
            this.cboTipoGrupoSolidario1.Name = "cboTipoGrupoSolidario1";
            this.cboTipoGrupoSolidario1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoGrupoSolidario1.TabIndex = 17;
            this.cboTipoGrupoSolidario1.ValueMember = "idTipoGrupoSolidario";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(64, 26);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(483, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Enabled = false;
            this.txtNombreGrupo.Location = new System.Drawing.Point(133, 4);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(414, 20);
            this.txtNombreGrupo.TabIndex = 1;
            // 
            // txtIdGrupoSolidario
            // 
            this.txtIdGrupoSolidario.Enabled = false;
            this.txtIdGrupoSolidario.Format = "n2";
            this.txtIdGrupoSolidario.Location = new System.Drawing.Point(64, 4);
            this.txtIdGrupoSolidario.Name = "txtIdGrupoSolidario";
            this.txtIdGrupoSolidario.Size = new System.Drawing.Size(70, 20);
            this.txtIdGrupoSolidario.TabIndex = 0;
            this.txtIdGrupoSolidario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBase8
            // 
            this.txtBase8.Enabled = false;
            this.txtBase8.Location = new System.Drawing.Point(274, 82);
            this.txtBase8.Name = "txtBase8";
            this.txtBase8.Size = new System.Drawing.Size(71, 20);
            this.txtBase8.TabIndex = 42;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(182, 85);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(86, 13);
            this.lblBase8.TabIndex = 41;
            this.lblBase8.Text = "N° Evaluación";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(6, 108);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(541, 115);
            this.dtgBase1.TabIndex = 40;
            this.dtgBase1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellClick);
            this.dtgBase1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellDoubleClick);
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Enabled = false;
            this.txtSolicitud.Location = new System.Drawing.Point(78, 82);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.Size = new System.Drawing.Size(71, 20);
            this.txtSolicitud.TabIndex = 39;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(3, 85);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(73, 13);
            this.lblBase7.TabIndex = 38;
            this.lblBase7.Text = "N° Solicitud";
            // 
            // frmBuscaSolicitudGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 305);
            this.Controls.Add(this.txtBase8);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.txtSolicitud);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.conBusGrupoSol1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Name = "frmBuscaSolicitudGrupoSol";
            this.Text = "Solicitudes de Grupo Solidario";
            this.Load += new System.EventHandler(this.frmBuscaSolicitudGrupoSol_Load);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusGrupoSol1, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.txtSolicitud, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.txtBase8, 0);
            this.conBusGrupoSol1.ResumeLayout(false);
            this.conBusGrupoSol1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol1;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboGrupoSolidarioCiclo1;
        private GEN.ControlesBase.cboTipoGrupoSolidario cboTipoGrupoSolidario1;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtNombreGrupo;
        private GEN.ControlesBase.txtNumerico txtIdGrupoSolidario;
        private GEN.ControlesBase.txtBase txtBase8;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.txtBase txtSolicitud;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}