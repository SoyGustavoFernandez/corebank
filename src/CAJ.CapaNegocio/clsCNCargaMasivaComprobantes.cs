using CAJ.AccesoDatos;
using System.Data;

namespace CAJ.CapaNegocio
{
    public class clsCNCargaMasivaComprobantes
    {
        clsADCargaMasivaComprobantes objADCargaMasiva = new clsADCargaMasivaComprobantes();

        public DataSet CNObtieneConfiguracionPlantilla(int cTipoComp)
        {
            return this.objADCargaMasiva.ADObtieneConfiguracionPlantilla(cTipoComp);
        }

        public DataTable CNGuardaComprobantesCargaMasiva(string xmlDatos)
        {
            return this.objADCargaMasiva.ADGuardaComprobantesCargaMasiva(xmlDatos);
        }

        public DataTable CNValidacionesEspecialesCargaMasiva()
        {
            return this.objADCargaMasiva.ADValidacionesEspecialesCargaMasiva();
        }
    }
}
