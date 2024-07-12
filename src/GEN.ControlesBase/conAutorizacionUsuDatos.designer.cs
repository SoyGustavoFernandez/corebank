namespace GEN.ControlesBase
{
    partial class conAutorizacionUsuDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conAutorizacionUsuDatos));
            this.btnAutorizaDatos = new GEN.BotonesBase.Boton2();
            this.ttpToolTipAutorizacion = new GEN.ControlesBase.ttpToolTip();
            this.SuspendLayout();
            // 
            // btnAutorizaDatos
            // 
            this.btnAutorizaDatos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAutorizaDatos.BackgroundImage")));
            this.btnAutorizaDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutorizaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutorizaDatos.Location = new System.Drawing.Point(0, 0);
            this.btnAutorizaDatos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAutorizaDatos.Name = "btnAutorizaDatos";
            this.btnAutorizaDatos.Size = new System.Drawing.Size(36, 28);
            this.btnAutorizaDatos.TabIndex = 14;
            this.btnAutorizaDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAutorizaDatos.UseVisualStyleBackColor = true;
            this.btnAutorizaDatos.Click += new System.EventHandler(this.btnAutorizaDatos_Click);
            // 
            // conAutorizacionUsuDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnAutorizaDatos);
            this.Name = "conAutorizacionUsuDatos";
            this.Size = new System.Drawing.Size(36, 28);
            this.Load += new System.EventHandler(this.conAutorizacionUsuDatos_Load);
            this.ResumeLayout(false);

        }

        #endregion
         
        private BotonesBase.Boton2 btnAutorizaDatos;
        private ttpToolTip ttpToolTipAutorizacion;
    }
}
