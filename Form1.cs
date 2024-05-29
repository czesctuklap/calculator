using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        double result = 0;
        double x = 0;
        double y = 0;
        string operation = "";
        bool isClicked = false;
        bool error = false;
        bool ummidk = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Comma_Click(object sender, EventArgs e)
        {
            if (!TextBox.Text.Contains(","))
            {
                TextBox.Text += ",";
            }

            if (error)
            {
                Clear.PerformClick();
                error = false;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!ummidk)
            {
                if (result != 0)
                {
                    Equals.PerformClick();
                    operation = button.Text;
                    //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                    //TextBox.Text = result.ToString() + " " + operation;
                    isClicked = true;
                    }

                if (error)
                {
                    Clear.PerformClick();
                    error = false;
                }

                else
                {
                    operation = button.Text;
                    result = Double.Parse(TextBox.Text);
                    //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                    //TextBox.Text = result.ToString() + " " + operation;
                    isClicked = true;
                }

                ummidk = true;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == "0" || isClicked || error)
            {
                TextBox.Clear();
                error = false;
            }

            Button button = (Button)sender;
            TextBox.Text += button.Text;
            isClicked = false;
            ummidk = false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            TextBox.Text = "0";
            result = 0;
            error = false;
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            if (error)
            {
                Clear.PerformClick();
                error = false;
                //return;
            }

            x = result;
            y = double.Parse(TextBox.Text);

            switch (operation) 
            {
                case "➕":
                    TextBox.Text = (x + y).ToString();
                    result = Double.Parse(TextBox.Text);
                    break;

                case "➖":
                    TextBox.Text = (x - y).ToString();
                    result = Double.Parse(TextBox.Text);
                    break;

                case "✖":
                    TextBox.Text = (x * y).ToString();
                    result = Double.Parse(TextBox.Text);
                    break;

                case "➗":
                    if (Double.TryParse(TextBox.Text, out y) && y != 0)
                    {
                        TextBox.Text = (x / y).ToString();
                        result = Double.Parse(TextBox.Text);
                        break;
                    }

                    else
                    {
                        TextBox.Text = "error";
                        result = 0;
                        error = true;
                        break;
                    }

                default:
                    result = Double.Parse(TextBox.Text);
                    break;
            }
        }
    }
}
