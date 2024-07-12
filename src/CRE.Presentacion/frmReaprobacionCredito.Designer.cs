namespace CRE.Presentacion
{
    partial class frmReaprobacionCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReaprobacionCredito));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtPersonalCreditos1 = new GEN.ControlesBase.txtBase(this.components);
            this.conCreditoTasa = new GEN.ControlesBase.ConCreditoTasa();
            this.dtgCuentaCreditoVinculado = new System.Windows.Forms.DataGridView();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtFecAprob = new GEN.ControlesBase.dtLargoBase(this.components);
            this.cboOperacionCre1 = new GEN.ControlesBase.cboOperacionCre(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtComentario = new GEN.ControlesBase.txtBase(this.components);
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.btnListaAprob1 = new GEN.BotonesBase.btnListaAprob();
            this.btnActualizar1 = new GEN.BotonesBase.btnActualizar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentaCreditoVinculado)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtPersonalCreditos1);
            this.grbBase1.Controls.Add(this.dtgCuentaCreditoVinculado);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dtFecAprob);
            this.grbBase1.Controls.Add(this.cboOperacionCre1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtComentario);
            this.grbBase1.Controls.Add(this.conCreditoTasa);
            this.grbBase1.Location = new System.Drawing.Point(12, 118);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(653, 382);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Condiciones de Crédito";
            // 
            // txtPersonalCreditos1
            // 
            this.txtPersonalCreditos1.Enabled = false;
            this.txtPersonalCreditos1.Location = new System.Drawing.Point(427, 45);
            this.txtPersonalCreditos1.Name = "txtPersonalCreditos1";
            this.txtPersonalCreditos1.Size = new System.Drawing.Size(213, 20);
            this.txtPersonalCreditos1.TabIndex = 105;
            // 
            // conCreditoTasa
            // 
            this.conCreditoTasa.AutoSize = true;
            this.conCreditoTasa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoTasa.CuotasEnabled = true;
            this.conCreditoTasa.DiasGraciaEnabled = false;
            this.conCreditoTasa.Enabled = false;
            this.conCreditoTasa.FechaDesembolsoEnabled = true;
            this.conCreditoTasa.lMostrarTodosNivCred = false;
            this.conCreditoTasa.Location = new System.Drawing.Point(6, 20);
            this.conCreditoTasa.MonedaEnabled = false;
            this.conCreditoTasa.MontoEnabled = true;
            this.conCreditoTasa.Name = "conCreditoTasa";
            this.conCreditoTasa.NivelesProductoEnabled = false;
            this.conCreditoTasa.PlazoCuotaEnabled = true;
            this.conCreditoTasa.Size = new System.Drawing.Size(325, 229);
            this.conCreditoTasa.TabIndex = 104;
            this.conCreditoTasa.TEAEnabled = true;
            this.conCreditoTasa.TipoPeriodoEnabled = true;
            this.conCreditoTasa.TipoTasaCreditoEnabled = true;
            // 
            // dtgCuentaCreditoVinculado
            // 
            this.dtgCuentaCreditoVinculado.AllowUserToAddRows = false;
            this.dtgCuentaCreditoVinculado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCuentaCreditoVinculado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCuentaCreditoVinculado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCuentaCreditoVinculado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCuentaCreditoVinculado.Location = new System.Drawing.Point(9, 282);
            this.dtgCuentaCreditoVinculado.Name = "dtgCuentaCreditoVinculado";
            this.dtgCuentaCreditoVinculado.ReadOnly = true;
            this.dtgCuentaCreditoVinculado.RowHeadersVisible = false;
            this.dtgCuentaCreditoVinculado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentaCreditoVinculado.Size = new System.Drawing.Size(631, 92);
            this.dtgCuentaCreditoVinculado.TabIndex = 17;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 261);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(177, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Cuentas de Créditos Vigentes";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 226);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(0, 13);
            this.lblBase5.TabIndex = 15;
            // 
            // dtFecAprob
            // 
            this.dtFecAprob.Enabled = false;
            this.dtFecAprob.Location = new System.Drawing.Point(427, 67);
            this.dtFecAprob.Name = "dtFecAprob";
            this.dtFecAprob.Size = new System.Drawing.Size(213, 20);
            this.dtFecAprob.TabIndex = 14;
            // 
            // cboOperacionCre1
            // 
            this.cboOperacionCre1.Enabled = false;
            this.cboOperacionCre1.FormattingEnabled = true;
            this.cboOperacionCre1.Location = new System.Drawing.Point(427, 22);
            this.cboOperacionCre1.Name = "cboOperacionCre1";
            this.cboOperacionCre1.Size = new System.Drawing.Size(213, 21);
            this.cboOperacionCre1.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(356, 71);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(68, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Fec. Aprob";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(378, 49);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(46, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Asesor";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(359, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Operación";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(349, 93);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(75, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Justificación";
            // 
            // txtComentario
            // 
            this.txtComentario.Enabled = false;
            this.txtComentario.Location = new System.Drawing.Point(349, 109);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(291, 114);
            this.txtComentario.TabIndex = 1;
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli1.Enabled = false;
            this.conBusCuentaCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(570, 100);
            this.conBusCuentaCli1.TabIndex = 0;
            this.conBusCuentaCli1.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli1_MyKey);
            this.conBusCuentaCli1.MyClic += new System.EventHandler(this.conBusCuentaCli1_MyClic);
            // 
            // btnListaAprob1
            // 
            this.btnListaAprob1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaAprob1.BackgroundImage")));
            this.btnListaAprob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListaAprob1.Location = new System.Drawing.Point(605, 21);
            this.btnListaAprob1.Name = "btnListaAprob1";
            this.btnListaAprob1.Size = new System.Drawing.Size(60, 50);
            this.btnListaAprob1.TabIndex = 1;
            this.btnListaAprob1.Text = "&Lista Aprob.";
            this.btnListaAprob1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaAprob1.UseVisualStyleBackColor = true;
            this.btnListaAprob1.Click += new System.EventHandler(this.btnListaAprob1_Click);
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.BackgroundImage")));
            this.btnActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar1.Location = new System.Drawing.Point(18, 503);
            this.btnActualizar1.Name = "btnActualizar1";
            this.btnActualizar1.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar1.TabIndex = 3;
            this.btnActualizar1.Text = "Act&ualizar";
            this.btnActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar1.texto = "Act&ualizar";
            this.btnActualizar1.UseVisualStyleBackColor = true;
            this.btnActualizar1.Visible = false;
            this.btnActualizar1.Click += new System.EventHandler(this.btnActualizar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(473, 503);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 10;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(407, 503);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(605, 503);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(539, 503);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmReaprobacionCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(677, 583);
            this.Controls.Add(this.btnListaAprob1);
            this.Controls.Add(this.btnActualizar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmReaprobacionCredito";
            this.Text = "Actualizador de Aprobaciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReaprobacionCredito_FormClosed);
            this.Load += new System.EventHandler(this.frmReaprobacionCredito_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnActualizar1, 0);
            this.Controls.SetChildIndex(this.btnListaAprob1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentaCreditoVinculado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtComentario;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnActualizar btnActualizar1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboOperacionCre cboOperacionCre1;
        private GEN.ControlesBase.dtLargoBase dtFecAprob;
        private GEN.BotonesBase.btnListaAprob btnListaAprob1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.DataGridView dtgCuentaCreditoVinculado;
        private GEN.ControlesBase.ConCreditoTasa conCreditoTasa;
        private GEN.ControlesBase.txtBase txtPersonalCreditos1;

    }
}