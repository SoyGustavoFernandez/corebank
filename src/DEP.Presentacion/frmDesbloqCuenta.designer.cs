namespace DEP.Presentacion
{
    partial class frmDesbloqCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesbloqCuenta));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMotDesbloqueo = new GEN.ControlesBase.txtBase(this.components);
            this.dtgBloqueosCta = new System.Windows.Forms.DataGridView();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced = new GEN.ControlesBase.grbBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtExterno = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtInterno = new GEN.ControlesBase.rbtBase(this.components);
            this.txtTotalBloq = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBloqueosCta)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.conBusCol.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtProducto);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Location = new System.Drawing.Point(3, 119);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(741, 55);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Cuenta:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(75, 20);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(251, 20);
            this.txtProducto.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 23);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Producto:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(392, 20);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(142, 21);
            this.cboMoneda.TabIndex = 1;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(335, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(56, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Moneda:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonto.Enabled = false;
            this.txtMonto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(591, 21);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(131, 21);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(545, 24);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(46, 13);
            this.lblBase7.TabIndex = 10;
            this.lblBase7.Text = "Monto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 302);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(138, 13);
            this.lblBase2.TabIndex = 40;
            this.lblBase2.Text = "Motivo de Desbloqueo:";
            // 
            // txtMotDesbloqueo
            // 
            this.txtMotDesbloqueo.Enabled = false;
            this.txtMotDesbloqueo.Location = new System.Drawing.Point(144, 302);
            this.txtMotDesbloqueo.Multiline = true;
            this.txtMotDesbloqueo.Name = "txtMotDesbloqueo";
            this.txtMotDesbloqueo.Size = new System.Drawing.Size(590, 50);
            this.txtMotDesbloqueo.TabIndex = 1;
            // 
            // dtgBloqueosCta
            // 
            this.dtgBloqueosCta.AllowUserToAddRows = false;
            this.dtgBloqueosCta.AllowUserToDeleteRows = false;
            this.dtgBloqueosCta.AllowUserToResizeColumns = false;
            this.dtgBloqueosCta.AllowUserToResizeRows = false;
            this.dtgBloqueosCta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBloqueosCta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBloqueosCta.Location = new System.Drawing.Point(7, 216);
            this.dtgBloqueosCta.MultiSelect = false;
            this.dtgBloqueosCta.Name = "dtgBloqueosCta";
            this.dtgBloqueosCta.ReadOnly = true;
            this.dtgBloqueosCta.RowHeadersVisible = false;
            this.dtgBloqueosCta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBloqueosCta.Size = new System.Drawing.Size(729, 129);
            this.dtgBloqueosCta.TabIndex = 45;
            this.dtgBloqueosCta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBloqueosCta_CellValueChanged);
            this.dtgBloqueosCta.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgBloqueosCta_CurrentCellDirtyStateChanged);
            this.dtgBloqueosCta.SelectionChanged += new System.EventHandler(this.dtgBloqueosCta_SelectionChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.grbBase5);
            this.grbBase3.Controls.Add(this.txtMotDesbloqueo);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.txtTotalBloq);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(2, 180);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(742, 361);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.lblBase10);
            this.grbBase5.Controls.Add(this.conBusCol);
            this.grbBase5.Controls.Add(this.txtNombre);
            this.grbBase5.Controls.Add(this.grbBase4);
            this.grbBase5.Location = new System.Drawing.Point(3, 171);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(736, 128);
            this.grbBase5.TabIndex = 0;
            this.grbBase5.TabStop = false;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(216, 105);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(71, 13);
            this.lblBase10.TabIndex = 58;
            this.lblBase10.Text = "Solicitante:";
            // 
            // conBusCol
            // 
            this.conBusCol.Controls.Add(this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced);
            this.conBusCol.Location = new System.Drawing.Point(223, 10);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(390, 86);
            this.conBusCol.TabIndex = 55;
            // 
            // object_5cf2b776_5b2d_4971_82bb_b26bee159ced
            // 
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.Location = new System.Drawing.Point(0, 0);
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.Name = "object_5cf2b776_5b2d_4971_82bb_b26bee159ced";
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.Size = new System.Drawing.Size(387, 86);
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.TabIndex = 0;
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.TabStop = false;
            this.object_5cf2b776_5b2d_4971_82bb_b26bee159ced.Text = "Datos del Colaborador";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(290, 102);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(431, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.rbtExterno);
            this.grbBase4.Controls.Add(this.rbtInterno);
            this.grbBase4.Location = new System.Drawing.Point(18, 8);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(159, 113);
            this.grbBase4.TabIndex = 0;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Solicitante del DesBloqueo";
            // 
            // rbtExterno
            // 
            this.rbtExterno.AutoSize = true;
            this.rbtExterno.Enabled = false;
            this.rbtExterno.ForeColor = System.Drawing.Color.Navy;
            this.rbtExterno.Location = new System.Drawing.Point(26, 72);
            this.rbtExterno.Name = "rbtExterno";
            this.rbtExterno.Size = new System.Drawing.Size(61, 17);
            this.rbtExterno.TabIndex = 58;
            this.rbtExterno.Text = "Externo";
            this.rbtExterno.UseVisualStyleBackColor = true;
            this.rbtExterno.CheckedChanged += new System.EventHandler(this.rbtExterno_CheckedChanged);
            // 
            // rbtInterno
            // 
            this.rbtInterno.AutoSize = true;
            this.rbtInterno.Enabled = false;
            this.rbtInterno.ForeColor = System.Drawing.Color.Navy;
            this.rbtInterno.Location = new System.Drawing.Point(29, 28);
            this.rbtInterno.Name = "rbtInterno";
            this.rbtInterno.Size = new System.Drawing.Size(58, 17);
            this.rbtInterno.TabIndex = 57;
            this.rbtInterno.Text = "Interno";
            this.rbtInterno.UseVisualStyleBackColor = true;
            this.rbtInterno.CheckedChanged += new System.EventHandler(this.rbtInterno_CheckedChanged);
            // 
            // txtTotalBloq
            // 
            this.txtTotalBloq.Enabled = false;
            this.txtTotalBloq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBloq.FormatoDecimal = false;
            this.txtTotalBloq.Location = new System.Drawing.Point(624, 13);
            this.txtTotalBloq.Name = "txtTotalBloq";
            this.txtTotalBloq.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotalBloq.nNumDecimales = 4;
            this.txtTotalBloq.nvalor = 0D;
            this.txtTotalBloq.Size = new System.Drawing.Size(106, 20);
            this.txtTotalBloq.TabIndex = 56;
            this.txtTotalBloq.Text = "0.00";
            this.txtTotalBloq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(475, 15);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(145, 13);
            this.lblBase8.TabIndex = 55;
            this.lblBase8.Text = "Monto Total de Bloqueo:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(487, 545);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(676, 545);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(550, 545);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(613, 545);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conBusCtaAho.Location = new System.Drawing.Point(1, 4);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(654, 113);
            this.conBusCtaAho.TabIndex = 0;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // frmDesbloqCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 621);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.dtgBloqueosCta);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmDesbloqCuenta";
            this.Text = "Control de Desbloqueo de Cuentas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBloqueoCuenta_FormClosed);
            this.Load += new System.EventHandler(this.frmBloqCuenta_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.dtgBloqueosCta, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBloqueosCta)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.conBusCol.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtMonto;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMotDesbloqueo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private System.Windows.Forms.DataGridView dtgBloqueosCta;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtNumRea txtTotalBloq;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.grbBase object_5cf2b776_5b2d_4971_82bb_b26bee159ced;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.rbtBase rbtExterno;
        private GEN.ControlesBase.rbtBase rbtInterno;

    }
}