namespace SER.Presentacion
{
    partial class frmMantDeTarifarioGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantDeTarifarioGiro));
            this.grbMantenimientoTarifario = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoPersona = new GEN.ControlesBase.cboTipoPersonaBusqueda(this.components);
            this.cboMontos = new GEN.ControlesBase.cboMontos(this.components);
            this.chcEstado = new GEN.ControlesBase.chcBase(this.components);
            this.cboTipoGiroTarifario = new GEN.ControlesBase.cboTipoGiroTarifario(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMontoComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipoComisionGiro = new GEN.ControlesBase.cboTipoComisionGiro(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.dtgTarifario = new GEN.ControlesBase.dtgBase(this.components);
            this.grbMantenimientoTarifario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTarifario)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMantenimientoTarifario
            // 
            this.grbMantenimientoTarifario.Controls.Add(this.cboTipoPersona);
            this.grbMantenimientoTarifario.Controls.Add(this.cboMontos);
            this.grbMantenimientoTarifario.Controls.Add(this.chcEstado);
            this.grbMantenimientoTarifario.Controls.Add(this.cboTipoGiroTarifario);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase9);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase7);
            this.grbMantenimientoTarifario.Controls.Add(this.txtMontoComision);
            this.grbMantenimientoTarifario.Controls.Add(this.cboTipoComisionGiro);
            this.grbMantenimientoTarifario.Controls.Add(this.cboMoneda);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase6);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase5);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase2);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase3);
            this.grbMantenimientoTarifario.Controls.Add(this.lblBase1);
            this.grbMantenimientoTarifario.Location = new System.Drawing.Point(109, 4);
            this.grbMantenimientoTarifario.Name = "grbMantenimientoTarifario";
            this.grbMantenimientoTarifario.Size = new System.Drawing.Size(776, 154);
            this.grbMantenimientoTarifario.TabIndex = 1;
            this.grbMantenimientoTarifario.TabStop = false;
            this.grbMantenimientoTarifario.Text = "Datos del Tarifario";
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(121, 60);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(227, 21);
            this.cboTipoPersona.TabIndex = 1;
            // 
            // cboMontos
            // 
            this.cboMontos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMontos.FormattingEnabled = true;
            this.cboMontos.Location = new System.Drawing.Point(546, 86);
            this.cboMontos.Name = "cboMontos";
            this.cboMontos.Size = new System.Drawing.Size(214, 21);
            this.cboMontos.TabIndex = 5;
            // 
            // chcEstado
            // 
            this.chcEstado.AutoSize = true;
            this.chcEstado.Location = new System.Drawing.Point(547, 118);
            this.chcEstado.Name = "chcEstado";
            this.chcEstado.Size = new System.Drawing.Size(117, 17);
            this.chcEstado.TabIndex = 6;
            this.chcEstado.Text = "Estado del Tarifario";
            this.chcEstado.UseVisualStyleBackColor = true;
            // 
            // cboTipoGiroTarifario
            // 
            this.cboTipoGiroTarifario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGiroTarifario.FormattingEnabled = true;
            this.cboTipoGiroTarifario.Location = new System.Drawing.Point(121, 87);
            this.cboTipoGiroTarifario.Name = "cboTipoGiroTarifario";
            this.cboTipoGiroTarifario.Size = new System.Drawing.Size(227, 21);
            this.cboTipoGiroTarifario.TabIndex = 2;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(369, 179);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(0, 13);
            this.lblBase9.TabIndex = 9;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 90);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(85, 13);
            this.lblBase7.TabIndex = 12;
            this.lblBase7.Text = "Tipo tarifario:";
            // 
            // txtMontoComision
            // 
            this.txtMontoComision.FormatoDecimal = false;
            this.txtMontoComision.Location = new System.Drawing.Point(546, 60);
            this.txtMontoComision.Name = "txtMontoComision";
            this.txtMontoComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoComision.nNumDecimales = 4;
            this.txtMontoComision.nvalor = 0D;
            this.txtMontoComision.Size = new System.Drawing.Size(214, 20);
            this.txtMontoComision.TabIndex = 4;
            // 
            // cboTipoComisionGiro
            // 
            this.cboTipoComisionGiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComisionGiro.FormattingEnabled = true;
            this.cboTipoComisionGiro.Location = new System.Drawing.Point(546, 33);
            this.cboTipoComisionGiro.Name = "cboTipoComisionGiro";
            this.cboTipoComisionGiro.Size = new System.Drawing.Size(214, 21);
            this.cboTipoComisionGiro.TabIndex = 3;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(121, 33);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(227, 21);
            this.cboMoneda.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(440, 63);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(100, 13);
            this.lblBase6.TabIndex = 5;
            this.lblBase6.Text = "Monto comisión:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(440, 36);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(90, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Tipo comisión:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 60);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(86, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Tipo persona:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(440, 90);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(88, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Rango monto:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(86, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo moneda:";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(530, 388);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 0;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(596, 388);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(662, 388);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(728, 388);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(464, 388);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 5;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // dtgTarifario
            // 
            this.dtgTarifario.AllowUserToAddRows = false;
            this.dtgTarifario.AllowUserToDeleteRows = false;
            this.dtgTarifario.AllowUserToResizeColumns = false;
            this.dtgTarifario.AllowUserToResizeRows = false;
            this.dtgTarifario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTarifario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTarifario.Location = new System.Drawing.Point(12, 164);
            this.dtgTarifario.MultiSelect = false;
            this.dtgTarifario.Name = "dtgTarifario";
            this.dtgTarifario.ReadOnly = true;
            this.dtgTarifario.RowHeadersVisible = false;
            this.dtgTarifario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTarifario.Size = new System.Drawing.Size(960, 218);
            this.dtgTarifario.TabIndex = 4;
            this.dtgTarifario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTarifario_CellContentClick);
            this.dtgTarifario.SelectionChanged += new System.EventHandler(this.dtgTarifario_SelectionChanged);
            // 
            // frmMantDeTarifarioGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 463);
            this.Controls.Add(this.dtgTarifario);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbMantenimientoTarifario);
            this.Name = "frmMantDeTarifarioGiro";
            this.Text = "Mantenimiento de Tarifarios";
            this.Load += new System.EventHandler(this.frmMantDeTarifarioGiro_Load);
            this.Controls.SetChildIndex(this.grbMantenimientoTarifario, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.dtgTarifario, 0);
            this.grbMantenimientoTarifario.ResumeLayout(false);
            this.grbMantenimientoTarifario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTarifario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.ControlesBase.grbBase grbMantenimientoTarifario;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMontoComision;
        private GEN.ControlesBase.cboTipoComisionGiro cboTipoComisionGiro;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboTipoGiroTarifario cboTipoGiroTarifario;
        private GEN.ControlesBase.dtgBase dtgTarifario;
        private GEN.ControlesBase.chcBase chcEstado;
        private GEN.ControlesBase.cboMontos cboMontos;
        private GEN.ControlesBase.cboTipoPersonaBusqueda cboTipoPersona;
    }
}