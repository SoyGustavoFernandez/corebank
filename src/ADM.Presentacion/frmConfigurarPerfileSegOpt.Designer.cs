namespace ADM.Presentacion
{
    partial class frmConfigurarPerfileSegOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarPerfileSegOpt));
            this.cboListaPerfil1 = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.chbAutorizado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboListaPerfil1
            // 
            this.cboListaPerfil1.AgregarItemTodos = true;
            this.cboListaPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil1.FormattingEnabled = true;
            this.cboListaPerfil1.Location = new System.Drawing.Point(67, 23);
            this.cboListaPerfil1.Name = "cboListaPerfil1";
            this.cboListaPerfil1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboListaPerfil1.Size = new System.Drawing.Size(253, 21);
            this.cboListaPerfil1.TabIndex = 2;
            this.cboListaPerfil1.SelectedValueChanged += new System.EventHandler(this.cboListaPerfil1_SelectedValueChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(49, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Perfiles";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(260, 72);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(200, 72);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // chbAutorizado
            // 
            this.chbAutorizado.AutoSize = true;
            this.chbAutorizado.Location = new System.Drawing.Point(67, 50);
            this.chbAutorizado.Name = "chbAutorizado";
            this.chbAutorizado.Size = new System.Drawing.Size(76, 17);
            this.chbAutorizado.TabIndex = 24;
            this.chbAutorizado.Text = "Autorizado";
            this.chbAutorizado.UseVisualStyleBackColor = true;
            this.chbAutorizado.CheckedChanged += new System.EventHandler(this.chbAutorizado_CheckedChanged);
            // 
            // frmAgregarPerfilesSegOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 147);
            this.Controls.Add(this.chbAutorizado);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboListaPerfil1);
            this.Name = "frmConfigurarPerfileSegOpt";
            this.Text = "Configurar Perfil Seguro Optativo";
            this.Load += new System.EventHandler(this.frmAgregarPerfilesSegOpt_Load);
            this.Controls.SetChildIndex(this.cboListaPerfil1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.chbAutorizado, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboListaPerfil cboListaPerfil1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.CheckBox chbAutorizado;

    }
}