using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNDirecCli
    {
        clsADDirecCli objListaDir = new clsADDirecCli();
        clsADDireccion objDireccion = new clsADDireccion();
        
        // Crear metodo para recibir datos en un datatable
        public DataTable ListaDirCli(int cCodCli)
        {
            return objListaDir.ListaDireccion(cCodCli);
        }

        public DataTable ListaSuministro()
        {
            return objListaDir.ListaSuministro();
        }

        public clsDireccionCliente recuperarDireccion(int idCli, int idTipoDireccion)
        {
            return objDireccion.recuperarDireccion(idCli, idTipoDireccion);
        }

        public DataTable ListaTipoDireccion()
        {
            return objListaDir.ListaTipoDireccion();
        }
    }
}
