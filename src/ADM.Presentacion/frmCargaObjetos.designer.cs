namespace ADM.Presentacion
{
    partial class frmCargaObjetos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaObjetos));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conLoader1 = new GEN.ControlesBase.conLoader();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnProReportes = new GEN.BotonesBase.btnBlanco();
            this.btnFormularios = new GEN.BotonesBase.btnBlanco();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(275, 77);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conLoader1
            // 
            this.conLoader1.Active = false;
            this.conLoader1.Color = System.Drawing.Color.LightSlateGray;
            this.conLoader1.InnerCircleRadius = 8;
            this.conLoader1.Location = new System.Drawing.Point(132, 12);
            this.conLoader1.Name = "conLoader1";
            this.conLoader1.NumberSpoke = 12;
            this.conLoader1.OuterCircleRadius = 17;
            this.conLoader1.RotationSpeed = 80;
            this.conLoader1.Size = new System.Drawing.Size(146, 59);
            this.conLoader1.SpokeThickness = 2;
            this.conLoader1.StylePreset = GEN.ControlesBase.conLoader.StylePresets.MacOSX;
            this.conLoader1.TabIndex = 0;
            this.conLoader1.Text = "conLoader1";
            this.conLoader1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnProReportes
            // 
            this.btnProReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProReportes.Location = new System.Drawing.Point(173, 77);
            this.btnProReportes.Name = "btnProReportes";
            this.btnProReportes.Size = new System.Drawing.Size(60, 50);
            this.btnProReportes.TabIndex = 4;
            this.btnProReportes.Text = "Reportes";
            this.btnProReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProReportes.UseVisualStyleBackColor = true;
            this.btnProReportes.Click += new System.EventHandler(this.btnProReportes_Click);
            // 
            // btnFormularios
            // 
            this.btnFormularios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFormularios.Location = new System.Drawing.Point(71, 77);
            this.btnFormularios.Name = "btnFormularios";
            this.btnFormularios.Size = new System.Drawing.Size(60, 50);
            this.btnFormularios.TabIndex = 5;
            this.btnFormularios.Text = "Forms";
            this.btnFormularios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFormularios.UseVisualStyleBackColor = true;
            this.btnFormularios.Click += new System.EventHandler(this.btnFormularios_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // frmCargaObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 173);
            this.Controls.Add(this.btnFormularios);
            this.Controls.Add(this.btnProReportes);
            this.Controls.Add(this.conLoader1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmCargaObjetos";
            this.Text = "Carga Formularios y Reportes en la Base de Datos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conLoader1, 0);
            this.Controls.SetChildIndex(this.btnProReportes, 0);
            this.Controls.SetChildIndex(this.btnFormularios, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.conLoader conLoader1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GEN.BotonesBase.btnBlanco btnProReportes;
        private GEN.BotonesBase.btnBlanco btnFormularios;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

