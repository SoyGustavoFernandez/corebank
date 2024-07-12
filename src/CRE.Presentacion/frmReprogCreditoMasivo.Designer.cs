namespace CRE.Presentacion
{
    partial class frmReprogCreditoMasivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprogCreditoMasivo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.txtCuentaProcesada = new GEN.ControlesBase.txtBase(this.components);
            this.txtSolicitudProcesada = new GEN.ControlesBase.txtBase(this.components);
            this.txtMensaje = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtProcesados = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnDescargar = new GEN.BotonesBase.btnDescargar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTipoPlanPago = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtUbicacionArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.dtgReprogCredito = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReprogCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.txtCuentaProcesada);
            this.panel1.Controls.Add(this.txtSolicitudProcesada);
            this.panel1.Controls.Add(this.txtMensaje);
            this.panel1.Controls.Add(this.lblBase7);
            this.panel1.Controls.Add(this.lblBase6);
            this.panel1.Controls.Add(this.lblBase3);
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.txtProcesados);
            this.panel1.Controls.Add(this.lblBase4);
            this.panel1.Controls.Add(this.btnDescargar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.txtUbicacionArchivo);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.dtgReprogCredito);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 508);
            this.panel1.TabIndex = 2;
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Info;
            this.txtEstado.Location = new System.Drawing.Point(451, 201);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 43;
            // 
            // txtCuentaProcesada
            // 
            this.txtCuentaProcesada.BackColor = System.Drawing.SystemColors.Info;
            this.txtCuentaProcesada.Location = new System.Drawing.Point(451, 159);
            this.txtCuentaProcesada.Name = "txtCuentaProcesada";
            this.txtCuentaProcesada.ReadOnly = true;
            this.txtCuentaProcesada.Size = new System.Drawing.Size(100, 20);
            this.txtCuentaProcesada.TabIndex = 42;
            // 
            // txtSolicitudProcesada
            // 
            this.txtSolicitudProcesada.BackColor = System.Drawing.SystemColors.Info;
            this.txtSolicitudProcesada.Location = new System.Drawing.Point(451, 120);
            this.txtSolicitudProcesada.Name = "txtSolicitudProcesada";
            this.txtSolicitudProcesada.ReadOnly = true;
            this.txtSolicitudProcesada.Size = new System.Drawing.Size(100, 20);
            this.txtSolicitudProcesada.TabIndex = 41;
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.SystemColors.Info;
            this.txtMensaje.Format = "n2";
            this.txtMensaje.Location = new System.Drawing.Point(451, 240);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(191, 96);
            this.txtMensaje.TabIndex = 40;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(451, 224);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(59, 13);
            this.lblBase7.TabIndex = 39;
            this.lblBase7.Text = "Mensaje:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(451, 183);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(50, 13);
            this.lblBase6.TabIndex = 38;
            this.lblBase6.Text = "Estado:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(451, 143);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(153, 13);
            this.lblBase3.TabIndex = 37;
            this.lblBase3.Text = "Ultima cuenta procesada:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(451, 102);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(161, 13);
            this.lblBase2.TabIndex = 36;
            this.lblBase2.Text = "Ultima solicitud procesada:";
            // 
            // txtProcesados
            // 
            this.txtProcesados.BackColor = System.Drawing.SystemColors.Info;
            this.txtProcesados.Format = "n2";
            this.txtProcesados.Location = new System.Drawing.Point(451, 79);
            this.txtProcesados.Name = "txtProcesados";
            this.txtProcesados.ReadOnly = true;
            this.txtProcesados.Size = new System.Drawing.Size(100, 20);
            this.txtProcesados.TabIndex = 22;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(448, 61);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(170, 13);
            this.lblBase4.TabIndex = 21;
            this.lblBase4.Text = "N° de Registros Procesados:";
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
            this.btnDescargar.Visible = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTipoPlanPago);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 48);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos periodo";
            // 
            // cboTipoPlanPago
            // 
            this.cboTipoPlanPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanPago.FormattingEnabled = true;
            this.cboTipoPlanPago.Items.AddRange(new object[] {
            "0 - NINGUNO",
            "1 - NUEVA CON CUOTA CONSTANTE",
            "2 - REPROG. CONSERVA CUOTA ORIGINAL",
            "3 - REPROG. NUEVA TASA EFECTIVA ANUAL"});
            this.cboTipoPlanPago.Location = new System.Drawing.Point(157, 19);
            this.cboTipoPlanPago.Name = "cboTipoPlanPago";
            this.cboTipoPlanPago.Size = new System.Drawing.Size(285, 21);
            this.cboTipoPlanPago.TabIndex = 1;
            this.cboTipoPlanPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanPagos_Change);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 22);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(142, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Tipo de plan de pagos: ";
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
            // dtgReprogCredito
            // 
            this.dtgReprogCredito.AllowUserToAddRows = false;
            this.dtgReprogCredito.AllowUserToDeleteRows = false;
            this.dtgReprogCredito.AllowUserToResizeColumns = false;
            this.dtgReprogCredito.AllowUserToResizeRows = false;
            this.dtgReprogCredito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReprogCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReprogCredito.Location = new System.Drawing.Point(3, 57);
            this.dtgReprogCredito.MultiSelect = false;
            this.dtgReprogCredito.Name = "dtgReprogCredito";
            this.dtgReprogCredito.ReadOnly = true;
            this.dtgReprogCredito.RowHeadersVisible = false;
            this.dtgReprogCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReprogCredito.Size = new System.Drawing.Size(442, 396);
            this.dtgReprogCredito.TabIndex = 12;
            // 
            // frmReprogCreditoMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 526);
            this.Controls.Add(this.panel1);
            this.Name = "frmReprogCreditoMasivo";
            this.Text = "Reprogramación Masiva de Créditos";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReprogCredito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtUbicacionArchivo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.ControlesBase.dtgBase dtgReprogCredito;
        private GEN.BotonesBase.btnDescargar btnDescargar;
        private GEN.ControlesBase.txtNumerico txtProcesados;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.txtBase txtCuentaProcesada;
        private GEN.ControlesBase.txtBase txtSolicitudProcesada;
        private GEN.ControlesBase.txtNumerico txtMensaje;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboTipoPlanPago;
        private GEN.ControlesBase.lblBase lblBase5;

    }
}