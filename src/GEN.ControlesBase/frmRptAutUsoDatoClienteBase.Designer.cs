namespace GEN.ControlesBase
{
    partial class frmRptAutUsoDatoClienteBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptAutUsoDatoClienteBase));
            this.cboTipoAutorizacion1 = new GEN.ControlesBase.cboTipoAutorizacion(this.components);
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboEstadoAutUsoDatos1 = new GEN.ControlesBase.cboEstadoAutUsoDatos(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.cprogressbar = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // cboTipoAutorizacion1
            // 
            this.cboTipoAutorizacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAutorizacion1.FormattingEnabled = true;
            this.cboTipoAutorizacion1.Location = new System.Drawing.Point(128, 10);
            this.cboTipoAutorizacion1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboTipoAutorizacion1.Name = "cboTipoAutorizacion1";
            this.cboTipoAutorizacion1.Size = new System.Drawing.Size(390, 21);
            this.cboTipoAutorizacion1.TabIndex = 2;
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(128, 36);
            this.cboZona1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(168, 21);
            this.cboZona1.TabIndex = 17;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(300, 37);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Oficina:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 36);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 14;
            this.lblBase1.Text = "Región:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 12);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(109, 13);
            this.lblBase3.TabIndex = 19;
            this.lblBase3.Text = "Tipo autorización:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 63);
            this.lblBase4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 20;
            this.lblBase4.Text = "Estado:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(16, 86);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(78, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Fecha inicio:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(300, 89);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(63, 13);
            this.lblBase6.TabIndex = 22;
            this.lblBase6.Text = "Fecha fin:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(251, 117);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 23;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(362, 85);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(155, 20);
            this.dtpFecFin.TabIndex = 24;
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicio.Location = new System.Drawing.Point(128, 85);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(168, 20);
            this.dtpFecInicio.TabIndex = 25;
            // 
            // cboEstadoAutUsoDatos1
            // 
            this.cboEstadoAutUsoDatos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoAutUsoDatos1.FormattingEnabled = true;
            this.cboEstadoAutUsoDatos1.Location = new System.Drawing.Point(128, 60);
            this.cboEstadoAutUsoDatos1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboEstadoAutUsoDatos1.Name = "cboEstadoAutUsoDatos1";
            this.cboEstadoAutUsoDatos1.Size = new System.Drawing.Size(168, 21);
            this.cboEstadoAutUsoDatos1.TabIndex = 26;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(362, 36);
            this.cboAgencias1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(155, 21);
            this.cboAgencias1.TabIndex = 27;
            // 
            // cprogressbar
            // 
            this.cprogressbar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cprogressbar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cprogressbar.AnimationSpeed = 500;
            this.cprogressbar.BackColor = System.Drawing.Color.Transparent;
            this.cprogressbar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cprogressbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cprogressbar.InnerColor = System.Drawing.Color.White;
            this.cprogressbar.InnerMargin = 0;
            this.cprogressbar.InnerWidth = 0;
            this.cprogressbar.Location = new System.Drawing.Point(227, 12);
            this.cprogressbar.MarqueeAnimationSpeed = 2000;
            this.cprogressbar.Name = "cprogressbar";
            this.cprogressbar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cprogressbar.OuterMargin = -11;
            this.cprogressbar.OuterWidth = 8;
            this.cprogressbar.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.cprogressbar.ProgressWidth = 14;
            this.cprogressbar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F);
            this.cprogressbar.Size = new System.Drawing.Size(103, 99);
            this.cprogressbar.StartAngle = 270;
            this.cprogressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.cprogressbar.SubscriptColor = System.Drawing.Color.Gray;
            this.cprogressbar.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.cprogressbar.SubscriptText = "";
            this.cprogressbar.SuperscriptColor = System.Drawing.Color.Gray;
            this.cprogressbar.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.cprogressbar.SuperscriptText = "";
            this.cprogressbar.TabIndex = 28;
            this.cprogressbar.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.cprogressbar.Value = 67;
            this.cprogressbar.Visible = false;
            // 
            // frmRptAutUsoDatoClienteBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 191);
            this.Controls.Add(this.cprogressbar);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.cboEstadoAutUsoDatos1);
            this.Controls.Add(this.dtpFecInicio);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboZona1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoAutorizacion1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmRptAutUsoDatoClienteBase";
            this.Text = "Reporte de autorizaciones de clientes";
            this.Load += new System.EventHandler(this.frmRptAutUsoDatoCliente_Load);
            this.Controls.SetChildIndex(this.cboTipoAutorizacion1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboZona1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.dtpFecInicio, 0);
            this.Controls.SetChildIndex(this.cboEstadoAutUsoDatos1, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.cprogressbar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboTipoAutorizacion cboTipoAutorizacion1;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecInicio;
        private GEN.ControlesBase.cboEstadoAutUsoDatos cboEstadoAutUsoDatos1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private CircularProgressBar.CircularProgressBar cprogressbar;
    }
}