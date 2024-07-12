using System.Drawing;

namespace CRE.Presentacion
{
    partial class frmGestionObservaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionObservaciones));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.lblFechaFinal = new GEN.ControlesBase.lblBase();
            this.lblFechaInicial = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpFechaSimp(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpFechaSimp(this.components);
            this.dtgObservaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.pnlIndicadores = new System.Windows.Forms.Panel();
            this.lblAbsolComplet = new System.Windows.Forms.Label();
            this.lblRechazo = new System.Windows.Forms.Label();
            this.lblResolComplet = new System.Windows.Forms.Label();
            this.lblEmisionCompl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.chbVigente = new System.Windows.Forms.CheckBox();
            this.chbEtapa = new System.Windows.Forms.CheckBox();
            this.chbSolicitud = new System.Windows.Forms.CheckBox();
            this.lblNombSol = new System.Windows.Forms.Label();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.chbUsuario = new System.Windows.Forms.CheckBox();
            this.cboTipObs = new GEN.ControlesBase.cboTipObs(this.components);
            this.btnEditObs = new GEN.BotonesBase.btnMiniEditar();
            this.btnQuitObs = new GEN.BotonesBase.btnMiniQuitar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnRptGestObs = new System.Windows.Forms.Button();
            this.btnAddObs = new GEN.BotonesBase.btnAgregar();
            this.btnEmitirObs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.pnlIndicadores.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaFinal.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaFinal.Location = new System.Drawing.Point(847, 25);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(70, 13);
            this.lblFechaFinal.TabIndex = 154;
            this.lblFechaFinal.Text = "Fecha Final";
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaInicial.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaInicial.Location = new System.Drawing.Point(599, 25);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(78, 13);
            this.lblFechaInicial.TabIndex = 153;
            this.lblFechaInicial.Text = "Fecha Inicial";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(850, 41);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(235, 20);
            this.dtpFechaFin.TabIndex = 152;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(600, 41);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(237, 20);
            this.dtpFechaInicio.TabIndex = 151;
            this.dtpFechaInicio.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // dtgObservaciones
            // 
            this.dtgObservaciones.AllowUserToAddRows = false;
            this.dtgObservaciones.AllowUserToDeleteRows = false;
            this.dtgObservaciones.AllowUserToResizeColumns = false;
            this.dtgObservaciones.AllowUserToResizeRows = false;
            this.dtgObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObservaciones.Location = new System.Drawing.Point(9, 90);
            this.dtgObservaciones.MultiSelect = false;
            this.dtgObservaciones.Name = "dtgObservaciones";
            this.dtgObservaciones.ReadOnly = true;
            this.dtgObservaciones.RowHeadersVisible = false;
            this.dtgObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.Size = new System.Drawing.Size(1077, 360);
            this.dtgObservaciones.TabIndex = 155;
            this.dtgObservaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgObservaciones_CellContentClick);
            this.dtgObservaciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgObservaciones_CellFormatting);
            this.dtgObservaciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgObservaciones_CellPainting);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.pnlIndicadores);
            this.grbBase2.Controls.Add(this.lblSolicitud);
            this.grbBase2.Controls.Add(this.chbVigente);
            this.grbBase2.Controls.Add(this.chbEtapa);
            this.grbBase2.Controls.Add(this.chbSolicitud);
            this.grbBase2.Controls.Add(this.lblNombSol);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.dtpFechaFin);
            this.grbBase2.Controls.Add(this.chbUsuario);
            this.grbBase2.Controls.Add(this.cboTipObs);
            this.grbBase2.Controls.Add(this.lblFechaInicial);
            this.grbBase2.Controls.Add(this.lblFechaFinal);
            this.grbBase2.Controls.Add(this.dtgObservaciones);
            this.grbBase2.Controls.Add(this.dtpFechaInicio);
            this.grbBase2.Location = new System.Drawing.Point(7, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(1094, 456);
            this.grbBase2.TabIndex = 163;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Observaciones de créditos";
            // 
            // pnlIndicadores
            // 
            this.pnlIndicadores.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlIndicadores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIndicadores.Controls.Add(this.lblAbsolComplet);
            this.pnlIndicadores.Controls.Add(this.lblRechazo);
            this.pnlIndicadores.Controls.Add(this.lblResolComplet);
            this.pnlIndicadores.Controls.Add(this.lblEmisionCompl);
            this.pnlIndicadores.Controls.Add(this.label1);
            this.pnlIndicadores.Location = new System.Drawing.Point(396, 10);
            this.pnlIndicadores.Name = "pnlIndicadores";
            this.pnlIndicadores.Size = new System.Drawing.Size(197, 74);
            this.pnlIndicadores.TabIndex = 171;
            // 
            // lblAbsolComplet
            // 
            this.lblAbsolComplet.AutoSize = true;
            this.lblAbsolComplet.ForeColor = System.Drawing.Color.Teal;
            this.lblAbsolComplet.Location = new System.Drawing.Point(3, 55);
            this.lblAbsolComplet.Name = "lblAbsolComplet";
            this.lblAbsolComplet.Size = new System.Drawing.Size(112, 13);
            this.lblAbsolComplet.TabIndex = 175;
            this.lblAbsolComplet.Text = "Absolución Completa: ";
            // 
            // lblRechazo
            // 
            this.lblRechazo.AutoSize = true;
            this.lblRechazo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRechazo.Location = new System.Drawing.Point(3, 43);
            this.lblRechazo.Name = "lblRechazo";
            this.lblRechazo.Size = new System.Drawing.Size(56, 13);
            this.lblRechazo.TabIndex = 174;
            this.lblRechazo.Text = "Rechazo: ";
            // 
            // lblResolComplet
            // 
            this.lblResolComplet.AutoSize = true;
            this.lblResolComplet.ForeColor = System.Drawing.Color.Green;
            this.lblResolComplet.Location = new System.Drawing.Point(3, 30);
            this.lblResolComplet.Name = "lblResolComplet";
            this.lblResolComplet.Size = new System.Drawing.Size(113, 13);
            this.lblResolComplet.TabIndex = 173;
            this.lblResolComplet.Text = "Resolución Completa: ";
            // 
            // lblEmisionCompl
            // 
            this.lblEmisionCompl.AutoSize = true;
            this.lblEmisionCompl.ForeColor = System.Drawing.Color.Navy;
            this.lblEmisionCompl.Location = new System.Drawing.Point(3, 16);
            this.lblEmisionCompl.Name = "lblEmisionCompl";
            this.lblEmisionCompl.Size = new System.Drawing.Size(96, 13);
            this.lblEmisionCompl.TabIndex = 172;
            this.lblEmisionCompl.Text = "Emisión Completa: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 171;
            this.label1.Text = "INDICADORES:";
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolicitud.Location = new System.Drawing.Point(107, 21);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(17, 17);
            this.lblSolicitud.TabIndex = 170;
            this.lblSolicitud.Text = "0";
            // 
            // chbVigente
            // 
            this.chbVigente.AutoSize = true;
            this.chbVigente.Location = new System.Drawing.Point(1019, 67);
            this.chbVigente.Name = "chbVigente";
            this.chbVigente.Size = new System.Drawing.Size(67, 17);
            this.chbVigente.TabIndex = 160;
            this.chbVigente.Text = "Vigentes";
            this.chbVigente.UseVisualStyleBackColor = true;
            this.chbVigente.CheckedChanged += new System.EventHandler(this.chbVigente_CheckedChanged);
            // 
            // chbEtapa
            // 
            this.chbEtapa.AutoSize = true;
            this.chbEtapa.Location = new System.Drawing.Point(875, 67);
            this.chbEtapa.Name = "chbEtapa";
            this.chbEtapa.Size = new System.Drawing.Size(138, 17);
            this.chbEtapa.TabIndex = 159;
            this.chbEtapa.Text = "Registros de esta etapa";
            this.chbEtapa.UseVisualStyleBackColor = true;
            this.chbEtapa.CheckedChanged += new System.EventHandler(this.chbEtapa_CheckedChanged);
            // 
            // chbSolicitud
            // 
            this.chbSolicitud.AutoSize = true;
            this.chbSolicitud.Location = new System.Drawing.Point(600, 67);
            this.chbSolicitud.Name = "chbSolicitud";
            this.chbSolicitud.Size = new System.Drawing.Size(137, 17);
            this.chbSolicitud.TabIndex = 158;
            this.chbSolicitud.Text = "Registros de la solicitud";
            this.chbSolicitud.UseVisualStyleBackColor = true;
            this.chbSolicitud.CheckedChanged += new System.EventHandler(this.chbSolicitud_CheckedChanged);
            // 
            // lblNombSol
            // 
            this.lblNombSol.AutoSize = true;
            this.lblNombSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombSol.Location = new System.Drawing.Point(6, 21);
            this.lblNombSol.Name = "lblNombSol";
            this.lblNombSol.Size = new System.Drawing.Size(95, 17);
            this.lblNombSol.TabIndex = 169;
            this.lblNombSol.Text = "ID Solicitud:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 45);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(122, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo de observación";
            // 
            // chbUsuario
            // 
            this.chbUsuario.AutoSize = true;
            this.chbUsuario.Location = new System.Drawing.Point(743, 67);
            this.chbUsuario.Name = "chbUsuario";
            this.chbUsuario.Size = new System.Drawing.Size(126, 17);
            this.chbUsuario.TabIndex = 157;
            this.chbUsuario.Text = "Registros del Usuario";
            this.chbUsuario.UseVisualStyleBackColor = true;
            this.chbUsuario.CheckedChanged += new System.EventHandler(this.chbUsuario_CheckedChanged);
            // 
            // cboTipObs
            // 
            this.cboTipObs.DisplayMember = "cTipObs";
            this.cboTipObs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipObs.FormattingEnabled = true;
            this.cboTipObs.Location = new System.Drawing.Point(9, 63);
            this.cboTipObs.Name = "cboTipObs";
            this.cboTipObs.Size = new System.Drawing.Size(381, 21);
            this.cboTipObs.TabIndex = 156;
            this.cboTipObs.ValueMember = "idTipObs";
            this.cboTipObs.SelectedIndexChanged += new System.EventHandler(this.cboTipObs_SelectedIndexChanged);
            // 
            // btnEditObs
            // 
            this.btnEditObs.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditObs.BackgroundImage")));
            this.btnEditObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditObs.Location = new System.Drawing.Point(1182, 130);
            this.btnEditObs.Name = "btnEditObs";
            this.btnEditObs.Size = new System.Drawing.Size(36, 28);
            this.btnEditObs.TabIndex = 165;
            this.btnEditObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditObs.UseVisualStyleBackColor = false;
            // 
            // btnQuitObs
            // 
            this.btnQuitObs.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitObs.BackgroundImage")));
            this.btnQuitObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitObs.Location = new System.Drawing.Point(1182, 102);
            this.btnQuitObs.Name = "btnQuitObs";
            this.btnQuitObs.Size = new System.Drawing.Size(36, 28);
            this.btnQuitObs.TabIndex = 164;
            this.btnQuitObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitObs.UseVisualStyleBackColor = false;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(1034, 468);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 166;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnRptGestObs
            // 
            this.btnRptGestObs.Enabled = false;
            this.btnRptGestObs.Location = new System.Drawing.Point(969, 468);
            this.btnRptGestObs.Name = "btnRptGestObs";
            this.btnRptGestObs.Size = new System.Drawing.Size(59, 50);
            this.btnRptGestObs.TabIndex = 172;
            this.btnRptGestObs.Text = "Reporte Gest. Observ.";
            this.btnRptGestObs.UseVisualStyleBackColor = true;
            this.btnRptGestObs.Visible = false;
            // 
            // btnAddObs
            // 
            this.btnAddObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddObs.BackgroundImage")));
            this.btnAddObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddObs.Location = new System.Drawing.Point(16, 468);
            this.btnAddObs.Name = "btnAddObs";
            this.btnAddObs.Size = new System.Drawing.Size(60, 50);
            this.btnAddObs.TabIndex = 173;
            this.btnAddObs.Text = "&Agregar";
            this.btnAddObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddObs.UseVisualStyleBackColor = true;
            this.btnAddObs.Click += new System.EventHandler(this.btnAddObs_Click);
            // 
            // btnEmitirObs
            // 
            this.btnEmitirObs.Location = new System.Drawing.Point(82, 468);
            this.btnEmitirObs.Name = "btnEmitirObs";
            this.btnEmitirObs.Size = new System.Drawing.Size(59, 50);
            this.btnEmitirObs.TabIndex = 174;
            this.btnEmitirObs.Text = "&Emitir Observ.";
            this.btnEmitirObs.UseVisualStyleBackColor = true;
            this.btnEmitirObs.Visible = false;
            this.btnEmitirObs.Click += new System.EventHandler(this.btnEmitirObs_Click);
            // 
            // frmGestionObservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 544);
            this.Controls.Add(this.btnEmitirObs);
            this.Controls.Add(this.btnAddObs);
            this.Controls.Add(this.btnRptGestObs);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditObs);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnQuitObs);
            this.Name = "frmGestionObservaciones";
            this.Text = "Gestión de Observaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGestionObservaciones_FormClosing);
            this.Load += new System.EventHandler(this.frmGestionObservaciones_Load);
            this.Controls.SetChildIndex(this.btnQuitObs, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnEditObs, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnRptGestObs, 0);
            this.Controls.SetChildIndex(this.btnAddObs, 0);
            this.Controls.SetChildIndex(this.btnEmitirObs, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.pnlIndicadores.ResumeLayout(false);
            this.pnlIndicadores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private GEN.ControlesBase.lblBase lblFechaFinal;
        private GEN.ControlesBase.lblBase lblFechaInicial;
        private GEN.ControlesBase.dtpFechaSimp dtpFechaFin;
        private GEN.ControlesBase.dtpFechaSimp dtpFechaInicio;
        private GEN.ControlesBase.dtgBase dtgObservaciones;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnMiniEditar btnEditObs;
        private GEN.BotonesBase.btnMiniQuitar btnQuitObs;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.CheckBox chbEtapa;
        private System.Windows.Forms.CheckBox chbSolicitud;
        private System.Windows.Forms.CheckBox chbUsuario;
        private GEN.ControlesBase.cboTipObs cboTipObs;
        private System.Windows.Forms.Label lblNombSol;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.CheckBox chbVigente;
        private System.Windows.Forms.Panel pnlIndicadores;
        private System.Windows.Forms.Label lblAbsolComplet;
        private System.Windows.Forms.Label lblRechazo;
        private System.Windows.Forms.Label lblResolComplet;
        private System.Windows.Forms.Label lblEmisionCompl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRptGestObs;
        private GEN.BotonesBase.btnAgregar btnAddObs;
        private System.Windows.Forms.Button btnEmitirObs;
    }
}