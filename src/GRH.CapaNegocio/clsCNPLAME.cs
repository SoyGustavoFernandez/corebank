using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNPLAME
    {
        clsADPLAME LitaHorarios = new clsADPLAME();

        public DataTable ListarPLAME()
        {
            return LitaHorarios.ListarPLAME();
        }
        public DataTable ProcesPlanillas(string cNomSp, int idPeriodo)
        {
            return LitaHorarios.ProcesPlanillas(cNomSp, idPeriodo);
        }
        public DataTable ListarTREGISTRO()
        {
            return LitaHorarios.ListarTREGISTRO();
        }
        public DataTable ProcesRegistros(string cNomSp, int idPeriodo)
        {
            return LitaHorarios.ProcesRegistros(cNomSp, idPeriodo);
        }
    }
}
