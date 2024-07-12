using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SPL.AccesoDatos;

namespace SPL.CapaNegocio
{
    public class clsCNDeclaracionJurada
    {
        clsADDeclaracionJurada addeclaracion= new clsADDeclaracionJurada();

        public DataTable validarSujetoObligado(int idCli)
        {
            return addeclaracion.validarSujetoObligado(idCli);
        }

        public void insertaDeclaracionJurada(clsDeclaracionJurada declaracion, string cOcupaciones)
        {
            addeclaracion.insertaDeclaracionJurada(declaracion, cOcupaciones);
        }

        public DataTable retDatDecJurSujObli(int idCli)
        {
            return addeclaracion.retDatDecJurSujObli(idCli);
        }
        public DataTable retDatDeclaracionJurada(int idDeclaracion)
        {
            return addeclaracion.retDatDeclaracionJurada(idDeclaracion);
        }
        public DataTable retDatOcupacionesDecla(int idDeclaracion)
        {
            return addeclaracion.retDatOcupacionesDecla(idDeclaracion);
        }
        public DataTable CNListaActividadSujetoObligado()
        {
            return addeclaracion.ADListaActividadSujetoObligado();
        }
        public DataTable CNInsertaActSujetoOb(string cXml)
        {
            return addeclaracion.ADInsertaActSujetoOb(cXml);
        }
    }
}
