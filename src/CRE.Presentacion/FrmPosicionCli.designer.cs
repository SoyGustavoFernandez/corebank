namespace CRE.Presentacion
{
    partial class FrmPosicionCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosicionCli));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImpKardexPagos = new GEN.BotonesBase.btnImprimir();
            this.tbcDatosCredito = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblSaldoEAI = new GEN.ControlesBase.lblBase();
            this.lblEAI = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.txtTipo = new GEN.ControlesBase.txtBase(this.components);
            this.conDatosReprogramacion = new GEN.ControlesBase.conDatosReprogramacion();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtGestorRecuperaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtFechaDesembolso = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMontoDesembolsado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtExpediente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtAsesor = new GEN.ControlesBase.txtBase(this.components);
            this.dtgIntervinientes = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnImpPlanPagos = new GEN.BotonesBase.btnImprimir();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.dtgPlanPagos = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnImprAfectKard = new GEN.BotonesBase.btnImprimir();
            this.dtgPagoKardex = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dtgGastosPendientes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnImpResumenCred = new GEN.BotonesBase.btnImprimir();
            this.cboEstadoCredito = new GEN.ControlesBase.cboEstadoCredito(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnImpUltCred = new GEN.BotonesBase.btnImprimir();
            this.lblClasifInt = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.btnBlanco1 = new GEN.BotonesBase.btnBlanco();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblSegmento = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.tbcDatosCredito.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoKardex)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(530, 84);
            this.conBusCli.TabIndex = 0;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Location = new System.Drawing.Point(12, 140);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(672, 171);
            this.dtgCreditos.TabIndex = 1;
            this.dtgCreditos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreditos_CellContentClick);
            this.dtgCreditos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreditos_RowEnter);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(624, 572);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(558, 572);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImpKardexPagos
            // 
            this.btnImpKardexPagos.BackColor = System.Drawing.SystemColors.Control;
            this.btnImpKardexPagos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpKardexPagos.BackgroundImage")));
            this.btnImpKardexPagos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpKardexPagos.Location = new System.Drawing.Point(601, 144);
            this.btnImpKardexPagos.Name = "btnImpKardexPagos";
            this.btnImpKardexPagos.Size = new System.Drawing.Size(60, 50);
            this.btnImpKardexPagos.TabIndex = 6;
            this.btnImpKardexPagos.Text = "&Imprimir";
            this.btnImpKardexPagos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpKardexPagos.UseVisualStyleBackColor = true;
            this.btnImpKardexPagos.Click += new System.EventHandler(this.btnImpKardexPagos_Click);
            // 
            // tbcDatosCredito
            // 
            this.tbcDatosCredito.Controls.Add(this.tabPage1);
            this.tbcDatosCredito.Controls.Add(this.tabPage2);
            this.tbcDatosCredito.Controls.Add(this.tabPage3);
            this.tbcDatosCredito.Controls.Add(this.tabPage4);
            this.tbcDatosCredito.Location = new System.Drawing.Point(12, 317);
            this.tbcDatosCredito.Name = "tbcDatosCredito";
            this.tbcDatosCredito.SelectedIndex = 0;
            this.tbcDatosCredito.Size = new System.Drawing.Size(672, 249);
            this.tbcDatosCredito.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblSaldoEAI);
            this.tabPage1.Controls.Add(this.lblEAI);
            this.tabPage1.Controls.Add(this.lblBase14);
            this.tabPage1.Controls.Add(this.txtTipo);
            this.tabPage1.Controls.Add(this.conDatosReprogramacion);
            this.tabPage1.Controls.Add(this.lblBase11);
            this.tabPage1.Controls.Add(this.txtGestorRecuperaciones);
            this.tabPage1.Controls.Add(this.lblBase9);
            this.tabPage1.Controls.Add(this.txtMoneda);
            this.tabPage1.Controls.Add(this.lblBase7);
            this.tabPage1.Controls.Add(this.lblBase6);
            this.tabPage1.Controls.Add(this.txtCuenta);
            this.tabPage1.Controls.Add(this.lblBase5);
            this.tabPage1.Controls.Add(this.txtEstado);
            this.tabPage1.Controls.Add(this.lblBase4);
            this.tabPage1.Controls.Add(this.txtFechaDesembolso);
            this.tabPage1.Controls.Add(this.lblBase3);
            this.tabPage1.Controls.Add(this.txtMontoDesembolsado);
            this.tabPage1.Controls.Add(this.lblBase2);
            this.tabPage1.Controls.Add(this.txtExpediente);
            this.tabPage1.Controls.Add(this.lblBase1);
            this.tabPage1.Controls.Add(this.txtAsesor);
            this.tabPage1.Controls.Add(this.dtgIntervinientes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(664, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos del Crédito";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblSaldoEAI
            // 
            this.lblSaldoEAI.AutoSize = true;
            this.lblSaldoEAI.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoEAI.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoEAI.Location = new System.Drawing.Point(494, 54);
            this.lblSaldoEAI.Name = "lblSaldoEAI";
            this.lblSaldoEAI.Size = new System.Drawing.Size(12, 13);
            this.lblSaldoEAI.TabIndex = 22;
            this.lblSaldoEAI.Text = "-";
            // 
            // lblEAI
            // 
            this.lblEAI.AutoSize = true;
            this.lblEAI.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEAI.ForeColor = System.Drawing.Color.Navy;
            this.lblEAI.Location = new System.Drawing.Point(321, 54);
            this.lblEAI.Name = "lblEAI";
            this.lblEAI.Size = new System.Drawing.Size(175, 13);
            this.lblEAI.TabIndex = 21;
            this.lblEAI.Text = "Saldo Efectivo al Instante: S/";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(6, 105);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(36, 13);
            this.lblBase14.TabIndex = 20;
            this.lblBase14.Text = "Tipo:";
            // 
            // txtTipo
            // 
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(173, 102);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(142, 20);
            this.txtTipo.TabIndex = 19;
            // 
            // conDatosReprogramacion
            // 
            this.conDatosReprogramacion.idCuenta = 0;
            this.conDatosReprogramacion.lAlerta = false;
            this.conDatosReprogramacion.lMostrarMontoCuota = false;
            this.conDatosReprogramacion.Location = new System.Drawing.Point(318, 6);
            this.conDatosReprogramacion.Margin = new System.Windows.Forms.Padding(0);
            this.conDatosReprogramacion.Name = "conDatosReprogramacion";
            this.conDatosReprogramacion.Size = new System.Drawing.Size(340, 50);
            this.conDatosReprogramacion.TabIndex = 18;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(5, 202);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(50, 13);
            this.lblBase11.TabIndex = 16;
            this.lblBase11.Text = "Gestor:";
            // 
            // txtGestorRecuperaciones
            // 
            this.txtGestorRecuperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGestorRecuperaciones.Location = new System.Drawing.Point(62, 199);
            this.txtGestorRecuperaciones.Name = "txtGestorRecuperaciones";
            this.txtGestorRecuperaciones.ReadOnly = true;
            this.txtGestorRecuperaciones.Size = new System.Drawing.Size(252, 20);
            this.txtGestorRecuperaciones.TabIndex = 17;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(6, 154);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(56, 13);
            this.lblBase9.TabIndex = 15;
            this.lblBase9.Text = "Moneda:";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(173, 151);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(142, 20);
            this.txtMoneda.TabIndex = 14;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(321, 56);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(91, 13);
            this.lblBase7.TabIndex = 13;
            this.lblBase7.Text = "Intervinientes:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(89, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "N° de Cuenta:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.Location = new System.Drawing.Point(173, 6);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ReadOnly = true;
            this.txtCuenta.Size = new System.Drawing.Size(142, 20);
            this.txtCuenta.TabIndex = 0;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 130);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(117, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Estado del Crédito:";
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(173, 127);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(142, 20);
            this.txtEstado.TabIndex = 4;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 81);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(137, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Fecha de Desembolso:";
            // 
            // txtFechaDesembolso
            // 
            this.txtFechaDesembolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaDesembolso.Location = new System.Drawing.Point(173, 78);
            this.txtFechaDesembolso.Name = "txtFechaDesembolso";
            this.txtFechaDesembolso.ReadOnly = true;
            this.txtFechaDesembolso.Size = new System.Drawing.Size(142, 20);
            this.txtFechaDesembolso.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 57);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(134, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Monto Desembolsado:";
            // 
            // txtMontoDesembolsado
            // 
            this.txtMontoDesembolsado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDesembolsado.Location = new System.Drawing.Point(173, 54);
            this.txtMontoDesembolsado.Name = "txtMontoDesembolsado";
            this.txtMontoDesembolsado.ReadOnly = true;
            this.txtMontoDesembolsado.Size = new System.Drawing.Size(142, 20);
            this.txtMontoDesembolsado.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 33);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(125, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Expediente Anterior:";
            // 
            // txtExpediente
            // 
            this.txtExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpediente.Location = new System.Drawing.Point(173, 30);
            this.txtExpediente.Name = "txtExpediente";
            this.txtExpediente.ReadOnly = true;
            this.txtExpediente.Size = new System.Drawing.Size(142, 20);
            this.txtExpediente.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 178);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Asesor:";
            // 
            // txtAsesor
            // 
            this.txtAsesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsesor.Location = new System.Drawing.Point(63, 175);
            this.txtAsesor.Name = "txtAsesor";
            this.txtAsesor.ReadOnly = true;
            this.txtAsesor.Size = new System.Drawing.Size(252, 20);
            this.txtAsesor.TabIndex = 5;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Location = new System.Drawing.Point(321, 72);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(340, 147);
            this.dtgIntervinientes.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.btnImpPlanPagos);
            this.tabPage2.Controls.Add(this.lblBase15);
            this.tabPage2.Controls.Add(this.dtgPlanPagos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(664, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plan de Pagos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.PaleGreen;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(618, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 17);
            this.pictureBox3.TabIndex = 149;
            this.pictureBox3.TabStop = false;
            // 
            // btnImpPlanPagos
            // 
            this.btnImpPlanPagos.BackColor = System.Drawing.SystemColors.Control;
            this.btnImpPlanPagos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpPlanPagos.BackgroundImage")));
            this.btnImpPlanPagos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpPlanPagos.Location = new System.Drawing.Point(601, 144);
            this.btnImpPlanPagos.Name = "btnImpPlanPagos";
            this.btnImpPlanPagos.Size = new System.Drawing.Size(60, 50);
            this.btnImpPlanPagos.TabIndex = 1;
            this.btnImpPlanPagos.Text = "&Imprimir";
            this.btnImpPlanPagos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpPlanPagos.UseVisualStyleBackColor = true;
            this.btnImpPlanPagos.Click += new System.EventHandler(this.btnImpPlanPagos_Click);
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(605, 26);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(46, 26);
            this.lblBase15.TabIndex = 148;
            this.lblBase15.Text = "Otros\r\nGastos";
            this.lblBase15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgPlanPagos
            // 
            this.dtgPlanPagos.AllowUserToAddRows = false;
            this.dtgPlanPagos.AllowUserToDeleteRows = false;
            this.dtgPlanPagos.AllowUserToResizeColumns = false;
            this.dtgPlanPagos.AllowUserToResizeRows = false;
            this.dtgPlanPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPlanPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanPagos.Location = new System.Drawing.Point(3, 3);
            this.dtgPlanPagos.MultiSelect = false;
            this.dtgPlanPagos.Name = "dtgPlanPagos";
            this.dtgPlanPagos.ReadOnly = true;
            this.dtgPlanPagos.RowHeadersVisible = false;
            this.dtgPlanPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanPagos.Size = new System.Drawing.Size(589, 191);
            this.dtgPlanPagos.TabIndex = 0;
            this.dtgPlanPagos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPlanPagos_CellDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnImprAfectKard);
            this.tabPage3.Controls.Add(this.dtgPagoKardex);
            this.tabPage3.Controls.Add(this.btnImpKardexPagos);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(664, 223);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kardex de Pago";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnImprAfectKard
            // 
            this.btnImprAfectKard.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprAfectKard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprAfectKard.BackgroundImage")));
            this.btnImprAfectKard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprAfectKard.Location = new System.Drawing.Point(601, 88);
            this.btnImprAfectKard.Name = "btnImprAfectKard";
            this.btnImprAfectKard.Size = new System.Drawing.Size(60, 50);
            this.btnImprAfectKard.TabIndex = 7;
            this.btnImprAfectKard.Text = "Afect Kardex / Cuotas";
            this.btnImprAfectKard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprAfectKard.UseVisualStyleBackColor = true;
            this.btnImprAfectKard.Click += new System.EventHandler(this.btnImprAfectKard_Click);
            // 
            // dtgPagoKardex
            // 
            this.dtgPagoKardex.AllowUserToAddRows = false;
            this.dtgPagoKardex.AllowUserToDeleteRows = false;
            this.dtgPagoKardex.AllowUserToResizeColumns = false;
            this.dtgPagoKardex.AllowUserToResizeRows = false;
            this.dtgPagoKardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgPagoKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagoKardex.Location = new System.Drawing.Point(3, 0);
            this.dtgPagoKardex.MultiSelect = false;
            this.dtgPagoKardex.Name = "dtgPagoKardex";
            this.dtgPagoKardex.ReadOnly = true;
            this.dtgPagoKardex.RowHeadersVisible = false;
            this.dtgPagoKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPagoKardex.Size = new System.Drawing.Size(590, 191);
            this.dtgPagoKardex.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dtgGastosPendientes);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(664, 223);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Gastos pendientes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dtgGastosPendientes
            // 
            this.dtgGastosPendientes.AllowUserToAddRows = false;
            this.dtgGastosPendientes.AllowUserToDeleteRows = false;
            this.dtgGastosPendientes.AllowUserToResizeColumns = false;
            this.dtgGastosPendientes.AllowUserToResizeRows = false;
            this.dtgGastosPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgGastosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGastosPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgGastosPendientes.Location = new System.Drawing.Point(3, 3);
            this.dtgGastosPendientes.MultiSelect = false;
            this.dtgGastosPendientes.Name = "dtgGastosPendientes";
            this.dtgGastosPendientes.ReadOnly = true;
            this.dtgGastosPendientes.RowHeadersVisible = false;
            this.dtgGastosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGastosPendientes.Size = new System.Drawing.Size(658, 217);
            this.dtgGastosPendientes.TabIndex = 0;
            // 
            // btnImpResumenCred
            // 
            this.btnImpResumenCred.BackColor = System.Drawing.SystemColors.Control;
            this.btnImpResumenCred.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpResumenCred.BackgroundImage")));
            this.btnImpResumenCred.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpResumenCred.Location = new System.Drawing.Point(12, 572);
            this.btnImpResumenCred.Name = "btnImpResumenCred";
            this.btnImpResumenCred.Size = new System.Drawing.Size(60, 50);
            this.btnImpResumenCred.TabIndex = 3;
            this.btnImpResumenCred.Text = "&Imprimir";
            this.btnImpResumenCred.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpResumenCred.UseVisualStyleBackColor = true;
            this.btnImpResumenCred.Click += new System.EventHandler(this.btnImpResumenCred_Click);
            // 
            // cboEstadoCredito
            // 
            this.cboEstadoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoCredito.FormattingEnabled = true;
            this.cboEstadoCredito.Location = new System.Drawing.Point(134, 113);
            this.cboEstadoCredito.Name = "cboEstadoCredito";
            this.cboEstadoCredito.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoCredito.TabIndex = 7;
            this.cboEstadoCredito.SelectedIndexChanged += new System.EventHandler(this.cboEstadoCredito_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(13, 116);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(115, 13);
            this.lblBase8.TabIndex = 13;
            this.lblBase8.Text = "Seleccione estado:";
            // 
            // btnImpUltCred
            // 
            this.btnImpUltCred.BackColor = System.Drawing.SystemColors.Control;
            this.btnImpUltCred.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpUltCred.BackgroundImage")));
            this.btnImpUltCred.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpUltCred.Location = new System.Drawing.Point(78, 572);
            this.btnImpUltCred.Name = "btnImpUltCred";
            this.btnImpUltCred.Size = new System.Drawing.Size(60, 50);
            this.btnImpUltCred.TabIndex = 14;
            this.btnImpUltCred.Text = "Imprimir útimos créditos";
            this.btnImpUltCred.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpUltCred.UseVisualStyleBackColor = true;
            this.btnImpUltCred.Click += new System.EventHandler(this.btnImpUltCred_Click);
            // 
            // lblClasifInt
            // 
            this.lblClasifInt.AutoSize = true;
            this.lblClasifInt.Font = new System.Drawing.Font("Verdana", 18F);
            this.lblClasifInt.ForeColor = System.Drawing.Color.Navy;
            this.lblClasifInt.Location = new System.Drawing.Point(381, 105);
            this.lblClasifInt.Name = "lblClasifInt";
            this.lblClasifInt.Size = new System.Drawing.Size(61, 29);
            this.lblClasifInt.TabIndex = 15;
            this.lblClasifInt.Text = "AAA";
            this.lblClasifInt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(291, 116);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(93, 13);
            this.lblBase10.TabIndex = 16;
            this.lblBase10.Text = "Clasif. Interna:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(240, 579);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(104, 13);
            this.lblBase12.TabIndex = 17;
            this.lblBase12.Text = "Código de Grupo";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(235, 605);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(109, 13);
            this.lblBase13.TabIndex = 18;
            this.lblBase13.Text = "Nombre de Grupo";
            // 
            // txtBase1
            // 
            this.txtBase1.Location = new System.Drawing.Point(345, 576);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.ReadOnly = true;
            this.txtBase1.Size = new System.Drawing.Size(76, 20);
            this.txtBase1.TabIndex = 19;
            // 
            // txtBase2
            // 
            this.txtBase2.Location = new System.Drawing.Point(345, 602);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.ReadOnly = true;
            this.txtBase2.Size = new System.Drawing.Size(207, 20);
            this.txtBase2.TabIndex = 20;
            // 
            // btnBlanco1
            // 
            this.btnBlanco1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco1.Location = new System.Drawing.Point(144, 572);
            this.btnBlanco1.Name = "btnBlanco1";
            this.btnBlanco1.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco1.TabIndex = 21;
            this.btnBlanco1.Text = "Pos. Integ. de  Interv.";
            this.btnBlanco1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco1.UseVisualStyleBackColor = true;
            this.btnBlanco1.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // lblBase16
            // 
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(548, 12);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(126, 29);
            this.lblBase16.TabIndex = 22;
            this.lblBase16.Text = "Segmento de Cliente :";
            this.lblBase16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSegmento
            // 
            this.lblSegmento.AutoSize = true;
            this.lblSegmento.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegmento.ForeColor = System.Drawing.Color.Navy;
            this.lblSegmento.Location = new System.Drawing.Point(584, 41);
            this.lblSegmento.Name = "lblSegmento";
            this.lblSegmento.Size = new System.Drawing.Size(49, 23);
            this.lblSegmento.TabIndex = 23;
            this.lblSegmento.Text = "AAA";
            this.lblSegmento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPosicionCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 650);
            this.Controls.Add(this.lblSegmento);
            this.Controls.Add(this.lblBase16);
            this.Controls.Add(this.btnBlanco1);
            this.Controls.Add(this.txtBase2);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblClasifInt);
            this.Controls.Add(this.btnImpUltCred);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.cboEstadoCredito);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnImpResumenCred);
            this.Controls.Add(this.tbcDatosCredito);
            this.Controls.Add(this.dtgCreditos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Name = "FrmPosicionCli";
            this.Text = "Historial de créditos del cliente";
            this.Load += new System.EventHandler(this.FrmPosicionCli_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgCreditos, 0);
            this.Controls.SetChildIndex(this.tbcDatosCredito, 0);
            this.Controls.SetChildIndex(this.btnImpResumenCred, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.cboEstadoCredito, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnImpUltCred, 0);
            this.Controls.SetChildIndex(this.lblClasifInt, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.txtBase2, 0);
            this.Controls.SetChildIndex(this.btnBlanco1, 0);
            this.Controls.SetChildIndex(this.lblBase16, 0);
            this.Controls.SetChildIndex(this.lblSegmento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.tbcDatosCredito.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagoKardex)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImpKardexPagos;
        private GEN.ControlesBase.tbcBase tbcDatosCredito;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private GEN.ControlesBase.dtgBase dtgIntervinientes;
        private GEN.ControlesBase.dtgBase dtgPagoKardex;
        private GEN.ControlesBase.dtgBase dtgPlanPagos;
        private GEN.BotonesBase.btnImprimir btnImpPlanPagos;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtCuenta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtFechaDesembolso;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtMontoDesembolsado;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtExpediente;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtAsesor;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnImprimir btnImpResumenCred;
        private GEN.ControlesBase.cboEstadoCredito cboEstadoCredito;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.BotonesBase.btnImprimir btnImpUltCred;
        private GEN.ControlesBase.lblBaseCustom lblClasifInt;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.btnImprimir btnImprAfectKard;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtGestorRecuperaciones;
        private System.Windows.Forms.TabPage tabPage4;
        private GEN.ControlesBase.dtgBase dtgGastosPendientes;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.BotonesBase.btnBlanco btnBlanco1;
        private GEN.ControlesBase.conDatosReprogramacion conDatosReprogramacion;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.txtBase txtTipo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBaseCustom lblSegmento;
        private GEN.ControlesBase.lblBase lblSaldoEAI;
        private GEN.ControlesBase.lblBase lblEAI;
    }
}