using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.Servicio
{
    #region Métodos
    
    public class clsMenuExpediente
    {
        public int idMenu { get; set; }
        public string cMenu { get; set; }
        public int idPadre { get; set; }
        public int idDescTipoDoc { get; set; }
        public int nOrden { get; set; }
        public int idCategoriaArchivo { get; set; }
        public int idArchivo { get; set; }
        public string cExtension { get; set; }
        public int idSecundario { get; set; }

        public clsMenuExpediente() { }
        public clsMenuExpediente(clsMenuExpediente objClas)
        {
            this.idMenu = objClas.idMenu;
            this.cMenu = objClas.cMenu;
            this.idPadre = objClas.idPadre;
            this.idDescTipoDoc = objClas.idDescTipoDoc;
            this.idCategoriaArchivo = objClas.idCategoriaArchivo;
            this.idArchivo = objClas.idArchivo;
            this.cExtension = objClas.cExtension;
            this.idSecundario = objClas.idSecundario;
        }
    }

    public class clsLsMenuExpediente : List<clsMenuExpediente>
    {
    }
    #endregion
}
