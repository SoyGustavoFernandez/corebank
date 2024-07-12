namespace ADM.Presentacion
{
    partial class frmVisitaSupervisionResumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisitaSupervisionResumen));
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.btnFinalizar1 = new GEN.BotonesBase.btnFinalizar();
            this.lblCalificativo = new System.Windows.Forms.Label();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgResumen = new GEN.ControlesBase.dtgBase(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEvaluar = new GEN.BotonesBase.btnPuntaje();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnLogin = new GEN.BotonesBase.btnMiniLogin(this.components);
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.dtgInterviene = new GEN.ControlesBase.dtgBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumen)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInterviene)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(342, 423);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 39;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // btnFinalizar1
            // 
            this.btnFinalizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinalizar1.BackgroundImage")));
            this.btnFinalizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFinalizar1.Location = new System.Drawing.Point(207, 423);
            this.btnFinalizar1.Name = "btnFinalizar1";
            this.btnFinalizar1.Size = new System.Drawing.Size(60, 50);
            this.btnFinalizar1.TabIndex = 38;
            this.btnFinalizar1.Text = "Finalizar";
            this.btnFinalizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFinalizar1.UseVisualStyleBackColor = true;
            this.btnFinalizar1.Visible = false;
            this.btnFinalizar1.Click += new System.EventHandler(this.btnFinalizar1_Click);
            // 
            // lblCalificativo
            // 
            this.lblCalificativo.AutoSize = true;
            this.lblCalificativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalificativo.Location = new System.Drawing.Point(122, 13);
            this.lblCalificativo.Name = "lblCalificativo";
            this.lblCalificativo.Size = new System.Drawing.Size(115, 13);
            this.lblCalificativo.TabIndex = 37;
            this.lblCalificativo.Text = "SIN CALIFICATIVO";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(96, 13);
            this.lblBase1.TabIndex = 36;
            this.lblBase1.Text = "CALIFICATIVO:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgResumen);
            this.grbBase1.Location = new System.Drawing.Point(12, 39);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(516, 202);
            this.grbBase1.TabIndex = 32;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Resumen de la Evaluación";
            // 
            // dtgResumen
            // 
            this.dtgResumen.AllowUserToAddRows = false;
            this.dtgResumen.AllowUserToDeleteRows = false;
            this.dtgResumen.AllowUserToResizeColumns = false;
            this.dtgResumen.AllowUserToResizeRows = false;
            this.dtgResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResumen.Location = new System.Drawing.Point(7, 20);
            this.dtgResumen.MultiSelect = false;
            this.dtgResumen.Name = "dtgResumen";
            this.dtgResumen.ReadOnly = true;
            this.dtgResumen.RowHeadersVisible = false;
            this.dtgResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgResumen.Size = new System.Drawing.Size(503, 177);
            this.dtgResumen.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ADM.Presentacion.Properties.Resources.btnEconomica;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(273, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 50);
            this.button1.TabIndex = 35;
            this.button1.Text = "Resultado";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(474, 423);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 34;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEvaluar.BackgroundImage")));
            this.btnEvaluar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEvaluar.Location = new System.Drawing.Point(408, 423);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(62, 50);
            this.btnEvaluar.TabIndex = 33;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnLogin);
            this.grbBase2.Controls.Add(this.btnMiniQuitar1);
            this.grbBase2.Controls.Add(this.dtgInterviene);
            this.grbBase2.Controls.Add(this.btnMiniAgregar1);
            this.grbBase2.Location = new System.Drawing.Point(12, 247);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(522, 170);
            this.grbBase2.TabIndex = 31;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Participantes de la Evaluación";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.Location = new System.Drawing.Point(390, 134);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(36, 28);
            this.btnLogin.TabIndex = 29;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(432, 134);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 3;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // dtgInterviene
            // 
            this.dtgInterviene.AllowUserToAddRows = false;
            this.dtgInterviene.AllowUserToDeleteRows = false;
            this.dtgInterviene.AllowUserToResizeColumns = false;
            this.dtgInterviene.AllowUserToResizeRows = false;
            this.dtgInterviene.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgInterviene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInterviene.Location = new System.Drawing.Point(7, 19);
            this.dtgInterviene.MultiSelect = false;
            this.dtgInterviene.Name = "dtgInterviene";
            this.dtgInterviene.ReadOnly = true;
            this.dtgInterviene.RowHeadersVisible = false;
            this.dtgInterviene.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInterviene.Size = new System.Drawing.Size(503, 109);
            this.dtgInterviene.TabIndex = 1;
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(474, 134);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 2;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // frmVisitaSupervisionResumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 505);
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.btnFinalizar1);
            this.Controls.Add(this.lblCalificativo);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEvaluar);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmVisitaSupervisionResumen";
            this.Text = "Resumen de Evaluación de Visita de Supervisión";
            this.Load += new System.EventHandler(this.frmVisitaSupervisionResumen_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnEvaluar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblCalificativo, 0);
            this.Controls.SetChildIndex(this.btnFinalizar1, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumen)).EndInit();
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInterviene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.BotonesBase.btnFinalizar btnFinalizar1;
        private System.Windows.Forms.Label lblCalificativo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgResumen;
        private System.Windows.Forms.Button button1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnPuntaje btnEvaluar;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnMiniLogin btnLogin;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.ControlesBase.dtgBase dtgInterviene;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;

    }
}