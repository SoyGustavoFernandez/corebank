namespace CNT.Presentacion
{
    partial class frmBSI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBSI));
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnExporTxt1 = new GEN.BotonesBase.btnExporTxt();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rbtDefinitivo = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtPreliminar = new GEN.ControlesBase.rbtBase(this.components);
            this.SuspendLayout();
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(51, 118);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 1;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(187, 118);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(50, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(94, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Fecha Proceso:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(152, 36);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // btnExporTxt1
            // 
            this.btnExporTxt1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporTxt1.BackgroundImage")));
            this.btnExporTxt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporTxt1.Enabled = false;
            this.btnExporTxt1.Location = new System.Drawing.Point(119, 118);
            this.btnExporTxt1.Name = "btnExporTxt1";
            this.btnExporTxt1.Size = new System.Drawing.Size(60, 50);
            this.btnExporTxt1.TabIndex = 7;
            this.btnExporTxt1.Text = "A&rchivo";
            this.btnExporTxt1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporTxt1.UseVisualStyleBackColor = true;
            this.btnExporTxt1.Click += new System.EventHandler(this.btnExporTxt1_Click);
            // 
            // rbtDefinitivo
            // 
            this.rbtDefinitivo.AutoSize = true;
            this.rbtDefinitivo.Checked = true;
            this.rbtDefinitivo.ForeColor = System.Drawing.Color.Navy;
            this.rbtDefinitivo.Location = new System.Drawing.Point(116, 72);
            this.rbtDefinitivo.Name = "rbtDefinitivo";
            this.rbtDefinitivo.Size = new System.Drawing.Size(69, 17);
            this.rbtDefinitivo.TabIndex = 8;
            this.rbtDefinitivo.TabStop = true;
            this.rbtDefinitivo.Text = "Definitivo";
            this.rbtDefinitivo.UseVisualStyleBackColor = true;
            this.rbtDefinitivo.CheckedChanged += new System.EventHandler(this.rbtDefinitivo_CheckedChanged);
            // 
            // rbtPreliminar
            // 
            this.rbtPreliminar.AutoSize = true;
            this.rbtPreliminar.ForeColor = System.Drawing.Color.Navy;
            this.rbtPreliminar.Location = new System.Drawing.Point(116, 92);
            this.rbtPreliminar.Name = "rbtPreliminar";
            this.rbtPreliminar.Size = new System.Drawing.Size(70, 17);
            this.rbtPreliminar.TabIndex = 9;
            this.rbtPreliminar.Text = "Preliminar";
            this.rbtPreliminar.UseVisualStyleBackColor = true;
            this.rbtPreliminar.CheckedChanged += new System.EventHandler(this.rbtPreliminar_CheckedChanged);
            // 
            // frmBSI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 201);
            this.Controls.Add(this.rbtPreliminar);
            this.Controls.Add(this.rbtDefinitivo);
            this.Controls.Add(this.btnExporTxt1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnProcesar1);
            this.Name = "frmBSI";
            this.Text = "Balance de Sectorizaciòn Institucional";
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.btnExporTxt1, 0);
            this.Controls.SetChildIndex(this.rbtDefinitivo, 0);
            this.Controls.SetChildIndex(this.rbtPreliminar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.BotonesBase.btnExporTxt btnExporTxt1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.rbtBase rbtDefinitivo;
        private GEN.ControlesBase.rbtBase rbtPreliminar;
    }
}