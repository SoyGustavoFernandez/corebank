namespace CLI.Presentacion
{
    partial class FrmRptAporteFondoMort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRptAporteFondoMort));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tbpAporte = new System.Windows.Forms.TabPage();
            this.dtgAportesKardx = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgAportes = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.tbpFondoMor = new System.Windows.Forms.TabPage();
            this.dtgDetalleFondoKardx = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetalleFondo = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            this.tbcBase1.SuspendLayout();
            this.tbpAporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAportesKardx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAportes)).BeginInit();
            this.tbpFondoMor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleFondoKardx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 8);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 81);
            this.conBusCli1.TabIndex = 2;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tbpAporte);
            this.tbcBase1.Controls.Add(this.tbpFondoMor);
            this.tbcBase1.Location = new System.Drawing.Point(7, 99);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(841, 309);
            this.tbcBase1.TabIndex = 3;
            // 
            // tbpAporte
            // 
            this.tbpAporte.Controls.Add(this.dtgAportesKardx);
            this.tbpAporte.Controls.Add(this.dtgAportes);
            this.tbpAporte.Controls.Add(this.lblBase2);
            this.tbpAporte.Controls.Add(this.lblBase1);
            this.tbpAporte.Location = new System.Drawing.Point(4, 22);
            this.tbpAporte.Name = "tbpAporte";
            this.tbpAporte.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAporte.Size = new System.Drawing.Size(833, 283);
            this.tbpAporte.TabIndex = 0;
            this.tbpAporte.Text = "Aportes";
            this.tbpAporte.UseVisualStyleBackColor = true;
            // 
            // dtgAportesKardx
            // 
            this.dtgAportesKardx.AllowUserToAddRows = false;
            this.dtgAportesKardx.AllowUserToDeleteRows = false;
            this.dtgAportesKardx.AllowUserToResizeColumns = false;
            this.dtgAportesKardx.AllowUserToResizeRows = false;
            this.dtgAportesKardx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAportesKardx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAportesKardx.Location = new System.Drawing.Point(418, 20);
            this.dtgAportesKardx.MultiSelect = false;
            this.dtgAportesKardx.Name = "dtgAportesKardx";
            this.dtgAportesKardx.ReadOnly = true;
            this.dtgAportesKardx.RowHeadersVisible = false;
            this.dtgAportesKardx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAportesKardx.Size = new System.Drawing.Size(408, 260);
            this.dtgAportesKardx.TabIndex = 2;
            // 
            // dtgAportes
            // 
            this.dtgAportes.AllowUserToAddRows = false;
            this.dtgAportes.AllowUserToDeleteRows = false;
            this.dtgAportes.AllowUserToResizeColumns = false;
            this.dtgAportes.AllowUserToResizeRows = false;
            this.dtgAportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAportes.Location = new System.Drawing.Point(4, 20);
            this.dtgAportes.MultiSelect = false;
            this.dtgAportes.Name = "dtgAportes";
            this.dtgAportes.ReadOnly = true;
            this.dtgAportes.RowHeadersVisible = false;
            this.dtgAportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAportes.Size = new System.Drawing.Size(408, 260);
            this.dtgAportes.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(579, 4);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Kardex de Pago";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(160, 4);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(87, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Plan de Pagos";
            // 
            // tbpFondoMor
            // 
            this.tbpFondoMor.Controls.Add(this.dtgDetalleFondoKardx);
            this.tbpFondoMor.Controls.Add(this.dtgDetalleFondo);
            this.tbpFondoMor.Controls.Add(this.lblBase3);
            this.tbpFondoMor.Controls.Add(this.lblBase4);
            this.tbpFondoMor.Location = new System.Drawing.Point(4, 22);
            this.tbpFondoMor.Name = "tbpFondoMor";
            this.tbpFondoMor.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFondoMor.Size = new System.Drawing.Size(833, 283);
            this.tbpFondoMor.TabIndex = 1;
            this.tbpFondoMor.Text = "Fondo Mortuorio";
            this.tbpFondoMor.UseVisualStyleBackColor = true;
            // 
            // dtgDetalleFondoKardx
            // 
            this.dtgDetalleFondoKardx.AllowUserToAddRows = false;
            this.dtgDetalleFondoKardx.AllowUserToDeleteRows = false;
            this.dtgDetalleFondoKardx.AllowUserToResizeColumns = false;
            this.dtgDetalleFondoKardx.AllowUserToResizeRows = false;
            this.dtgDetalleFondoKardx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleFondoKardx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleFondoKardx.Location = new System.Drawing.Point(418, 20);
            this.dtgDetalleFondoKardx.MultiSelect = false;
            this.dtgDetalleFondoKardx.Name = "dtgDetalleFondoKardx";
            this.dtgDetalleFondoKardx.ReadOnly = true;
            this.dtgDetalleFondoKardx.RowHeadersVisible = false;
            this.dtgDetalleFondoKardx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleFondoKardx.Size = new System.Drawing.Size(408, 260);
            this.dtgDetalleFondoKardx.TabIndex = 6;
            // 
            // dtgDetalleFondo
            // 
            this.dtgDetalleFondo.AllowUserToAddRows = false;
            this.dtgDetalleFondo.AllowUserToDeleteRows = false;
            this.dtgDetalleFondo.AllowUserToResizeColumns = false;
            this.dtgDetalleFondo.AllowUserToResizeRows = false;
            this.dtgDetalleFondo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleFondo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleFondo.Location = new System.Drawing.Point(4, 20);
            this.dtgDetalleFondo.MultiSelect = false;
            this.dtgDetalleFondo.Name = "dtgDetalleFondo";
            this.dtgDetalleFondo.ReadOnly = true;
            this.dtgDetalleFondo.RowHeadersVisible = false;
            this.dtgDetalleFondo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleFondo.Size = new System.Drawing.Size(408, 260);
            this.dtgDetalleFondo.TabIndex = 5;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(579, 4);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(98, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Kardex de Pago";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(160, 4);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(87, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Plan de Pagos";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(788, 409);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(7, 410);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "Aportes";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(73, 410);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 6;
            this.btnImprimir2.Text = "Fondo";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // FrmRptAporteFondoMort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 484);
            this.Controls.Add(this.btnImprimir2);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.conBusCli1);
            this.Name = "FrmRptAporteFondoMort";
            this.Text = "Reporte de Aporte y Fondo Mortuorio por Socio";
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir2, 0);
            this.tbcBase1.ResumeLayout(false);
            this.tbpAporte.ResumeLayout(false);
            this.tbpAporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAportesKardx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAportes)).EndInit();
            this.tbpFondoMor.ResumeLayout(false);
            this.tbpFondoMor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleFondoKardx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleFondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tbpFondoMor;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.TabPage tbpAporte;
        private GEN.ControlesBase.dtgBase dtgAportesKardx;
        private GEN.ControlesBase.dtgBase dtgAportes;
        private GEN.ControlesBase.dtgBase dtgDetalleFondoKardx;
        private GEN.ControlesBase.dtgBase dtgDetalleFondo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnImprimir btnImprimir2;
    }
}