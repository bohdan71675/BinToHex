using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinToHex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string BinToHex(string bin)
        {

            StringBuilder binary = new StringBuilder(bin);
            bool isNegative = false;
            if (binary[0] == '-')
            {
                isNegative = true;
                binary.Remove(0, 1);
            }

            for (int i = 0, length = binary.Length; i < (4 - length % 4) % 4; i++)
            {
                binary.Insert(0, '0');
            }

            StringBuilder hexadecimal = new StringBuilder();
            StringBuilder word = new StringBuilder("0000");
            for (int i = 0; i < binary.Length; i += 4)
            {
                for (int j = i; j < i + 4; j++)
                {
                    word[j % 4] = binary[j];
                }

                switch (word.ToString())
                {
                    case "0000": hexadecimal.Append('0'); break;
                    case "0001": hexadecimal.Append('1'); break;
                    case "0010": hexadecimal.Append('2'); break;
                    case "0011": hexadecimal.Append('3'); break;
                    case "0100": hexadecimal.Append('4'); break;
                    case "0101": hexadecimal.Append('5'); break;
                    case "0110": hexadecimal.Append('6'); break;
                    case "0111": hexadecimal.Append('7'); break;
                    case "1000": hexadecimal.Append('8'); break;
                    case "1001": hexadecimal.Append('9'); break;
                    case "1010": hexadecimal.Append('A'); break;
                    case "1011": hexadecimal.Append('B'); break;
                    case "1100": hexadecimal.Append('C'); break;
                    case "1101": hexadecimal.Append('D'); break;
                    case "1110": hexadecimal.Append('E'); break;
                    case "1111": hexadecimal.Append('F'); break;
                    default:
                        return "Invalid number";
                }
            }

            if (isNegative)
            {
                hexadecimal.Insert(0, '-');
            }



            return hexadecimal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string bin = textBox1.Text;
            MessageBox.Show(BinToHex(bin));

        }
    }
}
