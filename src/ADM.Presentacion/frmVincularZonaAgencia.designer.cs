namespace ADM.Presentacion
{
    partial class frmVincularZonaAgencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincularZonaAgencia));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.lstAgencias = new GEN.ControlesBase.lstBase(this.components);
            this.lstZonaAge = new GEN.ControlesBase.lstBase(this.components);
            this.cboZona = new GEN.ControlesBase.cboBase(this.components);
            this.btnAgregar = new GEN.BotonesBase.btnMiniPasarDerecha();
            this.btnQuitar = new GEN.BotonesBase.btnMiniPasarIzquierda();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.ttpMensaje = new GEN.ControlesBase.ttpToolTip();
            this.pbxAyuda1 = new GEN.ControlesBase.pbxAyuda();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(452, 264);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(387, 264);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(321, 264);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(255, 264);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 6;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // lstAgencias
            // 
            this.lstAgencias.Enabled = false;
            this.lstAgencias.FormattingEnabled = true;
            this.lstAgencias.Location = new System.Drawing.Point(14, 37);
            this.lstAgencias.Name = "lstAgencias";
            this.lstAgencias.Size = new System.Drawing.Size(225, 212);
            this.lstAgencias.TabIndex = 8;
            // 
            // lstZonaAge
            // 
            this.lstZonaAge.Enabled = false;
            this.lstZonaAge.FormattingEnabled = true;
            this.lstZonaAge.Location = new System.Drawing.Point(287, 37);
            this.lstZonaAge.Name = "lstZonaAge";
            this.lstZonaAge.Size = new System.Drawing.Size(225, 212);
            this.lstZonaAge.TabIndex = 8;
            // 
            // cboZona
            // 
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(287, 10);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(179, 21);
            this.cboZona.TabIndex = 9;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(245, 110);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(245, 144);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 18);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(164, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Agencias sin zona asignada";
            // 
            // pbxAyuda1
            // 
            this.pbxAyuda1.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda1.Image")));
            this.pbxAyuda1.Location = new System.Drawing.Point(491, 10);
            this.pbxAyuda1.Name = "pbxAyuda1";
            this.pbxAyuda1.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda1.TabIndex = 13;
            this.pbxAyuda1.TabStop = false;
            this.ttpMensaje.SetToolTip(this.pbxAyuda1, "Arraste la agencia para asignar o \r\nutilice los botones para quitar o asignar\r\nal" +
        " momento de editar");
            // 
            // frmVincularZonaAgencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 346);
            this.Controls.Add(this.pbxAyuda1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboZona);
            this.Controls.Add(this.lstZonaAge);
            this.Controls.Add(this.lstAgencias);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmVincularZonaAgencia";
            this.Text = "Vincular Región-Zona con Oficinas";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.lstAgencias, 0);
            this.Controls.SetChildIndex(this.lstZonaAge, 0);
            this.Controls.SetChildIndex(this.cboZona, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.pbxAyuda1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.lstBase lstAgencias;
        private GEN.ControlesBase.lstBase lstZonaAge;
        private GEN.ControlesBase.cboBase cboZona;
        private GEN.BotonesBase.btnMiniPasarDerecha btnAgregar;
        private GEN.BotonesBase.btnMiniPasarIzquierda btnQuitar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.ttpToolTip ttpMensaje;
        private GEN.ControlesBase.pbxAyuda pbxAyuda1;
    }
}

