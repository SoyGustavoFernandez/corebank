namespace GEN.ControlesBase
{
    partial class conDatCli
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
            this.txtCodCli = new GEN.ControlesBase.txtBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase();
            this.txtNroDoc = new GEN.ControlesBase.txtBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // txtCodCli
            // 
            this.txtCodCli.Enabled = false;
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(94, 6);
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(120, 20);
            this.txtCodCli.TabIndex = 15;
            // 
            // lblBase3
            // 
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(0, 7);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(104, 22);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Código Cliente:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(94, 39);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(388, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(332, 6);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(150, 20);
            this.txtNroDoc.TabIndex = 12;
            // 
            // lblBase2
            // 
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(0, 32);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(91, 30);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Nombre o Razón Social:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(221, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(105, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Nro. Documento:";
            // 
            // conDatCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCodCli);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "conDatCli";
            this.Size = new System.Drawing.Size(485, 74);
            this.Load += new System.EventHandler(this.conDatCli_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public txtBase txtCodCli;
        private lblBase lblBase3;
        public txtBase txtNombre;
        public txtBase txtNroDoc;
        public lblBase lblBase2;
        public lblBase lblBase1;
    }
}
