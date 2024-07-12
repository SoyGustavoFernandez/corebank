namespace ADM.Presentacion
{
    partial class frmMantenimientoOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoOperaciones));
            this.cboModulo1 = new GEN.ControlesBase.cboModulo(this.components);
            this.CBModalidad = new System.Windows.Forms.CheckBox();
            this.CBProducto = new System.Windows.Forms.CheckBox();
            this.CBExtractocta = new System.Windows.Forms.CheckBox();
            this.dtgOperaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.txtNombOper = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtCodigoSBS = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtNumDiasVcto = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.chcImpVoucher = new GEN.ControlesBase.chcBase(this.components);
            this.chcSplaft = new System.Windows.Forms.CheckBox();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.CBMoneda = new System.Windows.Forms.CheckBox();
            this.CBVigente = new System.Windows.Forms.CheckBox();
            this.cboTipoAsiento1 = new GEN.ControlesBase.cboTipoAsiento(this.components);
            this.txtImpres = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.chcSplaft = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperaciones)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(103, 12);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(130, 21);
            this.cboModulo1.TabIndex = 0;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // CBModalidad
            // 
            this.CBModalidad.AutoSize = true;
            this.CBModalidad.ForeColor = System.Drawing.Color.Navy;
            this.CBModalidad.Location = new System.Drawing.Point(34, 47);
            this.CBModalidad.Name = "CBModalidad";
            this.CBModalidad.Size = new System.Drawing.Size(109, 17);
            this.CBModalidad.TabIndex = 1;
            this.CBModalidad.Text = "Sujeto a Extornos";
            this.CBModalidad.UseVisualStyleBackColor = true;
            // 
            // CBProducto
            // 
            this.CBProducto.AutoSize = true;
            this.CBProducto.ForeColor = System.Drawing.Color.Navy;
            this.CBProducto.Location = new System.Drawing.Point(34, 70);
            this.CBProducto.Name = "CBProducto";
            this.CBProducto.Size = new System.Drawing.Size(149, 17);
            this.CBProducto.TabIndex = 2;
            this.CBProducto.Text = "Clasificación por Producto";
            this.CBProducto.UseVisualStyleBackColor = true;
            // 
            // CBExtractocta
            // 
            this.CBExtractocta.AutoSize = true;
            this.CBExtractocta.ForeColor = System.Drawing.Color.Navy;
            this.CBExtractocta.Location = new System.Drawing.Point(34, 116);
            this.CBExtractocta.Name = "CBExtractocta";
            this.CBExtractocta.Size = new System.Drawing.Size(175, 17);
            this.CBExtractocta.TabIndex = 3;
            this.CBExtractocta.Text = "Figura en el Extracto de Cuenta";
            this.CBExtractocta.UseVisualStyleBackColor = true;
            // 
            // dtgOperaciones
            // 
            this.dtgOperaciones.AllowUserToAddRows = false;
            this.dtgOperaciones.AllowUserToDeleteRows = false;
            this.dtgOperaciones.AllowUserToResizeColumns = false;
            this.dtgOperaciones.AllowUserToResizeRows = false;
            this.dtgOperaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgOperaciones.Location = new System.Drawing.Point(9, 205);
            this.dtgOperaciones.MultiSelect = false;
            this.dtgOperaciones.Name = "dtgOperaciones";
            this.dtgOperaciones.ReadOnly = true;
            this.dtgOperaciones.RowHeadersVisible = false;
            this.dtgOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOperaciones.Size = new System.Drawing.Size(563, 285);
            this.dtgOperaciones.TabIndex = 6;
            this.dtgOperaciones.SelectionChanged += new System.EventHandler(this.dtgOperaciones_SelectionChanged);
            // 
            // txtNombOper
            // 
            this.txtNombOper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombOper.Location = new System.Drawing.Point(151, 21);
            this.txtNombOper.MaxLength = 50;
            this.txtNombOper.Name = "txtNombOper";
            this.txtNombOper.Size = new System.Drawing.Size(399, 20);
            this.txtNombOper.TabIndex = 0;
            // 
            // txtCodigoSBS
            // 
            this.txtCodigoSBS.Location = new System.Drawing.Point(414, 45);
            this.txtCodigoSBS.MaxLength = 2;
            this.txtCodigoSBS.Name = "txtCodigoSBS";
            this.txtCodigoSBS.Size = new System.Drawing.Size(136, 20);
            this.txtCodigoSBS.TabIndex = 4;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(446, 494);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(248, 494);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(380, 494);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(512, 494);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(31, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Nom. Operación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(302, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(80, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Código SBS:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 15);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(88, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Elegir Módulo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(302, 72);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(100, 13);
            this.lblBase4.TabIndex = 18;
            this.lblBase4.Text = "Tipo de Asiento:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.txtNumDiasVcto);
            this.grbBase1.Controls.Add(this.chcImpVoucher);
            this.grbBase1.Controls.Add(this.chcSplaft);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.CBMoneda);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.cboTipoAsiento1);
            this.grbBase1.Controls.Add(this.txtImpres);
            this.grbBase1.Controls.Add(this.CBExtractocta);
            this.grbBase1.Controls.Add(this.txtNombOper);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.CBModalidad);
            this.grbBase1.Controls.Add(this.CBProducto);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtCodigoSBS);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(9, 41);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(563, 158);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(307, 118);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(173, 13);
            this.lblBase6.TabIndex = 25;
            this.lblBase6.Text = "Dias vcto. solicitudes aprob.:";
            // 
            // txtNumDiasVcto
            // 
            this.txtNumDiasVcto.Location = new System.Drawing.Point(488, 114);
            this.txtNumDiasVcto.MaxLength = 2;
            this.txtNumDiasVcto.Name = "txtNumDiasVcto";
            this.txtNumDiasVcto.Size = new System.Drawing.Size(62, 20);
            this.txtNumDiasVcto.TabIndex = 24;
            // 
            // chcImpVoucher
            // 
            this.chcImpVoucher.AutoSize = true;
            this.chcImpVoucher.Location = new System.Drawing.Point(370, 140);
            this.chcImpVoucher.Name = "chcImpVoucher";
            this.chcImpVoucher.Size = new System.Drawing.Size(110, 17);
            this.chcImpVoucher.TabIndex = 23;
            this.chcImpVoucher.Text = "Imprime voucher?";
            this.chcImpVoucher.UseVisualStyleBackColor = true;
            // 
            // chcSplaft
            // 
            this.chcSplaft.AutoSize = true;
            this.chcSplaft.ForeColor = System.Drawing.Color.Navy;
            this.chcSplaft.Location = new System.Drawing.Point(34, 140);
            this.chcSplaft.Name = "chcSplaft";
            this.chcSplaft.Size = new System.Drawing.Size(190, 17);
            this.chcSplaft.TabIndex = 22;
            this.chcSplaft.Text = "Figura en las operaciones SPLAFT";
            this.chcSplaft.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(302, 95);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(178, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Cant. Impresiones (Voucher):";
            // 
            // CBMoneda
            // 
            this.CBMoneda.AutoSize = true;
            this.CBMoneda.ForeColor = System.Drawing.Color.Navy;
            this.CBMoneda.Location = new System.Drawing.Point(34, 93);
            this.CBMoneda.Name = "CBMoneda";
            this.CBMoneda.Size = new System.Drawing.Size(145, 17);
            this.CBMoneda.TabIndex = 19;
            this.CBMoneda.Text = "Clasificación por Moneda";
            this.CBMoneda.UseVisualStyleBackColor = true;
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(488, 140);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 6;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // cboTipoAsiento1
            // 
            this.cboTipoAsiento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAsiento1.DropDownWidth = 170;
            this.cboTipoAsiento1.FormattingEnabled = true;
            this.cboTipoAsiento1.Location = new System.Drawing.Point(414, 68);
            this.cboTipoAsiento1.Name = "cboTipoAsiento1";
            this.cboTipoAsiento1.Size = new System.Drawing.Size(136, 21);
            this.cboTipoAsiento1.TabIndex = 5;
            // 
            // txtImpres
            // 
            this.txtImpres.Location = new System.Drawing.Point(488, 91);
            this.txtImpres.MaxLength = 2;
            this.txtImpres.Name = "txtImpres";
            this.txtImpres.Size = new System.Drawing.Size(62, 20);
            this.txtImpres.TabIndex = 20;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(314, 494);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // chcSplaft
            // 
            this.chcSplaft.AutoSize = true;
            this.chcSplaft.ForeColor = System.Drawing.Color.Navy;
            this.chcSplaft.Location = new System.Drawing.Point(34, 137);
            this.chcSplaft.Name = "chcSplaft";
            this.chcSplaft.Size = new System.Drawing.Size(190, 17);
            this.chcSplaft.TabIndex = 22;
            this.chcSplaft.Text = "Figura en las operaciones SPLAFT";
            this.chcSplaft.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 572);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgOperaciones);
            this.Controls.Add(this.cboModulo1);
            this.Name = "frmMantenimientoOperaciones";
            this.Text = "Mantenimiento de Operaciones";
            this.Load += new System.EventHandler(this.MantenimientoOperaciones_Load);
            this.Controls.SetChildIndex(this.cboModulo1, 0);
            this.Controls.SetChildIndex(this.dtgOperaciones, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperaciones)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboModulo cboModulo1;
        private System.Windows.Forms.CheckBox CBModalidad;
        private System.Windows.Forms.CheckBox CBProducto;
        private System.Windows.Forms.CheckBox CBExtractocta;
        private GEN.ControlesBase.dtgBase dtgOperaciones;
        private GEN.ControlesBase.txtCBLetra txtNombOper;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigoSBS;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboTipoAsiento cboTipoAsiento1;
        private System.Windows.Forms.CheckBox CBVigente;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.CheckBox CBMoneda;
        private GEN.ControlesBase.txtCBNumerosEnteros txtImpres;
        private System.Windows.Forms.CheckBox chcSplaft;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumDiasVcto;
        private GEN.ControlesBase.chcBase chcImpVoucher;
    }
}