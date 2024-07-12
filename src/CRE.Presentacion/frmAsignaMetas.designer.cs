namespace CRE.Presentacion
{
    partial class frmAsignaMetas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignaMetas));
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.nudAnio = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMes = new GEN.ControlesBase.cboMeses(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnConsultar1 = new GEN.BotonesBase.btnConsultar();
            this.dtgMetas = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboTipoMeta = new GEN.ControlesBase.cboTipoMeta(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.txtTotalMeta = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblAcumula = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboGrupo = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMetas)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencia
            // 
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(94, 69);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(165, 21);
            this.cboAgencia.TabIndex = 2;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(94, 12);
            this.nudAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(58, 20);
            this.nudAnio.TabIndex = 3;
            this.nudAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAnio.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.nudAnio.ValueChanged += new System.EventHandler(this.nudAnio_ValueChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(34, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Año:";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(94, 40);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(165, 21);
            this.cboMes.TabIndex = 5;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(25, 44);
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
            this.lblBase3.Location = new System.Drawing.Point(25, 73);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnConsultar1
            // 
            this.btnConsultar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar1.BackgroundImage")));
            this.btnConsultar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar1.Location = new System.Drawing.Point(294, 104);
            this.btnConsultar1.Name = "btnConsultar1";
            this.btnConsultar1.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar1.TabIndex = 8;
            this.btnConsultar1.Text = "&Consultar";
            this.btnConsultar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar1.UseVisualStyleBackColor = true;
            this.btnConsultar1.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // dtgMetas
            // 
            this.dtgMetas.AllowUserToAddRows = false;
            this.dtgMetas.AllowUserToDeleteRows = false;
            this.dtgMetas.AllowUserToResizeColumns = false;
            this.dtgMetas.AllowUserToResizeRows = false;
            this.dtgMetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMetas.Location = new System.Drawing.Point(10, 160);
            this.dtgMetas.MultiSelect = false;
            this.dtgMetas.Name = "dtgMetas";
            this.dtgMetas.ReadOnly = true;
            this.dtgMetas.RowHeadersVisible = false;
            this.dtgMetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMetas.Size = new System.Drawing.Size(466, 278);
            this.dtgMetas.TabIndex = 9;
            this.dtgMetas.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMetas_CellValidated);
            this.dtgMetas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgMetas_EditingControlShowing);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(25, 127);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Tipo meta:";
            // 
            // cboTipoMeta
            // 
            this.cboTipoMeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMeta.FormattingEnabled = true;
            this.cboTipoMeta.Location = new System.Drawing.Point(94, 124);
            this.cboTipoMeta.Name = "cboTipoMeta";
            this.cboTipoMeta.Size = new System.Drawing.Size(165, 21);
            this.cboTipoMeta.TabIndex = 12;
            this.cboTipoMeta.SelectedIndexChanged += new System.EventHandler(this.cboTipoMeta_SelectedIndexChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(416, 469);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(350, 469);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 14;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtTotalMeta
            // 
            this.txtTotalMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMeta.FormatoDecimal = true;
            this.txtTotalMeta.Location = new System.Drawing.Point(350, 440);
            this.txtTotalMeta.MaxLength = 15;
            this.txtTotalMeta.Name = "txtTotalMeta";
            this.txtTotalMeta.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalMeta.nNumDecimales = 2;
            this.txtTotalMeta.nvalor = 0D;
            this.txtTotalMeta.ReadOnly = true;
            this.txtTotalMeta.Size = new System.Drawing.Size(126, 23);
            this.txtTotalMeta.TabIndex = 15;
            this.txtTotalMeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAcumula
            // 
            this.lblAcumula.AutoSize = true;
            this.lblAcumula.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAcumula.ForeColor = System.Drawing.Color.Navy;
            this.lblAcumula.Location = new System.Drawing.Point(255, 445);
            this.lblAcumula.Name = "lblAcumula";
            this.lblAcumula.Size = new System.Drawing.Size(39, 13);
            this.lblAcumula.TabIndex = 16;
            this.lblAcumula.Text = "Total:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(25, 99);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(47, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Grupo:";
            // 
            // cboGrupo
            // 
            this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(94, 96);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(165, 21);
            this.cboGrupo.TabIndex = 17;
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
            // 
            // frmAsignaMetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 549);
            this.Controls.Add(this.cboGrupo);
            this.Controls.Add(this.lblAcumula);
            this.Controls.Add(this.txtTotalMeta);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.cboTipoMeta);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgMetas);
            this.Controls.Add(this.btnConsultar1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.nudAnio);
            this.Controls.Add(this.cboAgencia);
            this.Name = "frmAsignaMetas";
            this.Text = "Asigna Metas";
            this.Load += new System.EventHandler(this.frmAsignaMetas_Load);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.nudAnio, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboMes, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnConsultar1, 0);
            this.Controls.SetChildIndex(this.dtgMetas, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboTipoMeta, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.txtTotalMeta, 0);
            this.Controls.SetChildIndex(this.lblAcumula, 0);
            this.Controls.SetChildIndex(this.cboGrupo, 0);
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
        private GEN.BotonesBase.btnConsultar btnConsultar1;
        private GEN.ControlesBase.dtgBase dtgMetas;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboTipoMeta cboTipoMeta;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtNumRea txtTotalMeta;
        private GEN.ControlesBase.lblBase lblAcumula;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboGrupo;

    }
}