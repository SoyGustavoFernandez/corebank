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
    [ToolboxData("<{0}:btnContinuar runat=server></{0}:btnContinuar>")]
    public class btnContinuar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Continuar";
            this.CssClass = "btnBase_Continuar";
            base.Render(writer);
        }
    }
}
