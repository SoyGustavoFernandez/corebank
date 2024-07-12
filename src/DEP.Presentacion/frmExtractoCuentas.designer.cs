namespace DEP.Presentacion
{
    partial class frmExtractoCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtractoCuentas));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.dtFecInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFecFin = new System.Windows.Forms.DateTimePicker();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAhoExtr();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroImpresion = new GEN.ControlesBase.txtBase(this.components);
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.rbtFResumen = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtFDetallado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtFCorreo = new GEN.ControlesBase.rbtBase(this.components);
            this.conBusCtaAho.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(499, 158);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(373, 158);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 13;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // dtFecInicio
            // 
            this.dtFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecInicio.Location = new System.Drawing.Point(95, 12);
            this.dtFecInicio.Name = "dtFecInicio";
            this.dtFecInicio.Size = new System.Drawing.Size(126, 20);
            this.dtFecInicio.TabIndex = 16;
            // 
            // dtFecFin
            // 
            this.dtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecFin.Location = new System.Drawing.Point(95, 36);
            this.dtFecFin.Name = "dtFecFin";
            this.dtFecFin.Size = new System.Drawing.Size(126, 20);
            this.dtFecFin.TabIndex = 17;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 18;
            this.lblBase1.Text = "Desde:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 39);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 19;
            this.lblBase2.Text = "Hasta:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(436, 158);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Controls.Add(this.txtNombre);
            this.conBusCtaAho.Controls.Add(this.grbBase1);
            this.conBusCtaAho.Location = new System.Drawing.Point(0, 8);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(569, 114);
            this.conBusCtaAho.TabIndex = 24;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            this.conBusCtaAho.ChangeDocumentoID += new System.EventHandler(this.conBusCtaAho_ChangeDocumentoID);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(158, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(556, 112);
            this.grbBase1.TabIndex = 19;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 193);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(132, 13);
            this.lblBase4.TabIndex = 25;
            this.lblBase4.Text = "Numero de consultas:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.dtFecInicio);
            this.grbBase2.Controls.Add(this.dtFecFin);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(3, 121);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(229, 64);
            this.grbBase2.TabIndex = 26;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Periodo:";
            // 
            // txtNroImpresion
            // 
            this.txtNroImpresion.Location = new System.Drawing.Point(148, 190);
            this.txtNroImpresion.Name = "txtNroImpresion";
            this.txtNroImpresion.ReadOnly = true;
            this.txtNroImpresion.Size = new System.Drawing.Size(76, 20);
            this.txtNroImpresion.TabIndex = 27;
            this.txtNroImpresion.Text = "0";
            this.txtNroImpresion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(310, 158);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 28;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rbtFResumen
            // 
            this.rbtFResumen.AutoSize = true;
            this.rbtFResumen.ForeColor = System.Drawing.Color.Navy;
            this.rbtFResumen.Location = new System.Drawing.Point(236, 135);
            this.rbtFResumen.Name = "rbtFResumen";
            this.rbtFResumen.Size = new System.Drawing.Size(111, 17);
            this.rbtFResumen.TabIndex = 30;
            this.rbtFResumen.TabStop = true;
            this.rbtFResumen.Text = "Formato Resumen";
            this.rbtFResumen.UseVisualStyleBackColor = true;
            this.rbtFResumen.CheckedChanged += new System.EventHandler(this.rbtBase_CheckedChanged);
            // 
            // rbtFDetallado
            // 
            this.rbtFDetallado.AutoSize = true;
            this.rbtFDetallado.ForeColor = System.Drawing.Color.Navy;
            this.rbtFDetallado.Location = new System.Drawing.Point(353, 135);
            this.rbtFDetallado.Name = "rbtFDetallado";
            this.rbtFDetallado.Size = new System.Drawing.Size(111, 17);
            this.rbtFDetallado.TabIndex = 31;
            this.rbtFDetallado.TabStop = true;
            this.rbtFDetallado.Text = "Formato Detallado";
            this.rbtFDetallado.UseVisualStyleBackColor = true;
            this.rbtFDetallado.CheckedChanged += new System.EventHandler(this.rbtBase_CheckedChanged);
            // 
            // rbtFCorreo
            // 
            this.rbtFCorreo.AutoSize = true;
            this.rbtFCorreo.ForeColor = System.Drawing.Color.Navy;
            this.rbtFCorreo.Location = new System.Drawing.Point(470, 135);
            this.rbtFCorreo.Name = "rbtFCorreo";
            this.rbtFCorreo.Size = new System.Drawing.Size(97, 17);
            this.rbtFCorreo.TabIndex = 32;
            this.rbtFCorreo.TabStop = true;
            this.rbtFCorreo.Text = "Formato Correo";
            this.rbtFCorreo.UseVisualStyleBackColor = true;
            this.rbtFCorreo.CheckedChanged += new System.EventHandler(this.rbtBase_CheckedChanged);
            // 
            // frmExtractoCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 239);
            this.Controls.Add(this.rbtFCorreo);
            this.Controls.Add(this.rbtFDetallado);
            this.Controls.Add(this.rbtFResumen);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtNroImpresion);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmExtractoCuentas";
            this.Text = "Extracto de Cuentas";
            this.Load += new System.EventHandler(this.frmExtractoCuentas_Load);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.txtNroImpresion, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.rbtFResumen, 0);
            this.Controls.SetChildIndex(this.rbtFDetallado, 0);
            this.Controls.SetChildIndex(this.rbtFCorreo, 0);
            this.conBusCtaAho.ResumeLayout(false);
            this.conBusCtaAho.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private System.Windows.Forms.DateTimePicker dtFecInicio;
        private System.Windows.Forms.DateTimePicker dtFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.conBusCtaAhoExtr conBusCtaAho;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtNroImpresion;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.ControlesBase.rbtBase rbtFResumen;
        private GEN.ControlesBase.rbtBase rbtFDetallado;
        private GEN.ControlesBase.rbtBase rbtFCorreo;
    }
}