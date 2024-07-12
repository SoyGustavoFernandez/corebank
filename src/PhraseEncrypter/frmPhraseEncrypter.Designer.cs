namespace PhraseEncrypter
{
    partial class frmPhraseEncrypter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhraseEncrypter));
            this.contentLabel = new System.Windows.Forms.Label();
            this.contentText = new System.Windows.Forms.TextBox();
            this.contentEncryptedText = new System.Windows.Forms.TextBox();
            this.contentEncryptedLabel = new System.Windows.Forms.Label();
            this.visible = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(13, 13);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(55, 13);
            this.contentLabel.TabIndex = 0;
            this.contentLabel.Text = "Contenido";
            // 
            // contentText
            // 
            this.contentText.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentText.Location = new System.Drawing.Point(13, 30);
            this.contentText.Name = "contentText";
            this.contentText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentText.Size = new System.Drawing.Size(546, 25);
            this.contentText.TabIndex = 1;
            this.contentText.TextChanged += new System.EventHandler(this.contentText_TextChanged);
            this.contentText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contentText_KeyPress);
            // 
            // contentEncryptedText
            // 
            this.contentEncryptedText.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentEncryptedText.Location = new System.Drawing.Point(13, 83);
            this.contentEncryptedText.Multiline = true;
            this.contentEncryptedText.Name = "contentEncryptedText";
            this.contentEncryptedText.ReadOnly = true;
            this.contentEncryptedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentEncryptedText.Size = new System.Drawing.Size(546, 73);
            this.contentEncryptedText.TabIndex = 3;
            this.contentEncryptedText.Click += new System.EventHandler(this.contentEncryptedText_Enter);
            this.contentEncryptedText.Enter += new System.EventHandler(this.contentEncryptedText_Enter);
            // 
            // contentEncryptedLabel
            // 
            this.contentEncryptedLabel.AutoSize = true;
            this.contentEncryptedLabel.Location = new System.Drawing.Point(13, 66);
            this.contentEncryptedLabel.Name = "contentEncryptedLabel";
            this.contentEncryptedLabel.Size = new System.Drawing.Size(109, 13);
            this.contentEncryptedLabel.TabIndex = 2;
            this.contentEncryptedLabel.Text = "Contenido Encriptado";
            // 
            // visible
            // 
            this.visible.AutoSize = true;
            this.visible.Location = new System.Drawing.Point(503, 12);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(56, 17);
            this.visible.TabIndex = 4;
            this.visible.Text = "Visible";
            this.visible.UseVisualStyleBackColor = true;
            this.visible.CheckedChanged += new System.EventHandler(this.visible_CheckedChanged);
            // 
            // frmPhraseEncrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(571, 167);
            this.Controls.Add(this.visible);
            this.Controls.Add(this.contentEncryptedText);
            this.Controls.Add(this.contentEncryptedLabel);
            this.Controls.Add(this.contentText);
            this.Controls.Add(this.contentLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPhraseEncrypter";
            this.Text = "Encriptador de Frase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.TextBox contentText;
        private System.Windows.Forms.TextBox contentEncryptedText;
        private System.Windows.Forms.Label contentEncryptedLabel;
        private System.Windows.Forms.CheckBox visible;
    }
}

