namespace RCP.Presentacion
{
    partial class frmAsigManualCartera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsigManualCartera));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnMiniImprimir1 = new GEN.BotonesBase.btnMiniImprimir(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgCreditosAsignar = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalSaldoCapitalAsignar = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroCreditosAsignar = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtPeriodoAsignar = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodigoUsuarioAsignar = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMiniImprimir2 = new GEN.BotonesBase.btnMiniImprimir(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgCreditosAsignados = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTotalSaldoCapitalMNAsignado = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroCreditosAsignado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtPeriodoAsignado = new GEN.ControlesBase.txtBase(this.components);
            this.txtUsuarioAsignado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAsignar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAsignados)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 123);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(959, 493);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnMiniImprimir1);
            this.tabPage1.Controls.Add(this.btnMiniAgregar1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(951, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Por Asignar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnMiniImprimir1
            // 
            this.btnMiniImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniImprimir1.BackgroundImage")));
            this.btnMiniImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniImprimir1.Location = new System.Drawing.Point(902, 147);
            this.btnMiniImprimir1.Name = "btnMiniImprimir1";
            this.btnMiniImprimir1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniImprimir1.TabIndex = 4;
            this.btnMiniImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniImprimir1.UseVisualStyleBackColor = true;
            this.btnMiniImprimir1.Click += new System.EventHandler(this.btnMiniImprimir1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(902, 115);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 2;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgCreditosAsignar);
            this.groupBox2.Location = new System.Drawing.Point(7, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(892, 362);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Créditos a asignar";
            // 
            // dtgCreditosAsignar
            // 
            this.dtgCreditosAsignar.AllowUserToAddRows = false;
            this.dtgCreditosAsignar.AllowUserToDeleteRows = false;
            this.dtgCreditosAsignar.AllowUserToResizeColumns = false;
            this.dtgCreditosAsignar.AllowUserToResizeRows = false;
            this.dtgCreditosAsignar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditosAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditosAsignar.Location = new System.Drawing.Point(3, 16);
            this.dtgCreditosAsignar.MultiSelect = false;
            this.dtgCreditosAsignar.Name = "dtgCreditosAsignar";
            this.dtgCreditosAsignar.ReadOnly = true;
            this.dtgCreditosAsignar.RowHeadersVisible = false;
            this.dtgCreditosAsignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosAsignar.Size = new System.Drawing.Size(886, 343);
            this.dtgCreditosAsignar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalSaldoCapitalAsignar);
            this.groupBox1.Controls.Add(this.txtNumeroCreditosAsignar);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.lblBase6);
            this.groupBox1.Controls.Add(this.txtPeriodoAsignar);
            this.groupBox1.Controls.Add(this.txtCodigoUsuarioAsignar);
            this.groupBox1.Controls.Add(this.lblBase7);
            this.groupBox1.Controls.Add(this.lblBase8);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(938, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resumen a asignar";
            // 
            // txtTotalSaldoCapitalAsignar
            // 
            this.txtTotalSaldoCapitalAsignar.Location = new System.Drawing.Point(618, 45);
            this.txtTotalSaldoCapitalAsignar.Name = "txtTotalSaldoCapitalAsignar";
            this.txtTotalSaldoCapitalAsignar.ReadOnly = true;
            this.txtTotalSaldoCapitalAsignar.Size = new System.Drawing.Size(172, 20);
            this.txtTotalSaldoCapitalAsignar.TabIndex = 24;
            this.txtTotalSaldoCapitalAsignar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroCreditosAsignar
            // 
            this.txtNumeroCreditosAsignar.Location = new System.Drawing.Point(618, 20);
            this.txtNumeroCreditosAsignar.Name = "txtNumeroCreditosAsignar";
            this.txtNumeroCreditosAsignar.ReadOnly = true;
            this.txtNumeroCreditosAsignar.Size = new System.Drawing.Size(172, 20);
            this.txtNumeroCreditosAsignar.TabIndex = 23;
            this.txtNumeroCreditosAsignar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(478, 48);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(135, 13);
            this.lblBase5.TabIndex = 22;
            this.lblBase5.Text = "Total saldo capital MN:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(489, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(124, 13);
            this.lblBase6.TabIndex = 21;
            this.lblBase6.Text = "Número de créditos:";
            // 
            // txtPeriodoAsignar
            // 
            this.txtPeriodoAsignar.Location = new System.Drawing.Point(270, 45);
            this.txtPeriodoAsignar.Name = "txtPeriodoAsignar";
            this.txtPeriodoAsignar.ReadOnly = true;
            this.txtPeriodoAsignar.Size = new System.Drawing.Size(172, 20);
            this.txtPeriodoAsignar.TabIndex = 20;
            this.txtPeriodoAsignar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigoUsuarioAsignar
            // 
            this.txtCodigoUsuarioAsignar.Location = new System.Drawing.Point(270, 20);
            this.txtCodigoUsuarioAsignar.Name = "txtCodigoUsuarioAsignar";
            this.txtCodigoUsuarioAsignar.ReadOnly = true;
            this.txtCodigoUsuarioAsignar.Size = new System.Drawing.Size(172, 20);
            this.txtCodigoUsuarioAsignar.TabIndex = 19;
            this.txtCodigoUsuarioAsignar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(209, 48);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(55, 13);
            this.lblBase7.TabIndex = 18;
            this.lblBase7.Text = "Periodo:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(148, 23);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(116, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Código de usuario:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMiniImprimir2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(951, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Asignado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMiniImprimir2
            // 
            this.btnMiniImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniImprimir2.BackgroundImage")));
            this.btnMiniImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniImprimir2.Location = new System.Drawing.Point(904, 114);
            this.btnMiniImprimir2.Name = "btnMiniImprimir2";
            this.btnMiniImprimir2.Size = new System.Drawing.Size(36, 28);
            this.btnMiniImprimir2.TabIndex = 9;
            this.btnMiniImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniImprimir2.UseVisualStyleBackColor = true;
            this.btnMiniImprimir2.Click += new System.EventHandler(this.btnMiniImprimir2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgCreditosAsignados);
            this.groupBox3.Location = new System.Drawing.Point(6, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(892, 362);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Créditos a asignar";
            // 
            // dtgCreditosAsignados
            // 
            this.dtgCreditosAsignados.AllowUserToAddRows = false;
            this.dtgCreditosAsignados.AllowUserToDeleteRows = false;
            this.dtgCreditosAsignados.AllowUserToResizeColumns = false;
            this.dtgCreditosAsignados.AllowUserToResizeRows = false;
            this.dtgCreditosAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditosAsignados.Location = new System.Drawing.Point(3, 16);
            this.dtgCreditosAsignados.MultiSelect = false;
            this.dtgCreditosAsignados.Name = "dtgCreditosAsignados";
            this.dtgCreditosAsignados.ReadOnly = true;
            this.dtgCreditosAsignados.RowHeadersVisible = false;
            this.dtgCreditosAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosAsignados.Size = new System.Drawing.Size(886, 343);
            this.dtgCreditosAsignados.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTotalSaldoCapitalMNAsignado);
            this.groupBox4.Controls.Add(this.txtNumeroCreditosAsignado);
            this.groupBox4.Controls.Add(this.lblBase3);
            this.groupBox4.Controls.Add(this.lblBase4);
            this.groupBox4.Controls.Add(this.txtPeriodoAsignado);
            this.groupBox4.Controls.Add(this.txtUsuarioAsignado);
            this.groupBox4.Controls.Add(this.lblBase2);
            this.groupBox4.Controls.Add(this.lblBase1);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(938, 85);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resumen a asignar";
            // 
            // txtTotalSaldoCapitalMNAsignado
            // 
            this.txtTotalSaldoCapitalMNAsignado.Location = new System.Drawing.Point(597, 47);
            this.txtTotalSaldoCapitalMNAsignado.Name = "txtTotalSaldoCapitalMNAsignado";
            this.txtTotalSaldoCapitalMNAsignado.ReadOnly = true;
            this.txtTotalSaldoCapitalMNAsignado.Size = new System.Drawing.Size(172, 20);
            this.txtTotalSaldoCapitalMNAsignado.TabIndex = 16;
            this.txtTotalSaldoCapitalMNAsignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumeroCreditosAsignado
            // 
            this.txtNumeroCreditosAsignado.Location = new System.Drawing.Point(597, 22);
            this.txtNumeroCreditosAsignado.Name = "txtNumeroCreditosAsignado";
            this.txtNumeroCreditosAsignado.ReadOnly = true;
            this.txtNumeroCreditosAsignado.Size = new System.Drawing.Size(172, 20);
            this.txtNumeroCreditosAsignado.TabIndex = 15;
            this.txtNumeroCreditosAsignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(457, 50);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(135, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Total saldo capital MN:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(468, 25);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(124, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Número de créditos:";
            // 
            // txtPeriodoAsignado
            // 
            this.txtPeriodoAsignado.Location = new System.Drawing.Point(249, 47);
            this.txtPeriodoAsignado.Name = "txtPeriodoAsignado";
            this.txtPeriodoAsignado.ReadOnly = true;
            this.txtPeriodoAsignado.Size = new System.Drawing.Size(172, 20);
            this.txtPeriodoAsignado.TabIndex = 12;
            this.txtPeriodoAsignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsuarioAsignado
            // 
            this.txtUsuarioAsignado.Location = new System.Drawing.Point(249, 22);
            this.txtUsuarioAsignado.Name = "txtUsuarioAsignado";
            this.txtUsuarioAsignado.ReadOnly = true;
            this.txtUsuarioAsignado.Size = new System.Drawing.Size(172, 20);
            this.txtUsuarioAsignado.TabIndex = 11;
            this.txtUsuarioAsignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(188, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Periodo:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(127, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(116, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Código de usuario:";
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(222, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            this.conBusCli1.Click += new System.EventHandler(this.conBusCli1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(908, 622);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(842, 622);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(776, 622);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // frmAsigManualCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 703);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAsigManualCartera";
            this.Text = "Asignación Manual de Cartera";
            this.Load += new System.EventHandler(this.frmAsigManualCartera_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAsignar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosAsignados)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnMiniImprimir btnMiniImprimir1;
        private GEN.BotonesBase.btnMiniImprimir btnMiniImprimir2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private GEN.ControlesBase.txtBase txtTotalSaldoCapitalMNAsignado;
        private GEN.ControlesBase.txtBase txtNumeroCreditosAsignado;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtPeriodoAsignado;
        private GEN.ControlesBase.txtBase txtUsuarioAsignado;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtTotalSaldoCapitalAsignar;
        private GEN.ControlesBase.txtBase txtNumeroCreditosAsignar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtPeriodoAsignar;
        private GEN.ControlesBase.txtBase txtCodigoUsuarioAsignar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtgBase dtgCreditosAsignar;
        private GEN.ControlesBase.dtgBase dtgCreditosAsignados;
    }
}