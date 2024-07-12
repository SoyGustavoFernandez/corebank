namespace CRE.Presentacion
{
    partial class frmPagoFechaValor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoFechaValor));
            this.cboMotivo = new GEN.ControlesBase.cboMotivoFechaValor(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.btnDescargar = new GEN.BotonesBase.btnDescargar();
            this.lblCantidadSustentos = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.btnValidar = new GEN.BotonesBase.btnValidar();
            this.btnArchivos = new GEN.BotonesBase.btnCargarFile();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMotivo
            // 
            this.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivo.FormattingEnabled = true;
            this.cboMotivo.Location = new System.Drawing.Point(576, 22);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Size = new System.Drawing.Size(173, 21);
            this.cboMotivo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ruta de Archivo:";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(99, 22);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.ReadOnly = true;
            this.txtRutaArchivo.Size = new System.Drawing.Size(422, 20);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPorcentaje);
            this.groupBox1.Controls.Add(this.progressBarLoading);
            this.groupBox1.Controls.Add(this.btnDescargar);
            this.groupBox1.Controls.Add(this.lblCantidadSustentos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblContador);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.btnImportar);
            this.groupBox1.Controls.Add(this.btnValidar);
            this.groupBox1.Controls.Add(this.btnArchivos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSustento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRutaArchivo);
            this.groupBox1.Controls.Add(this.cboMotivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1229, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta Masiva Fecha Valor";
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.BackColor = System.Drawing.Color.DarkKhaki;
            this.progressBarLoading.Location = new System.Drawing.Point(765, 90);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(456, 7);
            this.progressBarLoading.TabIndex = 15;
            this.progressBarLoading.Visible = false;
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDescargar.BackgroundImage")));
            this.btnDescargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDescargar.Location = new System.Drawing.Point(765, 19);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(60, 50);
            this.btnDescargar.TabIndex = 14;
            this.btnDescargar.Text = "&Plantilla";
            this.btnDescargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // lblCantidadSustentos
            // 
            this.lblCantidadSustentos.AutoSize = true;
            this.lblCantidadSustentos.Location = new System.Drawing.Point(234, 100);
            this.lblCantidadSustentos.Name = "lblCantidadSustentos";
            this.lblCantidadSustentos.Size = new System.Drawing.Size(13, 13);
            this.lblCantidadSustentos.TabIndex = 13;
            this.lblCantidadSustentos.TabStop = true;
            this.lblCantidadSustentos.Text = "0";
            this.lblCantidadSustentos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCantidadSustentos_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad de Archivos  de Sustento Cargados:";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(713, 100);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(36, 13);
            this.lblContador.TabIndex = 10;
            this.lblContador.Text = "0/250";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(1161, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(1095, 19);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 8;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(1029, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Location = new System.Drawing.Point(831, 19);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 4;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidar.BackgroundImage")));
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidar.Location = new System.Drawing.Point(963, 19);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(60, 50);
            this.btnValidar.TabIndex = 6;
            this.btnValidar.Text = "&Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnArchivos
            // 
            this.btnArchivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnArchivos.BackgroundImage")));
            this.btnArchivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArchivos.Location = new System.Drawing.Point(897, 19);
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(60, 50);
            this.btnArchivos.TabIndex = 5;
            this.btnArchivos.Text = "&Archivos";
            this.btnArchivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArchivos.UseVisualStyleBackColor = true;
            this.btnArchivos.Click += new System.EventHandler(this.btnArchivos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sustento:";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(99, 47);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSustento.Size = new System.Drawing.Size(650, 50);
            this.txtSustento.TabIndex = 3;
            this.txtSustento.TextChanged += new System.EventHandler(this.txtSustento_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Motivo:";
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AllowUserToDeleteRows = false;
            this.dtgDatos.AllowUserToResizeColumns = false;
            this.dtgDatos.AllowUserToResizeRows = false;
            this.dtgDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgDatos.Location = new System.Drawing.Point(12, 144);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.RowHeadersVisible = false;
            this.dtgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatos.Size = new System.Drawing.Size(1229, 253);
            this.dtgDatos.TabIndex = 6;
            this.dtgDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellClick);
            this.dtgDatos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgDatos_CellPainting);
            this.dtgDatos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellValueChanged);
            this.dtgDatos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgDatos_CurrentCellDirtyStateChanged);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(974, 74);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(0, 13);
            this.lblPorcentaje.TabIndex = 16;
            // 
            // frmPagoFechaValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 422);
            this.Controls.Add(this.dtgDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPagoFechaValor";
            this.Text = "Pagos Masivos con Fecha Valor";
            this.Load += new System.EventHandler(this.frmPagoFechaValor_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dtgDatos, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboMotivoFechaValor cboMotivo;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.txtBase txtRutaArchivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.BotonesBase.btnValidar btnValidar;
        private GEN.BotonesBase.btnCargarFile btnArchivos;
        private System.Windows.Forms.Label label3;
        private GEN.ControlesBase.txtBase txtSustento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgDatos;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.LinkLabel lblCantidadSustentos;
        private GEN.BotonesBase.btnDescargar btnDescargar;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private System.Windows.Forms.Label lblPorcentaje;
    }
}