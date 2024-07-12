namespace GEN.ControlesBase
{
    partial class frmCargaArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaArchivo));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtJuridica = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtNatural = new GEN.ControlesBase.rbtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar2 = new GEN.BotonesBase.btnGrabar();
            this.dtgFiles = new GEN.ControlesBase.dtgBase(this.components);
            this.panelFile = new System.Windows.Forms.Panel();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFiles)).BeginInit();
            this.panelFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panelBotones);
            this.flowLayoutPanel1.Controls.Add(this.panelFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(1800, 1800);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(964, 626);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.rbtJuridica);
            this.panel1.Controls.Add(this.rbtNatural);
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.txtSolicitud);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 28);
            this.panel1.TabIndex = 7;
            // 
            // rbtJuridica
            // 
            this.rbtJuridica.AutoSize = true;
            this.rbtJuridica.Enabled = false;
            this.rbtJuridica.ForeColor = System.Drawing.Color.Navy;
            this.rbtJuridica.Location = new System.Drawing.Point(553, 6);
            this.rbtJuridica.Name = "rbtJuridica";
            this.rbtJuridica.Size = new System.Drawing.Size(105, 17);
            this.rbtJuridica.TabIndex = 1;
            this.rbtJuridica.TabStop = true;
            this.rbtJuridica.Text = "Persona Jurídica";
            this.rbtJuridica.UseVisualStyleBackColor = true;
            // 
            // rbtNatural
            // 
            this.rbtNatural.AutoSize = true;
            this.rbtNatural.Enabled = false;
            this.rbtNatural.ForeColor = System.Drawing.Color.Navy;
            this.rbtNatural.Location = new System.Drawing.Point(447, 6);
            this.rbtNatural.Name = "rbtNatural";
            this.rbtNatural.Size = new System.Drawing.Size(101, 17);
            this.rbtNatural.TabIndex = 0;
            this.rbtNatural.TabStop = true;
            this.rbtNatural.Text = "Persona Natural";
            this.rbtNatural.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(333, 8);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(104, 13);
            this.lblBase2.TabIndex = 40;
            this.lblBase2.Text = "Tipo de Persona:";
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Enabled = false;
            this.txtSolicitud.Location = new System.Drawing.Point(138, 5);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.Size = new System.Drawing.Size(187, 20);
            this.txtSolicitud.TabIndex = 34;
            this.txtSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 8);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(129, 13);
            this.lblBase1.TabIndex = 39;
            this.lblBase1.Text = "Datos de la Solicitud:";
            // 
            // panelBotones
            // 
            this.panelBotones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBotones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelBotones.Controls.Add(this.panel2);
            this.panelBotones.Controls.Add(this.dtgFiles);
            this.panelBotones.Location = new System.Drawing.Point(3, 37);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(961, 260);
            this.panelBotones.TabIndex = 6;
            this.panelBotones.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBotones_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.btnSalir1);
            this.panel2.Controls.Add(this.btnGrabar2);
            this.panel2.Location = new System.Drawing.Point(892, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(65, 114);
            this.panel2.TabIndex = 7;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(3, 59);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGrabar2
            // 
            this.btnGrabar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar2.BackgroundImage")));
            this.btnGrabar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar2.Location = new System.Drawing.Point(3, 4);
            this.btnGrabar2.Name = "btnGrabar2";
            this.btnGrabar2.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar2.TabIndex = 3;
            this.btnGrabar2.Text = "&Grabar";
            this.btnGrabar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar2.UseVisualStyleBackColor = true;
            this.btnGrabar2.Click += new System.EventHandler(this.btnGrabar2_Click);
            // 
            // dtgFiles
            // 
            this.dtgFiles.AllowUserToAddRows = false;
            this.dtgFiles.AllowUserToDeleteRows = false;
            this.dtgFiles.AllowUserToResizeColumns = false;
            this.dtgFiles.AllowUserToResizeRows = false;
            this.dtgFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFiles.Location = new System.Drawing.Point(3, 3);
            this.dtgFiles.MultiSelect = false;
            this.dtgFiles.Name = "dtgFiles";
            this.dtgFiles.ReadOnly = true;
            this.dtgFiles.RowHeadersVisible = false;
            this.dtgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFiles.Size = new System.Drawing.Size(883, 254);
            this.dtgFiles.TabIndex = 2;
            this.dtgFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFiles_CellClick);
            // 
            // panelFile
            // 
            this.panelFile.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelFile.Controls.Add(this.contPdf);
            this.panelFile.Location = new System.Drawing.Point(3, 303);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(957, 320);
            this.panelFile.TabIndex = 7;
            // 
            // contPdf
            // 
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(1, 3);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(953, 314);
            this.contPdf.TabIndex = 0;
            // 
            // frmCargaArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(964, 648);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmCargaArchivo";
            this.Text = "Carga de Archivos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargaArchivo_FormClosing);
            this.Load += new System.EventHandler(this.frmCargaArchivo_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFiles)).EndInit();
            this.panelFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private dtgBase dtgFiles;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panelFile;
        private AxAcroPDFLib.AxAcroPDF contPdf;
        private System.Windows.Forms.Panel panel1;
        private rbtBase rbtJuridica;
        private rbtBase rbtNatural;
        private txtBase txtSolicitud;
        private System.Windows.Forms.Panel panel2;
        private BotonesBase.btnSalir btnSalir1;
        private lblBase lblBase2;
        private lblBase lblBase1;
        public BotonesBase.btnGrabar btnGrabar2;

    }
}