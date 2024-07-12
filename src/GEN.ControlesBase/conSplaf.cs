using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conSplaf : Label
    {
        public conSplaf()
        {
            InitializeComponent();
        }
        
        public bool validaClientePep(int idTipoDoc, string nNroDoc, int idCli)
        {
            bool nResp=false;
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCliPep = listarCli.ValidaPersonaPep(idTipoDoc, nNroDoc, idCli);


            if (tablaCliPep.Rows.Count > 0)
            {
                nResp = true;
                this.Text = "Cliente es PEP";
            }
            else 
            {
                this.Text = "";
            }
            return nResp;
        }
        public bool GenerarSolicitudAprobacion(int idCli,int idMoneda,Decimal nMontoOpe)
        {
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            
            DataTable tablaCliPep = listarCli.ValidaPersonaPep(0,"0", idCli);
            bool validaSplt = true;

                if (tablaCliPep.Rows.Count > 0)
                {   
                    DataTable tblEstadoSol=listarCli.ValidarSolicitudSplaft(idCli);
                    validaSplt = false;
                    string mensaje;
                    if (tblEstadoSol.Rows.Count <= 0)
                    {
                        DataTable tablaSol = listarCli.GuardarSolicitudAprobacSPLAFT(clsVarGlobal.nIdAgencia, idCli, idMoneda, nMontoOpe, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

                        mensaje = tablaSol.Rows[0]["cMensaje"].ToString();
                        //string msg2, msg3;
                        //msg2 = mensaje.Substring(0, mensaje.IndexOf("_") - 1);
                        //msg3 = mensaje.Substring(mensaje.IndexOf("_") + 1);
                        MessageBox.Show(mensaje, "SPLAFT: Solicitud de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show(msg2 + "\n" +msg3, "SPLAFT: Solicitud de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        validaSplt = false;
                    }
                    else
                    {
                        if (tblEstadoSol.Rows[0]["idEstadoSol"].ToString() == "2")
                        {
                            validaSplt = true;
                        }
                        else
                        {
                            mensaje = "Por Favor Espere la Aprobación de la Solicitud de operación para el cliente PEP.";
                            MessageBox.Show(mensaje, "SPLAFT: Solicitud de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            validaSplt = false;
                        }

                    }
                }
        
            return validaSplt;
        }

        public DataTable MarcarComoRegistroPEPPendiente(int idCli, string cDocumento, string ApellidoPat, string ApellidoMat, string cNombres, DateTime dFechaNac, int idTipoDoc, string cCargo)
        {
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            return listarCli.MarcarComoRegistroPEPPendiente(idCli, cDocumento, ApellidoPat, ApellidoMat, cNombres, dFechaNac, idTipoDoc, cCargo);
        }

        //--=================================================================================
        //--Validamos si El Cliente PEP esta Aprobado
        //--=================================================================================
        public bool ValidaAprobacionClientePep(int idCli, ref string mensaje, ref string x_cNroDni, ref int x_idEstApr)
        {
            bool nResp = false;
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCliPep = listarCli.ValidaPersonaPep(0, "0", idCli);
            if (tablaCliPep.Rows.Count > 0)
            {
                if (Convert.ToInt32(tablaCliPep.Rows[0]["idVigente"].ToString()) == 0)
                {
                    mensaje = "";
                    nResp = true;
                }
                else
                {
                    x_idEstApr = Convert.ToInt32(tablaCliPep.Rows[0]["bEstadoAprobacion"].ToString());
                    x_cNroDni = tablaCliPep.Rows[0]["nDocumento"].ToString();

                    switch (x_idEstApr)
                    {
                        case 1:
                            mensaje = "El Cliente: " + tablaCliPep.Rows[0]["cNombres"].ToString() + ", es PEP, Requiere Aprobación" + "\n Por favor actualizar su datos primero";
                            nResp = false;
                            break;
                        case 2:
                            mensaje = "";
                            nResp = true;
                            break;
                        case 3:
                            mensaje = "La Solicitud de Aprobación del Cliente PEP: " + tablaCliPep.Rows[0]["cNombres"].ToString() + ", Fue Rechazado, NO podrá Realizar la Operación";
                            nResp = false;
                            break;
                    }
                }                
            }
            else
            {
                nResp = true;
            }
            return nResp;
        }

    }
}
