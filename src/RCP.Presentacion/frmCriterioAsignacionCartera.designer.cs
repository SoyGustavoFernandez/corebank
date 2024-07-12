namespace RCP.Presentacion
{
    partial class frmCriterioAsignacionCartera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCriterioAsignacionCartera));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboTipoCriterioAsigCartera1 = new GEN.ControlesBase.cboTipoCriterioAsigCartera(this.components);
            this.chbVigente = new System.Windows.Forms.CheckBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgCriterios = new GEN.ControlesBase.dtgBase(this.components);
            this.idCriteriosAsigCartRecu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoCriteriosAsigCartRecu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoCriteriosAsigCartRecu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAgencia = new System.Windows.Forms.Panel();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.pnlAsesor = new System.Windows.Forms.Panel();
            this.cboPersonalCreditos = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.pnlUbigeo = new System.Windows.Forms.Panel();
            this.conBusUbig = new GEN.ControlesBase.ConBusUbig();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.cboUsuRecuperadores1 = new GEN.ControlesBase.cboUsuRecuperadores(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCriterios)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlAgencia.SuspendLayout();
            this.pnlAsesor.SuspendLayout();
            this.pnlUbigeo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.dtgCriterios);
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 51);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(393, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Asignacion de Cartera";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboTipoCriterioAsigCartera1);
            this.panel2.Controls.Add(this.chbVigente);
            this.panel2.Controls.Add(this.lblBase1);
            this.panel2.Location = new System.Drawing.Point(0, 209);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 30);
            this.panel2.TabIndex = 1;
            // 
            // cboTipoCriterioAsigCartera1
            // 
            this.cboTipoCriterioAsigCartera1.FormattingEnabled = true;
            this.cboTipoCriterioAsigCartera1.Location = new System.Drawing.Point(92, 6);
            this.cboTipoCriterioAsigCartera1.Name = "cboTipoCriterioAsigCartera1";
            this.cboTipoCriterioAsigCartera1.Size = new System.Drawing.Size(183, 21);
            this.cboTipoCriterioAsigCartera1.TabIndex = 0;
            this.cboTipoCriterioAsigCartera1.SelectedIndexChanged += new System.EventHandler(this.cboTipoCriterioAsigCartera1_SelectedIndexChanged);
            // 
            // chbVigente
            // 
            this.chbVigente.AutoSize = true;
            this.chbVigente.Location = new System.Drawing.Point(292, 8);
            this.chbVigente.Name = "chbVigente";
            this.chbVigente.Size = new System.Drawing.Size(62, 17);
            this.chbVigente.TabIndex = 1;
            this.chbVigente.Text = "Vigente";
            this.chbVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(36, 10);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Criterio:";
            // 
            // dtgCriterios
            // 
            this.dtgCriterios.AllowUserToAddRows = false;
            this.dtgCriterios.AllowUserToDeleteRows = false;
            this.dtgCriterios.AllowUserToResizeColumns = false;
            this.dtgCriterios.AllowUserToResizeRows = false;
            this.dtgCriterios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCriterios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCriterios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCriteriosAsigCartRecu,
            this.idTipoCriteriosAsigCartRecu,
            this.cTipoCriteriosAsigCartRecu,
            this.nValor,
            this.cValor});
            this.dtgCriterios.Location = new System.Drawing.Point(18, 19);
            this.dtgCriterios.MultiSelect = false;
            this.dtgCriterios.Name = "dtgCriterios";
            this.dtgCriterios.ReadOnly = true;
            this.dtgCriterios.RowHeadersVisible = false;
            this.dtgCriterios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCriterios.Size = new System.Drawing.Size(363, 184);
            this.dtgCriterios.TabIndex = 0;
            this.dtgCriterios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCriterios_CellEnter);
            // 
            // idCriteriosAsigCartRecu
            // 
            this.idCriteriosAsigCartRecu.DataPropertyName = "idCriteriosAsigCartRecu";
            this.idCriteriosAsigCartRecu.HeaderText = "idCriteriosAsigCartRecu";
            this.idCriteriosAsigCartRecu.Name = "idCriteriosAsigCartRecu";
            this.idCriteriosAsigCartRecu.ReadOnly = true;
            this.idCriteriosAsigCartRecu.Visible = false;
            // 
            // idTipoCriteriosAsigCartRecu
            // 
            this.idTipoCriteriosAsigCartRecu.DataPropertyName = "idTipoCriteriosAsigCartRecu";
            this.idTipoCriteriosAsigCartRecu.HeaderText = "idTipoCriteriosAsigCartRecu";
            this.idTipoCriteriosAsigCartRecu.Name = "idTipoCriteriosAsigCartRecu";
            this.idTipoCriteriosAsigCartRecu.ReadOnly = true;
            this.idTipoCriteriosAsigCartRecu.Visible = false;
            // 
            // cTipoCriteriosAsigCartRecu
            // 
            this.cTipoCriteriosAsigCartRecu.DataPropertyName = "cTipoCriteriosAsigCartRecu";
            this.cTipoCriteriosAsigCartRecu.FillWeight = 60F;
            this.cTipoCriteriosAsigCartRecu.HeaderText = "Criterio";
            this.cTipoCriteriosAsigCartRecu.Name = "cTipoCriteriosAsigCartRecu";
            this.cTipoCriteriosAsigCartRecu.ReadOnly = true;
            // 
            // nValor
            // 
            this.nValor.DataPropertyName = "nValor";
            this.nValor.HeaderText = "Valor";
            this.nValor.Name = "nValor";
            this.nValor.ReadOnly = true;
            this.nValor.Visible = false;
            // 
            // cValor
            // 
            this.cValor.DataPropertyName = "cValor";
            this.cValor.HeaderText = "Valor";
            this.cValor.Name = "cValor";
            this.cValor.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.pnlAgencia);
            this.flowLayoutPanel2.Controls.Add(this.pnlAsesor);
            this.flowLayoutPanel2.Controls.Add(this.pnlUbigeo);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 239);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(390, 201);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // pnlAgencia
            // 
            this.pnlAgencia.Controls.Add(this.lblBase4);
            this.pnlAgencia.Controls.Add(this.cboAgencia);
            this.pnlAgencia.Location = new System.Drawing.Point(3, 0);
            this.pnlAgencia.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlAgencia.Name = "pnlAgencia";
            this.pnlAgencia.Size = new System.Drawing.Size(384, 30);
            this.pnlAgencia.TabIndex = 0;
            this.pnlAgencia.Visible = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 9);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(41, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Valor:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(58, 5);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(310, 21);
            this.cboAgencia.TabIndex = 0;
            // 
            // pnlAsesor
            // 
            this.pnlAsesor.Controls.Add(this.cboPersonalCreditos);
            this.pnlAsesor.Controls.Add(this.lblBase2);
            this.pnlAsesor.Location = new System.Drawing.Point(3, 30);
            this.pnlAsesor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlAsesor.Name = "pnlAsesor";
            this.pnlAsesor.Size = new System.Drawing.Size(384, 30);
            this.pnlAsesor.TabIndex = 1;
            this.pnlAsesor.Visible = false;
            // 
            // cboPersonalCreditos
            // 
            this.cboPersonalCreditos.FormattingEnabled = true;
            this.cboPersonalCreditos.Location = new System.Drawing.Point(58, 5);
            this.cboPersonalCreditos.Name = "cboPersonalCreditos";
            this.cboPersonalCreditos.Size = new System.Drawing.Size(310, 21);
            this.cboPersonalCreditos.TabIndex = 0;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 9);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(41, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Valor:";
            // 
            // pnlUbigeo
            // 
            this.pnlUbigeo.Controls.Add(this.conBusUbig);
            this.pnlUbigeo.Location = new System.Drawing.Point(3, 60);
            this.pnlUbigeo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlUbigeo.Name = "pnlUbigeo";
            this.pnlUbigeo.Size = new System.Drawing.Size(384, 141);
            this.pnlUbigeo.TabIndex = 2;
            this.pnlUbigeo.Visible = false;
            // 
            // conBusUbig
            // 
            this.conBusUbig.BackColor = System.Drawing.Color.Transparent;
            this.conBusUbig.Location = new System.Drawing.Point(76, 4);
            this.conBusUbig.Name = "conBusUbig";
            this.conBusUbig.nIdNodo = 0;
            this.conBusUbig.Size = new System.Drawing.Size(232, 130);
            this.conBusUbig.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(327, 3);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(262, 3);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(140, 3);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 1;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(201, 3);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(79, 3);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 0;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // cboUsuRecuperadores1
            // 
            this.cboUsuRecuperadores1.FormattingEnabled = true;
            this.cboUsuRecuperadores1.Location = new System.Drawing.Point(70, 14);
            this.cboUsuRecuperadores1.Name = "cboUsuRecuperadores1";
            this.cboUsuRecuperadores1.Size = new System.Drawing.Size(305, 21);
            this.cboUsuRecuperadores1.TabIndex = 0;
            this.cboUsuRecuperadores1.SelectedIndexChanged += new System.EventHandler(this.cboUsuRecuperadores1_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboUsuRecuperadores1);
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 42);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(401, 562);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalir1);
            this.panel1.Controls.Add(this.btnNuevo1);
            this.panel1.Controls.Add(this.btnCancelar1);
            this.panel1.Controls.Add(this.btnGrabar1);
            this.panel1.Controls.Add(this.btnEditar1);
            this.panel1.Location = new System.Drawing.Point(3, 504);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 58);
            this.panel1.TabIndex = 2;
            // 
            // frmCriterioAsignacionCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(401, 584);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmCriterioAsignacionCartera";
            this.Text = "Criterios de Asignacion de Cartera";
            this.Load += new System.EventHandler(this.frmCriterioAsignacionCartera_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCriterios)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlAgencia.ResumeLayout(false);
            this.pnlAgencia.PerformLayout();
            this.pnlAsesor.ResumeLayout(false);
            this.pnlAsesor.PerformLayout();
            this.pnlUbigeo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.cboTipoCriterioAsigCartera cboTipoCriterioAsigCartera1;
        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditos;
        private GEN.ControlesBase.ConBusUbig conBusUbig;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.dtgBase dtgCriterios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCriteriosAsigCartRecu;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoCriteriosAsigCartRecu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoCriteriosAsigCartRecu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValor;
        private System.Windows.Forms.CheckBox chbVigente;
        private GEN.ControlesBase.cboUsuRecuperadores cboUsuRecuperadores1;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlAgencia;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.Panel pnlUbigeo;
        private System.Windows.Forms.Panel pnlAsesor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}