using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    [System.Drawing.ToolboxBitmap(typeof(TextBox))]
    [ToolboxData("<{0}:txtNumerico runat=server></{0}:txtNumerico>"), DefaultProperty("nDecimales")]
    public class txtNumerico : TextBox
    {
        private int mDecimalPlaces = 0;
        private char mDecimalSymbol = '.';
        private bool mAllowNegatives = true;

        /// <summary>
        /// Obtiene o establece el número de decimales para el cuadro de número.
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue(0), Description("Indica el número de decimales a mostrar.")]
        public virtual int nDecimales
        {
            get { return mDecimalPlaces; }
            set { mDecimalPlaces = value; }
        }

        /// <summary>
        /// Obtiene o establece el símbolo de agrupamiento de dígitos para el cuadro de número.
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("."), Description("El símbolo de agrupación de dígitos.")]
        public virtual char cSimboloDecimal
        {
            get { return mDecimalSymbol; }
            set { mDecimalSymbol = value; }
        }

        /// <summary>
        /// Obtiene o establecesi están permitidos los números negativos en el cuadro de número.
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue(true), Description("True cuando los valores negativos se permiten")]
        public virtual bool lPermiteNegativos
        {
            get { return mAllowNegatives; }
            set { mAllowNegatives = value; }
        }

        /// <summary>
        /// Obtiene o establece el valor del cuadro de número.
        /// </summary>
        public virtual Decimal nValor
        {
            get
            {
                try
                {
                    return ParseStringToDecimal (this.Text);
                }
                catch (FormatException e)
                {
                    throw new
                    InvalidOperationException(e.Message);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            set
            {
                if ((value < 0) & !lPermiteNegativos)
                    throw new
                        ArgumentOutOfRangeException("Sólo se permiten valores positivos para este NumberBox");

                //base.Text = value.ToString(this.Format);
                base.Text = value.ToString(GetFormat()).Replace(".", cSimboloDecimal.ToString());
            }
        }

        /// <summary>
        /// Obtiene o establece el contenido de texto del cuadro de número.
        /// </summary>
        override public string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                try
                {
                    this.nValor = ParseStringToDecimal (value);
                }
                catch (FormatException e)
                {
                    base.Text = value;
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// agrega un JavaScript en la página y llama al evento onKeyPress del form
        /// </summary>
        /// <param name="e"></param>
        override protected void OnPreRender(EventArgs e)
        {
            if (this.Page.Request.Browser.JavaScript == true)
            {
                // Build JavaScript		
                StringBuilder s = new StringBuilder();
                s.Append("\n<script type='text/javascript' language='JavaScript'>\n");
                s.Append("<!--\n");
                s.Append("    function NumberBoxKeyPress(event, dp, dc, n) {\n");
                s.Append("	     var myString = new String(event.srcElement.value);\n");
                s.Append("	     var pntPos = myString.indexOf(String.fromCharCode(dc));\n");
                s.Append("	     var keyChar = window.event.keyCode;\n");
                s.Append("       if ((keyChar < 48) || (keyChar > 57)) {\n");
                s.Append("          if (keyChar == dc) {\n");
                s.Append("              if ((pntPos != -1) || (dp < 1)) {\n");
                s.Append("                  return false;\n");
                s.Append("              }\n");
                s.Append("          } else \n");
                s.Append("if (((keyChar == 45) && (!n || myString.length != 0)) || (keyChar != 45)) \n");
                s.Append("		     return false;\n");
                s.Append("       }\n");
                s.Append("       return true;\n");
                s.Append("    }\n");
                s.Append("// -->\n");
                s.Append("</script>\n");

                // Add the Script to the Page
                //this.Page.RegisterClientScriptBlock("NumberBoxKeyPress", s.ToString());
                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "NumberBoxKeyPress", s.ToString());
                
                // Add KeyPress Event
                try
                {
                    this.Attributes.Remove("onKeyPress");
                }
                finally
                {
                    this.Attributes.Add("onKeyPress", "return NumberBoxKeyPress(event, "
                        + nDecimales.ToString() + ", "
                        + ((int)cSimboloDecimal).ToString() + ", "
                        + lPermiteNegativos.ToString().ToLower() + ")");
                }
            }
        }

        /// <summary>
        /// Retorna  RegularExpression string que se puede utilizar para validar
        /// usando un RegularExpressionValidator.
        /// </summary>
        virtual public string ValidationRegularExpression
        {
            get
            {
                StringBuilder regexp = new StringBuilder();

                if (lPermiteNegativos)
                    regexp.Append("([-]|[0-9])");

                regexp.Append("[0-9]*");

                if (nDecimales > 0)
                {
                    regexp.Append("([");
                    regexp.Append(cSimboloDecimal);
                    regexp.Append("]|[0-9]){0,1}[0-9]{0,");
                    regexp.Append(nDecimales.ToString());
                    regexp.Append("}$");
                }

                return regexp.ToString();
            }
        }

        /// <summary>
        /// Convierte un String a un Decimal /*era double*/
        /// </summary>
        /// <param name="s">string a ser convertido a un Decimal</param>
        /// <returns>Decimal value</returns>
        virtual protected Decimal ParseStringToDecimal (string s)
        {
            s = s.Replace(cSimboloDecimal.ToString(), ".");
            Decimal nVal=0;
            var lValido = Decimal.TryParse(s,out nVal);
            if (lValido)
            {
                return Decimal.Parse(s);                
            }
            else
            {
                return 0;
            }
          
        }

        /// <summary>
        /// Retorna el FormatString usado para mostrar el valor en el cuadro de número.
        /// </summary>
        /// <returns>Format string</returns>
        virtual protected string GetFormat()
        {
            StringBuilder f = new StringBuilder();
            f.Append("0");
            if (nDecimales > 0)
            {
                f.Append(".");
                f.Append('0', nDecimales);
            }

            return f.ToString();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.CssClass = "form-control";
            base.Render(writer);
        }
    }
}
