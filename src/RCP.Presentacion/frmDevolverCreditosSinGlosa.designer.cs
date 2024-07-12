namespace RCP.Presentacion
{
    partial class frmDevolverCreditosSinGlosa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolverCreditosSinGlosa));
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.lSeleCta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idAsigCartRecuperaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRecuperador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalCreditos = new GEN.ControlesBase.lblBase();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblPeriodo = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPeriodo1 = new GEN.ControlesBase.cboPeriodo(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lSeleCta,
            this.idAsigCartRecuperaciones,
            this.idCuenta,
            this.idCli,
            this.cCliente,
            this.cSimbolo,
            this.nSaldoCapital,
            this.nAtraso,
            this.cRecuperador});
            this.dtgCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(946, 297);
            this.dtgCreditos.TabIndex = 0;
            // 
            // lSeleCta
            // 
            this.lSeleCta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lSeleCta.DataPropertyName = "lSeleCta";
            this.lSeleCta.FillWeight = 30F;
            this.lSeleCta.HeaderText = "";
            this.lSeleCta.Name = "lSeleCta";
            this.lSeleCta.ReadOnly = true;
            this.lSeleCta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lSeleCta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lSeleCta.Width = 19;
            // 
            // idAsigCartRecuperaciones
            // 
            this.idAsigCartRecuperaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idAsigCartRecuperaciones.DataPropertyName = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones.HeaderText = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones.Name = "idAsigCartRecuperaciones";
            this.idAsigCartRecuperaciones.ReadOnly = true;
            this.idAsigCartRecuperaciones.Visible = false;
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Width = 66;
            // 
            // idCli
            // 
            this.idCli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "Cod.Cli.";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Width = 68;
            // 
            // cCliente
            // 
            this.cCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cCliente.DataPropertyName = "cCliente";
            this.cCliente.HeaderText = "Nombre cliente";
            this.cCliente.Name = "cCliente";
            this.cCliente.ReadOnly = true;
            // 
            // cSimbolo
            // 
            this.cSimbolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSimbolo.DataPropertyName = "cSimbolo";
            this.cSimbolo.HeaderText = "Mon.";
            this.cSimbolo.Name = "cSimbolo";
            this.cSimbolo.ReadOnly = true;
            this.cSimbolo.Width = 56;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            this.nSaldoCapital.Width = 94;
            // 
            // nAtraso
            // 
            this.nAtraso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtraso.DataPropertyName = "nAtraso";
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            this.nAtraso.Width = 62;
            // 
            // cRecuperador
            // 
            this.cRecuperador.DataPropertyName = "cRecuperador";
            this.cRecuperador.HeaderText = "Recuperador";
            this.cRecuperador.Name = "cRecuperador";
            this.cRecuperador.ReadOnly = true;
            // 
            // lblTotalCreditos
            // 
            this.lblTotalCreditos.AutoSize = true;
            this.lblTotalCreditos.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTotalCreditos.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalCreditos.Location = new System.Drawing.Point(12, 352);
            this.lblTotalCreditos.Name = "lblTotalCreditos";
            this.lblTotalCreditos.Size = new System.Drawing.Size(55, 13);
            this.lblTotalCreditos.TabIndex = 3;
            this.lblTotalCreditos.Text = "Créditos";
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(841, 355);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(907, 355);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.Navy;
            this.lblPeriodo.Location = new System.Drawing.Point(12, 9);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(55, 13);
            this.lblPeriodo.TabIndex = 6;
            this.lblPeriodo.Text = "Periodo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgCreditos);
            this.groupBox1.Location = new System.Drawing.Point(15, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 316);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Créditos";
            // 
            // cboPeriodo1
            // 
            this.cboPeriodo1.FormattingEnabled = true;
            this.cboPeriodo1.Location = new System.Drawing.Point(73, 6);
            this.cboPeriodo1.Name = "cboPeriodo1";
            this.cboPeriodo1.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodo1.TabIndex = 0;
            // 
            // frmDevolverCreditosSinGlosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 434);
            this.Controls.Add(this.cboPeriodo1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblTotalCreditos);
            this.Name = "frmDevolverCreditosSinGlosa";
            this.Text = "Devolver Créditos Sin Glosa";
            this.Load += new System.EventHandler(this.frmDevolverCreditosSinGlosa_Load);
            this.Controls.SetChildIndex(this.lblTotalCreditos, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblPeriodo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cboPeriodo1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.ControlesBase.lblBase lblTotalCreditos;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblPeriodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lSeleCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsigCartRecuperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRecuperador;
        private GEN.ControlesBase.cboPeriodo cboPeriodo1;
    }
}