namespace GEN.ControlesBase
{
    partial class ConBusSolEval
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConBusSolEval));
            this.txtSolicitud = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtEvaluacion = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtModalidad = new GEN.ControlesBase.txtBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblSolicitud = new GEN.ControlesBase.lblBase();
            this.lblEvaluacion = new GEN.ControlesBase.lblBase();
            this.lblModalidad = new GEN.ControlesBase.lblBase();
            this.lblOperacion = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Format = "n2";
            this.txtSolicitud.Location = new System.Drawing.Point(63, 4);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.Size = new System.Drawing.Size(75, 20);
            this.txtSolicitud.TabIndex = 0;
            // 
            // txtEvaluacion
            // 
            this.txtEvaluacion.Format = "n2";
            this.txtEvaluacion.Location = new System.Drawing.Point(63, 30);
            this.txtEvaluacion.Name = "txtEvaluacion";
            this.txtEvaluacion.Size = new System.Drawing.Size(75, 20);
            this.txtEvaluacion.TabIndex = 1;
            // 
            // txtOperacion
            // 
            this.txtOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperacion.Enabled = false;
            this.txtOperacion.Location = new System.Drawing.Point(177, 4);
            this.txtOperacion.MaximumSize = new System.Drawing.Size(200, 20);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(100, 20);
            this.txtOperacion.TabIndex = 2;
            // 
            // txtModalidad
            // 
            this.txtModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModalidad.Enabled = false;
            this.txtModalidad.Location = new System.Drawing.Point(177, 30);
            this.txtModalidad.MaximumSize = new System.Drawing.Size(200, 20);
            this.txtModalidad.Name = "txtModalidad";
            this.txtModalidad.Size = new System.Drawing.Size(100, 20);
            this.txtModalidad.TabIndex = 3;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(280, 2);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 4;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblSolicitud.Location = new System.Drawing.Point(3, 8);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(60, 13);
            this.lblSolicitud.TabIndex = 5;
            this.lblSolicitud.Text = "Solicitud:";
            // 
            // lblEvaluacion
            // 
            this.lblEvaluacion.AutoSize = true;
            this.lblEvaluacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEvaluacion.ForeColor = System.Drawing.Color.Navy;
            this.lblEvaluacion.Location = new System.Drawing.Point(3, 34);
            this.lblEvaluacion.Name = "lblEvaluacion";
            this.lblEvaluacion.Size = new System.Drawing.Size(40, 13);
            this.lblEvaluacion.TabIndex = 6;
            this.lblEvaluacion.Text = "Eval.:";
            // 
            // lblModalidad
            // 
            this.lblModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblModalidad.ForeColor = System.Drawing.Color.Navy;
            this.lblModalidad.Location = new System.Drawing.Point(138, 34);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(39, 13);
            this.lblModalidad.TabIndex = 8;
            this.lblModalidad.Text = "Mod.:";
            // 
            // lblOperacion
            // 
            this.lblOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblOperacion.ForeColor = System.Drawing.Color.Navy;
            this.lblOperacion.Location = new System.Drawing.Point(138, 8);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(39, 13);
            this.lblOperacion.TabIndex = 7;
            this.lblOperacion.Text = "Ope.:";
            // 
            // ConBusSolEval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblModalidad);
            this.Controls.Add(this.lblOperacion);
            this.Controls.Add(this.lblEvaluacion);
            this.Controls.Add(this.lblSolicitud);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtModalidad);
            this.Controls.Add(this.txtOperacion);
            this.Controls.Add(this.txtEvaluacion);
            this.Controls.Add(this.txtSolicitud);
            this.Name = "ConBusSolEval";
            this.Size = new System.Drawing.Size(341, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private txtNumerico txtSolicitud;
        private txtNumerico txtEvaluacion;
        private txtBase txtOperacion;
        private txtBase txtModalidad;
        private BotonesBase.btnBusqueda btnBusqueda;
        private lblBase lblSolicitud;
        private lblBase lblEvaluacion;
        private lblBase lblModalidad;
        private lblBase lblOperacion;
    }
}
