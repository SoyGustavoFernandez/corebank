using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConActividadCIIUSimp : UserControl
    {
        #region Variable Globales

        clsCNListaActivEco cnactividad = new clsCNListaActivEco();

        #endregion
        public ConActividadCIIUSimp()
        {
            InitializeComponent();

            this.AutoSize = false;
            this.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
        }

        public ConActividadCIIUSimp(IContainer container)
        {
            InitializeComponent();

            container.Add(this);
            this.AutoSize = false;
            this.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
        }

        #region Eventos

        private void conActividadCIIU_Load(object sender, EventArgs e)
        {
            this.cboActividadEco.CargarActivEconomica(0);
            cboActividadInterna1.cargarVigentes();
            cboActividadInterna1.SelectedIndex = -1;
        }

        private void cboActividadInterna1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadInterna1.SelectedIndex > -1)
            {
                cargarActividadesInternas();
            }
        }

        private void cboActividadEco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadEco.SelectedValue is DataRowView) return;

            if (cboActividadEco.SelectedIndex > 0)
            {
                this.cboGrupoCiiu.CargarActivEconomica((int)cboActividadEco.SelectedValue);
                cboGrupoCiiu.Enabled = false;
                cboCIIU.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cboActividadEco.SelectedValue) > 0)
                {
                    cboGrupoCiiu.SelectedValue = 0;
                    cboGrupoCiiu.Enabled = true;
                    cboCIIU.Enabled = true;
                }
                else
                {
                    cboGrupoCiiu.SelectedIndex = -1;
                    cboGrupoCiiu.Enabled = false;
                    cboCIIU.Enabled = false;
                }
            }

        }

        private void cboGrupoCiiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoCiiu.SelectedValue is DataRowView) return;

            if (cboGrupoCiiu.SelectedIndex > -1)
            {
                if (cboGrupoCiiu.SelectedValue is DataRowView) return;

                this.cboCIIU.CargarActivEconomica((int)cboGrupoCiiu.SelectedValue);
                cboCIIU.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cboGrupoCiiu.SelectedValue) > 0)
                {
                    cboCIIU.SelectedValue = 0;
                    cboCIIU.Enabled = true;
                }
                else
                {
                    cboCIIU.SelectedIndex = -1;
                    cboCIIU.Enabled = false;
                }
            }
        }

        private void lblBase5_MouseHover(object sender, EventArgs e)
        {
            if (cboActividadEco.SelectedValue == null) return;

            this.ttpMensaje.ToolTipTitle = "";
            this.ttpMensaje.UseFading = true;
            this.ttpMensaje.UseAnimation = true;
            this.ttpMensaje.IsBalloon = true;
            this.ttpMensaje.ShowAlways = true;
            this.ttpMensaje.AutoPopDelay = 5000;
            this.ttpMensaje.InitialDelay = 300;
            this.ttpMensaje.ReshowDelay = 0;
        }

        private void lblBase6_MouseHover(object sender, EventArgs e)
        {
            if (cboGrupoCiiu.SelectedValue == null) return;

            this.ttpMensaje.ToolTipTitle = "";
            this.ttpMensaje.UseFading = true;
            this.ttpMensaje.UseAnimation = true;
            this.ttpMensaje.IsBalloon = true;
            this.ttpMensaje.ShowAlways = true;
            this.ttpMensaje.AutoPopDelay = 5000;
            this.ttpMensaje.InitialDelay = 300;
            this.ttpMensaje.ReshowDelay = 0;

        }

        private void lblBase3_MouseHover(object sender, EventArgs e)
        {
            if (cboCIIU.SelectedValue == null) return;

            var drCiiu = (DataRowView)cboCIIU.SelectedItem;
            var cCodSbs = drCiiu["cCodSbs"].ToString();

            this.ttpMensaje.ToolTipTitle = "CIIU : " + cCodSbs;
            this.ttpMensaje.UseFading = true;
            this.ttpMensaje.UseAnimation = true;
            this.ttpMensaje.IsBalloon = true;
            this.ttpMensaje.ShowAlways = true;
            this.ttpMensaje.AutoPopDelay = 5000;
            this.ttpMensaje.InitialDelay = 300;
            this.ttpMensaje.ReshowDelay = 0;

        }

        private void btnMiniBusqueda_Click(object sender, EventArgs e)
        {
            frmListaActivEcoInterna frmActivEco = new frmListaActivEcoInterna();
            frmActivEco.ShowDialog();
            if (frmActivEco.aceptado)
            {
                cboActividadInterna1.SelectedValue = frmActivEco.idActivEcoInt;
            }
            else
            {
                limpiarCombosCIIU();
            }
        }

        #endregion

        #region Métodos

        private void cargarActividadesInternas()
        {
            if (this.cboActividadInterna1.Items.Count > 0)
            {
                var drActividadInterna = (DataRowView)cboActividadInterna1.SelectedItem;
                var idActividad = Convert.ToInt32(drActividadInterna["idActividad"]);

                var dtActividad = cnactividad.CNListaActividadEspecifica(idActividad);
                if (dtActividad.Rows.Count > 0)
                {
                    var idPadreActividad = Convert.ToInt32(dtActividad.Rows[0]["idPadreActividad"]);
                    var dtActividad2 = cnactividad.CNListaActividadEspecifica(idPadreActividad);
                    var idPadreActividad2 = Convert.ToInt32(dtActividad2.Rows[0]["idPadreActividad"]);

                    this.cboActividadEco.SelectedIndex = -1;
                    this.cboActividadEco.SelectedValue = idPadreActividad2;
                    this.cboGrupoCiiu.SelectedIndex = -1;
                    this.cboGrupoCiiu.SelectedValue = idPadreActividad;
                    this.cboCIIU.SelectedValue = idActividad;
                }
            }
        }

        /// <summary>
        /// Método que realiza la asignación de los controles a partir del  CIIU
        /// </summary>
        /// <param name="idActividad">Código de Acitvidad CIIU</param>
        public void cargarActividades(int idActividad)
        {
            var dtActividad = cnactividad.CNListaActividadEspecifica(idActividad);
            if (dtActividad.Rows.Count > 0)
            {
                var idPadreActividad = Convert.ToInt32(dtActividad.Rows[0]["idPadreActividad"]);

                var dtActividad2 = cnactividad.CNListaActividadEspecifica(idPadreActividad);
                var idPadreActividad2 = Convert.ToInt32(dtActividad2.Rows[0]["idPadreActividad"]);

                this.cboActividadEco.SelectedValue = idPadreActividad2;
                this.cboGrupoCiiu.SelectedValue = idPadreActividad;
                this.cboCIIU.SelectedValue = idActividad;
                cboActividadInterna1.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Método que realiza la asignación de los controles a partir de la actividad interna de la empresa
        /// </summary>
        /// <param name="idActividadInterna">Código de Acitvidad Interna</param>
        public void cargarActividadInterna(int idActividadInterna)
        {
            var listItems = ((DataTable)this.cboActividadInterna1.DataSource).AsEnumerable().Where(x => (int)x["idActividadInterna"] == idActividadInterna).ToList();
            if (listItems.Count > 0)
            {
                var drActividadInterna = listItems[0];
                cboActividadInterna1.SelectedValue = Convert.ToInt32(drActividadInterna["idActividadInterna"]);
            }
        }

        public void limpiarCombosCIIU()
        {
            cboActividadInterna1.SelectedIndex = -1;
            cboActividadEco.SelectedIndex = -1;
            cboGrupoCiiu.SelectedIndex = -1;
            cboCIIU.SelectedIndex = -1;
        }

        #endregion
    }
}
