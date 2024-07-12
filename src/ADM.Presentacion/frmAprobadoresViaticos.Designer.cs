namespace ADM.Presentacion
{
    partial class frmAprobadoresViaticos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobadoresViaticos));
            this.cboSolicitante = new System.Windows.Forms.ComboBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboEtapa = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboAprobador = new System.Windows.Forms.ComboBox();
            this.dtgConfigAprobadores = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoEntrega1 = new GEN.ControlesBase.cboTipoEntrega(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAlcance = new GEN.ControlesBase.cboBase(this.components);
            this.lblAlcance = new GEN.ControlesBase.lblBase();
            this.btnAgregar2 = new GEN.BotonesBase.btnAgregar();
            this.dtgPerfilAlcance = new GEN.ControlesBase.dtgBase(this.components);
            this.cboPerfilNivel = new System.Windows.Forms.ComboBox();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigAprobadores)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfilAlcance)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSolicitante
            // 
            this.cboSolicitante.FormattingEnabled = true;
            this.cboSolicitante.Location = new System.Drawing.Point(115, 58);
            this.cboSolicitante.Name = "cboSolicitante";
            this.cboSolicitante.Size = new System.Drawing.Size(360, 21);
            this.cboSolicitante.TabIndex = 2;
            this.cboSolicitante.SelectedIndexChanged += new System.EventHandler(this.cboSolicitante_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(73, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(36, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo:";
            // 
            // cboEtapa
            // 
            this.cboEtapa.FormattingEnabled = true;
            this.cboEtapa.Location = new System.Drawing.Point(115, 34);
            this.cboEtapa.Name = "cboEtapa";
            this.cboEtapa.Size = new System.Drawing.Size(218, 21);
            this.cboEtapa.TabIndex = 6;
            this.cboEtapa.SelectedIndexChanged += new System.EventHandler(this.cboEtapa_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(65, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Etapa:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(5, 66);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(104, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Perfil Solicitante:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(4, 91);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(105, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Perfil Aprobador:";
            // 
            // cboAprobador
            // 
            this.cboAprobador.FormattingEnabled = true;
            this.cboAprobador.Location = new System.Drawing.Point(115, 83);
            this.cboAprobador.Name = "cboAprobador";
            this.cboAprobador.Size = new System.Drawing.Size(360, 21);
            this.cboAprobador.TabIndex = 8;
            this.cboAprobador.SelectedIndexChanged += new System.EventHandler(this.cboAprobador_SelectedIndexChanged);
            // 
            // dtgConfigAprobadores
            // 
            this.dtgConfigAprobadores.AllowUserToAddRows = false;
            this.dtgConfigAprobadores.AllowUserToDeleteRows = false;
            this.dtgConfigAprobadores.AllowUserToResizeColumns = false;
            this.dtgConfigAprobadores.AllowUserToResizeRows = false;
            this.dtgConfigAprobadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfigAprobadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigAprobadores.Location = new System.Drawing.Point(3, 19);
            this.dtgConfigAprobadores.MultiSelect = false;
            this.dtgConfigAprobadores.Name = "dtgConfigAprobadores";
            this.dtgConfigAprobadores.ReadOnly = true;
            this.dtgConfigAprobadores.RowHeadersVisible = false;
            this.dtgConfigAprobadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigAprobadores.Size = new System.Drawing.Size(595, 152);
            this.dtgConfigAprobadores.TabIndex = 10;
            this.dtgConfigAprobadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConfigAprobadores_CellClick);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoEntrega1);
            this.grbBase1.Controls.Add(this.cboEtapa);
            this.grbBase1.Controls.Add(this.cboSolicitante);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboAprobador);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(6, 6);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(487, 119);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros:";
            // 
            // cboTipoEntrega1
            // 
            this.cboTipoEntrega1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntrega1.FormattingEnabled = true;
            this.cboTipoEntrega1.Location = new System.Drawing.Point(115, 8);
            this.cboTipoEntrega1.Name = "cboTipoEntrega1";
            this.cboTipoEntrega1.Size = new System.Drawing.Size(218, 21);
            this.cboTipoEntrega1.TabIndex = 17;
            this.cboTipoEntrega1.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntrega_SelectedIndexChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgConfigAprobadores);
            this.grbBase2.Location = new System.Drawing.Point(8, 140);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(604, 178);
            this.grbBase2.TabIndex = 12;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Perfil Aprobadores - Solicitantes";
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.Location = new System.Drawing.Point(574, 394);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 14;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(541, 64);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 15;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 392);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbBase1);
            this.tabPage1.Controls.Add(this.grbBase2);
            this.tabPage1.Controls.Add(this.btnAgregar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(618, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Aprobadores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbBase3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alcance de Perfiles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboAlcance);
            this.grbBase3.Controls.Add(this.lblAlcance);
            this.grbBase3.Controls.Add(this.btnAgregar2);
            this.grbBase3.Controls.Add(this.dtgPerfilAlcance);
            this.grbBase3.Controls.Add(this.cboPerfilNivel);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Location = new System.Drawing.Point(6, 6);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(606, 354);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Alcance de Perfiles:";
            // 
            // cboAlcance
            // 
            this.cboAlcance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlcance.FormattingEnabled = true;
            this.cboAlcance.Location = new System.Drawing.Point(69, 64);
            this.cboAlcance.Name = "cboAlcance";
            this.cboAlcance.Size = new System.Drawing.Size(345, 21);
            this.cboAlcance.TabIndex = 16;
            this.cboAlcance.SelectedIndexChanged += new System.EventHandler(this.cboAlcance_SelectedIndexChanged);
            // 
            // lblAlcance
            // 
            this.lblAlcance.AutoSize = true;
            this.lblAlcance.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAlcance.ForeColor = System.Drawing.Color.Navy;
            this.lblAlcance.Location = new System.Drawing.Point(7, 70);
            this.lblAlcance.Name = "lblAlcance";
            this.lblAlcance.Size = new System.Drawing.Size(56, 13);
            this.lblAlcance.TabIndex = 15;
            this.lblAlcance.Text = "Alcance:";
            // 
            // btnAgregar2
            // 
            this.btnAgregar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar2.BackgroundImage")));
            this.btnAgregar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar2.Location = new System.Drawing.Point(420, 37);
            this.btnAgregar2.Name = "btnAgregar2";
            this.btnAgregar2.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar2.TabIndex = 13;
            this.btnAgregar2.Text = "&Agregar";
            this.btnAgregar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar2.UseVisualStyleBackColor = true;
            this.btnAgregar2.Click += new System.EventHandler(this.btnAgregar2_Click);
            // 
            // dtgPerfilAlcance
            // 
            this.dtgPerfilAlcance.AllowUserToAddRows = false;
            this.dtgPerfilAlcance.AllowUserToDeleteRows = false;
            this.dtgPerfilAlcance.AllowUserToResizeColumns = false;
            this.dtgPerfilAlcance.AllowUserToResizeRows = false;
            this.dtgPerfilAlcance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPerfilAlcance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPerfilAlcance.Location = new System.Drawing.Point(21, 93);
            this.dtgPerfilAlcance.MultiSelect = false;
            this.dtgPerfilAlcance.Name = "dtgPerfilAlcance";
            this.dtgPerfilAlcance.ReadOnly = true;
            this.dtgPerfilAlcance.RowHeadersVisible = false;
            this.dtgPerfilAlcance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPerfilAlcance.Size = new System.Drawing.Size(545, 152);
            this.dtgPerfilAlcance.TabIndex = 10;
            this.dtgPerfilAlcance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPerfilAlcance_CellClick);
            // 
            // cboPerfilNivel
            // 
            this.cboPerfilNivel.FormattingEnabled = true;
            this.cboPerfilNivel.Location = new System.Drawing.Point(69, 37);
            this.cboPerfilNivel.Name = "cboPerfilNivel";
            this.cboPerfilNivel.Size = new System.Drawing.Size(345, 21);
            this.cboPerfilNivel.TabIndex = 8;
            this.cboPerfilNivel.SelectedIndexChanged += new System.EventHandler(this.cboPerfilNivel_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(18, 40);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Perfil :";
            // 
            // frmAprobadoresViaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSalir2);
            this.Name = "frmAprobadoresViaticos";
            this.Text = "Aprobadores de Viáticos y Entregas a Rendir";
            this.Load += new System.EventHandler(this.frmAprobadoresViaticos_Load);
            this.Controls.SetChildIndex(this.btnSalir2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigAprobadores)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfilAlcance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSolicitante;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboEtapa;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.ComboBox cboAprobador;
        private GEN.ControlesBase.dtgBase dtgConfigAprobadores;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnSalir btnSalir2;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.grbBase grbBase3;
        private System.Windows.Forms.ComboBox cboPerfilNivel;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgPerfilAlcance;
        private GEN.BotonesBase.btnAgregar btnAgregar2;
        private GEN.ControlesBase.cboBase cboAlcance;
        private GEN.ControlesBase.lblBase lblAlcance;
        private GEN.ControlesBase.cboTipoEntrega cboTipoEntrega1;
    }
}