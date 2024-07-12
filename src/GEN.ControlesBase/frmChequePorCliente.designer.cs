namespace GEN.ControlesBase
{
    partial class frmChequePorCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChequePorCliente));
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgChequesByCLi = new GEN.ControlesBase.dtgBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChequesByCLi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(277, 132);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(343, 132);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgChequesByCLi
            // 
            this.dtgChequesByCLi.AllowUserToAddRows = false;
            this.dtgChequesByCLi.AllowUserToDeleteRows = false;
            this.dtgChequesByCLi.AllowUserToResizeColumns = false;
            this.dtgChequesByCLi.AllowUserToResizeRows = false;
            this.dtgChequesByCLi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgChequesByCLi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChequesByCLi.Location = new System.Drawing.Point(12, 12);
            this.dtgChequesByCLi.MultiSelect = false;
            this.dtgChequesByCLi.Name = "dtgChequesByCLi";
            this.dtgChequesByCLi.ReadOnly = true;
            this.dtgChequesByCLi.RowHeadersVisible = false;
            this.dtgChequesByCLi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgChequesByCLi.Size = new System.Drawing.Size(391, 114);
            this.dtgChequesByCLi.TabIndex = 4;
            // 
            // frmChequePorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 209);
            this.Controls.Add(this.dtgChequesByCLi);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmChequePorCliente";
            this.Text = "Cheques por Cliente";
            this.Load += new System.EventHandler(this.frmChequePorCliente_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgChequesByCLi, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChequesByCLi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnSalir btnSalir;
        private dtgBase dtgChequesByCLi;
    }
}