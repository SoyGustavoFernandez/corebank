using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using System.Data;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class conDatosReprogramacion : UserControl
    {
        public int idCuenta { get; set; }
        public bool lAlerta { get; set; }
        public bool lMostrarMontoCuota { get; set; }
        private bool lReprogramacion { get; set; }
        private bool lRetencion { get; set; }
        private clsCNCredito objCNCredito { get; set; }
        private List<int> lstCuenta { get; set; }

        public conDatosReprogramacion()
        {
            InitializeComponent();
        }

        public void cargarComponentes()
        {
            idCuenta = 0;
            lAlerta = false;
            lMostrarMontoCuota = false;
        }

        public void cargarComponentes( int _idCuenta, bool _lAlerta, bool _lMostrarMontoCuota)
        {
            idCuenta = _idCuenta;
            lAlerta = _lAlerta;
            lMostrarMontoCuota = _lMostrarMontoCuota;
            objCNCredito = new clsCNCredito();

            recuperarDatosReprogramacion();

            if(lAlerta && lReprogramacion)
            {
                MessageBox.Show("Crédito Reprogramado.", "Reprogramación de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (lAlerta && lRetencion)
            {
                MessageBox.Show("Crédito con retención de tasa.", "Retención con cambio de Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            pnlEstado.Visible = true;
            pnlTipoReprogramacion.Visible = lReprogramacion;
            pnlMontoCuota.Visible = lMostrarMontoCuota;

        }

        public void cargarComponentes (List<int> _lstCuenta, bool _lAlerta, bool _lMostrarMontoCuota = false)
        {
            lstCuenta = _lstCuenta;
            lAlerta = _lAlerta;
            lMostrarMontoCuota = _lMostrarMontoCuota;
            objCNCredito = new clsCNCredito();

            recuperarGrupoDatosReprogramacion();

            if(lAlerta && lReprogramacion)
            {
                MessageBox.Show("Alguno de los integrantes del grupo tiene su crédito reprogramado.", "Reprogramación de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void recuperarDatosReprogramacion()
        {
            DataTable dtReprogramacion = objCNCredito.CNRecuperarDatosReprogramacion(idCuenta);
            if(dtReprogramacion.Rows.Count > 0)
            {
                lReprogramacion = Convert.ToBoolean(dtReprogramacion.Rows[0]["lReprogramacion"]);
                lblEstadoCredito.Text = Convert.ToString(dtReprogramacion.Rows[0]["cEstadoReprogramacion"]);
                lblTipoReprogramacion.Text = Convert.ToString(dtReprogramacion.Rows[0]["cTipoPlanPago"]);
                lblMontoCuota.Text = Convert.ToString(dtReprogramacion.Rows[0]["nMontoCuota"]);
                lRetencion = Convert.ToBoolean(dtReprogramacion.Rows[0]["lRetencion"]);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al cargar los datos de reprogramación", "Reprogramación de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void recuperarGrupoDatosReprogramacion()
        {
            string xmlCuenta = lstCuenta.GetXml();
            DataTable dtGrupoReprogramacion = objCNCredito.CNRecuperarGrupoDatosReprogramacion(xmlCuenta);

            if(dtGrupoReprogramacion.Rows.Count > 0)
            {
                lReprogramacion = dtGrupoReprogramacion.AsEnumerable().Any(item => Convert.ToBoolean(item["lReprogramacion"]));
            }
            else
            {
                MessageBox.Show("Ocurrio un error al cargar los datos de reprogramación", "Reprogramación de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void limpiarDatos()
        {
            idCuenta = 0;
            lAlerta = false;
            lMostrarMontoCuota = false;
            lReprogramacion = false;
            lstCuenta = new List<int>();

            lblEstadoCredito.Text = "-";
            lblTipoReprogramacion.Text = "-";
            lblMontoCuota.Text = "-";

            pnlEstado.Visible = true;
            pnlTipoReprogramacion.Visible = lReprogramacion;
            pnlMontoCuota.Visible = lMostrarMontoCuota;
        }



    }
}
