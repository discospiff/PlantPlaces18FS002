using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class Math : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSum_Click(object sender, EventArgs e)
        {
            Calculator.CalculatorSoapClient calcualtor = new Calculator.CalculatorSoapClient("CalculatorSoap");
            string number1 = Number1.Text;
            int intNumber1 = Convert.ToInt32(number1);
            string number2 = Number2.Text;
            int intNumber2 = Convert.ToInt32(number2);

            int sum = calcualtor.Add(intNumber1, intNumber2);

            LblSum.Text = "" + sum;
        }
    }
}