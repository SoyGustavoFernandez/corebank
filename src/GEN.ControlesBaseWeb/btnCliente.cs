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
    [ToolboxData("<{0}:btnCliente runat=server></{0}:btnCliente>")]
    public class btnCliente : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Cliente";
            this.CssClass = "btnBase_Cliente";
            base.Render(writer);
        }
    }
}

