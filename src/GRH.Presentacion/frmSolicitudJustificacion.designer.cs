namespace GRH.Presentacion
{
    partial class frmSolicitudJustificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudJustificacion));
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.dtgInasistencias = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.txtDocSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblEstadoSolicitud = new GEN.ControlesBase.lblBase();
            this.lblNroSolicitud = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboPeriodo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblFechaSol = new GEN.ControlesBase.lblBase();
            this.lblUsuarioSol = new GEN.ControlesBase.lblBase();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.CBNewSolic = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInasistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCol1
            // 
            this.conBusCol1.Location = new System.Drawing.Point(17, 12);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(394, 86);
            this.conBusCol1.TabIndex = 2;
            this.conBusCol1.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario);
            // 
            // dtgInasistencias
            // 
            this.dtgInasistencias.AllowUserToAddRows = false;
            this.dtgInasistencias.AllowUserToDeleteRows = false;
            this.dtgInasistencias.AllowUserToResizeColumns = false;
            this.dtgInasistencias.AllowUserToResizeRows = false;
            this.dtgInasistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgInasistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInasistencias.Location = new System.Drawing.Point(17, 239);
            this.dtgInasistencias.MultiSelect = false;
            this.dtgInasistencias.Name = "dtgInasistencias";
            this.dtgInasistencias.ReadOnly = true;
            this.dtgInasistencias.RowHeadersVisible = false;
            this.dtgInasistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInasistencias.Size = new System.Drawing.Size(516, 156);
            this.dtgInasistencias.TabIndex = 3;
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Enabled = false;
            this.btnEnviar1.Location = new System.Drawing.Point(341, 477);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 4;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(473, 477);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(407, 477);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // txtDocSustento
            // 
            this.txtDocSustento.Location = new System.Drawing.Point(17, 426);
            this.txtDocSustento.MaxLength = 300;
            this.txtDocSustento.Multiline = true;
            this.txtDocSustento.Name = "txtDocSustento";
            this.txtDocSustento.Size = new System.Drawing.Size(516, 45);
            this.txtDocSustento.TabIndex = 105;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 223);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(138, 13);
            this.lblBase1.TabIndex = 106;
            this.lblBase1.Text = "Faltas en este periodo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 410);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(377, 13);
            this.lblBase2.TabIndex = 107;
            this.lblBase2.Text = "Número de Documento de Justificación y Descripción del Motivo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(389, 151);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 108;
            this.lblBase3.Text = "N° Solicitud:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 151);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(102, 13);
            this.lblBase4.TabIndex = 109;
            this.lblBase4.Text = "Estado Solicitud:";
            // 
            // lblEstadoSolicitud
            // 
            this.lblEstadoSolicitud.AutoSize = true;
            this.lblEstadoSolicitud.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstadoSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblEstadoSolicitud.Location = new System.Drawing.Point(114, 151);
            this.lblEstadoSolicitud.Name = "lblEstadoSolicitud";
            this.lblEstadoSolicitud.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoSolicitud.TabIndex = 111;
            // 
            // lblNroSolicitud
            // 
            this.lblNroSolicitud.AutoSize = true;
            this.lblNroSolicitud.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblNroSolicitud.Location = new System.Drawing.Point(464, 151);
            this.lblNroSolicitud.Name = "lblNroSolicitud";
            this.lblNroSolicitud.Size = new System.Drawing.Size(0, 13);
            this.lblNroSolicitud.TabIndex = 112;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(14, 117);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(55, 13);
            this.lblBase7.TabIndex = 113;
            this.lblBase7.Text = "Periodo:";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.Enabled = false;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(85, 114);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(117, 21);
            this.cboPeriodo.TabIndex = 114;
            this.cboPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboPeriodo_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(389, 173);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(74, 13);
            this.lblBase5.TabIndex = 115;
            this.lblBase5.Text = "F. Solicitud:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(14, 173);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(100, 13);
            this.lblBase6.TabIndex = 116;
            this.lblBase6.Text = "Usuario Solicitó:";
            // 
            // lblFechaSol
            // 
            this.lblFechaSol.AutoSize = true;
            this.lblFechaSol.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaSol.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaSol.Location = new System.Drawing.Point(464, 173);
            this.lblFechaSol.Name = "lblFechaSol";
            this.lblFechaSol.Size = new System.Drawing.Size(0, 13);
            this.lblFechaSol.TabIndex = 117;
            // 
            // lblUsuarioSol
            // 
            this.lblUsuarioSol.AutoSize = true;
            this.lblUsuarioSol.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblUsuarioSol.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuarioSol.Location = new System.Drawing.Point(114, 173);
            this.lblUsuarioSol.Name = "lblUsuarioSol";
            this.lblUsuarioSol.Size = new System.Drawing.Size(0, 13);
            this.lblUsuarioSol.TabIndex = 118;
            // 
            // lblAlerta
            // 
            this.lblAlerta.AutoSize = true;
            this.lblAlerta.ForeColor = System.Drawing.Color.Red;
            this.lblAlerta.Location = new System.Drawing.Point(14, 197);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(0, 13);
            this.lblAlerta.TabIndex = 119;
            // 
            // CBNewSolic
            // 
            this.CBNewSolic.AutoSize = true;
            this.CBNewSolic.ForeColor = System.Drawing.Color.Navy;
            this.CBNewSolic.Location = new System.Drawing.Point(374, 197);
            this.CBNewSolic.Name = "CBNewSolic";
            this.CBNewSolic.Size = new System.Drawing.Size(153, 17);
            this.CBNewSolic.TabIndex = 120;
            this.CBNewSolic.Text = "Enviar una nueva Solicitud";
            this.CBNewSolic.UseVisualStyleBackColor = true;
            this.CBNewSolic.Visible = false;
            this.CBNewSolic.CheckedChanged += new System.EventHandler(this.CBNewSolic_CheckedChanged);
            // 
            // frmSolicitudJustificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 557);
            this.Controls.Add(this.CBNewSolic);
            this.Controls.Add(this.lblAlerta);
            this.Controls.Add(this.lblUsuarioSol);
            this.Controls.Add(this.lblFechaSol);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboPeriodo);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblNroSolicitud);
            this.Controls.Add(this.lblEstadoSolicitud);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDocSustento);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.dtgInasistencias);
            this.Controls.Add(this.conBusCol1);
            this.Name = "frmSolicitudJustificacion";
            this.Text = "Solicitud de Justificacion";
            this.Load += new System.EventHandler(this.frmSolicitudJustificacion_Load);
            this.Controls.SetChildIndex(this.conBusCol1, 0);
            this.Controls.SetChildIndex(this.dtgInasistencias, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.txtDocSustento, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblEstadoSolicitud, 0);
            this.Controls.SetChildIndex(this.lblNroSolicitud, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.cboPeriodo, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblFechaSol, 0);
            this.Controls.SetChildIndex(this.lblUsuarioSol, 0);
            this.Controls.SetChildIndex(this.lblAlerta, 0);
            this.Controls.SetChildIndex(this.CBNewSolic, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInasistencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusCol1;
        private GEN.ControlesBase.dtgBase dtgInasistencias;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtBase txtDocSustento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblEstadoSolicitud;
        private GEN.ControlesBase.lblBase lblNroSolicitud;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboBase cboPeriodo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblFechaSol;
        private GEN.ControlesBase.lblBase lblUsuarioSol;
        private System.Windows.Forms.Label lblAlerta;
        private GEN.ControlesBase.chcBase CBNewSolic;
    }
}