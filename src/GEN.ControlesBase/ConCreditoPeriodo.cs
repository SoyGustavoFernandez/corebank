using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class ConCreditoPeriodo : UserControl
    {
        private int idOperacion;

        public event EventHandler ChangeTipoPeriodo;
        public event EventHandler ChangePeriodo;
        public event EventHandler LeaveDia;
        public event EventHandler EnterDia;
        public event EventHandler ValueChangedDia;

        public clsPeriodoCredito objPeriodoCredito;
        public bool _lUnicuota;
        public bool lUnicuota
        {
            get { return this._lUnicuota; }
            set { this._lUnicuota = value; }
        }
        public int idTipoPeriodo
        {
            get
            {
                return Convert.ToInt32(this.cboTipoPeriodo.SelectedValue);
            }
        }
        public string cTipoPeriodo
        {
            get
            {
                return this.cboTipoPeriodo.Text;
            }
        }
        public int TipoPeridoIndex
        {
            set
            {
                this.cboTipoPeriodo.SelectedIndex = value;
            }
        }
        public int idPeriodo
        {
            get
            {
                return this.cboPeriodoCredito.idPeriodoCredito;
            }
        }
        public int nPeriodoDia
        {
            get
            {
                if (idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
                {
                    if (nCuotas == 1)
                    {
                        return Convert.ToInt32(this.nudDia.Value);
                    }
                    else
                    {
                        return this.cboPeriodoCredito.obtenerSeleccion().nDias;
                    }
                }
                else if (idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
                {
                    return 30;
                }
                else
                {
                    return Convert.ToInt32(this.nudDia.Value);
                }
            }
        }
        public int nCuotas
        {
            get;
            private set;
        }
        public int nDias
        {
            get;
            private set;
        }
        public bool lTipoPeriodoSelected
        {
            get { return (this.cboTipoPeriodo.SelectedIndex > -1);}
        }
        public bool lTipoPeriodoEnabled
        {
            get { return this.cboTipoPeriodo.Enabled; }
            set { this.cboTipoPeriodo.Enabled = value; }
        }

        public bool lPeriodoEnabled
        {
            get { return this.cboPeriodoCredito.Enabled; }
            set { this.cboPeriodoCredito.Enabled = value; }
        }

        public bool lDiaEnabled
        {
            get { return this.nudDia.Enabled; }
            set { this.nudDia.Enabled = value; }
        }
        public string PeriodoText
        {
            set
            {
                this.lblPeriodo.Text = value;
            }
        }
        public ConCreditoPeriodo()
        {
            InitializeComponent();
        }
        public clsPeriodoCredito obtenerPeriodoCredito()
        {
            return this.cboPeriodoCredito.obtenerSeleccion();
        }
        public void asignarPeriodoCredReprog(int idTipoPeriodo, int nDias, int idOperacion, int nCuotas, bool lUnicuota)
        {
            this.idOperacion = idOperacion;
            this.nCuotas = nCuotas;
            this.nDias = nDias;
            this.cboTipoPeriodo.SelectedIndexChanged -= this.cboTipoPeriodo_SelectedIndexChanged;
            this.cboTipoPeriodo.SelectedValue = idTipoPeriodo;
            this.cboTipoPeriodo.SelectedIndexChanged += this.cboTipoPeriodo_SelectedIndexChanged;

            this._lUnicuota = lUnicuota;
            if (this.lUnicuota)
            {
                this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(x => x.idPeriodoCredito == 10);
            }
            else if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(x => x.nDias == this.nDias);
                if (this.objPeriodoCredito != null)
                {
                }
                else
                {
                    this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(
                                x => x.nDiasMin <= this.nDias && x.nDiasMax >= this.nDias);
                }
            }
            else
            {
                this.objPeriodoCredito = null;
            }

            if (this.objPeriodoCredito != null)
            {
                this.cboPeriodoCredito.SelectedIndexChanged -= cboPeriodoCredito_SelectedIndexChanged;
                this.cboPeriodoCredito.SelectedValue = this.objPeriodoCredito.idPeriodoCredito;
                this.cboPeriodoCredito.SelectedIndexChanged += cboPeriodoCredito_SelectedIndexChanged;
            }
            else
            {
                this.cboPeriodoCredito.SelectedIndexChanged -= cboPeriodoCredito_SelectedIndexChanged;
                this.cboPeriodoCredito.SelectedIndex = -1;
                this.cboPeriodoCredito.SelectedIndexChanged += cboPeriodoCredito_SelectedIndexChanged;
            }
            this.actualizarTipoPeriodo();
        }
        public void asignarPeriodoCredito(int idTipoPeriodo, int nDias, int idOperacion, int nCuotas, int idPeriodo = 0)
        {
            this.idOperacion = idOperacion;
            this.nCuotas = nCuotas;
            this.nDias = nDias;
            this.cboTipoPeriodo.SelectedIndexChanged -= this.cboTipoPeriodo_SelectedIndexChanged;
            this.cboTipoPeriodo.SelectedValue = idTipoPeriodo;
            this.cboTipoPeriodo.SelectedIndexChanged += this.cboTipoPeriodo_SelectedIndexChanged;

            this._lUnicuota = false;
            if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && (idPeriodo == 10 || (idPeriodo==0 && this.nCuotas == 1)))
            {
                this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(x => x.idPeriodoCredito == 10);
                this._lUnicuota = true;
            }
            else if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(x => x.nDias == this.nDias);
                if (this.objPeriodoCredito != null)
                {
                }
                else
                {
                    this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(
                                x => x.nDiasMin <= this.nDias && x.nDiasMax >= this.nDias);
                }
            }
            else
            {
                this.objPeriodoCredito = null;
            }

            if (this.objPeriodoCredito != null)
            {
                this.cboPeriodoCredito.SelectedIndexChanged -= cboPeriodoCredito_SelectedIndexChanged;
                this.cboPeriodoCredito.SelectedValue = this.objPeriodoCredito.idPeriodoCredito;
                this.cboPeriodoCredito.SelectedIndexChanged += cboPeriodoCredito_SelectedIndexChanged;
            }
            else
            {
                this.cboPeriodoCredito.SelectedIndexChanged -= cboPeriodoCredito_SelectedIndexChanged;
                this.cboPeriodoCredito.SelectedIndex = -1;
                this.cboPeriodoCredito.SelectedIndexChanged += cboPeriodoCredito_SelectedIndexChanged;
            }
            this.actualizarTipoPeriodo();
        }
        public void limpiarControles()
        {
            this.nudDia.Value = 0;
            this.cboTipoPeriodo.SelectedIndex = -1;
            this.cboPeriodoCredito.SelectedIndex = -1;
            this.cboPeriodoCredito.Visible = false;
            this.cboPeriodoCredito.Width = 58;
            this.nudDia.Visible = true;
            this.lblPeriodo.Text = "Día de Pago";

            this.idOperacion = 0;
            this.nCuotas = 0;
            this.nDias = 0;
            nudDia.BackColor = Color.White;

        }
        public bool lTipoPeriodoValido
        {
            get
            {
                if (this.cboTipoPeriodo.SelectedIndex > -1)
                    return true;
                else
                    return false;
            }
        }

        public bool lPeriodoDiaValido
        {
            get
            {
                if (idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
                {
                    if (this.cboPeriodoCredito.SelectedIndex == -1)
                        return false;
                }
                else if (idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
                {
                    return true;
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(this.nudDia.Text) || Convert.ToInt32(this.nudDia.Text) == 0)
                        return false;
                }
                return true;
            }
        }

        public void actualizarTipoPeriodo()
        {
            this.cboPeriodoCredito.Enabled = true;
            this.nudDia.Enabled = false;

            if (idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                if (this.lUnicuota) //Condicional para unicuotas
                {
                    this.nCuotas = 1;
                    this._lUnicuota = true;
                    this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
                    this.nudDia.Value = this.nDias;
                    this.nudDia.ValueChanged += this.nudDia_ValueChanged;
                    this.cboPeriodoCredito.Enabled = true;
                    this.cboPeriodoCredito.Visible = true;
                    this.cboPeriodoCredito.Width = 58;
                    this.nudDia.Visible = true;
                    this.lblPeriodo.Text = "Frecuencia";

                    this.cboPeriodoCredito.SelectedIndexChanged -= cboPeriodoCredito_SelectedIndexChanged;
                    this.cboPeriodoCredito.SelectedValue = 10; //Unicuota
                    this.cboPeriodoCredito.SelectedIndexChanged += cboPeriodoCredito_SelectedIndexChanged;
                }
                else
                {

                    if (this.objPeriodoCredito == null)
                    {
                        if (this.nDias > 0 && this.idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha)
                        {
                            this.cboPeriodoCredito.Visible = true;
                            this.cboPeriodoCredito.Enabled = false;
                            this.cboPeriodoCredito.Width = 58;
                            this.nudDia.Visible = true;
                            this.nudDia.Enabled = false;
                        }
                        else if (this.nDias > 0)
                        {

                            if (this.objPeriodoCredito != null)
                            {
                                this.cboPeriodoCredito.Visible = true;
                                this.cboPeriodoCredito.Width = 110;
                                this.nudDia.Visible = false;
                                this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
                                this.nudDia.Value = 0;
                                this.nDias = 0;
                                this.nudDia.ValueChanged += this.nudDia_ValueChanged;
                            }
                            else
                            {
                                this.cboPeriodoCredito.Visible = true;
                                this.cboPeriodoCredito.Width = 110;
                                this.nudDia.Visible = false;
                                this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
                                this.nudDia.Value = 0;
                                this.nDias = 0;
                                this.nudDia.ValueChanged += this.nudDia_ValueChanged;
                            }
                        }
                        else
                        {
                            this.cboPeriodoCredito.Visible = true;
                            this.cboPeriodoCredito.Width = 110;
                            this.nudDia.Visible = false;
                            this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
                            this.nudDia.Value = 0;
                            this.nDias = 0;
                            this.nudDia.ValueChanged += this.nudDia_ValueChanged;
                        }
                    }
                    else
                    {
                        if (this.idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha)
                        {
                            this.cboPeriodoCredito.Visible = true;
                            this.cboPeriodoCredito.Enabled = false;
                            this.cboPeriodoCredito.Width = 58;
                            this.nudDia.Visible = true;
                            this.nudDia.Value = this.nDias;
                        }
                        else
                        {
                            this.cboPeriodoCredito.Visible = true;
                            this.cboPeriodoCredito.Enabled = true;
                            this.cboPeriodoCredito.Width = 110;
                            this.nudDia.Visible = false;
                        }
                    }
                    this.lblPeriodo.Text = "Frecuencia";
                }
            }
            else if (idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this._lUnicuota = false;
                this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
                this.nudDia.Value = this.nDias;
                this.nudDia.ValueChanged += this.nudDia_ValueChanged;
                this.cboPeriodoCredito.Visible = false;
                this.cboPeriodoCredito.Width = 58;
                this.nudDia.Visible = true;
                this.nudDia.Value = (this.nudDia.Value > 31) ? 31 : this.nudDia.Value;
                this.lblPeriodo.Text = "Día de Pago";
            }
            else if (idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
            {
                this._lUnicuota = false;
                this.lblPeriodo.Visible = false;
                this.cboPeriodoCredito.Visible = false;
                this.nudDia.Visible = false;
            }
            else
            {
                this._lUnicuota = false;
                this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
                this.nudDia.Value = this.nDias;
                this.nudDia.ValueChanged += this.nudDia_ValueChanged;
                this.cboPeriodoCredito.Visible = false;
                this.cboPeriodoCredito.Width = 58;
                this.nudDia.Visible = true;
                this.nudDia.Value = (this.nudDia.Value > 31) ? 31 : this.nudDia.Value;
                this.lblPeriodo.Text = "Día de Pago";
            }
        }
        public void actualizarDia(int nDia)
        {
            this.nDias = nDia;
            //this.nudDia.ValueChanged -= this.nudDia_ValueChanged;
            this.nudDia.Value = this.nDias;
            //this.nudDia.ValueChanged += this.nudDia_ValueChanged;

            nudDia.BackColor = Color.White;

            if (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                if (this.nDias > (int)clsVarApl.dicVarGen["nNumDiaPago"])
                {
                    nudDia.BackColor = Color.Red;
                }
            }           
        }
        public void actualizarCuotas(int nCuotas)
        {
            if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                if (this.nCuotas != nCuotas)
                {
                    this.nCuotas = nCuotas;
                    if (this.nCuotas == 1)
                        this._lUnicuota = true;
                    this.actualizarTipoPeriodo();
                }
            }
        }

        public void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoPeriodo.SelectedIndex == -1)
                return;

            this.cboPeriodoCredito.SelectedIndexChanged -= this.cboPeriodoCredito_SelectedIndexChanged;
            this.cboPeriodoCredito.SelectedIndex = -1;
            this.objPeriodoCredito = null;
            if (this.nCuotas == 1)
                this.nCuotas = 2;
            this._lUnicuota = false;
            this.cboPeriodoCredito.SelectedIndexChanged += this.cboPeriodoCredito_SelectedIndexChanged;

            this.actualizarTipoPeriodo();

            if (ChangeTipoPeriodo != null)
                ChangeTipoPeriodo(sender, e);
        }

        private void cboPeriodoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPeriodoCredito.SelectedIndex == -1)
            {
                this.objPeriodoCredito = null;
                return;
            }
            this.objPeriodoCredito = this.cboPeriodoCredito.lstPeriodoCredito.Find(x=>x.idPeriodoCredito == cboPeriodoCredito.idPeriodoCredito);
            if (this.objPeriodoCredito != null)
            {
                this.nudDia.Value = this.objPeriodoCredito.nDias;
                this.nDias = this.objPeriodoCredito.nDias;
            }

            if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo &&
                Convert.ToInt32(this.cboPeriodoCredito.SelectedValue) == 10) //Unicuota
            {
                this._lUnicuota = true;
            }
            else
            {
                this._lUnicuota = false;
                if (this.nCuotas == 1)
                    this.nCuotas = 2;
            }

            this.actualizarTipoPeriodo();

            if (ChangePeriodo != null)
                ChangePeriodo(sender, e);
        }

        private void nudDia_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudDia.Value.ToString().Length;
            nudDia.Select(0, nLonTex);

            if (EnterDia != null)
                EnterDia(sender, e);
        }

        private void nudDia_Leave(object sender, EventArgs e)
        {
            if (this.idTipoPeriodo ==(int)TipoPeriodo.FechaFija && this.nudDia.Value > 31)
            {
                this.nudDia.Value = 31;
            }
            if (LeaveDia != null)
                LeaveDia(sender, e);
        }

        private void nudDia_ValueChanged(object sender, EventArgs e)
        {
            if (this.ValueChangedDia != null)
                this.ValueChangedDia(sender, e);
        }

        private void ConCreditoPeriodo_Load(object sender, EventArgs e)
        {
            this.cboTipoPeriodo.SelectedIndexChanged -= cboTipoPeriodo_SelectedIndexChanged;
            this.cboPeriodoCredito.SelectedIndexChanged -= cboPeriodoCredito_SelectedIndexChanged;
            this.nudDia.ValueChanged -= nudDia_ValueChanged;

            this._lUnicuota = false;
            this.cboTipoPeriodo.cargarDatos();

            this.cboTipoPeriodo.SelectedIndexChanged += cboTipoPeriodo_SelectedIndexChanged;
            this.cboPeriodoCredito.SelectedIndexChanged += cboPeriodoCredito_SelectedIndexChanged;
            this.nudDia.ValueChanged += nudDia_ValueChanged;
        }
    }
}
