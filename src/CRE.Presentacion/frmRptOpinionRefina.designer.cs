namespace CRE.Presentacion
{
    partial class frmRptOpinionRefina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptOpinionRefina));
            this.dtgSolRefina = new GEN.ControlesBase.dtgBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbOpinion = new GEN.ControlesBase.grbBase(this.components);
            this.txtGestiones = new GEN.ControlesBase.txtBase(this.components);
            this.txtConclusion = new GEN.ControlesBase.txtBase(this.components);
            this.txtAntecedentes = new GEN.ControlesBase.txtBase(this.components);
            this.txtMotivoMora = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.rbtNO = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtSI = new GEN.ControlesBase.rbtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolRefina)).BeginInit();
            this.grbOpinion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgSolRefina
            // 
            this.dtgSolRefina.AllowUserToAddRows = false;
            this.dtgSolRefina.AllowUserToDeleteRows = false;
            this.dtgSolRefina.AllowUserToResizeColumns = false;
            this.dtgSolRefina.AllowUserToResizeRows = false;
            this.dtgSolRefina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolRefina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolRefina.Location = new System.Drawing.Point(12, 22);
            this.dtgSolRefina.MultiSelect = false;
            this.dtgSolRefina.Name = "dtgSolRefina";
            this.dtgSolRefina.ReadOnly = true;
            this.dtgSolRefina.RowHeadersVisible = false;
            this.dtgSolRefina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolRefina.Size = new System.Drawing.Size(647, 150);
            this.dtgSolRefina.TabIndex = 8;
            this.dtgSolRefina.SelectionChanged += new System.EventHandler(this.dtgSolRefina_SelectionChanged);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(533, 421);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(599, 421);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbOpinion
            // 
            this.grbOpinion.Controls.Add(this.txtGestiones);
            this.grbOpinion.Controls.Add(this.txtConclusion);
            this.grbOpinion.Controls.Add(this.txtAntecedentes);
            this.grbOpinion.Controls.Add(this.txtMotivoMora);
            this.grbOpinion.Controls.Add(this.lblBase10);
            this.grbOpinion.Controls.Add(this.lblBase9);
            this.grbOpinion.Controls.Add(this.lblBase8);
            this.grbOpinion.Controls.Add(this.lblBase7);
            this.grbOpinion.Controls.Add(this.lblBase6);
            this.grbOpinion.Controls.Add(this.rbtNO);
            this.grbOpinion.Controls.Add(this.rbtSI);
            this.grbOpinion.Controls.Add(this.lblBase5);
            this.grbOpinion.ForeColor = System.Drawing.Color.Navy;
            this.grbOpinion.Location = new System.Drawing.Point(12, 187);
            this.grbOpinion.Name = "grbOpinion";
            this.grbOpinion.Size = new System.Drawing.Size(659, 228);
            this.grbOpinion.TabIndex = 13;
            this.grbOpinion.TabStop = false;
            this.grbOpinion.Text = "Opinión de gestor de recuperaciones";
            // 
            // txtGestiones
            // 
            this.txtGestiones.Location = new System.Drawing.Point(225, 108);
            this.txtGestiones.MaxLength = 500;
            this.txtGestiones.Multiline = true;
            this.txtGestiones.Name = "txtGestiones";
            this.txtGestiones.ReadOnly = true;
            this.txtGestiones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGestiones.Size = new System.Drawing.Size(210, 109);
            this.txtGestiones.TabIndex = 17;
            // 
            // txtConclusion
            // 
            this.txtConclusion.Location = new System.Drawing.Point(441, 108);
            this.txtConclusion.MaxLength = 500;
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.ReadOnly = true;
            this.txtConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConclusion.Size = new System.Drawing.Size(210, 109);
            this.txtConclusion.TabIndex = 17;
            // 
            // txtAntecedentes
            // 
            this.txtAntecedentes.Location = new System.Drawing.Point(10, 108);
            this.txtAntecedentes.MaxLength = 500;
            this.txtAntecedentes.Multiline = true;
            this.txtAntecedentes.Name = "txtAntecedentes";
            this.txtAntecedentes.ReadOnly = true;
            this.txtAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntecedentes.Size = new System.Drawing.Size(210, 109);
            this.txtAntecedentes.TabIndex = 16;
            // 
            // txtMotivoMora
            // 
            this.txtMotivoMora.Location = new System.Drawing.Point(112, 41);
            this.txtMotivoMora.MaxLength = 500;
            this.txtMotivoMora.Multiline = true;
            this.txtMotivoMora.Name = "txtMotivoMora";
            this.txtMotivoMora.ReadOnly = true;
            this.txtMotivoMora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivoMora.Size = new System.Drawing.Size(541, 44);
            this.txtMotivoMora.TabIndex = 15;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(438, 94);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(78, 13);
            this.lblBase10.TabIndex = 14;
            this.lblBase10.Text = "Conclusión :";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(223, 94);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(137, 13);
            this.lblBase9.TabIndex = 14;
            this.lblBase9.Text = "Gestiones Realizadas :";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 94);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(93, 13);
            this.lblBase8.TabIndex = 14;
            this.lblBase8.Text = "Antecedentes :";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 78);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(55, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Opinión:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(7, 42);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(101, 13);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "Motivo de mora:";
            // 
            // rbtNO
            // 
            this.rbtNO.AutoSize = true;
            this.rbtNO.Enabled = false;
            this.rbtNO.ForeColor = System.Drawing.Color.Navy;
            this.rbtNO.Location = new System.Drawing.Point(266, 20);
            this.rbtNO.Name = "rbtNO";
            this.rbtNO.Size = new System.Drawing.Size(41, 17);
            this.rbtNO.TabIndex = 13;
            this.rbtNO.Text = "NO";
            this.rbtNO.UseVisualStyleBackColor = true;
            // 
            // rbtSI
            // 
            this.rbtSI.AutoSize = true;
            this.rbtSI.Enabled = false;
            this.rbtSI.ForeColor = System.Drawing.Color.Navy;
            this.rbtSI.Location = new System.Drawing.Point(225, 20);
            this.rbtSI.Name = "rbtSI";
            this.rbtSI.Size = new System.Drawing.Size(35, 17);
            this.rbtSI.TabIndex = 12;
            this.rbtSI.Text = "SI";
            this.rbtSI.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(7, 22);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(213, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "¿Cliente muestra voluntad de pago?";
            // 
            // frmRptOpinionRefina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 505);
            this.Controls.Add(this.grbOpinion);
            this.Controls.Add(this.dtgSolRefina);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRptOpinionRefina";
            this.Text = "Listado de opinión de refinanciación";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.dtgSolRefina, 0);
            this.Controls.SetChildIndex(this.grbOpinion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolRefina)).EndInit();
            this.grbOpinion.ResumeLayout(false);
            this.grbOpinion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.dtgBase dtgSolRefina;
        private GEN.ControlesBase.grbBase grbOpinion;
        private GEN.ControlesBase.txtBase txtGestiones;
        private GEN.ControlesBase.txtBase txtConclusion;
        private GEN.ControlesBase.txtBase txtAntecedentes;
        private GEN.ControlesBase.txtBase txtMotivoMora;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.rbtBase rbtNO;
        private GEN.ControlesBase.rbtBase rbtSI;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}

