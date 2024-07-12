namespace RCP.Presentacion
{
    partial class frmPlanTrabajoObjetivoGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanTrabajoObjetivoGeneral));
            this.cboObjetivoTipo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboSemana = new GEN.ControlesBase.cboBase(this.components);
            this.txtDescripcionObjetivoGeneral = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboObjetivoResumen = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // cboObjetivoTipo
            // 
            this.cboObjetivoTipo.Enabled = false;
            this.cboObjetivoTipo.FormattingEnabled = true;
            this.cboObjetivoTipo.Location = new System.Drawing.Point(143, 12);
            this.cboObjetivoTipo.Name = "cboObjetivoTipo";
            this.cboObjetivoTipo.Size = new System.Drawing.Size(404, 21);
            this.cboObjetivoTipo.TabIndex = 0;
            this.cboObjetivoTipo.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoTipo_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo de objetivo:";
            // 
            // cboSemana
            // 
            this.cboSemana.FormattingEnabled = true;
            this.cboSemana.Location = new System.Drawing.Point(143, 58);
            this.cboSemana.Name = "cboSemana";
            this.cboSemana.Size = new System.Drawing.Size(404, 21);
            this.cboSemana.TabIndex = 2;
            this.cboSemana.SelectedIndexChanged += new System.EventHandler(this.cboSemana_SelectedIndexChanged);
            // 
            // txtDescripcionObjetivoGeneral
            // 
            this.txtDescripcionObjetivoGeneral.Location = new System.Drawing.Point(143, 81);
            this.txtDescripcionObjetivoGeneral.MaxLength = 1000;
            this.txtDescripcionObjetivoGeneral.Multiline = true;
            this.txtDescripcionObjetivoGeneral.Name = "txtDescripcionObjetivoGeneral";
            this.txtDescripcionObjetivoGeneral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionObjetivoGeneral.Size = new System.Drawing.Size(404, 99);
            this.txtDescripcionObjetivoGeneral.TabIndex = 3;
            this.txtDescripcionObjetivoGeneral.Leave += new System.EventHandler(this.txtDescripcionObjetivoGeneral_Leave);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 117);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(109, 26);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Descripción del \r\nObjetivo General:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 62);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(59, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Semana:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(427, 186);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(487, 186);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboObjetivoResumen
            // 
            this.cboObjetivoResumen.FormattingEnabled = true;
            this.cboObjetivoResumen.Location = new System.Drawing.Point(143, 35);
            this.cboObjetivoResumen.Name = "cboObjetivoResumen";
            this.cboObjetivoResumen.Size = new System.Drawing.Size(404, 21);
            this.cboObjetivoResumen.TabIndex = 1;
            this.cboObjetivoResumen.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoResumen_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 39);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Resumen:";
            // 
            // frmPlanTrabajoObjetivoGeneral
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 261);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboObjetivoResumen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtDescripcionObjetivoGeneral);
            this.Controls.Add(this.cboSemana);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboObjetivoTipo);
            this.Name = "frmPlanTrabajoObjetivoGeneral";
            this.Text = "Mantenimiento Plan de Trabajo - Objetivos Generales";
            this.Load += new System.EventHandler(this.frmPlanTrabajoObjetivoGeneral_Load);
            this.Controls.SetChildIndex(this.cboObjetivoTipo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboSemana, 0);
            this.Controls.SetChildIndex(this.txtDescripcionObjetivoGeneral, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboObjetivoResumen, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboObjetivoTipo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboSemana;
        private GEN.ControlesBase.txtBase txtDescripcionObjetivoGeneral;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboBase cboObjetivoResumen;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}