namespace LOG.Presentacion
{
    partial class frmAsigancionActivos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsigancionActivos));
            this.dtgActivoOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgActivoDestino = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAddActivos = new GEN.BotonesBase.btnAgregar();
            this.btnAddUsuario = new GEN.BotonesBase.btnAgregar();
            this.btnQuitActivos = new GEN.BotonesBase.btnQuitar();
            this.btnQuitUsuario = new GEN.BotonesBase.btnQuitar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpActivacion = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboTipodeImpresion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoDestino)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgActivoOrigen
            // 
            this.dtgActivoOrigen.AllowUserToAddRows = false;
            this.dtgActivoOrigen.AllowUserToDeleteRows = false;
            this.dtgActivoOrigen.AllowUserToResizeColumns = false;
            this.dtgActivoOrigen.AllowUserToResizeRows = false;
            this.dtgActivoOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgActivoOrigen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgActivoOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgActivoOrigen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgActivoOrigen.Location = new System.Drawing.Point(6, 29);
            this.dtgActivoOrigen.MultiSelect = false;
            this.dtgActivoOrigen.Name = "dtgActivoOrigen";
            this.dtgActivoOrigen.ReadOnly = true;
            this.dtgActivoOrigen.RowHeadersVisible = false;
            this.dtgActivoOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivoOrigen.Size = new System.Drawing.Size(576, 170);
            this.dtgActivoOrigen.TabIndex = 2;
            // 
            // dtgActivoDestino
            // 
            this.dtgActivoDestino.AllowUserToAddRows = false;
            this.dtgActivoDestino.AllowUserToDeleteRows = false;
            this.dtgActivoDestino.AllowUserToResizeColumns = false;
            this.dtgActivoDestino.AllowUserToResizeRows = false;
            this.dtgActivoDestino.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgActivoDestino.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgActivoDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgActivoDestino.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgActivoDestino.Location = new System.Drawing.Point(6, 222);
            this.dtgActivoDestino.MultiSelect = false;
            this.dtgActivoDestino.Name = "dtgActivoDestino";
            this.dtgActivoDestino.ReadOnly = true;
            this.dtgActivoDestino.RowHeadersVisible = false;
            this.dtgActivoDestino.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivoDestino.Size = new System.Drawing.Size(578, 106);
            this.dtgActivoDestino.TabIndex = 3;
            // 
            // btnAddActivos
            // 
            this.btnAddActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddActivos.BackgroundImage")));
            this.btnAddActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddActivos.Location = new System.Drawing.Point(589, 29);
            this.btnAddActivos.Name = "btnAddActivos";
            this.btnAddActivos.Size = new System.Drawing.Size(60, 50);
            this.btnAddActivos.TabIndex = 4;
            this.btnAddActivos.Text = "&Agregar";
            this.btnAddActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddActivos.UseVisualStyleBackColor = true;
            this.btnAddActivos.Click += new System.EventHandler(this.btnAddActivos_Click);
            // 
            // btnAddUsuario
            // 
            this.btnAddUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddUsuario.BackgroundImage")));
            this.btnAddUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddUsuario.Location = new System.Drawing.Point(589, 222);
            this.btnAddUsuario.Name = "btnAddUsuario";
            this.btnAddUsuario.Size = new System.Drawing.Size(60, 50);
            this.btnAddUsuario.TabIndex = 5;
            this.btnAddUsuario.Text = "&Agregar";
            this.btnAddUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddUsuario.UseVisualStyleBackColor = true;
            this.btnAddUsuario.Click += new System.EventHandler(this.btnAddUsuario_Click);
            // 
            // btnQuitActivos
            // 
            this.btnQuitActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitActivos.BackgroundImage")));
            this.btnQuitActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitActivos.Location = new System.Drawing.Point(589, 86);
            this.btnQuitActivos.Name = "btnQuitActivos";
            this.btnQuitActivos.Size = new System.Drawing.Size(60, 50);
            this.btnQuitActivos.TabIndex = 6;
            this.btnQuitActivos.Text = "&Quitar";
            this.btnQuitActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitActivos.UseVisualStyleBackColor = true;
            this.btnQuitActivos.Click += new System.EventHandler(this.btnQuitActivos_Click);
            // 
            // btnQuitUsuario
            // 
            this.btnQuitUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitUsuario.BackgroundImage")));
            this.btnQuitUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitUsuario.Location = new System.Drawing.Point(589, 278);
            this.btnQuitUsuario.Name = "btnQuitUsuario";
            this.btnQuitUsuario.Size = new System.Drawing.Size(60, 50);
            this.btnQuitUsuario.TabIndex = 7;
            this.btnQuitUsuario.Text = "&Quitar";
            this.btnQuitUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitUsuario.UseVisualStyleBackColor = true;
            this.btnQuitUsuario.Click += new System.EventHandler(this.btnQuitUsuario_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(409, 428);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(475, 428);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(475, 428);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(607, 428);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(541, 428);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.label2);
            this.grbBase1.Controls.Add(this.label1);
            this.grbBase1.Controls.Add(this.dtgActivoOrigen);
            this.grbBase1.Controls.Add(this.btnAddActivos);
            this.grbBase1.Controls.Add(this.btnQuitActivos);
            this.grbBase1.Controls.Add(this.dtgActivoDestino);
            this.grbBase1.Controls.Add(this.btnAddUsuario);
            this.grbBase1.Controls.Add(this.btnQuitUsuario);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(655, 335);
            this.grbBase1.TabIndex = 13;
            this.grbBase1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(3, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "DESTINO DEL ACTIVO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ORIGEN DEL ACTIVO:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(343, 428);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.dtpActivacion);
            this.grbBase4.Controls.Add(this.lblBase5);
            this.grbBase4.Location = new System.Drawing.Point(411, 353);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(183, 69);
            this.grbBase4.TabIndex = 18;
            this.grbBase4.TabStop = false;
            // 
            // dtpActivacion
            // 
            this.dtpActivacion.Location = new System.Drawing.Point(9, 27);
            this.dtpActivacion.Name = "dtpActivacion";
            this.dtpActivacion.Size = new System.Drawing.Size(163, 20);
            this.dtpActivacion.TabIndex = 8;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 11);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(125, 13);
            this.lblBase5.TabIndex = 6;
            this.lblBase5.Text = "Fecha de Activación:";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(12, 369);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(391, 53);
            this.txtSustento.TabIndex = 19;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 353);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(100, 13);
            this.lblBase6.TabIndex = 20;
            this.lblBase6.Text = "Detallar motivo:";
            // 
            // cboTipodeImpresion
            // 
            this.cboTipodeImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipodeImpresion.FormattingEnabled = true;
            this.cboTipodeImpresion.Location = new System.Drawing.Point(216, 457);
            this.cboTipodeImpresion.Name = "cboTipodeImpresion";
            this.cboTipodeImpresion.Size = new System.Drawing.Size(121, 21);
            this.cboTipodeImpresion.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "Formato de Impresion \r\nCargo de entrega";
            // 
            // frmAsigancionActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 509);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipodeImpresion);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Name = "frmAsigancionActivos";
            this.Text = "Asignación Activos a Personal";
            this.Load += new System.EventHandler(this.frmAsigancionActivos_Load);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboTipodeImpresion, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoDestino)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgActivoOrigen;
        private GEN.ControlesBase.dtgBase dtgActivoDestino;
        private GEN.BotonesBase.btnAgregar btnAddActivos;
        private GEN.BotonesBase.btnAgregar btnAddUsuario;
        private GEN.BotonesBase.btnQuitar btnQuitActivos;
        private GEN.BotonesBase.btnQuitar btnQuitUsuario;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.dtpCorto dtpActivacion;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.ComboBox cboTipodeImpresion;
        private System.Windows.Forms.Label label3;
    }
}