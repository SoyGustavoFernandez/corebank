namespace GEN.ControlesBase
{
    partial class ConBusRep
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConBusRep));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgReports = new GEN.ControlesBase.dtgBase(this.components);
            this.R_IDReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_IDModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_Reporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_lActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtReporte = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnConsultar1 = new GEN.BotonesBase.btnConsultar();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReports)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.dtgReports);
            this.grbBase2.Location = new System.Drawing.Point(13, 71);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(262, 158);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Resultados";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(136, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Seleccione el Reporte:";
            // 
            // dtgReports
            // 
            this.dtgReports.AllowUserToAddRows = false;
            this.dtgReports.AllowUserToDeleteRows = false;
            this.dtgReports.AllowUserToResizeColumns = false;
            this.dtgReports.AllowUserToResizeRows = false;
            this.dtgReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.R_IDReporte,
            this.R_IDModulo,
            this.R_Reporte,
            this.R_Descripcion,
            this.R_Ruta,
            this.R_lActivo});
            this.dtgReports.Location = new System.Drawing.Point(14, 32);
            this.dtgReports.MultiSelect = false;
            this.dtgReports.Name = "dtgReports";
            this.dtgReports.ReadOnly = true;
            this.dtgReports.RowHeadersVisible = false;
            this.dtgReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReports.Size = new System.Drawing.Size(235, 112);
            this.dtgReports.TabIndex = 0;
            // 
            // R_IDReporte
            // 
            this.R_IDReporte.DataPropertyName = "IDReporte";
            this.R_IDReporte.HeaderText = "IDReporte";
            this.R_IDReporte.Name = "R_IDReporte";
            this.R_IDReporte.ReadOnly = true;
            this.R_IDReporte.Visible = false;
            // 
            // R_IDModulo
            // 
            this.R_IDModulo.DataPropertyName = "IDModulo";
            this.R_IDModulo.HeaderText = "IDModulo";
            this.R_IDModulo.Name = "R_IDModulo";
            this.R_IDModulo.ReadOnly = true;
            this.R_IDModulo.Visible = false;
            // 
            // R_Reporte
            // 
            this.R_Reporte.DataPropertyName = "Reporte";
            this.R_Reporte.HeaderText = "Reporte";
            this.R_Reporte.Name = "R_Reporte";
            this.R_Reporte.ReadOnly = true;
            // 
            // R_Descripcion
            // 
            this.R_Descripcion.DataPropertyName = "Descripcion";
            this.R_Descripcion.HeaderText = "Descripcion";
            this.R_Descripcion.Name = "R_Descripcion";
            this.R_Descripcion.ReadOnly = true;
            this.R_Descripcion.Visible = false;
            // 
            // R_Ruta
            // 
            this.R_Ruta.DataPropertyName = "Ruta";
            this.R_Ruta.HeaderText = "Ruta";
            this.R_Ruta.Name = "R_Ruta";
            this.R_Ruta.ReadOnly = true;
            this.R_Ruta.Visible = false;
            // 
            // R_lActivo
            // 
            this.R_lActivo.DataPropertyName = "lActivo";
            this.R_lActivo.HeaderText = "lActivo";
            this.R_lActivo.Name = "R_lActivo";
            this.R_lActivo.ReadOnly = true;
            this.R_lActivo.Visible = false;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtReporte);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(13, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(262, 58);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda";
            // 
            // txtReporte
            // 
            this.txtReporte.Location = new System.Drawing.Point(15, 29);
            this.txtReporte.Name = "txtReporte";
            this.txtReporte.Size = new System.Drawing.Size(235, 20);
            this.txtReporte.TabIndex = 0;
            this.txtReporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReporte_KeyDown);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 13);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(189, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Ingrese el Nombre del Reporte:";
            // 
            // btnConsultar1
            // 
            this.btnConsultar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar1.BackgroundImage")));
            this.btnConsultar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar1.Location = new System.Drawing.Point(281, 125);
            this.btnConsultar1.Name = "btnConsultar1";
            this.btnConsultar1.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar1.TabIndex = 3;
            this.btnConsultar1.Text = "&Consultar";
            this.btnConsultar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar1.UseVisualStyleBackColor = true;
            this.btnConsultar1.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(281, 12);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 1;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // ConBusRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnConsultar1);
            this.Controls.Add(this.btnBusqueda1);
            this.Name = "ConBusRep";
            this.Size = new System.Drawing.Size(355, 237);
            this.Load += new System.EventHandler(this.ConBusRep_Load);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReports)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BotonesBase.btnBusqueda btnBusqueda1;
        private lblBase lblBase1;
        private txtBase txtReporte;
        private BotonesBase.btnConsultar btnConsultar1;
        private dtgBase dtgReports;
        private grbBase grbBase1;
        private lblBase lblBase2;
        private grbBase grbBase2;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_IDReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_IDModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_Reporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_lActivo;
    }
}
