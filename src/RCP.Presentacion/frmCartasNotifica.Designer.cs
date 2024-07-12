namespace RCP.Presentacion
{
    partial class frmCartasNotifica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCartasNotifica));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgTipoCarta = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoCarta)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 2;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(616, 437);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Location = new System.Drawing.Point(12, 132);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(657, 108);
            this.dtgCreditos.TabIndex = 5;
            this.dtgCreditos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgCreditos_CellMouseClick);
            // 
            // dtgTipoCarta
            // 
            this.dtgTipoCarta.AllowUserToAddRows = false;
            this.dtgTipoCarta.AllowUserToDeleteRows = false;
            this.dtgTipoCarta.AllowUserToResizeColumns = false;
            this.dtgTipoCarta.AllowUserToResizeRows = false;
            this.dtgTipoCarta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTipoCarta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoCarta.Location = new System.Drawing.Point(12, 287);
            this.dtgTipoCarta.MultiSelect = false;
            this.dtgTipoCarta.Name = "dtgTipoCarta";
            this.dtgTipoCarta.ReadOnly = true;
            this.dtgTipoCarta.RowHeadersVisible = false;
            this.dtgTipoCarta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoCarta.Size = new System.Drawing.Size(602, 202);
            this.dtgTipoCarta.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 262);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(90, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Notificaciones:";
            // 
            // frmCartasNotifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 520);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgTipoCarta);
            this.Controls.Add(this.dtgCreditos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.conBusCli1);
            this.Name = "frmCartasNotifica";
            this.Text = "Generación de Cartas de Recuperación";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgCreditos, 0);
            this.Controls.SetChildIndex(this.dtgTipoCarta, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoCarta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.ControlesBase.dtgBase dtgTipoCarta;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}

