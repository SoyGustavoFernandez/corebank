namespace CNE.Presentacion
{
    partial class frmPDPGestionarComisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDPGestionarComisiones));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.cboPDPEstado = new GEN.ControlesBase.cboPDPEstado(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnExporExcel = new GEN.BotonesBase.btnExporExcel();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.cboPDPEmisor = new GEN.ControlesBase.cboPDPEmisor(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgConsultarComisiones = new GEN.ControlesBase.dtgBase(this.components);
            this.idSetPay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFechaHoraTransaccion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaProc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWinUser1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmisorCorto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComentario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAccion11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarComisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnNuevo);
            this.grbBase1.Controls.Add(this.cboPDPEstado);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.btnExporExcel);
            this.grbBase1.Controls.Add(this.btnConsultar);
            this.grbBase1.Controls.Add(this.cboPDPEmisor);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.dtpFechaFin);
            this.grbBase1.Controls.Add(this.dtpFechaInicio);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(899, 123);
            this.grbBase1.TabIndex = 5;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtro";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(302, 14);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cboPDPEstado
            // 
            this.cboPDPEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPDPEstado.FormattingEnabled = true;
            this.cboPDPEstado.Location = new System.Drawing.Point(109, 41);
            this.cboPDPEstado.Name = "cboPDPEstado";
            this.cboPDPEstado.Size = new System.Drawing.Size(121, 21);
            this.cboPDPEstado.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(52, 44);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Estado:";
            // 
            // btnExporExcel
            // 
            this.btnExporExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel.BackgroundImage")));
            this.btnExporExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel.Location = new System.Drawing.Point(368, 14);
            this.btnExporExcel.Name = "btnExporExcel";
            this.btnExporExcel.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel.TabIndex = 9;
            this.btnExporExcel.Text = "E&xcel";
            this.btnExporExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(236, 14);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboPDPEmisor
            // 
            this.cboPDPEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPDPEmisor.FormattingEnabled = true;
            this.cboPDPEmisor.Location = new System.Drawing.Point(109, 14);
            this.cboPDPEmisor.Name = "cboPDPEmisor";
            this.cboPDPEmisor.Size = new System.Drawing.Size(121, 21);
            this.cboPDPEmisor.TabIndex = 7;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(28, 96);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(75, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Fecha Final:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(20, 71);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(83, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha Inicial:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(52, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Emisor:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(109, 94);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaFin.TabIndex = 4;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(109, 68);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // dtgConsultarComisiones
            // 
            this.dtgConsultarComisiones.AllowUserToAddRows = false;
            this.dtgConsultarComisiones.AllowUserToDeleteRows = false;
            this.dtgConsultarComisiones.AllowUserToResizeColumns = false;
            this.dtgConsultarComisiones.AllowUserToResizeRows = false;
            this.dtgConsultarComisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConsultarComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsultarComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSetPay1,
            this.cFechaHoraTransaccion1,
            this.dFechaProc1,
            this.cWinUser1,
            this.cEmisorCorto1,
            this.nMonto1,
            this.cEstado1,
            this.cComentario1,
            this.cAccion11});
            this.dtgConsultarComisiones.Location = new System.Drawing.Point(12, 141);
            this.dtgConsultarComisiones.MultiSelect = false;
            this.dtgConsultarComisiones.Name = "dtgConsultarComisiones";
            this.dtgConsultarComisiones.ReadOnly = true;
            this.dtgConsultarComisiones.RowHeadersVisible = false;
            this.dtgConsultarComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConsultarComisiones.Size = new System.Drawing.Size(899, 276);
            this.dtgConsultarComisiones.TabIndex = 2;
            this.dtgConsultarComisiones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConsultarComisiones_CellClick);
            this.dtgConsultarComisiones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgConsultarComisiones_CellPainting);
            // 
            // idSetPay1
            // 
            this.idSetPay1.DataPropertyName = "idSetPay";
            this.idSetPay1.HeaderText = "ID";
            this.idSetPay1.Name = "idSetPay1";
            this.idSetPay1.ReadOnly = true;
            // 
            // cFechaHoraTransaccion1
            // 
            this.cFechaHoraTransaccion1.DataPropertyName = "cFechaHoraTransaccion";
            this.cFechaHoraTransaccion1.HeaderText = "Fec.Trans.";
            this.cFechaHoraTransaccion1.Name = "cFechaHoraTransaccion1";
            this.cFechaHoraTransaccion1.ReadOnly = true;
            // 
            // dFechaProc1
            // 
            this.dFechaProc1.DataPropertyName = "dFechaProc";
            this.dFechaProc1.HeaderText = "Fec.Act.";
            this.dFechaProc1.Name = "dFechaProc1";
            this.dFechaProc1.ReadOnly = true;
            // 
            // cWinUser1
            // 
            this.cWinUser1.DataPropertyName = "cWinUser";
            this.cWinUser1.HeaderText = "Usr.Act.";
            this.cWinUser1.Name = "cWinUser1";
            this.cWinUser1.ReadOnly = true;
            // 
            // cEmisorCorto1
            // 
            this.cEmisorCorto1.DataPropertyName = "cEmisorCorto";
            this.cEmisorCorto1.HeaderText = "Emisor";
            this.cEmisorCorto1.Name = "cEmisorCorto1";
            this.cEmisorCorto1.ReadOnly = true;
            // 
            // nMonto1
            // 
            this.nMonto1.DataPropertyName = "nMonto";
            this.nMonto1.HeaderText = "Monto";
            this.nMonto1.Name = "nMonto1";
            this.nMonto1.ReadOnly = true;
            // 
            // cEstado1
            // 
            this.cEstado1.DataPropertyName = "cEstado";
            this.cEstado1.HeaderText = "Est.Cobro";
            this.cEstado1.Name = "cEstado1";
            this.cEstado1.ReadOnly = true;
            // 
            // cComentario1
            // 
            this.cComentario1.DataPropertyName = "cComentario";
            this.cComentario1.HeaderText = "Comentario";
            this.cComentario1.Name = "cComentario1";
            this.cComentario1.ReadOnly = true;
            // 
            // cAccion11
            // 
            this.cAccion11.DataPropertyName = "cAccion11";
            this.cAccion11.HeaderText = " ";
            this.cAccion11.Name = "cAccion11";
            this.cAccion11.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(851, 423);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmPDPGestionarComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 503);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgConsultarComisiones);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmPDPGestionarComisiones";
            this.Text = "Gestionar Comisiones";
            this.Load += new System.EventHandler(this.frmPDPGestionarComisiones_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgConsultarComisiones, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsultarComisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboPDPEstado cboPDPEstado;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnExporExcel btnExporExcel;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.ControlesBase.cboPDPEmisor cboPDPEmisor;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.dtgBase dtgConsultarComisiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSetPay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFechaHoraTransaccion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaProc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWinUser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmisorCorto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComentario1;
        private System.Windows.Forms.DataGridViewButtonColumn cAccion11;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
    }
}