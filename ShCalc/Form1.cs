using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Илтимос факат ракам дароред!");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Илтимос факат ракам дароред!");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text,"[^0-9]"))
            {
                MessageBox.Show("Илтимос факат ракам дароред!");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        double loan_Summa, term_Month, persent, persentGetMonth;
        double total_amount, total_percentage, total_all_amount, persent_part, total_month_pay;
        double dolgovaya_chast, ostatok_month;
        private void button2_Click(object sender, EventArgs e)
        {
            Cleare();

            GetInputNumber();

            persentGetMonth = persent / 12 / 100;

            total_month_pay = (float)(loan_Summa * (persentGetMonth + (persentGetMonth / (Math.Pow(1 + persentGetMonth, term_Month) - 1))));

            for (int i = 1; i <= term_Month; i++)
            {
                persent_part = loan_Summa * persentGetMonth; 
                dolgovaya_chast = total_month_pay - persent_part;
                ostatok_month = loan_Summa - dolgovaya_chast;

                UseIf();

                UseRound();

                dataGridView1.Rows.Add(i, loan_Summa, total_month_pay, persent_part, dolgovaya_chast,ostatok_month);

                loan_Summa = ostatok_month;

                CalcTotal();
            }
            PrintTotal();
        }

        private void Cleare()
        {
            dataGridView1.Rows.Clear();

            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }
        private void PrintTotal()
        {
            label5.Text = total_amount.ToString();
            label6.Text = total_percentage.ToString();
            label7.Text = total_all_amount.ToString();
        }
        private void UseRound()
        {
            loan_Summa = Math.Round(loan_Summa, 2);
            total_month_pay = Math.Round(total_month_pay, 2);
            persent_part = Math.Round(persent_part, 2);
            dolgovaya_chast = Math.Round(dolgovaya_chast, 2);
            ostatok_month = Math.Round(ostatok_month, 2);
        }
        private void CalcTotal()
        {
            total_amount += total_month_pay;
            total_percentage += persent_part;
            total_all_amount += dolgovaya_chast;
        }
        private void GetInputNumber()
        {
            loan_Summa = int.Parse(textBox1.Text);
            term_Month = int.Parse(textBox2.Text);
            persent = int.Parse(textBox3.Text);
        }
        private void UseIf()
        {
            if (ostatok_month <= 0)
            {
                ostatok_month = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

    }
}
