namespace DEP.Presentacion
{
    partial class frmEnvioEstadosDeCuentaIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioEstadosDeCuentaIndividual));
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.conFechaAñoMes1 = new GEN.ControlesBase.ConFechaAñoMes();
            this.cboMeses = new GEN.ControlesBase.cboMeses(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.txtAnioMes = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgCtasCuentas = new System.Windows.Forms.DataGridView();
            this.conBusCliente = new GEN.ControlesBase.ConBusCli();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnGenerar1 = new GEN.BotonesBase.btnGenerar();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.conLoader1 = new GEN.ControlesBase.conLoader();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conFechaAñoMes1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(12, 373);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 30;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // conFechaAñoMes1
            // 
            this.conFechaAñoMes1.anio = 1;
            this.conFechaAñoMes1.cMes = "ENERO";
            this.conFechaAñoMes1.Controls.Add(this.cboMeses);
            this.conFechaAñoMes1.Controls.Add(this.nudAnio);
            this.conFechaAñoMes1.idMes = 1;
            this.conFechaAñoMes1.Location = new System.Drawing.Point(45, 147);
            this.conFechaAñoMes1.Name = "conFechaAñoMes1";
            this.conFechaAñoMes1.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMes1.TabIndex = 29;
            this.conFechaAñoMes1.eventCambio += new System.EventHandler(this.conFechaAñoMes1_eventCambio);
            // 
            // cboMeses
            // 
            this.cboMeses.DisplayMember = "cMes";
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(1, 15);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(106, 21);
            this.cboMeses.TabIndex = 2;
            this.cboMeses.ValueMember = "idMeses";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(110, 15);
            this.nudAnio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(51, 20);
            this.nudAnio.TabIndex = 1;
            this.nudAnio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtAnioMes
            // 
            this.txtAnioMes.Enabled = false;
            this.txtAnioMes.Location = new System.Drawing.Point(236, 162);
            this.txtAnioMes.Name = "txtAnioMes";
            this.txtAnioMes.Size = new System.Drawing.Size(100, 20);
            this.txtAnioMes.TabIndex = 28;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(233, 146);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(113, 13);
            this.lblBase2.TabIndex = 27;
            this.lblBase2.Text = "Carpeta Generada";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(44, 129);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(113, 13);
            this.lblBase1.TabIndex = 26;
            this.lblBase1.Text = "Seleccione el Mes:";
            // 
            // dtgCtasCuentas
            // 
            this.dtgCtasCuentas.AllowUserToAddRows = false;
            this.dtgCtasCuentas.AllowUserToDeleteRows = false;
            this.dtgCtasCuentas.AllowUserToResizeColumns = false;
            this.dtgCtasCuentas.AllowUserToResizeRows = false;
            this.dtgCtasCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCtasCuentas.Location = new System.Drawing.Point(12, 192);
            this.dtgCtasCuentas.MultiSelect = false;
            this.dtgCtasCuentas.Name = "dtgCtasCuentas";
            this.dtgCtasCuentas.ReadOnly = true;
            this.dtgCtasCuentas.RowHeadersVisible = false;
            this.dtgCtasCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCtasCuentas.Size = new System.Drawing.Size(743, 155);
            this.dtgCtasCuentas.TabIndex = 31;
            this.dtgCtasCuentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCtasCuentas_CellClick);
            this.dtgCtasCuentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCtasCuentas_CellContentClick);
            // 
            // conBusCliente
            // 
            this.conBusCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliente.idCli = 0;
            this.conBusCliente.Location = new System.Drawing.Point(41, 12);
            this.conBusCliente.Name = "conBusCliente";
            this.conBusCliente.Size = new System.Drawing.Size(532, 105);
            this.conBusCliente.TabIndex = 33;
            this.conBusCliente.ChangeDocumentoID += new System.EventHandler(this.conBusCtaAho_ChangeDocumentoID);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(619, 373);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 34;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(37, 350);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 20);
            this.lblResultado.TabIndex = 35;
            // 
            // btnGenerar1
            // 
            this.btnGenerar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar1.BackgroundImage")));
            this.btnGenerar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar1.Location = new System.Drawing.Point(92, 373);
            this.btnGenerar1.Name = "btnGenerar1";
            this.btnGenerar1.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar1.TabIndex = 36;
            this.btnGenerar1.Text = "Gene&rar";
            this.btnGenerar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar1.UseVisualStyleBackColor = true;
            this.btnGenerar1.Click += new System.EventHandler(this.btnGenerar1_Click);
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(168, 373);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 37;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // conLoader1
            // 
            this.conLoader1.Active = false;
            this.conLoader1.Color = System.Drawing.Color.Crimson;
            this.conLoader1.InnerCircleRadius = 5;
            this.conLoader1.Location = new System.Drawing.Point(362, 151);
            this.conLoader1.Name = "conLoader1";
            this.conLoader1.NumberSpoke = 12;
            this.conLoader1.OuterCircleRadius = 11;
            this.conLoader1.RotationSpeed = 100;
            this.conLoader1.Size = new System.Drawing.Size(45, 35);
            this.conLoader1.SpokeThickness = 2;
            this.conLoader1.StylePreset = GEN.ControlesBase.conLoader.StylePresets.MacOSX;
            this.conLoader1.TabIndex = 38;
            this.conLoader1.Text = "conLoader1";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(695, 373);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 39;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmEnvioEstadosDeCuentaIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 463);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.conLoader1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.btnGenerar1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusCliente);
            this.Controls.Add(this.dtgCtasCuentas);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.conFechaAñoMes1);
            this.Controls.Add(this.txtAnioMes);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmEnvioEstadosDeCuentaIndividual";
            this.Text = "Generación Individual de los EECC";
            this.Load += new System.EventHandler(this.frmEnvioEstadosDeCuentaIndividual_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtAnioMes, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMes1, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.Controls.SetChildIndex(this.dtgCtasCuentas, 0);
            this.Controls.SetChildIndex(this.conBusCliente, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblResultado, 0);
            this.Controls.SetChildIndex(this.btnGenerar1, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.conLoader1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.conFechaAñoMes1.ResumeLayout(false);
            this.conFechaAñoMes1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasCuentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMes1;
        private GEN.ControlesBase.cboMeses cboMeses;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.txtBase txtAnioMes;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.DataGridView dtgCtasCuentas;
        private GEN.ControlesBase.ConBusCli conBusCliente;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.Label lblResultado;
        private GEN.BotonesBase.btnGenerar btnGenerar1;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.ControlesBase.conLoader conLoader1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}