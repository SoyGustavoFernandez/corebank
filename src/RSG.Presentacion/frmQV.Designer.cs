namespace RSG.Presentacion
{
    partial class frmQV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQV));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.rbtOficina = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtProducto = new GEN.ControlesBase.rbtBase(this.components);
            this.cboPeriodoRiegos1 = new GEN.ControlesBase.cboPeriodoRiegos(this.components);
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.rbtCarteraPotencial = new GEN.ControlesBase.rbtBase(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(213, 146);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(147, 146);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 7;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // rbtOficina
            // 
            this.rbtOficina.AutoSize = true;
            this.rbtOficina.Checked = true;
            this.rbtOficina.ForeColor = System.Drawing.Color.Navy;
            this.rbtOficina.Location = new System.Drawing.Point(6, 19);
            this.rbtOficina.Name = "rbtOficina";
            this.rbtOficina.Size = new System.Drawing.Size(58, 17);
            this.rbtOficina.TabIndex = 8;
            this.rbtOficina.TabStop = true;
            this.rbtOficina.Text = "Oficina";
            this.rbtOficina.UseVisualStyleBackColor = true;
            this.rbtOficina.CheckedChanged += new System.EventHandler(this.rbtOficina_CheckedChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtCarteraPotencial);
            this.grbBase1.Controls.Add(this.rbtProducto);
            this.grbBase1.Controls.Add(this.rbtOficina);
            this.grbBase1.Location = new System.Drawing.Point(17, 41);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(129, 92);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione reporte";
            // 
            // rbtProducto
            // 
            this.rbtProducto.AutoSize = true;
            this.rbtProducto.ForeColor = System.Drawing.Color.Navy;
            this.rbtProducto.Location = new System.Drawing.Point(6, 42);
            this.rbtProducto.Name = "rbtProducto";
            this.rbtProducto.Size = new System.Drawing.Size(68, 17);
            this.rbtProducto.TabIndex = 8;
            this.rbtProducto.Text = "Producto";
            this.rbtProducto.UseVisualStyleBackColor = true;
            this.rbtProducto.CheckedChanged += new System.EventHandler(this.rbtProducto_CheckedChanged);
            // 
            // cboPeriodoRiegos1
            // 
            this.cboPeriodoRiegos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoRiegos1.FormattingEnabled = true;
            this.cboPeriodoRiegos1.Location = new System.Drawing.Point(222, 86);
            this.cboPeriodoRiegos1.Name = "cboPeriodoRiegos1";
            this.cboPeriodoRiegos1.Size = new System.Drawing.Size(166, 21);
            this.cboPeriodoRiegos1.TabIndex = 10;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(222, 60);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(166, 20);
            this.dtpFecha.TabIndex = 11;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(162, 64);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Fecha:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(161, 90);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Periodo:";
            // 
            // rbtCarteraPotencial
            // 
            this.rbtCarteraPotencial.AutoSize = true;
            this.rbtCarteraPotencial.ForeColor = System.Drawing.Color.Navy;
            this.rbtCarteraPotencial.Location = new System.Drawing.Point(6, 65);
            this.rbtCarteraPotencial.Name = "rbtCarteraPotencial";
            this.rbtCarteraPotencial.Size = new System.Drawing.Size(106, 17);
            this.rbtCarteraPotencial.TabIndex = 9;
            this.rbtCarteraPotencial.Text = "Cartera Potencial";
            this.rbtCarteraPotencial.UseVisualStyleBackColor = true;
            this.rbtCarteraPotencial.CheckedChanged += new System.EventHandler(this.rbtCarteraPotencial_CheckedChanged);
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(9, 9);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(388, 25);
            this.lblBaseCustom1.TabIndex = 13;
            this.lblBaseCustom1.Text = "REPORTE QUICK VIEW";
            this.lblBaseCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmQV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 225);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cboPeriodoRiegos1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmQV";
            this.Text = "Reporte quick view";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.cboPeriodoRiegos1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.rbtBase rbtOficina;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.rbtBase rbtProducto;
        private GEN.ControlesBase.cboPeriodoRiegos cboPeriodoRiegos1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.rbtBase rbtCarteraPotencial;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
    }
}

