namespace SPL.Presentacion
{
    partial class frmRegistroFamiliar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroFamiliar));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombres = new GEN.ControlesBase.txtBase(this.components);
            this.txtPaterno = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMaterno = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.cboVinculo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtDocumento = new GEN.ControlesBase.txtCBDNI(this.components);
            this.cboTipDocumento1 = new GEN.ControlesBase.cboTipDocumento(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(63, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nombres:";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(123, 6);
            this.txtNombres.MaxLength = 50;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(264, 20);
            this.txtNombres.TabIndex = 0;
            this.txtNombres.Tag = "Nombres";
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            // 
            // txtPaterno
            // 
            this.txtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaterno.Location = new System.Drawing.Point(123, 32);
            this.txtPaterno.MaxLength = 50;
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(264, 20);
            this.txtPaterno.TabIndex = 1;
            this.txtPaterno.Tag = "Apellido Paterno";
            this.txtPaterno.TextChanged += new System.EventHandler(this.txtPaterno_TextChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 35);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Apellido Paterno:";
            // 
            // txtMaterno
            // 
            this.txtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterno.Location = new System.Drawing.Point(123, 58);
            this.txtMaterno.MaxLength = 50;
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(264, 20);
            this.txtMaterno.TabIndex = 2;
            this.txtMaterno.Tag = "Apellido Materno";
            this.txtMaterno.TextChanged += new System.EventHandler(this.txtMaterno_TextChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 61);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(107, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Apellido Materno:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(123, 84);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(264, 20);
            this.txtDireccion.TabIndex = 3;
            this.txtDireccion.Tag = "Dirección";
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 87);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Dirección:";
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(261, 192);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 7;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // cboVinculo
            // 
            this.cboVinculo.FormattingEnabled = true;
            this.cboVinculo.Location = new System.Drawing.Point(123, 165);
            this.cboVinculo.Name = "cboVinculo";
            this.cboVinculo.Size = new System.Drawing.Size(264, 21);
            this.cboVinculo.TabIndex = 6;
            this.cboVinculo.Tag = "Vínculo";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 168);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(53, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Vínculo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 142);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(77, 13);
            this.lblBase6.TabIndex = 8;
            this.lblBase6.Text = "Documento:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(327, 192);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(123, 139);
            this.txtDocumento.MaxLength = 8;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(264, 20);
            this.txtDocumento.TabIndex = 5;
            this.txtDocumento.Tag = "Documento";
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // cboTipDocumento1
            // 
            this.cboTipDocumento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocumento1.FormattingEnabled = true;
            this.cboTipDocumento1.Location = new System.Drawing.Point(123, 112);
            this.cboTipDocumento1.Name = "cboTipDocumento1";
            this.cboTipDocumento1.Size = new System.Drawing.Size(264, 21);
            this.cboTipDocumento1.TabIndex = 4;
            this.cboTipDocumento1.SelectedIndexChanged += new System.EventHandler(this.cboTipDocumento1_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 115);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(105, 13);
            this.lblBase7.TabIndex = 8;
            this.lblBase7.Text = "Tipo Documento:";
            // 
            // frmRegistroFamiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 284);
            this.Controls.Add(this.cboTipDocumento1);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboVinculo);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMaterno);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtPaterno);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmRegistroFamiliar";
            this.Text = "Registro de Familiar";
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtNombres, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtPaterno, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtMaterno, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.cboVinculo, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.txtDocumento, 0);
            this.Controls.SetChildIndex(this.cboTipDocumento1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtNombres;
        private GEN.ControlesBase.txtBase txtPaterno;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMaterno;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.cboBase cboVinculo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.txtCBDNI txtDocumento;
        private GEN.ControlesBase.cboTipDocumento cboTipDocumento1;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}