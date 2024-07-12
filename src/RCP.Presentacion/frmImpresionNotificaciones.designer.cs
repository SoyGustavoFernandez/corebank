namespace RCP.Presentacion
{
    partial class frmImpresionNotificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresionNotificaciones));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKilometrajeInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtEstadoHojaRuta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase24 = new GEN.ControlesBase.lblBase();
            this.txtTotalCreditos = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.DatePicker();
            this.dtpFechaInicio = new GEN.ControlesBase.DatePicker();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgNotificaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.chcImpDir = new GEN.ControlesBase.chcBase(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKilometrajeInicio);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.txtEstadoHojaRuta);
            this.groupBox1.Controls.Add(this.lblBase24);
            this.groupBox1.Controls.Add(this.txtTotalCreditos);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales de la Hoja de Ruta";
            // 
            // txtKilometrajeInicio
            // 
            this.txtKilometrajeInicio.Enabled = false;
            this.txtKilometrajeInicio.Location = new System.Drawing.Point(130, 50);
            this.txtKilometrajeInicio.Name = "txtKilometrajeInicio";
            this.txtKilometrajeInicio.Size = new System.Drawing.Size(101, 20);
            this.txtKilometrajeInicio.TabIndex = 20;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 53);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(111, 13);
            this.lblBase5.TabIndex = 19;
            this.lblBase5.Text = "Kilometraje inicio:";
            // 
            // txtEstadoHojaRuta
            // 
            this.txtEstadoHojaRuta.Enabled = false;
            this.txtEstadoHojaRuta.Location = new System.Drawing.Point(455, 50);
            this.txtEstadoHojaRuta.Name = "txtEstadoHojaRuta";
            this.txtEstadoHojaRuta.ReadOnly = true;
            this.txtEstadoHojaRuta.Size = new System.Drawing.Size(148, 20);
            this.txtEstadoHojaRuta.TabIndex = 18;
            // 
            // lblBase24
            // 
            this.lblBase24.AutoSize = true;
            this.lblBase24.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase24.ForeColor = System.Drawing.Color.Navy;
            this.lblBase24.Location = new System.Drawing.Point(404, 53);
            this.lblBase24.Name = "lblBase24";
            this.lblBase24.Size = new System.Drawing.Size(45, 13);
            this.lblBase24.TabIndex = 9;
            this.lblBase24.Text = "Estado";
            // 
            // txtTotalCreditos
            // 
            this.txtTotalCreditos.Enabled = false;
            this.txtTotalCreditos.Location = new System.Drawing.Point(333, 50);
            this.txtTotalCreditos.Name = "txtTotalCreditos";
            this.txtTotalCreditos.Size = new System.Drawing.Size(68, 20);
            this.txtTotalCreditos.TabIndex = 8;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(237, 53);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(90, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Notificaciones:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Location = new System.Drawing.Point(403, 22);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 5;
            this.dtpFechaFin.Value = new System.DateTime(2015, 7, 20, 12, 39, 12, 428);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Location = new System.Drawing.Point(91, 24);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 4;
            this.dtpFechaInicio.Value = new System.DateTime(2015, 7, 20, 12, 39, 0, 974);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(332, 28);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(771, 280);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(705, 280);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 3;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgNotificaciones);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 172);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notificaciones";
            // 
            // dtgNotificaciones
            // 
            this.dtgNotificaciones.AllowUserToAddRows = false;
            this.dtgNotificaciones.AllowUserToDeleteRows = false;
            this.dtgNotificaciones.AllowUserToResizeColumns = false;
            this.dtgNotificaciones.AllowUserToResizeRows = false;
            this.dtgNotificaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNotificaciones.Location = new System.Drawing.Point(3, 16);
            this.dtgNotificaciones.MultiSelect = false;
            this.dtgNotificaciones.Name = "dtgNotificaciones";
            this.dtgNotificaciones.ReadOnly = true;
            this.dtgNotificaciones.RowHeadersVisible = false;
            this.dtgNotificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotificaciones.Size = new System.Drawing.Size(816, 153);
            this.dtgNotificaciones.TabIndex = 0;
            // 
            // chcImpDir
            // 
            this.chcImpDir.AutoSize = true;
            this.chcImpDir.Location = new System.Drawing.Point(12, 280);
            this.chcImpDir.Name = "chcImpDir";
            this.chcImpDir.Size = new System.Drawing.Size(106, 17);
            this.chcImpDir.TabIndex = 2;
            this.chcImpDir.Text = "Impresion directa";
            this.chcImpDir.UseVisualStyleBackColor = true;
            // 
            // frmImpresionNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 361);
            this.Controls.Add(this.chcImpDir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImpresionNotificaciones";
            this.Text = "Impresion Notificaciones";
            this.Load += new System.EventHandler(this.frmImpresionNotificaciones_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.chcImpDir, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public GEN.ControlesBase.txtBase txtEstadoHojaRuta;
        private GEN.ControlesBase.lblBase lblBase24;
        private GEN.ControlesBase.txtCBNumerosEnteros txtTotalCreditos;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.DatePicker dtpFechaFin;
        private GEN.ControlesBase.DatePicker dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtKilometrajeInicio;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgNotificaciones;
        private GEN.ControlesBase.chcBase chcImpDir;
    }
}