using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNFormulario
    {
        clsADFormulario objform = new clsADFormulario();

        public EstadoFormulario validarRegFormulario(string cNombreForm)
        {
            EstadoFormulario estado= EstadoFormulario.NoRegistradoBD;

            ArrayList prmSalida = objform.validarRegFormulario(cNombreForm);

            if (prmSalida[0].ToString()=="0")
            {
                estado= EstadoFormulario.NoRegistradoBD;
            }
            if (prmSalida[0].ToString()=="1")
            {
                estado = EstadoFormulario.RegistradoBD;
            }

            if (prmSalida[0].ToString() == "1" && prmSalida[1].ToString() == "2")
            {
                estado = EstadoFormulario.Actualizar;
            }

            return estado;
        }

        public void insertarControles(clsFormulario formulario)
        {
            objform.insertarControles(formulario);
        }

        public void actualizarControles(clsFormulario formulario) 
        {
            objform.actualizarControles(formulario);
        }

        public clslisControl listarcontrolesByPerfil(string cNombreForm, int idPerfil, int idTipoEvento)
        {
            return objform.listarcontrolesByPerfil(cNombreForm, idPerfil, idTipoEvento);
        }

        public clslisFormulario listarFormularios(int idModulo)
        {
            return objform.listarFormularios(idModulo);
        }

        public clslisControl listarcontrolesByForm(string cNombreForm, int idPerfil, int idTipoEvento)
        {
            return objform.listarcontrolesByForm(cNombreForm, idPerfil, idTipoEvento);
        }

        public void insertarCrontorlByPerfil(clslisControl listacontroles, int idPerfil, int idTipoEvento)
        {
            objform.insertarCrontorlByPerfil(listacontroles, idPerfil, idTipoEvento);
        }
    }
}
