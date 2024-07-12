namespace CRE.Presentacion
{
    partial class frmDenegacionAfectacionCOBs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDenegacionAfectacionCOBs));
            this.pnlFrmCobAfec = new System.Windows.Forms.Panel();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.btnDenegar2 = new GEN.BotonesBase.btnDenegar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.SuspendLayout();
            // 
            // pnlFrmCobAfec
            // 
            this.pnlFrmCobAfec.BackColor = System.Drawing.Color.Gray;
            this.pnlFrmCobAfec.Location = new System.Drawing.Point(0, 0);
            this.pnlFrmCobAfec.Name = "pnlFrmCobAfec";
            this.pnlFrmCobAfec.Size = new System.Drawing.Size(564, 511);
            this.pnlFrmCobAfec.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 514);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(62, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Sustento:";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(12, 531);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(542, 54);
            this.txtSustento.TabIndex = 5;
            // 
            // btnDenegar2
            // 
            this.btnDenegar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar2.BackgroundImage")));
            this.btnDenegar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar2.Location = new System.Drawing.Point(362, 589);
            this.btnDenegar2.Name = "btnDenegar2";
            this.btnDenegar2.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar2.TabIndex = 7;
            this.btnDenegar2.Text = "&Denegar";
            this.btnDenegar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar2.UseVisualStyleBackColor = true;
            this.btnDenegar2.Click += new System.EventHandler(this.btnDenegar2_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(428, 589);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 8;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(494, 589);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmDenegacionAfectacionCOBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 664);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnDenegar2);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.pnlFrmCobAfec);
            this.Name = "frmDenegacionAfectacionCOBs";
            this.Text = "Denegación de Afectaciones de COBs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDenegacionAfectacionCOBs_FormClosing);
            this.Controls.SetChildIndex(this.pnlFrmCobAfec, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.btnDenegar2, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFrmCobAfec;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.BotonesBase.btnDenegar btnDenegar2;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}