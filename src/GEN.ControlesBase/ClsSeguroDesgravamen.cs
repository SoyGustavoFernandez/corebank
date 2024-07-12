using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public class ClsSeguroDesgravamen
    {
        #region Variables

        decimal nCapitalAGarantizar;

        ADM.CapaNegocio.clsCNConfigGastComiSeg ConfigGastComiSeg;
        int idConceptoSeguroDesgravamen = 10;
        bool lAplicaSeguro = true;

        #endregion

        public ClsSeguroDesgravamen()
        {
            ConfigGastComiSeg = new ADM.CapaNegocio.clsCNConfigGastComiSeg();
        }

        #region Metodos Públicos

        public DataTable validarAplicaSeguroDesgravamen(int nNumSolicitud, int nTipoOperacion, int nIdMenu, int idCanal, decimal nMontoSolicitado = 0, int idCuenta = 0, bool lMostrarAlerta = true)
        {
            //================================================================================
            // Validando si el crédito del cliente será asegurado :nAplicaSeguro "0:No aplica"; "1: Aplica"; "2: Aplica a una parte del crédito"
            //================================================================================
            DataTable dtRes = ConfigGastComiSeg.CNValidarAplicacionSeguroDesgravamen(nNumSolicitud, nMontoSolicitado, idCuenta);

            if (Convert.ToInt32(dtRes.Rows[0]["idEstado"]) == 0)
            {
                if (lMostrarAlerta)
                {
                MessageBox.Show("Aplicación de seguro de desgravamen: \n" + dtRes.Rows[0]["cMensaje"], "Seguro de Desgravamen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lAplicaSeguro = false;
                nCapitalAGarantizar = Convert.ToDecimal(dtRes.Rows[0]["nMontoAsegurado"]);
            }
            else if (Convert.ToInt32(dtRes.Rows[0]["idEstado"]) == 1)
            {
                lAplicaSeguro = true;
                nCapitalAGarantizar = Convert.ToDecimal(dtRes.Rows[0]["nMontoAsegurado"]);
            }
            else
            {
                if (lMostrarAlerta)
                {
                MessageBox.Show("Aplicación de seguro de desgravamen: \n" + dtRes.Rows[0]["cMensaje"], "Seguro de Desgravamen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lAplicaSeguro = true;
                nCapitalAGarantizar = Convert.ToDecimal(dtRes.Rows[0]["nMontoAsegurado"]);
            }
            //================================================================================
            // Fin Validando si el crédito del cliente será asegurado
            //================================================================================
            if (lAplicaSeguro)
            {
                return ConfigGastComiSeg.ValidarSolicitudConfigGastComiSeg(nNumSolicitud, nTipoOperacion, nIdMenu, idCanal, idCuenta);
            }
            else
            {
                lAplicaSeguro = false;
                nCapitalAGarantizar = 0;
                return eliminandoSeguroDesgravamen(ConfigGastComiSeg.ValidarSolicitudConfigGastComiSeg(nNumSolicitud, nTipoOperacion, nIdMenu, idCanal, idCuenta));
            }
        }

        public Decimal obtenerNCapitalAGarantizar()
        {
            return nCapitalAGarantizar;
        }

        public bool obternerNAplicaSeguro()
        {
            return lAplicaSeguro;
        }
        
        #endregion

        #region Metodos Private

        private DataTable eliminandoSeguroDesgravamen(DataTable dt)
        {
            DataTable dtTemp = dt.Clone();

            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["nIdTipoGasto"]) != idConceptoSeguroDesgravamen)
                {
                    dtTemp.ImportRow(item);
                }
            }

            return dtTemp;
        }

        #endregion
    }
}
