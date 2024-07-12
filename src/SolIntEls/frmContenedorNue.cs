using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace SolIntEls
{
    public partial class frmContenedorNue : frmBase
    {
        #region Variables

        DataTable dtmenu = new DataTable();
        public frm_Inicio FrmInicio;

        #endregion

        public frmContenedorNue(frm_Inicio x_Inicio)
        {
            this.FrmInicio = x_Inicio;
            InitializeComponent();
            asignarRespVentanilla();
            mostarLimiteCobertura();
            ptbImgFondo.ImageLocation = clsVarGlobal.cRutPathApp + @"\logoempresa.png";
            trvMenu.objTreeSemaforo = this.semaforo1;
        }

        private void asignarRespVentanilla()
        {
            DataTable dtData = new clsCNPerfilUsu().RetRespVentanilla(clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia);
            clsVarGlobal.PerfilUsu.lResVentanilla = dtData.Rows.Count > 0 ? Convert.ToBoolean(dtData.Rows[0]["lResVentanilla"]) : false;
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            asignarTitulo();
            mostrarTabPerfil();
            dtmenu = new clsCNMenu().LisTreeMenByPer(clsVarGlobal.PerfilUsu.idPerfil);
            trvMenu.LoadTree(FiltrarDT(dtmenu, 4));
            clsVarGlobal.idModulo = 4;
            LoadMenu();
            distribuirBotones();
            sstBase.ForeColor = Color.White;
            splcPrincipal.SplitterDistance = 100;
            splcPrincipal.IsSplitterFixed = true;
            splcOpciones.IsSplitterFixed = true;
            splcMenu.SplitterDistance = this.Width - splcMenu.Width + 255;
            ptbLogo.Location = new Point(ptbLogo.Parent.Width - 217, 4);
            lnkSolintels.Location = new Point(lnkSolintels.Parent.Width - 150, lnkSolintels.Parent.Height - 23);
            DataTable dtAlertas = new clsCNAlerta().ListarAlertas(clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            btnAlerta.Visible = (dtAlertas.Rows.Count > 0);
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 8));
            this.btnTituloModulo.Text = "ADMINISTRACIÓN";
            clsVarGlobal.idModulo = 8;
            asignaImagenSeleciionada(8, true);
        }

        private void btnGth_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 6));
            this.btnTituloModulo.Text = "PERSONAL";
            clsVarGlobal.idModulo = 6;
            asignaImagenSeleciionada(6, true);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 9));
            this.btnTituloModulo.Text = "SERVICIOS";
            clsVarGlobal.idModulo = 9;
            asignaImagenSeleciionada(9, true);
        }

        private void btnSplaft_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 10));
            this.btnTituloModulo.Text = "SPLAFT";
            clsVarGlobal.idModulo = 10;
            asignaImagenSeleciionada(10, true);
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 5));
            this.btnTituloModulo.Text = "CONTABILIDAD";
            clsVarGlobal.idModulo = 5;
            asignaImagenSeleciionada(5, true);
        }

        private void btbClientes_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 4));
            this.btnTituloModulo.Text = "CLIENTES";
            clsVarGlobal.idModulo = 4;
            asignaImagenSeleciionada(4, true);
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 1));
            this.btnTituloModulo.Text = "CRÉDITOS";
            clsVarGlobal.idModulo = 1;
            asignaImagenSeleciionada(1, true);
        }

        private void btnDepositos_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 2));
            this.btnTituloModulo.Text = "DEPÓSITOS";
            clsVarGlobal.idModulo = 2;
            asignaImagenSeleciionada(2, true);
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 3));
            this.btnTituloModulo.Text = "CAJA";
            clsVarGlobal.idModulo = 3;
            asignaImagenSeleciionada(3, true);
        }

        private void btnRecuperaciones_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 13));
            this.btnTituloModulo.Text = "RECUPERACIONES";
            clsVarGlobal.idModulo = 13;
            asignaImagenSeleciionada(13, true);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 11));
            this.btnTituloModulo.Text = "REPORTES";
            clsVarGlobal.idModulo = 11;
            asignaImagenSeleciionada(11, true);
        }

        private void btnCanales_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 12));
            this.btnTituloModulo.Text = "CANALES ELECTRONICOS";
            clsVarGlobal.idModulo = 12;
            asignaImagenSeleciionada(12, true);
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 7));
            this.btnTituloModulo.Text = "LOGÍSTICA";
            clsVarGlobal.idModulo = 7;
            asignaImagenSeleciionada(7, true);
        }

        private void btnGerencial_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 14));
            this.btnTituloModulo.Text = "GERENCIAL";
            clsVarGlobal.idModulo = 14;
            asignaImagenSeleciionada(14, true);
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 18));
            this.btnTituloModulo.Text = "PRESUPUESTOS";
            clsVarGlobal.idModulo = 18;
            asignaImagenSeleciionada(18, true);
        }

        private void asignaImagenSeleciionada(int idModulo, bool lSel)
        {
            #region Cambio de imagen
            if (idModulo == 1 && lSel)
            {
                this.btnCreditos.Image = SolIntEls.Properties.Resources.NewBtncreditosSel;
            }
            else
            {
                this.btnCreditos.Image = SolIntEls.Properties.Resources.NewBtncreditos;
            }

            if (idModulo == 2 && lSel)
            {
                this.btnDepositos.Image = SolIntEls.Properties.Resources.NewBtndepositosSel;
            }
            else
            {
                this.btnDepositos.Image = SolIntEls.Properties.Resources.NewBtndepositos;
            }

            if (idModulo == 3 && lSel)
            {
                this.btnCaja.Image = SolIntEls.Properties.Resources.NewBtncajaSel;
            }
            else
            {
                this.btnCaja.Image = SolIntEls.Properties.Resources.NewBtncaja;
            }

            if (idModulo == 4 && lSel)
            {
                this.btnClientes.Image = SolIntEls.Properties.Resources.NewBtnclientesSel;
            }
            else
            {
                this.btnClientes.Image = SolIntEls.Properties.Resources.NewBtnclientes;
            }

            if (idModulo == 5 && lSel)
            {
                this.btnContabilidad.Image = SolIntEls.Properties.Resources.NewBtncontabilidadSel;
            }
            else
            {
                this.btnContabilidad.Image = SolIntEls.Properties.Resources.NewBtncontabilidad;
            }

            if (idModulo == 6 && lSel)
            {
                this.btnGth.Image = SolIntEls.Properties.Resources.NewBtngthSel1;
            }
            else
            {
                this.btnGth.Image = SolIntEls.Properties.Resources.NewBtngth;
            }

            if (idModulo == 7 && lSel)
            {
                this.btnLogistica.Image = SolIntEls.Properties.Resources.logisticaSel;
            }
            else
            {
                this.btnLogistica.Image = SolIntEls.Properties.Resources.logistica;
            }

            if (idModulo == 8 && lSel)
            {
                this.btnAdministracion.Image = SolIntEls.Properties.Resources.NewBtnadministracionSel;
            }
            else
            {
                this.btnAdministracion.Image = SolIntEls.Properties.Resources.NewBtnadministracion;
            }

            if (idModulo == 9 && lSel)
            {
                this.btnServicios.Image = SolIntEls.Properties.Resources.NewBtnserviciosSel;
            }
            else
            {
                this.btnServicios.Image = SolIntEls.Properties.Resources.NewBtnservicios;
            }

            if (idModulo == 10 && lSel)
            {
                this.btnSplaft.Image = SolIntEls.Properties.Resources.NewBtnsplaftSel;
            }
            else
            {
                this.btnSplaft.Image = SolIntEls.Properties.Resources.NewBtnsplaft;
            }

            if (idModulo == 11 && lSel)
            {
                this.btnReportes.Image = SolIntEls.Properties.Resources.NewBtnreportesSel;
            }
            else
            {
                this.btnReportes.Image = SolIntEls.Properties.Resources.NewBtnreportes;
            }

            if (idModulo == 12 && lSel)
            {
                this.btnCanales.Image = SolIntEls.Properties.Resources.canalesSel;
            }
            else
            {
                this.btnCanales.Image = SolIntEls.Properties.Resources.canales1;
            }

            if (idModulo == 13 && lSel)
            {
                this.btnRecuperaciones.Image = SolIntEls.Properties.Resources.NewRecuperacionSel;
            }
            else
            {
                this.btnRecuperaciones.Image = SolIntEls.Properties.Resources.NewRecuperacion;
            }

            if (idModulo == 14 && lSel)
            {
                this.btnGerencial.Image = SolIntEls.Properties.Resources.NewBtnGerencialSel;
            }
            else
            {
                this.btnGerencial.Image = SolIntEls.Properties.Resources.NewBtnGerencial;
            }

            if (idModulo == 16 && lSel)
            {
                this.btnRiesgos.Image = SolIntEls.Properties.Resources.NewBtnRiesgo2;
            }
            else
            {
                this.btnRiesgos.Image = SolIntEls.Properties.Resources.NewBtnRiesgo;
            }
            if (idModulo == 18 && lSel)
            {
                this.btnPresupuestos.Image = SolIntEls.Properties.Resources.NewBtnPresupuestosSel;
            }
            else
            {
                this.btnPresupuestos.Image = SolIntEls.Properties.Resources.NewBtnPresupuestos;
            }
            if (idModulo == 19 && lSel)
            {
                this.btnTraDatos.Image = SolIntEls.Properties.Resources.NewBtntratadatosSel;
            }
            else
            {
                this.btnTraDatos.Image = SolIntEls.Properties.Resources.NewBtntratadatos;
            }
            #endregion
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            frmPerfil objPerfil = new frmPerfil();
            objPerfil.lisPerfiles = new clsCNPerfilUsu().ListarPerUsu(clsVarGlobal.User.idUsuario);
            objPerfil.ShowDialog();
            LoadMenu();
            asignarTitulo();
            mostrarTabPerfil();
            LoadMenu();
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 4));
            clsVarGlobal.idModulo = 4;
            this.btnTituloModulo.Text = "CLIENTES";
            if (trvMenu.nTotNodes <= 0)
            {
                this.btnTituloModulo.Text = "";
            }
            asignarRespVentanilla();
            mostarLimiteCobertura();
            distribuirBotones();
            asignaImagenSeleciionada(4, true);
        }

        private void splitContainer2_Panel2_SizeChanged(object sender, EventArgs e)
        {
            distribuirBotones();
        }

        private void btnImpresora_Click(object sender, EventArgs e)
        {
            PrintDialog impre = new PrintDialog();
            impre.ShowDialog();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            Process procCalculadora = new Process();
            procCalculadora.StartInfo.FileName = @"calc.exe";
            procCalculadora.Start();
            procCalculadora.WaitForExit();
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            frmPresentacion frmacercade = new frmPresentacion();
            frmacercade.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            string cRuta = clsVarGlobal.cRutPathApp + @"\HelpCoreBank.chm";
            Help.ShowHelp(this, cRuta);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            startInfo.Arguments = "www.solintels.com";
            Process.Start(startInfo);
        }

        private void btnReniec_Click(object sender, EventArgs e)
        {
            frmWebReniec frmwebreniec = new frmWebReniec();
            frmwebreniec.ShowDialog();
        }

        private void btnRiesgos_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 16));
            this.btnTituloModulo.Text = "RIESGOS";
            clsVarGlobal.idModulo = 16;
            asignaImagenSeleciionada(16, true);
        }

        private void btnAlerta_Click(object sender, EventArgs e)
        {
            frmAlertas frmAlertas = new frmAlertas();
            frmAlertas.ShowDialog();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Filtra el contenido seg'un el id del modulo
        /// </summary>
        /// <param name="dt">Contenido del menu</param>
        /// <param name="idModulo">id del modulo</param>
        /// <returns>Tabla de menu segun id</returns>
        private DataTable FiltrarDT(DataTable dt, int idModulo)
        {
            try
            {
                DataTable dtnew;
                var query = from d in dtmenu.AsEnumerable()
                            where Convert.ToInt32(d["idModulo"]) == idModulo
                            && Convert.ToInt32(d["idTipoMenu"]).In(1, 2)//solo windows
                            select d;
                if (query.Count() > 0)
                {
                    dtnew = query.CopyToDataTable();
                }
                else
                {
                    dtnew = new DataTable();
                }
                return dtnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Asigna el titulo del contenedor
        /// </summary>
        private void asignarTitulo()
        {
            string cTipCon = new Uri(System.Reflection.Assembly.GetExecutingAssembly().Location).IsUnc ? "Conexión: Remota" : "Conexión: Local";
            this.Text = "Core Bank V 1.5 | " + "Agencia: " +
                        clsVarGlobal.cNomAge.Trim() + " | " +
                        clsVarGlobal.User.cWinUser + " | " +
                        clsVarGlobal.PerfilUsu.cPerfil.Trim() + " | " +
                        clsVarGlobal.dFecSystem.ToLongDateString() + " | " +
                        cTipCon;

            lblAgencia.Text = clsVarGlobal.cNomAge.Trim();
            lblIdUsuario.Text = clsVarGlobal.User.idUsuario.ToString().Trim();
            lblUsuario.Text = clsVarGlobal.User.cWinUser.Trim();
            lblNomUsu.Text = clsVarGlobal.User.cNomUsu.Trim();
            lblPerfil.Text = clsVarGlobal.PerfilUsu.cPerfil.Trim();
            lblFecha.Text = clsVarGlobal.dFecSystem.ToLongDateString();
            lblVersion.Text = clsVarGlobal.User.cVersion;
            lblCategoria.Text = clsVarGlobal.cCategoria;
            lblEstablecimiento.Text = clsVarGlobal.User.cEstablecimiento;
        }

        /// <summary>
        /// Valida si tiene mas de un perfil y muestra el tab
        /// </summary>
        private void mostrarTabPerfil()
        {
            if (new clsCNPerfilUsu().ListarPerUsu(clsVarGlobal.User.idUsuario).Count == 1)
            {
                this.tbcBarraMenu.TabPages[1].Dispose();

            }
            else
            {
                this.tbcBarraMenu.TabPages[1].Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void mostarLimiteCobertura()
        {
            semaforo1.Visible = false;
            if (clsVarGlobal.PerfilUsu.lResVentanilla)
            {
                clsCNPerfilUsu Perfiles = new clsCNPerfilUsu();
                List<clsLimCobertura> listMontoCobertur = new List<clsLimCobertura>();
                listMontoCobertur = Perfiles.limiteCobertura(1, clsVarGlobal.nIdAgencia);
                if (listMontoCobertur.Count > 0)
                {
                    clsVarGlobal.montoCobertura = listMontoCobertur[0];
                    clsVarGlobal.PerfilUsu.lLimCobertura = true;
                    semaforo1.Visible = true;
                    lindicaEjecucion = true;
                    semaforo1.ValidarSaldoSemaforo();
                }
                else
                {
                    clsVarGlobal.PerfilUsu.lLimCobertura = false;
                }
            }
        }

        /// <summary>
        /// Carga los menus por perfil y muestra solo los modulo con accesos
        /// </summary>
        private void LoadMenu()
        {
            try
            {
                dtmenu = new clsCNMenu().LisTreeMenByPer(clsVarGlobal.PerfilUsu.idPerfil);

                if (FiltrarDT(dtmenu, 1).Rows.Count <= 0)
                    this.btnCreditos.Visible = false;
                else
                    this.btnCreditos.Visible = true;

                if (FiltrarDT(dtmenu, 2).Rows.Count <= 0)
                    this.btnDepositos.Visible = false;
                else
                    this.btnDepositos.Visible = true;

                if (FiltrarDT(dtmenu, 3).Rows.Count <= 0)
                    this.btnCaja.Visible = false;
                else
                    this.btnCaja.Visible = true;

                if (FiltrarDT(dtmenu, 4).Rows.Count <= 0)
                    this.btnClientes.Visible = false;
                else
                    this.btnClientes.Visible = true;

                if (FiltrarDT(dtmenu, 5).Rows.Count <= 0)
                    this.btnContabilidad.Visible = false;
                else
                    this.btnContabilidad.Visible = true;

                if (FiltrarDT(dtmenu, 6).Rows.Count <= 0)
                    this.btnGth.Visible = false;
                else
                    this.btnGth.Visible = true;

                if (FiltrarDT(dtmenu, 7).Rows.Count <= 0)
                    this.btnLogistica.Visible = false;
                else
                    this.btnLogistica.Visible = true;

                if (FiltrarDT(dtmenu, 8).Rows.Count <= 0)
                    this.btnAdministracion.Visible = false;
                else
                    this.btnAdministracion.Visible = true;

                if (FiltrarDT(dtmenu, 9).Rows.Count <= 0)
                    this.btnServicios.Visible = false;
                else
                    this.btnServicios.Visible = true;

                if (FiltrarDT(dtmenu, 10).Rows.Count <= 0)
                    this.btnSplaft.Visible = false;
                else
                    this.btnSplaft.Visible = true;

                if (FiltrarDT(dtmenu, 11).Rows.Count <= 0)
                    this.btnReportes.Visible = false;
                else
                    this.btnReportes.Visible = true;

                if (FiltrarDT(dtmenu, 12).Rows.Count <= 0)
                    this.btnCanales.Visible = false;
                else
                    this.btnCanales.Visible = true;

                if (FiltrarDT(dtmenu, 13).Rows.Count <= 0)
                    this.btnRecuperaciones.Visible = false;
                else
                    this.btnRecuperaciones.Visible = true;

                if (FiltrarDT(dtmenu, 14).Rows.Count <= 0)
                    this.btnGerencial.Visible = false;
                else
                    this.btnGerencial.Visible = true;

                if (FiltrarDT(dtmenu, 16).Rows.Count <= 0)
                    this.btnRiesgos.Visible = false;
                else
                    this.btnRiesgos.Visible = true;

                if (FiltrarDT(dtmenu, 18).Rows.Count <= 0)
                    this.btnPresupuestos.Visible = false;
                else
                    this.btnPresupuestos.Visible = true;

                if (FiltrarDT(dtmenu, 19).Rows.Count <= 0)
                    this.btnTraDatos.Visible = false;
                else
                    this.btnTraDatos.Visible = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void distribuirBotones()
        {
            Size xy = this.splcMenu.Size;
            int nEspacio = 55;
            int nEspacio2 = 5;
            int nDerecha = 9;
            int nDerecha2 = 254;

            foreach (Control item in this.splcMenu.Panel2.Controls)
            {
                if (item is Button)
                {
                    if (item.Visible == true)
                    {
                        if (nEspacio > xy.Height - 50)
                        {
                            nEspacio2 = nEspacio2 + 50;
                            ((Button)item).Location = new Point(nDerecha2, xy.Height - nEspacio2);
                        }
                        else
                        {
                            ((Button)item).Location = new Point(nDerecha, xy.Height - nEspacio);
                            nEspacio = nEspacio + 50;
                        }
                    }
                }
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            frmWebSbsDeudasPer frmwebsbsdeuda = new frmWebSbsDeudasPer();
            frmwebsbsdeuda.ShowDialog();
        }
        
        private void btnTituloModulo_TextChanged(object sender, EventArgs e)
        {
           this.semaforo1.oControlBoveda.comprobarLimiteBoveda();// descomentar cuando se pasa a produccion
        }

        private void btnTraDatos_Click(object sender, EventArgs e)
        {
            this.trvMenu.LoadTree(FiltrarDT(dtmenu, 19));
            this.btnTituloModulo.Text = "AUTORIZACIÓN DATOS";
            clsVarGlobal.idModulo = 19;
            asignaImagenSeleciionada(19, true);
        }

    }
}
