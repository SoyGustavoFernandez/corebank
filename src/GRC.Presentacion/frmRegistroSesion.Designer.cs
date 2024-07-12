namespace GRC.Presentacion
{
    partial class frmRegistroSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroSesion));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgConsejos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgIntegrantes = new GEN.ControlesBase.dtgBase(this.components);
            this.cboTipoSesion2 = new GEN.ControlesBase.cboTipoSesion(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.txtAsunto = new GEN.ControlesBase.txtBase(this.components);
            this.txtAcuerdos = new GEN.ControlesBase.txtBase(this.components);
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsejos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(305, 628);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(371, 628);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 10;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(173, 628);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 7;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(239, 628);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 8;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(437, 628);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgConsejos
            // 
            this.dtgConsejos.AllowUserToAddRows = false;
            this.dtgConsejos.AllowUserToDeleteRows = false;
            this.dtgConsejos.AllowUserToResizeColumns = false;
            this.dtgConsejos.AllowUserToResizeRows = false;
            this.dtgConsejos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConsejos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsejos.Location = new System.Drawing.Point(12, 12);
            this.dtgConsejos.MultiSelect = false;
            this.dtgConsejos.Name = "dtgConsejos";
            this.dtgConsejos.ReadOnly = true;
            this.dtgConsejos.RowHeadersVisible = false;
            this.dtgConsejos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConsejos.Size = new System.Drawing.Size(549, 92);
            this.dtgConsejos.TabIndex = 0;
            this.dtgConsejos.SelectionChanged += new System.EventHandler(this.dtgConsejos_SelectionChanged);
            // 
            // dtgIntegrantes
            // 
            this.dtgIntegrantes.AllowUserToAddRows = false;
            this.dtgIntegrantes.AllowUserToDeleteRows = false;
            this.dtgIntegrantes.AllowUserToResizeColumns = false;
            this.dtgIntegrantes.AllowUserToResizeRows = false;
            this.dtgIntegrantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantes.Enabled = false;
            this.dtgIntegrantes.Location = new System.Drawing.Point(12, 128);
            this.dtgIntegrantes.MultiSelect = false;
            this.dtgIntegrantes.Name = "dtgIntegrantes";
            this.dtgIntegrantes.ReadOnly = true;
            this.dtgIntegrantes.RowHeadersVisible = false;
            this.dtgIntegrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantes.Size = new System.Drawing.Size(549, 142);
            this.dtgIntegrantes.TabIndex = 1;
            // 
            // cboTipoSesion2
            // 
            this.cboTipoSesion2.Enabled = false;
            this.cboTipoSesion2.FormattingEnabled = true;
            this.cboTipoSesion2.Location = new System.Drawing.Point(116, 289);
            this.cboTipoSesion2.Name = "cboTipoSesion2";
            this.cboTipoSesion2.Size = new System.Drawing.Size(181, 21);
            this.cboTipoSesion2.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(116, 312);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(445, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Enabled = false;
            this.txtAsunto.Location = new System.Drawing.Point(116, 334);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(445, 20);
            this.txtAsunto.TabIndex = 4;
            // 
            // txtAcuerdos
            // 
            this.txtAcuerdos.Enabled = false;
            this.txtAcuerdos.Location = new System.Drawing.Point(116, 357);
            this.txtAcuerdos.Multiline = true;
            this.txtAcuerdos.Name = "txtAcuerdos";
            this.txtAcuerdos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAcuerdos.Size = new System.Drawing.Size(445, 75);
            this.txtAcuerdos.TabIndex = 5;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Location = new System.Drawing.Point(116, 435);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(445, 72);
            this.txtObservaciones.TabIndex = 6;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 292);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(78, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Tipo Sesión:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 315);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(78, 13);
            this.lblBase6.TabIndex = 21;
            this.lblBase6.Text = "Descripción:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(9, 337);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(51, 13);
            this.lblBase7.TabIndex = 21;
            this.lblBase7.Text = "Asunto:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 360);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 21;
            this.lblBase8.Text = "Acuerdos:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(9, 441);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(96, 13);
            this.lblBase9.TabIndex = 21;
            this.lblBase9.Text = "Observaciones:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 112);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(147, 13);
            this.lblBase1.TabIndex = 22;
            this.lblBase1.Text = "Integrantes de Consejo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, -1);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 23;
            this.lblBase2.Text = "Consejos:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 525);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 24;
            this.lblBase3.Text = "Documentos:";
            // 
            // dtgDocumentos
            // 
            this.dtgDocumentos.AllowUserToAddRows = false;
            this.dtgDocumentos.AllowUserToDeleteRows = false;
            this.dtgDocumentos.AllowUserToResizeColumns = false;
            this.dtgDocumentos.AllowUserToResizeRows = false;
            this.dtgDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentos.Enabled = false;
            this.dtgDocumentos.Location = new System.Drawing.Point(116, 516);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(379, 106);
            this.dtgDocumentos.TabIndex = 25;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(501, 516);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 26;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Enabled = false;
            this.btnQuitar1.Location = new System.Drawing.Point(501, 572);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 27;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // frmRegistroSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 703);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.dtgDocumentos);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtAcuerdos);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cboTipoSesion2);
            this.Controls.Add(this.dtgIntegrantes);
            this.Controls.Add(this.dtgConsejos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Name = "frmRegistroSesion";
            this.Text = "Registro de Sesión Realizada";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgConsejos, 0);
            this.Controls.SetChildIndex(this.dtgIntegrantes, 0);
            this.Controls.SetChildIndex(this.cboTipoSesion2, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.txtAsunto, 0);
            this.Controls.SetChildIndex(this.txtAcuerdos, 0);
            this.Controls.SetChildIndex(this.txtObservaciones, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtgDocumentos, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsejos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgConsejos;
        private GEN.ControlesBase.dtgBase dtgIntegrantes;
        private GEN.ControlesBase.cboTipoSesion cboTipoSesion2;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.txtBase txtAsunto;
        private GEN.ControlesBase.txtBase txtAcuerdos;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
    }
}

