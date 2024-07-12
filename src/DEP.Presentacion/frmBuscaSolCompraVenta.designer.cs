namespace DEP.Presentacion
{
    partial class frmBuscaSolCompraVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaSolCompraVenta));
            this.dtgSolComVen = new GEN.ControlesBase.dtgBase(this.components);
            this.idOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipComVen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoEqui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonRedondeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bTipCamEsp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolComVen)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSolComVen
            // 
            this.dtgSolComVen.AllowUserToAddRows = false;
            this.dtgSolComVen.AllowUserToDeleteRows = false;
            this.dtgSolComVen.AllowUserToResizeColumns = false;
            this.dtgSolComVen.AllowUserToResizeRows = false;
            this.dtgSolComVen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolComVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolComVen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOperacion,
            this.idEstadoOpe,
            this.cEstadoSol,
            this.dFechaOpe,
            this.idUsuOpe,
            this.idAgencia,
            this.idTipComVen,
            this.nMontoOpe,
            this.nTipoCambio,
            this.cTipoOperacion,
            this.nMontoEqui,
            this.nMonRedondeo,
            this.nMontoNeto,
            this.cDocumentoID,
            this.cNombre,
            this.cDireccion,
            this.bTipCamEsp,
            this.idEstadoSol,
            this.idSolAproba,
            this.cCodCliente,
            this.idNacionalidad,
            this.idTipDocumento});
            this.dtgSolComVen.Location = new System.Drawing.Point(12, 43);
            this.dtgSolComVen.MultiSelect = false;
            this.dtgSolComVen.Name = "dtgSolComVen";
            this.dtgSolComVen.ReadOnly = true;
            this.dtgSolComVen.RowHeadersVisible = false;
            this.dtgSolComVen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolComVen.Size = new System.Drawing.Size(678, 150);
            this.dtgSolComVen.TabIndex = 2;
            this.dtgSolComVen.SelectionChanged += new System.EventHandler(this.dtgSolComVen_SelectionChanged);
            // 
            // idOperacion
            // 
            this.idOperacion.DataPropertyName = "idOperacion";
            this.idOperacion.FillWeight = 31.09585F;
            this.idOperacion.HeaderText = "Cod";
            this.idOperacion.Name = "idOperacion";
            this.idOperacion.ReadOnly = true;
            // 
            // idEstadoOpe
            // 
            this.idEstadoOpe.DataPropertyName = "idEstadoOpe";
            this.idEstadoOpe.HeaderText = "idEstadoOpe";
            this.idEstadoOpe.Name = "idEstadoOpe";
            this.idEstadoOpe.ReadOnly = true;
            this.idEstadoOpe.Visible = false;
            // 
            // cEstadoSol
            // 
            this.cEstadoSol.DataPropertyName = "cEstadoSol";
            this.cEstadoSol.HeaderText = "Estado";
            this.cEstadoSol.Name = "cEstadoSol";
            this.cEstadoSol.ReadOnly = true;
            // 
            // dFechaOpe
            // 
            this.dFechaOpe.DataPropertyName = "dFechaOpe";
            this.dFechaOpe.HeaderText = "dFechaOpe";
            this.dFechaOpe.Name = "dFechaOpe";
            this.dFechaOpe.ReadOnly = true;
            this.dFechaOpe.Visible = false;
            // 
            // idUsuOpe
            // 
            this.idUsuOpe.DataPropertyName = "idUsuOpe";
            this.idUsuOpe.HeaderText = "idUsuOpe";
            this.idUsuOpe.Name = "idUsuOpe";
            this.idUsuOpe.ReadOnly = true;
            this.idUsuOpe.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // idTipComVen
            // 
            this.idTipComVen.DataPropertyName = "idTipComVen";
            this.idTipComVen.HeaderText = "idTipComVen";
            this.idTipComVen.Name = "idTipComVen";
            this.idTipComVen.ReadOnly = true;
            this.idTipComVen.Visible = false;
            // 
            // nMontoOpe
            // 
            this.nMontoOpe.DataPropertyName = "nMontoOpe";
            this.nMontoOpe.FillWeight = 60F;
            this.nMontoOpe.HeaderText = "Monto";
            this.nMontoOpe.Name = "nMontoOpe";
            this.nMontoOpe.ReadOnly = true;
            // 
            // nTipoCambio
            // 
            this.nTipoCambio.DataPropertyName = "nTipoCambio";
            this.nTipoCambio.FillWeight = 60F;
            this.nTipoCambio.HeaderText = "Tipo Cambio";
            this.nTipoCambio.Name = "nTipoCambio";
            this.nTipoCambio.ReadOnly = true;
            // 
            // cTipoOperacion
            // 
            this.cTipoOperacion.DataPropertyName = "cTipoOperacion";
            this.cTipoOperacion.HeaderText = "Tipo de Operación";
            this.cTipoOperacion.Name = "cTipoOperacion";
            this.cTipoOperacion.ReadOnly = true;
            // 
            // nMontoEqui
            // 
            this.nMontoEqui.DataPropertyName = "nMontoEqui";
            this.nMontoEqui.HeaderText = "nMontoEqui";
            this.nMontoEqui.Name = "nMontoEqui";
            this.nMontoEqui.ReadOnly = true;
            this.nMontoEqui.Visible = false;
            // 
            // nMonRedondeo
            // 
            this.nMonRedondeo.DataPropertyName = "nMonRedondeo";
            this.nMonRedondeo.HeaderText = "nMonRedondeo";
            this.nMonRedondeo.Name = "nMonRedondeo";
            this.nMonRedondeo.ReadOnly = true;
            this.nMonRedondeo.Visible = false;
            // 
            // nMontoNeto
            // 
            this.nMontoNeto.DataPropertyName = "nMontoNeto";
            this.nMontoNeto.HeaderText = "nMontoNeto";
            this.nMontoNeto.Name = "nMontoNeto";
            this.nMontoNeto.ReadOnly = true;
            this.nMontoNeto.Visible = false;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 62.1917F;
            this.cDocumentoID.HeaderText = "Nº Documento";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 116.6094F;
            this.cNombre.HeaderText = "Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cDireccion
            // 
            this.cDireccion.DataPropertyName = "cDireccion";
            this.cDireccion.HeaderText = "cDireccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Visible = false;
            // 
            // bTipCamEsp
            // 
            this.bTipCamEsp.DataPropertyName = "bTipCamEsp";
            this.bTipCamEsp.HeaderText = "bTipCamEsp";
            this.bTipCamEsp.Name = "bTipCamEsp";
            this.bTipCamEsp.ReadOnly = true;
            this.bTipCamEsp.Visible = false;
            // 
            // idEstadoSol
            // 
            this.idEstadoSol.DataPropertyName = "idEstadoSol";
            this.idEstadoSol.HeaderText = "idEstadoSol";
            this.idEstadoSol.Name = "idEstadoSol";
            this.idEstadoSol.ReadOnly = true;
            this.idEstadoSol.Visible = false;
            // 
            // idSolAproba
            // 
            this.idSolAproba.DataPropertyName = "idSolAproba";
            this.idSolAproba.HeaderText = "idSolAproba";
            this.idSolAproba.Name = "idSolAproba";
            this.idSolAproba.ReadOnly = true;
            this.idSolAproba.Visible = false;
            // 
            // cCodCliente
            // 
            this.cCodCliente.DataPropertyName = "cCodCliente";
            this.cCodCliente.HeaderText = "cCodCliente";
            this.cCodCliente.Name = "cCodCliente";
            this.cCodCliente.ReadOnly = true;
            this.cCodCliente.Visible = false;
            // 
            // idNacionalidad
            // 
            this.idNacionalidad.DataPropertyName = "idNacionalidad";
            this.idNacionalidad.HeaderText = "idNacionalidad";
            this.idNacionalidad.Name = "idNacionalidad";
            this.idNacionalidad.ReadOnly = true;
            this.idNacionalidad.Visible = false;
            // 
            // idTipDocumento
            // 
            this.idTipDocumento.DataPropertyName = "idTipDocumento";
            this.idTipDocumento.HeaderText = "idTipDocumento";
            this.idTipDocumento.Name = "idTipDocumento";
            this.idTipDocumento.ReadOnly = true;
            this.idTipDocumento.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.SystemColors.Info;
            this.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 8);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(678, 27);
            this.lblDescripcion.TabIndex = 108;
            this.lblDescripcion.Text = "LISTA LAS SOLICITUDES DE COMPRA VENTA";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(564, 199);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 109;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(630, 199);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 110;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmBuscaSolCompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 280);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.dtgSolComVen);
            this.Name = "frmBuscaSolCompraVenta";
            this.Text = "Solicitud de Compra Venta";
            this.Load += new System.EventHandler(this.frmBuscaSolCompraVenta_Load);
            this.Controls.SetChildIndex(this.dtgSolComVen, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolComVen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgSolComVen;
        private System.Windows.Forms.Label lblDescripcion;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipComVen;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoEqui;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonRedondeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn bTipCamEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolAproba;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipDocumento;
    }
}