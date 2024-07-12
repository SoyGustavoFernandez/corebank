namespace GEN.ControlesBase
{
    partial class ConDatPerReaOperac
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
            this.txtDocIdePerson = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccPerson = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombrePerson = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // txtDocIdePerson
            // 
            this.txtDocIdePerson.Location = new System.Drawing.Point(78, 7);
            this.txtDocIdePerson.MaxLength = 15;
            this.txtDocIdePerson.Name = "txtDocIdePerson";
            this.txtDocIdePerson.Size = new System.Drawing.Size(131, 20);
            this.txtDocIdePerson.TabIndex = 0;
            this.txtDocIdePerson.TextChanged += new System.EventHandler(this.txtDocIdePerson_TextChanged_1);
            this.txtDocIdePerson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocIdePerson_KeyPress_1);
            // 
            // txtDireccPerson
            // 
            this.txtDireccPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccPerson.Enabled = false;
            this.txtDireccPerson.Location = new System.Drawing.Point(77, 54);
            this.txtDireccPerson.Name = "txtDireccPerson";
            this.txtDireccPerson.Size = new System.Drawing.Size(299, 20);
            this.txtDireccPerson.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 59);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 13;
            this.lblBase1.Text = "Dirección:";
            // 
            // txtNombrePerson
            // 
            this.txtNombrePerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombrePerson.Enabled = false;
            this.txtNombrePerson.Location = new System.Drawing.Point(77, 30);
            this.txtNombrePerson.Name = "txtNombrePerson";
            this.txtNombrePerson.Size = new System.Drawing.Size(299, 20);
            this.txtNombrePerson.TabIndex = 1;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(7, 34);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(57, 13);
            this.lblBase16.TabIndex = 10;
            this.lblBase16.Text = "Nombre:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(7, 10);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(35, 13);
            this.lblBase17.TabIndex = 9;
            this.lblBase17.Text = "DOI:";
            // 
            // ConDatPerReaOperac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDocIdePerson);
            this.Controls.Add(this.txtDireccPerson);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtNombrePerson);
            this.Controls.Add(this.lblBase16);
            this.Controls.Add(this.lblBase17);
            this.Name = "ConDatPerReaOperac";
            this.Size = new System.Drawing.Size(383, 79);
            this.Load += new System.EventHandler(this.ConDatPerReaOperac_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase16;
        private lblBase lblBase17;
        private lblBase lblBase1;
        public txtBase txtNombrePerson;
        public txtBase txtDireccPerson;
        public txtBase txtDocIdePerson;
    }
}
