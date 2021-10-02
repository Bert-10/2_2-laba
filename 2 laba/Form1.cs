using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.s.ToString();
            textBox3.Text = Properties.Settings.Default.n.ToString();
            textBox2.Text = Properties.Settings.Default.outText.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             int n,a;
             string s,outText;
            try
            {
                 n = int.Parse(textBox3.Text);
                 s = textBox1.Text;
                 string[] subs = s.Split(' ');
                for(int i = 0; i < subs.Length; i++)
                {
                    a = int.Parse(subs[i]);
                }
            }
            catch (FormatException)
            {
                // сообщение об ошибке
                MessageBox.Show("Некорректный ввод. В первое поле можно вводить только числа и пробелы между ними (в конце и в начале пробелы запрещены). Во второе поле можно вводить только одно число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                return; // а затем прерываем обработчик
            }
           
            outText= Logic.Compare(n,s);
            textBox2.Text = outText;
            //----
            Properties.Settings.Default.s = s;
            Properties.Settings.Default.n = n;
            Properties.Settings.Default.outText = outText;
            Properties.Settings.Default.Save();
            //----
        }

        private void button2_Click(object sender, EventArgs e)
        {
              textBox1.Text ="";
              textBox2.Text ="";
              textBox3.Text ="";

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox3.Focus();
               // button2_Click;
            }
        }

    }


    public class Logic
    {
        public static string Compare(int n,string s)
        {
            string outText="";
            string[] subs = s.Split(' ');
            int count;
            //создаём массив для хранения индексов элементов
            int[] arr = new int[n];
            /*перебираем массив цикл идёт до subs.Length-n+1 поскольку в дальнейшем будет
             * ещё один цикл for в котором будет веститсь перебор дальше. subs.Length-n+1
             * позволяет избежать выхода за пределы массива
             * */
            for (int i = 0; i < subs.Length - n + 1; i++)
            {
                count = 0;

                for (int j = i; j < n + i - 1; j++)
                {
                    if (subs[j] == subs[j + 1])
                    {

                        arr[count] = j;
                        count++;

                        if (j == n + i - 2)
                        {
                            arr[count] = j + 1;
                        }

                    }
                }
                if (count + 1 == n)
                { 

                    foreach (int t in arr)
                    {
                        outText = outText + t + " ";
                    }
                    break;
                }
            }

            if (arr[n - 1] == 0)
            {
                outText="Возможных пар не обнаружено";
            }

            return outText;
        }           
        
    }
}