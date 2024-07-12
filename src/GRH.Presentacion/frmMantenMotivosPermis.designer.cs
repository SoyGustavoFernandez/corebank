namespace GRH.Presentacion
{
    partial class frmMantenMotivosPermis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenMotivosPermis));
            this.CBLaborable = new GEN.ControlesBase.chcBase(this.components);
            this.CBPermisoRRHH = new GEN.ControlesBase.chcBase(this.components);
            this.CBJustificacion = new GEN.ControlesBase.chcBase(this.components);
            this.CBPermiso = new GEN.ControlesBase.chcBase(this.components);
            this.CBDescuento = new GEN.ControlesBase.chcBase(this.components);
            this.CBFalta = new GEN.ControlesBase.chcBase(this.components);
            this.dtgMotivos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNomMotivo = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMotivos)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBLaborable
            // 
            this.CBLaborable.AutoSize = true;
            this.CBLaborable.ForeColor = System.Drawing.Color.Navy;
            this.CBLaborable.Location = new System.Drawing.Point(37, 35);
            this.CBLaborable.Name = "CBLaborable";
            this.CBLaborable.Size = new System.Drawing.Size(122, 17);
            this.CBLaborable.TabIndex = 2;
            this.CBLaborable.Text = "Cont. Día Laborable";
            this.CBLaborable.UseVisualStyleBackColor = true;
            // 
            // CBPermisoRRHH
            // 
            this.CBPermisoRRHH.AutoSize = true;
            this.CBPermisoRRHH.ForeColor = System.Drawing.Color.Navy;
            this.CBPermisoRRHH.Location = new System.Drawing.Point(207, 81);
            this.CBPermisoRRHH.Name = "CBPermisoRRHH";
            this.CBPermisoRRHH.Size = new System.Drawing.Size(108, 17);
            this.CBPermisoRRHH.TabIndex = 3;
            this.CBPermisoRRHH.Text = "Motivo de RRHH";
            this.CBPermisoRRHH.UseVisualStyleBackColor = true;
            // 
            // CBJustificacion
            // 
            this.CBJustificacion.AutoSize = true;
            this.CBJustificacion.ForeColor = System.Drawing.Color.Navy;
            this.CBJustificacion.Location = new System.Drawing.Point(207, 58);
            this.CBJustificacion.Name = "CBJustificacion";
            this.CBJustificacion.Size = new System.Drawing.Size(134, 17);
            this.CBJustificacion.TabIndex = 4;
            this.CBJustificacion.Text = "Motivo de Justificación";
            this.CBJustificacion.UseVisualStyleBackColor = true;
            // 
            // CBPermiso
            // 
            this.CBPermiso.AutoSize = true;
            this.CBPermiso.ForeColor = System.Drawing.Color.Navy;
            this.CBPermiso.Location = new System.Drawing.Point(207, 35);
            this.CBPermiso.Name = "CBPermiso";
            this.CBPermiso.Size = new System.Drawing.Size(113, 17);
            this.CBPermiso.TabIndex = 5;
            this.CBPermiso.Text = "Motivo de Permiso";
            this.CBPermiso.UseVisualStyleBackColor = true;
            // 
            // CBDescuento
            // 
            this.CBDescuento.AutoSize = true;
            this.CBDescuento.ForeColor = System.Drawing.Color.Navy;
            this.CBDescuento.Location = new System.Drawing.Point(37, 81);
            this.CBDescuento.Name = "CBDescuento";
            this.CBDescuento.Size = new System.Drawing.Size(106, 17);
            this.CBDescuento.TabIndex = 6;
            this.CBDescuento.Text = "Cont. Descuento";
            this.CBDescuento.UseVisualStyleBackColor = true;
            // 
            // CBFalta
            // 
            this.CBFalta.AutoSize = true;
            this.CBFalta.ForeColor = System.Drawing.Color.Navy;
            this.CBFalta.Location = new System.Drawing.Point(37, 58);
            this.CBFalta.Name = "CBFalta";
            this.CBFalta.Size = new System.Drawing.Size(113, 17);
            this.CBFalta.TabIndex = 7;
            this.CBFalta.Text = "Cont. Día de Falta";
            this.CBFalta.UseVisualStyleBackColor = true;
            // 
            // dtgMotivos
            // 
            this.dtgMotivos.AllowUserToAddRows = false;
            this.dtgMotivos.AllowUserToDeleteRows = false;
            this.dtgMotivos.AllowUserToResizeColumns = false;
            this.dtgMotivos.AllowUserToResizeRows = false;
            this.dtgMotivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMotivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMotivos.Location = new System.Drawing.Point(27, 26);
            this.dtgMotivos.MultiSelect = false;
            this.dtgMotivos.Name = "dtgMotivos";
            this.dtgMotivos.ReadOnly = true;
            this.dtgMotivos.RowHeadersVisible = false;
            this.dtgMotivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMotivos.Size = new System.Drawing.Size(199, 232);
            this.dtgMotivos.TabIndex = 8;
            this.dtgMotivos.SelectionChanged += new System.EventHandler(this.dtgMotivos_SelectionChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(544, 208);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(244, 208);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(364, 208);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(304, 208);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.CBLaborable);
            this.grbBase1.Controls.Add(this.CBPermisoRRHH);
            this.grbBase1.Controls.Add(this.CBJustificacion);
            this.grbBase1.Controls.Add(this.CBPermiso);
            this.grbBase1.Controls.Add(this.CBDescuento);
            this.grbBase1.Controls.Add(this.CBFalta);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(244, 72);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(360, 119);
            this.grbBase1.TabIndex = 15;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Configuración de los Motivos";
            // 
            // txtNomMotivo
            // 
            this.txtNomMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomMotivo.Location = new System.Drawing.Point(383, 30);
            this.txtNomMotivo.MaxLength = 30;
            this.txtNomMotivo.Name = "txtNomMotivo";
            this.txtNomMotivo.Size = new System.Drawing.Size(221, 20);
            this.txtNomMotivo.TabIndex = 16;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(249, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(119, 13);
            this.lblBase1.TabIndex = 17;
            this.lblBase1.Text = "Nombre del Motivo:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(424, 208);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(484, 208);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 24;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmMantenMotivosPermis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 305);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtNomMotivo);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgMotivos);
            this.Name = "frmMantenMotivosPermis";
            this.Text = "Mantenimiento de Motivos de Permiso y Justificación";
            this.Load += new System.EventHandler(this.frmMantenMotivosPermis_Load);
            this.Controls.SetChildIndex(this.dtgMotivos, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.txtNomMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMotivos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.chcBase CBLaborable;
        private GEN.ControlesBase.chcBase CBPermisoRRHH;
        private GEN.ControlesBase.chcBase CBJustificacion;
        private GEN.ControlesBase.chcBase CBPermiso;
        private GEN.ControlesBase.chcBase CBDescuento;
        private GEN.ControlesBase.chcBase CBFalta;
        private GEN.ControlesBase.dtgBase dtgMotivos;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtCBLetra txtNomMotivo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}