namespace GEN.ControlesBase
{
    partial class conTreeCentroCosto
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Sub Centro");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Centro de Costos", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conTreeCentroCosto));
            this.trvNavi = new System.Windows.Forms.TreeView();
            this.cmsMenuCta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cmsMenuCta.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvNavi
            // 
            this.trvNavi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvNavi.ImageIndex = 27;
            this.trvNavi.ImageList = this.imgList;
            this.trvNavi.Location = new System.Drawing.Point(0, 0);
            this.trvNavi.Name = "trvNavi";
            treeNode1.Name = "SubCentro";
            treeNode1.Text = "Sub Centro";
            treeNode2.Name = "CentroCostos";
            treeNode2.Text = "Centro de Costos";
            this.trvNavi.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.trvNavi.SelectedImageIndex = 0;
            this.trvNavi.Size = new System.Drawing.Size(316, 372);
            this.trvNavi.TabIndex = 0;
            // 
            // cmsMenuCta
            // 
            this.cmsMenuCta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem3,
            this.ToolStripMenuItem4,
            this.ToolStripMenuItem5});
            this.cmsMenuCta.Name = "ContextMenuStrip1";
            this.cmsMenuCta.ShowImageMargin = false;
            this.cmsMenuCta.Size = new System.Drawing.Size(104, 70);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(103, 22);
            this.ToolStripMenuItem3.Text = "Nuevo";
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(103, 22);
            this.ToolStripMenuItem4.Text = "Editar";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(103, 22);
            this.ToolStripMenuItem5.Text = "Desactivar";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "btn_aceptar.gif");
            this.imgList.Images.SetKeyName(1, "btn_aceptar.png");
            this.imgList.Images.SetKeyName(2, "btn_actualizar.gif");
            this.imgList.Images.SetKeyName(3, "btn_actualizar.png");
            this.imgList.Images.SetKeyName(4, "btn_agregar.gif");
            this.imgList.Images.SetKeyName(5, "btn_agregar.png");
            this.imgList.Images.SetKeyName(6, "btn_agusuario.gif");
            this.imgList.Images.SetKeyName(7, "btn_agusuario.png");
            this.imgList.Images.SetKeyName(8, "btn_anexar.gif");
            this.imgList.Images.SetKeyName(9, "btn_anexar.png");
            this.imgList.Images.SetKeyName(10, "btn_Calendar.gif");
            this.imgList.Images.SetKeyName(11, "btn_cancelar.gif");
            this.imgList.Images.SetKeyName(12, "btn_cancelar.png");
            this.imgList.Images.SetKeyName(13, "btn_descargar.gif");
            this.imgList.Images.SetKeyName(14, "btn_descargar.png");
            this.imgList.Images.SetKeyName(15, "btn_eliminar.gif");
            this.imgList.Images.SetKeyName(16, "btn_eliminar_.gif");
            this.imgList.Images.SetKeyName(17, "btn_eliminar_.png");
            this.imgList.Images.SetKeyName(18, "btn_examinar.gif");
            this.imgList.Images.SetKeyName(19, "btn_examinar.png");
            this.imgList.Images.SetKeyName(20, "btn_examinar1.png");
            this.imgList.Images.SetKeyName(21, "btn_filtrar.gif");
            this.imgList.Images.SetKeyName(22, "btn_filtrar.png");
            this.imgList.Images.SetKeyName(23, "btn_guardar.gif");
            this.imgList.Images.SetKeyName(24, "btn_guardar.png");
            this.imgList.Images.SetKeyName(25, "btn_imprimir.gif");
            this.imgList.Images.SetKeyName(26, "btn_imprimir.png");
            this.imgList.Images.SetKeyName(27, "btn_iniciar.gif");
            this.imgList.Images.SetKeyName(28, "btn_iniciar.png");
            this.imgList.Images.SetKeyName(29, "btn_modificar.gif");
            this.imgList.Images.SetKeyName(30, "btn_papelera.gif");
            this.imgList.Images.SetKeyName(31, "btn_papelera.png");
            this.imgList.Images.SetKeyName(32, "btn_personas.gif");
            this.imgList.Images.SetKeyName(33, "btn_personas.png");
            this.imgList.Images.SetKeyName(34, "btn_publicar.gif");
            this.imgList.Images.SetKeyName(35, "btn_publicar.png");
            this.imgList.Images.SetKeyName(36, "btn_reporte.gif");
            this.imgList.Images.SetKeyName(37, "btn_reporte.png");
            this.imgList.Images.SetKeyName(38, "btn_seleccionar.gif");
            this.imgList.Images.SetKeyName(39, "btn_seleccionar.png");
            this.imgList.Images.SetKeyName(40, "btn_ver.gif");
            this.imgList.Images.SetKeyName(41, "btn_ver.png");
            this.imgList.Images.SetKeyName(42, "btn_volver.gif");
            this.imgList.Images.SetKeyName(43, "btn_volver.png");
            this.imgList.Images.SetKeyName(44, "ico_excel.gif");
            this.imgList.Images.SetKeyName(45, "img_calendar.gif");
            this.imgList.Images.SetKeyName(46, "view_tree.png");
            // 
            // conTreeCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trvNavi);
            this.Name = "conTreeCentroCosto";
            this.Size = new System.Drawing.Size(316, 372);
            this.cmsMenuCta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView trvNavi;
        private System.Windows.Forms.ImageList imgList;
        public System.Windows.Forms.ContextMenuStrip cmsMenuCta;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem5;

    }
}
