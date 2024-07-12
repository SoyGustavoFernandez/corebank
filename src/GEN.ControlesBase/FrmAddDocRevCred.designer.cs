namespace GEN.ControlesBase
{
    partial class FrmAddDocRevCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddDocRevCred));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAddDoc = new GEN.BotonesBase.btnMiniAgregar();
            this.txtDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipDocRevCred = new GEN.ControlesBase.cboTipDocRevCred(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnAddDoc);
            this.grbBase1.Controls.Add(this.txtDocumento);
            this.grbBase1.Controls.Add(this.cboTipDocRevCred);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(497, 93);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del documento";
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDoc.BackgroundImage")));
            this.btnAddDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDoc.Location = new System.Drawing.Point(447, 54);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(36, 28);
            this.btnAddDoc.TabIndex = 1;
            this.btnAddDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Enabled = false;
            this.txtDocumento.Location = new System.Drawing.Point(129, 58);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(312, 20);
            this.txtDocumento.TabIndex = 3;
            // 
            // cboTipDocRevCred
            // 
            this.cboTipDocRevCred.DisplayMember = "cTipDocRevCred";
            this.cboTipDocRevCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocRevCred.FormattingEnabled = true;
            this.cboTipDocRevCred.Location = new System.Drawing.Point(129, 31);
            this.cboTipDocRevCred.Name = "cboTipDocRevCred";
            this.cboTipDocRevCred.Size = new System.Drawing.Size(354, 21);
            this.cboTipDocRevCred.TabIndex = 0;
            this.cboTipDocRevCred.ValueMember = "idTipDocRevCred";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(51, 62);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(77, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Documento:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 34);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(103, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo documento:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(383, 102);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(449, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAddDocRevCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 183);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase1);
            this.Name = "FrmAddDocRevCred";
            this.Text = "Agregar documento";
            this.Load += new System.EventHandler(this.AddDocRevCred_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private grbBase grbBase1;
        private BotonesBase.btnMiniAgregar btnAddDoc;
        private txtBase txtDocumento;
        private cboTipDocRevCred cboTipDocRevCred;
        private lblBase lblBase2;
        private lblBase lblBase1;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnCancelar btnCancelar;
    }
}