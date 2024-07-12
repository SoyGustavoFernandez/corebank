namespace CRE.Presentacion
{
    partial class frmGruSolExcNoCon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGruSolExcNoCon));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtidSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.grbReglas = new GEN.ControlesBase.grbBase(this.components);
            this.btnDetalle1 = new GEN.BotonesBase.btnDetalle();
            this.btnOtrasRNC = new GEN.BotonesBase.Boton();
            this.dtgReglas = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.txtMensajeError = new GEN.ControlesBase.txtBase(this.components);
            this.txtidRegla = new GEN.ControlesBase.txtBase(this.components);
            this.btnSolicitar1 = new GEN.BotonesBase.btnSolicitar();
            this.btnBusSolicitud1 = new GEN.BotonesBase.btnBusSolicitud();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtRnc = new GEN.ControlesBase.txtBase(this.components);
            this.txtExcepciones = new GEN.ControlesBase.txtBase(this.components);
            this.txtExcepcionesManuales = new GEN.ControlesBase.txtBase(this.components);
            this.txtExcepcionesAutomaticas = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombreMiembro = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgMiembros = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtidSolicitudCredGrupoSol = new GEN.ControlesBase.txtBase(this.components);
            this.grbReglas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReglas)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMiembros)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 45);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Código Solicitud:";
            // 
            // txtidSolicitud
            // 
            this.txtidSolicitud.Enabled = false;
            this.txtidSolicitud.Location = new System.Drawing.Point(124, 42);
            this.txtidSolicitud.Name = "txtidSolicitud";
            this.txtidSolicitud.Size = new System.Drawing.Size(100, 20);
            this.txtidSolicitud.TabIndex = 3;
            // 
            // grbReglas
            // 
            this.grbReglas.Controls.Add(this.btnDetalle1);
            this.grbReglas.Controls.Add(this.btnOtrasRNC);
            this.grbReglas.Controls.Add(this.dtgReglas);
            this.grbReglas.Controls.Add(this.btnSalir1);
            this.grbReglas.Controls.Add(this.lblBase4);
            this.grbReglas.Controls.Add(this.lblBase3);
            this.grbReglas.Controls.Add(this.txtSustento);
            this.grbReglas.Controls.Add(this.txtMensajeError);
            this.grbReglas.Controls.Add(this.txtidRegla);
            this.grbReglas.Controls.Add(this.btnSolicitar1);
            this.grbReglas.Location = new System.Drawing.Point(295, 68);
            this.grbReglas.Name = "grbReglas";
            this.grbReglas.Size = new System.Drawing.Size(419, 474);
            this.grbReglas.TabIndex = 5;
            this.grbReglas.TabStop = false;
            this.grbReglas.Text = "Datos de Reglas de la Solicitud";
            // 
            // btnDetalle1
            // 
            this.btnDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle1.BackgroundImage")));
            this.btnDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle1.Location = new System.Drawing.Point(221, 418);
            this.btnDetalle1.Name = "btnDetalle1";
            this.btnDetalle1.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle1.TabIndex = 17;
            this.btnDetalle1.Text = "&Detallar";
            this.btnDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle1.texto = "&Detallar";
            this.btnDetalle1.UseVisualStyleBackColor = true;
            this.btnDetalle1.Click += new System.EventHandler(this.btnDetalle1_Click);
            // 
            // btnOtrasRNC
            // 
            this.btnOtrasRNC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOtrasRNC.Location = new System.Drawing.Point(6, 418);
            this.btnOtrasRNC.Name = "btnOtrasRNC";
            this.btnOtrasRNC.Size = new System.Drawing.Size(60, 50);
            this.btnOtrasRNC.TabIndex = 19;
            this.btnOtrasRNC.Text = "Otras RNC";
            this.btnOtrasRNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOtrasRNC.UseVisualStyleBackColor = true;
            this.btnOtrasRNC.Click += new System.EventHandler(this.btnOtrasRNC_Click);
            // 
            // dtgReglas
            // 
            this.dtgReglas.AllowUserToAddRows = false;
            this.dtgReglas.AllowUserToDeleteRows = false;
            this.dtgReglas.AllowUserToResizeColumns = false;
            this.dtgReglas.AllowUserToResizeRows = false;
            this.dtgReglas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReglas.Location = new System.Drawing.Point(6, 19);
            this.dtgReglas.MultiSelect = false;
            this.dtgReglas.Name = "dtgReglas";
            this.dtgReglas.ReadOnly = true;
            this.dtgReglas.RowHeadersVisible = false;
            this.dtgReglas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReglas.Size = new System.Drawing.Size(407, 226);
            this.dtgReglas.TabIndex = 0;
            this.dtgReglas.SelectionChanged += new System.EventHandler(this.dtgReglas_SelectionChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(353, 418);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 18;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 300);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Sustento:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 254);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(44, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Regla:";
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(6, 316);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(407, 96);
            this.txtSustento.TabIndex = 3;
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.Enabled = false;
            this.txtMensajeError.Location = new System.Drawing.Point(6, 277);
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.Size = new System.Drawing.Size(407, 20);
            this.txtMensajeError.TabIndex = 3;
            // 
            // txtidRegla
            // 
            this.txtidRegla.Enabled = false;
            this.txtidRegla.Location = new System.Drawing.Point(56, 251);
            this.txtidRegla.Name = "txtidRegla";
            this.txtidRegla.Size = new System.Drawing.Size(100, 20);
            this.txtidRegla.TabIndex = 3;
            // 
            // btnSolicitar1
            // 
            this.btnSolicitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolicitar1.BackgroundImage")));
            this.btnSolicitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolicitar1.Location = new System.Drawing.Point(287, 418);
            this.btnSolicitar1.Name = "btnSolicitar1";
            this.btnSolicitar1.Size = new System.Drawing.Size(60, 50);
            this.btnSolicitar1.TabIndex = 10;
            this.btnSolicitar1.Text = "Solicitar";
            this.btnSolicitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolicitar1.UseVisualStyleBackColor = true;
            this.btnSolicitar1.Click += new System.EventHandler(this.btnSolicitar1_Click);
            // 
            // btnBusSolicitud1
            // 
            this.btnBusSolicitud1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusSolicitud1.BackgroundImage")));
            this.btnBusSolicitud1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusSolicitud1.Location = new System.Drawing.Point(654, 12);
            this.btnBusSolicitud1.Name = "btnBusSolicitud1";
            this.btnBusSolicitud1.Size = new System.Drawing.Size(60, 50);
            this.btnBusSolicitud1.TabIndex = 6;
            this.btnBusSolicitud1.Text = "&Buscar Solicitud";
            this.btnBusSolicitud1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusSolicitud1.UseVisualStyleBackColor = true;
            this.btnBusSolicitud1.Click += new System.EventHandler(this.btnBusSolicitud1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtRnc);
            this.grbBase2.Controls.Add(this.txtExcepciones);
            this.grbBase2.Controls.Add(this.txtExcepcionesManuales);
            this.grbBase2.Controls.Add(this.txtExcepcionesAutomaticas);
            this.grbBase2.Controls.Add(this.txtNombreMiembro);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.dtgMiembros);
            this.grbBase2.Location = new System.Drawing.Point(15, 68);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(274, 474);
            this.grbBase2.TabIndex = 5;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Miembros del Grupo Solidario";
            // 
            // txtRnc
            // 
            this.txtRnc.Enabled = false;
            this.txtRnc.Location = new System.Drawing.Point(232, 437);
            this.txtRnc.Name = "txtRnc";
            this.txtRnc.Size = new System.Drawing.Size(36, 20);
            this.txtRnc.TabIndex = 2;
            // 
            // txtExcepciones
            // 
            this.txtExcepciones.Enabled = false;
            this.txtExcepciones.Location = new System.Drawing.Point(232, 401);
            this.txtExcepciones.Name = "txtExcepciones";
            this.txtExcepciones.Size = new System.Drawing.Size(36, 20);
            this.txtExcepciones.TabIndex = 2;
            // 
            // txtExcepcionesManuales
            // 
            this.txtExcepcionesManuales.Enabled = false;
            this.txtExcepcionesManuales.Location = new System.Drawing.Point(232, 361);
            this.txtExcepcionesManuales.Name = "txtExcepcionesManuales";
            this.txtExcepcionesManuales.Size = new System.Drawing.Size(36, 20);
            this.txtExcepcionesManuales.TabIndex = 2;
            // 
            // txtExcepcionesAutomaticas
            // 
            this.txtExcepcionesAutomaticas.Enabled = false;
            this.txtExcepcionesAutomaticas.Location = new System.Drawing.Point(232, 322);
            this.txtExcepcionesAutomaticas.Name = "txtExcepcionesAutomaticas";
            this.txtExcepcionesAutomaticas.Size = new System.Drawing.Size(36, 20);
            this.txtExcepcionesAutomaticas.TabIndex = 2;
            // 
            // txtNombreMiembro
            // 
            this.txtNombreMiembro.Enabled = false;
            this.txtNombreMiembro.Location = new System.Drawing.Point(82, 255);
            this.txtNombreMiembro.Multiline = true;
            this.txtNombreMiembro.Name = "txtNombreMiembro";
            this.txtNombreMiembro.Size = new System.Drawing.Size(186, 40);
            this.txtNombreMiembro.TabIndex = 2;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(112, 431);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(109, 26);
            this.lblBase8.TabIndex = 1;
            this.lblBase8.Text = "Nº total de reglas\r\nno contempladas:";
            this.lblBase8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(139, 395);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(82, 26);
            this.lblBase9.TabIndex = 1;
            this.lblBase9.Text = "Nº total de \r\nexcepciones:";
            this.lblBase9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(92, 355);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(129, 26);
            this.lblBase7.TabIndex = 1;
            this.lblBase7.Text = "Nº de excepciones \r\nmanuales del cliente:";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(78, 316);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(143, 26);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Nº de excepciones \r\nautomaticas del cliente:";
            this.lblBase6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 255);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(70, 26);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Nombre\r\ndel cliente:";
            // 
            // dtgMiembros
            // 
            this.dtgMiembros.AllowUserToAddRows = false;
            this.dtgMiembros.AllowUserToDeleteRows = false;
            this.dtgMiembros.AllowUserToResizeColumns = false;
            this.dtgMiembros.AllowUserToResizeRows = false;
            this.dtgMiembros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMiembros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMiembros.Location = new System.Drawing.Point(6, 19);
            this.dtgMiembros.MultiSelect = false;
            this.dtgMiembros.Name = "dtgMiembros";
            this.dtgMiembros.ReadOnly = true;
            this.dtgMiembros.RowHeadersVisible = false;
            this.dtgMiembros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMiembros.Size = new System.Drawing.Size(262, 226);
            this.dtgMiembros.TabIndex = 0;
            this.dtgMiembros.SelectionChanged += new System.EventHandler(this.dtgMiembros_SelectionChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 15);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(197, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Código Solicitud Grupo Solidario:";
            // 
            // txtidSolicitudCredGrupoSol
            // 
            this.txtidSolicitudCredGrupoSol.Enabled = false;
            this.txtidSolicitudCredGrupoSol.Location = new System.Drawing.Point(217, 12);
            this.txtidSolicitudCredGrupoSol.Name = "txtidSolicitudCredGrupoSol";
            this.txtidSolicitudCredGrupoSol.Size = new System.Drawing.Size(100, 20);
            this.txtidSolicitudCredGrupoSol.TabIndex = 3;
            // 
            // frmGruSolExcNoCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 578);
            this.Controls.Add(this.btnBusSolicitud1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbReglas);
            this.Controls.Add(this.txtidSolicitudCredGrupoSol);
            this.Controls.Add(this.txtidSolicitud);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmGruSolExcNoCon";
            this.Text = "Gestion de Excepciones no Contempladas";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtidSolicitud, 0);
            this.Controls.SetChildIndex(this.txtidSolicitudCredGrupoSol, 0);
            this.Controls.SetChildIndex(this.grbReglas, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnBusSolicitud1, 0);
            this.grbReglas.ResumeLayout(false);
            this.grbReglas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReglas)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMiembros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtidSolicitud;
        private GEN.ControlesBase.grbBase grbReglas;
        private GEN.ControlesBase.dtgBase dtgReglas;
        private GEN.BotonesBase.btnBusSolicitud btnBusSolicitud1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgMiembros;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtidSolicitudCredGrupoSol;
        private GEN.BotonesBase.btnDetalle btnDetalle1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.txtBase txtMensajeError;
        private GEN.ControlesBase.txtBase txtidRegla;
        private GEN.BotonesBase.btnSolicitar btnSolicitar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.Boton btnOtrasRNC;
        private GEN.ControlesBase.txtBase txtRnc;
        private GEN.ControlesBase.txtBase txtExcepciones;
        private GEN.ControlesBase.txtBase txtExcepcionesManuales;
        private GEN.ControlesBase.txtBase txtExcepcionesAutomaticas;
        private GEN.ControlesBase.txtBase txtNombreMiembro;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}