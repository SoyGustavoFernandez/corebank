namespace GEN.ControlesBase
{
    partial class frmAlertaOfertaCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertaOfertaCredito));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgOferta = new GEN.ControlesBase.dtgBase(this.components);
            this.idCliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstablecimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAsesorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCuotasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPerfilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoGrupoCampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMensajeSMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsClienteOfertas = new System.Windows.Forms.BindingSource(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOferta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClienteOfertas)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(575, 288);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgOferta
            // 
            this.dtgOferta.AllowUserToAddRows = false;
            this.dtgOferta.AllowUserToDeleteRows = false;
            this.dtgOferta.AllowUserToResizeColumns = false;
            this.dtgOferta.AllowUserToResizeRows = false;
            this.dtgOferta.AutoGenerateColumns = false;
            this.dtgOferta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOferta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOferta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCliDataGridViewTextBoxColumn,
            this.cTipoDocumentoDataGridViewTextBoxColumn,
            this.cDocumentoIDDataGridViewTextBoxColumn,
            this.cNombreDataGridViewTextBoxColumn,
            this.idEstablecimientoDataGridViewTextBoxColumn,
            this.idAsesorDataGridViewTextBoxColumn,
            this.idProductoDataGridViewTextBoxColumn,
            this.cMonedaDataGridViewTextBoxColumn,
            this.nCuotasDataGridViewTextBoxColumn,
            this.nMontoDataGridViewTextBoxColumn,
            this.nTazaDataGridViewTextBoxColumn,
            this.idPerfilDataGridViewTextBoxColumn,
            this.idTipoGrupoCampDataGridViewTextBoxColumn,
            this.cMensaje,
            this.cMensajeSMS});
            this.dtgOferta.DataSource = this.dsClienteOfertas;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgOferta.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgOferta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgOferta.Location = new System.Drawing.Point(3, 16);
            this.dtgOferta.MultiSelect = false;
            this.dtgOferta.Name = "dtgOferta";
            this.dtgOferta.ReadOnly = true;
            this.dtgOferta.RowHeadersVisible = false;
            this.dtgOferta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOferta.Size = new System.Drawing.Size(617, 251);
            this.dtgOferta.TabIndex = 3;
            // 
            // idCliDataGridViewTextBoxColumn
            // 
            this.idCliDataGridViewTextBoxColumn.DataPropertyName = "idCli";
            this.idCliDataGridViewTextBoxColumn.HeaderText = "idCli";
            this.idCliDataGridViewTextBoxColumn.Name = "idCliDataGridViewTextBoxColumn";
            this.idCliDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCliDataGridViewTextBoxColumn.Visible = false;
            // 
            // cTipoDocumentoDataGridViewTextBoxColumn
            // 
            this.cTipoDocumentoDataGridViewTextBoxColumn.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumentoDataGridViewTextBoxColumn.HeaderText = "cTipoDocumento";
            this.cTipoDocumentoDataGridViewTextBoxColumn.Name = "cTipoDocumentoDataGridViewTextBoxColumn";
            this.cTipoDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cTipoDocumentoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cDocumentoIDDataGridViewTextBoxColumn
            // 
            this.cDocumentoIDDataGridViewTextBoxColumn.DataPropertyName = "cDocumentoID";
            this.cDocumentoIDDataGridViewTextBoxColumn.HeaderText = "cDocumentoID";
            this.cDocumentoIDDataGridViewTextBoxColumn.Name = "cDocumentoIDDataGridViewTextBoxColumn";
            this.cDocumentoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDocumentoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cNombreDataGridViewTextBoxColumn
            // 
            this.cNombreDataGridViewTextBoxColumn.DataPropertyName = "cNombre";
            this.cNombreDataGridViewTextBoxColumn.HeaderText = "cNombre";
            this.cNombreDataGridViewTextBoxColumn.Name = "cNombreDataGridViewTextBoxColumn";
            this.cNombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.cNombreDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEstablecimientoDataGridViewTextBoxColumn
            // 
            this.idEstablecimientoDataGridViewTextBoxColumn.DataPropertyName = "idEstablecimiento";
            this.idEstablecimientoDataGridViewTextBoxColumn.HeaderText = "idEstablecimiento";
            this.idEstablecimientoDataGridViewTextBoxColumn.Name = "idEstablecimientoDataGridViewTextBoxColumn";
            this.idEstablecimientoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEstablecimientoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idAsesorDataGridViewTextBoxColumn
            // 
            this.idAsesorDataGridViewTextBoxColumn.DataPropertyName = "idAsesor";
            this.idAsesorDataGridViewTextBoxColumn.HeaderText = "idAsesor";
            this.idAsesorDataGridViewTextBoxColumn.Name = "idAsesorDataGridViewTextBoxColumn";
            this.idAsesorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAsesorDataGridViewTextBoxColumn.Visible = false;
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "idProducto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "idProducto";
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProductoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cMonedaDataGridViewTextBoxColumn
            // 
            this.cMonedaDataGridViewTextBoxColumn.DataPropertyName = "cMoneda";
            this.cMonedaDataGridViewTextBoxColumn.HeaderText = "cMoneda";
            this.cMonedaDataGridViewTextBoxColumn.Name = "cMonedaDataGridViewTextBoxColumn";
            this.cMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cMonedaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nCuotasDataGridViewTextBoxColumn
            // 
            this.nCuotasDataGridViewTextBoxColumn.DataPropertyName = "nCuotas";
            this.nCuotasDataGridViewTextBoxColumn.HeaderText = "nCuotas";
            this.nCuotasDataGridViewTextBoxColumn.Name = "nCuotasDataGridViewTextBoxColumn";
            this.nCuotasDataGridViewTextBoxColumn.ReadOnly = true;
            this.nCuotasDataGridViewTextBoxColumn.Visible = false;
            // 
            // nMontoDataGridViewTextBoxColumn
            // 
            this.nMontoDataGridViewTextBoxColumn.DataPropertyName = "nMonto";
            this.nMontoDataGridViewTextBoxColumn.HeaderText = "nMonto";
            this.nMontoDataGridViewTextBoxColumn.Name = "nMontoDataGridViewTextBoxColumn";
            this.nMontoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMontoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nTazaDataGridViewTextBoxColumn
            // 
            this.nTazaDataGridViewTextBoxColumn.DataPropertyName = "nTaza";
            this.nTazaDataGridViewTextBoxColumn.HeaderText = "nTaza";
            this.nTazaDataGridViewTextBoxColumn.Name = "nTazaDataGridViewTextBoxColumn";
            this.nTazaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nTazaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPerfilDataGridViewTextBoxColumn
            // 
            this.idPerfilDataGridViewTextBoxColumn.DataPropertyName = "idPerfil";
            this.idPerfilDataGridViewTextBoxColumn.HeaderText = "idPerfil";
            this.idPerfilDataGridViewTextBoxColumn.Name = "idPerfilDataGridViewTextBoxColumn";
            this.idPerfilDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPerfilDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTipoGrupoCampDataGridViewTextBoxColumn
            // 
            this.idTipoGrupoCampDataGridViewTextBoxColumn.DataPropertyName = "idTipoGrupoCamp";
            this.idTipoGrupoCampDataGridViewTextBoxColumn.HeaderText = "idTipoGrupoCamp";
            this.idTipoGrupoCampDataGridViewTextBoxColumn.Name = "idTipoGrupoCampDataGridViewTextBoxColumn";
            this.idTipoGrupoCampDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoGrupoCampDataGridViewTextBoxColumn.Visible = false;
            // 
            // cMensaje
            // 
            this.cMensaje.DataPropertyName = "cMensaje";
            this.cMensaje.HeaderText = "Oferta";
            this.cMensaje.Name = "cMensaje";
            this.cMensaje.ReadOnly = true;
            // 
            // cMensajeSMS
            // 
            this.cMensajeSMS.DataPropertyName = "cMensajeSMS";
            this.cMensajeSMS.HeaderText = "cMensajeSMS";
            this.cMensajeSMS.Name = "cMensajeSMS";
            this.cMensajeSMS.ReadOnly = true;
            this.cMensajeSMS.Visible = false;
            // 
            // dsClienteOfertas
            // 
            this.dsClienteOfertas.DataSource = typeof(EntityLayer.clsClienteOfertas);
            // 
            // grbBase1
            // 
            this.grbBase1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBase1.Controls.Add(this.dtgOferta);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(623, 270);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Ofertas de crédito";
            // 
            // frmAlertaOfertaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 363);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAlertaOfertaCredito";
            this.Text = "Alerta de oferta de Crédito";
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOferta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClienteOfertas)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnSalir btnSalir1;
        private dtgBase dtgOferta;
        private grbBase grbBase1;
        private System.Windows.Forms.BindingSource dsClienteOfertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstablecimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsesorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCuotasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTazaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPerfilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoGrupoCampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMensajeSMS;
    }
}