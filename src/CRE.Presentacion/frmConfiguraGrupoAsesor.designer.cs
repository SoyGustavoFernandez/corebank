namespace CRE.Presentacion
{
    partial class frmConfiguraGrupoAsesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguraGrupoAsesor));
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMes = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbParametros = new GEN.ControlesBase.grbBase(this.components);
            this.dtgGrupoAsesor = new GEN.ControlesBase.dtgBase(this.components);
            this.pbxAyuda1 = new GEN.ControlesBase.pbxAyuda();
            this.ttpMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.lblTotal = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.grbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoAsesor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(136, 483);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 6;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(196, 483);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(256, 483);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(376, 483);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 75);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 49);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(34, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Mes:";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(82, 46);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(167, 21);
            this.cboMes.TabIndex = 12;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 11;
            this.lblBase1.Text = "Año:";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(82, 21);
            this.nudAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(58, 20);
            this.nudAnio.TabIndex = 10;
            this.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAnio.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.nudAnio.ValueChanged += new System.EventHandler(this.nudAnio_ValueChanged);
            // 
            // cboAgencia
            // 
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(82, 72);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(167, 21);
            this.cboAgencia.TabIndex = 9;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // grbParametros
            // 
            this.grbParametros.Controls.Add(this.cboMes);
            this.grbParametros.Controls.Add(this.lblBase3);
            this.grbParametros.Controls.Add(this.cboAgencia);
            this.grbParametros.Controls.Add(this.lblBase2);
            this.grbParametros.Controls.Add(this.nudAnio);
            this.grbParametros.Controls.Add(this.lblBase1);
            this.grbParametros.Location = new System.Drawing.Point(16, 4);
            this.grbParametros.Name = "grbParametros";
            this.grbParametros.Size = new System.Drawing.Size(259, 98);
            this.grbParametros.TabIndex = 15;
            this.grbParametros.TabStop = false;
            this.grbParametros.Text = "Parámetros";
            // 
            // dtgGrupoAsesor
            // 
            this.dtgGrupoAsesor.AllowUserToAddRows = false;
            this.dtgGrupoAsesor.AllowUserToDeleteRows = false;
            this.dtgGrupoAsesor.AllowUserToResizeColumns = false;
            this.dtgGrupoAsesor.AllowUserToResizeRows = false;
            this.dtgGrupoAsesor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupoAsesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoAsesor.Enabled = false;
            this.dtgGrupoAsesor.Location = new System.Drawing.Point(16, 108);
            this.dtgGrupoAsesor.MultiSelect = false;
            this.dtgGrupoAsesor.Name = "dtgGrupoAsesor";
            this.dtgGrupoAsesor.ReadOnly = true;
            this.dtgGrupoAsesor.RowHeadersVisible = false;
            this.dtgGrupoAsesor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoAsesor.Size = new System.Drawing.Size(418, 369);
            this.dtgGrupoAsesor.TabIndex = 16;
            // 
            // pbxAyuda1
            // 
            this.pbxAyuda1.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda1.Image")));
            this.pbxAyuda1.Location = new System.Drawing.Point(414, 82);
            this.pbxAyuda1.Name = "pbxAyuda1";
            this.pbxAyuda1.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda1.TabIndex = 17;
            this.pbxAyuda1.TabStop = false;
            this.ttpMensaje.SetToolTip(this.pbxAyuda1, "Recuerde que después de asignar el tipo de grupo \r\ndebe de procesar la asignación" +
        " de metas");
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Enabled = false;
            this.btnProcesar1.Location = new System.Drawing.Point(316, 483);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 18;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblTotal.Location = new System.Drawing.Point(13, 483);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 13);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "Total:";
            // 
            // frmConfiguraGrupoAsesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 563);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.pbxAyuda1);
            this.Controls.Add(this.dtgGrupoAsesor);
            this.Controls.Add(this.grbParametros);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmConfiguraGrupoAsesor";
            this.Text = "Configurar Grupo de Asesores";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.grbParametros, 0);
            this.Controls.SetChildIndex(this.dtgGrupoAsesor, 0);
            this.Controls.SetChildIndex(this.pbxAyuda1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.lblTotal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.grbParametros.ResumeLayout(false);
            this.grbParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoAsesor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMeses cboMes;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase nudAnio;
        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.grbBase grbParametros;
        private GEN.ControlesBase.dtgBase dtgGrupoAsesor;
        private GEN.ControlesBase.pbxAyuda pbxAyuda1;
        private System.Windows.Forms.ToolTip ttpMensaje;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblTotal;
    }
}

