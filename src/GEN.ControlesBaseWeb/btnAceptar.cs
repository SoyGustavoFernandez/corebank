using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    [ToolboxData("<{0}:btnAceptar runat=server></{0}:btnAceptar>")]
    public class btnAceptar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Aceptar";
            this.CssClass = "btnBase_Aceptar";

            base.Render(writer);
        }
    }
}
    