namespace RCP.Presentacion
{
    partial class frmRegistrarPlanillaMovilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarPlanillaMovilidad));
            this.conBuscarColaborador = new GEN.ControlesBase.ConBusCol();
            this.dtgPlanillaMovilidadDetalle = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstadoSolicitud = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaResolucion = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblFechaResolucion = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnListaAprobado = new GEN.BotonesBase.Boton();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnRechazar = new GEN.BotonesBase.btnRechazar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillaMovilidadDetalle)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBuscarColaborador
            // 
            this.conBuscarColaborador.cEstado = "0";
            this.conBuscarColaborador.Location = new System.Drawing.Point(12, 12);
            this.conBuscarColaborador.Name = "conBuscarColaborador";
            this.conBuscarColaborador.Size = new System.Drawing.Size(390, 86);
            this.conBuscarColaborador.TabIndex = 11;
            this.conBuscarColaborador.BuscarUsuario += new System.EventHandler(this.conBuscarColaborador_BuscarUsuario);
            // 
            // dtgPlanillaMovilidadDetalle
            // 
            this.dtgPlanillaMovilidadDetalle.AllowUserToAddRows = false;
            this.dtgPlanillaMovilidadDetalle.AllowUserToDeleteRows = false;
            this.dtgPlanillaMovilidadDetalle.AllowUserToResizeColumns = false;
            this.dtgPlanillaMovilidadDetalle.AllowUserToResizeRows = false;
            this.dtgPlanillaMovilidadDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanillaMovilidadDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillaMovilidadDetalle.Location = new System.Drawing.Point(2, 19);
            this.dtgPlanillaMovilidadDetalle.MultiSelect = false;
            this.dtgPlanillaMovilidadDetalle.Name = "dtgPlanillaMovilidadDetalle";
            this.dtgPlanillaMovilidadDetalle.ReadOnly = true;
            this.dtgPlanillaMovilidadDetalle.RowHeadersVisible = false;
            this.dtgPlanillaMovilidadDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillaMovilidadDetalle.Size = new System.Drawing.Size(720, 276);
            this.dtgPlanillaMovilidadDetalle.TabIndex = 0;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboEstadoSolicitud);
            this.grbBase2.Controls.Add(this.dtpFechaFin);
            this.grbBase2.Controls.Add(this.dtpFechaInicio);
            this.grbBase2.Controls.Add(this.dtpFechaResolucion);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblFechaResolucion);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Location = new System.Drawing.Point(494, 5);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(243, 120);
            this.grbBase2.TabIndex = 14;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Estado - Planilla Movilidad";
            // 
            // cboEstadoSolicitud
            // 
            this.cboEstadoSolicitud.FormattingEnabled = true;
            this.cboEstadoSolicitud.Location = new System.Drawing.Point(116, 13);
            this.cboEstadoSolicitud.Name = "cboEstadoSolicitud";
            this.cboEstadoSolicitud.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoSolicitud.TabIndex = 26;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(116, 58);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaFin.TabIndex = 25;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(116, 36);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaInicio.TabIndex = 24;
            // 
            // dtpFechaResolucion
            // 
            this.dtpFechaResolucion.Location = new System.Drawing.Point(116, 80);
            this.dtpFechaResolucion.Name = "dtpFechaResolucion";
            this.dtpFechaResolucion.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaResolucion.TabIndex = 23;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 17);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 22;
            this.lblBase4.Text = "Estado:";
            // 
            // lblFechaResolucion
            // 
            this.lblFechaResolucion.AutoSize = true;
            this.lblFechaResolucion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaResolucion.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaResolucion.Location = new System.Drawing.Point(6, 84);
            this.lblFechaResolucion.Name = "lblFechaResolucion";
            this.lblFechaResolucion.Size = new System.Drawing.Size(110, 13);
            this.lblFechaResolucion.TabIndex = 19;
            this.lblFechaResolucion.Text = "Fecha Resolución:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 62);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 20;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 40);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(75, 13);
            this.lblBase3.TabIndex = 21;
            this.lblBase3.Text = "Fecha incio:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(680, 422);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(620, 422);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(500, 422);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(560, 422);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnListaAprobado
            // 
            this.btnListaAprobado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaAprobado.BackgroundImage")));
            this.btnListaAprobado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListaAprobado.Location = new System.Drawing.Point(408, 32);
            this.btnListaAprobado.Name = "btnListaAprobado";
            this.btnListaAprobado.Size = new System.Drawing.Size(60, 50);
            this.btnListaAprobado.TabIndex = 6;
            this.btnListaAprobado.Text = "Lista";
            this.btnListaAprobado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaAprobado.UseVisualStyleBackColor = true;
            this.btnListaAprobado.Click += new System.EventHandler(this.btnListaAprobado_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(440, 422);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(12, 422);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Location = new System.Drawing.Point(72, 422);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 2;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgPlanillaMovilidadDetalle);
            this.grbBase1.Location = new System.Drawing.Point(12, 115);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(725, 301);
            this.grbBase1.TabIndex = 15;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Resumen de Actividad";
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazar.BackgroundImage")));
            this.btnRechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar.Location = new System.Drawing.Point(132, 422);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar.TabIndex = 16;
            this.btnRechazar.Text = "&Rechaza";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // frmRegistrarPlanillaMovilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 519);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.conBuscarColaborador);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnListaAprobado);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAprobar);
            this.Name = "frmRegistrarPlanillaMovilidad";
            this.Text = "Registro de Planilla de Movilidad";
            this.Load += new System.EventHandler(this.frmRegistroPlanillaMovilidad_Load);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnListaAprobado, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conBuscarColaborador, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnRechazar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillaMovilidadDetalle)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.Boton btnListaAprobado;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.ControlesBase.ConBusCol conBuscarColaborador;
        private GEN.ControlesBase.dtgBase dtgPlanillaMovilidadDetalle;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblFechaResolucion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpFechaResolucion;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolicitud;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnRechazar btnRechazar;
    }
}