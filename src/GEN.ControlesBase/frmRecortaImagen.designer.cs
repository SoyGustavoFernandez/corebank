namespace GEN.ControlesBase
{
    partial class frmRecortaImagen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecortaImagen));
            this.ptbImgCrop = new System.Windows.Forms.PictureBox();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.splImg = new System.Windows.Forms.SplitContainer();
            this.btnCortar1 = new GEN.BotonesBase.btnCortar();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImgCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splImg)).BeginInit();
            this.splImg.Panel1.SuspendLayout();
            this.splImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbImgCrop
            // 
            this.ptbImgCrop.Location = new System.Drawing.Point(11, 32);
            this.ptbImgCrop.Name = "ptbImgCrop";
            this.ptbImgCrop.Size = new System.Drawing.Size(465, 329);
            this.ptbImgCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ptbImgCrop.TabIndex = 2;
            this.ptbImgCrop.TabStop = false;
            this.ptbImgCrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbImgCrop_MouseDown);
            this.ptbImgCrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbImgCrop_MouseMove);
            this.ptbImgCrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbImgCrop_MouseUp);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(542, 287);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(542, 231);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 6;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(542, 175);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 7;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // splImg
            // 
            this.splImg.Location = new System.Drawing.Point(23, 27);
            this.splImg.Name = "splImg";
            // 
            // splImg.Panel1
            // 
            this.splImg.Panel1.AutoScroll = true;
            this.splImg.Panel1.Controls.Add(this.ptbImgCrop);
            this.splImg.Size = new System.Drawing.Size(498, 381);
            this.splImg.SplitterDistance = 469;
            this.splImg.TabIndex = 8;
            // 
            // btnCortar1
            // 
            this.btnCortar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCortar1.BackgroundImage")));
            this.btnCortar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCortar1.Location = new System.Drawing.Point(542, 119);
            this.btnCortar1.Name = "btnCortar1";
            this.btnCortar1.Size = new System.Drawing.Size(60, 50);
            this.btnCortar1.TabIndex = 9;
            this.btnCortar1.Text = "Recor&tar";
            this.btnCortar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCortar1.UseVisualStyleBackColor = true;
            this.btnCortar1.Click += new System.EventHandler(this.btnCortar1_Click);
            // 
            // frmRecortaImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 444);
            this.Controls.Add(this.btnCortar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.splImg);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Name = "frmRecortaImagen";
            this.Text = "Formulario Recortar Imagen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.splImg, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCortar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImgCrop)).EndInit();
            this.splImg.Panel1.ResumeLayout(false);
            this.splImg.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splImg)).EndInit();
            this.splImg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox ptbImgCrop;
        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.btnCancelar btnCancelar1;
        private BotonesBase.btnGrabar btnGrabar1;
        private System.Windows.Forms.SplitContainer splImg;
        private BotonesBase.btnCortar btnCortar1;
    }
}

