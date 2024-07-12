namespace CRE.Presentacion
{
    partial class frmComiteAmpliadoRiesgo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComiteAmpliadoRiesgo));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombreComite = new GEN.ControlesBase.txtBase(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtgParticipantes = new System.Windows.Forms.DataGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmQuiParticipantes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgrParticipantes = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblSolInformeRiesgo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbDatosComite = new GEN.ControlesBase.grbBase(this.components);
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantes)).BeginInit();
            this.panel10.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.grbDatosComite.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtNombreComite
            // 
            this.txtNombreComite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreComite.Location = new System.Drawing.Point(79, 29);
            this.txtNombreComite.MaxLength = 50;
            this.txtNombreComite.Name = "txtNombreComite";
            this.txtNombreComite.Size = new System.Drawing.Size(484, 20);
            this.txtNombreComite.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(9, 151);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(554, 158);
            this.panel6.TabIndex = 95;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(554, 155);
            this.panel7.TabIndex = 78;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(552, 153);
            this.panel8.TabIndex = 25;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtgParticipantes);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 24);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(552, 129);
            this.panel9.TabIndex = 25;
            // 
            // dtgParticipantes
            // 
            this.dtgParticipantes.AllowUserToAddRows = false;
            this.dtgParticipantes.AllowUserToDeleteRows = false;
            this.dtgParticipantes.AllowUserToResizeColumns = false;
            this.dtgParticipantes.AllowUserToResizeRows = false;
            this.dtgParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgParticipantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgParticipantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgParticipantes.Location = new System.Drawing.Point(0, 0);
            this.dtgParticipantes.MultiSelect = false;
            this.dtgParticipantes.Name = "dtgParticipantes";
            this.dtgParticipantes.RowHeadersVisible = false;
            this.dtgParticipantes.Size = new System.Drawing.Size(552, 129);
            this.dtgParticipantes.TabIndex = 10;
            this.dtgParticipantes.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.menuStrip2);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(552, 24);
            this.panel10.TabIndex = 9;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQuiParticipantes,
            this.tsmAgrParticipantes});
            this.menuStrip2.Location = new System.Drawing.Point(240, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(312, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.TabStop = true;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmQuiParticipantes
            // 
            this.tsmQuiParticipantes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuiParticipantes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuiParticipantes.Image = global::CRE.Presentacion.Properties.Resources.btn_quitar;
            this.tsmQuiParticipantes.Name = "tsmQuiParticipantes";
            this.tsmQuiParticipantes.Size = new System.Drawing.Size(28, 20);
            this.tsmQuiParticipantes.Text = "toolStripMenuItem2";
            this.tsmQuiParticipantes.Click += new System.EventHandler(this.tsmQuiParticipantes_Click);
            // 
            // tsmAgrParticipantes
            // 
            this.tsmAgrParticipantes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgrParticipantes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgrParticipantes.Image = global::CRE.Presentacion.Properties.Resources.btn_agregar;
            this.tsmAgrParticipantes.Name = "tsmAgrParticipantes";
            this.tsmAgrParticipantes.Size = new System.Drawing.Size(28, 20);
            this.tsmAgrParticipantes.Text = "toolStripMenuItem1";
            this.tsmAgrParticipantes.Click += new System.EventHandler(this.tsmAgrParticipantes_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 24);
            this.label2.TabIndex = 100;
            this.label2.Text = "Participantes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(398, 458);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(458, 458);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(518, 458);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(338, 458);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(24, 89);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 102;
            this.lblBase2.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivo.Location = new System.Drawing.Point(79, 54);
            this.txtMotivo.MaxLength = 500;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(484, 82);
            this.txtMotivo.TabIndex = 1;
            // 
            // lblSolInformeRiesgo
            // 
            this.lblSolInformeRiesgo.AutoSize = true;
            this.lblSolInformeRiesgo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolInformeRiesgo.ForeColor = System.Drawing.Color.Navy;
            this.lblSolInformeRiesgo.Location = new System.Drawing.Point(135, 120);
            this.lblSolInformeRiesgo.Name = "lblSolInformeRiesgo";
            this.lblSolInformeRiesgo.Size = new System.Drawing.Size(110, 13);
            this.lblSolInformeRiesgo.TabIndex = 103;
            this.lblSolInformeRiesgo.Text = "lblBaseCustom1";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 120);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(112, 13);
            this.lblBase3.TabIndex = 104;
            this.lblBase3.Text = "Cod. Sol. Opinion:";
            // 
            // grbDatosComite
            // 
            this.grbDatosComite.Controls.Add(this.lblBase1);
            this.grbDatosComite.Controls.Add(this.txtNombreComite);
            this.grbDatosComite.Controls.Add(this.panel6);
            this.grbDatosComite.Controls.Add(this.txtMotivo);
            this.grbDatosComite.Controls.Add(this.lblBase2);
            this.grbDatosComite.Location = new System.Drawing.Point(5, 143);
            this.grbDatosComite.Name = "grbDatosComite";
            this.grbDatosComite.Size = new System.Drawing.Size(573, 313);
            this.grbDatosComite.TabIndex = 107;
            this.grbDatosComite.TabStop = false;
            this.grbDatosComite.Text = "Datos Comite";
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Location = new System.Drawing.Point(17, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(554, 100);
            this.conBusCuentaCli.TabIndex = 108;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // frmComiteAmpliadoRiesgo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 536);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.grbDatosComite);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblSolInformeRiesgo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmComiteAmpliadoRiesgo";
            this.Text = "Comite Ampliado de Riesgo";
            this.Load += new System.EventHandler(this.frmComiteAmpliadoRiesgo_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.lblSolInformeRiesgo, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.grbDatosComite, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantes)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.grbDatosComite.ResumeLayout(false);
            this.grbDatosComite.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombreComite;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dtgParticipantes;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmQuiParticipantes;
        private System.Windows.Forms.ToolStripMenuItem tsmAgrParticipantes;
        private System.Windows.Forms.Label label2;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.lblBaseCustom lblSolInformeRiesgo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbDatosComite;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
    }
}