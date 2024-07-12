namespace SPL.Presentacion
{
    partial class frmRptOperacionesPorRangos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOperacionesPorRangos));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.txtnMontoDolares = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpdFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpdFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgClientesRango = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetalleOperaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtnTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesRango)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleOperaciones)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnBusqueda1);
            this.grbBase1.Controls.Add(this.txtnMontoDolares);
            this.grbBase1.Controls.Add(this.dtpdFechaFin);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpdFechaInicio);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(6, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(656, 73);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(590, 11);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 5;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // txtnMontoDolares
            // 
            this.txtnMontoDolares.FormatoDecimal = false;
            this.txtnMontoDolares.Location = new System.Drawing.Point(130, 45);
            this.txtnMontoDolares.Name = "txtnMontoDolares";
            this.txtnMontoDolares.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtnMontoDolares.nNumDecimales = 4;
            this.txtnMontoDolares.nvalor = 0D;
            this.txtnMontoDolares.Size = new System.Drawing.Size(158, 20);
            this.txtnMontoDolares.TabIndex = 3;
            // 
            // dtpdFechaFin
            // 
            this.dtpdFechaFin.Location = new System.Drawing.Point(365, 19);
            this.dtpdFechaFin.Name = "dtpdFechaFin";
            this.dtpdFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpdFechaFin.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(294, 25);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(63, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Fecha fin:";
            // 
            // dtpdFechaInicio
            // 
            this.dtpdFechaInicio.Location = new System.Drawing.Point(88, 19);
            this.dtpdFechaInicio.Name = "dtpdFechaInicio";
            this.dtpdFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpdFechaInicio.TabIndex = 4;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 48);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(125, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Monto en dolares $.:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Fecha inicio:";
            // 
            // dtgClientesRango
            // 
            this.dtgClientesRango.AllowUserToAddRows = false;
            this.dtgClientesRango.AllowUserToDeleteRows = false;
            this.dtgClientesRango.AllowUserToResizeColumns = false;
            this.dtgClientesRango.AllowUserToResizeRows = false;
            this.dtgClientesRango.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgClientesRango.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesRango.Location = new System.Drawing.Point(6, 79);
            this.dtgClientesRango.MultiSelect = false;
            this.dtgClientesRango.Name = "dtgClientesRango";
            this.dtgClientesRango.ReadOnly = true;
            this.dtgClientesRango.RowHeadersVisible = false;
            this.dtgClientesRango.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesRango.Size = new System.Drawing.Size(590, 172);
            this.dtgClientesRango.TabIndex = 3;
            this.dtgClientesRango.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgClientesRango_CellEnter);
            // 
            // dtgDetalleOperaciones
            // 
            this.dtgDetalleOperaciones.AllowUserToAddRows = false;
            this.dtgDetalleOperaciones.AllowUserToDeleteRows = false;
            this.dtgDetalleOperaciones.AllowUserToResizeColumns = false;
            this.dtgDetalleOperaciones.AllowUserToResizeRows = false;
            this.dtgDetalleOperaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleOperaciones.Location = new System.Drawing.Point(9, 17);
            this.dtgDetalleOperaciones.MultiSelect = false;
            this.dtgDetalleOperaciones.Name = "dtgDetalleOperaciones";
            this.dtgDetalleOperaciones.ReadOnly = true;
            this.dtgDetalleOperaciones.RowHeadersVisible = false;
            this.dtgDetalleOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleOperaciones.Size = new System.Drawing.Size(641, 189);
            this.dtgDetalleOperaciones.TabIndex = 3;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(602, 469);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(536, 469);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 6;
            this.btnImprimir1.Text = "Detalle";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(602, 79);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 7;
            this.btnImprimir2.Text = "Imprimir";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgDetalleOperaciones);
            this.grbBase2.Location = new System.Drawing.Point(6, 254);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(656, 214);
            this.grbBase2.TabIndex = 8;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Detalle de operaciones";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 471);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(154, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Monto total en dolares $.:";
            // 
            // txtnTotal
            // 
            this.txtnTotal.FormatoDecimal = false;
            this.txtnTotal.Location = new System.Drawing.Point(167, 469);
            this.txtnTotal.Name = "txtnTotal";
            this.txtnTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtnTotal.nNumDecimales = 4;
            this.txtnTotal.nvalor = 0D;
            this.txtnTotal.ReadOnly = true;
            this.txtnTotal.Size = new System.Drawing.Size(158, 20);
            this.txtnTotal.TabIndex = 3;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(470, 469);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmRptOperacionesPorRangos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 547);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.txtnTotal);
            this.Controls.Add(this.btnImprimir2);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgClientesRango);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptOperacionesPorRangos";
            this.Text = "Reporte de operaciones por rangos mayores a $. 7000";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgClientesRango, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir2, 0);
            this.Controls.SetChildIndex(this.txtnTotal, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesRango)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleOperaciones)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtNumRea txtnMontoDolares;
        private GEN.ControlesBase.dtpCorto dtpdFechaFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpdFechaInicio;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgClientesRango;
        private GEN.ControlesBase.dtgBase dtgDetalleOperaciones;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnImprimir btnImprimir2;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtnTotal;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}