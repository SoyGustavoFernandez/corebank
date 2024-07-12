using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityLayer
{
    /// <summary>
    /// Clase que representa un control u objeto dentro de un formulario
    /// </summary>
    public class clsControl
    {
        public int idControl { get; set; }
        public int idFormulario { get; set; }
        public string cControl { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public Control control { get; set; }
        public int idTipoEvento { get; set; }
        

        public override string ToString()
        {
            return cControl;
        }
    }

    /// <summary>
    /// Coleccion de la entidad control, y representa la entidad formulario
    /// </summary>
    public class clslisControl : List<clsControl>
    {
        public int idFormulario { get; set; }
        public string cFormulario { get; set; }
        
    }

    /// <summary>
    /// entidad formulario
    /// </summary>
    public class clsFormulario
    {
        public int idFormulario { get; set; }
        public string cFormulario { get; set; }
        public clslisControl lisControles { get; set; }
        public int idModulo { get; set; }
        public int idEstado { get; set; }
        public int idTipoForm { get; set; }

        public override string ToString()
        {
            return cFormulario;
        }
    }

    public class clslisFormulario:List<clsFormulario>
    {
        
    }

    public enum EstadoFormulario
    {
        RegistradoBD=1,
        NoRegistradoBD=0,
        Actualizar=2
    }

    public class clsTipoEvento
    {
        public int idTipoEvento { get; set; }
        public string cEvento { get; set; }
    }


    public enum EventoFormulario
    {
        INICIO      = 1,
        NUEVO       = 2,
        EDITAR      = 3,
        CANCELAR    = 4,
        GRABAR      = 5,
        IMPRIMIR    = 6,
        ENVIAR      = 7
    }

    public enum Transaccion
    {
        Nuevo = 1,
        Edita = 2,
        Elimina = 3,
        Selecciona = 4
    }

    public class TipoCorrespondencia
    {
        public static int CancelaCredito = 1;
        public static int PagoXCuota = 2;
        public static int Refinanciamiento = 3;
    }

    public enum TranPlanPagos
    {
        Nuevo = 1,
        Selecciona = 2,
        Procesa = 3,
        Graba = 4,
        VinculaImpr = 5
    }
}