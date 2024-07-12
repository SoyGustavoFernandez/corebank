namespace GEN.ControlesBase
{
    partial class frmAdministrarFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrarFiles));
            this.dtgFiles = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panelFile = new System.Windows.Forms.Panel();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFiles)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.SuspendLayout();
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
            this.dtgFiles.Size = new System.Drawing.Size(924, 150);
            this.dtgFiles.TabIndex = 2;
            this.dtgFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFiles_CellClick);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(788, 3);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(854, 3);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.dtgFiles);
            this.flowLayoutPanel1.Controls.Add(this.panelBotones);
            this.flowLayoutPanel1.Controls.Add(this.panelFile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(1800, 1800);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(930, 623);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panelBotones
            // 
            this.panelBotones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBotones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelBotones.Controls.Add(this.btnSalir1);
            this.panelBotones.Controls.Add(this.btnGrabar1);
            this.panelBotones.Location = new System.Drawing.Point(3, 159);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(924, 53);
            this.panelBotones.TabIndex = 6;
            // 
            // panelFile
            // 
            this.panelFile.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelFile.Controls.Add(this.contPdf);
            this.panelFile.Location = new System.Drawing.Point(3, 218);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(924, 402);
            this.panelFile.TabIndex = 7;
            // 
            // contPdf
            // 
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(1, 3);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(923, 396);
            this.contPdf.TabIndex = 0;
            // 
            // frmAdministrarFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(930, 645);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = true;
            this.Name = "frmAdministrarFiles";
            this.Text = "Reportes Centrales de Riesgo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdministrarFiles_FormClosing);
            this.Load += new System.EventHandler(this.frmAdministrarFiles_Load);
            this.SizeChanged += new System.EventHandler(this.frmAdministrarFiles_SizeChanged);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFiles)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.panelFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dtgBase dtgFiles;
        private BotonesBase.btnGrabar btnGrabar1;
        private BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panelFile;
        private AxAcroPDFLib.AxAcroPDF contPdf;

    }
}