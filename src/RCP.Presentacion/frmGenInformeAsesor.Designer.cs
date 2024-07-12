namespace RCP.Presentacion
{
    partial class frmGenInformeAsesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenInformeAsesor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInfPaseRecuperaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDeudaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreGestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGestorRecupera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(716, 285);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(650, 285);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgCreditos);
            this.grbBase1.Location = new System.Drawing.Point(12, 48);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(764, 231);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Listado de créditos";
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
            this.idCuenta,
            this.idInfPaseRecuperaciones,
            this.cNombre,
            this.nSaldoCapital,
            this.nDeudaTotal,
            this.nAtraso,
            this.cMoneda,
            this.cNombreAge,
            this.cNombreGestor,
            this.idCli,
            this.IdMoneda,
            this.idAgencia,
            this.idSolicitud,
            this.idGestorRecupera});
            this.dtgCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(758, 212);
            this.dtgCreditos.TabIndex = 0;
            // 
            // idCuenta
            // 
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "N° cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            // 
            // idInfPaseRecuperaciones
            // 
            this.idInfPaseRecuperaciones.DataPropertyName = "idInfPaseRecuperaciones";
            this.idInfPaseRecuperaciones.HeaderText = "idInfPaseRecuperaciones";
            this.idInfPaseRecuperaciones.Name = "idInfPaseRecuperaciones";
            this.idInfPaseRecuperaciones.ReadOnly = true;
            this.idInfPaseRecuperaciones.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            dataGridViewCellStyle1.Format = "#,0.00";
            this.nSaldoCapital.DefaultCellStyle = dataGridViewCellStyle1;
            this.nSaldoCapital.HeaderText = "Saldo capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            // 
            // nDeudaTotal
            // 
            this.nDeudaTotal.DataPropertyName = "nDeudaTotal";
            dataGridViewCellStyle2.Format = "#,0.00";
            this.nDeudaTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.nDeudaTotal.HeaderText = "Deuda total";
            this.nDeudaTotal.Name = "nDeudaTotal";
            this.nDeudaTotal.ReadOnly = true;
            // 
            // nAtraso
            // 
            this.nAtraso.DataPropertyName = "nAtraso";
            dataGridViewCellStyle3.Format = "#,0";
            this.nAtraso.DefaultCellStyle = dataGridViewCellStyle3;
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            // 
            // cMoneda
            // 
            this.cMoneda.DataPropertyName = "cMoneda";
            this.cMoneda.HeaderText = "Moneda";
            this.cMoneda.Name = "cMoneda";
            this.cMoneda.ReadOnly = true;
            // 
            // cNombreAge
            // 
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.HeaderText = "Agencia";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            // 
            // cNombreGestor
            // 
            this.cNombreGestor.DataPropertyName = "cNombreGestor";
            this.cNombreGestor.HeaderText = "Gestor";
            this.cNombreGestor.Name = "cNombreGestor";
            this.cNombreGestor.ReadOnly = true;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // IdMoneda
            // 
            this.IdMoneda.DataPropertyName = "IdMoneda";
            this.IdMoneda.HeaderText = "IdMoneda";
            this.IdMoneda.Name = "IdMoneda";
            this.IdMoneda.ReadOnly = true;
            this.IdMoneda.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.HeaderText = "idSolicitud";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Visible = false;
            // 
            // idGestorRecupera
            // 
            this.idGestorRecupera.DataPropertyName = "idGestorRecupera";
            this.idGestorRecupera.HeaderText = "idGestorRecupera";
            this.idGestorRecupera.Name = "idGestorRecupera";
            this.idGestorRecupera.ReadOnly = true;
            this.idGestorRecupera.Visible = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(75, 21);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(326, 21);
            this.cboAgencia.TabIndex = 0;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // frmGenInformeAsesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 366);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmGenInformeAsesor";
            this.Text = "Generar informe de asesor";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInfPaseRecuperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDeudaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreGestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGestorRecupera;
    }
}

