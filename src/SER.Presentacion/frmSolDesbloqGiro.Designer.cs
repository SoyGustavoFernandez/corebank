namespace SER.Presentacion
{
    partial class frmSolDesbloqGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolDesbloqGiro));
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCargarArchivo = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.lblNombreArchivo = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbDetalleSolicitud = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstadoSolic = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.txtMotivoSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroGiro = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbDetalleSolicitud.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(412, 256);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(478, 256);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarArchivo.BackgroundImage")));
            this.btnCargarArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarArchivo.Location = new System.Drawing.Point(11, 256);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(60, 50);
            this.btnCargarArchivo.TabIndex = 1;
            this.btnCargarArchivo.Text = "Cargar Archivos";
            this.btnCargarArchivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreArchivo.Location = new System.Drawing.Point(77, 275);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(12, 13);
            this.lblNombreArchivo.TabIndex = 7;
            this.lblNombreArchivo.Text = "-";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(97, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Estado Solicitud";
            // 
            // grbDetalleSolicitud
            // 
            this.grbDetalleSolicitud.Controls.Add(this.lblBase1);
            this.grbDetalleSolicitud.Controls.Add(this.cboEstadoSolic);
            this.grbDetalleSolicitud.Controls.Add(this.lblBase2);
            this.grbDetalleSolicitud.Controls.Add(this.txtMotivoSolicitud);
            this.grbDetalleSolicitud.Location = new System.Drawing.Point(8, 38);
            this.grbDetalleSolicitud.Name = "grbDetalleSolicitud";
            this.grbDetalleSolicitud.Size = new System.Drawing.Size(530, 200);
            this.grbDetalleSolicitud.TabIndex = 0;
            this.grbDetalleSolicitud.TabStop = false;
            this.grbDetalleSolicitud.Text = "Detalle de Solicitud";
            // 
            // cboEstadoSolic
            // 
            this.cboEstadoSolic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolic.Enabled = false;
            this.cboEstadoSolic.FormattingEnabled = true;
            this.cboEstadoSolic.Location = new System.Drawing.Point(148, 19);
            this.cboEstadoSolic.Name = "cboEstadoSolic";
            this.cboEstadoSolic.Size = new System.Drawing.Size(148, 21);
            this.cboEstadoSolic.TabIndex = 1;
            // 
            // txtMotivoSolicitud
            // 
            this.txtMotivoSolicitud.Location = new System.Drawing.Point(6, 68);
            this.txtMotivoSolicitud.MaxLength = 500;
            this.txtMotivoSolicitud.Multiline = true;
            this.txtMotivoSolicitud.Name = "txtMotivoSolicitud";
            this.txtMotivoSolicitud.Size = new System.Drawing.Size(518, 126);
            this.txtMotivoSolicitud.TabIndex = 0;
            // 
            // txtNroGiro
            // 
            this.txtNroGiro.Enabled = false;
            this.txtNroGiro.Location = new System.Drawing.Point(156, 12);
            this.txtNroGiro.Name = "txtNroGiro";
            this.txtNroGiro.Size = new System.Drawing.Size(100, 20);
            this.txtNroGiro.TabIndex = 11;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(20, 16);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(64, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Nro. Giro:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(190, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Motivo de Desbloqueo de clave:";
            // 
            // frmSolDesbloqGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 342);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtNroGiro);
            this.Controls.Add(this.grbDetalleSolicitud);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEnviar);
            this.Name = "frmSolDesbloqGiro";
            this.Text = "Solicitud de Desbloqueo de Clave de Giro";
            this.Load += new System.EventHandler(this.frmSolDesbloqGiro_Load);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCargarArchivo, 0);
            this.Controls.SetChildIndex(this.lblNombreArchivo, 0);
            this.Controls.SetChildIndex(this.grbDetalleSolicitud, 0);
            this.Controls.SetChildIndex(this.txtNroGiro, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.grbDetalleSolicitud.ResumeLayout(false);
            this.grbDetalleSolicitud.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnAdjuntarFile btnCargarArchivo;
        private GEN.ControlesBase.lblBase lblNombreArchivo;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbDetalleSolicitud;
        private GEN.ControlesBase.txtBase txtMotivoSolicitud;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolic;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroGiro;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}