namespace CRE.Presentacion
{
    partial class frmSeleccionarCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarCartaFianza));
            this.dtgCartasFianzas = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCartaFianza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCartaFianza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTasaComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPlazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartasFianzas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCartasFianzas
            // 
            this.dtgCartasFianzas.AllowUserToAddRows = false;
            this.dtgCartasFianzas.AllowUserToDeleteRows = false;
            this.dtgCartasFianzas.AllowUserToResizeColumns = false;
            this.dtgCartasFianzas.AllowUserToResizeRows = false;
            this.dtgCartasFianzas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCartasFianzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCartasFianzas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMoneda,
            this.codCartaFianza,
            this.idCartaFianza,
            this.cSimbolo,
            this.nMonto,
            this.nTasaComision,
            this.dFechaVigencia,
            this.nPlazo,
            this.idProducto});
            this.dtgCartasFianzas.Location = new System.Drawing.Point(13, 13);
            this.dtgCartasFianzas.MultiSelect = false;
            this.dtgCartasFianzas.Name = "dtgCartasFianzas";
            this.dtgCartasFianzas.ReadOnly = true;
            this.dtgCartasFianzas.RowHeadersVisible = false;
            this.dtgCartasFianzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCartasFianzas.Size = new System.Drawing.Size(603, 150);
            this.dtgCartasFianzas.TabIndex = 2;
            this.dtgCartasFianzas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCartasFianzas_CellEnter);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(495, 169);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(556, 169);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.HeaderText = "idMoneda";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.ReadOnly = true;
            this.idMoneda.Visible = false;
            // 
            // codCartaFianza
            // 
            this.codCartaFianza.DataPropertyName = "codCartaFianza";
            this.codCartaFianza.HeaderText = "Cod. Carta Fianza";
            this.codCartaFianza.Name = "codCartaFianza";
            this.codCartaFianza.ReadOnly = true;
            // 
            // idCartaFianza
            // 
            this.idCartaFianza.DataPropertyName = "idCartaFianza";
            this.idCartaFianza.HeaderText = "idCartaFianza";
            this.idCartaFianza.Name = "idCartaFianza";
            this.idCartaFianza.ReadOnly = true;
            this.idCartaFianza.Visible = false;
            // 
            // cSimbolo
            // 
            this.cSimbolo.DataPropertyName = "cSimbolo";
            this.cSimbolo.HeaderText = "Moneda";
            this.cSimbolo.Name = "cSimbolo";
            this.cSimbolo.ReadOnly = true;
            // 
            // nMonto
            // 
            this.nMonto.DataPropertyName = "nMonto";
            this.nMonto.HeaderText = "Monto";
            this.nMonto.Name = "nMonto";
            this.nMonto.ReadOnly = true;
            // 
            // nTasaComision
            // 
            this.nTasaComision.DataPropertyName = "nTasaComision";
            this.nTasaComision.HeaderText = "Tasa Comision";
            this.nTasaComision.Name = "nTasaComision";
            this.nTasaComision.ReadOnly = true;
            // 
            // dFechaVigencia
            // 
            this.dFechaVigencia.DataPropertyName = "dFechaVigencia";
            this.dFechaVigencia.HeaderText = "Fecha Inicio Vigencia";
            this.dFechaVigencia.Name = "dFechaVigencia";
            this.dFechaVigencia.ReadOnly = true;
            // 
            // nPlazo
            // 
            this.nPlazo.DataPropertyName = "nPlazo";
            this.nPlazo.HeaderText = "Plazo";
            this.nPlazo.Name = "nPlazo";
            this.nPlazo.ReadOnly = true;
            // 
            // idProducto
            // 
            this.idProducto.DataPropertyName = "idProducto";
            this.idProducto.HeaderText = "idProducto";
            this.idProducto.Name = "idProducto";
            this.idProducto.ReadOnly = true;
            this.idProducto.Visible = false;
            // 
            // frmSeleccionarCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 252);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.dtgCartasFianzas);
            this.Name = "frmSeleccionarCartaFianza";
            this.Text = "Seleccionar Carta Fianza";
            this.Controls.SetChildIndex(this.dtgCartasFianzas, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartasFianzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCartasFianzas;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCartaFianza;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCartaFianza;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTasaComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaVigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPlazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
    }
}