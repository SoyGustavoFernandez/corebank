namespace DEP.Presentacion
{
    partial class frmControlImpresionOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlImpresionOP));
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.dtgSolOP = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnDetalle = new GEN.BotonesBase.btnDetalle();
            this.dtgValorado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtgValoradoAnu = new GEN.ControlesBase.dtgBase(this.components);
            this.btnMiniPasarIzquierda = new GEN.BotonesBase.btnMiniPasarIzquierda();
            this.btnMiniPasarDerecha = new GEN.BotonesBase.btnMiniPasarDerecha();
            this.dtgNuevos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.nudFolio = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.labelTitu1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcEditar = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoradoAnu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNuevos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(4, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 21);
            this.label1.TabIndex = 136;
            this.label1.Text = "Listado de Solicitudes de Ordenes de Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(598, 7);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 135;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // dtgSolOP
            // 
            this.dtgSolOP.AllowUserToAddRows = false;
            this.dtgSolOP.AllowUserToDeleteRows = false;
            this.dtgSolOP.AllowUserToResizeColumns = false;
            this.dtgSolOP.AllowUserToResizeRows = false;
            this.dtgSolOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolOP.Location = new System.Drawing.Point(4, 83);
            this.dtgSolOP.MultiSelect = false;
            this.dtgSolOP.Name = "dtgSolOP";
            this.dtgSolOP.ReadOnly = true;
            this.dtgSolOP.RowHeadersVisible = false;
            this.dtgSolOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolOP.Size = new System.Drawing.Size(678, 112);
            this.dtgSolOP.TabIndex = 133;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(324, 27);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 132;
            this.lblBase4.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(383, 24);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(196, 21);
            this.cboMoneda.TabIndex = 130;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(52, 27);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(63, 13);
            this.lblBase2.TabIndex = 131;
            this.lblBase2.Text = "Agencias:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Location = new System.Drawing.Point(6, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(586, 51);
            this.grbBase1.TabIndex = 134;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtro";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(115, 17);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(186, 21);
            this.cboAgencias.TabIndex = 130;
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle.BackgroundImage")));
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle.Enabled = false;
            this.btnDetalle.Location = new System.Drawing.Point(7, 201);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle.TabIndex = 138;
            this.btnDetalle.Text = "&Detallar";
            this.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle.texto = "&Detallar";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // dtgValorado
            // 
            this.dtgValorado.AllowUserToAddRows = false;
            this.dtgValorado.AllowUserToDeleteRows = false;
            this.dtgValorado.AllowUserToResizeColumns = false;
            this.dtgValorado.AllowUserToResizeRows = false;
            this.dtgValorado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValorado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValorado.Location = new System.Drawing.Point(3, 275);
            this.dtgValorado.MultiSelect = false;
            this.dtgValorado.Name = "dtgValorado";
            this.dtgValorado.ReadOnly = true;
            this.dtgValorado.RowHeadersVisible = false;
            this.dtgValorado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValorado.Size = new System.Drawing.Size(319, 179);
            this.dtgValorado.TabIndex = 137;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(497, 554);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 140;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(438, 554);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 139;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(622, 554);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 142;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(556, 554);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 141;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtgValoradoAnu
            // 
            this.dtgValoradoAnu.AllowUserToAddRows = false;
            this.dtgValoradoAnu.AllowUserToDeleteRows = false;
            this.dtgValoradoAnu.AllowUserToResizeColumns = false;
            this.dtgValoradoAnu.AllowUserToResizeRows = false;
            this.dtgValoradoAnu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValoradoAnu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValoradoAnu.Location = new System.Drawing.Point(363, 277);
            this.dtgValoradoAnu.MultiSelect = false;
            this.dtgValoradoAnu.Name = "dtgValoradoAnu";
            this.dtgValoradoAnu.ReadOnly = true;
            this.dtgValoradoAnu.RowHeadersVisible = false;
            this.dtgValoradoAnu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValoradoAnu.Size = new System.Drawing.Size(319, 179);
            this.dtgValoradoAnu.TabIndex = 143;
            // 
            // btnMiniPasarIzquierda
            // 
            this.btnMiniPasarIzquierda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniPasarIzquierda.BackgroundImage")));
            this.btnMiniPasarIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniPasarIzquierda.Enabled = false;
            this.btnMiniPasarIzquierda.Location = new System.Drawing.Point(325, 358);
            this.btnMiniPasarIzquierda.Name = "btnMiniPasarIzquierda";
            this.btnMiniPasarIzquierda.Size = new System.Drawing.Size(36, 28);
            this.btnMiniPasarIzquierda.TabIndex = 145;
            this.btnMiniPasarIzquierda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniPasarIzquierda.UseVisualStyleBackColor = true;
            this.btnMiniPasarIzquierda.Click += new System.EventHandler(this.btnMiniPasarIzquierda_Click);
            // 
            // btnMiniPasarDerecha
            // 
            this.btnMiniPasarDerecha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniPasarDerecha.BackgroundImage")));
            this.btnMiniPasarDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniPasarDerecha.Enabled = false;
            this.btnMiniPasarDerecha.Location = new System.Drawing.Point(325, 324);
            this.btnMiniPasarDerecha.Name = "btnMiniPasarDerecha";
            this.btnMiniPasarDerecha.Size = new System.Drawing.Size(36, 28);
            this.btnMiniPasarDerecha.TabIndex = 144;
            this.btnMiniPasarDerecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniPasarDerecha.UseVisualStyleBackColor = true;
            this.btnMiniPasarDerecha.Click += new System.EventHandler(this.btnMiniPasarDerecha_Click);
            // 
            // dtgNuevos
            // 
            this.dtgNuevos.AllowUserToAddRows = false;
            this.dtgNuevos.AllowUserToDeleteRows = false;
            this.dtgNuevos.AllowUserToResizeColumns = false;
            this.dtgNuevos.AllowUserToResizeRows = false;
            this.dtgNuevos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNuevos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNuevos.Location = new System.Drawing.Point(7, 517);
            this.dtgNuevos.MultiSelect = false;
            this.dtgNuevos.Name = "dtgNuevos";
            this.dtgNuevos.ReadOnly = true;
            this.dtgNuevos.RowHeadersVisible = false;
            this.dtgNuevos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNuevos.Size = new System.Drawing.Size(368, 114);
            this.dtgNuevos.TabIndex = 146;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(315, 467);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 148;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(254, 467);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 147;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudFolio
            // 
            this.nudFolio.Enabled = false;
            this.nudFolio.Location = new System.Drawing.Point(91, 493);
            this.nudFolio.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudFolio.Name = "nudFolio";
            this.nudFolio.Size = new System.Drawing.Size(128, 20);
            this.nudFolio.TabIndex = 150;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(3, 497);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(80, 13);
            this.lblBase8.TabIndex = 149;
            this.lblBase8.Text = "Nro de Folio:";
            // 
            // labelTitu1
            // 
            this.labelTitu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTitu1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitu1.ForeColor = System.Drawing.Color.Navy;
            this.labelTitu1.Location = new System.Drawing.Point(3, 256);
            this.labelTitu1.Name = "labelTitu1";
            this.labelTitu1.Size = new System.Drawing.Size(319, 18);
            this.labelTitu1.TabIndex = 151;
            this.labelTitu1.Text = "LISTADO ACTUAL DE OP";
            this.labelTitu1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(363, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 18);
            this.label2.TabIndex = 152;
            this.label2.Text = "OP ANULADOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, 459);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(376, 177);
            this.grbBase2.TabIndex = 153;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Agregar Nuevas Órdenes de Pago";
            // 
            // chcEditar
            // 
            this.chcEditar.AutoSize = true;
            this.chcEditar.Enabled = false;
            this.chcEditar.Location = new System.Drawing.Point(73, 233);
            this.chcEditar.Name = "chcEditar";
            this.chcEditar.Size = new System.Drawing.Size(254, 17);
            this.chcEditar.TabIndex = 154;
            this.chcEditar.Text = "Modificar las Órdenes de Pago para la Impresión";
            this.chcEditar.UseVisualStyleBackColor = true;
            this.chcEditar.CheckedChanged += new System.EventHandler(this.chcEditar_CheckedChanged);
            // 
            // frmControlImpresionOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 663);
            this.Controls.Add(this.chcEditar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTitu1);
            this.Controls.Add(this.nudFolio);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtgNuevos);
            this.Controls.Add(this.btnMiniPasarIzquierda);
            this.Controls.Add(this.btnMiniPasarDerecha);
            this.Controls.Add(this.dtgValoradoAnu);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.dtgValorado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.dtgSolOP);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmControlImpresionOP";
            this.Text = "Control de Impresiones de Ordenes de Pago";
            this.Load += new System.EventHandler(this.frmControlImpresionOP_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtgSolOP, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtgValorado, 0);
            this.Controls.SetChildIndex(this.btnDetalle, 0);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgValoradoAnu, 0);
            this.Controls.SetChildIndex(this.btnMiniPasarDerecha, 0);
            this.Controls.SetChildIndex(this.btnMiniPasarIzquierda, 0);
            this.Controls.SetChildIndex(this.dtgNuevos, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.nudFolio, 0);
            this.Controls.SetChildIndex(this.labelTitu1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.chcEditar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).EndInit();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoradoAnu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNuevos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.dtgBase dtgSolOP;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboAgencia cboAgencias;
        private GEN.BotonesBase.btnDetalle btnDetalle;
        private GEN.ControlesBase.dtgBase dtgValorado;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgValoradoAnu;
        private GEN.BotonesBase.btnMiniPasarIzquierda btnMiniPasarIzquierda;
        private GEN.BotonesBase.btnMiniPasarDerecha btnMiniPasarDerecha;
        private GEN.ControlesBase.dtgBase dtgNuevos;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.ControlesBase.nudBase nudFolio;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.Label labelTitu1;
        private System.Windows.Forms.Label label2;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.chcBase chcEditar;
    }
}