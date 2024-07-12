namespace SPL.Presentacion
{
    partial class frmMantenCalificRiesgoScoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenCalificRiesgoScoring));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtColorMuestra = new GEN.ControlesBase.txtBase(this.components);
            this.cboColor = new GEN.ControlesBase.cboBase(this.components);
            this.chcAprobacion = new GEN.ControlesBase.chcBase(this.components);
            this.nudRangoMin = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.nudRangoMax = new GEN.ControlesBase.nudBase(this.components);
            this.chcVigencia = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombreR = new GEN.ControlesBase.txtBase(this.components);
            this.dtgCalificativos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificativos)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtColorMuestra);
            this.grbBase1.Controls.Add(this.cboColor);
            this.grbBase1.Controls.Add(this.chcAprobacion);
            this.grbBase1.Controls.Add(this.nudRangoMin);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.nudRangoMax);
            this.grbBase1.Controls.Add(this.chcVigencia);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtNombreR);
            this.grbBase1.Location = new System.Drawing.Point(12, 310);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(440, 95);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle de calificación de riesgo";
            // 
            // txtColorMuestra
            // 
            this.txtColorMuestra.BackColor = System.Drawing.SystemColors.Window;
            this.txtColorMuestra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColorMuestra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorMuestra.Location = new System.Drawing.Point(190, 68);
            this.txtColorMuestra.Name = "txtColorMuestra";
            this.txtColorMuestra.ReadOnly = true;
            this.txtColorMuestra.Size = new System.Drawing.Size(30, 20);
            this.txtColorMuestra.TabIndex = 76;
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(68, 68);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(121, 21);
            this.cboColor.TabIndex = 75;
            this.cboColor.SelectedIndexChanged += new System.EventHandler(this.cboColor_SelectedIndexChanged);
            // 
            // chcAprobacion
            // 
            this.chcAprobacion.AutoSize = true;
            this.chcAprobacion.Location = new System.Drawing.Point(331, 44);
            this.chcAprobacion.Name = "chcAprobacion";
            this.chcAprobacion.Size = new System.Drawing.Size(103, 17);
            this.chcAprobacion.TabIndex = 74;
            this.chcAprobacion.Text = "Requiere Aprob.";
            this.chcAprobacion.UseVisualStyleBackColor = true;
            this.chcAprobacion.Visible = false;
            // 
            // nudRangoMin
            // 
            this.nudRangoMin.DecimalPlaces = 2;
            this.nudRangoMin.Location = new System.Drawing.Point(77, 42);
            this.nudRangoMin.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudRangoMin.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudRangoMin.Name = "nudRangoMin";
            this.nudRangoMin.Size = new System.Drawing.Size(70, 20);
            this.nudRangoMin.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 71);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(43, 13);
            this.lblBase2.TabIndex = 73;
            this.lblBase2.Text = "Color:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 45);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(71, 13);
            this.lblBase7.TabIndex = 73;
            this.lblBase7.Text = "Rango Min:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(153, 45);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(75, 13);
            this.lblBase10.TabIndex = 72;
            this.lblBase10.Text = "Rango Max:";
            // 
            // nudRangoMax
            // 
            this.nudRangoMax.DecimalPlaces = 2;
            this.nudRangoMax.Location = new System.Drawing.Point(228, 42);
            this.nudRangoMax.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudRangoMax.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudRangoMax.Name = "nudRangoMax";
            this.nudRangoMax.Size = new System.Drawing.Size(70, 20);
            this.nudRangoMax.TabIndex = 2;
            // 
            // chcVigencia
            // 
            this.chcVigencia.AutoSize = true;
            this.chcVigencia.Location = new System.Drawing.Point(367, 15);
            this.chcVigencia.Name = "chcVigencia";
            this.chcVigencia.Size = new System.Drawing.Size(67, 17);
            this.chcVigencia.TabIndex = 3;
            this.chcVigencia.Text = "Vigencia";
            this.chcVigencia.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtNombreR
            // 
            this.txtNombreR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreR.Location = new System.Drawing.Point(68, 16);
            this.txtNombreR.Name = "txtNombreR";
            this.txtNombreR.Size = new System.Drawing.Size(230, 20);
            this.txtNombreR.TabIndex = 0;
            // 
            // dtgCalificativos
            // 
            this.dtgCalificativos.AllowUserToAddRows = false;
            this.dtgCalificativos.AllowUserToDeleteRows = false;
            this.dtgCalificativos.AllowUserToResizeColumns = false;
            this.dtgCalificativos.AllowUserToResizeRows = false;
            this.dtgCalificativos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCalificativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCalificativos.Location = new System.Drawing.Point(12, 12);
            this.dtgCalificativos.MultiSelect = false;
            this.dtgCalificativos.Name = "dtgCalificativos";
            this.dtgCalificativos.ReadOnly = true;
            this.dtgCalificativos.RowHeadersVisible = false;
            this.dtgCalificativos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCalificativos.Size = new System.Drawing.Size(440, 292);
            this.dtgCalificativos.TabIndex = 0;
            this.dtgCalificativos.SelectionChanged += new System.EventHandler(this.dtgCalificativos_SelectionChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(326, 411);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(194, 411);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(392, 411);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(128, 411);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(260, 411);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmMantenCalificRiesgoScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 486);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dtgCalificativos);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenCalificRiesgoScoring";
            this.Text = "Mantenimiento calificativos de riesgo Scoring";
            this.Load += new System.EventHandler(this.frmMantenCalificRiesgoScoring_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgCalificativos, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangoMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificativos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcVigencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombreR;
        private GEN.ControlesBase.nudBase nudRangoMin;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.nudBase nudRangoMax;
        private GEN.ControlesBase.dtgBase dtgCalificativos;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.chcBase chcAprobacion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboColor;
        private GEN.ControlesBase.txtBase txtColorMuestra;
    }
}