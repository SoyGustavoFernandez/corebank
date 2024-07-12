namespace RCP.Presentacion
{
    partial class frmPlanTrabajoDetalleAccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanTrabajoDetalleAccion));
            this.cboObjetivoEspecifico = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFechaAccion = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtDetalleAccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgDetalleAccionCliente = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.cboAccionResumen = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnMiniDetalle = new GEN.BotonesBase.btnMiniDetalle(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAccionCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // cboObjetivoEspecifico
            // 
            this.cboObjetivoEspecifico.FormattingEnabled = true;
            this.cboObjetivoEspecifico.Location = new System.Drawing.Point(196, 13);
            this.cboObjetivoEspecifico.Name = "cboObjetivoEspecifico";
            this.cboObjetivoEspecifico.Size = new System.Drawing.Size(380, 21);
            this.cboObjetivoEspecifico.TabIndex = 0;
            this.cboObjetivoEspecifico.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoEspecifico_SelectedIndexChanged);
            // 
            // dtpFechaAccion
            // 
            this.dtpFechaAccion.Enabled = false;
            this.dtpFechaAccion.Location = new System.Drawing.Point(196, 36);
            this.dtpFechaAccion.Name = "dtpFechaAccion";
            this.dtpFechaAccion.Size = new System.Drawing.Size(380, 20);
            this.dtpFechaAccion.TabIndex = 1;
            this.dtpFechaAccion.Leave += new System.EventHandler(this.dtpFechaAccion_Leave);
            // 
            // txtDetalleAccion
            // 
            this.txtDetalleAccion.Location = new System.Drawing.Point(196, 92);
            this.txtDetalleAccion.MaxLength = 500;
            this.txtDetalleAccion.Multiline = true;
            this.txtDetalleAccion.Name = "txtDetalleAccion";
            this.txtDetalleAccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleAccion.Size = new System.Drawing.Size(380, 50);
            this.txtDetalleAccion.TabIndex = 3;
            this.txtDetalleAccion.Leave += new System.EventHandler(this.txtDetalleAccion_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(115, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Objetivo Específico";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 39);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(104, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Fecha de Acción:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 110);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(181, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Descripción de Detalle Acción:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(602, 336);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(662, 336);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgDetalleAccionCliente
            // 
            this.dtgDetalleAccionCliente.AllowUserToAddRows = false;
            this.dtgDetalleAccionCliente.AllowUserToDeleteRows = false;
            this.dtgDetalleAccionCliente.AllowUserToResizeColumns = false;
            this.dtgDetalleAccionCliente.AllowUserToResizeRows = false;
            this.dtgDetalleAccionCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleAccionCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleAccionCliente.Location = new System.Drawing.Point(12, 188);
            this.dtgDetalleAccionCliente.MultiSelect = false;
            this.dtgDetalleAccionCliente.Name = "dtgDetalleAccionCliente";
            this.dtgDetalleAccionCliente.ReadOnly = true;
            this.dtgDetalleAccionCliente.RowHeadersVisible = false;
            this.dtgDetalleAccionCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleAccionCliente.Size = new System.Drawing.Size(710, 145);
            this.dtgDetalleAccionCliente.TabIndex = 10;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 165);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Clientes a Visitar:";
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(650, 150);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 6;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            this.btnMiniAgregar.Click += new System.EventHandler(this.btnMiniAgregar_Click);
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(686, 150);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 7;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(578, 150);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 4;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // cboAccionResumen
            // 
            this.cboAccionResumen.FormattingEnabled = true;
            this.cboAccionResumen.Location = new System.Drawing.Point(196, 69);
            this.cboAccionResumen.Name = "cboAccionResumen";
            this.cboAccionResumen.Size = new System.Drawing.Size(380, 21);
            this.cboAccionResumen.TabIndex = 2;
            this.cboAccionResumen.SelectedIndexChanged += new System.EventHandler(this.cboAccionResumen_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 72);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(150, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Resumen Detalle Acción:";
            // 
            // btnMiniDetalle
            // 
            this.btnMiniDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDetalle.BackgroundImage")));
            this.btnMiniDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDetalle.Location = new System.Drawing.Point(614, 150);
            this.btnMiniDetalle.Name = "btnMiniDetalle";
            this.btnMiniDetalle.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDetalle.TabIndex = 5;
            this.btnMiniDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDetalle.UseVisualStyleBackColor = true;
            this.btnMiniDetalle.Click += new System.EventHandler(this.btnMiniDetalle_Click);
            // 
            // frmPlanTrabajoDetalleAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.btnMiniDetalle);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboAccionResumen);
            this.Controls.Add(this.btnMiniBusq);
            this.Controls.Add(this.btnMiniQuitar);
            this.Controls.Add(this.btnMiniAgregar);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgDetalleAccionCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDetalleAccion);
            this.Controls.Add(this.dtpFechaAccion);
            this.Controls.Add(this.cboObjetivoEspecifico);
            this.Name = "frmPlanTrabajoDetalleAccion";
            this.Text = "Plan de Trabajo - Detalle Acción";
            this.Load += new System.EventHandler(this.frmPlanTrabajoDetalleAccion_Load);
            this.Controls.SetChildIndex(this.cboObjetivoEspecifico, 0);
            this.Controls.SetChildIndex(this.dtpFechaAccion, 0);
            this.Controls.SetChildIndex(this.txtDetalleAccion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.dtgDetalleAccionCliente, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq, 0);
            this.Controls.SetChildIndex(this.cboAccionResumen, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnMiniDetalle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAccionCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboObjetivoEspecifico;
        private GEN.ControlesBase.dtpCorto dtpFechaAccion;
        private GEN.ControlesBase.txtBase txtDetalleAccion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgDetalleAccionCliente;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.ControlesBase.cboBase cboAccionResumen;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnMiniDetalle btnMiniDetalle;
    }
}