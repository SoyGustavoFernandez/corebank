using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using CLI.AccesoDatos;
using System.Data;
using EntityLayer;

namespace CLI.CapaNegocio
{
    public class clsCNRetDatosCliente
    {
        clsADRetDatosCliente objLista = new clsADRetDatosCliente();
        
        // Crear metodo para recibir datos en un datatable
        public DataTable ListarDatosCli(int nidClient, string cTipBus)
        {
            return objLista.ListaCliente(nidClient, cTipBus);
        }

        /// <summary>
        /// retorna los datos de un cliente
        /// </summary>
        /// <param name="nidClient"></param>
        /// <param name="cTipBus"></param>
        /// <returns></returns>
        public clsCliente retornarCliente(int nidClient, string cTipBus)
        {
            return objLista.retornarCliente(nidClient, cTipBus);
        }

        /// <summary>
        /// retorna datos basicos de un cliente:idcli,nombres y documento
        /// </summary>
        /// <param name="nidClient"></param>
        /// <returns></returns>
        public clsCliente retornarCliente(int nidClient)
        {
            return objLista.retornarCliente(nidClient);
        }

        // Crear metodo para recibir datos en un datatable
        public DataTable RetUbiCli(int nIdUbigeo)
        {
            return objLista.RetUbigeoCli(nIdUbigeo);
        }
        // CREA METODO PARA BUSCARUBIGEO POR CODIGO DE RENIEC
        public DataTable RetUbiCliPorCodigoReniec(string cUbigeoRENIEC)
        {
            return objLista.RetUbiCliPorCodigoReniec(cUbigeoRENIEC);
        }

        // Crear metodo para recibir datos en un datatable
        public string RetDatVal(int nidClient, string cNroDoc, string cTipOpe, int TipDoc)
        {
            string cRetorno = "OK";
            DataTable tbValCli = objLista.RetDatValidar(nidClient, cNroDoc, cTipOpe, TipDoc);
            switch (cTipOpe)
            {
                case "D": //--Validar Ingreso Duplicado
                    if (tbValCli.Rows.Count > 0)
                    {
                        cRetorno = "ERROR";
                    }
                    else
                    {
                        cRetorno = "OK";
                    }
                    break;

                case "E":  //--Validar Edad del Cliente
                    if (tbValCli.Rows.Count > 0 && Convert.ToInt32(tbValCli.Rows[0]["Edad"].ToString()) >= 18)
                    {
                        cRetorno = "OK";
                    }
                    else
                    {
                        cRetorno = "ERROR";
                    }
                    break;
                case "S":  //--Validar Sexo de Conyuge
                    if (tbValCli.Rows.Count > 0)
                    {
                        cRetorno = tbValCli.Rows[0]["idSexo"].ToString();
                    }
                    else
                    {
                        cRetorno = "ERROR";
                    }
                    break;
            }

            return cRetorno;
        }

        // Crear metodo para recibir listado de clientes juridicos en un datatable
        public DataTable ListarClientesJuridicos()
        {
            return objLista.ListaClientesJuridicos();
        }

        public DataTable CNBuscaClientesAgencia(int idAgencia, int idUsuario)
        {
            return objLista.BuscaClientesAgencia(idAgencia, idUsuario);
        }       
    }
}
