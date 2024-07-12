namespace DEP.Presentacion
{
    partial class frmRegistroValorados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroValorados));
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.nudLote = new GEN.ControlesBase.nudBase(this.components);
            this.cboTipoValorado = new GEN.ControlesBase.cboTipoValorado(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.nudIniValorado = new GEN.ControlesBase.nudBase(this.components);
            this.nudFinValorado = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.nudCantidad = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.dtgValorado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtTotalValorado = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.txtValoradoErr = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.nudLote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIniValorado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinValorado)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(276, 46);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 92;
            this.lblBase8.Text = "Nro LOTE:";
            // 
            // nudLote
            // 
            this.nudLote.Enabled = false;
            this.nudLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLote.Location = new System.Drawing.Point(345, 42);
            this.nudLote.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.nudLote.Name = "nudLote";
            this.nudLote.Size = new System.Drawing.Size(160, 20);
            this.nudLote.TabIndex = 2;
            // 
            // cboTipoValorado
            // 
            this.cboTipoValorado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValorado.Enabled = false;
            this.cboTipoValorado.FormattingEnabled = true;
            this.cboTipoValorado.Location = new System.Drawing.Point(111, 17);
            this.cboTipoValorado.Name = "cboTipoValorado";
            this.cboTipoValorado.Size = new System.Drawing.Size(160, 21);
            this.cboTipoValorado.TabIndex = 1;
            this.cboTipoValorado.SelectedIndexChanged += new System.EventHandler(this.cboTipoValorado_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(90, 13);
            this.lblBase2.TabIndex = 97;
            this.lblBase2.Text = "Tipo Valorado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(56, 110);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 98;
            this.lblBase1.Text = "Desde:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(248, 110);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(44, 13);
            this.lblBase3.TabIndex = 99;
            this.lblBase3.Text = "Hasta:";
            // 
            // nudIniValorado
            // 
            this.nudIniValorado.Enabled = false;
            this.nudIniValorado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudIniValorado.Location = new System.Drawing.Point(108, 108);
            this.nudIniValorado.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudIniValorado.Name = "nudIniValorado";
            this.nudIniValorado.Size = new System.Drawing.Size(112, 20);
            this.nudIniValorado.TabIndex = 3;
            // 
            // nudFinValorado
            // 
            this.nudFinValorado.Enabled = false;
            this.nudFinValorado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFinValorado.Location = new System.Drawing.Point(298, 108);
            this.nudFinValorado.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudFinValorado.Name = "nudFinValorado";
            this.nudFinValorado.Size = new System.Drawing.Size(122, 20);
            this.nudFinValorado.TabIndex = 4;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(10, 87);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(444, 51);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Folios (Rango)";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.nudCantidad);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.nudLote);
            this.grbBase3.Controls.Add(this.cboMoneda);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(7, 4);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(512, 69);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Enabled = false;
            this.nudCantidad.Location = new System.Drawing.Point(104, 41);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(160, 20);
            this.nudCantidad.TabIndex = 3;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(36, 41);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 123;
            this.lblBase5.Text = "Cantidad:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(286, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 122;
            this.lblBase4.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(345, 15);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(160, 21);
            this.cboMoneda.TabIndex = 0;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // dtgValorado
            // 
            this.dtgValorado.AllowUserToAddRows = false;
            this.dtgValorado.AllowUserToDeleteRows = false;
            this.dtgValorado.AllowUserToResizeColumns = false;
            this.dtgValorado.AllowUserToResizeRows = false;
            this.dtgValorado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValorado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValorado.Location = new System.Drawing.Point(10, 144);
            this.dtgValorado.MultiSelect = false;
            this.dtgValorado.Name = "dtgValorado";
            this.dtgValorado.ReadOnly = true;
            this.dtgValorado.RowHeadersVisible = false;
            this.dtgValorado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValorado.Size = new System.Drawing.Size(510, 240);
            this.dtgValorado.TabIndex = 111;
            this.dtgValorado.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValorado_CellValueChanged);
            this.dtgValorado.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgValorado_CurrentCellDirtyStateChanged);
            this.dtgValorado.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgValorado_EditingControlShowing);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(269, 420);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 6;
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
            this.btnGrabar.Location = new System.Drawing.Point(328, 420);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
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
            this.btnCancelar.Location = new System.Drawing.Point(387, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(460, 420);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(293, 392);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(120, 13);
            this.lblBase6.TabIndex = 117;
            this.lblBase6.Text = "Total Valorados OK:";
            // 
            // txtTotalValorado
            // 
            this.txtTotalValorado.Enabled = false;
            this.txtTotalValorado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalValorado.Location = new System.Drawing.Point(416, 388);
            this.txtTotalValorado.Name = "txtTotalValorado";
            this.txtTotalValorado.Size = new System.Drawing.Size(105, 20);
            this.txtTotalValorado.TabIndex = 120;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(460, 88);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 5;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // txtValoradoErr
            // 
            this.txtValoradoErr.Enabled = false;
            this.txtValoradoErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValoradoErr.ForeColor = System.Drawing.Color.Brown;
            this.txtValoradoErr.Location = new System.Drawing.Point(162, 389);
            this.txtValoradoErr.Name = "txtValoradoErr";
            this.txtValoradoErr.Size = new System.Drawing.Size(94, 20);
            this.txtValoradoErr.TabIndex = 123;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(8, 392);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(153, 13);
            this.lblBase7.TabIndex = 122;
            this.lblBase7.Text = "Total Valorados Dañados:";
            // 
            // frmRegistroValorados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 498);
            this.Controls.Add(this.txtValoradoErr);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.txtTotalValorado);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgValorado);
            this.Controls.Add(this.nudFinValorado);
            this.Controls.Add(this.nudIniValorado);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoValorado);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmRegistroValorados";
            this.Text = "Registro de Valorados";
            this.Load += new System.EventHandler(this.frmRegistroValorados_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoValorado, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.nudIniValorado, 0);
            this.Controls.SetChildIndex(this.nudFinValorado, 0);
            this.Controls.SetChildIndex(this.dtgValorado, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtTotalValorado, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.txtValoradoErr, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudLote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIniValorado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinValorado)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.nudBase nudLote;
        private GEN.ControlesBase.cboTipoValorado cboTipoValorado;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.nudBase nudIniValorado;
        private GEN.ControlesBase.nudBase nudFinValorado;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgValorado;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtCBNumerosEnteros txtTotalValorado;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.nudBase nudCantidad;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.txtCBNumerosEnteros txtValoradoErr;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}