namespace CAJ.Presentacion
{
    partial class frmRptCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCajaChica));
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtFecFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtFecInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.cboEstadoComprobante1 = new GEN.ControlesBase.cboEstadoComprobante(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgListaNroCajChicas = new GEN.ControlesBase.dtgBase(this.components);
            this.cboCajChica = new GEN.ControlesBase.cboBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaNroCajChicas)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 43);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(124, 13);
            this.lblBase7.TabIndex = 131;
            this.lblBase7.Text = "Nombre Caja Chica:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 129;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(136, 13);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(195, 21);
            this.cboAgencias.TabIndex = 128;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.grbBase1);
            this.grbBase3.Controls.Add(this.btnBusqueda1);
            this.grbBase3.Controls.Add(this.cboEstadoComprobante1);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.dtgListaNroCajChicas);
            this.grbBase3.Controls.Add(this.cboCajChica);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.cboAgencias);
            this.grbBase3.Location = new System.Drawing.Point(3, 1);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(771, 280);
            this.grbBase3.TabIndex = 132;
            this.grbBase3.TabStop = false;
            // 
            // dtFecFinal
            // 
            this.dtFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecFinal.Location = new System.Drawing.Point(62, 39);
            this.dtFecFinal.Name = "dtFecFinal";
            this.dtFecFinal.Size = new System.Drawing.Size(114, 20);
            this.dtFecFinal.TabIndex = 139;
            // 
            // dtFecInicio
            // 
            this.dtFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecInicio.Location = new System.Drawing.Point(62, 15);
            this.dtFecInicio.Name = "dtFecInicio";
            this.dtFecInicio.Size = new System.Drawing.Size(114, 20);
            this.dtFecInicio.TabIndex = 138;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 43);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(27, 13);
            this.lblBase3.TabIndex = 137;
            this.lblBase3.Text = "Al :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 136;
            this.lblBase2.Text = "Desde:";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(644, 42);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 135;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // cboEstadoComprobante1
            // 
            this.cboEstadoComprobante1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoComprobante1.FormattingEnabled = true;
            this.cboEstadoComprobante1.Location = new System.Drawing.Point(136, 66);
            this.cboEstadoComprobante1.Name = "cboEstadoComprobante1";
            this.cboEstadoComprobante1.Size = new System.Drawing.Size(195, 21);
            this.cboEstadoComprobante1.TabIndex = 134;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 69);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 133;
            this.lblBase1.Text = "Estado:";
            // 
            // dtgListaNroCajChicas
            // 
            this.dtgListaNroCajChicas.AllowUserToAddRows = false;
            this.dtgListaNroCajChicas.AllowUserToDeleteRows = false;
            this.dtgListaNroCajChicas.AllowUserToResizeColumns = false;
            this.dtgListaNroCajChicas.AllowUserToResizeRows = false;
            this.dtgListaNroCajChicas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaNroCajChicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaNroCajChicas.Location = new System.Drawing.Point(6, 109);
            this.dtgListaNroCajChicas.MultiSelect = false;
            this.dtgListaNroCajChicas.Name = "dtgListaNroCajChicas";
            this.dtgListaNroCajChicas.ReadOnly = true;
            this.dtgListaNroCajChicas.RowHeadersVisible = false;
            this.dtgListaNroCajChicas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaNroCajChicas.Size = new System.Drawing.Size(758, 165);
            this.dtgListaNroCajChicas.TabIndex = 132;
            // 
            // cboCajChica
            // 
            this.cboCajChica.FormattingEnabled = true;
            this.cboCajChica.Location = new System.Drawing.Point(136, 39);
            this.cboCajChica.Name = "cboCajChica";
            this.cboCajChica.Size = new System.Drawing.Size(289, 21);
            this.cboCajChica.TabIndex = 98;
            this.cboCajChica.SelectedIndexChanged += new System.EventHandler(this.cboCajChica_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(714, 287);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 114;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(651, 287);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 113;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtFecInicio);
            this.grbBase1.Controls.Add(this.dtFecFinal);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(438, 24);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(200, 67);
            this.grbBase1.TabIndex = 140;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Inicio";
            // 
            // frmRptCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 362);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmRptCajaChica";
            this.Text = "Reporte Caja Chica";
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaNroCajChicas)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboBase cboCajChica;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.dtgBase dtgListaNroCajChicas;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboEstadoComprobante cboEstadoComprobante1;
        private GEN.ControlesBase.dtpCorto dtFecFinal;
        private GEN.ControlesBase.dtpCorto dtFecInicio;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}