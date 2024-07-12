namespace RPT.Presentacion
{
    partial class frmRegOpeUnMul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegOpeUnMul));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtFechaFinal = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtFechaInicio = new GEN.ControlesBase.dtLargoBase(this.components);
            this.btnBlanco1 = new GEN.BotonesBase.btnBlanco();
            this.btnBlanco2 = new GEN.BotonesBase.btnBlanco();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblTitleROU = new System.Windows.Forms.Label();
            this.lblTitleROM = new System.Windows.Forms.Label();
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(212, 276);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(38, 99);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 22;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(32, 62);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 21;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinal.Location = new System.Drawing.Point(121, 99);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(96, 20);
            this.dtFechaFinal.TabIndex = 20;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(121, 62);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(96, 20);
            this.dtFechaInicio.TabIndex = 19;
            // 
            // btnBlanco1
            // 
            this.btnBlanco1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco1.Location = new System.Drawing.Point(49, 146);
            this.btnBlanco1.Name = "btnBlanco1";
            this.btnBlanco1.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco1.TabIndex = 27;
            this.btnBlanco1.Text = "Generar Archivo";
            this.btnBlanco1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco1.UseVisualStyleBackColor = true;
            this.btnBlanco1.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // btnBlanco2
            // 
            this.btnBlanco2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco2.Location = new System.Drawing.Point(146, 146);
            this.btnBlanco2.Name = "btnBlanco2";
            this.btnBlanco2.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco2.TabIndex = 28;
            this.btnBlanco2.Text = "Generar Archivo";
            this.btnBlanco2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco2.UseVisualStyleBackColor = true;
            this.btnBlanco2.Click += new System.EventHandler(this.btnBlanco2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(121, 18);
            this.radioButton1.TabIndex = 29;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Actualizado al 2021";
            this.radioButton1.UseCompatibleTextRendering = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(146, 29);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(91, 17);
            this.radioButton2.TabIndex = 30;
            this.radioButton2.Text = "Hasta el 2021";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(49, 202);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 31;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblTitleROU
            // 
            this.lblTitleROU.AutoSize = true;
            this.lblTitleROU.Location = new System.Drawing.Point(61, 130);
            this.lblTitleROU.Name = "lblTitleROU";
            this.lblTitleROU.Size = new System.Drawing.Size(31, 13);
            this.lblTitleROU.TabIndex = 33;
            this.lblTitleROU.Text = "ROU";
            // 
            // lblTitleROM
            // 
            this.lblTitleROM.AutoSize = true;
            this.lblTitleROM.Location = new System.Drawing.Point(160, 130);
            this.lblTitleROM.Name = "lblTitleROM";
            this.lblTitleROM.Size = new System.Drawing.Size(32, 13);
            this.lblTitleROM.TabIndex = 34;
            this.lblTitleROM.Text = "ROM";
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(146, 202);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 35;
            this.btnImprimir2.Text = "Imprimir";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.radioButton2);
            this.grbBase1.Controls.Add(this.btnImprimir2);
            this.grbBase1.Controls.Add(this.dtFechaInicio);
            this.grbBase1.Controls.Add(this.lblTitleROM);
            this.grbBase1.Controls.Add(this.dtFechaFinal);
            this.grbBase1.Controls.Add(this.lblTitleROU);
            this.grbBase1.Controls.Add(this.btnImprimir1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.btnBlanco2);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnBlanco1);
            this.grbBase1.Controls.Add(this.radioButton1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(260, 258);
            this.grbBase1.TabIndex = 36;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "REGISTRO DE OPERACIONES ÙNICAS";
            // 
            // frmRegOpeUnMul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 353);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRegOpeUnMul";
            this.Text = "Reporte registro operaciones";
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtLargoBase dtFechaFinal;
        private GEN.ControlesBase.dtLargoBase dtFechaInicio;
        private GEN.BotonesBase.btnBlanco btnBlanco1;
        private GEN.BotonesBase.btnBlanco btnBlanco2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.Label lblTitleROU;
        private System.Windows.Forms.Label lblTitleROM;
        private GEN.BotonesBase.btnImprimir btnImprimir2;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}