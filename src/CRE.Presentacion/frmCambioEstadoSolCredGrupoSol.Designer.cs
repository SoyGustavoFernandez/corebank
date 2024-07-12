namespace CRE.Presentacion
{
    partial class frmCambioEstadoSolCredGrupoSol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioEstadoSolCredGrupoSol));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.nudIdGrupoSol = new GEN.ControlesBase.nudBase(this.components);
            this.nudIdSolCredGrupoSol = new GEN.ControlesBase.nudBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudIdGrupoSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdSolCredGrupoSol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(44, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(81, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Num. Grupo:";
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Location = new System.Drawing.Point(109, 72);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 4;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(216, 72);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(18, 41);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(107, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Num. Sol. Grupo:";
            // 
            // nudIdGrupoSol
            // 
            this.nudIdGrupoSol.Location = new System.Drawing.Point(128, 14);
            this.nudIdGrupoSol.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nudIdGrupoSol.Name = "nudIdGrupoSol";
            this.nudIdGrupoSol.Size = new System.Drawing.Size(148, 20);
            this.nudIdGrupoSol.TabIndex = 7;
            // 
            // nudIdSolCredGrupoSol
            // 
            this.nudIdSolCredGrupoSol.Location = new System.Drawing.Point(128, 41);
            this.nudIdSolCredGrupoSol.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nudIdSolCredGrupoSol.Name = "nudIdSolCredGrupoSol";
            this.nudIdSolCredGrupoSol.Size = new System.Drawing.Size(148, 20);
            this.nudIdSolCredGrupoSol.TabIndex = 8;
            // 
            // frmCambioEstadoSolCredGrupoSol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 147);
            this.Controls.Add(this.nudIdSolCredGrupoSol);
            this.Controls.Add(this.nudIdGrupoSol);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmCambioEstadoSolCredGrupoSol";
            this.Text = "frmCambioEstadoSolCredGrupoSol";
            this.Load += new System.EventHandler(this.frmCambioEstadoSolCredGrupoSol_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.nudIdGrupoSol, 0);
            this.Controls.SetChildIndex(this.nudIdSolCredGrupoSol, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudIdGrupoSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdSolCredGrupoSol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.nudBase nudIdGrupoSol;
        private GEN.ControlesBase.nudBase nudIdSolCredGrupoSol;
    }
}