namespace CRE.Presentacion
{
    partial class frmExpedienteLineaCongelar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedienteLineaCongelar));
            this.grbDatosSolicitud = new GEN.ControlesBase.grbBase(this.components);
            this.txtSolicitud = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtAsesor = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipoCliente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtFechaSolicitud = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboGrupoExpediente1 = new GEN.ControlesBase.cboGrupoExpediente(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtGrupal = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtIndividual = new GEN.ControlesBase.rbtBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbDatosSolicitud.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosSolicitud
            // 
            this.grbDatosSolicitud.Controls.Add(this.txtSolicitud);
            this.grbDatosSolicitud.Controls.Add(this.lblBase6);
            this.grbDatosSolicitud.Controls.Add(this.txtAsesor);
            this.grbDatosSolicitud.Controls.Add(this.txtTipoCliente);
            this.grbDatosSolicitud.Controls.Add(this.lblBase5);
            this.grbDatosSolicitud.Controls.Add(this.lblBase1);
            this.grbDatosSolicitud.Controls.Add(this.txtFechaSolicitud);
            this.grbDatosSolicitud.Controls.Add(this.lblBase4);
            this.grbDatosSolicitud.Controls.Add(this.lblBase2);
            this.grbDatosSolicitud.Controls.Add(this.txtProducto);
            this.grbDatosSolicitud.Controls.Add(this.txtOperacion);
            this.grbDatosSolicitud.Controls.Add(this.lblBase3);
            this.grbDatosSolicitud.Location = new System.Drawing.Point(6, 58);
            this.grbDatosSolicitud.Name = "grbDatosSolicitud";
            this.grbDatosSolicitud.Size = new System.Drawing.Size(544, 112);
            this.grbDatosSolicitud.TabIndex = 3;
            this.grbDatosSolicitud.TabStop = false;
            this.grbDatosSolicitud.Text = "Datos de la Solicitud";
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Format = "n2";
            this.txtSolicitud.Location = new System.Drawing.Point(8, 33);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.Size = new System.Drawing.Size(145, 20);
            this.txtSolicitud.TabIndex = 1;
            this.txtSolicitud.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSolicitud_KeyPress);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(314, 64);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(93, 13);
            this.lblBase6.TabIndex = 62;
            this.lblBase6.Text = "Tipo de Cliente";
            // 
            // txtAsesor
            // 
            this.txtAsesor.Enabled = false;
            this.txtAsesor.Location = new System.Drawing.Point(317, 33);
            this.txtAsesor.Name = "txtAsesor";
            this.txtAsesor.Size = new System.Drawing.Size(219, 20);
            this.txtAsesor.TabIndex = 59;
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Enabled = false;
            this.txtTipoCliente.Location = new System.Drawing.Point(317, 80);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Size = new System.Drawing.Size(219, 20);
            this.txtTipoCliente.TabIndex = 61;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(314, 17);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(46, 13);
            this.lblBase5.TabIndex = 60;
            this.lblBase5.Text = "Asesor";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 52;
            this.lblBase1.Text = "Solicitud";
            // 
            // txtFechaSolicitud
            // 
            this.txtFechaSolicitud.Enabled = false;
            this.txtFechaSolicitud.Location = new System.Drawing.Point(8, 80);
            this.txtFechaSolicitud.Name = "txtFechaSolicitud";
            this.txtFechaSolicitud.Size = new System.Drawing.Size(145, 20);
            this.txtFechaSolicitud.TabIndex = 53;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(156, 64);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 58;
            this.lblBase4.Text = "Producto";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 64);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(92, 13);
            this.lblBase2.TabIndex = 54;
            this.lblBase2.Text = "Fecha Solicitud";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(159, 80);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(150, 20);
            this.txtProducto.TabIndex = 57;
            // 
            // txtOperacion
            // 
            this.txtOperacion.Enabled = false;
            this.txtOperacion.Location = new System.Drawing.Point(159, 33);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(150, 20);
            this.txtOperacion.TabIndex = 55;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(156, 17);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(65, 13);
            this.lblBase3.TabIndex = 56;
            this.lblBase3.Text = "Operación";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboGrupoExpediente1);
            this.grbBase1.Location = new System.Drawing.Point(8, 176);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(542, 51);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Grupo de Expediente:";
            // 
            // cboGrupoExpediente1
            // 
            this.cboGrupoExpediente1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoExpediente1.FormattingEnabled = true;
            this.cboGrupoExpediente1.Location = new System.Drawing.Point(6, 19);
            this.cboGrupoExpediente1.Name = "cboGrupoExpediente1";
            this.cboGrupoExpediente1.Size = new System.Drawing.Size(295, 21);
            this.cboGrupoExpediente1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtGrupal);
            this.panel1.Controls.Add(this.rbtIndividual);
            this.panel1.Location = new System.Drawing.Point(0, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 29);
            this.panel1.TabIndex = 0;
            // 
            // rbtGrupal
            // 
            this.rbtGrupal.AutoSize = true;
            this.rbtGrupal.ForeColor = System.Drawing.Color.Navy;
            this.rbtGrupal.Location = new System.Drawing.Point(157, 6);
            this.rbtGrupal.Name = "rbtGrupal";
            this.rbtGrupal.Size = new System.Drawing.Size(92, 17);
            this.rbtGrupal.TabIndex = 2;
            this.rbtGrupal.Text = "Crédito Grupal";
            this.rbtGrupal.UseVisualStyleBackColor = true;
            this.rbtGrupal.CheckedChanged += new System.EventHandler(this.rbtGrupal_CheckedChanged);
            // 
            // rbtIndividual
            // 
            this.rbtIndividual.AutoSize = true;
            this.rbtIndividual.Checked = true;
            this.rbtIndividual.ForeColor = System.Drawing.Color.Navy;
            this.rbtIndividual.Location = new System.Drawing.Point(6, 6);
            this.rbtIndividual.Name = "rbtIndividual";
            this.rbtIndividual.Size = new System.Drawing.Size(106, 17);
            this.rbtIndividual.TabIndex = 1;
            this.rbtIndividual.TabStop = true;
            this.rbtIndividual.Text = "Crédito Individual";
            this.rbtIndividual.UseVisualStyleBackColor = true;
            this.rbtIndividual.CheckedChanged += new System.EventHandler(this.rbtIndividual_CheckedChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(410, 233);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 5;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(476, 233);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(344, 233);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.panel1);
            this.grbBase2.Location = new System.Drawing.Point(8, 6);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(544, 46);
            this.grbBase2.TabIndex = 8;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Tipo de Crédito";
            // 
            // frmExpedienteLineaCongelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 309);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbDatosSolicitud);
            this.Name = "frmExpedienteLineaCongelar";
            this.Text = "Guardar Expedientes del Crédito";
            this.Load += new System.EventHandler(this.frmExpedienteLineaCongelar_Load);
            this.Controls.SetChildIndex(this.grbDatosSolicitud, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbDatosSolicitud.ResumeLayout(false);
            this.grbDatosSolicitud.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosSolicitud;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtAsesor;
        private GEN.ControlesBase.txtBase txtTipoCliente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtFechaSolicitud;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.txtBase txtOperacion;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboGrupoExpediente cboGrupoExpediente1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.rbtBase rbtIndividual;
        private GEN.ControlesBase.rbtBase rbtGrupal;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtNumerico txtSolicitud;
    }
}