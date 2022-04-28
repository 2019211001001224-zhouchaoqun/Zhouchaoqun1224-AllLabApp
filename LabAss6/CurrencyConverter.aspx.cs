using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabAss6
{
    public partial class CurrencyConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        double function(string tb)
        {
            double b = Convert.ToDouble(tb);          
            return 0.15*b;
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            string tb = TextBox1.Text;
            TextBox1.Text = function(tb).ToString();
        }
    }
}