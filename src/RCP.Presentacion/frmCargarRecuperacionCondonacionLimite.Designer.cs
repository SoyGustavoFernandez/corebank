namespace RCP.Presentacion
{
    partial class frmCargarRecuperacionCondonacionLimite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarRecuperacionCondonacionLimite));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboMes = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtUbicacionArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.dtgRecuperacionCondonacionLimite = new GEN.ControlesBase.dtgBase(this.components);
            this.btnDescargar = new GEN.BotonesBase.btnDescargar();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecuperacionCondonacionLimite)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDescargar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.txtUbicacionArchivo);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnGrabar);
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.dtgRecuperacionCondonacionLimite);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 508);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMiniBusq);
            this.groupBox1.Controls.Add(this.nudAnio);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 48);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos periodo";
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(601, 15);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 12;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(283, 19);
            this.nudAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(134, 20);
            this.nudAnio.TabIndex = 7;
            this.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAnio.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(432, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Mes:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(252, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(34, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Año:";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(472, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(120, 21);
            this.cboMes.TabIndex = 8;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.cboMes_SelectionChangeCommitted);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(66, 455);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Dirección:";
            // 
            // txtUbicacionArchivo
            // 
            this.txtUbicacionArchivo.Location = new System.Drawing.Point(69, 471);
            this.txtUbicacionArchivo.Name = "txtUbicacionArchivo";
            this.txtUbicacionArchivo.ReadOnly = true;
            this.txtUbicacionArchivo.Size = new System.Drawing.Size(296, 20);
            this.txtUbicacionArchivo.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(501, 456);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(585, 456);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(435, 456);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Location = new System.Drawing.Point(369, 456);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 13;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dtgRecuperacionCondonacionLimite
            // 
            this.dtgRecuperacionCondonacionLimite.AllowUserToAddRows = false;
            this.dtgRecuperacionCondonacionLimite.AllowUserToDeleteRows = false;
            this.dtgRecuperacionCondonacionLimite.AllowUserToResizeColumns = false;
            this.dtgRecuperacionCondonacionLimite.AllowUserToResizeRows = false;
            this.dtgRecuperacionCondonacionLimite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRecuperacionCondonacionLimite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRecuperacionCondonacionLimite.Location = new System.Drawing.Point(3, 57);
            this.dtgRecuperacionCondonacionLimite.MultiSelect = false;
            this.dtgRecuperacionCondonacionLimite.Name = "dtgRecuperacionCondonacionLimite";
            this.dtgRecuperacionCondonacionLimite.ReadOnly = true;
            this.dtgRecuperacionCondonacionLimite.RowHeadersVisible = false;
            this.dtgRecuperacionCondonacionLimite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRecuperacionCondonacionLimite.Size = new System.Drawing.Size(651, 396);
            this.dtgRecuperacionCondonacionLimite.TabIndex = 12;
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDescargar.BackgroundImage")));
            this.btnDescargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDescargar.Location = new System.Drawing.Point(3, 455);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(60, 50);
            this.btnDescargar.TabIndex = 20;
            this.btnDescargar.Text = "Formato";
            this.btnDescargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // frmCargarRecuperacionCondonacionLimite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 526);
            this.Controls.Add(this.panel1);
            this.Name = "frmCargarRecuperacionCondonacionLimite";
            this.Text = "Cargar Limite de Condonacion";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecuperacionCondonacionLimite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboMeses cboMes;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtUbicacionArchivo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.ControlesBase.dtgBase dtgRecuperacionCondonacionLimite;
        private GEN.BotonesBase.btnDescargar btnDescargar;

    }
}