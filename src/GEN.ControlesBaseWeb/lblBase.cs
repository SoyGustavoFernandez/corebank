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
     [System.Drawing.ToolboxBitmap(typeof(Label))]
    [ToolboxData("<{0}:lblBase runat=server></{0}:lblBase>")]
    public class lblBase : Label
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.CssClass = "lblBase";
        }
    }
 }