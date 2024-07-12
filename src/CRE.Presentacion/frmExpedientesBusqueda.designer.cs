namespace CRE.Presentacion
{
    partial class frmExpedientesBusqueda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedientesBusqueda));
            this.dtgBuscaExp = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFechaRegistroIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoExpediente2 = new GEN.ControlesBase.cboTipoExpediente(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpFechaRegistroFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.cboEstadoExpediente1 = new GEN.ControlesBase.cboEstadoExpediente(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnMiniDetalle1 = new GEN.BotonesBase.btnMiniDetalle(this.components);
            this.dtgDetalleExpediente = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBuscaExp)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleExpediente)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBuscaExp
            // 
            this.dtgBuscaExp.AllowUserToAddRows = false;
            this.dtgBuscaExp.AllowUserToDeleteRows = false;
            this.dtgBuscaExp.AllowUserToResizeColumns = false;
            this.dtgBuscaExp.AllowUserToResizeRows = false;
            this.dtgBuscaExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBuscaExp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBuscaExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBuscaExp.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgBuscaExp.Location = new System.Drawing.Point(6, 211);
            this.dtgBuscaExp.MultiSelect = false;
            this.dtgBuscaExp.Name = "dtgBuscaExp";
            this.dtgBuscaExp.ReadOnly = true;
            this.dtgBuscaExp.RowHeadersVisible = false;
            this.dtgBuscaExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBuscaExp.Size = new System.Drawing.Size(702, 168);
            this.dtgBuscaExp.TabIndex = 16;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 47);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 17;
            this.lblBase1.Text = "Estado:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 195);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(81, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Expedientes:";
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(6, 6);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(625, 104);
            this.conBusCli1.TabIndex = 1;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(322, 47);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(28, 13);
            this.lblBase3.TabIndex = 19;
            this.lblBase3.Text = "De:";
            // 
            // dtpFechaRegistroIni
            // 
            this.dtpFechaRegistroIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRegistroIni.Location = new System.Drawing.Point(356, 47);
            this.dtpFechaRegistroIni.Name = "dtpFechaRegistroIni";
            this.dtpFechaRegistroIni.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaRegistroIni.TabIndex = 5;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoExpediente2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.btnProcesar1);
            this.grbBase1.Controls.Add(this.dtpFechaRegistroFin);
            this.grbBase1.Controls.Add(this.cboAgencia1);
            this.grbBase1.Controls.Add(this.cboEstadoExpediente1);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpFechaRegistroIni);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(8, 116);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(742, 74);
            this.grbBase1.TabIndex = 33;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Expediente";
            // 
            // cboTipoExpediente2
            // 
            this.cboTipoExpediente2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoExpediente2.FormattingEnabled = true;
            this.cboTipoExpediente2.Location = new System.Drawing.Point(436, 17);
            this.cboTipoExpediente2.Name = "cboTipoExpediente2";
            this.cboTipoExpediente2.Size = new System.Drawing.Size(180, 21);
            this.cboTipoExpediente2.TabIndex = 35;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(466, 47);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 42;
            this.lblBase4.Text = "Hasta:";
            // 
            // dtpFechaRegistroFin
            // 
            this.dtpFechaRegistroFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRegistroFin.Location = new System.Drawing.Point(516, 45);
            this.dtpFechaRegistroFin.Name = "dtpFechaRegistroFin";
            this.dtpFechaRegistroFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaRegistroFin.TabIndex = 41;
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(99, 17);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(196, 21);
            this.cboAgencia1.TabIndex = 2;
            // 
            // cboEstadoExpediente1
            // 
            this.cboEstadoExpediente1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoExpediente1.FormattingEnabled = true;
            this.cboEstadoExpediente1.Location = new System.Drawing.Point(99, 44);
            this.cboEstadoExpediente1.Name = "cboEstadoExpediente1";
            this.cboEstadoExpediente1.Size = new System.Drawing.Size(196, 21);
            this.cboEstadoExpediente1.TabIndex = 3;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(322, 20);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(103, 13);
            this.lblBase5.TabIndex = 35;
            this.lblBase5.Text = "Tipo Expediente:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(15, 20);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(57, 13);
            this.lblBase10.TabIndex = 35;
            this.lblBase10.Text = "Agencia:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(690, 627);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(624, 627);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(676, 17);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 6;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnMiniDetalle1
            // 
            this.btnMiniDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDetalle1.BackgroundImage")));
            this.btnMiniDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDetalle1.Location = new System.Drawing.Point(714, 210);
            this.btnMiniDetalle1.Name = "btnMiniDetalle1";
            this.btnMiniDetalle1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDetalle1.TabIndex = 34;
            this.btnMiniDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDetalle1.UseVisualStyleBackColor = true;
            this.btnMiniDetalle1.Click += new System.EventHandler(this.btnMiniDetalle1_Click);
            // 
            // dtgDetalleExpediente
            // 
            this.dtgDetalleExpediente.AllowUserToAddRows = false;
            this.dtgDetalleExpediente.AllowUserToDeleteRows = false;
            this.dtgDetalleExpediente.AllowUserToResizeColumns = false;
            this.dtgDetalleExpediente.AllowUserToResizeRows = false;
            this.dtgDetalleExpediente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgDetalleExpediente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleExpediente.Location = new System.Drawing.Point(6, 406);
            this.dtgDetalleExpediente.MultiSelect = false;
            this.dtgDetalleExpediente.Name = "dtgDetalleExpediente";
            this.dtgDetalleExpediente.ReadOnly = true;
            this.dtgDetalleExpediente.RowHeadersVisible = false;
            this.dtgDetalleExpediente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleExpediente.Size = new System.Drawing.Size(744, 213);
            this.dtgDetalleExpediente.TabIndex = 35;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 390);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(146, 13);
            this.lblBase6.TabIndex = 18;
            this.lblBase6.Text = "Historial del Expediente:";
            // 
            // frmExpedientesBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 702);
            this.Controls.Add(this.dtgDetalleExpediente);
            this.Controls.Add(this.btnMiniDetalle1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtgBuscaExp);
            this.Name = "frmExpedientesBusqueda";
            this.Text = "Busqueda de Expedientes";
            this.Load += new System.EventHandler(this.frmExpedientesBusqueda_Load);
            this.Controls.SetChildIndex(this.dtgBuscaExp, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnMiniDetalle1, 0);
            this.Controls.SetChildIndex(this.dtgDetalleExpediente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBuscaExp)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleExpediente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgBuscaExp;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFechaRegistroIni;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboEstadoExpediente cboEstadoExpediente1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpFechaRegistroFin;
        private GEN.ControlesBase.cboTipoExpediente cboTipoExpediente2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnMiniDetalle btnMiniDetalle1;
        private GEN.ControlesBase.dtgBase dtgDetalleExpediente;
        private GEN.ControlesBase.lblBase lblBase6;

    }
}