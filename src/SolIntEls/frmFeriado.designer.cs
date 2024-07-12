namespace SolIntEls
{
    partial class frmFeriado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeriado));
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgFeriado = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpCalendario = new GEN.ControlesBase.dtLargoBase(this.components);
            this.ListaFeriado = new GEN.ControlesBase.lstBase(this.components);
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMotivoFeriado = new GEN.ControlesBase.txtBase(this.components);
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFeriado)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(13, 291);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 3;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(211, 291);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgFeriado
            // 
            this.dtgFeriado.AllowUserToAddRows = false;
            this.dtgFeriado.AllowUserToDeleteRows = false;
            this.dtgFeriado.AllowUserToResizeColumns = false;
            this.dtgFeriado.AllowUserToResizeRows = false;
            this.dtgFeriado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFeriado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFeriado.Location = new System.Drawing.Point(277, 12);
            this.dtgFeriado.MultiSelect = false;
            this.dtgFeriado.Name = "dtgFeriado";
            this.dtgFeriado.ReadOnly = true;
            this.dtgFeriado.RowHeadersVisible = false;
            this.dtgFeriado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFeriado.Size = new System.Drawing.Size(414, 329);
            this.dtgFeriado.TabIndex = 7;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(145, 291);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpCalendario);
            this.grbBase1.Location = new System.Drawing.Point(13, 168);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(257, 54);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Fecha";
            // 
            // dtpCalendario
            // 
            this.dtpCalendario.Location = new System.Drawing.Point(11, 19);
            this.dtpCalendario.Name = "dtpCalendario";
            this.dtpCalendario.Size = new System.Drawing.Size(234, 20);
            this.dtpCalendario.TabIndex = 0;
            // 
            // ListaFeriado
            // 
            this.ListaFeriado.FormattingEnabled = true;
            this.ListaFeriado.Location = new System.Drawing.Point(11, 19);
            this.ListaFeriado.Name = "ListaFeriado";
            this.ListaFeriado.Size = new System.Drawing.Size(235, 69);
            this.ListaFeriado.TabIndex = 0;
            this.ListaFeriado.SelectedIndexChanged += new System.EventHandler(this.ListaFeriado_SelectedIndexChanged);
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(79, 291);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 4;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.ListaFeriado);
            this.grbBase2.Location = new System.Drawing.Point(12, 63);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(257, 99);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Tipo";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtMotivoFeriado);
            this.grbBase3.Location = new System.Drawing.Point(13, 228);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(257, 57);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Motivo del Feriado";
            // 
            // txtMotivoFeriado
            // 
            this.txtMotivoFeriado.Location = new System.Drawing.Point(11, 14);
            this.txtMotivoFeriado.Multiline = true;
            this.txtMotivoFeriado.Name = "txtMotivoFeriado";
            this.txtMotivoFeriado.Size = new System.Drawing.Size(235, 37);
            this.txtMotivoFeriado.TabIndex = 0;
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(12, 18);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(233, 21);
            this.cboAgencia1.TabIndex = 8;
            this.cboAgencia1.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.cboAgencia1);
            this.grbBase4.Location = new System.Drawing.Point(12, 8);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(257, 49);
            this.grbBase4.TabIndex = 9;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Agencia";
            // 
            // frmFeriado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 372);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.dtgFeriado);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAgregar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFeriado";
            this.Text = "Feriados";
            this.Load += new System.EventHandler(this.frmRegistroFeriado_Load);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgFeriado, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFeriado)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.grbBase grbBase1;
        public GEN.ControlesBase.dtgBase dtgFeriado;
        private GEN.ControlesBase.lstBase ListaFeriado;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtLargoBase dtpCalendario;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtMotivoFeriado;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.grbBase grbBase4;

    }
}