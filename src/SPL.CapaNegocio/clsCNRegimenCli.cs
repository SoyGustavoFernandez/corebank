using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using SPL.AccesoDatos;
using System.Data;
using EntityLayer;

namespace SPL.CapaNegocio
{
    public class clsCNRegimenCli
    {
        private const string cSustento = "Por estar en régimen reforzado";
        private const string cTitulo = "Régimen de clientes - SPLAFT";
        private clsCNAprobacion _objAprobacion;
        private clsADRegimenCli _objADRegimenCli;

        public clsCNRegimenCli()
        {
            _objAprobacion = new clsCNAprobacion();
            _objADRegimenCli = new clsADRegimenCli();
        }

        public bool ValidarOperacionCliente(int idTipoOperacion,int idCli, int idMoneda, int idProducto, int idDocument,
                                            decimal nMonto, int idUsuReg, Action<string, string, bool> onMessageShow,
                                            Func<string,string, bool> onQuestionShow)
        {
            DataTable dtRegimenCli = _objADRegimenCli.GetRegimenCliente(idCli);
            if (dtRegimenCli.Rows.Count == 0)
                return true;

            DataRow dr = dtRegimenCli.Rows[0];
            bool lReqAprobacion = dr.Field<bool>("lReqAprobacion");
            if (!lReqAprobacion)
                return true;

            DataTable dtListaSolAprob = _objAprobacion.ListarSolicitudesAprobacion(idTipoOperacion, 1, idCli,
                                                                                    idMoneda, idProducto, idDocument, idUsuReg);
            var filter = dtListaSolAprob.AsEnumerable().Where(x => x.Field<decimal>("nValAproba") == nMonto);
            if (!filter.Any())
            {
                RegistrarSolicitudAprobacion(idTipoOperacion, idCli, idMoneda, idProducto, idDocument, nMonto, onMessageShow);
                return false;
            }
            else
            {
                DataRow row = filter.First();
                int idEstado = (int)row["idEstadoSol"];
                if (idEstado == 1)
                {
                    string cMensaje = "La solicitud de operación para cliente en régimen REFORZADO aún no ha sido APROBADA.";
                    onMessageShow(cMensaje, cTitulo, false);
                    return false;
                }
                else if (idEstado == 4)
                {
                    string cMensaje = "La solicitud de operación para cliente en régimen REFORZADO fue RECHAZADA. ¿Desea volver a solicitar la operación?";
                    bool lRespuesta = onQuestionShow(cMensaje, cTitulo);
                    if (lRespuesta)
                    {
                        RegistrarSolicitudAprobacion(idTipoOperacion, idCli, idMoneda, idProducto, idDocument, nMonto, onMessageShow);
                    }
                    return false;
                }
                return true;
            }
        }


        private void RegistrarSolicitudAprobacion(int idTipoOperacion, int idCli, int idMoneda, int idProducto, int idDocument, decimal nMonto,
                                                    Action<string, string, bool> onMessageShow)
        {
            DataTable tbSolApr = _objAprobacion.GuardarSolicitudAprobac(
                                                                clsVarGlobal.nIdAgencia,
                                                                idCli,
                                                                idTipoOperacion,
                                                                1,
                                                                idMoneda,
                                                                idProducto,
                                                                nMonto,
                                                                idDocument,
                                                                clsVarGlobal.dFecSystem.Date,
                                                                0,
                                                                cSustento,
                                                                1,
                                                                clsVarGlobal.dFecSystem.Date,
                                                                clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
            if (tbSolApr.Rows.Count > 0)
            {
                DataRow drRpta = tbSolApr.Rows[0];
                int idSolAprob = Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"]);
                string cMsjeBd = "Se registró la solicitud de la operación para el cliente de régimen REFORZADO. El número de la solicitud: " + idSolAprob.ToString();
                if (idSolAprob != 0)
                {
                    onMessageShow(cMsjeBd, cTitulo, false);
                    if (Convert.ToInt32(tbSolApr.Rows[0]["idEstadoSol"]) == 4)
                    {
                        string cMensaje = string.Format("{0}. Nro Solicitud: {1}", tbSolApr.Rows[0]["cMensaje"], idSolAprob);
                        onMessageShow(cMensaje, cTitulo, false);
                    }
                }
                else
                {
                    onMessageShow(cMsjeBd, cTitulo, false);
                }
            }
        }

    }
}
