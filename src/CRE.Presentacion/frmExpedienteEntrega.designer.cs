namespace CRE.Presentacion
{
    partial class frmExpedienteEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedienteEntrega));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtFechaEnt = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtgDetalleSolExp = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtDescripMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNroExpEnt = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.dtgListaSolExp = new GEN.ControlesBase.dtgBase(this.components);
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rbBusqGeneral = new System.Windows.Forms.RadioButton();
            this.rbBusquedaPerson = new System.Windows.Forms.RadioButton();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEntregado1 = new GEN.BotonesBase.btnEntregado();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.btnDenegar1 = new GEN.BotonesBase.btnDenegar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboPerfilesExp = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleSolExp)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSolExp)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 33);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(111, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Fecha de Entrega:";
            // 
            // dtFechaEnt
            // 
            this.dtFechaEnt.Enabled = false;
            this.dtFechaEnt.Location = new System.Drawing.Point(6, 59);
            this.dtFechaEnt.Name = "dtFechaEnt";
            this.dtFechaEnt.Size = new System.Drawing.Size(217, 20);
            this.dtFechaEnt.TabIndex = 11;
            // 
            // dtgDetalleSolExp
            // 
            this.dtgDetalleSolExp.AllowUserToAddRows = false;
            this.dtgDetalleSolExp.AllowUserToDeleteRows = false;
            this.dtgDetalleSolExp.AllowUserToResizeColumns = false;
            this.dtgDetalleSolExp.AllowUserToResizeRows = false;
            this.dtgDetalleSolExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgDetalleSolExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleSolExp.Location = new System.Drawing.Point(243, 349);
            this.dtgDetalleSolExp.MultiSelect = false;
            this.dtgDetalleSolExp.Name = "dtgDetalleSolExp";
            this.dtgDetalleSolExp.ReadOnly = true;
            this.dtgDetalleSolExp.RowHeadersVisible = false;
            this.dtgDetalleSolExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleSolExp.Size = new System.Drawing.Size(591, 151);
            this.dtgDetalleSolExp.TabIndex = 12;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtDescripMotivo);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNroExpEnt);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtFechaEnt);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 130);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(230, 320);
            this.grbBase1.TabIndex = 13;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Entrega de Expedientes:";
            // 
            // txtDescripMotivo
            // 
            this.txtDescripMotivo.Location = new System.Drawing.Point(6, 173);
            this.txtDescripMotivo.Multiline = true;
            this.txtDescripMotivo.Name = "txtDescripMotivo";
            this.txtDescripMotivo.Size = new System.Drawing.Size(217, 134);
            this.txtDescripMotivo.TabIndex = 91;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 150);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(96, 13);
            this.lblBase1.TabIndex = 90;
            this.lblBase1.Text = "Observaciones:";
            // 
            // txtNroExpEnt
            // 
            this.txtNroExpEnt.Location = new System.Drawing.Point(132, 103);
            this.txtNroExpEnt.Name = "txtNroExpEnt";
            this.txtNroExpEnt.ReadOnly = true;
            this.txtNroExpEnt.Size = new System.Drawing.Size(91, 20);
            this.txtNroExpEnt.TabIndex = 15;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(3, 103);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(123, 13);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "N° Exp. Entregados:";
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(243, 9);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(591, 105);
            this.conBusCli1.TabIndex = 14;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // dtgListaSolExp
            // 
            this.dtgListaSolExp.AllowUserToAddRows = false;
            this.dtgListaSolExp.AllowUserToDeleteRows = false;
            this.dtgListaSolExp.AllowUserToResizeColumns = false;
            this.dtgListaSolExp.AllowUserToResizeRows = false;
            this.dtgListaSolExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgListaSolExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaSolExp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.dtgListaSolExp.Location = new System.Drawing.Point(243, 141);
            this.dtgListaSolExp.MultiSelect = false;
            this.dtgListaSolExp.Name = "dtgListaSolExp";
            this.dtgListaSolExp.ReadOnly = true;
            this.dtgListaSolExp.RowHeadersVisible = false;
            this.dtgListaSolExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaSolExp.Size = new System.Drawing.Size(591, 183);
            this.dtgListaSolExp.TabIndex = 15;
            this.dtgListaSolExp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaSolExp_CellClick);
            this.dtgListaSolExp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaSolExp_CellContentClick);
            this.dtgListaSolExp.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaSolExp_CellEnter);
            // 
            // chk
            // 
            this.chk.FillWeight = 20F;
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 5;
            // 
            // rbBusqGeneral
            // 
            this.rbBusqGeneral.AutoSize = true;
            this.rbBusqGeneral.Checked = true;
            this.rbBusqGeneral.ForeColor = System.Drawing.Color.Navy;
            this.rbBusqGeneral.Location = new System.Drawing.Point(27, 58);
            this.rbBusqGeneral.Name = "rbBusqGeneral";
            this.rbBusqGeneral.Size = new System.Drawing.Size(132, 17);
            this.rbBusqGeneral.TabIndex = 12;
            this.rbBusqGeneral.TabStop = true;
            this.rbBusqGeneral.Text = "Solicitudes Pendientes";
            this.rbBusqGeneral.UseVisualStyleBackColor = true;
            this.rbBusqGeneral.CheckedChanged += new System.EventHandler(this.rbBusqGeneral_CheckedChanged);
            // 
            // rbBusquedaPerson
            // 
            this.rbBusquedaPerson.AutoSize = true;
            this.rbBusquedaPerson.ForeColor = System.Drawing.Color.Navy;
            this.rbBusquedaPerson.Location = new System.Drawing.Point(27, 35);
            this.rbBusquedaPerson.Name = "rbBusquedaPerson";
            this.rbBusquedaPerson.Size = new System.Drawing.Size(141, 17);
            this.rbBusquedaPerson.TabIndex = 16;
            this.rbBusquedaPerson.Text = "Búsqueda personalizada";
            this.rbBusquedaPerson.UseVisualStyleBackColor = true;
            this.rbBusquedaPerson.CheckedChanged += new System.EventHandler(this.rbBusquedaPerson_CheckedChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbBusquedaPerson);
            this.grbBase2.Controls.Add(this.rbBusqGeneral);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(7, 3);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(230, 105);
            this.grbBase2.TabIndex = 17;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Selección de Expedientes por:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(243, 330);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(208, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Detalle de Expedientes Solicitados:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(243, 121);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(139, 13);
            this.lblBase4.TabIndex = 18;
            this.lblBase4.Text = "Solicitudes Pendientes:";
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(774, 406);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 20;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(774, 350);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 19;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(708, 509);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(774, 509);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEntregado1
            // 
            this.btnEntregado1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEntregado1.BackgroundImage")));
            this.btnEntregado1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEntregado1.Location = new System.Drawing.Point(642, 509);
            this.btnEntregado1.Name = "btnEntregado1";
            this.btnEntregado1.Size = new System.Drawing.Size(60, 50);
            this.btnEntregado1.TabIndex = 21;
            this.btnEntregado1.Text = "&Entregar";
            this.btnEntregado1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntregado1.UseVisualStyleBackColor = true;
            this.btnEntregado1.Click += new System.EventHandler(this.btnEntregado1_Click);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(778, 329);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 88;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // btnDenegar1
            // 
            this.btnDenegar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar1.BackgroundImage")));
            this.btnDenegar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar1.Location = new System.Drawing.Point(576, 509);
            this.btnDenegar1.Name = "btnDenegar1";
            this.btnDenegar1.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar1.TabIndex = 89;
            this.btnDenegar1.Text = "&Denegar";
            this.btnDenegar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar1.UseVisualStyleBackColor = true;
            this.btnDenegar1.Click += new System.EventHandler(this.btnDenegar1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(469, 121);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(124, 13);
            this.lblBase5.TabIndex = 90;
            this.lblBase5.Text = "Seleccione un Perfil:";
            // 
            // cboPerfilesExp
            // 
            this.cboPerfilesExp.FormattingEnabled = true;
            this.cboPerfilesExp.Location = new System.Drawing.Point(599, 118);
            this.cboPerfilesExp.Name = "cboPerfilesExp";
            this.cboPerfilesExp.Size = new System.Drawing.Size(235, 21);
            this.cboPerfilesExp.TabIndex = 91;
            this.cboPerfilesExp.SelectedIndexChanged += new System.EventHandler(this.cboPerfilesExp_SelectedIndexChanged);
            // 
            // frmExpedienteEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 588);
            this.Controls.Add(this.cboPerfilesExp);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnDenegar1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnEntregado1);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.dtgListaSolExp);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgDetalleSolExp);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmExpedienteEntrega";
            this.Text = "Entrega de expediente";
            this.Load += new System.EventHandler(this.frmEntregaExpediente_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgDetalleSolExp, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.dtgListaSolExp, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.btnEntregado1, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.btnDenegar1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboPerfilesExp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleSolExp)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaSolExp)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtLargoBase dtFechaEnt;
        private GEN.ControlesBase.dtgBase dtgDetalleSolExp;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.dtgBase dtgListaSolExp;
        private System.Windows.Forms.RadioButton rbBusqGeneral;
        private System.Windows.Forms.RadioButton rbBusquedaPerson;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.txtBase txtNroExpEnt;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.BotonesBase.btnEntregado btnEntregado1;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.BotonesBase.btnDenegar btnDenegar1;
        private GEN.ControlesBase.txtBase txtDescripMotivo;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboPerfilesExp;
    }
}