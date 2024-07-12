namespace CRE.Presentacion
{
    partial class frmAutorizacionPoliza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutorizacionPoliza));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAprobar1 = new GEN.BotonesBase.btnAprobar();
            this.btnDenegar2 = new GEN.BotonesBase.btnDenegar();
            this.tbSustento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAutorizacionPoliza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCapitalSolicitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkExpediente = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.AllowUserToResizeColumns = false;
            this.dgvPendientes.AllowUserToResizeRows = false;
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSolicitud,
            this.idAutorizacionPoliza,
            this.idCli,
            this.cNombreAge,
            this.cProducto,
            this.nCapitalSolicitado,
            this.dFechaRegistro});
            this.dgvPendientes.Location = new System.Drawing.Point(15, 25);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(744, 161);
            this.dgvPendientes.TabIndex = 2;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Solicitudes de Crédito Pendientes de Autorización";
            // 
            // btnAprobar1
            // 
            this.btnAprobar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar1.BackgroundImage")));
            this.btnAprobar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar1.Location = new System.Drawing.Point(605, 28);
            this.btnAprobar1.Name = "btnAprobar1";
            this.btnAprobar1.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar1.TabIndex = 75;
            this.btnAprobar1.Text = "&Aprobar";
            this.btnAprobar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar1.UseVisualStyleBackColor = true;
            this.btnAprobar1.Click += new System.EventHandler(this.btnAprobar1_Click);
            // 
            // btnDenegar2
            // 
            this.btnDenegar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar2.BackgroundImage")));
            this.btnDenegar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar2.Location = new System.Drawing.Point(671, 28);
            this.btnDenegar2.Name = "btnDenegar2";
            this.btnDenegar2.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar2.TabIndex = 76;
            this.btnDenegar2.Text = "&Denegar";
            this.btnDenegar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar2.UseVisualStyleBackColor = true;
            this.btnDenegar2.Click += new System.EventHandler(this.btnDenegar2_Click);
            // 
            // tbSustento
            // 
            this.tbSustento.Location = new System.Drawing.Point(13, 28);
            this.tbSustento.Multiline = true;
            this.tbSustento.Name = "tbSustento";
            this.tbSustento.Size = new System.Drawing.Size(586, 50);
            this.tbSustento.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Sustento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbSustento);
            this.panel1.Controls.Add(this.btnAprobar1);
            this.panel1.Controls.Add(this.btnDenegar2);
            this.panel1.Location = new System.Drawing.Point(15, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 96);
            this.panel1.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Desición - Solicitud ########";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(699, 321);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 83;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idSolicitud.DefaultCellStyle = dataGridViewCellStyle10;
            this.idSolicitud.HeaderText = "ID Solicitud";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // idAutorizacionPoliza
            // 
            this.idAutorizacionPoliza.DataPropertyName = "idAutorizacionPoliza";
            this.idAutorizacionPoliza.HeaderText = "idAutorizacionPoliza";
            this.idAutorizacionPoliza.Name = "idAutorizacionPoliza";
            this.idAutorizacionPoliza.ReadOnly = true;
            this.idAutorizacionPoliza.Visible = false;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // cNombreAge
            // 
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.HeaderText = "Agencia";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            this.cNombreAge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNombreAge.Width = 200;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            this.cProducto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cProducto.Width = 200;
            // 
            // nCapitalSolicitado
            // 
            this.nCapitalSolicitado.DataPropertyName = "nCapitalSolicitado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nCapitalSolicitado.DefaultCellStyle = dataGridViewCellStyle11;
            this.nCapitalSolicitado.HeaderText = "Capital Sol.";
            this.nCapitalSolicitado.Name = "nCapitalSolicitado";
            this.nCapitalSolicitado.ReadOnly = true;
            this.nCapitalSolicitado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dFechaRegistro
            // 
            this.dFechaRegistro.DataPropertyName = "dFechaRegistro";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dFechaRegistro.DefaultCellStyle = dataGridViewCellStyle12;
            this.dFechaRegistro.HeaderText = "Fecha de Solicitud";
            this.dFechaRegistro.Name = "dFechaRegistro";
            this.dFechaRegistro.ReadOnly = true;
            this.dFechaRegistro.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // linkExpediente
            // 
            this.linkExpediente.AutoSize = true;
            this.linkExpediente.Location = new System.Drawing.Point(647, 203);
            this.linkExpediente.Name = "linkExpediente";
            this.linkExpediente.Size = new System.Drawing.Size(111, 13);
            this.linkExpediente.TabIndex = 84;
            this.linkExpediente.TabStop = true;
            this.linkExpediente.Text = "Ver Expediente Virtual";
            this.linkExpediente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmAutorizacionPoliza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 399);
            this.Controls.Add(this.linkExpediente);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPendientes);
            this.Name = "frmAutorizacionPoliza";
            this.Text = "Autorización de Póliza 1093";
            this.Load += new System.EventHandler(this.frmAprobacionPoliza_Load);
            this.Controls.SetChildIndex(this.dgvPendientes, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.linkExpediente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnAprobar btnAprobar1;
        private GEN.BotonesBase.btnDenegar btnDenegar2;
        private System.Windows.Forms.TextBox tbSustento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutorizacionPoliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCapitalSolicitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaRegistro;
        private System.Windows.Forms.LinkLabel linkExpediente;

    }
}