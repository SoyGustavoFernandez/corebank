using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;
using EntityLayer;
using System.Data;

namespace CLI.CapaNegocio
{
    public class clsCNBeneficiario
    {
        clsADBeneficiario adbeneficiario = new clsADBeneficiario();
        public clslisBeneficiario listarbeneficiarios(int idSocio)
        {
            return adbeneficiario.listarbeneficiarios(idSocio);
        }

        public DataTable listarBeneficiariosComoTabla(int idSocio)
        {
            return adbeneficiario.listarBeneficiariosComoTabla(idSocio);
        }


        /// <summary>
        /// Lista la situación de Indemnización de Beneficiarios de un Socio
        /// </summary>
        /// <param name="idSocio"></param>
        /// <returns></returns>
        public DataTable listarSituacIndemizacBenef(int idSocio)
        {
            return adbeneficiario.listarSituacIndemizacBenef(idSocio);
        }
        /// <summary>
        /// Lista la situación de devolución de Beneficiarios de un Socio
        /// </summary>
        /// <param name="idSocio"></param>
        /// <returns></returns>
        public DataTable listarSituacDevolucionBenef(int idSocio)
        {
            return adbeneficiario.listarSituacDevolucionBenef(idSocio);
        }
    }
}
