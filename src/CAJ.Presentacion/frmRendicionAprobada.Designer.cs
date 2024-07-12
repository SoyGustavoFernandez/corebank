namespace CAJ.Presentacion
{
    partial class frmRendicionAprobada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRendicionAprobada));
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.dtgComprobantesPago = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnFinalizar1 = new GEN.BotonesBase.btnFinalizar();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgRecibos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetalle = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.dtgResumen = new GEN.ControlesBase.dtgBase(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbCpg = new GEN.ControlesBase.grbBase(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComprobantesPago)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecibos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumen)).BeginInit();
            this.panel2.SuspendLayout();
            this.grbCpg.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCol1
            // 
            this.conBusCol1.cEstado = "0";
            this.conBusCol1.Location = new System.Drawing.Point(12, 3);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(390, 86);
            this.conBusCol1.TabIndex = 2;
            this.conBusCol1.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario);
            // 
            // dtgComprobantesPago
            // 
            this.dtgComprobantesPago.AllowUserToAddRows = false;
            this.dtgComprobantesPago.AllowUserToDeleteRows = false;
            this.dtgComprobantesPago.AllowUserToResizeColumns = false;
            this.dtgComprobantesPago.AllowUserToResizeRows = false;
            this.dtgComprobantesPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgComprobantesPago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgComprobantesPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComprobantesPago.Location = new System.Drawing.Point(16, 19);
            this.dtgComprobantesPago.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtgComprobantesPago.MultiSelect = false;
            this.dtgComprobantesPago.Name = "dtgComprobantesPago";
            this.dtgComprobantesPago.ReadOnly = true;
            this.dtgComprobantesPago.RowHeadersVisible = false;
            this.dtgComprobantesPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComprobantesPago.Size = new System.Drawing.Size(787, 259);
            this.dtgComprobantesPago.TabIndex = 5;
            this.dtgComprobantesPago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgComprobantesPago_CellClick);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(677, 4);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(743, 4);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnFinalizar1
            // 
            this.btnFinalizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinalizar1.BackgroundImage")));
            this.btnFinalizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFinalizar1.Location = new System.Drawing.Point(611, 4);
            this.btnFinalizar1.Name = "btnFinalizar1";
            this.btnFinalizar1.Size = new System.Drawing.Size(60, 50);
            this.btnFinalizar1.TabIndex = 9;
            this.btnFinalizar1.Text = "Finalizar";
            this.btnFinalizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFinalizar1.UseVisualStyleBackColor = true;
            this.btnFinalizar1.Click += new System.EventHandler(this.btnFinalizar1_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgRecibos);
            this.grbBase3.Location = new System.Drawing.Point(4, 3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(800, 112);
            this.grbBase3.TabIndex = 12;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Gastos con Recibo";
            // 
            // dtgRecibos
            // 
            this.dtgRecibos.AllowUserToAddRows = false;
            this.dtgRecibos.AllowUserToDeleteRows = false;
            this.dtgRecibos.AllowUserToResizeColumns = false;
            this.dtgRecibos.AllowUserToResizeRows = false;
            this.dtgRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRecibos.Location = new System.Drawing.Point(12, 19);
            this.dtgRecibos.MultiSelect = false;
            this.dtgRecibos.Name = "dtgRecibos";
            this.dtgRecibos.ReadOnly = true;
            this.dtgRecibos.RowHeadersVisible = false;
            this.dtgRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRecibos.Size = new System.Drawing.Size(787, 89);
            this.dtgRecibos.TabIndex = 5;
            this.dtgRecibos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRecibos_CellClick);
            // 
            // dtgDetalle
            // 
            this.dtgDetalle.AllowUserToAddRows = false;
            this.dtgDetalle.AllowUserToDeleteRows = false;
            this.dtgDetalle.AllowUserToResizeColumns = false;
            this.dtgDetalle.AllowUserToResizeRows = false;
            this.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalle.Location = new System.Drawing.Point(592, 3);
            this.dtgDetalle.MultiSelect = false;
            this.dtgDetalle.Name = "dtgDetalle";
            this.dtgDetalle.ReadOnly = true;
            this.dtgDetalle.RowHeadersVisible = false;
            this.dtgDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalle.Size = new System.Drawing.Size(211, 89);
            this.dtgDetalle.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.txtSolicitud);
            this.panel1.Controls.Add(this.dtgResumen);
            this.panel1.Controls.Add(this.conBusCol1);
            this.panel1.Controls.Add(this.dtgDetalle);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 94);
            this.panel1.TabIndex = 15;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(178, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(60, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Solicitud:";
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Location = new System.Drawing.Point(244, 19);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.ReadOnly = true;
            this.txtSolicitud.Size = new System.Drawing.Size(74, 20);
            this.txtSolicitud.TabIndex = 8;
            // 
            // dtgResumen
            // 
            this.dtgResumen.AllowUserToAddRows = false;
            this.dtgResumen.AllowUserToDeleteRows = false;
            this.dtgResumen.AllowUserToResizeColumns = false;
            this.dtgResumen.AllowUserToResizeRows = false;
            this.dtgResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResumen.Location = new System.Drawing.Point(403, 3);
            this.dtgResumen.MultiSelect = false;
            this.dtgResumen.Name = "dtgResumen";
            this.dtgResumen.ReadOnly = true;
            this.dtgResumen.RowHeadersVisible = false;
            this.dtgResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgResumen.Size = new System.Drawing.Size(183, 89);
            this.dtgResumen.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.grbCpg);
            this.panel2.Location = new System.Drawing.Point(3, 103);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 285);
            this.panel2.TabIndex = 16;
            // 
            // grbCpg
            // 
            this.grbCpg.Controls.Add(this.dtgComprobantesPago);
            this.grbCpg.Location = new System.Drawing.Point(0, 0);
            this.grbCpg.Name = "grbCpg";
            this.grbCpg.Size = new System.Drawing.Size(803, 282);
            this.grbCpg.TabIndex = 20;
            this.grbCpg.TabStop = false;
            this.grbCpg.Text = "Gastos con Comprobantes de Pago";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grbBase3);
            this.panel3.Location = new System.Drawing.Point(3, 391);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(807, 118);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSalir1);
            this.panel4.Controls.Add(this.btnCancelar1);
            this.panel4.Controls.Add(this.btnFinalizar1);
            this.panel4.Location = new System.Drawing.Point(3, 515);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(807, 57);
            this.panel4.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(820, 575);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // frmRendicionAprobada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(820, 597);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmRendicionAprobada";
            this.Text = "Rendición de Viáticos y Entregas a Rendir";
            this.Load += new System.EventHandler(this.frmRendicionAprobada_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgComprobantesPago)).EndInit();
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecibos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grbCpg.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusCol1;
        private GEN.ControlesBase.dtgBase dtgComprobantesPago;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnFinalizar btnFinalizar1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgRecibos;
        private GEN.ControlesBase.dtgBase dtgDetalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GEN.ControlesBase.grbBase grbCpg;
        private GEN.ControlesBase.dtgBase dtgResumen;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtSolicitud;
    }
}