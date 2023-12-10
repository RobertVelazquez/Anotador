using System;
using System.Windows.Forms;

namespace Anotador
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = Owner as Form1;
            string division = "div";
            string clase = "class";
            string identidad = "id";
            if (txtId.TextLength > 1)
            {
                form1.richTextBox1.SelectedText = "<" + division + " " + identidad + "=" + "\"" + txtId.Text + "\"" + ">" + "<div>";
            }
            else
            {
                form1.richTextBox1.Update();
            }
            if (txtClass.TextLength > 1)
            {
                form1.richTextBox1.SelectedText = "<" + division + " " + clase + "=" + "\"" + txtClass.Text + "\"" + ">" + "<div>";
            }
            else
            {
                form1.richTextBox1.Update();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
