namespace RCP.Presentacion
{
    partial class frmTransferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferencias));
            this.dtgResumenTransferencia = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.idResumenAsigCartRecuperaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNroCreditos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumenTransferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgResumenTransferencia
            // 
            this.dtgResumenTransferencia.AllowUserToAddRows = false;
            this.dtgResumenTransferencia.AllowUserToDeleteRows = false;
            this.dtgResumenTransferencia.AllowUserToResizeColumns = false;
            this.dtgResumenTransferencia.AllowUserToResizeRows = false;
            this.dtgResumenTransferencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgResumenTransferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResumenTransferencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idResumenAsigCartRecuperaciones,
            this.dFecha,
            this.nNroCreditos});
            this.dtgResumenTransferencia.Location = new System.Drawing.Point(12, 12);
            this.dtgResumenTransferencia.MultiSelect = false;
            this.dtgResumenTransferencia.Name = "dtgResumenTransferencia";
            this.dtgResumenTransferencia.ReadOnly = true;
            this.dtgResumenTransferencia.RowHeadersVisible = false;
            this.dtgResumenTransferencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgResumenTransferencia.Size = new System.Drawing.Size(407, 178);
            this.dtgResumenTransferencia.TabIndex = 2;
            this.dtgResumenTransferencia.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgResumenTransferencia_CellEnter);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(359, 196);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(293, 196);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 4;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // idResumenAsigCartRecuperaciones
            // 
            this.idResumenAsigCartRecuperaciones.DataPropertyName = "idResumenAsigCartRecuperaciones";
            this.idResumenAsigCartRecuperaciones.HeaderText = "idResumenAsigCartRecuperaciones";
            this.idResumenAsigCartRecuperaciones.Name = "idResumenAsigCartRecuperaciones";
            this.idResumenAsigCartRecuperaciones.ReadOnly = true;
            this.idResumenAsigCartRecuperaciones.Visible = false;
            // 
            // dFecha
            // 
            this.dFecha.DataPropertyName = "dFecha";
            this.dFecha.HeaderText = "Fecha Trasferencia";
            this.dFecha.Name = "dFecha";
            this.dFecha.ReadOnly = true;
            // 
            // nNroCreditos
            // 
            this.nNroCreditos.DataPropertyName = "nNroCreditos";
            this.nNroCreditos.HeaderText = "Nro Créditos";
            this.nNroCreditos.Name = "nNroCreditos";
            this.nNroCreditos.ReadOnly = true;
            // 
            // frmTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 278);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgResumenTransferencia);
            this.Name = "frmTransferencias";
            this.Text = "Tranferencias de carteras";
            this.Load += new System.EventHandler(this.frmTransferencias_Load);
            this.Controls.SetChildIndex(this.dtgResumenTransferencia, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumenTransferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgResumenTransferencia;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idResumenAsigCartRecuperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNroCreditos;
    }
}