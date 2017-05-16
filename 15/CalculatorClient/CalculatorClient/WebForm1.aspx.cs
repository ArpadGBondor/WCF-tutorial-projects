using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            int numerator = Convert.ToInt32(txtNumerator.Text);
            int denominator = Convert.ToInt32(txtDenominator.Text);
            CalculatorService.CalculatorServiceClient client =
                new CalculatorService.CalculatorServiceClient();
            lblResult.Text = client.Divide(numerator, denominator).ToString();
        }
    }
}