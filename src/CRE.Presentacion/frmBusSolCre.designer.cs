namespace GEN.ControlesBase
{
    partial class frmBusSolCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusSolCre));
            this.dtgSolCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolCreditos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSolCreditos
            // 
            this.dtgSolCreditos.AllowUserToAddRows = false;
            this.dtgSolCreditos.AllowUserToDeleteRows = false;
            this.dtgSolCreditos.AllowUserToResizeColumns = false;
            this.dtgSolCreditos.AllowUserToResizeRows = false;
            this.dtgSolCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolCreditos.Location = new System.Drawing.Point(12, 36);
            this.dtgSolCreditos.MultiSelect = false;
            this.dtgSolCreditos.Name = "dtgSolCreditos";
            this.dtgSolCreditos.ReadOnly = true;
            this.dtgSolCreditos.RowHeadersVisible = false;
            this.dtgSolCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolCreditos.Size = new System.Drawing.Size(422, 176);
            this.dtgSolCreditos.TabIndex = 4;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(374, 220);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(308, 220);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
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
            this.lblBase6.Text = "Relacione la Evaluación con una Solicitud de Crédito";
            // 
            // frmBusSolCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 306);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgSolCreditos);
            this.Name = "frmBusSolCre";
            this.Text = "Solicitudes de Credito Pendientes";
            this.Load += new System.EventHandler(this.frmBusSolCre_Load);
            this.Controls.SetChildIndex(this.dtgSolCreditos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolCreditos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dtgBase dtgSolCreditos;
        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.btnGrabar btnGrabar;
        private lblBase lblBase6;
    }
}