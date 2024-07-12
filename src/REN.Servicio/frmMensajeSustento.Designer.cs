namespace CLI.Servicio
{
    partial class frmMensajeSustento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMensajeSustento));
            this.lblDocumento = new System.Windows.Forms.Label();
            this.flpRevision = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExporPdf1 = new System.Windows.Forms.Button();
            this.btnImagen = new GEN.BotonesBase.btnBlanco();
            this.pnlRevisionSustento = new System.Windows.Forms.Panel();
            this.grbSustentoSolicitud = new System.Windows.Forms.GroupBox();
            this.lblBase2 = new System.Windows.Forms.Label();
            this.lblBase1 = new System.Windows.Forms.Label();
            this.txtSustento = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grbVerificacionPersonal = new System.Windows.Forms.GroupBox();
            this.btnMiniQuitarPersonal = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregarPersonal = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgPersonalAprobacion = new System.Windows.Forms.DataGridView();
            this.chcDerivacionDirecta = new System.Windows.Forms.CheckBox();
            this.btnConsultaReniec = new GEN.BotonesBase.btnBlanco();
            this.btnCargarImagen = new GEN.BotonesBase.btnBlanco();
            this.btnCargarFile1 = new System.Windows.Forms.Button();
            this.btnCancelar1 = new System.Windows.Forms.Button();
            this.btnAceptar1 = new System.Windows.Forms.Button();
            this.flpRevision.SuspendLayout();
            this.pnlRevisionSustento.SuspendLayout();
            this.grbSustentoSolicitud.SuspendLayout();
            this.grbVerificacionPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersonalAprobacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Italic);
            this.lblDocumento.ForeColor = System.Drawing.Color.Navy;
            this.lblDocumento.Location = new System.Drawing.Point(10, 313);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(0, 13);
            this.lblDocumento.TabIndex = 9;
            // 
            // flpRevision
            // 
            this.flpRevision.Controls.Add(this.btnExporPdf1);
            this.flpRevision.Controls.Add(this.btnImagen);
            this.flpRevision.Location = new System.Drawing.Point(1, 1);
            this.flpRevision.Name = "flpRevision";
            this.flpRevision.Size = new System.Drawing.Size(124, 52);
            this.flpRevision.TabIndex = 18;
            // 
            // btnExporPdf1
            // 
            this.btnExporPdf1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporPdf1.BackgroundImage")));
            this.btnExporPdf1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporPdf1.Location = new System.Drawing.Point(1, 1);
            this.btnExporPdf1.Margin = new System.Windows.Forms.Padding(1);
            this.btnExporPdf1.Name = "btnExporPdf1";
            this.btnExporPdf1.Size = new System.Drawing.Size(60, 50);
            this.btnExporPdf1.TabIndex = 10;
            this.btnExporPdf1.Text = "P&df";
            this.btnExporPdf1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporPdf1.UseVisualStyleBackColor = true;
            this.btnExporPdf1.Click += new System.EventHandler(this.btnExporPdf1_Click);
            // 
            // btnImagen
            // 
            this.btnImagen.BackgroundImage = global::REN.Servicio.Properties.Resources.buscar;
            this.btnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImagen.Location = new System.Drawing.Point(63, 1);
            this.btnImagen.Margin = new System.Windows.Forms.Padding(1);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(60, 50);
            this.btnImagen.TabIndex = 17;
            this.btnImagen.Text = "Imagen";
            this.btnImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Visible = false;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // pnlRevisionSustento
            // 
            this.pnlRevisionSustento.Controls.Add(this.flpRevision);
            this.pnlRevisionSustento.Location = new System.Drawing.Point(201, 329);
            this.pnlRevisionSustento.Name = "pnlRevisionSustento";
            this.pnlRevisionSustento.Size = new System.Drawing.Size(126, 54);
            this.pnlRevisionSustento.TabIndex = 19;
            // 
            // grbSustentoSolicitud
            // 
            this.grbSustentoSolicitud.Controls.Add(this.lblBase2);
            this.grbSustentoSolicitud.Controls.Add(this.lblBase1);
            this.grbSustentoSolicitud.Controls.Add(this.txtSustento);
            this.grbSustentoSolicitud.Controls.Add(this.comboBox1);
            this.grbSustentoSolicitud.Location = new System.Drawing.Point(7, 33);
            this.grbSustentoSolicitud.Name = "grbSustentoSolicitud";
            this.grbSustentoSolicitud.Size = new System.Drawing.Size(470, 148);
            this.grbSustentoSolicitud.TabIndex = 15;
            this.grbSustentoSolicitud.TabStop = false;
            this.grbSustentoSolicitud.Text = "Sustento";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(123, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Motivo de Excepción";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 54);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(370, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Sustento para solicitar la excepción de identificación biometrica";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(10, 69);
            this.txtSustento.MaxLength = 375;
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(450, 71);
            this.txtSustento.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(450, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // grbVerificacionPersonal
            // 
            this.grbVerificacionPersonal.Controls.Add(this.btnMiniQuitarPersonal);
            this.grbVerificacionPersonal.Controls.Add(this.btnMiniAgregarPersonal);
            this.grbVerificacionPersonal.Controls.Add(this.dtgPersonalAprobacion);
            this.grbVerificacionPersonal.Location = new System.Drawing.Point(7, 184);
            this.grbVerificacionPersonal.Name = "grbVerificacionPersonal";
            this.grbVerificacionPersonal.Size = new System.Drawing.Size(470, 116);
            this.grbVerificacionPersonal.TabIndex = 14;
            this.grbVerificacionPersonal.TabStop = false;
            this.grbVerificacionPersonal.Text = "Verificacion de Personal";
            // 
            // btnMiniQuitarPersonal
            // 
            this.btnMiniQuitarPersonal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitarPersonal.BackgroundImage")));
            this.btnMiniQuitarPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitarPersonal.Location = new System.Drawing.Point(427, 47);
            this.btnMiniQuitarPersonal.Name = "btnMiniQuitarPersonal";
            this.btnMiniQuitarPersonal.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitarPersonal.TabIndex = 15;
            this.btnMiniQuitarPersonal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitarPersonal.UseVisualStyleBackColor = true;
            this.btnMiniQuitarPersonal.Click += new System.EventHandler(this.btnMiniQuitarPersonal_Click);
            // 
            // btnMiniAgregarPersonal
            // 
            this.btnMiniAgregarPersonal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarPersonal.BackgroundImage")));
            this.btnMiniAgregarPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarPersonal.Location = new System.Drawing.Point(427, 19);
            this.btnMiniAgregarPersonal.Name = "btnMiniAgregarPersonal";
            this.btnMiniAgregarPersonal.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarPersonal.TabIndex = 14;
            this.btnMiniAgregarPersonal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarPersonal.UseVisualStyleBackColor = true;
            this.btnMiniAgregarPersonal.Click += new System.EventHandler(this.btnMiniAgregarPersonal_Click);
            // 
            // dtgPersonalAprobacion
            // 
            this.dtgPersonalAprobacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPersonalAprobacion.Location = new System.Drawing.Point(7, 19);
            this.dtgPersonalAprobacion.Name = "dtgPersonalAprobacion";
            this.dtgPersonalAprobacion.Size = new System.Drawing.Size(420, 91);
            this.dtgPersonalAprobacion.TabIndex = 13;
            // 
            // chcDerivacionDirecta
            // 
            this.chcDerivacionDirecta.AutoSize = true;
            this.chcDerivacionDirecta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcDerivacionDirecta.ForeColor = System.Drawing.Color.Navy;
            this.chcDerivacionDirecta.Location = new System.Drawing.Point(282, 10);
            this.chcDerivacionDirecta.Name = "chcDerivacionDirecta";
            this.chcDerivacionDirecta.Size = new System.Drawing.Size(193, 17);
            this.chcDerivacionDirecta.TabIndex = 12;
            this.chcDerivacionDirecta.Text = "Aprobación de Nivel Superior";
            this.chcDerivacionDirecta.UseVisualStyleBackColor = true;
            this.chcDerivacionDirecta.CheckedChanged += new System.EventHandler(this.chcDerivacionDirecta_CheckedChanged);
            // 
            // btnConsultaReniec
            // 
            this.btnConsultaReniec.BackgroundImage = global::REN.Servicio.Properties.Resources.reniec;
            this.btnConsultaReniec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultaReniec.Location = new System.Drawing.Point(130, 331);
            this.btnConsultaReniec.Name = "btnConsultaReniec";
            this.btnConsultaReniec.Size = new System.Drawing.Size(60, 50);
            this.btnConsultaReniec.TabIndex = 20;
            this.btnConsultaReniec.Text = "Consulta RENIEC";
            this.btnConsultaReniec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultaReniec.UseVisualStyleBackColor = true;
            this.btnConsultaReniec.Click += new System.EventHandler(this.btnConsultaReniec_Click);
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.BackgroundImage = global::REN.Servicio.Properties.Resources.mapa;
            this.btnCargarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarImagen.Location = new System.Drawing.Point(10, 331);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(60, 50);
            this.btnCargarImagen.TabIndex = 11;
            this.btnCargarImagen.Text = "Subir Imagen";
            this.btnCargarImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // btnCargarFile1
            // 
            this.btnCargarFile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarFile1.BackgroundImage")));
            this.btnCargarFile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarFile1.Location = new System.Drawing.Point(70, 331);
            this.btnCargarFile1.Name = "btnCargarFile1";
            this.btnCargarFile1.Size = new System.Drawing.Size(60, 50);
            this.btnCargarFile1.TabIndex = 7;
            this.btnCargarFile1.Text = "Subir Archivo";
            this.btnCargarFile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarFile1.UseVisualStyleBackColor = true;
            this.btnCargarFile1.Click += new System.EventHandler(this.btnCargarFile1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(415, 331);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(355, 331);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmMensajeSustento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 389);
            this.ControlBox = false;
            this.Controls.Add(this.btnConsultaReniec);
            this.Controls.Add(this.pnlRevisionSustento);
            this.Controls.Add(this.grbSustentoSolicitud);
            this.Controls.Add(this.grbVerificacionPersonal);
            this.Controls.Add(this.chcDerivacionDirecta);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.btnCargarFile1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Name = "frmMensajeSustento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sustento";
            this.Load += new System.EventHandler(this.frmMensajeSustento_Load);
            this.flpRevision.ResumeLayout(false);
            this.pnlRevisionSustento.ResumeLayout(false);
            this.grbSustentoSolicitud.ResumeLayout(false);
            this.grbSustentoSolicitud.PerformLayout();
            this.grbVerificacionPersonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersonalAprobacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBase1;
        private System.Windows.Forms.TextBox txtSustento;
        private System.Windows.Forms.Button btnAceptar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblBase2;
        private System.Windows.Forms.Button btnCancelar1;
        private System.Windows.Forms.Button btnCargarFile1;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Button btnExporPdf1;
        private GEN.BotonesBase.btnBlanco btnCargarImagen;
        private System.Windows.Forms.CheckBox chcDerivacionDirecta;
        private System.Windows.Forms.DataGridView dtgPersonalAprobacion;
        private System.Windows.Forms.GroupBox grbVerificacionPersonal;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitarPersonal;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarPersonal;
        private System.Windows.Forms.GroupBox grbSustentoSolicitud;
        private GEN.BotonesBase.btnBlanco btnImagen;
        private System.Windows.Forms.FlowLayoutPanel flpRevision;
        private System.Windows.Forms.Panel pnlRevisionSustento;
        private GEN.BotonesBase.btnBlanco btnConsultaReniec;
    }
}