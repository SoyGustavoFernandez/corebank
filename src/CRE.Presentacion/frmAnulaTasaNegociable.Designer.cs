namespace CRE.Presentacion
{
    partial class frmAnulaTasaNegociable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnulaTasaNegociable));
            this.lblOtrosAnula = new GEN.ControlesBase.lblBase();
            this.lblBase37 = new GEN.ControlesBase.lblBase();
            this.cboMotivoAnula = new GEN.ControlesBase.cboBase(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtOtrosAnula = new GEN.ControlesBase.txtBase(this.components);
            this.SuspendLayout();
            // 
            // lblOtrosAnula
            // 
            this.lblOtrosAnula.AutoSize = true;
            this.lblOtrosAnula.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblOtrosAnula.ForeColor = System.Drawing.Color.Navy;
            this.lblOtrosAnula.Location = new System.Drawing.Point(9, 70);
            this.lblOtrosAnula.Name = "lblOtrosAnula";
            this.lblOtrosAnula.Size = new System.Drawing.Size(106, 13);
            this.lblOtrosAnula.TabIndex = 182;
            this.lblOtrosAnula.Text = "Especificar otros:";
            this.lblOtrosAnula.Visible = false;
            // 
            // lblBase37
            // 
            this.lblBase37.AutoSize = true;
            this.lblBase37.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase37.ForeColor = System.Drawing.Color.Navy;
            this.lblBase37.Location = new System.Drawing.Point(9, 12);
            this.lblBase37.Name = "lblBase37";
            this.lblBase37.Size = new System.Drawing.Size(196, 13);
            this.lblBase37.TabIndex = 180;
            this.lblBase37.Text = "Seleccionar Motivo de Anulación:";
            // 
            // cboMotivoAnula
            // 
            this.cboMotivoAnula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoAnula.FormattingEnabled = true;
            this.cboMotivoAnula.Location = new System.Drawing.Point(12, 28);
            this.cboMotivoAnula.Name = "cboMotivoAnula";
            this.cboMotivoAnula.Size = new System.Drawing.Size(369, 21);
            this.cboMotivoAnula.TabIndex = 179;
            this.cboMotivoAnula.SelectedIndexChanged += new System.EventHandler(this.cboMotivoAnula_SelectedIndexChanged);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(134, 143);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 183;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(200, 143);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 184;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtOtrosAnula
            // 
            this.txtOtrosAnula.Location = new System.Drawing.Point(12, 88);
            this.txtOtrosAnula.Multiline = true;
            this.txtOtrosAnula.Name = "txtOtrosAnula";
            this.txtOtrosAnula.Size = new System.Drawing.Size(369, 37);
            this.txtOtrosAnula.TabIndex = 185;
            // 
            // frmAnulaTasaNegociable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 234);
            this.Controls.Add(this.txtOtrosAnula);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblOtrosAnula);
            this.Controls.Add(this.lblBase37);
            this.Controls.Add(this.cboMotivoAnula);
            this.Name = "frmAnulaTasaNegociable";
            this.Text = "Anular Tasa Negociable";
            this.Load += new System.EventHandler(this.frmAnulaTasaNegociable_Load);
            this.Controls.SetChildIndex(this.cboMotivoAnula, 0);
            this.Controls.SetChildIndex(this.lblBase37, 0);
            this.Controls.SetChildIndex(this.lblOtrosAnula, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtOtrosAnula, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblOtrosAnula;
        private GEN.ControlesBase.cboBase cboMotivoAnula;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        public GEN.ControlesBase.lblBase lblBase37;
        private GEN.ControlesBase.txtBase txtOtrosAnula;
    }
}