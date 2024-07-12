using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;
using EntityLayer;

namespace CLI.CapaNegocio
{
    public class clsCNFirmas
    {
        clsADFirmas adfirma= new clsADFirmas();

        /// <summary>
        /// retorna datos de la firma de un cliente
        /// </summary>
        /// <param name="idCli">id del cliente</param>
        /// <returns></returns>
        public clsFirma retornaFirma(int idCli)
        {
            return adfirma.retornaFirma(idCli);
        }

        /// <summary>
        /// inserta los datos de la firma del cliente
        /// </summary>
        /// <param name="firma">objeto de la entidad clsfirma</param>
        public void insertarFirma(clsFirma firma)
        {
            adfirma.insertarFirma(firma);
        }
    }
}
