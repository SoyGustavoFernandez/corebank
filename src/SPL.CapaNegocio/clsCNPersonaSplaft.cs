using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPL.AccesoDatos;
using System.Data;
using CLI.CapaNegocio;

namespace SPL.CapaNegocio
{
    public class clsCNPersonaSplaft
    {

        //public clsListaPersonaSplaft listarPersonaSplaft(int idKardex, int idModulo)
        //{
        //    return new clsADPersonaSplaft().ListarPersonaSPLAFT(idKardex, idModulo);
        //}

        public clsListaPersonaSplaft listarPersonaSplaft(int idKardex, int idModulo)
        {
            int pais;
            int departamento;
            int provincia;
            int distrito;

            int act=0;
            clsADPersonaSplaft ob = new clsADPersonaSplaft();
            clsListaPersonaSplaft temporal = ob.ListarPersonaSPLAFT(idKardex, idModulo);
            clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
            clsADNombresUbig nombres = new clsADNombresUbig();
            DataTable nombresU=new DataTable();
            DataTable tbDatUbi = new DataTable();

            //-----------------
            foreach (var item in temporal)
            {
                tbDatUbi=RetCliNat.RetUbiCli(item.NIdUbigeo);
                
                pais = Convert.ToInt32(tbDatUbi.Rows[4]["idUbigeo"]);
                departamento = Convert.ToInt32(tbDatUbi.Rows[3]["idUbigeo"]);
                provincia = Convert.ToInt32(tbDatUbi.Rows[2]["idUbigeo"]);
                distrito = Convert.ToInt32(tbDatUbi.Rows[1]["idUbigeo"]);


                item.codPais = pais.ToString();
                item.codDepartamento = departamento.ToString();
                item.codProvincia = provincia.ToString();
                item.codDistrito = distrito.ToString();
                
                nombresU=nombres.listarNombres(pais, departamento, provincia, distrito);

                item.cPais = nombresU.Rows[0]["cDescipcion"].ToString();
                item.cDepartamento = nombresU.Rows[1]["cDescipcion"].ToString();
                item.cProvincia = nombresU.Rows[2]["cDescipcion"].ToString();
                item.cDistrito = nombresU.Rows[3]["cDescipcion"].ToString();

                item.idLista = act;
                act += 1;
            }
            

          

            return temporal;
        }

        public clsPersonaSplaft buscarPersonaSplaft(int idCli)
        {
            return new clsADPersonaSplaft().BuscarPersona(idCli);
        }


        public clsListaPersonaSplaft DevolverPersona(int idkardex) 
        {
            return new clsADPersonaSplaft().DevolverPersonas(idkardex);
        }

        public DataTable DevolverPersonaDT(int idkardex)
        {
            return new clsADPersonaSplaft().DevolverPersonaDT(idkardex);
        }


        public void actualizarPersonaSPL(clsListaPersonaSplaft personas, int idkardex)
        {
            new clsADPersonaSplaft().actualizarPersonaSPL(personas, idkardex);
        }

        public clsListaPersonaSplaft listarRepresentanteSplaft(int idCli)
        {
            int pais;
            int departamento;
            int provincia;
            int distrito;

            int act = 0;
            clsADPersonaSplaft ob = new clsADPersonaSplaft();
            clsListaPersonaSplaft temporal = ob.ListarRepresentanteSPLAFT(idCli);
            clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
            clsADNombresUbig nombres = new clsADNombresUbig();
            DataTable nombresU = new DataTable();
            DataTable tbDatUbi = new DataTable();

            //-----------------
            foreach (var item in temporal)
            {
                tbDatUbi = RetCliNat.RetUbiCli(item.NIdUbigeo);

                pais = Convert.ToInt32(tbDatUbi.Rows[4]["idUbigeo"]);
                departamento = Convert.ToInt32(tbDatUbi.Rows[3]["idUbigeo"]);
                provincia = Convert.ToInt32(tbDatUbi.Rows[2]["idUbigeo"]);
                distrito = Convert.ToInt32(tbDatUbi.Rows[1]["idUbigeo"]);


                item.codPais = pais.ToString();
                item.codDepartamento = departamento.ToString();
                item.codProvincia = provincia.ToString();
                item.codDistrito = distrito.ToString();

                nombresU = nombres.listarNombres(pais, departamento, provincia, distrito);

                item.cPais = nombresU.Rows[0]["cDescipcion"].ToString();
                item.cDepartamento = nombresU.Rows[1]["cDescipcion"].ToString();
                item.cProvincia = nombresU.Rows[2]["cDescipcion"].ToString();
                item.cDistrito = nombresU.Rows[3]["cDescipcion"].ToString();

                item.idLista = act;
                act += 1;
            }

            return temporal;
        }


    }
}
