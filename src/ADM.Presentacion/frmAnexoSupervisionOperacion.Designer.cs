namespace ADM.Presentacion
{
    partial class frmAnexoSupervisionOperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnexoSupervisionOperacion));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAnexo = new System.Windows.Forms.Button();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbAnexo = new GEN.ControlesBase.grbBase(this.components);
            this.dtgAnexo = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1.SuspendLayout();
            this.grbAnexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAnexo)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnAnexo);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(18, 87);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(218, 37);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            // 
            // btnAnexo
            // 
            this.btnAnexo.Location = new System.Drawing.Point(128, 13);
            this.btnAnexo.Name = "btnAnexo";
            this.btnAnexo.Size = new System.Drawing.Size(75, 23);
            this.btnAnexo.TabIndex = 1;
            this.btnAnexo.Text = "Examinar";
            this.btnAnexo.UseVisualStyleBackColor = true;
            this.btnAnexo.Click += new System.EventHandler(this.btnAnexo_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(24, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(98, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Agregar Anexo:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(570, 87);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbAnexo
            // 
            this.grbAnexo.Controls.Add(this.dtgAnexo);
            this.grbAnexo.Location = new System.Drawing.Point(12, 12);
            this.grbAnexo.Name = "grbAnexo";
            this.grbAnexo.Size = new System.Drawing.Size(630, 69);
            this.grbAnexo.TabIndex = 9;
            this.grbAnexo.TabStop = false;
            this.grbAnexo.Text = "Anexo:";
            // 
            // dtgAnexo
            // 
            this.dtgAnexo.AllowUserToAddRows = false;
            this.dtgAnexo.AllowUserToDeleteRows = false;
            this.dtgAnexo.AllowUserToResizeColumns = false;
            this.dtgAnexo.AllowUserToResizeRows = false;
            this.dtgAnexo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAnexo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAnexo.Location = new System.Drawing.Point(6, 19);
            this.dtgAnexo.MultiSelect = false;
            this.dtgAnexo.Name = "dtgAnexo";
            this.dtgAnexo.ReadOnly = true;
            this.dtgAnexo.RowHeadersVisible = false;
            this.dtgAnexo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAnexo.Size = new System.Drawing.Size(612, 44);
            this.dtgAnexo.TabIndex = 5;
            this.dtgAnexo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAnexo_CellClick);
            // 
            // frmAnexoSupervisionOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 163);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbAnexo);
            this.Name = "frmAnexoSupervisionOperacion";
            this.Text = "Anexo de la Supervisión Operativa";
            this.Load += new System.EventHandler(this.frmAnexoSupervisionOperacion_Load);
            this.Controls.SetChildIndex(this.grbAnexo, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbAnexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAnexo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.Button btnAnexo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbAnexo;
        private GEN.ControlesBase.dtgBase dtgAnexo;
    }
}