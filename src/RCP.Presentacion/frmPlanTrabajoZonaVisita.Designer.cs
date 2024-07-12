namespace RCP.Presentacion
{
    partial class frmPlanTrabajoZonaVisita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanTrabajoZonaVisita));
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.txtDescripcionZonaVisita = new GEN.ControlesBase.txtBase(this.components);
            this.cboObjetivoVisita = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFechaVisita = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(143, 65);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(275, 21);
            this.cboZona.TabIndex = 2;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // txtDescripcionZonaVisita
            // 
            this.txtDescripcionZonaVisita.Location = new System.Drawing.Point(143, 134);
            this.txtDescripcionZonaVisita.MaxLength = 500;
            this.txtDescripcionZonaVisita.Multiline = true;
            this.txtDescripcionZonaVisita.Name = "txtDescripcionZonaVisita";
            this.txtDescripcionZonaVisita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionZonaVisita.Size = new System.Drawing.Size(275, 75);
            this.txtDescripcionZonaVisita.TabIndex = 4;
            this.txtDescripcionZonaVisita.Leave += new System.EventHandler(this.txtDescripcionZonaVisita_Leave);
            // 
            // cboObjetivoVisita
            // 
            this.cboObjetivoVisita.FormattingEnabled = true;
            this.cboObjetivoVisita.Location = new System.Drawing.Point(143, 12);
            this.cboObjetivoVisita.Name = "cboObjetivoVisita";
            this.cboObjetivoVisita.Size = new System.Drawing.Size(275, 21);
            this.cboObjetivoVisita.TabIndex = 5;
            this.cboObjetivoVisita.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoVisita_SelectedIndexChanged);
            // 
            // dtpFechaVisita
            // 
            this.dtpFechaVisita.Enabled = false;
            this.dtpFechaVisita.Location = new System.Drawing.Point(143, 35);
            this.dtpFechaVisita.Name = "dtpFechaVisita";
            this.dtpFechaVisita.Size = new System.Drawing.Size(275, 20);
            this.dtpFechaVisita.TabIndex = 6;
            this.dtpFechaVisita.Leave += new System.EventHandler(this.dtpFechaVisita_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 39);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(93, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Fecha de Visita";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(127, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Objetivo de la Visita:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 69);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(41, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Zona:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 92);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 10;
            this.lblBase4.Text = "Agencia:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 158);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(91, 26);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Descripción de\r\nla visita:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(298, 215);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(358, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(143, 88);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(275, 21);
            this.cboAgencias.TabIndex = 14;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(143, 111);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(275, 21);
            this.cboDistrito.TabIndex = 15;
            this.cboDistrito.SelectedIndexChanged += new System.EventHandler(this.cboDistrito_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 115);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(53, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Distrito:";
            // 
            // frmPlanTrabajoZonaVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 293);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.cboAgencias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaVisita);
            this.Controls.Add(this.cboObjetivoVisita);
            this.Controls.Add(this.txtDescripcionZonaVisita);
            this.Controls.Add(this.cboZona);
            this.Name = "frmPlanTrabajoZonaVisita";
            this.Text = "Plan Trabajo - Zonas a Visitar";
            this.Load += new System.EventHandler(this.frmPlanTrabajoZonaVisita_Load);
            this.Controls.SetChildIndex(this.cboZona, 0);
            this.Controls.SetChildIndex(this.txtDescripcionZonaVisita, 0);
            this.Controls.SetChildIndex(this.cboObjetivoVisita, 0);
            this.Controls.SetChildIndex(this.dtpFechaVisita, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboAgencias, 0);
            this.Controls.SetChildIndex(this.cboDistrito, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.txtBase txtDescripcionZonaVisita;
        private GEN.ControlesBase.cboBase cboObjetivoVisita;
        private GEN.ControlesBase.dtpCorto dtpFechaVisita;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.lblBase lblBase6;
    }
}