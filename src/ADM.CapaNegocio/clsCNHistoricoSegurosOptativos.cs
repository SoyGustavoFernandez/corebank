using ADM.AccesoDatos;
using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ADM.CapaNegocio
{
    public class clsCNHistoricoSegurosOptativos
    {
        clsADHistoricoSegurosOptativos clsADHistoricoSegurosOptativos = new clsADHistoricoSegurosOptativos();
        SI_FINHSeguroOptativoCabecera sI_FINHSeguroOptativoCabecera = new SI_FINHSeguroOptativoCabecera();

        public void MapearHistoricoSeguro(string accion, AccionHistorico intAccion, clsMantenimientoSeguroOptativo clsDatosSeguroOpt, clsHistoricoSegurosOptativos objHistoricoSegurosOptativos, bool lPerfilModificado)
        {
            var seguro = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.FirstOrDefault(x => x.nTipoSeguro == clsDatosSeguroOpt.idTipoSeguro);

            if (seguro != null)
            {
                if (intAccion == AccionHistorico.AGREGAR)
                {
                    //Implementar en caso se requiera
                }
                else
                {
                    seguro.nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
                    seguro.cTipoSeguro = clsDatosSeguroOpt.cTipoSeguro;
                    seguro.nPrimaSeguro = clsDatosSeguroOpt.nValor;
                    seguro.nTipoValor = clsDatosSeguroOpt.idTipoValSegOptativo;
                    seguro.cTipoValor = clsDatosSeguroOpt.cTipoValSegOptativo;
                    seguro.nConceptoRecibo = clsDatosSeguroOpt.idConcepto;
                    seguro.cConceptoRecibo = clsDatosSeguroOpt.cConcepto;
                    seguro.nTipoPago = clsDatosSeguroOpt.idTipoPagoSeguroOptativo;
                    seguro.cTipoPago = clsDatosSeguroOpt.cTipoPagoSeguroOptativo;
                    seguro.lVigente = clsDatosSeguroOpt.lvigente;
                    seguro.cModificacion = accion;
                    seguro.idAccion = intAccion;
                }
                GuardarHistoricoSegurosOptativos(objHistoricoSegurosOptativos, intAccion);
            }
        }

        public void MapearHistoricoSeguroPerfil(string accion, AccionHistorico intAccion, clsMantenimientoSeguroOptativo clsDatosSeguroOpt, clsHistoricoSegurosOptativos objHistoricoSegurosOptativos)
        {
            var seguro = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.FirstOrDefault(x => x.nTipoSeguro == clsDatosSeguroOpt.idTipoSeguro);

            if (seguro != null)
            {
                if (intAccion == AccionHistorico.AGREGAR)
                {
                    seguro.lstPerfil.Add(new Perfiles
                    {
                        nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro,
                        nPerfil = clsDatosSeguroOpt.idPerfil,
                        cAutorizado = clsDatosSeguroOpt.lAutorizadoPerfil ? "SI" : "NO",
                        cModificacion = accion
                    });
                }
                else
                {
                    var perfil = seguro.lstPerfil.FirstOrDefault(y => y.nPerfil == clsDatosSeguroOpt.idPerfil);

                    if (perfil != null)
                    {
                        perfil.nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
                        perfil.nPerfil = clsDatosSeguroOpt.idPerfil;
                        perfil.cAutorizado = clsDatosSeguroOpt.lAutorizadoPerfil ? "SI" : "NO";
                        perfil.cModificacion = accion;
                    }
                }
                seguro.idAccion = intAccion;
                seguro.cModificacion = accion;
                GuardarHistoricoSegurosOptativos(objHistoricoSegurosOptativos, intAccion);
            }
        }

        public void MapearHistoricoSeguroAgencia(string accion, AccionHistorico intAccion, clsMantenimientoSeguroOptativo clsDatosSeguroOpt, clsHistoricoSegurosOptativos objHistoricoSegurosOptativos)
        {
            var seguro = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.FirstOrDefault(x => x.nTipoSeguro == clsDatosSeguroOpt.idTipoSeguro);

            if (seguro != null)
            {
                if (intAccion == AccionHistorico.AGREGAR)
                {
                    seguro.lstAgencia.Add(new Agencias
                    {
                        nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro,
                        nAgencia = clsDatosSeguroOpt.idAgencia,
                        cAutorizado = clsDatosSeguroOpt.lAutorizadoAgencia ? "SI" : "NO",
                        cModificacion = accion
                    });
                }
                else
                {
                    var agencia = seguro.lstAgencia.FirstOrDefault(y => y.nAgencia == clsDatosSeguroOpt.idAgencia);

                    if (agencia != null)
                    {
                        agencia.nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
                        agencia.nAgencia = clsDatosSeguroOpt.idAgencia;
                        agencia.cAutorizado = clsDatosSeguroOpt.lAutorizadoAgencia ? "SI" : "NO";
                        agencia.cModificacion = accion;
                    }
                }
                seguro.idAccion = intAccion;
                seguro.cModificacion = accion;

                GuardarHistoricoSegurosOptativos(objHistoricoSegurosOptativos, intAccion);

            }
        }

        public void MapearHistoricoSeguroProducto(string accion, AccionHistorico intAccion, clsMantenimientoSeguroOptativo clsDatosSeguroOpt, clsHistoricoSegurosOptativos objHistoricoSegurosOptativos)
        {
            var seguro = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.FirstOrDefault(x => x.nTipoSeguro == clsDatosSeguroOpt.idTipoSeguro);

            if (seguro != null)
            {
                if (intAccion == AccionHistorico.AGREGAR)
                {
                    seguro.lstProducto.Add(new Productos
                    {
                        nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro,
                        nSubProducto = clsDatosSeguroOpt.idSubProducto,
                        cAutorizado = clsDatosSeguroOpt.lAutorizadoProducto ? "SI" : "NO",
                        cModificacion = accion
                    });
                }
                else
                {
                    var producto = seguro.lstProducto.FirstOrDefault(y => y.nSubProducto == clsDatosSeguroOpt.idSubProducto);

                    if (producto != null)
                    {
                        producto.nTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
                        producto.nSubProducto = clsDatosSeguroOpt.idSubProducto;
                        producto.cAutorizado = clsDatosSeguroOpt.lAutorizadoProducto ? "SI" : "NO";
                        producto.cModificacion = accion;
                    }
                }
                seguro.idAccion = intAccion;
                seguro.cModificacion = accion;

                GuardarHistoricoSegurosOptativos(objHistoricoSegurosOptativos, intAccion);
            }
        }

        public void MapearHistoricoSeguroPlanes(string accion, AccionHistorico intAccion, clsMantenimientoPlanSeguroVida clsListaPlanSeguro, clsHistoricoSegurosOptativos objHistoricoSegurosOptativos)
        {
            var seguro = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.FirstOrDefault(x => x.nTipoSeguro == clsListaPlanSeguro.idTipoSeguro);

            if (seguro != null)
            {
                if (intAccion == AccionHistorico.AGREGAR)
                {
                    seguro.lstPlanSeguroOptativo.Add(new PlanesSeguroOptativo
                    {
                        nTipoPlan = clsListaPlanSeguro.idTipoPlan,
                        nTipoSeguro = clsListaPlanSeguro.idTipoSeguro,
                        nMeses = clsListaPlanSeguro.nMeses,
                        cDescripcion = clsListaPlanSeguro.cDescripcion,
                        cFijo = clsListaPlanSeguro.lFijo ? "SI" : "NO",
                        cSolicitud = clsListaPlanSeguro.lSolicitud ? "SI" : "NO",
                        cRedondear = clsListaPlanSeguro.lRedondear ? "SI" : "NO",
                        nPrecio = clsListaPlanSeguro.nPrecioMensual,
                        cModificacion = accion
                    });
                }
                else
                {
                    var plan = seguro.lstPlanSeguroOptativo.FirstOrDefault(y => y.nTipoPlan == clsListaPlanSeguro.idTipoPlan);

                    if (plan != null)
                    {
                        plan.nTipoPlan = clsListaPlanSeguro.idTipoPlan;
                        plan.nTipoSeguro = clsListaPlanSeguro.idTipoSeguro;
                        plan.nMeses = clsListaPlanSeguro.nMeses;
                        plan.cDescripcion = clsListaPlanSeguro.cDescripcion;
                        plan.cFijo = clsListaPlanSeguro.lFijo ? "SI" : "NO";
                        plan.cSolicitud = clsListaPlanSeguro.lSolicitud ? "SI" : "NO";
                        plan.cRedondear = !clsListaPlanSeguro.lRedondear ? "SI" : "NO";
                        plan.nPrecio = clsListaPlanSeguro.nPrecioMensual;
                        plan.cModificacion = accion;
                    }
                }
                seguro.idAccion = intAccion;
                seguro.cModificacion = accion;

                GuardarHistoricoSegurosOptativos(objHistoricoSegurosOptativos, intAccion);
            }
        }

        private void GuardarHistoricoSegurosOptativos(clsHistoricoSegurosOptativos objHistoricoSegurosOptativos, AccionHistorico intAccion)
        {
            List<clsFrmEditarSeguroOptativo> lstHistoricoSegurosOptativosTMP_nuevo = new List<clsFrmEditarSeguroOptativo>();
            List<clsFrmEditarSeguroOptativo> lstHistoricoSegurosOptativosTMP_anterior = new List<clsFrmEditarSeguroOptativo>(objHistoricoSegurosOptativos.objSeguroOptativoAnterior);
            clsHistoricoSegurosOptativos objHistoricoSegurosOptativosTMP = new clsHistoricoSegurosOptativos();

            //Identifico todos los registros que tengam modificaciones
            lstHistoricoSegurosOptativosTMP_nuevo = objHistoricoSegurosOptativos.objSeguroOptativoNuevo.FindAll(x => x.idAccion != AccionHistorico.NINGUNA);
            lstHistoricoSegurosOptativosTMP_anterior.RemoveAll(x => !lstHistoricoSegurosOptativosTMP_nuevo.Select(y => y.nTipoSeguro).Contains(x.nTipoSeguro));

            //Elimino las listas no modificadas
            lstHistoricoSegurosOptativosTMP_nuevo.ForEach(item =>
            {
                item.lstProducto.RemoveAll(x => x.cModificacion == string.Empty);
                item.lstPerfil.RemoveAll(x => x.cModificacion == string.Empty);
                item.lstAgencia.RemoveAll(x => x.cModificacion == string.Empty);
                item.lstPlanSeguroOptativo.RemoveAll(x => x.cModificacion == string.Empty);
            });

            lstHistoricoSegurosOptativosTMP_anterior.ForEach(item =>
            {
                item.lstProducto.RemoveAll(x => !lstHistoricoSegurosOptativosTMP_nuevo.SelectMany(y => y.lstProducto).Select(y => y.nSubProducto).Contains(x.nSubProducto));
                item.lstPerfil.RemoveAll(x => !lstHistoricoSegurosOptativosTMP_nuevo.SelectMany(y => y.lstPerfil).Select(y => y.nPerfil).Contains(x.nPerfil));
                item.lstAgencia.RemoveAll(x => !lstHistoricoSegurosOptativosTMP_nuevo.SelectMany(y => y.lstAgencia).Select(y => y.nAgencia).Contains(x.nAgencia));
                item.lstPlanSeguroOptativo.RemoveAll(x => !lstHistoricoSegurosOptativosTMP_nuevo.SelectMany(y => y.lstPlanSeguroOptativo).Select(y => y.nTipoPlan).Contains(x.nTipoPlan));
            });

            objHistoricoSegurosOptativosTMP.objSeguroOptativoNuevo = lstHistoricoSegurosOptativosTMP_nuevo;
            objHistoricoSegurosOptativosTMP.objSeguroOptativoAnterior = lstHistoricoSegurosOptativosTMP_anterior;

            //INICIALIZO LISTA PARA EL MAPEO E INSERCIÓN EN BD
            sI_FINHSeguroOptativoCabecera.lstProductos = new List<SI_FINDSeguroOptativoProductos>();
            sI_FINHSeguroOptativoCabecera.lstPerfiles = new List<SI_FINDSeguroOptativoPerfiles>();
            sI_FINHSeguroOptativoCabecera.lstAgencias = new List<SI_FINDSeguroOptativoAgencias>();
            sI_FINHSeguroOptativoCabecera.lstPlanes = new List<SI_FINDSeguroOptativoPlanes>();

            var cabeceraNuevo = objHistoricoSegurosOptativosTMP.objSeguroOptativoNuevo.FirstOrDefault();
            var cabeceraAnterior = objHistoricoSegurosOptativosTMP.objSeguroOptativoAnterior.FirstOrDefault();

            if (cabeceraAnterior != null && cabeceraNuevo != null)
            {
                sI_FINHSeguroOptativoCabecera = new SI_FINHSeguroOptativoCabecera
                {
                    nTipoSeguro = cabeceraAnterior.nTipoSeguro,
                    cTipoSeguro = cabeceraAnterior.cTipoSeguro,
                    cTipoSeguroMod = cabeceraNuevo.cTipoSeguro,
                    nPrimaSeguro = cabeceraAnterior.nPrimaSeguro,
                    nPrimaSeguroMod = cabeceraNuevo.nPrimaSeguro,
                    nTipoValor = cabeceraAnterior.nTipoValor,
                    nTipoValorMod = cabeceraNuevo.nTipoValor,
                    nConceptoRecibo = cabeceraAnterior.nConceptoRecibo,
                    nConceptoReciboMod = cabeceraNuevo.nConceptoRecibo,
                    nTipoPago = cabeceraAnterior.nTipoPago,
                    nTipoPagoMod = cabeceraNuevo.nTipoPago,
                    lVigente = cabeceraAnterior.lVigente,
                    lVigenteMod = cabeceraNuevo.lVigente,
                    cModificacion = cabeceraNuevo.cModificacion == string.Empty ? cabeceraAnterior.cModificacion : cabeceraNuevo.cModificacion,
                    idAccion = (int)intAccion,
                    idUsuario = clsVarGlobal.User.idUsuario,

                    lstProductos = cabeceraAnterior.lstProducto.Select(p => new SI_FINDSeguroOptativoProductos
                    {
                        nTipoSeguro = p.nTipoSeguro,
                        nSubProducto = p.nSubProducto,
                        cAutorizado = p.cAutorizado,
                    }).ToList(),

                    lstPerfiles = cabeceraAnterior.lstPerfil.Select(pf => new SI_FINDSeguroOptativoPerfiles
                    {
                        nTipoSeguro = pf.nTipoSeguro,
                        nPerfil = pf.nPerfil,
                        cAutorizado = pf.cAutorizado,
                    }).ToList(),

                    lstAgencias = cabeceraAnterior.lstAgencia.Select(a => new SI_FINDSeguroOptativoAgencias
                    {
                        nTipoSeguro = a.nTipoSeguro,
                        nAgencia = a.nAgencia,
                        cAutorizado = a.cAutorizado,
                    }).ToList(),

                    lstPlanes = cabeceraAnterior.lstPlanSeguroOptativo.Select(pl => new SI_FINDSeguroOptativoPlanes
                    {
                        nTipoPlan = pl.nTipoPlan,
                        nTipoSeguro = pl.nTipoSeguro,
                        nPrecio = pl.nPrecio,
                        nMeses = pl.nMeses,
                        cFijo = pl.cFijo,
                        cSolicitud = pl.cSolicitud,
                        cRedondear = pl.cRedondear,
                        cDescripcion = pl.cDescripcion,
                    }).ToList()
                };

                // Actualizar lstProductos
                foreach (var nuevoProducto in cabeceraNuevo.lstProducto)
                {
                    var productoExistente = sI_FINHSeguroOptativoCabecera.lstProductos.FirstOrDefault(p => p.nTipoSeguro == nuevoProducto.nTipoSeguro);

                    if (productoExistente != null)
                    {
                        productoExistente.nTipoSeguro = nuevoProducto.nTipoSeguro;
                        productoExistente.nSubProductoMod = nuevoProducto.nSubProducto;
                        productoExistente.cAutorizadoMod = nuevoProducto.cAutorizado;
                    }
                    else
                    {
                        sI_FINHSeguroOptativoCabecera.lstProductos.Add(new SI_FINDSeguroOptativoProductos
                        {
                            nTipoSeguro = nuevoProducto.nTipoSeguro,
                            nSubProductoMod = nuevoProducto.nSubProducto,
                            cAutorizadoMod = nuevoProducto.cAutorizado
                        });
                    }
                }

                // Actualizar lstPerfiles
                foreach (var nuevoPerfil in cabeceraNuevo.lstPerfil)
                {
                    var perfilExistente = sI_FINHSeguroOptativoCabecera.lstPerfiles.FirstOrDefault(pf => pf.nTipoSeguro == nuevoPerfil.nTipoSeguro);

                    if (perfilExistente != null)
                    {
                        perfilExistente.nTipoSeguro = nuevoPerfil.nTipoSeguro;
                        perfilExistente.nPerfilMod = nuevoPerfil.nPerfil;
                        perfilExistente.cAutorizadoMod = nuevoPerfil.cAutorizado;
                    }
                    else
                    {
                        sI_FINHSeguroOptativoCabecera.lstPerfiles.Add(new SI_FINDSeguroOptativoPerfiles
                        {
                            nTipoSeguro = nuevoPerfil.nTipoSeguro,
                            nPerfilMod = nuevoPerfil.nPerfil,
                            cAutorizadoMod = nuevoPerfil.cAutorizado
                        });
                    }
                }

                // Actualizar lstAgencias
                foreach (var nuevaAgencia in cabeceraNuevo.lstAgencia)
                {
                    var agenciaExistente = sI_FINHSeguroOptativoCabecera.lstAgencias.FirstOrDefault(a => a.nTipoSeguro == nuevaAgencia.nTipoSeguro);

                    if (agenciaExistente != null)
                    {
                        agenciaExistente.nTipoSeguro = nuevaAgencia.nTipoSeguro;
                        agenciaExistente.nAgenciaMod = nuevaAgencia.nAgencia;
                        agenciaExistente.cAutorizadoMod = nuevaAgencia.cAutorizado;
                    }
                    else
                    {
                        sI_FINHSeguroOptativoCabecera.lstAgencias.Add(new SI_FINDSeguroOptativoAgencias
                        {
                            nTipoSeguro = nuevaAgencia.nTipoSeguro,
                            nAgenciaMod = nuevaAgencia.nAgencia,
                            cAutorizadoMod = nuevaAgencia.cAutorizado
                        });
                    }
                }

                // Actualizar lstPlanes
                foreach (var nuevoPlan in cabeceraNuevo.lstPlanSeguroOptativo)
                {
                    var planExistente = sI_FINHSeguroOptativoCabecera.lstPlanes.FirstOrDefault(pl => pl.nTipoSeguro == nuevoPlan.nTipoSeguro && pl.nTipoPlan == nuevoPlan.nTipoPlan);

                    if (planExistente != null)
                    {
                        planExistente.nTipoPlan = nuevoPlan.nTipoPlan;
                        planExistente.nTipoSeguro = nuevoPlan.nTipoSeguro;
                        planExistente.nPrecioMod = nuevoPlan.nPrecio;
                        planExistente.nMesesMod = nuevoPlan.nMeses;
                        planExistente.cFijoMod = nuevoPlan.cFijo;
                        planExistente.cSolicitudMod = nuevoPlan.cSolicitud;
                        planExistente.cRedondear = nuevoPlan.cRedondear;
                        planExistente.cDescripcionMod = nuevoPlan.cDescripcion;
                    }
                    else
                    {
                        sI_FINHSeguroOptativoCabecera.lstPlanes.Add(new SI_FINDSeguroOptativoPlanes
                        {
                            nTipoPlan = nuevoPlan.nTipoPlan,
                            nTipoSeguro = nuevoPlan.nTipoSeguro,
                            nPrecioMod = nuevoPlan.nPrecio,
                            nMesesMod = nuevoPlan.nMeses,
                            cFijoMod = nuevoPlan.cFijo,
                            cSolicitudMod = nuevoPlan.cSolicitud,
                            cRedondearMod = nuevoPlan.cRedondear,
                            cDescripcionMod = nuevoPlan.cDescripcion
                        });
                    }
                }

                string xmlHistorico = clsUtils.toXmlObject(sI_FINHSeguroOptativoCabecera);

                clsADHistoricoSegurosOptativos.GuardarHistoricoSegurosOptativos(xmlHistorico);
            }
        }

        public DataTable CNObtenerHistoricoSegurosOptativos(DateTime dFechaDesde, DateTime dFechaHasta, int idSeguro)
        {
            return clsADHistoricoSegurosOptativos.CNObtenerHistoricoSegurosOptativos(dFechaDesde, dFechaHasta, idSeguro);
        }
    }
}