namespace DEP.Presentacion
{
    partial class frmReasigDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReasigDeposito));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.dtgOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDestino = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciasOri = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.conBusColOrigen = new GEN.ControlesBase.ConBusCol();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.conBusColDestino = new GEN.ControlesBase.ConBusCol();
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgenciasDes = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblNroCueOrigen = new GEN.ControlesBase.lblBase();
            this.lblNroCueDest = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrigen)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDestino)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.conBusColDestino.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcTodos);
            this.grbBase1.Controls.Add(this.dtgOrigen);
            this.grbBase1.Controls.Add(this.lblNroCueOrigen);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(8, 164);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(511, 211);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Cartera promotor origen";
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(446, 10);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 21;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // dtgOrigen
            // 
            this.dtgOrigen.AllowUserToAddRows = false;
            this.dtgOrigen.AllowUserToDeleteRows = false;
            this.dtgOrigen.AllowUserToResizeColumns = false;
            this.dtgOrigen.AllowUserToResizeRows = false;
            this.dtgOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgOrigen.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgOrigen.Location = new System.Drawing.Point(5, 29);
            this.dtgOrigen.MultiSelect = false;
            this.dtgOrigen.Name = "dtgOrigen";
            this.dtgOrigen.ReadOnly = true;
            this.dtgOrigen.RowHeadersVisible = false;
            this.dtgOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgOrigen.Size = new System.Drawing.Size(500, 162);
            this.dtgOrigen.TabIndex = 0;
            this.dtgOrigen.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgOrigen_CurrentCellDirtyStateChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgDestino);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblNroCueDest);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(526, 164);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(403, 211);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Cartera promotor destino";
            // 
            // dtgDestino
            // 
            this.dtgDestino.AllowUserToAddRows = false;
            this.dtgDestino.AllowUserToDeleteRows = false;
            this.dtgDestino.AllowUserToResizeColumns = false;
            this.dtgDestino.AllowUserToResizeRows = false;
            this.dtgDestino.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDestino.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDestino.Location = new System.Drawing.Point(6, 29);
            this.dtgDestino.MultiSelect = false;
            this.dtgDestino.Name = "dtgDestino";
            this.dtgDestino.ReadOnly = true;
            this.dtgDestino.RowHeadersVisible = false;
            this.dtgDestino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDestino.Size = new System.Drawing.Size(390, 162);
            this.dtgDestino.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(806, 391);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(743, 391);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(869, 391);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboAgenciasOri);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.conBusColOrigen);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(7, 5);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(512, 153);
            this.grbBase3.TabIndex = 7;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Promotor origen:";
            // 
            // cboAgenciasOri
            // 
            this.cboAgenciasOri.FormattingEnabled = true;
            this.cboAgenciasOri.Location = new System.Drawing.Point(73, 23);
            this.cboAgenciasOri.Name = "cboAgenciasOri";
            this.cboAgenciasOri.Size = new System.Drawing.Size(325, 21);
            this.cboAgenciasOri.TabIndex = 12;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 26);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Agencia:";
            // 
            // conBusColOrigen
            // 
            this.conBusColOrigen.ForeColor = System.Drawing.Color.Navy;
            this.conBusColOrigen.Location = new System.Drawing.Point(8, 55);
            this.conBusColOrigen.Name = "conBusColOrigen";
            this.conBusColOrigen.Size = new System.Drawing.Size(390, 86);
            this.conBusColOrigen.TabIndex = 14;
            this.conBusColOrigen.BuscarUsuario += new System.EventHandler(this.conBusColOrigen_BuscarUsuario);
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.cboAgenciasDes);
            this.grbBase5.Controls.Add(this.conBusColDestino);
            this.grbBase5.Controls.Add(this.lblBase6);
            this.grbBase5.ForeColor = System.Drawing.Color.Navy;
            this.grbBase5.Location = new System.Drawing.Point(525, 5);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(404, 153);
            this.grbBase5.TabIndex = 8;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Promotor destino:";
            // 
            // conBusColDestino
            // 
            this.conBusColDestino.Controls.Add(this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf);
            this.conBusColDestino.Location = new System.Drawing.Point(7, 55);
            this.conBusColDestino.Name = "conBusColDestino";
            this.conBusColDestino.Size = new System.Drawing.Size(390, 86);
            this.conBusColDestino.TabIndex = 15;
            this.conBusColDestino.BuscarUsuario += new System.EventHandler(this.conBusColDestino_BuscarUsuario);
            // 
            // object_46706a16_4fb1_4390_9267_8a0c2475cdcf
            // 
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.Location = new System.Drawing.Point(0, 0);
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.Name = "object_46706a16_4fb1_4390_9267_8a0c2475cdcf";
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.Size = new System.Drawing.Size(387, 86);
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.TabIndex = 0;
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.TabStop = false;
            this.object_46706a16_4fb1_4390_9267_8a0c2475cdcf.Text = "Datos del Colaborador";
            // 
            // cboAgenciasDes
            // 
            this.cboAgenciasDes.FormattingEnabled = true;
            this.cboAgenciasDes.Location = new System.Drawing.Point(74, 25);
            this.cboAgenciasDes.Name = "cboAgenciasDes";
            this.cboAgenciasDes.Size = new System.Drawing.Size(318, 21);
            this.cboAgenciasDes.TabIndex = 13;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 28);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(57, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Agencia:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(334, 194);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(101, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Nro de Cuentas:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(235, 195);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(101, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Nro de Cuentas:";
            // 
            // lblNroCueOrigen
            // 
            this.lblNroCueOrigen.AutoSize = true;
            this.lblNroCueOrigen.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCueOrigen.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCueOrigen.Location = new System.Drawing.Point(441, 194);
            this.lblNroCueOrigen.Name = "lblNroCueOrigen";
            this.lblNroCueOrigen.Size = new System.Drawing.Size(15, 13);
            this.lblNroCueOrigen.TabIndex = 11;
            this.lblNroCueOrigen.Text = "  ";
            // 
            // lblNroCueDest
            // 
            this.lblNroCueDest.AutoSize = true;
            this.lblNroCueDest.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCueDest.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCueDest.Location = new System.Drawing.Point(342, 195);
            this.lblNroCueDest.Name = "lblNroCueDest";
            this.lblNroCueDest.Size = new System.Drawing.Size(15, 13);
            this.lblNroCueDest.TabIndex = 12;
            this.lblNroCueDest.Text = "  ";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(13, 395);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(500, 46);
            this.txtMotivo.TabIndex = 13;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 379);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(143, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Motivo de reasignación:";
            // 
            // frmReasigDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 471);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.grbBase5);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmReasigDeposito";
            this.Text = "Reasignación de promotor de depósitos";
            this.Load += new System.EventHandler(this.frmReasigDeposito_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOrigen)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDestino)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.conBusColDestino.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgOrigen;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgDestino;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblNroCueOrigen;
        private GEN.ControlesBase.lblBase lblNroCueDest;
        private GEN.ControlesBase.cboAgencias cboAgenciasOri;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgenciasDes;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.ConBusCol conBusColOrigen;
        private GEN.ControlesBase.ConBusCol conBusColDestino;
        private GEN.ControlesBase.grbBase object_46706a16_4fb1_4390_9267_8a0c2475cdcf;
        private GEN.ControlesBase.lblBase lblBase3;
    }
}