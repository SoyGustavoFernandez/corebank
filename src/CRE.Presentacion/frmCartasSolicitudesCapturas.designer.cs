namespace CRE.Presentacion
{
    partial class frmCartasSolicitudesCapturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCartasSolicitudesCapturas));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCarta = new GEN.BotonesBase.btnImprimir();
            this.btnLiquidacion = new GEN.BotonesBase.btnImprimir();
            this.btnCargo = new GEN.BotonesBase.btnImprimir();
            this.btnPlanPago = new GEN.BotonesBase.btnImprimir();
            this.btnKardexPago = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgCreditosAprobados = new GEN.ControlesBase.dtgBase(this.components);
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAprobados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(461, 276);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCarta
            // 
            this.btnCarta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCarta.BackgroundImage")));
            this.btnCarta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCarta.Enabled = false;
            this.btnCarta.Location = new System.Drawing.Point(298, 276);
            this.btnCarta.Name = "btnCarta";
            this.btnCarta.Size = new System.Drawing.Size(60, 50);
            this.btnCarta.TabIndex = 1;
            this.btnCarta.Text = "&Carta";
            this.btnCarta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCarta.UseVisualStyleBackColor = true;
            this.btnCarta.Visible = false;
            this.btnCarta.Click += new System.EventHandler(this.btnCarta_Click);
            // 
            // btnLiquidacion
            // 
            this.btnLiquidacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiquidacion.BackgroundImage")));
            this.btnLiquidacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiquidacion.Enabled = false;
            this.btnLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiquidacion.Location = new System.Drawing.Point(34, 276);
            this.btnLiquidacion.Name = "btnLiquidacion";
            this.btnLiquidacion.Size = new System.Drawing.Size(60, 50);
            this.btnLiquidacion.TabIndex = 2;
            this.btnLiquidacion.Text = "&Liquidación";
            this.btnLiquidacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiquidacion.UseVisualStyleBackColor = true;
            this.btnLiquidacion.Click += new System.EventHandler(this.btnLiquidacion_Click);
            // 
            // btnCargo
            // 
            this.btnCargo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargo.BackgroundImage")));
            this.btnCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargo.Enabled = false;
            this.btnCargo.Location = new System.Drawing.Point(232, 276);
            this.btnCargo.Name = "btnCargo";
            this.btnCargo.Size = new System.Drawing.Size(60, 50);
            this.btnCargo.TabIndex = 5;
            this.btnCargo.Text = "&Cargo";
            this.btnCargo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargo.UseVisualStyleBackColor = true;
            this.btnCargo.Visible = false;
            this.btnCargo.Click += new System.EventHandler(this.btnCargo_Click);
            // 
            // btnPlanPago
            // 
            this.btnPlanPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlanPago.BackgroundImage")));
            this.btnPlanPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlanPago.Enabled = false;
            this.btnPlanPago.Location = new System.Drawing.Point(100, 276);
            this.btnPlanPago.Name = "btnPlanPago";
            this.btnPlanPago.Size = new System.Drawing.Size(60, 50);
            this.btnPlanPago.TabIndex = 3;
            this.btnPlanPago.Text = "&Plan Pago";
            this.btnPlanPago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlanPago.UseVisualStyleBackColor = true;
            this.btnPlanPago.Click += new System.EventHandler(this.btnPlanPago_Click);
            // 
            // btnKardexPago
            // 
            this.btnKardexPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKardexPago.BackgroundImage")));
            this.btnKardexPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKardexPago.Enabled = false;
            this.btnKardexPago.Location = new System.Drawing.Point(166, 276);
            this.btnKardexPago.Name = "btnKardexPago";
            this.btnKardexPago.Size = new System.Drawing.Size(60, 50);
            this.btnKardexPago.TabIndex = 4;
            this.btnKardexPago.Text = "&Kardex Pago";
            this.btnKardexPago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKardexPago.UseVisualStyleBackColor = true;
            this.btnKardexPago.Click += new System.EventHandler(this.btnKardexPago_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(397, 276);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgCreditosAprobados
            // 
            this.dtgCreditosAprobados.AllowUserToAddRows = false;
            this.dtgCreditosAprobados.AllowUserToDeleteRows = false;
            this.dtgCreditosAprobados.AllowUserToResizeColumns = false;
            this.dtgCreditosAprobados.AllowUserToResizeRows = false;
            this.dtgCreditosAprobados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditosAprobados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosAprobados.Location = new System.Drawing.Point(33, 114);
            this.dtgCreditosAprobados.MultiSelect = false;
            this.dtgCreditosAprobados.Name = "dtgCreditosAprobados";
            this.dtgCreditosAprobados.ReadOnly = true;
            this.dtgCreditosAprobados.RowHeadersVisible = false;
            this.dtgCreditosAprobados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosAprobados.Size = new System.Drawing.Size(488, 156);
            this.dtgCreditosAprobados.TabIndex = 8;
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 3);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 10;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // frmCartasSolicitudesCapturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 351);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.dtgCreditosAprobados);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnPlanPago);
            this.Controls.Add(this.btnKardexPago);
            this.Controls.Add(this.btnCargo);
            this.Controls.Add(this.btnLiquidacion);
            this.Controls.Add(this.btnCarta);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmCartasSolicitudesCapturas";
            this.Text = "Cartas de Solicitudes por capturas";
            this.Load += new System.EventHandler(this.frmCartasSolicitudesCapturas_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCarta, 0);
            this.Controls.SetChildIndex(this.btnLiquidacion, 0);
            this.Controls.SetChildIndex(this.btnCargo, 0);
            this.Controls.SetChildIndex(this.btnKardexPago, 0);
            this.Controls.SetChildIndex(this.btnPlanPago, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgCreditosAprobados, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAprobados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnCarta;
        private GEN.BotonesBase.btnImprimir btnLiquidacion;
        private GEN.BotonesBase.btnImprimir btnCargo;
        private GEN.BotonesBase.btnImprimir btnPlanPago;
        private GEN.BotonesBase.btnImprimir btnKardexPago;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgCreditosAprobados;
        private GEN.ControlesBase.ConBusCli conBusCli1;
    }
}