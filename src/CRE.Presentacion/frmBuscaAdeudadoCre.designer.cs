namespace GEN.ControlesBase
{
    partial class frmBuscaAdeudadoCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaAdeudadoCre));
            this.dtgAdeudadoCre = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAdeudadoCre)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAdeudadoCre
            // 
            this.dtgAdeudadoCre.AllowUserToAddRows = false;
            this.dtgAdeudadoCre.AllowUserToDeleteRows = false;
            this.dtgAdeudadoCre.AllowUserToResizeColumns = false;
            this.dtgAdeudadoCre.AllowUserToResizeRows = false;
            this.dtgAdeudadoCre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAdeudadoCre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAdeudadoCre.Location = new System.Drawing.Point(12, 36);
            this.dtgAdeudadoCre.MultiSelect = false;
            this.dtgAdeudadoCre.Name = "dtgAdeudadoCre";
            this.dtgAdeudadoCre.ReadOnly = true;
            this.dtgAdeudadoCre.RowHeadersVisible = false;
            this.dtgAdeudadoCre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAdeudadoCre.Size = new System.Drawing.Size(595, 163);
            this.dtgAdeudadoCre.TabIndex = 4;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(547, 205);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(481, 205);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 7;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(9, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(238, 13);
            this.lblBase6.TabIndex = 40;
            this.lblBase6.Text = "Seleccionar el Adeudado para el Crédito";
            // 
            // frmBuscaAdeudadoCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 283);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgAdeudadoCre);
            this.Name = "frmBuscaAdeudadoCre";
            this.Text = "Búsqueda Adeudado del Crédito";
            this.Load += new System.EventHandler(this.frmBuscaAdeudadoCre_Load);
            this.Controls.SetChildIndex(this.dtgAdeudadoCre, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAdeudadoCre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.btnGrabar btnGrabar1;
        private lblBase lblBase6;
        private dtgBase dtgAdeudadoCre;
    }
}