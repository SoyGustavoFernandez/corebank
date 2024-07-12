namespace CRE.Presentacion
{
    partial class frmRefinanciacionOpinion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefinanciacionOpinion));
            this.dtgSolicitudRefinanciacion = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbOpinion = new GEN.ControlesBase.grbBase(this.components);
            this.txtConclusion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.rbtNO = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtSI = new GEN.ControlesBase.rbtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgIntervinientes = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgCreditosVinculados = new GEN.ControlesBase.dtgBase(this.components);
            this.grbDatosCredito = new GEN.ControlesBase.grbBase(this.components);
            this.txtDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtBuscar = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.btnSig = new System.Windows.Forms.Button();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.txtNroDepositos = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudRefinanciacion)).BeginInit();
            this.grbOpinion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosVinculados)).BeginInit();
            this.grbDatosCredito.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgSolicitudRefinanciacion
            // 
            this.dtgSolicitudRefinanciacion.AllowUserToAddRows = false;
            this.dtgSolicitudRefinanciacion.AllowUserToDeleteRows = false;
            this.dtgSolicitudRefinanciacion.AllowUserToResizeColumns = false;
            this.dtgSolicitudRefinanciacion.AllowUserToResizeRows = false;
            this.dtgSolicitudRefinanciacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgSolicitudRefinanciacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudRefinanciacion.Location = new System.Drawing.Point(16, 28);
            this.dtgSolicitudRefinanciacion.MultiSelect = false;
            this.dtgSolicitudRefinanciacion.Name = "dtgSolicitudRefinanciacion";
            this.dtgSolicitudRefinanciacion.ReadOnly = true;
            this.dtgSolicitudRefinanciacion.RowHeadersVisible = false;
            this.dtgSolicitudRefinanciacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudRefinanciacion.Size = new System.Drawing.Size(658, 134);
            this.dtgSolicitudRefinanciacion.TabIndex = 9;
            this.dtgSolicitudRefinanciacion.SelectionChanged += new System.EventHandler(this.dtgSolicitudRefinanciacion_SelectionChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(344, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(315, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Solicitudes para opinión de gestor de recuperaciones:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(143, 24);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(60, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Decisión:";
            // 
            // grbOpinion
            // 
            this.grbOpinion.Controls.Add(this.txtConclusion);
            this.grbOpinion.Controls.Add(this.lblBase10);
            this.grbOpinion.Controls.Add(this.rbtNO);
            this.grbOpinion.Controls.Add(this.rbtSI);
            this.grbOpinion.Controls.Add(this.lblBase5);
            this.grbOpinion.Enabled = false;
            this.grbOpinion.ForeColor = System.Drawing.Color.Navy;
            this.grbOpinion.Location = new System.Drawing.Point(6, 446);
            this.grbOpinion.Name = "grbOpinion";
            this.grbOpinion.Size = new System.Drawing.Size(665, 132);
            this.grbOpinion.TabIndex = 12;
            this.grbOpinion.TabStop = false;
            this.grbOpinion.Text = "Opinión de Recuperaciones";
            // 
            // txtConclusion
            // 
            this.txtConclusion.Location = new System.Drawing.Point(216, 43);
            this.txtConclusion.MaxLength = 480;
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConclusion.Size = new System.Drawing.Size(433, 84);
            this.txtConclusion.TabIndex = 17;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(143, 46);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(59, 13);
            this.lblBase10.TabIndex = 14;
            this.lblBase10.Text = "Opinión :";
            // 
            // rbtNO
            // 
            this.rbtNO.AutoSize = true;
            this.rbtNO.ForeColor = System.Drawing.Color.Navy;
            this.rbtNO.Location = new System.Drawing.Point(326, 19);
            this.rbtNO.Name = "rbtNO";
            this.rbtNO.Size = new System.Drawing.Size(110, 17);
            this.rbtNO.TabIndex = 13;
            this.rbtNO.Text = "DESFAVORABLE";
            this.rbtNO.UseVisualStyleBackColor = true;
            // 
            // rbtSI
            // 
            this.rbtSI.AutoSize = true;
            this.rbtSI.ForeColor = System.Drawing.Color.Navy;
            this.rbtSI.Location = new System.Drawing.Point(225, 20);
            this.rbtSI.Name = "rbtSI";
            this.rbtSI.Size = new System.Drawing.Size(88, 17);
            this.rbtSI.TabIndex = 12;
            this.rbtSI.Text = "FAVORABLE";
            this.rbtSI.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(7, 58);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(196, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Cuentas de crédito a refinanciar:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(7, 161);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(173, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Intervinientes de la solicitud:";
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Location = new System.Drawing.Point(10, 174);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(658, 93);
            this.dtgIntervinientes.TabIndex = 9;
            // 
            // dtgCreditosVinculados
            // 
            this.dtgCreditosVinculados.AllowUserToAddRows = false;
            this.dtgCreditosVinculados.AllowUserToDeleteRows = false;
            this.dtgCreditosVinculados.AllowUserToResizeColumns = false;
            this.dtgCreditosVinculados.AllowUserToResizeRows = false;
            this.dtgCreditosVinculados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgCreditosVinculados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosVinculados.Location = new System.Drawing.Point(10, 71);
            this.dtgCreditosVinculados.MultiSelect = false;
            this.dtgCreditosVinculados.Name = "dtgCreditosVinculados";
            this.dtgCreditosVinculados.ReadOnly = true;
            this.dtgCreditosVinculados.RowHeadersVisible = false;
            this.dtgCreditosVinculados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosVinculados.Size = new System.Drawing.Size(658, 86);
            this.dtgCreditosVinculados.TabIndex = 9;
            this.dtgCreditosVinculados.SelectionChanged += new System.EventHandler(this.dtgCreditosVinculados_SelectionChanged);
            // 
            // grbDatosCredito
            // 
            this.grbDatosCredito.Controls.Add(this.txtNroDepositos);
            this.grbDatosCredito.Controls.Add(this.lblBase6);
            this.grbDatosCredito.Controls.Add(this.txtDocumento);
            this.grbDatosCredito.Controls.Add(this.txtCodCli);
            this.grbDatosCredito.Controls.Add(this.txtNombre);
            this.grbDatosCredito.Controls.Add(this.lblBase14);
            this.grbDatosCredito.Controls.Add(this.lblBase13);
            this.grbDatosCredito.Controls.Add(this.lblBase12);
            this.grbDatosCredito.Controls.Add(this.dtgCreditosVinculados);
            this.grbDatosCredito.Controls.Add(this.lblBase2);
            this.grbDatosCredito.Controls.Add(this.dtgIntervinientes);
            this.grbDatosCredito.Controls.Add(this.txtDireccion);
            this.grbDatosCredito.Controls.Add(this.lblBase3);
            this.grbDatosCredito.Controls.Add(this.lblBase4);
            this.grbDatosCredito.ForeColor = System.Drawing.Color.Navy;
            this.grbDatosCredito.Location = new System.Drawing.Point(6, 168);
            this.grbDatosCredito.Name = "grbDatosCredito";
            this.grbDatosCredito.Size = new System.Drawing.Size(675, 273);
            this.grbDatosCredito.TabIndex = 8;
            this.grbDatosCredito.TabStop = false;
            this.grbDatosCredito.Text = "Datos del Cliente";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Location = new System.Drawing.Point(360, 9);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(137, 20);
            this.txtDocumento.TabIndex = 15;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Enabled = false;
            this.txtCodCli.Location = new System.Drawing.Point(127, 9);
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(99, 20);
            this.txtCodCli.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(72, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtNombre.Size = new System.Drawing.Size(248, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(9, 36);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(57, 13);
            this.lblBase14.TabIndex = 12;
            this.lblBase14.Text = "Nombre:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(249, 12);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(105, 13);
            this.lblBase13.TabIndex = 11;
            this.lblBase13.Text = "Nro. Documento:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(7, 16);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(114, 13);
            this.lblBase12.TabIndex = 10;
            this.lblBase12.Text = "Código de Cliente:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(324, 36);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(395, 33);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(273, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(464, 584);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(530, 584);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(398, 584);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(595, 584);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(72, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(160, 20);
            this.txtBuscar.TabIndex = 14;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(21, 12);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(51, 13);
            this.lblBase11.TabIndex = 15;
            this.lblBase11.Text = "Buscar:";
            // 
            // btnSig
            // 
            this.btnSig.Location = new System.Drawing.Point(231, 5);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(62, 21);
            this.btnSig.TabIndex = 16;
            this.btnSig.Text = "Siguiente";
            this.btnSig.UseVisualStyleBackColor = true;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(332, 584);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 17;
            this.btnImprimir1.Text = "Expdte";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // txtNroDepositos
            // 
            this.txtNroDepositos.Enabled = false;
            this.txtNroDepositos.Location = new System.Drawing.Point(626, 9);
            this.txtNroDepositos.Name = "txtNroDepositos";
            this.txtNroDepositos.Size = new System.Drawing.Size(42, 20);
            this.txtNroDepositos.TabIndex = 17;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(528, 16);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(92, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Nro Depósitos:";
            // 
            // frmRefinanciacionOpinion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 662);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSig);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.grbOpinion);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgSolicitudRefinanciacion);
            this.Controls.Add(this.grbDatosCredito);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRefinanciacionOpinion";
            this.Text = "Emitir opinión sobre evaluación de refinanciación";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbDatosCredito, 0);
            this.Controls.SetChildIndex(this.dtgSolicitudRefinanciacion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbOpinion, 0);
            this.Controls.SetChildIndex(this.txtBuscar, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.btnSig, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudRefinanciacion)).EndInit();
            this.grbOpinion.ResumeLayout(false);
            this.grbOpinion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosVinculados)).EndInit();
            this.grbDatosCredito.ResumeLayout(false);
            this.grbDatosCredito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgSolicitudRefinanciacion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbOpinion;
        private GEN.ControlesBase.rbtBase rbtNO;
        private GEN.ControlesBase.rbtBase rbtSI;
        private GEN.ControlesBase.txtBase txtConclusion;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgIntervinientes;
        private GEN.ControlesBase.dtgBase dtgCreditosVinculados;
        private GEN.ControlesBase.grbBase grbDatosCredito;
        private GEN.ControlesBase.txtBase txtBuscar;
        private GEN.ControlesBase.lblBase lblBase11;
        private System.Windows.Forms.Button btnSig;
        private GEN.ControlesBase.txtBase txtDocumento;
        private GEN.ControlesBase.txtBase txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.txtBase txtNroDepositos;
        private GEN.ControlesBase.lblBase lblBase6;
    }
}

