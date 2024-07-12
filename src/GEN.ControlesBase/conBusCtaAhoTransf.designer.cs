namespace GEN.ControlesBase
{
    partial class conBusCtaAhoTransf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conBusCtaAhoTransf));
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusCliente = new GEN.BotonesBase.btnBusCliente();
            this.txtCodMon = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodMod = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodIns = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroCta = new GEN.ControlesBase.txtBase(this.components);
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(112, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(347, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnBusCliente);
            this.grbBase1.Controls.Add(this.txtCodMon);
            this.grbBase1.Controls.Add(this.txtCodMod);
            this.grbBase1.Controls.Add(this.txtCodAge);
            this.grbBase1.Controls.Add(this.txtCodIns);
            this.grbBase1.Controls.Add(this.txtCodCli);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtNroCta);
            this.grbBase1.Controls.Add(this.txtProducto);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(460, 114);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente a Transferir";
            this.grbBase1.Enter += new System.EventHandler(this.grbBase1_Enter);
            // 
            // btnBusCliente
            // 
            this.btnBusCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente.BackgroundImage")));
            this.btnBusCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente.Location = new System.Drawing.Point(396, 11);
            this.btnBusCliente.Name = "btnBusCliente";
            this.btnBusCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente.TabIndex = 5;
            this.btnBusCliente.Text = "Cliente";
            this.btnBusCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente.UseVisualStyleBackColor = true;
            this.btnBusCliente.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // txtCodMon
            // 
            this.txtCodMon.Enabled = false;
            this.txtCodMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMon.Location = new System.Drawing.Point(191, 14);
            this.txtCodMon.MaxLength = 1;
            this.txtCodMon.Name = "txtCodMon";
            this.txtCodMon.Size = new System.Drawing.Size(13, 20);
            this.txtCodMon.TabIndex = 3;
            // 
            // txtCodMod
            // 
            this.txtCodMod.Enabled = false;
            this.txtCodMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodMod.Location = new System.Drawing.Point(163, 14);
            this.txtCodMod.MaxLength = 3;
            this.txtCodMod.Name = "txtCodMod";
            this.txtCodMod.Size = new System.Drawing.Size(28, 20);
            this.txtCodMod.TabIndex = 2;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(136, 14);
            this.txtCodAge.MaxLength = 3;
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 1;
            // 
            // txtCodIns
            // 
            this.txtCodIns.Enabled = false;
            this.txtCodIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodIns.Location = new System.Drawing.Point(109, 14);
            this.txtCodIns.MaxLength = 3;
            this.txtCodIns.Name = "txtCodIns";
            this.txtCodIns.Size = new System.Drawing.Size(27, 20);
            this.txtCodIns.TabIndex = 0;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Enabled = false;
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(109, 38);
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(186, 20);
            this.txtCodCli.TabIndex = 6;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 41);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Código Cliente:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 66);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Cliente:";
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
            this.txtNroCta.Enabled = false;
            this.txtNroCta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCta.Location = new System.Drawing.Point(204, 14);
            this.txtNroCta.MaxLength = 12;
            this.txtNroCta.Name = "txtNroCta";
            this.txtNroCta.Size = new System.Drawing.Size(93, 20);
            this.txtNroCta.TabIndex = 4;
            this.txtNroCta.TextChanged += new System.EventHandler(this.txtNroCta_TextChanged);
            this.txtNroCta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCta_KeyPress);
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(109, 88);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(347, 20);
            this.txtProducto.TabIndex = 7;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 87);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(62, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Producto:";
            // 
            // conBusCtaAhoTransf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.grbBase1);
            this.Name = "conBusCtaAhoTransf";
            this.Size = new System.Drawing.Size(467, 117);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public txtBase txtCodCli;
        private lblBase lblBase3;
        public txtBase txtNombre;
        public txtBase txtProducto;
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
