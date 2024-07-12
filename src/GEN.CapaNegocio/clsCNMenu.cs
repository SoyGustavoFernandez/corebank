using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNMenu
    {
        clsADMenu admenu = new clsADMenu();
        public DataTable LisTreeMenByPer(int idPerfil)
        {
            return admenu.LisTreeMenByPer(idPerfil);           
        }

        public clslisMenu listarMenuPorPerfil(int idPerfil)
        {
            clslisMenu lista = new clslisMenu();
            DataTable dt = new clsADMenu().listarMenuPorPerfil(idPerfil);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsMenu()
                    {
                        idMenu      = (int)item["idMenu"]           ,
                        idMenuPadre = (int)item["idMenuPadre"]      ,
                        idModulo    = (int)item["idModulo"]         ,
                        nOrden      = (int)item["nOrden"]           ,
                        cMenu       = item["cMenu"].ToString()      ,
                        cNameSpace  = item["cNameSpace"].ToString() ,
                        cFormMenu   = item["cFormMenu"].ToString()  ,
                        idTipoMenu  = (int)item["idTipoMenu"]       ,
                        idTipoClass = (int)item["idTipoClass"]      ,
                        idTipoProc  = (int)item["idTipoProc"]       ,
                        lVigente    = (bool)item["lVigente"]        ,
                        idMenuPerfil = (int)item["idMenuPerfil"]    ,
                        lActivo     = (bool)item["lActivo"]
                    });
                }
            }
            return lista;
        }

        public void insertarMenuPerfil(clslisMenu listamenu, int idPerfil)
        {
            admenu.insertarMenuPerfil(listamenu, idPerfil);
        }

        public clslisMenu listaropcionesmenu(int idModulo)
        {
            clslisMenu lista = new clslisMenu();
            DataTable dt = admenu.listaropcionesmenu(idModulo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsMenu()
                    {
                        idMenu = (int)item["idMenu"],
                        idMenuPadre = (int)item["idMenuPadre"],
                        idModulo = (int)item["idModulo"],
                        nOrden = (int)item["nOrden"],
                        cMenu = item["cMenu"].ToString(),
                        cNameSpace = item["cNameSpace"].ToString(),
                        cFormMenu = item["cFormMenu"].ToString(),
                        idTipoMenu = (int)item["idTipoMenu"],
                        idTipoClass = (int)item["idTipoClass"],
                        idTipoProc = (int)item["idTipoProc"],
                        lVigente = (bool)item["lVigente"],
                        lBaseNegativa = (bool)item["lBaseNegativa"]
                    });
                }
            }
            return lista;
        }

        public void insertActMenu(clsMenu menu)
        {
            admenu.insertActMenu(menu);
        }

        public DataTable listarMenuVigentes(int idModulo)
        {
            var dtMenu = admenu.listaropcionesmenu(idModulo);
            var dtMenuaux = dtMenu.Clone();

            (from item in dtMenu.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtMenuaux, LoadOption.OverwriteChanges);
            return dtMenuaux;
        }
    }
}
