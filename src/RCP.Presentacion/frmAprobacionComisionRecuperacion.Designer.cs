namespace RCP.Presentacion
{
    partial class frmAprobacionComisionRecuperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionComisionRecuperacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtComentario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnDenegar = new GEN.BotonesBase.btnDenegar();
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.dtgAprobacionRecuperacionComision = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1.SuspendLayout();
            this.gbxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobacionRecuperacionComision)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtComentario);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.btnDenegar);
            this.panel1.Controls.Add(this.btnAprobar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.gbxDatos);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 260);
            this.panel1.TabIndex = 2;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(105, 204);
            this.txtComentario.MaxLength = 255;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(344, 52);
            this.txtComentario.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 224);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(87, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Comentario : ";
            // 
            // btnDenegar
            // 
            this.btnDenegar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar.BackgroundImage")));
            this.btnDenegar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar.Location = new System.Drawing.Point(532, 205);
            this.btnDenegar.Name = "btnDenegar";
            this.btnDenegar.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar.TabIndex = 3;
            this.btnDenegar.Text = "&Denegar";
            this.btnDenegar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar.UseVisualStyleBackColor = true;
            this.btnDenegar.Click += new System.EventHandler(this.btnDenegar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Location = new System.Drawing.Point(466, 205);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 2;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(657, 205);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.btnImprimir);
            this.gbxDatos.Controls.Add(this.dtgAprobacionRecuperacionComision);
            this.gbxDatos.Location = new System.Drawing.Point(3, 3);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(720, 198);
            this.gbxDatos.TabIndex = 0;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(654, 17);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Detalle";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dtgAprobacionRecuperacionComision
            // 
            this.dtgAprobacionRecuperacionComision.AllowUserToAddRows = false;
            this.dtgAprobacionRecuperacionComision.AllowUserToDeleteRows = false;
            this.dtgAprobacionRecuperacionComision.AllowUserToResizeColumns = false;
            this.dtgAprobacionRecuperacionComision.AllowUserToResizeRows = false;
            this.dtgAprobacionRecuperacionComision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAprobacionRecuperacionComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAprobacionRecuperacionComision.Location = new System.Drawing.Point(6, 19);
            this.dtgAprobacionRecuperacionComision.MultiSelect = false;
            this.dtgAprobacionRecuperacionComision.Name = "dtgAprobacionRecuperacionComision";
            this.dtgAprobacionRecuperacionComision.ReadOnly = true;
            this.dtgAprobacionRecuperacionComision.RowHeadersVisible = false;
            this.dtgAprobacionRecuperacionComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAprobacionRecuperacionComision.Size = new System.Drawing.Size(644, 170);
            this.dtgAprobacionRecuperacionComision.TabIndex = 0;
            this.dtgAprobacionRecuperacionComision.SelectionChanged += new System.EventHandler(this.dtgAprobacionRecuperacionComision_SelectionChanged);
            // 
            // frmAprobacionComisionRecuperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 283);
            this.Controls.Add(this.panel1);
            this.Name = "frmAprobacionComisionRecuperacion";
            this.Text = "Aprobación Comisión Recuperación";
            this.Shown += new System.EventHandler(this.frmAprobacionComisionRecuperacion_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAprobacionRecuperacionComision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.GroupBox gbxDatos;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.ControlesBase.dtgBase dtgAprobacionRecuperacionComision;
        private GEN.BotonesBase.btnDenegar btnDenegar;
        private GEN.ControlesBase.txtBase txtComentario;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
    }
}