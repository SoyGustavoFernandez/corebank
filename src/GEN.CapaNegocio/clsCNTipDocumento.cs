using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNTipDocumento
    {
        clsADTipDocumento objTipDoc = new clsADTipDocumento();
        // Crear Método para recibir los datos de la Capa de Datos

        public DataTable ListaTipDocFiltro(string cTipoFiltro)
        {
            return objTipDoc.ListaTipDocumento(cTipoFiltro);
        }
        public DataTable ListaTipDoc()
        {
            return objTipDoc.ListaTipDoc();
        }
        
    } 
}
