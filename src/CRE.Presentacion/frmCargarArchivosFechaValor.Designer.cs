namespace CRE.Presentacion
{
    partial class frmCargarArchivosFechaValor
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
            this.lblTituloGeneral = new GEN.ControlesBase.lblBase();
            this.PanelGeneral = new System.Windows.Forms.Panel();
            this.PanelContenedorVisualizador = new System.Windows.Forms.Panel();
            this.PanelVisualizador = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.PanelDTGArchivosCargados = new System.Windows.Forms.Panel();
            this.dtgArchivosCargados = new GEN.ControlesBase.dtgBase(this.components);
            this.bindingSourceArchivosCargados = new System.Windows.Forms.BindingSource(this.components);
            this.PanelGeneral.SuspendLayout();
            this.PanelContenedorVisualizador.SuspendLayout();
            this.PanelVisualizador.SuspendLayout();
            this.PanelDTGArchivosCargados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchivosCargados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceArchivosCargados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloGeneral
            // 
            this.lblTituloGeneral.AutoSize = true;
            this.lblTituloGeneral.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTituloGeneral.ForeColor = System.Drawing.Color.Navy;
            this.lblTituloGeneral.Location = new System.Drawing.Point(223, 23);
            this.lblTituloGeneral.Name = "lblTituloGeneral";
            this.lblTituloGeneral.Size = new System.Drawing.Size(156, 13);
            this.lblTituloGeneral.TabIndex = 4;
            this.lblTituloGeneral.Text = "ARCHIVOS DE SUSTENTO";
            // 
            // PanelGeneral
            // 
            this.PanelGeneral.AutoSize = true;
            this.PanelGeneral.Controls.Add(this.PanelContenedorVisualizador);
            this.PanelGeneral.Controls.Add(this.PanelDTGArchivosCargados);
            this.PanelGeneral.Location = new System.Drawing.Point(22, 50);
            this.PanelGeneral.Name = "PanelGeneral";
            this.PanelGeneral.Size = new System.Drawing.Size(565, 514);
            this.PanelGeneral.TabIndex = 5;
            // 
            // PanelContenedorVisualizador
            // 
            this.PanelContenedorVisualizador.Controls.Add(this.PanelVisualizador);
            this.PanelContenedorVisualizador.Location = new System.Drawing.Point(3, 215);
            this.PanelContenedorVisualizador.Name = "PanelContenedorVisualizador";
            this.PanelContenedorVisualizador.Size = new System.Drawing.Size(559, 292);
            this.PanelContenedorVisualizador.TabIndex = 1;
            // 
            // PanelVisualizador
            // 
            this.PanelVisualizador.Controls.Add(this.webBrowser);
            this.PanelVisualizador.Location = new System.Drawing.Point(3, 3);
            this.PanelVisualizador.Name = "PanelVisualizador";
            this.PanelVisualizador.Size = new System.Drawing.Size(553, 283);
            this.PanelVisualizador.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(553, 283);
            this.webBrowser.TabIndex = 0;
            // 
            // PanelDTGArchivosCargados
            // 
            this.PanelDTGArchivosCargados.Controls.Add(this.dtgArchivosCargados);
            this.PanelDTGArchivosCargados.Location = new System.Drawing.Point(3, 3);
            this.PanelDTGArchivosCargados.Name = "PanelDTGArchivosCargados";
            this.PanelDTGArchivosCargados.Size = new System.Drawing.Size(559, 206);
            this.PanelDTGArchivosCargados.TabIndex = 0;
            // 
            // dtgArchivosCargados
            // 
            this.dtgArchivosCargados.AllowUserToAddRows = false;
            this.dtgArchivosCargados.AllowUserToDeleteRows = false;
            this.dtgArchivosCargados.AllowUserToResizeColumns = false;
            this.dtgArchivosCargados.AllowUserToResizeRows = false;
            this.dtgArchivosCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgArchivosCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArchivosCargados.Location = new System.Drawing.Point(3, 3);
            this.dtgArchivosCargados.MultiSelect = false;
            this.dtgArchivosCargados.Name = "dtgArchivosCargados";
            this.dtgArchivosCargados.ReadOnly = true;
            this.dtgArchivosCargados.RowHeadersVisible = false;
            this.dtgArchivosCargados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgArchivosCargados.Size = new System.Drawing.Size(553, 200);
            this.dtgArchivosCargados.TabIndex = 0;
            this.dtgArchivosCargados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchivosCargados_CellClick);
            // 
            // frmCargarArchivosFechaValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 603);
            this.Controls.Add(this.PanelGeneral);
            this.Controls.Add(this.lblTituloGeneral);
            this.Name = "frmCargarArchivosFechaValor";
            this.Text = "Archivos Cargados - Fecha Valor";
            this.Controls.SetChildIndex(this.lblTituloGeneral, 0);
            this.Controls.SetChildIndex(this.PanelGeneral, 0);
            this.PanelGeneral.ResumeLayout(false);
            this.PanelContenedorVisualizador.ResumeLayout(false);
            this.PanelVisualizador.ResumeLayout(false);
            this.PanelDTGArchivosCargados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgArchivosCargados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceArchivosCargados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblTituloGeneral;
        private System.Windows.Forms.Panel PanelGeneral;
        private System.Windows.Forms.Panel PanelContenedorVisualizador;
        private System.Windows.Forms.Panel PanelVisualizador;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel PanelDTGArchivosCargados;
        private GEN.ControlesBase.dtgBase dtgArchivosCargados;
        private System.Windows.Forms.BindingSource bindingSourceArchivosCargados;
    }
}