namespace ADM.Presentacion
{
    partial class frmMantenimientoMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoMenu));
            this.cboModulo1 = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbDetMenu = new GEN.ControlesBase.grbBase(this.components);
            this.cboNivelMenu1 = new GEN.ControlesBase.cboNivelMenu(this.components);
            this.cboTipoMenu1 = new GEN.ControlesBase.cboTipoMenu(this.components);
            this.cboTipoControl1 = new GEN.ControlesBase.cboTipoControl(this.components);
            this.grbEstado = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnInactivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnActivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.txtnombreForm = new GEN.ControlesBase.txtBase(this.components);
            this.txtNameSpace = new GEN.ControlesBase.txtBase(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.txtOrden = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.chcBaseNegativa = new GEN.ControlesBase.chcBase(this.components);
            this.grbDetMenu.SuspendLayout();
            this.grbEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.DropDownWidth = 200;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(135, 19);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(139, 21);
            this.cboModulo1.TabIndex = 0;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(117, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Seleccione Módulo:";
            // 
            // grbDetMenu
            // 
            this.grbDetMenu.Controls.Add(this.chcBaseNegativa);
            this.grbDetMenu.Controls.Add(this.cboNivelMenu1);
            this.grbDetMenu.Controls.Add(this.cboTipoMenu1);
            this.grbDetMenu.Controls.Add(this.cboTipoControl1);
            this.grbDetMenu.Controls.Add(this.grbEstado);
            this.grbDetMenu.Controls.Add(this.txtnombreForm);
            this.grbDetMenu.Controls.Add(this.txtNameSpace);
            this.grbDetMenu.Controls.Add(this.txtDescripcion);
            this.grbDetMenu.Controls.Add(this.txtOrden);
            this.grbDetMenu.Controls.Add(this.lblBase5);
            this.grbDetMenu.Controls.Add(this.lblBase4);
            this.grbDetMenu.Controls.Add(this.lblBase9);
            this.grbDetMenu.Controls.Add(this.lblBase7);
            this.grbDetMenu.Controls.Add(this.lblBase6);
            this.grbDetMenu.Controls.Add(this.lblBase3);
            this.grbDetMenu.Controls.Add(this.lblBase8);
            this.grbDetMenu.Controls.Add(this.lblBase1);
            this.grbDetMenu.Enabled = false;
            this.grbDetMenu.Location = new System.Drawing.Point(333, 72);
            this.grbDetMenu.Name = "grbDetMenu";
            this.grbDetMenu.Size = new System.Drawing.Size(336, 357);
            this.grbDetMenu.TabIndex = 2;
            this.grbDetMenu.TabStop = false;
            this.grbDetMenu.Text = "Detalle Menú";
            // 
            // cboNivelMenu1
            // 
            this.cboNivelMenu1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelMenu1.FormattingEnabled = true;
            this.cboNivelMenu1.Location = new System.Drawing.Point(73, 19);
            this.cboNivelMenu1.Name = "cboNivelMenu1";
            this.cboNivelMenu1.Size = new System.Drawing.Size(121, 21);
            this.cboNivelMenu1.TabIndex = 0;
            // 
            // cboTipoMenu1
            // 
            this.cboTipoMenu1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMenu1.FormattingEnabled = true;
            this.cboTipoMenu1.Location = new System.Drawing.Point(132, 254);
            this.cboTipoMenu1.Name = "cboTipoMenu1";
            this.cboTipoMenu1.Size = new System.Drawing.Size(148, 21);
            this.cboTipoMenu1.TabIndex = 6;
            // 
            // cboTipoControl1
            // 
            this.cboTipoControl1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoControl1.FormattingEnabled = true;
            this.cboTipoControl1.Location = new System.Drawing.Point(132, 227);
            this.cboTipoControl1.Name = "cboTipoControl1";
            this.cboTipoControl1.Size = new System.Drawing.Size(148, 21);
            this.cboTipoControl1.TabIndex = 5;
            // 
            // grbEstado
            // 
            this.grbEstado.Controls.Add(this.rbtnInactivo);
            this.grbEstado.Controls.Add(this.rbtnActivo);
            this.grbEstado.Location = new System.Drawing.Point(132, 286);
            this.grbEstado.Name = "grbEstado";
            this.grbEstado.Size = new System.Drawing.Size(148, 30);
            this.grbEstado.TabIndex = 7;
            this.grbEstado.TabStop = false;
            // 
            // rbtnInactivo
            // 
            this.rbtnInactivo.AutoSize = true;
            this.rbtnInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnInactivo.Location = new System.Drawing.Point(67, 11);
            this.rbtnInactivo.Name = "rbtnInactivo";
            this.rbtnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbtnInactivo.TabIndex = 1;
            this.rbtnInactivo.TabStop = true;
            this.rbtnInactivo.Text = "Inactivo";
            this.rbtnInactivo.UseVisualStyleBackColor = true;
            // 
            // rbtnActivo
            // 
            this.rbtnActivo.AutoSize = true;
            this.rbtnActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnActivo.Location = new System.Drawing.Point(6, 11);
            this.rbtnActivo.Name = "rbtnActivo";
            this.rbtnActivo.Size = new System.Drawing.Size(55, 17);
            this.rbtnActivo.TabIndex = 0;
            this.rbtnActivo.TabStop = true;
            this.rbtnActivo.Text = "Activo";
            this.rbtnActivo.UseVisualStyleBackColor = true;
            // 
            // txtnombreForm
            // 
            this.txtnombreForm.Location = new System.Drawing.Point(23, 201);
            this.txtnombreForm.Name = "txtnombreForm";
            this.txtnombreForm.Size = new System.Drawing.Size(301, 20);
            this.txtnombreForm.TabIndex = 4;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(23, 162);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(301, 20);
            this.txtNameSpace.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(23, 105);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(301, 35);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtOrden
            // 
            this.txtOrden.FormatoDecimal = false;
            this.txtOrden.Location = new System.Drawing.Point(73, 58);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOrden.nNumDecimales = 0;
            this.txtOrden.nvalor = 0D;
            this.txtOrden.Size = new System.Drawing.Size(53, 20);
            this.txtOrden.TabIndex = 1;
            this.txtOrden.Text = "0";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(20, 185);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(141, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Nombre Form/Control :";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(20, 143);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(84, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Name Space:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(20, 299);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(54, 13);
            this.lblBase9.TabIndex = 15;
            this.lblBase9.Text = "Estado :";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(20, 262);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(94, 13);
            this.lblBase7.TabIndex = 14;
            this.lblBase7.Text = "Tipo de menú :";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(20, 230);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(101, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Tipo de control :";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(20, 89);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Descripción:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(20, 22);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(40, 13);
            this.lblBase8.TabIndex = 8;
            this.lblBase8.Text = "Nivel:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 61);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(47, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Orden:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(609, 447);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(411, 447);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 4;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(477, 447);
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
            this.btnGrabar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(543, 447);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // trvMenu
            // 
            this.trvMenu.ImageIndex = 2;
            this.trvMenu.ImageList = this.imgMenu;
            this.trvMenu.Location = new System.Drawing.Point(12, 49);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.SelectedImageIndex = 3;
            this.trvMenu.Size = new System.Drawing.Size(296, 448);
            this.trvMenu.TabIndex = 1;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenu_AfterSelect);
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
            // btnEditar1
            // 
            this.btnEditar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(345, 447);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // chcBaseNegativa
            // 
            this.chcBaseNegativa.AutoSize = true;
            this.chcBaseNegativa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcBaseNegativa.ForeColor = System.Drawing.Color.Navy;
            this.chcBaseNegativa.Location = new System.Drawing.Point(24, 334);
            this.chcBaseNegativa.Name = "chcBaseNegativa";
            this.chcBaseNegativa.Size = new System.Drawing.Size(180, 17);
            this.chcBaseNegativa.TabIndex = 16;
            this.chcBaseNegativa.Text = "Activar control de Base negativa";
            this.chcBaseNegativa.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 537);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.trvMenu);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbDetMenu);
            this.Controls.Add(this.cboModulo1);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmMantenimientoMenu";
            this.Text = "Mantenimiento de opciones del menú";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboModulo1, 0);
            this.Controls.SetChildIndex(this.grbDetMenu, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.trvMenu, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.grbDetMenu.ResumeLayout(false);
            this.grbDetMenu.PerformLayout();
            this.grbEstado.ResumeLayout(false);
            this.grbEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboModulo cboModulo1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbDetMenu;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private System.Windows.Forms.TreeView trvMenu;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.grbBase grbEstado;
        private GEN.ControlesBase.txtBase txtnombreForm;
        private GEN.ControlesBase.txtBase txtNameSpace;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.txtNumRea txtOrden;
        private GEN.ControlesBase.rbtnBase rbtnInactivo;
        private GEN.ControlesBase.rbtnBase rbtnActivo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.ImageList imgMenu;
        private GEN.ControlesBase.cboTipoMenu cboTipoMenu1;
        private GEN.ControlesBase.cboTipoControl cboTipoControl1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboNivelMenu cboNivelMenu1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.chcBase chcBaseNegativa;
    }
}

