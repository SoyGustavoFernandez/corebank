using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer
{
    /// <summary>
    /// Enitdad compania de seguros
    /// </summary>
    public class clsCompaniaSeguro
    {
        public int idCompania { get; set; }
        public string cCompania { get; set; }
        public int idEstado { get; set; }

        public override string ToString()
        {
            return cCompania;
        }
    }

    /// <summary>
    /// Coleccion de la entidad compania de seguros
    /// </summary>
    public class clslisCompaniaSeguro:List<clsCompaniaSeguro>
    {
        
    }
}
