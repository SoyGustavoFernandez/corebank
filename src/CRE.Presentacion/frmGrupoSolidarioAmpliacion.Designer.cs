namespace CRE.Presentacion
{
    partial class frmGrupoSolidarioAmpliacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolidarioAmpliacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgCreditoAmpliacion = new System.Windows.Forms.DataGridView();
            this.bsCreditoApliacion = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.idCuentaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIntMoraOtros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoAmpliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoSolAmpliacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTasaCompensatoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaDesembolsoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitudDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditoAmpliacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreditoApliacion)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgCreditoAmpliacion);
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 285);
            this.panel1.TabIndex = 0;
            // 
            // dtgCreditoAmpliacion
            // 
            this.dtgCreditoAmpliacion.AllowUserToAddRows = false;
            this.dtgCreditoAmpliacion.AllowUserToDeleteRows = false;
            this.dtgCreditoAmpliacion.AllowUserToResizeColumns = false;
            this.dtgCreditoAmpliacion.AllowUserToResizeRows = false;
            this.dtgCreditoAmpliacion.AutoGenerateColumns = false;
            this.dtgCreditoAmpliacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCreditoAmpliacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditoAmpliacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCuentaDataGridViewTextBoxColumn1,
            this.idCliDataGridViewTextBoxColumn1,
            this.cClienteDataGridViewTextBoxColumn,
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1,
            this.nSaldoCapital,
            this.nIntMoraOtros,
            this.nMontoAmpliado,
            this.nMontoSolAmpliacion,
            this.nTasaCompensatoriaDataGridViewTextBoxColumn,
            this.cEstadoDataGridViewTextBoxColumn,
            this.dFechaDesembolsoDataGridViewTextBoxColumn1,
            this.idSolicitudDataGridViewTextBoxColumn1,
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn});
            this.dtgCreditoAmpliacion.DataSource = this.bsCreditoApliacion;
            this.dtgCreditoAmpliacion.Location = new System.Drawing.Point(3, 3);
            this.dtgCreditoAmpliacion.Name = "dtgCreditoAmpliacion";
            this.dtgCreditoAmpliacion.RowHeadersVisible = false;
            this.dtgCreditoAmpliacion.Size = new System.Drawing.Size(881, 279);
            this.dtgCreditoAmpliacion.TabIndex = 0;
            this.dtgCreditoAmpliacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreditoAmpliacion_CellEnter);
            this.dtgCreditoAmpliacion.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgCreditoAmpliacion_CellValidating);
            // 
            // bsCreditoApliacion
            // 
            this.bsCreditoApliacion.DataSource = typeof(EntityLayer.clsCreditoGrupoSolInt);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 94);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(574, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Este formulario es informativo, contiene datos del crédito grupal activo, de moda" +
    "lidad principal.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(512, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto Solicitud: monto de la solicitud de ampliación (Saldo Capital + Monto Ampli" +
    "ar).";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(57, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto Ampliar: monto adicional que será entregado al cliente.";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(57, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Capital: capital pendiente de pago, que será cancelado.";
            this.label1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.69197F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.12365F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 461);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Location = new System.Drawing.Point(3, 394);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(887, 64);
            this.panel3.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(732, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(824, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // idCuentaDataGridViewTextBoxColumn1
            // 
            this.idCuentaDataGridViewTextBoxColumn1.DataPropertyName = "idCuenta";
            this.idCuentaDataGridViewTextBoxColumn1.HeaderText = "Cuenta";
            this.idCuentaDataGridViewTextBoxColumn1.Name = "idCuentaDataGridViewTextBoxColumn1";
            this.idCuentaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idCuentaDataGridViewTextBoxColumn1.Width = 66;
            // 
            // idCliDataGridViewTextBoxColumn1
            // 
            this.idCliDataGridViewTextBoxColumn1.DataPropertyName = "idCli";
            this.idCliDataGridViewTextBoxColumn1.HeaderText = "Cod.Cli.";
            this.idCliDataGridViewTextBoxColumn1.Name = "idCliDataGridViewTextBoxColumn1";
            this.idCliDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idCliDataGridViewTextBoxColumn1.Width = 68;
            // 
            // cClienteDataGridViewTextBoxColumn
            // 
            this.cClienteDataGridViewTextBoxColumn.DataPropertyName = "cCliente";
            this.cClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.cClienteDataGridViewTextBoxColumn.Name = "cClienteDataGridViewTextBoxColumn";
            this.cClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cClienteDataGridViewTextBoxColumn.Width = 64;
            // 
            // nCapitalDesembolsoDataGridViewTextBoxColumn1
            // 
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1.DataPropertyName = "nCapitalDesembolso";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "###,###,##0.00";
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1.HeaderText = "Capital Desem.";
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1.Name = "nCapitalDesembolsoDataGridViewTextBoxColumn1";
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nCapitalDesembolsoDataGridViewTextBoxColumn1.Width = 95;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Format = "###,###,##0.00";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nSaldoCapital.DefaultCellStyle = dataGridViewCellStyle2;
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            this.nSaldoCapital.Width = 87;
            // 
            // nIntMoraOtros
            // 
            this.nIntMoraOtros.DataPropertyName = "nIntMoraOtros";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "###,###,##0.00";
            this.nIntMoraOtros.DefaultCellStyle = dataGridViewCellStyle3;
            this.nIntMoraOtros.HeaderText = "Interes Mora Otros";
            this.nIntMoraOtros.Name = "nIntMoraOtros";
            this.nIntMoraOtros.Width = 87;
            // 
            // nMontoAmpliado
            // 
            this.nMontoAmpliado.DataPropertyName = "nMontoAmpliado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Format = "###,###,##0.00";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.nMontoAmpliado.DefaultCellStyle = dataGridViewCellStyle4;
            this.nMontoAmpliado.HeaderText = "Monto Ampliar";
            this.nMontoAmpliado.Name = "nMontoAmpliado";
            this.nMontoAmpliado.ReadOnly = true;
            this.nMontoAmpliado.Visible = false;
            this.nMontoAmpliado.Width = 91;
            // 
            // nMontoSolAmpliacion
            // 
            this.nMontoSolAmpliacion.DataPropertyName = "nMontoSolAmpliacion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.Format = "###,###,##0.00";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.nMontoSolAmpliacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.nMontoSolAmpliacion.HeaderText = "Monto Solicitud";
            this.nMontoSolAmpliacion.Name = "nMontoSolAmpliacion";
            this.nMontoSolAmpliacion.ReadOnly = true;
            this.nMontoSolAmpliacion.Visible = false;
            this.nMontoSolAmpliacion.Width = 96;
            // 
            // nTasaCompensatoriaDataGridViewTextBoxColumn
            // 
            this.nTasaCompensatoriaDataGridViewTextBoxColumn.DataPropertyName = "nTasaCompensatoria";
            this.nTasaCompensatoriaDataGridViewTextBoxColumn.HeaderText = "Tasa";
            this.nTasaCompensatoriaDataGridViewTextBoxColumn.Name = "nTasaCompensatoriaDataGridViewTextBoxColumn";
            this.nTasaCompensatoriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nTasaCompensatoriaDataGridViewTextBoxColumn.Width = 56;
            // 
            // cEstadoDataGridViewTextBoxColumn
            // 
            this.cEstadoDataGridViewTextBoxColumn.DataPropertyName = "cEstado";
            this.cEstadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.cEstadoDataGridViewTextBoxColumn.Name = "cEstadoDataGridViewTextBoxColumn";
            this.cEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cEstadoDataGridViewTextBoxColumn.Width = 65;
            // 
            // dFechaDesembolsoDataGridViewTextBoxColumn1
            // 
            this.dFechaDesembolsoDataGridViewTextBoxColumn1.DataPropertyName = "dFechaDesembolso";
            this.dFechaDesembolsoDataGridViewTextBoxColumn1.HeaderText = "Fec. Desembolso";
            this.dFechaDesembolsoDataGridViewTextBoxColumn1.Name = "dFechaDesembolsoDataGridViewTextBoxColumn1";
            this.dFechaDesembolsoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dFechaDesembolsoDataGridViewTextBoxColumn1.Width = 105;
            // 
            // idSolicitudDataGridViewTextBoxColumn1
            // 
            this.idSolicitudDataGridViewTextBoxColumn1.DataPropertyName = "idSolicitudAnterior";
            this.idSolicitudDataGridViewTextBoxColumn1.HeaderText = "Solicitud";
            this.idSolicitudDataGridViewTextBoxColumn1.Name = "idSolicitudDataGridViewTextBoxColumn1";
            this.idSolicitudDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idSolicitudDataGridViewTextBoxColumn1.Width = 72;
            // 
            // idSolicitudCredGrupoSolDataGridViewTextBoxColumn
            // 
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn.DataPropertyName = "idSolicitudCredGrupoSol";
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn.HeaderText = "Solicitud GS.";
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn.Name = "idSolicitudCredGrupoSolDataGridViewTextBoxColumn";
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn.ReadOnly = true;
            this.idSolicitudCredGrupoSolDataGridViewTextBoxColumn.Width = 86;
            // 
            // frmGrupoSolidarioAmpliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 489);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGrupoSolidarioAmpliacion";
            this.Text = "Crédito Grupal Ampliable";
            this.Load += new System.EventHandler(this.frmGrupoSolidarioAmpliacion_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditoAmpliacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCreditoApliacion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bsCreditoApliacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.DataGridView dtgCreditoAmpliacion;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuentaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCapitalDesembolsoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIntMoraOtros;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoAmpliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoSolAmpliacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTasaCompensatoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaDesembolsoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitudDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitudCredGrupoSolDataGridViewTextBoxColumn;
    }
}