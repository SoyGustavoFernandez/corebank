namespace CRE.Presentacion
{
    partial class frmBusGarantEvaEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusGarantEvaEmp));
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantias.Location = new System.Drawing.Point(12, 114);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(769, 195);
            this.dtgGarantias.TabIndex = 2;
            this.dtgGarantias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgGarantias_KeyPress);
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(12, 3);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 3;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(660, 315);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(721, 315);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmBusGarantEvaEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 395);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.dtgGarantias);
            this.Name = "frmBusGarantEvaEmp";
            this.Text = "Buscar Garantia";
            this.Controls.SetChildIndex(this.dtgGarantias, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgGarantias;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}