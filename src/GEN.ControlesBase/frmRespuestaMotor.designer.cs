namespace GEN.ControlesBase
{
    partial class frmRespuestaMotor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRespuestaMotor));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblIdSolicitud = new GEN.ControlesBase.lblNumber();
            this.lblEstado = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblHora = new GEN.ControlesBase.lblBase();
            this.lblComentarios = new GEN.ControlesBase.lblBase();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.txtReglas = new GEN.ControlesBase.txtBase(this.components);
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(32, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "N° Solicitud: ";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(32, 51);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(54, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Estado: ";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(32, 75);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(43, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Hora: ";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(32, 99);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(89, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Comentarios: ";
            // 
            // lblIdSolicitud
            // 
            this.lblIdSolicitud.AutoSize = true;
            this.lblIdSolicitud.Format = null;
            this.lblIdSolicitud.Location = new System.Drawing.Point(109, 28);
            this.lblIdSolicitud.Name = "lblIdSolicitud";
            this.lblIdSolicitud.Size = new System.Drawing.Size(13, 13);
            this.lblIdSolicitud.TabIndex = 4;
            this.lblIdSolicitud.Text = "0";
            this.lblIdSolicitud.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(80, 51);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(14, 13);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "0";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblHora.ForeColor = System.Drawing.Color.Navy;
            this.lblHora.Location = new System.Drawing.Point(68, 75);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(14, 13);
            this.lblHora.TabIndex = 6;
            this.lblHora.Text = "0";
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblComentarios.ForeColor = System.Drawing.Color.Navy;
            this.lblComentarios.Location = new System.Drawing.Point(114, 99);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(14, 13);
            this.lblComentarios.TabIndex = 7;
            this.lblComentarios.Text = "0";
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(351, 28);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 8;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // txtReglas
            // 
            this.txtReglas.Location = new System.Drawing.Point(35, 121);
            this.txtReglas.Name = "txtReglas";
            this.txtReglas.Size = new System.Drawing.Size(376, 20);
            this.txtReglas.Multiline = true;
            this.txtReglas.ReadOnly = true;
            this.txtReglas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReglas.Visible = false;
            this.txtReglas.TabIndex = 9;
            // 
            // frmRespuestaMotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 161);
            this.Controls.Add(this.txtReglas);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblIdSolicitud);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRespuestaMotor";
            this.Text = "Motor Decisiones";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblIdSolicitud, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.lblHora, 0);
            this.Controls.SetChildIndex(this.lblComentarios, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.txtReglas, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase1;
        private lblBase lblBase2;
        private lblBase lblBase3;
        private lblBase lblBase4;
        private lblNumber lblIdSolicitud;
        private lblBaseCustom lblEstado;
        private lblBase lblHora;
        private lblBase lblComentarios;
        private BotonesBase.BtnAceptar btnAceptar1;
        private txtBase txtReglas;
    }
}