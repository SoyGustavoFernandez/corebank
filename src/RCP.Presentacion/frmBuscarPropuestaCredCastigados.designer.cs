namespace RCP.Presentacion
{
    partial class frmBuscarPropuestaCredCastigados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarPropuestaCredCastigados));
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgListaCredCast = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnDetalle1 = new GEN.BotonesBase.btnDetalle();
            this.txtCodigo = new GEN.ControlesBase.txtNumRea(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaCredCast)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(346, 6);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 11;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 15);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(95, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Buscar Código:";
            // 
            // dtgListaCredCast
            // 
            this.dtgListaCredCast.AllowUserToAddRows = false;
            this.dtgListaCredCast.AllowUserToDeleteRows = false;
            this.dtgListaCredCast.AllowUserToResizeColumns = false;
            this.dtgListaCredCast.AllowUserToResizeRows = false;
            this.dtgListaCredCast.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgListaCredCast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaCredCast.Location = new System.Drawing.Point(12, 40);
            this.dtgListaCredCast.MultiSelect = false;
            this.dtgListaCredCast.Name = "dtgListaCredCast";
            this.dtgListaCredCast.ReadOnly = true;
            this.dtgListaCredCast.RowHeadersVisible = false;
            this.dtgListaCredCast.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaCredCast.Size = new System.Drawing.Size(573, 207);
            this.dtgListaCredCast.TabIndex = 12;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(527, 253);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnDetalle1
            // 
            this.btnDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle1.BackgroundImage")));
            this.btnDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle1.Location = new System.Drawing.Point(461, 253);
            this.btnDetalle1.Name = "btnDetalle1";
            this.btnDetalle1.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle1.TabIndex = 15;
            this.btnDetalle1.Text = "&Detallar";
            this.btnDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle1.texto = "&Detallar";
            this.btnDetalle1.UseVisualStyleBackColor = true;
            this.btnDetalle1.Click += new System.EventHandler(this.btnDetalle1_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatoDecimal = false;
            this.txtCodigo.Location = new System.Drawing.Point(110, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCodigo.nNumDecimales = 4;
            this.txtCodigo.nvalor = 0D;
            this.txtCodigo.Size = new System.Drawing.Size(214, 20);
            this.txtCodigo.TabIndex = 16;
            // 
            // frmBuscarPropuestaCredCastigados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 328);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnDetalle1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnMiniBusq1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.dtgListaCredCast);
            this.Name = "frmBuscarPropuestaCredCastigados";
            this.Text = "Lista de Créditos Para Castigar";
            this.Controls.SetChildIndex(this.dtgListaCredCast, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnDetalle1, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaCredCast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtgBase dtgListaCredCast;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnDetalle btnDetalle1;
        private GEN.ControlesBase.txtNumRea txtCodigo;
    }
}