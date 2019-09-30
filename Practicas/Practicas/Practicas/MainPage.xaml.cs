using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Practicas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public double result1 = 0, result2 = 0;
        public bool action = false;
        public string prevOp = "";
        public MainPage()
        {
            InitializeComponent();
        }

        void OnClicked(object sender, EventArgs e)
        {
            double value = Convert.ToDouble((((Button)sender).Text).ToString());
            if (!action)
            {
                result1 *= 10;
                result1 += value;
                ResultSpan.Text = result1.ToString();
            }
            else
            {
                result2 *= 10;
                result2 += value;
                ResultSpan.Text = result2.ToString();
            }
        }

        void OnOperatorClicked(object sender, EventArgs e)
        {
            string op = ((Button)sender).Text;
            action = true;
            if (!op.Contains("+") && !op.Contains("-") && !op.Contains("/") && !op.Contains("="))
            {
                op = "x";
            }
            ResultSpan.Text = "0";
            if (op == "=")
            {
                if (prevOp == "+")
                    ResultSpan.Text = (result1 + result2).ToString();
                else if (prevOp == "x")
                    ResultSpan.Text = (result1 * result2).ToString();
                else if (prevOp == "-")
                    ResultSpan.Text = (result1 - result2).ToString();
                else 
                {
                    if(result2 != 0)
                        ResultSpan.Text = (result1 / result2).ToString();
                }


                action = false;
                result1 = Convert.ToDouble(ResultSpan.Text);
                result2 = 0;

            }
            prevOp = op;
           
        }

        void OnClearClicked(object sender, EventArgs e)
        {
            result1 = 0;
            result2 = 0;
            ResultSpan.Text = "0";
        }
    }
}
