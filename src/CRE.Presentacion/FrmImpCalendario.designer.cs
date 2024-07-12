namespace CRE.Presentacion
{
    partial class FrmImpCalendario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpCalendario));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboRptImpCre = new GEN.ControlesBase.cboDocumentoDesembolso(this.components);
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(443, 101);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 4;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 104);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(122, 13);
            this.lblBase7.TabIndex = 9;
            this.lblBase7.Text = "Reporte a Imprimir:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(377, 101);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 11;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli1.Location = new System.Drawing.Point(13, 13);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(556, 73);
            this.conBusCuentaCli1.TabIndex = 2;
            this.conBusCuentaCli1.ChangeDocumentoID += new System.EventHandler(this.conBusCuentaCli1_ChangeDocumentoID);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(509, 101);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboRptImpCre
            // 
            this.cboRptImpCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRptImpCre.Enabled = false;
            this.cboRptImpCre.FormattingEnabled = true;
            this.cboRptImpCre.Location = new System.Drawing.Point(140, 104);
            this.cboRptImpCre.Name = "cboRptImpCre";
            this.cboRptImpCre.Size = new System.Drawing.Size(172, 21);
            this.cboRptImpCre.TabIndex = 12;
            // 
            // FrmImpCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 184);
            this.Controls.Add(this.cboRptImpCre);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "FrmImpCalendario";
            this.Text = "Impresión de Calendarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmImpCalendario_FormClosed);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.cboRptImpCre, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboDocumentoDesembolso cboRptImpCre;
    }
}