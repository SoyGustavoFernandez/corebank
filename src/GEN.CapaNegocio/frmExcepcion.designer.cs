using System.Windows.Forms;
namespace GEN.CapaNegocio
{
    partial class frmExcepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcepcion));
            this.lblDescExcep = new System.Windows.Forms.Label();
            this.txtSustento = new System.Windows.Forms.TextBox();
            this.btnAceptar1 = new System.Windows.Forms.Button();
            this.btnCancelar1 = new System.Windows.Forms.Button();
            this.rbtExcepcion = new System.Windows.Forms.RadioButton();
            this.rbtNoExcepcion = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblDescExcep
            // 
            this.lblDescExcep.AutoSize = true;
            this.lblDescExcep.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescExcep.ForeColor = System.Drawing.Color.Navy;
            this.lblDescExcep.Location = new System.Drawing.Point(22, 13);
            this.lblDescExcep.Name = "lblDescExcep";
            this.lblDescExcep.Size = new System.Drawing.Size(215, 13);
            this.lblDescExcep.TabIndex = 2;
            this.lblDescExcep.Text = "Ingrese SUSTENTO DE EXCEPCIÓN:";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(12, 86);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(460, 100);
            this.txtSustento.TabIndex = 3;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(142, 194);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(288, 194);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            // 
            // rbtExcepcion
            // 
            this.rbtExcepcion.AutoSize = true;
            this.rbtExcepcion.Checked = true;
            this.rbtExcepcion.ForeColor = System.Drawing.Color.Navy;
            this.rbtExcepcion.Location = new System.Drawing.Point(25, 39);
            this.rbtExcepcion.Name = "rbtExcepcion";
            this.rbtExcepcion.Size = new System.Drawing.Size(75, 17);
            this.rbtExcepcion.TabIndex = 6;
            this.rbtExcepcion.TabStop = true;
            this.rbtExcepcion.Text = "Excepción";
            this.rbtExcepcion.UseVisualStyleBackColor = true;
            // 
            // rbtNoExcepcion
            // 
            this.rbtNoExcepcion.AutoSize = true;
            this.rbtNoExcepcion.ForeColor = System.Drawing.Color.Navy;
            this.rbtNoExcepcion.Location = new System.Drawing.Point(25, 62);
            this.rbtNoExcepcion.Name = "rbtNoExcepcion";
            this.rbtNoExcepcion.Size = new System.Drawing.Size(361, 17);
            this.rbtNoExcepcion.TabIndex = 6;
            this.rbtNoExcepcion.Text = "No se considera excepción ya que cumple con la regla y tiene sustento";
            this.rbtNoExcepcion.UseVisualStyleBackColor = true;
            // 
            // frmExcepcion
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 260);
            this.ControlBox = false;
            this.Controls.Add(this.rbtNoExcepcion);
            this.Controls.Add(this.rbtExcepcion);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblDescExcep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmExcepcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmExcepcion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDescExcep;
        private TextBox txtSustento;
        private Button btnAceptar1;
        private Button btnCancelar1;
        private System.Windows.Forms.RadioButton rbtExcepcion;
        private System.Windows.Forms.RadioButton rbtNoExcepcion;

    }
}

