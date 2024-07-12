namespace CRE.Presentacion
{
    partial class frmConsultaEstadoSolAprb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaEstadoSolAprb));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.lblNEstadoSol = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblEstadoSolicitud = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblCodSolicitud = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblNCodSolicitud = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblFechaRegistro = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblNFechaRegistro = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(551, 100);
            this.conBusCuentaCli.TabIndex = 2;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // lblNEstadoSol
            // 
            this.lblNEstadoSol.AutoSize = true;
            this.lblNEstadoSol.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNEstadoSol.ForeColor = System.Drawing.Color.Navy;
            this.lblNEstadoSol.Location = new System.Drawing.Point(179, 155);
            this.lblNEstadoSol.Name = "lblNEstadoSol";
            this.lblNEstadoSol.Size = new System.Drawing.Size(50, 13);
            this.lblNEstadoSol.TabIndex = 4;
            this.lblNEstadoSol.Text = "Estado:";
            // 
            // lblEstadoSolicitud
            // 
            this.lblEstadoSolicitud.AutoSize = true;
            this.lblEstadoSolicitud.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblEstadoSolicitud.Location = new System.Drawing.Point(229, 152);
            this.lblEstadoSolicitud.Name = "lblEstadoSolicitud";
            this.lblEstadoSolicitud.Size = new System.Drawing.Size(16, 18);
            this.lblEstadoSolicitud.TabIndex = 5;
            this.lblEstadoSolicitud.Text = "-";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(443, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(503, 221);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblCodSolicitud
            // 
            this.lblCodSolicitud.AutoSize = true;
            this.lblCodSolicitud.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblCodSolicitud.Location = new System.Drawing.Point(229, 122);
            this.lblCodSolicitud.Name = "lblCodSolicitud";
            this.lblCodSolicitud.Size = new System.Drawing.Size(16, 18);
            this.lblCodSolicitud.TabIndex = 9;
            this.lblCodSolicitud.Text = "-";
            // 
            // lblNCodSolicitud
            // 
            this.lblNCodSolicitud.AutoSize = true;
            this.lblNCodSolicitud.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNCodSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblNCodSolicitud.Location = new System.Drawing.Point(169, 125);
            this.lblNCodSolicitud.Name = "lblNCodSolicitud";
            this.lblNCodSolicitud.Size = new System.Drawing.Size(60, 13);
            this.lblNCodSolicitud.TabIndex = 8;
            this.lblNCodSolicitud.Text = "Solicitud:";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRegistro.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaRegistro.Location = new System.Drawing.Point(229, 180);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(16, 18);
            this.lblFechaRegistro.TabIndex = 11;
            this.lblFechaRegistro.Text = "-";
            // 
            // lblNFechaRegistro
            // 
            this.lblNFechaRegistro.AutoSize = true;
            this.lblNFechaRegistro.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNFechaRegistro.ForeColor = System.Drawing.Color.Navy;
            this.lblNFechaRegistro.Location = new System.Drawing.Point(115, 183);
            this.lblNFechaRegistro.Name = "lblNFechaRegistro";
            this.lblNFechaRegistro.Size = new System.Drawing.Size(114, 13);
            this.lblNFechaRegistro.TabIndex = 10;
            this.lblNFechaRegistro.Text = "Fecha de Registro:";
            // 
            // frmConsultaEstadoSolAprb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 312);
            this.Controls.Add(this.lblFechaRegistro);
            this.Controls.Add(this.lblNFechaRegistro);
            this.Controls.Add(this.lblCodSolicitud);
            this.Controls.Add(this.lblNCodSolicitud);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblEstadoSolicitud);
            this.Controls.Add(this.lblNEstadoSol);
            this.Controls.Add(this.conBusCuentaCli);
            this.Name = "frmConsultaEstadoSolAprb";
            this.Text = "Consulta de Estado de Solicitud";
            this.Load += new System.EventHandler(this.frmConsultaEstadoSolAprb_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.lblNEstadoSol, 0);
            this.Controls.SetChildIndex(this.lblEstadoSolicitud, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblNCodSolicitud, 0);
            this.Controls.SetChildIndex(this.lblCodSolicitud, 0);
            this.Controls.SetChildIndex(this.lblNFechaRegistro, 0);
            this.Controls.SetChildIndex(this.lblFechaRegistro, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.lblBaseCustom lblNEstadoSol;
        private GEN.ControlesBase.lblBaseCustom lblEstadoSolicitud;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBaseCustom lblCodSolicitud;
        private GEN.ControlesBase.lblBaseCustom lblNCodSolicitud;
        private GEN.ControlesBase.lblBaseCustom lblFechaRegistro;
        private GEN.ControlesBase.lblBaseCustom lblNFechaRegistro;
    }
}