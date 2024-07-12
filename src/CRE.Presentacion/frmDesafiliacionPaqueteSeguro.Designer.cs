namespace CRE.Presentacion
{
    partial class frmDesafiliacionPaqueteSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesafiliacionPaqueteSeguro));
            this.conBusCliente = new GEN.ControlesBase.ConBusCli();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNumeroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtPrimaMensual = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgPrimaSeguro = new GEN.ControlesBase.dtgBase(this.components);
            this.nCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoGeneradoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaInicioCobertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinCobertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnDesafiliarSeguro = new GEN.BotonesBase.btnCancelarCred();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtPaqueteSeguro = new GEN.ControlesBase.txtBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrimaSeguro)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCliente
            // 
            this.conBusCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliente.idCli = 0;
            this.conBusCliente.Location = new System.Drawing.Point(12, 12);
            this.conBusCliente.Name = "conBusCliente";
            this.conBusCliente.Size = new System.Drawing.Size(532, 105);
            this.conBusCliente.TabIndex = 2;
            this.conBusCliente.ClicBuscar += new System.EventHandler(this.conBusCliente_ClicBuscar);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(24, 148);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(99, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Número cuenta:";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Enabled = false;
            this.txtNumeroCuenta.Location = new System.Drawing.Point(129, 145);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(122, 20);
            this.txtNumeroCuenta.TabIndex = 4;
            // 
            // txtPrimaMensual
            // 
            this.txtPrimaMensual.Enabled = false;
            this.txtPrimaMensual.Location = new System.Drawing.Point(383, 145);
            this.txtPrimaMensual.Name = "txtPrimaMensual";
            this.txtPrimaMensual.Size = new System.Drawing.Size(122, 20);
            this.txtPrimaMensual.TabIndex = 6;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(278, 148);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(97, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Prima mensual:";
            // 
            // dtgPrimaSeguro
            // 
            this.dtgPrimaSeguro.AllowUserToAddRows = false;
            this.dtgPrimaSeguro.AllowUserToDeleteRows = false;
            this.dtgPrimaSeguro.AllowUserToResizeColumns = false;
            this.dtgPrimaSeguro.AllowUserToResizeRows = false;
            this.dtgPrimaSeguro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPrimaSeguro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrimaSeguro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nCuota,
            this.nMontoGeneradoCuota,
            this.dFechaInicioCobertura,
            this.dFechaFinCobertura,
            this.cEstadoCuota});
            this.dtgPrimaSeguro.Location = new System.Drawing.Point(27, 220);
            this.dtgPrimaSeguro.MultiSelect = false;
            this.dtgPrimaSeguro.Name = "dtgPrimaSeguro";
            this.dtgPrimaSeguro.ReadOnly = true;
            this.dtgPrimaSeguro.RowHeadersVisible = false;
            this.dtgPrimaSeguro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrimaSeguro.Size = new System.Drawing.Size(517, 237);
            this.dtgPrimaSeguro.TabIndex = 7;
            // 
            // nCuota
            // 
            this.nCuota.DataPropertyName = "nCuota";
            this.nCuota.FillWeight = 2F;
            this.nCuota.HeaderText = "Cuota";
            this.nCuota.Name = "nCuota";
            this.nCuota.ReadOnly = true;
            // 
            // nMontoGeneradoCuota
            // 
            this.nMontoGeneradoCuota.DataPropertyName = "nMontoGeneradoCuota";
            this.nMontoGeneradoCuota.FillWeight = 5F;
            this.nMontoGeneradoCuota.HeaderText = "Monto";
            this.nMontoGeneradoCuota.Name = "nMontoGeneradoCuota";
            this.nMontoGeneradoCuota.ReadOnly = true;
            // 
            // dFechaInicioCobertura
            // 
            this.dFechaInicioCobertura.DataPropertyName = "dFechaInicioCobertura";
            this.dFechaInicioCobertura.FillWeight = 5F;
            this.dFechaInicioCobertura.HeaderText = "Cobertura desde";
            this.dFechaInicioCobertura.Name = "dFechaInicioCobertura";
            this.dFechaInicioCobertura.ReadOnly = true;
            // 
            // dFechaFinCobertura
            // 
            this.dFechaFinCobertura.DataPropertyName = "dFechaFinCobertura";
            this.dFechaFinCobertura.FillWeight = 5F;
            this.dFechaFinCobertura.HeaderText = "Cobertura Hasta";
            this.dFechaFinCobertura.Name = "dFechaFinCobertura";
            this.dFechaFinCobertura.ReadOnly = true;
            // 
            // cEstadoCuota
            // 
            this.cEstadoCuota.DataPropertyName = "cEstadoCuota";
            this.cEstadoCuota.FillWeight = 5F;
            this.cEstadoCuota.HeaderText = "Estado Prima";
            this.cEstadoCuota.Name = "cEstadoCuota";
            this.cEstadoCuota.ReadOnly = true;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(483, 474);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnDesafiliarSeguro
            // 
            this.btnDesafiliarSeguro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDesafiliarSeguro.BackgroundImage")));
            this.btnDesafiliarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDesafiliarSeguro.Location = new System.Drawing.Point(353, 474);
            this.btnDesafiliarSeguro.Name = "btnDesafiliarSeguro";
            this.btnDesafiliarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnDesafiliarSeguro.TabIndex = 12;
            this.btnDesafiliarSeguro.Text = "Desafiliar Plan";
            this.btnDesafiliarSeguro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesafiliarSeguro.UseVisualStyleBackColor = true;
            this.btnDesafiliarSeguro.Click += new System.EventHandler(this.btnDesafiliarSeguro_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(287, 474);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(24, 184);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(107, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Planes de Seguro";
            // 
            // txtPaqueteSeguro
            // 
            this.txtPaqueteSeguro.Enabled = false;
            this.txtPaqueteSeguro.Location = new System.Drawing.Point(129, 180);
            this.txtPaqueteSeguro.Name = "txtPaqueteSeguro";
            this.txtPaqueteSeguro.Size = new System.Drawing.Size(376, 20);
            this.txtPaqueteSeguro.TabIndex = 15;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(419, 474);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 16;
            this.btnImprimir1.Text = "Cronograma de Pagos";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmDesafiliacionPaqueteSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 558);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.txtPaqueteSeguro);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDesafiliarSeguro);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgPrimaSeguro);
            this.Controls.Add(this.txtPrimaMensual);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conBusCliente);
            this.Name = "frmDesafiliacionPaqueteSeguro";
            this.Text = "Desafiliación Plan de Seguro";
            this.Load += new System.EventHandler(this.frmDesafiliacionPaqueteSeguro_Load);
            this.Controls.SetChildIndex(this.conBusCliente, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtNumeroCuenta, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtPrimaMensual, 0);
            this.Controls.SetChildIndex(this.dtgPrimaSeguro, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnDesafiliarSeguro, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtPaqueteSeguro, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrimaSeguro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCliente;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNumeroCuenta;
        private GEN.ControlesBase.txtBase txtPrimaMensual;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgPrimaSeguro;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelarCred btnDesafiliarSeguro;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoGeneradoCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaInicioCobertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFinCobertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoCuota;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtPaqueteSeguro;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}