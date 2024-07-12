namespace GEN.ControlesBase
{
    partial class conPagoBcos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.txtCodOpera = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase26 = new GEN.ControlesBase.lblBase();
            this.lblBase28 = new GEN.ControlesBase.lblBase();
            this.cboCuenta = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase27 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Controls.Add(this.cboEntidad);
            this.grbBase1.Controls.Add(this.txtCodOpera);
            this.grbBase1.Controls.Add(this.lblBase26);
            this.grbBase1.Controls.Add(this.lblBase28);
            this.grbBase1.Controls.Add(this.cboCuenta);
            this.grbBase1.Controls.Add(this.lblBase27);
            this.grbBase1.Location = new System.Drawing.Point(0, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(241, 104);
            this.grbBase1.TabIndex = 60;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle Medio de Pago";
            // 
            // cboEntidad
            // 
            this.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(64, 20);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(171, 21);
            this.cboEntidad.TabIndex = 54;
            this.cboEntidad.SelectedIndexChanged += new System.EventHandler(this.cboEntidad_SelectedIndexChanged);
            // 
            // txtCodOpera
            // 
            this.txtCodOpera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodOpera.Location = new System.Drawing.Point(104, 72);
            this.txtCodOpera.MaxLength = 50;
            this.txtCodOpera.Name = "txtCodOpera";
            this.txtCodOpera.Size = new System.Drawing.Size(131, 20);
            this.txtCodOpera.TabIndex = 59;
            // 
            // lblBase26
            // 
            this.lblBase26.AutoSize = true;
            this.lblBase26.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase26.ForeColor = System.Drawing.Color.Navy;
            this.lblBase26.Location = new System.Drawing.Point(4, 23);
            this.lblBase26.Name = "lblBase26";
            this.lblBase26.Size = new System.Drawing.Size(54, 13);
            this.lblBase26.TabIndex = 55;
            this.lblBase26.Text = "Entidad:";
            // 
            // lblBase28
            // 
            this.lblBase28.AutoSize = true;
            this.lblBase28.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase28.ForeColor = System.Drawing.Color.Navy;
            this.lblBase28.Location = new System.Drawing.Point(4, 75);
            this.lblBase28.Name = "lblBase28";
            this.lblBase28.Size = new System.Drawing.Size(94, 13);
            this.lblBase28.TabIndex = 58;
            this.lblBase28.Text = "Nro Operación:";
            // 
            // cboCuenta
            // 
            this.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Location = new System.Drawing.Point(64, 45);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(171, 21);
            this.cboCuenta.TabIndex = 56;
            // 
            // lblBase27
            // 
            this.lblBase27.AutoSize = true;
            this.lblBase27.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase27.ForeColor = System.Drawing.Color.Navy;
            this.lblBase27.Location = new System.Drawing.Point(4, 48);
            this.lblBase27.Name = "lblBase27";
            this.lblBase27.Size = new System.Drawing.Size(53, 13);
            this.lblBase27.TabIndex = 57;
            this.lblBase27.Text = "Cuenta:";
            // 
            // conPagoBcos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbBase1);
            this.Name = "conPagoBcos";
            this.Size = new System.Drawing.Size(244, 108);
            this.Tag = "";
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private txtBase txtCodOpera;
        private lblBase lblBase28;
        private lblBase lblBase27;
        private cboBase cboCuenta;
        private lblBase lblBase26;
        private cboEntidad cboEntidad;
        private grbBase grbBase1;
    }
}
