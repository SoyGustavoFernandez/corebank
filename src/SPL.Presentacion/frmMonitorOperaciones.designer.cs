namespace SPL.Presentacion
{
    partial class frmMonitorOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitorOperaciones));
            this.dtgLista = new GEN.ControlesBase.dtgBase(this.components);
            this.cboOperaciones = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboPerfiles = new GEN.ControlesBase.cboBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.pnlRangoFecha = new System.Windows.Forms.Panel();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpHasta = new GEN.ControlesBase.DatePicker();
            this.dtpDesde = new GEN.ControlesBase.DatePicker();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).BeginInit();
            this.pnlRangoFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgLista
            // 
            this.dtgLista.AllowUserToAddRows = false;
            this.dtgLista.AllowUserToDeleteRows = false;
            this.dtgLista.AllowUserToResizeColumns = false;
            this.dtgLista.AllowUserToResizeRows = false;
            this.dtgLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLista.Location = new System.Drawing.Point(7, 141);
            this.dtgLista.MultiSelect = false;
            this.dtgLista.Name = "dtgLista";
            this.dtgLista.ReadOnly = true;
            this.dtgLista.RowHeadersVisible = false;
            this.dtgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLista.Size = new System.Drawing.Size(770, 339);
            this.dtgLista.TabIndex = 3;
            // 
            // cboOperaciones
            // 
            this.cboOperaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperaciones.FormattingEnabled = true;
            this.cboOperaciones.Location = new System.Drawing.Point(100, 39);
            this.cboOperaciones.Name = "cboOperaciones";
            this.cboOperaciones.Size = new System.Drawing.Size(121, 21);
            this.cboOperaciones.TabIndex = 6;
            this.cboOperaciones.SelectedIndexChanged += new System.EventHandler(this.cboOperaciones_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(40, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Ver por:";
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(646, 487);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 26;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(712, 486);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 23;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Perfil cliente:";
            // 
            // cboPerfiles
            // 
            this.cboPerfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfiles.FormattingEnabled = true;
            this.cboPerfiles.Location = new System.Drawing.Point(100, 12);
            this.cboPerfiles.Name = "cboPerfiles";
            this.cboPerfiles.Size = new System.Drawing.Size(150, 21);
            this.cboPerfiles.TabIndex = 4;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(580, 487);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 27;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusUbig1.Location = new System.Drawing.Point(282, 1);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 134);
            this.conBusUbig1.TabIndex = 28;
            // 
            // pnlRangoFecha
            // 
            this.pnlRangoFecha.Controls.Add(this.lblBase4);
            this.pnlRangoFecha.Controls.Add(this.lblBase3);
            this.pnlRangoFecha.Controls.Add(this.dtpHasta);
            this.pnlRangoFecha.Controls.Add(this.dtpDesde);
            this.pnlRangoFecha.Location = new System.Drawing.Point(282, 1);
            this.pnlRangoFecha.Name = "pnlRangoFecha";
            this.pnlRangoFecha.Size = new System.Drawing.Size(171, 69);
            this.pnlRangoFecha.TabIndex = 29;
            this.pnlRangoFecha.Visible = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(7, 41);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 30;
            this.lblBase4.Text = "Hasta:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 14);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(48, 13);
            this.lblBase3.TabIndex = 30;
            this.lblBase3.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(57, 38);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(102, 20);
            this.dtpHasta.TabIndex = 1;
            this.dtpHasta.Value = new System.DateTime(2016, 2, 11, 12, 26, 12, 753);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(57, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(102, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.Value = new System.DateTime(2016, 2, 11, 12, 26, 12, 753);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(520, 12);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 30;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // frmMonitorOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.pnlRangoFecha);
            this.Controls.Add(this.conBusUbig1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.cboOperaciones);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboPerfiles);
            this.Controls.Add(this.dtgLista);
            this.Name = "frmMonitorOperaciones";
            this.Text = "Monitor por perfil de clientes";
            this.Load += new System.EventHandler(this.frmMonitorSeguimientoSPLAFT_Load);
            this.Controls.SetChildIndex(this.dtgLista, 0);
            this.Controls.SetChildIndex(this.cboPerfiles, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboOperaciones, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.conBusUbig1, 0);
            this.Controls.SetChildIndex(this.pnlRangoFecha, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).EndInit();
            this.pnlRangoFecha.ResumeLayout(false);
            this.pnlRangoFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgLista;
        private GEN.ControlesBase.cboBase cboOperaciones;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboPerfiles;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private System.Windows.Forms.Panel pnlRangoFecha;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.DatePicker dtpHasta;
        private GEN.ControlesBase.DatePicker dtpDesde;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
    }
}