namespace CRE.Presentacion
{
    partial class frmListaCartaFianzaAprob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaCartaFianzaAprob));
            this.dtgCartasFianza = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.idCartaFianza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartasFianza)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgCartasFianza
            // 
            this.dtgCartasFianza.AllowUserToAddRows = false;
            this.dtgCartasFianza.AllowUserToDeleteRows = false;
            this.dtgCartasFianza.AllowUserToResizeColumns = false;
            this.dtgCartasFianza.AllowUserToResizeRows = false;
            this.dtgCartasFianza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCartasFianza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCartasFianza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCartaFianza,
            this.SolAproba,
            this.idSolicitud,
            this.cNombre,
            this.Moneda,
            this.nMonto,
            this.idEstadoSol});
            this.dtgCartasFianza.Location = new System.Drawing.Point(13, 13);
            this.dtgCartasFianza.MultiSelect = false;
            this.dtgCartasFianza.Name = "dtgCartasFianza";
            this.dtgCartasFianza.ReadOnly = true;
            this.dtgCartasFianza.RowHeadersVisible = false;
            this.dtgCartasFianza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCartasFianza.Size = new System.Drawing.Size(521, 150);
            this.dtgCartasFianza.TabIndex = 2;
            this.dtgCartasFianza.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCartasFianza_RowEnter);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(474, 169);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(408, 169);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // idCartaFianza
            // 
            this.idCartaFianza.DataPropertyName = "idCartaFianza";
            this.idCartaFianza.HeaderText = "idCartaFianza";
            this.idCartaFianza.Name = "idCartaFianza";
            this.idCartaFianza.ReadOnly = true;
            this.idCartaFianza.Visible = false;
            // 
            // SolAproba
            // 
            this.SolAproba.DataPropertyName = "idSolAproba";
            this.SolAproba.HeaderText = "idSolAproba";
            this.SolAproba.Name = "SolAproba";
            this.SolAproba.ReadOnly = true;
            this.SolAproba.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.HeaderText = "idSolicitud";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // Moneda
            // 
            this.Moneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Moneda.DataPropertyName = "cMoneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Width = 71;
            // 
            // nMonto
            // 
            this.nMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nMonto.DataPropertyName = "nMonto";
            this.nMonto.HeaderText = "Monto";
            this.nMonto.Name = "nMonto";
            this.nMonto.ReadOnly = true;
            this.nMonto.Width = 62;
            // 
            // idEstadoSol
            // 
            this.idEstadoSol.DataPropertyName = "idEstadoSol";
            this.idEstadoSol.HeaderText = "idEstadoSol";
            this.idEstadoSol.Name = "idEstadoSol";
            this.idEstadoSol.ReadOnly = true;
            this.idEstadoSol.Visible = false;
            // 
            // frmListaCartaFianzaAprob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 259);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgCartasFianza);
            this.Name = "frmListaCartaFianzaAprob";
            this.Text = "Lista Carta Fianza Aprobadas";
            this.Load += new System.EventHandler(this.frmListaCartaFianzaAprob_Load);
            this.Controls.SetChildIndex(this.dtgCartasFianza, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCartasFianza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCartasFianza;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCartaFianza;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolAproba;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoSol;
    }
}