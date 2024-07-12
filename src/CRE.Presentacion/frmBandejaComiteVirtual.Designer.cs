namespace CRE.Presentacion
{
    partial class frmBandejaComiteVirtual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBandejaComiteVirtual));
            this.dtgBandejaComiteVirtual = new System.Windows.Forms.DataGridView();
            this.idComiteCred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomComite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nParticipantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nEvaluaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lConfirmAsis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lInvitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBandejaComiteVirtual = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnActualizar1 = new GEN.BotonesBase.btnActualizar();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnRechazar1 = new GEN.BotonesBase.Boton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBandejaComiteVirtual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBandejaComiteVirtual)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBandejaComiteVirtual
            // 
            this.dtgBandejaComiteVirtual.AllowUserToAddRows = false;
            this.dtgBandejaComiteVirtual.AllowUserToDeleteRows = false;
            this.dtgBandejaComiteVirtual.AllowUserToResizeColumns = false;
            this.dtgBandejaComiteVirtual.AllowUserToResizeRows = false;
            this.dtgBandejaComiteVirtual.AutoGenerateColumns = false;
            this.dtgBandejaComiteVirtual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBandejaComiteVirtual.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgBandejaComiteVirtual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBandejaComiteVirtual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComiteCred,
            this.cDesZona,
            this.cNomCorto,
            this.cNomComite,
            this.nParticipantes,
            this.nEvaluaciones,
            this.lConfirmAsis,
            this.Asistencia,
            this.lInvitacion});
            this.dtgBandejaComiteVirtual.DataSource = this.bsBandejaComiteVirtual;
            this.dtgBandejaComiteVirtual.Location = new System.Drawing.Point(6, 32);
            this.dtgBandejaComiteVirtual.MultiSelect = false;
            this.dtgBandejaComiteVirtual.Name = "dtgBandejaComiteVirtual";
            this.dtgBandejaComiteVirtual.ReadOnly = true;
            this.dtgBandejaComiteVirtual.RowHeadersVisible = false;
            this.dtgBandejaComiteVirtual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBandejaComiteVirtual.Size = new System.Drawing.Size(644, 195);
            this.dtgBandejaComiteVirtual.TabIndex = 0;
            // 
            // idComiteCred
            // 
            this.idComiteCred.DataPropertyName = "idComiteCred";
            this.idComiteCred.HeaderText = "Comité";
            this.idComiteCred.Name = "idComiteCred";
            this.idComiteCred.ReadOnly = true;
            this.idComiteCred.Visible = false;
            // 
            // cDesZona
            // 
            this.cDesZona.DataPropertyName = "cDesZona";
            this.cDesZona.HeaderText = "Región";
            this.cDesZona.Name = "cDesZona";
            this.cDesZona.ReadOnly = true;
            // 
            // cNomCorto
            // 
            this.cNomCorto.DataPropertyName = "cNomCorto";
            this.cNomCorto.HeaderText = "Oficina";
            this.cNomCorto.Name = "cNomCorto";
            this.cNomCorto.ReadOnly = true;
            // 
            // cNomComite
            // 
            this.cNomComite.DataPropertyName = "cNomComite";
            this.cNomComite.HeaderText = "Comité";
            this.cNomComite.Name = "cNomComite";
            this.cNomComite.ReadOnly = true;
            // 
            // nParticipantes
            // 
            this.nParticipantes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nParticipantes.DataPropertyName = "nParticipantes";
            this.nParticipantes.HeaderText = "Num. Participantes";
            this.nParticipantes.Name = "nParticipantes";
            this.nParticipantes.ReadOnly = true;
            this.nParticipantes.Width = 70;
            // 
            // nEvaluaciones
            // 
            this.nEvaluaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nEvaluaciones.DataPropertyName = "nEvaluaciones";
            this.nEvaluaciones.HeaderText = "N Evaluaciones";
            this.nEvaluaciones.Name = "nEvaluaciones";
            this.nEvaluaciones.ReadOnly = true;
            this.nEvaluaciones.Width = 75;
            // 
            // lConfirmAsis
            // 
            this.lConfirmAsis.DataPropertyName = "lConfirmAsis";
            this.lConfirmAsis.HeaderText = "ConfirmAsis";
            this.lConfirmAsis.Name = "lConfirmAsis";
            this.lConfirmAsis.ReadOnly = true;
            this.lConfirmAsis.Visible = false;
            // 
            // Asistencia
            // 
            this.Asistencia.DataPropertyName = "cAsistencia";
            this.Asistencia.HeaderText = "Asistencia";
            this.Asistencia.Name = "Asistencia";
            this.Asistencia.ReadOnly = true;
            // 
            // lInvitacion
            // 
            this.lInvitacion.DataPropertyName = "lInvitacion";
            this.lInvitacion.HeaderText = "Invitación";
            this.lInvitacion.Name = "lInvitacion";
            this.lInvitacion.ReadOnly = true;
            this.lInvitacion.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(590, 231);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(4, 9);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(261, 13);
            this.lblMensaje.TabIndex = 131;
            this.lblMensaje.Text = "Ha sido invitado a participar en los siguientes comités.";
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.BackgroundImage")));
            this.btnActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar1.Location = new System.Drawing.Point(392, 231);
            this.btnActualizar1.Name = "btnActualizar1";
            this.btnActualizar1.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar1.TabIndex = 132;
            this.btnActualizar1.Text = "Act&ualiza";
            this.btnActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar1.texto = "Act&ualiza";
            this.btnActualizar1.UseVisualStyleBackColor = true;
            this.btnActualizar1.Click += new System.EventHandler(this.btnActualizar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(458, 231);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 133;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnRechazar1
            // 
            this.btnRechazar1.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnRechazar1;
            this.btnRechazar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRechazar1.Location = new System.Drawing.Point(524, 231);
            this.btnRechazar1.Name = "btnRechazar1";
            this.btnRechazar1.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar1.TabIndex = 135;
            this.btnRechazar1.Text = "Rechaza";
            this.btnRechazar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar1.UseVisualStyleBackColor = true;
            this.btnRechazar1.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // frmBandejaComiteVirtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 306);
            this.Controls.Add(this.btnRechazar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnActualizar1);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgBandejaComiteVirtual);
            this.Name = "frmBandejaComiteVirtual";
            this.Text = "Bandeja Comité Virtual";
            this.Controls.SetChildIndex(this.dtgBandejaComiteVirtual, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblMensaje, 0);
            this.Controls.SetChildIndex(this.btnActualizar1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnRechazar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBandejaComiteVirtual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBandejaComiteVirtual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBandejaComiteVirtual;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.BindingSource bsBandejaComiteVirtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComiteCred;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomComite;
        private System.Windows.Forms.DataGridViewTextBoxColumn nParticipantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nEvaluaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn lConfirmAsis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn lInvitacion;
        private System.Windows.Forms.Label lblMensaje;
        private GEN.BotonesBase.btnActualizar btnActualizar1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.Boton btnRechazar1;
    }
}