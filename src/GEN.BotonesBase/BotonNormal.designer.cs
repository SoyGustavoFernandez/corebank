namespace GEN.BotonesBase
{
    partial class BotonNormal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BotonNormal
            // 
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MouseLeave += new System.EventHandler(this.BotonNormal_MouseLeave);
            this.MouseHover += new System.EventHandler(this.BotonNormal_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
