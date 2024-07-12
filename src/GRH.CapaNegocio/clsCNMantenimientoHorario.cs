using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNMantenimientoHorario
    {
        clsADMantenimientoHorario ListaHorarios = new clsADMantenimientoHorario();
        public DataTable ListarDetalleHorarios(int idHorario) {
            return ListaHorarios.ListarDetalleHorarios(idHorario);
        
        }
        public int DatoHorarioNoc(int idHorario)
        {
            DataTable dt= ListaHorarios.DatoHorarioNoc(idHorario);
            int HorNoc=Convert.ToInt32(dt.Rows[0][0]);
            return HorNoc;
        
        }
        public void ActualizarHorario(int idDetalleHorario,int idDiaIngreso, DateTime HoraIngreso, int MinAntesIngreso, 
                                                 int MinToleranciaIngreso,int MarcaIngreso,int idDiaSalida,DateTime HoraSalida,int MinAntesSalida,
                                                 int MinToleranciaSalida,int MarcaSalida,int Vigente) {
           ListaHorarios.ActualizarHorario(idDetalleHorario, idDiaIngreso, HoraIngreso, MinAntesIngreso, 
                                                  MinToleranciaIngreso,MarcaIngreso,idDiaSalida, HoraSalida,MinAntesSalida,
                                                   MinToleranciaSalida, MarcaSalida, Vigente);
        
        }
        public int GuardarHorario(int idHorario,int idDiaIngreso, DateTime HoraIngreso, int MinAntesIngreso,
                                                 int MinToleranciaIngreso, int MarcaIngreso, int idDiaSalida, DateTime HoraSalida, int MinAntesSalida,
                                                 int MinToleranciaSalida, int MarcaSalida, int Vigente)
        {
            DataTable tbIDHorario = ListaHorarios.GuardarHorario(idHorario, idDiaIngreso, HoraIngreso, MinAntesIngreso,
                                                               MinToleranciaIngreso, MarcaIngreso, idDiaSalida, HoraSalida, MinAntesSalida, 
                                                               MinToleranciaSalida, MarcaSalida, Vigente);
            int NuevoId = Convert.ToInt32(tbIDHorario.Rows[0][0]);
            return NuevoId;

        }
        public DataTable ControlDuplicidad(int idHorario,int idDiaIngreso, DateTime HoraIngreso, 
                                            int idDiaSalida,DateTime HoraSalida) {
            return ListaHorarios.ControlDuplicidad(idHorario, idDiaIngreso, HoraIngreso, 
                                                idDiaSalida, HoraSalida);
        
        }
        public DataTable CNListarTurnosFechaUsuario(int idUsuario, DateTime dFecha)
        {
            return ListaHorarios.ADListarTurnosFechaUsuario(idUsuario, dFecha);
        }
        public int CNCrearNuevoHorario(string NombHorario, int lHorNocturno)
        {
            DataTable dtHorario = ListaHorarios.ADCrearNuevoHorario(NombHorario, lHorNocturno);
            int idHorario= Convert.ToInt32(dtHorario.Rows[0][0]);
            return idHorario;
        }       
        public int CNEliminarHorario(int idHorario)
        {
            DataTable tbHorario=ListaHorarios.ADEliminarHorario(idHorario);
            int CantAsignaciones=Convert.ToInt32(tbHorario.Rows[0][0]);
            return CantAsignaciones;
        }
         
    }
}
