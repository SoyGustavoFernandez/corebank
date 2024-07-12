namespace DEP.Presentacion
{
    partial class frmEnvioEstadosDeCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioEstadosDeCuenta));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGenerar1 = new GEN.BotonesBase.btnGenerar();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.dtgBase2 = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.conLoader1 = new GEN.ControlesBase.conLoader();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.conFechaAñoMes1 = new GEN.ControlesBase.ConFechaAñoMes();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(113, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Seleccione el Mes:";
            // 
            // btnGenerar1
            // 
            this.btnGenerar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar1.BackgroundImage")));
            this.btnGenerar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGenerar1.Location = new System.Drawing.Point(773, 16);
            this.btnGenerar1.Name = "btnGenerar1";
            this.btnGenerar1.Size = new System.Drawing.Size(60, 50);
            this.btnGenerar1.TabIndex = 4;
            this.btnGenerar1.Text = "Gene&rar";
            this.btnGenerar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerar1.UseVisualStyleBackColor = true;
            this.btnGenerar1.Click += new System.EventHandler(this.btnGenerar1_Click);
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(707, 345);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 6;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(773, 345);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(210, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(113, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Carpeta Generada";
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(213, 42);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(100, 20);
            this.txtBase1.TabIndex = 10;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(707, 16);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 12;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // dtgBase2
            // 
            this.dtgBase2.AllowUserToAddRows = false;
            this.dtgBase2.AllowUserToDeleteRows = false;
            this.dtgBase2.AllowUserToResizeColumns = false;
            this.dtgBase2.AllowUserToResizeRows = false;
            this.dtgBase2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase2.Location = new System.Drawing.Point(6, 6);
            this.dtgBase2.MultiSelect = false;
            this.dtgBase2.Name = "dtgBase2";
            this.dtgBase2.ReadOnly = true;
            this.dtgBase2.RowHeadersVisible = false;
            this.dtgBase2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase2.Size = new System.Drawing.Size(801, 207);
            this.dtgBase2.TabIndex = 13;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 78);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(119, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Estados de Cuenta:";
            // 
            // conLoader1
            // 
            this.conLoader1.Active = false;
            this.conLoader1.Color = System.Drawing.Color.Crimson;
            this.conLoader1.InnerCircleRadius = 5;
            this.conLoader1.Location = new System.Drawing.Point(411, 12);
            this.conLoader1.Name = "conLoader1";
            this.conLoader1.NumberSpoke = 12;
            this.conLoader1.OuterCircleRadius = 11;
            this.conLoader1.RotationSpeed = 100;
            this.conLoader1.Size = new System.Drawing.Size(60, 50);
            this.conLoader1.SpokeThickness = 2;
            this.conLoader1.StylePreset = GEN.ControlesBase.conLoader.StylePresets.MacOSX;
            this.conLoader1.TabIndex = 16;
            this.conLoader1.Text = "conLoader1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(821, 245);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgBase1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(813, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(6, 6);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(801, 207);
            this.dtgBase1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgBase2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(813, 219);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Enviados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // conFechaAñoMes1
            // 
            this.conFechaAñoMes1.anio = 1;
            this.conFechaAñoMes1.cMes = "ENERO";
            this.conFechaAñoMes1.idMes = 1;
            this.conFechaAñoMes1.Location = new System.Drawing.Point(22, 27);
            this.conFechaAñoMes1.Name = "conFechaAñoMes1";
            this.conFechaAñoMes1.Size = new System.Drawing.Size(164, 39);
            this.conFechaAñoMes1.TabIndex = 18;
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(16, 345);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 19;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // frmEnvioEstadosDeCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(841, 425);
            this.ControlBox = false;
            this.Controls.Add(this.btnExporExcel1);
            this.Controls.Add(this.conFechaAñoMes1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.conLoader1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.btnGenerar1);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmEnvioEstadosDeCuenta";
            this.Text = "Envío de Estados de Cuenta Mensual - Ahorros";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGenerar1, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.conLoader1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.conFechaAñoMes1, 0);
            this.Controls.SetChildIndex(this.btnExporExcel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGenerar btnGenerar1;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtBase1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private GEN.ControlesBase.dtgBase dtgBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.conLoader conLoader1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.ConFechaAñoMes conFechaAñoMes1;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
    }
}