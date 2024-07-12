using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMantenimientoHorario
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();


        public DataTable ListarDetalleHorarios(int idHorario)
        {
            return objEjeSp.EjecSP("GRH_ListarDetalleHorario_SP", idHorario);
        }
        public DataTable DatoHorarioNoc(int idHorario)
        {
            return objEjeSp.EjecSP("GRH_ConsultaHorNoctuno_SP", idHorario);
        }
        public void ActualizarHorario(int idDetalleHorario, int idDiaIngreso, DateTime HoraIngreso, int MinAntesIngreso,
                                                 int MinToleranciaIngreso, int MarcaIngreso, int idDiaSalida, DateTime HoraSalida, int MinAntesSalida,
                                                 int MinToleranciaSalida, int MarcaSalida, int Vigente)
        {
            objEjeSp.EjecSP("GRH_ActualizarHorario_SP", idDetalleHorario, idDiaIngreso, HoraIngreso, MinAntesIngreso,
                                                 MinToleranciaIngreso, MarcaIngreso, idDiaSalida, HoraSalida, MinAntesSalida,
                                                   MinToleranciaSalida, MarcaSalida, Vigente);

        }
        public DataTable GuardarHorario(int idHorario, int idDiaIngreso, DateTime HoraIngreso, int MinAntesIngreso,
                                                 int MinToleranciaIngreso, int MarcaIngreso, int idDiaSalida, DateTime HoraSalida, int MinAntesSalida,
                                                 int MinToleranciaSalida, int MarcaSalida, int Vigente)
        {
            return objEjeSp.EjecSP("GRH_GuardarHorario_SP",idHorario, idDiaIngreso, HoraIngreso, MinAntesIngreso,
                                                 MinToleranciaIngreso, MarcaIngreso, idDiaSalida, HoraSalida, MinAntesSalida,
                                                   MinToleranciaSalida, MarcaSalida, Vigente);

        }
        public DataTable ControlDuplicidad(int idHorario, int idDiaIngreso, DateTime HoraIngreso,
                                            int idDiaSalida, DateTime HoraSalida)
        {
            return objEjeSp.EjecSP("GRH_DuplicadoHorario_SP", idHorario, idDiaIngreso, HoraIngreso, 
                                                                idDiaSalida, HoraSalida);

        }
        public DataTable ADListarTurnosFechaUsuario(int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("GRH_ListarTurnosFechaUsuario_SP", idUsuario, dFecha);
        }
        public DataTable ADCrearNuevoHorario(string NombHorario, int lHorNocturno)
        {
            return objEjeSp.EjecSP("GRH_CrearHorario_SP", NombHorario, lHorNocturno);            
        }
       
        public DataTable ADEliminarHorario(int idHorario)
        {
            return objEjeSp.EjecSP("GRH_EliminarHorario_SP", idHorario);
        }
    }
}
