namespace GRC.Presentacion
{
    partial class frmConsultaSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaSesion));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.cboTipoSesion1 = new GEN.ControlesBase.cboTipoSesion(this.components);
            this.dtpIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboTipoConsejo1 = new GEN.ControlesBase.cboTipoConsejo(this.components);
            this.dtgSesiones = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDocumentos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgAsistentes = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSesiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsistentes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(531, 439);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(339, 29);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 3;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(465, 439);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 5;
            this.btnImprimir1.Text = "Ver";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // cboTipoSesion1
            // 
            this.cboTipoSesion1.FormattingEnabled = true;
            this.cboTipoSesion1.Location = new System.Drawing.Point(106, 46);
            this.cboTipoSesion1.Name = "cboTipoSesion1";
            this.cboTipoSesion1.Size = new System.Drawing.Size(217, 21);
            this.cboTipoSesion1.TabIndex = 6;
            // 
            // dtpIni
            // 
            this.dtpIni.Location = new System.Drawing.Point(106, 19);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(96, 20);
            this.dtpIni.TabIndex = 7;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(226, 20);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(97, 20);
            this.dtpFin.TabIndex = 7;
            // 
            // cboTipoConsejo1
            // 
            this.cboTipoConsejo1.FormattingEnabled = true;
            this.cboTipoConsejo1.Location = new System.Drawing.Point(106, 71);
            this.cboTipoConsejo1.Name = "cboTipoConsejo1";
            this.cboTipoConsejo1.Size = new System.Drawing.Size(217, 21);
            this.cboTipoConsejo1.TabIndex = 8;
            // 
            // dtgSesiones
            // 
            this.dtgSesiones.AllowUserToAddRows = false;
            this.dtgSesiones.AllowUserToDeleteRows = false;
            this.dtgSesiones.AllowUserToResizeColumns = false;
            this.dtgSesiones.AllowUserToResizeRows = false;
            this.dtgSesiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSesiones.Location = new System.Drawing.Point(12, 144);
            this.dtgSesiones.MultiSelect = false;
            this.dtgSesiones.Name = "dtgSesiones";
            this.dtgSesiones.ReadOnly = true;
            this.dtgSesiones.RowHeadersVisible = false;
            this.dtgSesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSesiones.Size = new System.Drawing.Size(581, 116);
            this.dtgSesiones.TabIndex = 9;
            this.dtgSesiones.SelectionChanged += new System.EventHandler(this.dtgSesisones_SelectionChanged);
            // 
            // dtgDocumentos
            // 
            this.dtgDocumentos.AllowUserToAddRows = false;
            this.dtgDocumentos.AllowUserToDeleteRows = false;
            this.dtgDocumentos.AllowUserToResizeColumns = false;
            this.dtgDocumentos.AllowUserToResizeRows = false;
            this.dtgDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentos.Location = new System.Drawing.Point(323, 292);
            this.dtgDocumentos.MultiSelect = false;
            this.dtgDocumentos.Name = "dtgDocumentos";
            this.dtgDocumentos.ReadOnly = true;
            this.dtgDocumentos.RowHeadersVisible = false;
            this.dtgDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentos.Size = new System.Drawing.Size(268, 131);
            this.dtgDocumentos.TabIndex = 10;
            this.dtgDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentos_CellClick);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 11;
            this.lblBase1.Text = "Registrado del:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboTipoConsejo1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnBusqueda1);
            this.grbBase1.Controls.Add(this.dtpIni);
            this.grbBase1.Controls.Add(this.dtpFin);
            this.grbBase1.Controls.Add(this.cboTipoSesion1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(405, 99);
            this.grbBase1.TabIndex = 12;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 46);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(94, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Tipo de sesión:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(203, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(23, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Al:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 74);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(102, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Tipo de consejo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(320, 276);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(83, 13);
            this.lblBase5.TabIndex = 15;
            this.lblBase5.Text = "Documentos:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(14, 128);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(63, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Sesiones:";
            // 
            // dtgAsistentes
            // 
            this.dtgAsistentes.AllowUserToAddRows = false;
            this.dtgAsistentes.AllowUserToDeleteRows = false;
            this.dtgAsistentes.AllowUserToResizeColumns = false;
            this.dtgAsistentes.AllowUserToResizeRows = false;
            this.dtgAsistentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAsistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAsistentes.Location = new System.Drawing.Point(12, 292);
            this.dtgAsistentes.MultiSelect = false;
            this.dtgAsistentes.Name = "dtgAsistentes";
            this.dtgAsistentes.ReadOnly = true;
            this.dtgAsistentes.RowHeadersVisible = false;
            this.dtgAsistentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAsistentes.Size = new System.Drawing.Size(290, 131);
            this.dtgAsistentes.TabIndex = 17;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 276);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(70, 13);
            this.lblBase7.TabIndex = 18;
            this.lblBase7.Text = "Asistentes:";
            // 
            // frmConsultaSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 524);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.dtgAsistentes);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgDocumentos);
            this.Controls.Add(this.dtgSesiones);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmConsultaSesion";
            this.Text = "Consulta de Sesión Realizada";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.dtgSesiones, 0);
            this.Controls.SetChildIndex(this.dtgDocumentos, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.dtgAsistentes, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSesiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentos)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsistentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.cboTipoSesion cboTipoSesion1;
        private GEN.ControlesBase.dtpCorto dtpIni;
        private GEN.ControlesBase.dtpCorto dtpFin;
        private GEN.ControlesBase.cboTipoConsejo cboTipoConsejo1;
        private GEN.ControlesBase.dtgBase dtgSesiones;
        private GEN.ControlesBase.dtgBase dtgDocumentos;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtgBase dtgAsistentes;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}

