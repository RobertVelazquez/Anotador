using System;
using System.Windows.Forms;

namespace Anotador
{
    public partial class Lista : Form
    {

        string[] lista = { "<li>", "</li>\n" };
        public Lista()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form1 = Owner as Form1;
            if (form1.richTextBox1.Text.Length > 1)
            {

                form1.richTextBox1.SelectedText = lista[0] + textBox1.Text + lista[1];
            }
            else
            {
                MessageBox.Show("agregue un nombre a la lista");
            }
        }
    }
}
