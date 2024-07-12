namespace GEN.ControlesBase
{
    partial class FrmBusUsuComite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusUsuComite));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoParticip = new GEN.ControlesBase.cboTipoParticip(this.components);
            this.cboCriBusCol = new GEN.ControlesBase.cboCriBusCli(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtDniNom = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgColaborador = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPorcenLibreVia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWinUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 275);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(130, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Tipo de participacion:";
            // 
            // cboTipoParticip
            // 
            this.cboTipoParticip.DisplayMember = "cTipoParticip";
            this.cboTipoParticip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoParticip.FormattingEnabled = true;
            this.cboTipoParticip.Location = new System.Drawing.Point(151, 272);
            this.cboTipoParticip.Name = "cboTipoParticip";
            this.cboTipoParticip.Size = new System.Drawing.Size(170, 21);
            this.cboTipoParticip.TabIndex = 4;
            this.cboTipoParticip.ValueMember = "idTipoParticip";
            // 
            // cboCriBusCol
            // 
            this.cboCriBusCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriBusCol.FormattingEnabled = true;
            this.cboCriBusCol.Location = new System.Drawing.Point(152, 12);
            this.cboCriBusCol.Name = "cboCriBusCol";
            this.cboCriBusCol.Size = new System.Drawing.Size(276, 21);
            this.cboCriBusCol.TabIndex = 0;
            this.cboCriBusCol.SelectedIndexChanged += new System.EventHandler(this.cboCriBusCol_SelectedIndexChanged);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(452, 10);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtDniNom
            // 
            this.txtDniNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDniNom.Location = new System.Drawing.Point(152, 40);
            this.txtDniNom.Name = "txtDniNom";
            this.txtDniNom.Size = new System.Drawing.Size(276, 20);
            this.txtDniNom.TabIndex = 1;
            this.txtDniNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDniNom_KeyPress);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(452, 257);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgColaborador
            // 
            this.dtgColaborador.AllowUserToAddRows = false;
            this.dtgColaborador.AllowUserToDeleteRows = false;
            this.dtgColaborador.AllowUserToResizeColumns = false;
            this.dtgColaborador.AllowUserToResizeRows = false;
            this.dtgColaborador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgColaborador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsuario,
            this.idCli,
            this.cDocumentoID,
            this.cNombre,
            this.idCargo,
            this.cCargo,
            this.idEstado,
            this.nPorcenLibreVia,
            this.idAgencia,
            this.idArea,
            this.cWinUser});
            this.dtgColaborador.Location = new System.Drawing.Point(8, 75);
            this.dtgColaborador.MultiSelect = false;
            this.dtgColaborador.Name = "dtgColaborador";
            this.dtgColaborador.ReadOnly = true;
            this.dtgColaborador.RowHeadersVisible = false;
            this.dtgColaborador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgColaborador.Size = new System.Drawing.Size(504, 176);
            this.dtgColaborador.TabIndex = 3;
            this.dtgColaborador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgColaborador_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(386, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(11, 43);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(34, 13);
            this.lblCriterio.TabIndex = 14;
            this.lblCriterio.Text = "DNI:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(115, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Criterio Búsqueda:";
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 40F;
            this.cDocumentoID.HeaderText = "Nro. Documento";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 98.47716F;
            this.cNombre.HeaderText = "Nombres";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // idCargo
            // 
            this.idCargo.DataPropertyName = "idCargo";
            this.idCargo.HeaderText = "idCargo";
            this.idCargo.Name = "idCargo";
            this.idCargo.ReadOnly = true;
            this.idCargo.Visible = false;
            // 
            // cCargo
            // 
            this.cCargo.DataPropertyName = "cCargo";
            this.cCargo.HeaderText = "cCargo";
            this.cCargo.Name = "cCargo";
            this.cCargo.ReadOnly = true;
            this.cCargo.Visible = false;
            // 
            // idEstado
            // 
            this.idEstado.DataPropertyName = "idEstado";
            this.idEstado.HeaderText = "idEstado";
            this.idEstado.Name = "idEstado";
            this.idEstado.ReadOnly = true;
            this.idEstado.Visible = false;
            // 
            // nPorcenLibreVia
            // 
            this.nPorcenLibreVia.DataPropertyName = "nPorcenLibreVia";
            this.nPorcenLibreVia.HeaderText = "nPorcenLibreVia";
            this.nPorcenLibreVia.Name = "nPorcenLibreVia";
            this.nPorcenLibreVia.ReadOnly = true;
            this.nPorcenLibreVia.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // idArea
            // 
            this.idArea.DataPropertyName = "idArea";
            this.idArea.HeaderText = "idArea";
            this.idArea.Name = "idArea";
            this.idArea.ReadOnly = true;
            this.idArea.Visible = false;
            // 
            // cWinUser
            // 
            this.cWinUser.DataPropertyName = "cWinUser";
            this.cWinUser.HeaderText = "Usuario";
            this.cWinUser.Name = "cWinUser";
            this.cWinUser.ReadOnly = true;
            this.cWinUser.Visible = false;
            // 
            // FrmBusUsuComite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 338);
            this.Controls.Add(this.cboCriBusCol);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtDniNom);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgColaborador);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoParticip);
            this.Controls.Add(this.lblBase2);
            this.Name = "FrmBusUsuComite";
            this.Text = "Busqueda de personal para comité";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoParticip, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblCriterio, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.dtgColaborador, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtDniNom, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.cboCriBusCol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgColaborador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase2;
        private cboTipoParticip cboTipoParticip;
        private cboCriBusCli cboCriBusCol;
        private BotonesBase.btnBusqueda btnBusqueda;
        private txtBase txtDniNom;
        private BotonesBase.btnSalir btnSalir1;
        private dtgBase dtgColaborador;
        private BotonesBase.BtnAceptar btnAceptar;
        private lblBase lblCriterio;
        private lblBase lblBase1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPorcenLibreVia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWinUser;

    }
}

