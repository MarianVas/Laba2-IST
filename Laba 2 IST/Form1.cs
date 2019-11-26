using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2_IST
{
    public partial class Form1 : Form
    {
        const int K = 3;
        const int R = 5;
        static int N = K + R;
        int[] numb = new int[K];
        int[,] arr = new int[2, R] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        int[] mas = new int[N];
        string temp;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // <generic>
        {
            textBox1.Clear();
            Random rand = new Random();
            for (int i = 0; i < K; i++)
            {
                numb[i] = rand.Next(0, 2);
                textBox1.Text += numb[i] + "\t";


            }
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < R; j++)
                    arr[i, j] = 0;
        }

        private void button2_Click(object sender, EventArgs e)  // <coder>
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < R; j++)
                    arr[i, j] = 0;

            textBox2.Clear();
            for (int i = 0; i < 3; i++)
            {
                arr[1, 0] = arr[0, 4] ^ numb[i];
                textBox2.Text += arr[1, 0];

                arr[1, 1] = arr[0, 0] ^ arr[1, 0];
                textBox2.Text += arr[1, 1];

                arr[1, 2] = arr[0, 1];
                textBox2.Text += arr[1, 2];

                arr[1, 3] = arr[0, 2];
                textBox2.Text += arr[1, 3];

                arr[1, 4] = arr[0, 3] ^ arr[1, 0];
                textBox2.Text += arr[1, 4];

                arr = arr_copy(arr);
                textBox2.Text += "\n";
            }
        }

        int[,] arr_copy(int[,] arr)
        {
            for (int i = 0; i < 4; i++)
                arr[0, i] = arr[1, i];
            return arr;
        }

        private void button3_Click(object sender, EventArgs e) // <get data>
        {
            textBox3.Clear();
            int j = 0;

            for (int i = 0; i < K; i++)
            {
                textBox3.Text += numb[i] + "\t";
                mas[j++] = numb[i];
            }
            for (int i = R - 1; i >= 0; i--)
            {
                textBox3.Text += arr[1, i] + "\t";
                mas[j++] = arr[1, i];
            }
        }

        private void button4_Click(object sender, EventArgs e) // <decoder>
        {
            int step = 0;
            int zero = 0;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < R; j++)
                    arr[i, j] = 0;
            textBox4.Clear();

            for (int i = 0; i < N; i++)
            {
                step++;
                arr[1, 0] = mas[i] ^ arr[0, 4];
                textBox4.Text += arr[1, 0];

                arr[1, 1] = arr[1, 0] ^ arr[0, 0];
                textBox4.Text += arr[1, 1];

                arr[1, 2] = arr[0, 1];
                textBox4.Text += arr[1, 2];

                arr[1, 3] = arr[0, 2];
                textBox4.Text += arr[1, 3];

                arr[1, 4] = arr[0, 3] ^ arr[0, 4];
                textBox4.Text += arr[1, 4];

                arr = arr_copy(arr);
                textBox4.Text += "\n";
            }
            //-------------------------------------------------------
            while (true)
            {
                if (arr[1, 0] == 0 && arr[1, 1] == 0 && arr[1, 2] == 0 && arr[1, 3] == 0 && step == 0)
                {
                    label12.Text = "DATA CORRECT!!! \n";
                    break;
                }
                else
                {
                    step++;
                    arr[1, 0] = zero ^ arr[0, 4];
                    textBox4.Text += arr[1, 0];

                    arr[1, 1] = arr[1, 0] ^ arr[0, 0];
                    textBox4.Text += arr[1, 1];

                    arr[1, 2] = arr[0, 1];
                    textBox4.Text += arr[1, 2];

                    arr[1, 3] = arr[0, 2];
                    textBox4.Text += arr[1, 3];

                    arr[1, 4] = arr[0, 3] ^ arr[0, 4];
                    textBox4.Text += arr[1, 4];

                    arr = arr_copy(arr);
                    textBox4.Text += "\n";

                    if ((arr[1, 0] == 1 && arr[1, 1] == 0 && arr[1, 2] == 0 && arr[1, 3] == 0) && step != 0)
                    {
                        label13.Text = "BUG IN " + step + " BIT";
                        if (mas[step - 1] == 0) mas[step - 1] = 1;
                        else mas[step - 1] = 0;
                        break;
                    }
                    if (step <= 60)
                    {
                        break;
                    }
                }
            }
            label14.Text = "Message: ";
            temp = "";
                for(int i = 0; i < K; i++)
                {
                    temp += mas[i];
                }
                label15.Text = temp;
            
        }

        private void button5_Click(object sender, EventArgs e) // <bug>
        {
            Random rand = new Random();
            int bit = rand.Next(0, N - 1);

            if (mas[bit] == 0) mas[bit] = 1;
            else mas[bit] = 0;
            label12.Text = "bug in " + (bit + 1) + "\n";

            textBox4.Clear();
            textBox3.Clear();
            for (int i = 0; i < N; i++)
            {
                textBox3.Text += mas[i] + "\n";
            }
        }
    }

}
