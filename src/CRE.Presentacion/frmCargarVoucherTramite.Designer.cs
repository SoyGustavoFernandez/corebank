namespace CRE.Presentacion
{
    partial class frmCargarVoucherTramite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarVoucherTramite));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.dtgListaVoucher = new GEN.ControlesBase.dtgBase(this.components);
            this.panelFile = new System.Windows.Forms.Panel();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaVoucher)).BeginInit();
            this.panelFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelBotones);
            this.flowLayoutPanel1.Controls.Add(this.panelFile);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 617);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.panel2);
            this.panelBotones.Controls.Add(this.dtgListaVoucher);
            this.panelBotones.Location = new System.Drawing.Point(3, 3);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(850, 142);
            this.panelBotones.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSalir1);
            this.panel2.Controls.Add(this.btnGrabar1);
            this.panel2.Location = new System.Drawing.Point(777, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(71, 114);
            this.panel2.TabIndex = 1;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(6, 59);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 1;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(6, 3);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 0;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar2_Click);
            // 
            // dtgListaVoucher
            // 
            this.dtgListaVoucher.AllowUserToAddRows = false;
            this.dtgListaVoucher.AllowUserToDeleteRows = false;
            this.dtgListaVoucher.AllowUserToResizeColumns = false;
            this.dtgListaVoucher.AllowUserToResizeRows = false;
            this.dtgListaVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaVoucher.Location = new System.Drawing.Point(3, 3);
            this.dtgListaVoucher.MultiSelect = false;
            this.dtgListaVoucher.Name = "dtgListaVoucher";
            this.dtgListaVoucher.ReadOnly = true;
            this.dtgListaVoucher.RowHeadersVisible = false;
            this.dtgListaVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaVoucher.Size = new System.Drawing.Size(773, 136);
            this.dtgListaVoucher.TabIndex = 0;
            this.dtgListaVoucher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaVoucher_CellClick);
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.contPdf);
            this.panelFile.Location = new System.Drawing.Point(3, 151);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(850, 466);
            this.panelFile.TabIndex = 2;
            // 
            // contPdf
            // 
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(1, 3);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(846, 460);
            this.contPdf.TabIndex = 1;
            // 
            // frmCargarVoucherTramite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 643);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmCargarVoucherTramite";
            this.Text = "Cargar Voucher de Trámite";
            this.Load += new System.EventHandler(this.frmCargarVoucherTramite_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaVoucher)).EndInit();
            this.panelFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panelFile;
        private AxAcroPDFLib.AxAcroPDF contPdf;
        private System.Windows.Forms.Panel panel2;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.dtgBase dtgListaVoucher;
        private GEN.BotonesBase.btnSalir btnSalir1;       

    }
}