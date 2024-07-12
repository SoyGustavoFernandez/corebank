namespace GEN.ControlesBase
{
    partial class conUbigeo
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
            this.lblBase28 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboPais = new GEN.ControlesBase.cboBase(this.components);
            this.cboDpto = new GEN.ControlesBase.cboBase(this.components);
            this.cboProv = new GEN.ControlesBase.cboBase(this.components);
            this.cboDist = new GEN.ControlesBase.cboBase(this.components);
            this.SuspendLayout();
            // 
            // lblBase28
            // 
            this.lblBase28.AutoSize = true;
            this.lblBase28.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase28.ForeColor = System.Drawing.Color.Navy;
            this.lblBase28.Location = new System.Drawing.Point(470, 14);
            this.lblBase28.Name = "lblBase28";
            this.lblBase28.Size = new System.Drawing.Size(53, 13);
            this.lblBase28.TabIndex = 24;
            this.lblBase28.Text = "Distrito:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(320, 14);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(64, 13);
            this.lblBase4.TabIndex = 23;
            this.lblBase4.Text = "Provincia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(154, 14);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(39, 13);
            this.lblBase2.TabIndex = 22;
            this.lblBase2.Text = "Dpto:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 14);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(35, 13);
            this.lblBase1.TabIndex = 21;
            this.lblBase1.Text = "País:";
            // 
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(42, 11);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(112, 21);
            this.cboPais.TabIndex = 25;
            // 
            // cboDpto
            // 
            this.cboDpto.FormattingEnabled = true;
            this.cboDpto.Location = new System.Drawing.Point(193, 11);
            this.cboDpto.Name = "cboDpto";
            this.cboDpto.Size = new System.Drawing.Size(122, 21);
            this.cboDpto.TabIndex = 26;
            // 
            // cboProv
            // 
            this.cboProv.FormattingEnabled = true;
            this.cboProv.Location = new System.Drawing.Point(384, 12);
            this.cboProv.Name = "cboProv";
            this.cboProv.Size = new System.Drawing.Size(86, 21);
            this.cboProv.TabIndex = 27;
            // 
            // cboDist
            // 
            this.cboDist.FormattingEnabled = true;
            this.cboDist.Location = new System.Drawing.Point(522, 12);
            this.cboDist.Name = "cboDist";
            this.cboDist.Size = new System.Drawing.Size(111, 21);
            this.cboDist.TabIndex = 28;
            // 
            // conUbigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboDist);
            this.Controls.Add(this.cboProv);
            this.Controls.Add(this.cboDpto);
            this.Controls.Add(this.cboPais);
            this.Controls.Add(this.lblBase28);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "conUbigeo";
            this.Size = new System.Drawing.Size(645, 52);
            this.Load += new System.EventHandler(this.conUbigeo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase28;
        private lblBase lblBase4;
        private lblBase lblBase2;
        private lblBase lblBase1;
        private cboBase cboPais;
        private cboBase cboDpto;
        private cboBase cboProv;
        private cboBase cboDist;
    }
}
