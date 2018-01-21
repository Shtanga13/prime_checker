using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeChecker
{

    public partial class Form1 : Form
    {
        private string tb2, tb3;
        public Form1()
        {
            InitializeComponent();
        }
        private void CleanTextFields()
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            CleanTextFields();
            if (long.TryParse(textBox1.Text, out long a))
            {
                Number n = new Number
                {
                    value = long.Parse(textBox1.Text)
                };
                n.prime = n.CheckPrime(N: n.value);
                if(n.prime)
                {
                    textBox3.Visible = false;
                    tb2 = String.Format("The number {0} is prime.", n.value);
                    textBox2.Text = tb2;
                }
                else
                { 
                    if(checkBox1.Checked)
                    {
                        textBox3.Visible = true;
                        List<long> fac = new List<long>();
                        for (long h = 2; h < n.value; h++)
                        {
                            if (n.value % h == 0)
                            {
                                fac.Add(h);
                            }
                        }
                        n.factorsList = fac.ToArray();
                        textBox2.Text = String.Format("The number {0} is not prime. ", n.value);
                        tb3 = "Factors: ";
                        for(int i = 0; i < n.factorsList.Length; i++)
                        {
                            tb3 += n.factorsList[i];
                            if (i != n.factorsList.Length - 1)
                            {
                                tb3 += ", ";
                            }
                            else
                            {
                                tb3 += ".";
                            }
                        }
                        textBox3.Text = tb3;
                    }
                    else
                    {
                        textBox3.Visible = false;
                        tb2 = String.Format("The number {0} is not prime.", n.value);
                        textBox2.Text = tb2;
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a whole number!","Wrong input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public class Number
    {
        public long value;
        public int numberFactors;
        public bool prime;
        public long[] factorsList;
        public bool CheckPrime(long N)
        {
            if (N == 0)
            {
                this.prime = false;
            }
            if (N == 1)
            {
                this.prime = false;
            }

            if (N == 2)
            {
                this.prime = true;
            }
            if (N == 3)
            {
                this.prime = true;
            }
            this.prime = true;
            for (int a = 2; a <= Math.Sqrt(N); a++)
            {
                if (N % a == 0)
                {
                    this.prime = false;
                    break;
                }
            }
            return this.prime;
        }
    }
}
