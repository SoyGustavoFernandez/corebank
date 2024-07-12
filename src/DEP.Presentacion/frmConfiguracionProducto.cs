using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmConfiguracionProducto : frmBase
    {
        public DataTable tbProduc;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        DataTable tbTipPerPermitida;
        DataTable dtTipCtaPermitido;
        DataTable dtTipRenovPermitido;
        DataTable dtTipPagoIntPermitido;
        DataTable tbTipPer ;
        DataTable dtTipCuenta; 
        DataTable dtTipRenov;
        DataTable dtTipPago;

        public frmConfiguracionProducto()
        {
            InitializeComponent();
        }
        private void frmMantenimientoProducto_Load(object sender, EventArgs e)
        {
            this.cboProducto1.CargarProducto(46);
            this.cboProdTasaCancel.CargarProducto(55);
            this.cboProdTasaRenov.CargarProducto(56);
            CargarTiposcapitalizacion();
            CargarProductos("P", 0);
            CargarListBoxGeneral();
            CargarListBoxPermitidos(0);
            LimpiarControles();
            HabilitarControles(false);
            RBTodos.Checked = true;
            this.cboProdTasaRenov.Enabled = false;
            this.CBRenovTasa.Enabled = false;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cboProducto4.SelectedIndex <= 0 && !RBTodos.Checked)
            {
                MessageBox.Show("Debe Seleccionar el Sub Producto para la Búsqueda", "Búsqueda de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto4.Focus();
                return;
            }
            Buscar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
     {
         pcTipOpe = "A";         
         HabilitarControles(true);
         this.cboProducto1.Enabled = false;
         this.cboProducto2.Enabled = false;
         this.cboProducto3.Enabled = false;
         this.cboProducto4.Enabled = false;
         this.cboMoneda.Enabled = false;
                     
         if (CBInactividad.Checked == false)
         {
             this.txtPlazoInactiv.Enabled=false;
             this.txtPlazoCancel.Enabled=false;
         }
         if (CBPlazoProd.Checked == false)
         {
             this.txtPlazoMinProd.Enabled=false;
             this.txtPlazoMaxProd.Enabled=false;
             this.CBReqPagInt.Enabled=false;
             this.CBDepTipPagInt.Enabled=false;
             this.CBRenovProd.Enabled=false;
             this.CBRequCert.Enabled = false;
             if (Convert.ToInt32(cboProducto3.SelectedValue) == 56)
             {
                this.CBRenovTasa.Enabled = false;
                this.cboProdTasaRenov.Enabled = false;
             }
         }

         
         this.btnNuevo.Enabled = false;
         this.btnEditar.Enabled = false;
         this.btnGrabar.Enabled = true;
         this.btnCancelar.Enabled = true;
         this.btnProcesar.Enabled = false;
         dtgproductos.Enabled = false;
     }
        private void btnNuevo_Click(object sender, EventArgs e)
         {
             pcTipOpe = "N";
             tbProduc.Rows.Clear();
             LimpiarControles();
             HabilitarControles(true);
             this.btnNuevo.Enabled = false;
             this.btnEditar.Enabled = false;
             this.btnGrabar.Enabled = true;
             this.btnCancelar.Enabled = true;
             this.btnProcesar.Enabled = false;

             this.CBEstado.Checked = true;
             this.CBEstado.Enabled = false;
             RBTodos.Checked = false;
             RBFiltrar.Checked = false;

            // AL INICIAR DEBE ESTAR VISIBLE
             this.lblProdTasaCanc.Visible = true;
             this.cboProdTasaCancel.Visible = true;

             this.cboProdTasaRenov.Visible = true;


             //CAMBIA DE CHECKED PARA QUE SE ACTIVE EL EVENTO
             this.CBInactividad.Checked = true;
             this.CBInactividad.Checked = false;
             this.CBPlazoProd.Checked = true;
             this.CBPlazoProd.Checked = false;

             CargarListBoxGeneral();


         
         }
        private void CargarListBoxGeneral() {
            clsCNTipoPersona ListadoTipoPersona = new clsCNTipoPersona();
            tbTipPer = ListadoTipoPersona.listarTipoPersona();
            LBTipPerNoPermite.DataSource = tbTipPer;
            LBTipPerNoPermite.DisplayMember = "cTipoPersona";
            LBTipPerNoPermite.ValueMember = "idTipoPersona";

            clsCNTipoCuenta ListaTipoCuenta = new clsCNTipoCuenta();
            dtTipCuenta = ListaTipoCuenta.LisTipoCuenta();
            LBTipCtaNoPermite.DataSource = dtTipCuenta;
            LBTipCtaNoPermite.ValueMember = "idTipoCuenta";
            LBTipCtaNoPermite.DisplayMember = "cTipoCuenta";

            clsCNOperacionDep ListaRenov = new clsCNOperacionDep();
            dtTipRenov = ListaRenov.ListaTipoRenovacion();
            LBTipRenovNoPermite.DataSource = dtTipRenov;
            LBTipRenovNoPermite.ValueMember = "IdRenovacion";
            LBTipRenovNoPermite.DisplayMember = "cDescripcion";

            clsCNTipPagoInt ListaTipPago = new clsCNTipPagoInt();
            dtTipPago = ListaTipPago.ListarTipPagoInt();
            LBTipPagoNoPermite.DataSource = dtTipPago;
            LBTipPagoNoPermite.ValueMember = "IdPagoInt";
            LBTipPagoNoPermite.DisplayMember = "cDescripcion";

        }
        private void CargarListBoxPermitidos(int idProducto)
        {

            clsCNProductos TipoPersPermitido = new clsCNProductos();
            tbTipPerPermitida = TipoPersPermitido.TipoPersXprod(idProducto);
            LBTipPerPermite.DataSource = tbTipPerPermitida;
            LBTipPerPermite.ValueMember = "idTipoPersona";
            LBTipPerPermite.DisplayMember = "cTipoPersona";            

            clsCNProductos TipoCtaPermitido = new clsCNProductos();
            dtTipCtaPermitido = TipoCtaPermitido.TipoCtaXprod(idProducto);
            LBTipCtaPermite.DataSource = dtTipCtaPermitido;
            LBTipCtaPermite.ValueMember = "idTipoCuenta";
            LBTipCtaPermite.DisplayMember = "cTipoCuenta";

            clsCNProductos ListaRenovPermite = new clsCNProductos();
            dtTipRenovPermitido = ListaRenovPermite.TipoRenovXprod(idProducto);
            LBTipRenovPermite.DataSource = dtTipRenovPermitido;
            LBTipRenovPermite.ValueMember = "IdRenovacion";
            LBTipRenovPermite.DisplayMember = "cDescripcion";

            clsCNProductos TipoPagoPermitido = new clsCNProductos();
            dtTipPagoIntPermitido = TipoPagoPermitido.TipoPagoIntXprod(idProducto);
            LBTipPagoPermite.DataSource = dtTipPagoIntPermitido;
            LBTipPagoPermite.ValueMember = "IdPagoInt";
            LBTipPagoPermite.DisplayMember = "cDescripcion";

        }

        private void CargarTiposcapitalizacion()
        {
            clsCNProductos clsTipCap = new clsCNProductos();
            DataTable dtTipCap = clsTipCap.TipoCapitalizacion();
            cboTipoCap.DataSource = dtTipCap;
            cboTipoCap.ValueMember = "idTipoCapDep";
            cboTipoCap.DisplayMember = "cDenominacion";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
         if (pcTipOpe == "A")
         {
             this.btnEditar.Enabled = true;
             this.btnCancelar.Enabled = true;
             
         }
         if (pcTipOpe == "N")
         {
             //LimpiarControles();
             tbProduc.Rows.Clear();
             this.btnEditar.Enabled = false;
             this.btnCancelar.Enabled = false;
             this.RBTodos.Checked = true;
             
         }

         HabilitarControles(false);
         this.btnGrabar.Enabled = false;
         this.btnNuevo.Enabled = true;
         this.btnProcesar.Enabled = true;
         dtgproductos.Enabled = true;
        
         pcTipOpe = "N";
         LimpiarControles();
                     
     }
        private void btnGrabar_Click(object sender, EventArgs e)
         {
             if (ValidarDatos() == "ERROR")
             {
                 return;
             }
            //Tipo de Personas Permitidas
             DataSet dsTipPer = new DataSet("dsTipPersona");
             dsTipPer.Tables.Add(tbTipPerPermitida);
             string xmlTipPer = dsTipPer.GetXml();
             xmlTipPer = clsCNFormatoXML.EncodingXML(xmlTipPer);
             dsTipPer.Tables.Clear();

             //Tipo de Cuentas Permitidas
             DataSet dsTipCta = new DataSet("dsTipCta");
             dsTipCta.Tables.Add(dtTipCtaPermitido);
             string xmlTipCta = dsTipCta.GetXml();
             xmlTipCta = clsCNFormatoXML.EncodingXML(xmlTipCta);
             dsTipCta.Tables.Clear();

             //Tipo de Cuentas Permitidas
             DataSet dsTipRenov = new DataSet("dsTipRenov");
             dsTipRenov.Tables.Add(dtTipRenovPermitido);
             string xmlTipRenov = dsTipRenov.GetXml();
             xmlTipRenov = clsCNFormatoXML.EncodingXML(xmlTipRenov);
             dsTipRenov.Tables.Clear();

             //Tipo de Cuentas Permitidas
             DataSet dsTipPago = new DataSet("dsTipPago");
             dsTipPago.Tables.Add(dtTipPagoIntPermitido);
             string xmlTipPago = dsTipPago.GetXml();
             xmlTipPago = clsCNFormatoXML.EncodingXML(xmlTipPago);
             dsTipPago.Tables.Clear();
                                  

             int idProducto=Convert.ToInt32(cboProducto4.SelectedValue); 
             int idMoneda=Convert.ToInt32(cboMoneda.SelectedValue);
             Boolean inactividad = Convert.ToBoolean(CBInactividad.Checked);
             int PlazoInact = 0;
             if(txtPlazoInactiv.Text!="")
                PlazoInact = Convert.ToInt32(txtPlazoInactiv.Text);
             int PlazoCancel = 0;
             if (txtPlazoCancel.Text != "")
                PlazoCancel = Convert.ToInt32(txtPlazoCancel.Text);
             Decimal MonminApe = Convert.ToDecimal(txtMontoMinApert.Text);
             Decimal MonMinSaldo = Convert.ToDecimal(txtMontoMinSaldo.Text);
             Decimal MonMinOpe = Convert.ToDecimal(txtMontoMinOper.Text);
             int PlazoMinProd = 0;
             if(txtPlazoMinProd.Text!="")
                PlazoMinProd= Convert.ToInt32(txtPlazoMinProd.Text);
             int PlazoMaxProd = 0;
             if (txtPlazoMaxProd.Text!="")    
                PlazoMaxProd = Convert.ToInt32(txtPlazoMaxProd.Text);
             int plazoProd = Convert.ToInt32(CBPlazoProd.Checked);
             Boolean Renovprod = Convert.ToBoolean(CBRenovProd.Checked);
             Boolean RequCert = Convert.ToBoolean(CBRequCert.Checked);
             Boolean AfectoITF = Convert.ToBoolean(CBAfectoITF.Checked);
             Boolean ReqPagInt = Convert.ToBoolean(CBReqPagInt.Checked);
             Boolean DepTipPagInt = Convert.ToBoolean(CBDepTipPagInt.Checked);
             Boolean ReqEmpl = Convert.ToBoolean(CBReqEmpl.Checked);
             Boolean ProdTransf = Convert.ToBoolean(CBProdTranf.Checked);
             Boolean ProdCTS = Convert.ToBoolean(CBProdCTS.Checked);
             Boolean DepAhoProg = Convert.ToBoolean(CBDepAhorProg.Checked);
             int TipCalcul = Convert.ToInt32(cboTipoCalculado.SelectedValue);
             int TipCapitalizacion = Convert.ToInt32(cboTipoCap.SelectedValue);
             int PerCapit = Convert.ToInt32(txtPeriodoCap.Text);
             Boolean OpeRet = Convert.ToBoolean(CBOperRetiro.Checked);
             Boolean OpeDep = Convert.ToBoolean(CBOpeDepos.Checked);
             Boolean CtaCte = Convert.ToBoolean(CBCtaCteReal.Checked);
             Boolean OrdenPago = Convert.ToBoolean(CBOrdenPago.Checked);
             Boolean AplicaMenEdad = Convert.ToBoolean(chcAplicaMenEdad.Checked);
             Boolean Estado = Convert.ToBoolean(CBEstado.Checked);
             Boolean lGarCre = Convert.ToBoolean(chcGarCredito.Checked);
             int ClasifProd = Convert.ToInt32(cboClasifProdDepos1.SelectedValue);
             int idProdTasCanc=0;

            Boolean RenovprodTasa = Convert.ToBoolean(CBRenovTasa.Checked);
            int idProdTasaRenov = Convert.ToInt32(cboProdTasaRenov.SelectedValue);

             idProdTasCanc = Convert.ToInt32(cboProdTasaCancel.SelectedValue);
             if (ProdCTS)
             {
                 idProdTasCanc = idProducto;
             }
             //if (cboProdTasaCancel.Visible==true)
             //    idProdTasCanc = Convert.ToInt32(cboProdTasaCancel.SelectedValue);
             //if (cboProdTasaCancel.Visible == false)
             //    idProdTasCanc=Convert.ToInt32(cboProducto4.SelectedValue);             

             clsCNProductos GuardaParamProductos = new clsCNProductos();

             if (pcTipOpe == "A")
             {
                     GuardaParamProductos.ActualizarProd(idProducto,idMoneda,inactividad,PlazoInact,
                                                         PlazoCancel,MonminApe,MonMinSaldo,MonMinOpe,
                                                         PlazoMinProd,PlazoMaxProd,plazoProd,Renovprod,
                                                         RequCert,AfectoITF,ReqPagInt,DepTipPagInt,
                                                         ReqEmpl,ProdTransf,ProdCTS,DepAhoProg,
                                                         TipCalcul,PerCapit,OpeRet,OpeDep,
                                                         CtaCte, Estado, idProdTasCanc, OrdenPago, ClasifProd,
                                                         xmlTipPer, xmlTipCta, xmlTipRenov, xmlTipPago, AplicaMenEdad, TipCapitalizacion, lGarCre, RenovprodTasa, idProdTasaRenov);
                     MessageBox.Show("Los Datos se actualizaron correctamente ", "Mantenimiento de Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                     //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados
                     //this.RBTodos.Checked = true;
                     Buscar();
                     int n = 0;
                     foreach (DataGridViewRow fila in dtgproductos.Rows)
                     {
                         n += 1;
                         if (Convert.ToInt32(fila.Cells["IdProducto"].Value) == idProducto && Convert.ToInt32(fila.Cells["IdMoneda"].Value) == idMoneda)
                         {                             
                             dtgproductos.CurrentCell = dtgproductos.Rows[(n - 1)].Cells["cProducto"];
                             MostrarDatos();
                         }
                     }
                 }
             else if (pcTipOpe == "N")
             {
                 int Duplicado = GuardaParamProductos.ControlDuplicidad(idProducto, idMoneda);
                 if (Duplicado != 0)
                 {
                     MessageBox.Show("La configuración del Producto ya se encuentra registrado para dicha moneda, Si desea puede modificarlo", "Mantenimiento de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     return;
                     //RBTodos.Checked = true;                     
                     //Buscar();
                     //int n = 0;
                     //foreach (DataGridViewRow fila in dtgproductos.Rows)
                     //{
                     //    n += 1;
                     //    if (Convert.ToInt32(fila.Cells["IdProducto"].Value) == idProducto && Convert.ToInt32(fila.Cells["IdMoneda"].Value) == idMoneda)
                     //    {
                     //        dtgproductos.CurrentCell = dtgproductos.Rows[n - 1].Cells["cProducto"];
                     //        MostrarDatos();
                     //    }
                     //}
                 }
                 else if (Duplicado == 0)
                 {
                     GuardaParamProductos.GuardarProd(idProducto, idMoneda, inactividad, PlazoInact,
                                                         PlazoCancel, MonminApe, MonMinSaldo, MonMinOpe,
                                                         PlazoMinProd, PlazoMaxProd, plazoProd, Renovprod,
                                                         RequCert, AfectoITF, ReqPagInt, DepTipPagInt,
                                                         ReqEmpl, ProdTransf, ProdCTS, DepAhoProg,
                                                         TipCalcul, PerCapit, OpeRet, OpeDep,
                                                         CtaCte, Estado, idProdTasCanc, OrdenPago, ClasifProd,
                                                         xmlTipPer, xmlTipCta, xmlTipRenov, xmlTipPago, AplicaMenEdad, TipCapitalizacion, lGarCre, RenovprodTasa, idProdTasaRenov);

                     MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     //RBTodos.Checked = true;                    
                     Buscar();
                     int n = 0;
                     foreach (DataGridViewRow fila in dtgproductos.Rows)
                     {
                         n += 1;
                         if (Convert.ToInt32(fila.Cells["IdProducto"].Value) == idProducto && Convert.ToInt32(fila.Cells["IdMoneda"].Value) == idMoneda)
                         {
                             dtgproductos.CurrentCell = dtgproductos.Rows[n - 1].Cells["cProducto"];
                             MostrarDatos();
                         }
                     }
                     this.btnNuevo.Enabled = true;
                     this.btnEditar.Enabled = true;
                     this.btnGrabar.Enabled = false;
                     this.btnCancelar.Enabled = true;
                     pcTipOpe = "N";
                 }
             }
             dtgproductos.Enabled = true;
         }
        private void cboProducto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto1.SelectedIndex > 0)
            {
                this.cboProducto2.CargarProducto((int)cboProducto1.SelectedValue);
                this.cboProducto2.SelectedIndex = 1;
            }
            else
            {
                this.cboProducto2.CargarProducto(-1);
            }
        }
        private void cboProducto2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto2.SelectedIndex > 0)
            {
                this.cboProducto3.CargarProducto((int)cboProducto2.SelectedValue);
                this.cboProducto3.SelectedIndex = 1;
            }
            else
            {
                this.cboProducto3.CargarProducto(-1);
            }
        }
        private void cboProducto3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto3.SelectedIndex > 0)
            {
                this.cboProducto4.CargarProducto((int)cboProducto3.SelectedValue);
                this.cboProducto4.SelectedIndex = 0;
                if (Convert.ToInt32(cboProducto3.SelectedValue) != 57)
                {
                    this.lblProdTasaCanc.Visible = true;
                    this.cboProdTasaCancel.Visible = true;
                }
                else if (Convert.ToInt32(cboProducto3.SelectedValue) == 57)
                {
                    this.lblProdTasaCanc.Visible = false;
                    this.cboProdTasaCancel.Visible = false;
                }



                if (Convert.ToInt32(cboProducto3.SelectedValue) == 57 || Convert.ToInt32(cboProducto3.SelectedValue) == 55)//AHORRO CORRIENTE Y CTS 
                {
                    dtTipRenovPermitido.Rows.Clear();
                    dtTipRenov.Rows.Clear();

                }
                else
                {
                    clsCNOperacionDep ListaRenov = new clsCNOperacionDep();
                    dtTipRenov = ListaRenov.ListaTipoRenovacion();
                    LBTipRenovNoPermite.DataSource = dtTipRenov;
                    LBTipRenovNoPermite.ValueMember = "IdRenovacion";
                    LBTipRenovNoPermite.DisplayMember = "cDescripcion";
                }


                if (Convert.ToInt32(cboProducto3.SelectedValue) == 55)//AHORRO CORRIENTE 
                {
                    dtTipPagoIntPermitido.Rows.Clear();
                    dtTipPago.Rows.Clear();
                }
                else
                {
                    clsCNTipPagoInt ListaTipPago = new clsCNTipPagoInt();
                    dtTipPago = ListaTipPago.ListarTipPagoInt();
                    LBTipPagoNoPermite.DataSource = dtTipPago;
                    LBTipPagoNoPermite.ValueMember = "IdPagoInt";
                    LBTipPagoNoPermite.DisplayMember = "cDescripcion";                
                }
                

            }
            else
            {
                this.cboProducto4.CargarProducto(-1);
            }
        }
        private void RBTodos_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (RBTodos.Checked)
            {
                this.btnProcesar.Enabled = true;
                this.btnNuevo.Enabled = true;                
                this.btnGrabar.Enabled = false;
                HabilitarControles(false);
            }
        }
        private void RBFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (RBFiltrar.Checked)
            {
                this.btnProcesar.Enabled = true;
                this.btnNuevo.Enabled = true;                
                this.btnGrabar.Enabled = false;
                HabilitarControles(false);
                cboProducto1.Enabled = true;
                cboProducto2.Enabled = true;
                cboProducto3.Enabled = true;
                cboProducto4.Enabled = true;
            }           

        }
        private void CBInactividad_CheckedChanged(object sender, EventArgs e)
        {
            if (CBInactividad.Enabled==true)
            {
                txtPlazoInactiv.Enabled = CBInactividad.Checked;
                txtPlazoCancel.Enabled = CBInactividad.Checked;
                if (CBInactividad.Checked == false)
                {
                    txtPlazoInactiv.Clear();
                    txtPlazoCancel.Clear();
                }
            }
        }
        private void CBPlazoProd_CheckedChanged(object sender, EventArgs e)
        {
            if (CBPlazoProd.Enabled==true)
            {
                txtPlazoMinProd.Enabled = CBPlazoProd.Checked;
                txtPlazoMaxProd.Enabled = CBPlazoProd.Checked;
                CBReqPagInt.Enabled = CBPlazoProd.Checked;
                CBDepTipPagInt.Enabled = CBPlazoProd.Checked;
                CBRenovProd.Enabled = CBPlazoProd.Checked;
                CBRenovProd.Checked = CBPlazoProd.Checked;
                CBRequCert.Enabled = CBPlazoProd.Checked;

                if (Convert.ToInt32(cboProducto3.SelectedValue) == 56)
                {
                    CBRenovTasa.Enabled = CBPlazoProd.Checked;
                }

                if (CBPlazoProd.Checked == false)
                {
                    txtPlazoMinProd.Clear();
                    txtPlazoMaxProd.Clear();
                    CBReqPagInt.Checked = false;
                    CBDepTipPagInt.Checked = false;
                    CBRenovProd.Checked = false;
                    CBRequCert.Checked = false;
                    if (Convert.ToInt32(cboProducto3.SelectedValue) == 56)
                    {
                        CBRenovTasa.Checked = false;
                        this.cboProdTasaRenov.Enabled = false;
                        this.cboProdTasaRenov.SelectedIndex = 0;
                    }

                }
            }
        }
        private void dtgproductos_SelectionChanged_1(object sender, EventArgs e)
        {           
            MostrarDatos();
        }
        private void btnMiniPasarDerecha1_Click(object sender, EventArgs e)
        {
            if (LBTipPerNoPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipPerNoPermite.SelectedIndex);
                tbTipPerPermitida.ImportRow(tbTipPer.Rows[indice]);
                tbTipPer.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarIzquierda1_Click(object sender, EventArgs e)
        {
            if (LBTipPerPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipPerPermite.SelectedIndex);
                tbTipPer.ImportRow(tbTipPerPermitida.Rows[indice]);
                tbTipPerPermitida.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarDerecha2_Click(object sender, EventArgs e)
        {
            if (LBTipCtaNoPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipCtaNoPermite.SelectedIndex);
                dtTipCtaPermitido.ImportRow(dtTipCuenta.Rows[indice]);
                dtTipCuenta.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarIzquierda2_Click(object sender, EventArgs e)
        {
            if (LBTipCtaPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipCtaPermite.SelectedIndex);
                dtTipCuenta.ImportRow(dtTipCtaPermitido.Rows[indice]);
                dtTipCtaPermitido.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarDerecha3_Click(object sender, EventArgs e)
        {
            if (LBTipRenovNoPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipRenovNoPermite.SelectedIndex);
                dtTipRenovPermitido.ImportRow(dtTipRenov.Rows[indice]);
                dtTipRenov.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarIzquierda3_Click(object sender, EventArgs e)
        {
            if (LBTipRenovPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipRenovPermite.SelectedIndex);
                dtTipRenov.ImportRow(dtTipRenovPermitido.Rows[indice]);
                dtTipRenovPermitido.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarDerecha4_Click(object sender, EventArgs e)
        {
            if (LBTipPagoNoPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipPagoNoPermite.SelectedIndex);
                dtTipPagoIntPermitido.ImportRow(dtTipPago.Rows[indice]);
                dtTipPago.Rows.RemoveAt(indice);
            }
        }
        private void btnMiniPasarIzquierda4_Click(object sender, EventArgs e)
        {
            if (LBTipPagoPermite.Items.Count > 0)
            {
                int indice = Convert.ToInt32(LBTipPagoPermite.SelectedIndex);
                dtTipPago.ImportRow(dtTipPagoIntPermitido.Rows[indice]);
                dtTipPagoIntPermitido.Rows.RemoveAt(indice);
            }
        }      

        private void Buscar() 
        {

            if (RBTodos.Checked)
            {
                CargarProductos("T", 0);

            }
            if (RBFiltrar.Checked)
            {
                int Prod = Convert.ToInt32(cboProducto4.SelectedValue);
                CargarProductos("P", Prod);

            }
            pcTipOpe = "N";
        }
        
        private void LimpiarControles()
        {

            this.cboProducto1.SelectedIndex = -1;
            this.cboProducto2.SelectedIndex = -1;
            this.cboProducto3.SelectedIndex = -1;
            this.cboProducto4.SelectedIndex = -1;
            this.cboMoneda.SelectedIndex = -1;
            this.CBInactividad.Checked = false;
            this.txtPlazoInactiv.Clear();
            this.txtPlazoCancel.Clear();
            this.txtMontoMinApert.Clear();
            this.txtMontoMinSaldo.Clear();
            this.txtMontoMinOper.Clear();
            this.txtPlazoMinProd.Clear();
            this.txtPlazoMaxProd.Clear();
            this.CBPlazoProd.Checked = false;
            this.CBRenovProd.Checked = false;
            this.CBRequCert.Checked = false;
            this.CBAfectoITF.Checked = false;
            this.CBReqPagInt.Checked = false;
            this.CBDepTipPagInt.Checked = false;
            this.CBReqEmpl.Checked = false;
            this.CBProdTranf.Checked = false;
            this.CBProdCTS.Checked = false;
            this.CBDepAhorProg.Checked = false;
            this.cboTipoCalculado.SelectedIndex = -1;
            this.txtPeriodoCap.Clear();
            this.CBOperRetiro.Checked = false;
            this.CBOpeDepos.Checked = false;
            this.CBCtaCteReal.Checked = false;
            this.CBOrdenPago.Checked = false;
            chcGarCredito.Checked = false;
            this.cboProdTasaCancel.SelectedIndex = -1;
            this.cboTipoCap.SelectedIndex = -1;
            this.cboClasifProdDepos1.SelectedIndex = -1;
            this.CBEstado.Checked = false;
            this.chcAplicaMenEdad.Checked = false;
            this.CBRenovTasa.Checked = false;
            dtgproductos.DataSource = "";
            tbTipPer.Rows.Clear();
            dtTipCuenta.Rows.Clear();
            dtTipRenov.Rows.Clear();
            dtTipPago.Rows.Clear();
            tbTipPerPermitida.Rows.Clear();
            dtTipCtaPermitido.Rows.Clear();
            dtTipRenovPermitido.Rows.Clear();
            dtTipPagoIntPermitido.Rows.Clear();
            this.cboProdTasaRenov.SelectedIndex = -1;


        }
        private void HabilitarControles(Boolean val)
        {
            this.cboProducto1.Enabled = val;
            this.cboProducto2.Enabled = val;
            this.cboProducto3.Enabled = val;
            this.cboProducto4.Enabled = val;
            this.cboMoneda.Enabled = val;
            this.CBInactividad.Enabled = val;
            this.txtPlazoInactiv.Enabled = val;
            this.txtPlazoCancel.Enabled = val;
            this.txtMontoMinApert.Enabled = val;
            this.txtMontoMinSaldo.Enabled = val;
            this.txtMontoMinOper.Enabled = val;
            this.txtPlazoMinProd.Enabled = val;
            this.txtPlazoMaxProd.Enabled = val;
            this.CBPlazoProd.Enabled = val;
            this.CBRenovProd.Enabled = val;
            this.CBRequCert.Enabled = val;
            this.CBAfectoITF.Enabled = val;
            this.CBReqPagInt.Enabled = val;
            this.CBDepTipPagInt.Enabled = val;
            this.CBReqEmpl.Enabled = val;
            this.CBProdTranf.Enabled = val;
            this.CBProdCTS.Enabled = val;
            this.CBDepAhorProg.Enabled = val;
            chcGarCredito.Enabled = val;
            this.cboTipoCalculado.Enabled = val;
            this.txtPeriodoCap.Enabled = false;
            this.CBOperRetiro.Enabled = val;
            this.CBOpeDepos.Enabled = val;
            this.CBCtaCteReal.Enabled = val;
            this.CBOrdenPago.Enabled = val;
            this.chcAplicaMenEdad.Enabled = val;
            this.cboProdTasaCancel.Enabled = val;
            this.cboTipoCap.Enabled = val;
            this.cboClasifProdDepos1.Enabled = val;
            this.CBEstado.Enabled = val;
            this.btnMiniPasarDerecha1.Enabled = val;
            this.btnMiniPasarDerecha2.Enabled = val;
            this.btnMiniPasarDerecha3.Enabled = val;
            this.btnMiniPasarDerecha4.Enabled = val;
            this.btnMiniPasarIzquierda1.Enabled = val;
            this.btnMiniPasarIzquierda2.Enabled = val;
            this.btnMiniPasarIzquierda3.Enabled = val;
            this.btnMiniPasarIzquierda4.Enabled = val;
            
            if (Convert.ToInt32(cboProducto3.SelectedValue) == 56)
            {
                this.CBRenovTasa.Enabled = val;
                this.cboProdTasaRenov.Enabled = val;
            }


        }
        private void CargarProductos(String Filtro, int CodProd) {

            clsCNProductos ListaProductos = new clsCNProductos();
            tbProduc = ListaProductos.ListarProductos(Filtro, CodProd);

            if (dtgproductos.ColumnCount > 0)
            {
                dtgproductos.Columns.Remove("cProducto");
                dtgproductos.Columns.Remove("IdProducto");
                dtgproductos.Columns.Remove("IdMoneda");
                dtgproductos.Columns.Remove("cMoneda");
                dtgproductos.Columns.Remove("lIsInactiva");
                dtgproductos.Columns.Remove("nPlaInactiva");
                dtgproductos.Columns.Remove("nPlaCancInac");
                dtgproductos.Columns.Remove("nMonMinApe");
                dtgproductos.Columns.Remove("nMonMinSalDis");
                dtgproductos.Columns.Remove("nMonMinOpe");
                dtgproductos.Columns.Remove("nPlaMinProd");
                dtgproductos.Columns.Remove("nPlaMaxProd");
                dtgproductos.Columns.Remove("lIsPlazoProd");
                dtgproductos.Columns.Remove("lIsRenovProd");
                dtgproductos.Columns.Remove("lIsRequeCert");
                dtgproductos.Columns.Remove("lIsAfectoITF");
                dtgproductos.Columns.Remove("lIsReqPagInt");
                dtgproductos.Columns.Remove("lIsDefTipPagInt");
                dtgproductos.Columns.Remove("lIsReqEmpleador");
                dtgproductos.Columns.Remove("lIsProdTransf");
                dtgproductos.Columns.Remove("lIsProdCTS");
                dtgproductos.Columns.Remove("lIsDepAhoProg");
                dtgproductos.Columns.Remove("lVigente");
                dtgproductos.Columns.Remove("nTipCalInt");
                dtgproductos.Columns.Remove("nPeriodoCap");
                dtgproductos.Columns.Remove("lIsOpeRetiro");
                dtgproductos.Columns.Remove("lIsOpeDeposito");
                dtgproductos.Columns.Remove("lIsCtaCteRel");
                dtgproductos.Columns.Remove("idProdTasCancel");
                dtgproductos.Columns.Remove("cVigente");
                dtgproductos.Columns.Remove("lIsCtaOrdPago");
                dtgproductos.Columns.Remove("idClasifProdDep");
                dtgproductos.Columns.Remove("lIsDepMenEdad");
                dtgproductos.Columns.Remove("idTipoCapDep");
                dtgproductos.Columns.Remove("lIsGarantia");
                dtgproductos.Columns.Remove("lActualizaTasaRen");
                dtgproductos.Columns.Remove("idProdTasaRenov");
                
            }

            dtgproductos.DataSource = tbProduc.DefaultView;
            FormatoGridTar();
        }    
        private void FormatoGridTar() {

            dtgproductos.Columns["cProducto"].Width = 75;
            dtgproductos.Columns["cProducto"].HeaderText = "Producto";
            dtgproductos.Columns["cProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgproductos.Columns["IdProducto"].Visible = false;
            dtgproductos.Columns["cMoneda"].Width = 50;
            dtgproductos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgproductos.Columns["cMoneda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgproductos.Columns["IdMoneda"].Visible = false;
            dtgproductos.Columns["lIsInactiva"].Visible = false;
            dtgproductos.Columns["nPlaInactiva"].Width = 40;
            dtgproductos.Columns["nPlaInactiva"].HeaderText = "Plazo para Inactiva";
            dtgproductos.Columns["nPlaInactiva"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgproductos.Columns["nPlaCancInac"].Visible = false;
            dtgproductos.Columns["nMonMinApe"].Visible = false;
            dtgproductos.Columns["nMonMinSalDis"].Width = 45;
            dtgproductos.Columns["nMonMinSalDis"].HeaderText = "Monto Min. Saldo Disp.";
            dtgproductos.Columns["nMonMinSalDis"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgproductos.Columns["nMonMinOpe"].Width = 45;
            dtgproductos.Columns["nMonMinOpe"].HeaderText = "Monto Mín. Operación";
            dtgproductos.Columns["nMonMinOpe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgproductos.Columns["nPlaMinProd"].Visible = false;
            dtgproductos.Columns["nPlaMaxProd"].Visible = false;
            dtgproductos.Columns["lIsPlazoProd"].Visible = false;
            dtgproductos.Columns["lIsRenovProd"].Visible = false;
            dtgproductos.Columns["lIsRequeCert"].Visible = false;
            dtgproductos.Columns["lIsAfectoITF"].Visible = false;
            dtgproductos.Columns["lIsReqPagInt"].Visible = false;
            dtgproductos.Columns["lIsDefTipPagInt"].Visible = false;
            dtgproductos.Columns["lIsReqEmpleador"].Visible = false;
            dtgproductos.Columns["lIsProdTransf"].Visible = false;
            dtgproductos.Columns["lIsProdCTS"].Visible = false;
            dtgproductos.Columns["lIsDepAhoProg"].Visible = false;
            dtgproductos.Columns["lVigente"].Visible = false;
            dtgproductos.Columns["nTipCalInt"].Visible = false;
            dtgproductos.Columns["nPeriodoCap"].Visible = false;
            dtgproductos.Columns["lIsOpeRetiro"].Visible = false;
            dtgproductos.Columns["lIsOpeDeposito"].Visible = false;
            dtgproductos.Columns["lIsCtaCteRel"].Visible = false;
            dtgproductos.Columns["idProdTasCancel"].Visible = false;
            dtgproductos.Columns["cVigente"].Width = 90;
            dtgproductos.Columns["cVigente"].HeaderText = "Estado";
            dtgproductos.Columns["cVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgproductos.Columns["lIsCtaOrdPago"].Visible = false;
            dtgproductos.Columns["idClasifProdDep"].Visible = false;
            dtgproductos.Columns["lIsDepMenEdad"].Visible = false;
            dtgproductos.Columns["idTipoCapDep"].Visible = false;
            dtgproductos.Columns["lIsGarantia"].Visible = false;
            dtgproductos.Columns["lActualizaTasaRen"].Visible = false;
            
        }        

        private void MostrarDatos() 
        {
            if (Convert.ToInt32(this.dtgproductos.Rows.Count) >= 1)
            {
             HabilitarControles(false);
             
             int filaseleccionada = Convert.ToInt32(this.dtgproductos.CurrentRow.Index);
             int idproduc = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["IdProducto"].Value);
             clsCNProductos DatosProductos = new clsCNProductos();
             DataTable tbDatProd = DatosProductos.RetDatosProducto(idproduc);
                 int cantNiveles = tbDatProd.Rows.Count;
                 this.cboProducto1.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 2)]["IdProducto"]);
                 this.cboProducto2.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 3)]["IdProducto"]);
                 this.cboProducto3.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 4)]["IdProducto"]);
                 this.cboProducto4.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 5)]["IdProducto"]);
                
             this.cboMoneda.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["IdMoneda"].Value);
             this.CBInactividad.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsInactiva"].Value);
                 if (CBInactividad.Checked == true)
                 {
                     this.txtPlazoInactiv.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nPlaInactiva"].Value);
                     this.txtPlazoCancel.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nPlaCancInac"].Value);
                 }
                 else if (CBInactividad.Checked == false) { 
                    this.txtPlazoInactiv.Text = "";
                    this.txtPlazoCancel.Text = "";                                           
                 }

             this.CBPlazoProd.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsPlazoProd"].Value);
                 if (CBPlazoProd.Checked == true)
                 {
                     this.txtPlazoMinProd.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nPlaMinProd"].Value);
                     this.txtPlazoMaxProd.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nPlaMaxProd"].Value);
                 }
                 else if (CBPlazoProd.Checked == false) { 
                     this.txtPlazoMinProd.Text = "";
                     this.txtPlazoMaxProd.Text = "";
                 }

             this.txtMontoMinApert.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nMonMinApe"].Value);
             this.txtMontoMinSaldo.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nMonMinSalDis"].Value);
             this.txtMontoMinOper.Text = Convert.ToString(this.dtgproductos.Rows[filaseleccionada].Cells["nMonMinOpe"].Value);
                            
             this.CBRenovProd.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsRenovProd"].Value);               
             this.CBRequCert.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsRequeCert"].Value);                
             this.CBAfectoITF.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsAfectoITF"].Value);                
             this.CBReqPagInt.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsReqPagInt"].Value);               
             this.CBDepTipPagInt.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsDefTipPagInt"].Value);                
             this.CBReqEmpl.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsReqEmpleador"].Value);               
             this.CBProdTranf.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsProdTransf"].Value);                
             this.CBProdCTS.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsProdCTS"].Value);                
             this.CBDepAhorProg.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsDepAhoProg"].Value);
             this.chcGarCredito.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsGarantia"].Value);  
                
             this.cboTipoCalculado.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["nTipCalInt"].Value);
             this.cboTipoCap.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["idTipoCapDep"].Value);
             //this.txtPeriodoCap.Text = this.dtgproductos.Rows[filaseleccionada].Cells["nPeriodoCap"].Value + "";
             this.chcAplicaMenEdad.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsDepMenEdad"].Value);
             this.CBOperRetiro.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsOpeRetiro"].Value);                
             this.CBOpeDepos.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsOpeDeposito"].Value);                
             this.CBCtaCteReal.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsCtaCteRel"].Value);                
             this.CBEstado.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lVigente"].Value);
             this.CBOrdenPago.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lIsCtaOrdPago"].Value);
             this.cboClasifProdDepos1.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["idClasifProdDep"].Value);

             this.cboProdTasaCancel.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["idProdTasCancel"].Value);

             this.CBRenovTasa.Checked = Convert.ToBoolean(this.dtgproductos.Rows[filaseleccionada].Cells["lActualizaTasaRen"].Value);
             this.cboProdTasaRenov.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["idProdTasaRenov"].Value);
             

             if (this.CBProdCTS.Checked)
             {
                 this.cboProdTasaCancel.Visible = true;
                 this.lblProdTasaCanc.Visible = true;
                 //this.cboProdTasaCancel.SelectedValue = Convert.ToInt32(this.dtgproductos.Rows[filaseleccionada].Cells["idProdTasCancel"].Value);
             }
             if (Convert.ToInt32(cboProducto3.SelectedValue) == 57)
             {
                 this.cboProdTasaCancel.Visible = false;
                 this.lblProdTasaCanc.Visible = false;
                 //this.cboProdTasaCancel.SelectedValue = cboProducto4.SelectedValue;
             }          
            
             CargarListBoxPermitidos(idproduc);
             CargarListBoxGeneral();

             for (int i = 0; i < tbTipPer.Rows.Count; i++)
             {
                 for (int j = 0; j < tbTipPerPermitida.Rows.Count; j++ ) 
                 {
                     if (Convert.ToInt32(tbTipPer.Rows[i]["idTipoPersona"]) == Convert.ToInt32(tbTipPerPermitida.Rows[j]["idTipoPersona"]))
                     {
                         tbTipPer.Rows.RemoveAt(i);
                         i = -1;
                         break;
                     }
                                      
                 }
             }

             for (int i = 0; i < dtTipCuenta.Rows.Count; i++)  
             {
                 for (int j = 0; j < dtTipCtaPermitido.Rows.Count; j++)   
                 {
                     if (Convert.ToInt32(dtTipCuenta.Rows[i]["idTipoCuenta"]) == Convert.ToInt32(dtTipCtaPermitido.Rows[j]["idTipoCuenta"]))
                     {
                         dtTipCuenta.Rows.RemoveAt(i);
                         i = -1;
                         break;
                     }
                 }
             }

             for (int i = 0; i < dtTipRenov.Rows.Count; i++)  
             {
                 for (int j = 0; j < dtTipRenovPermitido.Rows.Count; j++)   
                 {
                     if (Convert.ToInt32(dtTipRenov.Rows[i]["IdRenovacion"]) == Convert.ToInt32(dtTipRenovPermitido.Rows[j]["IdRenovacion"]))
                     {
                         dtTipRenov.Rows.RemoveAt(i);
                         i = -1;
                         break;
                     }
                 }
             }

             for (int i = 0; i < dtTipPago.Rows.Count; i++)    
             {
                 for (int j = 0; j < dtTipPagoIntPermitido.Rows.Count; j++)     
                 {
                     if (Convert.ToInt32(dtTipPago.Rows[i]["IdPagoInt"]) == Convert.ToInt32(dtTipPagoIntPermitido.Rows[j]["IdPagoInt"]))
                     {
                         dtTipPago.Rows.RemoveAt(i);
                         i = -1;
                         break;
                     }
                 }
             }

             if (Convert.ToInt32(cboProducto3.SelectedValue) == 57 || Convert.ToInt32(cboProducto3.SelectedValue) == 55)//AHORRO CORRIENTE Y CTS 
             {
                 dtTipRenovPermitido.Rows.Clear();
                 dtTipRenov.Rows.Clear();
             
             }
             if (Convert.ToInt32(cboProducto3.SelectedValue) == 55)//CTS
             {
                 dtTipPagoIntPermitido.Rows.Clear();
                 dtTipPago.Rows.Clear();
             }


             this.btnNuevo.Enabled = true;
             this.btnEditar.Enabled = true;
             this.btnProcesar.Enabled = true;
             this.btnCancelar.Enabled = true;
             this.btnGrabar.Enabled = false;            
             //this.RBFiltrar.Checked = false;
             //this.RBTodos.Checked = true;
            }
     }
        private string ValidarDatos() {
         if (cboProducto1.Text.Trim() == "")
         {
             MessageBox.Show("Debe Seleccionar el Tipo de Producto ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboProducto1.Focus();
             return "ERROR";
         }
         if (cboProducto2.Text.Trim() == "")
         {
             MessageBox.Show("Debe Seleccionar el Sub-Tipo de Producto ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboProducto2.Focus();
             return "ERROR";
         }
         if (cboProducto3.Text.Trim() == "")
         {
             MessageBox.Show("Debe Seleccionar el Producto ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboProducto3.Focus();
             return "ERROR";
         }
         if (cboProducto4.Text.Trim() == "")
         {
             MessageBox.Show("Debe Seleccionar el Sub-Producto ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboProducto4.Focus();
             return "ERROR";
         }
         if (cboMoneda.Text.Trim() == "")
         {
             MessageBox.Show("Debe el Tipo de Moneda ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboMoneda.Focus();
             return "ERROR";
         }
         if (cboTipoCalculado.Text.Trim() == "")
         {
             MessageBox.Show("Debe seleccionar el Tipo de Cálculo ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboTipoCalculado.Focus();
             return "ERROR";
         }
         if (cboTipoCap.Text.Trim() == "")
         {
             MessageBox.Show("Debe seleccionar el Tipo de Capitalización ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboTipoCap.Focus();
             return "ERROR";
         }


         if (CBInactividad.Checked == true)
         {
             if (txtPlazoInactiv.Text.Trim() == "")
             {
                 MessageBox.Show("Debe indicar el Plazo para Inactivar una Cuenta", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtPlazoInactiv.Focus();
                 return "ERROR";
             }
             if (txtPlazoCancel.Text.Trim() == "")
             {
                 MessageBox.Show("Debe indicar el Plazo para la Cancelación Inactiva", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtPlazoCancel.Focus();
                 return "ERROR";
             }
         }

         if (CBPlazoProd.Checked == true)
         {
             if (txtPlazoMinProd.Text.Trim() == "")
             {
                 MessageBox.Show("Debe indicar el Plazo Mínimo del Producto", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtPlazoMinProd.Focus();
                 return "ERROR";
             }
             if (txtPlazoMaxProd.Text.Trim() == "")
             {
                 MessageBox.Show("Debe indicar el Plazo Máximo del Producto", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtPlazoMaxProd.Focus();
                 return "ERROR";
             }
             if (CBRenovProd.Checked==false)
             {
                 MessageBox.Show("Debe Marcar la casilla: Requiere Renovación?, ya que es Obligatoria ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 CBRenovProd.Focus();
                 return "ERROR";
             }
             if (Convert.ToInt32(cboProducto3.SelectedValue) == 56 && CBRenovTasa.Checked == false)
             {
                 MessageBox.Show("Para Plazo Fijo debe Marcar la casilla: Requiere Renovación de Tasa y seleccionar el Producto.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 CBRenovTasa.Focus();
                 return "ERROR";
             }
             
             if (CBRenovTasa.Checked == true && Convert.ToInt32(cboProdTasaRenov.SelectedIndex) <= 0)
             {
                 MessageBox.Show("Para Plazo Fijo debe seleccionar el Producto correspondiente a la renovación.", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 CBRenovTasa.Focus();
                 return "ERROR";
             }

         }            

         if (txtMontoMinApert.Text.Trim() == "")
         {
             MessageBox.Show("Debe indicar el Monto Mínimo de Apertura ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             txtMontoMinApert.Focus();
             return "ERROR";
         }
         if (txtMontoMinSaldo.Text.Trim() == "")
         {
             MessageBox.Show("Debe indicar el Monto Mínimo de Saldo Disponible ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             txtMontoMinSaldo.Focus();
             return "ERROR";
         }            
            
         if (txtMontoMinOper.Text.Trim() == "")
         {
             MessageBox.Show("Debe indicar el Monto Mínimo de Operación ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             txtMontoMinOper.Focus();
             return "ERROR";
         }         
         if (txtPeriodoCap.Text.Trim() == "")
         {
             MessageBox.Show("Debe indicar el Periodo Capitalizable", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             txtPeriodoCap.Focus();
             return "ERROR";
         }
         if (cboClasifProdDepos1.Text.Trim() == "")
         {
             MessageBox.Show("Debe indicar la Clasificación del Producto ", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             cboClasifProdDepos1.Focus();
             return "ERROR";
         }

         return "OK";
     
     }

        private void cboTipoCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCap.SelectedIndex<=0)
            {
                txtPeriodoCap.Text = "0";
                return;
            }
            if (Convert.ToInt16(cboTipoCap.SelectedValue)==1)
            {
                txtPeriodoCap.Text = "0";
            }
            else
            {
                txtPeriodoCap.Text = "30";
            }
        }

        private void cboProducto4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pcTipOpe == "N")
            {
                if (cboProducto4.Items.Count<=0)
                {
                    MessageBox.Show("El tipo de Ahorro, No tiene registrado un sub producto", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGrabar.Enabled = false;
                }
                clsCNProductos ListaProductos = new clsCNProductos();
                int Prod = Convert.ToInt32(cboProducto4.SelectedValue);
                tbProduc = ListaProductos.ListarProductos("P", Prod);
                if (tbProduc.Rows.Count == 2)
                {
                    //MessageBox.Show("Ya se ha registrado los parámetros para el producto, Solo puede Editarlo", "Validar Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGrabar.Enabled = false;
                }
                else
	            {
                    btnGrabar.Enabled = true;
	            }
            }

        }
        private void HabilitarCboTasa()
        {
            if (CBRenovTasa.Checked)
            {
                this.cboProdTasaRenov.Enabled = true;
            }
            else
            {
                this.cboProdTasaRenov.Enabled = false;
                this.cboProdTasaRenov.SelectedIndex = -1;
            }
        }

        private void CBRenovTasa_Click(object sender, EventArgs e)
        {
            HabilitarCboTasa();
        }
        


        
}}
