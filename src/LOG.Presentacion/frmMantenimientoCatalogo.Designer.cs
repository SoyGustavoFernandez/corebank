namespace LOG.Presentacion
{
    partial class frmMantenimientoCatalogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoCatalogo));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboTipoBien = new GEN.ControlesBase.cboTipoBien(this.components);
            this.conTreeCatalogo = new GEN.ControlesBase.conTreeCatalogo();
            this.grbCatalogo = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboUniMedCom = new GEN.ControlesBase.cboUnidadMedida(this.components);
            this.txtCodigo = new GEN.ControlesBase.txtCBLetra(this.components);
            this.cboUniMedAlm = new GEN.ControlesBase.cboUnidadMedida(this.components);
            this.chcActivo = new GEN.ControlesBase.chcBase(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtValCon = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblRubro = new GEN.ControlesBase.lblBase();
            this.lblSubGrupo = new GEN.ControlesBase.lblBase();
            this.lblGrupo = new GEN.ControlesBase.lblBase();
            this.txtNombre = new GEN.ControlesBase.txtCBLetra(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtContable = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblNiv = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnDebe = new System.Windows.Forms.Button();
            this.txtBuscar1 = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoNivel = new GEN.ControlesBase.cboNivelMenu(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.grbCatalogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(65, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo Bien:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(125, 3);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(691, 254);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboTipoBien
            // 
            this.cboTipoBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBien.FormattingEnabled = true;
            this.cboTipoBien.Location = new System.Drawing.Point(75, 8);
            this.cboTipoBien.Name = "cboTipoBien";
            this.cboTipoBien.Size = new System.Drawing.Size(225, 21);
            this.cboTipoBien.TabIndex = 1;
            this.cboTipoBien.SelectedIndexChanged += new System.EventHandler(this.cboTipoBien_SelectedIndexChanged);
            // 
            // conTreeCatalogo
            // 
            this.conTreeCatalogo.Location = new System.Drawing.Point(8, 61);
            this.conTreeCatalogo.Name = "conTreeCatalogo";
            this.conTreeCatalogo.Size = new System.Drawing.Size(292, 185);
            this.conTreeCatalogo.TabIndex = 4;
            this.conTreeCatalogo.Load += new System.EventHandler(this.conTreeCatalogo_Load);
            this.conTreeCatalogo.DragDrop += new System.Windows.Forms.DragEventHandler(this.conTreeCatalogo_DragDrop);
            this.conTreeCatalogo.DragEnter += new System.Windows.Forms.DragEventHandler(this.conTreeCatalogo_DragEnter);
            // 
            // grbCatalogo
            // 
            this.grbCatalogo.Controls.Add(this.lblBase4);
            this.grbCatalogo.Controls.Add(this.cboUniMedCom);
            this.grbCatalogo.Controls.Add(this.txtCodigo);
            this.grbCatalogo.Controls.Add(this.cboUniMedAlm);
            this.grbCatalogo.Controls.Add(this.chcActivo);
            this.grbCatalogo.Controls.Add(this.txtDescripcion);
            this.grbCatalogo.Controls.Add(this.lblBase8);
            this.grbCatalogo.Controls.Add(this.txtValCon);
            this.grbCatalogo.Controls.Add(this.lblBase7);
            this.grbCatalogo.Controls.Add(this.lblBase6);
            this.grbCatalogo.Controls.Add(this.lblBase9);
            this.grbCatalogo.Location = new System.Drawing.Point(309, 96);
            this.grbCatalogo.Name = "grbCatalogo";
            this.grbCatalogo.Size = new System.Drawing.Size(450, 150);
            this.grbCatalogo.TabIndex = 7;
            this.grbCatalogo.TabStop = false;
            this.grbCatalogo.Text = "Datos Catalogo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(7, 19);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 50;
            this.lblBase4.Text = "Código:";
            // 
            // cboUniMedCom
            // 
            this.cboUniMedCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUniMedCom.FormattingEnabled = true;
            this.cboUniMedCom.Location = new System.Drawing.Point(130, 38);
            this.cboUniMedCom.Name = "cboUniMedCom";
            this.cboUniMedCom.Size = new System.Drawing.Size(110, 21);
            this.cboUniMedCom.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(130, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(110, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // cboUniMedAlm
            // 
            this.cboUniMedAlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUniMedAlm.FormattingEnabled = true;
            this.cboUniMedAlm.Location = new System.Drawing.Point(130, 62);
            this.cboUniMedAlm.Name = "cboUniMedAlm";
            this.cboUniMedAlm.Size = new System.Drawing.Size(110, 21);
            this.cboUniMedAlm.TabIndex = 2;
            // 
            // chcActivo
            // 
            this.chcActivo.AutoSize = true;
            this.chcActivo.ForeColor = System.Drawing.Color.Navy;
            this.chcActivo.Location = new System.Drawing.Point(254, 17);
            this.chcActivo.Name = "chcActivo";
            this.chcActivo.Size = new System.Drawing.Size(124, 17);
            this.chcActivo.TabIndex = 4;
            this.chcActivo.Text = "Habilitar / Desahilitar";
            this.chcActivo.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(130, 86);
            this.txtDescripcion.MaxLength = 150;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(312, 58);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(7, 90);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(78, 13);
            this.lblBase8.TabIndex = 26;
            this.lblBase8.Text = "Descripción:";
            // 
            // txtValCon
            // 
            this.txtValCon.FormatoDecimal = true;
            this.txtValCon.Location = new System.Drawing.Point(348, 62);
            this.txtValCon.Name = "txtValCon";
            this.txtValCon.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValCon.nNumDecimales = 2;
            this.txtValCon.nvalor = 0D;
            this.txtValCon.Size = new System.Drawing.Size(94, 20);
            this.txtValCon.TabIndex = 5;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(252, 66);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(98, 13);
            this.lblBase7.TabIndex = 24;
            this.lblBase7.Text = "Val.Conversión:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(7, 42);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(119, 13);
            this.lblBase6.TabIndex = 22;
            this.lblBase6.Text = "Unidad de Compra:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(7, 66);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(122, 13);
            this.lblBase9.TabIndex = 19;
            this.lblBase9.Text = "Unidad Almacenaje:";
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblRubro.ForeColor = System.Drawing.Color.Navy;
            this.lblRubro.Location = new System.Drawing.Point(6, 17);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(46, 13);
            this.lblRubro.TabIndex = 33;
            this.lblRubro.Text = "Rubro:";
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSubGrupo.ForeColor = System.Drawing.Color.Navy;
            this.lblSubGrupo.Location = new System.Drawing.Point(6, 18);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(73, 13);
            this.lblSubGrupo.TabIndex = 32;
            this.lblSubGrupo.Text = "Sub Grupo:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblGrupo.ForeColor = System.Drawing.Color.Navy;
            this.lblGrupo.Location = new System.Drawing.Point(6, 18);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(47, 13);
            this.lblGrupo.TabIndex = 36;
            this.lblGrupo.Text = "Grupo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(130, 14);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(312, 20);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(5, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(65, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(185, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGrabar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Location = new System.Drawing.Point(441, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 57);
            this.panel1.TabIndex = 8;
            // 
            // txtContable
            // 
            this.txtContable.Location = new System.Drawing.Point(130, 37);
            this.txtContable.Name = "txtContable";
            this.txtContable.Size = new System.Drawing.Size(292, 20);
            this.txtContable.TabIndex = 6;
            this.txtContable.TextChanged += new System.EventHandler(this.txtContable_TextChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 41);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(108, 13);
            this.lblBase2.TabIndex = 46;
            this.lblBase2.Text = "Cuenta Contable:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 35);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Buscar:";
            // 
            // lblNiv
            // 
            this.lblNiv.AutoSize = true;
            this.lblNiv.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNiv.ForeColor = System.Drawing.Color.Navy;
            this.lblNiv.Location = new System.Drawing.Point(12, 249);
            this.lblNiv.Name = "lblNiv";
            this.lblNiv.Size = new System.Drawing.Size(14, 13);
            this.lblNiv.TabIndex = 47;
            this.lblNiv.Text = "_";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnDebe);
            this.grbBase1.Controls.Add(this.lblGrupo);
            this.grbBase1.Controls.Add(this.lblSubGrupo);
            this.grbBase1.Controls.Add(this.lblRubro);
            this.grbBase1.Controls.Add(this.txtNombre);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtContable);
            this.grbBase1.Location = new System.Drawing.Point(309, 25);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(450, 65);
            this.grbBase1.TabIndex = 48;
            this.grbBase1.TabStop = false;
            // 
            // btnDebe
            // 
            this.btnDebe.Location = new System.Drawing.Point(428, 35);
            this.btnDebe.Name = "btnDebe";
            this.btnDebe.Size = new System.Drawing.Size(14, 23);
            this.btnDebe.TabIndex = 47;
            this.btnDebe.Text = ":";
            this.btnDebe.UseVisualStyleBackColor = true;
            this.btnDebe.Click += new System.EventHandler(this.btnDebe_Click);
            // 
            // txtBuscar1
            // 
            this.txtBuscar1.Location = new System.Drawing.Point(75, 33);
            this.txtBuscar1.Name = "txtBuscar1";
            this.txtBuscar1.Size = new System.Drawing.Size(225, 20);
            this.txtBuscar1.TabIndex = 49;
            this.txtBuscar1.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // cboTipoNivel
            // 
            this.cboTipoNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoNivel.FormattingEnabled = true;
            this.cboTipoNivel.Location = new System.Drawing.Point(439, 8);
            this.cboTipoNivel.Name = "cboTipoNivel";
            this.cboTipoNivel.Size = new System.Drawing.Size(121, 21);
            this.cboTipoNivel.TabIndex = 51;
            this.cboTipoNivel.SelectedIndexChanged += new System.EventHandler(this.cboNivelMenu_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(316, 12);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(86, 13);
            this.lblBase5.TabIndex = 50;
            this.lblBase5.Text = "Tipo de Nivel:";
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.Location = new System.Drawing.Point(240, 252);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(60, 50);
            this.btnCatalogo.TabIndex = 52;
            this.btnCatalogo.Text = "Reasigna Bienes";
            this.btnCatalogo.UseVisualStyleBackColor = true;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // frmMantenimientoCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 335);
            this.Controls.Add(this.btnCatalogo);
            this.Controls.Add(this.cboTipoNivel);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtBuscar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblNiv);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.conTreeCatalogo);
            this.Controls.Add(this.cboTipoBien);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbCatalogo);
            this.Name = "frmMantenimientoCatalogo";
            this.Text = "Mantenimiento de Catalogos";
            this.Load += new System.EventHandler(this.frmMantenimientoGrupos_Load);
            this.Controls.SetChildIndex(this.grbCatalogo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoBien, 0);
            this.Controls.SetChildIndex(this.conTreeCatalogo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblNiv, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.txtBuscar1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboTipoNivel, 0);
            this.Controls.SetChildIndex(this.btnCatalogo, 0);
            this.grbCatalogo.ResumeLayout(false);
            this.grbCatalogo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.cboTipoBien cboTipoBien;
        private GEN.ControlesBase.conTreeCatalogo conTreeCatalogo;
        private GEN.ControlesBase.grbBase grbCatalogo;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtValCon;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblRubro;
        private GEN.ControlesBase.lblBase lblSubGrupo;
        private GEN.ControlesBase.lblBase lblGrupo;
        private GEN.ControlesBase.txtCBLetra txtNombre;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.chcBase chcActivo;
        private GEN.ControlesBase.txtCBLetra txtContable;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboUnidadMedida cboUniMedCom;
        private GEN.ControlesBase.cboUnidadMedida cboUniMedAlm;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtCBLetra txtCodigo;
        private GEN.ControlesBase.lblBase lblNiv;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtBuscar1;
        private GEN.ControlesBase.cboNivelMenu cboTipoNivel;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.Button btnDebe;
        private System.Windows.Forms.Button btnCatalogo;
    }
}