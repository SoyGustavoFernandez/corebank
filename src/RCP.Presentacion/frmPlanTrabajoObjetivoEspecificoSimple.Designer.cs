namespace RCP.Presentacion
{
    partial class frmPlanTrabajoObjetivoEspecificoSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanTrabajoObjetivoEspecificoSimple));
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboObjetivoTipo = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFechaEspecifica = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtDescripcionObjetivoGeneral = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboObjetivoGeneral = new GEN.ControlesBase.cboBase(this.components);
            this.cboSemanaObjetivo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboObjetivoResumen = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(374, 223);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(434, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboObjetivoTipo
            // 
            this.cboObjetivoTipo.Enabled = false;
            this.cboObjetivoTipo.FormattingEnabled = true;
            this.cboObjetivoTipo.Location = new System.Drawing.Point(147, 12);
            this.cboObjetivoTipo.Name = "cboObjetivoTipo";
            this.cboObjetivoTipo.Size = new System.Drawing.Size(347, 21);
            this.cboObjetivoTipo.TabIndex = 0;
            this.cboObjetivoTipo.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoTipo_SelectedIndexChanged);
            // 
            // dtpFechaEspecifica
            // 
            this.dtpFechaEspecifica.Location = new System.Drawing.Point(147, 120);
            this.dtpFechaEspecifica.Name = "dtpFechaEspecifica";
            this.dtpFechaEspecifica.Size = new System.Drawing.Size(347, 20);
            this.dtpFechaEspecifica.TabIndex = 4;
            this.dtpFechaEspecifica.Leave += new System.EventHandler(this.dtpFechaEspecifica_Leave);
            // 
            // txtDescripcionObjetivoGeneral
            // 
            this.txtDescripcionObjetivoGeneral.Location = new System.Drawing.Point(147, 142);
            this.txtDescripcionObjetivoGeneral.MaxLength = 1000;
            this.txtDescripcionObjetivoGeneral.Multiline = true;
            this.txtDescripcionObjetivoGeneral.Name = "txtDescripcionObjetivoGeneral";
            this.txtDescripcionObjetivoGeneral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionObjetivoGeneral.Size = new System.Drawing.Size(347, 75);
            this.txtDescripcionObjetivoGeneral.TabIndex = 5;
            this.txtDescripcionObjetivoGeneral.Leave += new System.EventHandler(this.txtDescripcionObjetivoGeneral_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(88, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Tipo Objetivo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(19, 124);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(103, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Fecha Ejecución:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(19, 166);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(120, 26);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Descripción del\r\nObjetivo Específico:";
            // 
            // cboObjetivoGeneral
            // 
            this.cboObjetivoGeneral.FormattingEnabled = true;
            this.cboObjetivoGeneral.Location = new System.Drawing.Point(147, 35);
            this.cboObjetivoGeneral.Name = "cboObjetivoGeneral";
            this.cboObjetivoGeneral.Size = new System.Drawing.Size(347, 21);
            this.cboObjetivoGeneral.TabIndex = 1;
            this.cboObjetivoGeneral.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoGeneral_SelectedIndexChanged);
            // 
            // cboSemanaObjetivo
            // 
            this.cboSemanaObjetivo.Enabled = false;
            this.cboSemanaObjetivo.FormattingEnabled = true;
            this.cboSemanaObjetivo.Location = new System.Drawing.Point(147, 58);
            this.cboSemanaObjetivo.Name = "cboSemanaObjetivo";
            this.cboSemanaObjetivo.Size = new System.Drawing.Size(347, 21);
            this.cboSemanaObjetivo.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(19, 39);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Objetivo General:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(19, 62);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(59, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Semana:";
            // 
            // cboObjetivoResumen
            // 
            this.cboObjetivoResumen.FormattingEnabled = true;
            this.cboObjetivoResumen.Location = new System.Drawing.Point(147, 97);
            this.cboObjetivoResumen.Name = "cboObjetivoResumen";
            this.cboObjetivoResumen.Size = new System.Drawing.Size(347, 21);
            this.cboObjetivoResumen.TabIndex = 3;
            this.cboObjetivoResumen.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoResumen_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(19, 101);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(117, 13);
            this.lblBase6.TabIndex = 15;
            this.lblBase6.Text = "Resumen Objetivo:";
            // 
            // frmPlanTrabajoObjetivoEspecificoSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 316);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboObjetivoResumen);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboSemanaObjetivo);
            this.Controls.Add(this.cboObjetivoGeneral);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDescripcionObjetivoGeneral);
            this.Controls.Add(this.dtpFechaEspecifica);
            this.Controls.Add(this.cboObjetivoTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmPlanTrabajoObjetivoEspecificoSimple";
            this.Text = "Mantenimiento Plan de Trabajo - Objetivos Específicos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlanTrabajoObjetivoEspecificoSimple_FormClosing);
            this.Load += new System.EventHandler(this.frmPlanTrabajoObjetivoEspecifico_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboObjetivoTipo, 0);
            this.Controls.SetChildIndex(this.dtpFechaEspecifica, 0);
            this.Controls.SetChildIndex(this.txtDescripcionObjetivoGeneral, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboObjetivoGeneral, 0);
            this.Controls.SetChildIndex(this.cboSemanaObjetivo, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboObjetivoResumen, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboBase cboObjetivoTipo;
        private GEN.ControlesBase.dtpCorto dtpFechaEspecifica;
        private GEN.ControlesBase.txtBase txtDescripcionObjetivoGeneral;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboObjetivoGeneral;
        private GEN.ControlesBase.cboBase cboSemanaObjetivo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboObjetivoResumen;
        private GEN.ControlesBase.lblBase lblBase6;
    }
}