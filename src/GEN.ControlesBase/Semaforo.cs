using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class Semaforo : UserControl
    {
        public frmControlLimitesBoveda oControlBoveda { get; set; }
        public Semaforo()
        {
            InitializeComponent();
            this.oControlBoveda = new frmControlLimitesBoveda();
        }
        //solo para ventanilla
        public void ValidarSaldoSemaforo()
        {
            clsCNGenAdmOpe cnSaldo = new clsCNGenAdmOpe();
            DataTable tbSaldo = cnSaldo.RetornaSaldoOperadorAge(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            decimal nSaldoTotal = (decimal)0.00;
           
                if (clsVarGlobal.montoCobertura.idControlTipMon == 1)//se controla en soles(soles +dolar*tipocambio)
                {
                    if (tbSaldo.Rows.Count > 0)
                    {
                        nSaldoTotal = Convert.ToDecimal(tbSaldo.Rows[0]["nSaldoOpe"].ToString());
                    }
                    this.picbox12.Visible = false;
                    this.picBox22.Visible = false;
                    this.picBox32.Visible = false;
                    lblSimbolo.Text = "S/.";
                    lblSimbolo2.Visible = false;
                }
                else if (clsVarGlobal.montoCobertura.idControlTipMon == 2)//se controla en dólares(soles/tipocambio +dolar)
                {
                    if (tbSaldo.Rows.Count > 0)
                    {
                        nSaldoTotal = Convert.ToDecimal(tbSaldo.Rows[0]["nSaldoOpeDol"].ToString());
                    }
                    this.picbox12.Visible = false;
                    this.picBox22.Visible = false;
                    this.picBox32.Visible = false;
                    lblSimbolo.Text = "$";
                    lblSimbolo2.Visible = false;
                }
                else if (clsVarGlobal.montoCobertura.idControlTipMon == 3)//se controla en las dos monedas
                {
                    decimal nSaldoTotalDol = (decimal)0.00;
                    if (tbSaldo.Rows.Count > 0)
                    {
                        nSaldoTotal = Convert.ToDecimal(tbSaldo.Rows[0]["nSalSoles"].ToString());

                        nSaldoTotalDol = Convert.ToDecimal(tbSaldo.Rows[0]["nSalDolar"].ToString());
                    }
                    lblSimbolo.Text = "S/.";
                    lblSimbolo2.Text = "$";
                    lblSimbolo2.Visible = true;
                 
                    if (nSaldoTotalDol <= clsVarGlobal.montoCobertura.nMonMinCoberturaDol)
                    {
                        this.picbox12.Visible = true;
                        this.picBox22.Visible = false;
                        this.picBox32.Visible = false;
                        clsVarGlobal.lFlagPermiteOperacion = true;
                        var colorGreen = System.Drawing.ColorTranslator.FromHtml("#6aba45");
                        lblSimbolo2.BackColor = colorGreen;
                       
                        ttipAletraSemafor2.SetToolTip(this.picbox12, "Se encuentra en el límite permitido");

                    }
                    else if (nSaldoTotalDol <= clsVarGlobal.montoCobertura.nMonIntCoberturaDol && nSaldoTotalDol > clsVarGlobal.montoCobertura.nMonMinCoberturaDol)
                    {
                        this.picbox12.Visible = false;
                        this.picBox22.Visible = true;
                        this.picBox32.Visible = false;
                        clsVarGlobal.lFlagPermiteOperacion = true;
                        var colorYellow = System.Drawing.ColorTranslator.FromHtml("#fcdb00");
                        lblSimbolo2.BackColor = colorYellow;
                        ttipAletraSemafor2.SetToolTip(this.picBox22, "Debe revisar el efectivo de su ventanilla");
                    }
                    else
                    {
                        this.picbox12.Visible = false;
                        this.picBox22.Visible = false;
                        this.picBox32.Visible = true;
                        var colorRed = System.Drawing.ColorTranslator.FromHtml("#e32228");
                        lblSimbolo2.BackColor = colorRed;
                        //Consultar base de datos
                        int lflgPerOpe = Convert.ToInt32(clsVarApl.dicVarGen["lPermiteOpeFueraLimite"]);
                        clsVarGlobal.lFlagPermiteOperacion = Convert.ToBoolean(lflgPerOpe);
                        ttipAletraSemafor2.SetToolTip(this.picBox32, "Ha sobrepasado el límite de cobertura " + cMoneda(2) + " \n Debe habilitar su efectivo...");
                    }
                    ttipAlertaSemaforo.UseAnimation = true;
                    ttipAlertaSemaforo.ToolTipIcon = ToolTipIcon.Info;
                }

            

            if (nSaldoTotal <= clsVarGlobal.montoCobertura.nMonMinCobertura)
            {
                this.picbox1.Visible = true;
                this.picBox2.Visible = false;
                this.picBox3.Visible = false;
                var colorGreen = System.Drawing.ColorTranslator.FromHtml("#6aba45");
                lblSimbolo.BackColor = colorGreen;
                clsVarGlobal.lFlagPermiteOperacion = true;                
                ttipAlertaSemaforo.SetToolTip(this.picbox1, "Se encuentra en el límite permitido");

            }
            else if (nSaldoTotal <= clsVarGlobal.montoCobertura.nMonIntCobertura && nSaldoTotal > clsVarGlobal.montoCobertura.nMonMinCobertura)
            {
                this.picbox1.Visible = false;
                this.picBox2.Visible = true;
                this.picBox3.Visible = false;
                var colorYellow = System.Drawing.ColorTranslator.FromHtml("#fcdb00");
                lblSimbolo.BackColor = colorYellow;
                clsVarGlobal.lFlagPermiteOperacion = true;            
                ttipAlertaSemaforo.SetToolTip(this.picBox2, "Debe revisar el efectivo de su ventanilla");
            }
            else
            {
                this.picbox1.Visible = false;
                this.picBox2.Visible = false;
                this.picBox3.Visible = true;
                var colorRed = System.Drawing.ColorTranslator.FromHtml("#e32228");
                lblSimbolo.BackColor = colorRed;
                //Consultar base de datos
                int lflgPerOpe = Convert.ToInt32(clsVarApl.dicVarGen["lPermiteOpeFueraLimite"]);
                clsVarGlobal.lFlagPermiteOperacion = Convert.ToBoolean(lflgPerOpe);
                if (clsVarGlobal.montoCobertura.idControlTipMon == 3)
                {                 
                    ttipAlertaSemaforo.SetToolTip(this.picBox3, "Ha sobrepasado el límite de cobertura " + cMoneda(1) + " \n Debe habilitar su efectivo...");
                }
                else
                {               
                    ttipAlertaSemaforo.SetToolTip(this.picBox3, "Ha sobrepasado el límite de cobertura \n Debe habilitar su efectivo...");
                }

               
            }
            ttipAlertaSemaforo.UseAnimation = true;
            ttipAlertaSemaforo.ToolTipIcon = ToolTipIcon.Info;
            //ttipAletraSemafor2.UseAnimation = true;
            //ttipAletraSemafor2.ToolTipIcon = ToolTipIcon.Info;

        }
        private string cMoneda(int idMoneda)
        {
            string cMoneda="";
            switch (idMoneda)
            {
                case 1:
                    cMoneda = " en soles";
                    break;
                case 2:
                    cMoneda = " en dólares";
                    break;
                default:
                    break;
            }
            return cMoneda;
        }

        private void Semaforo_Load(object sender, EventArgs e)
        {

        }

        private void picbox1_Click(object sender, EventArgs e)
        {
            int durationMilliseconds = 5000;
            ttipAlertaSemaforo.Show(ttipAlertaSemaforo.GetToolTip(picbox1), picbox1, durationMilliseconds);
        }

        private void picbox12_Click(object sender, EventArgs e)
        {
            int durationMilliseconds = 5000;
            ttipAletraSemafor2.Show(ttipAletraSemafor2.GetToolTip(picbox12), picbox12, durationMilliseconds);
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            int durationMilliseconds = 5000;
            ttipAlertaSemaforo.Show(ttipAlertaSemaforo.GetToolTip(picBox2), picBox2, durationMilliseconds);
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            int durationMilliseconds = 5000;
            ttipAlertaSemaforo.Show(ttipAlertaSemaforo.GetToolTip(picBox3), picBox3, durationMilliseconds);
        }

        private void picBox22_Click(object sender, EventArgs e)
        {
            int durationMilliseconds = 5000;
            ttipAletraSemafor2.Show(ttipAletraSemafor2.GetToolTip(picBox22), picBox22, durationMilliseconds);
        }

        private void picBox32_Click(object sender, EventArgs e)
        {
            int durationMilliseconds = 5000;
            ttipAletraSemafor2.Show(ttipAletraSemafor2.GetToolTip(picBox32), picBox32, durationMilliseconds);
        }

    }
}
