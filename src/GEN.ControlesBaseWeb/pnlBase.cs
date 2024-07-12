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
    [System.Drawing.ToolboxBitmap(typeof(Panel))]
    [ToolboxData("<{0}:pnlBase runat=server></{0}:pnlBase>")]
    public class pnlBase : Panel
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.CssClass = "panel panel-default";
        }
    }
}