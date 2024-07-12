using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNListaFormatoImp
    {
        public clsADListaFormatoImp objListaFor = new clsADListaFormatoImp();
        public DataTable CNListaFormato()
        {
            return objListaFor.ADListaFormato();

        }

        public DataTable CNListaFormatosReimpresion(int idOpcion, int idCuenta)
        {
            return objListaFor.ADListaFormatosReimpresion(idOpcion, idCuenta);

        }

        public DataTable CNRegistraReimpresionDocs(int idCuenta,int idMotivo,string cMotivo,int idSolicitud,int idUsuario,int idAgencia,string XMLDocs)
        {
            return objListaFor.ADRegistraReimpresionDocs(idCuenta, idMotivo, cMotivo, idSolicitud, idUsuario, idAgencia, XMLDocs);

        }

        public DataTable CNSolicitudReimpresionApr()
        {
            return objListaFor.ADSolicitudReimpresionApr();

        }
    }
}
