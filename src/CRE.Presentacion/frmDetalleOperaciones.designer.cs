namespace CRE.Presentacion
{
    partial class frmDetalleOperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleOperaciones));
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnDetalle = new GEN.BotonesBase.btnBlanco();
            this.btnResumen = new GEN.BotonesBase.btnBlanco();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(161, 18);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(121, 21);
            this.cboAgencia1.TabIndex = 12;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(75, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Agencia:";
            // 
            // dFecIni
            // 
            this.dFecIni.Location = new System.Drawing.Point(161, 46);
            this.dFecIni.Name = "dFecIni";
            this.dFecIni.Size = new System.Drawing.Size(121, 20);
            this.dFecIni.TabIndex = 4;
            // 
            // dFecFin
            // 
            this.dFecFin.Location = new System.Drawing.Point(161, 76);
            this.dFecFin.Name = "dFecFin";
            this.dFecFin.Size = new System.Drawing.Size(121, 20);
            this.dFecFin.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(75, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(75, 83);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle.Image = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnDetalle.Location = new System.Drawing.Point(88, 119);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle.TabIndex = 9;
            this.btnDetalle.Text = "&Detalle";
            this.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnResumen
            // 
            this.btnResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResumen.Image = global::CRE.Presentacion.Properties.Resources.btnImprimir;
            this.btnResumen.Location = new System.Drawing.Point(148, 119);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(60, 50);
            this.btnResumen.TabIndex = 8;
            this.btnResumen.Text = "&Resumen";
            this.btnResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(208, 119);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmDetalleOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 212);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dFecFin);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dFecIni);
            this.Name = "frmDetalleOperaciones";
            this.Text = "Detalle de Operaciones";
            this.Load += new System.EventHandler(this.frmDetalleOperaciones_Load);
            this.Controls.SetChildIndex(this.dFecIni, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnResumen, 0);
            this.Controls.SetChildIndex(this.btnDetalle, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnBlanco btnResumen;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dFecIni;
        private GEN.ControlesBase.dtpCorto dFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBlanco btnDetalle;
    }
}