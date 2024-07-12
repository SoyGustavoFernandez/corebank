namespace CRE.Presentacion
{
    partial class frmConfirmAsistComite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmAsistComite));
            this.dtgParticipantes = new GEN.ControlesBase.dtgBase(this.components);
            this.idComiteCred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoParticip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lConfirmAsis = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cWinUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoParticip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lPresideComite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnLogin = new GEN.BotonesBase.btnMiniLogin(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgParticipantes
            // 
            this.dtgParticipantes.AllowUserToAddRows = false;
            this.dtgParticipantes.AllowUserToDeleteRows = false;
            this.dtgParticipantes.AllowUserToResizeColumns = false;
            this.dtgParticipantes.AllowUserToResizeRows = false;
            this.dtgParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParticipantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComiteCred,
            this.idUsuario,
            this.cNombre,
            this.cTipoParticip,
            this.lConfirmAsis,
            this.cWinUser,
            this.idTipoParticip,
            this.lPresideComite});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgParticipantes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgParticipantes.Location = new System.Drawing.Point(6, 49);
            this.dtgParticipantes.MultiSelect = false;
            this.dtgParticipantes.Name = "dtgParticipantes";
            this.dtgParticipantes.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParticipantes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgParticipantes.RowHeadersVisible = false;
            this.dtgParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipantes.Size = new System.Drawing.Size(486, 163);
            this.dtgParticipantes.TabIndex = 7;
            // 
            // idComiteCred
            // 
            this.idComiteCred.DataPropertyName = "idComiteCred";
            this.idComiteCred.HeaderText = "idComiteCred";
            this.idComiteCred.Name = "idComiteCred";
            this.idComiteCred.ReadOnly = true;
            this.idComiteCred.Visible = false;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.FillWeight = 15F;
            this.idUsuario.HeaderText = "Cod.";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 55F;
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoParticip
            // 
            this.cTipoParticip.DataPropertyName = "cTipoParticip";
            this.cTipoParticip.FillWeight = 20F;
            this.cTipoParticip.HeaderText = "Tip. Particip.";
            this.cTipoParticip.Name = "cTipoParticip";
            this.cTipoParticip.ReadOnly = true;
            // 
            // lConfirmAsis
            // 
            this.lConfirmAsis.DataPropertyName = "lConfirmAsis";
            this.lConfirmAsis.FillWeight = 15F;
            this.lConfirmAsis.HeaderText = "Confirmado?";
            this.lConfirmAsis.Name = "lConfirmAsis";
            this.lConfirmAsis.ReadOnly = true;
            this.lConfirmAsis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lConfirmAsis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cWinUser
            // 
            this.cWinUser.DataPropertyName = "cWinUser";
            this.cWinUser.HeaderText = "cWinUser";
            this.cWinUser.Name = "cWinUser";
            this.cWinUser.ReadOnly = true;
            this.cWinUser.Visible = false;
            // 
            // idTipoParticip
            // 
            this.idTipoParticip.DataPropertyName = "idTipoParticip";
            this.idTipoParticip.HeaderText = "idTipoParticip";
            this.idTipoParticip.Name = "idTipoParticip";
            this.idTipoParticip.ReadOnly = true;
            this.idTipoParticip.Visible = false;
            // 
            // lPresideComite
            // 
            this.lPresideComite.DataPropertyName = "lPresideComite";
            this.lPresideComite.HeaderText = "lPresideComite";
            this.lPresideComite.Name = "lPresideComite";
            this.lPresideComite.ReadOnly = true;
            this.lPresideComite.Visible = false;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnLogin);
            this.grbBase1.Controls.Add(this.dtgParticipantes);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(498, 218);
            this.grbBase1.TabIndex = 8;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Participantes";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.Location = new System.Drawing.Point(456, 15);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(36, 28);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(387, 236);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(450, 236);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmConfirmAsistComite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 318);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmConfirmAsistComite";
            this.Text = "Confirmar asistencia a comité";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgParticipantes;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnMiniLogin btnLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComiteCred;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoParticip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lConfirmAsis;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWinUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoParticip;
        private System.Windows.Forms.DataGridViewTextBoxColumn lPresideComite;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}

