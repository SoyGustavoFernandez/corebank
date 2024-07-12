namespace CRE.Presentacion
{
    partial class frmCargarGastosJudiciales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarGastosJudiciales));
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.gbxDatosCarga = new System.Windows.Forms.GroupBox();
            this.rbtAcuerdoCliente = new System.Windows.Forms.RadioButton();
            this.rbtSentenciaJudicial = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgCargosJudiciales = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.gbxDatosCarga.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargosJudiciales)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli1.Location = new System.Drawing.Point(55, 12);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(564, 100);
            this.conBusCuentaCli1.TabIndex = 2;
            // 
            // gbxDatosCarga
            // 
            this.gbxDatosCarga.Controls.Add(this.rbtAcuerdoCliente);
            this.gbxDatosCarga.Controls.Add(this.rbtSentenciaJudicial);
            this.gbxDatosCarga.Location = new System.Drawing.Point(55, 119);
            this.gbxDatosCarga.Name = "gbxDatosCarga";
            this.gbxDatosCarga.Size = new System.Drawing.Size(564, 46);
            this.gbxDatosCarga.TabIndex = 3;
            this.gbxDatosCarga.TabStop = false;
            this.gbxDatosCarga.Text = "Datos de carga";
            // 
            // rbtAcuerdoCliente
            // 
            this.rbtAcuerdoCliente.AutoSize = true;
            this.rbtAcuerdoCliente.Location = new System.Drawing.Point(288, 19);
            this.rbtAcuerdoCliente.Name = "rbtAcuerdoCliente";
            this.rbtAcuerdoCliente.Size = new System.Drawing.Size(131, 17);
            this.rbtAcuerdoCliente.TabIndex = 1;
            this.rbtAcuerdoCliente.Text = "Acuerdo con el cliente";
            this.rbtAcuerdoCliente.UseVisualStyleBackColor = true;
            // 
            // rbtSentenciaJudicial
            // 
            this.rbtSentenciaJudicial.AutoSize = true;
            this.rbtSentenciaJudicial.Checked = true;
            this.rbtSentenciaJudicial.Location = new System.Drawing.Point(163, 18);
            this.rbtSentenciaJudicial.Name = "rbtSentenciaJudicial";
            this.rbtSentenciaJudicial.Size = new System.Drawing.Size(102, 17);
            this.rbtSentenciaJudicial.TabIndex = 0;
            this.rbtSentenciaJudicial.TabStop = true;
            this.rbtSentenciaJudicial.Text = "Sentecia judicial";
            this.rbtSentenciaJudicial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgCargosJudiciales);
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 268);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gastos Judiciales Pendientes";
            // 
            // dtgCargosJudiciales
            // 
            this.dtgCargosJudiciales.AllowUserToAddRows = false;
            this.dtgCargosJudiciales.AllowUserToDeleteRows = false;
            this.dtgCargosJudiciales.AllowUserToResizeColumns = false;
            this.dtgCargosJudiciales.AllowUserToResizeRows = false;
            this.dtgCargosJudiciales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCargosJudiciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCargosJudiciales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCargosJudiciales.Location = new System.Drawing.Point(3, 16);
            this.dtgCargosJudiciales.MultiSelect = false;
            this.dtgCargosJudiciales.Name = "dtgCargosJudiciales";
            this.dtgCargosJudiciales.RowHeadersVisible = false;
            this.dtgCargosJudiciales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCargosJudiciales.Size = new System.Drawing.Size(633, 249);
            this.dtgCargosJudiciales.TabIndex = 1;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(456, 450);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(522, 450);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(588, 450);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmCargarGastosJudiciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 537);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxDatosCarga);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Name = "frmCargarGastosJudiciales";
            this.Text = "Cargar Gastos Judiciales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargarGastosJudiciales_FormClosing);
            this.Load += new System.EventHandler(this.frmCargarGastosJudiciales_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.gbxDatosCarga, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.gbxDatosCarga.ResumeLayout(false);
            this.gbxDatosCarga.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCargosJudiciales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private System.Windows.Forms.GroupBox gbxDatosCarga;
        private System.Windows.Forms.RadioButton rbtAcuerdoCliente;
        private System.Windows.Forms.RadioButton rbtSentenciaJudicial;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgCargosJudiciales;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}