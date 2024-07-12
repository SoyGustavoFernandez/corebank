namespace CLI.Presentacion
{
    partial class frmMapGeolocalizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapGeolocalizacion));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.txtLatitud = new GEN.ControlesBase.txtBase(this.components);
            this.txtLongitud = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase92 = new GEN.ControlesBase.lblBase();
            this.lblBase91 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtIdGeo = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegistrar = new GEN.BotonesBase.Boton();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnActualizar1 = new GEN.BotonesBase.btnActualizar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(8, 10);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(985, 397);
            this.gMapControl1.TabIndex = 2;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // txtLatitud
            // 
            this.txtLatitud.Enabled = false;
            this.txtLatitud.Location = new System.Drawing.Point(82, 25);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(169, 20);
            this.txtLatitud.TabIndex = 3;
            // 
            // txtLongitud
            // 
            this.txtLongitud.Enabled = false;
            this.txtLongitud.Location = new System.Drawing.Point(82, 51);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(169, 20);
            this.txtLongitud.TabIndex = 4;
            // 
            // lblBase92
            // 
            this.lblBase92.AutoSize = true;
            this.lblBase92.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase92.ForeColor = System.Drawing.Color.Navy;
            this.lblBase92.Location = new System.Drawing.Point(16, 54);
            this.lblBase92.Name = "lblBase92";
            this.lblBase92.Size = new System.Drawing.Size(60, 13);
            this.lblBase92.TabIndex = 33;
            this.lblBase92.Text = "Longitud:";
            // 
            // lblBase91
            // 
            this.lblBase91.AutoSize = true;
            this.lblBase91.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase91.ForeColor = System.Drawing.Color.Navy;
            this.lblBase91.Location = new System.Drawing.Point(26, 28);
            this.lblBase91.Name = "lblBase91";
            this.lblBase91.Size = new System.Drawing.Size(50, 13);
            this.lblBase91.TabIndex = 32;
            this.lblBase91.Text = "Latitud:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(417, 413);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(576, 20);
            this.txtDireccion.TabIndex = 36;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(292, 416);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(119, 13);
            this.lblBase1.TabIndex = 37;
            this.lblBase1.Text = "Dirección domicilio:";
            // 
            // txtIdGeo
            // 
            this.txtIdGeo.Enabled = false;
            this.txtIdGeo.Location = new System.Drawing.Point(209, 25);
            this.txtIdGeo.Name = "txtIdGeo";
            this.txtIdGeo.Size = new System.Drawing.Size(42, 20);
            this.txtIdGeo.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase91);
            this.groupBox1.Controls.Add(this.txtLatitud);
            this.groupBox1.Controls.Add(this.txtLongitud);
            this.groupBox1.Controls.Add(this.lblBase92);
            this.groupBox1.Controls.Add(this.txtIdGeo);
            this.groupBox1.Location = new System.Drawing.Point(8, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 83);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Geolocalización";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackgroundImage = global::CLI.Presentacion.Properties.Resources.btnFileSave;
            this.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegistrar.Location = new System.Drawing.Point(811, 449);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(60, 50);
            this.btnRegistrar.TabIndex = 44;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(872, 449);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 45;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(54, 376);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 43;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(12, 376);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 42;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.BackgroundImage")));
            this.btnActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar1.Location = new System.Drawing.Point(750, 449);
            this.btnActualizar1.Name = "btnActualizar1";
            this.btnActualizar1.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar1.TabIndex = 40;
            this.btnActualizar1.Text = "Act&ualizar";
            this.btnActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar1.texto = "Act&ualizar";
            this.btnActualizar1.UseVisualStyleBackColor = true;
            this.btnActualizar1.Click += new System.EventHandler(this.btnActualizar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(933, 449);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 38;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmMapGeolocalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 531);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnMiniQuitar1);
            this.Controls.Add(this.btnMiniAgregar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnActualizar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.gMapControl1);
            this.Name = "frmMapGeolocalizacion";
            this.Text = "Mapa Geolocalización";
            this.Load += new System.EventHandler(this.frmMapGeolocalizacion_Load);
            this.Controls.SetChildIndex(this.gMapControl1, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnActualizar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar1, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar1, 0);
            this.Controls.SetChildIndex(this.btnRegistrar, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private GEN.ControlesBase.txtBase txtLatitud;
        private GEN.ControlesBase.txtBase txtLongitud;
        private GEN.ControlesBase.lblBase lblBase92;
        private GEN.ControlesBase.lblBase lblBase91;
        private GEN.ControlesBase.lblBase lblBase1;
        public GEN.ControlesBase.txtBase txtDireccion;
        private GEN.BotonesBase.btnSalir btnSalir1;
        public GEN.ControlesBase.txtBase txtIdGeo;
        public GEN.BotonesBase.btnActualizar btnActualizar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        public GEN.BotonesBase.Boton btnRegistrar;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
    }
}