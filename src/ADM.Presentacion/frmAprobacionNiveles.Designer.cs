namespace ADM.Presentacion
{
    partial class frmAprobacionNiveles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionNiveles));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMiniActualizar1 = new GEN.BotonesBase.btnMiniActualizar();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom();
            this.grbBase1 = new GEN.ControlesBase.grbBase();
            this.dtgSolParaAprobar = new GEN.ControlesBase.dtgBase();
            this.btnAprobar1 = new GEN.BotonesBase.btnBuenaPro();
            this.btnDenegar1 = new GEN.BotonesBase.btnDenegar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbResAplicacion = new GEN.ControlesBase.grbBase();
            this.txtSustento = new GEN.ControlesBase.txtBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtNroDocumento = new GEN.ControlesBase.txtBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboProducto = new GEN.ControlesBase.cboProducto();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSol = new GEN.ControlesBase.dtpCorto();
            this.btnDetalle1 = new GEN.BotonesBase.btnDetalle();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboModulo = new GEN.ControlesBase.cboModulo();
            this.cboTipoOperacion = new GEN.ControlesBase.cboTipoOperacion();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNombreCli = new GEN.ControlesBase.txtBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtUsuSol = new GEN.ControlesBase.txtBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase();
            this.txtComentario = new GEN.ControlesBase.txtBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.panel1.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolParaAprobar)).BeginInit();
            this.grbResAplicacion.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnMiniActualizar1);
            this.panel1.Controls.Add(this.lblBaseCustom1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 35);
            this.panel1.TabIndex = 2;
            // 
            // btnMiniActualizar1
            // 
            this.btnMiniActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniActualizar1.BackgroundImage")));
            this.btnMiniActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniActualizar1.Location = new System.Drawing.Point(10, 8);
            this.btnMiniActualizar1.Name = "btnMiniActualizar1";
            this.btnMiniActualizar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniActualizar1.TabIndex = 1;
            this.btnMiniActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniActualizar1.UseVisualStyleBackColor = true;
            this.btnMiniActualizar1.Click += new System.EventHandler(this.btnMiniActualizar1_Click);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.White;
            this.lblBaseCustom1.Location = new System.Drawing.Point(317, 9);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(240, 17);
            this.lblBaseCustom1.TabIndex = 0;
            this.lblBaseCustom1.Text = "BANDEJA DE APROBACIONES";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgSolParaAprobar);
            this.grbBase1.Location = new System.Drawing.Point(4, 20);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(890, 332);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Bandeja de Aprobaciones";
            // 
            // dtgSolParaAprobar
            // 
            this.dtgSolParaAprobar.AllowUserToAddRows = false;
            this.dtgSolParaAprobar.AllowUserToDeleteRows = false;
            this.dtgSolParaAprobar.AllowUserToResizeColumns = false;
            this.dtgSolParaAprobar.AllowUserToResizeRows = false;
            this.dtgSolParaAprobar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolParaAprobar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolParaAprobar.Location = new System.Drawing.Point(8, 19);
            this.dtgSolParaAprobar.MultiSelect = false;
            this.dtgSolParaAprobar.Name = "dtgSolParaAprobar";
            this.dtgSolParaAprobar.ReadOnly = true;
            this.dtgSolParaAprobar.RowHeadersVisible = false;
            this.dtgSolParaAprobar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolParaAprobar.Size = new System.Drawing.Size(876, 307);
            this.dtgSolParaAprobar.TabIndex = 0;
            this.dtgSolParaAprobar.SelectionChanged += new System.EventHandler(this.dtgSolParaAprobar_SelectionChanged);
            // 
            // btnAprobar1
            // 
            this.btnAprobar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar1.BackgroundImage")));
            this.btnAprobar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar1.Location = new System.Drawing.Point(686, 44);
            this.btnAprobar1.Name = "btnAprobar1";
            this.btnAprobar1.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar1.TabIndex = 4;
            this.btnAprobar1.Text = "Aprobar";
            this.btnAprobar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar1.UseVisualStyleBackColor = true;
            this.btnAprobar1.Click += new System.EventHandler(this.btnBuenaPro1_Click);
            // 
            // btnDenegar1
            // 
            this.btnDenegar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar1.BackgroundImage")));
            this.btnDenegar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar1.Location = new System.Drawing.Point(752, 44);
            this.btnDenegar1.Name = "btnDenegar1";
            this.btnDenegar1.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar1.TabIndex = 5;
            this.btnDenegar1.Text = "&Denegar";
            this.btnDenegar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar1.UseVisualStyleBackColor = true;
            this.btnDenegar1.Click += new System.EventHandler(this.btnDenegar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(818, 44);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbResAplicacion
            // 
            this.grbResAplicacion.Controls.Add(this.txtSustento);
            this.grbResAplicacion.Controls.Add(this.lblBase9);
            this.grbResAplicacion.Controls.Add(this.txtNroDocumento);
            this.grbResAplicacion.Controls.Add(this.lblBase8);
            this.grbResAplicacion.Controls.Add(this.lblBase7);
            this.grbResAplicacion.Controls.Add(this.cboProducto);
            this.grbResAplicacion.Controls.Add(this.lblBase6);
            this.grbResAplicacion.Controls.Add(this.cboAgencia);
            this.grbResAplicacion.Controls.Add(this.lblBase5);
            this.grbResAplicacion.Controls.Add(this.dtpFechaSol);
            this.grbResAplicacion.Controls.Add(this.btnDetalle1);
            this.grbResAplicacion.Controls.Add(this.lblBase4);
            this.grbResAplicacion.Controls.Add(this.lblBase3);
            this.grbResAplicacion.Controls.Add(this.cboModulo);
            this.grbResAplicacion.Controls.Add(this.cboTipoOperacion);
            this.grbResAplicacion.Controls.Add(this.lblBase2);
            this.grbResAplicacion.Controls.Add(this.txtNombreCli);
            this.grbResAplicacion.Controls.Add(this.lblBase1);
            this.grbResAplicacion.Controls.Add(this.txtUsuSol);
            this.grbResAplicacion.Location = new System.Drawing.Point(4, 354);
            this.grbResAplicacion.Name = "grbResAplicacion";
            this.grbResAplicacion.Size = new System.Drawing.Size(890, 163);
            this.grbResAplicacion.TabIndex = 8;
            this.grbResAplicacion.TabStop = false;
            this.grbResAplicacion.Text = "Detalle de Aprobación";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(133, 124);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(685, 35);
            this.txtSustento.TabIndex = 18;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(65, 124);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 17;
            this.lblBase9.Text = "Sustento:";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(688, 18);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(196, 20);
            this.txtNroDocumento.TabIndex = 16;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(604, 20);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(77, 13);
            this.lblBase8.TabIndex = 15;
            this.lblBase8.Text = "Documento:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(65, 98);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(62, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Producto:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(133, 95);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(679, 21);
            this.cboProducto.TabIndex = 13;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(355, 72);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(57, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(418, 69);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(241, 21);
            this.cboAgencia.TabIndex = 11;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(30, 72);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(97, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Fecha Solicitud:";
            // 
            // dtpFechaSol
            // 
            this.dtpFechaSol.Location = new System.Drawing.Point(133, 69);
            this.dtpFechaSol.Name = "dtpFechaSol";
            this.dtpFechaSol.Size = new System.Drawing.Size(178, 20);
            this.dtpFechaSol.TabIndex = 9;
            // 
            // btnDetalle1
            // 
            this.btnDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle1.BackgroundImage")));
            this.btnDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle1.Location = new System.Drawing.Point(824, 69);
            this.btnDetalle1.Name = "btnDetalle1";
            this.btnDetalle1.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle1.TabIndex = 8;
            this.btnDetalle1.Text = "&Detallar";
            this.btnDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle1.texto = "&Detallar";
            this.btnDetalle1.UseVisualStyleBackColor = true;
            this.btnDetalle1.Click += new System.EventHandler(this.btnDetalle1_Click);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(314, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(98, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Tipo Operacion:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(52, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Modulo:";
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(133, 18);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(178, 21);
            this.cboModulo.TabIndex = 5;
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(418, 17);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(165, 21);
            this.cboTipoOperacion.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(360, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Cliente:";
            // 
            // txtNombreCli
            // 
            this.txtNombreCli.Location = new System.Drawing.Point(418, 43);
            this.txtNombreCli.Name = "txtNombreCli";
            this.txtNombreCli.Size = new System.Drawing.Size(466, 20);
            this.txtNombreCli.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 46);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(118, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Usuario Solicitante:";
            // 
            // txtUsuSol
            // 
            this.txtUsuSol.Location = new System.Drawing.Point(133, 43);
            this.txtUsuSol.Name = "txtUsuSol";
            this.txtUsuSol.Size = new System.Drawing.Size(178, 20);
            this.txtUsuSol.TabIndex = 0;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtComentario);
            this.grbBase3.Controls.Add(this.btnDenegar1);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.btnAprobar1);
            this.grbBase3.Controls.Add(this.btnSalir1);
            this.grbBase3.Location = new System.Drawing.Point(4, 522);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(890, 100);
            this.grbBase3.TabIndex = 9;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Desición";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(133, 13);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(481, 78);
            this.txtComentario.TabIndex = 20;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(48, 16);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(79, 13);
            this.lblBase10.TabIndex = 19;
            this.lblBase10.Text = "Comentario:";
            // 
            // frmAprobacionNiveles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 659);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbResAplicacion);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmAprobacionNiveles";
            this.Text = "Aprobaciones";
            this.Load += new System.EventHandler(this.frmAprobacionNiveles_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbResAplicacion, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolParaAprobar)).EndInit();
            this.grbResAplicacion.ResumeLayout(false);
            this.grbResAplicacion.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgSolParaAprobar;
        private GEN.BotonesBase.btnBuenaPro btnAprobar1;
        private GEN.BotonesBase.btnDenegar btnDenegar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbResAplicacion;
        private GEN.BotonesBase.btnDetalle btnDetalle1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNombreCli;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtUsuSol;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtpCorto dtpFechaSol;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtNroDocumento;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtComentario;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.btnMiniActualizar btnMiniActualizar1;
    }
}