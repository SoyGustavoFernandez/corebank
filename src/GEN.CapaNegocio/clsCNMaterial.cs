using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNMaterial
    {
        clsADMaterial objmaterial = new clsADMaterial();

        clslisMaterial lista = new clslisMaterial();
        
        public clslisMaterial listarMaterialTecho()
        {
            var listafiltro = from item in objmaterial.listarMateriales()
                              where item.nTipoContruccion == 2
                              select item;

            lista.Clear();
            lista.AddRange(listafiltro);

            return lista;
        }
        public clslisMaterial listarMaterialPared()
        {
            var listafiltro = from item in objmaterial.listarMateriales()
                              where item.nTipoContruccion == 1
                              select item;

            lista.Clear();
            lista.AddRange(listafiltro);

            return lista;
        }
        public clslisMaterial listarMaterialVentana()
        {
            var listafiltro = from item in objmaterial.listarMateriales()
                              where item.nTipoContruccion == 3
                              select item;

            lista.Clear();
            lista.AddRange(listafiltro);

            return lista;
        }
    }
}
