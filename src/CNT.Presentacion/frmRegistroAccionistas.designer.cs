namespace CNT.Presentacion
{
    partial class frmRegistroAccionistas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroAccionistas));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNroAcciones = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtValNominal = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbGrupo = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoOperacion = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboTipoEmision = new GEN.ControlesBase.cboBase(this.components);
            this.txtCodAccionista = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDescAccionista = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtPorcParticipacion = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFecAdquisicion = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNroFolio = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboTipoAccionesEmp1 = new GEN.ControlesBase.cboTipoAccionesEmp(this.components);
            this.cboTipoAccionEmp1 = new GEN.ControlesBase.cboTipoAccionEmp(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(277, 107);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(103, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Nro de acciones:";
            // 
            // txtNroAcciones
            // 
            this.txtNroAcciones.FormatoDecimal = true;
            this.txtNroAcciones.Location = new System.Drawing.Point(381, 104);
            this.txtNroAcciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroAcciones.Name = "txtNroAcciones";
            this.txtNroAcciones.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNroAcciones.nNumDecimales = 2;
            this.txtNroAcciones.nvalor = 0D;
            this.txtNroAcciones.Size = new System.Drawing.Size(139, 20);
            this.txtNroAcciones.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(277, 22);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(95, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Tipo de Acción:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 156);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(92, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Valor Nominal:";
            // 
            // txtValNominal
            // 
            this.txtValNominal.FormatoDecimal = true;
            this.txtValNominal.Location = new System.Drawing.Point(114, 154);
            this.txtValNominal.Margin = new System.Windows.Forms.Padding(2);
            this.txtValNominal.Name = "txtValNominal";
            this.txtValNominal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValNominal.nNumDecimales = 2;
            this.txtValNominal.nvalor = 0D;
            this.txtValNominal.Size = new System.Drawing.Size(159, 20);
            this.txtValNominal.TabIndex = 8;
            // 
            // grbGrupo
            // 
            this.grbGrupo.Controls.Add(this.cboTipoOperacion);
            this.grbGrupo.Controls.Add(this.lblBase13);
            this.grbGrupo.Controls.Add(this.cboTipoEmision);
            this.grbGrupo.Controls.Add(this.txtCodAccionista);
            this.grbGrupo.Controls.Add(this.lblBase12);
            this.grbGrupo.Controls.Add(this.txtDescAccionista);
            this.grbGrupo.Controls.Add(this.lblBase11);
            this.grbGrupo.Controls.Add(this.txtPorcParticipacion);
            this.grbGrupo.Controls.Add(this.lblBase10);
            this.grbGrupo.Controls.Add(this.lblBase9);
            this.grbGrupo.Controls.Add(this.lblBase8);
            this.grbGrupo.Controls.Add(this.txtObservaciones);
            this.grbGrupo.Controls.Add(this.dtpFecAdquisicion);
            this.grbGrupo.Controls.Add(this.lblBase7);
            this.grbGrupo.Controls.Add(this.txtNroFolio);
            this.grbGrupo.Controls.Add(this.lblBase6);
            this.grbGrupo.Controls.Add(this.cboTipoAccionesEmp1);
            this.grbGrupo.Controls.Add(this.cboTipoAccionEmp1);
            this.grbGrupo.Controls.Add(this.chcVigente);
            this.grbGrupo.Controls.Add(this.lblBase5);
            this.grbGrupo.Controls.Add(this.lblBase4);
            this.grbGrupo.Controls.Add(this.lblBase2);
            this.grbGrupo.Controls.Add(this.lblBase1);
            this.grbGrupo.Controls.Add(this.txtNroAcciones);
            this.grbGrupo.Controls.Add(this.lblBase3);
            this.grbGrupo.Controls.Add(this.txtValNominal);
            this.grbGrupo.Location = new System.Drawing.Point(7, 113);
            this.grbGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.grbGrupo.Name = "grbGrupo";
            this.grbGrupo.Padding = new System.Windows.Forms.Padding(2);
            this.grbGrupo.Size = new System.Drawing.Size(535, 247);
            this.grbGrupo.TabIndex = 1;
            this.grbGrupo.TabStop = false;
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(381, 47);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(140, 21);
            this.cboTipoOperacion.TabIndex = 26;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(277, 49);
            this.lblBase13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(96, 13);
            this.lblBase13.TabIndex = 25;
            this.lblBase13.Text = "Tipo operación:";
            // 
            // cboTipoEmision
            // 
            this.cboTipoEmision.FormattingEnabled = true;
            this.cboTipoEmision.Location = new System.Drawing.Point(114, 104);
            this.cboTipoEmision.Name = "cboTipoEmision";
            this.cboTipoEmision.Size = new System.Drawing.Size(158, 21);
            this.cboTipoEmision.TabIndex = 4;
            // 
            // txtCodAccionista
            // 
            this.txtCodAccionista.Location = new System.Drawing.Point(114, 46);
            this.txtCodAccionista.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodAccionista.MaxLength = 100;
            this.txtCodAccionista.Name = "txtCodAccionista";
            this.txtCodAccionista.Size = new System.Drawing.Size(158, 20);
            this.txtCodAccionista.TabIndex = 2;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(9, 46);
            this.lblBase12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(100, 13);
            this.lblBase12.TabIndex = 24;
            this.lblBase12.Text = "Cod. Accionista:";
            // 
            // txtDescAccionista
            // 
            this.txtDescAccionista.Location = new System.Drawing.Point(114, 73);
            this.txtDescAccionista.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescAccionista.Name = "txtDescAccionista";
            this.txtDescAccionista.Size = new System.Drawing.Size(407, 20);
            this.txtDescAccionista.TabIndex = 3;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(9, 76);
            this.lblBase11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(105, 13);
            this.lblBase11.TabIndex = 22;
            this.lblBase11.Text = "Desc. Accionista:";
            // 
            // txtPorcParticipacion
            // 
            this.txtPorcParticipacion.FormatoDecimal = true;
            this.txtPorcParticipacion.Location = new System.Drawing.Point(114, 129);
            this.txtPorcParticipacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtPorcParticipacion.Name = "txtPorcParticipacion";
            this.txtPorcParticipacion.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcParticipacion.nNumDecimales = 7;
            this.txtPorcParticipacion.nvalor = 0D;
            this.txtPorcParticipacion.Size = new System.Drawing.Size(159, 20);
            this.txtPorcParticipacion.TabIndex = 6;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(9, 133);
            this.lblBase10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(100, 13);
            this.lblBase10.TabIndex = 20;
            this.lblBase10.Text = "% participación:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(9, 104);
            this.lblBase9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(84, 13);
            this.lblBase9.TabIndex = 19;
            this.lblBase9.Text = "Tipo Emisión:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 184);
            this.lblBase8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(96, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(114, 182);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(407, 56);
            this.txtObservaciones.TabIndex = 3;
            // 
            // dtpFecAdquisicion
            // 
            this.dtpFecAdquisicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecAdquisicion.Location = new System.Drawing.Point(394, 159);
            this.dtpFecAdquisicion.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecAdquisicion.Name = "dtpFecAdquisicion";
            this.dtpFecAdquisicion.Size = new System.Drawing.Size(127, 20);
            this.dtpFecAdquisicion.TabIndex = 9;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(277, 161);
            this.lblBase7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(113, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Fecha Adquisicion:";
            // 
            // txtNroFolio
            // 
            this.txtNroFolio.FormatoDecimal = true;
            this.txtNroFolio.Location = new System.Drawing.Point(381, 132);
            this.txtNroFolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroFolio.Name = "txtNroFolio";
            this.txtNroFolio.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNroFolio.nNumDecimales = 0;
            this.txtNroFolio.nvalor = 0D;
            this.txtNroFolio.Size = new System.Drawing.Size(71, 20);
            this.txtNroFolio.TabIndex = 7;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(277, 132);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(62, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Nro Folio:";
            // 
            // cboTipoAccionesEmp1
            // 
            this.cboTipoAccionesEmp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAccionesEmp1.FormattingEnabled = true;
            this.cboTipoAccionesEmp1.Location = new System.Drawing.Point(114, 17);
            this.cboTipoAccionesEmp1.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAccionesEmp1.Name = "cboTipoAccionesEmp1";
            this.cboTipoAccionesEmp1.Size = new System.Drawing.Size(159, 21);
            this.cboTipoAccionesEmp1.TabIndex = 0;
            // 
            // cboTipoAccionEmp1
            // 
            this.cboTipoAccionEmp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAccionEmp1.FormattingEnabled = true;
            this.cboTipoAccionEmp1.Location = new System.Drawing.Point(381, 19);
            this.cboTipoAccionEmp1.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoAccionEmp1.Name = "cboTipoAccionEmp1";
            this.cboTipoAccionEmp1.Size = new System.Drawing.Size(140, 21);
            this.cboTipoAccionEmp1.TabIndex = 1;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(506, 135);
            this.chcVigente.Margin = new System.Windows.Forms.Padding(2);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(15, 14);
            this.chcVigente.TabIndex = 10;
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(451, 135);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(55, 13);
            this.lblBase5.TabIndex = 8;
            this.lblBase5.Text = "Vigente:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 21);
            this.lblBase4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(108, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Tipo de Acciónes:";
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(7, 3);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(535, 105);
            this.conBusCli.TabIndex = 0;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(468, 364);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(340, 364);
            this.btnGrabar1.Margin = new System.Windows.Forms.Padding(2);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(404, 364);
            this.btnCancelar1.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(212, 363);
            this.btnEditar1.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 2;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(276, 364);
            this.btnNuevo1.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(147, 363);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmRegistroAccionistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 438);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.grbGrupo);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRegistroAccionistas";
            this.Text = "Registro de accionistas";
            this.Load += new System.EventHandler(this.frmRegistroAccionistas_Load);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbGrupo, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.grbGrupo.ResumeLayout(false);
            this.grbGrupo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtNroAcciones;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtValNominal;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbGrupo;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboTipoAccionesEmp cboTipoAccionesEmp1;
        private GEN.ControlesBase.cboTipoAccionEmp cboTipoAccionEmp1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.ControlesBase.dtpCorto dtpFecAdquisicion;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtNroFolio;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtCodAccionista;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtDescAccionista;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtPorcParticipacion;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboBase cboTipoEmision;
        private GEN.ControlesBase.cboBase cboTipoOperacion;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}