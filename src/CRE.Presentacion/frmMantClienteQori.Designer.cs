namespace CRE.Presentacion
{
    partial class frmMantClienteQori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantClienteQori));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgClientesQ = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancelar3 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar2 = new GEN.BotonesBase.btnGrabar();
            this.btnDescargar1 = new GEN.BotonesBase.btnDescargar();
            this.btnCargarFile1 = new GEN.BotonesBase.btnCargarFile();
            this.dtgCargaClientes = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgAsesor = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dtgListadoCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesQ)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargaClientes)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsesor)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListadoCreditos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(610, 448);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(462, 406);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Controls.Add(this.tabPage3);
            this.tbcBase1.Controls.Add(this.tabPage4);
            this.tbcBase1.Location = new System.Drawing.Point(12, 12);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(669, 430);
            this.tbcBase1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnProcesar1);
            this.tabPage1.Controls.Add(this.lblBase2);
            this.tabPage1.Controls.Add(this.lblBase1);
            this.tabPage1.Controls.Add(this.dtgClientesQ);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(661, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recálculo de Condiciones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(594, 348);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 7;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(414, 365);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(174, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Recálculo de Montos y plazos";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(92, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Clientes Q´ori ";
            // 
            // dtgClientesQ
            // 
            this.dtgClientesQ.AllowUserToAddRows = false;
            this.dtgClientesQ.AllowUserToDeleteRows = false;
            this.dtgClientesQ.AllowUserToResizeColumns = false;
            this.dtgClientesQ.AllowUserToResizeRows = false;
            this.dtgClientesQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgClientesQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientesQ.Location = new System.Drawing.Point(6, 40);
            this.dtgClientesQ.MultiSelect = false;
            this.dtgClientesQ.Name = "dtgClientesQ";
            this.dtgClientesQ.ReadOnly = true;
            this.dtgClientesQ.RowHeadersVisible = false;
            this.dtgClientesQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgClientesQ.Size = new System.Drawing.Size(649, 304);
            this.dtgClientesQ.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancelar3);
            this.tabPage2.Controls.Add(this.btnGrabar2);
            this.tabPage2.Controls.Add(this.btnDescargar1);
            this.tabPage2.Controls.Add(this.btnCargarFile1);
            this.tabPage2.Controls.Add(this.dtgCargaClientes);
            this.tabPage2.Controls.Add(this.btnCancelar1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(661, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Carga de Clientes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancelar3
            // 
            this.btnCancelar3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar3.BackgroundImage")));
            this.btnCancelar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar3.Location = new System.Drawing.Point(585, 348);
            this.btnCancelar3.Name = "btnCancelar3";
            this.btnCancelar3.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar3.TabIndex = 8;
            this.btnCancelar3.Text = "&Cancelar";
            this.btnCancelar3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar3.UseVisualStyleBackColor = true;
            this.btnCancelar3.Click += new System.EventHandler(this.btnCancelar3_Click);
            // 
            // btnGrabar2
            // 
            this.btnGrabar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar2.BackgroundImage")));
            this.btnGrabar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar2.Location = new System.Drawing.Point(519, 348);
            this.btnGrabar2.Name = "btnGrabar2";
            this.btnGrabar2.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar2.TabIndex = 7;
            this.btnGrabar2.Text = "&Grabar";
            this.btnGrabar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar2.UseVisualStyleBackColor = true;
            this.btnGrabar2.Click += new System.EventHandler(this.btnGrabar2_Click);
            // 
            // btnDescargar1
            // 
            this.btnDescargar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDescargar1.BackgroundImage")));
            this.btnDescargar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDescargar1.Location = new System.Drawing.Point(387, 348);
            this.btnDescargar1.Name = "btnDescargar1";
            this.btnDescargar1.Size = new System.Drawing.Size(60, 50);
            this.btnDescargar1.TabIndex = 6;
            this.btnDescargar1.Text = "Descargar Archivo";
            this.btnDescargar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDescargar1.UseVisualStyleBackColor = true;
            this.btnDescargar1.Click += new System.EventHandler(this.btnDescargar1_Click);
            // 
            // btnCargarFile1
            // 
            this.btnCargarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile1.BackgroundImage")));
            this.btnCargarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile1.Location = new System.Drawing.Point(453, 348);
            this.btnCargarFile1.Name = "btnCargarFile1";
            this.btnCargarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile1.TabIndex = 5;
            this.btnCargarFile1.Text = "Cargar Archivo";
            this.btnCargarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile1.UseVisualStyleBackColor = true;
            this.btnCargarFile1.Click += new System.EventHandler(this.btnCargarFile1_Click);
            // 
            // dtgCargaClientes
            // 
            this.dtgCargaClientes.AllowUserToAddRows = false;
            this.dtgCargaClientes.AllowUserToDeleteRows = false;
            this.dtgCargaClientes.AllowUserToResizeColumns = false;
            this.dtgCargaClientes.AllowUserToResizeRows = false;
            this.dtgCargaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCargaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCargaClientes.Location = new System.Drawing.Point(6, 6);
            this.dtgCargaClientes.MultiSelect = false;
            this.dtgCargaClientes.Name = "dtgCargaClientes";
            this.dtgCargaClientes.ReadOnly = true;
            this.dtgCargaClientes.RowHeadersVisible = false;
            this.dtgCargaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCargaClientes.Size = new System.Drawing.Size(648, 336);
            this.dtgCargaClientes.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgAsesor);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(661, 404);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Resumen de Asesores";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgAsesor
            // 
            this.dtgAsesor.AllowUserToAddRows = false;
            this.dtgAsesor.AllowUserToDeleteRows = false;
            this.dtgAsesor.AllowUserToResizeColumns = false;
            this.dtgAsesor.AllowUserToResizeRows = false;
            this.dtgAsesor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dtgAsesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAsesor.Location = new System.Drawing.Point(6, 6);
            this.dtgAsesor.MultiSelect = false;
            this.dtgAsesor.Name = "dtgAsesor";
            this.dtgAsesor.ReadOnly = true;
            this.dtgAsesor.RowHeadersVisible = false;
            this.dtgAsesor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAsesor.Size = new System.Drawing.Size(648, 384);
            this.dtgAsesor.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dtgListadoCreditos);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(661, 404);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Listado de Créditos Q\'ori";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dtgListadoCreditos
            // 
            this.dtgListadoCreditos.AllowUserToAddRows = false;
            this.dtgListadoCreditos.AllowUserToDeleteRows = false;
            this.dtgListadoCreditos.AllowUserToResizeColumns = false;
            this.dtgListadoCreditos.AllowUserToResizeRows = false;
            this.dtgListadoCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListadoCreditos.Location = new System.Drawing.Point(6, 6);
            this.dtgListadoCreditos.MultiSelect = false;
            this.dtgListadoCreditos.Name = "dtgListadoCreditos";
            this.dtgListadoCreditos.ReadOnly = true;
            this.dtgListadoCreditos.RowHeadersVisible = false;
            this.dtgListadoCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListadoCreditos.Size = new System.Drawing.Size(648, 392);
            this.dtgListadoCreditos.TabIndex = 0;
            // 
            // frmMantClienteQori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 526);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMantClienteQori";
            this.Text = "Mantenimiento de Cliente Q´ori";
            this.Load += new System.EventHandler(this.frmMantClienteQori_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientesQ)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargaClientes)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsesor)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListadoCreditos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgClientesQ;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.BotonesBase.btnCancelar btnCancelar3;
        private GEN.BotonesBase.btnGrabar btnGrabar2;
        private GEN.BotonesBase.btnDescargar btnDescargar1;
        private GEN.BotonesBase.btnCargarFile btnCargarFile1;
        private GEN.ControlesBase.dtgBase dtgCargaClientes;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.TabPage tabPage3;
        private GEN.ControlesBase.dtgBase dtgAsesor;
        private System.Windows.Forms.TabPage tabPage4;
        private GEN.ControlesBase.dtgBase dtgListadoCreditos;
    }
}