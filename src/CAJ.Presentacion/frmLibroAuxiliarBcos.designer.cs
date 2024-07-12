namespace CAJ.Presentacion
{
    partial class frmLibroAuxiliarBcos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroAuxiliarBcos));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAnio = new GEN.ControlesBase.cboBase(this.components);
            this.cboMes = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.lblCtas = new GEN.ControlesBase.lblBase();
            this.chklbCuentas = new GEN.ControlesBase.chklbBase(this.components);
            this.cboInstitucion = new GEN.ControlesBase.cboBase(this.components);
            this.lblInstitucion = new GEN.ControlesBase.lblBase();
            this.dtgExtractoCta = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.cboCuentas = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtractoCta)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAnio);
            this.grbBase1.Controls.Add(this.cboMes);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(360, 51);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(118, 19);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(57, 21);
            this.cboAnio.TabIndex = 3;
            this.cboAnio.SelectedIndexChanged += new System.EventHandler(this.cboAnio_SelectedIndexChanged);
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(181, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(106, 21);
            this.cboMes.TabIndex = 2;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Periodo Proceso:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.chcSelec);
            this.grbBase2.Controls.Add(this.lblCtas);
            this.grbBase2.Controls.Add(this.chklbCuentas);
            this.grbBase2.Controls.Add(this.cboInstitucion);
            this.grbBase2.Controls.Add(this.lblInstitucion);
            this.grbBase2.Location = new System.Drawing.Point(12, 54);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(360, 221);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcSelec.Location = new System.Drawing.Point(238, 45);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(110, 17);
            this.chcSelec.TabIndex = 124;
            this.chcSelec.Text = "Seleccionar Todo";
            this.chcSelec.UseVisualStyleBackColor = false;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // lblCtas
            // 
            this.lblCtas.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCtas.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCtas.ForeColor = System.Drawing.Color.Navy;
            this.lblCtas.Location = new System.Drawing.Point(11, 46);
            this.lblCtas.Name = "lblCtas";
            this.lblCtas.Size = new System.Drawing.Size(337, 16);
            this.lblCtas.TabIndex = 123;
            this.lblCtas.Text = "Cuentas:";
            this.lblCtas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chklbCuentas
            // 
            this.chklbCuentas.FormattingEnabled = true;
            this.chklbCuentas.Location = new System.Drawing.Point(11, 64);
            this.chklbCuentas.Name = "chklbCuentas";
            this.chklbCuentas.Size = new System.Drawing.Size(338, 139);
            this.chklbCuentas.TabIndex = 122;
            this.chklbCuentas.SelectedValueChanged += new System.EventHandler(this.chklbCuentas_SelectedValueChanged);
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(88, 17);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(260, 21);
            this.cboInstitucion.TabIndex = 1;
            this.cboInstitucion.SelectedIndexChanged += new System.EventHandler(this.cboInstitucion_SelectedIndexChanged);
            // 
            // lblInstitucion
            // 
            this.lblInstitucion.AutoSize = true;
            this.lblInstitucion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblInstitucion.ForeColor = System.Drawing.Color.Navy;
            this.lblInstitucion.Location = new System.Drawing.Point(11, 20);
            this.lblInstitucion.Name = "lblInstitucion";
            this.lblInstitucion.Size = new System.Drawing.Size(54, 13);
            this.lblInstitucion.TabIndex = 0;
            this.lblInstitucion.Text = "Entidad:";
            // 
            // dtgExtractoCta
            // 
            this.dtgExtractoCta.AllowUserToAddRows = false;
            this.dtgExtractoCta.AllowUserToDeleteRows = false;
            this.dtgExtractoCta.AllowUserToResizeColumns = false;
            this.dtgExtractoCta.AllowUserToResizeRows = false;
            this.dtgExtractoCta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExtractoCta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExtractoCta.Location = new System.Drawing.Point(378, 61);
            this.dtgExtractoCta.MultiSelect = false;
            this.dtgExtractoCta.Name = "dtgExtractoCta";
            this.dtgExtractoCta.ReadOnly = true;
            this.dtgExtractoCta.RowHeadersVisible = false;
            this.dtgExtractoCta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExtractoCta.Size = new System.Drawing.Size(515, 214);
            this.dtgExtractoCta.TabIndex = 4;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(833, 282);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(705, 282);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboCuentas
            // 
            this.cboCuentas.FormattingEnabled = true;
            this.cboCuentas.Location = new System.Drawing.Point(93, 19);
            this.cboCuentas.Name = "cboCuentas";
            this.cboCuentas.Size = new System.Drawing.Size(214, 21);
            this.cboCuentas.TabIndex = 8;
            this.cboCuentas.SelectedIndexChanged += new System.EventHandler(this.cboCuentas_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(20, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(53, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Cuenta:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboCuentas);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Location = new System.Drawing.Point(378, 3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(515, 51);
            this.grbBase3.TabIndex = 10;
            this.grbBase3.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(769, 282);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(641, 282);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 12;
            this.btnImprimir1.Text = "Imprimir Todos";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmLibroAuxiliarBcos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 358);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgExtractoCta);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmLibroAuxiliarBcos";
            this.Text = "Libro Auxiliar de Bancos";
            this.Load += new System.EventHandler(this.frmLibroAuxiliarBcos_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.dtgExtractoCta, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExtractoCta)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboBase cboAnio;
        private GEN.ControlesBase.cboBase cboMes;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.cboBase cboInstitucion;
        private GEN.ControlesBase.lblBase lblInstitucion;
        private GEN.ControlesBase.chcBase chcSelec;
        private GEN.ControlesBase.lblBase lblCtas;
        private GEN.ControlesBase.chklbBase chklbCuentas;
        private GEN.ControlesBase.dtgBase dtgExtractoCta;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboBase cboCuentas;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}