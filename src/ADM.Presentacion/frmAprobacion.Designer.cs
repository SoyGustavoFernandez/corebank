namespace ADM.Presentacion
{
    partial class frmAprobacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacion));
            this.gbxAprobacionSolicitud = new System.Windows.Forms.GroupBox();
            this.dtgAprobacionSolicitud = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblComentario = new GEN.ControlesBase.lblBase();
            this.txtComentario = new GEN.ControlesBase.txtBase(this.components);
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.btnDenegar = new GEN.BotonesBase.btnDenegar();
            this.btnRevisar = new GEN.BotonesBase.btnRevisar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.gbxAprobacionSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobacionSolicitud)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAprobacionSolicitud
            // 
            this.gbxAprobacionSolicitud.Controls.Add(this.dtgAprobacionSolicitud);
            this.gbxAprobacionSolicitud.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxAprobacionSolicitud.Location = new System.Drawing.Point(0, 0);
            this.gbxAprobacionSolicitud.Name = "gbxAprobacionSolicitud";
            this.gbxAprobacionSolicitud.Size = new System.Drawing.Size(726, 309);
            this.gbxAprobacionSolicitud.TabIndex = 2;
            this.gbxAprobacionSolicitud.TabStop = false;
            this.gbxAprobacionSolicitud.Text = "Lista de Solicitudes de Aprobación";
            // 
            // dtgAprobacionSolicitud
            // 
            this.dtgAprobacionSolicitud.AllowUserToAddRows = false;
            this.dtgAprobacionSolicitud.AllowUserToDeleteRows = false;
            this.dtgAprobacionSolicitud.AllowUserToResizeColumns = false;
            this.dtgAprobacionSolicitud.AllowUserToResizeRows = false;
            this.dtgAprobacionSolicitud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAprobacionSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAprobacionSolicitud.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgAprobacionSolicitud.Location = new System.Drawing.Point(3, 16);
            this.dtgAprobacionSolicitud.MultiSelect = false;
            this.dtgAprobacionSolicitud.Name = "dtgAprobacionSolicitud";
            this.dtgAprobacionSolicitud.ReadOnly = true;
            this.dtgAprobacionSolicitud.RowHeadersVisible = false;
            this.dtgAprobacionSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAprobacionSolicitud.Size = new System.Drawing.Size(720, 286);
            this.dtgAprobacionSolicitud.TabIndex = 0;
            this.dtgAprobacionSolicitud.SelectionChanged += new System.EventHandler(this.dtgAprobacionSolicitud_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblComentario);
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Controls.Add(this.btnAprobar);
            this.groupBox1.Controls.Add(this.btnDenegar);
            this.groupBox1.Controls.Add(this.btnRevisar);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 87);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblComentario.ForeColor = System.Drawing.Color.Navy;
            this.lblComentario.Location = new System.Drawing.Point(72, 13);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(79, 13);
            this.lblComentario.TabIndex = 7;
            this.lblComentario.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(72, 32);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(455, 49);
            this.txtComentario.TabIndex = 6;
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Location = new System.Drawing.Point(533, 31);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 5;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar.BackgroundImage")));
            this.btnDenegar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar.Location = new System.Drawing.Point(599, 31);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar.TabIndex = 4;
            this.btnDenegar.Text = "&Denegar";
            this.btnDenegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // btnRevisar
            // 
            this.btnRevisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRevisar.BackgroundImage")));
            this.btnRevisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRevisar.Location = new System.Drawing.Point(6, 31);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(60, 50);
            this.btnRevisar.TabIndex = 3;
            this.btnRevisar.Text = "Revisar";
            this.btnRevisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevisar.UseVisualStyleBackColor = true;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(663, 31);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmAprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 420);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxAprobacionSolicitud);
            this.Name = "frmAprobacion";
            this.Text = "Aprobación General de Solicitudes";
            this.Shown += new System.EventHandler(this.frmAprobacion_Shown);
            this.Controls.SetChildIndex(this.gbxAprobacionSolicitud, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbxAprobacionSolicitud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobacionSolicitud)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAprobacionSolicitud;
        private GEN.ControlesBase.dtgBase dtgAprobacionSolicitud;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnRevisar btnRevisar;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.BotonesBase.btnDenegar btnDenegar;
        private GEN.ControlesBase.lblBase lblComentario;
        private GEN.ControlesBase.txtBase txtComentario;
    }
}