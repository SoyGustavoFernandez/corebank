namespace CRE.Presentacion
{
    partial class frmExpedientesSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedientesSolicitud));
            this.dtgSolicExped = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.dtgDetalleExp = new GEN.ControlesBase.dtgBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.cboMotivoExpediente = new GEN.ControlesBase.cboBase(this.components);
            this.dtgExpedientesCliente = new GEN.ControlesBase.dtgBase(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.label5 = new System.Windows.Forms.Label();
            this.chcTodo = new GEN.ControlesBase.chcBase(this.components);
            this.btnMiniActualizar1 = new GEN.BotonesBase.btnMiniActualizar(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicExped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExpedientesCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSolicExped
            // 
            this.dtgSolicExped.AllowUserToAddRows = false;
            this.dtgSolicExped.AllowUserToDeleteRows = false;
            this.dtgSolicExped.AllowUserToResizeColumns = false;
            this.dtgSolicExped.AllowUserToResizeRows = false;
            this.dtgSolicExped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicExped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicExped.Location = new System.Drawing.Point(12, 280);
            this.dtgSolicExped.MultiSelect = false;
            this.dtgSolicExped.Name = "dtgSolicExped";
            this.dtgSolicExped.ReadOnly = true;
            this.dtgSolicExped.RowHeadersVisible = false;
            this.dtgSolicExped.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicExped.Size = new System.Drawing.Size(682, 116);
            this.dtgSolicExped.TabIndex = 5;
            this.dtgSolicExped.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSolicExped_CellContentClick);
            this.dtgSolicExped.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSolicExped_CellEnter);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(686, 582);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(622, 582);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 12;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 25);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(528, 105);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // dtgDetalleExp
            // 
            this.dtgDetalleExp.AllowUserToAddRows = false;
            this.dtgDetalleExp.AllowUserToDeleteRows = false;
            this.dtgDetalleExp.AllowUserToResizeColumns = false;
            this.dtgDetalleExp.AllowUserToResizeRows = false;
            this.dtgDetalleExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleExp.Location = new System.Drawing.Point(12, 450);
            this.dtgDetalleExp.MultiSelect = false;
            this.dtgDetalleExp.Name = "dtgDetalleExp";
            this.dtgDetalleExp.ReadOnly = true;
            this.dtgDetalleExp.RowHeadersVisible = false;
            this.dtgDetalleExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleExp.Size = new System.Drawing.Size(734, 126);
            this.dtgDetalleExp.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(9, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista expedientes del cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(9, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista documentos del expediente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "BUSCAR CLIENTE:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(558, 582);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 11;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // cboMotivoExpediente
            // 
            this.cboMotivoExpediente.FormattingEnabled = true;
            this.cboMotivoExpediente.Location = new System.Drawing.Point(299, 405);
            this.cboMotivoExpediente.Name = "cboMotivoExpediente";
            this.cboMotivoExpediente.Size = new System.Drawing.Size(231, 21);
            this.cboMotivoExpediente.TabIndex = 10;
            // 
            // dtgExpedientesCliente
            // 
            this.dtgExpedientesCliente.AllowUserToAddRows = false;
            this.dtgExpedientesCliente.AllowUserToDeleteRows = false;
            this.dtgExpedientesCliente.AllowUserToResizeColumns = false;
            this.dtgExpedientesCliente.AllowUserToResizeRows = false;
            this.dtgExpedientesCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExpedientesCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExpedientesCliente.Location = new System.Drawing.Point(12, 151);
            this.dtgExpedientesCliente.MultiSelect = false;
            this.dtgExpedientesCliente.Name = "dtgExpedientesCliente";
            this.dtgExpedientesCliente.ReadOnly = true;
            this.dtgExpedientesCliente.RowHeadersVisible = false;
            this.dtgExpedientesCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExpedientesCliente.Size = new System.Drawing.Size(682, 110);
            this.dtgExpedientesCliente.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(9, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lista expedientes solicitados";
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(700, 303);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 6;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(9, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Asignar motivo a expediente(s) seleccionado(s):";
            // 
            // chcTodo
            // 
            this.chcTodo.AutoSize = true;
            this.chcTodo.Location = new System.Drawing.Point(700, 280);
            this.chcTodo.Name = "chcTodo";
            this.chcTodo.Size = new System.Drawing.Size(51, 17);
            this.chcTodo.TabIndex = 22;
            this.chcTodo.Text = "Todo";
            this.chcTodo.UseVisualStyleBackColor = true;
            this.chcTodo.CheckedChanged += new System.EventHandler(this.chcTodo_CheckedChanged);
            // 
            // btnMiniActualizar1
            // 
            this.btnMiniActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniActualizar1.BackgroundImage")));
            this.btnMiniActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniActualizar1.Location = new System.Drawing.Point(536, 400);
            this.btnMiniActualizar1.Name = "btnMiniActualizar1";
            this.btnMiniActualizar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniActualizar1.TabIndex = 23;
            this.btnMiniActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniActualizar1.UseVisualStyleBackColor = true;
            this.btnMiniActualizar1.Click += new System.EventHandler(this.btnMiniActualizar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(700, 151);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 24;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // frmExpedientesSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 662);
            this.Controls.Add(this.btnMiniAgregar1);
            this.Controls.Add(this.btnMiniActualizar1);
            this.Controls.Add(this.chcTodo);
            this.Controls.Add(this.btnMiniQuitar1);
            this.Controls.Add(this.dtgExpedientesCliente);
            this.Controls.Add(this.cboMotivoExpediente);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgDetalleExp);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgSolicExped);
            this.Name = "frmExpedientesSolicitud";
            this.Text = "Registro de Solicitud de Expediente";
            this.Load += new System.EventHandler(this.frmSolicitudExpedientes_Load);
            this.Controls.SetChildIndex(this.dtgSolicExped, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.dtgDetalleExp, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.cboMotivoExpediente, 0);
            this.Controls.SetChildIndex(this.dtgExpedientesCliente, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar1, 0);
            this.Controls.SetChildIndex(this.chcTodo, 0);
            this.Controls.SetChildIndex(this.btnMiniActualizar1, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicExped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExpedientesCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgSolicExped;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.dtgBase dtgDetalleExp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboBase cboMotivoExpediente;
        private GEN.ControlesBase.dtgBase dtgExpedientesCliente;
        private System.Windows.Forms.Label label6;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private System.Windows.Forms.Label label5;
        private GEN.ControlesBase.chcBase chcTodo;
        private GEN.BotonesBase.btnMiniActualizar btnMiniActualizar1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
    }
}