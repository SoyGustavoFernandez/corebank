using EntityLayer;
using SPL.CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public class clsValidacionPreviaOpe
    {

        #region Varibles globales
        clsCNScoring cnScoring = new clsCNScoring();
        int idCliTitular;
        int idCliOpe;
        String cDocumentoIDOpe;
        int idAgencia;
        int idTipoOpe;

        //Datos Operacion
        private int _idCliOpe;
        private int _idMonedaOpe;
        private int _idProductoOpe;
        private int _idCuentaOpe;
        private decimal _nMontoOpe;


        //clsCNBuscaKardex cnBuscaKardex = new clsCNBuscaKardex();
        #endregion

        public clsValidacionPreviaOpe(int idCli, string cDocumentoID, int idAgencia, int idTipoOpe, int idCliTitular)
        {
            this.idCliOpe = idCli;
            this.cDocumentoIDOpe = cDocumentoID;
            this.idAgencia = idAgencia;
            this.idTipoOpe = idTipoOpe;
            this.idCliTitular = idCliTitular;
        }

        public clsValidacionPreviaOpe(int idCli, int idMoneda, int idProducto, int idCuenta, decimal nMonto)
        {
            _idCliOpe = idCli;
            _idMonedaOpe = idMoneda;
            _idProductoOpe = idProducto;
            _idCuentaOpe = idCuenta;
            _nMontoOpe = nMonto;
        }

        #region metodos
        /// <summary>
        /// Metodo para recorrer verificaciones previas; si devuelve false, se debe detener la operación
        /// </summary>
        public bool verificPararOperacion()
        {
            if (verificaDatosActualizadosCli())
            {
                return true;
            }

            return false;
        }

        public bool ValidarRegimenCli(int idTipoOperacion)
        {
            //Validacion Regimen SPLAFT
            clsCNRegimenCli objRegimen = new clsCNRegimenCli();
            Action<string, string, bool> onMessageShow = (cMensaje, cTitulo, lError) => MessageBox.Show(cMensaje, cTitulo, MessageBoxButtons.OK, lError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            Func<string, string, bool> onQuestionShow = (cMensaje, cTitulo) =>
            {
                DialogResult result = MessageBox.Show(cMensaje, cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return result == DialogResult.Yes;
            };
            return objRegimen.ValidarOperacionCliente(idTipoOperacion, _idCliOpe, _idMonedaOpe, _idProductoOpe, _idCuentaOpe, _nMontoOpe, clsVarGlobal.User.idUsuario,
                                                                 onMessageShow, onQuestionShow);
        }


        public bool verificaDatosActualizadosCli()
        {
            DataTable dtVerificarActualiz = cnScoring.VerificarDatosActualCli(idCliOpe, cDocumentoIDOpe, idAgencia, idTipoOpe, idCliTitular);
            if (Convert.ToBoolean(dtVerificarActualiz.Rows[0]["lDebeActualizar"]))
            {
                MessageBox.Show("Es necesario actualizar los datos del cliente " + dtVerificarActualiz.Rows[0]["cNombre"] + "", "Actualizacion de datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Convert.ToBoolean(dtVerificarActualiz.Rows[0]["lBloquearOpe"]);
            }
            else
            {
                return false;
            }
        }

        public bool verificaDatosActualizadosCliWeb()
        {
            DataTable dtVerificarActualiz = cnScoring.VerificarDatosActualCliWeb(idCliOpe);
            if (Convert.ToBoolean(dtVerificarActualiz.Rows[0]["lDebeActualizar"]))
            {
                MessageBox.Show("Es necesario actualizar los datos del cliente.", "Actualizacion de datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
