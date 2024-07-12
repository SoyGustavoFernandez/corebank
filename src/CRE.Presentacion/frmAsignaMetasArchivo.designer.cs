namespace CRE.Presentacion
{
    partial class frmAsignaMetasArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignaMetasArchivo));
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMes = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.dtgMetas = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.txtUbicacionArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnExporExcel = new GEN.BotonesBase.btnExporExcel();
            this.txtMetaSaldo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblTotal = new GEN.ControlesBase.lblBase();
            this.txtMetaCienteNuevo = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtMetaCrecimiento = new GEN.ControlesBase.txtNumerico(this.components);
            this.chcAsesoresNuevos = new GEN.ControlesBase.chcBase(this.components);
            this.chcAsesoresCesados = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMetas)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencia
            // 
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(90, 12);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(301, 21);
            this.cboAgencia.TabIndex = 3;
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(90, 39);
            this.nudAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(134, 20);
            this.nudAnio.TabIndex = 1;
            this.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAnio.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 43);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Año:";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(271, 39);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(120, 21);
            this.cboMes.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(229, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Mes:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(19, 16);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(556, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtgMetas
            // 
            this.dtgMetas.AllowUserToAddRows = false;
            this.dtgMetas.AllowUserToDeleteRows = false;
            this.dtgMetas.AllowUserToResizeColumns = false;
            this.dtgMetas.AllowUserToResizeRows = false;
            this.dtgMetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMetas.Location = new System.Drawing.Point(4, 69);
            this.dtgMetas.MultiSelect = false;
            this.dtgMetas.Name = "dtgMetas";
            this.dtgMetas.ReadOnly = true;
            this.dtgMetas.RowHeadersVisible = false;
            this.dtgMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMetas.Size = new System.Drawing.Size(1000, 311);
            this.dtgMetas.TabIndex = 5;
            this.dtgMetas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMetas_CellEnter);
            this.dtgMetas.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMetas_CellLeave);
            this.dtgMetas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgMetas_EditingControlShowing);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(944, 416);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(824, 416);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtUbicacionArchivo
            // 
            this.txtUbicacionArchivo.Enabled = false;
            this.txtUbicacionArchivo.Location = new System.Drawing.Point(321, 431);
            this.txtUbicacionArchivo.Name = "txtUbicacionArchivo";
            this.txtUbicacionArchivo.Size = new System.Drawing.Size(296, 20);
            this.txtUbicacionArchivo.TabIndex = 19;
            this.txtUbicacionArchivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(256, 434);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(65, 13);
            this.lblBase6.TabIndex = 20;
            this.lblBase6.Text = "Direccion:";
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Enabled = false;
            this.btnImportar.Location = new System.Drawing.Point(620, 416);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 0;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(884, 416);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(764, 416);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExporExcel
            // 
            this.btnExporExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel.BackgroundImage")));
            this.btnExporExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel.Location = new System.Drawing.Point(680, 416);
            this.btnExporExcel.Name = "btnExporExcel";
            this.btnExporExcel.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel.TabIndex = 22;
            this.btnExporExcel.Text = "E&xcel";
            this.btnExporExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel.UseVisualStyleBackColor = true;
            this.btnExporExcel.Click += new System.EventHandler(this.btnExporExcel_Click);
            // 
            // txtMetaSaldo
            // 
            this.txtMetaSaldo.Enabled = false;
            this.txtMetaSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetaSaldo.FormatoDecimal = false;
            this.txtMetaSaldo.Location = new System.Drawing.Point(736, 386);
            this.txtMetaSaldo.Name = "txtMetaSaldo";
            this.txtMetaSaldo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMetaSaldo.nNumDecimales = 4;
            this.txtMetaSaldo.nvalor = 0D;
            this.txtMetaSaldo.Size = new System.Drawing.Size(100, 20);
            this.txtMetaSaldo.TabIndex = 25;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblTotal.Location = new System.Drawing.Point(691, 389);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 13);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Total:";
            // 
            // txtMetaCienteNuevo
            // 
            this.txtMetaCienteNuevo.Enabled = false;
            this.txtMetaCienteNuevo.Format = "n2";
            this.txtMetaCienteNuevo.Location = new System.Drawing.Point(913, 386);
            this.txtMetaCienteNuevo.Name = "txtMetaCienteNuevo";
            this.txtMetaCienteNuevo.Size = new System.Drawing.Size(71, 20);
            this.txtMetaCienteNuevo.TabIndex = 27;
            // 
            // txtMetaCrecimiento
            // 
            this.txtMetaCrecimiento.Enabled = false;
            this.txtMetaCrecimiento.Format = "n2";
            this.txtMetaCrecimiento.Location = new System.Drawing.Point(839, 386);
            this.txtMetaCrecimiento.Name = "txtMetaCrecimiento";
            this.txtMetaCrecimiento.Size = new System.Drawing.Size(71, 20);
            this.txtMetaCrecimiento.TabIndex = 28;
            // 
            // chcAsesoresNuevos
            // 
            this.chcAsesoresNuevos.AutoSize = true;
            this.chcAsesoresNuevos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcAsesoresNuevos.ForeColor = System.Drawing.Color.LimeGreen;
            this.chcAsesoresNuevos.Location = new System.Drawing.Point(397, 41);
            this.chcAsesoresNuevos.Name = "chcAsesoresNuevos";
            this.chcAsesoresNuevos.Size = new System.Drawing.Size(153, 17);
            this.chcAsesoresNuevos.TabIndex = 29;
            this.chcAsesoresNuevos.Text = "Solo Asesores Nuevos";
            this.chcAsesoresNuevos.UseVisualStyleBackColor = true;
            // 
            // chcAsesoresCesados
            // 
            this.chcAsesoresCesados.AutoSize = true;
            this.chcAsesoresCesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcAsesoresCesados.ForeColor = System.Drawing.Color.Red;
            this.chcAsesoresCesados.Location = new System.Drawing.Point(397, 14);
            this.chcAsesoresCesados.Name = "chcAsesoresCesados";
            this.chcAsesoresCesados.Size = new System.Drawing.Size(158, 17);
            this.chcAsesoresCesados.TabIndex = 30;
            this.chcAsesoresCesados.Text = "Solo Asesores Cesados";
            this.chcAsesoresCesados.UseVisualStyleBackColor = true;
            // 
            // frmAsignaMetasArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 491);
            this.Controls.Add(this.chcAsesoresCesados);
            this.Controls.Add(this.chcAsesoresNuevos);
            this.Controls.Add(this.txtMetaCrecimiento);
            this.Controls.Add(this.txtMetaCienteNuevo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtMetaSaldo);
            this.Controls.Add(this.btnExporExcel);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtUbicacionArchivo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgMetas);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.nudAnio);
            this.Controls.Add(this.cboAgencia);
            this.Name = "frmAsignaMetasArchivo";
            this.Text = "Asigna Metas";
            this.Load += new System.EventHandler(this.frmAsignaMetas_Load);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.nudAnio, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboMes, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            this.Controls.SetChildIndex(this.dtgMetas, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.txtUbicacionArchivo, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnExporExcel, 0);
            this.Controls.SetChildIndex(this.txtMetaSaldo, 0);
            this.Controls.SetChildIndex(this.lblTotal, 0);
            this.Controls.SetChildIndex(this.txtMetaCienteNuevo, 0);
            this.Controls.SetChildIndex(this.txtMetaCrecimiento, 0);
            this.Controls.SetChildIndex(this.chcAsesoresNuevos, 0);
            this.Controls.SetChildIndex(this.chcAsesoresCesados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMeses cboMes;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.ControlesBase.dtgBase dtgMetas;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.txtBase txtUbicacionArchivo;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnExporExcel btnExporExcel;
        private GEN.ControlesBase.txtNumRea txtMetaSaldo;
        private GEN.ControlesBase.lblBase lblTotal;
        private GEN.ControlesBase.txtNumerico txtMetaCienteNuevo;
        private GEN.ControlesBase.txtNumerico txtMetaCrecimiento;
        private GEN.ControlesBase.chcBase chcAsesoresNuevos;
        private GEN.ControlesBase.chcBase chcAsesoresCesados;
    }
}