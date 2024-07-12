namespace CRE.Presentacion
{
    partial class frmBusEvaEmpr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusEvaEmpr));
            this.btnGrabarEvaCon = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgEvaEmprCredit = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaEmprCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabarEvaCon
            // 
            this.btnGrabarEvaCon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarEvaCon.BackgroundImage")));
            this.btnGrabarEvaCon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarEvaCon.Location = new System.Drawing.Point(413, 214);
            this.btnGrabarEvaCon.Name = "btnGrabarEvaCon";
            this.btnGrabarEvaCon.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarEvaCon.TabIndex = 10;
            this.btnGrabarEvaCon.Text = "&Grabar";
            this.btnGrabarEvaCon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarEvaCon.UseVisualStyleBackColor = true;
            this.btnGrabarEvaCon.Click += new System.EventHandler(this.btnGrabarEvaCon_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(479, 214);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(306, 13);
            this.lblBase6.TabIndex = 41;
            this.lblBase6.Text = "Relacione la Solicitud de Crédito con una Evaluación";
            // 
            // dtgEvaEmprCredit
            // 
            this.dtgEvaEmprCredit.AllowUserToAddRows = false;
            this.dtgEvaEmprCredit.AllowUserToDeleteRows = false;
            this.dtgEvaEmprCredit.AllowUserToResizeColumns = false;
            this.dtgEvaEmprCredit.AllowUserToResizeRows = false;
            this.dtgEvaEmprCredit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEvaEmprCredit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaEmprCredit.Location = new System.Drawing.Point(12, 32);
            this.dtgEvaEmprCredit.MultiSelect = false;
            this.dtgEvaEmprCredit.Name = "dtgEvaEmprCredit";
            this.dtgEvaEmprCredit.ReadOnly = true;
            this.dtgEvaEmprCredit.RowHeadersVisible = false;
            this.dtgEvaEmprCredit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaEmprCredit.Size = new System.Drawing.Size(527, 176);
            this.dtgEvaEmprCredit.TabIndex = 42;
            // 
            // frmBusEvaEmpr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 302);
            this.Controls.Add(this.dtgEvaEmprCredit);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnGrabarEvaCon);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmBusEvaEmpr";
            this.Text = "Evaluaciones Empresariales Pendientes";
            this.Load += new System.EventHandler(this.frmBusEvaEmpr_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabarEvaCon, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.dtgEvaEmprCredit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaEmprCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabarEvaCon;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtgBase dtgEvaEmprCredit;
    }
}