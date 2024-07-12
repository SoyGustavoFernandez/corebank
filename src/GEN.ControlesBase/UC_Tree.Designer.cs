namespace GEN.ControlesBase
{
    partial class UC_Tree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Tree));
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvMenu
            // 
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMenu.ImageIndex = 2;
            this.tvMenu.ImageList = this.imgMenu;
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.SelectedImageKey = "Adobe Acrobat Reader.ico";
            this.tvMenu.Size = new System.Drawing.Size(182, 214);
            this.tvMenu.TabIndex = 0;
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu.Images.SetKeyName(0, "Switch.png");
            this.imgMenu.Images.SetKeyName(1, "btn_agregar.gif");
            this.imgMenu.Images.SetKeyName(2, "Adobe Acrobat Standard.ico");
            this.imgMenu.Images.SetKeyName(3, "Adobe Acrobat Reader.ico");
            this.imgMenu.Images.SetKeyName(4, "Jo.ico");
            // 
            // UC_Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvMenu);
            this.Name = "UC_Tree";
            this.Size = new System.Drawing.Size(182, 214);
            this.Load += new System.EventHandler(this.UC_Tree_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.ImageList imgMenu;

    }
}
