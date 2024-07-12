namespace CRE.Presentacion
{
    partial class frmGeneraDsctoPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneraDsctoPlanilla));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGenerar = new GEN.BotonesBase.btnGenerar();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.cboConvenio = new GEN.ControlesBase.cboConvenio(this.components);
            this.dtgDetalleDscto = new GEN.ControlesBase.dtgBase(this.components);
            this.dtpFechaVen = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleDscto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(606, 327);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar.Location = new System.Drawing.Point(540, 327);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Gene&rar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(606, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboConvenio
            // 
            this.cboConvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvenio.FormattingEnabled = true;
            this.cboConvenio.Location = new System.Drawing.Point(132, 12);
            this.cboConvenio.Name = "cboConvenio";
            this.cboConvenio.Size = new System.Drawing.Size(434, 21);
            this.cboConvenio.TabIndex = 5;
            this.cboConvenio.SelectedIndexChanged += new System.EventHandler(this.cboConvenio_SelectedIndexChanged);
            // 
            // dtgDetalleDscto
            // 
            this.dtgDetalleDscto.AllowUserToAddRows = false;
            this.dtgDetalleDscto.AllowUserToDeleteRows = false;
            this.dtgDetalleDscto.AllowUserToResizeColumns = false;
            this.dtgDetalleDscto.AllowUserToResizeRows = false;
            this.dtgDetalleDscto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleDscto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleDscto.Location = new System.Drawing.Point(12, 81);
            this.dtgDetalleDscto.MultiSelect = false;
            this.dtgDetalleDscto.Name = "dtgDetalleDscto";
            this.dtgDetalleDscto.ReadOnly = true;
            this.dtgDetalleDscto.RowHeadersVisible = false;
            this.dtgDetalleDscto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleDscto.Size = new System.Drawing.Size(654, 198);
            this.dtgDetalleDscto.TabIndex = 6;
            this.dtgDetalleDscto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleDscto_CellContentClick);
            this.dtgDetalleDscto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleDscto_CellEndEdit);
            this.dtgDetalleDscto.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgDetalleDscto_EditingControlShowing);
            // 
            // dtpFechaVen
            // 
            this.dtpFechaVen.Location = new System.Drawing.Point(132, 39);
            this.dtpFechaVen.Name = "dtpFechaVen";
            this.dtpFechaVen.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaVen.TabIndex = 7;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.FormatoDecimal = false;
            this.txtTotal.Location = new System.Drawing.Point(556, 285);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 2;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.Size = new System.Drawing.Size(71, 20);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(66, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Convenio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(118, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Fecha Vencimiento:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(520, 288);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(39, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Total:";
            // 
            // frmGeneraDsctoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 420);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaVen);
            this.Controls.Add(this.dtgDetalleDscto);
            this.Controls.Add(this.cboConvenio);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmGeneraDsctoPlanilla";
            this.Text = "Genera Archivo Descuento Planilla";
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.cboConvenio, 0);
            this.Controls.SetChildIndex(this.dtgDetalleDscto, 0);
            this.Controls.SetChildIndex(this.dtpFechaVen, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleDscto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGenerar btnGenerar;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.cboConvenio cboConvenio;
        private GEN.ControlesBase.dtgBase dtgDetalleDscto;
        private GEN.ControlesBase.dtpCorto dtpFechaVen;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}