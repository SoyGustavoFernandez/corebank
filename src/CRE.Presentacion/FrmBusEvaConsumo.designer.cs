namespace CRE.Presentacion
{
    partial class FrmBusEvaConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusEvaConsumo));
            this.dtgEvaConCredit = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabarEvaCon = new GEN.BotonesBase.btnGrabar();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaConCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgEvaConCredit
            // 
            this.dtgEvaConCredit.AllowUserToAddRows = false;
            this.dtgEvaConCredit.AllowUserToDeleteRows = false;
            this.dtgEvaConCredit.AllowUserToResizeColumns = false;
            this.dtgEvaConCredit.AllowUserToResizeRows = false;
            this.dtgEvaConCredit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEvaConCredit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaConCredit.Location = new System.Drawing.Point(12, 35);
            this.dtgEvaConCredit.MultiSelect = false;
            this.dtgEvaConCredit.Name = "dtgEvaConCredit";
            this.dtgEvaConCredit.ReadOnly = true;
            this.dtgEvaConCredit.RowHeadersVisible = false;
            this.dtgEvaConCredit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaConCredit.Size = new System.Drawing.Size(527, 176);
            this.dtgEvaConCredit.TabIndex = 5;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(479, 219);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabarEvaCon
            // 
            this.btnGrabarEvaCon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarEvaCon.BackgroundImage")));
            this.btnGrabarEvaCon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarEvaCon.Location = new System.Drawing.Point(413, 219);
            this.btnGrabarEvaCon.Name = "btnGrabarEvaCon";
            this.btnGrabarEvaCon.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarEvaCon.TabIndex = 8;
            this.btnGrabarEvaCon.Text = "&Grabar";
            this.btnGrabarEvaCon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarEvaCon.UseVisualStyleBackColor = true;
            this.btnGrabarEvaCon.Click += new System.EventHandler(this.btnGrabarEvaCon_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(306, 13);
            this.lblBase6.TabIndex = 40;
            this.lblBase6.Text = "Relacione la Solicitud de Crédito con una Evaluación";
            // 
            // FrmBusEvaConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 301);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnGrabarEvaCon);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgEvaConCredit);
            this.Name = "FrmBusEvaConsumo";
            this.Text = "Evaluaciones de Consumo Pendientes";
            this.Load += new System.EventHandler(this.FrmBusEvaConsumo_Load);
            this.Controls.SetChildIndex(this.dtgEvaConCredit, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabarEvaCon, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaConCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgEvaConCredit;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabarEvaCon;
        private GEN.ControlesBase.lblBase lblBase6;
    }
}