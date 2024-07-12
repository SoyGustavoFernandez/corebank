namespace DEP.Presentacion
{
    partial class frmComisionesCta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComisionesCta));
            this.dtgComisionCta = new System.Windows.Forms.DataGridView();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtComision = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisionCta)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgComisionCta
            // 
            this.dtgComisionCta.AllowUserToAddRows = false;
            this.dtgComisionCta.AllowUserToDeleteRows = false;
            this.dtgComisionCta.AllowUserToResizeColumns = false;
            this.dtgComisionCta.AllowUserToResizeRows = false;
            this.dtgComisionCta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgComisionCta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComisionCta.Location = new System.Drawing.Point(0, 7);
            this.dtgComisionCta.MultiSelect = false;
            this.dtgComisionCta.Name = "dtgComisionCta";
            this.dtgComisionCta.ReadOnly = true;
            this.dtgComisionCta.RowHeadersVisible = false;
            this.dtgComisionCta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComisionCta.Size = new System.Drawing.Size(469, 153);
            this.dtgComisionCta.TabIndex = 46;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(408, 191);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 47;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtComision
            // 
            this.txtComision.BackColor = System.Drawing.SystemColors.Control;
            this.txtComision.Enabled = false;
            this.txtComision.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComision.Location = new System.Drawing.Point(376, 163);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(93, 22);
            this.txtComision.TabIndex = 49;
            this.txtComision.Text = "0.00";
            this.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(264, 167);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(110, 13);
            this.lblBase13.TabIndex = 48;
            this.lblBase13.Text = "Total Comisiones:";
            // 
            // frmComisionesCta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 266);
            this.Controls.Add(this.txtComision);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgComisionCta);
            this.Name = "frmComisionesCta";
            this.Text = "Comisiones por Cuenta";
            this.Load += new System.EventHandler(this.frmComisionesCta_Load);
            this.Controls.SetChildIndex(this.dtgComisionCta, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.txtComision, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgComisionCta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgComisionCta;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtBase txtComision;
        private GEN.ControlesBase.lblBase lblBase13;
    }
}