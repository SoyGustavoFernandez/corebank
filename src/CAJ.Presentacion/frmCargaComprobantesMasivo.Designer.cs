namespace CAJ.Presentacion
{
    partial class frmCargaComprobantesMasivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaComprobantesMasivo));
            this.dtgDatosCargados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.lblContador = new GEN.ControlesBase.lblBase();
            this.btnExporExcel = new GEN.BotonesBase.btnExporExcel();
            this.progressBar = new GEN.BotonesBase.CustomProgressBar();
            this.txtFiltro = new GEN.ControlesBase.txtBase(this.components);
            this.lblFiltro = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCargados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDatosCargados
            // 
            this.dtgDatosCargados.AllowUserToAddRows = false;
            this.dtgDatosCargados.AllowUserToDeleteRows = false;
            this.dtgDatosCargados.AllowUserToResizeColumns = false;
            this.dtgDatosCargados.AllowUserToResizeRows = false;
            this.dtgDatosCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatosCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosCargados.Location = new System.Drawing.Point(12, 46);
            this.dtgDatosCargados.MultiSelect = false;
            this.dtgDatosCargados.Name = "dtgDatosCargados";
            this.dtgDatosCargados.ReadOnly = true;
            this.dtgDatosCargados.RowHeadersVisible = false;
            this.dtgDatosCargados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatosCargados.Size = new System.Drawing.Size(1078, 318);
            this.dtgDatosCargados.TabIndex = 2;
            this.dtgDatosCargados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatosCargados_CellContentClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(964, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(1030, 371);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Location = new System.Drawing.Point(898, 371);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 73;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblContador.ForeColor = System.Drawing.Color.Navy;
            this.lblContador.Location = new System.Drawing.Point(12, 370);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(180, 13);
            this.lblContador.TabIndex = 74;
            this.lblContador.Text = "Cantidad de Comprobantes: 0";
            // 
            // btnExporExcel
            // 
            this.btnExporExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel.BackgroundImage")));
            this.btnExporExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel.cText = "E&xcel";
            this.btnExporExcel.Location = new System.Drawing.Point(832, 371);
            this.btnExporExcel.Name = "btnExporExcel";
            this.btnExporExcel.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel.TabIndex = 75;
            this.btnExporExcel.Text = "E&xcel";
            this.btnExporExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel.UseVisualStyleBackColor = true;
            this.btnExporExcel.Click += new System.EventHandler(this.btnExporExcel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 396);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 20);
            this.progressBar.TabIndex = 77;
            this.progressBar.Visible = false;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(178, 14);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(133, 20);
            this.txtFiltro.TabIndex = 78;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFiltro.ForeColor = System.Drawing.Color.Navy;
            this.lblFiltro.Location = new System.Drawing.Point(15, 17);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(157, 13);
            this.lblFiltro.TabIndex = 79;
            this.lblFiltro.Text = "Número de Comprobante:";
            // 
            // frmCargaComprobantesMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 446);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnExporExcel);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtgDatosCargados);
            this.Name = "frmCargaComprobantesMasivo";
            this.Text = "Carga de Comprobantes Masivo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargaComprobantesMasivo_FormClosing);
            this.Controls.SetChildIndex(this.dtgDatosCargados, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.lblContador, 0);
            this.Controls.SetChildIndex(this.btnExporExcel, 0);
            this.Controls.SetChildIndex(this.progressBar, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.lblFiltro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCargados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgDatosCargados;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.ControlesBase.lblBase lblContador;
        private GEN.BotonesBase.btnExporExcel btnExporExcel;
        private GEN.BotonesBase.CustomProgressBar progressBar;
        private GEN.ControlesBase.txtBase txtFiltro;
        private GEN.ControlesBase.lblBase lblFiltro;
    }
}