namespace GEN.ControlesBase
{
    partial class frmBusCtaOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusCtaOP));
            this.conBusCtaOP = new GEN.ControlesBase.conBusCtaOP();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.ptbFirma = new System.Windows.Forms.PictureBox();
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReqFirma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nEdadCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCtaOP
            // 
            this.conBusCtaOP.Location = new System.Drawing.Point(8, 19);
            this.conBusCtaOP.Name = "conBusCtaOP";
            this.conBusCtaOP.Size = new System.Drawing.Size(563, 193);
            this.conBusCtaOP.TabIndex = 2;
            this.conBusCtaOP.ClicBusCta += new System.EventHandler(this.conBusCtaOP_ClicBusCta);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(657, 418);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 53;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(527, 418);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 52;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(587, 418);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 54;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.ptbFirma);
            this.grbBase6.Controls.Add(this.dtgIntervinientes);
            this.grbBase6.Location = new System.Drawing.Point(12, 217);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(705, 192);
            this.grbBase6.TabIndex = 89;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "INTERVINIENTES DE LA CUENTA";
            // 
            // ptbFirma
            // 
            this.ptbFirma.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbFirma.Location = new System.Drawing.Point(477, 41);
            this.ptbFirma.Name = "ptbFirma";
            this.ptbFirma.Size = new System.Drawing.Size(222, 137);
            this.ptbFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbFirma.TabIndex = 50;
            this.ptbFirma.TabStop = false;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCli,
            this.idTipoInterv,
            this.idSolicitud,
            this.cDocumentoID,
            this.cTipoDocumento,
            this.cNombre,
            this.cTipoIntervencion,
            this.lCliAfeITF,
            this.isReqFirma,
            this.idTipoDocumento,
            this.idTipoPersona,
            this.nEdadCli});
            this.dtgIntervinientes.Location = new System.Drawing.Point(10, 21);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(461, 157);
            this.dtgIntervinientes.TabIndex = 3;
            this.dtgIntervinientes.SelectionChanged += new System.EventHandler(this.dtgIntervinientes_SelectionChanged);
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.FillWeight = 80F;
            this.idSolicitud.HeaderText = "CUENTA";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Visible = false;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 90F;
            this.cDocumentoID.HeaderText = "DOCUMENTO";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cTipoDocumento
            // 
            this.cTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumento.HeaderText = "cTipoDocumento";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            this.cTipoDocumento.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 260F;
            this.cNombre.HeaderText = "NOMBRE CLIENTE";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.FillWeight = 70F;
            this.cTipoIntervencion.HeaderText = "INTERV.";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            // 
            // lCliAfeITF
            // 
            this.lCliAfeITF.DataPropertyName = "lCliAfeITF";
            this.lCliAfeITF.FillWeight = 25F;
            this.lCliAfeITF.HeaderText = "ITF";
            this.lCliAfeITF.Name = "lCliAfeITF";
            this.lCliAfeITF.ReadOnly = true;
            this.lCliAfeITF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCliAfeITF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lCliAfeITF.Visible = false;
            // 
            // isReqFirma
            // 
            this.isReqFirma.DataPropertyName = "isReqFirma";
            this.isReqFirma.FillWeight = 50F;
            this.isReqFirma.HeaderText = "FIRMA";
            this.isReqFirma.Name = "isReqFirma";
            this.isReqFirma.ReadOnly = true;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // idTipoPersona
            // 
            this.idTipoPersona.DataPropertyName = "idTipoPersona";
            this.idTipoPersona.HeaderText = "idTipoPersona";
            this.idTipoPersona.Name = "idTipoPersona";
            this.idTipoPersona.ReadOnly = true;
            this.idTipoPersona.Visible = false;
            // 
            // nEdadCli
            // 
            this.nEdadCli.DataPropertyName = "nEdadCli";
            this.nEdadCli.HeaderText = "nEdadCli";
            this.nEdadCli.Name = "nEdadCli";
            this.nEdadCli.ReadOnly = true;
            this.nEdadCli.Visible = false;
            // 
            // frmBusCtaOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 496);
            this.Controls.Add(this.grbBase6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.conBusCtaOP);
            this.Name = "frmBusCtaOP";
            this.Text = "Buscar Cuentas de las Órdenes de Pago";
            this.Load += new System.EventHandler(this.frmBusCtaOP_Load);
            this.Controls.SetChildIndex(this.conBusCtaOP, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            this.grbBase6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private conBusCtaOP conBusCtaOP;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnCancelar btnCancelar;
        private grbBase grbBase6;
        private System.Windows.Forms.PictureBox ptbFirma;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReqFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn nEdadCli;
    }
}