namespace GEN.ControlesBase
{
    partial class frmCuentaCreditoVinculado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentaCreditoVinculado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbCuetas = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgCuentaCreditoVinculado = new System.Windows.Forms.DataGridView();
            this.txtSalTotalCre = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase34 = new GEN.ControlesBase.lblBase();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbCuetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentaCreditoVinculado)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCuetas
            // 
            this.grbCuetas.Controls.Add(this.btnQuitar);
            this.grbCuetas.Controls.Add(this.btnAgregar);
            this.grbCuetas.Controls.Add(this.dtgCuentaCreditoVinculado);
            this.grbCuetas.Controls.Add(this.txtSalTotalCre);
            this.grbCuetas.Controls.Add(this.lblBase34);
            this.grbCuetas.ForeColor = System.Drawing.Color.Navy;
            this.grbCuetas.Location = new System.Drawing.Point(12, 12);
            this.grbCuetas.Name = "grbCuetas";
            this.grbCuetas.Size = new System.Drawing.Size(645, 175);
            this.grbCuetas.TabIndex = 2;
            this.grbCuetas.TabStop = false;
            this.grbCuetas.Text = "Cuentas de Créditos Vigentes";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(604, 47);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(604, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgCuentaCreditoVinculado
            // 
            this.dtgCuentaCreditoVinculado.AllowUserToAddRows = false;
            this.dtgCuentaCreditoVinculado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCuentaCreditoVinculado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCuentaCreditoVinculado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCuentaCreditoVinculado.Location = new System.Drawing.Point(8, 19);
            this.dtgCuentaCreditoVinculado.Name = "dtgCuentaCreditoVinculado";
            this.dtgCuentaCreditoVinculado.ReadOnly = true;
            this.dtgCuentaCreditoVinculado.RowHeadersVisible = false;
            this.dtgCuentaCreditoVinculado.RowTemplate.Height = 19;
            this.dtgCuentaCreditoVinculado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCuentaCreditoVinculado.Size = new System.Drawing.Size(595, 120);
            this.dtgCuentaCreditoVinculado.TabIndex = 0;
            // 
            // txtSalTotalCre
            // 
            this.txtSalTotalCre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalTotalCre.FormatoDecimal = true;
            this.txtSalTotalCre.Location = new System.Drawing.Point(499, 145);
            this.txtSalTotalCre.Name = "txtSalTotalCre";
            this.txtSalTotalCre.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSalTotalCre.nNumDecimales = 2;
            this.txtSalTotalCre.nvalor = 0D;
            this.txtSalTotalCre.ReadOnly = true;
            this.txtSalTotalCre.Size = new System.Drawing.Size(104, 20);
            this.txtSalTotalCre.TabIndex = 2;
            this.txtSalTotalCre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase34
            // 
            this.lblBase34.AutoSize = true;
            this.lblBase34.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase34.ForeColor = System.Drawing.Color.Navy;
            this.lblBase34.Location = new System.Drawing.Point(418, 148);
            this.lblBase34.Name = "lblBase34";
            this.lblBase34.Size = new System.Drawing.Size(75, 13);
            this.lblBase34.TabIndex = 1;
            this.lblBase34.Text = "Saldo Total:";
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(525, 193);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 3;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(592, 193);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmCuentaCreditoVinculado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 277);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.grbCuetas);
            this.Name = "frmCuentaCreditoVinculado";
            this.Text = "Créditos Vinculados";
            this.Load += new System.EventHandler(this.frmCuentaCreditoVinculado_Load);
            this.Controls.SetChildIndex(this.grbCuetas, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbCuetas.ResumeLayout(false);
            this.grbCuetas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCuentaCreditoVinculado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private grbBase grbCuetas;
        private System.Windows.Forms.DataGridView dtgCuentaCreditoVinculado;
        private txtNumRea txtSalTotalCre;
        private lblBase lblBase34;
        private BotonesBase.BtnAceptar btnAceptar1;
        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.btnMiniQuitar btnQuitar;
        private BotonesBase.btnMiniAgregar btnAgregar;
    }
}