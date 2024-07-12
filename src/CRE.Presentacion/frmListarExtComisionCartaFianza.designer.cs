namespace CRE.Presentacion
{
    partial class frmListarExtComisionCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarExtComisionCartaFianza));
            this.dtgExtornosAprob = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idKardex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtornosAprob)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgExtornosAprob
            // 
            this.dtgExtornosAprob.AllowUserToAddRows = false;
            this.dtgExtornosAprob.AllowUserToDeleteRows = false;
            this.dtgExtornosAprob.AllowUserToResizeColumns = false;
            this.dtgExtornosAprob.AllowUserToResizeRows = false;
            this.dtgExtornosAprob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExtornosAprob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExtornosAprob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNombre,
            this.idMoneda,
            this.cMoneda,
            this.nMonto,
            this.idKardex});
            this.dtgExtornosAprob.Location = new System.Drawing.Point(12, 12);
            this.dtgExtornosAprob.MultiSelect = false;
            this.dtgExtornosAprob.Name = "dtgExtornosAprob";
            this.dtgExtornosAprob.ReadOnly = true;
            this.dtgExtornosAprob.RowHeadersVisible = false;
            this.dtgExtornosAprob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExtornosAprob.Size = new System.Drawing.Size(476, 150);
            this.dtgExtornosAprob.TabIndex = 2;
            this.dtgExtornosAprob.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExtornosAprob_CellEnter);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(430, 168);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(364, 168);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.HeaderText = "idMoneda";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.ReadOnly = true;
            this.idMoneda.Visible = false;
            // 
            // cMoneda
            // 
            this.cMoneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cMoneda.DataPropertyName = "cMoneda";
            this.cMoneda.HeaderText = "Moneda";
            this.cMoneda.Name = "cMoneda";
            this.cMoneda.ReadOnly = true;
            this.cMoneda.Width = 71;
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
            // idKardex
            // 
            this.idKardex.DataPropertyName = "idKardex";
            this.idKardex.HeaderText = "idKardex";
            this.idKardex.Name = "idKardex";
            this.idKardex.ReadOnly = true;
            this.idKardex.Visible = false;
            // 
            // frmListarExtComisionCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 249);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgExtornosAprob);
            this.Name = "frmListarExtComisionCartaFianza";
            this.Text = "Extornos Aprobados Carta Fianza";
            this.Load += new System.EventHandler(this.frmListarExtComisionCartaFianza_Load);
            this.Controls.SetChildIndex(this.dtgExtornosAprob, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtornosAprob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgExtornosAprob;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idKardex;
    }
}