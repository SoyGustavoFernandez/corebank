namespace RCP.Presentacion
{
    partial class frmFinalizarRegResultadosHojaRuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinalizarRegResultadosHojaRuta));
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtKilometrajeFinal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.SuspendLayout();
            // 
            // txtBase1
            // 
            this.txtBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(13, 13);
            this.txtBase1.Multiline = true;
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(415, 38);
            this.txtBase1.TabIndex = 2;
            this.txtBase1.Text = "Usted completo el registro de los registro de resultados de la hoja de ruta, para" +
    " finalizar ingrese su Kilometraje final y haga click en aceptar.";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(87, 58);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(108, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Kilometraje Final:";
            // 
            // txtKilometrajeFinal
            // 
            this.txtKilometrajeFinal.Location = new System.Drawing.Point(201, 55);
            this.txtKilometrajeFinal.MaxLength = 6;
            this.txtKilometrajeFinal.Name = "txtKilometrajeFinal";
            this.txtKilometrajeFinal.Size = new System.Drawing.Size(169, 20);
            this.txtKilometrajeFinal.TabIndex = 0;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(201, 81);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 1;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(267, 81);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 2;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // frmFinalizarRegResultadosHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 161);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.txtKilometrajeFinal);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtBase1);
            this.Name = "frmFinalizarRegResultadosHojaRuta";
            this.Text = "Finalizar Registro Resultados HojaRuta";
            this.Load += new System.EventHandler(this.frmFinalizarRegResultadosHojaRuta_Load);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtKilometrajeFinal, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtKilometrajeFinal;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;

    }
}