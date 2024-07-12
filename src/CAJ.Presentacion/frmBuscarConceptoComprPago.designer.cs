namespace CAJ.Presentacion
{
    partial class frmBuscarConceptoComprPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarConceptoComprPago));
            this.dtgSubConceptos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblConcepto = new GEN.ControlesBase.lblBase();
            this.txtBusCom = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSubConceptos
            // 
            this.dtgSubConceptos.AllowUserToAddRows = false;
            this.dtgSubConceptos.AllowUserToDeleteRows = false;
            this.dtgSubConceptos.AllowUserToResizeColumns = false;
            this.dtgSubConceptos.AllowUserToResizeRows = false;
            this.dtgSubConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgSubConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSubConceptos.Location = new System.Drawing.Point(12, 61);
            this.dtgSubConceptos.MultiSelect = false;
            this.dtgSubConceptos.Name = "dtgSubConceptos";
            this.dtgSubConceptos.ReadOnly = true;
            this.dtgSubConceptos.RowHeadersVisible = false;
            this.dtgSubConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSubConceptos.Size = new System.Drawing.Size(427, 155);
            this.dtgSubConceptos.TabIndex = 2;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblConcepto.ForeColor = System.Drawing.Color.Navy;
            this.lblConcepto.Location = new System.Drawing.Point(9, 25);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(66, 13);
            this.lblConcepto.TabIndex = 3;
            this.lblConcepto.Text = "Concepto:";
            // 
            // txtBusCom
            // 
            this.txtBusCom.Location = new System.Drawing.Point(81, 22);
            this.txtBusCom.Name = "txtBusCom";
            this.txtBusCom.Size = new System.Drawing.Size(289, 20);
            this.txtBusCom.TabIndex = 7;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(379, 5);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 8;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(379, 222);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(313, 222);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 5;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmBuscarConceptoComprPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 295);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.txtBusCom);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblConcepto);
            this.Controls.Add(this.dtgSubConceptos);
            this.Name = "frmBuscarConceptoComprPago";
            this.Text = "Concepto de Comprobante";
            this.Load += new System.EventHandler(this.frmBuscarConceptoComprPago_Load);
            this.Controls.SetChildIndex(this.dtgSubConceptos, 0);
            this.Controls.SetChildIndex(this.lblConcepto, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtBusCom, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgSubConceptos;
        private GEN.ControlesBase.lblBase lblConcepto;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtBase txtBusCom;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
    }
}