using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;
using EntityLayer;
using GEN.Funciones;


namespace ADM.CapaNegocio
{
    public class clsCNMantmtoAprobacionGen
    {
        private clsADMantmtoAprobacionGen objADMantAprobacionGen;
        public clsCNMantmtoAprobacionGen()
        {
            this.objADMantAprobacionGen = new clsADMantmtoAprobacionGen();
        }

        public List<clsAprobacionCanal> listarAprobacionCanal()
        {
            return this.objADMantAprobacionGen.listarAprobacionCanal();
        }
        public clsRespuestaServidor grabarAprobacionCanal(clsAprobacionCanal objAprobacionCanal)
        {
            List<clsAprobacionCanal> lstAprobacionCanal =  new List<clsAprobacionCanal>();
            lstAprobacionCanal.Add(objAprobacionCanal);

            string xmlAprobacionCanal = lstAprobacionCanal.ListObjectToXml("Canal", "Canales");
            return this.objADMantAprobacionGen.grabarAprobacionCanal(xmlAprobacionCanal);
        }

        public List<clsAprobacionSolicitudTipo> listarAprobacionSolTipo()
        {
            return this.objADMantAprobacionGen.listarAprobacionSolTipo();
        }
        public clsRespuestaServidor grabarAprobacionSolTipo(clsAprobacionSolicitudTipo objAprobacionSolTipo)
        {
            List<clsAprobacionSolicitudTipo> lstAprobacionSolTipo = new List<clsAprobacionSolicitudTipo>();
            lstAprobacionSolTipo.Add(objAprobacionSolTipo);

            string xmlAprobacionSolTipo = lstAprobacionSolTipo.ListObjectToXml("AproSolTipo", "AproSolTipos");
            return this.objADMantAprobacionGen.grabarAprobacionSolTipo(xmlAprobacionSolTipo);
        }

        public List<clsAprobacionNivel> listarAprobacionNivel(int idAprobacionCanal)
        {
            return this.objADMantAprobacionGen.listarAprobacionNivel(idAprobacionCanal);
        }
        public clsRespuestaServidor grabarAprobacionNivel(List<clsAprobacionNivel> lstAprobacionNivel)
        {
            string xmlAprobacionNivel = lstAprobacionNivel.ListObjectToXml("Nivel", "Niveles");
            return this.objADMantAprobacionGen.grabarAprobacionNivel(xmlAprobacionNivel);
        }

        public List<clsPerfil> listarPerfilAprobador(int idAprobacionNivel)
        {
            return this.objADMantAprobacionGen.listarPerfilAprobador(idAprobacionNivel);
        }
    }
}
