namespace ADM.Presentacion
{
    partial class frmMantPerfilMenu
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
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantPerfilMenu));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboModulo1 = new GEN.ControlesBase.cboModulo(this.components);
            this.cboListaPerfil1 = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.trvchMenu = new GEN.ControlesBase.TreeviewCbx();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboModulo1);
            this.grbBase1.Controls.Add(this.cboListaPerfil1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(433, 46);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.DropDownWidth = 200;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(275, 13);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(150, 21);
            this.cboModulo1.TabIndex = 2;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // cboListaPerfil1
            // 
            this.cboListaPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil1.DropDownWidth = 250;
            this.cboListaPerfil1.FormattingEnabled = true;
            this.cboListaPerfil1.Location = new System.Drawing.Point(3, 13);
            this.cboListaPerfil1.Name = "cboListaPerfil1";
            this.cboListaPerfil1.Size = new System.Drawing.Size(263, 21);
            this.cboListaPerfil1.TabIndex = 0;
            this.cboListaPerfil1.SelectedIndexChanged += new System.EventHandler(this.cboListaPerfil1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(0, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(106, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Seleccione Perfil:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(272, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(117, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Seleccione Módulo:";
            // 
            // trvchMenu
            // 
            this.trvchMenu.CheckBoxes = true;
            this.trvchMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.trvchMenu.Enabled = false;
            this.trvchMenu.Location = new System.Drawing.Point(12, 64);
            this.trvchMenu.Name = "trvchMenu";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Node1";
            treeNode7.Name = "Node2";
            treeNode7.Text = "Node2";
            treeNode8.Name = "Node0";
            treeNode8.Text = "Node0";
            treeNode9.Name = "Node4";
            treeNode9.Text = "Node4";
            treeNode10.Name = "Node3";
            treeNode10.Text = "Node3";
            this.trvchMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode10});
            this.trvchMenu.Size = new System.Drawing.Size(433, 511);
            this.trvchMenu.TabIndex = 3;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(460, 64);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 4;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(460, 120);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(460, 176);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(460, 525);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmMantPerfilMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 604);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.trvchMenu);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantPerfilMenu";
            this.Text = "Mantenimiento de opciones de menú por Perfil";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.trvchMenu, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboListaPerfil cboListaPerfil1;
        private GEN.ControlesBase.cboModulo cboModulo1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.TreeviewCbx trvchMenu;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}

