namespace ADM.Presentacion
{
    partial class frmAddEditObsSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditObsSol));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcSubsanado = new GEN.ControlesBase.chcBase(this.components);
            this.txtDetObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipObsSol = new GEN.ControlesBase.cboTipObsSol(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(390, 219);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(324, 219);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcSubsanado);
            this.grbBase1.Controls.Add(this.txtDetObservacion);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboTipObsSol);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(438, 201);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la observación";
            // 
            // chcSubsanado
            // 
            this.chcSubsanado.AutoSize = true;
            this.chcSubsanado.Location = new System.Drawing.Point(26, 175);
            this.chcSubsanado.Name = "chcSubsanado";
            this.chcSubsanado.Size = new System.Drawing.Size(86, 17);
            this.chcSubsanado.TabIndex = 5;
            this.chcSubsanado.Text = "Subsanado?";
            this.chcSubsanado.UseVisualStyleBackColor = true;
            // 
            // txtDetObservacion
            // 
            this.txtDetObservacion.Location = new System.Drawing.Point(26, 93);
            this.txtDetObservacion.Multiline = true;
            this.txtDetObservacion.Name = "txtDetObservacion";
            this.txtDetObservacion.Size = new System.Drawing.Size(406, 75);
            this.txtDetObservacion.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(26, 73);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(125, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Detalle observación:";
            // 
            // cboTipObsSol
            // 
            this.cboTipObsSol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipObsSol.FormattingEnabled = true;
            this.cboTipObsSol.Location = new System.Drawing.Point(26, 45);
            this.cboTipObsSol.Name = "cboTipObsSol";
            this.cboTipObsSol.Size = new System.Drawing.Size(188, 21);
            this.cboTipObsSol.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(109, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo observación:";
            // 
            // frmAddEditObsSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 301);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmAddEditObsSol";
            this.Text = "Agregar o editar observaciones de solicitudes";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcSubsanado;
        private GEN.ControlesBase.txtBase txtDetObservacion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipObsSol cboTipObsSol;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}

