namespace ADM.Presentacion
{
    partial class frmRegPcUsu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPcUsu));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.chklbDatPcUsu = new GEN.ControlesBase.chklbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboTipoActi = new GEN.ControlesBase.cboBase(this.components);
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(25, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(388, 16);
            this.lblBase2.TabIndex = 128;
            this.lblBase2.Text = "Pcs de Usuarios";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chklbDatPcUsu
            // 
            this.chklbDatPcUsu.FormattingEnabled = true;
            this.chklbDatPcUsu.Location = new System.Drawing.Point(25, 74);
            this.chklbDatPcUsu.Name = "chklbDatPcUsu";
            this.chklbDatPcUsu.Size = new System.Drawing.Size(388, 214);
            this.chklbDatPcUsu.TabIndex = 127;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(353, 294);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 126;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboTipoActi
            // 
            this.cboTipoActi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoActi.FormattingEnabled = true;
            this.cboTipoActi.Location = new System.Drawing.Point(188, 9);
            this.cboTipoActi.Name = "cboTipoActi";
            this.cboTipoActi.Size = new System.Drawing.Size(150, 21);
            this.cboTipoActi.TabIndex = 129;
            this.cboTipoActi.SelectedIndexChanged += new System.EventHandler(this.cboTipoActi_SelectedIndexChanged);
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcSelec.Location = new System.Drawing.Point(303, 55);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(110, 17);
            this.chcSelec.TabIndex = 130;
            this.chcSelec.Text = "Seleccionar Todo";
            this.chcSelec.UseVisualStyleBackColor = false;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(157, 13);
            this.lblBase1.TabIndex = 131;
            this.lblBase1.Text = "Selecione tipo a Visualizar";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(287, 294);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 132;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(221, 294);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 133;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmRegPcUsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 381);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.chcSelec);
            this.Controls.Add(this.cboTipoActi);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.chklbDatPcUsu);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRegPcUsu";
            this.Text = "Registro de PC de Usuario";
            this.Load += new System.EventHandler(this.frmRegPcUsu_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.chklbDatPcUsu, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoActi, 0);
            this.Controls.SetChildIndex(this.chcSelec, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chklbBase chklbDatPcUsu;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboBase cboTipoActi;
        private GEN.ControlesBase.chcBase chcSelec;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}

