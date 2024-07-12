using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
  public  class clsCNEstadoActual
    {
      public clsEstadoActual objdocide = new clsEstadoActual();
      
      public DataTable listarEstadoActual()
      {
          //return objdocide.ListarEstadoActual();
          var dt = objdocide.ListarEstadoActualXml();

          DataTable dtEstadoActual = dt.Clone();

          (from item in dt.AsEnumerable()
           where (bool)item["lVigente"] == true
           orderby (string)item["idEstado"]
           select item).CopyToDataTable(dtEstadoActual, LoadOption.OverwriteChanges);

          return dtEstadoActual;
           
      }
      public DataTable listarEstadoCuentaCli()
      {

          DataTable dtEstadoCuentaCli = objdocide.ListarEstadoCuentaCli();

          return dtEstadoCuentaCli;

      }
    }
}
