namespace GEN.ControlesBase
{
    partial class frmAutorizoUsoDatosCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutorizoUsoDatosCli));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTelefono = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.ttpToolTip1 = new GEN.ControlesBase.ttpToolTip();
            this.autorizaTratamientoUsoDatosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.conAutDatosBase1 = new GEN.ControlesBase.conAutDatosBase();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autorizaTratamientoUsoDatosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(731, 346);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtTelefono);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.lblBase13);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.txtDireccion);
            this.grbBase3.Controls.Add(this.txtNroDoc);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.txtNombre);
            this.grbBase3.Location = new System.Drawing.Point(5, 11);
            this.grbBase3.Margin = new System.Windows.Forms.Padding(2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Padding = new System.Windows.Forms.Padding(2);
            this.grbBase3.Size = new System.Drawing.Size(731, 77);
            this.grbBase3.TabIndex = 16;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos cliente:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(116, 50);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.MaxLength = 8;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(136, 20);
            this.txtTelefono.TabIndex = 26;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(4, 53);
            this.lblBase7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(60, 13);
            this.lblBase7.TabIndex = 25;
            this.lblBase7.Text = "Teléfono:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(4, 29);
            this.lblBase13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(105, 13);
            this.lblBase13.TabIndex = 16;
            this.lblBase13.Text = "Nro. Documento:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(258, 30);
            this.lblBase12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(63, 13);
            this.lblBase12.TabIndex = 17;
            this.lblBase12.Text = "Nombres:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(331, 50);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(394, 20);
            this.txtDireccion.TabIndex = 22;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(117, 26);
            this.txtNroDoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroDoc.MaxLength = 8;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(135, 20);
            this.txtNroDoc.TabIndex = 18;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(258, 53);
            this.lblBase10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(65, 13);
            this.lblBase10.TabIndex = 21;
            this.lblBase10.Text = "Dirección:";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(331, 26);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(394, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(666, 346);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 18;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(602, 346);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 19;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // autorizaTratamientoUsoDatosBindingSource
            // 
            this.autorizaTratamientoUsoDatosBindingSource.DataSource = typeof(GEN.ControlesBase.Model.AutorizaTratamientoUsoDatos);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(602, 346);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // conAutDatosBase1
            // 
            this.conAutDatosBase1.Location = new System.Drawing.Point(12, 93);
            this.conAutDatosBase1.Name = "conAutDatosBase1";
            this.conAutDatosBase1.Size = new System.Drawing.Size(788, 251);
            this.conAutDatosBase1.TabIndex = 24;
            this.conAutDatosBase1.ClicCargarDatos += new System.EventHandler(this.conAutDatosBase1_ClicCargarDatos);
            this.conAutDatosBase1.ClicEditarDatos += new System.EventHandler(this.conAutDatosBase1_ClicEditarDatos);
            // 
            // frmAutorizoUsoDatosCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 429);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.conAutDatosBase1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAutorizoUsoDatosCli";
            this.Text = "Autorización uso de datos del cliente";
            this.Load += new System.EventHandler(this.frmAutorizoUsoDatosCli_Load);
            this.Controls.SetChildIndex(this.conAutDatosBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autorizaTratamientoUsoDatosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BotonesBase.btnSalir btnSalir1;
        private grbBase grbBase3;
        public txtBase txtTelefono;
        public lblBase lblBase7;
        public lblBase lblBase13;
        public lblBase lblBase12;
        public txtBase txtDireccion;
        public txtBase txtNroDoc;
        public lblBase lblBase10;
        public txtBase txtNombre;
        private BotonesBase.btnGrabar btnGrabar1;
        private BotonesBase.btnNuevo btnNuevo1;
        private ttpToolTip ttpToolTip1;
        private System.Windows.Forms.BindingSource autorizaTratamientoUsoDatosBindingSource;
        private BotonesBase.btnImprimir btnImprimir;
        private conAutDatosBase conAutDatosBase1;
    }
}