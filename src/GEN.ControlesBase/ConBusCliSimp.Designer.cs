namespace GEN.ControlesBase
{
    partial class ConBusCliSimp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConBusCliSimp));
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnBusCliente = new GEN.BotonesBase.btnBusCliente();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.plCodDocumento = new System.Windows.Forms.Panel();
            this.lblClasificacionCliente = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.plCodigoCli = new System.Windows.Forms.Panel();
            this.plDocumento = new System.Windows.Forms.Panel();
            this.plNombre = new System.Windows.Forms.Panel();
            this.plDireccion = new System.Windows.Forms.Panel();
            this.plCodDocumento.SuspendLayout();
            this.plCodigoCli.SuspendLayout();
            this.plDocumento.SuspendLayout();
            this.plNombre.SuspendLayout();
            this.plDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(95, 0);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 24;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(122, 0);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 23;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(95, 0);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(255, 20);
            this.txtDireccion.TabIndex = 22;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(0, 4);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 21;
            this.lblBase4.Text = "Dirección:";
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(149, 0);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(75, 20);
            this.txtCodCli.TabIndex = 14;
            this.txtCodCli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodCli_KeyPress);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(0, 3);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Cód. Cliente:";
            // 
            // btnBusCliente
            // 
            this.btnBusCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBusCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCliente.BackgroundImage")));
            this.btnBusCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCliente.Location = new System.Drawing.Point(290, 0);
            this.btnBusCliente.Margin = new System.Windows.Forms.Padding(0);
            this.btnBusCliente.Name = "btnBusCliente";
            this.btnBusCliente.Size = new System.Drawing.Size(60, 50);
            this.btnBusCliente.TabIndex = 15;
            this.btnBusCliente.Text = "Cliente";
            this.btnBusCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCliente.UseVisualStyleBackColor = true;
            this.btnBusCliente.Click += new System.EventHandler(this.btnBusCliente_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(95, 0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(255, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(95, 0);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(129, 20);
            this.txtNroDoc.TabIndex = 18;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(0, 4);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Nombre:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(0, 4);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "N° Documento:";
            // 
            // plCodDocumento
            // 
            this.plCodDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plCodDocumento.Controls.Add(this.lblClasificacionCliente);
            this.plCodDocumento.Controls.Add(this.plCodigoCli);
            this.plCodDocumento.Controls.Add(this.plDocumento);
            this.plCodDocumento.Controls.Add(this.btnBusCliente);
            this.plCodDocumento.Location = new System.Drawing.Point(0, 0);
            this.plCodDocumento.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plCodDocumento.Name = "plCodDocumento";
            this.plCodDocumento.Size = new System.Drawing.Size(350, 50);
            this.plCodDocumento.TabIndex = 26;
            // 
            // lblClasificacionCliente
            // 
            this.lblClasificacionCliente.AutoSize = true;
            this.lblClasificacionCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacionCliente.ForeColor = System.Drawing.Color.Navy;
            this.lblClasificacionCliente.Location = new System.Drawing.Point(230, 12);
            this.lblClasificacionCliente.Name = "lblClasificacionCliente";
            this.lblClasificacionCliente.Size = new System.Drawing.Size(0, 13);
            this.lblClasificacionCliente.TabIndex = 28;
            // 
            // plCodigoCli
            // 
            this.plCodigoCli.Controls.Add(this.lblBase3);
            this.plCodigoCli.Controls.Add(this.txtCodCli);
            this.plCodigoCli.Controls.Add(this.txtCodAge);
            this.plCodigoCli.Controls.Add(this.txtCodInst);
            this.plCodigoCli.Location = new System.Drawing.Point(0, 8);
            this.plCodigoCli.Margin = new System.Windows.Forms.Padding(0);
            this.plCodigoCli.Name = "plCodigoCli";
            this.plCodigoCli.Size = new System.Drawing.Size(224, 20);
            this.plCodigoCli.TabIndex = 27;
            // 
            // plDocumento
            // 
            this.plDocumento.Controls.Add(this.lblBase1);
            this.plDocumento.Controls.Add(this.txtNroDoc);
            this.plDocumento.Location = new System.Drawing.Point(0, 29);
            this.plDocumento.Margin = new System.Windows.Forms.Padding(0);
            this.plDocumento.Name = "plDocumento";
            this.plDocumento.Size = new System.Drawing.Size(224, 20);
            this.plDocumento.TabIndex = 26;
            // 
            // plNombre
            // 
            this.plNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plNombre.Controls.Add(this.lblBase2);
            this.plNombre.Controls.Add(this.txtNombre);
            this.plNombre.Location = new System.Drawing.Point(0, 51);
            this.plNombre.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plNombre.Name = "plNombre";
            this.plNombre.Size = new System.Drawing.Size(350, 20);
            this.plNombre.TabIndex = 27;
            // 
            // plDireccion
            // 
            this.plDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plDireccion.Controls.Add(this.lblBase4);
            this.plDireccion.Controls.Add(this.txtDireccion);
            this.plDireccion.Location = new System.Drawing.Point(0, 72);
            this.plDireccion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plDireccion.Name = "plDireccion";
            this.plDireccion.Size = new System.Drawing.Size(350, 20);
            this.plDireccion.TabIndex = 27;
            // 
            // ConBusCliSimp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.plDireccion);
            this.Controls.Add(this.plNombre);
            this.Controls.Add(this.plCodDocumento);
            this.Name = "ConBusCliSimp";
            this.Size = new System.Drawing.Size(350, 92);
            this.Load += new System.EventHandler(this.ConBusCliSimp_Load);
            this.plCodDocumento.ResumeLayout(false);
            this.plCodDocumento.PerformLayout();
            this.plCodigoCli.ResumeLayout(false);
            this.plCodigoCli.PerformLayout();
            this.plDocumento.ResumeLayout(false);
            this.plDocumento.PerformLayout();
            this.plNombre.ResumeLayout(false);
            this.plNombre.PerformLayout();
            this.plDireccion.ResumeLayout(false);
            this.plDireccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public txtBase txtCodInst;
        public txtBase txtCodAge;
        public txtBase txtDireccion;
        public lblBase lblBase4;
        public txtCBNumerosEnteros txtCodCli;
        private lblBase lblBase3;
        public BotonesBase.btnBusCliente btnBusCliente;
        public txtBase txtNombre;
        public txtBase txtNroDoc;
        public lblBase lblBase2;
        public lblBase lblBase1;
        private System.Windows.Forms.Panel plCodDocumento;
        private System.Windows.Forms.Panel plCodigoCli;
        private System.Windows.Forms.Panel plDocumento;
        private System.Windows.Forms.Panel plNombre;
        private System.Windows.Forms.Panel plDireccion;
        private lblBaseCustom lblClasificacionCliente;
    }
}
