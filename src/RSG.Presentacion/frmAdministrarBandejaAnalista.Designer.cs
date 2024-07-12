namespace RSG.Presentacion
{
    partial class frmAdministrarBandejaAnalista
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrarBandejaAnalista));
			this.cboZona = new GEN.ControlesBase.cboZona(this.components);
			this.lblZona = new GEN.ControlesBase.lblBase();
			this.lblAnalista = new GEN.ControlesBase.lblBase();
			this.cboAnalista = new GEN.ControlesBase.cboBase(this.components);
			this.dtgAnalistaRsgZona = new System.Windows.Forms.DataGridView();
			this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
			((System.ComponentModel.ISupportInitialize)(this.dtgAnalistaRsgZona)).BeginInit();
			this.SuspendLayout();
			// 
			// cboZona
			// 
			this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboZona.FormattingEnabled = true;
			this.cboZona.Location = new System.Drawing.Point(80, 12);
			this.cboZona.Name = "cboZona";
			this.cboZona.Size = new System.Drawing.Size(214, 21);
			this.cboZona.TabIndex = 2;
			// 
			// lblZona
			// 
			this.lblZona.AutoSize = true;
			this.lblZona.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblZona.ForeColor = System.Drawing.Color.Navy;
			this.lblZona.Location = new System.Drawing.Point(33, 15);
			this.lblZona.Name = "lblZona";
			this.lblZona.Size = new System.Drawing.Size(41, 13);
			this.lblZona.TabIndex = 3;
			this.lblZona.Text = "Zona:";
			// 
			// lblAnalista
			// 
			this.lblAnalista.AutoSize = true;
			this.lblAnalista.Font = new System.Drawing.Font("Verdana", 8F);
			this.lblAnalista.ForeColor = System.Drawing.Color.Navy;
			this.lblAnalista.Location = new System.Drawing.Point(17, 47);
			this.lblAnalista.Name = "lblAnalista";
			this.lblAnalista.Size = new System.Drawing.Size(57, 13);
			this.lblAnalista.TabIndex = 4;
			this.lblAnalista.Text = "Analista:";
			// 
			// cboAnalista
			// 
			this.cboAnalista.FormattingEnabled = true;
			this.cboAnalista.Location = new System.Drawing.Point(80, 44);
			this.cboAnalista.Name = "cboAnalista";
			this.cboAnalista.Size = new System.Drawing.Size(288, 21);
			this.cboAnalista.TabIndex = 5;
			// 
			// dtgAnalistaRsgZona
			// 
			this.dtgAnalistaRsgZona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dtgAnalistaRsgZona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgAnalistaRsgZona.Location = new System.Drawing.Point(15, 77);
			this.dtgAnalistaRsgZona.Name = "dtgAnalistaRsgZona";
			this.dtgAnalistaRsgZona.ReadOnly = true;
			this.dtgAnalistaRsgZona.Size = new System.Drawing.Size(531, 356);
			this.dtgAnalistaRsgZona.TabIndex = 6;
			this.dtgAnalistaRsgZona.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAnalistaRsgZona_CellClick);
			// 
			// btnAgregar1
			// 
			this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
			this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregar1.Location = new System.Drawing.Point(417, 14);
			this.btnAgregar1.Name = "btnAgregar1";
			this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
			this.btnAgregar1.TabIndex = 7;
			this.btnAgregar1.Text = "&Agregar";
			this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar1.UseVisualStyleBackColor = true;
			this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
			// 
			// frmAdministrarBandejaAnalista
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 458);
			this.Controls.Add(this.btnAgregar1);
			this.Controls.Add(this.dtgAnalistaRsgZona);
			this.Controls.Add(this.cboAnalista);
			this.Controls.Add(this.lblAnalista);
			this.Controls.Add(this.lblZona);
			this.Controls.Add(this.cboZona);
			this.Name = "frmAdministrarBandejaAnalista";
			this.Text = "frmAdministrarBandejaAnalista";
			this.Load += new System.EventHandler(this.frmAdministrarBandejaAnalista_Load);
			this.Controls.SetChildIndex(this.cboZona, 0);
			this.Controls.SetChildIndex(this.lblZona, 0);
			this.Controls.SetChildIndex(this.lblAnalista, 0);
			this.Controls.SetChildIndex(this.cboAnalista, 0);
			this.Controls.SetChildIndex(this.dtgAnalistaRsgZona, 0);
			this.Controls.SetChildIndex(this.btnAgregar1, 0);
			((System.ComponentModel.ISupportInitialize)(this.dtgAnalistaRsgZona)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.lblBase lblZona;
        private GEN.ControlesBase.lblBase lblAnalista;
        private GEN.ControlesBase.cboBase cboAnalista;
        private System.Windows.Forms.DataGridView dtgAnalistaRsgZona;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
    }
}