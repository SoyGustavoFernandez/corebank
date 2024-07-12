namespace CRE.Presentacion
{
    partial class frmDesVincularGaranCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesVincularGaranCartaFianza));
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCartaFianza = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtFechaCancelacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoAprobado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnLiberar1 = new GEN.BotonesBase.btnLiberar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conBusCuentaCli1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli1.Controls.Add(this.grbBase1);
            this.conBusCuentaCli1.Controls.Add(this.grbBase2);
            this.conBusCuentaCli1.Controls.Add(this.grbBase3);
            this.conBusCuentaCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(557, 100);
            this.conBusCuentaCli1.TabIndex = 50;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(554, 99);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, -2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(554, 99);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(3, -2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(554, 99);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos del Cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMoneda);
            this.groupBox2.Controls.Add(this.lblBase1);
            this.groupBox2.Controls.Add(this.txtCartaFianza);
            this.groupBox2.Controls.Add(this.lblBase12);
            this.groupBox2.Controls.Add(this.txtFechaCancelacion);
            this.groupBox2.Controls.Add(this.txtMontoAprobado);
            this.groupBox2.Controls.Add(this.lblBase9);
            this.groupBox2.Controls.Add(this.lblBase8);
            this.groupBox2.Location = new System.Drawing.Point(15, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 72);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la carta fianza";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Location = new System.Drawing.Point(378, 18);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(159, 20);
            this.txtMoneda.TabIndex = 33;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(276, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 32;
            this.lblBase1.Text = "Moneda:";
            // 
            // txtCartaFianza
            // 
            this.txtCartaFianza.Enabled = false;
            this.txtCartaFianza.Location = new System.Drawing.Point(123, 17);
            this.txtCartaFianza.Name = "txtCartaFianza";
            this.txtCartaFianza.ReadOnly = true;
            this.txtCartaFianza.Size = new System.Drawing.Size(137, 20);
            this.txtCartaFianza.TabIndex = 31;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 20);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(108, 13);
            this.lblBase12.TabIndex = 30;
            this.lblBase12.Text = "Nro Carta Fianza:";
            // 
            // txtFechaCancelacion
            // 
            this.txtFechaCancelacion.Enabled = false;
            this.txtFechaCancelacion.Location = new System.Drawing.Point(378, 44);
            this.txtFechaCancelacion.Name = "txtFechaCancelacion";
            this.txtFechaCancelacion.ReadOnly = true;
            this.txtFechaCancelacion.Size = new System.Drawing.Size(159, 20);
            this.txtFechaCancelacion.TabIndex = 22;
            // 
            // txtMontoAprobado
            // 
            this.txtMontoAprobado.Enabled = false;
            this.txtMontoAprobado.Location = new System.Drawing.Point(123, 44);
            this.txtMontoAprobado.Name = "txtMontoAprobado";
            this.txtMontoAprobado.ReadOnly = true;
            this.txtMontoAprobado.Size = new System.Drawing.Size(137, 20);
            this.txtMontoAprobado.TabIndex = 21;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(276, 47);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(101, 13);
            this.lblBase9.TabIndex = 18;
            this.lblBase9.Text = "Fec cancelación:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 47);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(46, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Monto:";
            // 
            // btnLiberar1
            // 
            this.btnLiberar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar1.BackgroundImage")));
            this.btnLiberar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiberar1.Location = new System.Drawing.Point(380, 326);
            this.btnLiberar1.Name = "btnLiberar1";
            this.btnLiberar1.Size = new System.Drawing.Size(60, 50);
            this.btnLiberar1.TabIndex = 53;
            this.btnLiberar1.Text = "&Liberar";
            this.btnLiberar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLiberar1.UseVisualStyleBackColor = true;
            this.btnLiberar1.Click += new System.EventHandler(this.btnLiberar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(512, 326);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 54;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgGarantias);
            this.groupBox1.Location = new System.Drawing.Point(15, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 126);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Garantias";
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGarantias.Location = new System.Drawing.Point(3, 16);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(551, 107);
            this.dtgGarantias.TabIndex = 0;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(446, 326);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 56;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click_1);
            // 
            // frmDesVincularGaranCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 407);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnLiberar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Name = "frmDesVincularGaranCartaFianza";
            this.Text = "Desvincular Garantias Carta Fianza y Liberar cuentas de deposito";
            this.Load += new System.EventHandler(this.frmDesVincularGaranCartaFianza_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnLiberar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.conBusCuentaCli1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCartaFianza;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtFechaCancelacion;
        private GEN.ControlesBase.txtBase txtMontoAprobado;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnLiberar btnLiberar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.dtgBase dtgGarantias;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}