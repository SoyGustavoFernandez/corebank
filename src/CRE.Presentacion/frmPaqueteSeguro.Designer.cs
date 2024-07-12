namespace CRE.Presentacion
{
    partial class frmPaqueteSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaqueteSeguro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboEstadoVigencia1 = new GEN.ControlesBase.cboEstadoVigencia(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.DatePicker();
            this.dtpFechaIncio = new GEN.ControlesBase.DatePicker();
            this.cboDetalleGasto1 = new GEN.ControlesBase.cboDetalleGasto(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtPlanPaqueteSeguro = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.dtgListaPaqueteSeguro = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPaqueteSeguro)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboEstadoVigencia1);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaIncio);
            this.groupBox1.Controls.Add(this.cboDetalleGasto1);
            this.groupBox1.Controls.Add(this.btnBusqueda1);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.Controls.Add(this.txtPlanPaqueteSeguro);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // cboEstadoVigencia1
            // 
            this.cboEstadoVigencia1.FormattingEnabled = true;
            this.cboEstadoVigencia1.Location = new System.Drawing.Point(443, 88);
            this.cboEstadoVigencia1.Name = "cboEstadoVigencia1";
            this.cboEstadoVigencia1.Size = new System.Drawing.Size(134, 21);
            this.cboEstadoVigencia1.TabIndex = 15;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(379, 59);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(117, 20);
            this.dtpFechaFin.TabIndex = 14;
            this.dtpFechaFin.Value = new System.DateTime(2023, 6, 8, 18, 13, 19, 517);
            // 
            // dtpFechaIncio
            // 
            this.dtpFechaIncio.Location = new System.Drawing.Point(133, 59);
            this.dtpFechaIncio.Name = "dtpFechaIncio";
            this.dtpFechaIncio.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaIncio.TabIndex = 13;
            this.dtpFechaIncio.Value = new System.DateTime(2023, 6, 8, 18, 12, 52, 322);
            // 
            // cboDetalleGasto1
            // 
            this.cboDetalleGasto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetalleGasto1.FormattingEnabled = true;
            this.cboDetalleGasto1.Location = new System.Drawing.Point(133, 88);
            this.cboDetalleGasto1.Name = "cboDetalleGasto1";
            this.cboDetalleGasto1.Size = new System.Drawing.Size(244, 21);
            this.cboDetalleGasto1.TabIndex = 11;
            this.cboDetalleGasto1.SelectedIndexChanged += new System.EventHandler(this.cboDetalleGasto1_SelectedIndexChanged);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(512, 24);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 10;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(298, 63);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(39, 13);
            this.lblBase5.TabIndex = 8;
            this.lblBase5.Text = "Hasta";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(386, 92);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(51, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Estados";
            // 
            // txtPlanPaqueteSeguro
            // 
            this.txtPlanPaqueteSeguro.Location = new System.Drawing.Point(133, 25);
            this.txtPlanPaqueteSeguro.Name = "txtPlanPaqueteSeguro";
            this.txtPlanPaqueteSeguro.Size = new System.Drawing.Size(363, 20);
            this.txtPlanPaqueteSeguro.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 92);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(112, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Seguro obligatorio";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 63);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(81, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fec. Registro";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 29);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nombre Plan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMiniAgregar1);
            this.groupBox2.Controls.Add(this.btnMiniEditar1);
            this.groupBox2.Controls.Add(this.dtgListaPaqueteSeguro);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 221);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(553, 54);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 2;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.Location = new System.Drawing.Point(553, 19);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 1;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = true;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditar1_Click);
            // 
            // dtgListaPaqueteSeguro
            // 
            this.dtgListaPaqueteSeguro.AllowUserToAddRows = false;
            this.dtgListaPaqueteSeguro.AllowUserToDeleteRows = false;
            this.dtgListaPaqueteSeguro.AllowUserToResizeColumns = false;
            this.dtgListaPaqueteSeguro.AllowUserToResizeRows = false;
            this.dtgListaPaqueteSeguro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaPaqueteSeguro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPaqueteSeguro.Location = new System.Drawing.Point(6, 19);
            this.dtgListaPaqueteSeguro.MultiSelect = false;
            this.dtgListaPaqueteSeguro.Name = "dtgListaPaqueteSeguro";
            this.dtgListaPaqueteSeguro.ReadOnly = true;
            this.dtgListaPaqueteSeguro.RowHeadersVisible = false;
            this.dtgListaPaqueteSeguro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPaqueteSeguro.Size = new System.Drawing.Size(541, 196);
            this.dtgListaPaqueteSeguro.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(541, 378);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmPaqueteSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 458);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPaqueteSeguro";
            this.Text = "Planes de Seguro";
            this.Load += new System.EventHandler(this.frmPaqueteSeguro_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPaqueteSeguro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtPlanPaqueteSeguro;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgListaPaqueteSeguro;
        private GEN.ControlesBase.cboDetalleGasto cboDetalleGasto1;
        private GEN.ControlesBase.DatePicker dtpFechaFin;
        private GEN.ControlesBase.DatePicker dtpFechaIncio;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.ControlesBase.cboEstadoVigencia cboEstadoVigencia1;
    }
}