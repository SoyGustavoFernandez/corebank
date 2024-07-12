namespace CRE.Presentacion
{
    partial class frmExpedienteGrupoSolidario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedienteGrupoSolidario));
            this.dtgIntegrantes = new GEN.ControlesBase.dtgBase(this.components);
            this.pnlIntegrantes = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnConsultarReniec = new System.Windows.Forms.Button();
            this.btnCongelarPosicion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            this.pnlIntegrantes.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgIntegrantes
            // 
            this.dtgIntegrantes.AllowUserToAddRows = false;
            this.dtgIntegrantes.AllowUserToDeleteRows = false;
            this.dtgIntegrantes.AllowUserToResizeColumns = false;
            this.dtgIntegrantes.AllowUserToResizeRows = false;
            this.dtgIntegrantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantes.Location = new System.Drawing.Point(9, 3);
            this.dtgIntegrantes.MultiSelect = false;
            this.dtgIntegrantes.Name = "dtgIntegrantes";
            this.dtgIntegrantes.ReadOnly = true;
            this.dtgIntegrantes.RowHeadersVisible = false;
            this.dtgIntegrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantes.Size = new System.Drawing.Size(668, 141);
            this.dtgIntegrantes.TabIndex = 2;
            this.dtgIntegrantes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIntegrantes_CellDoubleClick);
            // 
            // pnlIntegrantes
            // 
            this.pnlIntegrantes.AutoSize = true;
            this.pnlIntegrantes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlIntegrantes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlIntegrantes.Controls.Add(this.dtgIntegrantes);
            this.pnlIntegrantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIntegrantes.Location = new System.Drawing.Point(3, 64);
            this.pnlIntegrantes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlIntegrantes.Name = "pnlIntegrantes";
            this.pnlIntegrantes.Size = new System.Drawing.Size(680, 147);
            this.pnlIntegrantes.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.pnlAcciones);
            this.flowLayoutPanel1.Controls.Add(this.pnlIntegrantes);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(689, 273);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.lblBase2);
            this.pnlAcciones.Controls.Add(this.lblBase1);
            this.pnlAcciones.Controls.Add(this.btnConsultarReniec);
            this.pnlAcciones.Controls.Add(this.btnCongelarPosicion);
            this.pnlAcciones.Location = new System.Drawing.Point(3, 3);
            this.pnlAcciones.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(677, 61);
            this.pnlAcciones.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(492, 1);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(85, 30);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Guardar Posición Intg.";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBase1
            // 
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(388, 1);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(97, 30);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Consultar a Reniec";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConsultarReniec
            // 
            this.btnConsultarReniec.BackgroundImage = global::CRE.Presentacion.Properties.Resources.reniec_logo;
            this.btnConsultarReniec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConsultarReniec.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConsultarReniec.Location = new System.Drawing.Point(388, 31);
            this.btnConsultarReniec.Name = "btnConsultarReniec";
            this.btnConsultarReniec.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultarReniec.Size = new System.Drawing.Size(97, 30);
            this.btnConsultarReniec.TabIndex = 1;
            this.btnConsultarReniec.Text = "Consultar";
            this.btnConsultarReniec.UseVisualStyleBackColor = true;
            this.btnConsultarReniec.Click += new System.EventHandler(this.btnConsultarReniec_Click);
            // 
            // btnCongelarPosicion
            // 
            this.btnCongelarPosicion.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnFileSave;
            this.btnCongelarPosicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCongelarPosicion.Location = new System.Drawing.Point(484, 31);
            this.btnCongelarPosicion.Name = "btnCongelarPosicion";
            this.btnCongelarPosicion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCongelarPosicion.Size = new System.Drawing.Size(97, 30);
            this.btnCongelarPosicion.TabIndex = 2;
            this.btnCongelarPosicion.Text = "Guardar";
            this.btnCongelarPosicion.UseVisualStyleBackColor = true;
            this.btnCongelarPosicion.Click += new System.EventHandler(this.btnCongelarPosicion_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btnSalir1);
            this.panel2.Location = new System.Drawing.Point(3, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 51);
            this.panel2.TabIndex = 6;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(617, 0);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 0;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // frmExpedienteGrupoSolidario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ClientSize = new System.Drawing.Size(689, 295);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmExpedienteGrupoSolidario";
            this.Text = "Expediente de Grupo Solidario";
            this.Load += new System.EventHandler(this.frmExpedienteGrupoSolidario_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).EndInit();
            this.pnlIntegrantes.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgIntegrantes;
        private System.Windows.Forms.Panel pnlIntegrantes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.Button btnConsultarReniec;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnCongelarPosicion;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;

    }
}