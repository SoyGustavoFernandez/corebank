namespace GEN.ControlesBase
{
    partial class conBusCtaAho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conBusCtaAho));
            this.btnBusCliente = new GEN.BotonesBase.btnBusCliente();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCodMon = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodMod = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodIns = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroCta = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBusCliente
            // 
            this.btnBusCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente.BackgroundImage")));
            this.btnBusCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente.Location = new System.Drawing.Point(484, 19);
            this.btnBusCliente.Name = "btnBusCliente";
            this.btnBusCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente.TabIndex = 0;
            this.btnBusCliente.Text = "Cliente";
            this.btnBusCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente.UseVisualStyleBackColor = true;
            this.btnBusCliente.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(158, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtCodMon);
            this.grbBase1.Controls.Add(this.txtCodMod);
            this.grbBase1.Controls.Add(this.txtCodAge);
            this.grbBase1.Controls.Add(this.txtCodIns);
            this.grbBase1.Controls.Add(this.txtCodCli);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtNroCta);
            this.grbBase1.Controls.Add(this.txtNroDoc);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(556, 112);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            this.grbBase1.Enter += new System.EventHandler(this.grbBase1_Enter);
            // 
            // txtCodMon
            // 
            this.txtCodMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMon.Location = new System.Drawing.Point(236, 13);
            this.txtCodMon.MaxLength = 1;
            this.txtCodMon.Name = "txtCodMon";
            this.txtCodMon.Size = new System.Drawing.Size(13, 20);
            this.txtCodMon.TabIndex = 3;
            this.txtCodMon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodMon_KeyPress);
            this.txtCodMon.Leave += new System.EventHandler(this.txtCodMon_Leave);
            // 
            // txtCodMod
            // 
            this.txtCodMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMod.Location = new System.Drawing.Point(209, 13);
            this.txtCodMod.MaxLength = 3;
            this.txtCodMod.Name = "txtCodMod";
            this.txtCodMod.Size = new System.Drawing.Size(27, 20);
            this.txtCodMod.TabIndex = 2;
            this.txtCodMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodMod_KeyPress);
            this.txtCodMod.Leave += new System.EventHandler(this.txtCodMod_Leave);
            // 
            // txtCodAge
            // 
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(182, 13);
            this.txtCodAge.MaxLength = 3;
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 1;
            this.txtCodAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodAge_KeyPress);
            this.txtCodAge.Leave += new System.EventHandler(this.txtCodAge_Leave);
            // 
            // txtCodIns
            // 
            this.txtCodIns.Enabled = false;
            this.txtCodIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodIns.Location = new System.Drawing.Point(155, 13);
            this.txtCodIns.MaxLength = 3;
            this.txtCodIns.Name = "txtCodIns";
            this.txtCodIns.Size = new System.Drawing.Size(27, 20);
            this.txtCodIns.TabIndex = 0;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Enabled = false;
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(155, 39);
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(184, 20);
            this.txtCodCli.TabIndex = 5;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 43);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(114, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Código de Cliente:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 86);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(145, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Nombre o Razón Social:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 19);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(99, 13);
            this.lblBase4.TabIndex = 20;
            this.lblBase4.Text = "Nro. de Cuenta:";
            // 
            // txtNroCta
            // 
            this.txtNroCta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCta.Location = new System.Drawing.Point(249, 13);
            this.txtNroCta.MaxLength = 12;
            this.txtNroCta.Name = "txtNroCta";
            this.txtNroCta.Size = new System.Drawing.Size(91, 20);
            this.txtNroCta.TabIndex = 4;
            this.txtNroCta.TextChanged += new System.EventHandler(this.txtNroCta_TextChanged);
            this.txtNroCta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCta_KeyPress);
            this.txtNroCta.Leave += new System.EventHandler(this.txtNroCta_Leave_1);
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(155, 61);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(183, 20);
            this.txtNroDoc.TabIndex = 6;
            this.txtNroDoc.TextChanged += new System.EventHandler(this.txtNroDoc_TextChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 65);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(123, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Nro. de Documento:";
            // 
            // conBusCtaAho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBusCliente);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.grbBase1);
            this.Name = "conBusCtaAho";
            this.Size = new System.Drawing.Size(563, 114);
            this.Load += new System.EventHandler(this.conBusCtaAho_Load);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
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
        private grbBase grbBase1;
        private lblBase lblBase4;
        public txtBase txtNroCta;
        public BotonesBase.btnBusCliente btnBusCliente;
        public txtBase txtCodMon;
        public txtBase txtCodMod;
        public txtBase txtCodAge;
        public txtBase txtCodIns;
    }
}
