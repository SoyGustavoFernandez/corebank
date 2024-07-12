using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMantConceptosRem
    {
        clsADMantConceptosRem ListaHorarios = new clsADMantConceptosRem();
        public DataTable ListarConceptos()
        {
            return ListaHorarios.ListarConceptos();
        }
        public DataTable ActualizarConcepto(int idConcepto,string  NombConcepto,int idTipoConcepto,int lVigente)
        {
            return ListaHorarios.ActualizarConcepto(idConcepto, NombConcepto, idTipoConcepto, lVigente);
        }
        public int GuardarConcepto(string NombConcepto, int idTipoConcepto, int lVigente)
        {
            DataTable dt= ListaHorarios.GuardarConcepto( NombConcepto, idTipoConcepto, lVigente);
            int idNuevo = Convert.ToInt32(dt.Rows[0][0]);
            return idNuevo;
        }
    }
}
