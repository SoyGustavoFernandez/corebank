using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNMantConceptos
    {
        clsADMantConceptos ListaConceptos= new clsADMantConceptos();
        public DataTable ListarConceptos()
        {
            return ListaConceptos.ListarConceptos();
        }

        public int ActualizarConceptos(int idConcepto,string Tipo, string Nombre, string NombreCorto, 
                                        int idGrupo, int AplicaCont, int Vigente)
        {
            DataTable resul= ListaConceptos.ActualizarConceptos(idConcepto, Tipo, Nombre, NombreCorto, 
                                         idGrupo,  AplicaCont,  Vigente);
            int idConcep = 0;
            return idConcep = Convert.ToInt32(resul.Rows[0][0]);
        }
    }
}
