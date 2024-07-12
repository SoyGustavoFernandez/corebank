namespace CRE.Presentacion
{
    partial class frmReporteSeguroDesgravamen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteSeguroDesgravamen));
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboTipoPoliza = new GEN.ControlesBase.cboTipoPolizaSeguro(this.components);
            this.btnImprimirStock = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimirNueva = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(71, 19);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(312, 21);
            this.cboZona1.TabIndex = 43;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 44;
            this.lblBase1.Text = "Región:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 45;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(20, 79);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 46;
            this.lblBase3.Text = "Poliza:";
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(71, 49);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(312, 21);
            this.cboAgencias1.TabIndex = 48;
            // 
            // cboTipoPoliza
            // 
            this.cboTipoPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPoliza.FormattingEnabled = true;
            this.cboTipoPoliza.Location = new System.Drawing.Point(71, 76);
            this.cboTipoPoliza.Name = "cboTipoPoliza";
            this.cboTipoPoliza.Size = new System.Drawing.Size(131, 21);
            this.cboTipoPoliza.TabIndex = 49;
            // 
            // btnImprimirStock
            // 
            this.btnImprimirStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirStock.BackgroundImage")));
            this.btnImprimirStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirStock.Location = new System.Drawing.Point(269, 122);
            this.btnImprimirStock.Name = "btnImprimirStock";
            this.btnImprimirStock.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirStock.TabIndex = 50;
            this.btnImprimirStock.Text = "Stock";
            this.btnImprimirStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirStock.UseVisualStyleBackColor = true;
            this.btnImprimirStock.Click += new System.EventHandler(this.btnImprimirStock_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(335, 122);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 51;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(208, 79);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 53;
            this.lblBase4.Text = "Fecha:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpFecha);
            this.grbBase1.Controls.Add(this.cboZona1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboAgencias1);
            this.grbBase1.Controls.Add(this.cboTipoPoliza);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(399, 104);
            this.grbBase1.TabIndex = 55;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(257, 77);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(126, 20);
            this.dtpFecha.TabIndex = 54;
            // 
            // btnImprimirNueva
            // 
            this.btnImprimirNueva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirNueva.BackgroundImage")));
            this.btnImprimirNueva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirNueva.Location = new System.Drawing.Point(205, 122);
            this.btnImprimirNueva.Name = "btnImprimirNueva";
            this.btnImprimirNueva.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirNueva.TabIndex = 56;
            this.btnImprimirNueva.Text = "Nueva";
            this.btnImprimirNueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirNueva.UseVisualStyleBackColor = true;
            this.btnImprimirNueva.Click += new System.EventHandler(this.btnImprimirNueva_Click);
            // 
            // frmReporteSeguroDesgravamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 198);
            this.Controls.Add(this.btnImprimirNueva);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimirStock);
            this.Name = "frmReporteSeguroDesgravamen";
            this.Text = "Reporte de Póliza de Seguro de Desgravamen";
            this.Load += new System.EventHandler(this.frmReporteSeguroDesgravamen_Load);
            this.Controls.SetChildIndex(this.btnImprimirStock, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimirNueva, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.cboTipoPolizaSeguro cboTipoPoliza;
        private GEN.BotonesBase.btnImprimir btnImprimirStock;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.BotonesBase.btnImprimir btnImprimirNueva;
    }
}