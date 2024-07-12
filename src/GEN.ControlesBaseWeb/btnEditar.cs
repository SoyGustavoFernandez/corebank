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
    [ToolboxData("<{0}:btnEditar runat=server></{0}:btnEditar>")]
    public class btnEditar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Editar";
            this.CssClass = "btnBase_Editar";
            base.Render(writer);            
        }
    }
}
