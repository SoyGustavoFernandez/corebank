namespace LOG.Presentacion
{
    partial class frmAsientoContableBienes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientoContableBienes));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgCuentaCtb = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoOperacion1 = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.cboTipoBien1 = new GEN.ControlesBase.cboTipoBien(this.components);
            this.cboDestino = new GEN.ControlesBase.cboBase(this.components);
            this.cboModalidadOperac = new GEN.ControlesBase.cboModalidadOperac(this.components);
            this.cboTipoTransaccion1 = new GEN.ControlesBase.cboTipoTransaccion(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbCuentaContable = new GEN.ControlesBase.grbBase(this.components);
            this.btnHaber = new System.Windows.Forms.Button();
            this.btnDebe = new System.Windows.Forms.Button();
            this.txtHaber = new GEN.ControlesBase.txtBase(this.components);
            this.txtDebe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentaCtb)).BeginInit();
            this.grbCuentaContable.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(840, 367);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(642, 367);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
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
            this.btnGrabar1.Location = new System.Drawing.Point(774, 367);
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
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(708, 367);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgCuentaCtb
            // 
            this.dtgCuentaCtb.AllowUserToAddRows = false;
            this.dtgCuentaCtb.AllowUserToDeleteRows = false;
            this.dtgCuentaCtb.AllowUserToResizeColumns = false;
            this.dtgCuentaCtb.AllowUserToResizeRows = false;
            this.dtgCuentaCtb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCuentaCtb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentaCtb.Location = new System.Drawing.Point(12, 26);
            this.dtgCuentaCtb.MultiSelect = false;
            this.dtgCuentaCtb.Name = "dtgCuentaCtb";
            this.dtgCuentaCtb.ReadOnly = true;
            this.dtgCuentaCtb.RowHeadersVisible = false;
            this.dtgCuentaCtb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentaCtb.Size = new System.Drawing.Size(939, 224);
            this.dtgCuentaCtb.TabIndex = 9;
            this.dtgCuentaCtb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCuentaCtb_CellClick);
            this.dtgCuentaCtb.SelectionChanged += new System.EventHandler(this.dtgCuentaCtb_SelectionChanged);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(576, 367);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 11;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 10);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(120, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Cuentas Contables:";
            // 
            // cboTipoOperacion1
            // 
            this.cboTipoOperacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion1.DropDownWidth = 220;
            this.cboTipoOperacion1.FormattingEnabled = true;
            this.cboTipoOperacion1.Location = new System.Drawing.Point(6, 34);
            this.cboTipoOperacion1.Name = "cboTipoOperacion1";
            this.cboTipoOperacion1.Size = new System.Drawing.Size(178, 21);
            this.cboTipoOperacion1.TabIndex = 12;
            // 
            // cboTipoBien1
            // 
            this.cboTipoBien1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien1.DropDownWidth = 160;
            this.cboTipoBien1.Enabled = false;
            this.cboTipoBien1.FormattingEnabled = true;
            this.cboTipoBien1.Location = new System.Drawing.Point(190, 34);
            this.cboTipoBien1.Name = "cboTipoBien1";
            this.cboTipoBien1.Size = new System.Drawing.Size(145, 21);
            this.cboTipoBien1.TabIndex = 13;
            // 
            // cboDestino
            // 
            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(462, 34);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(109, 21);
            this.cboDestino.TabIndex = 15;
            // 
            // cboModalidadOperac
            // 
            this.cboModalidadOperac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadOperac.FormattingEnabled = true;
            this.cboModalidadOperac.Location = new System.Drawing.Point(577, 34);
            this.cboModalidadOperac.Name = "cboModalidadOperac";
            this.cboModalidadOperac.Size = new System.Drawing.Size(90, 21);
            this.cboModalidadOperac.TabIndex = 34;
            // 
            // cboTipoTransaccion1
            // 
            this.cboTipoTransaccion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTransaccion1.FormattingEnabled = true;
            this.cboTipoTransaccion1.Location = new System.Drawing.Point(338, 34);
            this.cboTipoTransaccion1.Name = "cboTipoTransaccion1";
            this.cboTipoTransaccion1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoTransaccion1.TabIndex = 35;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(70, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Operación:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(190, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(83, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Tipo de Bien:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(338, 18);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(123, 13);
            this.lblBase6.TabIndex = 7;
            this.lblBase6.Text = "Tipo de Movimiento:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(464, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(55, 13);
            this.lblBase7.TabIndex = 7;
            this.lblBase7.Text = "Destino:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(574, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(50, 13);
            this.lblBase8.TabIndex = 7;
            this.lblBase8.Text = "Estado:";
            // 
            // grbCuentaContable
            // 
            this.grbCuentaContable.Controls.Add(this.btnHaber);
            this.grbCuentaContable.Controls.Add(this.btnDebe);
            this.grbCuentaContable.Controls.Add(this.txtHaber);
            this.grbCuentaContable.Controls.Add(this.txtDebe);
            this.grbCuentaContable.Controls.Add(this.lblBase4);
            this.grbCuentaContable.Controls.Add(this.cboTipoTransaccion1);
            this.grbCuentaContable.Controls.Add(this.lblBase5);
            this.grbCuentaContable.Controls.Add(this.cboModalidadOperac);
            this.grbCuentaContable.Controls.Add(this.lblBase6);
            this.grbCuentaContable.Controls.Add(this.cboDestino);
            this.grbCuentaContable.Controls.Add(this.lblBase7);
            this.grbCuentaContable.Controls.Add(this.cboTipoBien1);
            this.grbCuentaContable.Controls.Add(this.lblBase10);
            this.grbCuentaContable.Controls.Add(this.lblBase9);
            this.grbCuentaContable.Controls.Add(this.lblBase8);
            this.grbCuentaContable.Controls.Add(this.cboTipoOperacion1);
            this.grbCuentaContable.Controls.Add(this.txtDescripcion);
            this.grbCuentaContable.Controls.Add(this.lblBase11);
            this.grbCuentaContable.Enabled = false;
            this.grbCuentaContable.Location = new System.Drawing.Point(0, 256);
            this.grbCuentaContable.Name = "grbCuentaContable";
            this.grbCuentaContable.Size = new System.Drawing.Size(951, 108);
            this.grbCuentaContable.TabIndex = 36;
            this.grbCuentaContable.TabStop = false;
            this.grbCuentaContable.Text = "Define Cuenta Contable";
            // 
            // btnHaber
            // 
            this.btnHaber.Location = new System.Drawing.Point(927, 32);
            this.btnHaber.Name = "btnHaber";
            this.btnHaber.Size = new System.Drawing.Size(14, 23);
            this.btnHaber.TabIndex = 39;
            this.btnHaber.Text = ":";
            this.btnHaber.UseVisualStyleBackColor = true;
            this.btnHaber.Click += new System.EventHandler(this.btnHaber_Click);
            // 
            // btnDebe
            // 
            this.btnDebe.Location = new System.Drawing.Point(801, 32);
            this.btnDebe.Name = "btnDebe";
            this.btnDebe.Size = new System.Drawing.Size(14, 23);
            this.btnDebe.TabIndex = 39;
            this.btnDebe.Text = ":";
            this.btnDebe.UseVisualStyleBackColor = true;
            this.btnDebe.Click += new System.EventHandler(this.btnDebe_Click);
            // 
            // txtHaber
            // 
            this.txtHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHaber.Location = new System.Drawing.Point(819, 34);
            this.txtHaber.Name = "txtHaber";
            this.txtHaber.ReadOnly = true;
            this.txtHaber.Size = new System.Drawing.Size(111, 20);
            this.txtHaber.TabIndex = 38;
            // 
            // txtDebe
            // 
            this.txtDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebe.Location = new System.Drawing.Point(673, 34);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.ReadOnly = true;
            this.txtDebe.Size = new System.Drawing.Size(129, 20);
            this.txtDebe.TabIndex = 37;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(814, 18);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(46, 13);
            this.lblBase10.TabIndex = 7;
            this.lblBase10.Text = "Haber:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(670, 18);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(42, 13);
            this.lblBase9.TabIndex = 7;
            this.lblBase9.Text = "Debe:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(6, 74);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(453, 30);
            this.txtDescripcion.TabIndex = 36;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(3, 58);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(78, 13);
            this.lblBase11.TabIndex = 7;
            this.lblBase11.Text = "Descripción:";
            // 
            // frmAsientoContableBienes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 449);
            this.Controls.Add(this.grbCuentaContable);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.dtgCuentaCtb);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAsientoContableBienes";
            this.Text = "Cuenta Contable de Bienes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtgCuentaCtb, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.grbCuentaContable, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentaCtb)).EndInit();
            this.grbCuentaContable.ResumeLayout(false);
            this.grbCuentaContable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgCuentaCtb;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion1;
        private GEN.ControlesBase.cboTipoBien cboTipoBien1;
        private GEN.ControlesBase.cboBase cboDestino;
        private GEN.ControlesBase.cboModalidadOperac cboModalidadOperac;
        private GEN.ControlesBase.cboTipoTransaccion cboTipoTransaccion1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbCuentaContable;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtHaber;
        private GEN.ControlesBase.txtBase txtDebe;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private System.Windows.Forms.Button btnHaber;
        private System.Windows.Forms.Button btnDebe;
    }
}

