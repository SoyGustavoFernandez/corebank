namespace GEN.ControlesBase
{
    partial class ConBusTipoPers
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
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoPersona1 = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.SuspendLayout();
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(11, 11);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(86, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Tipo Persona:";
            // 
            // cboTipoPersona1
            // 
            this.cboTipoPersona1.FormattingEnabled = true;
            this.cboTipoPersona1.Location = new System.Drawing.Point(103, 3);
            this.cboTipoPersona1.Name = "cboTipoPersona1";
            this.cboTipoPersona1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoPersona1.TabIndex = 4;
            // 
            // ConBusTipoPers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboTipoPersona1);
            this.Controls.Add(this.lblBase5);
            this.Name = "ConBusTipoPers";
            this.Size = new System.Drawing.Size(236, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase5;
        private cboTipoPersona cboTipoPersona1;
    }
}
