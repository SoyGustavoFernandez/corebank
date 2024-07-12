namespace SER.Presentacion
{
    partial class frmRegistrarComisionGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarComisionGiro));
            this.txtMontoComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgenciaOrigen = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgenciaDestino = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboTipoComision = new System.Windows.Forms.ComboBox();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMontoMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMontoMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbMontos = new System.Windows.Forms.GroupBox();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.lblSimbolo = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtgComisionGiros = new GEN.ControlesBase.dtgBase(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbMontos.SuspendLayout();
            this.pnlMontos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisionGiros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMontoComision
            // 
            this.txtMontoComision.FormatoDecimal = false;
            this.txtMontoComision.Location = new System.Drawing.Point(117, 27);
            this.txtMontoComision.MaxLength = 6;
            this.txtMontoComision.Name = "txtMontoComision";
            this.txtMontoComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoComision.nNumDecimales = 2;
            this.txtMontoComision.nvalor = 0D;
            this.txtMontoComision.Size = new System.Drawing.Size(101, 20);
            this.txtMontoComision.TabIndex = 1;
            this.txtMontoComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoComision.Leave += new System.EventHandler(this.txtMontoComision_Leave);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(7, 7);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 107;
            this.lblBase5.Text = "Agencia Origen:";
            // 
            // cboAgenciaOrigen
            // 
            this.cboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaOrigen.FormattingEnabled = true;
            this.cboAgenciaOrigen.Location = new System.Drawing.Point(109, 3);
            this.cboAgenciaOrigen.Name = "cboAgenciaOrigen";
            this.cboAgenciaOrigen.Size = new System.Drawing.Size(147, 21);
            this.cboAgenciaOrigen.TabIndex = 0;
            this.cboAgenciaOrigen.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaOrigen_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 109;
            this.lblBase1.Text = "Agencia Destino:";
            // 
            // cboAgenciaDestino
            // 
            this.cboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaDestino.FormattingEnabled = true;
            this.cboAgenciaDestino.Location = new System.Drawing.Point(109, 30);
            this.cboAgenciaDestino.Name = "cboAgenciaDestino";
            this.cboAgenciaDestino.Size = new System.Drawing.Size(147, 21);
            this.cboAgenciaDestino.TabIndex = 1;
            this.cboAgenciaDestino.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaDestino_SelectedIndexChanged);
            // 
            // cboTipoComision
            // 
            this.cboTipoComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComision.FormattingEnabled = true;
            this.cboTipoComision.Location = new System.Drawing.Point(117, 3);
            this.cboTipoComision.Name = "cboTipoComision";
            this.cboTipoComision.Size = new System.Drawing.Size(142, 21);
            this.cboTipoComision.TabIndex = 0;
            this.cboTipoComision.SelectedIndexChanged += new System.EventHandler(this.cboTipoComision_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 6);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(111, 13);
            this.lblBase2.TabIndex = 111;
            this.lblBase2.Text = "Tipo de Comisión:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 30);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(103, 13);
            this.lblBase3.TabIndex = 112;
            this.lblBase3.Text = "Monto Comisión:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(14, 19);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(92, 13);
            this.lblBase4.TabIndex = 114;
            this.lblBase4.Text = "Monto mínimo:";
            // 
            // txtMontoMin
            // 
            this.txtMontoMin.FormatoDecimal = false;
            this.txtMontoMin.Location = new System.Drawing.Point(113, 15);
            this.txtMontoMin.MaxLength = 9;
            this.txtMontoMin.Name = "txtMontoMin";
            this.txtMontoMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMin.nNumDecimales = 2;
            this.txtMontoMin.nvalor = 0D;
            this.txtMontoMin.Size = new System.Drawing.Size(99, 20);
            this.txtMontoMin.TabIndex = 1;
            this.txtMontoMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoMin.Leave += new System.EventHandler(this.txtMontoMin_Leave);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(14, 40);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(96, 13);
            this.lblBase6.TabIndex = 116;
            this.lblBase6.Text = "Monto máximo:";
            // 
            // txtMontoMax
            // 
            this.txtMontoMax.FormatoDecimal = false;
            this.txtMontoMax.Location = new System.Drawing.Point(113, 36);
            this.txtMontoMax.MaxLength = 9;
            this.txtMontoMax.Name = "txtMontoMax";
            this.txtMontoMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMax.nNumDecimales = 2;
            this.txtMontoMax.nvalor = 0D;
            this.txtMontoMax.Size = new System.Drawing.Size(99, 20);
            this.txtMontoMax.TabIndex = 2;
            this.txtMontoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoMax.Leave += new System.EventHandler(this.txtMontoMax_Leave);
            // 
            // grbMontos
            // 
            this.grbMontos.BackColor = System.Drawing.SystemColors.Info;
            this.grbMontos.Controls.Add(this.txtMontoMin);
            this.grbMontos.Controls.Add(this.lblBase6);
            this.grbMontos.Controls.Add(this.lblBase4);
            this.grbMontos.Controls.Add(this.txtMontoMax);
            this.grbMontos.Location = new System.Drawing.Point(6, 51);
            this.grbMontos.Name = "grbMontos";
            this.grbMontos.Size = new System.Drawing.Size(249, 61);
            this.grbMontos.TabIndex = 2;
            this.grbMontos.TabStop = false;
            this.grbMontos.Text = "Aplicar a rango de montos ()";
            // 
            // pnlMontos
            // 
            this.pnlMontos.Controls.Add(this.lblSimbolo);
            this.pnlMontos.Controls.Add(this.lblBase3);
            this.pnlMontos.Controls.Add(this.txtMontoComision);
            this.pnlMontos.Controls.Add(this.lblBase2);
            this.pnlMontos.Controls.Add(this.grbMontos);
            this.pnlMontos.Controls.Add(this.cboTipoComision);
            this.pnlMontos.Location = new System.Drawing.Point(275, 2);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(263, 116);
            this.pnlMontos.TabIndex = 2;
            // 
            // lblSimbolo
            // 
            this.lblSimbolo.AutoSize = true;
            this.lblSimbolo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSimbolo.ForeColor = System.Drawing.Color.Navy;
            this.lblSimbolo.Location = new System.Drawing.Point(224, 30);
            this.lblSimbolo.Name = "lblSimbolo";
            this.lblSimbolo.Size = new System.Drawing.Size(19, 13);
            this.lblSimbolo.TabIndex = 126;
            this.lblSimbolo.Text = "%";
            this.lblSimbolo.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(223, 286);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(350, 286);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
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
            this.btnCancelar.Location = new System.Drawing.Point(413, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(476, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboAgenciaOrigen);
            this.panel1.Controls.Add(this.cboMoneda);
            this.panel1.Controls.Add(this.lblBase7);
            this.panel1.Controls.Add(this.lblBase5);
            this.panel1.Controls.Add(this.cboAgenciaDestino);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Location = new System.Drawing.Point(6, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 83);
            this.panel1.TabIndex = 0;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(109, 57);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(147, 21);
            this.cboMoneda.TabIndex = 2;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 60);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(104, 13);
            this.lblBase7.TabIndex = 109;
            this.lblBase7.Text = "Tipo de moneda:";
            // 
            // dtgComisionGiros
            // 
            this.dtgComisionGiros.AllowUserToAddRows = false;
            this.dtgComisionGiros.AllowUserToDeleteRows = false;
            this.dtgComisionGiros.AllowUserToResizeColumns = false;
            this.dtgComisionGiros.AllowUserToResizeRows = false;
            this.dtgComisionGiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgComisionGiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComisionGiros.Location = new System.Drawing.Point(6, 120);
            this.dtgComisionGiros.MultiSelect = false;
            this.dtgComisionGiros.Name = "dtgComisionGiros";
            this.dtgComisionGiros.ReadOnly = true;
            this.dtgComisionGiros.RowHeadersVisible = false;
            this.dtgComisionGiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComisionGiros.Size = new System.Drawing.Size(528, 160);
            this.dtgComisionGiros.TabIndex = 1;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(207, 97);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 130;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(286, 286);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmRegistrarComisionGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 361);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.dtgComisionGiros);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMontos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Name = "frmRegistrarComisionGiro";
            this.Text = "Registrar comisión para envío de Giros";
            this.Load += new System.EventHandler(this.frmRegistrarComisionGiro_Load);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.pnlMontos, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dtgComisionGiros, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.grbMontos.ResumeLayout(false);
            this.grbMontos.PerformLayout();
            this.pnlMontos.ResumeLayout(false);
            this.pnlMontos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisionGiros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtMontoComision;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgenciaOrigen;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencias cboAgenciaDestino;
        private System.Windows.Forms.ComboBox cboTipoComision;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMontoMin;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtMontoMax;
        private System.Windows.Forms.GroupBox grbMontos;
        private System.Windows.Forms.Panel pnlMontos;
        private GEN.ControlesBase.lblBase lblSimbolo;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtgBase dtgComisionGiros;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.BotonesBase.btnEditar btnEditar;
    }
}