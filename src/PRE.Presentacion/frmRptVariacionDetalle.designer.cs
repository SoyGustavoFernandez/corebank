namespace PRE.Presentacion
{
    partial class frmRptVariacionDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptVariacionDetalle));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboEstructuraPresupuesto = new GEN.ControlesBase.cboEstructuraPresupuesto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoModificacion = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboPeriodoPresupuestal = new GEN.ControlesBase.cboPeriodoPresupuestal(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(266, 114);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 50;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboEstructuraPresupuesto
            // 
            this.cboEstructuraPresupuesto.FormattingEnabled = true;
            this.cboEstructuraPresupuesto.Location = new System.Drawing.Point(98, 42);
            this.cboEstructuraPresupuesto.Name = "cboEstructuraPresupuesto";
            this.cboEstructuraPresupuesto.Size = new System.Drawing.Size(228, 21);
            this.cboEstructuraPresupuesto.TabIndex = 49;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 74);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 48;
            this.lblBase1.Text = "Tipo Partida:";
            // 
            // cboTipoModificacion
            // 
            this.cboTipoModificacion.FormattingEnabled = true;
            this.cboTipoModificacion.Location = new System.Drawing.Point(98, 71);
            this.cboTipoModificacion.Name = "cboTipoModificacion";
            this.cboTipoModificacion.Size = new System.Drawing.Size(228, 21);
            this.cboTipoModificacion.TabIndex = 47;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(61, 45);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(31, 13);
            this.lblBase3.TabIndex = 46;
            this.lblBase3.Text = "Por:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(200, 114);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 45;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(207, 15);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 14);
            this.lblEstado.TabIndex = 44;
            // 
            // cboPeriodoPresupuestal
            // 
            this.cboPeriodoPresupuestal.FormattingEnabled = true;
            this.cboPeriodoPresupuestal.Location = new System.Drawing.Point(98, 12);
            this.cboPeriodoPresupuestal.Name = "cboPeriodoPresupuestal";
            this.cboPeriodoPresupuestal.Size = new System.Drawing.Size(96, 21);
            this.cboPeriodoPresupuestal.TabIndex = 43;
            this.cboPeriodoPresupuestal.SelectedIndexChanged += new System.EventHandler(this.cboPeriodoPresupuestal_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(37, 16);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(55, 13);
            this.lblBase4.TabIndex = 42;
            this.lblBase4.Text = "Periodo:";
            // 
            // frmRptVariacionDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 190);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.cboEstructuraPresupuesto);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoModificacion);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cboPeriodoPresupuestal);
            this.Controls.Add(this.lblBase4);
            this.Name = "frmRptVariacionDetalle";
            this.Text = "Reporte de partidas de variación";
            this.Load += new System.EventHandler(this.frmRptVariacionDetalle_Load);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboPeriodoPresupuestal, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipoModificacion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboEstructuraPresupuesto, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboEstructuraPresupuesto cboEstructuraPresupuesto;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipoModificacion;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private System.Windows.Forms.Label lblEstado;
        private GEN.ControlesBase.cboPeriodoPresupuestal cboPeriodoPresupuestal;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}