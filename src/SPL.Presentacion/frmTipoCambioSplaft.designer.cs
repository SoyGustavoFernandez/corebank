namespace SPL.Presentacion
{
    partial class frmTipoCambioSplaft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCambioSplaft));
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTipoCamioSplaft = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbTipoCambio = new GEN.ControlesBase.grbBase(this.components);
            this.dtgTipoCambioSplaft = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbTipoCambio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoCambioSplaft)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(308, 258);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(374, 258);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Enabled = false;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Enabled = false;
            this.dtpFechaInicial.Location = new System.Drawing.Point(102, 24);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(112, 20);
            this.dtpFechaInicial.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Enabled = false;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(220, 30);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Enabled = false;
            this.dtpFechaFinal.Location = new System.Drawing.Point(297, 23);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(112, 20);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // lblBase3
            // 
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 64);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 28);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Tipo Cambio SPLAFT:";
            // 
            // txtTipoCamioSplaft
            // 
            this.txtTipoCamioSplaft.FormatoDecimal = false;
            this.txtTipoCamioSplaft.Location = new System.Drawing.Point(102, 64);
            this.txtTipoCamioSplaft.MaxLength = 7;
            this.txtTipoCamioSplaft.Name = "txtTipoCamioSplaft";
            this.txtTipoCamioSplaft.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipoCamioSplaft.nNumDecimales = 4;
            this.txtTipoCamioSplaft.nvalor = 0D;
            this.txtTipoCamioSplaft.Size = new System.Drawing.Size(112, 20);
            this.txtTipoCamioSplaft.TabIndex = 6;
            this.txtTipoCamioSplaft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbTipoCambio
            // 
            this.grbTipoCambio.Controls.Add(this.lblBase1);
            this.grbTipoCambio.Controls.Add(this.txtTipoCamioSplaft);
            this.grbTipoCambio.Controls.Add(this.lblBase3);
            this.grbTipoCambio.Controls.Add(this.dtpFechaFinal);
            this.grbTipoCambio.Controls.Add(this.lblBase2);
            this.grbTipoCambio.Controls.Add(this.dtpFechaInicial);
            this.grbTipoCambio.Enabled = false;
            this.grbTipoCambio.Location = new System.Drawing.Point(20, 138);
            this.grbTipoCambio.Name = "grbTipoCambio";
            this.grbTipoCambio.Size = new System.Drawing.Size(416, 114);
            this.grbTipoCambio.TabIndex = 7;
            this.grbTipoCambio.TabStop = false;
            this.grbTipoCambio.Text = "Tipo de Cambio";
            // 
            // dtgTipoCambioSplaft
            // 
            this.dtgTipoCambioSplaft.AllowUserToAddRows = false;
            this.dtgTipoCambioSplaft.AllowUserToDeleteRows = false;
            this.dtgTipoCambioSplaft.AllowUserToResizeColumns = false;
            this.dtgTipoCambioSplaft.AllowUserToResizeRows = false;
            this.dtgTipoCambioSplaft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTipoCambioSplaft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoCambioSplaft.Location = new System.Drawing.Point(21, 22);
            this.dtgTipoCambioSplaft.MultiSelect = false;
            this.dtgTipoCambioSplaft.Name = "dtgTipoCambioSplaft";
            this.dtgTipoCambioSplaft.ReadOnly = true;
            this.dtgTipoCambioSplaft.RowHeadersVisible = false;
            this.dtgTipoCambioSplaft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoCambioSplaft.Size = new System.Drawing.Size(415, 90);
            this.dtgTipoCambioSplaft.TabIndex = 8;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(110, 258);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 9;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(176, 258);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 10;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(242, 258);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 11;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmTipoCambioSplaft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 341);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.dtgTipoCambioSplaft);
            this.Controls.Add(this.grbTipoCambio);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmTipoCambioSplaft";
            this.Text = "Mantenimiento de Tipo Cambio Splaft";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbTipoCambio, 0);
            this.Controls.SetChildIndex(this.dtgTipoCambioSplaft, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.grbTipoCambio.ResumeLayout(false);
            this.grbTipoCambio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoCambioSplaft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaInicial;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaFinal;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtTipoCamioSplaft;
        private GEN.ControlesBase.grbBase grbTipoCambio;
        private GEN.ControlesBase.dtgBase dtgTipoCambioSplaft;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}

