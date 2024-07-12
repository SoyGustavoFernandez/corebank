namespace GEN.ControlesBase
{
    partial class ConBusGrupoSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConBusGrupoSol));
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombreGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdGrupoSolidario = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboTipoGrupoSolidario1 = new GEN.ControlesBase.cboTipoGrupoSolidario(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboGrupoSolidarioCiclo1 = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(553, 0);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 3;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(64, 26);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(483, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Location = new System.Drawing.Point(133, 4);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(414, 20);
            this.txtNombreGrupo.TabIndex = 1;
            this.txtNombreGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreGrupo_KeyDown);
            // 
            // txtIdGrupoSolidario
            // 
            this.txtIdGrupoSolidario.Format = "n0";
            this.txtIdGrupoSolidario.Location = new System.Drawing.Point(64, 4);
            this.txtIdGrupoSolidario.Name = "txtIdGrupoSolidario";
            this.txtIdGrupoSolidario.Size = new System.Drawing.Size(70, 20);
            this.txtIdGrupoSolidario.TabIndex = 0;
            this.txtIdGrupoSolidario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdGrupoSolidario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdGrupoSolidario_KeyDown);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(2, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(60, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Dirección";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(20, 8);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(42, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Grupo";
            // 
            // cboTipoGrupoSolidario1
            // 
            this.cboTipoGrupoSolidario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGrupoSolidario1.Enabled = false;
            this.cboTipoGrupoSolidario1.FormattingEnabled = true;
            this.cboTipoGrupoSolidario1.Location = new System.Drawing.Point(273, 49);
            this.cboTipoGrupoSolidario1.Name = "cboTipoGrupoSolidario1";
            this.cboTipoGrupoSolidario1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoGrupoSolidario1.TabIndex = 17;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(197, 52);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Tipo Grupo:";
            // 
            // cboGrupoSolidarioCiclo1
            // 
            this.cboGrupoSolidarioCiclo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoSolidarioCiclo1.Enabled = false;
            this.cboGrupoSolidarioCiclo1.FormattingEnabled = true;
            this.cboGrupoSolidarioCiclo1.Location = new System.Drawing.Point(64, 49);
            this.cboGrupoSolidarioCiclo1.Name = "cboGrupoSolidarioCiclo1";
            this.cboGrupoSolidarioCiclo1.Size = new System.Drawing.Size(121, 21);
            this.cboGrupoSolidarioCiclo1.TabIndex = 19;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(22, 52);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(40, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Ciclo:";
            // 
            // ConBusGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboGrupoSolidarioCiclo1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboTipoGrupoSolidario1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombreGrupo);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.txtIdGrupoSolidario);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase4);
            this.Name = "ConBusGrupoSol";
            this.Size = new System.Drawing.Size(613, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase4;
        private lblBase lblBase1;
        public txtBase txtNombreGrupo;
        public txtNumerico txtIdGrupoSolidario;
        public BotonesBase.btnBusqueda btnBusqueda;
        public txtBase txtDireccion;
        private cboTipoGrupoSolidario cboTipoGrupoSolidario1;
        private lblBase lblBase2;
        private CboGrupoSolidarioCiclo cboGrupoSolidarioCiclo1;
        private lblBase lblBase3;
    }
}
