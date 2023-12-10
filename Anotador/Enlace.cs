using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anotador
{
    public partial class Enlace : Form
    {
        public Enlace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = Owner as Form1;
            string Cadena = textBox1.Text;
            string cadena2 = textBox2.Text;
            if (Cadena.Length > 3 && cadena2.Length >3)
            {
                form1.richTextBox1.SelectedText = "<a href=\"" + Cadena + "\">"+cadena2+"</a>";
                Close();
            }
            else
            {
                form1.richTextBox1.SelectedText = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
