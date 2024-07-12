using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;

namespace CLI.Servicio
{
    public class clsTipoCliente
    {
        #region Atributos
        clsCNBuscarCli listarCli = new clsCNBuscarCli();
        private int idCli;
        private int idTipoCliente;
        #endregion

        #region Métodos Públicos
        public clsTipoCliente(int _idCli, int _idTipoCliente)
        {
            this.idCli = _idCli;
            this.idTipoCliente = _idTipoCliente;
            
        }

        public int initClienteRecurrente()
        {
            if (idTipoCliente == 0)
            {
                determinarTipoCliente();
            }
            else if (idTipoCliente == 1)
            {
                determinarTipoCliente();
            }
            else if(idTipoCliente == 2)
            {
                this.idTipoCliente = 2;
            }
        
            return this.idTipoCliente;
        }

        #endregion

        #region Métodos Privados
        private void determinarTipoCliente()
        {
            DataTable dtTipoCliente = listarCli.determinarTipoCliente(idCli);
            if (dtTipoCliente.Rows.Count == 0)
            {
                this.idTipoCliente = 0;
            }
            else
            {
                this.idTipoCliente = Convert.ToInt32(dtTipoCliente.Rows[0]["idTipoCliente"]);
            }
        }

        private void clienteNuevoRecurrente()
        {
            
            DataTable dtTipoCliente = listarCli.CNClienteNuevoRecurrenteNuevoCalculo(idCli);
            if (dtTipoCliente.Rows.Count == 0)
            {
                this.idTipoCliente = 1;
            }
            else
            {
                if (Convert.ToInt32(dtTipoCliente.Rows[0]["idTipoCliente"]) == 1)
                {
                    dtTipoCliente.Columns["nGrupoParalelo"].ReadOnly = false;
                    //Cliente Nuevo
                    calcularClienteRecurrente(dtTipoCliente);
                }
                else
                {
                    //Cliente Recurrente
                    this.idTipoCliente = Convert.ToInt32(dtTipoCliente.Rows[0]["idTipoCliente"]);
                }
            }
        }

        private void calcularClienteRecurrente(DataTable dtCreditosCli)
        {
            DataTable dtTemporal = dtCreditosCli.Clone();
            int nNro = 1;
            int nGrupoCreditosParalelos = 1;
            dtTemporal.ImportRow(obtenerDataRowGrupo(dtCreditosCli, nNro, nGrupoCreditosParalelos));

            DataTable dtCreditosFaltantes = quitarCreditosYaAgregados(dtCreditosCli, dtTemporal);
            while (dtCreditosFaltantes.Rows.Count > 0)
            {
                DataTable dtParalelos = obtenerCreditosParalelos(dtCreditosFaltantes, obtenerDataRowGrupo(dtCreditosCli, nNro, nGrupoCreditosParalelos), nGrupoCreditosParalelos);
                //agregar creditos paralelos con el grupoParalelo

                if (dtParalelos.Rows.Count == 0)
                {
                    //incluir
                    nNro = nNro + 1;
                    nGrupoCreditosParalelos = nGrupoCreditosParalelos + 1;
                    dtTemporal.ImportRow(obtenerDataRowGrupo(dtCreditosCli, nNro, nGrupoCreditosParalelos));
                }
                else
                {
                    dtTemporal.Merge(dtParalelos);
                    nNro = obtenerNroMayor(dtTemporal);

                }

                dtCreditosFaltantes.Clear();
                dtCreditosFaltantes = quitarCreditosYaAgregados(dtCreditosCli, dtTemporal);

            }

            //aqui se hace una suma simple los meses transcurridos por grupo
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTemporal);
            string cCreditosParalelosXml = ds.GetXml();
            
            DataTable dtRes = listarCli.CNClienteRecurrenteCredParalelos(cCreditosParalelosXml);

            this.idTipoCliente = Convert.ToInt32(dtRes.Rows[0]["idTipoCliente"]);
        }

        private DataRow obtenerDataRowGrupo(DataTable dt, int nNro, int nGrupoParalelo = 0)
        {
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["nNro"]) == nNro)
                {
                    item["nGrupoParalelo"] = nGrupoParalelo;
                    return item;
                }
            }
            return null;
        }

        private int obtenerNroMayor(DataTable dt)
        {
            int nNroMayor = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (nNroMayor == 0)
                {
                    nNroMayor = Convert.ToInt32(item["nNro"]);
                }

                if (nNroMayor < Convert.ToInt32(item["nNro"]))
                {
                    nNroMayor = Convert.ToInt32(item["nNro"]);
                }
            }
            return nNroMayor;
        }

        private DataTable quitarCreditosYaAgregados(DataTable dtBase, DataTable dtQuita)
        {
            DataTable dtRes = dtBase.Clone();
            bool lEsta = false;
            foreach (DataRow item in dtBase.Rows)
            {
                lEsta = false;
                foreach (DataRow item2 in dtQuita.Rows)
                {
                    if (Convert.ToInt32(item2["nNro"]) == Convert.ToInt32(item["nNro"]))
                    {
                        lEsta = true;
                    }
                }
                if (!lEsta)
                {
                    dtRes.ImportRow(item);
                }
            }

            return dtRes;
        }

        private DataTable obtenerCreditosParalelos(DataTable dt, DataRow dr, int nGrupoCreditosParalelos = 0)
        {
            DataTable dtResultado = dt.Clone();
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToDateTime(dr["dFechaDesembolso"]) <= Convert.ToDateTime(item["dFechaDesembolso"])
                    && Convert.ToDateTime(dr["dFechaFinCredito"]) >= Convert.ToDateTime(item["dFechaDesembolso"])
                    )
                {
                    item["nGrupoParalelo"] = nGrupoCreditosParalelos;
                    dtResultado.ImportRow(item);
                }
            }
            return dtResultado;
        }
        #endregion
    }
}
